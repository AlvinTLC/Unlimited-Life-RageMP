using ULife.Core;
using UNL.SDK;
using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ULife.Jobs
{
    class Trash : Script
    {
        private static nLog Log = new nLog("Trash");
        private static int checkpointPayment = 18;

        private static Vector3 UnloadTrashPos = new Vector3(-467.24396, -979.29724, 23.664331);

        public static List<CarInfo> CarInfos = new List<CarInfo>();
        public static void collectorCarsSpawner()
        {
            for (int a = 0; a < CarInfos.Count; a++)
            {
                var veh = NAPI.Vehicle.CreateVehicle(CarInfos[a].Model, CarInfos[a].Position, CarInfos[a].Rotation.Z, CarInfos[a].Color1, CarInfos[a].Color2, CarInfos[a].Number);
                NAPI.Data.SetEntityData(veh, "ACCESS", "WORK");
                NAPI.Data.SetEntityData(veh, "WORK", 7);
                NAPI.Data.SetEntityData(veh, "TYPE", "TRASH");
                NAPI.Data.SetEntityData(veh, "NUMBER", a);
                NAPI.Data.SetEntityData(veh, "ON_WORK", false);
                NAPI.Data.SetEntityData(veh, "DRIVER", null);
                veh.SetSharedData("PETROL", VehicleManager.VehicleTank[veh.Class]); //Shared
                Core.VehicleStreaming.SetEngineState(veh, false);
                Core.VehicleStreaming.SetLockStatus(veh, false);
            }
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
                NAPI.Data.SetEntityData(veh, "WORK", 7);
                NAPI.Data.SetEntityData(veh, "TYPE", "TRASH");
                NAPI.Data.SetEntityData(veh, "NUMBER", i);
                NAPI.Data.SetEntityData(veh, "ON_WORK", false);
                NAPI.Data.SetEntityData(veh, "DRIVER", null);
                Core.VehicleStreaming.SetEngineState(veh, false);
                Core.VehicleStreaming.SetLockStatus(veh, false);
                veh.SetSharedData("PETROL", VehicleManager.VehicleTank[veh.Class]); //Shared
            }
            catch (Exception e) { Log.Write("respawnCar: " + e.Message, nLog.Type.Error); }
        }

        [ServerEvent(Event.PlayerEnterVehicle)]
        public void onPlayerEnterVehicleHandler(Player player, Vehicle vehicle, sbyte seatid)
        {
            try
            {
                if (NAPI.Data.GetEntityData(vehicle, "TYPE") != "TRASH" || player.VehicleSeat != 0) return;
                if (Main.Players[player].WorkID == 7)
                {
                    if (player.HasData("WORKOBJECT"))
                    {
                        BasicSync.DetachObject(player);
                        player.ResetData("WORKOBJECT");
                    }
                    if (!NAPI.Data.GetEntityData(vehicle, "ON_WORK"))
                    {
                        if (NAPI.Data.GetEntityData(player, "WORK") == null)
                        {
                            if (Main.Players[player].Money >= 100) Trigger.ClientEvent(player, "openDialog", "COLLECTOR_RENT", "Wollen Sie wirklich einen Job als Müllmann beginnen und ein Fahrzeug für 100 Dollar mieten?");
                            else
                            {
                                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Du hast nicht " + (100 - Main.Players[player].Money) + "$ Geld um dir das Fahrzeug zu mieten", 3000);
                                VehicleManager.WarpPlayerOutOfVehicle(player);
                            }
                        }
                        else if (NAPI.Data.GetEntityData(player, "WORK") == vehicle)
                            NAPI.Data.SetEntityData(player, "IN_WORK_CAR", true);
                    }
                    else
                    {
                        if (NAPI.Data.GetEntityData(player, "WORK") != vehicle)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Das Fahrzeug ist besetzt", 3000);
                            VehicleManager.WarpPlayerOutOfVehicle(player);
                        }
                        else NAPI.Data.SetEntityData(player, "IN_WORK_CAR", true);
                    }
                }
                else
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Du arbeitest nicht als Müllmann. Du können einen Job beim Arbeitsamt bekommen", 3000);
                    VehicleManager.WarpPlayerOutOfVehicle(player);
                }
            }
            catch (Exception e) { Log.Write("PlayerEnterVehicle: " + e.Message, nLog.Type.Error); }
        }

        [ServerEvent(Event.PlayerExitVehicle)]
        public void onPlayerExitVehicleHandler(Player player, Vehicle vehicle)
        {
            try
            {
                if (NAPI.Data.GetEntityData(vehicle, "TYPE") == "TRASH" &&
                Main.Players[player].WorkID == 7 &&
                NAPI.Data.GetEntityData(player, "ON_WORK") &&
                NAPI.Data.GetEntityData(player, "WORK") == vehicle)
                {
                    if (!player.HasData("WORKOBJECT") && player.GetData<int>("COLLECTOR_BAGS") > 0)
                    {
                        BasicSync.AttachObjectToPlayer(player, NAPI.Util.GetHashKey("prop_money_bag_01"), 18905, new Vector3(0.55, 0.02, 0), new Vector3(0, -90, 0));
                        player.SetData("WORKOBJECT", true);
                    }

                    Notify.Send(player, NotifyType.Warning, NotifyPosition.BottomCenter, $"Wenn du nicht in 3 Minuten in dein Fahrzeug einsteigst, ist der Arbeitstag vorbei", 3000);
                    NAPI.Data.SetEntityData(player, "IN_WORK_CAR", false);
                    if (player.HasData("WORK_CAR_EXIT_TIMER"))
                        Timers.Stop(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"));
                    NAPI.Data.SetEntityData(player, "CAR_EXIT_TIMER_COUNT", 0);
                    NAPI.Data.SetEntityData(player, "WORK_CAR_EXIT_TIMER", Timers.StartTask(1000, () => timer_playerExitWorkVehicle(player, vehicle)));
                }
            }
            catch (Exception e) { Log.Write("PlayerExitVehicle: " + e.Message, nLog.Type.Error); }
        }

        public static void Event_PlayerDeath(Player player, Player entityKiller, uint weapon)
        {
            try
            {
                if (!Main.Players.ContainsKey(player)) return;
                if (Main.Players[player].WorkID == 7 && player.GetData<bool>("ON_WORK"))
                {
                    var vehicle = player.GetData<Vehicle>("WORK");

                    respawnCar(vehicle);

                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du bist für den Tag fertig", 3000);
                    NAPI.Data.SetEntityData(player, "PAYMENT", 0);

                    NAPI.Data.SetEntityData(player, "ON_WORK", false);
                    NAPI.Data.SetEntityData(player, "WORK", null);
                    Trigger.ClientEvent(player, "deleteCheckpoint", 16, 0);
                    Trigger.ClientEvent(player, "deleteWorkBlip");
                    Customization.ApplyCharacter(player);
                    if (player.HasData("WORK_CAR_EXIT_TIMER"))
                    {
                        Timers.Stop(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"));
                        NAPI.Data.ResetEntityData(player, "WORK_CAR_EXIT_TIMER");
                    }
                }
                if (player.HasData("WORKOBJECT"))
                {
                    BasicSync.DetachObject(player);
                    player.ResetData("WORKOBJECT");
                }
            }
            catch (Exception e) { Log.Write("PlayerDeath: " + e.Message, nLog.Type.Error); }
        }

        public static void Event_PlayerDisconnected(Player player, DisconnectionType type, string reason)
        {
            try
            {
                if (Main.Players[player].WorkID == 7 && player.GetData<bool>("ON_WORK"))
                {
                    var vehicle = player.GetData<Vehicle>("WORK");

                    respawnCar(vehicle);
                }
                if (player.HasData("WORKOBJECT"))
                {
                    BasicSync.DetachObject(player);
                    player.ResetData("WORKOBJECT");
                }
            }
            catch (Exception e) { Log.Write("PlayerDisconnected: " + e.Message, nLog.Type.Error); }
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
                        Timers.Stop(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"));
                        NAPI.Data.ResetEntityData(player, "WORK_CAR_EXIT_TIMER");
                        Log.Debug("Player exit work vehicle timer was stoped");
                        return;
                    }
                    if (NAPI.Data.GetEntityData(player, "CAR_EXIT_TIMER_COUNT") > 180)
                    {
                        respawnCar(vehicle);

                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du bist für den Tag fertig", 3000);
                        NAPI.Data.SetEntityData(player, "PAYMENT", 0);

                        NAPI.Data.SetEntityData(player, "ON_WORK", false);
                        NAPI.Data.SetEntityData(player, "WORK", null);
                        NAPI.ClientEvent.TriggerClientEvent(player, "deleteCheckpoint", 16, 0);
                        NAPI.ClientEvent.TriggerClientEvent(player, "deleteWorkBlip");
                        Timers.Stop(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"));
                        NAPI.Data.ResetEntityData(player, "WORK_CAR_EXIT_TIMER");
                        Customization.ApplyCharacter(player);

                        if (player.HasData("WORKOBJECT"))
                        {
                            BasicSync.DetachObject(player);
                            player.ResetData("WORKOBJECT");
                        }
                        return;
                    }
                    NAPI.Data.SetEntityData(player, "CAR_EXIT_TIMER_COUNT", NAPI.Data.GetEntityData(player, "CAR_EXIT_TIMER_COUNT") + 1);

                }
                catch (Exception e)
                {
                    Log.Write("Timer_PlayerExitWorkVehicle_Collector:\n" + e.ToString(), nLog.Type.Error);
                }
            });
        }

        public static void rentCar(Player player)
        {
            if (!NAPI.Player.IsPlayerInAnyVehicle(player) || player.VehicleSeat != 0 || player.Vehicle.GetData<string>("TYPE") != "TRASH") return;

            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast einen Job als Mülmann begonnen. Fahre zu den Punkten.", 3000);
            MoneySystem.Wallet.Change(player, -100);
            GameLog.Money($"player({Main.Players[player].UUID})", $"server", 100, $"collectorRent");
            var vehicle = player.Vehicle;
            NAPI.Data.SetEntityData(player, "WORK", vehicle);
            player.SetData("ON_WORK", true);
            Core.VehicleStreaming.SetEngineState(vehicle, false);
            NAPI.Data.SetEntityData(player, "IN_WORK_CAR", true);
            NAPI.Data.SetEntityData(vehicle, "DRIVER", player);
            player.SetData("COLLECTOR_BAGS", 15);
            player.SetData("W_LASTPOS", player.Position);
            player.SetData("W_LASTTIME", DateTime.Now);

            var x = WorkManager.rnd.Next(0, MoneySystem.ATM.ATMs.Count - 1); ;
            while (x == 36 || MoneySystem.ATM.ATMs[x].DistanceTo2D(player.Position) < 200)
                x = WorkManager.rnd.Next(0, MoneySystem.ATM.ATMs.Count - 1);
            player.SetData("WORKCHECK", x);
            if (Main.Players[player].Gender)
            {
                Customization.SetHat(player, 63, 9);
                player.SetClothes(11, 132, 0);
                player.SetClothes(4, 33, 0);
                player.SetClothes(6, 24, 0);
                player.SetClothes(9, 1, 1);
                player.SetClothes(8, 129, 0);
                player.SetClothes(3, Customization.CorrectTorso[true][132], 0);
            }
            else
            {
                Customization.SetHat(player, 63, 9);
                player.SetClothes(11, 129, 0);
                player.SetClothes(4, 32, 0);
                player.SetClothes(6, 24, 0);
                player.SetClothes(9, 6, 1);
                player.SetClothes(8, 159, 0);
                player.SetClothes(3, Customization.CorrectTorso[false][129], 0);
            }
            Trigger.ClientEvent(player, "createCheckpoint", 16, 29, MoneySystem.ATM.ATMs[x] + new Vector3(0, 0, 1.12), 1, 0, 220, 220, 0);
            Trigger.ClientEvent(player, "createWaypoint", MoneySystem.ATM.ATMs[x].X, MoneySystem.ATM.ATMs[x].Y);
            Trigger.ClientEvent(player, "createWorkBlip", MoneySystem.ATM.ATMs[x]);
        }

        public static void CollectorTakeMoney(Player player)
        {
            if (player.IsInVehicle || Main.Players[player].WorkID != 7 || !player.GetData<bool>("ON_WORK")) return;
            if (player.GetData<int>("COLLECTOR_BAGS") != 0)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Du kannst nichts mit nehmen ({player.GetData<int>("COLLECTOR_BAGS")})", 3000);
                return;
            }
            else
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast den Müllsack genommen.", 3000);
                player.SetData("COLLECTOR_BAGS", 15);

                var x = WorkManager.rnd.Next(0, MoneySystem.ATM.ATMs.Count - 1);
                while (x == 36 || MoneySystem.ATM.ATMs[x].DistanceTo2D(player.Position) < 200)
                    x = WorkManager.rnd.Next(0, MoneySystem.ATM.ATMs.Count - 1);

                player.SetData("W_LASTPOS", player.Position);
                player.SetData("W_LASTTIME", DateTime.Now);
                player.SetData("WORKCHECK", x);
                Trigger.ClientEvent(player, "createCheckpoint", 16, 29, MoneySystem.ATM.ATMs[x] + new Vector3(0, 0, 1.12), 1, 0, 220, 220, 0);
                Trigger.ClientEvent(player, "createWaypoint", MoneySystem.ATM.ATMs[x].X, MoneySystem.ATM.ATMs[x].Y);
                Trigger.ClientEvent(player, "createWorkBlip", MoneySystem.ATM.ATMs[x]);
            }
        }
        public static void CollectorEnterATM(Player player, ColShape shape)
        {
            try
            {
                if (player.IsInVehicle || Main.Players[player].WorkID != 7 || !player.GetData<bool>("ON_WORK")
                    || player.GetData<int>("COLLECTOR_BAGS") == 0 || player.GetData<int>("WORKCHECK") != shape.GetData<int>("NUMBER")) return;
                player.SetData("COLLECTOR_BAGS", player.GetData<int>("COLLECTOR_BAGS") - 1);

                var coef = Convert.ToInt32(player.Position.DistanceTo2D(player.GetData<Vector3>("W_LASTPOS")) / 100);
                var payment = Convert.ToInt32(coef * checkpointPayment * Group.GroupPayAdd[Main.Accounts[player].VipLvl] * Main.oldconfig.PaydayMultiplier);

                DateTime lastTime = player.GetData<DateTime>("W_LASTTIME");
                if (DateTime.Now < lastTime.AddSeconds(coef * 2))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, "Der Müllwagen ist voll", 3000);
                    return;
                }

                player.SetData("W_LASTPOS", player.Position);
                player.SetData("W_LASTTIME", DateTime.Now);
                MoneySystem.Wallet.Change(player, payment);
                GameLog.Money($"server", $"player({Main.Players[player].UUID})", payment, $"collectorCheck");

                if (player.HasData("WORKOBJECT"))
                {
                    BasicSync.DetachObject(player);
                    player.ResetData("WORKOBJECT");
                }

                if (player.GetData<int>("COLLECTOR_BAGS") == 0)
                {
                    Notify.Send(player, NotifyType.Alert, NotifyPosition.BottomCenter, "Fahre zurück zum Hof", 3000);
                    Trigger.ClientEvent(player, "deleteWorkBlip");
                    Trigger.ClientEvent(player, "createWaypoint", UnloadTrashPos.X, UnloadTrashPos.Y);
                    Trigger.ClientEvent(player, "deleteCheckpoint", 16);
                    return;
                }
                else
                {
                    var x = WorkManager.rnd.Next(0, MoneySystem.ATM.ATMs.Count - 1); ;
                    while (x == 36 || x == player.GetData<int>("WORKCHECK") || MoneySystem.ATM.ATMs[x].DistanceTo2D(player.Position) < 200)
                        x = WorkManager.rnd.Next(0, MoneySystem.ATM.ATMs.Count - 1);
                    player.SetData("WORKCHECK", x);
                    Trigger.ClientEvent(player, "createCheckpoint", 16, 29, MoneySystem.ATM.ATMs[x] + new Vector3(0, 0, 1.12), 1, 0, 220, 220, 0);
                    Trigger.ClientEvent(player, "createWaypoint", MoneySystem.ATM.ATMs[x].X, MoneySystem.ATM.ATMs[x].Y);
                    Trigger.ClientEvent(player, "createWorkBlip", MoneySystem.ATM.ATMs[x]);
                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Fahre zum nächsten Punkt.", 3000);
                }
            }
            catch { }
        }
    }
}
