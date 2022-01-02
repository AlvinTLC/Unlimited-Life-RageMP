using GTANetworkAPI;
using System.Collections.Generic;
using System;
using ULife.GUI;
using ULife.Core;
using UNL.SDK;

namespace ULife.Jobs
{
    class Window_wash : Script
    {
        private static int checkpointPayment = 6;
        private static nLog Log = new nLog("Window_wash");

        [ServerEvent(Event.ResourceStart)]
        public void Event_ResourceStart()
        {
            try
            {

                var col = NAPI.ColShape.CreateCylinderColShape(new Vector3(104.326126, -657.7652, 43.972385), 1, 2, 0);
                col.OnEntityEnterColShape += (shape, player) => {
                    try
                    {
                        player.SetData("INTERACTIONCHECK", 666);
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
                NAPI.TextLabel.CreateTextLabel(Main.StringToU16("~b~Drücken Sie E zum Ändern"), new Vector3(104.326126, -657.7652, 43.972385), 30f, 0.4f, 0, new Color(255, 255, 255), true, 0);
                NAPI.Marker.CreateMarker(1, new Vector3(104.326126, -657.7652, 43.972385) - new Vector3(0, 0, 0.7), new Vector3(), new Vector3(), 1, new Color(255, 255, 255, 220));

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
            Main.Players[player].WorkID = 5;
            if (Main.Players[player].WorkID != 5)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Du arbeitest nicht als Fensterputzer. Du kannst einen Job bei der Arbeitsagentur bekommen", 3000);
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
            new Checkpoint(new Vector3(118.79017, -665.9643, 45.95625), -23.639816),
            new Checkpoint(new Vector3(120.634315, -666.58014, 45.95625), -13.292203),
            new Checkpoint(new Vector3(123.69086, -667.0914, 45.95625), -10.438878),
            new Checkpoint(new Vector3(125.65409, -667.5952, 45.95625), -18.94156),
            new Checkpoint(new Vector3(127.787415, -668.02423, 45.95625), 5.300281),
            new Checkpoint(new Vector3(129.86328, -668.0992, 45.95625), -5.734886),
            new Checkpoint(new Vector3(132.90869, -667.81537, 45.95625), 9.259414),
            new Checkpoint(new Vector3(135.12962, -667.6574, 45.95625), 13.831611),
            new Checkpoint(new Vector3(137.04741, -667.1292, 45.95625), 4.458023),
            new Checkpoint(new Vector3(139.12645, -666.399, 45.95625), 28.539438),
            new Checkpoint(new Vector3(142.0683, -665.10046, 45.95625), 35.420662),
            new Checkpoint(new Vector3(143.71693, -664.05273, 45.95625), 35.128452),
            new Checkpoint(new Vector3(145.49014, -662.7563, 45.957424), 38.062004),
            new Checkpoint(new Vector3(147.13977, -661.38904, 45.957424), 47.911137),
            new Checkpoint(new Vector3(149.31818, -658.7838, 45.957424), 53.2683),
            new Checkpoint(new Vector3(150.45244, -657.344, 45.957424), 52.1052),
            new Checkpoint(new Vector3(151.51332, -655.6005, 45.957424), 63.713326),
            new Checkpoint(new Vector3(152.44742, -653.6454, 45.957424), 64.83632),
            new Checkpoint(new Vector3(154.05508, -650.7865, 45.95644), 64.58994),
            new Checkpoint(new Vector3(154.72044, -648.9613, 45.956432), 69.93563),
            new Checkpoint(new Vector3(155.54778, -646.9794, 45.95634), 65.82181),
            new Checkpoint(new Vector3(156.22055, -644.84045, 45.956444), 67.78704),
            new Checkpoint(new Vector3(157.21472, -642.3772, 45.956345), 62.802315),
            new Checkpoint(new Vector3(157.92592, -640.4476, 45.956326), 68.49178),
        };

        public static List<uint> WIndow_washObjects = new List<uint>
        {
            NAPI.Util.GetHashKey("prop_sponge_01"),
        };

        private static void PlayerEnterCheckpoint(ColShape shape, Player player)
        {
            try
            {
                if (!Main.Players.ContainsKey(player)) return;
                if (Main.Players[player].WorkID != 5 || !player.GetData<bool>("ON_WORK") || shape.GetData<int>("NUMBER") != player.GetData<int>("WORKCHECK")) return;

                if (Checkpoints[(int)shape.GetData<int>("NUMBER")].Position.DistanceTo(player.Position) > 3) return;

                var payment = Convert.ToInt32(checkpointPayment * Group.GroupPayAdd[Main.Accounts[player].VipLvl] * Main.oldconfig.PaydayMultiplier);
                MoneySystem.Wallet.Change(player, payment);
                GameLog.Money($"server", $"player({Main.Players[player].UUID})", payment, $"Window_washCheck");

                NAPI.Entity.SetEntityPosition(player, Checkpoints[shape.GetData<int>("NUMBER")].Position + new Vector3(0, 0, 1.2));
                NAPI.Entity.SetEntityRotation(player, new Vector3(0, 0, Checkpoints[shape.GetData<int>("NUMBER")].Heading));
                Main.OnAntiAnim(player);
                BasicSync.AttachObjectToPlayer(player, NAPI.Util.GetHashKey("prop_sponge_01"), 57005, new Vector3(0.15, 0.02, 0), new Vector3(0, 90, 0));
                player.PlayAnimation("amb@world_human_maid_clean@base", "base", 39);
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
