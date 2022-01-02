using GTANetworkAPI;
using System;
using ULife.GUI;
using ULife.Houses;
using System.Collections.Generic;
using System.Linq;
using UNL.SDK;
using ULife.Core;
using ULife.MoneySystem;

namespace ULife.Core
{
    class Arenda : Script
    {
        private static Dictionary<int, ColShape> Cols = new Dictionary<int, ColShape>();
        public static List<CarInfo> CarInfos = new List<CarInfo>();
        private static List<Vector3> arendaCheckpoints = new List<Vector3>()
        {
            new Vector3(100.493675, -1073.0432, 28.372833), // arenda    0
        };
        private static nLog Log = new nLog("ARENDA");

        public static object Vehicles { get; private set; }

        [ServerEvent(Event.ResourceStart)]
        public void onResourceStart()
        {
            try
            {
                foreach (Vector3 vec in arendaCheckpoints)
                {
                   
                    NAPI.Marker.CreateMarker(1, arendaCheckpoints[0] - new Vector3(0, 0, 0.7), new Vector3(), new Vector3(), 1, new Color(0, 255, 255));

                    Cols.Add(0, NAPI.ColShape.CreateCylinderColShape(arendaCheckpoints[0], 1, 2, 0)); // arenda
                    Cols[0].SetData("INTERACT", 67);
                    Cols[0].OnEntityEnterColShape += arendaShape_onEntityEnterColShape;
                    Cols[0].OnEntityExitColShape += arendaShape_onEntityExitColShape;
                    NAPI.TextLabel.CreateTextLabel(Main.StringToU16("Autovermietung"), new Vector3(arendaCheckpoints[0].X, arendaCheckpoints[0].Y, arendaCheckpoints[0].Z + 1.7), 20F, 0.5F, 0, new Color(255, 255, 255));


                }
            }
            catch (Exception e) { Log.Write("ResourceStart: " + e.Message, nLog.Type.Error); }
        }
        #region
        private void arendaShape_onEntityEnterColShape(ColShape shape, Player entity)
        {
            try
            {
                NAPI.Data.SetEntityData(entity, "INTERACTIONCHECK", shape.GetData<int>("INTERACT"));
            }
            catch (Exception ex) { Log.Write("svalkaShape_onEntityEnterColShape: " + ex.Message, nLog.Type.Error); }
        }

        private void arendaShape_onEntityExitColShape(ColShape shape, Player entity)
        {
            try
            {
                NAPI.Data.SetEntityData(entity, "INTERACTIONCHECK", 0);
            }
            catch (Exception ex) { Log.Write("svalkaShape_onEntityExitColShape: " + ex.Message, nLog.Type.Error); }
        }
        #endregion
        #region Timer
        [ServerEvent(Event.PlayerExitVehicle)]
        public void Event_OnPlayerExitVehicle(Player player, Vehicle vehicle)
        {
            try
            {
                if (!player.HasData("CARROOMID")) return;
                if (!vehicle.HasData("ACCESS") || vehicle.GetData<string>("ACCESS") != "RENT" || vehicle.GetData<Player>("DRIVER") != player) return;
                Notify.Send(player, NotifyType.Warning, NotifyPosition.BottomCenter, $"Wenn du in 15 Minuten nicht wieder ins Fahrzeug steigst, wird es wieder abgeholt.", 3000);
                NAPI.Data.SetEntityData(player, "IN_RENT_CAR", false);
                NAPI.Data.SetEntityData(player, "RENT_EXIT_TIMER_COUNT", 0);
                //NAPI.Data.SetEntityData(player, "RENT_CAR_EXIT_TIMER", Main.StartT(1000, 1000, (o) => timer_playerExitRentVehicle(player, vehicle), "RENT_CAR_TIMER"));
                NAPI.Data.SetEntityData(player, "RENT_CAR_EXIT_TIMER", Timers.Start(1000, () => timer_playerExitRentVehicle(player, vehicle)));
            }
            catch (Exception e) { Log.Write("PlayerExitVehicle: " + e.Message, nLog.Type.Error); }
        }
        public static void RespawnCar(Vehicle vehicle)
        {
            var number = vehicle.GetData<int>("NUMBER");
            var random = new Random();
            NAPI.Entity.SetEntityPosition(vehicle, CarInfos[number].Position);
            NAPI.Entity.SetEntityRotation(vehicle, CarInfos[number].Rotation);
            VehicleManager.RepairCar(vehicle);

            NAPI.Data.SetEntityData(vehicle, "ACCESS", "RENT");
            NAPI.Data.SetEntityData(vehicle, "NUMBER", number);
            NAPI.Data.SetEntityData(vehicle, "DRIVER", null);
            NAPI.Data.SetEntitySharedData(vehicle, "PETROL", 50);
            Core.VehicleStreaming.SetEngineState(vehicle, false);
            Core.VehicleStreaming.SetLockStatus(vehicle, false);
        }
        private void timer_playerExitRentVehicle(Player player, Vehicle vehicle)
        {
            NAPI.Task.Run(() =>
            {
                try
                {
                    if (!player.HasData("RENT_CAR_EXIT_TIMER")) return;
                    if (NAPI.Data.GetEntityData(player, "IN_RENT_CAR"))
                    {
                        //                    Main.StopT(NAPI.Data.GetEntityData(player, "RENT_CAR_EXIT_TIMER"), "timer_28");
                        Timers.Stop(NAPI.Data.GetEntityData(player, "RENT_CAR_EXIT_TIMER"));
                        NAPI.Data.ResetEntityData(player, "RENT_CAR_EXIT_TIMER");
                        return;
                    }
                    if (NAPI.Data.GetEntityData(player, "RENT_EXIT_TIMER_COUNT") > 9000)
                    {
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast dein Mietfahrzeug zurückgegeben", 3000);
                        RespawnCar(vehicle);
                        player.ResetData("RENTED_CAR");
                        //                        Main.StopT(NAPI.Data.GetEntityData(player, "RENT_CAR_EXIT_TIMER"), "timer_30");
                        Timers.Stop(NAPI.Data.GetEntityData(player, "RENT_CAR_EXIT_TIMER"));
                        NAPI.Data.ResetEntityData(player, "RENT_CAR_EXIT_TIMER");
                        return;
                    }
                    NAPI.Data.SetEntityData(player, "RENT_EXIT_TIMER_COUNT", NAPI.Data.GetEntityData(player, "RENT_EXIT_TIMER_COUNT") + 1);
                }
                catch (Exception e) { Log.Write("timerExitRentVehicle: " + e.Message, nLog.Type.Error); }
            });
        }

        public static void Event_OnPlayerDisconnected(Player player)
        {
            try
            {
                if (player.HasData("RENTED_CAR"))
                    RespawnCar(player.GetData<Vehicle>("RENTED_CAR"));
                if (player.HasData("RENT_CAR_EXIT_TIMER"))
                    Timers.Stop(player.GetData<string>("RENT_CAR_EXIT_TIMER"));
            }
            catch (Exception e) { Log.Write("PlayerDisconnected: " + e.Message, nLog.Type.Error); }
        }
        [ServerEvent(Event.PlayerEnterVehicle)]
        public void Event_OnPlayerEnterVehicle(Player player, Vehicle vehicle, sbyte seatid)
        {
            try
            {
                int number = vehicle.GetData<int>("NUMBER");
                if (vehicle.GetData<Player>("DRIVER") == null)
                {
                    if (player.HasData("RENTED_CAR"))
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, "Du hast schon ein Mietvertrag abgeschlossen", 3000);
                        VehicleManager.WarpPlayerOutOfVehicle(player);
                        return;
                    }
                }
                else
                {
                    player.SetData("IN_RENT_CAR", true);
                }
            }
            catch (Exception e) { Log.Write("PlayerEnterVehicle: " + e.Message, nLog.Type.Error); }
        }
        #endregion

        public static void OpenarcarsMenu(Player player)
        {
            Trigger.ClientEvent(player, "arcars");
        }
        [RemoteEvent("arcarss")]
        public static void callback_arcarss(Player player, int index)
        {
            try
            {
                switch (index)
                {
                case 0:
                    if (Main.Players[player].Money < 300)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nicht genug Geld", 3000);
                        VehicleManager.WarpPlayerOutOfVehicle(player);
                        return;
                    }
                    var veh = API.Shared.CreateVehicle(NAPI.Util.GetHashKey("bodhi2"), new Vector3(107.31913, -1059.6837, 29.20000), player.Rotation.Z, 0, 0);
                    veh.NumberPlate = "RENT";
                    VehicleStreaming.SetEngineState(veh, true);
                    //player.SetIntoVehicle(veh, 0);
                    Wallet.Change(player, -300);
                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Der Mietvertrag wurde Unterschrieben", 3000);
                    return;
                case 1:
                    if (Main.Players[player].Money < 250)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nicht genug Geld", 3000);
                        VehicleManager.WarpPlayerOutOfVehicle(player);
                        return;
                    }
                    veh = API.Shared.CreateVehicle(NAPI.Util.GetHashKey("emperor"), new Vector3(105.61901, -1062.9979, 29.192272), player.Rotation.Z, 0, 0);
                    veh.NumberPlate = "RENT";
                    VehicleStreaming.SetEngineState(veh, true);
                    //player.SetIntoVehicle(veh, 0);
                    Wallet.Change(player, -250);
                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Der Mietvertrag wurde Unterschrieben", 3000);
                    return;
                }
            }
            catch (Exception e)
            {
                Log.Write($"Arendacar: " + e.Message, nLog.Type.Error);
            }
        }
    }
}
        