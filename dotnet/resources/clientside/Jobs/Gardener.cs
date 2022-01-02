using GTANetworkAPI;
using System.Collections.Generic;
using System;
using ULife.GUI;
using ULife.Core;
using UNL.SDK;

namespace ULife.Jobs
{
    class Gardener : Script
    {
        private static int checkpointPayment = 12;
        private static nLog Log = new nLog("Gardener");

        [ServerEvent(Event.ResourceStart)]
        public void Event_ResourceStart()
        {
            try
            {

                var col = NAPI.ColShape.CreateCylinderColShape(new Vector3(-949.17444, 332.02942, 70.21934), 1, 2, 0);
                col.OnEntityEnterColShape += (shape, player) => {
                    try
                    {
                        player.SetData("INTERACTIONCHECK", 669);
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
                NAPI.TextLabel.CreateTextLabel(Main.StringToU16("~b~Drücken Sie E zum Ändern"), new Vector3(-949.17444, 332.02942, 70.21934), 30f, 0.4f, 0, new Color(255, 255, 255), true, 0);
                NAPI.Marker.CreateMarker(1, new Vector3(-949.17444, 332.02942, 70.21934) - new Vector3(0, 0, 0.7), new Vector3(), new Vector3(), 1, new Color(255, 255, 255, 220));

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
            Main.Players[player].WorkID = 10;
            if (Main.Players[player].WorkID != 10)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Du arbeitest nicht als Gärtner, du kannst dir einen Job bei der Arbeitsargentur besorgen", 3000);
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
                    player.SetClothes(3, 0, 0);
                    player.SetClothes(4, 98, 0);
                    player.SetClothes(6, 61, 0);
                    player.SetClothes(8, 59, 1);
                    player.SetClothes(11, 337, 0);
                }
                else
                {
                    player.SetClothes(3, 0, 0);
                    player.SetClothes(4, 101, 0);
                    player.SetClothes(6, 64, 0);
                    player.SetClothes(8, 36, 1);
                    player.SetClothes(11, 352, 0);
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
            new Checkpoint(new Vector3(-966.476, 337.3801, 70.3032), -108.23),
            new Checkpoint(new Vector3(-968.1511, 348.529, 71.04331), -108.23),
            new Checkpoint(new Vector3(-973.2154, 311.11316, 68.78832), -108.23),
            new Checkpoint(new Vector3(-980.7981, 303.49258, 68.13359), -108.23),
            new Checkpoint(new Vector3(-999.84467, 306.71725, 67.396996), -108.23),
            new Checkpoint(new Vector3(-1015.535, 324.18985, 67.73852), -108.23),
            new Checkpoint(new Vector3(-950.88776, 296.70648, 68.97812), -108.23),
            new Checkpoint(new Vector3(-953.36945, 288.4671, 68.74052), -108.23),
            new Checkpoint(new Vector3(-1014.53235, 317.12143, 67.32128), -108.23),

        };

        public static List<uint> GardenerObjects = new List<uint>
        {
            NAPI.Util.GetHashKey(""), //prop was der in der hand hat
        };

        private static void PlayerEnterCheckpoint(ColShape shape, Player player)
        {
            try
            {
                if (!Main.Players.ContainsKey(player)) return;
                if (Main.Players[player].WorkID != 10 || !player.GetData<bool>("ON_WORK") || shape.GetData<int>("NUMBER") != player.GetData<int>("WORKCHECK")) return;

                if (Checkpoints[(int)shape.GetData<int>("NUMBER")].Position.DistanceTo(player.Position) > 3) return;

                var payment = Convert.ToInt32(checkpointPayment * Group.GroupPayAdd[Main.Accounts[player].VipLvl] * Main.oldconfig.PaydayMultiplier);
                MoneySystem.Wallet.Change(player, payment);
                GameLog.Money($"server", $"player({Main.Players[player].UUID})", payment, $"GardenerCheck");

                NAPI.Entity.SetEntityPosition(player, Checkpoints[shape.GetData<int>("NUMBER")].Position + new Vector3(0, 0, 1.2));
                NAPI.Entity.SetEntityRotation(player, new Vector3(0, 0, Checkpoints[shape.GetData<int>("NUMBER")].Heading));
                Main.OnAntiAnim(player);
                BasicSync.AttachObjectToPlayer(player, NAPI.Util.GetHashKey("prop_cs_trowel"), 57005, new Vector3(0.15, 0.02, 0), new Vector3(0, -90, 0));
                player.PlayAnimation("amb@world_human_gardener_plant@female@idle_a", "idle_a_female", 39);
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