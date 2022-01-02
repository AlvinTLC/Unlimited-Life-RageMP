using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using UNL.SDK;

namespace ULife.Core
{
    class SafeZones : Script
    {
        private static nLog Log = new nLog("SafeZones");
        public static void CreateSafeZone(Vector3 position, int height, int width)
        {
            var colShape = NAPI.ColShape.Create2DColShape(position.X, position.Y, height, width, 0);
            colShape.OnEntityEnterColShape += (shape, player) =>
            {
                try
                {
                    Trigger.ClientEvent(player, "safeZone", true);
                }
                catch (Exception e) { Log.Write($"SafeZoneEnter: {e.Message}", nLog.Type.Error); }

            };
            colShape.OnEntityExitColShape += (shape, player) =>
            {
                try
                {
                    Trigger.ClientEvent(player, "safeZone", false);
                }
                catch (Exception e) { Log.Write($"SafeZoneExit: {e.Message}", nLog.Type.Error); }
            };
        }

        [ServerEvent(Event.ResourceStart)]
        public void Event_onResourceStart()
        {
            CreateSafeZone(new Vector3(-539.32446, -214.53189, 36.5298), 70, 70); // CityHall safe zone
            CreateSafeZone(new Vector3(-242.02869, -921.382, 31.192179), 70, 70); //JobCenter safe zone
            CreateSafeZone(new Vector3(299.0108, -584.4722, 42.140835), 70, 70); // EMS safe zone
        }
    }
}
