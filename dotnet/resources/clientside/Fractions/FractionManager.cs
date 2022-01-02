using System.Collections.Generic;
using System.Data;
using System;
using GTANetworkAPI;
using ULife.Core;
using UNL.SDK;
using ULife.GUI;
using ULife.Core.Character;
using System.Linq;
using Newtonsoft.Json;


namespace ULife.Fractions

{
    class Manager : Script
    { // Revision 3.0
        private static nLog Log = new nLog("Fractions");

        //[ServerEvent(Event.ResourceStart)] типа из-за него двоится ники во фракции и блипы
        public static void onResourceStart()
        {
            try
            {
                //NAPI.Blip.CreateBlip(468, Merryweather.Coords[0], 0.8f, 46, Main.StringToU16("Security"), 255, 0, true, 0, 0);
               // NAPI.Blip.CreateBlip(494, Manager.FractionSpawns[16], 0.40f, 20, Main.StringToU16("The Lost"), 255, 0, true, 0, 0);
                NAPI.Blip.CreateBlip(590, LSNews.LSNewsCoords[0], 0.40f, 45, Main.StringToU16("News"), 255, 0, true, 0, 0);
                NAPI.Blip.CreateBlip(419, Cityhall.CityhallChecksCoords[2], 1, 14, Main.StringToU16("Rathaus"), 255, 0, true, 0, 0);
                NAPI.Blip.CreateBlip(61, new Vector3(-442.9217, -345.694, 34.91079), 1, 49, Main.StringToU16("EMS"), 255, 0, true, 0, 0);
                NAPI.Blip.CreateBlip(88, Fbi.EnterFBI, 0.40f, 58, Main.StringToU16("FIB"), 255, 0, true, 0, 0);
                NAPI.Blip.CreateBlip(526, Police.policeCheckpoints[1], 1, 38, Main.StringToU16("LSPD"), 255, 0, true, 0, 0);
                NAPI.Blip.CreateBlip(85, Army.ArmyCheckpoints[2], 0.40f, 28, Main.StringToU16("Army"), 255, 0, true, 0, 0);
                NAPI.Blip.CreateBlip(544, AutoMechanic.checkpoints[1], 0.40f, 28, Main.StringToU16("ACLS"), 255, 0, true, 0, 0);


                /*  NAPI.Blip.CreateBlip(84, Manager.FractionSpawns[1], 0.40f, 52, Main.StringToU16("The Families"), 255, 0, true, 0, 0);
                  NAPI.Blip.CreateBlip(84, Manager.FractionSpawns[2], 0.40f, 58, Main.StringToU16("The Ballas"), 255, 0, true, 0, 0);
                  NAPI.Blip.CreateBlip(84, Manager.FractionSpawns[3], 0.40f, 28, Main.StringToU16("Los Santos Vagos"), 255, 0, true, 0, 0);
                  NAPI.Blip.CreateBlip(84, Manager.FractionSpawns[4], 0.40f, 74, Main.StringToU16("Marabunta Grande"), 255, 0, true, 0, 0);
                  NAPI.Blip.CreateBlip(84, Manager.FractionSpawns[5], 0.40f, 49, Main.StringToU16("Blood Street"), 255, 0, true, 0, 0);

                  NAPI.Blip.CreateBlip(78, Manager.FractionSpawns[10], 0.40f, 5, Main.StringToU16("La Cosa Nostra"), 255, 0, true, 0, 0);
                  NAPI.Blip.CreateBlip(78, Manager.FractionSpawns[11], 0.40f, 4, Main.StringToU16("Russian Mafia"), 255, 0, true, 0, 0);
                  NAPI.Blip.CreateBlip(78, Manager.FractionSpawns[12], 0.40f, 76, Main.StringToU16("Mexikanische Mafia"), 255, 0, true, 0, 0);
                  NAPI.Blip.CreateBlip(78, Manager.FractionSpawns[13], 0.40f, 40, Main.StringToU16("Armenian mafia"), 255, 0, true, 0, 0); */
                // NAPI.Blip.CreateBlip(16, Manager.FractionSpawns[14], 0.8f, 25, Main.StringToU16("USSR"), 255, 0, true, 0, 0);
                NAPI.Blip.CreateBlip(544, TuningMan.BlipPosition, 0.60f, 20, Main.StringToU16(TuningMan.Name), 255, 0, true, 0, 0);

                var result = MySQL.QueryRead("SELECT `uuid`,`firstname`,`lastname`,`fraction`,`fractionlvl` FROM `characters`");
                if (result != null)
                {
                    foreach (DataRow Row in result.Rows)
                    {
                        var memberData = new MemberData();
                        memberData.Name = $"{Convert.ToString(Row["firstname"])}_{Convert.ToString(Row["lastname"])}";
                        memberData.FractionID = Convert.ToInt32(Row["fraction"]);
                        memberData.FractionLVL = Convert.ToInt32(Row["fractionlvl"]);
                        memberData.inFracName = getNickname(memberData.FractionID, memberData.FractionLVL);

                        if (memberData.FractionID != 0)
                            AllMembers.Add(memberData);
                    }
                }
            }
            catch (Exception e)
            {
                Log.Write("EXCEPTION AT \"FRACTIONS_MANAGER\":\n" + e.ToString(), nLog.Type.Error);
            }
        }

        public static Dictionary<Weapons.Hash, int> matsForGun = new Dictionary<Weapons.Hash, int>()
        {
            { Weapons.Hash.Pistol, 50 },
            { Weapons.Hash.SNSPistol, 40 },
            { Weapons.Hash.DoubleBarrelShotgun, 80 },
            { Weapons.Hash.SawnOffShotgun, 100 },
            { Weapons.Hash.MachinePistol, 130 },
            { Weapons.Hash.MiniSMG, 120 },
            { Weapons.Hash.Bat, 30 },
            { Weapons.Hash.Machete, 30 },
            { Weapons.Hash.Pistol50, 80 },
            { Weapons.Hash.CombatPistol, 80 },
            { Weapons.Hash.VintagePistol, 70 },
            { Weapons.Hash.PumpShotgun, 120 },
            { Weapons.Hash.BullpupShotgun, 140 },
            { Weapons.Hash.AssaultRifle, 200 },
            { Weapons.Hash.CompactRifle, 180 },
            { Weapons.Hash.Hatchet, 50 },
            { Weapons.Hash.GolfClub, 50 },
            { Weapons.Hash.SwitchBlade, 50 },
            { Weapons.Hash.Hammer, 50 },
            { Weapons.Hash.MicroSMG, 150 },
            { Weapons.Hash.Nightstick, 30 },
            { Weapons.Hash.SMG, 60 },
            { Weapons.Hash.CombatPDW, 60 },
            { Weapons.Hash.StunGun, 100 },
            { Weapons.Hash.CarbineRifle, 100 },
            { Weapons.Hash.SmokeGrenade, 5 },
            { Weapons.Hash.HeavyShotgun, 500 },
            { Weapons.Hash.Knife, 20 },
            { Weapons.Hash.SniperRifle, 150 },
            { Weapons.Hash.HeavySniper, 1200 },
            { Weapons.Hash.AssaultSMG, 50 },
            { Weapons.Hash.AdvancedRifle, 50 },
            { Weapons.Hash.Gusenberg, 500 },
            { Weapons.Hash.CombatMG, 500 },
        };
        public static int matsForArmor = 250;
        private static List<List<string>> gangGuns = new List<List<string>>
        {
            new List<string>
            {
                "Pistol",
                "SNSPistol",
            },
            new List<string>
            {
                "DoubleBarrelShotgun",
                "SawnOffShotgun",
            },
            new List<string>
            {
                "MicroSMG",
            },
            new List<string> //Добавил, вроде связанно с крафтом
            {
                "BodyArmor",
            },

            new List<string>(),
        };
        private static List<List<string>> mafiaGuns = new List<List<string>>
        {
            new List<string>
            {
                "Pistol",
                "Pistol50",
                "VintagePistol",
            },
            new List<string>
            {
                "PumpShotgun",
            },
            new List<string>
            {
                "MiniSMG",
            },
            new List<string>
            {
                "AssaultRifle",
                "CompactRifle",
            },
        };

        public static Dictionary<Player, MemberData> Members = new Dictionary<Player, MemberData>();
        public static SortedList<int, Vector3> FractionSpawns = new SortedList<int, Vector3>()
        {
            {1, new Vector3(-79.18418, -1406.928, 29.80)},      // The Families точка респавна +
            {2, new Vector3(114.1684, -1928.366, 20.3)},     // The Ballas Gang +
            {3, new Vector3(1378.134, -1522.204, 57.5)},     // Los Santos Vagos +
            {4, new Vector3(893.8939, -2163.3765, 32.378136)},     // Marabunta Grande +
            {5, new Vector3(492.0538, -1512.27, 29.5)},         // Blood Street +
            {6, new Vector3(-559.9121, -205.7993, 38.1)},      // Cityhall +
            {7, new Vector3(455.17505, -998.6782, 30.69199)},         // LSPD police 
            {8, new Vector3(-427.636, -308.7417, 34.91)},      // Emergency care 
            {9, new Vector3(134.2327, -766.2291, 45.74332)},     // FBI +
            {10, new Vector3(1380.493, 1130.9565, 113.22135)},     // La Cosa Nostra +
            {11, new Vector3(-1539.0094, 836.36224, 180.69493)},    // Russian Mafia +
            {12, new Vector3(-1181.2308, 288.05157, 68.37902)},    // Mexican Cartel +
            {13, new Vector3(-1809.738, 444.3138, 129.3889)},    // Armenian Mafia +
            {14, new Vector3(-2248.268, 3300.472, 32.9)},    // Army +
            {15, new Vector3(-578.5106, -931.074, 23.8)},    // LSNews +
            {16, new Vector3(985.1607, -92.29832, 74.8)},    // The Lost +
            {17, new Vector3(745.1222, 1282.223, 360.5)},    // Merryweather +
            {18, new Vector3(847.8475, -1301.059, 31.74)},    // USMS 
            {19, TuningMan.PlayerSpawn},     // Tuning
            {20, new Vector3(3.00657, -1660.651, 28.57969)},     // Tuning
        };
        public static SortedList<int, int> FractionTypes = new SortedList<int, int>() // 0 - mafia, 1 gangs, 2 - gov, 
        {
            {0, -1},
            {1, 1}, // The Families
            {2, 1}, // The Ballas Gang
            {3, 1},  // Los Santos Vagos
            {4, 1}, // Marabunta Grande
            {5, 1}, // Blood Street
            {6, 2}, // Cityhall
            {7, 2}, // LSPD police
            {8, 2}, // Emergency care
            {9, 2}, // FBI 
            {10, 0}, // La Cosa Nostra 
            {11, 0}, // Russian Mafia
            {12, 0}, // Yakuza 
            {13, 0}, // Armenian Mafia 
            {14, 2}, // Army
            {15, 2}, // News
            {16, 1}, // The Lost
            {17, 2}, // Merryweather
            {18, 2}, // USMS
            {19, TuningMan.Type}, // Tuning / GOV
            {20, 2}, // ACLS
        };
        public static SortedList<int, string> FractionNames = new SortedList<int, string>()
        {
            {0, "-" },
            {1, "The Families" },
            {2, "The Ballas Gang" },
            {3, "Los Santos Vagos" },
            {4, "Marabunta Grande" },
            {5, "Blood Street" },
            {6, "Cityhall" },
            {7, "Police" },
            {8, "Hospital" },
            {9, "FIB" },
            {10, "La Cosa Nostra" },
            {11, "Russian Mafia" },
            {12, "Yakuza" },
            {13, "Armenian Mafia" },
            {14, "Army" },
            {15, "News" },
            {16, "The Lost" },
            {17, "Merryweather Security" },
            {18, "U.S. Marshal" },
            {19, TuningMan.Name },
            {20, "ACLS" },
        };
        public static List<MemberData> AllMembers = new List<MemberData>();

        public static void fractionChat(Player sender, string message)
        {
            try
            {
                if (sender == null || !Main.Players.ContainsKey(sender)) return;
                if (Main.Players[sender].FractionID == 0) return;

                if (Main.Players[sender].Unmute > 0)
                {
                    Notify.Send(sender, NotifyType.Error, NotifyPosition.MapUp, $"Sie werden zurück gequält {Main.Players[sender].Unmute / 60} Minuten", 3000);
                    return;
                }

                int Fraction = Main.Players[sender].FractionID;
                if (!Members.ContainsKey(sender)) return;
                string msgSender = $"~g~[F] {Members[sender].inFracName} " + sender.Name.ToString().Replace('_', ' ') + " (" + sender.Value + "): " + message;
                var fracid = Main.Players[sender].FractionID;
                foreach (var p in NAPI.Pools.GetAllPlayers())
                {
                    if (p == null || !Main.Players.ContainsKey(p)) continue;
                    if (Main.Players[p].FractionID == fracid)
                        NAPI.Chat.SendChatMessageToPlayer(p, msgSender);
                }
            }
            catch (Exception e) { Log.Write($"FractionChat:\n {e.ToString()}", nLog.Type.Error); }
        }

        public static Dictionary<int, int> GovIds = new Dictionary<int, int>
        {
            { 7, 14 },
            { 6, 8 },
            { 8, 11 },
            { 9, 14 },
            { 14, 15 },
            { 15, 16 },
            { 17, 15 },
            { 18, 14 },
            { 19, 14 },
            { 20, 14 },
        };
        public static Dictionary<int, string> GovTags = new Dictionary<int, string>
        {
            { 7, "LSPD" },
            { 6, "GOV" },
            { 8, "EMS" },
            { 9, "FIB" },
            { 14, "ARMY" },
            { 15, "NEWS" },
            { 17, "MERRYWEATHER" },
            { 18, "USMS" },
            { 19, TuningMan.GovTag },
            { 20, "ACLS" },
        };
        public static void govFractionChat(Player sender, string message)
        {
            if (!GovIds.ContainsKey(Main.Players[sender].FractionID)) return;
            if (!canUseCommand(sender, "dep")) return;
            if (Main.Players[sender].Unmute > 0)
            {
                Notify.Send(sender, NotifyType.Error, NotifyPosition.MapUp, $"Sie werden zurück gequält {Main.Players[sender].Unmute / 60} Minuten", 3000);
                return;
            }
            int Fraction = Main.Players[sender].FractionID;

            var color = "!{#B8962E}";
            string msgSender = $"{color}[{GovTags[Fraction]}] {Members[sender].inFracName} " + sender.Name.ToString().Replace('_', ' ') + " (" + sender.Value + "): " + message;
            var fracid = Main.Players[sender].FractionID;
            foreach (var p in NAPI.Pools.GetAllPlayers())
            {
                if (p == null) continue;
                if (!Main.Players.ContainsKey(p)) continue;
                if (GovIds.ContainsKey(Main.Players[p].FractionID))
                    NAPI.Chat.SendChatMessageToPlayer(p, msgSender);
            }
        }

        public static void Load(Player player, int fractionID, int fractionLVL)
        {
            if (Members.ContainsKey(player)) Members.Remove(player);
            MemberData data = new MemberData();
            data.FractionID = fractionID;
            data.FractionLVL = fractionLVL;
            data.inFracName = getNickname(fractionID, fractionLVL);
            data.Name = player.Name.ToString();
            Members.Add(player, data);

            if (fractionID == 14 && fractionLVL < 6)
                Main.Players[player].OnDuty = true;

            if (Main.Players[player].OnDuty)
            {
                setSkin(player, fractionID, fractionLVL);
                player.SetData("ON_DUTY", true);
            }

            var index = AllMembers.FindIndex(d => d.Name == player.Name);
            if (index == -1) AllMembers.Add(data);
            else
            {
                AllMembers[index].FractionID = data.FractionID;
                AllMembers[index].FractionLVL = data.FractionLVL;
                AllMembers[index].inFracName = data.inFracName;
            }
            Trigger.ClientEvent(player, "fractionChange", fractionID);
            player.SetSharedData("fraction", fractionID);
            Log.Write($"Member {player.Name.ToString()} loaded. ", nLog.Type.Success);
        }
        public static void UNLoad(Player player)
        {
            try
            {
                if (!Members.ContainsKey(player)) return;
                Members.Remove(player);
                Trigger.ClientEvent(player, "fractionChange", 0);
                player.SetSharedData("fraction", 0);
                Trigger.ClientEvent(player, "closePc");
                player.SetData("ON_DUTY", false);
                MenuManager.Close(player);
                Trigger.ClientEvent(player, "deleteFracBlips");

                if (Main.Players[player].FractionID == 9)
                {
                    var data = (Main.Players[player].Gender) ? "128_0_true" : "98_0_false";
                    var item = nInventory.Items[Main.Players[player].UUID].FirstOrDefault(i => i.Type == ItemType.Jewelry && i.Data == data);
                    if (item != null)
                    {
                        if (item.IsActive)
                        {
                            Customization.CustomPlayerData[Main.Players[player].UUID].Clothes.Accessory = new ComponentItem(0, 0);
                            player.SetClothes(7, 0, 0);
                        }
                        nInventory.Remove(player, item);
                    }
                }
                Log.Write($"Member {player.Name.ToString()} unloaded.", nLog.Type.Success);
            }
            catch (Exception e) { Log.Write("PlayerDisconnected: " + e.Message, nLog.Type.Error); }
        }
        public static void Spawn(Player player)
        {
            if (!Members.ContainsKey(player)) return;
            Vector3 spawnPos = FractionSpawns[Members[player].FractionID];
            NAPI.Entity.SetEntityPosition(player, spawnPos);
        }
        public static int countOfFractionMembers(int fracID)
        {
            int count = 0;
            foreach (var p in Members.Values)
            {
                if (p.FractionID == fracID) count++;
            }
            return count;
        }
        public static bool isHaveFraction(Player player)
        {
            if (Main.Players[player].FractionID != 0)
                return true;
            return false;
        }
        public static bool inFraction(Player player, int FracID)
        {
            if (Main.Players[player].FractionID == FracID)
                return true;
            return false;
        }
        public static bool isLeader(Player player, int FracID)
        {
            if (Main.Players[player].FractionID == FracID && Main.Players[player].FractionLVL == Configs.FractionRanks[FracID].Count)
                return true;
            return false;
        }
        public static string getName(int FractionID)
        {
            if (!FractionNames.ContainsKey(FractionID))
                return null;
            return FractionNames[FractionID];
        }

        public static void sendFractionMessage(int fracid, string message, bool inChat = false)
        {
            var all_players = Main.Players.Keys.ToList();
            if (inChat)
            {
                foreach (var p in all_players)
                {
                    if (p == null) continue;
                    if (!Main.Players.ContainsKey(p)) continue;
                    if (Main.Players[p].FractionID == fracid)
                        p.SendChatMessage(message);
                }
            }
            else
            {
                foreach (var p in all_players)
                {
                    if (p == null) continue;
                    if (!Main.Players.ContainsKey(p)) continue;
                    if (Main.Players[p].FractionID == fracid)
                        Notify.Send(p, NotifyType.Warning, NotifyPosition.MapUp, message, 3000);
                }
            }
        }

        public static void sendFractionPictureNotification(int fracid, string sender, string submessage, string message, string pic)
        {
            var all_players = NAPI.Pools.GetAllPlayers();
            foreach (var p in all_players)
            {
                if (p == null) continue;
                if (!Main.Players.ContainsKey(p)) continue;
                if (Main.Players[p].FractionID == fracid)
                    NAPI.Notification.SendPictureNotificationToPlayer(p, message, pic, 0, 0, sender, submessage);
            }
        }

        public static bool canUseCommand(Player player, string command, bool notify = true)
        {
            if (Main.Players[player].AdminLVL > 0) return true;
            if (player == null || !NAPI.Entity.DoesEntityExist(player)) return false;
            // Get player FractionID
            int fracid = Main.Players[player].FractionID;
            int fraclvl = Main.Players[player].FractionLVL;
            int minrank = 100;
            // Fractions available commands //

            if (Configs.FractionCommands.ContainsKey(fracid) && Configs.FractionCommands[fracid].ContainsKey(command))
                minrank = Configs.FractionCommands[fracid][command];

            #region Logic
            if (fraclvl < minrank)
            {
                if (notify)
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Kein Zugriff", 3000);
                return false;
            }
            else return true;
            #endregion Logic
        }
        public static bool canGetWeapon(Player player, string weapon, bool notify = true)
        {
            // Get player FractionID
            int fracid = Main.Players[player].FractionID;
            int fraclvl = Main.Players[player].FractionLVL;
            int minrank = 100;
            // Fractions available commands //

            if (Configs.FractionWeapons.ContainsKey(fracid) && Configs.FractionWeapons[fracid].ContainsKey(weapon))
                minrank = Configs.FractionWeapons[fracid][weapon];

            #region Logic
            if (fraclvl < minrank)
            {
                if (notify)
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Kein Zugriff", 3000);
                return false;
            }
            else return true;
            #endregion Logic
        }
        public static void setSkin(Player player, int fracID, int fracLvl)
        { // Only magic 
            bool gender = Main.Players[player].Gender;

            var clothes = (gender) ? Configs.FractionRanks[fracID][fracLvl].Item2 : Configs.FractionRanks[fracID][fracLvl].Item3;
            if (clothes == "null") return;

            Customization.ApplyCharacter(player);
            Customization.ClearClothes(player, gender);

            if (gender)
            {
                switch (clothes)
                {
                    case "city_1":
                        player.SetAccessories(1, 1, 1);
                        player.SetClothes(11, 242, 2);
                        player.SetClothes(4, 25, 0);
                        player.SetClothes(8, 129, 0);
                        player.SetClothes(6, 54, 0);
                        player.SetClothes(3, 0, 0);
                        break;
                    case "city_2":
                        player.SetClothes(8, 7, 0);
                        player.SetClothes(11, 120, 11);
                        player.SetClothes(4, 25, 2);
                        player.SetClothes(6, 10, 0);
                        player.SetClothes(3, 11, 0);
                        break;
                    case "city_3":
                        player.SetClothes(8, 71, 0);
                        player.SetClothes(6, 10, 0);
                        player.SetClothes(4, 25, 2);
                        player.SetClothes(11, 28, 2);
                        player.SetClothes(3, 1, 0);
                        break;
                    case "city_4":
                        player.SetClothes(11, 13, 0);
                        player.SetClothes(8, 58, 0);
                        player.SetClothes(4, 25, 0);
                        player.SetClothes(6, 54, 0);
                        player.SetClothes(7, 10, 2);
                        player.SetAccessories(1, 1, 1);
                        player.SetClothes(3, Customization.CorrectTorso[true][13], 0);
                        break;
                    case "city_5":
                        player.SetClothes(11, 4, 0);
                        player.SetClothes(8, 31, 0);
                        player.SetClothes(4, 10, 0);
                        player.SetClothes(6, 10, 0);
                        player.SetClothes(7, 10, 2);
                        player.SetClothes(1, 121, 0);
                        player.SetAccessories(1, 1, 1);
                        player.SetClothes(3, 12, 0);
                        break;
                    case "city_6":
                        player.SetClothes(11, 142, 0);
                        player.SetClothes(8, 31, 0);
                        player.SetClothes(4, 10, 0);
                        player.SetClothes(6, 10, 0);
                        player.SetClothes(7, 10, 2);
                        player.SetClothes(1, 121, 0);
                        player.SetAccessories(1, 1, 1);
                        player.SetClothes(3, 12, 0);
                        break;
                    case "city_7":
                        player.SetClothes(8, 31, 4);
                        player.SetClothes(7, 28, 4);
                        player.SetClothes(11, 32, 0);
                        player.SetClothes(6, 10, 0);
                        player.SetClothes(4, 25, 0);
                        player.SetClothes(3, 12, 0);
                        break;
                    case "city_8":
                        player.SetClothes(8, 31, 0);
                        player.SetClothes(7, 28, 12);
                        player.SetClothes(11, 32, 1);
                        player.SetClothes(6, 10, 0);
                        player.SetClothes(4, 25, 0);
                        player.SetClothes(3, 12, 0);
                        break;
                    case "city_9":
                        player.SetClothes(8, 31, 0);
                        player.SetClothes(7, 28, 15);
                        player.SetClothes(11, 32, 2);
                        player.SetClothes(6, 10, 0);
                        player.SetClothes(4, 25, 2);
                        player.SetClothes(3, 12, 0);
                        break;
                    case "city_10":
                        player.SetClothes(4, 10, 0);
                        player.SetClothes(7, 28, 15);
                        player.SetClothes(11, 32, 0);
                        player.SetClothes(6, 10, 0);
                        player.SetClothes(8, 31, 0);
                        player.SetClothes(3, 12, 0);
                        break;
                    case "city_11":
                        player.SetClothes(4, 10, 0);
                        player.SetClothes(7, 28, 15);
                        player.SetClothes(11, 32, 0);
                        player.SetClothes(6, 10, 0);
                        player.SetClothes(8, 31, 0);
                        player.SetClothes(3, 12, 0);
                        break;
                    case "city_12":
                        player.SetClothes(4, 10, 0);
                        player.SetClothes(7, 28, 15);
                        player.SetClothes(11, 32, 0);
                        player.SetClothes(6, 10, 0);
                        player.SetClothes(8, 31, 0);
                        player.SetClothes(3, 12, 0);
                        break;
                    case "city_13":
                        player.SetClothes(4, 10, 0);
                        player.SetClothes(7, 28, 15);
                        player.SetClothes(11, 32, 0);
                        player.SetClothes(6, 10, 0);
                        player.SetClothes(8, 31, 0);
                        player.SetClothes(3, 12, 0);
                        break;
                    case "city_14":
                        player.SetClothes(4, 10, 0);
                        player.SetClothes(7, 28, 15);
                        player.SetClothes(11, 32, 0);
                        player.SetClothes(6, 10, 0);
                        player.SetClothes(8, 31, 0);
                        player.SetClothes(3, 12, 0);
                        break;
                    case "city_15":
                        player.SetClothes(4, 10, 0);
                        player.SetClothes(7, 28, 15);
                        player.SetClothes(11, 32, 0);
                        player.SetClothes(6, 10, 0);
                        player.SetClothes(8, 31, 0);
                        player.SetClothes(3, 12, 0);
                        break;
                    case "city_16":
                        player.SetClothes(4, 10, 0);
                        player.SetClothes(7, 28, 15);
                        player.SetClothes(11, 32, 0);
                        player.SetClothes(6, 10, 0);
                        player.SetClothes(8, 31, 0);
                        player.SetClothes(3, 12, 0);
                        break;
                    case "city_17":
                        player.SetClothes(4, 10, 0);
                        player.SetClothes(7, 28, 15);
                        player.SetClothes(11, 32, 0);
                        player.SetClothes(6, 10, 0);
                        player.SetClothes(8, 31, 0);
                        player.SetClothes(3, 12, 0);
                        break;
                    case "city_18":
                        player.SetClothes(4, 10, 0);
                        player.SetClothes(7, 28, 15);
                        player.SetClothes(11, 32, 0);
                        player.SetClothes(6, 10, 0);
                        player.SetClothes(8, 31, 0);
                        player.SetClothes(3, 12, 0);
                        break;
                    case "city_19":
                        player.SetClothes(4, 10, 0);
                        player.SetClothes(7, 28, 15);
                        player.SetClothes(11, 32, 0);
                        player.SetClothes(6, 10, 0);
                        player.SetClothes(8, 31, 0);
                        player.SetClothes(3, 12, 0);
                        break;
                    case "city_20":
                        player.SetClothes(4, 10, 0);
                        player.SetClothes(7, 28, 15);
                        player.SetClothes(11, 32, 0);
                        player.SetClothes(6, 10, 0);
                        player.SetClothes(8, 31, 0);
                        player.SetClothes(3, 12, 0);
                        break;
                    case "police_1":
                        player.SetClothes(11, 55, 0);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][55], 0);
                        player.SetClothes(4, 35, 0);
                        player.SetClothes(6, 25, 0);
                        player.SetClothes(9, 7, 0);
                        player.SetClothes(8, 130, 0);
                        break;
                    case "police_2":
                        player.SetClothes(11, 55, 0);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][55], 0);
                        player.SetClothes(4, 35, 0);
                        player.SetClothes(6, 25, 0);
                        player.SetClothes(9, 7, 0);
                        player.SetClothes(8, 130, 0);
                        break;
                    case "police_3":
                        player.SetClothes(11, 55, 0);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][55], 0);
                        player.SetClothes(4, 35, 0);
                        player.SetClothes(6, 25, 0);
                        player.SetClothes(9, 7, 0);
                        player.SetClothes(8, 130, 0);
                        break;
                    case "police_4":
                        player.SetClothes(11, 55, 0);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][55], 0);
                        player.SetClothes(4, 35, 0);
                        player.SetClothes(6, 25, 0);
                        player.SetClothes(9, 7, 0);
                        player.SetClothes(8, 130, 0);
                        break;
                    case "police_5":
                        player.SetClothes(11, 55, 0);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][55], 0);
                        player.SetClothes(4, 35, 0);
                        player.SetClothes(6, 25, 0);
                        player.SetClothes(9, 7, 0);
                        player.SetClothes(8, 130, 0);
                        break;
                    case "police_6":
                        player.SetClothes(11, 55, 0);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][55], 0);
                        player.SetClothes(4, 35, 0);
                        player.SetClothes(6, 25, 0);
                        player.SetClothes(9, 7, 0);
                        player.SetClothes(10, 8, 1);
                        player.SetClothes(8, 130, 0);
                        break;
                    case "police_7":
                        player.SetClothes(11, 55, 0);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][55], 0);
                        player.SetClothes(4, 35, 0);
                        player.SetClothes(6, 25, 0);
                        player.SetClothes(9, 7, 0);
                        player.SetClothes(10, 8, 1);
                        player.SetClothes(8, 130, 0);
                        break;
                    case "police_8":
                        player.SetClothes(11, 55, 0);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][55], 0);
                        player.SetClothes(4, 35, 0);
                        player.SetClothes(6, 25, 0);
                        player.SetClothes(9, 7, 0);
                        player.SetClothes(10, 8, 1);
                        player.SetClothes(8, 130, 0);
                        break;
                    case "ems_1":
                        player.SetClothes(11, 250, 1);
                        player.SetClothes(3, 85, 1);
                        player.SetClothes(4, 96, 1);
                        player.SetClothes(6, 8, 0);
                        player.SetClothes(7, 127, 0);
                        player.SetClothes(10, 58, 0);
                        break;
                    case "ems_2":
                        player.SetClothes(11, 250, 0);
                        player.SetClothes(3, 85, 1);
                        player.SetClothes(4, 96, 0);
                        player.SetClothes(6, 8, 0);
                        player.SetClothes(7, 127, 0);
                        player.SetClothes(10, 58, 0);
                        break;
                    case "ems_3":
                        player.SetClothes(11, 249, 0);
                        player.SetClothes(3, 86, 1);
                        player.SetClothes(4, 96, 0);
                        player.SetClothes(6, 8, 0);
                        player.SetClothes(7, 126, 0);
                        player.SetClothes(10, 57, 0);
                        break;
                    case "ems_4":
                        player.SetClothes(11, 249, 1);
                        player.SetClothes(3, 86, 1);
                        player.SetClothes(4, 96, 1);
                        player.SetClothes(6, 8, 0);
                        player.SetClothes(7, 126, 0);
                        player.SetClothes(10, 57, 0);
                        break;
                    case "army_1":
                        player.SetClothes(11, 208, 3);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][208], 0);
                        player.SetClothes(4, 88, 3);
                        player.SetClothes(6, 62, 6);
                        break;
                    case "army_2":
                        player.SetClothes(11, 220, 3);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][220], 0);
                        player.SetClothes(4, 86, 3);
                        player.SetClothes(6, 63, 6);
                        break;
                    case "army_3":
                        Customization.SetHat(player, 103, 3);
                        player.SetClothes(11, 220, 3);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][220], 0);
                        player.SetClothes(4, 87, 3);
                        player.SetClothes(6, 62, 6);
                        break;
                    case "army_4":
                        Customization.SetHat(player, 103, 3);
                        player.SetClothes(11, 222, 3);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][222], 0);
                        player.SetClothes(4, 86, 3);
                        player.SetClothes(6, 63, 6);
                        break;
                    case "army_5":
                        Customization.SetHat(player, 107, 3);
                        player.SetClothes(11, 222, 3);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][222], 0);
                        player.SetClothes(4, 87, 3);
                        player.SetClothes(6, 62, 6);
                        break;
                    case "army_6":
                        Customization.SetHat(player, 105, 3);
                        player.SetClothes(11, 221, 3);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][221], 0);
                        player.SetClothes(4, 86, 3);
                        player.SetClothes(6, 63, 6);
                        break;
                    case "army_7":
                        Customization.SetHat(player, 107, 3);
                        player.SetClothes(11, 221, 3);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][221], 0);
                        player.SetClothes(4, 87, 3);
                        player.SetClothes(6, 62, 6);
                        break;
                    case "army_8":
                        Customization.SetHat(player, 112, 11);
                        player.SetClothes(11, 219, 3);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][219], 0);
                        player.SetClothes(4, 87, 3);
                        player.SetClothes(6, 62, 6);
                        break;
                    case "army_9":
                        Customization.SetHat(player, 106, 3);
                        player.SetClothes(11, 222, 3);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][222], 0);
                        player.SetClothes(4, 86, 3);
                        player.SetClothes(6, 63, 6);
                        break;
                    case "army_10":
                        Customization.SetHat(player, 106, 14);
                        player.SetClothes(11, 232, 7);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][232], 0);
                        player.SetClothes(8, 121, 14);
                        player.SetClothes(4, 87, 14);
                        player.SetClothes(6, 62, 0);
                        break;
                    case "army_11":
                        Customization.SetHat(player, 106, 9);
                        player.SetClothes(11, 228, 15);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][228], 0);
                        player.SetClothes(4, 87, 9);
                        player.SetClothes(6, 62, 6);
                        break;
                    case "army_12":
                        Customization.SetHat(player, 108, 14);
                        player.SetClothes(11, 222, 14);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][222], 0);
                        player.SetClothes(4, 86, 14);
                        player.SetClothes(6, 63, 0);
                        break;
                    case "army_13":
                        Customization.SetHat(player, 114, 15);
                        player.SetClothes(11, 221, 5);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][221], 0);
                        player.SetClothes(4, 87, 5);
                        player.SetClothes(6, 62, 0);
                        break;
                    case "army_14":
                        Customization.SetHat(player, 114, 15);
                        player.SetClothes(11, 220, 4);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][220], 0);
                        player.SetClothes(4, 87, 4);
                        player.SetClothes(6, 62, 0);
                        break;
                    case "army_15":
                        Customization.SetHat(player, 113, 5);
                        player.SetClothes(11, 222, 3);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][222], 0);
                        player.SetClothes(4, 87, 3);
                        player.SetClothes(6, 62, 6);
                        break;
                    case "mpolice_1": //Junior agent
                        Customization.SetHat(player, 103, 0);
                        player.SetClothes(9, 16, 0);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][222], 0);
                        player.SetClothes(11, 208, 0);
                        player.SetClothes(4, 87, 0);
                        player.SetClothes(6, 24, 0);
                        break;

                    case "mpolice_2": //Military police agent
                        Customization.SetHat(player, 106, 0);
                        player.SetClothes(9, 16, 0);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][222], 0);
                        player.SetClothes(11, 220, 0);
                        player.SetClothes(4, 86, 0);
                        player.SetClothes(6, 51, 0);
                        break;

                    case "mpolice_3": //Chief inspector
                        Customization.SetHat(player, 107, 0);
                        player.SetClothes(9, 16, 0);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][222], 0);
                        player.SetClothes(11, 221, 0);
                        player.SetClothes(4, 89, 0);
                        player.SetClothes(6, 51, 0);
                        break;
                    case "USMS": //USMS West
                        player.SetClothes(9, 18, 0); // Weste nicht weg machen AMK
                        player.SetClothes(0, 107, 0);
                        player.SetClothes(7, 173, 0);
                        break;
                }
            }
            else
            {
                switch (clothes)
                {
                    case "city_1":
                        player.SetClothes(11, 250, 2);
                        player.SetAccessories(1, 0, 1);
                        player.SetClothes(8, 159, 0);
                        player.SetClothes(6, 29, 0);
                        player.SetClothes(4, 64, 1);
                        player.SetClothes(3, 14, 0);
                        break;
                    case "city_2":
                        player.SetClothes(8, 24, 0);
                        player.SetClothes(11, 28, 10);
                        player.SetClothes(4, 36, 2);
                        player.SetClothes(6, 6, 0);
                        player.SetClothes(3, 0, 0);
                        break;
                    case "city_3":
                        player.SetClothes(11, 25, 7);
                        player.SetClothes(8, 67, 3);
                        player.SetClothes(4, 47, 0);
                        player.SetClothes(6, 6, 0);
                        player.SetClothes(3, 3, 0);
                        break;
                    case "city_4":
                        player.SetClothes(8, 35, 0);
                        player.SetClothes(11, 27, 0);
                        player.SetClothes(4, 64, 1);
                        player.SetClothes(6, 29, 0);
                        player.SetAccessories(1, 0, 1);
                        player.SetClothes(3, Customization.CorrectTorso[false][27], 0);
                        break;
                    case "city_5":
                        player.SetAccessories(1, 0, 1);
                        player.SetClothes(11, 7, 0);
                        player.SetClothes(8, 38, 0);
                        player.SetClothes(7, 21, 2);
                        player.SetClothes(1, 121, 0);
                        player.SetClothes(4, 6, 0);
                        player.SetClothes(6, 29, 0);
                        player.SetClothes(3, 3, 0);
                        break;
                    case "city_6":
                        player.SetAccessories(1, 0, 1);
                        player.SetClothes(11, 139, 0);
                        player.SetClothes(8, 38, 0);
                        player.SetClothes(7, 21, 2);
                        player.SetClothes(1, 121, 0);
                        player.SetClothes(4, 6, 0);
                        player.SetClothes(6, 29, 0);
                        player.SetClothes(3, Customization.CorrectTorso[false][139], 0);
                        break;
                    case "city_7":
                        player.SetClothes(11, 6, 0);
                        player.SetClothes(4, 6, 0);
                        player.SetClothes(6, 42, 0);
                        player.SetClothes(8, 20, 1);
                        player.SetClothes(7, 12, 0);
                        player.SetClothes(3, Customization.CorrectTorso[false][6], 0);
                        break;
                    case "city_8":
                        player.SetClothes(8, 41, 2);
                        player.SetClothes(11, 6, 2);
                        player.SetClothes(4, 6, 2);
                        player.SetClothes(6, 42, 2);
                        player.SetClothes(3, Customization.CorrectTorso[false][6], 0);
                        break;
                    case "city_9":
                        player.SetClothes(4, 50, 0);
                        player.SetClothes(11, 7, 1);
                        player.SetClothes(6, 0, 0);
                        player.SetClothes(8, 38, 0);
                        player.SetClothes(7, 22, 0);
                        player.SetClothes(3, Customization.CorrectTorso[false][6], 0);
                        break;
                    case "police_1":
                        player.SetClothes(11, 27, 1);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][27], 0);
                        player.SetClothes(4, 37, 0);
                        player.SetClothes(6, 29, 0);
                        player.SetClothes(8, 35, 0);
                        break;
                    case "police_2":
                        player.SetClothes(11, 48, 0);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][48], 0);
                        player.SetClothes(4, 37, 0);
                        player.SetClothes(6, 29, 0);
                        player.SetClothes(8, 35, 0);
                        player.SetClothes(10, 7, 1);
                        break;
                    case "police_3":
                        player.SetClothes(11, 48, 0);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][48], 0);
                        player.SetClothes(4, 37, 0);
                        player.SetClothes(6, 29, 0);
                        player.SetClothes(8, 35, 0);
                        player.SetClothes(10, 7, 2);
                        break;
                    case "police_4":
                        player.SetClothes(11, 46, 0);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][46], 0);
                        player.SetClothes(4, 32, 0);
                        player.SetClothes(6, 25, 0);
                        player.SetClothes(8, 152, 0);
                        //player.SetClothes(9, 9, 1); Убрал
                        player.SetClothes(7, 95, 0);
                        Customization.SetHat(player, 58, 2);
                        break;
                    case "police_5":
                        player.SetClothes(11, 27, 5);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][27], 0);
                        player.SetClothes(4, 37, 0);
                        player.SetClothes(6, 29, 0);
                        player.SetClothes(7, 95, 0);
                        player.SetClothes(8, 152, 0);
                        //player.SetClothes(9, 27, 9); Убрал
                        Customization.SetHat(player, 45, 0);
                        break;
                    case "police_6":
                        player.SetClothes(11, 27, 1);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][27], 0);
                        player.SetClothes(4, 37, 0);
                        player.SetClothes(6, 29, 0);
                        player.SetClothes(7, 95, 0);
                        player.SetClothes(8, 152, 0);
                        //player.SetClothes(9, 27, 9); Убрал
                        break;
                    case "police_7":
                        player.SetClothes(11, 27, 4);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][27], 0);
                        player.SetClothes(4, 37, 0);
                        player.SetClothes(6, 29, 0);
                        player.SetClothes(7, 95, 0);
                        player.SetClothes(8, 152, 0);
                        //player.SetClothes(9, 27, 9); Убрал
                        break;
                    case "police_8":
                        player.SetClothes(11, 27, 0);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][27], 0);
                        player.SetClothes(4, 37, 0);
                        player.SetClothes(6, 29, 0);
                        player.SetClothes(7, 95, 0);
                        player.SetClothes(8, 152, 0);
                        player.SetClothes(9, 27, 9);
                        break;
                    case "ems_1":
                        player.SetClothes(11, 73, 0);
                        player.SetClothes(4, 23, 3);
                        player.SetClothes(6, 1, 3);
                        player.SetClothes(3, 109, 0);
                        player.SetClothes(7, 97, 0);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][73], 0);
                        break;
                    case "ems_2":
                        player.SetClothes(11, 249, 1);
                        player.SetClothes(4, 23, 3);
                        player.SetClothes(6, 1, 3);
                        player.SetClothes(3, 109, 1);
                        player.SetClothes(7, 96, 0);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][249], 0);
                        break;
                    case "ems_3":
                        player.SetClothes(11, 249, 2);
                        player.SetClothes(4, 23, 0);
                        player.SetClothes(6, 1, 3);
                        player.SetClothes(3, 109, 0);
                        player.SetClothes(7, 96, 0);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][249], 0);
                        break;
                    case "ems_4":
                        player.SetClothes(11, 244, 4);
                        player.SetClothes(4, 23, 3);
                        player.SetClothes(6, 1, 3);
                        player.SetClothes(3, 93, 0);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][244], 0);
                        break;
                    case "army_1":
                        player.SetClothes(11, 212, 3);
                        player.SetClothes(4, 91, 3);
                        player.SetClothes(6, 65, 6);
                        player.SetClothes(8, 6, 0);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][212], 0);
                        break;
                    case "army_2":
                        player.SetClothes(11, 230, 3);
                        player.SetClothes(4, 89, 3);
                        player.SetClothes(6, 66, 6);
                        player.SetClothes(8, 6, 0);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][230], 0);
                        break;
                    case "army_3":
                        Customization.SetHat(player, 102, 3);
                        player.SetClothes(11, 230, 3);
                        player.SetClothes(4, 90, 3);
                        player.SetClothes(6, 65, 6);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][230], 0);
                        break;
                    case "army_4":
                        Customization.SetHat(player, 102, 3);
                        player.SetClothes(11, 232, 3);
                        player.SetClothes(4, 89, 3);
                        player.SetClothes(6, 66, 6);
                        player.SetClothes(8, 6, 0);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][232], 0);
                        break;
                    case "army_5":
                        Customization.SetHat(player, 106, 3);
                        player.SetClothes(11, 232, 3);
                        player.SetClothes(4, 90, 3);
                        player.SetClothes(6, 65, 6);
                        player.SetClothes(8, 6, 0);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][232], 0);
                        break;
                    case "army_6":
                        Customization.SetHat(player, 104, 3);
                        player.SetClothes(11, 231, 3);
                        player.SetClothes(4, 89, 3);
                        player.SetClothes(6, 66, 6);
                        player.SetClothes(8, 6, 0);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][231], 0);
                        break;
                    case "army_7":
                        Customization.SetHat(player, 106, 3);
                        player.SetClothes(11, 231, 0);
                        player.SetClothes(4, 90, 3);
                        player.SetClothes(6, 65, 6);
                        player.SetClothes(8, 6, 0);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][231], 0);
                        break;
                    case "army_8":
                        Customization.SetHat(player, 111, 11);
                        player.SetClothes(11, 226, 3);
                        player.SetClothes(4, 90, 3);
                        player.SetClothes(6, 65, 6);
                        player.SetClothes(8, 6, 0);
                        player.SetClothes(3, 4, 0);
                        break;
                    case "army_9":
                        Customization.SetHat(player, 105, 3);
                        player.SetClothes(11, 232, 3);
                        player.SetClothes(4, 89, 3);
                        player.SetClothes(6, 66, 6);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][232], 0);
                        break;
                    case "army_10":
                        Customization.SetHat(player, 105, 14);
                        player.SetClothes(11, 243, 7);
                        player.SetClothes(8, 141, 14);
                        player.SetClothes(4, 90, 14);
                        player.SetClothes(6, 65, 0);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][243], 0);
                        break;
                    case "army_11":
                        Customization.SetHat(player, 105, 9);
                        player.SetClothes(11, 238, 15);
                        player.SetClothes(4, 90, 9);
                        player.SetClothes(6, 65, 6);
                        player.SetClothes(8, 6, 0);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][238], 0);
                        break;
                    case "army_12":
                        Customization.SetHat(player, 107, 14);
                        player.SetClothes(11, 232, 14);
                        player.SetClothes(4, 89, 14);
                        player.SetClothes(6, 66, 0);
                        player.SetClothes(8, 6, 0);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][232], 0);
                        break;
                    case "army_13":
                        Customization.SetHat(player, 113, 15);
                        player.SetClothes(11, 231, 5);
                        player.SetClothes(4, 90, 5);
                        player.SetClothes(6, 65, 0);
                        player.SetClothes(8, 6, 0);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][231], 0);
                        break;
                    case "army_14":
                        Customization.SetHat(player, 113, 15);
                        player.SetClothes(11, 230, 4);
                        player.SetClothes(4, 90, 4);
                        player.SetClothes(6, 65, 0);
                        player.SetClothes(8, 6, 0);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][230], 0);
                        break;
                    case "army_15":
                        Customization.SetHat(player, 112, 5);
                        player.SetClothes(11, 232, 3);
                        player.SetClothes(4, 90, 3);
                        player.SetClothes(6, 65, 6);
                        player.SetClothes(8, 6, 0);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][232], 0);
                        break;
                    case "mpolice_1": //Junior agent
                        player.SetClothes(9, 16, 0);
                        player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][222], 0);
                        player.SetClothes(0, 103, 0);
                        player.SetClothes(11, 208, 0);
                        player.SetClothes(4, 87, 0);
                        player.SetClothes(6, 24, 0);
                        break;

                    /*  case "mpolice_2": //Military police agent
                          player.SetClothes(9, 16, 0);
                          player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][222], 0);
                          player.SetClothes(0, 106, 0);
                          player.SetClothes(11, 220, 0);
                          player.SetClothes(4, 86, 0);
                          player.SetClothes(6, 51, 0);
                          break;

                       case "mpolice_3": //Chief inspector
                          player.SetClothes(9, 16, 0);
                          player.SetClothes(3, Customization.CorrectTorso[Main.Players[player].Gender][222], 0);
                          player.SetClothes(0, 107, 0);
                          player.SetClothes(11, 221, 0);
                          player.SetClothes(4, 89, 0);
                          player.SetClothes(6, 51, 0);
                           break;
                      */
                    case "USMS": //USMS West
                        player.SetClothes(9, 18, 0); // Weste nicht weg machen AMK
                        player.SetClothes(0, 107, 0);
                        player.SetClothes(7, 173, 0);
                        break;
                }
            }

            if (player.HasData("HAND_MONEY")) player.SetClothes(5, 45, 0);
            else if (player.HasData("HEIST_DRILL")) player.SetClothes(5, 41, 0);
        }
        public static string getNickname(int fracID, int fracLvl)
        { // Only magic
            if (Configs.FractionRanks.ContainsKey(fracID) && Configs.FractionRanks[fracID].ContainsKey(fracLvl))
                return Configs.FractionRanks[fracID][fracLvl].Item1;
            return null;
        }

        public static Dictionary<Weapons.Hash, int> WeaponsMaxAmmo = new Dictionary<Weapons.Hash, int>()
        {
            { Weapons.Hash.Nightstick, 1 },
            { Weapons.Hash.Pistol, 12 },
            { Weapons.Hash.SMG, 30 },
            { Weapons.Hash.PumpShotgun, 8 },
            { Weapons.Hash.StunGun, 100 },
            { Weapons.Hash.Pistol50, 9 },
            { Weapons.Hash.CarbineRifle, 30 },
            { Weapons.Hash.SmokeGrenade, 1 },
            { Weapons.Hash.HeavyShotgun, 6 },
            { Weapons.Hash.Knife, 1 },
            { Weapons.Hash.SniperRifle, 10 },
            { Weapons.Hash.AssaultSMG, 30 },
            { Weapons.Hash.Gusenberg, 50 },
            { Weapons.Hash.CombatPistol, 10 },
            { Weapons.Hash.Revolver, 6 },
            { Weapons.Hash.HeavyPistol, 10 },
            { Weapons.Hash.SawnOffShotgun, 6 },
            { Weapons.Hash.BullpupShotgun, 10 },
            { Weapons.Hash.DoubleBarrelShotgun, 2 },
            { Weapons.Hash.MicroSMG, 15 },
            { Weapons.Hash.MachinePistol, 13 },
            { Weapons.Hash.CombatPDW, 30 },
            { Weapons.Hash.MiniSMG, 13 },
            { Weapons.Hash.SpecialCarbine, 30 },
            { Weapons.Hash.AssaultRifle, 30 },
            { Weapons.Hash.BullpupRifle, 30 },
            { Weapons.Hash.AdvancedRifle, 30 },
            { Weapons.Hash.CompactRifle, 30 },
            { Weapons.Hash.CombatMG, 100 },
        };

        public static void giveGun(Player player, Weapons.Hash gun, string weaponstr)
        {
            if (!Main.Players.ContainsKey(player) || !Stocks.fracStocks.ContainsKey(Main.Players[player].FractionID)) return;

            if (player.HasData($"GET_{gun.ToString()}") && DateTime.Now < player.GetData<DateTime>($"GET_{gun.ToString()}"))
            {
                DateTime date = player.GetData<DateTime>($"GET_{gun.ToString()}");
                DateTime g = new DateTime((date - DateTime.Now).Ticks);
                var min = g.Minute;
                var sec = g.Second;
                Notify.Send(player, NotifyType.Error, NotifyPosition.JobSms, $"Sie werden in der Lage sein {gun.ToString()} über {min}:{sec}", 3000);
                return;
            }

            var frac = Main.Players[player].FractionID;
            if (Configs.FractionWeapons[frac].ContainsKey(weaponstr) && Main.Players[player].FractionLVL < Configs.FractionWeapons[frac][weaponstr])
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.JobSms, $"Sie haben keinen Zugriff auf diesen Waffentyp", 3000);
                return;
            }
            if (Stocks.fracStocks[Main.Players[player].FractionID].Materials < matsForGun[gun])
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Es ist nicht genügend Material vorrätig", 3000);
                return;
            }

            var wType = (ItemType)Enum.Parse(typeof(ItemType), gun.ToString());
            if (nInventory.TryAdd(player, new nItem(wType)) == -1)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Nicht genug Platz im Inventar", 3000);
                return;
            }

            var serial = Weapons.GetSerial(true, Main.Players[player].FractionID);
            Weapons.GiveWeapon(player, wType, serial);

            Stocks.fracStocks[Main.Players[player].FractionID].Materials -= matsForGun[gun];
            Stocks.fracStocks[Main.Players[player].FractionID].UpdateLabel();

            var minutes = 5;
            if (Main.Players[player].FractionID == 7) minutes = 10;
            player.SetData($"GET_{gun.ToString()}", DateTime.Now.AddMinutes(minutes));

            GameLog.Stock(Main.Players[player].FractionID, Main.Players[player].UUID, $"{gun.ToString()}({serial})", 1, false);
            Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Sie haben {wType.ToString()}", 3000);
            return;
        }

        public static void giveAmmo(Player player, ItemType ammoType, int ammo)
        {
            if (!Main.Players.ContainsKey(player) || !Stocks.fracStocks.ContainsKey(Main.Players[player].FractionID)) return;

            if (Stocks.fracStocks[Main.Players[player].FractionID].Materials < MatsForAmmoType[ammoType] * ammo)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Es ist nicht genügend Material vorrätig", 3000);
                return;
            }

            var tryAdd = nInventory.TryAdd(player, new nItem(ammoType, ammo));
            if (tryAdd == -1 || tryAdd > 0)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Nicht genug Platz im Inventar", 3000);
                return;
            }

            Stocks.fracStocks[Main.Players[player].FractionID].Materials -= MatsForAmmoType[ammoType] * ammo;
            Stocks.fracStocks[Main.Players[player].FractionID].UpdateLabel();

            nInventory.Add(player, new nItem(ammoType, ammo));
            GameLog.Stock(Main.Players[player].FractionID, Main.Players[player].UUID, ammoType.ToString(), 1, false);
            Notify.Send(player, NotifyType.Info, NotifyPosition.JobSms, $"Sie haben {nInventory.ItemsNames[(int)ammoType]} x{ammo}", 3000);
            return;
        }

        public static void enterInterier(Player player, int fractionId)
        {
            var position = (fractionId <= 5) ? Gangs.ExitPoints[fractionId] : Mafia.ExitPoints[fractionId];
            player.Position = position + new Vector3(0, 0, 1.12);
            Main.PlayerEnterInterior(player, position + new Vector3(0, 0, 1.12));

            Trigger.ClientEvent(player, "stopTime");
        }

        public static void exitInterier(Player player, int fractionId)
        {
            var position = (fractionId <= 5) ? Gangs.EnterPoints[fractionId] : Mafia.EnterPoints[fractionId];
            player.Position = position + new Vector3(0, 0, 1.12);
            Main.PlayerEnterInterior(player, position + new Vector3(0, 0, 1.12));

            Trigger.ClientEvent(player, "resumeTime");
        }

        public class MemberData
        {
            public string Name { get; set; }
            public int FractionID { get; set; }
            public int FractionLVL { get; set; }
            public string inFracName { get; set; }
        }

        #region CraftMenu
        public static void OpenGunCraftMenu(Player player)
        {
            int fracid = Main.Players[player].FractionID;
            List<List<string>> list = null;

            if (FractionTypes[fracid] == -1 || FractionTypes[fracid] == 2)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Sie wissen nicht, wie man Waffen herstellt", 3000);
                return;
            }
            else if (FractionTypes[fracid] == 1) list = gangGuns;
            else if (FractionTypes[fracid] == 0) list = mafiaGuns;

            List<List<int>> prices = new List<List<int>>();
            for (int i = 0; i < list.Count; i++)
            {
                List<int> p = new List<int>();
                foreach (string g in list[i])
                {
                    p.Add(matsForGun[Weapons.GetHash(g)]);
                }
                prices.Add(p);
            }
            string json = JsonConvert.SerializeObject(prices);
            Log.Debug(json);
            Trigger.ClientEvent(player, "openWCraft", fracid, json);
        }
        [RemoteEvent("wcraft")]
        public static void Event_WCraft(Player Player, int frac, int cat, int index)
        {
            int where = -1;
            try
            {
                Log.Debug($"{frac.ToString()}:{cat.ToString()}:{index.ToString()}");
                List<List<string>> list = null;
                if (FractionTypes[frac] == 1) list = gangGuns;
                else if (FractionTypes[frac] == 0) list = mafiaGuns;
                if (list.Count < 1 || list.Count < cat + 1 || list[cat].Count < index + 1) return;

                string selected = list[cat][index];
                if (FractionTypes[frac] == -1 || FractionTypes[frac] == 2)
                {
                    Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, "Sie wissen nicht, wie man Waffen herstellt", 3000);
                    return;
                }
                var mItem = nInventory.Find(Main.Players[Player].UUID, ItemType.Material);
                var count = (mItem == null) ? 0 : mItem.Count;
                if (count < matsForGun[Weapons.GetHash(selected)])
                {
                    Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, "Sie haben nicht genug Material", 3000);
                    return;
                }

                var wType = (ItemType)Enum.Parse(typeof(ItemType), selected);
                var tryAdd = nInventory.TryAdd(Player, new nItem(wType, 1));
                if (tryAdd == -1 || tryAdd > 0)
                {
                    Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, "Nicht genug Platz im Inventar", 3000);
                    return;
                }

                nInventory.Remove(Player, ItemType.Material, matsForGun[Weapons.GetHash(selected)]);
                if (selected == "BodyArmor") //Добавил
                    nInventory.Add(Player, new nItem(ItemType.BodyArmor, 1, $"50")); //Добавил
                else // Добавил
                    Weapons.GiveWeapon(Player, wType, Weapons.GetSerial(true, frac));


                Notify.Send(Player, NotifyType.Info, NotifyPosition.MapUp, $"Sie fertigten {selected} für {matsForGun[Weapons.GetHash(selected)]} matov", 3000);
            }
            catch (Exception e)
            {
                Log.Write($"Event_WCraft/{where}/{frac}/{cat}/{index}/: \n{e.ToString()}", nLog.Type.Error);
            }
        }
        [RemoteEvent("wcraftammo")]
        public static void Event_WCraftAmmo(Player player, int frac, string text1, string text2)
        {
            try
            {
                if (!Main.Players.ContainsKey(player)) return;

                if (FractionTypes[frac] != 0 && FractionTypes[frac] != 1) return;

                var category = Convert.ToInt32(text1.Replace("wcraftslider", null));
                var mats = Convert.ToInt32(text2.Trim('M'));
                var ammo = mats / MatsForAmmo[category];

                if (ammo == 0)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie haben die Anzahl der Runden nicht angegeben", 3000);
                    return;
                }

                var matsItem = nInventory.Find(Main.Players[player].UUID, ItemType.Material);
                var matsCount = (matsItem == null) ? 0 : matsItem.Count;
                if (matsCount < MatsForAmmo[category] * ammo)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie haben nicht genügend Materialien", 3000);
                    return;
                }

                var tryAdd = nInventory.TryAdd(player, new nItem(AmmoTypes[category], ammo));
                if (tryAdd == -1 || tryAdd > 0)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Nicht genug Platz im Inventar", 3000);
                    return;
                }

                nInventory.Remove(player, ItemType.Material, MatsForAmmo[category] * ammo);
                nInventory.Add(player, new nItem(AmmoTypes[category], ammo));
                Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Sie haben erfolgreich gearbeitet {nInventory.ItemsNames[(int)AmmoTypes[category]]} x{ammo}", 3000);
            }
            catch (Exception e) { Log.Write(e.ToString(), nLog.Type.Error); }
        }
        private static Dictionary<ItemType, int> MatsForAmmoType = new Dictionary<ItemType, int>()
        {
            { ItemType.PistolAmmo, 1 },
            { ItemType.ShotgunsAmmo, 4 },
            { ItemType.SMGAmmo, 2 },
            { ItemType.RiflesAmmo, 4 },
            { ItemType.SniperAmmo, 10 },
        };
        private static List<int> MatsForAmmo = new List<int>()
        {
            1, // pistol
            4, // shotgun
            2, // smg
            4, // rifles
        };
        private static List<ItemType> AmmoTypes = new List<ItemType>()
        {
            ItemType.PistolAmmo,
            ItemType.ShotgunsAmmo,
            ItemType.SMGAmmo,
            ItemType.RiflesAmmo,
        };
        #endregion

        [RemoteEvent("setmembers")]
        public static void SetMembersToMenu(Player player)
        {
            try
            {
                Character acc = Main.Players[player];
                if (acc.FractionID == 0) return;
                List<List<object>> people = new List<List<object>>();

                var count = 0;
                var on = 0;
                var off = 0;

                for (int i = 0; i < AllMembers.Count; i++)
                {
                    if (i >= AllMembers.Count) break;
                    var member = AllMembers[i];
                    if (member.FractionID != acc.FractionID) continue;
                    count++;
                    bool online = false;
                    string id = "-";
                    if (Members.Values.FirstOrDefault(m => m.Name == member.Name) != null)
                    {
                        id = NAPI.Player.GetPlayerFromName(member.Name).Value.ToString();
                        online = true;
                        on++;
                    }
                    else
                        off++;
                    List<object> data = new List<object>
                    {
                        online,
                        id,
                        member.Name,
                        "-",
                        member.FractionLVL,
                    };
                    people.Add(data);
                }
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(people);
                Trigger.ClientEvent(player, "setmem", json, count, on, off);
            }
            catch (Exception e) { Log.Write("EXCEPTION AT \"SETMEMBERS\":\n" + e.ToString(), nLog.Type.Error); }
        }
        [RemoteEvent("openfmenu")]
        public static void OpenFractionMenu(Player player)
        {
            try
            {
                SetMembersToMenu(player);
                Trigger.ClientEvent(player, "openfm");
            }
            catch (Exception e) { Log.Write("EXCEPTION AT \"OPENFMENU\":\n" + e.ToString(), nLog.Type.Error); }
        }

        [RemoteEvent("tablet:request")]
        public static void tabletrequest(Player player)
        {
            if (Main.Players[player].FractionID == 7 || Main.Players[player].FractionID == 8 || Main.Players[player].FractionID == 18)
            {
                Trigger.ClientEvent(player, "fraktablet");
            }
            else
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du bist nicht berechtigt das Fraktionstablet aufzurufen!", 3000);

            }
            //catch (Exception e) { Log.Write("EXCEPTION AT \"OPENFMENU\":\n" + e.ToString(), nLog.Type.Error); }
        }

        [RemoteEvent("fmenu")]
        public static void callback_FracMenu(Player player, params object[] args)
        {
            try
            {
                int act = Convert.ToInt32(args[0]);
                string data1 = Convert.ToString(args[1]);
                string data2 = Convert.ToString(args[2]);
                int rank;
                int id;
                switch (act)
                {
                    case 2: //invite
                        if (Int32.TryParse(data1, out id))
                        {
                            Player target = Main.GetPlayerByID(id);
                            if (target == null)
                            {
                                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Spieler mit dieser ID wird nicht gefunden", 3000);
                                return;
                            }
                            FractionCommands.InviteToFraction(player, target);
                        }
                        else
                        {
                            Player target = NAPI.Player.GetPlayerFromName(data1);
                            if (target == null)
                            {
                                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Es wurde kein Spieler mit diesem Namen gefunden", 3000);
                                return;
                            }
                            FractionCommands.InviteToFraction(player, target);
                        }
                        break;
                    case 3: //kick
                        if (Int32.TryParse(data1, out id))
                        {
                            Player target = Main.GetPlayerByID(id);
                            if (target == null)
                            {
                                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Spieler mit dieser ID wird nicht gefunden", 3000);
                                return;
                            }
                            FractionCommands.UnInviteFromFraction(player, target);
                        }
                        else
                        {
                            if (!Main.PlayerNames.ContainsValue(data1))
                            {
                                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Es wurde kein Spieler mit diesem Namen gefunden", 3000);
                                return;
                            }
                            Player target = NAPI.Player.GetPlayerFromName(data1);
                            if (target == null)
                            {
                                if (!Manager.canUseCommand(player, "uninvite")) return;

                                int targetLvl = 0;
                                int targetFrac = 0;

                                var split = data1.Split('_');
                                var result = MySQL.QueryRead($"SELECT fraction,fractionlvl FROM characters WHERE firstname='{split[0]}' AND lastname='{split[1]}'");
                                if (result == null || result.Rows.Count == 0) return;
                                foreach (DataRow Row in result.Rows)
                                {
                                    targetFrac = Convert.ToInt32(Row["fraction"].ToString());
                                    targetLvl = Convert.ToInt32(Row["fractionlvl"].ToString());
                                }

                                if (targetFrac != Main.Players[player].FractionID)
                                {
                                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler ist nicht in Ihrer Fraktion", 3000);
                                    return;
                                }
                                if (targetLvl >= Main.Players[player].FractionLVL)
                                {
                                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie können diesen Spieler nicht entlassen", 3000);
                                    return;
                                }
                                MySQL.Query($"UPDATE `characters` SET fraction=0,fractionlvl=0 WHERE firstname='{split[0]}' AND lastname='{split[1]}'");
                                Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Sie haben einen Spieler gefeuert {data1} von Ihrer Fraktion", 3000);

                                int index = Fractions.Manager.AllMembers.FindIndex(m => m.Name == data1);
                                if (index > -1) Manager.AllMembers.RemoveAt(index);
                                return;
                            }
                            else
                                FractionCommands.UnInviteFromFraction(player, target);
                        }
                        break;
                    case 4: //change
                        if (!Int32.TryParse(data2, out rank))
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Richtige Daten eingeben", 3000);
                            return;
                        }
                        if (Int32.TryParse(data1, out id))
                        {
                            Player target = Main.GetPlayerByID(id);
                            if (target == null)
                            {
                                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Spieler mit dieser ID wird nicht gefunden", 3000);
                                return;
                            }
                            FractionCommands.SetFracRank(player, target, rank);
                        }
                        else
                        {
                            Player target = NAPI.Player.GetPlayerFromName(data1);
                            if (target == null)
                            {
                                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Es wurde kein Spieler mit diesem Namen gefunden", 3000);
                                return;
                            }
                            FractionCommands.SetFracRank(player, target, rank);
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                Log.Write("EXCEPTION AT \"FRACMENU\":\n" + e.ToString(), nLog.Type.Error);
            }
        }
    }

    class Stocks : Script
    {
        private static nLog Log = new nLog("Stocks");

        public static Dictionary<int, FractionStock> fracStocks = new Dictionary<int, FractionStock>();
        private static Dictionary<int, Vector3> stockCoords = new Dictionary<int, Vector3>()
        {
            { 1, new Vector3(-205.1935, -1615.512, -34.69367)},
            { 2, new Vector3(79.17244, -1966.011, -28.41237)},
            { 3, new Vector3(1424.026, -1488.611, -104.3677)},
            { 4, new Vector3(902.0025, -2155.1345, 32.36387)}, //marabunta Stock
            { 5, new Vector3(486.7317, -1527.169, -33.2506)},
            { 6, new Vector3()},
            { 7, new Vector3()},
            { 8, new Vector3()},
            { 9, new Vector3()},
            { 10, new Vector3(1405.4686, 1137.8661, 108.625694)}, //+
            { 11, new Vector3(-1495.9082, 845.40234, 180.43092)}, //+
            { 12, new Vector3(-1204.9156, 296.07962, 68.60236)}, //+
            { 13, new Vector3(-1808.541, 459.8595, -189.8455)},
            { 14, new Vector3()},
            { 15, new Vector3()},
            { 16, new Vector3(976.768738, -103.651985, 73.725174)},
            { 17, new Vector3(2040.175, 3018.278, -73.82208)},
            { 18, new Vector3(854.3138, -1318.539, 24.322002) },
            { 19, TuningMan.FractionStock},  //Tuning
            { 20, new Vector3(0.905387, -1663.9572, 29.48)},  //Tuning
        };
        private static Dictionary<int, Vector3> garageCoords = new Dictionary<int, Vector3>()
        {
            { 1, new Vector3(-77.7783, -1392.065, 28.20077)}, //Територрия зеленых (колшейп) сдача материалов
            { 2, new Vector3(85.16203, -1972.12, 18.78526)}, //Територрия фиолетовых (колшейп) сдача материалов
            { 3, new Vector3(1372.121, -1519.864, 56.35062)}, //Територрия желтых (колшейп) сдача материалов
            { 4, new Vector3(873.6498, -2197.615, 28.51937)}, //Територрия синих (колшейп) сдача материалов
            { 5, new Vector3(484.1238, -1527.802, 28.18009)}, //Територрия красных (колшейп) сдача материалов
            { 6, new Vector3(-580.291, -130.4515, 34.00952)}, //Мерия (колшейп) сдача материалов
            { 7, new Vector3(463.9062, -1014.959, 26.21062)}, //LSPD (колшейп) сдача материалов
            { 8, new Vector3(341.9803, -562.6921, 27.62378)}, //Медики (колшейп) сдача материалов
            { 9, new Vector3(89.61347, -726.3861, 32.01329)}, //FIB (колшейп) сдача материалов
            { 10, new Vector3(1413.687, 1118.036, 112.838)}, //Мафия La Cosa Nostra (колшейп) сдача материалов
            { 11, new Vector3(-1539.3055, 850.5986, 180.68665)}, //Мафия Русская (колшейп) сдача материалов
            { 12, new Vector3(-1202.0913, 267.96146, 68.40702)}, //Мафия Картель (колшейп) сдача материалов
            { 13, new Vector3(-1793.165, 404.6401, 111.1755)}, //Мафия Армянская (колшейп) сдача материалов
            { 14, new Vector3(-2455.718, 2984.414, 31.81033)}, //Армия (колшейп) сдача материалов
            { 15, new Vector3()},
            { 16, new Vector3(986.1573, -138.6537, 71.97079)}, //Мафия the Lost (колшейп) сдача материалов
            { 17, new Vector3(1551.65, 2152.611, 77.78671)}, //Marry Weather (колшейп) сдача материалов
            { 18, new Vector3(855.5311, -1302.950, 20.820345) },
            { 19, TuningMan.FractionGarage},
            { 20, new Vector3() },
        };
        public static Dictionary<string, int> maxMats = new Dictionary<string, int>()
        {
            { "", 300 },
            { "BARRACKS", 50000 }, //Написал тупо с большими BARRACKS
            { "BURRITO", 15000 },
            { "YOUGA", 15000 },
            { "YOUGA2", 15000 },
        };

        [ServerEvent(Event.ResourceStart)]
        public void FillStocks()
        {
            try
            {
                var result = MySQL.QueryRead("SELECT * FROM fractions");
                if (result == null || result.Rows.Count == 0)
                {
                    Log.Write("Table 'fractions' returns null result", nLog.Type.Warn);
                    return;
                }
                foreach (DataRow Row in result.Rows)
                {
                    var data = new FractionStock();
                    data.Drugs = Convert.ToInt32(Row["drugs"]);
                    data.Money = Convert.ToInt32(Row["money"]);
                    data.Materials = Convert.ToInt32(Row["mats"]);
                    data.Medkits = Convert.ToInt32(Row["medkits"]);
                    data.Weapons = JsonConvert.DeserializeObject<List<nItem>>(Row["weapons"].ToString());
                    data.IsOpen = Convert.ToBoolean(Row["isopen"]);
                    data.FuelLimit = Convert.ToInt32(Row["fuellimit"]);
                    data.FuelLeft = Convert.ToInt32(Row["fuelleft"]);
                    var id = Convert.ToInt32(Row["id"]);
                    Weapons.FractionsLastSerial[id] = Convert.ToInt32(Row["lastserial"]);

                    #region label Creating
                    if (garageCoords.ContainsKey(id))
                    {
                        data.label = NAPI.TextLabel.CreateTextLabel("", garageCoords[id] + new Vector3(0, 0, 1.5), 10f, 0.4f, 0, new Color(255, 255, 255), true); //~g~
                        if (id == 14) data.maxMats = 250000;
                        else data.maxMats = 50000;
                        data.UpdateLabel();
                    }

                    #endregion
                    fracStocks.Add(id, data);

                    var colshape = NAPI.ColShape.CreateCylinderColShape(stockCoords[id], 1, 2, 0); // stock colshape
                    colshape.SetData("FRACID", id);
                    colshape.OnEntityEnterColShape += enterStockShape;
                    colshape.OnEntityExitColShape += exitStockShape;
                    NAPI.Marker.CreateMarker(1, stockCoords[id] - new Vector3(0, 0, 0.7), new Vector3(), new Vector3(), 1f, new Color(155, 140, 120, 220));
                    NAPI.TextLabel.CreateTextLabel(Main.StringToU16($""), new Vector3(stockCoords[id].X, stockCoords[id].Y, stockCoords[id].Z + 0.6), 5F, 0.5F, 0, new Color(255, 255, 255)); //~g~Stock of {Manager.getName(id)}

                    colshape = NAPI.ColShape.CreateCylinderColShape(garageCoords[id], 5, 8, 0); // garage colshape
                    colshape.SetData("FRACID", id);
                    colshape.OnEntityEnterColShape += enterGarageShape;
                    colshape.OnEntityExitColShape += exitGarageShape;
                    NAPI.Marker.CreateMarker(1, garageCoords[id], new Vector3(), new Vector3(), 3f, new Color(155, 0, 0));
                }
            }
            catch (Exception e) { Log.Write("ResourceStart: " + e.Message, nLog.Type.Error); }
        }

        #region stocks colshape
        private static void enterGarageShape(ColShape shape, Player entity)
        {
            try
            {
                entity.SetData("INTERACTIONCHECK", 32);
                entity.SetData("ONFRACSTOCK", shape.GetData<object>("FRACID"));
                entity.TriggerEvent("interactHint", true);
            }
            catch (Exception ex) { Log.Write("enterGarageShape: " + ex.Message, nLog.Type.Error); }
        }

        private static void exitGarageShape(ColShape shape, Player entity)
        {
            try
            {
                entity.SetData("INTERACTIONCHECK", 0);
                entity.SetData("ONFRACSTOCK", 0);
                entity.TriggerEvent("interactHint", false);
            }
            catch (Exception ex) { Log.Write("exitGarageShape: " + ex.Message, nLog.Type.Error); }
        }

        private static void enterStockShape(ColShape shape, Player entity)
        {
            try
            {
                entity.SetData("INTERACTIONCHECK", 33);
                entity.SetData("ONFRACSTOCK", shape.GetData<object>("FRACID"));
                entity.TriggerEvent("interactHint", true);
            }
            catch (Exception ex) { Log.Write("enterStockShape: " + ex.Message, nLog.Type.Error); }
        }

        private static void exitStockShape(ColShape shape, Player entity)
        {
            try
            {
                entity.SetData("INTERACTIONCHECK", 0);
                entity.SetData("ONFRACSTOCK", 0);
                entity.TriggerEvent("interactHint", false);
            }
            catch (Exception ex) { Log.Write("exitStockShape: " + ex.Message, nLog.Type.Error); }
        }
        #endregion

        public static int TryAdd(int fraction, nItem item)
        {
            List<nItem> items = fracStocks[fraction].Weapons;

            var tail = 0;
            if (nInventory.ClothesItems.Contains(item.Type) || nInventory.WeaponsItems.Contains(item.Type) || nInventory.MeleeWeaponsItems.Contains(item.Type))
            {
                if (items.Count >= 200) return -1;
            }
            else
            {
                var count = 0;
                foreach (var i in items)
                    if (i.Type == item.Type) count += nInventory.ItemsStacks[i.Type] - i.Count;

                var slots = 200;
                var maxCapacity = (slots - items.Count) * nInventory.ItemsStacks[item.Type] + count;
                if (item.Count > maxCapacity) tail = item.Count - maxCapacity;
            }
            return tail;
        }
        public static void Add(int fraction, nItem item)
        {
            List<nItem> items = fracStocks[fraction].Weapons;

            if (nInventory.WeaponsItems.Contains(item.Type) || nInventory.MeleeWeaponsItems.Contains(item.Type))
            {
                items.Add(item);
            }
            else
            {
                var count = item.Count;
                for (int i = 0; i < items.Count; i++)
                {
                    if (i >= items.Count) break;
                    if (items[i].Type == item.Type && items[i].Count < nInventory.ItemsStacks[item.Type])
                    {
                        var temp = nInventory.ItemsStacks[item.Type] - items[i].Count;
                        if (count < temp) temp = count;
                        items[i].Count += temp;
                        count -= temp;
                    }
                }

                while (count > 0)
                {
                    if (count >= nInventory.ItemsStacks[item.Type])
                    {
                        items.Add(new nItem(item.Type, nInventory.ItemsStacks[item.Type], item.Data));
                        count -= nInventory.ItemsStacks[item.Type];
                    }
                    else
                    {
                        items.Add(new nItem(item.Type, count, item.Data));
                        count = 0;
                    }
                }
            }

            fracStocks[fraction].Weapons = items;
            foreach (var p in Main.Players.Keys.ToList())
            {
                if (p == null || !Main.Players.ContainsKey(p)) continue;
                if (p.HasData("OPENOUT_TYPE") && p.GetData<int>("OPENOUT_TYPE") == 6 && p.HasData("ONFRACSTOCK") && p.GetData<int>("ONFRACSTOCK") == fraction) Dashboard.OpenOut(p, fracStocks[fraction].Weapons, "Склад оружия", 6);
            }
        }
        public static void Remove(int fraction, nItem item)
        {
            List<nItem> items = fracStocks[fraction].Weapons;

            if (nInventory.ClothesItems.Contains(item.Type) || nInventory.WeaponsItems.Contains(item.Type) || nInventory.MeleeWeaponsItems.Contains(item.Type)
                || item.Type == ItemType.BagWithDrill || item.Type == ItemType.BagWithMoney || item.Type == ItemType.CarKey)
            {
                items.Remove(item);
            }
            else
            {
                for (int i = items.Count - 1; i >= 0; i--)
                {
                    if (i >= items.Count) continue;
                    if (items[i].Type != item.Type) continue;
                    if (items[i].Count <= item.Count)
                    {
                        item.Count -= items[i].Count;
                        items.RemoveAt(i);
                    }
                    else
                    {
                        items[i].Count -= item.Count;
                        item.Count = 0;
                        break;
                    }
                }
            }

            fracStocks[fraction].Weapons = items;
            foreach (var p in Main.Players.Keys.ToList())
            {
                if (p == null || !Main.Players.ContainsKey(p)) continue;
                if (p.HasData("OPENOUT_TYPE") && p.GetData<int>("OPENOUT_TYPE") == 6 && p.HasData("ONFRACSTOCK") && p.GetData<int>("ONFRACSTOCK") == fraction) Dashboard.OpenOut(p, fracStocks[fraction].Weapons, "Склад оружия", 6);
            }
        }
        public static int GetCountOfType(int fraction, ItemType type)
        {
            List<nItem> items = fracStocks[fraction].Weapons;
            var count = 0;

            for (int i = 0; i < items.Count; i++)
            {
                if (i >= items.Count) break;
                if (items[i].Type == type) count += items[i].Count;
            }

            return count;
        }
        public static void inputStocks(Player player, int where, string action, int amount)
        {
            // where (0 - stock, 1 - garage)
            if (where == 0)
            {
                switch (action)
                {
                    case "put_stock":
                        var item = player.GetData<string>("selectedStock");
                        var data = fracStocks[Main.Players[player].FractionID];
                        int stockContains = 0;
                        int playerHave = 0;

                        if (item == "mats")
                        {
                            stockContains = data.Materials;
                            var maxstock = 50000;
                            if (Main.Players[player].FractionID == 14) maxstock = 250000;
                            if (stockContains + amount > maxstock)
                            {
                                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Das Lager kann nicht so viel Material aufnehmen", 3000);
                                return;
                            }
                            playerHave = (nInventory.Find(Main.Players[player].UUID, ItemType.Material) == null) ? 0 : nInventory.Find(Main.Players[player].UUID, ItemType.Material).Count;
                        }
                        else if (item == "drugs")
                        {
                            stockContains = data.Drugs;
                            if (stockContains + amount > 10000)
                            {
                                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Das Lager kann nicht so viele Medikamente aufnehmen", 3000);
                                return;
                            }
                            playerHave = (nInventory.Find(Main.Players[player].UUID, ItemType.Drugs) == null) ? 0 : nInventory.Find(Main.Players[player].UUID, ItemType.Drugs).Count;
                        }
                        else if (item == "money")
                        {
                            stockContains = data.Money;
                            playerHave = (int)Main.Players[player].Money;
                        }
                        else if (item == "medkits")
                        {
                            stockContains = data.Medkits;
                            var invitem = nInventory.Find(Main.Players[player].UUID, ItemType.HealthKit);
                            if (invitem == null) playerHave = 0;
                            else playerHave += invitem.Count;
                        }

                        if (playerHave < amount)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie haben nicht so viel", 3000);
                            return;
                        }

                        if (item == "mats")
                        {
                            data.Materials += amount;
                            nInventory.Remove(player, ItemType.Material, amount);
                        }
                        else if (item == "drugs")
                        {
                            data.Drugs += amount;
                            nInventory.Remove(player, ItemType.Drugs, amount);
                        }
                        else if (item == "money")
                        {
                            data.Money += amount;
                            MoneySystem.Wallet.Change(player, -amount);
                            GameLog.Money($"player({Main.Players[player].UUID})", $"frac({Main.Players[player].FractionID})", amount, $"putStock");
                        }
                        else if (item == "medkits")
                        {
                            data.Medkits += amount;
                            nInventory.Remove(player, ItemType.HealthKit, amount);
                        }
                        GameLog.Stock(Main.Players[player].FractionID, Main.Players[player].UUID, item, amount, true);
                        Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Es sind noch welche im Lager vorhanden {stockContains + amount}, Sie haben {playerHave - amount}", 3000);
                        data.UpdateLabel();
                        break;
                    case "take_stock":
                        item = player.GetData<string>("selectedStock");
                        if (!Manager.canUseCommand(player, $"take{item}")) return;

                        data = fracStocks[Main.Players[player].FractionID];
                        stockContains = 0;
                        playerHave = 0;
                        if (item == "mats")
                        {
                            stockContains = data.Materials;
                            playerHave = (nInventory.Find(Main.Players[player].UUID, ItemType.Material) == null) ? 0 : nInventory.Find(Main.Players[player].UUID, ItemType.Material).Count;
                            if (playerHave + amount > 300)
                            {
                                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie können nicht so viel in Ihr Inventar aufnehmen", 3000);
                                return;
                            }
                        }
                        else if (item == "drugs")
                        {
                            stockContains = data.Drugs;
                            playerHave = (nInventory.Find(Main.Players[player].UUID, ItemType.Drugs) == null) ? 0 : nInventory.Find(Main.Players[player].UUID, ItemType.Drugs).Count;
                            if (playerHave + amount > 50)
                            {
                                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie können nicht so viel in Ihr Inventar aufnehmen", 3000);
                                return;
                            }
                        }
                        else if (item == "money")
                        {
                            stockContains = data.Money;
                            playerHave = (int)Main.Players[player].Money;
                        }
                        else if (item == "medkits")
                        {
                            stockContains = data.Medkits;
                            var invitem = nInventory.Find(Main.Players[player].UUID, ItemType.HealthKit);
                            if (invitem == null) playerHave = 0;
                            else playerHave += invitem.Count;
                        }

                        if (stockContains < amount)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Wir haben nicht so viel vorrätig.", 3000);
                            return;
                        }

                        if (item == "mats")
                        {
                            var tryAdd = nInventory.TryAdd(player, new nItem(ItemType.Material, amount));
                            if (tryAdd == -1 || tryAdd > 0)
                            {
                                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Nicht genug Platz im Inventar", 3000);
                                return;
                            }
                            data.Materials -= amount;
                            nInventory.Add(player, new nItem(ItemType.Material, amount));
                        }
                        else if (item == "drugs")
                        {
                            var tryAdd = nInventory.TryAdd(player, new nItem(ItemType.Drugs, amount));
                            if (tryAdd == -1 || tryAdd > 0)
                            {
                                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Nicht genug Platz im Inventar", 3000);
                                return;
                            }
                            data.Drugs -= amount;
                            nInventory.Add(player, new nItem(ItemType.Drugs, amount));
                        }
                        else if (item == "money")
                        {
                            data.Money -= amount;
                            MoneySystem.Wallet.Change(player, amount);
                            GameLog.Money($"frac({Main.Players[player].FractionID})", $"player({Main.Players[player].UUID})", amount, $"takeStock");
                        }
                        else if (item == "medkits")
                        {
                            var tryAdd = nInventory.TryAdd(player, new nItem(ItemType.HealthKit, amount));
                            if (tryAdd == -1 || tryAdd > 0)
                            {
                                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Nicht genug Platz im Inventar", 3000);
                                return;
                            }
                            data.Medkits -= amount;
                            nInventory.Add(player, new nItem(ItemType.HealthKit, amount));
                        }
                        GameLog.Stock(Main.Players[player].FractionID, Main.Players[player].UUID, item, amount, false);
                        Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Es sind noch welche im Lager vorhanden {stockContains - amount}, Sie haben {playerHave + amount}", 3000);
                        data.UpdateLabel();
                        break;
                }
            }
            else
            {
                if (!player.IsInVehicle)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie müssen im Auto sein", 3000);
                    return;
                }
                var vehicle = player.Vehicle;
                if (!vehicle.HasData("CANMATS") && !vehicle.HasData("CANDRUGS") && !vehicle.HasData("CANMEDKITS"))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Das Auto kann nichts transportieren", 3000);
                    return;
                }
                int onfrac = player.GetData<int>("ONFRACSTOCK");
                switch (action)
                {
                    case "load_mats":
                        if (onfrac != 14 && Main.Players[player].FractionID != onfrac)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie sind kein Mitglied {Fractions.Manager.getName(player.GetData<int>("ONFRACSTOCK"))}", 3000);
                            return;
                        }
                        if (onfrac != 14 && !Manager.canUseCommand(player, "takestock")) return;
                        if (fracStocks[onfrac].Materials < amount)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Wir haben nicht so viele Matten vorrätig.", 3000);
                            return;
                        }
                        var maxMats = (Fractions.Stocks.maxMats.ContainsKey(vehicle.DisplayName)) ? Fractions.Stocks.maxMats[vehicle.DisplayName] : 600;
                        if (VehicleInventory.GetCountOfType(vehicle, ItemType.Material) + amount > maxMats)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Es ist unmöglich, so viele Matten hochzuladen.", 3000);
                            return;
                        }
                        var tryAdd = VehicleInventory.TryAdd(vehicle, new nItem(ItemType.Material, amount));
                        if (tryAdd == -1 || tryAdd > 0)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Es ist unmöglich, so viele Matten hochzuladen.", 3000);
                            return;
                        }
                        var data = new nItem(ItemType.Material);
                        data.Count = amount;
                        VehicleInventory.Add(vehicle, data);
                        fracStocks[onfrac].Materials -= amount;
                        Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Sie haben die Materialien in die Maschine geladen", 3000);
                        fracStocks[onfrac].UpdateLabel();
                        GameLog.Stock(Main.Players[player].FractionID, Main.Players[player].UUID, "mats", amount, false);
                        return;
                    case "unload_mats":
                        var count = VehicleInventory.GetCountOfType(vehicle, ItemType.Material);
                        if (count < amount)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Es gibt nicht viele Schimpfwörter im Auto.", 3000);
                            return;
                        }
                        var maxstock = 50000;
                        if (onfrac == 14) maxstock = 250000;
                        if (fracStocks[onfrac].Materials + amount > maxstock)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Das Lager kann nicht so viel Material aufnehmen", 3000);
                            return;
                        }
                        VehicleInventory.Remove(vehicle, ItemType.Material, amount);
                        fracStocks[onfrac].Materials += amount;
                        Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Sie haben die Materialien aus der Maschine entladen", 3000);
                        fracStocks[onfrac].UpdateLabel();
                        GameLog.Stock(Main.Players[player].FractionID, Main.Players[player].UUID, "mats", amount, true);
                        return;
                    case "load_drugs":
                        if (Main.Players[player].FractionID != onfrac)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie sind kein Mitglied ~y~{Fractions.Manager.getName(player.GetData<int>("ONFRACSTOCK"))}", 3000);
                            return;
                        }
                        if (!Manager.canUseCommand(player, "takestock")) return;
                        if (fracStocks[onfrac].Drugs < amount)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Wir haben nicht so viele Medikamente vorrätig", 3000);
                            return;
                        }
                        tryAdd = VehicleInventory.TryAdd(vehicle, new nItem(ItemType.Drugs, amount));
                        if (tryAdd == -1 || tryAdd > 0)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Es ist unmöglich, so viele Medikamente hochzuladen", 3000);
                            return;
                        }
                        data = new nItem(ItemType.Drugs);
                        data.Count = amount;
                        VehicleInventory.Add(vehicle, data);
                        fracStocks[onfrac].Drugs -= amount;
                        Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Sie haben die Drogen in das Auto geladen", 3000);
                        fracStocks[onfrac].UpdateLabel();
                        GameLog.Stock(Main.Players[player].FractionID, Main.Players[player].UUID, "drugs", amount, false);
                        return;
                    case "unload_drugs":
                        count = VehicleInventory.GetCountOfType(vehicle, ItemType.Drugs);
                        if (count < amount)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Es sind nicht so viele Drogen im Auto", 3000);
                            return;
                        }
                        if (fracStocks[onfrac].Drugs + amount > 10000)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Das Lager kann nicht so viele Medikamente aufnehmen", 3000);
                            return;
                        }
                        VehicleInventory.Remove(vehicle, ItemType.Drugs, amount);
                        fracStocks[onfrac].Drugs += amount;
                        Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Sie haben die Drogen aus dem Auto abgeladen", 3000);
                        fracStocks[onfrac].UpdateLabel();
                        GameLog.Stock(Main.Players[player].FractionID, Main.Players[player].UUID, "drugs", amount, true);
                        return;
                    case "load_medkits":
                        if (Main.Players[player].FractionID != onfrac)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie sind kein Mitglied {Fractions.Manager.getName(player.GetData<int>("ONFRACSTOCK"))}", 3000);
                            return;
                        }
                        if (!player.GetData<bool>("ON_DUTY"))
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie müssen den Tag beginnen", 3000);
                            return;
                        }
                        if (fracStocks[onfrac].Medkits < amount)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Wir haben nicht so viele Erste-Hilfe-Kästen auf Lager.", 3000);
                            return;
                        }
                        var maxMedkits = 100;
                        if (VehicleInventory.GetCountOfType(vehicle, ItemType.HealthKit) + amount > maxMedkits)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Es ist unmöglich, so viele Erste-Hilfe-Kästen zu bestücken", 3000);
                            return;
                        }
                        tryAdd = VehicleInventory.TryAdd(vehicle, new nItem(ItemType.HealthKit, amount));
                        if (tryAdd == -1 || tryAdd > 0)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Es ist unmöglich, so viele Erste-Hilfe-Kästen zu bestücken", 3000);
                            return;
                        }
                        VehicleInventory.Add(vehicle, new nItem(ItemType.HealthKit, amount));
                        fracStocks[onfrac].Medkits -= amount;
                        Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Sie haben die Erste-Hilfe-Kästen ins Auto geladen", 3000);
                        fracStocks[onfrac].UpdateLabel();
                        GameLog.Stock(Main.Players[player].FractionID, Main.Players[player].UUID, "medkits", amount, false);
                        return;
                    case "unload_medkits":
                        if (!player.GetData<bool>("ON_DUTY"))
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie müssen den Tag beginnen", 3000);
                            return;
                        }
                        count = VehicleInventory.GetCountOfType(vehicle, ItemType.HealthKit);
                        if (count < amount)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Es gibt nicht so viele Erste-Hilfe-Kästen im Auto.", 3000);
                            return;
                        }
                        if (fracStocks[onfrac].Medkits + amount > 1000)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Das Lager kann nicht so viele Erste-Hilfe-Kästen aufnehmen.", 3000);
                            return;
                        }
                        VehicleInventory.Remove(vehicle, ItemType.HealthKit, amount);
                        fracStocks[onfrac].Medkits += amount;
                        Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Sie haben die Erste-Hilfe-Kästen aus dem Auto ausgeladen", 3000);
                        fracStocks[onfrac].UpdateLabel();
                        GameLog.Stock(Main.Players[player].FractionID, Main.Players[player].UUID, "medkits", amount, true);
                        return;
                }
            }
        }

        public static void interactPressed(Player player, int interact)
        {
            switch (interact)
            {
                case 32:
                    if (!player.IsInVehicle)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie müssen im Auto sein", 3000);
                        return;
                    }
                    var vehicle = player.Vehicle;
                    if (!vehicle.HasData("CANMATS") && !vehicle.HasData("CANDRUGS") && !vehicle.HasData("CANMEDKITS"))
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Das Auto kann nichts transportieren", 3000);
                        return;
                    }

                    if (player.GetData<int>("ONFRACSTOCK") == 14 && (DateTime.Now.Hour < 13 && DateTime.Now.Hour > 1))
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Das Lager ist dauerhaft geschlossen", 3000);
                        return;
                    }
                    else if (!fracStocks[(int)player.GetData<int>("ONFRACSTOCK")].IsOpen && player.GetData<int>("ONFRACSTOCK") != 14)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Das Lager ist geschlossen.", 3000);
                        return;
                    }

                    OpenFracGarageMenu(player);
                    return;
                case 33:
                    if (Main.Players[player].FractionID != player.GetData<int>("ONFRACSTOCK"))
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie sind kein Mitglied {Manager.getName(player.GetData<int>("ONFRACSTOCK"))}", 3000);
                        return;
                    }
                    if (!fracStocks[Main.Players[player].FractionID].IsOpen)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Das Lager ist geschlossen.", 3000);
                        return;
                    }
                    OpenFracStockMenu(player);
                    return;
            }
        }

        [ServerEvent(Event.PlayerExitVehicle)]
        public static void onPlayerExitVehicle(Player player, Vehicle vehicle)
        {
            try
            {
                /*var menu = MenuController.MenuManager.getMenu(player);
                if (menu != null && menu.Id == "fracGarage") MenuConstructor.CloseAll(player);*/
            }
            catch (Exception e) { Log.Write("PlayerExit: " + e.Message, nLog.Type.Error); }
        }

        public static void saveStocksDic()
        {
            foreach (var key in fracStocks.Keys)
            {
                var data = fracStocks[key];
                MySQL.Query($"UPDATE fractions SET drugs={data.Drugs},money={data.Money},mats={data.Materials},medkits={data.Medkits},lastserial={Weapons.FractionsLastSerial[key]}," +
                    $"weapons='{JsonConvert.SerializeObject(data.Weapons)}',isopen={data.IsOpen},fuellimit={data.FuelLimit},fuelleft={data.FuelLeft} WHERE id={key}");
            }
            Log.Write("Stocks has been saved to DB", nLog.Type.Success);
        }

        [RemoteEvent("openWeaponStock")]
        public static void Event_openWeaponsStock(Player player)
        {
            try
            {
                if (!Main.Players.ContainsKey(player) || !player.HasData("ONFRACSTOCK") || player.GetData<int>("ONFRACSTOCK") == 0) return;
                if (Main.Players[player].FractionID != player.GetData<int>("ONFRACSTOCK")) return;

                if (!Manager.canUseCommand(player, "openweaponstock")) return;

                GUI.Dashboard.OpenOut(player, fracStocks[(int)player.GetData<int>("ONFRACSTOCK")].Weapons, "Die Waffenkammer", 6);
            }
            catch (Exception e) { Log.Write("Openweaponstock: " + e.Message, nLog.Type.Error); }
        }

        #region menus
        public static void OpenFracGarageMenu(Player player)
        {
            bool isArmy = !player.Vehicle.HasData("CANDRUGS");
            bool isMed = player.Vehicle.HasData("CANMEDKITS");
            Trigger.ClientEvent(player, "matsOpen", isArmy, isMed);
        }
        public static void fracgarage(Player player, string eventName, string data)
        {
            int amount = 0;
            if (!Int32.TryParse(data, out amount))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Richtige Daten eingeben", 3000);
                return;
            }
            if (amount < 1)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Richtige Daten eingeben", 3000);
                return;
            }
            if (!player.IsInVehicle)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie müssen im Auto sein", 3000);
                return;
            }
            var vehicle = player.Vehicle;
            if (!vehicle.HasData("CANMATS") && !vehicle.HasData("CANDRUGS") && !vehicle.HasData("CANMEDKITS"))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Das Auto kann nichts transportieren", 3000);
                return;
            }
            switch (eventName)
            {
                case "loadmats":
                    if (player.GetData<int>("ONFRACSTOCK") != 14 && Main.Players[player].FractionID != player.GetData<int>("ONFRACSTOCK"))
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie sind kein Mitglied {Manager.getName(player.GetData<int>("ONFRACSTOCK"))}", 3000);
                        return;
                    }
                    //Main.OpenInputMenu(player, "Введите кол-во материалов", "load_mats");
                    Fractions.Stocks.inputStocks(player, 1, "load_mats", amount);
                    return;
                case "unloadmats":
                    //Main.OpenInputMenu(player, "Введите кол-во материалов", "unload_mats");
                    Fractions.Stocks.inputStocks(player, 1, "unload_mats", amount);
                    return;
                case "loaddrugs":
                    if (!vehicle.HasData("CANDRUGS"))
                    {
                        MenuManager.Close(player);
                        return;
                    }
                    if (Main.Players[player].FractionID != player.GetData<int>("ONFRACSTOCK"))
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie sind kein Mitglied {Manager.getName(player.GetData<int>("ONFRACSTOCK"))}", 3000);
                        return;
                    }
                    //Main.OpenInputMenu(player, "Введите кол-во наркотиков", "load_drugs");
                    Fractions.Stocks.inputStocks(player, 1, "load_drugs", amount);
                    return;
                case "unloaddrugs":
                    //Main.OpenInputMenu(player, "Введите кол-во наркотиков", "unload_drugs");
                    Fractions.Stocks.inputStocks(player, 1, "unload_drugs", amount);
                    return;
                case "loadmedkits":
                    Fractions.Stocks.inputStocks(player, 1, "load_medkits", amount);
                    return;
                case "unloadmedkits":
                    Fractions.Stocks.inputStocks(player, 1, "unload_medkits", amount);
                    return;
            }
        }

        public static void OpenFracStockMenu(Player player)
        {
            List<int> counter = new List<int>
            {
                fracStocks[Main.Players[player].FractionID].Money,
                fracStocks[Main.Players[player].FractionID].Medkits,
                fracStocks[Main.Players[player].FractionID].Drugs,
                fracStocks[Main.Players[player].FractionID].Materials,
                fracStocks[Main.Players[player].FractionID].Weapons.Count,
            };
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(counter);
            Log.Debug(json);
            Trigger.ClientEvent(player, "openStock", json);
        }
        private static void callback_fracstock(Player player, Menu menu, Menu.Item item, string eventName, dynamic data)
        {
            switch (item.ID)
            {
                case "mats":
                case "drugs":
                case "money":
                case "medkits":
                    MenuManager.Close(player);
                    OpenStockSelectMenu(player, item.ID);
                    return;
                case "close":
                    MenuManager.Close(player);
                    return;
            }
        }

        public static void OpenStockSelectMenu(Player player, string item)
        {
            player.SetData("selectedStock", item);
            string itemcount = "";
            string menuname = "";
            if (item == "mats")
            {
                var count = (nInventory.Find(Main.Players[player].UUID, ItemType.Material) == null) ? 0 : nInventory.Find(Main.Players[player].UUID, ItemType.Material).Count;
                itemcount += count + " mat";
                menuname = "Materialien";
            }
            else if (item == "drugs")
            {
                var count = (nInventory.Find(Main.Players[player].UUID, ItemType.Drugs) == null) ? 0 : nInventory.Find(Main.Players[player].UUID, ItemType.Drugs).Count;
                itemcount += count + "г";
                menuname = "Drogen";
            }
            else if (item == "money")
            {
                itemcount += Main.Players[player].Money + "$";
                menuname = "Geld";
            }
            else if (item == "medkits")
            {
                var invitem = nInventory.Find(Main.Players[player].UUID, ItemType.HealthKit);
                if (invitem == null) itemcount += "0 шт";
                else itemcount += invitem.Count + " шт";
                menuname = "Erste-Hilfe-Kästen";
            }
            Menu menu = new Menu("stockselect", false, false);
            menu.Callback = callback_stockselect;

            Menu.Item menuItem = new Menu.Item("header", Menu.MenuItem.Header);
            menuItem.Text = menuname;
            menu.Add(menuItem);

            menuItem = new Menu.Item("uhave", Menu.MenuItem.Card);
            menuItem.Text = $"Sie haben {itemcount}";
            menu.Add(menuItem);

            menuItem = new Menu.Item("put", Menu.MenuItem.Button);
            menuItem.Text = "Setzen Sie";
            menu.Add(menuItem);

            menuItem = new Menu.Item("take", Menu.MenuItem.Button);
            menuItem.Text = "Abgefragt von";
            menu.Add(menuItem);

            menuItem = new Menu.Item("back", Menu.MenuItem.Button);
            menuItem.Text = "Zurück";
            menu.Add(menuItem);

            menu.Open(player);
        }
        private static void callback_stockselect(Player player, Menu menu, Menu.Item item, string eventName, dynamic data)
        {
            switch (item.ID)
            {
                case "put":
                    MenuManager.Close(player);
                    Main.OpenInputMenu(player, "Menge eingeben", "put_stock");
                    return;
                case "take":
                    MenuManager.Close(player);
                    Main.OpenInputMenu(player, "Menge eingeben", "take_stock");
                    return;
                case "back":
                    MenuManager.Close(player);
                    OpenFracStockMenu(player);
                    return;
            }
        }
        #endregion

        public class FractionStock
        {
            public int Drugs { get; set; }
            public int Money { get; set; }
            public int Materials { get; set; }
            public int Medkits { get; set; }
            public List<nItem> Weapons { get; set; }
            public bool IsOpen { get; set; }
            [JsonIgnore]
            public int maxMats { get; set; }
            [JsonIgnore]
            public TextLabel label { get; set; }
            public int FuelLimit { get; set; }
            public int FuelLeft { get; set; }

            public void UpdateLabel()
            {
                if (label == null) return;
                var text = $"";
                if (Drugs > 0) text += $""; //Наркота: {Drugs}/10000\n
                if (Materials > 0) text += $""; //МАТы: {Materials}/{maxMats}\n
                if (Medkits > 0) text += $""; //Аптечки: { Medkits}\n
                label.Text = text;
            }
        }
    }

    class MatsWar : Script
    {
        private static API api = new API();
        public static bool isWar = false;
        public static int matsLeft = 15000;
        private static Marker warMarker = null;
        private static Vector3 warPosition = new Vector3(33.33279, -2669.874, 5.008363);
        private static Blip warblip;
#pragma warning disable IDE0052 // Удалить непрочитанные закрытые члены
        private static string startWarTimer = null;
#pragma warning restore IDE0052 // Удалить непрочитанные закрытые члены

        private static nLog Log = new nLog("MatsWar");

        [ServerEvent(Event.ResourceStart)]
        public void onResourceStart()
        {
            try
            {
                //var col = NAPI.ColShape.CreateCylinderColShape(warPosition, 6, 2, 0);
                //col.OnEntityEnterColShape += onEntityEnterColShape;
                //col.OnEntityExitColShape += onEntityExitColShape;

                //warblip = NAPI.Blip.CreateBlip(675, warPosition, 0.75f, 59, Main.StringToU16("War for materials"), 255, 0, true, 0, 0);
            }
            catch (Exception e) { Log.Write("ResourceStart: " + e.Message, nLog.Type.Error); }
        }

        public static void startMatWarTimer()
        {
            Manager.sendFractionMessage(1, "In 10 Minuten wird ein Schiff mit den Materialien im Hafen von Los Santos einlaufen.");
            Manager.sendFractionMessage(2, "In 10 Minuten wird ein Schiff mit den Materialien im Hafen von Los Santos einlaufen.");
            Manager.sendFractionMessage(3, "In 10 Minuten wird ein Schiff mit den Materialien im Hafen von Los Santos einlaufen.");
            Manager.sendFractionMessage(4, "In 10 Minuten wird ein Schiff mit den Materialien im Hafen von Los Santos einlaufen.");
            Manager.sendFractionMessage(5, "In 10 Minuten wird ein Schiff mit den Materialien im Hafen von Los Santos einlaufen.");
            Manager.sendFractionMessage(10, "In 10 Minuten wird ein Schiff mit den Materialien im Hafen von Los Santos einlaufen.");
            Manager.sendFractionMessage(11, "In 10 Minuten wird ein Schiff mit den Materialien im Hafen von Los Santos einlaufen.");
            Manager.sendFractionMessage(12, "In 10 Minuten wird ein Schiff mit den Materialien im Hafen von Los Santos einlaufen.");
            Manager.sendFractionMessage(13, "In 10 Minuten wird ein Schiff mit den Materialien im Hafen von Los Santos einlaufen.");
            startWarTimer = Timers.StartOnce(600000, () => startWar());
        }

        public static void startWar()
        {
            NAPI.Task.Run(() =>
            {
                try
                {
                    if (isWar) return;
                    matsLeft = 15000;
                    //warMarker = NAPI.Marker.CreateMarker(1, warPosition - new Vector3(0, 0, 5), new Vector3(), new Vector3(), 6f, new Color(155, 0, 0, 255));
                    isWar = true;
                    Manager.sendFractionMessage(1, "Ein Schiff mit Nachschub ist im Hafen von Los Santos angekommen.");
                    Manager.sendFractionMessage(2, "Ein Schiff mit Nachschub ist im Hafen von Los Santos angekommen.");
                    Manager.sendFractionMessage(3, "Ein Schiff mit Nachschub ist im Hafen von Los Santos angekommen.");
                    Manager.sendFractionMessage(4, "Ein Schiff mit Nachschub ist im Hafen von Los Santos angekommen.");
                    Manager.sendFractionMessage(5, "Ein Schiff mit Nachschub ist im Hafen von Los Santos angekommen.");
                    Manager.sendFractionMessage(10, "Ein Schiff mit Nachschub ist im Hafen von Los Santos angekommen.");
                    Manager.sendFractionMessage(11, "Ein Schiff mit Nachschub ist im Hafen von Los Santos angekommen.");
                    Manager.sendFractionMessage(12, "Ein Schiff mit Nachschub ist im Hafen von Los Santos angekommen.");
                    Manager.sendFractionMessage(13, "Ein Schiff mit Nachschub ist im Hafen von Los Santos angekommen.");
                    warblip.Color = 49;
                }
                catch { }
            });
        }

        public static void endWar()
        {
            try
            {
                NAPI.Task.Run(() =>
                {
                    NAPI.Entity.DeleteEntity(warMarker);
                    isWar = false;
                    Manager.sendFractionMessage(1, "Das Schiff hat den Hafen von Los Santos verlassen.");
                    Manager.sendFractionMessage(2, "Das Schiff hat den Hafen von Los Santos verlassen.");
                    Manager.sendFractionMessage(3, "Das Schiff hat den Hafen von Los Santos verlassen.");
                    Manager.sendFractionMessage(4, "Das Schiff hat den Hafen von Los Santos verlassen.");
                    Manager.sendFractionMessage(5, "Das Schiff hat den Hafen von Los Santos verlassen.");
                    Manager.sendFractionMessage(10, "Das Schiff hat den Hafen von Los Santos verlassen.");
                    Manager.sendFractionMessage(11, "Das Schiff hat den Hafen von Los Santos verlassen.");
                    Manager.sendFractionMessage(12, "Das Schiff hat den Hafen von Los Santos verlassen.");
                    Manager.sendFractionMessage(13, "Das Schiff hat den Hafen von Los Santos verlassen.");
                    warblip.Color = 49;
                });
            }
            catch (Exception e) { Log.Write($"EndMatsWar: " + e.Message, nLog.Type.Error); }
        }

        public static void Interact(Player player)
        {
            if (!Main.Players.ContainsKey(player)) return;
            var fracid = Main.Players[player].FractionID;
            if (!((fracid >= 1 && fracid <= 5) || (fracid >= 10 && fracid <= 13)))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Das können Sie nicht tun. - Fraction", 3000);
                return;
            }
            if (!player.IsInVehicle)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie müssen im Auto sein - Fraction", 3000);
                return;
            }
            if (!player.Vehicle.HasData("CANMATS"))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie können dieses Auto nicht zum Transport von Matten verwenden - Fraction", 3000);
                return;
            }
            if (player.HasData("loadMatsTimer"))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie sind bereits dabei, Materialien in die Maschine zu laden - Fraction", 3000);
                return;
            }
            var count = VehicleInventory.GetCountOfType(player.Vehicle, ItemType.Material);
            if (count >= Fractions.Stocks.maxMats[player.Vehicle.DisplayName])
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Maximale Menge an Material in der Maschine - Fraction", 3000);
                return;
            }
            player.SetData("loadMatsTimer", Timers.StartOnce(20000, () => Fractions.Army.LoadMaterialsTimer(player)));
            player.Vehicle.SetData("loaderMats", player);
            Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Laden von Materialien gestartet (20 Sekunden) - Fraction", 3000);
            Trigger.ClientEvent(player, "showLoader", "Laden von Materialien", 1);
            player.SetData("vehicleMats", player.Vehicle);
            player.SetData("whereLoad", "WAR");
            return;
        }

        private void onEntityEnterColShape(ColShape shape, Player entity)
        {
            try
            {
                if (!isWar) return;
                if (NAPI.Entity.GetEntityType(entity) != EntityType.Player) return;
                NAPI.Data.SetEntityData(entity, "INTERACTIONCHECK", 37);
            }
            catch (Exception ex) { Log.Write("onEntityEnterColShape: " + ex.Message, nLog.Type.Error); }
        }

        private void onEntityExitColShape(ColShape shape, Player entity)
        {
            try
            {
                if (NAPI.Entity.GetEntityType(entity) == EntityType.Player)
                {
                    NAPI.Data.SetEntityData(entity, "INTERACTIONCHECK", 0);
                    if (entity.IsInVehicle && NAPI.Data.HasEntityData(entity.Vehicle, "loaderMats"))
                    {
                        Player player = NAPI.Data.GetEntityData(entity.Vehicle, "loaderMats");
                        Timers.Stop(player.GetData<string>("loadMatsTimer"));
                        NAPI.Data.ResetEntityData(entity.Vehicle, "loaderMats");
                        player.ResetData("loadMatsTimer");
                        Trigger.ClientEvent(player, "hideLoader");
                        Notify.Send(player, NotifyType.Warning, NotifyPosition.MapUp, $"Das Laden von Material wurde abgebrochen, weil das Fahrzeug den Kontrollpunkt verlassen hat", 3000);
                    }
                }
            }
            catch (Exception ex) { Log.Write("onEntityExitColShape: " + ex.Message, nLog.Type.Error); }
        }
    }
}
