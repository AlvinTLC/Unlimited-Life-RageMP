using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading;
using GTANetworkAPI;
using MySql.Data.MySqlClient;
using ULife.Core;
using UNL.SDK;
using ULife.GUI;
using ULife.Core.nAccount;
using ULife.Core.Character;

namespace ULife.MoneySystem
{
    class Donations : Script
    {
        public static Queue<KeyValuePair<string, string>> toChange = new Queue<KeyValuePair<string, string>>();
        public static Queue<string> newNames = new Queue<string>();
        private static DateTime lastCheck = DateTime.Now;
        private static nLog Log = new nLog("Donations");
        private static Timer scanTimer;

        private static Config config = new Config("Donations");

        private static string SYNCSTR;
        private static string CHNGSTR;
        private static string NEWNSTR;

        private static string Connection;

        public static void LoadDonations()
        {
            Connection =
                $"Host={config.TryGet<string>("Host", "127.0.0.1")};" +
                $"User={config.TryGet<string>("User", "root")};" +
                $"Password={config.TryGet<string>("Password", "Ka3axctaH")};" +
                $"Database={config.TryGet<string>("Database", "donate")};" +
                $"{config.TryGet<string>("SSL", "SslMode=None;")}";

            SYNCSTR = string.Format("select * from completed where srv={0}", Main.oldconfig.ServerNumber);
            CHNGSTR = "update nicknames SET name='{0}' WHERE name='{1}' and srv={2}";
            NEWNSTR = "insert into nicknames(srv, name) VALUES ({0}, '{1}')";
        }
        #region Работа с таймером
        public static void Start()
        {
            scanTimer = new Timer(new TimerCallback(Tick), null, 90000, 90000);
        }

        public static void Stop()
        {
            scanTimer.Change(Timeout.Infinite, 0);
        }
        #endregion

        #region Проверка никнеймов и донатов
        private static void Tick(object state)
        {
            try
            {
                Log.Debug("Donate time");

                using (MySqlConnection connection = new MySqlConnection(Connection))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand();
                    command.Connection = connection;

                    while (toChange.Count > 0)
                    {
                        KeyValuePair<string, string> kvp = toChange.Dequeue();
                        command.CommandText = string.Format(CHNGSTR, kvp.Value, kvp.Key, Main.oldconfig.ServerNumber);
                        command.ExecuteNonQuery();
                    }

                    while (newNames.Count > 0)
                    {
                        string nickname = newNames.Dequeue();
                        command.CommandText = string.Format(NEWNSTR, Main.oldconfig.ServerNumber, nickname);
                        command.ExecuteNonQuery();
                    }

                    command.CommandText = SYNCSTR;
                    MySqlDataReader reader = command.ExecuteReader();

                    DataTable result = new DataTable();
                    result.Load(reader);
                    reader.Close();

                    foreach (DataRow Row in result.Rows)
                    {
                        int id = Convert.ToInt32(Row["id"]);
                        string name = Convert.ToString(Row["account"]).ToLower();
                        long lcash = Convert.ToInt64(Row["amount"]);

                        try
                        {
                            if (Main.oldconfig.DonateSaleEnable)
                            {
                                lcash = SaleEvent(lcash);
                            }

                            if (!Main.Usernames.Contains(name))
                            {
                                Log.Write($"Can't find registred name for {name}!", nLog.Type.Warn);
                                continue;
                            }

                            var Player = Main.Accounts.FirstOrDefault(a => a.Value.Login == name).Key;
                            if (Player == null || Player.IsNull || !Main.Accounts.ContainsKey(Player))
                            {
                                MySQL.Query($"update `accounts` set `ulife`=`ulife`+{lcash} where `login`='{name}'");
                            }
                            else
                            {
                                lock (Main.Players)
                                {
                                    Main.Accounts[Player].ulife += lcash;
                                }
                                NAPI.Task.Run(() =>
                                {
                                    try
                                    {
                                        if (!Main.Accounts.ContainsKey(Player)) return;
                                        Notify.Send(Player, NotifyType.Success, NotifyPosition.MapUp, $"Du hast {lcash} ULife coins erhalten", 3000);
                                        Trigger.ClientEvent(Player, "starset", Main.Accounts[Player].ulife);
                                    }
                                    catch { }
                                });
                            }
                            //TODO: новый лог денег
                            //GameLog.Money("donate", $"player({Main.PlayerUUIDs[name]})", +stars);
                            GameLog.Money("server", name, lcash, "donateRed");

                            command.CommandText = $"delete from completed where id={id}";
                            command.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        {
                            Log.Write($"Exception At Tick_Donations on {name}:\n" + e.ToString(), nLog.Type.Error);
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Log.Write("Exception At Tick_Donations:\n" + e.ToString(), nLog.Type.Error);
            }
        }
        #endregion

        #region Действия в донат-меню
        internal enum Type
        {
            Character,
            Nickname,
            Convert,
            BronzeVIP,
            SilverVIP,
            GoldVIP,
            PlatinumVIP,
            Warn,
            Slot,
        }

        [RemoteEvent("donate")]
        public void MakeDonate(Player Player, int id, string data)
        {
            try
            {
                Log.Write($"Data: {id} {data}");
                if (!Main.Accounts.ContainsKey(Player)) return;
                Account acc = Main.Accounts[Player];
                Type type = (Type)id;

                switch (type)
                {
                    case Type.Character:
                        {
                            if (acc.ulife < 100)
                            {
                                Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, "Nicht genug ULife coins!", 3000);
                                return;
                            }
                            Main.Accounts[Player].ulife -= 100;
                            GameLog.Money(acc.Login, "server", 100, "donateChar");
                            Customization.SendToCreator(Player);
                            break;
                        }
                    case Type.Nickname:
                        {
                            if (acc.ulife < 25)
                            {
                                Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, "Nicht genug ULife coins!", 3000);
                                return;
                            }

                            if (!Main.PlayerNames.ContainsValue(Player.Name)) return;
                            try
                            {
                                string[] split = data.Split("_");
                                Log.Debug($"SPLIT: {split[0]} {split[1]}");

                                if (split[0] == "null" || string.IsNullOrEmpty(split[0]))
                                {
                                    Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, "Keinen Vornamen eingegeben!", 3000);
                                    return;
                                }
                                else if (split[1] == "null" || string.IsNullOrEmpty(split[1]))
                                {
                                    Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, "Keinen Nachnamen eingegeben!", 3000);
                                    return;
                                }
                            }
                            catch (Exception e)
                            {
                                Log.Write("ERROR ON CHANGENAME DONATION\n" + e.ToString());
                                return;
                            }

                            if (Main.PlayerNames.ContainsValue(data))
                            {
                                Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, "Der Name existiert schon!", 3000);
                                return;
                            }

                            Player target = NAPI.Player.GetPlayerFromName(Player.Name);

                            if (target == null || target.IsNull) return;
                            else
                            {
                                Character.toChange.Add(Player.Name, data);
                                Main.Accounts[Player].ulife -= 25;
                                NAPI.Player.KickPlayer(target, "Änderung an Ihrem Konto");
                            }
                            GameLog.Money(acc.Login, "server", 25, "donateName");
                            break;
                        }
                    case Type.Convert:
                        {
                            int amount = 0;
                            if (!Int32.TryParse(data, out amount))
                            {
                                Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, "Fehler aufgetreten, versuchen Sie es erneut.", 3000);
                                return;
                            }
                            amount = Math.Abs(amount);
                            if (amount <= 0)
                            {
                                Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, "Geben Sie eine Zahl ein, die gleich oder größer als 1 ist.", 3000);
                                return;
                            }
                            if (Main.Accounts[Player].ulife < amount)
                            {
                                Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, "Nicht genug ULife coins!", 3000);
                                return;
                            }
                            Main.Accounts[Player].ulife -= amount;
                            GameLog.Money(acc.Login, "server", amount, "donateConvert");
                            amount = amount * 100;
                            MoneySystem.Wallet.Change(Player, +amount);
                            GameLog.Money($"donate", $"player({Main.Players[Player].UUID})", amount, $"donate");
                            break;
                        }
                    case Type.BronzeVIP:
                        {
                            if (Main.Accounts[Player].VipLvl >= 1)
                            {
                                Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, "Sie haben bereits den VIP-Status erworben!", 3000);
                                return;
                            }
                            if (acc.ulife < 300)
                            {
                                Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, "Nicht genug ULife coins!", 3000);
                                return;
                            }
                            Main.Accounts[Player].ulife -= 300;
                            GameLog.Money(acc.Login, "server", 300, "donateBVip");
                            Main.Accounts[Player].VipLvl = 1;
                            Main.Accounts[Player].VipDate = DateTime.Now.AddDays(30);
                            Dashboard.sendStats(Player);
                            break;
                        }
                    case Type.SilverVIP:
                        {
                            if (acc.VipLvl >= 1)
                            {
                                Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, "Sie haben bereits den VIP-Status erworben!", 3000);
                                return;
                            }
                            if (acc.ulife < 600)
                            {
                                Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, "Nicht genug ULife coins!", 3000);
                                return;
                            }
                            Main.Accounts[Player].ulife -= 600;
                            GameLog.Money(acc.Login, "server", 600, "donateSVip");
                            Main.Accounts[Player].VipLvl = 2;
                            Main.Accounts[Player].VipDate = DateTime.Now.AddDays(30);
                            Dashboard.sendStats(Player);
                            break;
                        }
                    case Type.GoldVIP:
                        {
                            if (Main.Accounts[Player].VipLvl >= 1)
                            {
                                Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, "Sie haben bereits den VIP-Status erworben!", 3000);
                                return;
                            }
                            if (acc.ulife < 800)
                            {
                                Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, "Nicht genug ULife coins!", 3000);
                                return;
                            }
                            Main.Accounts[Player].ulife -= 800;
                            GameLog.Money(acc.Login, "server", 800, "donateGVip");
                            Main.Accounts[Player].VipLvl = 3;
                            Main.Accounts[Player].VipDate = DateTime.Now.AddDays(30);
                            Dashboard.sendStats(Player);
                            break;
                        }
                    case Type.PlatinumVIP:
                        {
                            if (Main.Accounts[Player].VipLvl >= 1)
                            {
                                Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, "Sie haben bereits den VIP-Status erworben!", 3000);
                                return;
                            }
                            if (acc.ulife < 1000)
                            {
                                Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, "Nicht genug ULife coins!", 3000);
                                return;
                            }
                            Main.Accounts[Player].ulife -= 1000;
                            GameLog.Money(acc.Login, "server", 1000, "donatePVip");
                            Main.Accounts[Player].VipLvl = 4;
                            Main.Accounts[Player].VipDate = DateTime.Now.AddDays(30);
                            Dashboard.sendStats(Player);
                            break;
                        }
                    case Type.Warn:
                        {
                            if (Main.Players[Player].Warns <= 0)
                            {
                                Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, "Sie haben bereits den VIP-Status erworben!", 3000);
                                return;
                            }
                            if (acc.ulife < 250)
                            {
                                Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, "Nicht genug ULife coins!", 3000);
                                return;
                            }
                            Main.Accounts[Player].ulife -= 250;
                            GameLog.Money(acc.Login, "server", 250, "donateWarn");
                            Main.Players[Player].Warns -= 1;
                            Dashboard.sendStats(Player);
                            break;
                        }
                    case Type.Slot:
                        {
                            Log.Debug("Unlock slot");
                            if (acc.ulife < 1000)
                            {
                                Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, "Nicht genug ULife coins!", 3000);
                                return;
                            }
                            Main.Accounts[Player].ulife -= 1000;
                            GameLog.Money(acc.Login, "server", 1000, "donateSlot");

                            if (acc.VipLvl == 0)
                            {
                                Main.Accounts[Player].VipLvl = 3;
                                Main.Accounts[Player].VipDate = DateTime.Now.AddDays(30);
                            }
                            else if (acc.VipLvl <= 3)
                            {
                                Main.Accounts[Player].VipLvl = 3;
                                Main.Accounts[Player].VipDate = Main.Accounts[Player].VipDate.AddDays(30);
                            }
                            else Main.Accounts[Player].VipDate = Main.Accounts[Player].VipDate.AddDays(30);

                            Main.Accounts[Player].Characters[2] = -1;
                            Trigger.ClientEvent(Player, "unlockSlot", Main.Accounts[Player].ulife);
                            MySQL.Query($"update `accounts` set `ulife`={Main.Accounts[Player].ulife} where `login`='{Main.Accounts[Player].Login}'");
                            return;
                        }
                }
                //Log.Write(Main.Players[Player.Handle].Starbucks.ToString(), Logger.Type.Debug);
                MySQL.Query($"update `accounts` set `ulife`={Main.Accounts[Player].ulife} where `login`='{Main.Accounts[Player].Login}'");
                Trigger.ClientEvent(Player, "lcashet", Main.Accounts[Player].ulife);
            }
            catch (Exception e) { Log.Write("donate: " + e.Message, nLog.Type.Error); }
        }
        #endregion

        public static long SaleEvent(long input)
        {
            if (input < 1000) return input;
            if (input < 3000) return input + (input / 100 * 20);
            if (input < 5000) return input + (input / 100 * 25);
            if (input < 10000) return input + (input / 100 * 30);
            if (input < 15000) return input + (input / 100 * 35);
            if (input >= 15000) return input + (input / 100 * 50);
            // else, but never used
            return input;
        }

        public static void Rename(string Old, string New)
        {
            toChange.Enqueue(
                new KeyValuePair<string, string>(Old, New));
        }
    }
}
