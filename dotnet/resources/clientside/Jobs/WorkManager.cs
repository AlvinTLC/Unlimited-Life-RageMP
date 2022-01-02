using GTANetworkAPI;
using System;
using System.Linq;
using System.Collections.Generic;
using ULife.Core;
using UNL.SDK;
using ULife.GUI;
using Newtonsoft.Json;

namespace ULife.Jobs
{
    class WorkManager : Script
    {
        private static nLog Log = new nLog("WorkManager");
        public static Random rnd = new Random();

        [ServerEvent(Event.ResourceStart)]
        public void onResourceStart()
        {
            try
            {
                //Cols.Add(0, NAPI.ColShape.CreateCylinderColShape(Points[0], 1, 2, 0)); // job placement
                //Cols[0].OnEntityEnterColShape += JobMenu_onEntityEnterColShape; // job placement point handler
                //NAPI.TextLabel.CreateTextLabel(Main.StringToU16("~g~Работа"), new Vector3(Points[0].X, Points[0].Y, Points[0].Z + 0.5), 10F, 0.3F, 0, new Color(255, 255, 255));
                //NAPI.Marker.CreateMarker(1, Points[0] - new Vector3(0, 0, 0.7), new Vector3(), new Vector3(), 1f, new Color(255, 255, 255, 220));

                // blips
                NAPI.Blip.CreateBlip(408, new Vector3(-513.191, -1020.0745, 22.68515), 0.75f, 11, Main.StringToU16("Konstruktion"), 255, 0, true, 0, 0);//Builder
                NAPI.Blip.CreateBlip(408, new Vector3(106.11198, -657.6642, 43.94262), 0.75f, 11, Main.StringToU16("Fensterputzer"), 255, 0, true, 0, 0);
                NAPI.Blip.CreateBlip(586, new Vector3(136.69688, 94.82483, 82.38765), 0.75f, 45, Main.StringToU16("GoPostal"), 255, 0, true, 0, 0);
                NAPI.Blip.CreateBlip(198, new Vector3(903.3215, -191.7, 73.40494), 0.75f, 45, Main.StringToU16("Taxi"), 255, 0, true, 0, 0);
                NAPI.Blip.CreateBlip(198, new Vector3(1956.65015, 3769.12817, 31.0833454), 0.75f, 45, Main.StringToU16("Taxi"), 255, 0, true, 0, 0);//TODOTAXI
                NAPI.Blip.CreateBlip(198, new Vector3(1791.82837, 4586.595, 36.2361145), 0.75f, 45, Main.StringToU16("Taxi"), 255, 0, true, 0, 0);
                NAPI.Blip.CreateBlip(408, new Vector3(-2157.3635, -388.85593, 11.795702), 0.75f, 11, Main.StringToU16("Busfahrer"), 255, 0, true, 0, 0);
                NAPI.Blip.CreateBlip(408, new Vector3(951.2937, -3169.9072, 4.7808037), 0.75f, 11, Main.StringToU16("Lader"), 255, 0, true, 0, 0); //docks
                NAPI.Blip.CreateBlip(408, new Vector3(-1543.1458, -570.0307, 24.587872), 0.75f, 11, Main.StringToU16("Kollektor"), 255, 0, true, 0, 0); //main

                NAPI.Blip.CreateBlip(255, new Vector3(-501.78833, 61.4290543, 56.57218), 0.75f, 45, Main.StringToU16("Rollervermietung"), 255, 0, true, 0, 0);
                NAPI.Blip.CreateBlip(255, new Vector3(-1108.662, -1690.129, 3.254202), 0.75f, 45, Main.StringToU16("Fahrradverleih"), 255, 0, true, 0, 0);
                NAPI.Blip.CreateBlip(255, new Vector3(151.32138, -986.2304, 30.091936), 0.75f, 45, Main.StringToU16("Straßenreiniger"), 255, 0, true, 0, 0);
                NAPI.Blip.CreateBlip(255, new Vector3(1483.1759, 1132.3517, 113.33425), 0.75f, 45, Main.StringToU16("Farmer"), 255, 0, true, 0, 0);
                NAPI.Blip.CreateBlip(255, new Vector3(-949.17444, 332.02942, 70.21934), 0.75f, 45, Main.StringToU16("Gärtner"), 255, 0, true, 0, 0);
                // markers
                NAPI.Marker.CreateMarker(1, new Vector3(136.69688, 94.82483, 82.38765) - new Vector3(0, 0, 0.7), new Vector3(), new Vector3(), 1f, new Color(255, 255, 255, 220));
                NAPI.Marker.CreateMarker(1, new Vector3(64.48331, 123.934135, 78.03842) - new Vector3(0, 0, 0.7), new Vector3(), new Vector3(), 1f, new Color(255, 255, 255, 220));
            }
            catch (Exception e) { Log.Write("ResourceStart: " + e.Message, nLog.Type.Error); }
        }

        public void JobMenu_onEntityEnterColShape(ColShape shape, Player entity)
        {
            try
            {
                openJobsSelecting(entity);
            }
            catch (Exception ex) { Log.Write("JobMenu_onEntityEnterColShape: " + ex.Message, nLog.Type.Error); }
        }

        private static SortedDictionary<int, ColShape> Cols = new SortedDictionary<int, ColShape>();
        public static List<string> JobStats = new List<string>
        {
            "Elektriker",
            "Postbote",
            "Taxifahrer",
            "Busfahrer",
            "Lkw-Fahrer",
            "Kollektor",
            "Automechaniker",
            "Fensterputzer",
            "Baumeister",
            "Maurer",
            "Straßenreiniger",
            "Farmer",
            "Gärtner"
        };
        public static SortedList<int, Vector3> Points = new SortedList<int, Vector3>
        {
            {0, new Vector3() },  // Точка выдачи работы +
            {1, new Vector3(724.9625, 133.9959, 79.83643) },  // Builder job
            {2, new Vector3(136.69688, 94.82483, 82.38765) },  // Postal job
            {3, new Vector3(903.3215,-191.7,73.40494) },      // Taxi job
            {4, new Vector3(-2187.392, -409.30582, 12.00754) }, // Bus driver job
            {5, new Vector3(-1331.475, 53.58579, 53.53268) },  // Truck job
            {6, new Vector3(-1543.1458, -570.0307, 24.587872) },  // Collector job
            {7, new Vector3(473.9508, -1275.597, 29.60513) },  // AutoMechanic job
            {8, new Vector3(104.326126, -657.7652, 43.972385) },  // Мойщик окон
            {9, new Vector3(151.32138, -986.2304, 30.091936) }, //Street_cleaner
            {10, new Vector3(1483.1759, 1132.3517, 113.33425) },
        };
        private static SortedList<int, string> JobList = new SortedList<int, string>
        {
            {1, "Elektriker" },
            {2, "Postbote" },
            {3, "Taxifahrer" },
            {4, "Busfahrer" },
            {5, "Trucker" },
            {7, "Kollektor" },
            {8, "Fensterputzer" },
            {9, "Baumeister" },
            {10, "мойщиком" }, //??????
            {11, "Trucker" },
            {12, "Street_cleaner" },
            {13, "Street_cleaner" },
            {14, "Gärtner" },
        };
        private static SortedList<int, int> JobsMinLVL = new SortedList<int, int>()
        {
            { 1, 0 },
            { 2, 0 },
            { 3, 1 },
            { 4, 2 },
            { 5, 0 },
            { 6, 4 },
            { 7, 5 },
            { 8, 3 },
            { 9, 0 },
            { 10, 0 },
            { 11, 0 },
            { 12, 0 },
            { 13, 0 },
            { 14, 0 },
        };

        public static void Layoff(Player player)
        {
            if (NAPI.Data.GetEntityData(player, "ON_WORK") == true)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du musst erst das Tagespensum erfüllen.", 3000);
                return;
            }
            if (Main.Players[player].WorkID != 0)
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Du hast deinen Job gekündigt", 3000);
                Main.Players[player].WorkID = 0;
                Dashboard.sendStats(player);
                Trigger.ClientEvent(player, "showJobMenu", Main.Players[player].LVL, Main.Players[player].WorkID);
            }
            else
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du arbeitest für niemanden", 3000);
        }
        public static void JobJoin(Player player, int job)
        {
            if (Main.Players[player].FractionID != 0)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du kannst keinen Job bekommen, weil du Mitglied in einer Organisation sind", 3000);
                return;
            }
            if (Main.Players[player].WorkID != 0)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Für den Anfang kündige deinen bisherigen Job.", 3000);
                return;
            }
            if (NAPI.Data.GetEntityData(player, "ON_WORK") == true)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du musst erst das Tagespensum erfüllen.", 3000);
                return;
            }

            if (Main.Players[player].WorkID == job)
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du arbeitest bereits {JobList[job]}", 3000);
            else
            {
                if (Main.Players[player].LVL < JobsMinLVL[job])
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Erforderlich als Minimum {JobsMinLVL[job]} Level", 3000);
                    return;
                }
                if ((job == 3 || job == 8) && !Main.Players[player].Licenses[1])
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast keinen Führerschein der Klasse B", 3000);
                    return;
                }
                if ((job == 4 || job == 6 || job == 7) && !Main.Players[player].Licenses[2])
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast keinen Führerschein der Klasse C", 3000);
                    return;
                }
                Main.Players[player].WorkID = job;
                Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du erhältst einen Auftrag {JobList[job]}. Zum Startpunkt des Auftrags gelangen", 3000);
                Trigger.ClientEvent(player, "createWaypoint", Points[job].X, Points[job].Y);
                Dashboard.sendStats(player);
                Trigger.ClientEvent(player, "showJobMenu", Main.Players[player].LVL, Main.Players[player].WorkID);
            }
        }
        // REQUIRED REFACTOR //
        public static void load(Player player)
        {
            NAPI.Data.SetEntityData(player, "ON_WORK", false);
            NAPI.Data.SetEntityData(player, "PAYMENT", 0);
            NAPI.Data.SetEntityData(player, "BUS_ONSTOP", false);
            NAPI.Data.SetEntityData(player, "TRUCK_ONSTOP", false);
            NAPI.Data.SetEntityData(player, "IS_CALL_TAXI", false);
            NAPI.Data.SetEntityData(player, "IS_REQUESTED", false);
            NAPI.Data.SetEntityData(player, "IN_WORK_CAR", false);
            player.SetData("PACKAGES", 0);
            NAPI.Data.SetEntityData(player, "WORK", null);
            NAPI.Data.SetEntityData(player, "WORKWAY", -1);
            NAPI.Data.SetEntityData(player, "IS_PRICED", false);
            NAPI.Data.SetEntityData(player, "ON_DUTY", false);
            NAPI.Data.SetEntityData(player, "CUFFED", false);
            NAPI.Data.SetEntityData(player, "IN_CP_MODE", false);
            NAPI.Data.SetEntityData(player, "WANTED", 0);
            NAPI.Data.SetEntityData(player, "REQUEST", "null");
            player.SetData("IS_IN_ARREST_AREA", false);
            player.SetData("PAYMENT", 0);
            player.SetData("INTERACTIONCHECK", 0);
            player.SetData("IN_HOSPITAL", false);
            player.SetData("MEDKITS", 0);
            player.SetData("GANGPOINT", -1);
            player.SetData("CUFFED_BY_COP", false);
            player.SetData("CUFFED_BY_MAFIA", false);
            player.SetData("IS_CALL_MECHANIC", false);
            NAPI.Data.SetEntityData(player, "CARROOM_CAR", null);
        }

        #region Jobs
        #region Jobs Selecting
        public static void openJobsSelecting(Player player)
        {
            Trigger.ClientEvent(player, "showJobMenu", Main.Players[player].LVL, Main.Players[player].WorkID);
        }
        [RemoteEvent("jobjoin")]
        public static void callback_jobsSelecting(Player Player, int act)
        {
            try
            {
                switch (act)
                {
                    case -1:
                        Layoff(Player);
                        return;
                    default:
                        JobJoin(Player, act);
                        return;
                }
            }
            catch (Exception e) { Log.Write("jobjoin: " + e.Message, nLog.Type.Error); }
        }
        #endregion
        #region GoPostal Job
        public static void openGoPostalStart(Player player)
        {
            Menu menu = new Menu("gopostal", false, false);
            menu.Callback = callback_gpStartMenu;

            Menu.Item menuItem = new Menu.Item("header", Menu.MenuItem.Header);
            menuItem.Text = "Lagerhaus";
            menu.Add(menuItem);

            menuItem = new Menu.Item("start", Menu.MenuItem.Button);
            menuItem.Text = "Starten";
            menu.Add(menuItem);

            menuItem = new Menu.Item("get", Menu.MenuItem.Button);
            menuItem.Text = "Pakete abholen";
            menu.Add(menuItem);

            menuItem = new Menu.Item("finish", Menu.MenuItem.Button);
            menuItem.Text = "Arbeit beenden";
            menu.Add(menuItem);

            menuItem = new Menu.Item("close", Menu.MenuItem.Button);
            menuItem.Text = "Schließen";
            menu.Add(menuItem);

            menu.Open(player);
        }

        private static void callback_gpStartMenu(Player Player, Menu menu, Menu.Item item, string eventName, dynamic data)
        {
            if (!Main.Players.ContainsKey(Player) || Player.Position.DistanceTo(Gopostal.Coords[0]) > 15)
            {
                MenuManager.Close(Player);
                return;
            }
            switch (item.ID)
            {
                case "start":
                    //if (Main.Players[Player].WorkID == 2)
                    //{
                        if (!NAPI.Data.GetEntityData(Player, "ON_WORK"))
                        {
                            if (Houses.HouseManager.Houses.Count == 0) return;
                            Player.SetData("PACKAGES", 10);
                            Notify.Send(Player, NotifyType.Info, NotifyPosition.MapUp, $"Du hast 10 Pakete, bringe sie nach Hause.", 3000);
                            Player.SetData("ON_WORK", true);

                            Player.SetData("W_LASTPOS", Player.Position);
                            Player.SetData("W_LASTTIME", DateTime.Now);
                            var next = Jobs.WorkManager.rnd.Next(0, Houses.HouseManager.Houses.Count - 1);
                            while (Houses.HouseManager.Houses[next].Position.DistanceTo2D(Player.Position) < 200)
                                next = Jobs.WorkManager.rnd.Next(0, Houses.HouseManager.Houses.Count - 1);

                            Player.SetData("NEXTHOUSE", Houses.HouseManager.Houses[next].ID);
                            Trigger.ClientEvent(Player, "createCheckpoint", 1, 1, Houses.HouseManager.Houses[next].Position, 1, 0, 255, 0, 0);
                            Trigger.ClientEvent(Player, "createWaypoint", Houses.HouseManager.Houses[next].Position.X, Houses.HouseManager.Houses[next].Position.Y);
                            Trigger.ClientEvent(Player, "createWorkBlip", Houses.HouseManager.Houses[next].Position);

                            var gender = Main.Players[Player].Gender;
                            Customization.ClearClothes(Player, gender);
                            if (gender)
                            {
                                Customization.SetHat(Player, 76, 10);
                                Player.SetClothes(11, 38, 3);
                                Player.SetClothes(4, 17, 0);
                                Player.SetClothes(6, 1, 7);
                                Player.SetClothes(3, Core.Customization.CorrectTorso[gender][38], 0);
                            }
                            else
                            {
                                Customization.SetHat(Player, 75, 10);
                                Player.SetClothes(11, 0, 6);
                                Player.SetClothes(4, 25, 2);
                                Player.SetClothes(6, 1, 2);
                                Player.SetClothes(3, Core.Customization.CorrectTorso[gender][0], 0);
                            }

                            int x = Jobs.WorkManager.rnd.Next(0, Gopostal.GoPostalObjects.Count);
                            BasicSync.AttachObjectToPlayer(Player, Jobs.Gopostal.GoPostalObjects[x], 60309, new Vector3(0.03, 0, 0.02), new Vector3(0, 0, 50));
                        }
                        else Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast bereits mit der Arbeit des Tages begonnen", 3000);
                    //}
                    //else Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, $"Вы не работаете курьером. Устроиться можно на бирже труда", 3000);
                    return;
                case "get":
                    {
                        /*if (Main.Players[Player].WorkID != 2)
                        {
                            Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, $"Вы не работаете курьером", 3000);
                            return;
                        }*/
                        if (!Player.GetData<bool>("ON_WORK"))
                        {
                            Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast den Tag nicht begonnen", 3000);
                            return;
                        }
                        if (Player.GetData<int>("PACKAGES") != 0)
                        {
                            Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast noch nicht alle Pakete verteilt. Du hast noch {Player.GetData<int>("PACKAGES")} Teile übrig", 3000);
                            return;
                        }
                        if (Houses.HouseManager.Houses.Count == 0) return;
                        Player.SetData("PACKAGES", 10);
                        Notify.Send(Player, NotifyType.Info, NotifyPosition.MapUp, $"Du hast 10 Pakete erhalten. Verteilen Sie sie an Haushalte", 3000);

                        Player.SetData("W_LASTPOS", Player.Position);
                        Player.SetData("W_LASTTIME", DateTime.Now);
                        var next = Jobs.WorkManager.rnd.Next(0, Houses.HouseManager.Houses.Count - 1);
                        while (Houses.HouseManager.Houses[next].Position.DistanceTo2D(Player.Position) < 200)
                            next = Jobs.WorkManager.rnd.Next(0, Houses.HouseManager.Houses.Count - 1);
                        Player.SetData("NEXTHOUSE", Houses.HouseManager.Houses[next].ID);

                        Trigger.ClientEvent(Player, "createCheckpoint", 1, 1, Houses.HouseManager.Houses[next].Position, 1, 0, 255, 0, 0);
                        Trigger.ClientEvent(Player, "createWaypoint", Houses.HouseManager.Houses[next].Position.X, Houses.HouseManager.Houses[next].Position.Y);
                        Trigger.ClientEvent(Player, "createWorkBlip", Houses.HouseManager.Houses[next].Position);

                        int y = Jobs.WorkManager.rnd.Next(0, Jobs.Gopostal.GoPostalObjects.Count);
                        BasicSync.AttachObjectToPlayer(Player, Jobs.Gopostal.GoPostalObjects[y], 60309, new Vector3(0.03, 0, 0.02), new Vector3(0, 0, 50));
                        return;
                    }
                case "finish":
                    //if (Main.Players[Player].WorkID == 2)
                   // {
                        if (NAPI.Data.GetEntityData(Player, "ON_WORK"))
                        {
                            Trigger.ClientEvent(Player, "deleteCheckpoint", 1, 0);
                            BasicSync.DetachObject(Player);

                            Notify.Send(Player, NotifyType.Info, NotifyPosition.MapUp, $"Du bist für den Tag fertig", 3000);
                            Trigger.ClientEvent(Player, "deleteWorkBlip");

                            Player.SetData("PAYMENT", 0);
                            Customization.ApplyCharacter(Player);
                            if (Player.HasData("HAND_MONEY")) Player.SetClothes(5, 45, 0);
                            else if (Player.HasData("HEIST_DRILL")) Player.SetClothes(5, 41, 0);

                            Player.SetData("PACKAGES", 0);
                            Player.SetData("ON_WORK", false);

                            if (Player.GetData<bool>("WORK") != null)
                            {
                                NAPI.Entity.DeleteEntity(Player.GetData<Vehicle>("WORK"));
                                Player.SetData<Vehicle>("WORK", null);
                            }
                        }
                        else Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, $"Du arbeitest nicht", 3000);

                    //}
                   // else Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, $"Вы не работаете курьером", 3000);
                    return;
                case "close":
                    MenuManager.Close(Player);
                    return;
            }
        }
        #endregion
        #region Truckers Job
        public static void OpenTruckersOrders(Player player)
        {
            Menu menu = new Menu("truckersorders", false, false);
            menu.Callback += callback_truckersorders;

            Menu.Item menuItem = new Menu.Item("header", Menu.MenuItem.Header);
            menuItem.Text = "Заказы";
            menu.Add(menuItem);

            Order order = null;
            List<string> ordersIDs = new List<string>();
            foreach (var o in BusinessManager.Orders)
            {
                var biz = BusinessManager.BizList[o.Value];
                var temp_order = biz.Orders.FirstOrDefault(or => or.UID == o.Key);
                if (temp_order == null || temp_order.Taked) continue;
                if (order == null) order = temp_order;
                ordersIDs.Add(o.Key.ToString());
            }

            if (ordersIDs.Count == 0)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Keine Aufträge vorhanden", 3000);
                return;
            }

            menuItem = new Menu.Item("products", Menu.MenuItem.List);
            menuItem.Elements = ordersIDs;
            menu.Add(menuItem);

            menuItem = new Menu.Item("Name", Menu.MenuItem.Card);
            menuItem.Text = $"Продукт: {order.Name}";
            menu.Add(menuItem);

            var youGet = Convert.ToInt32(order.Amount * BusinessManager.ProductsOrderPrice[order.Name] * 0.1);
            var max = Convert.ToInt32(2000 * Group.GroupPayAdd[Main.Accounts[player].VipLvl]);
            var min = Convert.ToInt32(500 * Group.GroupPayAdd[Main.Accounts[player].VipLvl]);
            if (youGet > max) youGet = max;
            else if (youGet < min) youGet = min;
            menuItem = new Menu.Item("youget", Menu.MenuItem.Card);
            menuItem.Text = $"Du erhältst: {youGet}$";
            menu.Add(menuItem);

            menuItem = new Menu.Item("take", Menu.MenuItem.Button);
            menuItem.Text = "Eine Bestellung aufgeben";
            menu.Add(menuItem);

            menuItem = new Menu.Item("close", Menu.MenuItem.Button);
            menuItem.Text = "Schließen";
            menu.Add(menuItem);

            menu.Open(player);
        }

        public static List<Vector3> getProduct = new List<Vector3>()
        {
            new Vector3(95.82169, 6363.628, 30.37586), // 24/7 products
            new Vector3(2786.021, 1575.39, 23.50065), // petrol products
            new Vector3(148.6672, 6362.376, 30.52923), // autos
            new Vector3(148.6672, 6362.376, 30.52923),
            new Vector3(148.6672, 6362.376, 30.52923),
            new Vector3(148.6672, 6362.376, 30.52923),
            new Vector3(2710.076, 3454.989, 55.31736), // gun products
            new Vector3(95.82169, 6363.628, 30.37586), // clothes
            new Vector3(95.82169, 6363.628, 30.37586), // burgershot
            new Vector3(95.82169, 6363.628, 30.37586), // tattoo-salon
            new Vector3(95.82169, 6363.628, 30.37586), // barber-shop
            new Vector3(95.82169, 6363.628, 30.37586), // mask-shop
            new Vector3(95.82169, 6363.628, 30.37586), // ls customs
            new Vector3(95.82169, 6363.628, 30.37586), // car wash
            new Vector3(95.82169, 6363.628, 30.37586), // petshop
        };

        private static void callback_truckersorders(Player Player, Menu menu, Menu.Item item, string eventName, dynamic data)
        {
            List<Order> orders = Player.GetData<List<Order>>("TRUCKERORDERLIST");
            switch (eventName)
            {
                case "listChangeright":
                case "listChangeleft":
                    {
                        var uid = Convert.ToInt32(data["1"]["Value"].ToString());
                        if (!BusinessManager.Orders.ContainsKey(uid)) return;

                        Business biz = BusinessManager.BizList[BusinessManager.Orders[uid]];
                        var order = biz.Orders.FirstOrDefault(o => o.UID == uid);

                        menu.Items[2].Text = $"Продукт: {order.Name}";
                        menu.Change(Player, 2, menu.Items[2]);

                        var youGet = Convert.ToInt32(order.Amount * BusinessManager.ProductsOrderPrice[order.Name] * 0.1);
                        var max = Convert.ToInt32(2000 * Group.GroupPayAdd[Main.Accounts[Player].VipLvl]);
                        var min = Convert.ToInt32(500 * Group.GroupPayAdd[Main.Accounts[Player].VipLvl]);
                        if (youGet > max) youGet = max;
                        else if (youGet < min) youGet = min;
                        menu.Items[3].Text = $"Du erhältst: {youGet}$";
                        menu.Change(Player, 3, menu.Items[3]);
                        return;
                    }
                case "button":
                    {
                        if (item.ID == "close")
                            MenuManager.Close(Player);
                        else
                        {
                            if (Player.HasData("ORDER"))
                            {
                                Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast den Auftrag bereits angenommen", 3000);
                                return;
                            }
                            var uid = Convert.ToInt32(data["1"]["Value"].ToString());
                            if (!BusinessManager.Orders.ContainsKey(uid))
                            {
                                Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, $"Dieser Auftrag existiert nicht mehr.", 3000);
                                return;
                            };

                            Business biz = BusinessManager.BizList[BusinessManager.Orders[uid]];
                            var order = biz.Orders.FirstOrDefault(o => o.UID == uid);
                            if (order == null || order.Taked)
                            {
                                Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, $"Jemand anderes hat diesen Auftrag bereits übernommen.", 3000);
                                return;
                            }

                            order.Taked = true;

                            Player.SetData("ORDERDATE", DateTime.Now.AddMinutes(6));

							Notify.Send(Player, NotifyType.Info, NotifyPosition.MapUp, $"Du hast einen Lieferauftrag {order.Name} in {BusinessManager.BusinessTypeNames[biz.Type]} angenommen. Beschaffe zunächst das Produkt", 3000);
                            var pos = getProduct[biz.Type];
                            Trigger.ClientEvent(Player, "createWaypoint", pos.X, pos.Y);
                            Player.SetData("ORDER", uid);
                            MenuManager.Close(Player);
                        }
                        return;
                    }
            }
        }
        #endregion
        #endregion
    }
}