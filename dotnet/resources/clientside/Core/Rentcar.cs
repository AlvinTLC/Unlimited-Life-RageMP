using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using ULife.GUI;
using UNL.SDK;

namespace ULife.Core
{
    class Rentcar : Script
    {
        private static nLog Log = new nLog("Rentcar");
        public static List<CarInfo> CarInfos = new List<CarInfo>();

        private static List<Vector3> RentAreas = new List<Vector3>()
        {
            new Vector3(-2145.544, -379.614, 13.24884),
            new Vector3(-1401.284, 36.33679, 53.16653),
            new Vector3(-581.241, -244.2824, 36.00377),
        };

        public static Vector3 GetNearestRentArea(Vector3 position)
        {
            Vector3 nearesetArea = RentAreas[0];
            foreach (var v in RentAreas)
            {
                if (v == new Vector3(237.3785, 217.7914, 106.2868)) continue;
                if (position.DistanceTo(v) < position.DistanceTo(nearesetArea))
                    nearesetArea = v;
            }
            return nearesetArea;
        }

        public static void rentCarsSpawner()
        {
            var random = new Random();
            var i = 0;
            foreach (var c in CarInfos)
            {
                var veh = NAPI.Vehicle.CreateVehicle(c.Model, c.Position, c.Rotation, random.Next(0, 130), random.Next(0, 130));
                NAPI.Data.SetEntityData(veh, "ACCESS", "RENT");
                NAPI.Data.SetEntityData(veh, "NUMBER", i);
                NAPI.Data.SetEntityData(veh, "DRIVER", null);
                Core.VehicleStreaming.SetEngineState(veh, false);
                Core.VehicleStreaming.SetLockStatus(veh, false);
                i++;
            }
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
            NAPI.Data.SetEntitySharedData(vehicle, "PETROL", 50); //к Entity добавить Shared
            Core.VehicleStreaming.SetEngineState(vehicle, false);
            Core.VehicleStreaming.SetLockStatus(vehicle, false);
        }

        [ServerEvent(Event.PlayerEnterVehicle)]
        public void Event_OnPlayerEnterVehicle(Player player, Vehicle vehicle, sbyte seatid)
        {
            try
            {
                if (!vehicle.HasData("ACCESS") || vehicle.GetData<string>("ACCESS") != "RENT" || seatid != 0) return;
                if (vehicle.GetData<Player>("DRIVER") != null && vehicle.GetData<Player>("DRIVER") != player)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Der Transport wurde bereits angemietet", 3000);
                    VehicleManager.WarpPlayerOutOfVehicle(player);
                    return;
                }

                int number = vehicle.GetData<int>("NUMBER");
                if (vehicle.GetData<Player>("DRIVER") == null)
                {
                    if (player.HasData("RENTED_CAR"))
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Sie haben bereits eine andere Fahrzeugmiete bezahlt", 3000);
                        VehicleManager.WarpPlayerOutOfVehicle(player);
                        return;
                    }
                    if (CarInfos[number].Model == VehicleHash.Faggio && Main.Players[player].LVL >= 2)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Diese Fahrräder sind nur für Anfänger geeignet", 3000);
                        VehicleManager.WarpPlayerOutOfVehicle(player);
                        return;
                    }
                    int price = CarInfos[number].Price;
                    switch (Main.Accounts[player].VipLvl)
                    {
                        case 0:
                            price = CarInfos[number].Price;
                            break;
                        case 1:
                            price = Convert.ToInt32(CarInfos[number].Price * 0.95);
                            break;
                        case 2:
                            price = Convert.ToInt32(CarInfos[number].Price * 0.9);
                            break;
                        case 3:
                            price = Convert.ToInt32(CarInfos[number].Price * 0.85);
                            break;
                        case 4:
                            price = Convert.ToInt32(CarInfos[number].Price * 0.8);
                            break;
                        default:
                            price = CarInfos[number].Price;
                            break;
                    }
                    Trigger.ClientEvent(player, "openDialog", "RENT_CAR", $"Sie möchten dieses Fahrzeug mieten für ${price}?");
                }
                else
                {
                    player.SetData("IN_RENT_CAR", true);
                }
            }
            catch (Exception e) { Log.Write("PlayerEnterVehicle: " + e.Message, nLog.Type.Error); }
        }

        [ServerEvent(Event.PlayerExitVehicle)]
        public void Event_OnPlayerExitVehicle(Player player, Vehicle vehicle)
        {
            try
            {
                if (!vehicle.HasData("ACCESS") || vehicle.GetData<string>("ACCESS") != "RENT" || vehicle.GetData<Player>("DRIVER") != player) return;
                Notify.Send(player, NotifyType.Warning, NotifyPosition.MapUp, $"Drei Minuten bis zum Ende des Mietvertrags.", 3000);
                NAPI.Data.SetEntityData(player, "IN_RENT_CAR", false);
                NAPI.Data.SetEntityData(player, "RENT_EXIT_TIMER_COUNT", 0);
                NAPI.Data.SetEntityData(player, "RENT_CAR_EXIT_TIMER", Timers.Start(1000, () => timer_playerExitRentVehicle(player, vehicle)));
            }
            catch (Exception e) { Log.Write("PlayerExitVehicle: " + e.Message, nLog.Type.Error); }
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
                        Timers.Stop(NAPI.Data.GetEntityData(player, "RENT_CAR_EXIT_TIMER"));
                        NAPI.Data.ResetEntityData(player, "RENT_CAR_EXIT_TIMER");
                        return;
                    }
                    if (NAPI.Data.GetEntityData(player, "RENT_EXIT_TIMER_COUNT") > 180)
                    {
                        Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Das Mietauto ist abgelaufen", 3000);
                        RespawnCar(vehicle);
                        player.ResetData("RENTED_CAR");
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

        public static void RentCar(Player player)
        {
            if (!player.IsInVehicle || !player.Vehicle.HasData("ACCESS") || player.Vehicle.GetData<string>("ACCESS") != "RENT" || player.Vehicle.GetData<Player>("DRIVER") != null)
            {
                VehicleManager.WarpPlayerOutOfVehicle(player);
                return;
            }
            int price = CarInfos[player.Vehicle.GetData<int>("NUMBER")].Price;
            switch (Main.Accounts[player].VipLvl)
            {
                case 0:
                    price = CarInfos[player.Vehicle.GetData<int>("NUMBER")].Price;
                    break;
                case 1:
                    price = Convert.ToInt32(CarInfos[player.Vehicle.GetData<int>("NUMBER")].Price * 0.95);
                    break;
                case 2:
                    price = Convert.ToInt32(CarInfos[player.Vehicle.GetData<int>("NUMBER")].Price * 0.9);
                    break;
                case 3:
                    price = Convert.ToInt32(CarInfos[player.Vehicle.GetData<int>("NUMBER")].Price * 0.85);
                    break;
                case 4:
                    price = Convert.ToInt32(CarInfos[player.Vehicle.GetData<int>("NUMBER")].Price * 0.8);
                    break;
                default:
                    price = CarInfos[player.Vehicle.GetData<int>("NUMBER")].Price;
                    break;
            }
            if (Main.Players[player].Money < price)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Unzureichende Mittel", 3000);
                VehicleManager.WarpPlayerOutOfVehicle(player);
                return;
            }
            player.Vehicle.SetData("DRIVER", player);
            player.SetData("RENTED_CAR", player.Vehicle);
            player.SetData("IN_RENT_CAR", true);
            MoneySystem.Wallet.Change(player, -price);
            GameLog.Money($"player({Main.Players[player].UUID})", $"server", price, $"rentCar");
        }
    }
}
