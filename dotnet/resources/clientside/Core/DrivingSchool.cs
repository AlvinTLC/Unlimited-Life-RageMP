using System.Collections.Generic;
using System;
using GTANetworkAPI;
using Newtonsoft.Json;
using ULife.GUI;
using UNL.SDK;

namespace ULife.Core
{
    class DrivingSchool : Script
    {
        // мотоциклы, легковые машины, грузовые, водный, вертолёты, самолёты
        private static List<int> LicPrices = new List<int>() { 600, 1000, 3000, 6000, 10000, 10000 };
        private static Vector3 enterSchool = new Vector3(215.32645, -1398.8573, 29.463541);
        private static List<Vector3> startCourseCoord = new List<Vector3>()
        {
            new Vector3(216.06218, -1381.225, 30.638868),
        };
        private static List<Vector3> startCourseRot = new List<Vector3>()
        {
            new Vector3(-0.21613333, 0.8579618, -89.87785),
            new Vector3(-0.21613333, 0.8579618, -89.87785),
            new Vector3(-0.21613333, 0.8579618, -89.87785),
        };
        private static List<Vector3> drivingCoords = new List<Vector3>()
        {
            new Vector3(211.58707, -1372.0221, 30.251547),     //as1
            new Vector3(217.59138, -1410.556, 28.956057),     //as2
            new Vector3(182.79324, -1395.3002, 28.944029),     //as3
            new Vector3(209.74854, -1327.4828, 29.007536),     //as4
            new Vector3(217.04362, -1146.5477, 29.001747),     //as5
            new Vector3(218.59813, -1067.2379, 28.897377),     //as6
            new Vector3(253.64275, -967.593, 28.997921),     //as7
            new Vector3(291.49347, -878.5284, 28.88644),     //as8
            new Vector3(389.0182, -865.1754, 28.929373),     //as9
            new Vector3(401.73676, -904.9045, 29.046135),     //as10
            new Vector3(400.67175, -937.8246, 29.059843),     //as11
            new Vector3(435.34396, -957.4822, 28.76032),     //as12
            new Vector3(486.21124, -957.5473, 26.98216),     //as13
            new Vector3(498.15427, -1028.521, 27.837553),     //as14
            new Vector3(498.16837, -1114.7081, 28.997135),     //as15
            new Vector3(499.8312, -1191.4781, 28.95066),     //as16
            new Vector3(500.0408, -1249.6163, 28.955584),     //as17
            new Vector3(533.5599, -1412.0422, 28.951246),     //as18
            new Vector3(522.8357, -1508.5587, 28.946255),     //as19
            new Vector3(467.71634, -1607.4988, 28.952015),     //as20
            new Vector3(214.2001, -1363.6821, 30.248001),     //as21
        };

        private static nLog Log = new nLog("DrivingSc");

        [ServerEvent(Event.ResourceStart)]
        public void onResourceStart()
        {
            try
            {
                var shape = NAPI.ColShape.CreateCylinderColShape(enterSchool, 1, 2, 0);
                shape.OnEntityEnterColShape += onPlayerEnterSchool;
                shape.OnEntityExitColShape += onPlayerExitSchool;

                NAPI.Marker.CreateMarker(1, enterSchool - new Vector3(0, 0, 0.7), new Vector3(), new Vector3(), 1, new Color(0, 255, 255));
                NAPI.TextLabel.CreateTextLabel(Main.StringToU16(""), new Vector3(enterSchool.X, enterSchool.Y, enterSchool.Z + 1), 5f, 0.3f, 0, new Color(255, 255, 255));
                var blip = NAPI.Blip.CreateBlip(enterSchool, 0);
                blip.ShortRange = true;
                blip.Name = Main.StringToU16("Fahrschule");
                blip.Sprite = 545;
                blip.Scale = 0.4f;
                blip.Color = 29;
                for (int i = 0; i < drivingCoords.Count; i++)
                {
                    var colshape = NAPI.ColShape.CreateCylinderColShape(drivingCoords[i], 4, 5, 0);
                    colshape.OnEntityEnterColShape += onPlayerEnterDrive;
                    colshape.SetData("NUMBER", i);
                }
            }
            catch (Exception e) { Log.Write("ResourceStart: " + e.Message, nLog.Type.Error); }
        }

        [ServerEvent(Event.PlayerExitVehicle)]
        public void Event_OnPlayerExitVehicle(Player player, Vehicle vehicle)
        {
            try
            {
                if (player.HasData("SCHOOLVEH") && player.GetData<Vehicle>("SCHOOLVEH") == vehicle)
                {
                    player.SetData("SCHOOL_TIMER", Timers.StartOnce(120000, () => timer_exitVehicle(player)));

                    Notify.Send(player, NotifyType.Warning, NotifyPosition.MapUp, $"Sie haben zwei Minuten, um wieder ins Auto zu steigen.", 3000);
                    return;
                }
            }
            catch (Exception e) { Log.Write("PlayerExitVehicle: " + e.Message, nLog.Type.Error); }
        }

        private void timer_exitVehicle(Player player)
        {
            NAPI.Task.Run(() =>
            {
                try
                {
                    if (!Main.Players.ContainsKey(player)) return;
                    if (!player.HasData("SCHOOLVEH")) return;
                    if (player.IsInVehicle && player.Vehicle == player.GetData<Vehicle>("SCHOOLVEH")) return;
                    NAPI.Entity.DeleteEntity(player.GetData<Vehicle>("SCHOOLVEH"));
                    Trigger.ClientEvent(player, "deleteCheckpoint", 12, 0);
                    player.ResetData("IS_DRIVING");
                    player.ResetData("SCHOOLVEH");
                    Timers.Stop(player.GetData<string>("SCHOOL_TIMER"));
                    player.ResetData("SCHOOL_TIMER");
                    Notify.Send(player, NotifyType.Warning, NotifyPosition.MapUp, $"Sie haben die Prüfung nicht bestanden.", 3000);
                }
                catch (Exception e) { Log.Write("TimerDrivingSchool: " + e.Message, nLog.Type.Error); }
            });
        }

        public static void onPlayerDisconnected(Player player, DisconnectionType type, string reason)
        {
            NAPI.Task.Run(() =>
            {
                try
                {
                    if (player.HasData("SCHOOLVEH")) NAPI.Entity.DeleteEntity(player.GetData<Vehicle>("SCHOOLVEH"));
                }
                catch (Exception e) { Log.Write("PlayerDisconnected: " + e.Message, nLog.Type.Error); }
            }, 0);
        }
        public static void startDrivingCourse(Player player, int index)
        {
            if (player.HasData("IS_DRIVING") || player.GetData<bool>("ON_WORK"))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Das können Sie jetzt nicht tun.", 3000);
                return;
            }
            if (Main.Players[player].Licenses[index])
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie haben diese Lizenz bereits", 3000);
                return;
            }
            switch (index)
            {
                case 0:
                    if (Main.Players[player].Money < LicPrices[0])
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Unzureichende Mittel", 3000);
                        return;
                    }
                    var vehicle = NAPI.Vehicle.CreateVehicle(VehicleHash.Bagger, startCourseCoord[0], startCourseRot[0], 30, 30);
                    player.SetIntoVehicle(vehicle, 0);
                    player.SetData("SCHOOLVEH", vehicle);
                    vehicle.SetData("ACCESS", "SCHOOL");
                    vehicle.SetData("DRIVER", player);
                    player.SetData("IS_DRIVING", true);
                    player.SetData("LICENSE", 0);
                    Trigger.ClientEvent(player, "createCheckpoint", 12, 1, drivingCoords[0] - new Vector3(0, 0, 2), 4, 0, 255, 0, 0);
                    Trigger.ClientEvent(player, "createWaypoint", drivingCoords[0].X, drivingCoords[0].Y);
                    player.SetData("CHECK", 0);
                    MoneySystem.Wallet.Change(player, -LicPrices[0]);
                    Fractions.Stocks.fracStocks[6].Money += LicPrices[0];
                    GameLog.Money($"player({Main.Players[player].UUID})", $"frac(6)", LicPrices[0], $"buyLic");
                    Core.VehicleStreaming.SetEngineState(vehicle, false);
                    Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Um das Fahrzeug zu starten, drücken Sie B", 3000);
                    return;
                case 1:
                    if (Main.Players[player].Money < LicPrices[1])
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Unzureichende Mittel", 3000);
                        return;
                    }
                    vehicle = NAPI.Vehicle.CreateVehicle(VehicleHash.Dilettante, startCourseCoord[0], startCourseRot[0], 30, 30);
                    player.SetIntoVehicle(vehicle, 0);
                    player.SetData("SCHOOLVEH", vehicle);
                    vehicle.SetData("ACCESS", "SCHOOL");
                    vehicle.SetData("DRIVER", player);
                    player.SetData("IS_DRIVING", true);
                    player.SetData("LICENSE", 1);
                    Trigger.ClientEvent(player, "createCheckpoint", 12, 1, drivingCoords[0] - new Vector3(0, 0, 2), 4, 0, 255, 0, 0);
                    Trigger.ClientEvent(player, "createWaypoint", drivingCoords[0].X, drivingCoords[0].Y);
                    player.SetData("CHECK", 0);
                    MoneySystem.Wallet.Change(player, -LicPrices[1]);
                    Fractions.Stocks.fracStocks[6].Money += LicPrices[1];
                    GameLog.Money($"player({Main.Players[player].UUID})", $"frac(6)", LicPrices[1], $"buyLic");
                    Core.VehicleStreaming.SetEngineState(vehicle, false);
                    Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Um das Fahrzeug zu starten, drücken Sie B", 3000);
                    return;
                case 2:
                    if (Main.Players[player].Money < LicPrices[2])
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Unzureichende Mittel", 3000);
                        return;
                    }
                    vehicle = NAPI.Vehicle.CreateVehicle(VehicleHash.Flatbed, startCourseCoord[0], startCourseRot[0], 30, 30);
                    player.SetIntoVehicle(vehicle, 0);
                    player.SetData("SCHOOLVEH", vehicle);
                    vehicle.SetData("ACCESS", "SCHOOL");
                    vehicle.SetData("DRIVER", player);
                    player.SetData("IS_DRIVING", true);
                    player.SetData("LICENSE", 2);
                    Trigger.ClientEvent(player, "createCheckpoint", 12, 1, drivingCoords[0] - new Vector3(0, 0, 2), 4, 0, 255, 0, 0);
                    Trigger.ClientEvent(player, "createWaypoint", drivingCoords[0].X, drivingCoords[0].Y);
                    player.SetData("CHECK", 0);
                    MoneySystem.Wallet.Change(player, -LicPrices[2]);
                    Fractions.Stocks.fracStocks[6].Money += LicPrices[2];
                    GameLog.Money($"player({Main.Players[player].UUID})", $"frac(6)", LicPrices[2], $"buyLic");
                    Core.VehicleStreaming.SetEngineState(vehicle, false);
                    Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Um das Fahrzeug zu starten, drücken Sie B", 3000);
                    return;
                case 3:
                    if (Main.Players[player].Money < LicPrices[3])
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Unzureichende Mittel", 3000);
                        return;
                    }
                    Main.Players[player].Licenses[3] = true;
                    MoneySystem.Wallet.Change(player, -LicPrices[3]);
                    Fractions.Stocks.fracStocks[6].Money += LicPrices[3];
                    GameLog.Money($"player({Main.Players[player].UUID})", $"frac(6)", LicPrices[3], $"buyLic");
                    Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Um das Fahrzeug zu starten, drücken Sie B", 3000);
                    Dashboard.sendStats(player);
                    return;
                case 4:
                    if (Main.Players[player].Money < LicPrices[4])
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"", 3000);
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Unzureichende Mittel", 3000);
                        return;
                    }
                    Main.Players[player].Licenses[4] = true;
                    MoneySystem.Wallet.Change(player, -LicPrices[4]);
                    Fractions.Stocks.fracStocks[6].Money += LicPrices[4];
                    GameLog.Money($"player({Main.Players[player].UUID})", $"frac(6)", LicPrices[4], $"buyLic");
                    Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Um das Fahrzeug zu starten, drücken Sie B", 3000);
                    Dashboard.sendStats(player);
                    return;
                case 5:
                    if (Main.Players[player].Money < LicPrices[5])
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Unzureichende Mittel", 3000);
                        return;
                    }
                    Main.Players[player].Licenses[5] = true;
                    MoneySystem.Wallet.Change(player, -LicPrices[5]);
                    Fractions.Stocks.fracStocks[6].Money += LicPrices[5];
                    GameLog.Money($"player({Main.Players[player].UUID})", $"frac(6)", LicPrices[5], $"buyLic");
                    Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Um das Fahrzeug zu starten, drücken Sie B", 3000);
                    Dashboard.sendStats(player);
                    return;
            }
        }
        private void onPlayerEnterSchool(ColShape shape, Player entity)
        {
            try
            {
                NAPI.Data.SetEntityData(entity, "INTERACTIONCHECK", 39);
            }
            catch (Exception e) { Log.Write("onPlayerEnterSchool: " + e.ToString(), nLog.Type.Error); }
        }
        private void onPlayerExitSchool(ColShape shape, Player player)
        {
            NAPI.Data.SetEntityData(player, "INTERACTIONCHECK", 0);
        }
        private void onPlayerEnterDrive(ColShape shape, Player player)
        {
            try
            {
                if (!player.IsInVehicle || player.VehicleSeat != 0) return;
                if (!player.Vehicle.HasData("ACCESS") || player.Vehicle.GetData<string>("ACCESS") != "SCHOOL") return;
                if (!player.HasData("IS_DRIVING")) return;
                if (player.Vehicle != player.GetData<Vehicle>("SCHOOLVEH")) return;
                if (shape.GetData<int>("NUMBER") != player.GetData<int>("CHECK")) return;
                //Trigger.ClientEvent(player, "deleteCheckpoint", 12, 0);
                var check = player.GetData<int>("CHECK");
                if (check == drivingCoords.Count - 1)
                {
                    player.ResetData("IS_DRIVING");
                    var vehHP = player.Vehicle.Health;
                    NAPI.Task.Run(() =>
                    {
                        try
                        {
                            NAPI.Entity.DeleteEntity(player.Vehicle);
                        }
                        catch { }
                    });
                    player.ResetData("SCHOOLVEH");
                    if (vehHP < 500)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie haben die Prüfung nicht bestanden.", 3000);
                        return;
                    }
                    Main.Players[player].Licenses[player.GetData<int>("LICENSE")] = true;
                    Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Sie haben die Prüfung bestanden", 3000);
                    Dashboard.sendStats(player);
                    Trigger.ClientEvent(player, "deleteCheckpoint", 12, 0);
                    return;
                }

                player.SetData("CHECK", check + 1);
                if (check + 2 < drivingCoords.Count)
                    Trigger.ClientEvent(player, "createCheckpoint", 12, 1, drivingCoords[check + 1] - new Vector3(0, 0, 2), 4, 0, 255, 0, 0, drivingCoords[check + 2] - new Vector3(0, 0, 1.12));
                else
                    Trigger.ClientEvent(player, "createCheckpoint", 12, 1, drivingCoords[check + 1] - new Vector3(0, 0, 2), 4, 0, 255, 0, 0);
                Trigger.ClientEvent(player, "createWaypoint", drivingCoords[check + 1].X, drivingCoords[check + 1].Y);
            }
            catch (Exception e)
            {
                Log.Write("ENTERDRIVE:\n" + e.ToString(), nLog.Type.Error);
            }
        }

        #region menu
        public static void OpenDriveSchoolMenu(Player player)
        {
            Menu menu = new Menu("driveschool", false, false);
            menu.Callback = callback_driveschool;

            Menu.Item menuItem = new Menu.Item("header", Menu.MenuItem.Header);
            menuItem.Text = "Lizenzen";
            menu.Add(menuItem);

            menuItem = new Menu.Item("lic_0", Menu.MenuItem.Button);
            menuItem.Text = $"(A) Motorräder - {LicPrices[0]}$";
            menu.Add(menuItem);

            menuItem = new Menu.Item("lic_1", Menu.MenuItem.Button);
            menuItem.Text = $"(B) Personenkraftwagen - {LicPrices[1]}$";
            menu.Add(menuItem);

            menuItem = new Menu.Item("lic_2", Menu.MenuItem.Button);
            menuItem.Text = $"(C) Lastwagen - {LicPrices[2]}$";
            menu.Add(menuItem);

            menuItem = new Menu.Item("lic_3", Menu.MenuItem.Button);
            menuItem.Text = $"(V) Wassertransport - {LicPrices[3]}$";
            menu.Add(menuItem);

            menuItem = new Menu.Item("lic_4", Menu.MenuItem.Button);
            menuItem.Text = $"(LV) Hubschrauber - {LicPrices[4]}$";
            menu.Add(menuItem);

            menuItem = new Menu.Item("lic_5", Menu.MenuItem.Button);
            menuItem.Text = $"(LS) Flugzeuge - {LicPrices[5]}$";
            menu.Add(menuItem);

            menuItem = new Menu.Item("close", Menu.MenuItem.Button);
            menuItem.Text = "Schließen";
            menu.Add(menuItem);

            menu.Open(player);
        }
        private static void callback_driveschool(Player Player, Menu menu, Menu.Item item, string eventName, dynamic data)
        {
            MenuManager.Close(Player);
            if (item.ID == "close") return;
            var id = item.ID.Split('_')[1];
            startDrivingCourse(Player, Convert.ToInt32(id));
            return;
        }
        #endregion
    }
}