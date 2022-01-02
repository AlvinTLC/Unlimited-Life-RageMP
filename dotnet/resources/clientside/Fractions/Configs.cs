using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GTANetworkAPI;
using ULife.Core;
using Newtonsoft.Json;
using UNL.SDK;

namespace ULife.Fractions
{
    class Configs : Script
    {
        private static nLog Log = new nLog("FractionConfigs");
        public static Dictionary<int, Dictionary<string, Tuple<string, Vector3, Vector3, int, int, int, VehicleManager.VehicleCustomization>>> FractionVehicles = new Dictionary<int, Dictionary<string, Tuple<string, Vector3, Vector3, int, int, int, VehicleManager.VehicleCustomization>>>();
        public static Dictionary<int, string> FractionTypes = new Dictionary<int, string>()
        {
            { 1, "FAMILY" },
            { 2, "BALLAS" },
            { 3, "VAGOS" },
            { 4, "MARABUNTA" },
            { 5, "BLOOD" },
            { 6, "CITY" },
            { 7, "POLICE" },
            { 8, "EMS" },
            { 9, "FIB" },
            { 10, "LCN" },
            { 11, "RUSSIAN" },
            { 12, "YAKUZA" },
            { 13, "ARMENIAN" },
            { 14, "ARMY" },
            { 15, "LSNEWS" },
            { 16, "THELOST" },
            { 17, "MERRYWEATHER" },
            { 18, "USMS" },
            { 19, TuningMan.Name },
            { 20, "ACLS" },
        };
        // fractionid - ranknumber - rankname, rankclothes
        public static Dictionary<int, Dictionary<int, Tuple<string, string, string, int>>> FractionRanks = new Dictionary<int, Dictionary<int, Tuple<string, string, string, int>>>();
        // fractionid - commandname, minrank
        public static Dictionary<int, Dictionary<string, int>> FractionCommands = new Dictionary<int, Dictionary<string, int>>();
        // fractionid - commandname, minrank
        public static Dictionary<int, Dictionary<string, int>> FractionWeapons = new Dictionary<int, Dictionary<string, int>>();
        public static void LoadFractionConfigs()
        {
            #region loadconfigstodb
            
            #endregion
            for (int i = 1; i <= 20; i++)
                FractionVehicles.Add(i, new Dictionary<string, Tuple<string, Vector3, Vector3, int, int, int, VehicleManager.VehicleCustomization>>());
            for (int i = 1; i <= 20; i++)
                FractionRanks.Add(i, new Dictionary<int, Tuple<string, string, string, int>>());
            for (int i = 1; i <= 20; i++)
                FractionCommands.Add(i, new Dictionary<string, int>());
            for (int i = 1; i <= 20; i++)
                FractionWeapons.Add(i, new Dictionary<string, int>());

            // loading fraction vehicle configs and spawn
            DataTable result = MySQL.QueryRead("SELECT * FROM `fractionvehicles`");
            if (result == null || result.Rows.Count == 0) return;
            foreach (DataRow Row in result.Rows)
            {
                var fraction = Convert.ToInt32(Row["fraction"]);
                var number = Row["number"].ToString();
                //var model = (VehicleHash)NAPI.Util.GetHashKey(Row["model"].ToString());
                //var model = NAPI.Util.VehicleNameToModel(Row["model"].ToString()); // Добавлено
                var model = Row["model"].ToString();
                var position = JsonConvert.DeserializeObject<Vector3>(Row["position"].ToString());
                var rotation = JsonConvert.DeserializeObject<Vector3>(Row["rotation"].ToString());
                var minrank = Convert.ToInt32(Row["rank"]);
                var color1 = Convert.ToInt32(Row["colorprim"]);
                var color2 = Convert.ToInt32(Row["colorsec"]);
                VehicleManager.VehicleCustomization components = JsonConvert.DeserializeObject<VehicleManager.VehicleCustomization>(Row["components"].ToString());

                FractionVehicles[fraction].Add(number, new Tuple<string, Vector3, Vector3, int, int, int, VehicleManager.VehicleCustomization>(model, position, rotation, minrank, color1, color2, components));
            }

            CarSpawner.Init(); // Fraction Vehicles Spawner Init

            //foreach (var fraction in FractionVehicles.Keys)
            //SpawnFractionCars(fraction);

            // load fraction ranks configs
            result = MySQL.QueryRead("SELECT * FROM `fractionranks`");
            if (result == null || result.Rows.Count == 0) return;
            foreach (DataRow Row in result.Rows)
            {
                var fraction = Convert.ToInt32(Row["fraction"]);
                var rank = Convert.ToInt32(Row["rank"]);
                var payday = Convert.ToInt32(Row["payday"]);
                var name = Row["name"].ToString();
                var clothesm = Row["clothesm"].ToString();
                var clothesf = Row["clothesf"].ToString();

                FractionRanks[fraction].Add(rank, new Tuple<string, string, string, int>(name, clothesm, clothesf, payday));
            }

            result = MySQL.QueryRead("SELECT * FROM `fractionaccess`");
            if (result == null || result.Rows.Count == 0) return;
            foreach (DataRow Row in result.Rows)
            {
                var fraction = Convert.ToInt32(Row["fraction"]);
                var dictionaryCmd = JsonConvert.DeserializeObject<Dictionary<string, int>>(Row["commands"].ToString());
                var dictionaryWeap = JsonConvert.DeserializeObject<Dictionary<string, int>>(Row["weapons"].ToString());

                FractionCommands[fraction] = dictionaryCmd;
                FractionWeapons[fraction] = dictionaryWeap;
            }

            Manager.onResourceStart();
        }

        public static void SpawnFractionCars(int fraction)
        {
            foreach (var vehicle in FractionVehicles[fraction])
            {
                if (vehicle.Value.Item1 == "barracks")
                {
                    var model = NAPI.Util.GetHashKey(vehicle.Value.Item1);
                    var canmats = ((VehicleHash)model == VehicleHash.Barracks || (VehicleHash)model == VehicleHash.Youga || (VehicleHash)model == VehicleHash.Burrito3); // "CANMATS"
                    var candrugs = ((VehicleHash)model == VehicleHash.Youga || (VehicleHash)model == VehicleHash.Burrito3); // "CANDRUGS"
                    var canmeds = ((VehicleHash)model == VehicleHash.Ambulance); // "CANMEDKITS"
                    var veh = NAPI.Vehicle.CreateVehicle(model, vehicle.Value.Item2, vehicle.Value.Item3.Z, vehicle.Value.Item5, vehicle.Value.Item6);

                    NAPI.Data.SetEntityData(veh, "ACCESS", "FRACTION");
                    NAPI.Data.SetEntityData(veh, "FRACTION", fraction);
                    NAPI.Data.SetEntityData(veh, "MINRANK", vehicle.Value.Item4);
                    NAPI.Data.SetEntityData(veh, "TYPE", FractionTypes[fraction]);
                    if (canmats)
                        NAPI.Data.SetEntityData(veh, "CANMATS", true);
                    if (candrugs)
                        NAPI.Data.SetEntityData(veh, "CANDRUGS", true);
                    if (canmeds)
                        NAPI.Data.SetEntityData(veh, "CANMEDKITS", true);
                    NAPI.Vehicle.SetVehicleNumberPlate(veh, vehicle.Key);
                    Core.VehicleStreaming.SetEngineState(veh, false);
                    VehicleManager.FracApplyCustomization(veh, fraction);

                    CarSpawner.carSpawners.Find(x => x.FractionID == fraction).SpawnedCars.Add(vehicle.Key);
                }
            }
        }

        public static void RespawnFractionCar(Vehicle vehicle)
        {
            try
            {
                var canmats = vehicle.HasData("CANMATS");
                var candrugs = vehicle.HasData("CANDRUGS");
                var canmeds = vehicle.HasData("CANMEDKITS");
                string number = vehicle.NumberPlate;
                int fraction = vehicle.GetData<int>("FRACTION");

                NAPI.Entity.SetEntityPosition(vehicle, FractionVehicles[fraction][number].Item2);
                NAPI.Entity.SetEntityRotation(vehicle, FractionVehicles[fraction][number].Item3);
                VehicleManager.RepairCar(vehicle);
                NAPI.Data.SetEntityData(vehicle, "ACCESS", "FRACTION");
                NAPI.Data.SetEntityData(vehicle, "FRACTION", fraction);
                NAPI.Data.SetEntityData(vehicle, "MINRANK", FractionVehicles[fraction][number].Item4);
                if (canmats)
                    NAPI.Data.SetEntityData(vehicle, "CANMATS", true);
                if (candrugs)
                    NAPI.Data.SetEntityData(vehicle, "CANDRUGS", true);
                if (canmeds)
                    NAPI.Data.SetEntityData(vehicle, "CANMEDKITS", true);
                NAPI.Vehicle.SetVehicleNumberPlate(vehicle, number);
                Core.VehicleStreaming.SetEngineState(vehicle, false);
                VehicleManager.FracApplyCustomization(vehicle, fraction);
            }
            catch (Exception e) { Log.Write("RespawnFractionCar: " + e.Message, nLog.Type.Error); }
        }

        [RemoteEvent("callbackCarSpawner")]
        public static void CallBackCarSpawner(Player player, string vnumber, int type)
        {
            //player.SendChatMessage($"{vnumber} - {type}");
            switch (type)
            {
                case 0:
                    Configs.DeleteSpawnedCar(player, vnumber);
                    break;
                case 1:
                    Configs.SpawnFractionCar(player, vnumber);
                    break;
            }
        }

        private static void DeleteSpawnedCar(Player player, string vnumber)
        {
            if (Main.Players[player].FractionID <= 0) return;
            int fractionid = Main.Players[player].FractionID;
            CarSpawner spawner = CarSpawner.carSpawners.Find(x => x.FractionID == fractionid);

            var vehicle = FractionVehicles[fractionid][vnumber];
            if (vehicle == null) return;
            if (!spawner.SpawnedCars.Contains(vnumber))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Машина не заспавнена", 2500);
                return;
            }
            if (vehicle.Item4 > Main.Players[player].FractionLVL)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Недостаточно уровня", 2500);
                return;
            }

            foreach (Vehicle item in NAPI.Pools.GetAllVehicles())
            {
                if (item.NumberPlate == vnumber)
                {
                    if (item.HasData("FRACTION") && item.GetData<int>("FRACTION") == fractionid)
                    {
                        if (item.Occupants.Count != 0)
                        {
                            foreach (Player p in item.Occupants)
                            {
                                VehicleManager.WarpPlayerOutOfVehicle(p);
                            }
                        }
                        NAPI.Task.Run(() => {
                            NAPI.Entity.DeleteEntity(item);
                            int index = spawner.SpawnedCars.FindIndex(x => x == vnumber);
                            spawner.SpawnedCars.RemoveAt(index);
                        });
                    }
                }
            }
        }

        private static void SpawnFractionCar(Player player, string vnumber)
        {
            if (Main.Players[player].FractionID <= 0) return;
            int fractionid = Main.Players[player].FractionID;

            var vehicle = FractionVehicles[fractionid][vnumber];
            if (vehicle == null) return;

            /*if (player.HasData("LASTSPAWNCAR"))
            {
                DateTime lastSpawn = player.GetData<DateTime>("LASTSPAWNCAR");
                if (DateTime.Now < lastSpawn)
                {
                    DateTime g = new DateTime((lastSpawn - DateTime.Now).Ticks);
                    var min = g.Minute;
                    var sec = g.Second;
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Вы сможете вызвать любую машину через {min}:{sec}", 3000);
                    return;
                }
            }
            if (player.HasData($"{vnumber}SPAWN"))
            {
                DateTime lastSpawn = player.GetData<DateTime>($"{vnumber}SPAWN");
                if (DateTime.Now < lastSpawn)
                {
                    DateTime g = new DateTime((lastSpawn - DateTime.Now).Ticks);
                    var min = g.Minute;
                    var sec = g.Second;
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Вы сможете вызвать эту машину через {min}:{sec}", 3000);
                    return;
                }
            }*/

            if (vehicle.Item4 > Main.Players[player].FractionLVL)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Du hast nicht den erforderlichen Rang dafür!", 2500);
                return;
            }
            var model = NAPI.Util.GetHashKey(vehicle.Item1);
            var canmats = ((VehicleHash)model == VehicleHash.Barracks || (VehicleHash)model == VehicleHash.Youga || (VehicleHash)model == VehicleHash.Burrito3); // "CANMATS"
            var candrugs = ((VehicleHash)model == VehicleHash.Youga || (VehicleHash)model == VehicleHash.Burrito3); // "CANDRUGS"
            var canmeds = ((VehicleHash)model == VehicleHash.Ambulance); // "CANMEDKITS"
            var veh = NAPI.Vehicle.CreateVehicle(model, vehicle.Item2, vehicle.Item3.Z, vehicle.Item5, vehicle.Item6);

            NAPI.Data.SetEntityData(veh, "ACCESS", "FRACTION");
            NAPI.Data.SetEntityData(veh, "FRACTION", fractionid);
            NAPI.Data.SetEntityData(veh, "MINRANK", vehicle.Item4);
            NAPI.Data.SetEntityData(veh, "TYPE", FractionTypes[fractionid]);
            if (canmats)
                NAPI.Data.SetEntityData(veh, "CANMATS", true);
            if (candrugs)
                NAPI.Data.SetEntityData(veh, "CANDRUGS", true);
            if (canmeds)
                NAPI.Data.SetEntityData(veh, "CANMEDKITS", true);
            NAPI.Vehicle.SetVehicleNumberPlate(veh, vnumber);
            Core.VehicleStreaming.SetEngineState(veh, false);
            VehicleManager.FracApplyCustomization(veh, fractionid);
            if ((VehicleHash)model == VehicleHash.Submersible || (VehicleHash)model == VehicleHash.Thruster) veh.SetSharedData("PETROL", 0);

            CarSpawner.carSpawners.Find(x => x.FractionID == fractionid).SpawnedCars.Add(vnumber);

            NAPI.Data.SetEntityData(player, $"{vnumber}SPAWN", DateTime.Now.AddMinutes(5));
            NAPI.Data.SetEntityData(player, $"LASTSPAWNCAR", DateTime.Now.AddMinutes(1));
        }
    }
    public class CarSpawner
    {
        public int FractionID { get; set; }
        public Vector3 Position { get; set; }

        public List<string> SpawnedCars = new List<string>();

        private GTANetworkAPI.ColShape shape;
        private GTANetworkAPI.Marker marker;
        private GTANetworkAPI.TextLabel label;

        public static List<CarSpawner> carSpawners = new List<CarSpawner>();

        public CarSpawner(int fractionID, Vector3 position)
        {
            FractionID = fractionID;
            Position = position;

            Create();
        }

        private void Create()
        {
            shape = NAPI.ColShape.CreateCylinderColShape(Position, 1f, 2f, 0);
            marker = NAPI.Marker.CreateMarker(1, Position, new Vector3(), new Vector3(), 1f, new Color(255, 250, 250, 120), false, 0);
            label = NAPI.TextLabel.CreateTextLabel("", Position + new Vector3(0, 0, 1), 10f, 5f, 4, new Color(255, 255, 255), false, 0);

            shape.OnEntityEnterColShape += (s, p) =>
            {
                if (!Main.Players.ContainsKey(p)) return;
                if (Main.Players[p].FractionID != FractionID) return;
                NAPI.Data.SetEntityData(p, "INTERACTIONCHECK", 807);
            };
            shape.OnEntityExitColShape += (s, p) =>
            {
                NAPI.Data.ResetEntityData(p, "INTERACTIONCHECK");
            };
        }

        public static void Init()
        {
            Dictionary<int, Vector3> FractionsCarSpawnerCoords = new Dictionary<int, Vector3>()
            {
                { 1, new Vector3(0,0,0)}, // [ Fartions id 1 ist die id von der Farktion ] [Vector3 ist wo der punkt stehen soll um das menü zu öffen] 
                { 2, new Vector3(102.482956, -1957.5361, 19.62336)},
                { 3, new Vector3(0,0,0)},
                { 4, new Vector3(0,0,0)},
                { 5, new Vector3(979.38043, -1828.0836, 30.069244)},
                { 6, new Vector3(0,0,0)},
                { 7, new Vector3(457.70844, -1007.76044, 26.389936)},
                { 8, new Vector3(-423.39996, -341.0975, 22.329397)},
                { 9, new Vector3(0,0,0)},
                { 10, new Vector3(0,0,0)},
                { 11, new Vector3(0,0,0)},
                { 12, new Vector3(0,0,0)},
                { 13, new Vector3(0,0,0)},
                { 14, new Vector3(0,0,0)},
                { 15, new Vector3(0,0,0)},
                { 16, new Vector3(0,0,0)},
                { 17, new Vector3(0,0,0)},
                { 18, new Vector3(862.45514, -1346.4543, 24.342505)},
            };

            foreach (var item in FractionsCarSpawnerCoords)
            {
                CarSpawner spawner = new CarSpawner(item.Key, item.Value);
                spawner.Create();
                carSpawners.Add(spawner);
            }

            Configs.SpawnFractionCars(14); //Для спавна Матовозок
        }

        public static void OpenMenuSpawner(Player player)
        {
            if (!Main.Players.ContainsKey(player)) return;
            CarSpawner spawner = carSpawners.Find(x => x.FractionID == Main.Players[player].FractionID);

            List<List<object>> data = new List<List<object>>();

            foreach (var item in Configs.FractionVehicles[Main.Players[player].FractionID])
            {
                List<object> vehdata = new List<object>()
                {
                    spawner.SpawnedCars.Contains(item.Key),
                    item.Value.Item4,
                    item.Value.Item1,
                    item.Key,
                };
                data.Add(vehdata);
            }
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            Trigger.ClientEvent(player, "openFractionVehicleSpawner", json);
        }
    }
}
