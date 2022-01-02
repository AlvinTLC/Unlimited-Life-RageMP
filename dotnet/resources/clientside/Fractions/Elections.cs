﻿using System;
using System.Collections.Generic;
using GTANetworkAPI;
using MySql.Data.MySqlClient;
using ULife.Core;
using UNL.SDK;
using ULife.GUI;
using System.Data;

namespace ULife.Fractions
{
    class ElectionsSystem : Script
    {
        private static nLog Log = new nLog("Elections");
        private static Config config = new Config("Elections");

        private class ElectionPoints
        { // Точки колшэйпа, через которые производятся выборы
            public int ID { get; set; }
            public uint Election { get; set; }
            public Vector3 Position { get; set; }
            public uint Dimension { get; set; }
            public bool Opened { get; set; }
            public TextLabel Info { get; set; }
            public ColShape Point { get; set; } = null;
        }
        private static List<ElectionPoints> ElectionPointsList;

        private class Elections
        {
            public int ID { get; set; }
            public uint Election { get; set; } // Уникальный ID Выборов, у разных кандидатов одних выборов - одинаковый election
            public string Name { get; set; }
            public ushort Votes { get; set; }
        }
        private static List<Elections> ElectionList;

        private class Voter
        {
            public uint Election { get; set; }
            public string Login { get; set; }
            public string VotedFor { get; set; }
        }
        private static List<Voter> Voters;

        private static byte minVoteLVL;

        public static void OnResourceStart()
        {
            minVoteLVL = config.TryGet<byte>("minVoteLVL", 5);
            LoadElections();
        }

        public static void Interaction(ColShape colshape, Player player)
        {
            try
            {
                Console.WriteLine("Election interract");
                if (!Main.Players.ContainsKey(player)) return;
                if (Main.Players[player].LVL < minVoteLVL)
                {
                    player.SendChatMessage($"Dein Level muss mindestens sein {minVoteLVL}LVL!");
                    Notify.Send(player, NotifyType.Alert, NotifyPosition.MapUp, $"Dein Level muss mindestens sein {minVoteLVL}LVL!", 3000);
                    return;
                }
                for (int i = 0; i != ElectionPointsList.Count; i++)
                {
                    if (ElectionPointsList[i].Point == colshape)
                    {
                        if (ElectionPointsList[i].Opened)
                        {
                            if (ElectionList.Count >= 2)
                            {
                                if (!CheckPlayerVoted(Main.Accounts[player].Login, ElectionPointsList[i].Election))
                                {
                                    int second = 1;
                                    for (int l = 0; l != ElectionList.Count; l++)
                                    {
                                        if (ElectionList[l].Election == ElectionPointsList[i].Election)
                                        {
                                            Console.Write("Menu open");
                                            Trigger.ClientEvent(player, "openelem", ElectionList[l].Name); // Первый итем добавляется вместе с созданием самой меню natifveui, иначе рандомно случается краш, не у всех и не всегда
                                            second = l + 1;
                                            break;
                                        }
                                    }
                                    for (int l = second; l != ElectionList.Count; l++)
                                    {
                                        if (ElectionList[l].Election == ElectionPointsList[i].Election) Trigger.ClientEvent(player, "addcandidate", ElectionList[l].Name); // Добавление всех остальных кандидатов к текущей менюшке
                                    }
                                }
                                else player.SendChatMessage("Du Hast bereits mit diesem Konto bei dieser Wahl abgestimmt.");
                            }
                            else player.SendChatMessage("Es wurden keine Kandidaten für diese Wahl gefunden.");
                        }
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Log.Write(e.ToString(), nLog.Type.Error);
            }
        }

        [Command("election_r")] // Перезагрузка с базы
        public void ElectionReload(Player player)
        {
            if (!Main.Players.ContainsKey(player)) return;
            if (Main.Players[player].AdminLVL < 6) return;
            Notify.Send(player, NotifyType.Alert, NotifyPosition.MapUp, "Nachladen der Daten...", 3000);
            for (int l = 0; l != ElectionPointsList.Count; l++)
            {
                if (ElectionPointsList[l].Opened)
                {
                    NAPI.ColShape.DeleteColShape(ElectionPointsList[l].Point);
                    ElectionPointsList[l].Info.Delete();
                }
            }
            LoadElections();
        }

        private static void LoadElections()
        {
            ElectionList = new List<Elections>();
            ElectionPointsList = new List<ElectionPoints>();
            Voters = new List<Voter>();

            try
            {
                DataTable result = MySQL.QueryRead("SELECT * FROM e_candidates");
                if (result != null && result.Rows.Count != 0)
                {
                    foreach (DataRow row in result.Rows)
                    {
                        ElectionList.Add(new Elections
                        {
                            ID = (int)row[0],
                            Election = Convert.ToUInt32(row[1]),
                            Name = (string)row[2],
                            Votes = (ushort)Convert.ToUInt32(row[3])
                        });
                    }
                }

                result = MySQL.QueryRead("SELECT * FROM e_points");
                if (result != null && result.Rows.Count != 0)
                {
                    foreach (DataRow row in result.Rows)
                    {
                        ElectionPoints point = new ElectionPoints
                        {
                            ID = (int)row[0],
                            Election = Convert.ToUInt32(row[1]),
                            Position = new Vector3((float)row[2], (float)row[3], (float)row[4]),
                            Dimension = Convert.ToUInt32(row[5]),
                            Opened = Convert.ToBoolean(row[6])
                        };
                        ElectionPointsList.Add(point);
                        if (point.Opened)
                        {
                            point.Point = NAPI.ColShape.CreateSphereColShape(point.Position, 2f, point.Dimension);
                            point.Info = NAPI.TextLabel.CreateTextLabel("Abstimmpunkt\nAbstimmpunkt №" + point.Election, new Vector3(point.Position.X, point.Position.Y, point.Position.Z + 1), 10f, 1f, 0, new Color(255, 255, 255), dimension: point.Dimension);
                        }
                    }
                }

                result = MySQL.QueryRead("SELECT * FROM e_voters");
                if (result != null && result.Rows.Count != 0)
                {
                    foreach (DataRow row in result.Rows)
                    {
                        Voters.Add(new Voter
                        {
                            Election = Convert.ToUInt32((uint)row[1]),
                            Login = (string)row[2],
                            VotedFor = (string)row[4]
                        });
                    }
                }

                if (ElectionPointsList.Count != 0)
                {
                    for (int p = 0; p != ElectionPointsList.Count; p++)
                    {
                        if (ElectionPointsList[p].Point != null)
                        {
                            ElectionPointsList[p].Point.OnEntityEnterColShape += (colshape, player) =>
                            {
                                try
                                {
                                    Interaction(colshape, player);
                                }
                                catch (Exception e) { Console.WriteLine("shape.OnEntityEnterColshape: " + e.Message); }
                            };
                            ElectionPointsList[p].Point.OnEntityExitColShape += (s, entity) =>
                            {
                                try
                                {

                                }
                                catch (Exception e) { Console.WriteLine("shape.OnEntityEnterColshape: " + e.Message); }
                            };
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log.Write(e.ToString(), nLog.Type.Error);
            }
        }

        [RemoteEvent("choosedelec")]
        private void AddVote(Player player, string Name)
        {
            try
            {
                if (!Main.Players.ContainsKey(player)) return;
                for (int i = 0; i != ElectionPointsList.Count; i++)
                {
                    if (player.Position.DistanceTo(ElectionPointsList[i].Position) <= 2)
                    { // Лучше проверять на дистанцию, чтобы игроки могли голосовать только около точки.
                        if (ElectionPointsList[i].Opened)
                        { // Проверка на то, открыто ли еще голосование, чтобы не добавлять голоса после того, как выборы закончились, а игрок не успел выбрать.
                            for (int l = 0; l != ElectionList.Count; l++)
                            {
                                if (ElectionList[l].Election == ElectionPointsList[i].Election)
                                { // Теперь ищем игроков с номером выборов, которые подходят нам
                                    if (ElectionList[l].Name.Equals(Name))
                                    { // Если имя то, которое мы выбрали, то добавляем ему голос.
                                        ElectionList[l].Votes++;

                                        MySqlCommand cmd = new MySqlCommand();
                                        cmd.CommandText = "UPDATE e_candidates SET Votes=@vot WHERE Name=@nam LIMIT 1";
                                        cmd.Parameters.AddWithValue("@vot", ElectionList[l].Votes);
                                        cmd.Parameters.AddWithValue("@nam", Name);
                                        MySQL.Query(cmd);

                                        cmd = new MySqlCommand();
                                        cmd.CommandText = "INSERT INTO `e_voters` (`Election`, `Login`, `TimeVoted`,`VotedFor`) VALUES (@ele,@log,@voted,@name)";
                                        cmd.Parameters.AddWithValue("@ele", ElectionList[l].Election);
                                        cmd.Parameters.AddWithValue("@log", Main.Accounts[player].Login);
                                        cmd.Parameters.AddWithValue("@voted", DateTime.Now.ToString("s"));
                                        cmd.Parameters.AddWithValue("@name", Name);
                                        MySQL.Query(cmd);

                                        Voters.Add(new Voter
                                        {
                                            Election = ElectionList[l].Election,
                                            Login = Main.Accounts[player].Login,
                                            VotedFor = Name
                                        });

                                        GameLog.Votes(ElectionList[l].Election, Main.Accounts[player].Login, Name);
                                        player.SendChatMessage($"Sie haben Ihre Stimme bei der Wahl abgegeben № {ElectionList[l].Election} zu Gunsten von {Name}");

                                        Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp,
                                            $"Sie haben Ihre Stimme bei der Wahl abgegeben № {ElectionList[l].Election} zu Gunsten von {Name}", 3000);
                                        break;
                                    }
                                }
                            }
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log.Write(e.ToString(), nLog.Type.Error);
            }
        }

        private static bool CheckPlayerVoted(string login, uint election)
        { // Проверка на то, голосовал ли уже в этих выборах
            try
            {
                foreach (Voter v in Voters)
                {
                    if (v.Election == election)
                    {
                        if (v.Login == login) return true;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Log.Write(e.ToString(), nLog.Type.Error);
            }
            return true; // Если таблица voted не доступна по какой-либо причине, то игрок получит 'Вы уже голосовали на этих выборах', дабы не было сбоев.
        }

        [Command("election_addpoint")]
        public void AddPoint_CMD(Player Player, uint ElectionID, bool isOpened = false)
        {
            if (!Main.Players.ContainsKey(Player)) return;
            if (Main.Players[Player].AdminLVL < 8) return;

            if (ElectionList.Find(x => x.Election == ElectionID) != null)
            {
                Player.SendChatMessage("Eine solche Wahl existiert bereits!");
                Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, "Eine solche Wahl existiert bereits!", 3000);
                return;
            }

            Vector3 pos = Player.Position;
            pos.Z -= 1.12F;

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "INSERT INTO `e_points` (`Election`,`X`,`Y`,`Z`,`Dimension`,`Opened`) VALUES (@ele,@x,@y,@z,@dim,@opn)";
            cmd.Parameters.AddWithValue("@ele", ElectionID);
            cmd.Parameters.AddWithValue("@x", pos.X);
            cmd.Parameters.AddWithValue("@y", pos.Y);
            cmd.Parameters.AddWithValue("@z", pos.Z);
            cmd.Parameters.AddWithValue("@dim", Player.Dimension);
            cmd.Parameters.AddWithValue("@opn", isOpened);
            MySQL.Query(cmd);

            ElectionReload(Player);
        }
    }
}
