using GTANetworkAPI;
using Newtonsoft.Json;
using ULife.Core;
using ULife.Fractions;
using UNL.SDK;
using System;
using System.Collections.Generic;
using System.IO;

namespace ULife.carsmenu
{
    class Casinos : Script
    {
        private static nLog Log = new nLog("casino");
        [ServerEvent(Event.ResourceStart)]
        public void onResourceStart()
        {
            NAPI.Marker.CreateMarker(1, new Vector3(1089.695, 206.015, -50.29974), new Vector3(), new Vector3(), 1f, new Color(228, 228, 0, 200));
            NAPI.Marker.CreateMarker(1, new Vector3(935.7294, 46.61844, 79.5), new Vector3(), new Vector3(), 1f, new Color(228, 228, 0, 200));
            ColShape luckywill = NAPI.ColShape.CreateCylinderColShape(new Vector3(1110.981, 227.6995, -49.6358), 2, 2, 0);
            luckywill.OnEntityEnterColShape += (s, ent) =>
            {
                try
                {
                    NAPI.Data.SetEntityData(ent, "INTERACTIONCHECK", 535);
                    Trigger.ClientEvent(ent, "PressE", true);
                }
                catch (Exception ex) { Console.WriteLine("shape.OnEntityEnterColShape: " + ex.Message); }
            };
            luckywill.OnEntityExitColShape += (s, ent) =>
            {
                try
                {
                    NAPI.Data.SetEntityData(ent, "INTERACTIONCHECK", 0);
                    Trigger.ClientEvent(ent, "PressE", false);
                }
                catch (Exception ex) { Console.WriteLine("shape.OnEntityExitColShape: " + ex.Message); }
            };


            ColShape entercasino = NAPI.ColShape.CreateCylinderColShape(new Vector3(1089.695, 206.015, -48.99974), 1, 2, 0);
            entercasino.OnEntityEnterColShape += (s, ent) =>
            {
                try
                {
                    if (!ent.IsInVehicle)
                    {
                        ent.Position = new Vector3(932.9989, 45.74269, 80.29);
                    }
                }
                catch (Exception ex) { Console.WriteLine("shape.OnEntityEnterColShape: " + ex.Message); }
            };
            ColShape exitcasino = NAPI.ColShape.CreateCylinderColShape(new Vector3(935.7294, 46.61844, 80.09), 1, 2, 0);
            exitcasino.OnEntityEnterColShape += (s, ent) =>
            {
                try
                {
                    if (!ent.IsInVehicle)
                    {
                        ent.Position = new Vector3(1092.306, 209.75, -48.994);
                    }
                }
                catch (Exception ex) { Console.WriteLine("shape.OnEntityEnterColShape: " + ex.Message); }
            };
        }
        private static Random rndf = new Random();
        public static void roll(Player player)
        {
            var acc = Main.Accounts[player];
            string timetowheel = "";
            DateTime dates = Convert.ToDateTime(Main.Accounts[player].wheel.AddHours(3));
            DateTime onlines = Convert.ToDateTime(Main.Accounts[player].timewheel.AddMinutes(Main.Players[player].TimeOnline));
            Console.WriteLine("shape.OnEntityExitColShape: " + onlines);
            if (dates > onlines)
            {
                DateTime g = new DateTime((dates - onlines).Ticks);
                var min = g.Minute;
                var hour = g.Hour;
                timetowheel = $"{hour} ÷. {min + 1} Mindest.";
            }
            else timetowheel = "0";
            if (Main.Players[player].TimeOnline < 180)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Drehung nicht verfügbar, nächste Drehung in {timetowheel}", 3000);
                return;
            }
            var rndt = new Random();
            int pluscost = rndt.Next(1, 20);
            Main.Players[player].TimeOnline = 0;
            Trigger.ClientEvent(player, "client_casino_luckywheel_player_spin", player.GetData<int>("REMOTE_ID"), pluscost);
            Notify.Send(player, NotifyType.Warning, NotifyPosition.MapUp, $"Sie haben das Rad gedreht, erwarten Sie einen Preis", 3000);
            acc.Save(player);
        }
        [RemoteEvent("server_casino_luckywheel_getGift")]
        public static void getGift(Player player, int index)
        {
            var rndt = new Random();
            var ints = 0;
            if (index == 8 || index == 12 || index == 16 || index == 20) ints = 1;
            if (index == 2 || index == 6 || index == 14 || index == 19) ints = 2;
            if (index == 1 || index == 5 || index == 9 || index == 13 || index == 17) ints = 3;
            if (index == 3 || index == 7 || index == 10 || index == 15) ints = 4;
            if (index == 4) ints = 5;
            if (index == 11) ints = 6;
            if (index == 18) ints = 7;
            switch (ints)
            {
                case 1:
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie haben die Kleidung gewonnen.", 3000);
                    return;
                case 2:
                    int money = rndt.Next(10, 150);
                    MoneySystem.Wallet.Change(player, 30 * money);
                    int wallet = 30 * money;
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie gewinnen. {wallet}$", 3000);
                    return;
                case 3:
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie haben ein Geschenk gewonnen.", 3000);
                    return;
                case 4:
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie haben die Chips gewonnen.", 3000);
                    return;
                case 5:
                    int nexuspoint = rndt.Next(1, 15);
                    int amount = 5 * nexuspoint;
                    Main.Accounts[player].ulife += amount;
                    Trigger.ClientEvent(player, "starset", Main.Accounts[player].ulife);
                    MySQL.QueryRead($"UPDATE `accounts` SET `redbucks`=`redbucks`+{amount}  WHERE `login`='{Main.Accounts[player].Login}'");
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie gewinnen. {amount} NP", 3000);
                    return;
                case 6:
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie gewinnen den Superpreis.", 3000);
                    return;
                case 7:
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie haben das Auto gewonnen.", 3000);
                    var vNumber = VehicleManager.Create(player.Name, "charger", new Color(0, 0, 0), new Color(0, 0, 0));
                    nInventory.Add(player, new nItem(ItemType.CarKey, 1, $"{vNumber}_{VehicleManager.Vehicles[vNumber].KeyNum}"));
                    Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Sie haben ein Charger-Auto mit Kennzeichen gewonnen {vNumber}", 3000);
                    return;
            }
        }
        #region Casino Roulette
        private static Dictionary<int, Tables> Casino = new Dictionary<int, Tables>()
        {
            { 0, new Tables(new Vector3(1110.981, 227.6995, -49.6358),
                new List<Vector3>(){
                    new Vector3(1144.272, 268.3762, -51.66087),
                    new Vector3(1145.217, 268.4534, -51.66087),
                    new Vector3(1145.847, 269.2192, -51.66087),
                    new Vector3(1145.176, 270.0057, -51.66087),
            },true,true,true,0)},
            { 1, new Tables(new Vector3(1151.271, 263.0273, -52.6358),
                new List<Vector3>(){
                    new Vector3(1151.057, 262.2002, -51.96087),
                    new Vector3(1151.99, 262.2178, -51.96087),
                    new Vector3(1152.656, 263.0127, -51.96087),
                    new Vector3(1151.97, 263.8024, -51.96087),
            },true,true,true,0)},
            { 2, new Tables(new Vector3(1148.961, 248.513, -52.6358),
                new List<Vector3>(){
                    new Vector3(1148.726, 247.7198, -51.15577),
                    new Vector3(1149.676, 247.7573, -51.15577),
                    new Vector3(1150.328, 248.4774, -51.15577),
                    new Vector3(1149.651, 249.2952, -51.15577),
            },true,true,true,0)},
            { 3, new Tables(new Vector3(1143.681, 251.2601, -52.6358),
                new List<Vector3>(){
                    new Vector3(1143.479, 250.4144, -51.15577),
                    new Vector3(1144.456, 250.4553, -51.15577),
                    new Vector3(1144.123, 251.2726, -51.15577),
                    new Vector3(1144.427, 251.0957, -51.15577),
            },true,true,true,0)},
            { 4, new Tables(new Vector3(1133.354, 262.2992, -52.6358),
                new List<Vector3>(){
                    new Vector3(1133.987, 261.5208, -51.15577),
                    new Vector3(1133.999, 261.4994, -51.15577),
                    new Vector3(1134.571, 262.2891, -51.15577),
                    new Vector3(1133.911, 261.0585, -51.15577),
            },true,true,true,0)},
            { 5, new Tables(new Vector3(1133.354, 262.2992, -52.6358),
                new List<Vector3>(){
                    new Vector3(1129.829, 266.0712, -51.03578),
                    new Vector3(1130.809, 266.0267, -51.15577),
                    new Vector3(1131.396, 266.8144, -51.15577),
                    new Vector3(1130.733, 267.5821, -51.15577),
            },true,true,true,0)},
        };
        private static Dictionary<int, Bet> Bets = new Dictionary<int, Bet>()
        {
            {1, new Bet(8,"Черное")},
            {2, new Bet(19,"Красное")},
            {3, new Bet(31,"Черное")},
            {4, new Bet(18,"Красное")},
            {5, new Bet(6,"Черное")},
            {6, new Bet(21,"Красное")},
            {7, new Bet(33,"Черное")},
            {8, new Bet(16,"Красное")},
            {9, new Bet(4,"Черное")},
            {10, new Bet(23,"Красное")},
            {11, new Bet(35,"Черное")},
            {12, new Bet(14,"Красное")},
            {13, new Bet(2,"Черное")},
            {14, new Bet(0,"Зеленое")},
            {15, new Bet(28,"Черное")},
            {16, new Bet(9,"Красное")},
            {17, new Bet(26,"Черное")},
            {18, new Bet(30,"Красное")},
            {19, new Bet(11,"Черное")},
            {20, new Bet(7,"Красное")},
            {21, new Bet(20,"Черное")},
            {22, new Bet(32,"Красное")},
            {23, new Bet(17,"Черное")},
            {24, new Bet(5,"Красное")},
            {25, new Bet(22,"Черное")},
            {26, new Bet(34,"Красное")},
            {27, new Bet(15,"Черное")},
            {28, new Bet(3,"Красное")},
            {29, new Bet(24,"Черное")},
            {30, new Bet(36,"Красное")},
            {31, new Bet(13,"Черное")},
            {32, new Bet(1,"Красное")},
            {33, new Bet(1000,"Зеленое")},
            {34, new Bet(27,"Красное")},
            {35, new Bet(10,"Черное")},
            {36, new Bet(25,"Красное")},
            {37, new Bet(29,"Черное")},
            {38, new Bet(12,"Красное")}
        };
        class Tables
        {
            public Vector3 TablePosition { get; }
            public List<Vector3> SeatsPositions { get; }
            public List<bool> Seats { get; set; } = new List<bool> { true,true,true,true};
            public bool Tablestartgame { get; set; }
            public bool Firstbet { get; set; }
            public bool StartTimer { get; set; }
            public int Ballends { get; set; }


            public Tables(Vector3 position, List<Vector3> seatsPositions, bool tablestartgame, bool firstbet, bool starttimer, int ballends)
            {
                TablePosition = position;
                SeatsPositions = seatsPositions;
                Tablestartgame = tablestartgame;
                Firstbet = firstbet;
                StartTimer = starttimer;
                Ballends = ballends;
            }
        }
        class Bet
        {
            public int Number { get; }
            public string Color { get; }
            public Bet(int number, string color)
            {
                Number = number;
                Color = color;
            }
        }
        private static Dictionary<int, CheckBet> CheckBets = new Dictionary<int, CheckBet>()
        {
            {0, new CheckBet(499,2501)},
            {1, new CheckBet(999,5001)},
            {2, new CheckBet(2999,15001)},
            {3, new CheckBet(6999,35001)},
            {4, new CheckBet(9999,50001)},
            {5, new CheckBet(19999,100001)},
        };
        class CheckBet
        {
            public int Min { get; }
            public int Max { get; }
            public CheckBet(int min, int max)
            {
                Min = min;
                Max = max;
            }
        }
        public static void onplayerdisconnect(Player player)
        {
            try
            {
                if (player.HasData("key")) { player.ResetData("key"); Trigger.ClientEvent(player, "deleteObjectsd"); }
                if (player.HasData("key2")) { player.ResetData("key2"); Trigger.ClientEvent(player, "deleteObjectsd2"); }
                if (player.HasData("key3")) { player.ResetData("key3"); Trigger.ClientEvent(player, "deleteObjectsd3"); }
                Trigger.ClientEvent(player, "freeze", false);
                if (player.HasData("seat"))
                {
                    int table = player.GetData<int>("tablekey");
                    int seat = player.GetData<int>("seat");
                    Casino[table].Seats[seat] = true;
                    player.ResetData("seat");
                    player.ResetData("tablekey");
                }
            }
            catch (Exception e) { Log.Write("playerPressCuffBut: " + e.Message, nLog.Type.Error); }
        }

        [RemoteEvent("leaveCasinoSeat")]
        public static void leaveCasinoSeat(Player player)
        {
            try
            {
                Trigger.ClientEvent(player, "freeze", false);
                int table = player.GetData<int>("tablekey");
                int seat = player.GetData<int>("seat");
                if (seat != 1)
                {
                    player.PlayAnimation("anim_casino_b@amb@casino@games@shared@player@", "sit_exit_left", 33);
                }
                else
                {
                    player.PlayAnimation("anim_casino_b@amb@casino@games@shared@player@", "sit_exit_right", 33);
                }
                NAPI.Task.Run(() =>
                {
                player.StopAnimation();
                }, 3500);
                Trigger.ClientEvent(player, "setBlockControl", false);
                Casino[table].Seats[seat] = true;
                //player.FreezePosition = false;
                player.SetSharedData("afkgames", false);
                player.SetData("ingames", false);
                player.SetSharedData("seats", false);
                player.ResetData("seat");
                Trigger.ClientEvent(player, "seatsdisable");
            }
            catch (Exception e) { Log.Write("playerPressCuffBut: " + e.Message, nLog.Type.Error); }
        }
       
        [RemoteEvent("occupyCasinoSeat")]
        public static void occupyCasinoSeat(Player player, int table, int seat)
        {

            try
            {
                if (player.HasData("key"))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie haben ein aktives Gebot an einem anderen Tisch", 3000);
                    return;
                }
                if (Casino[table].Seats[seat] == false) { Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Dieser Platz ist besetzt.!", 3000); return; }
                //   player.Position = Casino[table].SeatsPositions[seat];
                if (seat != 1)
                {
                    player.PlayAnimation("anim_casino_b@amb@casino@games@shared@player@", "sit_enter_left_side", 33);
                    NAPI.Task.Run(() =>
                    {
                    //  player.StopAnimation();
                    player.PlayAnimation("anim_casino_b@amb@casino@games@shared@player@", "idle_var_01", 33);
                        NAPI.Task.Run(() =>
                        {
                            Trigger.ClientEvent(player, "freeze", true);
                        }, 500);
                    }, 3500);
                }
                else
                {
                    player.PlayAnimation("anim_casino_b@amb@casino@games@shared@player@", "sit_enter_right_side", 33);
                    NAPI.Task.Run(() =>
                    {
                        //  player.StopAnimation();
                        player.PlayAnimation("anim_casino_b@amb@casino@games@shared@player@", "idle_var_01", 33);
                        NAPI.Task.Run(() =>
                        {
                            Trigger.ClientEvent(player, "freeze", true);
                        }, 500);
                    }, 3500);
                }
                Trigger.ClientEvent(player, "setBlockControl", true);
               // player.FreezePosition = true;
                player.SetData("tablekey", table);
                Casino[table].Seats[seat] = false;
                player.SetData("ingames", true);
                player.SetData("seat", seat);
                player.SetSharedData("seats", true);
                if (Casino[table].Tablestartgame == true)
                {
                    startnewbet(player);
                }
                Trigger.ClientEvent(player, "playerSitAtCasinoTable", player, table);
                Trigger.ClientEvent(player, "seatsactive");
            }
            catch (Exception e) { Log.Write("playerPressCuffBut: " + e.Message, nLog.Type.Error); }
        }
        public static void startnewbet(Player players)
        {
            try
            {
                var p = Main.GetPlayersInRadiusOfPosition(new Vector3(1140.802, 259.2148, -52.44087), 30);

                foreach (var player in p)
                {
                    if (player == null || !Main.Players.ContainsKey(player)) continue;
                    int table = -1;
                    if (players.HasData("tablekey")) table = players.GetData<int>("tablekey");
                    else return;
                    if (Casino[table].Tablestartgame == true)
                    {
                        if (Casino[table].Seats[0] == false || Casino[table].Seats[1] == false || Casino[table].Seats[2] == false || Casino[table].Seats[3] == false)
                        {
                            if (table == player.GetData<int>("tablekey"))
                            {
                                Trigger.ClientEvent(player, "rouletteAllowBets", true);
                            }
                            if (Casino[table].Firstbet == false)
                            {
                                NAPI.Task.Run(() =>
                                {
                                    if (table == player.GetData<int>("tablekey"))
                                    {
                                        Trigger.ClientEvent(player, "rouletteAllowBets", false);
                                        Casino[table].Tablestartgame = false;
                                        Casino[table].Firstbet = true;
                                    }
                                }, 20000);
                                NAPI.Task.Run(() =>
                                {
                                    if (player.HasData("tablekey") && player.HasData("startthegame"))
                                    {
                                        if (Casino[table].Tablestartgame == false)
                                        {
                                            if (players.HasData("startthegame"))
                                            {
                                                players.ResetData("startthegame");
                                                spinRouletteWheel(players, table);
                                            }
                                        }
                                    }
                                }, 23000);
                            }
                        }
                    }
                    else return;
                }
            }
            catch (Exception e) { Log.Write("playerPressCuffBut: " + e.Message, nLog.Type.Error); }
        }
        public static void newtimer(int table)
        {
            var rndt = new Random();
            Casino[table].Ballends = rndt.Next(1, 36); 
        }

        [RemoteEvent("removeRouletteBet")]
        public static void removeRouletteBet(Player player, int closestChipSpot)
        {
            int money = 0;
            if (player.HasData("key"))
            {
                if (player.GetData<int>("key") == closestChipSpot)
                {
                    money = player.GetData<int>("keymoney");
                    MoneySystem.Wallet.Change(player, +money);
                    player.ResetData("key");
                    Trigger.ClientEvent(player, "deleteObjectsd");
                    return;
                }
            }
            if (player.HasData("key2"))
            {
                if (player.GetData<int>("key2") == closestChipSpot)
                {
                    money = player.GetData<int>("keymoney2");
                    player.ResetData("key2");
                    MoneySystem.Wallet.Change(player, +money);
                    Trigger.ClientEvent(player, "deleteObjectsd2");
                    return;
                }
            }
            if (player.HasData("key3"))
            {
                if (player.GetData<int>("key3") == closestChipSpot)
                {
                    money = player.GetData<int>("keymoney3");
                    player.ResetData("key3");
                    MoneySystem.Wallet.Change(player, +money);
                    Trigger.ClientEvent(player, "deleteObjectsd3");
                    return;
                }
            }
        }

        [RemoteEvent("makeRouletteBet")]
        public static void makeRouletteBet(Player player, int closestChipSpot, int money)
        {
            try
            {
                int table = player.GetData<int>("tablekey");
                if (Main.Players[player].Money < money)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie haben nicht genug Geld", 3000);
                    return;
                }
                if (Casino[table].Firstbet == true)
                {
                    Casino[table].Firstbet = false;
                    startnewbet(player);
                    newtimer(table);
                    player.SetData("startthegame", true);
                }
                player.SetSharedData("afkgames", true);
                if (!player.HasData("key"))
                {
                    player.SetData("keymoney", money);
                    player.SetData("key", closestChipSpot);
                    MoneySystem.Wallet.Change(player, -money);
                    Trigger.ClientEvent(player, "chipsserver", closestChipSpot);
                    return;
                }
                if (!player.HasData("key2"))
                {
                    if (player.GetData<int>("key") != closestChipSpot)
                    {
                        player.SetData("keymoney2", money);
                        player.SetData("key2", closestChipSpot);
                        MoneySystem.Wallet.Change(player, -money);
                        Trigger.ClientEvent(player, "chipsserver2", closestChipSpot);
                        return;
                    }
                    else { Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie haben bereits auf diese Zahl gewettet", 3000); return; };
                }
                if (!player.HasData("key3"))
                {
                    if (player.GetData<int>("key") != closestChipSpot && player.GetData<int>("key2") != closestChipSpot)
                    {
                        player.SetData("keymoney3", money);
                        player.SetData("key3", closestChipSpot);
                        MoneySystem.Wallet.Change(player, -money);
                        Trigger.ClientEvent(player, "chipsserver3", closestChipSpot);
                        return;
                    }
                    else { Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie haben bereits auf diese Zahl gewettet", 3000); return; }
                }
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie haben die maximalen 3 Wetten platziert", 3000);
            }
            catch (Exception e) { Log.Write("playerPressCuffBut: " + e.Message, nLog.Type.Error); }
        }
        public static void getprize(Player player, int table)
        {
            try
            {
                if (player.HasData("tablekey"))
                {
                    if (player.GetData<int>("tablekey") == table)
                    {
                        int money = 0;
                        int i = -1;
                        string s = "";
                        i = Bets[Casino[table].Ballends].Number;
                        s = Bets[Casino[table].Ballends].Color;
                        int x = 0;
                        int key3 = -1;
                        int key2 = -1;
                        int key = -1;
                        if (s == "Зеленое") x = 38;
                        if (s == "Красное") x = 36;
                        if (s == "Черное") x = 36;
                        if (player.HasData("key")) key = player.GetData<int>("key");
                        if (player.HasData("key2")) key2 = player.GetData<int>("key2");
                        if (player.HasData("key3")) key3 = player.GetData<int>("key3");
                        player.SetData("winmoney", 0);
                        if (key == 44 || key2 == 44 || key3 == 44)
                        {
                            if (i >= 1 && i <= 18)
                            {
                                if (key == 44) money = player.GetData<int>("keymoney");if (key2 == 44) money = player.GetData<int>("keymoney2");if (key3 == 44) money = player.GetData<int>("keymoney3");MoneySystem.Wallet.Change(player, +money * 2);int moneys = money * 2;player.SetData("winmoney", player.GetData<int>("winmoney") + moneys);player.SetData("win", true);
                            }
                        }
                        if (key == 41 || key2 == 41 || key3 == 41)
                        {
                            if (i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25 || i == 28 || i == 31 || i == 34)
                            {
                                if (key == 41) money = player.GetData<int>("keymoney");if (key2 == 41) money = player.GetData<int>("keymoney2");if (key3 == 41) money = player.GetData<int>("keymoney3"); MoneySystem.Wallet.Change(player, +money * 3);  int moneys = money * 3; player.SetData("winmoney", player.GetData<int>("winmoney") + moneys); player.SetData("win", true);
                            }
                        }
                        if (key == 42 || key2 == 42 || key3 == 42)
                        {
                            if (i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26 || i == 29 || i == 32 || i == 35)
                            {
                                if (key == 42) money = player.GetData<int>("keymoney");if (key2 == 42) money = player.GetData<int>("keymoney2");if (key3 == 4429) money = player.GetData<int>("keymoney3"); MoneySystem.Wallet.Change(player, +money * 3); int moneys = money * 3;player.SetData("winmoney", player.GetData<int>("winmoney") + moneys);player.SetData("win", true);
                            }
                        }
                        if (key == 43 || key2 == 43 || key3 == 43)
                        {
                            if (i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24 || i == 27 || i == 30 || i == 33 || i == 36)
                            {
                                if (key == 43) money = player.GetData<int>("keymoney");if (key2 == 43) money = player.GetData<int>("keymoney2");if (key3 == 43) money = player.GetData<int>("keymoney3"); MoneySystem.Wallet.Change(player, +money * 3);int moneys = money * 3;player.SetData("winmoney", player.GetData<int>("winmoney") + moneys); player.SetData("win", true);
                            }
                        }
                        if (key == 49 || key2 == 49 || key3 == 49)
                        {
                            if (i >= 19 && i <= 36)
                            {
                               if (key == 49) money = player.GetData<int>("keymoney");if (key2 == 49) money = player.GetData<int>("keymoney2");if (key3 == 49) money = player.GetData<int>("keymoney3");MoneySystem.Wallet.Change(player, +money * 2);int moneys = money * 2;player.SetData("winmoney", player.GetData<int>("winmoney") + moneys);player.SetData("win", true);
                            }
                        }
                        if (key == 45 || key2 == 45 || key3 == 45)
                        {
                            if (i % 2 == 0 && s != "Çåëåíîå")
                            {
                                if (key == 45) money = player.GetData<int>("keymoney");
                                if (key2 == 45) money = player.GetData<int>("keymoney2");
                                if (key3 == 45) money = player.GetData<int>("keymoney3");
                                MoneySystem.Wallet.Change(player, +money * 2);
                                int moneys = money * 2;
                                player.SetData("winmoney", player.GetData<int>("winmoney") + moneys);
                                player.SetData("win", true);
                            }
                        }
                        if (key == 48 || key2 == 48 || key3 == 48)
                        {
                            if (i % 2 != 0 && s != "Зеленое")
                            {
                                if (key == 48) money = player.GetData<int>("keymoney");
                                if (key2 == 48) money = player.GetData<int>("keymoney2");
                                if (key3 == 48) money = player.GetData<int>("keymoney3");
                                MoneySystem.Wallet.Change(player, +money * 2);
                                int moneys = money * 2;
                                player.SetData("winmoney", player.GetData<int>("winmoney") + moneys);
                                player.SetData("win", true);
                            }
                        }
                        if (key == 47 || key2 == 47 || key3 == 47)
                        {
                            if (s == "Черное")
                            {
                                if (key == 47) money = player.GetData<int>("keymoney");
                                if (key2 == 47) money = player.GetData<int>("keymoney2");
                                if (key3 == 47) money = player.GetData<int>("keymoney3");
                                MoneySystem.Wallet.Change(player, +money * 2);
                                int moneys = money * 2;
                                player.SetData("winmoney", player.GetData<int>("winmoney") + moneys);
                                player.SetData("win", true);
                            }
                        }
                        if (key == 46 || key2 == 46 || key3 == 46)
                        {
                            if (s == "Красное")
                            {
                                if (key == 46) money = player.GetData<int>("keymoney");
                                if (key2 == 46) money = player.GetData<int>("keymoney2");
                                if (key3 == 46) money = player.GetData<int>("keymoney3");
                                MoneySystem.Wallet.Change(player, +money * 2);
                                int moneys = money * 2;
                                player.SetData("winmoney", player.GetData<int>("winmoney") + moneys);
                                player.SetData("win", true);
                            }
                        }
                        if (s != "Зеленое" && key == i + 1 || key2 == i + 1 || key3 == i + 1)
                        {

                            if (key == i + 1) money = player.GetData<int>("keymoney");
                            if (key2 == i + 1) money = player.GetData<int>("keymoney2");
                            if (key3 == i + 1) money = player.GetData<int>("keymoney3");
                            MoneySystem.Wallet.Change(player, +money * x);
                            int moneys = money * x;
                            player.SetData("winmoney", player.GetData<int>("winmoney") + moneys);
                            player.SetData("win", true);
                        }
                        if (key == 38 || key == 39 || key == 40 || key2 == 38 || key2 == 39 || key2 == 40 || key3 == 38 || key3 == 39 || key3 == 40)
                        {
                            if (i >= 25 && i <= 36)
                            {
                                if (key == 40 || key2 == 40 || key3 == 40)
                                {
                                    if (key == 40) money = player.GetData<int>("keymoney");
                                    if (key2 == 40) money = player.GetData<int>("keymoney2");
                                    if (key3 == 40) money = player.GetData<int>("keymoney3");
                                    if (player.HasData("keymoney")) money = player.GetData<int>("keymoney");
                                    MoneySystem.Wallet.Change(player, +money * 3);
                                    int moneys = money * 3;
                                    player.SetData("winmoney", player.GetData<int>("winmoney") + moneys);
                                    player.SetData("win", true);
                                }
                            }
                            if (i >= 1 && i <= 12)
                            {
                                if (key == 38 || key2 == 38 || key3 == 38)
                                {
                                    if (key == 38) money = player.GetData<int>("keymoney");
                                    if (key2 == 38) money = player.GetData<int>("keymoney2");
                                    if (key3 == 38) money = player.GetData<int>("keymoney3");
                                    MoneySystem.Wallet.Change(player, +money * 3);
                                    int moneys = money * 3;
                                    player.SetData("winmoney", player.GetData<int>("winmoney") + moneys);
                                    player.SetData("win", true);
                                }
                            }
                            if (i >= 13 && i <= 24)
                            {
                                if (key == 39 || key2 == 39 || key3 == 39)
                                {
                                    if (key == 39) money = player.GetData<int>("keymoney");
                                    if (key2 == 39) money = player.GetData<int>("keymoney2");
                                    if (key3 == 39) money = player.GetData<int>("keymoney3");
                                    if (player.HasData("keymoney")) money = player.GetData<int>("keymoney");
                                    MoneySystem.Wallet.Change(player, +money * 3);
                                    int moneys = money * 3;
                                    player.SetData("winmoney", player.GetData<int>("winmoney") + moneys);
                                    player.SetData("win", true);
                                }
                            }
                        }
  if (s == "Зеленое")
                        {
                            if (i == 0)
                            {
                                if (key == i || key2 == i || key3 == i)
                                {
                                    if (key == i) money = player.GetData<int>("keymoney");
                                    if (key2 == i) money = player.GetData<int>("keymoney2");
                                    if (key3 == i) money = player.GetData<int>("keymoney3");
                                    MoneySystem.Wallet.Change(player, +money * x);
                                    int moneys = money * x;
                                    player.SetData("winmoney", player.GetData<int>("winmoney") + moneys);
                                    player.SetData("win", true);
                                }
                            }
                            if (i == 1000)
                            {
                                if (key == 1 || key2 == 1 || key3 == 1)
                                {
                                    if (key == 1) money = player.GetData<int>("keymoney");
                                    if (key2 == 1) money = player.GetData<int>("keymoney2");
                                    if (key3 == 1) money = player.GetData<int>("keymoney3");
                                    MoneySystem.Wallet.Change(player, +money * x);
                                    int moneys = money * x;
                                    player.SetData("winmoney", player.GetData<int>("winmoney") + moneys);
                                    player.SetData("win", true);
                                }
                                s = "дабл Зеленое";
                                i = 00;
                            }
                        }
                        int moni = 0;
                        if (player.HasData("winmoney"))
                        {
                            moni = player.GetData<int>("winmoney");
                        }
                        winnotify(player, i, s, moni);
                        Casino[table].Tablestartgame = true;
                        player.SetData("win", false);
                        if (player.HasData("key")) { player.ResetData("key"); Trigger.ClientEvent(player, "deleteObjectsd"); }
                        if (player.HasData("key2")) { player.ResetData("key2"); Trigger.ClientEvent(player, "deleteObjectsd2"); }
                        if (player.HasData("key3")) { player.ResetData("key3"); Trigger.ClientEvent(player, "deleteObjectsd3"); }
                        startnewbet(player);
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine("shape.OnEntityExitColShape: " + ex.Message); }
        }

        public static void winnotify(Player player, int i, string s, int money)
        {
            if (player.GetData<bool>("win") == true)
            {
                if (player.HasData("ingames")) ;
                {
                    if (player.GetData<bool>("ingames") == true)
                    {
                        Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Eine Nummer kam auf {i} {s}, Sie gewinnen. {money}$", 3000);
                        player.PlayAnimation("anim_casino_b@amb@casino@games@shared@player@", "reaction_great_var_01", 33);
                        NAPI.Task.Run(() =>
                        {
                            player.PlayAnimation("anim_casino_b@amb@casino@games@shared@player@", "idle_var_01", 33);
                        }, 3000);
                    }
                }
            }
            else
            {
                if (player.HasData("ingames"));
                {
                    if (player.GetData<bool>("ingames") == true)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Eine Nummer kam auf {i} {s}", 3000);
                        player.PlayAnimation("anim_casino_b@amb@casino@games@shared@player@", "reaction_terrible_var_04", 33);
                        NAPI.Task.Run(() =>
                        {
                            player.PlayAnimation("anim_casino_b@amb@casino@games@shared@player@", "idle_var_01", 33);
                        }, 3000);
                    }
                }
            }
        }



        public static void spinRouletteWheel(Player player, int tables)
        {
            try {
                Table table = new Table();
                table.tableLib = "anim_casino_b@amb@casino@games@roulette@table";
                table.dealerLib = "anim_casino_b@amb@casino@games@roulette@dealer";
                table.tableStart = "intro_wheel";
                table.tableMain = "loop_wheel";
                table.ballStart = "intro_ball";
                table.ballMain = "loop_ball";
                table.ballRot = 32.6;
                table.speed = 136704;
                var p = Main.GetPlayersInRadiusOfPosition(new Vector3(1140.802, 259.2148, -52.44087), 30);

                foreach (var players in p)
                {
                    if (players == null || !Main.Players.ContainsKey(players)) continue;
                    if (player.HasData("tablekey"))
                    {
                        if (player.GetData<int>("tablekey") == tables)
                        { Trigger.ClientEvent(players, "initRoulette", JsonConvert.SerializeObject(table)); 
                            Trigger.ClientEvent(players, "entityStreamIn", "S_M_Y_Casino_01");
                            Trigger.ClientEvent(players, "spinRouletteWheel", tables, 1, $"exit_{Casino[tables].Ballends}_wheel", $"exit_{Casino[tables].Ballends}_ball");
                            NAPI.Task.Run(() =>
                            {
                                Casino[tables].StartTimer = true;
                                Trigger.ClientEvent(players, "clearRouletteTable", tables);
                                getprize(players, tables);
                            }, 20000);
                        }
                    }
                }
            }
            catch (Exception e) { Log.Write("playerPressCuffBut: " + e.Message, nLog.Type.Error); }
        }
        public class Table
        {

            public Table(string TableLib, string DealerLib, string TableStart, string TableMain, string BallStart, string BallMain, double BallRot, int Speed)
            {
                tableLib = TableLib;
                dealerLib = DealerLib;
                tableStart = TableStart;
                tableMain = TableMain;
                ballStart = BallStart;
                ballMain = BallMain;
                ballRot = BallRot;
                speed = Speed;
            }

            public Table()
            {
            }
            public string tableLib { get; set; }
            public string dealerLib { get; set; }
            public string tableStart { get; set; }
            public string tableMain { get; set; }
            public string ballStart { get; set; }
            public string ballMain { get; set; }
            public double ballRot { get; set; }
            public int speed { get; set; }
        }
        #endregion


    }
}