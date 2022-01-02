using GTANetworkAPI;
using System;
using System.Collections.Generic;
using ULife.Core;
using UNL.SDK;

namespace ULife.Jobs
{
    class Truck : Script
    {
        private static List<int> TruckwaysPayments = new List<int>()
        {
            1500, 1800, 2100, 2500, 2800, 3200
        };
        private static nLog Log = new nLog("Truck");

        private static int TruckRentCost = 100;
        private static List<List<TruckCheck>> TruckWays = new List<List<TruckCheck>>()
        {
            new List<TruckCheck>() // 
            {
                new TruckCheck(new Vector3(-281.14426, -149.9919, 42.445324), true), // Погрузка 1

                new TruckCheck(new Vector3(-271.98944, -186.79492, 39.613544), true), // Разгрузка 1

            },
            new List<TruckCheck>() //
            {
                new TruckCheck(new Vector3(-281.14426, -149.9919, 42.445324), false), // 1 

                new TruckCheck(new Vector3(-271.98944, -186.79492, 39.613544), true), // 10 Остановка +
            },
            new List<TruckCheck>() // 
            {
                new TruckCheck(new Vector3(-281.14426, -149.9919, 42.445324), false), // 1 

                new TruckCheck(new Vector3(-271.98944, -186.79492, 39.613544), true), // 10 Остановка +
               
            },
            new List<TruckCheck>() // 
            {
                new TruckCheck(new Vector3(-281.14426, -149.9919, 42.445324), false), // 1 

                new TruckCheck(new Vector3(-271.98944, -186.79492, 39.613544), true), // 10 Остановка +
            
            },
            new List<TruckCheck>()
            {
                new TruckCheck(new Vector3(-281.14426, -149.9919, 42.445324), false), // 1 

                new TruckCheck(new Vector3(-271.98944, -186.79492, 39.613544), true), // 10 Остановка +
              
            },
            new List<TruckCheck>()
            {
                new TruckCheck(new Vector3(-281.14426, -149.9919, 42.445324), false), // 1 

                new TruckCheck(new Vector3(-271.98944, -186.79492, 39.613544), true), // 10 Остановка +
           
            },
        };

        [ServerEvent(Event.ResourceStart)]
        public void onResourceStartHandler()
        {
            try
            {
                for (int a = 0; a < TruckWays.Count; a++)
                {
                    for (int x = 0; x < TruckWays[a].Count; x++)
                    {
                        var col = NAPI.ColShape.CreateCylinderColShape(TruckWays[a][x].Pos, 4, 3, 0);
                        col.OnEntityEnterColShape += TruckCheckpointEnterWay;
                        col.SetData("WORKWAY", a);
                        col.SetData("NUMBER", x);
                    }
                }

            }
            catch (Exception e) { Log.Write("ResourceStart: " + e.Message, nLog.Type.Error); }
        }

        public static List<CarInfo> CarInfos = new List<CarInfo>();
        public static void TruckCarsSpawner()
        {
            // создаём автобусы
            for (int a = 0; a < CarInfos.Count; a++)
            {
                var veh = NAPI.Vehicle.CreateVehicle(CarInfos[a].Model, CarInfos[a].Position, CarInfos[a].Rotation.Z, CarInfos[a].Color1, CarInfos[a].Color2, CarInfos[a].Number);
                Core.VehicleStreaming.SetEngineState(veh, false);
                NAPI.Data.SetEntityData(veh, "ACCESS", "WORK");
                NAPI.Data.SetEntityData(veh, "WORK", 5);
                NAPI.Data.SetEntityData(veh, "TYPE", "TRUCK");
                NAPI.Data.SetEntityData(veh, "NUMBER", a);
                NAPI.Data.SetEntityData(veh, "ON_WORK", false);
                NAPI.Data.SetEntityData(veh, "DRIVER", null);
                veh.SetSharedData("PETROL", VehicleManager.VehicleTank[veh.Class]); //Shared
            }
        }

        public static void onPlayerDissconnectedHandler(Player player, DisconnectionType type, string reason)
        {
            try
            {
                if (!Main.Players.ContainsKey(player)) return;
                if (Main.Players[player].WorkID == 5 &&
                    NAPI.Data.GetEntityData(player, "WORK") != null)
                {
                    var vehicle = NAPI.Data.GetEntityData(player, "WORK");
                    respawnTruckCar(vehicle);
                }
            }
            catch (Exception e) { Log.Write("PlayerDisconnected: " + e.Message, nLog.Type.Error); }
        }

        public static void respawnTruckCar(Vehicle veh)
        {
            try
            {
                int i = NAPI.Data.GetEntityData(veh, "NUMBER");

                NAPI.Entity.SetEntityPosition(veh, CarInfos[i].Position);
                NAPI.Entity.SetEntityRotation(veh, CarInfos[i].Rotation);
                VehicleManager.RepairCar(veh);
                Core.VehicleStreaming.SetEngineState(veh, false);
                Core.VehicleStreaming.SetLockStatus(veh, false);
                NAPI.Data.SetEntityData(veh, "WORK", 5);
                NAPI.Data.SetEntityData(veh, "TYPE", "TRUCK");
                NAPI.Data.SetEntityData(veh, "NUMBER", i);
                NAPI.Data.SetEntityData(veh, "ON_WORK", false);
                NAPI.Data.SetEntityData(veh, "ACCESS", "WORK");
                NAPI.Data.SetEntityData(veh, "DRIVER", null);
                veh.SetSharedData("PETROL", VehicleManager.VehicleTank[veh.Class]); //Shared
            }
            catch (Exception e) { Log.Write("respawnTruckCar: " + e.Message, nLog.Type.Error); }
        }



        #region TruckWays

        private static void TruckCheckpointEnterWay(ColShape shape, Player player)
        {
            try
            {
                if (!NAPI.Player.IsPlayerInAnyVehicle(player)) return;
                var vehicle = player.Vehicle;
                if (NAPI.Data.GetEntityData(vehicle, "TYPE") != "TRUCK") return;
                if (Main.Players[player].WorkID != 5 || !player.GetData<bool>("ON_WORK") || player.GetData<int>("WORKWAY") != shape.GetData<int>("WORKWAY")) return;
                var way = player.GetData<int>("WORKWAY");

                if (shape.GetData<int>("NUMBER") != player.GetData<int>("WORKCHECK")) return;
                var check = NAPI.Data.GetEntityData(player, "WORKCHECK");

                if (player.GetData<bool>("TRUCK_ONSTOP") == true) return;
                if (!TruckWays[way][check].IsStop)
                {
                    if (NAPI.Data.GetEntityData(player, "WORKCHECK") != check) return;
                    if (check + 1 != TruckWays[way].Count) check++;
                    else check = 0;

                    var direction = (check + 1 != TruckWays[way].Count) ? TruckWays[way][check + 1].Pos - new Vector3(0, 0, 0.12) : TruckWays[way][0].Pos - new Vector3(0, 0, 1.12);
                    var color = (TruckWays[way][check].IsStop) ? new Color(255, 255, 255) : new Color(255, 0, 0);
                    Trigger.ClientEvent(player, "createCheckpoint", 3, 1, TruckWays[way][check].Pos - new Vector3(0, 0, 1.12), 4, 0, color.Red, color.Green, color.Blue, direction);
                    Trigger.ClientEvent(player, "createWaypoint", TruckWays[way][check].Pos.X, TruckWays[way][check].Pos.Y);
                    Trigger.ClientEvent(player, "createWorkBlip", TruckWays[way][check].Pos);

                    NAPI.Data.SetEntityData(player, "WORKCHECK", check);

                    var payment = Convert.ToInt32(TruckwaysPayments[way] * Group.GroupPayAdd[Main.Accounts[player].VipLvl] * Main.oldconfig.PaydayMultiplier);
                    if (shape.GetData<int>("NUMBER") != 0)
                    {
                        MoneySystem.Wallet.Change(player, payment);
                    }

                    GameLog.Money($"server", $"player({Main.Players[player].UUID})", payment, $"TruckCheck");
                }
                else
                {
                    if (NAPI.Data.GetEntityData(player, "WORKCHECK") != check) return;
                    Trigger.ClientEvent(player, "deleteCheckpoint", 3, 0);
                    Trigger.ClientEvent(player, "deleteWorkBlip");

                    NAPI.Data.SetEntityData(player, "TRUCK_ONSTOP", true);
                    Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Der Ladevorgang läuft. Warte 10 Sekunden", 3000);
                    player.SetData("TRUCK_TIMER", Timers.StartOnce(10000, () => timer_TruckStop(player, way, check)));

                }
            }
            catch (Exception ex) { Log.Write("TruckCheckpointEnterWay: " + ex.Message, nLog.Type.Error); }
        }

        private static void timer_TruckStop(Player player, int way, int check)
        {
            NAPI.Task.Run(() =>
            {
                try
                {
                    NAPI.Data.SetEntityData(player, "TRUCK_ONSTOP", false);
                    Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Wir sind Startklar", 3000);
                    var payment = Convert.ToInt32(TruckwaysPayments[way] * Group.GroupPayAdd[Main.Accounts[player].VipLvl] * Main.oldconfig.PaydayMultiplier);
                    MoneySystem.Wallet.Change(player, payment);
                    GameLog.Money($"server", $"player({Main.Players[player].UUID})", payment, $"TruckCheck");
                    if (check + 1 != TruckWays[way].Count) check++;
                    else check = 0;

                    var direction = (check + 1 < TruckWays[way].Count) ? TruckWays[way][check + 1].Pos - new Vector3(0, 0, 0.12) : TruckWays[way][0].Pos - new Vector3(0, 0, 1.12);
                    var color = (TruckWays[way][check].IsStop) ? new Color(255, 255, 255) : new Color(255, 0, 0);
                    NAPI.ClientEvent.TriggerClientEvent(player, "createCheckpoint", 3, 1, TruckWays[way][check].Pos - new Vector3(0, 0, 1.12), 4, 0, color.Red, color.Green, color.Blue, direction);
                    NAPI.ClientEvent.TriggerClientEvent(player, "createWaypoint", TruckWays[way][check].Pos.X, TruckWays[way][check].Pos.Y);
                    NAPI.ClientEvent.TriggerClientEvent(player, "createWorkBlip", TruckWays[way][check].Pos);

                    player.SetData("WORKCHECK", check);
                    Timers.Stop(player.GetData<string>("TRUCK_TIMER"));
                    player.ResetData("TRUCK_TIMER");


                }
                catch (Exception e)
                {
                    Log.Write("EXCEPTION AT \"TIMER_TRUCK_STOP\":\n" + e.ToString(), nLog.Type.Error);
                }
            });
        }
        #endregion

        [ServerEvent(Event.PlayerExitVehicle)]
        public void onPlayerExitVehicleHandler(Player player, Vehicle vehicle)
        {
            try
            {
                if (NAPI.Data.GetEntityData(vehicle, "TYPE") == "TRUCK" &&
                    Main.Players[player].WorkID == 5 &&
                    NAPI.Data.GetEntityData(player, "ON_WORK") &&
                    NAPI.Data.GetEntityData(player, "WORK") == vehicle)
                {
                    Notify.Send(player, NotifyType.Warning, NotifyPosition.MapUp, $"Wenn du nicht innerhalb von 60 Sekunden in dein Fahrzeug steigst, ist der Arbeitstag vorbei", 3000);
                    NAPI.Data.SetEntityData(player, "IN_WORK_CAR", false);
                    if (player.HasData("WORK_CAR_EXIT_TIMER"))
                        //Main.StopT(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"), "timer_24");
                        Timers.Stop(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"));
                    NAPI.Data.SetEntityData(player, "CAR_EXIT_TIMER_COUNT", 0);
                    //NAPI.Data.SetEntityData(player, "WORK_CAR_EXIT_TIMER", Main.StartT(1000, 1000, (o) => timer_playerExitWorkVehicle(player, vehicle), "BUS_EXIT_CAR_TIMER"));
                    NAPI.Data.SetEntityData(player, "WORK_CAR_EXIT_TIMER", Timers.Start(1000, () => timer_playerExitWorkVehicle(player, vehicle)));
                }
            }
            catch (Exception e) { Log.Write("PlayerExitVehicle: " + e.Message, nLog.Type.Error); }
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
                        //Main.StopT(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"), "timer_25");
                        Timers.Stop(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"));
                        NAPI.Data.ResetEntityData(player, "WORK_CAR_EXIT_TIMER");
                        return;
                    }
                    if (NAPI.Data.GetEntityData(player, "CAR_EXIT_TIMER_COUNT") > 60)
                    {
                        respawnTruckCar(vehicle);

                        NAPI.Data.SetEntityData(player, "ON_WORK", false);
                        NAPI.Data.SetEntityData(player, "WORK", null);
                        Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Du bist für den Tag fertig", 3000);
                        Trigger.ClientEvent(player, "deleteCheckpoint", 3, 0);
                        Trigger.ClientEvent(player, "deleteWorkBlip");

                        //Main.StopT(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"), "timer_26");
                        Timers.Stop(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"));
                        NAPI.Data.ResetEntityData(player, "WORK_CAR_EXIT_TIMER");
                        player.SetData("PAYMENT", 0);
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

        [ServerEvent(Event.PlayerEnterVehicle)]
        public void onPlayerEnterVehicleHandler(Player player, Vehicle vehicle, sbyte seatid)
        {
            try
            {

                if (NAPI.Data.GetEntityData(vehicle, "TYPE") != "TRUCK") return;
                if (player.VehicleSeat == 0)
                {
                    if (!Main.Players[player].Licenses[2])
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast keinen Führerschein der Klasse C", 3000);
                        VehicleManager.WarpPlayerOutOfVehicle(player);
                        return;
                    }
                    Main.Players[player].WorkID = 5;
                    if (Main.Players[player].WorkID == 5)
                    {
                        if (vehicle.GetData<Player>("DRIVER") == null)
                        {
                            if (player.GetData<string>("WORK") == null)
                            {
                                if (Main.Players[player].Money >= TruckRentCost)
                                {
                                    Trigger.ClientEvent(player, "openDialog", "TRUCK_RENT", $"LKW mieten für ${TruckRentCost}?");
                                }
                                else
                                {
                                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast nicht genug " + (TruckRentCost - Main.Players[player].Money) + "$ Geld", 3000);
                                    VehicleManager.WarpPlayerOutOfVehicle(player);
                                }
                            }
                            else
                                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast bereits einen LKW gemietet", 3000);
                        }
                        else
                        {
                            if (NAPI.Data.GetEntityData(player, "WORK") != vehicle)
                            {
                                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der LKW hat bereits einen Fahrer", 3000);
                                VehicleManager.WarpPlayerOutOfVehicle(player);
                            }
                            else
                                NAPI.Data.SetEntityData(player, "IN_WORK_CAR", true);
                        }
                    }
                    else
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du arbeitest nicht als LKW Fahrer, du kriegst einen Job bei der Arbeitsargentur", 3000);
                        VehicleManager.WarpPlayerOutOfVehicle(player);
                    }
                }
            }
            catch (Exception e) { Log.Write("PlayerEnterVehicle: " + e.Message, nLog.Type.Error); }

        }

        public static void acceptTruckRent(Player player)
        {
            if (NAPI.Player.IsPlayerInAnyVehicle(player) && player.VehicleSeat == 0 && player.Vehicle.GetData<string>("TYPE") == "TRUCK")
            {
                var ways = new Dictionary<int, int>
                        {
                            { 0, 0 },
                            { 1, 0 },
                            { 2, 0 },
                            { 3, 0 },
                            { 4, 0 },
                            { 5, 0 }
                        };
                foreach (var p in NAPI.Pools.GetAllPlayers())
                {
                    if (!Main.Players.ContainsKey(p)) continue;
                    if (Main.Players[p].WorkID != 5 || !p.GetData<bool>("ON_WORK")) continue;
                    ways[p.GetData<int>("WORKWAY")]++;
                }

                var way = -1;
                for (int i = 0; i < ways.Count; i++)
                    if (ways[i] == 0)
                    {
                        way = i;
                        break;
                    }
                if (way == -1)
                {
                    for (int i = 0; i < ways.Count; i++)
                        if (ways[i] == 1)
                        {
                            way = i;
                            break;
                        }
                }
                if (way == -1) way = 0;

                var vehicle = player.Vehicle;
                NAPI.Data.SetEntityData(player, "IN_WORK_CAR", true);
                NAPI.Data.SetEntityData(player, "ON_WORK", true);
                MoneySystem.Wallet.Change(player, -TruckRentCost);
                GameLog.Money($"player({Main.Players[player].UUID})", $"server", TruckRentCost, $"TruckRent");

                Core.VehicleStreaming.SetEngineState(vehicle, true);
                NAPI.Data.SetEntityData(vehicle, "DRIVER", player);
                NAPI.Data.SetEntityData(vehicle, "ON_WORK", true);
                NAPI.Data.SetEntityData(vehicle, "DRIVER", player);

                NAPI.Data.SetEntityData(player, "WORKWAY", way);
                NAPI.Data.SetEntityData(player, "WORKCHECK", 0);
                Trigger.ClientEvent(player, "createCheckpoint", 3, 1, TruckWays[way][0].Pos - new Vector3(0, 0, 1.12), 4, 0, 255, 0, 0, TruckWays[way][1].Pos - new Vector3(0, 0, 1.12));
                Trigger.ClientEvent(player, "createWaypoint", TruckWays[way][0].Pos.X, TruckWays[way][0].Pos.Y);
                Trigger.ClientEvent(player, "createWorkBlip", TruckWays[way][0].Pos);

                NAPI.Data.SetEntityData(player, "WORK", vehicle);

                //BasicSync.AttachLabelToObject("~y~" + BusWaysNames[way] + "\n~w~Проезд: ~g~15$", new Vector3(0, 0, 1.5), vehicle);
                //Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Вы арендовали автобус. Вас распределили на маршрут {TruckWaysNames[way]}", 3000);
            }
            else
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du musst im LKW sein", 3000);
            }
        }

        private static void GenerateWays(Player player)
        {

            var ways = new Dictionary<int, int>
                        {
                            { 0, 0 },
                            { 1, 0 },
                            { 2, 0 },
                            { 3, 0 },
                            { 4, 0 },
                            { 5, 0 }
                        };
            foreach (var p in NAPI.Pools.GetAllPlayers())
            {
                if (!Main.Players.ContainsKey(p)) continue;
                if (Main.Players[p].WorkID != 5 || !p.GetData<bool>("ON_WORK")) continue;
                ways[p.GetData<int>("WORKWAY")]++;
            }

            var way = -1;
            for (int i = 0; i < ways.Count; i++)
                if (ways[i] == 0)
                {
                    way = i;
                    break;
                }
            if (way == -1)
            {
                for (int i = 0; i < ways.Count; i++)
                    if (ways[i] == 1)
                    {
                        way = i;
                        break;
                    }
            }
            if (way == -1) way = 0;

            NAPI.Data.SetEntityData(player, "WORKWAY", way);
            NAPI.Data.SetEntityData(player, "WORKCHECK", 0);
            Trigger.ClientEvent(player, "createCheckpoint", 3, 1, TruckWays[way][0].Pos - new Vector3(0, 0, 1.12), 4, 0, 255, 0, 0, TruckWays[way][1].Pos - new Vector3(0, 0, 1.12));
            Trigger.ClientEvent(player, "createWaypoint", TruckWays[way][0].Pos.X, TruckWays[way][0].Pos.Y);
            Trigger.ClientEvent(player, "createWorkBlip", TruckWays[way][0].Pos);
        }

        internal class TruckCheck
        {
            public Vector3 Pos { get; }
            public bool IsStop { get; }

            public TruckCheck(Vector3 pos, bool isStop = false)
            {
                Pos = pos;
                IsStop = isStop;
            }
        }
    }
}
