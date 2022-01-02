using GTANetworkAPI;
using System.Collections.Generic;
using ULife.GUI;
using System;
using ULife.Core;
using UNL.SDK;

namespace ULife.Jobs
{
    class AutoMechanic : Script
    {
        public static List<CarInfo> CarInfos = new List<CarInfo>();
        public static void mechanicCarsSpawner()
        {
            for (int a = 0; a < CarInfos.Count; a++)
            {
                var veh = NAPI.Vehicle.CreateVehicle(CarInfos[a].Model, CarInfos[a].Position, CarInfos[a].Rotation.Z, CarInfos[a].Color1, CarInfos[a].Color2, CarInfos[a].Number);
                NAPI.Data.SetEntityData(veh, "ACCESS", "WORK");
                NAPI.Data.SetEntityData(veh, "WORK", 8);
                NAPI.Data.SetEntityData(veh, "TYPE", "MECHANIC");
                NAPI.Data.SetEntityData(veh, "NUMBER", a);
                NAPI.Data.SetEntityData(veh, "ON_WORK", false);
                NAPI.Data.SetEntityData(veh, "DRIVER", null);
                NAPI.Data.SetEntitySharedData(veh, "FUELTANK", 0);
                veh.SetSharedData("PETROL", VehicleManager.VehicleTank[veh.Class]); //Shared
                Core.VehicleStreaming.SetEngineState(veh, false);
                Core.VehicleStreaming.SetLockStatus(veh, false);
            }
        }
        private static nLog Log = new nLog("Mechanic");

        private static int mechanicRentCost = 100;
        private static Dictionary<Player, ColShape> orderCols = new Dictionary<Player, ColShape>();

        public static void mechanicRepair(Player player, Player target, int price)
        {
            if (Main.Players[player].WorkID != 8 || !player.GetData<bool>("ON_WORK"))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du arbeitest nicht hier", 3000);
                return;
            }
            if (!player.IsInVehicle || !player.Vehicle.HasData("TYPE") || player.Vehicle.GetData<string>("TYPE") != "MECHANIC")
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du musst dich an einem Arbeitsfahrzeug befinden", 3000);
                return;
            }
            if (!target.IsInVehicle)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"dein gegenüber muss sich in einem Fahrzeug befinden", 3000);
                return;
            }
            if (player.Vehicle.Position.DistanceTo(target.Vehicle.Position) > 5)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Dein gegenüber ist zu weit von dir weg", 3000);
                return;
            }
            if (price < 100 || price > 400)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du kannst den Preis von 100$ bis 400$ einstellen", 3000);
                return;
            }
            if (Main.Players[target].Money < price)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Dein gegenüber hat nicht genug Geld", 3000);
                return;
            }

            target.SetData("MECHANIC", player);
            target.SetData("MECHANIC_PRICE", price);
            Trigger.ClientEvent(target, "openDialog", "REPAIR_CAR", $"Der Bürger ({player.Value}) hat dir angeboten dein Auto für ${price} zu reperieren");

            Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Du hast deinen gegenüber angeboten ({target.Value})sein auto für {price}$ zu reperieren", 3000);
        }

        public static void mechanicRent(Player player)
        {
            if (!NAPI.Player.IsPlayerInAnyVehicle(player) || player.VehicleSeat != 0 || player.Vehicle.GetData<string>("TYPE") != "MECHANIC") return;

            Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Du hast dir das Auto gemietet, warte auf eine Bestellung", 3000);
            MoneySystem.Wallet.Change(player, -mechanicRentCost);
            GameLog.Money($"player({Main.Players[player].UUID})", $"server", mechanicRentCost, $"mechanicRent");
            var vehicle = player.Vehicle;
            NAPI.Data.SetEntityData(player, "WORK", vehicle);
            Core.VehicleStreaming.SetEngineState(vehicle, false);
            NAPI.Data.SetEntityData(player, "IN_WORK_CAR", true);
            NAPI.Data.SetEntityData(player, "ON_WORK", true);
            NAPI.Data.SetEntityData(vehicle, "DRIVER", player);
        }

        public static void mechanicPay(Player player)
        {
            if (!player.IsInVehicle)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du musst dich in einem Fahrzeug befinden", 3000);
                return;
            }

            var price = NAPI.Data.GetEntityData(player, "MECHANIC_PRICE");
            if (Main.Players[player].Money < price)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Nicht genug Geld", 3000);
                return;
            }

            VehicleManager.RepairCar(player.Vehicle);
            var driver = NAPI.Data.GetEntityData(player, "MECHANIC");
            MoneySystem.Wallet.Change(player, -price);
            MoneySystem.Wallet.Change(driver, price);
            GameLog.Money($"player({Main.Players[player].UUID})", $"player({Main.Players[driver].UUID})", price, $"mechanicRepair");
            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du hast die Reperatur bezahlt", 3000);
            Notify.Send(driver, NotifyType.Info, NotifyPosition.MapUp, $"Dein gegenüber ({player.Value}) hat für die Reperatur bezahlt", 3000);
            /*Commands.RPChat("me", driver, $"починил автомобиль");*/

            player.ResetData("MECHANIC_DRIVER");
            driver.ResetData("MECHANIC_Player");
            try
            {
                NAPI.ColShape.DeleteColShape(orderCols[player]);
                orderCols.Remove(player);
            }
            catch { }
        }

        private static void order_onEntityExit(ColShape shape, Player player)
        {
            if (shape.GetData<Player>("MECHANIC_Player") != player) return;

            if (player.HasData("MECHANIC_DRIVER"))
            {
                Player driver = player.GetData<Player>("MECHANIC_DRIVER");
                driver.ResetData("MECHANIC_Player");
                player.ResetData("MECHANIC_DRIVER");
                player.SetData("IS_CALL_MECHANIC", false);
                Notify.Send(driver, NotifyType.Warning, NotifyPosition.MapUp, $"Der Kunde hat die Bestellung Stoniert", 3000);
                Notify.Send(player, NotifyType.Warning, NotifyPosition.MapUp, $"Du hast den Bereich verlassen, wo du den Mechaniker gerufen hast", 3000);
                try
                {
                    NAPI.ColShape.DeleteColShape(orderCols[player]);
                    orderCols.Remove(player);
                }
                catch { }
            }
        }

        [ServerEvent(Event.PlayerEnterVehicle)]
        public void Event_onPlayerEnterVehicleHandler(Player player, Vehicle vehicle, sbyte seatid)
        {
            try
            {
                if (NAPI.Data.GetEntityData(vehicle, "TYPE") != "MECHANIC") return;
                if (seatid == 0)
                {
                    if (!Main.Players[player].Licenses[1])
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast keine Lizenz der Kategorie B", 3000);
                        VehicleManager.WarpPlayerOutOfVehicle(player);
                        return;
                    }
                    if (Main.Players[player].WorkID == 8)
                    {
                        if (NAPI.Data.GetEntityData(player, "WORK") == null)
                        {
                            if (vehicle.GetData<Player>("DRIVER") != null)
                            {
                                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Dieses Auto ist bereits in benutzung", 3000);
                                return;
                            }
                            if (Main.Players[player].Money >= mechanicRentCost)
                            {
                                Trigger.ClientEvent(player, "openDialog", "MECHANIC_RENT", $"Das Fahrzeug mieten für ${mechanicRentCost}?");
                            }
                            else
                            {
                                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast nicht genug " + (mechanicRentCost - Main.Players[player].Money) + "$ Geld um das Fahrzeug zu mieten", 3000);
                                VehicleManager.WarpPlayerOutOfVehicle(player);
                            }
                        }
                        else if (NAPI.Data.GetEntityData(player, "WORK") == vehicle) NAPI.Data.SetEntityData(player, "IN_WORK_CAR", true);
                        else Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du arbeitest bereits", 3000);
                    }
                    else
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du arbeitest nicht als Automechaniker, du kannst einen Job bei der Arbeitsagentur bekommen", 3000);
                        VehicleManager.WarpPlayerOutOfVehicle(player);
                    }
                }
            }
            catch (Exception e) { Log.Write("PlayerEnterVehicle: " + e.Message, nLog.Type.Error); }
        }

        public static void respawnCar(Vehicle veh)
        {
            try
            {
                int i = NAPI.Data.GetEntityData(veh, "NUMBER");
                NAPI.Entity.SetEntityPosition(veh, CarInfos[i].Position);
                NAPI.Entity.SetEntityRotation(veh, CarInfos[i].Rotation);
                VehicleManager.RepairCar(veh);
                NAPI.Data.SetEntityData(veh, "ACCESS", "WORK");
                NAPI.Data.SetEntityData(veh, "WORK", 8);
                NAPI.Data.SetEntityData(veh, "TYPE", "MECHANIC");
                NAPI.Data.SetEntityData(veh, "NUMBER", i);
                NAPI.Data.SetEntityData(veh, "ON_WORK", false);
                NAPI.Data.SetEntityData(veh, "DRIVER", null);
                NAPI.Data.SetEntitySharedData(veh, "FUELTANK", 0);
                Core.VehicleStreaming.SetEngineState(veh, false);
                Core.VehicleStreaming.SetLockStatus(veh, false);
                veh.SetSharedData("PETROL", VehicleManager.VehicleTank[veh.Class]); //Shared
            }
            catch (Exception e) { Log.Write("RespawnCar: " + e.Message, nLog.Type.Error); }
        }

        public static void onPlayerDissconnectedHandler(Player player, DisconnectionType type, string reason)
        {
            try
            {
                if (!Main.Players.ContainsKey(player)) return;
                if (player.HasData("MECHANIC_DRIVER"))
                {
                    Player driver = player.GetData<Player>("MECHANIC_DRIVER");
                    driver.ResetData("MECHANIC_Player");
                    Notify.Send(driver, NotifyType.Warning, NotifyPosition.MapUp, $"Der Kunde hat die Bestellung stoniert", 3000);
                    try
                    {
                        NAPI.ColShape.DeleteColShape(orderCols[player]);
                        orderCols.Remove(player);
                    }
                    catch { }
                }
                if ((Main.Players[player].WorkID == 8 && NAPI.Data.GetEntityData(player, "ON_WORK") && NAPI.Data.GetEntityData(player, "WORK") != null))
                {
                    var vehicle = NAPI.Data.GetEntityData(player, "WORK");
                    respawnCar(vehicle);
                    if (player.HasData("MECHANIC_Player"))
                    {
                        Player Player = player.GetData<Player>("MECHANIC_Player");
                        Player.ResetData("MECHANIC_DRIVER");
                        Player.SetData("IS_CALL_MECHANIC", false);
                        Notify.Send(Player, NotifyType.Warning, NotifyPosition.MapUp, $"Der Mechaniker hat den Arbeitsplatz verlassen, mache einen neuen Auftrag", 3000);
                        try
                        {
                            NAPI.ColShape.DeleteColShape(orderCols[Player]);
                            orderCols.Remove(Player);
                        }
                        catch { }
                    }
                }
            }
            catch (Exception e) { Log.Write("PlayerDisconnected: " + e.Message, nLog.Type.Error); }
        }

        [ServerEvent(Event.PlayerExitVehicle)]
        public void Event_onPlayerExitVehicleHandler(Player player, Vehicle vehicle)
        {
            try
            {
                if (NAPI.Data.GetEntityData(vehicle, "ACCESS") == "WORK" &&
                Main.Players[player].WorkID == 8 &&
                NAPI.Data.GetEntityData(player, "WORK") == vehicle)
                {
                    Notify.Send(player, NotifyType.Warning, NotifyPosition.MapUp, $"Wenn du nicht in 5 Minuten einen Transport bekommen, ist der Arbeitstag vorbei.", 3000);
                    NAPI.Data.SetEntityData(player, "IN_WORK_CAR", false);
                    if (player.HasData("WORK_CAR_EXIT_TIMER"))
                        //Main.StopT(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"), "timer_1");
                        Timers.Stop(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"));
                    NAPI.Data.SetEntityData(player, "CAR_EXIT_TIMER_COUNT", 0);
                    //NAPI.Data.SetEntityData(player, "WORK_CAR_EXIT_TIMER", Main.StartT(1000, 1000, (o) => timer_playerExitWorkVehicle(player, vehicle), "AUM_EXIT_CAR_TIMER"));
                    NAPI.Data.SetEntityData(player, "WORK_CAR_EXIT_TIMER", Timers.Start(1000, () => timer_playerExitWorkVehicle(player, vehicle)));
                }
            }
            catch (Exception e) { Log.Write("PlayerExit: " + e.Message, nLog.Type.Error); }
        }

        private void timer_playerExitWorkVehicle(Player player, Vehicle vehicle)
        {
            NAPI.Task.Run(() =>
            {
                try
                {
                    if (!player.HasData("WORK_CAR_EXIT_TIMER")) return;
                    if (NAPI.Data.GetEntityData(player, "IN_WORK_CAR"))
                    {
                        //Main.StopT(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"), "timer_2");
                        Timers.Stop(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"));
                        NAPI.Data.ResetEntityData(player, "WORK_CAR_EXIT_TIMER");
                        return;
                    }
                    if (NAPI.Data.GetEntityData(player, "CAR_EXIT_TIMER_COUNT") > 300)
                    {
                        Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Du bist für den Tag fertig", 3000);
                        respawnCar(vehicle);
                        player.SetData<bool>("ON_WORK", false);
                        player.SetData<Vehicle>("WORK", null);
                        //Main.StopT(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"), "timer_3");
                        Timers.Stop(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"));
                        NAPI.Data.ResetEntityData(player, "WORK_CAR_EXIT_TIMER");
                        if (player.HasData("MECHANIC_Player"))
                        {
                            Player Player = player.GetData<Player>("MECHANIC_Player");
                            Player.ResetData("MECHANIC_DRIVER");
                            Player.SetData("IS_CALL_MECHANIC", false);
                            Notify.Send(player, NotifyType.Warning, NotifyPosition.MapUp, $"Der Mechaniker hat den Arbeitsplatz verlassen, mache einen neuen Auftrag", 3000);
                            player.ResetData("MECHANIC_Player");
                            try
                            {
                                NAPI.ColShape.DeleteColShape(orderCols[Player]);
                                orderCols.Remove(Player);
                            }
                            catch { }
                        }
                        return;
                    }
                    NAPI.Data.SetEntityData(player, "CAR_EXIT_TIMER_COUNT", NAPI.Data.GetEntityData(player, "CAR_EXIT_TIMER_COUNT") + 1);

                }
                catch (Exception e)
                {
                    Log.Write("Timer_PlayerExitWorkVehicle:\n" + e.ToString(), nLog.Type.Error);
                }
            });
        }

        public static void acceptMechanic(Player player, Player target)
        {
            if (Main.Players[player].WorkID == 8 && player.GetData<bool>("ON_WORK"))
            {
                if (player.HasData("MECHANIC_Player"))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast den Auftrag bereits angenommen", 3000);
                    return;
                }
                if (NAPI.Data.GetEntityData(target, "IS_CALL_MECHANIC") && !target.HasData("MECHANIC_DRIVER"))
                {
                    Notify.Send(target, NotifyType.Warning, NotifyPosition.MapUp, $"Dein gegenüber ({player.Value}) hat den Auftrag angenommen, er ist auf den Weg zu dir", 3000);
                    Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Вы приняли вызов игрока ({target.Value})", 3000);
                    Trigger.ClientEvent(player, "createWaypoint", NAPI.Entity.GetEntityPosition(target).X, NAPI.Entity.GetEntityPosition(target).Y);

                    target.SetData("MECHANIC_DRIVER", player);
                    player.SetData("MECHANIC_Player", target);

                    orderCols.Add(target, NAPI.ColShape.CreateCylinderColShape(target.Position, 10F, 10F, 0));
                    orderCols[target].SetData("MECHANIC_Player", target);
                    orderCols[target].OnEntityExitColShape += order_onEntityExit;
                }
                else Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Mechaniker wurde nicht angerufen", 3000);
            }
            else Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du bist gerade nicht als Mechaniker tätig", 3000);
        }

        public static void cancelMechanic(Player player)
        {
            if (player.HasData("MECHANIC_Player"))
            {
                Player Player = player.GetData<Player>("MECHANIC_Player");
                Player.ResetData("MECHANIC_DRIVER");
                Player.SetData("IS_CALL_MECHANIC", false);
                player.ResetData("MECHANIC_Player");
                Notify.Send(Player, NotifyType.Warning, NotifyPosition.MapUp, $"Der Mechaniker hat den Arbeitsplatz verlassen, mache einen neuen Auftrag", 3000);
                Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Du hast den Auftrag abgesagt", 3000);
                try
                {
                    NAPI.ColShape.DeleteColShape(orderCols[Player]);
                    orderCols.Remove(Player);
                }
                catch { }
                return;
            }
            if (NAPI.Data.GetEntityData(player, "IS_CALL_MECHANIC"))
            {
                NAPI.Data.SetEntityData(player, "IS_CALL_MECHANIC", false);
                Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Du hast den Kontakt mit dem Mechaniker abgebrochen", 3000);
                if (player.HasData("MECHANIC_DRIVER"))
                {
                    Player driver = player.GetData<Player>("MECHANIC_DRIVER");
                    driver.ResetData("MECHANIC_Player");
                    player.ResetData("MECHANIC_DRIVER");
                    Notify.Send(driver, NotifyType.Warning, NotifyPosition.MapUp, $"Der Kunde hat die Bestellung stoniert", 3000);
                    try
                    {
                        NAPI.ColShape.DeleteColShape(orderCols[player]);
                        orderCols.Remove(player);
                    }
                    catch { }
                }
            }
            else Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast keinen Mechaniker gerufen.", 3000);
        }

        public static void callMechanic(Player player)
        {
            if (!NAPI.Data.GetEntityData(player, "IS_CALL_MECHANIC"))
            {
                List<Player> players = NAPI.Pools.GetAllPlayers();
                var i = 0;
                foreach (var p in players)
                {
                    if (p == null || !Main.Players.ContainsKey(p)) continue;
                    if (Main.Players[p].WorkID == 8 && NAPI.Data.GetEntityData(p, "ON_WORK"))
                    {
                        i++;
                        NAPI.Chat.SendChatMessageToPlayer(p, $"~g~[DISPATCHER]: ~w~Der Spieler ({player.Value}) hat ~y~({player.Position.DistanceTo(p.Position)}m)~w~ angerufen. Schreiben Sie ~y~/ ~b~[ID]~w~, um den Auftrag anzunehmen");
                    }
                }
                if (i > 0)
                {
                    NAPI.Data.SetEntityData(player, "IS_CALL_MECHANIC", true);
                    Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Rechne damit, einen Anruf zu erhalten. Es gibt jetzt {i} Automechaniker in Ihrer Nähe. Verwende /cmechanic, um den Anruf abzubrechen", 3000);
                }
                else Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Es befinden sich im moment keine Mechaniker in deiner Nähe, versuche es später noch einmal", 3000);
            }
            else Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast bereits einen Automechaniker hinzugezogen. Um abzubrechen, gebe /cmechanic ein", 3000);
        }

        public static void buyFuel(Player player, int fuel)
        {
            if (!Main.Players.ContainsKey(player)) return;
            if (Main.Players[player].WorkID != 8 || !player.GetData<bool>("ON_WORK") || !player.IsInVehicle || player.GetData<Vehicle>("WORK") != player.Vehicle)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du musst als Automechaniker arbeiten und in einem funktionierenden Auto sein", 3000);
                return;
            }
            if (player.GetData<int>("BIZ_ID") == -1 || BusinessManager.BizList[player.GetData<int>("BIZ_ID")].Type != 1)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du musst an der Tankstelle sein", 3000);
                return;
            }
            if (fuel <= 0)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Richtige Daten eingeben", 3000);
                return;
            }
            Business biz = BusinessManager.BizList[player.GetData<int>("BIZ_ID")];
            if (Main.Players[player].Money < biz.Products[0].Price * fuel)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Nicht genug Geld", 3000);
                return;
            }
            if (player.Vehicle.GetSharedData<int>("FUELTANK") + fuel > 1000)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Benzintank ist voll", 3000);
                return;
            }
            if (!BusinessManager.takeProd(biz.ID, fuel, biz.Products[0].Name, biz.Products[0].Price * fuel))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Nicht genügend Kraftstoff an der Tankstelle", 3000);
                return;
            }
            MoneySystem.Wallet.Change(player, -biz.Products[0].Price * fuel);
            GameLog.Money($"player({Main.Players[player].UUID})", $"biz({biz.ID})", biz.Products[0].Price * fuel, $"mechanicBuyFuel");
            player.Vehicle.SetSharedData("FUELTANK", player.Vehicle.GetSharedData<int>("FUELTANK") + fuel);
            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du hast den Tank nachgefüllt, es wurden {player.Vehicle.GetSharedData<int>("FUELTANK")}Liter getankt", 3000);
        }

        public static void mechanicFuel(Player player, Player target, int fuel, int pricePerLitr)
        {
            if (Main.Players[player].WorkID != 8 || !player.GetData<bool>("ON_WORK"))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du arbeitest nicht als Automechaniker", 3000);
                return;
            }
            if (!player.IsInVehicle || !player.Vehicle.HasData("TYPE") || player.Vehicle.GetData<string>("TYPE") != "MECHANIC")
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du musst dich in einem Arbeitsfahrzeug befinden", 3000);
                return;
            }
            if (!target.IsInVehicle)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Bürger muss sich im Fahrzeug befinden", 3000);
                return;
            }
            if (player.Vehicle.Position.DistanceTo(target.Vehicle.Position) > 5)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler ist zu weit von Ihnen entfernt", 3000);
                return;
            }
            if (fuel < 1)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du kannst nicht weniger als einen Liter verkaufen", 3000);
                return;
            }
            if (pricePerLitr < 2 || pricePerLitr > 10)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du kannst den Preis von $2 bis $10 pro Liter einstellen", 3000);
                return;
            }
            if (Main.Players[target].Money < pricePerLitr * fuel)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Bürger hat nicht genug Geld", 3000);
                return;
            }

            target.SetData("MECHANIC", player);
            target.SetData("MECHANIC_PRICE", pricePerLitr);
            target.SetData("MECHANIC_FEUL", fuel);
            Trigger.ClientEvent(target, "openDialog", "FUEL_CAR", $"Spieler ({player.Value}) angeboten, Ihr Fahrzeug zu tanken bei {fuel} für ${fuel * pricePerLitr}");

            Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Du hast deinen gegenüber ({target.Value}) angeboten sein Fahrzeug zu betanken bie {fuel} für {fuel * pricePerLitr}$.", 3000);
        }

        public static void mechanicPayFuel(Player player)
        {
            if (!player.IsInVehicle)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du musst dich in einem Fahrzeug befinden", 3000);
                return;
            }

            var price = NAPI.Data.GetEntityData(player, "MECHANIC_PRICE");
            var fuel = NAPI.Data.GetEntityData(player, "MECHANIC_FEUL");
            if (Main.Players[player].Money < price * fuel)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Nicht genug Geld", 3000);
                return;
            }

            Player driver = NAPI.Data.GetEntityData(player, "MECHANIC");

            if (!driver.IsInVehicle || !driver.Vehicle.HasData("TYPE") || driver.Vehicle.GetData<string>("TYPE") != "MECHANIC")
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Mechaniker muss sich im Fahrzeug befinden", 3000);
                return;
            }

            if (driver.Vehicle.GetData<object>("FUELTANK") < fuel) //Shared
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Mechaniker hat nicht genug Kraftstoff, dabei um dein Auto zu betanken", 3000);
                return;
            }

            MoneySystem.Wallet.Change(player, -price * fuel);
            MoneySystem.Wallet.Change(driver, price * fuel);
            GameLog.Money($"player({Main.Players[player].UUID})", $"player({Main.Players[driver].UUID})", price * fuel, $"mechanicFuel");
            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du hast die Reperatur bezahlt", 3000);
            Notify.Send(driver, NotifyType.Info, NotifyPosition.MapUp, $"Der Kunde ({player.Value}) hat für die Fahrzeugbetankung bezahlt", 3000);
            /*Commands.RPChat("me", driver, $"заправил транспортное средство");*/

            var carFuel = (player.Vehicle.GetData<object>("PETROL") + fuel > player.Vehicle.GetData<object>("MAXPETROL")) ? player.Vehicle.GetData<object>("MAXPETROL") : player.Vehicle.GetData<object>("PETROL") + fuel;
            player.Vehicle.SetData("PETROL", carFuel);
            driver.Vehicle.SetData("FUELTANK", driver.Vehicle.GetData<object>("FUELTANK") - fuel);
            player.ResetData("MECHANIC_DRIVER");
            driver.ResetData("MECHANIC_Player");
            try
            {
                NAPI.ColShape.DeleteColShape(orderCols[player]);
                orderCols.Remove(player);
            }
            catch { }
        }
    }
}
