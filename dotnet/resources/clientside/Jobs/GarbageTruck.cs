using GTANetworkAPI;
using System;
using System.Collections.Generic;
using ULife.GUI;
using ULife.Core;
using UNL.SDK;
using ULife;

namespace NeptuneEvo.Jobs
{
    class GarbageTruck : Script
    {
        private static Vehicle veh;
        [RemoteEvent("SERVER:WORK:START")]
        public static void GarbageTruckStartWork(Player player)
        {
            if (!Main.Players[player].Licenses[0])
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"У Вас нет лицензии категории C", 3000);
                VehicleManager.WarpPlayerOutOfVehicle(player);
                return;
            }

            veh = NAPI.Vehicle.CreateVehicle(VehicleHash.Trash, new Vector3(-5.5374121665954590, 6.7852067947387695, 70.7732925415039), 180, 0, 0, "Truck");
            NAPI.Data.SetEntityData(veh, "ACCESS", "WORK");
            NAPI.Data.SetEntityData(veh, "NUMBER", "Truck");
            NAPI.Data.SetEntityData(veh, "ON_WORK", true);
            NAPI.Data.SetEntityData(veh, "DRIVER", player);
            veh.SetSharedData("PETROL", VehicleManager.VehicleTank[veh.Class]);
        }

        [RemoteEvent("SERVER:WORK:END")]
        public static void GarbageTruckEndWork(Player player)
        {
            NAPI.Data.SetEntityData(veh, "ACCESS", "WORK");
            NAPI.Data.SetEntityData(veh, "NUMBER", "Truck");
            NAPI.Data.SetEntityData(veh, "ON_WORK", false);
            NAPI.Data.SetEntityData(veh, "DRIVER", null);
            veh.Delete();
        }

        [RemoteEvent("WORK:GARBAGE:SET:MONEY")]
        public static void GarbageTruckWorkPay(Player player, int amount)
        {
            player.SendNotification("Вы получили " + amount + " за собранный мусор!");
            ULife.MoneySystem.Wallet.Change(player, amount);
        }

    }
}
