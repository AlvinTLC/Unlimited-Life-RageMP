using GTANetworkAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using ULife.GUI;
using System.Linq;
using UNL.SDK;

namespace ULife.Core
{
    class CarRoom : Script
    {
        private static nLog Log = new nLog("CARROOM");


        public static Vector3 CamPosition = new Vector3(-42.3758, -1101.672, 26.42235); // Позиция камеры
        public static Vector3 CamRotation = new Vector3(0, 0, 1.701622); // Rotation камеры
        public static Vector3 CarSpawnPos = new Vector3(-42.79771, -1095.676, 26.0117); // Место для спавна машины в автосалоне
        public static Vector3 CarSpawnRot = new Vector3(-0.05113003, 0.05638388, 91.65826); // Rotation для спавна машины в автосалоне

        public static void onPlayerDissonnectedHandler(Player player, DisconnectionType type, string reason)
        {
            try
            {
                if (player.HasData("ROOMCAR"))
                {
                    var uveh = player.GetData<Entity>("ROOMCAR");
                    uveh.Delete();
                    player.ResetData("ROOMCAR");
                }
            }
            catch (Exception e) { Log.Write("PlayerDisconnected: " + e.Message, nLog.Type.Error); }
        }
        [RemoteEvent("createveh")]
        public static void createveh(Player player, string name, int color1, int color2)
        {
            if (!player.HasData("CARROOMID")) return;
            if (player.HasData("ROOMCAR"))
            {
                var uveh = player.GetData<Entity>("ROOMCAR");
                uveh.Delete();
                player.ResetData("ROOMCAR");
            }
            VehicleHash vh = (VehicleHash)NAPI.Util.GetHashKey(name);
            Entity veh = NAPI.Vehicle.CreateVehicle(vh, CarSpawnPos, CarSpawnRot, color1, color2);
            NAPI.Entity.SetEntityDimension(veh, Dimensions.GetPlayerDimension(player));
            player.SetData<Entity>("ROOMCAR", veh);
        }

        public static void enterCarroom(Player player, string name)
        {
            if (NAPI.Player.IsPlayerInAnyVehicle(player)) return;
            uint dim = Dimensions.RequestPrivateDimension(player);
            NAPI.Entity.SetEntityDimension(player, dim);
            Main.Players[player].ExteriorPos = player.Position;
            NAPI.Entity.SetEntityPosition(player, new Vector3(CamPosition.X, CamPosition.Y - 2, CamPosition.Z));
            //player.FreezePosition = true;
            player.SetData("INTERACTIONCHECK", 0);
            Trigger.ClientEvent(player, "carRoom");

            OpenCarromMenu(player, BusinessManager.BizList[player.GetData<int>("CARROOMID")].Type);
        }

        #region Menu
        private static Dictionary<string, Color> carColors = new Dictionary<string, Color>
        {
            { "Schwarz", new Color(0, 0, 0) },
            { "Weiß", new Color(225, 225, 225) },
            { "Rot", new Color(230, 0, 0) },
            { "Orange", new Color(255, 115, 0) },
            { "Gelb", new Color(240, 240, 0) },
            { "Grün", new Color(0, 230, 0) },
            { "Blau", new Color(0, 205, 255) },
            { "Blau2", new Color(0, 0, 230) },
            { "Lila", new Color(190, 60, 165) },
        };

        public static void OpenCarromMenu(Player player, int biztype)
        {
            biztype -= 2;

            var prices = new List<int>();
            Business biz = BusinessManager.BizList[player.GetData<int>("CARROOMID")];
            foreach (var p in biz.Products)
                prices.Add(p.Price);

            Trigger.ClientEvent(player, "openAuto", JsonConvert.SerializeObject(BusinessManager.CarsNames[biztype]), JsonConvert.SerializeObject(prices));
        }

        private static string BuyVehicle(Player player, Business biz, string vName, string color)
        {
            // Check products available
            var prod = biz.Products.FirstOrDefault(p => p.Name == vName);
            string vNumber = "none";

            if (Main.Players[player].Money < prod.Price)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Nicht genug Geld", 3000);
                return vNumber;
            }

            MoneySystem.Wallet.Change(player, -prod.Price);

            GameLog.Money($"player({Main.Players[player].UUID})", $"biz({biz.ID})", prod.Price, $"buyCar({vName})");

            vNumber = VehicleManager.Create(player.Name, vName, carColors[color], carColors[color]);

            Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Sie haben einen {vName} gekauft.", 3000);

            return vNumber;
        }

        [RemoteEvent("carroomBuy")]
        public static void RemoteEvent_carroomBuy(Player player, string vName, string color)
        {
            try
            {
                Business biz = BusinessManager.BizList[player.GetData<int>("CARROOMID")];
                NAPI.Entity.SetEntityPosition(player, new Vector3(biz.EnterPoint.X, biz.EnterPoint.Y, biz.EnterPoint.Z + 1.5));
                //player.FreezePosition = false;

                Main.Players[player].ExteriorPos = new Vector3();
                Trigger.ClientEvent(player, "destroyCamera");
                NAPI.Entity.SetEntityDimension(player, 0);
                Dimensions.DismissPrivateDimension(player);

                var house = Houses.HouseManager.GetHouse(player, true);
                if (house == null)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.JobSms, $"Sie haben kein persönliches Zuhause", 3000);
                    return;
                }
                if (house.GarageID == 0)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.JobSms, $"Sie haben keine Garage", 3000);
                    return;
                }
                var garage = Houses.GarageManager.Garages[house.GarageID];
                if (VehicleManager.getAllPlayerVehicles(player.Name).Count >= Houses.GarageManager.GarageTypes[garage.Type].MaxCars)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.JobSms, $"Sie haben die maximale Anzahl von Autos", 3000);
                    return;
                }

                var prod = biz.Products.FirstOrDefault(p => p.Name == vName);
                if (Main.Players[player].Money < prod.Price)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.JobSms, "Unzureichende Mittel", 3000);
                    return;
                }
                if (!BusinessManager.takeProd(biz.ID, 1, vName, prod.Price))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.JobSms, "Dieses Modell ist nicht mehr auf Lager", 3000);
                    return;
                }
                MoneySystem.Wallet.Change(player, -prod.Price);
                GameLog.Money($"player({Main.Players[player].UUID})", $"biz({biz.ID})", prod.Price, $"buyCar({vName})");

                var vNumber = VehicleManager.Create(player.Name, vName, carColors[color], carColors[color]);

                VehicleManager.Spawn(vNumber, biz.UnloadPoint, 90, player);

                //garage.SpawnCar(vNumber);
                nInventory.Add(player, new nItem(ItemType.CarKey, 1, $"{vNumber}_{VehicleManager.Vehicles[vNumber].KeyNum}"));

                Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Sie haben einen {vName} gekauft.", 3000);
            }
            catch (Exception e) { Log.Write("CarroomBuy: " + e.Message, nLog.Type.Error); }
        }

        [RemoteEvent("carroomCancel")]
        public static void RemoteEvent_carroomCancel(Player player)
        {
            try
            {
                if (!player.HasData("CARROOMID")) return;
                var enterPoint = BusinessManager.BizList[player.GetData<int>("CARROOMID")].EnterPoint;
                NAPI.Entity.SetEntityPosition(player, new Vector3(enterPoint.X, enterPoint.Y, enterPoint.Z + 1.5));
                Main.Players[player].ExteriorPos = new Vector3();
                //player.FreezePosition = false;
                Dimensions.DismissPrivateDimension(player);
                player.ResetData("CARROOMID");
                NAPI.Entity.SetEntityDimension(player, 0);
                Trigger.ClientEvent(player, "destroyCamera");
                if (player.HasData("ROOMCAR"))
                {
                    var uveh = player.GetData<Entity>("ROOMCAR");
                    uveh.Delete();
                    player.ResetData("ROOMCAR");
                }

            }
            catch (Exception e) { Log.Write("carroomCancel: " + e.Message, nLog.Type.Error); }
        }
        #endregion
    }
}
