using GTANetworkAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Timers;
using ULife.MoneySystem;
using ULife.Fractions;
using ULife.GUI;
using UNL.SDK;
using ULife.Core.Character;
using ULife.Core;


namespace ULife.Fractions
{
    class AutoMechanic : Script
    {
        public const int INTERACTION_DUTY = 506;
        public const int INTERACTION_MENU = 507;
        public const int FRACTION_ID = 20;

        public static List<CarInfo> CarInfos = new List<CarInfo>();

        private static nLog Log = new nLog("MECHANIC GOV");
        private static Dictionary<Player, ColShape> orderCols = new Dictionary<Player, ColShape>();

        private static Dictionary<int, ColShape> Cols = new Dictionary<int, ColShape>();
        public static List<Vector3> checkpoints = new List<Vector3>()
        {
            new Vector3(3.00657, -1660.651, 28.57969), // duty
            new Vector3(-1.742678, -1657.25, 28.57969), // menu
        };


        public static void workingDayHandler(Player player)
        {
            if (Main.Players[player].FractionID == FRACTION_ID)
            {
                if (!NAPI.Data.GetEntityData(player, "ON_DUTY"))
                {
                    Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du hast deinen Tag bei der Arbeit begonnen", 3000);
                    //Manager.setSkin(player, 7, Main.Players[player].FractionLVL);
                    NAPI.Data.SetEntityData(player, "ON_DUTY", true);
                }
                else
                {
                    Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du hast deinen Tag bei der Arbeit beendet", 3000); ;
                    Customization.ApplyCharacter(player);
                    if (player.HasData("HAND_MONEY"))
                    {
                        player.SetClothes(5, 45, 0);
                    }
                    else if (player.HasData("HEIST_DRILL"))
                    {
                        player.SetClothes(5, 41, 0);
                    }

                    NAPI.Data.SetEntityData(player, "ON_DUTY", false);
                }
            }
            else
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du bist kein Mechaniker", 3000);
            }
        }

        [ServerEvent(Event.ResourceStart)]
        public void onResourceStart()
        {
            Cols.Add(0, NAPI.ColShape.CreateCylinderColShape(checkpoints[0], 1, 2, 0));
            Cols[0].SetData("INTERACT", INTERACTION_DUTY);
            Cols[0].OnEntityEnterColShape += onEntityEnterColshape;
            Cols[0].OnEntityExitColShape += onEntityExitColshape;

            NAPI.TextLabel.CreateTextLabel(Main.StringToU16("~g~Umkleide"), 
                new Vector3(checkpoints[0].X, checkpoints[0].Y, checkpoints[0].Z + 0.7), 
                5F, 0.3F, 0, new Color(255, 255, 255));
            NAPI.Marker.CreateMarker(1, checkpoints[0] - new Vector3(0, 0, 0.7), new Vector3(), new Vector3(), 1, new Color(255, 255, 255, 220));



            Cols.Add(1, NAPI.ColShape.CreateCylinderColShape(checkpoints[1], 1, 2, 0));
            Cols[1].SetData("INTERACT", INTERACTION_MENU);
            Cols[1].OnEntityEnterColShape += onEntityEnterColshape;
            Cols[1].OnEntityExitColShape += onEntityExitColshape;

            NAPI.TextLabel.CreateTextLabel(Main.StringToU16("~g~Funkgeräte"), 
                new Vector3(checkpoints[1].X, checkpoints[1].Y, checkpoints[1].Z + 0.7), 
                5F, 0.3F, 0, new Color(255, 255, 255));
            NAPI.Marker.CreateMarker(1, checkpoints[1] - new Vector3(0, 0, 0.7), new Vector3(), new Vector3(), 1, new Color(255, 255, 255, 220));
        }

        private void onEntityEnterColshape(ColShape shape, Player entity)
        {
            try
            {
                NAPI.Data.SetEntityData(entity, "INTERACTIONCHECK", shape.GetData<int>("INTERACT"));
            }
            catch (Exception ex) { Log.Write("onEntityEnterColshape: " + ex.Message, nLog.Type.Error); }
        }

        private void onEntityExitColshape(ColShape shape, Player entity)
        {
            try
            {
                NAPI.Data.SetEntityData(entity, "INTERACTIONCHECK", 0);
            }
            catch (Exception ex) { Log.Write("onEntityExitColshape: " + ex.Message, nLog.Type.Error); }
        }


        public static void menuHandler(Player player)
        {
            if (Main.Players[player].FractionID != FRACTION_ID)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du bist kein Mechaniker", 3000);
                return;
            }
            if (!NAPI.Data.GetEntityData(player, "ON_DUTY"))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie müssen zuerst den Arbeitstag beginnen", 3000);
                return;
            }

            OpenMechItemsMenu(player);
            return;
        }

        public static void OpenMechItemsMenu(Player player)
        {
            Trigger.ClientEvent(player, "mechitemsUI");
        }
        [RemoteEvent("mechitems")]
        public static void callback_mechItems(Player client, int index)
        {
            try
            {
                switch (index)
                {
                    case 0: // Funk spamming?
                        nInventory.Add(client, new nItem(ItemType.Funk, 1));
                        Notify.Send(client, NotifyType.Success, NotifyPosition.MapUp, $"Du hast ein Funkgerät genommen", 3000);
                        return;
                }
            }
            catch (Exception e)
            {
                Log.Write($"ACLS items: " + e.Message, nLog.Type.Error);
            }
        }



        private static void order_onEntityExit(ColShape shape, Player player)
        {
            if (shape.GetData<Player>("MECHANIC_CLIENT") != player) return;

            if (player.HasData("MECHANIC_DRIVER"))
            {
                Player driver = player.GetData<Player>("MECHANIC_DRIVER");
                driver.ResetData("MECHANIC_CLIENT");
                player.ResetData("MECHANIC_DRIVER");
                player.SetData("IS_CALL_MECHANIC", false);
                Notify.Send(driver, NotifyType.Warning, NotifyPosition.MapUp, $"Der Kunde hat den Auftrag storniert", 3000);
                Notify.Send(player, NotifyType.Warning, NotifyPosition.MapUp, $"Du hast den Ort des Anrufs des Automechanikers verlassen", 3000);
                try
                {
                    NAPI.ColShape.DeleteColShape(orderCols[player]);
                    orderCols.Remove(player);
                }
                catch { }
            }
        }

        public static void mechanicRepair(Player player, Player target, int price)
        {
            if (Main.Players[player].FractionID != 20 || !player.GetData<bool>("ON_DUTY"))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du arbeitest nicht als Automechaniker", 3000);
                return;
            }

            /*
            if (!player.IsInVehicle || !player.Vehicle.HasData("TYPE") || player.Vehicle.GetData("TYPE") != "MECHANIC")
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie müssen sich in einem Arbeitsfahrzeug befinden", 3000);
                return;
            }
           
            if (!target.IsInVehicle)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler muss sich im Fahrzeug befinden", 3000);
                return;
            }

            if (player.Vehicle.Position.DistanceTo(target.Vehicle.Position) > 5)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler ist zu weit von dir entfernt", 3000);
                return;
            }
             */

            if (player.Position.DistanceTo(target.Vehicle.Position) > 5)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Das Fahrzeug ist zu weit von dir entfernt :(", 3000);
                return;
            }

            if (price < 50 || price > 30000)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie können einen Preis von $50 bis $30000 festlegen :)", 3000);
                return;
            }
            if (Main.Players[target].Money < price)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler hat nicht genug Geld :(", 3000);
                return;
            }

            target.SetData("MECHANIC", player);
            target.SetData("MECHANIC_PRICE", price);
            Trigger.ClientEvent(target, "openDialog", "REPAIR_CAR", $"Ihnen wird angeboten, Ihr Fahrzeug für ${price} zu reparieren!");

            Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Du hast dem Spieler angeboten sein Fahrzeug für {price}$ zu reparieren!", 3000);
        }

        [ServerEvent(Event.PlayerEnterVehicle)]
        public void Event_onPlayerEnterVehicleHandler(Player player, Vehicle vehicle, sbyte seatid)
        {
            try
            {
                var vehType = NAPI.Data.GetEntityData(vehicle, "TYPE");
                var vehAccess = NAPI.Data.GetEntityData(vehicle, "ACCESS");
                var onDuty = NAPI.Data.GetEntityData(player, "ON_DUTY");

                Log.Write($"{vehType} {vehAccess} {onDuty}");

                if (vehType != "MECHANIC")
                {
                    return;
                }

                if (vehAccess != "FRACTION")
                {
                    return;
                }


                if (seatid == -1)
                {
                    if (!Main.Players[player].Licenses[1])
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie haben keine Lizenz der Kategorie B", 3000);
                        VehicleManager.WarpPlayerOutOfVehicle(player);
                        return;
                    }

                    if (NAPI.Data.GetEntityData(player, "ON_DUTY") != true)
                    {
                        Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Du musst in den Dienst!", 3000);
                        VehicleManager.WarpPlayerOutOfVehicle(player);
                        return;
                    }

                    if (Main.Players[player].FractionID == 20)
                    {
                        NAPI.Data.SetEntityData(player, "IN_WORK_CAR", true);
                        NAPI.Data.SetEntityData(player, "WORK", vehicle);
                    }
                    else
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du arbeitest nicht als Automechaniker.", 3000);
                        VehicleManager.WarpPlayerOutOfVehicle(player);
                    }
                }
            }
            catch (Exception e) { Log.Write("PlayerEnterVehicle: " + e.Message, nLog.Type.Error); }
        }

       
        public static void onPlayerDissconnectedHandler(Player player, DisconnectionType type, string reason)
        {
            try
            {
                if (!Main.Players.ContainsKey(player)) return;
                if (player.HasData("MECHANIC_DRIVER"))
                {
                    Player driver = player.GetData<Player>("MECHANIC_DRIVER");
                    driver.ResetData("MECHANIC_CLIENT");
                    Notify.Send(driver, NotifyType.Warning, NotifyPosition.MapUp, $"Der Kunde hat den Auftrag storniert", 3000);
                    try
                    {
                        NAPI.ColShape.DeleteColShape(orderCols[player]);
                        orderCols.Remove(player);
                    }
                    catch { }
                }

                if (Main.Players[player].FractionID == 20 && NAPI.Data.GetEntityData(player, "ON_DUTY"))
                {
                    var vehicle = NAPI.Data.GetEntityData(player, "WORK");
                    Configs.RespawnFractionCar(vehicle);
                    if (player.HasData("MECHANIC_CLIENT"))
                    {
                        Player client = player.GetData<Player>("MECHANIC_CLIENT");
                        client.ResetData("MECHANIC_DRIVER");
                        client.SetData("IS_CALL_MECHANIC", false);
                        Notify.Send(client, NotifyType.Warning, NotifyPosition.MapUp, $"Der Mechaniker hat den Auftragsort verlassen, der Auftrag wurde entgegengenommen!", 3000);
                        try
                        {
                            NAPI.ColShape.DeleteColShape(orderCols[client]);
                            orderCols.Remove(client);
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
            /*
            try
            {
                if (NAPI.Data.GetEntityData(vehicle, "ACCESS") == "FRACTION" &&
                Main.Players[player].FractionID == 19 &&
                NAPI.Data.GetEntityData(player, "WORK") == vehicle)
                {
                    Notify.Send(player, NotifyType.Warning, NotifyPosition.MapUp, $"Wenn Sie nicht in 5 Minuten in den Transport steigen, endet der Arbeitstag", 3000);
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
            */
        }

        private void timer_playerExitWorkVehicle(Player player, Vehicle vehicle)
        {
            NAPI.Task.Run(() =>
            {
                try {
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
                        Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Du hast deinen Tag bei der Arbeit beendet", 3000);
                        Configs.RespawnFractionCar(vehicle);
                        player.SetData("ON_DUTY", false);
                        player.SetData<string>("WORK", null);
                        //Main.StopT(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"), "timer_3");
                        Timers.Stop(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"));
                        NAPI.Data.ResetEntityData(player, "WORK_CAR_EXIT_TIMER");
                        if (player.HasData("MECHANIC_CLIENT"))
                        {
                            Player client = player.GetData<Player>("MECHANIC_CLIENT");
                            client.ResetData("MECHANIC_DRIVER");
                            client.SetData("IS_CALL_MECHANIC", false);
                            Notify.Send(player, NotifyType.Warning, NotifyPosition.MapUp, $"Der Mechaniker hat den Auftragsort verlassen, der Auftrag wurde entgegengenommen!", 3000);
                            player.ResetData("MECHANIC_CLIENT");
                            try
                            {
                                NAPI.ColShape.DeleteColShape(orderCols[client]);
                                orderCols.Remove(client);
                            }
                            catch { }
                        }
                        return;
                    }
                    NAPI.Data.SetEntityData(player, "CAR_EXIT_TIMER_COUNT", NAPI.Data.GetEntityData(player, "CAR_EXIT_TIMER_COUNT") + 1);

                } catch(Exception e)
                {
                    Log.Write("Timer_PlayerExitWorkVehicle:\n" + e.ToString(), nLog.Type.Error);
                }
            });
        }

        public static void acceptMechanic(Player player, Player target)
        {
            if (Main.Players[player].FractionID == 20 && player.GetData<bool>("ON_DUTY"))
            {
                if (player.HasData("MECHANIC_CLIENT"))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast den Auftrag bereits angenommen", 3000);
                    return;
                }
                if (NAPI.Data.GetEntityData(target, "IS_CALL_MECHANIC") && !target.HasData("MECHANIC_DRIVER"))
                {
                    Notify.Send(target, NotifyType.Warning, NotifyPosition.MapUp, $"Die Zentrale hat ein Wagen zu Ihnen geschickt. Bleiben Sie vor Ort :)", 3000);
                    Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Du hast den Auftrag der Zentrale angenommen", 3000);
                    Trigger.ClientEvent(player, "createWaypoint", NAPI.Entity.GetEntityPosition(target).X, NAPI.Entity.GetEntityPosition(target).Y);

                    target.SetData("MECHANIC_DRIVER", player);
                    player.SetData("MECHANIC_CLIENT", target);

                    orderCols.Add(target, NAPI.ColShape.CreateCylinderColShape(target.Position, 10F, 10F, 0));
                    orderCols[target].SetData("MECHANIC_CLIENT", target);
                    orderCols[target].OnEntityExitColShape += order_onEntityExit;
                }
                else Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler hat keinen Automechaniker gerufen", 3000);
            }
            else Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du bist im Moment nicht im Dienst", 3000);
        }

        public static void cancelMechanic(Player player)
        {
            if (player.HasData("MECHANIC_CLIENT"))
            {
                Player client = player.GetData<Player>("MECHANIC_CLIENT");
                client.ResetData("MECHANIC_DRIVER");
                client.SetData("IS_CALL_MECHANIC", false);
                player.ResetData("MECHANIC_CLIENT");
                Notify.Send(client, NotifyType.Warning, NotifyPosition.MapUp, $"Der Mechaniker hat den Auftrag storniert, Sie können ein neuen Dispatch senden", 3000);
                Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Sie haben Ihre Anfahrt zum Kunden storniert", 3000);
                try
                {
                    NAPI.ColShape.DeleteColShape(orderCols[client]);
                    orderCols.Remove(client);
                }
                catch { }
                return;
            }
            if (NAPI.Data.GetEntityData(player, "IS_CALL_MECHANIC"))
            {
                NAPI.Data.SetEntityData(player, "IS_CALL_MECHANIC", false);
                Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Du hast den Anruf des Automechanikers abgebrochen", 3000);
                if (player.HasData("MECHANIC_DRIVER"))
                {
                    Player driver = player.GetData<Player>("MECHANIC_DRIVER");
                    driver.ResetData("MECHANIC_CLIENT");
                    player.ResetData("MECHANIC_DRIVER");
                    Notify.Send(driver, NotifyType.Warning, NotifyPosition.MapUp, $"Der Kunde hat den Auftrag storniert", 3000);
                    try
                    {
                        NAPI.ColShape.DeleteColShape(orderCols[player]);
                        orderCols.Remove(player);
                    }
                    catch { }
                }
            }
            else Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast keinen Automechaniker gerufen.", 3000);
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
                    if (Main.Players[p].FractionID == 20 && NAPI.Data.GetEntityData(p, "ON_DUTY"))
                    {
                        i++;
                        NAPI.Chat.SendChatMessageToPlayer(p, $"~g~[Zentrale]: ~w~Es wurde ein Unfall gemeldet! ({player.Value})~y~({player.Position.DistanceTo(p.Position)}м)~w~. Nimm den Auftrag mit ~y~/fma ~b~[ID]~w~ an");
                    }
                }
                if (i > 0)
                {
                    NAPI.Data.SetEntityData(player, "IS_CALL_MECHANIC", true);
                    Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Warten Sie, bis der Anruf angenommen wird. Jetzt in Ihrer Nähe {i} Automechaniker. Um einen Anruf abzubrechen, verwenden Sie /fcmechanic", 3000);
                }
                else Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Es gibt derzeit keine Automechaniker in Ihrer Nähe. Versuchen Sie es ein anderes Mal", 3000);
            }
            else Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast bereits den Automechaniker angerufen. Um abzubrechen, schreiben Sie /cmechanic", 3000);
        }

        public static void buyFuel(Player player, int fuel)
        {
            if (!Main.Players.ContainsKey(player)) return;
            if (Main.Players[player].FractionID != 20 || !player.GetData<bool>("ON_DUTY") || !player.IsInVehicle || player.GetData<Entity>("WORK") != player.Vehicle)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie müssen Mechaniker sein und sich in der Arbeitsmaschine befinden", 3000);
                return;
            }
            if (player.GetData<int>("BIZ_ID") == -1 || BusinessManager.BizList[player.GetData<int>("BIZ_ID")].Type != 1)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du solltest an der Tankstelle sein", 3000);
                return;
            }
            if (fuel <= 0)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Geben Sie korrekte Daten ein", 3000);
                return;
            }
            Business biz = BusinessManager.BizList[player.GetData<int>("BIZ_ID")];
            if (Main.Players[player].Money < biz.Products[0].Price * fuel)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Unzureichende Mittel", 3000);
                return;
            }
            if (player.Vehicle.GetSharedData<int>("FUELTANK") + fuel > 1000)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Gastank ist voll", 3000);
                return;
            }
            if (!BusinessManager.takeProd(biz.ID, fuel, biz.Products[0].Name, biz.Products[0].Price * fuel))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Nicht genügend Kraftstoff an der Tankstelle", 3000);
                return;
            }
            Wallet.Change(player, -biz.Products[0].Price * fuel);
            GameLog.Money($"player({Main.Players[player].UUID})", $"biz({biz.ID})", biz.Products[0].Price * fuel, $"mechanicBuyFuel");
            player.Vehicle.SetSharedData("FUELTANK", player.Vehicle.GetSharedData<int>("FUELTANK") + fuel);
            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Sie haben den Tank in Ihrer Arbeitsmaschine wieder aufgefüllt, bis Sie die {player.Vehicle.GetSharedData<string>("FUELTANK")}л", 3000);
        }

        public static void mechanicFuel(Player player, Player target, int fuel, int pricePerLitr)
        {
            if (Main.Players[player].FractionID != 20 || !player.GetData<bool>("ON_DUTY"))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du arbeitest nicht als Automechaniker", 3000);
                return;
            }
            if (!player.IsInVehicle || !player.Vehicle.HasData("TYPE") || player.Vehicle.GetData<string>("TYPE") != "MECHANIC")
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie müssen sich in einem Arbeitsfahrzeug befinden", 3000);
                return;
            }
            if (!target.IsInVehicle)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler muss sich im Fahrzeug befinden", 3000);
                return;
            }
            if (player.Vehicle.Position.DistanceTo(target.Vehicle.Position) > 5)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler ist zu weit von dir entfernt", 3000);
                return;
            }
            if (fuel < 1)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du kannst nicht weniger als einen Liter verkaufen", 3000);
                return;
            }
            if (pricePerLitr < 2 || pricePerLitr > 10)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie können einen Preis von $2 bis $10 pro Liter festlegen", 3000);
                return;
            }
            if (Main.Players[target].Money < pricePerLitr * fuel)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler hat nicht genug Geld", 3000);
                return;
            }
            
            target.SetData("MECHANIC", player);
            target.SetData("MECHANIC_PRICE", pricePerLitr);
            target.SetData("MECHANIC_FEUL", fuel);
            Trigger.ClientEvent(target, "openDialog", "FUEL_CAR", $"Spieler ({player.Value}) angeboten, Ihren Transport zu füllen für {fuel}l für ${fuel * pricePerLitr}");
            
            Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Du hast dem Spieler angeboten ({target.Value}) um die Fahrzeuge zu betanken {fuel}l für {fuel * pricePerLitr}$.", 3000);
        }
    }
}
