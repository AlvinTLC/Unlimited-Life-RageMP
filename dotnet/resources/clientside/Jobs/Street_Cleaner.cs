using GTANetworkAPI;
using System.Collections.Generic;
using System;
using ULife.GUI;
using ULife.Core;
using UNL.SDK;

namespace ULife.Jobs
{
    class Street_Cleaner : Script
    {
        private static int checkpointPayment = 10;
        private static nLog Log = new nLog("Street_Cleaner");

        [ServerEvent(Event.ResourceStart)]
        public void Event_ResourceStart()
        {
            try
            {

                var col = NAPI.ColShape.CreateCylinderColShape(new Vector3(151.32138, -986.2304, 29.091936), 1, 2, 0);
                col.OnEntityEnterColShape += (shape, player) => {
                    try
                    {
                        player.SetData("INTERACTIONCHECK", 667);
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
                NAPI.TextLabel.CreateTextLabel(Main.StringToU16("~b~Drücke E zum Ändern"), new Vector3(151.32138, -986.2304, 30.091936), 30f, 0.4f, 0, new Color(255, 255, 255), true, 0);
                NAPI.Marker.CreateMarker(1, new Vector3(151.32138, -986.2304, 29.091936) - new Vector3(0, 0, 0.7), new Vector3(), new Vector3(), 1, new Color(255, 255, 255, 220));

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
            Main.Players[player].WorkID = 9;
            if (Main.Players[player].WorkID != 9)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Du arbeitest nicht als Straßenreiniger, du kannst dir einen Job bei der Arbeitsargentur besorgen", 3000);
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
                {
                    player.SetClothes(3, 73, 0);
                    player.SetClothes(4, 36, 0);
                    player.SetClothes(6, 1, 0);
                    player.SetClothes(8, 59, 1);
                    player.SetClothes(11, 226, 0);
                }
                else
                {
                    player.SetClothes(3, 84, 0);
                    player.SetClothes(4, 35, 0);
                    player.SetClothes(6, 3, 0);
                    player.SetClothes(8, 36, 1);
                    player.SetClothes(11, 236, 0);
                }

                var check = WorkManager.rnd.Next(0, Checkpoints.Count - 1);
                player.SetData("WORKCHECK", check);
                Trigger.ClientEvent(player, "createCheckpoint", 15, 1, Checkpoints[check].Position, 1, 0, 255, 0, 0);
                Trigger.ClientEvent(player, "createWorkBlip", Checkpoints[check].Position);

                player.SetData("ON_WORK", true);
                Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, "Du hast deinen Arbeitstag begonnen", 3000);
                return;
            }
        }

        private static List<Checkpoint> Checkpoints = new List<Checkpoint>()
        {
            new Checkpoint(new Vector3(173.98247, -986.6199, 29.091913), 32.017303),
            new Checkpoint(new Vector3(173.98247, -986.6199, 29.091913), 74.22709),
            new Checkpoint(new Vector3(172.19698, -952.9133, 29.091946), 74.22709),
            new Checkpoint(new Vector3(185.56882, -922.70074, 29.688148), 74.22709),
            new Checkpoint(new Vector3(164.08823, -917.6722, 29.18901), 74.22709),
            new Checkpoint(new Vector3(206.23297, -948.1257, 29.685276), 74.22709),
            new Checkpoint(new Vector3(209.20787, -923.3652, 29.692202), 74.22709),
            new Checkpoint(new Vector3(229.16763, -894.2689, 29.692213), -149.81659),
        };

        public static List<uint> Street_CleanerObjects = new List<uint>
        {
            NAPI.Util.GetHashKey("prop_leaf_blower_01"),
        };

        private static void PlayerEnterCheckpoint(ColShape shape, Player player)
        {
            try
            {
                if (!Main.Players.ContainsKey(player)) return;
                if (Main.Players[player].WorkID != 9 || !player.GetData<bool>("ON_WORK") || shape.GetData<int>("NUMBER") != player.GetData<int>("WORKCHECK")) return;

                if (Checkpoints[(int)shape.GetData<int>("NUMBER")].Position.DistanceTo(player.Position) > 3) return;

                var payment = Convert.ToInt32(checkpointPayment * Group.GroupPayAdd[Main.Accounts[player].VipLvl] * Main.oldconfig.PaydayMultiplier);
                MoneySystem.Wallet.Change(player, payment);
                GameLog.Money($"server", $"player({Main.Players[player].UUID})", payment, $"Street_CleanerCheck");

                NAPI.Entity.SetEntityPosition(player, Checkpoints[shape.GetData<int>("NUMBER")].Position + new Vector3(0, 0, 1.2));
                NAPI.Entity.SetEntityRotation(player, new Vector3(0, 0, Checkpoints[shape.GetData<int>("NUMBER")].Heading));
                Main.OnAntiAnim(player);
                BasicSync.AttachObjectToPlayer(player, NAPI.Util.GetHashKey("prop_leaf_blower_01"), 57005, new Vector3(0.15, 0.02, 0), new Vector3(0, 0, 0));
                player.PlayAnimation("amb@world_human_gardener_leaf_blower@idle_a", "idle_a", 39);
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
