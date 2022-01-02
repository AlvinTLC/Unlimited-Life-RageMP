using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using UNL.SDK;

namespace ULife.Core
{
    class Doormanager : Script
    {
        private static nLog Log = new nLog("Doormanager");

        [ServerEvent(Event.ResourceStart)]
        public void onResourceStart()
        {
            try
            {
                //X:266,3624 Y:217,5697 Z:110,4328

                RegisterDoor(-1246222793, new Vector3(0, 0, 0)); // pacific standart staff door
                SetDoorLocked(0, false, 0);

                RegisterDoor(1956494919, new Vector3(0, 0, 0)); // pacific standart staff door
                SetDoorLocked(1, false, 0);

                RegisterDoor(961976194, new Vector3(255.2283, 223.976, 102.3932)); // safe door 
                SetDoorLocked(2, true, 0);

                RegisterDoor(110411286, new Vector3(232.6054, 214.1584, 106.4049)); // pacific standart main door 1
                SetDoorLocked(3, false, 0);

                RegisterDoor(110411286, new Vector3(231.5123, 216.5177, 106.4049)); // pacific standart main door 2
                SetDoorLocked(4, false, 0);

                RegisterDoor(631614199, new Vector3(461.8065, -997.6583, 25.06443)); // police prison door
                SetDoorLocked(5, true, 0);

                RegisterDoor(1335309163, new Vector3(260.6518, 203.2292, 106.4328)); // pacific exit door
                SetDoorLocked(6, false, 0);

                RegisterDoor(1335309163, new Vector3(258.2093, 204.119, 106.4328)); // pacific exit door 2
                SetDoorLocked(7, false, 0);

                RegisterDoor(67239936, new Vector3(434.7444, -980.7556, 30.8153)); // pacific exit door 2
                SetDoorLocked(8, true, 0);

                RegisterDoor(67239936, new Vector3(434.7444, -983.0781, 30.8153)); // pacific exit door 2
                SetDoorLocked(9, true, 0);

                NAPI.World.DeleteWorldProp(1765048490, new Vector3(1855.685, 3683.93, 34.59282), 30f); //Офис Шерифа, Сенди Шорс
                NAPI.World.DeleteWorldProp(543652229, new Vector3(321.8085, 178.3599, 103.6782), 30f); //Офис Шерифа, Сенди Шорс*/
            }
            catch (Exception e) { Log.Write("ResourceStart: " + e.Message, nLog.Type.Error); }
        }

        private static List<Door> allDoors = new List<Door>();
        public static int RegisterDoor(int model, Vector3 Position)
        {
            allDoors.Add(new Door(model, Position));
            var col = NAPI.ColShape.CreateCylinderColShape(Position, 5, 5, 0);
            col.SetData("DoorID", allDoors.Count - 1);
            col.OnEntityEnterColShape += Door_onEntityEnterColShape;
            return allDoors.Count - 1;
        }

        private static void Door_onEntityEnterColShape(ColShape shape, Player entity)
        {
            try
            {
                if (NAPI.Entity.GetEntityType(entity) != EntityType.Player) return;
                var door = allDoors[shape.GetData<int>("DoorID")];
                Trigger.ClientEvent(entity, "setDoorLocked", door.Model, door.Position.X, door.Position.Y, door.Position.Z, door.Locked, door.Angle);
            }
            catch (Exception e) { Log.Write("Door_onEntityEnterColshape: " + e.ToString(), nLog.Type.Error); }
        }

        public static void SetDoorLocked(int id, bool locked, float angle)
        {
            if (allDoors.Count < id + 1) return;
            allDoors[id].Locked = locked;
            allDoors[id].Angle = angle;
            Main.ClientEventToAll("setDoorLocked", allDoors[id].Model, allDoors[id].Position.X, allDoors[id].Position.Y, allDoors[id].Position.Z, allDoors[id].Locked, allDoors[id].Angle);
        }

        public static bool GetDoorLocked(int id)
        {
            if (allDoors.Count < id + 1) return false;
            return allDoors[id].Locked;
        }

        internal class Door
        {
            public Door(int model, Vector3 position)
            {
                Model = model;
                Position = position;
                Locked = false;
                Angle = 50.0f;
            }

            public int Model { get; set; }
            public Vector3 Position { get; set; }
            public bool Locked { get; set; }
            public float Angle { get; set; }
        }
    }
}
