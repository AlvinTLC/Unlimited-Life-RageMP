using ULife.Core;
using UNL.SDK;
using System;
using System.Data;
using System.Linq;
using GTANetworkAPI;
using ULife.GUI;
using ULife.Core.Character;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading;

namespace ULife.Fractions
{
    class FractionCommands : Script
    {
        private static nLog Log = new nLog("FractionCommangs");

        [ServerEvent(Event.PlayerEnterVehicle)]
        public void onPlayerEnterVehicleHandler(Player player, Vehicle vehicle, sbyte seatid)
        {
            try
            {
                if (!Main.Players.ContainsKey(player)) return;
                if (NAPI.Data.GetEntityData(player, "CUFFED") && player.VehicleSeat == 0)
                {
                    VehicleManager.WarpPlayerOutOfVehicle(player);
                    return;
                }
                if (NAPI.Data.HasEntityData(player, "FOLLOWER"))
                {
                    VehicleManager.WarpPlayerOutOfVehicle(player);
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du lässt den Mann gehen", 3000);
                    return;
                }
            }
            catch (Exception e) { Log.Write("PlayerEnterVehicle: " + e.Message, nLog.Type.Error); }
        }
        private static Dictionary<int, DateTime> NextCarRespawn = new Dictionary<int, DateTime>()
        {
            { 1, DateTime.Now },
            { 2, DateTime.Now },
            { 3, DateTime.Now },
            { 4, DateTime.Now },
            { 5, DateTime.Now },
            { 6, DateTime.Now },
            { 7, DateTime.Now },
            { 8, DateTime.Now },
            { 9, DateTime.Now },
            { 10, DateTime.Now },
            { 11, DateTime.Now },
            { 12, DateTime.Now },
            { 13, DateTime.Now },
            { 14, DateTime.Now },
            { 15, DateTime.Now },
            { 16, DateTime.Now },
            { 17, DateTime.Now },
        };
        public static void respawnFractionCars(Player player)
        {
            if (Main.Players[player].FractionID == 0 || Main.Players[player].FractionLVL < (Configs.FractionRanks[Main.Players[player].FractionID].Count - 1)) return;
            if (DateTime.Now < NextCarRespawn[Main.Players[player].FractionID])
            {
                DateTime g = new DateTime((NextCarRespawn[Main.Players[player].FractionID] - DateTime.Now).Ticks);
                var min = g.Minute;
                var sec = g.Second;
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Das kannst du nur tun über {min}:{sec}", 3000);
                return;
            }

            var all_vehicles = NAPI.Pools.GetAllVehicles();
            foreach (var vehicle in all_vehicles)
            {
                var occupants = VehicleManager.GetVehicleOccupants(vehicle);
                if (occupants.Count > 0)
                {
                    var newOccupants = new List<Player>();
                    foreach (var occupant in occupants)
                        if (Main.Players.ContainsKey(occupant)) newOccupants.Add(occupant);
                    vehicle.SetData("OCCUPANTS", newOccupants);
                }
            }

            foreach (var vehicle in all_vehicles)
            {
                if (VehicleManager.GetVehicleOccupants(vehicle).Count >= 1) continue;
                var color1 = vehicle.PrimaryColor;
                var color2 = vehicle.SecondaryColor;
                if (!vehicle.HasData("ACCESS")) continue;

                if (vehicle.GetData<string>("ACCESS") == "FRACTION" && vehicle.GetData<int>("FRACTION") == Main.Players[player].FractionID)
                    Admin.RespawnFractionCar(vehicle);
            }

            NextCarRespawn[Main.Players[player].FractionID] = DateTime.Now.AddHours(2);
            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast alle Fahrzeuge der Fraktion Repariert", 3000);
        }
        public static void playerPressCuffBut(Player player)
        {
            var fracid = Main.Players[player].FractionID;
            if (!Manager.canUseCommand(player, "cuff")) return;
            if (NAPI.Data.GetEntityData(player, "CUFFED"))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du bist in Handschellen oder gefesselt", 3000);
                return;
            }
            var target = Main.GetNearestPlayer(player, 2);
            if (target == null) return;
            var cuffmesp = ""; // message for Player after cuff
            var cuffmest = ""; // message for Target after cuff
            var uncuffmesp = ""; // message for Player after uncuff
            var uncuffmest = ""; // message for Target after uncuff
            var cuffme = ""; // message /me after cuff
            var uncuffme = ""; // message /me after uncuff

            if (player.IsInVehicle) return;
            if (target.IsInVehicle) return;

            if (Manager.FractionTypes[fracid] == 2) // for gov factions
            {
                if (!NAPI.Data.GetEntityData(player, "ON_DUTY"))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du musst zuerst den Dienst antreten", 3000);
                    return;
                }
                if (target.GetData<bool>("CUFFED_BY_MAFIA"))
                {
                    uncuffmesp = $"Du hast einen Spieler losgebunden {target.Name}";
                    uncuffmest = $"Spieler {player.Name} losgebunden";
                    uncuffme = "entfesselt(а) Spieler {name}";
                }
                else
                {
                    cuffmesp = $"Du hast einen Spieler Handschellen angelegt {target.Name}";
                    cuffmest = $"Spieler {player.Name} Sie in Handschellen gelegt";
                    cuffme = "einen Spieler in Handschellen legen {name}";
                    uncuffmesp = $"Du hast einem Spieler die Hanschellen abgenommen {target.Name}";
                    uncuffmest = $"Spieler {player.Name} nahm Ihnen die Handschellen ab";
                    uncuffme = "einen Spieler losgebunden {name}";
                }
            }
            else // for mafia
            {
                if (target.GetData<bool>("CUFFED_BY_COP"))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast nicht die Schlüssel für die Handschellen", 3000);
                    return;
                }
                var cuffs = nInventory.Find(Main.Players[player].UUID, ItemType.Cuffs);
                var count = (cuffs == null) ? 0 : cuffs.Count;

                if (!target.GetData<bool>("CUFFED") && count == 0)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast keine Handschellen", 3000);
                    return;
                }
                else if (!target.GetData<bool>("CUFFED"))
                    nInventory.Remove(player, ItemType.Cuffs, 1);

                cuffmesp = $"Du hast jemanden gefesselt {target.Name}";
                cuffmest = $"Spieler {player.Name} hat dich gefesselt";
                cuffme = "Hat einen Spieler verlinkt {name}";
                uncuffmesp = $"du hast jemanden losgebunden {target.Name}";
                uncuffmest = $"Spieler {player.Name} развязал Вас";
                uncuffme = "einen Spieler losgebunden {name}";
            }

            if (NAPI.Player.IsPlayerInAnyVehicle(player))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du sitzt im Auto", 3000);
                return;
            }
            if (NAPI.Player.IsPlayerInAnyVehicle(target))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Die Person ist im Auto", 3000);
                return;
            }
            if (NAPI.Data.HasEntityData(target, "FOLLOWING") || NAPI.Data.HasEntityData(target, "FOLLOWER") || Main.Players[target].ArrestTime != 0)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Kann nicht auf diese Person angewendet werden", 3000);
                return;
            }
            if (!target.GetData<bool>("CUFFED"))
            {
                // cuff target
                if (NAPI.Data.HasEntityData(target, "HAND_MONEY")) SafeMain.dropMoneyBag(target);
                if (NAPI.Data.HasEntityData(target, "HEIST_DRILL")) SafeMain.dropDrillBag(target);

                NAPI.Data.SetEntityData(target, "CUFFED", true);
                Voice.Voice.PhoneHCommand(target);

                Main.OnAntiAnim(player);
                NAPI.Player.PlayPlayerAnimation(target, 49, "mp_arresting", "idle");
                BasicSync.AttachObjectToPlayer(target, NAPI.Util.GetHashKey("p_cs_cuffs_02_s"), 6286, new Vector3(-0.02f, 0.063f, 0.0f), new Vector3(75.0f, 0.0f, 76.0f));

                Trigger.ClientEvent(target, "CUFFED", true);
                if (fracid == 6 || fracid == 7 || fracid == 9) target.SetData("CUFFED_BY_COP", true);
                else target.SetData("CUFFED_BY_MAFIA", true);

                GUI.Dashboard.Close(target);
                Trigger.ClientEvent(target, "blockMove", true);
                Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, cuffmesp, 3000);
                Notify.Send(target, NotifyType.Warning, NotifyPosition.MapUp, cuffmest, 3000);
                Commands.RPChat("me", player, cuffme, target);
                return;
            }
            // uncuff target
            unCuffPlayer(target);
            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, uncuffmesp, 3000);
            Notify.Send(target, NotifyType.Warning, NotifyPosition.MapUp, uncuffmest, 3000);
            NAPI.Data.SetEntityData(target, "CUFFED_BY_COP", false);
            NAPI.Data.SetEntityData(target, "CUFFED_BY_MAFIA", false);
            Commands.RPChat("me", player, uncuffme, target);
            return;
        }

        public static void onPlayerDeathHandler(Player player, Player entityKiller, uint weapon)
        {
            try
            {
                if (!Main.Players.ContainsKey(player)) return;
                if (NAPI.Data.GetEntityData(player, "CUFFED"))
                {
                    unCuffPlayer(player);
                }
                if (NAPI.Data.HasEntityData(player, "FOLLOWER"))
                {
                    Player target = NAPI.Data.GetEntityData(player, "FOLLOWER");
                    unFollow(player, target);
                }
                if (NAPI.Data.HasEntityData(player, "FOLLOWING"))
                {
                    Player cop = NAPI.Data.GetEntityData(player, "FOLLOWING");
                    unFollow(cop, player);
                }
                if (player.HasData("HEAD_POCKET"))
                {
                    player.ClearAccessory(1);
                    player.SetClothes(1, 0, 0);

                    Trigger.ClientEvent(player, "setPocketEnabled", false);
                    player.ResetData("HEAD_POCKET");
                }
            }
            catch (Exception e) { Log.Write("PlayerDeath: " + e.Message, nLog.Type.Error); }
        }

        #region every fraction commands

        [Command("delad", GreedyArg = true)]
        public static void CMD_deleteAdvert(Player player, int AdID, string reason)
        {
            try
            {
                if (!Main.Players.ContainsKey(player)) return;
                if (Main.Players[player].FractionID == 15)
                {
                    if (!Manager.canUseCommand(player, "delad")) return;
                    LSNews.AddAnswer(player, AdID, reason, true);
                }
                else if (Group.CanUseCmd(player, "delad")) LSNews.AddAnswer(player, AdID, reason, true);
            }
            catch (Exception e) { Log.Write("delad: " + e.Message, nLog.Type.Error); }
        }

        [Command("openstock")]
        public static void CMD_OpenFractionStock(Player player)
        {
            if (!Manager.canUseCommand(player, "openstock")) return;

            if (!Stocks.fracStocks.ContainsKey(Main.Players[player].FractionID)) return;

            if (Stocks.fracStocks[Main.Players[player].FractionID].IsOpen)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Das Lager ist bereits geöffnet", 3000);
                return;
            }

            Stocks.fracStocks[Main.Players[player].FractionID].IsOpen = true;
            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, "Das Lager ist Geöffnet", 3000);
        }

        [Command("closestock")]
        public static void CMD_CloseFractionStock(Player player)
        {
            if (!Manager.canUseCommand(player, "openstock")) return;

            if (!Stocks.fracStocks.ContainsKey(Main.Players[player].FractionID)) return;

            if (!Stocks.fracStocks[Main.Players[player].FractionID].IsOpen)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Das Lager ist bereits geschlossen", 3000);
                return;
            }

            Stocks.fracStocks[Main.Players[player].FractionID].IsOpen = false;
            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, "Du hast das Lager geschlossen", 3000);
        }

        public static void GetMembers(Player sender)
        {
            if (Manager.canUseCommand(sender, "members"))
            {
                sender.SendChatMessage("Mitglieder online:");
                int fracid = Main.Players[sender].FractionID;
                foreach (var m in Manager.Members)
                    if (m.Value.FractionID == fracid) sender.SendChatMessage($"[{m.Value.inFracName}] {m.Value.Name}");
            }
        }

        public static void GetAllMembers(Player sender)
        {
            if (Manager.canUseCommand(sender, "offmembers"))
            {
                string message = "Alle Mitglieder der Organisation: ";
                NAPI.Chat.SendChatMessageToPlayer(sender, message);
                int fracid = Main.Players[sender].FractionID;
                var result = MySQL.QueryRead($"SELECT * FROM `characters` WHERE `fraction`='{fracid}'");
                foreach (DataRow Row in result.Rows)
                {
                    var fraclvl = Convert.ToInt32(Row["fractionlvl"]);
                    NAPI.Chat.SendChatMessageToPlayer(sender, $"~g~[{Manager.getNickname(fracid, fraclvl)}]: ~w~" + Row["name"].ToString().Replace('_', ' '));
                }
                return;
            }
        }

        public static void SetFracRank(Player sender, Player target, int newrank)
        {
            if (Manager.canUseCommand(sender, "setrank"))
            {
                if (newrank <= 0)
                {
                    Notify.Send(sender, NotifyType.Error, NotifyPosition.MapUp, "Kann nicht auf Rang 0 Gesetzt werden", 3000);
                    return;
                }
                int senderlvl = Main.Players[sender].FractionLVL;
                int playerlvl = Main.Players[target].FractionLVL;
                int senderfrac = Main.Players[sender].FractionID;
                if (!Manager.inFraction(target, senderfrac)) return;

                if (newrank >= senderlvl)
                {
                    Notify.Send(sender, NotifyType.Error, NotifyPosition.MapUp, $"Du kannst nicht in diesen Rang befördert werden", 3000);
                    return;
                }
                if (playerlvl > senderlvl)
                {
                    Notify.Send(sender, NotifyType.Error, NotifyPosition.MapUp, $"Du kannst diese Person nicht befördern", 3000);
                    return;
                };
                Manager.UNLoad(target);

                Main.Players[target].FractionLVL = newrank;
                Manager.Load(target, Main.Players[target].FractionID, Main.Players[target].FractionLVL);
                int index = Fractions.Manager.AllMembers.FindIndex(m => m.Name == target.Name);
                if (index > -1)
                {
                    Manager.AllMembers[index].FractionLVL = newrank;
                    Manager.AllMembers[index].inFracName = Manager.getNickname(senderfrac, newrank);
                }
                Notify.Send(target, NotifyType.Warning, NotifyPosition.MapUp, $"Jetzt sind Sie {Manager.Members[target].inFracName} in Fraktionen", 3000);
                Notify.Send(sender, NotifyType.Warning, NotifyPosition.MapUp, $"Sie haben einen Spieler befördert {target.Name} an {Manager.Members[target].inFracName}", 3000);
                Dashboard.sendStats(target);
                return;
            }
        }

        public static void InviteToFraction(Player sender, Player target)
        {
            if (Manager.canUseCommand(sender, "invite"))
            {
                if (sender.Position.DistanceTo(target.Position) > 3)
                {
                    Notify.Send(sender, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler ist zu weit von Ihnen entfernt", 3000);
                    return;
                }
                if (Manager.isHaveFraction(target))
                {
                    Notify.Send(sender, NotifyType.Error, NotifyPosition.MapUp, $"Ein Spieler ist bereits Mitglied in einer Organisation", 3000);
                    return;
                }
                if (Main.Players[target].LVL < 1)
                {
                    Notify.Send(sender, NotifyType.Error, NotifyPosition.MapUp, $"Mindestens 1 Lvl ist erforderlich, um einen Spieler in die Fraktion einzuladen", 3000);
                    return;
                }
                if (Main.Players[target].Warns > 0)
                {
                    Notify.Send(sender, NotifyType.Error, NotifyPosition.MapUp, $"Es ist unmöglich, diesen Spieler zu akzeptieren", 3000);
                    return;
                }
                if (Manager.FractionTypes[Main.Players[sender].FractionID] == 2 && !Main.Players[target].Licenses[7])
                {
                    Notify.Send(sender, NotifyType.Error, NotifyPosition.MapUp, $"Ein Spieler hat keine medizinische Karte", 3000);
                    return;
                }

                target.SetData("INVITEFRACTION", Main.Players[sender].FractionID);
                target.SetData("SENDERFRAC", sender);
                Trigger.ClientEvent(target, "openDialog", "INVITED", $"{sender.Name} пригласил Вас в {Manager.FractionNames[Main.Players[sender].FractionID]}");

                Notify.Send(sender, NotifyType.Success, NotifyPosition.MapUp, $"Sie haben den Spieler eingeladen {target.Name}", 3000);
                Dashboard.sendStats(target);
            }
        }

        public static void UnInviteFromFraction(Player sender, Player target, bool mayor = false)
        {
            if (!Manager.canUseCommand(sender, "uninvite")) return;
            if (sender == target)
            {
                Notify.Send(sender, NotifyType.Error, NotifyPosition.MapUp, $"Sie können sich nicht selbst entlassen", 3000);
                return;
            }

            int senderlvl = Main.Players[sender].FractionLVL;
            int playerlvl = Main.Players[target].FractionLVL;
            int senderfrac = Main.Players[sender].FractionID;

            if (senderlvl <= playerlvl)
            {
                Notify.Send(sender, NotifyType.Error, NotifyPosition.MapUp, $"Sie können diesen Spieler nicht rausschmeißen", 3000);
                return;
            }

            if (mayor)
            {
                if (Manager.FractionTypes[Main.Players[target].FractionID] != 2)
                {
                    Notify.Send(sender, NotifyType.Error, NotifyPosition.MapUp, $"Sie können diesen Spieler nicht rausschmeißen", 3000);
                    return;
                }
            }
            else
            {
                if (senderfrac != Main.Players[target].FractionID)
                {
                    Notify.Send(sender, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler ist ein Mitglied einer anderen Organisation", 3000);
                    return;
                }
            }

            Manager.UNLoad(target);

            int index = Fractions.Manager.AllMembers.FindIndex(m => m.Name == target.Name);
            if (index > -1) Manager.AllMembers.RemoveAt(index);

            if (Main.Players[target].FractionID == 15) Trigger.ClientEvent(target, "enableadvert", false);

            Main.Players[target].OnDuty = false;
            Main.Players[target].FractionID = 0;
            Main.Players[target].FractionLVL = 0;

            Customization.ApplyCharacter(target);
            if (target.HasData("HAND_MONEY")) target.SetClothes(5, 45, 0);
            else if (target.HasData("HEIST_DRILL")) target.SetClothes(5, 41, 0);
            target.SetData("ON_DUTY", false);
            GUI.MenuManager.Close(sender);

            Notify.Send(target, NotifyType.Warning, NotifyPosition.MapUp, $"Sie wurden aus der Fraktion geworfen {Manager.FractionNames[Main.Players[sender].FractionID]}", 3000);
            Notify.Send(sender, NotifyType.Success, NotifyPosition.MapUp, $"Sie wurden aus der Fraktion geworfen {target.Name}", 3000);
            Dashboard.sendStats(target);
            return;
        }

        #endregion

        #region cops and cityhall commands
        public static void ticketToTarget(Player player, Player target, int sum, string reason)
        {
            if (!Manager.canUseCommand(player, "ticket")) return;
            if (sum > 7000)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Das Bußgeldlimit beträgt 7.000 $.", 3000);
                return;
            }
            if (reason.Length > 100)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Es gibt zu viele Gründe", 3000);
                return;
            }
            if (Main.Players[target].Money < sum && MoneySystem.Bank.Accounts[Main.Players[target].Bank].Balance < sum)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler hat nicht genügend Geldmittel", 3000);
                return;
            }

            target.SetData("TICKETER", player);
            target.SetData("TICKETSUM", sum);
            target.SetData("TICKETREASON", reason);
            Trigger.ClientEvent(target, "openDialog", "TICKET", $"{player.Name} hat Ihnen einen Bußgeldbescheid in Höhe von {sum}$ für {reason}. Bezahlen?");
            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Sie haben ein Ticket ausgestellt für {target.Name} in Höhe von {sum}$ für {reason}", 3000);
        }
        public static void ticketConfirm(Player target, bool confirm)
        {
            Player player = target.GetData<Player>("TICKETER");
            if (player == null || !Main.Players.ContainsKey(player)) return;
            int sum = target.GetData<int>("TICKETSUM");
            string reason = target.GetData<string>("TICKETREASON");

            if (confirm)
            {
                if (!MoneySystem.Wallet.Change(target, -sum) && !MoneySystem.Bank.Change(Main.Players[target].Bank, -sum, false))
                {
                    Notify.Send(target, NotifyType.Error, NotifyPosition.MapUp, $"Unzureichende Mittel", 3000);
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler hat nicht genügend Geldmittel", 3000);
                }

                Stocks.fracStocks[6].Money += Convert.ToInt32(sum * 0.9);
                MoneySystem.Wallet.Change(player, Convert.ToInt32(sum * 0.1));
                Notify.Send(target, NotifyType.Info, NotifyPosition.MapUp, $"Sie haben eine Geldstrafe in Höhe von {sum}$ für {reason}", 3000);
                Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"{target.Name} zahlte eine Geldstrafe in Höhe von {sum}$ für {reason}", 3000);
                /*Commands.RPChat("me", player, " выписал штраф для {name}", target);*/
                Manager.sendFractionMessage(7, $"{player.Name} mit einer Geldstrafe belegt {target.Name} unter {sum}$ ({reason})", true);
                GameLog.Ticket(Main.Players[player].UUID, Main.Players[target].UUID, sum, reason, player.Name, target.Name);
            }
            else
            {
                Notify.Send(target, NotifyType.Error, NotifyPosition.MapUp, $"Sie haben sich geweigert, die Geldstrafe von {sum}$ für {reason}", 3000);
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"{target.Name} weigerte sich, die Geldstrafe von {sum}$ für {reason} zu zahlen", 3000);
            }
        }
        public static void arrestTarget(Player player, Player target)
        {
            if (!Manager.canUseCommand(player, "arrest")) return;
            if (player == target)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie können es nicht auf sich selbst anwenden", 3000);
                return;
            }
            if (!NAPI.Data.GetEntityData(player, "ON_DUTY"))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie müssen den Tag beginnen", 3000);
                return;
            }
            if (player.Position.DistanceTo(target.Position) > 2)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Player ist zu weit weg", 3000);
                return;
            }
            if (!NAPI.Data.GetEntityData(player, "IS_IN_ARREST_AREA"))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie müssen sich in der Nähe der Kamera befinden", 3000);
                return;
            }
            if (Main.Players[target].ArrestTime != 0)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler ist bereits im Gefängnis", 3000);
                return;
            }
            if (Main.Players[target].WantedLVL == null)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler ist nicht erwünscht.", 3000);
                return;
            }
            if (!NAPI.Data.GetEntityData(target, "CUFFED"))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler ist nicht in Handschellen.", 3000);
                return;
            }
            if (NAPI.Data.HasEntityData(target, "FOLLOWING"))
            {
                unFollow(target.GetData<Player>("FOLLOWING"), target);
            }
            unCuffPlayer(target);

            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Sie haben einen Spieler platziert ({target.Value}) unter {Main.Players[target].WantedLVL.Level * 20} Minuten", 3000);
            Notify.Send(target, NotifyType.Warning, NotifyPosition.MapUp, $"Spieler ({player.Value}) setzte Sie auf {Main.Players[target].WantedLVL.Level * 20} Minuten", 3000);
            /*Commands.RPChat("me", player, " поместил {name} в КПЗ", target);*/
            Manager.sendFractionMessage(7, $"{player.Name} in Gewahrsam nehmen {target.Name} ({Main.Players[target].WantedLVL.Reason})", true);
            Manager.sendFractionMessage(9, $"{player.Name} in Gewahrsam nehmen {target.Name} ({Main.Players[target].WantedLVL.Reason})", true);
            Main.Players[target].ArrestTime = Main.Players[target].WantedLVL.Level * 20 * 60;
            GameLog.Arrest(Main.Players[player].UUID, Main.Players[target].UUID, Main.Players[target].WantedLVL.Reason, Main.Players[target].WantedLVL.Level, player.Name, target.Name);
            arrestPlayer(target);
        }

        public static void releasePlayerFromPrison(Player player, Player target)
        {
            if (!Manager.canUseCommand(player, "rfp")) return;
            if (!NAPI.Data.GetEntityData(player, "ON_DUTY"))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie müssen den Tag beginnen", 3000);
                return;
            }
            if (player == target)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie können es nicht auf sich selbst anwenden", 3000);
                return;
            }
            if (player.Position.DistanceTo(target.Position) > 3)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Player ist zu weit weg", 3000);
                return;
            }
            if (!NAPI.Data.GetEntityData(player, "IS_IN_ARREST_AREA"))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie müssen sich in der Nähe der Kamera befinden", 3000);
                return;
            }
            if (Main.Players[target].ArrestTime == 0)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler ist nicht im Knast.", 3000);
                return;
            }
            freePlayer(target);
            Main.Players[target].ArrestTime = 0;
            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Sie haben einen Spieler ({target.Value}) aus dem Gefängnis befreit.", 3000);
            Notify.Send(target, NotifyType.Warning, NotifyPosition.MapUp, $"Spieler ({player.Value}) hat Sie aus dem Gefängnis entlassen", 3000);
            /*Commands.RPChat("me", player, " освободил {name} из КПЗ", target);*/
        }

        public static void arrestTimer(Player player)
        {
            try
            {
                if (!Main.Players.ContainsKey(player)) return;
                if (Main.Players[player].ArrestTime == 0)
                {
                    freePlayer(player);
                    return;
                }
                Main.Players[player].ArrestTime--;
            }
            catch (Exception e)
            {
                Log.Write("ARRESTTIMER: " + e.ToString(), nLog.Type.Error);
            }

        }

        public static void freePlayer(Player player)
        {
            NAPI.Task.Run(() =>
            {
                try
                {
                    if (!player.HasData("ARREST_TIMER")) return;
                    Timers.Stop(NAPI.Data.GetEntityData(player, "ARREST_TIMER")); // still not fixed
                    NAPI.Data.ResetEntityData(player, "ARREST_TIMER");
                    Police.setPlayerWantedLevel(player, null);
                    NAPI.Entity.SetEntityPosition(player, Police.policeCheckpoints[5]);
                    NAPI.Entity.SetEntityDimension(player, 0);
                    Notify.Send(player, NotifyType.Warning, NotifyPosition.MapUp, $"Sie wurden aus dem Gefängnis entlassen", 3000);
                }
                catch { }
            });
        }

        public static void arrestPlayer(Player target)
        {
            NAPI.Entity.SetEntityPosition(target, Police.policeCheckpoints[4]);
            Police.setPlayerWantedLevel(target, null);
            NAPI.Data.SetEntityData(target, "ARREST_TIMER", Timers.Start(1000, () => arrestTimer(target)));
            Weapons.RemoveAll(target, true);
        }

        public static void unCuffPlayer(Player player)
        {
            Trigger.ClientEvent(player, "CUFFED", false);
            NAPI.Data.SetEntityData(player, "CUFFED", false);
            NAPI.Player.StopPlayerAnimation(player);
            BasicSync.DetachObject(player);
            Trigger.ClientEvent(player, "blockMove", false);
            Main.OffAntiAnim(player);
        }

        [RemoteEvent("playerPressFollowBut")]
        public void ClientEvent_playerPressFollow(Player player)
        {
            try
            {
                if (!Main.Players.ContainsKey(player)) return;
                if (!Manager.canUseCommand(player, "follow", false)) return;
                if (player.HasData("FOLLOWER"))
                {
                    Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Sie lassen einen Spieler gehen ({player.GetData<Player>("FOLLOWER").Value})", 3000);
                    Notify.Send(player.GetData<Player>("FOLLOWER"), NotifyType.Warning, NotifyPosition.MapUp, $"Spieler ({player.Value}) Sie gehen lassen.", 3000);
                    unFollow(player, player.GetData<Player>("FOLLOWER"));
                }
                else
                {
                    var target = Main.GetNearestPlayer(player, 2);
                    if (target == null || !Main.Players.ContainsKey(target)) return;
                    targetFollowPlayer(player, target);
                }
            }
            catch (Exception e) { Log.Write($"PlayerPressFollow: {e.ToString()} // {e.TargetSite} // ", nLog.Type.Error); }
        }

        public static void unFollow(Player cop, Player suspect)
        {
            NAPI.Data.ResetEntityData(cop, "FOLLOWER");
            NAPI.Data.ResetEntityData(suspect, "FOLLOWING");
            Trigger.ClientEvent(suspect, "setFollow", false);
        }

        public static void targetFollowPlayer(Player player, Player target)
        {
            if (!Manager.canUseCommand(player, "follow")) return;
            var fracid = Main.Players[player].FractionID;
            if (Manager.FractionTypes[fracid] == 2) // for gov factions
            {
                if (!NAPI.Data.GetEntityData(player, "ON_DUTY"))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie müssen den Tag erst beginnen", 3000);
                    return;
                }
            }
            if (player.IsInVehicle || target.IsInVehicle) return;

            if (player == target)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie können es nicht auf sich selbst anwenden", 3000);
                return;
            }

            if (NAPI.Data.HasEntityData(player, "FOLLOWER"))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie schleppen bereits einen Spieler", 3000);
                return;
            }

            if (player.Position.DistanceTo(target.Position) > 2)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Player ist zu weit weg", 3000);
                return;
            }

            if (!NAPI.Data.GetEntityData(target, "CUFFED"))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler ist nicht in Handschellen.", 3000);
                return;
            }

            if (NAPI.Data.HasEntityData(target, "FOLLOWING"))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler wird bereits geschleppt", 3000);
                return;
            }

            NAPI.Data.SetEntityData(player, "FOLLOWER", target);
            NAPI.Data.SetEntityData(target, "FOLLOWING", player);
            Trigger.ClientEvent(target, "setFollow", true, player);
            /*Commands.RPChat("me", player, "потащил(а) {name} за собой", target);*/
            Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Sie haben einen Spieler hinter sich hergezogen ({target.Value})", 3000);
            Notify.Send(target, NotifyType.Warning, NotifyPosition.MapUp, $"Spieler ({player.Value}) hat Sie mitgeschleppt", 3000);
        }
        public static void targetUnFollowPlayer(Player player)
        {
            if (!Manager.canUseCommand(player, "follow")) return;
            var fracid = Main.Players[player].FractionID;
            if (!NAPI.Data.HasEntityData(player, "FOLLOWER"))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du ziehst niemanden mit", 3000);
                return;
            }
            Player target = NAPI.Data.GetEntityData(player, "FOLLOWER");
            unFollow(player, target);
            Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Sie lassen einen Spieler gehen ({target.Value})", 3000);
            Notify.Send(target, NotifyType.Warning, NotifyPosition.MapUp, $"Spieler ({player.Value}) Sie gehen lassen.", 3000);
        }

        public static void suPlayer(Player player, int pasport, int stars, string reason)
        {
            if (!Manager.canUseCommand(player, "su")) return;
            if (!Main.PlayerNames.ContainsKey(pasport))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Es gibt keinen Reisepass mit dieser Nummer.", 3000);
                return;
            }
            Player target = NAPI.Player.GetPlayerFromName(Main.PlayerNames[pasport]);
            if (target == null)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Passinhaber muss online sein", 3000);
                return;
            }
            if (player != target)
            {
                if (!NAPI.Data.GetEntityData(player, "ON_DUTY"))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie müssen den Tag beginnen", 3000);
                    return;
                }
                if (Main.Players[target].ArrestTime != 0)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler im Gefängnis", 3000);
                    return;
                }

                if (stars > 5)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"So viele Sterne kann man nicht vergeben", 3000);
                    return;
                }

                if (Main.Players[target].WantedLVL == null || Main.Players[target].WantedLVL.Level + stars <= 5)
                {
                    Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Sie haben einen Spieler erklärt " + target.Name.Replace('_', ' ') + " gesucht", 3000);
                    Notify.Send(target, NotifyType.Warning, NotifyPosition.MapUp, $"{player.Name.Replace('_', ' ')} eine Fahndung nach Ihnen herausgeben. ({reason})", 3000);
                    var oldStars = (Main.Players[target].WantedLVL == null) ? 0 : Main.Players[target].WantedLVL.Level;
                    var wantedLevel = new WantedLevel(oldStars + stars, player.Name, DateTime.Now, reason);
                    Police.setPlayerWantedLevel(target, wantedLevel);
                    return;
                }
                else Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"So viele Sterne kann man nicht vergeben", 3000);
            }
            else Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie können sich nicht selbst zur Fahndung ausschreiben", 3000);
        }

        // Садит игрока в машину
        public static void playerInCar(Player player, Player target)
        {
            if (!Manager.canUseCommand(player, "incar")) return;
            if (player == target)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Kann nicht an sich selbst verwendet werden", 3000);
                return;
            }
            var vehicle = VehicleManager.getNearestVehicle(player, 3);
            if (vehicle == null)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Es sind keine Autos in der Nähe.", 3000);
                return;
            }
            if (player.VehicleSeat != 0)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie müssen sich auf dem Fahrersitz befinden", 3000);
                return;
            }
            if (player.Position.DistanceTo(target.Position) > 5)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Player ist zu weit weg", 3000);
                return;
            }
            if (!NAPI.Data.GetEntityData(target, "CUFFED"))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler muss mit Handschellen gefesselt sein", 3000);
                return;
            }
            if (NAPI.Data.HasEntityData(target, "FOLLOWING"))
            {
                var cop = NAPI.Data.GetEntityData(target, "FOLLOWING");
                unFollow(cop, target);
            }

            var emptySlots = new List<int>
            {
                2,
                1,
                0
            };

            var players = NAPI.Pools.GetAllPlayers();
            foreach (var p in players)
            {
                if (p == null || !p.IsInVehicle || p.Vehicle != vehicle) continue;
                if (emptySlots.Contains(p.VehicleSeat)) emptySlots.Remove(p.VehicleSeat);
            }

            if (emptySlots.Count == 0)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Es ist kein Platz mehr im Auto", 3000);
                return;
            }

            NAPI.Player.SetPlayerIntoVehicle(target, vehicle, emptySlots[0]);

            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Sie haben einen Spieler geschubst ({target.Value}) ins Auto", 3000);
            Notify.Send(target, NotifyType.Warning, NotifyPosition.MapUp, $"Spieler ({player.Value}) setzen Sie sich ins Auto", 3000);
            /*Commands.RPChat("me", player, " открыл дверь и усадил {name} в машину", target);*/
        }

        public static void playerOutCar(Player player, Player target)
        {
            if (player != target)
            {
                if (!Manager.canUseCommand(player, "pull")) return;
                Vector3 posPlayer = NAPI.Entity.GetEntityPosition(player);
                Vector3 posTarget = NAPI.Entity.GetEntityPosition(target);
                if (player.Position.DistanceTo(target.Position) < 5)
                {
                    if (NAPI.Player.IsPlayerInAnyVehicle(target))
                    {
                        Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Sie haben den Spieler ({target.Value}) aus dem Auto geworfen", 3000);
                        Notify.Send(target, NotifyType.Warning, NotifyPosition.MapUp, $"Игрок ({player.Value}) Выкинул Вас из машины", 3000);
                        VehicleManager.WarpPlayerOutOfVehicle(target);
                        /*Commands.RPChat("me", player, " открыл дверь и вытащил {name} из машины", target);*/
                    }
                    else Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Player befindet sich nicht im Auto.", 3000);
                }
                else Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler ist zu weit von Ihnen entfernt", 3000);
            }
            else Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie können sich nicht selbst aus dem Auto schmeißen", 3000);
        }

        public static void setWargPoliceMode(Player player)
        {
            if (!Manager.canUseCommand(player, "warg"))
            {
                return;
            }
            if (Main.Players[player].FractionID == 7)
            {
                var message = "";
                Police.is_warg = !Police.is_warg;
                if (Police.is_warg) message = $"{NAPI.Player.GetPlayerName(player)} hat den Ausnahmezustand erklärt!!!";
                else message = $"{NAPI.Player.GetPlayerName(player)} Ich habe den Notfallmodus deaktiviert..";
                Manager.sendFractionMessage(7, message);
            }
            else if (Main.Players[player].FractionID == 9)
            {
                var message = "";
                Fbi.warg_mode = !Fbi.warg_mode;
                if (Fbi.warg_mode) message = $"{NAPI.Player.GetPlayerName(player)} hat den Ausnahmezustand erklärt!!!";
                else message = $"{NAPI.Player.GetPlayerName(player)} Ich habe den Notfallmodus deaktiviert..";
                Manager.sendFractionMessage(9, message);
            }

        }

        public static void takeGunLic(Player player, Player target)
        {
            if (!Manager.canUseCommand(player, "takegunlic")) return;
            if (player.Position.DistanceTo(target.Position) > 2)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Player ist zu weit weg", 3000);
                return;
            }
            if (!Main.Players[target].Licenses[6])
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"У ein Spieler keinen Waffenschein hat", 3000);
                return;
            }
            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Sie haben einem Spieler die Waffenlizenz entzogen ({target.Value})", 3000);
            Notify.Send(target, NotifyType.Success, NotifyPosition.MapUp, $"Spieler ({player.Value}) hat Ihnen den Waffenschein abgenommen", 3000);
            Main.Players[target].Licenses[6] = false;
            Dashboard.sendStats(target);
        }

        public static void giveGunLic(Player player, Player target, int price)
        {
            if (!Manager.canUseCommand(player, "givegunlic")) return;
            if (player == target) return;
            if (player.Position.DistanceTo(target.Position) > 2)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Player ist zu weit weg", 3000);
                return;
            }
            if (price < 5000 || price > 6000)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Preis ist falsch", 3000);
                return;
            }
            if (Main.Players[target].Licenses[6])
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler hat bereits einen Waffenschein", 3000);
                return;
            }
            if (Main.Players[target].Money < price)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler hat nicht genügend Geldmittel", 3000);
                return;
            }
            Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Sie haben angeboten, einen Waffenschein für einen Spieler zu kaufen ({target.Value}) für ${price}", 3000);

            Trigger.ClientEvent(target, "openDialog", "GUN_LIC", $"Spieler ({player.Value}) angeboten, Ihnen einen Waffenschein zu kaufen für ${price}");
            target.SetData("SELLER", player);
            target.SetData("GUN_PRICE", price);
        }

        public static void acceptGunLic(Player player)
        {
            if (!Main.Players.ContainsKey(player)) return;

            Player seller = player.GetData<Player>("SELLER");
            if (!Main.Players.ContainsKey(seller)) return;
            int price = player.GetData<int>("GUN_PRICE");
            if (player.Position.DistanceTo(seller.Position) > 2)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Verkäufer ist zu weit weg", 3000);
                return;
            }

            if (!MoneySystem.Wallet.Change(player, -price))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Unzureichende Mittel", 3000);
                return;
            }

            MoneySystem.Wallet.Change(seller, price / 20);
            Fractions.Stocks.fracStocks[6].Money += Convert.ToInt32(price * 0.95);
            GameLog.Money($"player({Main.Players[player].UUID})", $"frac(6)", price, $"buyGunlic({Main.Players[seller].UUID})");
            GameLog.Money($"frac(6)", $"player({Main.Players[seller].UUID})", price / 20, $"sellGunlic({Main.Players[player].UUID})");

            Main.Players[player].Licenses[6] = true;
            Dashboard.sendStats(player);

            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Sie haben einen Waffenschein von einem Spieler gekauft ({seller.Value}) für {price}$", 3000);
            Notify.Send(seller, NotifyType.Info, NotifyPosition.MapUp, $"Spieler ({player.Value}) einen Waffenschein bei Ihnen gekauft", 3000);
        }

        public static void playerTakeoffMask(Player player, Player target)
        {
            if (player.IsInVehicle || target.IsInVehicle) return;

            if (!target.HasData("IS_MASK") || !target.HasData("IS_MASK"))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler hat keine Maske", 3000);
                return;
            }

            var maskItem = nInventory.Items[Main.Players[target].UUID].FirstOrDefault(i => i.Type == ItemType.Mask && i.IsActive);
            nInventory.Remove(target, maskItem);
            Customization.CustomPlayerData[Main.Players[target].UUID].Clothes.Mask = new ComponentItem(0, 0);
            if (maskItem != null) Items.onDrop(player, maskItem, null);

            Customization.SetMask(target, 0, 0); ;

            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Sie haben einem Spieler die Maske vom Gesicht gerissen ({target.Value})", 3000);
            Notify.Send(target, NotifyType.Warning, NotifyPosition.MapUp, $"Spieler ({player.Value}) Ihre Maske heruntergerissen.", 3000);
            /*Commands.RPChat("me", player, " сорвал маску с {name}", target);*/
        }
        #endregion

        #region crimeCommands
        public static void robberyTarget(Player player, Player target)
        {
            if (!Main.Players.ContainsKey(player) || !Main.Players.ContainsKey(target)) return;

            if (!target.GetData<bool>("CUFFED") && !target.HasData("HANDS_UP"))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler muss gefesselt oder mit erhobenen Händen sein", 3000);
                return;
            }

            if (!player.HasData("IS_MASK") || !player.GetSharedData<bool>("IS_MASK"))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Ein Überfall ist nur möglich, wenn eine Maske getragen wird", 3000);
                return;
            }

            if (Main.Players[target].LVL < 2 || Main.Players[target].Money <= 1000 || (target.HasData("NEXT_ROB") && DateTime.Now < target.GetData<DateTime>("NEXT_ROB")))
            {
                Commands.RPChat("me", player, "Ich habe mich in {Name} gründlich umgesehen, konnte aber nichts finden.", target);
                return;
            }

            var max = (Main.Players[target].Money >= 3000) ? 3000 : Convert.ToInt32(Main.Players[target].Money) - 200;
            var min = (max - 200 < 0) ? max : max - 200;

            var found = Main.rnd.Next(min, max + 1);
            MoneySystem.Wallet.Change(target, -found);
            MoneySystem.Wallet.Change(player, found);
            GameLog.Money($"player({Main.Players[target].UUID})", $"player({Main.Players[player].UUID})", found, $"robbery");
            target.SetData("NEXT_ROB", DateTime.Now.AddMinutes(60));

            Commands.RPChat("me", player, "durch genaues Hinsehen {name}" + $", gefunden ${found}", target);
        }
        public static void playerChangePocket(Player player, Player target)
        {
            if (!Manager.canUseCommand(player, "pocket")) return;
            if (player.IsInVehicle) return;
            if (target.IsInVehicle) return;

            if (target.HasData("HEAD_POCKET"))
            {
                target.ClearAccessory(1);
                target.SetClothes(1, 0, 0);

                Trigger.ClientEvent(target, "setPocketEnabled", false);
                target.ResetData("HEAD_POCKET");

                Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Sie haben einem Spieler die Tasche abgenommen ({target.Value})", 3000);
                Notify.Send(target, NotifyType.Info, NotifyPosition.MapUp, $"Spieler ({player.Value}) hat Ihnen die Tasche abgenommen.", 3000);
                /*Commands.RPChat("me", player, "снял(а) мешок с {name}", target);*/
            }
            else
            {
                if (nInventory.Find(Main.Players[player].UUID, ItemType.Pocket) == null)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie haben keine Taschen", 3000);
                    return;
                }

                target.SetAccessories(1, 24, 2);
                target.SetClothes(1, 56, 1);

                Trigger.ClientEvent(target, "setPocketEnabled", true);
                target.SetData("HEAD_POCKET", true);

                nInventory.Remove(player, ItemType.Pocket, 1);
                Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Sie legen einen Beutel auf einen Spieler ({target.Value})", 3000);
                Notify.Send(target, NotifyType.Info, NotifyPosition.MapUp, $"Spieler ({player.Value}) einen Sack über dich stülpen.", 3000);
                /*Commands.RPChat("me", player, "надел(а) мешок на {name}", target);*/
            }
        }
        #endregion

        #region EMS commands
        public static void giveMedicalLic(Player player, Player target)
        {
            if (!Manager.canUseCommand(player, "givemedlic")) return;

            if (Main.Players[target].Licenses[7])
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler hat bereits eine medizinische Karte.", 3000);
                return;
            }

            Main.Players[target].Licenses[7] = true;
            GUI.Dashboard.sendStats(target);

            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Sie haben dem Spieler {target.Name} eine medizinische Karte gegeben", 3000);
            Notify.Send(target, NotifyType.Success, NotifyPosition.MapUp, $"{player.Name} выдал Вам медицинскую карту", 3000);
        }
        public static void sellMedKitToTarget(Player player, Player target, int price)
        {
            if (Manager.canUseCommand(player, "medkit"))
            {
                if (!player.GetData<bool>("ON_DUTY"))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie müssen den Tag beginnen", 3000);
                    return;
                }
                var item = nInventory.Find(Main.Players[player].UUID, ItemType.HealthKit);
                if (item == null)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie müssen die Erste-Hilfe-Kästen aus dem Lager holen", 3000);
                    return;
                }
                if (price < 500 || price > 1500)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie müssen den Preis zwischen $500 und $1.500 festlegen", 3000);
                    return;
                }
                if (player.Position.DistanceTo(target.Position) > 2)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Player ist zu weit weg", 3000);
                    return;
                }
                if (Main.Players[target].Money < price)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Ein Spieler hat nicht so viel Geld", 3000);
                    return;
                }
                Trigger.ClientEvent(target, "openDialog", "PAY_MEDKIT", $"Sanitäter ({player.Value}) angeboten, Ihnen einen Erste-Hilfe-Kasten zu kaufen für ${price}.");
                target.SetData("SELLER", player);
                target.SetData("PRICE", price);

                Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Sie haben einen Spieler angeboten ({target.Value}) einen  Erste-Hilfe-Kasten für {price}$ zu kaufen", 3000);
            }
        }

        public static void acceptEMScall(Player player, Player target)
        {
            if (Manager.canUseCommand(player, "accept"))
            {
                if (!player.GetData<bool>("ON_DUTY"))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast den Tag nicht begonnen", 3000);
                    return;
                }
                if (!target.HasData("IS_CALL_EMS"))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler hat keinen Krankenwagen gerufen", 3000);
                    return;
                }
                Trigger.ClientEvent(player, "createWaypoint", target.Position.X, target.Position.Y);
                Notify.Send(target, NotifyType.Warning, NotifyPosition.MapUp, $"Sanitäter ({player.Value}) hat Ihren Dispatch angenommen", 3000);
                Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Sie haben den Dispatch eines Spielers angenommen ({target.Value})", 3000);
                target.ResetData("IS_CALL_EMS");
                return;
            }
        }

        public static void healTarget(Player player, Player target, int price)
        {
            if (Manager.canUseCommand(player, "heal"))
            {
                if (player.Position.DistanceTo(target.Position) > 2)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Player ist zu weit weg", 3000);
                    return;
                }
                if (price < 50 || price > 400)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie müssen den Preis zwischen $50 und $400 festlegen", 3000);
                    return;
                }
                if (NAPI.Player.IsPlayerInAnyVehicle(player) && NAPI.Player.IsPlayerInAnyVehicle(target))
                {
                    var pveh = player.Vehicle;
                    var tveh = target.Vehicle;
                    Vehicle veh = NAPI.Entity.GetEntityFromHandle<Vehicle>(pveh);
                    if (veh.GetData<string>("ACCESS") != "FRACTION" || veh.GetData<object>("TYPE") != "EMS" || !veh.HasData("CANMEDKITS"))
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie sitzen nicht in einem EMS-Wagen", 3000);

                        return;
                    }
                    if (pveh != tveh)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler sitzt im anderen Auto", 3000);
                        return;
                    }
                    target.SetData("SELLER", player);
                    target.SetData("PRICE", price);
                    Trigger.ClientEvent(target, "openDialog", "PAY_HEAL", $"Sanitäter ({player.Value}) angebotene Behandlung für ${price}");

                    Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Sie haben einem Spieler eine Behandlung angeboten ({target.Value}) für {price}$", 3000);
                    return;
                }
                else if (player.GetData<bool>("IN_HOSPITAL") && target.GetData<bool>("IN_HOSPITAL"))
                {
                    target.SetData("SELLER", player);
                    target.SetData("PRICE", price);
                    Trigger.ClientEvent(target, "openDialog", "PAY_HEAL", $"Sanitäter ({player.Value}) hat ihnen eine Behandlung für ${price} angeboten");
                    Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Sie haben einem Spieler eine Behandlung angeboten ({target.Value}) für {price}$", 3000);
                    return;
                }
                else
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie müssen sich in einem Krankenhaus oder einer Notaufnahme befinden", 3000); ;
                    return;
                }
            }
        }

        #endregion

    }
}