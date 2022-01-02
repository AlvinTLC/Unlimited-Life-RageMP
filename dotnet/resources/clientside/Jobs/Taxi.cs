using GTANetworkAPI;
using System.Collections.Generic;
using ULife.GUI;
using System;
using ULife.Core;
using UNL.SDK;

namespace ULife.Jobs
{
    class Taxi : Script
    {
        public static List<CarInfo> CarInfos = new List<CarInfo>();
        public static void taxiCarsSpawner()
        {
            for (int a = 0; a < CarInfos.Count; a++)
            {
                var veh = NAPI.Vehicle.CreateVehicle(CarInfos[a].Model, CarInfos[a].Position, CarInfos[a].Rotation.Z, CarInfos[a].Color1, CarInfos[a].Color2, CarInfos[a].Number);
                NAPI.Data.SetEntityData(veh, "ACCESS", "WORK");
                NAPI.Data.SetEntityData(veh, "WORK", 3);
                NAPI.Data.SetEntityData(veh, "TYPE", "TAXI");
                NAPI.Data.SetEntityData(veh, "NUMBER", a);
                NAPI.Data.SetEntityData(veh, "DRIVER", null);
                NAPI.Data.SetEntityData(veh, "ON_WORK", false);
                veh.SetSharedData("PETROL", VehicleManager.VehicleTank[veh.Class]); //Shared
                Core.VehicleStreaming.SetEngineState(veh, false);
                Core.VehicleStreaming.SetLockStatus(veh, false);
            }
        }
        private static nLog Log = new nLog("Taxi");

        private static int taxiRentCost = 200;
        private static Dictionary<Player, ColShape> orderCols = new Dictionary<Player, ColShape>();

        public static void taxiRent(Player player)
        {
            if (NAPI.Player.IsPlayerInAnyVehicle(player) && player.VehicleSeat == 0 && player.Vehicle.GetData<string>("TYPE") == "TAXI")
            {
                if (player.Vehicle.GetData<Player>("DRIVER") == null)
                {
                    var vehicle = player.Vehicle;
                    NAPI.Data.SetEntityData(player, "WORK", vehicle);
                    NAPI.Data.SetEntityData(player, "IN_WORK_CAR", true);

                    NAPI.Data.SetEntityData(vehicle, "DRIVER", player);
                    vehicle.SetData("ON_WORK", true);

                    if (!MoneySystem.Wallet.Change(player, -taxiRentCost))
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Nicht genug Geld", 3000);
                        return;
                    }
                    GameLog.Money($"player({Main.Players[player].UUID})", $"server", taxiRentCost, $"taxiRent");
                    Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Du hast dir ein Taxi gemietet, um den Fahrgästen zu sagen das Geld zu bezahlen gib /tprice ein [ID] [Preis]", 3000);
                    Core.VehicleStreaming.SetEngineState(vehicle, false);
                }
            }
        }

        public static void taxiPay(Player player)
        {
            var seller = player.GetData<Player>("TAXI_SELLER");
            var price = player.GetData<int>("TAXI_PAY");

            if (!Main.Players.ContainsKey(seller)) return;

            if (!MoneySystem.Wallet.Change(player, -price))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Недостаточно денег", 3000);
                return;
            }
            MoneySystem.Wallet.Change(seller, price);
            GameLog.Money($"player({Main.Players[player].UUID})", $"player({Main.Players[seller].UUID})", taxiRentCost, $"taxiPay");
            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du hast dein Fahrgeld bezahlt", 3000);
            Notify.Send(seller, NotifyType.Info, NotifyPosition.MapUp, $"Spieler " + player.Name.Replace('_', ' ') + " den Fahrpreis bezahlt.", 3000);
        }

        private static void order_onEntityExit(ColShape shape, Player player)
        {
            try
            {
                if (shape.GetData<Player>("PASSAGER") != player) return;

                if (player.HasData("TAXI_DRIVER"))
                {
                    Player driver = player.GetData<Player>("TAXI_DRIVER");
                    driver.ResetData("PASSAGER");
                    player.ResetData("TAXI_DRIVER");
                    player.SetData("IS_CALL_TAXI", false);
                    Notify.Send(driver, NotifyType.Warning, NotifyPosition.MapUp, $"Der Fahrgast hat die Reservierung storniert", 3000);
                    Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du hast den Ort verlassen, an dem du das Taxi gerufen hast", 3000);
                    try
                    {
                        NAPI.ColShape.DeleteColShape(orderCols[player]);
                        orderCols.Remove(player);
                    }
                    catch { }
                }
            }
            catch (Exception ex) { Log.Write("order_onEntityExit: " + ex.Message, nLog.Type.Error); }
        }

        [ServerEvent(Event.PlayerEnterVehicle)]
        public void onPlayerEnterVehicleHandler(Player player, Vehicle vehicle, sbyte seatid)
        {
            try
            {
                if (NAPI.Data.GetEntityData(vehicle, "TYPE") != "TAXI") return;
                if (seatid == 0)
                {
                    if (!Main.Players[player].Licenses[1])
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du besitzt keine Lizenz der Kategorie B", 3000);
                        VehicleManager.WarpPlayerOutOfVehicle(player);
                        return;
                    }
                    Main.Players[player].WorkID = 3;
                    if (Main.Players[player].WorkID == 3)
                    {
                        if (NAPI.Data.GetEntityData(player, "WORK") == null)
                        {
                            if (vehicle.GetData<Player>("DRIVER") != null)
                            {
                                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Dieses Taxi ist schon besetzt", 3000);
                                return;
                            }
                            if (Main.Players[player].Money >= taxiRentCost)
                            {
                                Trigger.ClientEvent(player, "openDialog", "TAXI_RENT", $"Miete ein Taxi für ${taxiRentCost}?");
                            }
                            else
                            {
                                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast nicht genug " + (taxiRentCost - Main.Players[player].Money) + "$ für Taximieten", 3000);
                                VehicleManager.WarpPlayerOutOfVehicle(player);
                            }
                        }
                        else if (NAPI.Data.GetEntityData(player, "WORK") == vehicle) NAPI.Data.SetEntityData(player, "IN_WORK_CAR", true);
                        else Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du arbeitest bereits", 3000);
                    }
                    else
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du arbeitest nicht als Taxifahrer, du kannst dir bei der Arbeitsargentur einen Job besorgen", 3000);
                        VehicleManager.WarpPlayerOutOfVehicle(player);
                    }
                }
                else
                {
                    if (NAPI.Data.GetEntityData(vehicle, "DRIVER") != null)
                    {
                        Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, "Wenn du deine Route an den Fahrer senden möchtest, setze eine Markierung auf der Karte und drücke Y.", 5000);
                        var driver = NAPI.Data.GetEntityData(vehicle, "DRIVER");
                        if (driver.HasData("PASSAGER") && driver.GetData("PASSAGER") == player)
                        {
                            driver.ResetData("PASSAGER");
                            player.SetData("IS_CALL_TAXI", false);
                            //player.ResetData("TAXI_DRIVER");
                            try
                            {
                                NAPI.ColShape.DeleteColShape(orderCols[player]);
                                orderCols.Remove(player);
                            }
                            catch { }
                        }
                    }
                    else
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Es ist kein Fahrer im Auto", 3000);
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
                NAPI.Data.SetEntityData(veh, "WORK", 3);
                NAPI.Data.SetEntityData(veh, "TYPE", "TAXI");
                NAPI.Data.SetEntityData(veh, "NUMBER", i);
                NAPI.Data.SetEntityData(veh, "DRIVER", null);
                NAPI.Data.SetEntityData(veh, "ON_WORK", false);
                Core.VehicleStreaming.SetEngineState(veh, false);
                Core.VehicleStreaming.SetLockStatus(veh, false);
                veh.SetSharedData("PETROL", VehicleManager.VehicleTank[veh.Class]); //Shared
            }
            catch (Exception e) { Log.Write($"respawnCar: " + e.Message, nLog.Type.Error); }
        }

        public static void onPlayerDissconnectedHandler(Player player, DisconnectionType type, string reason)
        {
            try
            {
                if (!Main.Players.ContainsKey(player)) return;
                if (player.HasData("TAXI_DRIVER"))
                {
                    Player driver = player.GetData<Player>("TAXI_DRIVER");
                    driver.ResetData("PASSAGER");
                    Notify.Send(driver, NotifyType.Warning, NotifyPosition.MapUp, $"Der Fahrgast hat die Reservierung storniert", 3000);
                    try
                    {
                        NAPI.ColShape.DeleteColShape(orderCols[player]);
                        orderCols.Remove(player);
                    }
                    catch { }
                }
                if (Main.Players[player].WorkID == 3 && NAPI.Data.GetEntityData(player, "WORK") != null)
                {
                    var vehicle = NAPI.Data.GetEntityData(player, "WORK");
                    NAPI.Task.Run(() => { try { respawnCar(vehicle); } catch { } });
                    if (player.HasData("PASSAGER"))
                    {
                        Player passager = player.GetData<Player>("PASSAGER");
                        passager.ResetData("TAXI_DRIVER");
                        passager.SetData("IS_CALL_TAXI", false);
                        Notify.Send(passager, NotifyType.Warning, NotifyPosition.MapUp, $"Taxifahrer hat den Arbeitsplatz verlassen, mache einen neuen Auftrag", 3000);
                        NAPI.Task.Run(() => {
                            try
                            {
                                NAPI.ColShape.DeleteColShape(orderCols[passager]);
                                orderCols.Remove(passager);
                            }
                            catch { }
                        });
                    }
                }
            }
            catch (Exception e) { Log.Write("PlayerDisconnected: " + e.Message, nLog.Type.Error); }
        }

        [ServerEvent(Event.PlayerExitVehicle)]
        public void onPlayerExitVehicleHandler(Player player, Vehicle vehicle)
        {
            try
            {
                if (NAPI.Data.GetEntityData(vehicle, "ACCESS") == "WORK" &&
                Main.Players[player].WorkID == 3 &&
                NAPI.Data.GetEntityData(player, "WORK") == vehicle)
                {
                    Notify.Send(player, NotifyType.Warning, NotifyPosition.MapUp, $"Wenn du nicht in 5 Minuten einen Auftrag bekommst, ist dein Arbeitstag vorbei.", 3000);
                    NAPI.Data.SetEntityData(player, "IN_WORK_CAR", false);
                    if (player.HasData("WORK_CAR_EXIT_TIMER"))
                        //Main.StopT(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"), "WORK_CAR_EXIT_TIMER_taxi_1");
                        Timers.Stop(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"));
                    NAPI.Data.SetEntityData(player, "CAR_EXIT_TIMER_COUNT", 0);
                    //NAPI.Data.SetEntityData(player, "WORK_CAR_EXIT_TIMER", Main.StartT(1000, 1000, (o) => timer_playerExitWorkVehicle(player, vehicle), "TAXI_CAR_EXIT_TIMER"));
                    NAPI.Data.SetEntityData(player, "WORK_CAR_EXIT_TIMER", Timers.StartTask(1000, () => timer_playerExitWorkVehicle(player, vehicle)));
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
                        //Main.StopT(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"), "WORK_CAR_EXIT_TIMER_taxi_2");
                        Timers.Stop(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"));
                        NAPI.Data.ResetEntityData(player, "WORK_CAR_EXIT_TIMER");
                        return;
                    }
                    if (NAPI.Data.GetEntityData(player, "CAR_EXIT_TIMER_COUNT") > 300)
                    {
                        Main.Players[player].WorkID = 0;
                        Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Du bist fertig für den Tag", 3000);
                        respawnCar(vehicle);
                        player.SetData<bool>("ON_WORK", false);
                        player.SetData<Vehicle>("WORK", null);
                        //Main.StopT(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"), "WORK_CAR_EXIT_TIMER_taxi_3");
                        Timers.Stop(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"));
                        NAPI.Data.ResetEntityData(player, "WORK_CAR_EXIT_TIMER");
                        if (player.HasData("PASSAGER"))
                        {
                            Player passager = player.GetData<Player>("PASSAGER");
                            passager.ResetData("TAXI_DRIVER");
                            passager.SetData("IS_CALL_TAXI", false);
                            Notify.Send(player, NotifyType.Warning, NotifyPosition.MapUp, $"Taxifahrer hat den Arbeitsplatz verlassen, mache einen neuen Auftrag", 3000);
                            player.ResetData("PASSAGER");
                            try
                            {
                                NAPI.ColShape.DeleteColShape(orderCols[passager]);
                                orderCols.Remove(passager);
                            }
                            catch { }
                        }
                        return;
                    }
                    NAPI.Data.SetEntityData(player, "CAR_EXIT_TIMER_COUNT", NAPI.Data.GetEntityData(player, "CAR_EXIT_TIMER_COUNT") + 1);
                }
                catch (Exception e) { Log.Write("taxi_exitVehicleTimer: " + e.Message); }
            });
        }

        public static void offerTaxiPay(Player player, Player target, int price)
        {
            if (Main.Players[player].WorkID == 3)
            {
                if (NAPI.Data.GetEntityData(player, "WORK") != null)
                {
                    if (!target.IsInVehicle || player.Position.DistanceTo(target.Position) > 2) return;
                    if (!NAPI.Player.IsPlayerInAnyVehicle(player) || player.VehicleSeat != 0 || player.Vehicle != player.GetData<Vehicle>("WORK") || player.Vehicle != target.Vehicle) return;
                    var vehicle = player.Vehicle;
                    if (NAPI.Data.GetEntityData(vehicle, "TYPE") == "TAXI")
                    {
                        if (price > 2000 || price < 100)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du kannst den Preis nicht über $2.000 oder unter $20 festlegen", 3000);
                            return;
                        }
                        if (Main.Players[target].Money < price)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Dein Gast hat nicht genug Geld", 3000);
                            return;
                        }

                        Trigger.ClientEvent(target, "openDialog", "TAXI_PAY", $"Fahrpreis bezahlen ${price}?");
                        target.SetData("TAXI_SELLER", player);
                        target.SetData("TAXI_PAY", price);

                        Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Du hast dem Spieler ({target.Value}) angeboten, die Fahrt zu bezahlen für {price}$", 3000);
                    }
                }
                else Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du arbeitest im moment nicht", 3000);
            }
            else Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du arbeitest nicht als Taxifahrer", 3000);
        }

        public static void acceptTaxi(Player player, Player target)
        {
            if (Main.Players[player].WorkID == 3 && NAPI.Data.GetEntityData(player, "WORK") != null)
            {
                if (player.HasData("PASSAGER"))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast den Auftrag bereits angenommen", 3000);
                    return;
                }
                if (NAPI.Data.GetEntityData(target, "IS_CALL_TAXI") && !target.HasData("TAXI_DRIVER"))
                {
                    Notify.Send(target, NotifyType.Warning, NotifyPosition.MapUp, $"Der Taxifahrer ({player.Value}) hat dein Auftrag angenommen. Bleibe, wo du bist", 3000);
                    Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Вы приняли вызов игрока ({target.Value})", 3000);
                    Trigger.ClientEvent(player, "createWaypoint", NAPI.Entity.GetEntityPosition(target).X, NAPI.Entity.GetEntityPosition(target).Y);

                    target.SetData("TAXI_DRIVER", player);
                    player.SetData("PASSAGER", target);

                    orderCols.Add(target, NAPI.ColShape.CreateCylinderColShape(target.Position, 10F, 10F, 0));
                    orderCols[target].SetData("PASSAGER", target);
                    orderCols[target].OnEntityExitColShape += order_onEntityExit;
                }
                else Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Bürger hat kein Taxi gerufen oder er wurde bereits mitgenommen", 3000);
            }
            else Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du arbeitest im moment nicht als Taxifahrer", 3000);
        }

        public static void cancelTaxi(Player player)
        {
            if (player.HasData("PASSAGER"))
            {
                Player passager = player.GetData<Player>("PASSAGER");
                passager.ResetData("TAXI_DRIVER");
                passager.SetData("IS_CALL_TAXI", false);
                player.ResetData("PASSAGER");
                Notify.Send(passager, NotifyType.Warning, NotifyPosition.MapUp, $"Taxifahrer hat den Arbeitsplatz verlassen, mache einen neuen Auftrag", 3000);
                Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Du hast den Auftrag abgesagt", 3000);
                NAPI.Task.Run(() =>
                {
                    try
                    {
                        NAPI.ColShape.DeleteColShape(orderCols[passager]);
                        orderCols.Remove(passager);
                    }
                    catch { }
                });

                return;
            }
            if (NAPI.Data.GetEntityData(player, "IS_CALL_TAXI"))
            {
                NAPI.Data.SetEntityData(player, "IS_CALL_TAXI", false);
                Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Du hast den Auftrag storniert", 3000);
                if (player.HasData("TAXI_DRIVER"))
                {
                    Player driver = player.GetData<Player>("TAXI_DRIVER");
                    driver.ResetData("PASSAGER");
                    player.ResetData("TAXI_DRIVER");
                    Notify.Send(driver, NotifyType.Warning, NotifyPosition.MapUp, $"Der Fahrgast hat die Reservierung storniert", 3000);
                    NAPI.Task.Run(() =>
                    {
                        try
                        {
                            NAPI.ColShape.DeleteColShape(orderCols[player]);
                            orderCols.Remove(player);
                        }
                        catch { }
                    });
                }
            }
            else Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast kein Taxi gerufen.", 3000);
        }

        public static void callTaxi(Player player)
        {
            if (!NAPI.Data.GetEntityData(player, "IS_CALL_TAXI"))
            {
                List<Player> players = NAPI.Pools.GetAllPlayers();
                var i = 0;
                foreach (var p in players)
                {
                    if (p == null || !Main.Players.ContainsKey(p)) continue;
                    if (Main.Players[p].WorkID == 3 && NAPI.Data.GetEntityData(p, "WORK") != null)
                    {
                        i++;
                        NAPI.Chat.SendChatMessageToPlayer(p, $"~g~[DISPATCHER]: ~w~Der Spieler ({player.Value}) hat ~y~({player.Position.DistanceTo(p.Position)}m)~w~ aufgerufen. Schreibe ~y~/ta ~b~[ID]~w~, um den Anruf anzunehmen");
                    }
                }
                if (i > 0)
                {
                    NAPI.Data.SetEntityData(player, "IS_CALL_TAXI", true);
                    Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Warte, bis der Anruf entgegengenommen wird. Es gibt jetzt {i} Taxifahrer in Ihrer Umgebung. Um den Anruf abzubrechen, verwenden Sie /ctaxi", 3000);
                }
                else Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Es gibt im Moment keine Taxifahrer in deiner Umgebung. Versuche es ein anderes Mal.", 3000);
            }
            else Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast bereits ein Taxi gerufen. Zum Abbrechen, Text /ctaxi", 3000);
        }
    }
}
