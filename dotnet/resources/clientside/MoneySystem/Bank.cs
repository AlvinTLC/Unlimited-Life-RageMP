using GTANetworkAPI;
using System;
using System.Collections.Generic;
using ULife.Core;
using UNL.SDK;
using System.Data;
using System.Linq;
using Newtonsoft.Json;
using ULife.GUI;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ULife.MoneySystem
{
    class Bank : Script
    {
        private static nLog Log = new nLog("BankSystem");
        private static Random Rnd = new Random();

        public static Dictionary<int, Data> Accounts = new Dictionary<int, Data>();
        public static ICollection<int> BankAccKeys = Accounts.Keys;

        public enum BankNotifyType
        {
            PaySuccess,
            PayIn,
            PayOut,
            PayError,
            InputError,
        }
        public Bank()
        {
            Log.Write("Loading Bank Accounts...");
            var result = MySQL.QueryRead("SELECT * FROM `money`");
            if (result == null || result.Rows.Count == 0)
            {
                Log.Write("DB return null result.", nLog.Type.Warn);
                return;
            }
            foreach (DataRow Row in result.Rows)
            {
                Data data = new Data();
                data.ID = Convert.ToInt32(Row["id"]);
                data.Type = Convert.ToInt32(Row["type"]);
                data.Holder = Row["holder"].ToString();
                data.Balance = Convert.ToInt64(Row["balance"]);
                Accounts.Add(Convert.ToInt32(Row["id"]), data);
            }
        }

        #region Changing account balance
        public static bool Change(int accountID, long amount, bool notify = true)
        {
            lock (Accounts)
            {
                if (!Accounts.ContainsKey(accountID)) return false;
                if (Accounts[accountID].Balance + amount < 0) return false;
                Accounts[accountID].Balance += amount;
                if (Accounts[accountID].Type == 1 || amount >= 10000) MySQL.Query($"UPDATE `money` SET balance={Accounts[accountID].Balance} WHERE id={accountID}");
                if (Accounts[accountID].Type == 1 && NAPI.Player.GetPlayerFromName(Accounts[accountID].Holder) != null)
                {
                    NAPI.Task.Run(() =>
                    {
                        try
                        {
                            if (notify)
                            {
                                if (amount > 0)
                                    BankNotify(NAPI.Player.GetPlayerFromName(Accounts[accountID].Holder), BankNotifyType.PayIn, amount.ToString());
                                else
                                    BankNotify(NAPI.Player.GetPlayerFromName(Accounts[accountID].Holder), BankNotifyType.PayOut, amount.ToString());
                            }
                            NAPI.Player.GetPlayerFromName(Accounts[accountID].Holder).TriggerEvent("UpdateBank", Accounts[accountID].Balance);
                        }
                        catch { }
                    });
                }
                return true;
            }
        }
        #endregion Changing account balance
        #region Transfer money from 1-Acc to 2-Acc
        public static bool Transfer(int firstAccID, int lastAccID, long amount)
        {
            if (firstAccID == 0 || lastAccID == 0)
            {
                Log.Write($"Account ID error [{firstAccID}->{lastAccID}]", nLog.Type.Error);
                return false;
            }
            Data firstAcc = Accounts[firstAccID];
            if (!Accounts.ContainsKey(lastAccID))
            {
                if (firstAcc.Type == 1)
                    BankNotify(NAPI.Player.GetPlayerFromName(firstAcc.Holder), BankNotifyType.InputError, "Das Konto existiert nicht!");
                Log.Write($"Transfer with error. Account does not exist! [{firstAccID.ToString()}->{lastAccID.ToString()}:{amount.ToString()}]", nLog.Type.Warn);
                return false;
            }
            if (!Change(firstAccID, -amount))
            {
                if (firstAcc.Type == 1)
                    BankNotify(NAPI.Player.GetPlayerFromName(firstAcc.Holder), BankNotifyType.PayError, "Zu wenig Geld!");
                Log.Write($"Transfer with error. Insufficient funds! [{firstAccID.ToString()}->{lastAccID.ToString()}:{amount.ToString()}]", nLog.Type.Warn);
                return false;
            }
            Change(lastAccID, amount);
            GameLog.Money($"bank({firstAccID})", $"bank({lastAccID})", amount, "bankTransfer");
            return true;
        }
        #endregion Transfer money from 1-Acc to 2-Acc
        #region Save Acc
        public static void Save(int AccID)
        {
            if (!Accounts.ContainsKey(AccID)) return;
            Data acc = Accounts[AccID];
            MySQL.Query($"UPDATE `money` SET `balance`={acc.Balance}, `holder`='{acc.Holder}' WHERE id={AccID}");
        }
        #endregion Save Acc

        public static void BankNotify(Player player, BankNotifyType type, string info)
        {
            switch (type)
            {
                case BankNotifyType.InputError:
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Eingabefehler", 3000);
                    return;
                case BankNotifyType.PayError:
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Belastungsfehler", 3000);
                    return;
                case BankNotifyType.PayIn:
                    Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Geldeingang ({info}$)", 3000);
                    return;
                case BankNotifyType.PayOut:
                    Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Lastschrift ({info}$)", 3000);
                    return;
            }
        }

        public static int Create(string holder, int type = 1, long balance = 0)
        {
            int id = GenerateUUID();
            Data data = new Data();
            data.ID = id;
            data.Type = type;
            data.Holder = holder;
            data.Balance = balance;
            Accounts.Add(id, data);
            MySQL.Query($"INSERT INTO `money`(`id`, `type`, `holder`, `balance`) VALUES ({id},{type},'{holder}',{balance})");
            Log.Write("Created new Bank Account! ID:" + id.ToString(), nLog.Type.Success);
            return id;
        }
        public static void Remove(int id, string holder)
        {
            if (!Accounts.ContainsKey(id)) return;
            Accounts.Remove(id);
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "DELETE FROM `money` WHERE holder=@pn";
            cmd.Parameters.AddWithValue("@pn", holder);
            MySQL.Query(cmd);
            Log.Write("Bank account deleted! ID:" + id, nLog.Type.Warn);
        }
        public static void RemoveByID(int id)
        {
            if (!Accounts.ContainsKey(id)) return;
            Accounts.Remove(id);
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "DELETE FROM `money` WHERE id=@pn";
            cmd.Parameters.AddWithValue("@pn", id);
            MySQL.Query(cmd);
            Log.Write("Bank account deleted! ID:" + id, nLog.Type.Warn);
        }
        public static bool isAccExist(int id)
        {
            return Accounts.ContainsKey(id);
        }

        public static Data Get(string holder)
        {
            return Accounts.FirstOrDefault(A => A.Value.Holder == holder).Value;
        }

        public static Data Get(int id)
        {
            return Accounts.FirstOrDefault(A => A.Value.ID == id).Value;
        }

        public static void Update(Player Player)
        {
            NAPI.Task.Run(() =>
            {
                Trigger.ClientEvent(Player, "UpdateBank", Get(Player.Name).Balance);
            });
        }

        private static int GenerateUUID()
        {
            var result = 0;
            while (true)
            {
                result = Rnd.Next(000001, 1000000);
                if (!BankAccKeys.Contains(result)) break;
            }
            return result;
        }

        public static void changeHolder(string oldName, string newName)
        {
            List<int> toChange = new List<int>();
            lock (Accounts)
            {
                foreach (KeyValuePair<int, Data> bank in Accounts)
                {
                    if (bank.Value.Holder != oldName) continue;
                    Log.Debug($"The bank was found! [{bank.Key}]");
                    toChange.Add(bank.Key);
                }
                foreach (int id in toChange)
                {
                    Accounts[id].Holder = newName;
                    Save(id);
                }
            }
        }

        internal class Data
        {
            public int ID { get; set; }
            public int Type { get; set; }
            public string Holder { get; set; }
            public long Balance { get; set; }
        }
    }

    class ATM : Script
    {
        private static nLog Log = new nLog("ATMs");

        public static Dictionary<int, ColShape> ATMCols = new Dictionary<int, ColShape>();

        #region ATMs List
        public static List<Vector3> ATMs = new List<Vector3>
        {
            new Vector3(-2975.39, 380.171, 14.9982),
            new Vector3(-3043.96, 594.665, 7.7368),
            new Vector3(-3240.93, 997.295, 12.5455),
            new Vector3(-2959.19, 487.732, 15.4639),
            new Vector3(-2956.71, 487.666, 15.4639),
            new Vector3(-3144.32, 1127.68, 20.8549),
            new Vector3(-386.735, 6045.95, 31.5016),
            new Vector3(-283.174, 6226.16, 31.4933),
            new Vector3(-133.005, 6366.48, 31.4754),
            new Vector3(-97.3712, 6455.26, 31.4659),
            new Vector3(-95.5665, 6457.03, 31.4603),
            new Vector3(174.211, 6637.88, 31.5731),
            new Vector3(155.872, 6642.79, 31.6029),
            new Vector3(1735.32, 6410.47, 35.0372),
            new Vector3(1701.36, 6426.35, 32.6379),
            new Vector3(1703.06, 4933.44, 42.0637),
            new Vector3(1686.76, 4815.77, 42.0088),
            new Vector3(1968.22, 3743.63, 32.3438),
            new Vector3(1822.53, 3683.07, 34.2767),
            new Vector3(540.419, 2671.09, 42.1565),
            new Vector3(1171.42, 2702.49, 38.1755),
            new Vector3(1172.49, 2702.54, 38.1747),
            new Vector3(2564.63, 2584.97, 38.0831),
            new Vector3(2558.4, 389.48, 108.623),
            new Vector3(2558.84, 350.924, 108.622),
            new Vector3(1077.7, -776.454, 58.2397),
            new Vector3(1153.73, -326.681, 69.2051),
            new Vector3(1166.81, -456.08, 66.8141),
            new Vector3(1138.29, -469.09, 66.7271),
            new Vector3(380.916, 323.439, 103.566),
            new Vector3(236.495, 219.685, 106.287),
            new Vector3(237.095, 218.635, 106.287),
            new Vector3(237.248, 217.737, 106.287),
            new Vector3(237.854, 216.97, 106.287),
            new Vector3(238.24, 216.002, 106.287),
            new Vector3(356.848, 173.496, 103.069),
            new Vector3(-165.064, 234.901, 94.9219),
            new Vector3(-165.158, 232.632, 94.9219),
            new Vector3(-1827.34, 785.072, 138.303),
            new Vector3(-2293.63, 354.695, 174.602),
            new Vector3(-2294.65, 356.563, 174.602),
            new Vector3(-2295.46, 358.312, 174.602),
            new Vector3(-2072.45, -317.302, 13.316),
            new Vector3(-1205.73, -324.884, 37.8581),
            new Vector3(-1204.84, -326.44, 37.834),
            new Vector3(-1305.36, -706.284, 25.3224),
            new Vector3(-1282.52, -210.937, 42.446),
            new Vector3(-1286.18, -213.4, 42.446),
            new Vector3(-1289.2, -226.793, 42.446),
            new Vector3(-1285.65, -224.343, 42.446),
            new Vector3(-1109.75, -1690.76, 4.37501),
            new Vector3(-846.802, -340.142, 38.6802),
            new Vector3(-846.226, -341.402, 38.6802),
            new Vector3(-867.613, -186.135, 37.8429),
            new Vector3(-866.562, -187.747, 37.8333),
            new Vector3(-821.621, -1081.99, 11.1324),
            new Vector3(-57.6823, -92.5967, 57.7789),
            new Vector3(89.5119, 2.39246, 68.315),
            new Vector3(-526.545, -1222.93, 18.455), // 58 в мэрии
            new Vector3(228.185, 338.479, 105.563),
            new Vector3(-537.823, -854.419, 29.2902),
            new Vector3(285.684, 143.406, 104.169),
            new Vector3(527.227, -160.691, 57.0894),
            new Vector3(-717.543, -915.58, 19.2156),
            new Vector3(-303.314, -829.719, 32.4173),
            new Vector3(296.445, -894.158, 29.2307),
            new Vector3(-301.718, -830.081, 32.4173),
            new Vector3(295.763, -896.027, 29.2172),
            new Vector3(-258.764, -723.367, 33.4654),
            new Vector3(147.769, -1035.76, 29.3429),
            new Vector3(146.035, -1035.14, 29.3448),
            new Vector3(-256.161, -716.088, 33.517),
            new Vector3(-254.537, -692.413, 33.6049),
            new Vector3(119.138, -883.713, 31.123),
            new Vector3(114.354, -776.454, 31.4181),
            new Vector3(111.222, -775.377, 31.4383),
            new Vector3(5.1865, -919.813, 29.5591),
            new Vector3(24.4466, -946.04, 29.3576),
            new Vector3(-203.758, -861.348, 30.2676),
            new Vector3(-710.067, -818.993, 23.7292),
            new Vector3(-712.934, -819.018, 23.7295),
            new Vector3(33.2104, -1348.18, 29.497),
            new Vector3(-660.852, -854.069, 24.4846),
            new Vector3(130.109, -1292.7, 29.2695),
            new Vector3(129.66, -1291.97, 29.2695),
            new Vector3(129.215, -1291.15, 29.2695),
            new Vector3(-618.304, -708.927, 30.0528),
            new Vector3(-618.355, -706.806, 30.0528),
            new Vector3(-614.633, -704.746, 31.236),
            new Vector3(-611.721, -704.75, 31.2359),
            new Vector3(-56.637, -1752.26, 29.421),
            new Vector3(-1571.13, -547.326, 34.9578),
            new Vector3(-1570.13, -546.529, 34.9527),
            new Vector3(-1415.98, -211.923, 46.5004),
            new Vector3(-1430.08, -211.09, 46.5004),
            new Vector3(-1410.28, -98.6399, 52.4354),
            new Vector3(-1409.68, -100.472, 52.3845),
            new Vector3(289.017, -1256.86, 29.4408),
            new Vector3(288.75, -1282.28, 29.64),
            new Vector3(2682.9, 3286.39, 55.2411),
            new Vector3(-1091.53, 2708.51, 18.9453),
            new Vector3(-3040.73, 593.046, 7.90893),
            new Vector3(211.81314, -928.1804, 30.692198),
            new Vector3(214.88826, -923.83014, 30.708118),
            new Vector3(218.35837, -918.82874, 30.701254),
            new Vector3(-3240.637, 1008.6544, 12.830708),
            new Vector3(-1314.8502, -836.0371, 16.960155),
            new Vector3(-1315.7577, -834.6624, 16.961735),
            new Vector3(-1570.1855, -546.64124, 34.954796),
            new Vector3(-1205.0233, -326.30176, 37.839916),
            new Vector3(-303.2386, -829.7329, 32.417267),
            new Vector3(112.567276, -819.39685, 31.338223),
            new Vector3(-272.61334, -2025.2332, 30.145584),
            new Vector3(-261.90976, -2012.292, 30.145588),
            new Vector3(238.34637, 215.87302, 106.28677),
            new Vector3(265.82825, 213.86699, 106.2832),
            new Vector3(265.45636, 212.92671, 106.2832),
            new Vector3(265.12314, 211.88556, 106.2832),
            new Vector3(264.74316, 211.00905, 106.2832),
            new Vector3(264.43005, 210.1048, 106.2832),
            new Vector3(158.6875, 234.09824, 106.626015),
            new Vector3(-846.2699, -341.30496, 38.68024),
            new Vector3(-867.6228, -186.11574, 37.84284),
            new Vector3(-1409.7347, -100.40165, 52.38676),
            new Vector3(-2295.4275, 358.2003, 174.60162),
            new Vector3(-1051.1824, -2760.9165, 21.314455),
            new Vector3(-1049.1611, -2762.0378, 21.314455),
            new Vector3(-1046.9993, -2763.2722, 21.314455),
            new Vector3(-1074.0770, -2744.5974, 21.314455),
            new Vector3(-1075.8702, -2747.5835, 21.314455),
        };
        #endregion ATMs List

        [ServerEvent(Event.ResourceStart)]
        public void onResourceStart()
        {
            try
            {
                Log.Write("Loading ATMs...");
                for (int i = 0; i < ATMs.Count; i++)
                {
                    if (i != 58) ; //NAPI.Blip.CreateBlip(500, ATMs[i], 0.65f, 2, "ATM", shortRange: true,dimension: 0);
                    ATMCols.Add(i, NAPI.ColShape.CreateCylinderColShape(ATMs[i], 1, 2, 0));
                    ATMCols[i].SetData("NUMBER", i);
                    ATMCols[i].OnEntityEnterColShape += (s, e) => {
                        try
                        {
                            e.SetData("INTERACTIONCHECK", 13);
                            Jobs.Collector.CollectorEnterATM(e, s);
                        }
                        catch (Exception ex) { Log.Write("ATMCols.OnEntityEnterColShape: " + ex.Message, nLog.Type.Error); }
                    };
                    ATMCols[i].OnEntityExitColShape += (s, e) => {
                        try
                        {
                            e.SetData("INTERACTIONCHECK", 0);
                        }
                        catch (Exception ex) { Log.Write("ATMCols.OnEntityExitrColShape: " + ex.Message, nLog.Type.Error); }
                    };
                }
            }
            catch (Exception e) { Log.Write("ResourceStart: " + e.Message, nLog.Type.Error); }
        }

        public static Vector3 GetNearestATM(Player player)
        {
            Vector3 nearesetATM = ATMs[0];
            foreach (var v in ATMs)
            {
                if (v == new Vector3(237.3785, 217.7914, 106.2868)) continue;
                if (player.Position.DistanceTo(v) < player.Position.DistanceTo(nearesetATM))
                    nearesetATM = v;
            }
            return nearesetATM;
        }

        public static void OpenATM(Player player)
        {
            var acc = Main.Players[player];
            if (acc.Bank == 0)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Eröffne dir in der nächsten Bankfilliale ein neues Konto", 3000);
                return;
            }
            long balance = Bank.Accounts[acc.Bank].Balance;
            Trigger.ClientEvent(player, "setatm", acc.Bank.ToString(), player.Name, balance.ToString(), "");
            Trigger.ClientEvent(player, "openatm");
            return;
        }

        public static void AtmBizGen(Player player)
        {
            var acc = Main.Players[player];
            Log.Debug("Biz count : " + acc.BizIDs.Count);
            if (acc.BizIDs.Count > 0)
            {
                List<string> data = new List<string>();
                foreach (int key in acc.BizIDs)
                {
                    Business biz = BusinessManager.BizList[key];
                    string name = BusinessManager.BusinessTypeNames[biz.Type];
                    data.Add($"{name}");
                }
                Trigger.ClientEvent(player, "atmOpenBiz", JsonConvert.SerializeObject(data), "");
            }
            else
            {
                Trigger.ClientEvent(player, "atmOpen", "[1,0,0]");
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Keine Befugniss!", 3000);
            }
        }

        [RemoteEvent("atmVal")]
        public static void ClientEvent_ATMVAL(Player player, params object[] args)
        {
            try
            {
                if (Admin.IsServerStoping)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Der Server kann diese Aktion gerade nicht verarbeiten", 3000);
                    return;
                }
                var acc = Main.Players[player];
                int type = NAPI.Data.GetEntityData(player, "ATMTYPE");
                string data = Convert.ToString(args[0]);
                int amount;
                if (!Int32.TryParse(data, out amount))
                    return;
                switch (type)
                {
                    case 0:
                        Trigger.ClientEvent(player, "atmClose");
                        if (Wallet.Change(player, -Math.Abs(amount)))
                        {
                            Bank.Change(acc.Bank, +Math.Abs(amount));
                            GameLog.Money($"player({Main.Players[player].UUID})", $"bank({acc.Bank})", Math.Abs(amount), $"atmIn");
                            Trigger.ClientEvent(player, "setbank", Bank.Accounts[acc.Bank].Balance.ToString(), "");
                        }
                        break;
                    case 1:
                        if (Bank.Change(acc.Bank, -Math.Abs(amount)))
                        {
                            Wallet.Change(player, +Math.Abs(amount));
                            GameLog.Money($"bank({acc.Bank})", $"player({Main.Players[player].UUID})", Math.Abs(amount), $"atmOut");
                            Trigger.ClientEvent(player, "setbank", Bank.Accounts[acc.Bank].Balance.ToString(), "");
                        }
                        break;
                    case 2:
                        var house = Houses.HouseManager.GetHouse(player, true);
                        if (house == null) return;

                        var maxMoney = Convert.ToInt32(house.Price / 100 * 0.013) * 24 * 7;
                        if (Bank.Accounts[house.BankID].Balance + Math.Abs(amount) > maxMoney)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Du kannst nicht soviel Geld für dein Haus einzahlen.", 3000);
                            return;
                        }
                        if (!Wallet.Change(player, -Math.Abs(amount)))
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Nicht genug Geld.", 3000);
                            return;
                        }
                        Bank.Change(house.BankID, +Math.Abs(amount));
                        GameLog.Money($"player({Main.Players[player].UUID})", $"bank({house.BankID})", Math.Abs(amount), $"atmHouse");
                        Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, "Erfolgreich.", 3000);
                        Trigger.ClientEvent(player,
                                "atmOpen", $"[2,'{Bank.Accounts[house.BankID].Balance}/{Convert.ToInt32(house.Price / 100 * 0.013) * 24 * 7}$','Betrag der Einlagen']");
                        break;
                    case 3:
                        int bid = NAPI.Data.GetEntityData(player, "ATMBIZ");

                        Business biz = BusinessManager.BizList[acc.BizIDs[bid]];

                        maxMoney = Convert.ToInt32(biz.SellPrice / 100 * 0.013) * 24 * 7;
                        if (Bank.Accounts[biz.BankID].Balance + Math.Abs(amount) > maxMoney)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Es ist unmöglich, so viel Geld auf ein Geschäftskonto zu überweisen", 3000);
                            return;
                        }
                        if (!Wallet.Change(player, -Math.Abs(amount)))
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Nicht genug Geld.", 3000);
                            return;
                        }
                        Bank.Change(biz.BankID, +Math.Abs(amount));
                        GameLog.Money($"player({Main.Players[player].UUID})", $"bank({biz.BankID})", Math.Abs(amount), $"atmBiz");
                        Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, "Erfolgreich!", 3000);
                        Trigger.ClientEvent(player, "atmOpen", $"[2,'{Bank.Accounts[biz.BankID].Balance}/{Convert.ToInt32(biz.SellPrice / 10000 * 0.013) * 24 * 7}$','Gutgeschriebener Betrag']");
                        break;
                    case 4:
                        if (!Bank.Accounts.ContainsKey(amount) || amount <= 0)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Kein Konto gefunden!", 3000);
                            Trigger.ClientEvent(player, "closeatm");
                            return;
                        }
                        NAPI.Data.SetEntityData(player, "ATM2ACC", amount);
                        Trigger.ClientEvent(player,
                                "atmOpen", "[2,0,'Zu überweisender Betrag']");
                        NAPI.Data.SetEntityData(player, "ATMTYPE", 44);
                        break;
                    case 44:
                        if (Main.Players[player].LVL < 1)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Überweisungen sind erst ab Stufe 1 verfügbar", 3000);
                            return;
                        }
                        if (player.HasData("NEXT_BANK_TRANSFER") && DateTime.Now < player.GetData<DateTime>("NEXT_BANK_TRANSFER"))
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Die nächste überweisung wird innerhalb einer Minute möglich sein.", 3000);
                            return;
                        }
                        int bank = NAPI.Data.GetEntityData(player, "ATM2ACC");
                        if (!Bank.Accounts.ContainsKey(bank) || bank <= 0)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Kein Konto gefunden!", 3000);
                            Trigger.ClientEvent(player, "closeatm");
                            return;
                        }
                        if (Bank.Accounts[bank].Type != 1 && Main.Players[player].AdminLVL == 0)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Kein Konto gefunden!", 3000);
                            Trigger.ClientEvent(player, "closeatm");
                            return;
                        }
                        if (acc.Bank == bank)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Der Vorgang wurde abgebrochen.", 3000);
                            Trigger.ClientEvent(player, "closeatm");
                            return;
                        }
                        Bank.Transfer(acc.Bank, bank, Math.Abs(amount));
                        Trigger.ClientEvent(player, "closeatm");
                        if (Main.Players[player].AdminLVL == 0) player.SetData("NEXT_BANK_TRANSFER", DateTime.Now.AddMinutes(1));
                        break;
                }
            }
            catch (Exception e)
            {
                Log.Write(e.ToString(), nLog.Type.Error);
            }
        }
        [RemoteEvent("atmDP")]
        public static void ClientEvent_ATMDupe(Player Player)
        {
            foreach (var p in Main.Players.Keys.ToList())
            {
                if (!Main.Players.ContainsKey(p)) continue;
                if (Main.Players[p].AdminLVL >= 3)
                {
                    p.SendChatMessage($"!{{#d35400}}[ATM-FLOOD] {Player.Name} ({Player.Value})");
                }
            }
        }

        [RemoteEvent("atmCB")]
        public static void ClientEvent_ATMCB(Player player, params object[] args)
        {
            try
            {
                var acc = Main.Players[player];
                int type = Convert.ToInt32(args[0]);
                int index = Convert.ToInt32(args[1]);
                if (index == -1)
                {
                    Trigger.ClientEvent(player, "closeatm");
                    return;
                }
                switch (type)
                {
                    case 1:
                        switch (index)
                        {
                            case 0:
                                Trigger.ClientEvent(player,
                                    "atmOpen", "[2,0,'Betrag der Einzahlung']");
                                NAPI.Data.SetEntityData(player, "ATMTYPE", index);
                                break;
                            case 1:
                                Trigger.ClientEvent(player,
                                    "atmOpen", "[2,0,'Abzuhebender Betrag']");
                                NAPI.Data.SetEntityData(player, "ATMTYPE", index);
                                break;
                            case 2:
                                if (Houses.HouseManager.GetHouse(player, true) == null)
                                {
                                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Sie haben kein Zuhause!", 3000);
                                    return;
                                }
                                var house = Houses.HouseManager.GetHouse(player, true);
                                Trigger.ClientEvent(player,
                                    "atmOpen", $"[2,'{Bank.Accounts[house.BankID].Balance}/{Convert.ToInt32(house.Price / 100 * 0.013) * 24 * 7}$','Betrag der Einzahlung']");
                                Trigger.ClientEvent(player, "setatm", "Haus", $"Haus #{house.ID}", Bank.Accounts[house.BankID].Balance, "");
                                NAPI.Data.SetEntityData(player, "ATMTYPE", index);
                                break;
                            case 3:
                                AtmBizGen(player);
                                NAPI.Data.SetEntityData(player, "ATMTYPE", index);
                                break;
                            case 4:
                                Trigger.ClientEvent(player,
                                    "atmOpen", "[2,0,'Konto eingeben']");
                                NAPI.Data.SetEntityData(player, "ATMTYPE", index);
                                break;

                        }
                        break;
                    case 2:
                        Trigger.ClientEvent(player, "atmOpen", "[1,0,0]");
                        Trigger.ClientEvent(player, "setatm", acc.Bank, player.Name, Bank.Accounts[acc.Bank].Balance, "");
                        break;
                    case 3:
                        if (index == -1)
                        {
                            Trigger.ClientEvent(player, "atmOpen", "[1,0,0]");
                            Trigger.ClientEvent(player, "setatm", acc.Bank, player.Name, Bank.Accounts[acc.Bank].Balance, "");
                            return;
                        }
                        Business biz = BusinessManager.BizList[acc.BizIDs[index]];
                        NAPI.Data.SetEntityData(player, "ATMBIZ", index);
                        Trigger.ClientEvent(player, "atmOpen", $"[2,'{Bank.Accounts[biz.BankID].Balance}/{Convert.ToInt32(biz.SellPrice / 100 * 0.013) * 24 * 7}$','Betrag']");
                        Trigger.ClientEvent(player, "setatm",
                            "Geschäftlich",
                            BusinessManager.BusinessTypeNames[biz.Type],
                            Bank.Accounts[biz.BankID].Balance, "");
                        break;

                }
            }
            catch (Exception e) { Log.Write("atmCB: " + e.Message, nLog.Type.Error); }
        }

        [RemoteEvent("atm")]
        public static void ClientEvent_ATM(Player player, params object[] args)
        {
            try
            {
                if (Admin.IsServerStoping)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Der Server kann diese Aktion nicht verarbeiten.", 3000);
                    return;
                }
                int act = Convert.ToInt32(args[0]);
                string data1 = Convert.ToString(args[1]);
                var acc = Main.Players[player];
                int amount;
                if (!Int32.TryParse(data1, out amount))
                    return;
                Log.Debug($"{player.Name} : {data1}");
                switch (act)
                {
                    case 0: //put money
                        if (Wallet.Change(player, -Math.Abs(amount)))
                        {
                            Bank.Change(acc.Bank, amount);
                            GameLog.Money($"player({Main.Players[player].UUID})", $"bank({acc.Bank})", Math.Abs(amount), $"atmIn");
                            Trigger.ClientEvent(player, "setbank", Bank.Accounts[acc.Bank].Balance.ToString(), "");
                        }
                        break;
                    case 1: //take money
                        if (Bank.Change(acc.Bank, -Math.Abs(amount)))
                        {
                            Wallet.Change(player, amount);
                            GameLog.Money($"bank({acc.Bank})", $"player({Main.Players[player].UUID})", Math.Abs(amount), $"atmOut");
                            Trigger.ClientEvent(player, "setbank", Bank.Accounts[acc.Bank].Balance.ToString(), "");
                        }
                        break;
                    case 2: //put house tax
                        var house = Houses.HouseManager.GetHouse(player, true);
                        if (house == null) return;

                        var maxMoney = Convert.ToInt32(house.Price / 100 * 0.013) * 24 * 7;
                        if (Bank.Accounts[house.BankID].Balance + Math.Abs(amount) > maxMoney)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Du kannst nicht soviel Geld einzahlen.", 3000);
                            return;
                        }
                        if (!Wallet.Change(player, -Math.Abs(amount)))
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Nicht genug Geld.", 3000);
                            return;
                        }
                        Bank.Change(house.BankID, Math.Abs(amount));
                        GameLog.Money($"player({Main.Players[player].UUID})", $"bank({house.BankID})", Math.Abs(amount), $"atmHouse");
                        Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, "Erfolgreich", 3000);
                        break;
                    case 3: //put biz tax
                        var check = NAPI.Data.GetEntityData(player, "bizcheck");
                        if (check == null) return;
                        if (acc.BizIDs.Count != check)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Es ist ein Fehler aufgetreten! Bitte versuchen Sie es erneut.", 3000);
                            return;
                        }
                        int bid = 0;
                        if (!Int32.TryParse(Convert.ToString(args[2]), out bid))
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Es ist ein Fehler aufgetreten! Bitte versuchen Sie es erneut.", 3000);
                            return;
                        }

                        Business biz = BusinessManager.BizList[acc.BizIDs[bid]];

                        maxMoney = Convert.ToInt32(biz.SellPrice / 100 * 0.01) * 24 * 7;
                        if (Bank.Accounts[biz.BankID].Balance + Math.Abs(amount) > maxMoney)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Du kannst nicht soviel einzahlen.", 3000);
                            return;
                        }
                        if (!Wallet.Change(player, -Math.Abs(amount)))
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Nicht genug Geld.", 3000);
                            return;
                        }
                        Bank.Change(biz.BankID, Math.Abs(amount));
                        GameLog.Money($"player({Main.Players[player].UUID})", $"bank({biz.BankID})", Math.Abs(amount), $"atmBiz");
                        Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, "Erfolgreich!", 3000);
                        break;
                    case 4: //transfer to
                        int num = 0;
                        if (!Int32.TryParse(Convert.ToString(args[2]), out num))
                            return;
                        Bank.Transfer(acc.Bank, num, +Math.Abs(amount));
                        break;
                }
            }
            catch (Exception e) { Log.Write("atm: " + e.Message, nLog.Type.Error); }
        }
    }
}
