using GTANetworkAPI;
using ULife.Core;
using ULife.Fractions;
using UNL.SDK;
using System;
using System.Collections.Generic;
using System.IO;

namespace ULife.carsmenu
{
    class carsmenu : Script
    {
        private static nLog RLog = new nLog("carsmenu");
        private static ColShape shape;
        private static ColShape shapes;
        private static ColShape shapess;
        private static Marker intmarker;
        public static int school_car = 6;
        public static int ems_car = 12;
        public static int spawn_car = 1;
        [ServerEvent(Event.ResourceStart)]


        public static void Cars()
        {
            NAPI.Marker.CreateMarker(1, cars[0], new Vector3(), new Vector3(), 0.5f, new Color(255, 225, 64), false, 0);
            NAPI.Marker.CreateMarker(1, cars[5], new Vector3(), new Vector3(), 0.5f, new Color(255, 225, 64), false, 0);
            NAPI.Marker.CreateMarker(1, cars[11], new Vector3(), new Vector3(), 0.5f, new Color(255, 225, 64), false, 0);
            shapess = NAPI.ColShape.CreateCylinderColShape(cars[11], 1, 2, 0);
            shapess.OnEntityEnterColShape += (s, ent) =>
            {
                try
                {
                    NAPI.Data.SetEntityData(ent, "INTERACTIONCHECK", 532);
                }
                catch (Exception ex) { Console.WriteLine("shape.OnEntityEnterColShape: " + ex.Message); }
            };
            shapess.OnEntityExitColShape += (s, ent) =>
            {
                try
                {

                    NAPI.Data.SetEntityData(ent, "INTERACTIONCHECK", 0);
                }
                catch (Exception ex) { Console.WriteLine("shape.OnEntityExitColShape: " + ex.Message); }
            };

            shape = NAPI.ColShape.CreateCylinderColShape(cars[0], 1, 2, 0);
            shapes = NAPI.ColShape.CreateCylinderColShape(cars[5], 1, 2, 0);
            shapes.OnEntityEnterColShape += (s, ent) =>
            {
                try
                {
                    NAPI.Data.SetEntityData(ent, "INTERACTIONCHECK", 536);
                }
                catch (Exception ex) { Console.WriteLine("shape.OnEntityEnterColShape: " + ex.Message); }
            };
            shapes.OnEntityExitColShape += (s, ent) =>
            {
                try
                {

                    NAPI.Data.SetEntityData(ent, "INTERACTIONCHECK", 0);
                }
                catch (Exception ex) { Console.WriteLine("shape.OnEntityExitColShape: " + ex.Message); }
            };
        shape.OnEntityEnterColShape += (s, ent) =>
            {
                try
                {
                    NAPI.Data.SetEntityData(ent, "INTERACTIONCHECK", 522);
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

        }
        public static List<Vector3> cars = new List<Vector3>()
        {
            new Vector3(-140.5982, -883.1056, 28.53704), //  0
            new Vector3(-139.9348, -895.9017, 29.16), //1
            new Vector3(-143.8845, -894.4292, 29.16557),//2
            new Vector3(-149.1374, -892.4435, 29.15401),//3
            new Vector3(-156.2322, -889.8961, 29.12925),//4
            new Vector3(234.526, 363.2961, 104.7),//5 Автошкола вызов меню мапедов
            new Vector3(242.8662, 351.8961, 105.419),//6 спавн мапедов автошкола
            new Vector3(239.5112, 353.1154, 105.4371),//7 спавн мапедов автошкола
            new Vector3(235.1484, 354.6682, 105.5029),//8 спавн мапедов автошкола
            new Vector3(229.1127, 357.4172, 105.6325),//9 спавн мапедов автошкола
            new Vector3(224.0875, 359.158, 105.7731),//10 спавн мапедов автошкола
            new Vector3(324.6607, -1370.91, 30.90841),//11 Емс мапеды вызов
            new Vector3(322.9118, -1355.471, 32.08092),//12 Емс мапеды
            new Vector3(325.299, -1352.439, 32.21509),//13 Емс мапеды
            new Vector3(327.7995, -1349.197, 32.33757),//14 Емс мапеды
            new Vector3(332.6469, -1343.376, 32.31586),//15 Емс мапеды
        };
        public static List<Vector3> carsrot = new List<Vector3>()
        {
            new Vector3(0,0,0), // craft Famalys               0
            new Vector3(-10.03894, 2.025895, 69.10031),//1
            new Vector3(-10.26923, 2.630296, 69.12708),//2
            new Vector3(-5.814378, 1.07974, 69.82324),//3
            new Vector3(-10.26076, 2.602917, 69.61981),//4
            new Vector3(0,0,0), // 5
            new Vector3(-8.781533, 0.3238137, 75.01016),// 6
            new Vector3(-10.19422, 3.058383, 63.86356),// 7
            new Vector3(-10.19608, 2.527312, 67.52414),// 8
            new Vector3(-1.002211, -2.31791, 69.94305),// 9
            new Vector3(-8.433666, -1.073428, 69.89508),// 10
            new Vector3(0,0,0), // 11
            new Vector3(3.33068, 10.00883, 323.5994), // 12
            new Vector3(2.549769, 9.482234, 323.3081), // 13
            new Vector3(3.808941, 8.090415, 320.0153), // 14
            new Vector3(5.960221, 9.373871, 320.4864), // 15
        };
        public static void getCars(Player player)
        {
            Trigger.ClientEvent(player, "openDialog", "New_Car", $"Вы хотите арендовать этот транспорт за 100$?");
        }
        public static void getCarsschool(Player player)
        {
            Trigger.ClientEvent(player, "openDialog", "New_Carschool", $"Вы хотите арендовать этот транспорт за 100$?");
        }
        public static void getemscars(Player player)
        {
            Trigger.ClientEvent(player, "openDialog", "New_Emschool", $"Вы хотите арендовать этот транспорт за 100$?");
        }
        public static void NewCars(Player player)
        {
            if (player.GetData<bool>("NoobCar") == true)
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"У вас уже есть арендованный транспорт", 3000);
                return;
            }
            player.SetData<bool>("NoobCar", true);
            ULife.MoneySystem.Wallet.Change(player, -100);
            var veh = API.Shared.CreateVehicle(VehicleHash.Faggio, cars[spawn_car], carsrot[spawn_car], 10, 10);
            spawn_car++;
            if (spawn_car >= 4)
            {
                spawn_car = 1;
            }
            NAPI.Player.SetPlayerIntoVehicle(player, veh, -1);
            player.SetData("IN_RENT_CARs", true);
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Вы получили транспорт", 3000);
            NAPI.Data.SetEntityData(veh, "ACCESS", "RENTNew");
            NAPI.Data.SetEntityData(veh, "DRIVER", player);
            player.SetData("vehnoob", veh);
            VehicleStreaming.SetEngineState(veh, true);
        }
        public static void NewCarsschool(Player player)
        {
            if (player.GetData<bool>("NoobCar") == true)
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"У вас уже есть арендованный транспорт", 3000);
                return;
            }
            player.SetData<bool>("NoobCar", true);
            ULife.MoneySystem.Wallet.Change(player, -100);
            var veh = API.Shared.CreateVehicle(VehicleHash.Faggio, cars[school_car], carsrot[school_car], 10, 10);
            school_car++;
            if (school_car >= 10)
            {
                school_car = 6;
            }
            NAPI.Player.SetPlayerIntoVehicle(player, veh, -1);
            player.SetData<bool>("IN_RENT_CARs", true);
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Вы получили транспорт", 3000);
            NAPI.Data.SetEntityData(veh, "ACCESS", "RENTNew");
            NAPI.Data.SetEntityData(veh, "DRIVER", player);
            player.SetData<Vehicle>("vehnoob", veh);
            VehicleStreaming.SetEngineState(veh, true);
        }

        public static void NewEmschool(Player player)
        {
            if (player.GetData<bool>("NoobCar") == true)
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"У вас уже есть арендованный транспорт", 3000);
                return;
            }
            player.SetData<bool>("NoobCar", true);
            ULife.MoneySystem.Wallet.Change(player, -100);
            var veh = API.Shared.CreateVehicle(VehicleHash.Faggio, cars[ems_car], carsrot[ems_car], 10, 10);
            ems_car++;
            if (ems_car >= 15)
            {
                ems_car = 12;
            }
            NAPI.Player.SetPlayerIntoVehicle(player, veh, -1);
            player.SetData<bool>("IN_RENT_CARs", true);
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Вы получили транспорт", 3000);
            NAPI.Data.SetEntityData(veh, "ACCESS", "RENTNew");
            NAPI.Data.SetEntityData(veh, "DRIVER", player);
            player.SetData<Vehicle>("vehnoob", veh);
            VehicleStreaming.SetEngineState(veh, true);
        }
        [ServerEvent(Event.PlayerExitVehicle)]
        public void Event_OnPlayerExitVehicle(Player player, Vehicle vehicle)
        {
            try
            {
                if (!player.IsInVehicle && !vehicle.HasData("ACCESS") || vehicle.GetData<string>("ACCESS") != "RENTNew" || vehicle.GetData<Player>("DRIVER") != player) return;
                Notify.Send(player, NotifyType.Warning, NotifyPosition.BottomCenter, $"Через 5 минут аренда транспорта закончится, если вы снова не сядете в т/с", 3000);
                NAPI.Data.SetEntityData(player, "IN_RENT_CARs", false);
                NAPI.Data.SetEntityData(player, "RENT_EXIT_TIMER_COUNTs", 0);
                //NAPI.Data.SetEntityData(player, "RENT_CAR_EXIT_TIMER", Main.StartT(1000, 1000, (o) => timer_playerExitRentVehicle(player, vehicle), "RENT_CAR_TIMER"));
                NAPI.Data.SetEntityData(player, "RENT_CAR_EXIT_TIMERs", Timers.Start(1000, () => timer_playerExitRentVehicle(player, vehicle)));
            }
            catch (Exception e) { }
        }
        private void timer_playerExitRentVehicle(Player player, Vehicle vehicle)
        {
            NAPI.Task.Run(() =>
            {
                try
                {
                    if (player.IsInVehicle) return;
                    if (!player.IsInVehicle && NAPI.Data.GetEntityData(player, "IN_RENT_CARs"))
                    {
                        //                    Main.StopT(NAPI.Data.GetEntityData(player, "RENT_CAR_EXIT_TIMER"), "timer_28");
                        Timers.Stop(NAPI.Data.GetEntityData(player, "RENT_CAR_EXIT_TIMERs"));
                        NAPI.Data.ResetEntityData(player, "RENT_CAR_EXIT_TIMERs");
                        return;
                    }
                    if (NAPI.Data.GetEntityData(player, "RENT_EXIT_TIMER_COUNTs") > 300)
                    {
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Срок аренды автомобиля закончился", 3000);
                        vehicle.Delete();
                        player.ResetData("NoobCar");
                        player.ResetData("vehnoob");
                        Timers.Stop(NAPI.Data.GetEntityData(player, "RENT_CAR_EXIT_TIMERs"));
                        NAPI.Data.ResetEntityData(player, "RENT_CAR_EXIT_TIMERs");
                        NAPI.Data.ResetEntityData(player, "RENT_EXIT_TIMER_COUNTs");
                        return;
                    }
                    NAPI.Data.SetEntityData(player, "RENT_EXIT_TIMER_COUNTs", NAPI.Data.GetEntityData(player, "RENT_EXIT_TIMER_COUNTs") + 1);
                }
                catch { };
                });
        }
        public static void Event_OnPlayerDisconnected(Player player)
        {
            try
            {
                if (player.HasData("vehnoob"))
                {
                        var vehicle = NAPI.Data.GetEntityData(player, "vehnoob");
                        NAPI.Entity.DeleteEntity(vehicle);
                        player.ResetData("vehnoob");
                        return;
                }
            }
            catch (Exception ex) { Console.WriteLine("playerdisconnectCarsMenu: " + ex.Message); }
        }
    }
}