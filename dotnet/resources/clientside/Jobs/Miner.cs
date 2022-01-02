using GTANetworkAPI;
using System.Collections.Generic;
using System;
using ULife.GUI;
using ULife.Core;
using UNL.SDK;

namespace ULife.Jobs
{
    class Miner : Script
    {
        private static int checkpointPayment = 100; // Цена 1 точки
        private static int checkpointPayment2 = 200; // Цена 2 точки
        private static int checkpointPayment3 = 300; // Цена 3 точки
        private static int JobWorkId = 11; // Номер работы
        private static int JobsMinLVL = 1; // С какого уровня можно устроиться на работу
        private static nLog Log = new nLog("Miner");

        [ServerEvent(Event.ResourceStart)]
        public void Event_ResourceStart()
        {
            try
            {
                NAPI.Blip.CreateBlip(618, new Vector3(2947.133, 2747.014, 42.28965), 1.5f, 22, Main.StringToU16("Steinbruch"), 255, 0, true, 0, 0); // Блип на карте
                NAPI.TextLabel.CreateTextLabel("~w~Приму вас на работу", new Vector3(2946.686, 2746.836, 44.50), 30f, 0.3f, 0, new Color(255, 255, 255), true, NAPI.GlobalDimension); // Над головой у Ped
                //NAPI.Marker.CreateMarker(1, new Vector3(2947.133, 2747.014, 42.28965) - new Vector3(0, 0, 0.7), new Vector3(), new Vector3(), 1, new Color(255, 255, 255, 220)); //Начать рабочий день маркер
                var col = NAPI.ColShape.CreateCylinderColShape(new Vector3(2947.133, 2747.014, 42.28965), 1, 2, 0); // Меню которое открывается на 'E'

                col.OnEntityEnterColShape += (shape, player) => {
                    try
                    {
                        player.SetData("INTERACTIONCHECK", 508);
                        //Trigger.ClientEvent(player, "PressE", true);
                        Trigger.ClientEvent(player, "JobsEinfo");
                    }
                    catch (Exception ex) { Log.Write("col.OnEntityEnterColShape: " + ex.Message, nLog.Type.Error); }
                };
                col.OnEntityExitColShape += (shape, player) => {
                    try
                    {
                        player.SetData("INTERACTIONCHECK", 0);
                        //Trigger.ClientEvent(player, "PressE", false);
                        Trigger.ClientEvent(player, "JobsEinfo2");
                    }
                    catch (Exception ex) { Log.Write("col.OnEntityExitColShape: " + ex.Message, nLog.Type.Error); }
                };

                int i = 0;
                foreach (var Check in Checkpoints)
                {
                    col = NAPI.ColShape.CreateCylinderColShape(Check.Position, 1, 2, 0);
                    col.SetData("NUMBER2", i);
                    col.OnEntityEnterColShape += PlayerEnterCheckpoint;
                    i++;
                };

                int ii = 0;
                foreach (var Check in Checkpoints2)
                {
                    col = NAPI.ColShape.CreateCylinderColShape(Check.Position, 4, 2, 0);
                    col.SetData("NUMBER3", ii);
                    col.OnEntityEnterColShape += PlayerEnterCheckpoint;
                    ii++;
                };
            }
            catch (Exception e) { Log.Write("ResourceStart: " + e.Message, nLog.Type.Error); }
        }
        #region Чекпоинты 
        private static List<Checkpoint> Checkpoints = new List<Checkpoint>()
        {
            new Checkpoint(new Vector3(2985.421, 2789.584, 43.76892), 215.7225), // Взять камень 0
            new Checkpoint(new Vector3(2979.828, 2795.692, 43.00959), 71.75107), // Взять камень 1
            new Checkpoint(new Vector3(2983.816, 2794.697, 42.81905), 357.624), // Взять камень 2
            new Checkpoint(new Vector3(2990.245, 2781.003, 42.4916), 17.26049), // Взять камень 3
            new Checkpoint(new Vector3(2990.063, 2777.616, 42.04763), 111.4968), // Взять камень 4
            new Checkpoint(new Vector3(2993.527, 2774.679, 41.8222), 182.0327), // Взять камень 5
            new Checkpoint(new Vector3(2997.51, 2756.311, 41.88037), 285.6414), // Взять камень 6
            new Checkpoint(new Vector3(2995.744, 2756.501, 41.79721), 154.5374), // Взять камень 7
        };
        private static List<Checkpoint> Checkpoints2 = new List<Checkpoint>()
        {
            new Checkpoint(new Vector3(2962.704, 2822.617, 42.75938), 178.5201), // Выгрузить камень
        };
        #endregion
        #region Меню 'E'
        public static void StartWorkDayMiner(Player player)
        {
            if (Main.Players[player].LVL < JobsMinLVL)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Erforderlich als Minimum {JobsMinLVL} Level", 3000);
                return;
            }

            //Trigger.ClientEvent(player, "PressE", false);
            Trigger.ClientEvent(player, "JobsEinfo2");
            Trigger.ClientEvent(player, "OpenMiner", checkpointPayment, Main.Players[player].LVL, Main.Players[player].WorkID, NAPI.Data.GetEntityData(player, "ON_WORK2"), checkpointPayment2, checkpointPayment3);

        }
        #endregion

        #region Устроиться на работу
        [RemoteEvent("jobJoinMiner")]
        public static void callback_jobsSelecting(Player client, int act)
        {
            try
            {
                switch (act)
                {
                    case -1:
                        Layoff(client);
                        return;
                    default:
                        JobJoin(client);
                        return;
                }
            }
            catch (Exception e) { Log.Write("jobjoin: " + e.Message, nLog.Type.Error); }
        }
        public static void Layoff(Player player)
        {
            if (NAPI.Data.GetEntityData(player, "ON_WORK") == true)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du musst zuerst das Tagespensum erfüllen", 3000);
                return;
            }
            if (Main.Players[player].WorkID != 0)
            {
                Main.Players[player].WorkID = 0;
                //Dashboard.sendStats(player);
                Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Du hast den Job gekündigt", 3000);
                var jobsid = Main.Players[player].WorkID;
                Trigger.ClientEvent(player, "secusejob", jobsid);
                //Trigger.ClientEvent(player, "OpenMiner", checkpointPayment, Main.Players[player].LVL, Main.Players[player].WorkID, NAPI.Data.GetEntityData(player, "ON_WORK2"), checkpointPayment2, checkpointPayment3);
                return;
            }
            else
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du arbeitest für niemanden", 3000);
        }
        public static void JobJoin(Player player)
        {
            if (Main.Players[player].WorkID != 0)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du arbeitest bereits: {Jobs.WorkManager.JobStats[Main.Players[player].WorkID - 1]}", 3000);
                return;
            }
            if (NAPI.Data.GetEntityData(player, "ON_WORK") == true)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du musst zuerst das Tagespensum erfüllen", 3000);
                return;
            }
            Main.Players[player].WorkID = JobWorkId;
            //Dashboard.sendStats(player);
            //Trigger.ClientEvent(player, "OpenMiner", checkpointPayment, Main.Players[player].LVL, Main.Players[player].WorkID, NAPI.Data.GetEntityData(player, "ON_WORK2"), checkpointPayment2, checkpointPayment3);
            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du hast einen Job: {Jobs.WorkManager.JobStats[JobWorkId - 1]}", 3000);
            var jobsid = Main.Players[player].WorkID;
            Trigger.ClientEvent(player, "secusejob", jobsid);
            return;
        }
        #endregion
        #region Начать рабочий день
        [RemoteEvent("enterJobMiner")]
        public static void ClientEvent_Miner(Player client, int act)
        {
            try
            {
                switch (act)
                {
                    case -1:
                        Layoff2(client);
                        return;
                    default:
                        JobJoin2(client, act);
                        return;
                }
            }
            catch (Exception e) { Log.Write("jobjoin: " + e.Message, nLog.Type.Error); }
        }
        public static void Layoff2(Player player)
        {
            if (player.GetData<int>("PACKAGES") == 1)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Gib deinde Steine ab, bevor du den Arbeitstag beendest", 3000);
                return;
            }
            if (NAPI.Data.GetEntityData(player, "ON_WORK") != false)
            {
                Customization.ApplyCharacter(player);
                player.SetData("ON_WORK", false);
                player.SetData("ON_WORK2", 0);
                Trigger.ClientEvent(player, "deleteCheckpoint", 15);
                Trigger.ClientEvent(player, "deleteWorkBlip");
                player.SetData("PACKAGES", 0);

                player.StopAnimation();
                Main.OffAntiAnim(player);
                BasicSync.DetachObject(player);
                MoneySystem.Wallet.Change(player, player.GetData<int>("PAYMENT"));


                Trigger.ClientEvent(player, "CloseJobStatsInfo", player.GetData<int>("PAYMENT"));
                Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"+ {player.GetData<int>("PAYMENT")}$", 3000);
                player.SetData("PAYMENT", 0);
            }
            else
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du arbeitest nicht mehr", 3000);
            }
        }
        public static void JobJoin2(Player player, int job)
        {
            if (Main.Players[player].WorkID != JobWorkId)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du arbeitest nicht in diesem Job.", 3000);
                return;
            }
            if (NAPI.Data.GetEntityData(player, "ON_WORK") == true)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du musst zuerst das Tagespensum erfüllen", 3000);
                return;
            }

            Customization.ClearClothes(player, Main.Players[player].Gender);
            if (Main.Players[player].Gender)
            {
                player.SetClothes(3, 16, 0); //Торс
                player.SetClothes(5, 40, 0); //Сумка
                player.SetClothes(11, 251, 0); //куртка 
                player.SetClothes(4, 97, 5); //Штаны
                player.SetClothes(6, 81, 0); //Ботинки
            }
            else
            {
                player.SetClothes(3, 17, 0); //Торс
                player.SetClothes(5, 40, 0); //Сумка
                player.SetClothes(11, 259, 0); //куртка 
                player.SetClothes(4, 100, 5); //Штаны
                player.SetClothes(6, 77, 0); //Ботинки
            }
            var check = WorkManager.rnd.Next(0, Checkpoints.Count - 1);
            player.SetData("WORKCHECK", check);
            Trigger.ClientEvent(player, "createCheckpoint", 15, 1, Checkpoints[check].Position, 2, 0, 255, 0, 0);
            Trigger.ClientEvent(player, "createWorkBlip", Checkpoints[check].Position);
            player.SetData("PACKAGES", 0);

            player.SetData("ON_WORK", true);
            player.SetData("ON_WORK2", job);
            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du hast deinen Arbeitstag begonnen", 3000);
            Trigger.ClientEvent(player, "JobStatsInfo", player.GetData<int>("PAYMENT"));
        }
        #endregion

        #region Зашел на чекпоинт
        private static void PlayerEnterCheckpoint(ColShape shape, Player player)
        {
            try
            {
                if (!Main.Players.ContainsKey(player)) return;
                if (Main.Players[player].WorkID != JobWorkId || !player.GetData<bool>("ON_WORK")) return;

                if (player.GetData<int>("PACKAGES") == 0)
                {
                    if (shape.GetData<int>("NUMBER2") == player.GetData<int>("WORKCHECK"))
                    {
                        player.SetData("PACKAGES", player.GetData<int>("PACKAGES") + 1);

                        if (shape.GetData<int>("NUMBER2") < 3)
                        { // 0 1 2
                            var payment = Convert.ToInt32(checkpointPayment * Group.GroupPayAdd[Main.Accounts[player].VipLvl] * Main.oldconfig.PaydayMultiplier);
                            player.SetData("PAYMENT", player.GetData<int>("PAYMENT") + payment);
                            //Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Ваша зарплата составляет: {player.GetData("PAYMENT")}$", 1000);
                        }
                        else if (shape.GetData<int>("NUMBER2") > 2 && shape.GetData<int>("NUMBER2") < 6) // 3 4 5
                        {
                            var payment2 = Convert.ToInt32(checkpointPayment2 * Group.GroupPayAdd[Main.Accounts[player].VipLvl] * Main.oldconfig.PaydayMultiplier);
                            player.SetData("PAYMENT", player.GetData<int>("PAYMENT") + payment2);
                            //Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Ваша зарплата составляет: {player.GetData("PAYMENT")}$", 1000);
                        }
                        else if (shape.GetData<int>("NUMBER2") > 5)
                        { // 6 7 8
                            var payment3 = Convert.ToInt32(checkpointPayment3 * Group.GroupPayAdd[Main.Accounts[player].VipLvl] * Main.oldconfig.PaydayMultiplier);
                            player.SetData("PAYMENT", player.GetData<int>("PAYMENT") + payment3);
                            //Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Ваша зарплата составляет: {player.GetData("PAYMENT")}$", 1000);
                        }

                        NAPI.Entity.SetEntityPosition(player, Checkpoints[shape.GetData<int>("NUMBER2")].Position + new Vector3(0, 0, 1.2));
                        NAPI.Entity.SetEntityRotation(player, new Vector3(0, 0, Checkpoints[shape.GetData<int>("NUMBER2")].Heading));

                        Main.OnAntiAnim(player);
                        BasicSync.AttachObjectToPlayer(player, NAPI.Util.GetHashKey("prop_tool_pickaxe"), 18905, new Vector3(0.1, 0, 0), new Vector3(60, 0, -180));
                        player.PlayAnimation("melee@large_wpn@streamed_core", "ground_attack_on_spot", 47);

                        player.SetData("WORKCHECK", -1);
                        NAPI.Task.Run(() => {try{if (player != null && Main.Players.ContainsKey(player)){ BasicSync.DetachObject(player); player.PlayAnimation("anim@mp_snowball", "pickup_snowball", 47);}}catch { }}, 3000);
                        NAPI.Task.Run(() => {
                            try{
                                if (player != null && Main.Players.ContainsKey(player)) {

                                    Main.OnAntiAnim(player);
                                    BasicSync.AttachObjectToPlayer(player, NAPI.Util.GetHashKey("prop_rock_5_smash3"), 18905, new Vector3(0.1, 0.1, 0.2), new Vector3(-10, -75, -40));
                                    player.PlayAnimation("anim@heists@box_carry@", "idle", 49);
                                    

                                    var check = WorkManager.rnd.Next(0, Checkpoints2.Count - 1);
                                    player.SetData("WORKCHECK", check);
                                    Trigger.ClientEvent(player, "createCheckpoint", 15, 1, Checkpoints2[check].Position, 5, 0, 255, 0, 0);
                                    Trigger.ClientEvent(player, "createWorkBlip", Checkpoints2[check].Position);
                                }
                            }
                            catch { }
                        }, 3400);
                    }
                }
                else
                {
                    if (shape.GetData<int>("NUMBER3") == player.GetData<int>("WORKCHECK"))
                    {
                        //NAPI.Entity.SetEntityPosition(player, Checkpoints[shape.GetData("NUMBER")].Position + new Vector3(0, 0, 1.2));
                        //NAPI.Entity.SetEntityRotation(player, new Vector3(0, 0, Checkpoints[shape.GetData("NUMBER")].Heading));



                        player.SetData("PACKAGES", player.GetData<int>("PACKAGES") - 1);



                        Trigger.ClientEvent(player, "JobStatsInfo", player.GetData<int>("PAYMENT"));

                        player.PlayAnimation("anim@mp_snowball", "pickup_snowball", 47);

                        player.SetData("WORKCHECK", -1);
                        NAPI.Task.Run(() =>
                        {
                            try
                            {
                                if (player != null && Main.Players.ContainsKey(player))
                                {
                                    BasicSync.DetachObject(player);
                                    player.StopAnimation();
                                    Main.OffAntiAnim(player);

                                    var check = WorkManager.rnd.Next(0, Checkpoints.Count - 1);
                                    player.SetData("WORKCHECK", check);
                                    Trigger.ClientEvent(player, "createCheckpoint", 15, 1, Checkpoints[check].Position, 2, 0, 255, 0, 0);
                                    Trigger.ClientEvent(player, "createWorkBlip", Checkpoints[check].Position);
                                }
                            }
                            catch { }
                        }, 150);
                    }
                }

            }
            catch (Exception e) { Log.Write("PlayerEnterCheckpoint: " + e.Message, nLog.Type.Error); }
        }
        #endregion
        #region Если выкинуло из игры
        public static void Event_PlayerDisconnected(Player player, DisconnectionType type, string reason)
        {
            try
            {
                if (Main.Players[player].WorkID == JobWorkId && player.GetData<bool>("ON_WORK"))
                {
                    Customization.ApplyCharacter(player);
                    player.SetData("ON_WORK", false);
                    player.SetData("ON_WORK2", 0);
                    Trigger.ClientEvent(player, "deleteCheckpoint", 15);
                    Trigger.ClientEvent(player, "deleteWorkBlip");
                    player.SetData("PACKAGES", 0);

                    player.StopAnimation();
                    Main.OffAntiAnim(player);
                    BasicSync.DetachObject(player);
                    MoneySystem.Wallet.Change(player, player.GetData<int>("PAYMENT"));

                    Trigger.ClientEvent(player, "CloseJobStatsInfo", player.GetData<int>("PAYMENT"));
                    player.SetData("PAYMENT", 0);
                }
            }
            catch (Exception e) { Log.Write("PlayerDisconnected: " + e.Message, nLog.Type.Error); }
        }
        #endregion
        #region Если игрок умер
        public static void Event_PlayerDeath(Player player, Player entityKiller, uint weapon)
        {
            try
            {
                if (!Main.Players.ContainsKey(player)) return;
                if (Main.Players[player].WorkID == JobWorkId && player.GetData<bool>("ON_WORK"))
                {
                    Customization.ApplyCharacter(player);
                    player.SetData("ON_WORK", false);
                    player.SetData("ON_WORK2", 0);
                    Trigger.ClientEvent(player, "deleteCheckpoint", 15);
                    Trigger.ClientEvent(player, "deleteWorkBlip");
                    player.SetData("PACKAGES", 0);

                    player.StopAnimation();
                    Main.OffAntiAnim(player);
                    BasicSync.DetachObject(player);
                    MoneySystem.Wallet.Change(player, player.GetData<int>("PAYMENT"));

                    Trigger.ClientEvent(player, "CloseJobStatsInfo", player.GetData<int>("PAYMENT"));
                    Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"+ {player.GetData<int>("PAYMENT")}$", 3000);
                    player.SetData("PAYMENT", 0);
                }
            }
            catch (Exception e) { Log.Write("PlayerDeath: " + e.Message, nLog.Type.Error); }
        }
        #endregion


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
