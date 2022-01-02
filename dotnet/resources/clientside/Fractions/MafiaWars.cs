using System;
using System.Collections.Generic;
using System.Linq;
using GTANetworkAPI;
using ULife.Core;
using UNL.SDK;
using ULife.GUI;

namespace ULife.Fractions
{
    class MafiaWars : Script
    {
        public static bool warIsGoing = false;
        public static bool warStarting = false;
        private static string warTimer;
        private static string toStartWarTimer;
        private static int attackersFracID = -1;
        private static int timerCount = 0;
        private static int attackersSt = 0;
        private static int defendersSt = 0;
        private static int bizID = -1;
        private static int whereWarIsGoing = -1;
        private static bool smbTryCapture = false;
        private static Dictionary<int, string> pictureNotif = new Dictionary<int, string>
        {
            { 10, "CHAR_MARTIN" }, // la cosa nostra
            { 11, "CHAR_JOSEF" }, // russian
            { 12, "CHAR_HAO" }, // yakuza
            { 13, "CHAR_SIMEON" }, // armenian
        };
        private static Dictionary<int, DateTime> nextCaptDate = new Dictionary<int, DateTime>
        {
            { 10, DateTime.Now },
            { 11, DateTime.Now },
            { 12, DateTime.Now },
            { 13, DateTime.Now },
        };
        private static Dictionary<int, DateTime> protectDate = new Dictionary<int, DateTime>
        {
            { 10, DateTime.Now },
            { 11, DateTime.Now },
            { 12, DateTime.Now },
            { 13, DateTime.Now },
        };
        private static List<Vector3> warPoints = new List<Vector3>()
        {
            /*new Vector3(1714.411, -1646.583, 110.5078),
            new Vector3(1018.687, 2363.665, 49.2389),
            new Vector3(525.6157, -3163.575, 2.183115),
            new Vector3(1666.619, -15.92353, 171.7745),
            new Vector3(-575.5857, 5332.536, 68.23749),*/
        };
        private static Dictionary<int, Blip> warBlips = new Dictionary<int, Blip>();
        private static List<ColShape> warPointColshape = new List<ColShape>();

        private static nLog Log = new nLog("MafiaWars");

        [ServerEvent(Event.ResourceStart)]
        public void onResourceStart()
        {
            try
            {
                int i = 0;
                foreach (var vec in warPoints)
                {
                    warPointColshape.Add(NAPI.ColShape.CreateCylinderColShape(vec, 100, 10, 0));
                    warPointColshape[i].SetData("ID", i);
                    warPointColshape[i].OnEntityEnterColShape += onPlayerEnterBizWar;
                    warPointColshape[i].OnEntityExitColShape += onPlayerExitBizWar;
                    warBlips.Add(i, NAPI.Blip.CreateBlip(119, vec, 0.75f, 48, Main.StringToU16("War for business"), 255, 0, true, 0, 0));
                    i++;
                }
            }
            catch (Exception e) { Log.Write("ResourceStart: " + e.Message, nLog.Type.Error); }
        }

        /* [Command("takebiz")]
         public static void CMD_takeBiz(Player player)
         {
             if (!Manager.canUseCommand(player, "takebiz")) return;
             if (player.GetData("BIZ_ID") == -1)
             {
                 Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Вы не находитесь ни на одном из бизнесов", 3000);
                 return;
             }
             Business biz = BusinessManager.BizList[player.GetData("BIZ_ID")];
             biz.Mafia = Main.Players[player].FractionID;
             biz.UpdateLabel();
         } */

        [Command("bizwar")]
        public static void CMD_startBizwar(Player player)
        {
            if (!Manager.canUseCommand(player, "bizwar")) return;
            if (player.GetData<int>("BIZ_ID") == -1)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie sind nicht im Geschäft", 3000);
                return;
            }
            Business biz = BusinessManager.BizList[player.GetData<int>("BIZ_ID")];
            if (biz.Mafia == Main.Players[player].FractionID)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie können keinen Krieg für Ihr Unternehmen beginnen", 3000);
                return;
            }
            if (biz.Mafia == -1)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Das Unternehmen gehört nicht zur Mafia", 3000);
                return;
            }
            if (DateTime.Now.Hour < 13 || DateTime.Now.Hour > 23)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie können einen Krieg zwischen 13:00 und 23:00 Uhr beginnen.", 3000);
                return;
            }
            if (DateTime.Now < nextCaptDate[Main.Players[player].FractionID])
            {
                DateTime g = new DateTime((nextCaptDate[Main.Players[player].FractionID] - DateTime.Now).Ticks);
                var min = g.Minute;
                var sec = g.Second;
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Die einzige Möglichkeit, einen Krieg zu beginnen, ist {min}:{sec}", 3000);
                return;
            }
            if (DateTime.Now < protectDate[biz.Mafia])
            {
                DateTime g = new DateTime((protectDate[biz.Mafia] - DateTime.Now).Ticks);
                var min = g.Minute;
                var sec = g.Second;
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Die einzige Möglichkeit, einen Krieg mit diesem Mob zu beginnen, ist. {min}:{sec}", 3000);
                return;
            }
            if (Manager.countOfFractionMembers(biz.Mafia) < 4)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Unzureichend online in der gegnerischen Mafia", 3000);
                return;
            }
            if (smbTryCapture) return;
            smbTryCapture = true;
            if (warIsGoing || warStarting)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Es ist bereits ein Revierkampf im Gange", 3000);
                smbTryCapture = false;
                return;
            }
            var ter = Jobs.WorkManager.rnd.Next(0, 5);
            warBlips[ter].Color = 49;
            Manager.sendFractionMessage(biz.Mafia, $"Achtung! Wir haben 20 Minuten Zeit zum Packen! {Manager.getName(Main.Players[player].FractionID)} beschlossen, unser Geschäft zu übernehmen");
            Manager.sendFractionMessage(Main.Players[player].FractionID, "Los gehts! Quetschen! In etwa 20 Minuten wird der Feind eintreffen");

            timerCount = 0;
            bizID = biz.ID;

            attackersFracID = Main.Players[player].FractionID;
            nextCaptDate[attackersFracID] = DateTime.Now.AddMinutes(60); // NEXT BIZWAR
            whereWarIsGoing = ter;

            toStartWarTimer = Timers.StartOnce(1200000, () => timerStart());

            warStarting = true;
            smbTryCapture = false;
        }

        private static void timerStart()
        {
            var attackers = 0;
            var defenders = 0;

            var biz = BusinessManager.BizList[bizID];

            foreach (var p in NAPI.Pools.GetAllPlayers())
            {
                if (!Main.Players.ContainsKey(p) || !p.HasData("WARZONE") || p.GetData<int>("WARZONE") != whereWarIsGoing) continue;
                if (Main.Players[p].FractionID == biz.Mafia) defenders++;
                else if (Main.Players[p].FractionID == attackersFracID) attackers++;
            }
            foreach (var p in NAPI.Pools.GetAllPlayers())
            {
                if (!Main.Players.ContainsKey(p) || !p.HasData("WARZONE") || p.GetData<int>("WARZONE") != whereWarIsGoing) continue;
                if (Main.Players[p].FractionID == biz.Mafia || Main.Players[p].FractionID == attackersFracID)
                {
                    Trigger.ClientEvent(p, "sendCaptureInformation", attackers, defenders, 0, 0);
                    Trigger.ClientEvent(p, "captureHud", true);
                }
            }

            warTimer = Timers.Start(1000, () => timerUpdate());
            warStarting = false;
            warIsGoing = true;

            Manager.sendFractionMessage(biz.Mafia, $"Achtung! Wir werden angegriffen! {Manager.getName(attackersFracID)} beschlossen, unser Unternehmen zu übernehmen");
            Manager.sendFractionMessage(attackersFracID, "Los gehts! Quetschen! Sie haben einen Geschäftskrieg begonnen");
        }

        private static void timerUpdate()
        {
            try
            {
                var attackers = 0;
                var defenders = 0;
                Business biz = BusinessManager.BizList[bizID];
                foreach (var p in NAPI.Pools.GetAllPlayers())
                {
                    if (!Main.Players.ContainsKey(p) || !p.HasData("WARZONE") || p.GetData<int>("WARZONE") != whereWarIsGoing) continue;
                    if (Main.Players[p].FractionID == biz.Mafia) defenders++;
                    else if (Main.Players[p].FractionID == attackersFracID) attackers++;
                }

                attackersSt = attackers;
                defendersSt = defenders;

                if (timerCount >= 300 && (attackers == 0 || defenders == 0))
                {
                    endCapture();
                }

                timerCount++;
                int minutes = timerCount / 60;
                int seconds = timerCount % 60;

                foreach (var p in NAPI.Pools.GetAllPlayers())
                {
                    if (!Main.Players.ContainsKey(p) || !p.HasData("WARZONE") || p.GetData<int>("WARZONE") != whereWarIsGoing) continue;
                    if (Main.Players[p].FractionID == biz.Mafia || Main.Players[p].FractionID == attackersFracID)
                    {
                        Trigger.ClientEvent(p, "sendCaptureInformation", attackers, defenders, minutes, seconds);
                    }
                }
            }
            catch (Exception e) { Log.Write("MafiaWars: " + e.Message, nLog.Type.Error); }
        }

        private static void endCapture()
        {
            try
            {
                Timers.Stop(warTimer);
                Main.ClientEventToAll("captureHud", false);
                var biz = BusinessManager.BizList[bizID];
                protectDate[biz.Mafia] = DateTime.Now.AddMinutes(20);
                protectDate[attackersFracID] = DateTime.Now.AddMinutes(20);
                if (attackersSt <= defendersSt)
                {
                    Manager.sendFractionMessage(biz.Mafia, $"Die Arschlöcher sind entkommen! Wir haben ihnen den Laufpass gegeben! Die haben sich für das Geschäft eingesetzt");
                    Manager.sendFractionMessage(attackersFracID, "Sie sind am Arsch! Unsere Feinde waren stärker! Die konnten das Geschäft nicht übernehmen");

                    foreach (var m in Manager.Members.Keys)
                    {
                        if (Main.Players[m].FractionID == biz.Mafia)
                        {
                            MoneySystem.Wallet.Change(m, 300);
                            GameLog.Money($"server", $"player({Main.Players[m].UUID})", 300, $"winBiz");
                        }
                    }
                }
                else if (attackersSt > defendersSt)
                {
                    Manager.sendFractionMessage(biz.Mafia, $"Wir haben ein Geschäft verpasst...");
                    Manager.sendFractionMessage(attackersFracID, "Wir haben sie weggescheucht wie Kinder! Sie haben das Geschäft übernommen!");
                    biz.Mafia = attackersFracID;
                    foreach (var m in Manager.Members.Keys)
                    {
                        if (Main.Players[m].FractionID == attackersFracID)
                        {
                            MoneySystem.Wallet.Change(m, 300);
                            GameLog.Money($"server", $"player({Main.Players[m].UUID})", 300, $"winBiz");
                        }
                    }
                    biz.UpdateLabel();
                }
                warIsGoing = false;
                warBlips[whereWarIsGoing].Color = 40;
            }
            catch (Exception e) { Log.Write($"EndMafiaWar: " + e.Message, nLog.Type.Error); }
        }

        private static void onPlayerEnterBizWar(ColShape shape, Player player)
        {
            try
            {
                if (!Main.Players.ContainsKey(player)) return;
                if (Main.Players[player].FractionID >= 10 && Main.Players[player].FractionID <= 13)
                {
                    player.SetData("WARZONE", shape.GetData<int>("ID"));
                    if (warIsGoing && (Main.Players[player].FractionID == attackersFracID || Main.Players[player].FractionID == BusinessManager.BizList[bizID].Mafia) && whereWarIsGoing == shape.GetData<int>("ID"))
                    {
                        int minutes = timerCount / 60;
                        int seconds = timerCount % 60;
                        Trigger.ClientEvent(player, "sendCaptureInformation", attackersSt, defendersSt, minutes, seconds);
                        Trigger.ClientEvent(player, "captureHud", true);
                    }
                }
            }
            catch (Exception ex) { Log.Write("onPlayerEnterBizWar: " + ex.Message, nLog.Type.Error); }
        }

        private static void onPlayerExitBizWar(ColShape shape, Player player)
        {
            try
            {
                if (!Main.Players.ContainsKey(player)) return;
                if (Main.Players[player].FractionID >= 10 && Main.Players[player].FractionID <= 13)
                {
                    player.SetData("WARZONE", -1);
                    Trigger.ClientEvent(player, "captureHud", false);
                }
            }
            catch (Exception ex) { Log.Write("onPlayerExitBizWar: " + ex.Message, nLog.Type.Error); }
        }
    }
}
