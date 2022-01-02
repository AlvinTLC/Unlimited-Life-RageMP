using GTANetworkAPI;
using UNL.SDK;
using System;
using System.Collections.Generic;
using ULife.Houses;

namespace ULife.Houses
{
    class Realtor : Script
    {
        private static nLog RLog = new nLog("RealtorManager");
        private static List<object> HouseList = new List<object>();
        private static ColShape shape;
        private static Marker intmarker;
        private static Blip blip;
        private static Vector3 PositionRealtor = new Vector3(-700.76843, 268.61572, 83.14726);
        private static int[] PriceToInfo = { 100, 200, 500, 1000, 1500, 2000};

        [ServerEvent(Event.ResourceStart)]
        public static void EnterShapeRealtor()
        {
            try
            {
                #region #2CW Creating Marker & Colshape & Blip
                blip = NAPI.Blip.CreateBlip(374, PositionRealtor, 0.7f, 2, "Immobilienmakler", shortRange: true, dimension: 0);
                intmarker = NAPI.Marker.CreateMarker(2, PositionRealtor + new Vector3(0, 0, 0.1), new Vector3(), new Vector3(), 0.5f, new Color(255, 225, 64), false, 0);
                shape = NAPI.ColShape.CreateCylinderColShape(PositionRealtor, 1, 2, 0);
                shape.OnEntityEnterColShape += (s, ent) =>
                {
                    try
                    {
                        NAPI.Data.SetEntityData(ent, "INTERACTIONCHECK", 511);
                    }
                    catch (Exception ex) { Console.WriteLine("shape.OnEntityEnterColShape: " + ex.Message); }
                };
                shape.OnEntityExitColShape += (s, ent) =>
                {
                    try
                    {
                        NAPI.Data.SetEntityData(ent, "INTERACTIONCHECK", 0);
                    }
                    catch (Exception ex) { Console.WriteLine("shape.OnEntityExitColShape: " + ex.Message); }
                };
                #endregion

                RLog.Write("Loaded", nLog.Type.Info);
            }
            catch (Exception e) { RLog.Write(e.ToString(), nLog.Type.Error); }
        }

        public static void OpenRealtorMenu(Player player)
        {
            Trigger.ClientEvent(player, "openRealtorMenu");
        }

        [RemoteEvent("closeRealtorMenu")]
        public static void CloseRealtorMenu(Player player)
        {
            Trigger.ClientEvent(player, "closeRealtorMenu");
        }

        [RemoteEvent("buyRealtorInfoHome")]
        public static void BuyInfoHome(Player player, int hclass, float x, float y)
        {
            if (PriceToInfo[hclass] > Main.Players[player].Money)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast nicht genug geld um Informationen zu erhalten.", 3000);
            }
            else
            {
                Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Routenführung gestartet!", 3000);
                Trigger.ClientEvent(player, "createWaypoint", x, y);
                MoneySystem.Wallet.Change(player, -PriceToInfo[hclass]);
            }
            NAPI.Task.Run(() =>
            {
                try
                {
                    CloseRealtorMenu(player);
                }
                catch { }
            }, 200);
        }

        [RemoteEvent("LoadHouseToMenu")]
        public static void LoadHouseToMenu(Player player, int houseclass)
        {
            try
            {
                foreach (House house in HouseManager.Houses.FindAll(x => x.Type == houseclass))
                {
                    if (house.Owner == "")
                    {
                        var maxcars = GarageManager.Garages.ContainsKey(house.GarageID) ? GarageManager.GarageTypes[GarageManager.Garages[house.GarageID].Type].MaxCars.ToString() : "Keine";
                        List<object> data = new List<object>
                        {
                            house.ID,
                            house.Type,
                            house.Price,
                            house.Position,
                            maxcars,
							PriceToInfo[houseclass]
                        };
                        HouseList.Add(data);
                    }
                }
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(HouseList);
                Trigger.ClientEvent(player, "LoadHouse", json);

                HouseList.Clear();
            }
            catch (Exception e)
            {
                RLog.Write(e.ToString(), nLog.Type.Error);
            }
        }
    }
}
