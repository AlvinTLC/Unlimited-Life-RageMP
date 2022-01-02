using GTANetworkAPI;
using System.Collections.Generic;
using System;
using ULife.GUI;
using ULife.Core;
using UNL.SDK;


namespace ULife.Jobs
{
    class Loader
    {
        private static int checkpointPayment = 13;
        private static nLog Log = new nLog("Loader");

        [ServerEvent(Event.ResourceStart)]
        public void Event_ResourceStart()
        {
            try
            {
                //NAPI.TextLabel.CreateTextLabel("~g~Ronny Bolls", new Vector3(724.8585, 134.1029, 81.95643), 30f, 0.3f, 0, new Color(255, 255, 255), true, NAPI.GlobalDimension);

                #region Objects Delete
                /*//NAPI.World.DeleteWorldProp(1046551856, new Vector3(732.2359, 133.4224, 79.84549), 30f); // Двери место работы электрика
                //NAPI.World.DeleteWorldProp(1046551856, new Vector3(722.1532, 139.4459, 79.84549), 30f); // Двери место работы электрика*/

                #endregion
                NAPI.Blip.CreateBlip(566, new Vector3(1229.4194, -3234.0862, 6.0287633), 0.75f, 46, Main.StringToU16("Loader"), 255, 0, true, 0, 0); // Блип на карте
                var col = NAPI.ColShape.CreateCylinderColShape(new Vector3(1229.4194, -3234.0862, 6.0287633), 1, 2, 0);
                col.OnEntityEnterColShape += (shape, player) => {
                    try
                    {
                        player.SetData("INTERACTIONCHECK", 671);
                    }
                    catch (Exception ex) { Log.Write("col.OnEntityEnterColShape: " + ex.Message, nLog.Type.Error); }
                };
                col.OnEntityExitColShape += (shape, player) => {
                    try
                    {
                        player.SetData("INTERACTIONCHECK", 0);
                    }
                    catch (Exception ex) { Log.Write("col.OnEntityExitColShape: " + ex.Message, nLog.Type.Error); }
                };
                // NAPI.TextLabel.CreateTextLabel(Main.StringToU16("~b~Нажмите Е, чтобы переодеться"), new Vector3(1695.806, 43.05446, 162.9473), 30f, 0.3f, 0, new Color(255, 255, 255), true, 0);
                // NAPI.Marker.CreateMarker(1, new Vector3(-513.208, -1019.0484, 22.362576) - new Vector3(0, 0, 0.7), new Vector3(), new Vector3(), 1, new Color(255, 255, 255, 220));

                int i = 0;
                foreach (var Check in Checkpoints)
                {
                    col = NAPI.ColShape.CreateCylinderColShape(Check.Position, 1, 2, 0);
                    col.SetData("NUMBER", i);
                    col.OnEntityEnterColShape += PlayerEnterCheckpoint;
                    i++;
                }
            }
            catch (Exception e) { Log.Write("ResourceStart: " + e.Message, nLog.Type.Error); }
        }

        public static void StartWorkDay(Player player)
        {
            Main.Players[player].WorkID = 1;
            if (Main.Players[player].WorkID != 1)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Du arbeitest nicht als Lader, du kannst dir ein Job bei der Arbeitsargentur besorgen", 3000);
                return;
            }
            if (player.GetData<bool>("ON_WORK"))
            {
                Main.Players[player].WorkID = 0;
                Customization.ApplyCharacter(player);
                player.SetData("ON_WORK", false);
                Trigger.ClientEvent(player, "deleteCheckpoint", 15);
                Trigger.ClientEvent(player, "deleteWorkBlip");

                Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Du bist für den Tag fertig", 3000);
                //player.SetData("PAYMENT", 0);
                return;
            }
            else
            {
                Customization.ClearClothes(player, Main.Players[player].Gender);
                if (Main.Players[player].Gender)
                    if (Main.Players[player].Gender)
                    {
                        //player.SetAccessories(1, 24, 2);
                        //player.SetClothes(3, 2, 0);
                        player.SetClothes(8, 59, 0);
                        player.SetClothes(11, 1, 0);
                        player.SetClothes(4, 0, 5);
                        player.SetClothes(6, 48, 0);
                    }
                    else
                    {
                        //player.SetAccessories(1, 26, 2);
                        //player.SetClothes(3, 11, 0);
                        player.SetClothes(8, 36, 0);
                        player.SetClothes(11, 0, 0);
                        player.SetClothes(4, 1, 5);
                        player.SetClothes(6, 49, 0);
                    }

                var check = WorkManager.rnd.Next(0, Checkpoints.Count - 1);
                player.SetData("WORKCHECK", check);
                Trigger.ClientEvent(player, "createCheckpoint", 15, 1, Checkpoints[check].Position, 1, 0, 255, 0, 0);
                /*Trigger.ClientEvent(player, "createObjectJobs", 0, Objects[0], Checkpoints[0].Position.X, Checkpoints[0].Position.Y, Checkpoints[0].Position.Z); //new
                Trigger.ClientEvent(player, "createObjectJobs", 1, Objects[1], Checkpoints[1].Position.X, Checkpoints[1].Position.Y, Checkpoints[1].Position.Z);  //new
                Trigger.ClientEvent(player, "createObjectJobs", 2, Objects[2], Checkpoints[2].Position.X, Checkpoints[2].Position.Y, Checkpoints[2].Position.Z);  //new
                Trigger.ClientEvent(player, "createObjectJobs", 3, Objects[3], Checkpoints[3].Position.X, Checkpoints[3].Position.Y, Checkpoints[3].Position.Z);   //new
                Trigger.ClientEvent(player, "createObjectJobs", 4, Objects[4], Checkpoints[4].Position.X, Checkpoints[4].Position.Y, Checkpoints[4].Position.Z);   //new */
                Trigger.ClientEvent(player, "createWorkBlip", Checkpoints[check].Position);

                player.SetData("ON_WORK", true);
                Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, "Du hast deinen Arbeitstag begonnen", 3000);
                return;
            }
        }

        private static List<Checkpoint> Checkpoints = new List<Checkpoint>()
        {
            new Checkpoint(new Vector3(1266.80, -3129.506, 4.782248), 269.0657), // Взять ящик 0
            new Checkpoint(new Vector3(1266.47, -3133.008, 4.782152), 267.7546), // Взять ящик 1
            new Checkpoint(new Vector3(1266.31, -3119.273, 4.782105), 269.8171), // Взять ящик 2
            new Checkpoint(new Vector3(1247.34, -3172.527, 4.589797), 157.6356), // Взять ящик 3
        };

        public static List<uint> Objects = new List<uint>
        {
            NAPI.Util.GetHashKey("prop_cs_package_01"),
        };

        private static void PlayerEnterCheckpoint(ColShape shape, Player player)
        {
            try
            {
                if (!Main.Players.ContainsKey(player)) return;
                if (Main.Players[player].WorkID != 1 || !player.GetData<bool>("ON_WORK") || shape.GetData<int>("NUMBER") != player.GetData<int>("WORKCHECK")) return;

                if (Checkpoints[(int)shape.GetData<int>("NUMBER")].Position.DistanceTo(player.Position) > 3) return;

                var payment = Convert.ToInt32(checkpointPayment * Group.GroupPayAdd[Main.Accounts[player].VipLvl] * Main.oldconfig.PaydayMultiplier);
                MoneySystem.Wallet.Change(player, payment);
                GameLog.Money($"server", $"player({Main.Players[player].UUID})", payment, $"builderCheck");

                NAPI.Entity.SetEntityPosition(player, Checkpoints[shape.GetData<int>("NUMBER")].Position + new Vector3(0, 0, 1.2));
                NAPI.Entity.SetEntityRotation(player, new Vector3(0, 0, Checkpoints[shape.GetData<int>("NUMBER")].Heading));
                Main.OnAntiAnim(player);
                BasicSync.AttachObjectToPlayer(player, NAPI.Util.GetHashKey("prop_cs_package_01"), 18905, new Vector3(0.10, 0, 0.05), new Vector3(0, -90, 0));
                //player.PlayAnimation("amb@world_human_welding@male@base", "base", 39);
                player.SetData("WORKCHECK", -1);
                NAPI.Task.Run(() => {
                    try
                    {
                        if (player != null && Main.Players.ContainsKey(player))
                        {
                            player.StopAnimation();
                            Main.OffAntiAnim(player);
                            var nextCheck = WorkManager.rnd.Next(0, Checkpoints.Count - 1);
                            while (nextCheck == shape.GetData<int>("NUMBER")) nextCheck = WorkManager.rnd.Next(0, Checkpoints.Count - 1);
                            player.SetData("WORKCHECK", nextCheck);
                            BasicSync.DetachObject(player);
                            Trigger.ClientEvent(player, "createCheckpoint", 15, 1, Checkpoints[nextCheck].Position, 1, 0, 255, 0, 0);
                            /* Trigger.ClientEvent(player, "createObjectJobs", 0, Objects[0], Checkpoints[0].Position.X, Checkpoints[0].Position.Y, Checkpoints[0].Position.Z); //new
                             Trigger.ClientEvent(player, "createObjectJobs", 1, Objects[1], Checkpoints[1].Position.X, Checkpoints[1].Position.Y, Checkpoints[1].Position.Z);  //new
                             Trigger.ClientEvent(player, "createObjectJobs", 2, Objects[2], Checkpoints[2].Position.X, Checkpoints[2].Position.Y, Checkpoints[2].Position.Z);    //new
                             Trigger.ClientEvent(player, "createObjectJobs", 3, Objects[3], Checkpoints[3].Position.X, Checkpoints[3].Position.Y, Checkpoints[3].Position.Z);    //new
                             Trigger.ClientEvent(player, "createObjectJobs", 4, Objects[4], Checkpoints[4].Position.X, Checkpoints[4].Position.Y, Checkpoints[4].Position.Z);    //new */
                            Trigger.ClientEvent(player, "createWorkBlip", Checkpoints[nextCheck].Position);
                        }
                    }
                    catch { }
                }, 4000);

            }
            catch (Exception e) { Log.Write("PlayerEnterCheckpoint: " + e.Message, nLog.Type.Error); }
        }

        internal class Checkpoint
        {
            public Vector3 Position { get; }
            public double Heading { get; }

            public Checkpoint(Vector3 pos, double rot)
            {
                Position = pos;
                Heading = rot;
            }
        }
    }
}
