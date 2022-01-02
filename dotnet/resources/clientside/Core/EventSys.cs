using GTANetworkAPI;
using UNL.SDK;
using System;
using System.Collections.Generic;

namespace ULife.Core
{
    class EventSys : Script
    {
        private class CustomEvent
        {
            public string Name { get; set; }
            public Player Admin { get; set; }
            public Vector3 Position { get; set; }
            public uint Dimension { get; set; }
            public ushort MembersLimit { get; set; }
            public Player Winner { get; set; }
            public uint Reward { get; set; }
            public ColShape Zone { get; set; } = null;
            public byte EventState { get; set; } = 0; // 0 - МП не создано, 1 - Создано, но не началось, 2 - Создано и началось.
            public DateTime Started { get; set; }
            public uint RewardLimit { get; set; } = 0;
            public List<Player> EventMembers = new List<Player>();
            public List<Vehicle> EventVehicles = new List<Vehicle>();
        }
        private static CustomEvent AdminEvent = new CustomEvent(); // Одновременно можно будет создать только одно мероприятие.
        private static nLog Log = new nLog("EventSys");
        private static Config config = new Config("EventSys");

        public static void Init()
        {
            AdminEvent.RewardLimit = config.TryGet<uint>("RewardLimit", 20000);
        }

        private void DeletePlayerFromEvent(Player player)
        {
            AdminEvent.EventMembers.Remove(player);
        }

        [ServerEvent(Event.PlayerDisconnected)]
        public void OnPlayerDisconnected(Player player, DisconnectionType type, string reason)
        {
            if (AdminEvent.EventState != 0)
            {
                if (AdminEvent.EventMembers.Contains(player))
                {
                    DeletePlayerFromEvent(player);
                    if (AdminEvent.EventState == 2)
                    {
                        if (AdminEvent.EventMembers.Count == 0) CloseAdminEvent(AdminEvent.Admin, 0);
                    }
                }
            }
        }

        [ServerEvent(Event.PlayerDeath)]
        public void OnPlayerDeath(Player player, Player killer, uint reason)
        {
            if (AdminEvent.EventState != 0)
            {
                if (AdminEvent.EventMembers.Contains(player))
                {
                    DeletePlayerFromEvent(player);
                    if (AdminEvent.EventState == 2)
                    {
                        if (AdminEvent.EventMembers.Count == 0) CloseAdminEvent(AdminEvent.Admin, 0);
                    }
                }
            }
        }

        [ServerEvent(Event.PlayerExitColshape)]
        public void OnPlayerExitColshape(ColShape colshape, Player player)
        {
            if (AdminEvent.EventState == 2)
            { // Проверяет только после начала мп, когда телепорт закрыт
                if (AdminEvent.Zone != null)
                {
                    if (AdminEvent.EventMembers.Contains(player))
                    {
                        if (colshape == AdminEvent.Zone)
                        {
                            player.Health = 0;
                            player.Armor = 0;
                            player.SendChatMessage("Sie haben das Gelände der Veranstaltung verlassen.");
                        }
                    }
                }
            }
        }

        [Command("createmp", "Verwenden Sie: /createmp [Teilnehmergrenze] [Radius der Zone] [Name der Veranstaltung]", GreedyArg = true)]
        public void CreateEvent(Player player, ushort members, float radius, string eventname)
        {
            if (Main.Players.ContainsKey(player))
            {
                if (!Group.CanUseCmd(player, "createmp")) return;
                if (AdminEvent.EventState == 0)
                {
                    if (eventname.Length < 50)
                    {
                        if (radius >= 10) AdminEvent.Zone = NAPI.ColShape.CreateSphereColShape(player.Position, radius, player.Dimension);
                        AdminEvent.EventState = 1;
                        AdminEvent.EventMembers = new List<Player>();
                        AdminEvent.EventVehicles = new List<Vehicle>();
                        if (members >= NAPI.Server.GetMaxPlayers()) members = 0;
                        AdminEvent.Started = DateTime.Now;
                        AdminEvent.MembersLimit = members;
                        AdminEvent.Name = eventname;
                        AdminEvent.Winner = null;
                        AdminEvent.Position = player.Position;
                        AdminEvent.Dimension = player.Dimension;
                        AdminEvent.Admin = player;
                        AddAdminEventLog();
                        NAPI.Chat.SendChatMessageToAll("!{#A87C33}Liebe Spieler, die Veranstaltung beginnt gleich '" + eventname + "'!");
                        if (members != 0) NAPI.Chat.SendChatMessageToAll("!{#A87C33}Die Teilnehmerzahl für diese Veranstaltung ist begrenzt: " + members + ".");
                        else NAPI.Chat.SendChatMessageToAll("!{#A87C33}Für diese Veranstaltung gibt es kein Teilnehmerlimit.");
                        if (AdminEvent.Zone != null) NAPI.Chat.SendChatMessageToAll("!{#A87C33}Die Veranstaltung ist gültig im Bereich " + radius + "m vom Teleportpunkt entfernt.");
                        NAPI.Chat.SendChatMessageToAll("!{#A87C33}Um sich zu einem Event zu teleportieren, geben Sie den Befehl /mp");
                    }
                    else player.SendChatMessage("Der Name der Veranstaltung ist zu lang, lassen Sie sich einen kürzeren Namen einfallen.");
                }
                else player.SendChatMessage("Ein Ereignis wurde bereits erstellt, Sie können kein neues Ereignis erstellen, solange das alte aktiv ist.");
            }
        }

        [Command("startmp")]
        public void StartEvent(Player player)
        {
            if (Main.Players.ContainsKey(player))
            {
                if (!Group.CanUseCmd(player, "startmp")) return;
                if (AdminEvent.EventState == 1)
                {
                    if (AdminEvent.EventMembers.Count >= 1)
                    {
                        AdminEvent.EventState = 2;
                        NAPI.Chat.SendChatMessageToAll("!{#A87C33}Veranstaltung '" + AdminEvent.Name + "' Jetzt geht's los, der Teleporter ist geschlossen!");
                        NAPI.Chat.SendChatMessageToAll("!{#A87C33}Spieler bei der Veranstaltung: " + AdminEvent.EventMembers.Count + ".");
                    }
                    else player.SendChatMessage("Sie können keine Veranstaltung ohne Teilnehmer durchführen.");
                }
                else player.SendChatMessage("Das Ereignis ist entweder nicht erstellt oder läuft bereits.");
            }
        }

        [Command("stopmp", "Verwenden Sie: /stopmp [ID Spieler] [Auszeichnung]")]
        public void MPReward(Player player, int pid, uint reward)
        {
            if (Main.Players.ContainsKey(player))
            {
                if (!Group.CanUseCmd(player, "stopmp")) return;
                if (AdminEvent.EventState == 2)
                {
                    if (reward <= AdminEvent.RewardLimit)
                    {
                        if (AdminEvent.Winner == null)
                        {
                            Player target = Main.GetPlayerByID(pid);
                            if (target != null)
                            {
                                if (AdminEvent.EventMembers.Contains(target) || AdminEvent.Admin == target) CloseAdminEvent(target, reward);
                                else player.SendChatMessage("Der betreffende Spieler wurde gefunden, er ist aber kein Teilnehmer der Veranstaltung.");
                            }
                            else player.SendChatMessage("Es wurde kein Spieler mit dieser ID gefunden.");
                        }
                        else player.SendChatMessage("Der Gewinner ist bereits nominiert.");
                    }
                    else player.SendChatMessage("Die Belohnung kann den angegebenen Grenzwert nicht überschreiten: " + AdminEvent.RewardLimit + ".");
                }
                else player.SendChatMessage("Das Ereignis ist entweder nicht erstellt oder noch nicht gestartet worden.");
            }
        }

        [Command("mpveh", "Verwenden Sie: /mpveh [Modell Name] [Farbe] [Farbe] [Anzahl der Autos]")]
        public void CreateMPVehs(Player player, string model, byte c1, byte c2, byte count)
        {
            if (Main.Players.ContainsKey(player))
            {
                if (!Group.CanUseCmd(player, "mpveh")) return;
                if (AdminEvent.EventState >= 1)
                {
                    if (count >= 1 && count <= 10)
                    {
                        VehicleHash vehHash = (VehicleHash)NAPI.Util.GetHashKey(model);
                        if (vehHash != 0)
                        {
                            for (byte i = 0; i != count; i++)
                            {
                                Vehicle vehicle = NAPI.Vehicle.CreateVehicle(vehHash, new Vector3((player.Position.X + (4 * i)), player.Position.Y, player.Position.Z), player.Rotation.Z, c1, c2, "EVENTCAR");
                                vehicle.Dimension = player.Dimension;
                                VehicleStreaming.SetEngineState(vehicle, true);
                                AdminEvent.EventVehicles.Add(vehicle);
                            }
                            AdminEvent.Admin = player;
                        }
                        else player.SendChatMessage("Es befindet sich kein Fahrzeug mit diesem Namen in der Datenbank.");
                    }
                    else player.SendChatMessage("Es können 1 bis 10 Autos gleichzeitig erstellt werden.");
                }
                else player.SendChatMessage("Sie können einen Transport erst anlegen, nachdem er erstellt wurde und bevor das Ereignis.");
            }
        }

        [Command("mpreward", "Verwenden Sie: /mpreward [Neue Grenze]")]
        public void SetMPReward(Player player, uint newreward)
        {
            if (Main.Players.ContainsKey(player))
            {
                if (Main.Players[player].AdminLVL >= 6)
                {
                    if (newreward <= 999999)
                    {
                        AdminEvent.RewardLimit = newreward;
                        try
                        {
                            MySQL.Query($"UPDATE `eventcfg` SET `RewardLimit`={newreward}");
                            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, "Sie setzen einen Grenzwert für " + newreward, 3000);
                        }
                        catch (Exception e)
                        {
                            Log.Write("EXCEPTION AT \"SetMPReward\":\n" + e.ToString(), nLog.Type.Error);
                        }
                    }
                    else player.SendChatMessage("Fehler. Maximal mögliche Grenze: 999999");
                }
            }
        }

        [Command("mp")]
        public void TpToMp(Player player)
        {
            if (Main.Players.ContainsKey(player))
            {
                if (Main.Players[player].DemorganTime == 0 && Main.Players[player].ArrestTime == 0 && player.HasData("CUFFED") && player.GetData<bool>("CUFFED") == false && player.HasSharedData("InDeath") && player.GetSharedData<bool>("InDeath") == false)
                {
                    if (AdminEvent.EventState == 1)
                    {
                        if (!AdminEvent.EventMembers.Contains(player))
                        {
                            if (AdminEvent.MembersLimit == 0 || AdminEvent.EventMembers.Count < AdminEvent.MembersLimit)
                            {
                                AdminEvent.EventMembers.Add(player);
                                player.Position = AdminEvent.Position;
                                player.Dimension = AdminEvent.Dimension;
                                player.SendChatMessage("Sie wurden zu dem Ereignis teleportiert '" + AdminEvent.Name + "'.");
                            }
                            else player.SendChatMessage("Leider ist die Liste der Teilnehmer voll.");
                        }
                        else player.SendChatMessage("Sie sind bereits als Teilnehmer gelistet.");
                    }
                    else player.SendChatMessage("Der Teleport ist geschlossen.");
                }
                else player.SendChatMessage("Der Teleport ist für Sie nicht verfügbar.");
            }
        }

        [Command("mpkick", "Verwenden Sie: /mpkick [ID Spieler]")]
        public void MPKick(Player player, int pid)
        {
            if (Main.Players.ContainsKey(player))
            {
                if (!Group.CanUseCmd(player, "mpkick")) return;
                if (AdminEvent.EventState == 1)
                {
                    Player target = Main.GetPlayerByID(pid);
                    if (target != null)
                    {
                        if (AdminEvent.EventMembers.Contains(target))
                        {
                            AdminEvent.Admin = player;
                            target.Health = 0;
                            target.Armor = 0;
                            player.SendChatMessage("Sie haben rausgeschmissen " + target.Name + " seit der Veranstaltung.");
                        }
                        else player.SendChatMessage("Es wurde ein Spieler mit dieser ID gefunden, aber er ist kein Mitglied des Events.");
                    }
                    else player.SendChatMessage("Es wurde kein Spieler mit dieser ID gefunden.");
                }
                else player.SendChatMessage("Ein Spieler kann nur nach dem Erstellen des Ereignisses und vor Beginn des Ereignisses rausgeschmissen werden.");
            }
        }

        [Command("mphp", "Verwenden Sie: /mphp [Menge HP]")]
        public void MPHeal(Player player, byte health)
        {
            if (Main.Players.ContainsKey(player))
            {
                if (!Group.CanUseCmd(player, "mphp")) return;
                if (AdminEvent.EventState >= 1)
                {
                    if (health >= 1 && health <= 100)
                    {
                        AdminEvent.Admin = player;
                        foreach (Player target in AdminEvent.EventMembers)
                        {
                            NAPI.Player.SetPlayerHealth(target, health);
                        }
                        player.SendChatMessage("Sie haben alle Mitglieder der IG erfolgreich installiert " + health + " HP.");
                    }
                    else player.SendChatMessage("Die Anzahl der einstellbaren HP liegt im Bereich von 1 bis 100.");
                }
                else player.SendChatMessage("Sie können nur HP an Spieler ausgeben, bevor das Ereignis beginnt.");
            }
        }

        [Command("mpar", "Verwenden Sie: /mpar [Menge Armor]")]
        public void MPArmor(Player player, byte armor)
        {
            if (Main.Players.ContainsKey(player))
            {
                if (!Group.CanUseCmd(player, "mpar")) return;
                if (AdminEvent.EventState >= 1)
                {
                    if (armor >= 0 && armor <= 100)
                    {
                        AdminEvent.Admin = player;
                        foreach (Player target in AdminEvent.EventMembers)
                        {
                            NAPI.Player.SetPlayerArmor(target, armor);
                        }
                        player.SendChatMessage("Sie haben alle Mitglieder der IG erfolgreich installiert " + armor + " Menge.");
                    }
                    else player.SendChatMessage("Die Anzahl der einstellbaren Armor liegt im Bereich von 0 bis 100.");
                }
                else player.SendChatMessage("Rüstungen können nur vor dem Event an Spieler ausgegeben werden.");
            }
        }

        [Command("mpplayers")]
        public void MpPlayerList(Player player)
        {
            if (Main.Players.ContainsKey(player))
            {
                if (!Group.CanUseCmd(player, "mpplayers")) return;
                if (AdminEvent.EventState != 0)
                {
                    short memcount = Convert.ToInt16(AdminEvent.EventMembers.Count);
                    if (memcount > 0)
                    {
                        if (memcount <= 15)
                        {
                            foreach (Player target in AdminEvent.EventMembers)
                            {
                                player.SendChatMessage("ID: " + target.Value + " | Name: " + target.Name);
                            }
                            player.SendChatMessage("Spieler bei der Veranstaltung: " + memcount);
                        }
                        else player.SendChatMessage("Spieler bei der Veranstaltung: " + memcount);
                    }
                    else player.SendChatMessage("Es wurden keine Spieler bei der Veranstaltung gefunden.");
                }
                else player.SendChatMessage("Das Ereignis ist noch nicht erstellt worden.");
            }
        }

        private void AddAdminEventLog()
        {
            try
            {
                GameLog.EventLogAdd(AdminEvent.Admin.Name, AdminEvent.Name, AdminEvent.MembersLimit, MySQL.ConvertTime(AdminEvent.Started));
            }
            catch (Exception e)
            {
                Log.Write("EXCEPTION AT \"AddAdminEventLog\":\n" + e.ToString(), nLog.Type.Error);
            }
        }

        private void UpdateLastAdminEventLog()
        {
            try
            {
                GameLog.EventLogUpdate(AdminEvent.Admin.Name, AdminEvent.EventMembers.Count, AdminEvent.Winner.Name, AdminEvent.Reward, MySQL.ConvertTime(DateTime.Now), AdminEvent.RewardLimit, AdminEvent.MembersLimit, AdminEvent.Name);
            }
            catch (Exception e)
            {
                Log.Write("EXCEPTION AT \"UpdateLastAdminEventLog\":\n" + e.ToString(), nLog.Type.Error);
            }
        }

        private void CloseAdminEvent(Player winner, uint reward)
        {
            if (AdminEvent.Zone != null)
            {
                AdminEvent.Zone.Delete();
                AdminEvent.Zone = null;
            }
            if (AdminEvent.EventVehicles.Count != 0)
            {
                foreach (Vehicle vehicle in AdminEvent.EventVehicles)
                {
                    vehicle.Delete();
                }
            }
            AdminEvent.Winner = winner;
            AdminEvent.Reward = reward;
            AdminEvent.EventState = 0;
            UpdateLastAdminEventLog();
            NAPI.Chat.SendChatMessageToAll("!{#A87C33}Veranstaltung '" + AdminEvent.Name + "' es ist vorbei, danke fürs Mitmachen!");
            if (winner != AdminEvent.Admin)
            {
                if (reward != 0)
                {
                    NAPI.Chat.SendChatMessageToAll("!{#A87C33}Gewinner " + winner.Name + " erhielt einen Preis von " + reward + "$.");
                    MoneySystem.Wallet.Change(winner, (int)reward);
                }
                else NAPI.Chat.SendChatMessageToAll("!{#A87C33}Gewinner: " + winner.Name + ".");
            }
        }
    }
}
