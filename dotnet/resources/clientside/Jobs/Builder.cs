using GTANetworkAPI;
using System.Collections.Generic;
using System;
using ULife.GUI;
using ULife.Core;
using UNL.SDK;

namespace ULife.Jobs
{
    class Builder : Script
    {
        private static int checkpointPayment = 12;
        private static nLog Log = new nLog("Builder");

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

                var col = NAPI.ColShape.CreateCylinderColShape(new Vector3(-513.208, -1019.0484, 22.362576), 1, 2, 0);
                col.OnEntityEnterColShape += (shape, player) => {
                    try
                    {
                        player.SetData("INTERACTIONCHECK", 8);
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
                NAPI.TextLabel.CreateTextLabel(Main.StringToU16("~b~Drücke E zum ändern"), new Vector3(-513.208, -1019.0484, 22.362576), 30f, 0.4f, 0, new Color(255, 255, 255), true, 0);
                NAPI.Marker.CreateMarker(1, new Vector3(-513.208, -1019.0484, 22.362576) - new Vector3(0, 0, 0.7), new Vector3(), new Vector3(), 1, new Color(255, 255, 255, 220));

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
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Du arbeitest nicht als Bauarbeiter. Du kannst einen Job bei der Arbeitsagentur bekommen", 3000);
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
                    player.SetAccessories(1, 24, 2);
                    player.SetClothes(3, 61, 0);
                    player.SetClothes(4, 36, 0);
                    player.SetClothes(6, 12, 0);
                    player.SetClothes(8, 59, 1);
                    player.SetClothes(11, 57, 0);
                }
                else
                {
                    player.SetAccessories(1, 24, 2);
                    player.SetClothes(3, 62, 0);
                    player.SetClothes(4, 35, 0);
                    player.SetClothes(6, 26, 0);
                    player.SetClothes(8, 36, 1);
                    player.SetClothes(11, 50, 0);
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
            new Checkpoint(new Vector3(-482.82538, -985.2864, 28.012741), 88.95784),
            new Checkpoint(new Vector3(-494.33273, -984.5859, 28.012478), -170.64359),
            new Checkpoint(new Vector3(-504.0599, -985.2748, 27.857992), 91.83983),
            new Checkpoint(new Vector3(-482.9279, -995.8563, 28.01248), 93.306595),
            new Checkpoint(new Vector3(-482.8256, -1006.50995, 28.012737), 86.67746),
            new Checkpoint(new Vector3(-482.75925, -1016.50385, 28.01299), 87.80045),
            new Checkpoint(new Vector3(-482.8253, -1026.8102, 28.012829), 88.50519),
            new Checkpoint(new Vector3(-490.43787, -1033.0933, 28.011711), 127.37465),
            new Checkpoint(new Vector3(-499.14554, -1036.846, 28.011717), 116.757744),
            new Checkpoint(new Vector3(-473.06613, -1052.4489, 28.011715), -30.635637),
            new Checkpoint(new Vector3(-471.22592, -1050.2045, 28.011742), 148.9064),
            new Checkpoint(new Vector3(-452.41498, -1057.241, 28.011715), -25.754032),
            new Checkpoint(new Vector3(-448.12955, -1055.5986, 28.012966), 145.91557),
            new Checkpoint(new Vector3(-456.6386, -1049.1288, 28.012796), 150.47058),
            new Checkpoint(new Vector3(-464.88638, -1042.553, 28.013208), 138.64473),
            new Checkpoint(new Vector3(-472.84622, -1036.5797, 28.012901), 143.77844),
            new Checkpoint(new Vector3(-481.09805, -1030.2284, 28.012808), 139.84793),
            new Checkpoint(new Vector3(-460.6863, -1069.8818, 39.69403), 141.46368),
            new Checkpoint(new Vector3(-493.5995, -1033.6576, 39.69402), -60.02837),
            new Checkpoint(new Vector3(-470.55215, -1050.6212, 39.659748), 154.08595),
        };

        public static List<uint> BuilderObjects = new List<uint>
        {
            NAPI.Util.GetHashKey("prop_weld_torch"),
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
                BasicSync.AttachObjectToPlayer(player, NAPI.Util.GetHashKey("prop_weld_torch"), 18905, new Vector3(0.10, 0, 0.05), new Vector3(0, -90, 0));
                player.PlayAnimation("amb@world_human_welding@male@base", "base", 39);
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
