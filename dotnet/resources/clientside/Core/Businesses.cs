using GTANetworkAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ULife.GUI;
using ULife.MoneySystem;
using UNL.SDK;

namespace ULife.Core
{
    class BusinessManager : Script
    {
        private static nLog Log = new nLog("BusinessManager");
        private static int lastBizID = -1;

        [ServerEvent(Event.ResourceStart)]
        public void onResourceStart()
        {
            try
            {
                var result = MySQL.QueryRead($"SELECT * FROM businesses");
                if (result == null || result.Rows.Count == 0)
                {
                    Log.Write("DB biz return null result.", nLog.Type.Warn);
                    return;
                }
                foreach (DataRow Row in result.Rows)
                {
                    Vector3 enterpoint = JsonConvert.DeserializeObject<Vector3>(Row["enterpoint"].ToString());
                    Vector3 unloadpoint = JsonConvert.DeserializeObject<Vector3>(Row["unloadpoint"].ToString());

                    Business data = new Business(Convert.ToInt32(Row["id"]), Row["owner"].ToString(), Convert.ToInt32(Row["sellprice"]), Convert.ToInt32(Row["type"]), JsonConvert.DeserializeObject<List<Product>>(Row["products"].ToString()), enterpoint, unloadpoint, Convert.ToInt32(Row["money"]),
                        Convert.ToInt32(Row["mafia"]), JsonConvert.DeserializeObject<List<Order>>(Row["orders"].ToString()));
                    var id = Convert.ToInt32(Row["id"]);

                    lastBizID = id;

                    if (data.Type == 0)
                    {
                        if (data.Products.Find(p => p.Name == "Schlüsselbund") == null)
                        {
                            Product product = new Product(ProductsOrderPrice["Schlüsselbund"], 0, 0, "Schlüsselbund", false);
                            data.Products.Add(product);
                            Log.Write($"Produkt Schlüsselbund wurde zu hinzugefügt { data.ID} biz");
                        }
                        data.Save();
                    }
                    BizList.Add(id, data);
                }
            }
            catch (Exception e)
            {
                Log.Write("EXCEPTION AT \"BUSINESSES\":\n" + e.ToString(), nLog.Type.Error);
            }
        }

        public static void SavingBusiness()
        {
            foreach (var b in BizList)
            {
                var biz = BizList[b.Key];
                biz.Save();
            }
            Log.Write("Unternehmen wurden in der DB gespeichert", nLog.Type.Success);
        }

        [ServerEvent(Event.ResourceStop)]
        public void OnResourceStop()
        {
            try
            {
                SavingBusiness();
            }
            catch (Exception e) { Log.Write("ResourceStart: " + e.Message, nLog.Type.Error); }
        }

        public static Dictionary<int, Business> BizList = new Dictionary<int, Business>();
        public static Dictionary<int, int> Orders = new Dictionary<int, int>(); // key - Auftrags-ID, Wert - Geschäfts-ID

        public static List<string> BusinessTypeNames = new List<string>()
        {
            "24/7", //0
            "Tankstelle",//1
            "Premium Autohaus",//2
            "Luxor Autohaus",//3
            "Low Autohaus",//4
            "Motorrad Laden",//5
            "Waffen",//6
            "Bekleidungsgeschäft",//7
            "BurgerShot",//8
            "Tattoo Studio",//9
            "Friseurladen",//10
            "Maskengeschäft",//11
            "LS Customs",//12
            "Autowäsche",//13
            "Tierladen",//14
        };
        public static List<int> BlipByType = new List<int>()
        {
            52, // 24/7
            361, // petrol station
            530, // premium
            523, // sport
            225, // middle
            522, // moto
            110, // gun shop
            73, // clothes shop
            106, // burger-shot
            75, // Tattoo Salon
            71, // barber-shop
            463, // masks shop
            72, // ls customs
            100, // carwash
            273, // Petshop
        };
        public static List<int> BlipColorByType = new List<int>()
        {
            4, // 24/7
            76, // petrol station
            45, // showroom
            45, // showroom
            45, // showroom
            45, // showroom
            76, // gun shop
            76, // clothes shop
            71, // burger-shot
            64, // Tattoo Salon
            64, // barber-shop
            27, // masks shop
            40, // ls customs
            17, // carwash
            5, // petshop
        };

        public static List<string> PetNames = new List<string>() {
            "Husky",
            "Poodle",
            "Pug",
            "Retriever",
            "Rottweiler",
            "Shepherd",
            "Westy",
            "Katze",
            "Hase",
        };
        public static List<int> PetHashes = new List<int>() {
            1318032802, // Husky
            1125994524,
            1832265812,
            882848737, // Retriever
            -1788665315,
            1126154828,
            -1384627013,
            1462895032,
            -541762431,
        };
        public static List<List<string>> CarsNames = new List<List<string>>()
        {
            new List<string>() // premium
            {
                "Sultan",
                "SultanRS",
                "Kuruma",
                "Fugitive",
                "Tailgater",
                "Sentinel",
                "F620",
                "Schwarzer",
                "Exemplar",
                "Felon",
                "Schafter2",
                "Jackal",
                "Oracle2",
                "Surano",
                "Zion",
                "Dominator",
                "FQ2",
                "Gresley",
                "Serrano",
                "Dubsta",
                "Rocoto",
                "Cavalcade2",
                "XLS",
                "Baller2",
                "Elegy",
                "Banshee",
                "Massacro2",
                "GP1",
            }, // premium
            new List<string>() // sport
            {
                "Comet2",
                "Coquette",
                "Ninef",
                "Ninef2",
                "Jester",
                "Elegy2",
                "Infernus",
                "Carbonizzare",
                "Dubsta2",
                "Baller3",
                "Huntley",
                "Superd",
                "Windsor",
                "BestiaGTS",
                "Banshee2",
                "EntityXF",
                "Neon",
                "Jester2",
                "Turismor",
                "Penetrator",
                "Omnis",
                "Reaper",
                "Italigtb2",
                "Xa21",
                "Osiris",
                "Nero",
                "Zentorno",
            }, // sport
            new List<string>() // middle
            {
                "Tornado3",
                "Tornado4",
                "Emperor2",
                "Voodoo2",
                "Regina",
                "Ingot",
                "Emperor",
                "Picador",
                "Minivan",
                "Blista2",
                "Manana",
                "Dilettante",
                "Asea",
                "Glendale",
                "Voodoo",
                "Surge",
                "Primo",
                "Stanier",
                "Stratum",
                "Tampa",
                "Prairie",
                "Radi",
                "Blista",
                "Stalion",
                "Asterope",
                "Washington",
                "Premier",
                "Intruder",
                "Ruiner",
                "Oracle",
                "Phoenix",
                "Gauntlet",
                "Buffalo",
                "RancherXL",
                "Seminole",
                "Baller",
                "Landstalker",
                "Cavalcade",
                "BJXL",
                "Patriot",
                "Bison3",
                "Issi2",
                "Panto",
            }, // middle
            new List<string>() // moto
            {
                "Faggio2",
                "Sanchez2",
                "Enduro",
                "PCJ",
                "Hexer",
                "Lectro",
                "Nemesis",
                "Hakuchou",
                "Ruffian",
                "Bmx",
                "Scorcher",
                "BF400",
                "CarbonRS",
                "Bati",
                "Double",
                "Diablous",
                "Cliffhanger",
                "Akuma",
                "Thrust",
                "Nightblade",
                "Vindicator",
                "Ratbike",
                "Blazer",
                "Gargoyle",
                "Sanctus"
            }, // moto
        };
        private static List<string> GunNames = new List<string>()
        {
            "Pistol",
            "CombatPistol",
            "Revolver",
            "HeavyPistol",

            "BullpupShotgun",

            "CombatPDW",
            "MachinePistol",
        };
        private static List<string> MarketProducts = new List<string>()
        {
            "Taschenlampe",
            "Hammer",
            "Rohrzange",
            "Benzinkanister",
            "Chips",
            "Pizza",
            "SIM-Karte",
            "Schlüsselbund",
            "Zigarette",
            //"Funk",
            "Wasser",
            "Kaffee",
            "Gummibärchen",
            "Donut",
            "Schinken",
            "Aceton",
            "Rucksack",         
         };
        private static List<string> BurgerProducts = new List<string>()
        {
            "Burger",
            "Hotdog",
            "Sandwich",
            "eCola",
            "Sprunk",
            "Wasser",
            "Kaffee",
            "Donut",
        };

        public static List<List<BusinessTattoo>> BusinessTattoos = new List<List<BusinessTattoo>>()
        {
            // Torso
            new List<BusinessTattoo>()
            {
	            // Левый сосок  -   0
                // Правый сосок -   1
                // Живот        -   2
                // Левый низ спины    -   3
	            // Правый низ спины    -   4
                // Левый верх спины   -   5
                // Правый верх спины   -   6
                // Левый бок    -   7
                // Правый бок   -   8
                new BusinessTattoo(new List<int>(){ 2 }, "Refined Hustler", "mpbusiness_overlays", "MP_Buis_M_Stomach_000", String.Empty, 4500),
                new BusinessTattoo(new List<int>(){ 1 }, "Rich", "mpbusiness_overlays", "MP_Buis_M_Chest_000", String.Empty, 2475),
                new BusinessTattoo(new List<int>(){ 0 }, "$$$", "mpbusiness_overlays", "MP_Buis_M_Chest_001", String.Empty, 2470),
                new BusinessTattoo(new List<int>(){ 3, 4 }, "Makin' Paper", "mpbusiness_overlays", "MP_Buis_M_Back_000", String.Empty, 3000),
                new BusinessTattoo(new List<int>(){ 0, 1 }, "High Roller", "mpbusiness_overlays", String.Empty, "MP_Buis_F_Chest_000", 2475),
                new BusinessTattoo(new List<int>(){ 0, 1 }, "Makin' Money", "mpbusiness_overlays", String.Empty, "MP_Buis_F_Chest_001", 3650),
                new BusinessTattoo(new List<int>(){ 1 }, "Love Money", "mpbusiness_overlays", String.Empty, "MP_Buis_F_Chest_002", 2470),
                new BusinessTattoo(new List<int>(){ 2 }, "Diamond Back", "mpbusiness_overlays", String.Empty, "MP_Buis_F_Stom_000", 4500),
                new BusinessTattoo(new List<int>(){ 8 }, "Santo Capra Logo", "mpbusiness_overlays", String.Empty, "MP_Buis_F_Stom_001", 3000),
                new BusinessTattoo(new List<int>(){ 8 }, "Money Bag", "mpbusiness_overlays", String.Empty, "MP_Buis_F_Stom_002", 3000),
                new BusinessTattoo(new List<int>(){ 3, 4 }, "Respect", "mpbusiness_overlays", String.Empty, "MP_Buis_F_Back_000", 3000),
                new BusinessTattoo(new List<int>(){ 3, 4 }, "Gold Digger", "mpbusiness_overlays", String.Empty, "MP_Buis_F_Back_001", 1250),
                new BusinessTattoo(new List<int>(){ 3, 4, 5, 6 }, "Carp Outline", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_005", "MP_Xmas2_F_Tat_005", 9320),
                new BusinessTattoo(new List<int>(){ 3, 4, 5, 6 }, "Carp Shaded", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_006", "MP_Xmas2_F_Tat_006", 9350),
                new BusinessTattoo(new List<int>(){ 1 }, "Time To Die", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_009", "MP_Xmas2_F_Tat_009", 1850),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Roaring Tiger", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_011", "MP_Xmas2_F_Tat_011", 3350),
                new BusinessTattoo(new List<int>(){ 7 }, "Lizard", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_013", "MP_Xmas2_F_Tat_013", 3000),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Japanese Warrior", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_015", "MP_Xmas2_F_Tat_015", 3650),
                new BusinessTattoo(new List<int>(){ 0 }, "Loose Lips Outline", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_016", "MP_Xmas2_F_Tat_016", 2470),
                new BusinessTattoo(new List<int>(){ 0 }, "Loose Lips Color", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_017", "MP_Xmas2_F_Tat_017", 2470),
                new BusinessTattoo(new List<int>(){ 0, 1 }, "Royal Dagger Outline", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_018", "MP_Xmas2_F_Tat_018", 3650),
                new BusinessTattoo(new List<int>(){ 0, 1 }, "Royal Dagger Color", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_019", "MP_Xmas2_F_Tat_019", 3600),
                new BusinessTattoo(new List<int>(){ 2, 8 }, "Executioner", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_028", "MP_Xmas2_F_Tat_028", 3000),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Bullet Proof", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_000_M", "MP_Gunrunning_Tattoo_000_F", 3000),
                new BusinessTattoo(new List<int>(){ 3, 4 }, "Crossed Weapons", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_001_M", "MP_Gunrunning_Tattoo_001_F", 3000),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Butterfly Knife", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_009_M", "MP_Gunrunning_Tattoo_009_F", 3350),
                new BusinessTattoo(new List<int>(){ 2 }, "Cash Money", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_010_M", "MP_Gunrunning_Tattoo_010_F", 4500),
                new BusinessTattoo(new List<int>(){ 1 }, "Dollar Daggers", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_012_M", "MP_Gunrunning_Tattoo_012_F", 2450),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Wolf Insignia", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_013_M", "MP_Gunrunning_Tattoo_013_F", 3350),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Backstabber", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_014_M", "MP_Gunrunning_Tattoo_014_F", 3250),
                new BusinessTattoo(new List<int>(){ 0, 1 }, "Dog Tags", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_017_M", "MP_Gunrunning_Tattoo_017_F", 3650),
                new BusinessTattoo(new List<int>(){ 3, 4 }, "Dual Wield Skull", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_018_M", "MP_Gunrunning_Tattoo_018_F", 3250),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Pistol Wings", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_019_M", "MP_Gunrunning_Tattoo_019_F", 3350),
                new BusinessTattoo(new List<int>(){ 0, 1 }, "Crowned Weapons", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_020_M", "MP_Gunrunning_Tattoo_020_F", 3600),
                new BusinessTattoo(new List<int>(){ 5 }, "Explosive Heart", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_022_M", "MP_Gunrunning_Tattoo_022_F", 2450),
                new BusinessTattoo(new List<int>(){ 0, 1 }, "Micro SMG Chain", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_028_M", "MP_Gunrunning_Tattoo_028_F", 3650),
                new BusinessTattoo(new List<int>(){ 2 }, "Win Some Lose Some", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_029_M", "MP_Gunrunning_Tattoo_029_F", 4500),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Crossed Arrows", "mphipster_overlays", "FM_Hip_M_Tat_000", "FM_Hip_F_Tat_000", 3350),
                new BusinessTattoo(new List<int>(){ 1 }, "Chemistry", "mphipster_overlays", "FM_Hip_M_Tat_002", "FM_Hip_F_Tat_002", 2470),
                new BusinessTattoo(new List<int>(){ 7 }, "Feather Birds", "mphipster_overlays", "FM_Hip_M_Tat_006", "FM_Hip_F_Tat_006", 3000),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Infinity", "mphipster_overlays", "FM_Hip_M_Tat_011", "FM_Hip_F_Tat_011", 3350),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Antlers", "mphipster_overlays", "FM_Hip_M_Tat_012", "FM_Hip_F_Tat_012", 3320),
                new BusinessTattoo(new List<int>(){ 0, 1 }, "Boombox", "mphipster_overlays", "FM_Hip_M_Tat_013", "FM_Hip_F_Tat_013", 3600),
                new BusinessTattoo(new List<int>(){ 6 }, "Pyramid", "mphipster_overlays", "FM_Hip_M_Tat_024", "FM_Hip_F_Tat_024", 2450),
                new BusinessTattoo(new List<int>(){ 5 }, "Watch Your Step", "mphipster_overlays", "FM_Hip_M_Tat_025", "FM_Hip_F_Tat_025", 2450),
                new BusinessTattoo(new List<int>(){ 2, 8 }, "Sad", "mphipster_overlays", "FM_Hip_M_Tat_029", "FM_Hip_F_Tat_029", 5450),
                new BusinessTattoo(new List<int>(){ 3, 4 }, "Shark Fin", "mphipster_overlays", "FM_Hip_M_Tat_030", "FM_Hip_F_Tat_030", 3350),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Skateboard", "mphipster_overlays", "FM_Hip_M_Tat_031", "FM_Hip_F_Tat_031", 3350),
                new BusinessTattoo(new List<int>(){ 6 }, "Paper Plane", "mphipster_overlays", "FM_Hip_M_Tat_032", "FM_Hip_F_Tat_032", 2450),
                new BusinessTattoo(new List<int>(){ 0, 1 }, "Stag", "mphipster_overlays", "FM_Hip_M_Tat_033", "FM_Hip_F_Tat_033", 3600),
                new BusinessTattoo(new List<int>(){ 2, 8 }, "Sewn Heart", "mphipster_overlays", "FM_Hip_M_Tat_035", "FM_Hip_F_Tat_035", 5450),
                new BusinessTattoo(new List<int>(){ 3 }, "Tooth", "mphipster_overlays", "FM_Hip_M_Tat_041", "FM_Hip_F_Tat_041", 3000),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Triangles", "mphipster_overlays", "FM_Hip_M_Tat_046", "FM_Hip_F_Tat_046", 3320),
                new BusinessTattoo(new List<int>(){ 1 }, "Cassette", "mphipster_overlays", "FM_Hip_M_Tat_047", "FM_Hip_F_Tat_047", 2450),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Block Back", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_000_M", "MP_MP_ImportExport_Tat_000_F", 3350),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Power Plant", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_001_M", "MP_MP_ImportExport_Tat_001_F", 3250),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Tuned to Death", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_002_M", "MP_MP_ImportExport_Tat_002_F", 3250),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Serpents of Destruction", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_009_M", "MP_MP_ImportExport_Tat_009_F", 1120),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Take the Wheel", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_010_M", "MP_MP_ImportExport_Tat_010_F", 3250),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Talk Shit Get Hit", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_011_M", "MP_MP_ImportExport_Tat_011_F", 3350),
                new BusinessTattoo(new List<int>(){ 0 }, "King Fight", "mplowrider_overlays", "MP_LR_Tat_001_M", "MP_LR_Tat_001_F", 2450),
                new BusinessTattoo(new List<int>(){ 0, 1 }, "Holy Mary", "mplowrider_overlays", "MP_LR_Tat_002_M", "MP_LR_Tat_002_F", 3500),
                new BusinessTattoo(new List<int>(){ 7 }, "Gun Mic", "mplowrider_overlays", "MP_LR_Tat_004_M", "MP_LR_Tat_004_F", 3000),
                new BusinessTattoo(new List<int>(){ 6 }, "Amazon", "mplowrider_overlays", "MP_LR_Tat_009_M", "MP_LR_Tat_009_F", 8700),
                new BusinessTattoo(new List<int>(){ 3, 4, 5, 6 }, "Bad Angel", "mplowrider_overlays", "MP_LR_Tat_010_M", "MP_LR_Tat_010_F", 1800),
                new BusinessTattoo(new List<int>(){ 1 }, "Love Gamble", "mplowrider_overlays", "MP_LR_Tat_013_M", "MP_LR_Tat_013_F", 2450),
                new BusinessTattoo(new List<int>(){ 3, 4, 5, 6 }, "Love is Blind", "mplowrider_overlays", "MP_LR_Tat_014_M", "MP_LR_Tat_014_F", 1850),
                new BusinessTattoo(new List<int>(){ 3, 4, 5, 6 }, "Sad Angel", "mplowrider_overlays", "MP_LR_Tat_021_M", "MP_LR_Tat_021_F", 1500),
                new BusinessTattoo(new List<int>(){ 1 }, "Royal Takeover", "mplowrider_overlays", "MP_LR_Tat_026_M", "MP_LR_Tat_026_F", 2450),
                new BusinessTattoo(new List<int>(){ 1 }, "Turbulence", "mpairraces_overlays", "MP_Airraces_Tattoo_000_M", "MP_Airraces_Tattoo_000_F", 2450),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Pilot Skull", "mpairraces_overlays", "MP_Airraces_Tattoo_001_M", "MP_Airraces_Tattoo_001_F", 3350),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Winged Bombshell", "mpairraces_overlays", "MP_Airraces_Tattoo_002_M", "MP_Airraces_Tattoo_002_F", 3350),
                new BusinessTattoo(new List<int>(){ 3, 4, 5, 6 }, "Balloon Pioneer", "mpairraces_overlays", "MP_Airraces_Tattoo_004_M", "MP_Airraces_Tattoo_004_F", 1500),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Parachute Belle", "mpairraces_overlays", "MP_Airraces_Tattoo_005_M", "MP_Airraces_Tattoo_005_F", 3350),
                new BusinessTattoo(new List<int>(){ 2 }, "Bombs Away", "mpairraces_overlays", "MP_Airraces_Tattoo_006_M", "MP_Airraces_Tattoo_006_F", 4500),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Eagle Eyes", "mpairraces_overlays", "MP_Airraces_Tattoo_007_M", "MP_Airraces_Tattoo_007_F", 3250),
                new BusinessTattoo(new List<int>(){ 0 }, "Demon Rider", "mpbiker_overlays", "MP_MP_Biker_Tat_000_M", "MP_MP_Biker_Tat_000_F", 2450),
                new BusinessTattoo(new List<int>(){ 0, 1 }, "Both Barrels", "mpbiker_overlays", "MP_MP_Biker_Tat_001_M", "MP_MP_Biker_Tat_001_F", 3600),
                new BusinessTattoo(new List<int>(){ 2 }, "Web Rider", "mpbiker_overlays", "MP_MP_Biker_Tat_003_M", "MP_MP_Biker_Tat_003_F", 4500),
                new BusinessTattoo(new List<int>(){ 0, 1 }, "Made In America", "mpbiker_overlays", "MP_MP_Biker_Tat_005_M", "MP_MP_Biker_Tat_005_F", 3600),
                new BusinessTattoo(new List<int>(){ 3, 4 }, "Chopper Freedom", "mpbiker_overlays", "MP_MP_Biker_Tat_006_M", "MP_MP_Biker_Tat_006_F", 3000),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Freedom Wheels", "mpbiker_overlays", "MP_MP_Biker_Tat_008_M", "MP_MP_Biker_Tat_008_F", 3250),
                new BusinessTattoo(new List<int>(){ 2 }, "Skull Of Taurus", "mpbiker_overlays", "MP_MP_Biker_Tat_010_M", "MP_MP_Biker_Tat_010_F", 9250),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "R.I.P. My Brothers", "mpbiker_overlays", "MP_MP_Biker_Tat_011_M", "MP_MP_Biker_Tat_011_F", 3350),
                new BusinessTattoo(new List<int>(){ 0, 1 }, "Demon Crossbones", "mpbiker_overlays", "MP_MP_Biker_Tat_013_M", "MP_MP_Biker_Tat_013_F", 4500),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Clawed Beast", "mpbiker_overlays", "MP_MP_Biker_Tat_017_M", "MP_MP_Biker_Tat_017_F", 3350),
                new BusinessTattoo(new List<int>(){ 1 }, "Skeletal Chopper", "mpbiker_overlays", "MP_MP_Biker_Tat_018_M", "MP_MP_Biker_Tat_018_F", 2000),
                new BusinessTattoo(new List<int>(){ 0, 1 }, "Gruesome Talons", "mpbiker_overlays", "MP_MP_Biker_Tat_019_M", "MP_MP_Biker_Tat_019_F", 3950),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Flaming Reaper", "mpbiker_overlays", "MP_MP_Biker_Tat_021_M", "MP_MP_Biker_Tat_021_F", 3350),
                new BusinessTattoo(new List<int>(){ 0, 1 }, "Western MC", "mpbiker_overlays", "MP_MP_Biker_Tat_023_M", "MP_MP_Biker_Tat_023_F", 3950),
                new BusinessTattoo(new List<int>(){ 0, 1 }, "American Dream", "mpbiker_overlays", "MP_MP_Biker_Tat_026_M", "MP_MP_Biker_Tat_026_F", 3950),
                new BusinessTattoo(new List<int>(){ 0 }, "Bone Wrench", "mpbiker_overlays", "MP_MP_Biker_Tat_029_M", "MP_MP_Biker_Tat_029_F", 2250),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Brothers For Life", "mpbiker_overlays", "MP_MP_Biker_Tat_030_M", "MP_MP_Biker_Tat_030_F", 3500),
                new BusinessTattoo(new List<int>(){ 2 }, "Gear Head", "mpbiker_overlays", "MP_MP_Biker_Tat_031_M", "MP_MP_Biker_Tat_031_F", 4500),
                new BusinessTattoo(new List<int>(){ 0 }, "Western Eagle", "mpbiker_overlays", "MP_MP_Biker_Tat_032_M", "MP_MP_Biker_Tat_032_F", 2700),
                new BusinessTattoo(new List<int>(){ 1 }, "Brotherhood of Bikes", "mpbiker_overlays", "MP_MP_Biker_Tat_034_M", "MP_MP_Biker_Tat_034_F", 2720),
                new BusinessTattoo(new List<int>(){ 2 }, "Gas Guzzler", "mpbiker_overlays", "MP_MP_Biker_Tat_039_M", "MP_MP_Biker_Tat_039_F", 4220),
                new BusinessTattoo(new List<int>(){ 0, 1 }, "No Regrets", "mpbiker_overlays", "MP_MP_Biker_Tat_041_M", "MP_MP_Biker_Tat_041_F", 3600),
                new BusinessTattoo(new List<int>(){ 3, 4 }, "Ride Forever", "mpbiker_overlays", "MP_MP_Biker_Tat_043_M", "MP_MP_Biker_Tat_043_F", 3500),
                new BusinessTattoo(new List<int>(){ 0, 1 }, "Unforgiven", "mpbiker_overlays", "MP_MP_Biker_Tat_050_M", "MP_MP_Biker_Tat_050_F", 4500),
                new BusinessTattoo(new List<int>(){ 2 }, "Biker Mount", "mpbiker_overlays", "MP_MP_Biker_Tat_052_M", "MP_MP_Biker_Tat_052_F", 3650),
                new BusinessTattoo(new List<int>(){ 1 }, "Reaper Vulture", "mpbiker_overlays", "MP_MP_Biker_Tat_058_M", "MP_MP_Biker_Tat_058_F", 2450),
                new BusinessTattoo(new List<int>(){ 1 }, "Faggio", "mpbiker_overlays", "MP_MP_Biker_Tat_059_M", "MP_MP_Biker_Tat_059_F", 2450),
                new BusinessTattoo(new List<int>(){ 0 }, "We Are The Mods!", "mpbiker_overlays", "MP_MP_Biker_Tat_060_M", "MP_MP_Biker_Tat_060_F", 2750),
                new BusinessTattoo(new List<int>(){ 3, 4, 5, 6 }, "SA Assault", "mplowrider2_overlays", "MP_LR_Tat_000_M", "MP_LR_Tat_000_F", 1500),
                new BusinessTattoo(new List<int>(){ 3, 4, 5, 6 }, "Love the Game", "mplowrider2_overlays", "MP_LR_Tat_008_M", "MP_LR_Tat_008_F", 1550),
                new BusinessTattoo(new List<int>(){ 7 }, "Lady Liberty", "mplowrider2_overlays", "MP_LR_Tat_011_M", "MP_LR_Tat_011_F", 3050),
                new BusinessTattoo(new List<int>(){ 0 }, "Royal Kiss", "mplowrider2_overlays", "MP_LR_Tat_012_M", "MP_LR_Tat_012_F", 2750),
                new BusinessTattoo(new List<int>(){ 2 }, "Two Face", "mplowrider2_overlays", "MP_LR_Tat_016_M", "MP_LR_Tat_016_F", 9000),
                new BusinessTattoo(new List<int>(){ 1 }, "Death Behind", "mplowrider2_overlays", "MP_LR_Tat_019_M", "MP_LR_Tat_019_F", 2450),
                new BusinessTattoo(new List<int>(){ 3, 4, 5, 6 }, "Dead Pretty", "mplowrider2_overlays", "MP_LR_Tat_031_M", "MP_LR_Tat_031_F", 1250),
                new BusinessTattoo(new List<int>(){ 3, 4, 5, 6 }, "Reign Over", "mplowrider2_overlays", "MP_LR_Tat_032_M", "MP_LR_Tat_032_F", 1560),
                new BusinessTattoo(new List<int>(){ 2 }, "Abstract Skull", "mpluxe_overlays", "MP_LUXE_TAT_003_M", "MP_LUXE_TAT_003_F", 3950),
                new BusinessTattoo(new List<int>(){ 1 }, "Eye of the Griffin", "mpluxe_overlays", "MP_LUXE_TAT_007_M", "MP_LUXE_TAT_007_F", 2750),
                new BusinessTattoo(new List<int>(){ 1 }, "Flying Eye", "mpluxe_overlays", "MP_LUXE_TAT_008_M", "MP_LUXE_TAT_008_F", 2700),
                new BusinessTattoo(new List<int>(){ 0, 1 }, "Ancient Queen", "mpluxe_overlays", "MP_LUXE_TAT_014_M", "MP_LUXE_TAT_014_F", 6600),
                new BusinessTattoo(new List<int>(){ 0 }, "Smoking Sisters", "mpluxe_overlays", "MP_LUXE_TAT_015_M", "MP_LUXE_TAT_015_F", 2450),
                new BusinessTattoo(new List<int>(){ 3, 4, 5, 6 }, "Feather Mural", "mpluxe_overlays", "MP_LUXE_TAT_024_M", "MP_LUXE_TAT_024_F", 9350),
                new BusinessTattoo(new List<int>(){ 0 }, "The Howler", "mpluxe2_overlays", "MP_LUXE_TAT_002_M", "MP_LUXE_TAT_002_F", 2450),
                new BusinessTattoo(new List<int>(){ 0, 1, 2, 8 }, "Geometric Galaxy", "mpluxe2_overlays", "MP_LUXE_TAT_012_M", "MP_LUXE_TAT_012_F", 2100),
                new BusinessTattoo(new List<int>(){ 3, 4, 5, 6 }, "Cloaked Angel", "mpluxe2_overlays", "MP_LUXE_TAT_022_M", "MP_LUXE_TAT_022_F", 1800),
                new BusinessTattoo(new List<int>(){ 0 }, "Reaper Sway", "mpluxe2_overlays", "MP_LUXE_TAT_025_M", "MP_LUXE_TAT_025_F", 2450),
                new BusinessTattoo(new List<int>(){ 1 }, "Cobra Dawn", "mpluxe2_overlays", "MP_LUXE_TAT_027_M", "MP_LUXE_TAT_027_F", 2700),
                new BusinessTattoo(new List<int>(){ 3, 4, 5, 6 }, "Geometric Design T", "mpluxe2_overlays", "MP_LUXE_TAT_029_M", "MP_LUXE_TAT_029_F", 1500),
                new BusinessTattoo(new List<int>(){ 1 }, "Bless The Dead", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_000_M", "MP_Smuggler_Tattoo_000_F", 3000),
                new BusinessTattoo(new List<int>(){ 2 }, "Dead Lies", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_002_M", "MP_Smuggler_Tattoo_002_F", 4500),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Give Nothing Back", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_003_M", "MP_Smuggler_Tattoo_003_F", 3000),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Never Surrender", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_006_M", "MP_Smuggler_Tattoo_006_F", 3000),
                new BusinessTattoo(new List<int>(){ 0, 1 }, "No Honor", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_007_M", "MP_Smuggler_Tattoo_007_F", 3650),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Tall Ship Conflict", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_009_M", "MP_Smuggler_Tattoo_009_F", 3000),
                new BusinessTattoo(new List<int>(){ 2 }, "See You In Hell", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_010_M", "MP_Smuggler_Tattoo_010_F", 4500),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Torn Wings", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_013_M", "MP_Smuggler_Tattoo_013_F", 3050),
                new BusinessTattoo(new List<int>(){ 2 }, "Jolly Roger", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_015_M", "MP_Smuggler_Tattoo_015_F", 3500),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Skull Compass", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_016_M", "MP_Smuggler_Tattoo_016_F", 3000),
                new BusinessTattoo(new List<int>(){ 3, 4, 5, 6 }, "Framed Tall Ship", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_017_M", "MP_Smuggler_Tattoo_017_F", 1500),
                new BusinessTattoo(new List<int>(){ 3, 4, 5, 6 }, "Finders Keepers", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_018_M", "MP_Smuggler_Tattoo_018_F", 1800),
                new BusinessTattoo(new List<int>(){ 0 }, "Lost At Sea", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_019_M", "MP_Smuggler_Tattoo_019_F", 2050),
                new BusinessTattoo(new List<int>(){ 0, 1 }, "Dead Tales", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_021_M", "MP_Smuggler_Tattoo_021_F", 3000),
                new BusinessTattoo(new List<int>(){ 5 }, "X Marks The Spot", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_022_M", "MP_Smuggler_Tattoo_022_F", 2450),
                new BusinessTattoo(new List<int>(){ 3, 4, 5, 6 }, "Pirate Captain", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_024_M", "MP_Smuggler_Tattoo_024_F", 5500),
                new BusinessTattoo(new List<int>(){ 3, 4, 5, 6 }, "Claimed By The Beast", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_025_M", "MP_Smuggler_Tattoo_025_F", 1550),
                new BusinessTattoo(new List<int>(){ 0, 1 }, "Wheels of Death", "mpstunt_overlays", "MP_MP_Stunt_Tat_011_M", "MP_MP_Stunt_Tat_011_F", 3000),
                new BusinessTattoo(new List<int>(){ 7 }, "Punk Biker", "mpstunt_overlays", "MP_MP_Stunt_Tat_012_M", "MP_MP_Stunt_Tat_012_F", 3000),
                new BusinessTattoo(new List<int>(){ 2 }, "Bat Cat of Spades", "mpstunt_overlays", "MP_MP_Stunt_Tat_014_M", "MP_MP_Stunt_Tat_014_F", 9100),
                new BusinessTattoo(new List<int>(){ 0 }, "Vintage Bully", "mpstunt_overlays", "MP_MP_Stunt_Tat_018_M", "MP_MP_Stunt_Tat_018_F", 2450),
                new BusinessTattoo(new List<int>(){ 1 }, "Engine Heart", "mpstunt_overlays", "MP_MP_Stunt_Tat_019_M", "MP_MP_Stunt_Tat_019_F", 2450),
                new BusinessTattoo(new List<int>(){ 3, 4, 5, 6 }, "Road Kill", "mpstunt_overlays", "MP_MP_Stunt_Tat_024_M", "MP_MP_Stunt_Tat_024_F", 1500),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Winged Wheel", "mpstunt_overlays", "MP_MP_Stunt_Tat_026_M", "MP_MP_Stunt_Tat_026_F", 3000),
                new BusinessTattoo(new List<int>(){ 0 }, "Punk Road Hog", "mpstunt_overlays", "MP_MP_Stunt_Tat_027_M", "MP_MP_Stunt_Tat_027_F", 2470),
                new BusinessTattoo(new List<int>(){ 3, 4 }, "Majestic Finish", "mpstunt_overlays", "MP_MP_Stunt_Tat_029_M", "MP_MP_Stunt_Tat_029_F", 3000),
                new BusinessTattoo(new List<int>(){ 6 }, "Man's Ruin", "mpstunt_overlays", "MP_MP_Stunt_Tat_030_M", "MP_MP_Stunt_Tat_030_F", 3000),
                new BusinessTattoo(new List<int>(){ 1 }, "Sugar Skull Trucker", "mpstunt_overlays", "MP_MP_Stunt_Tat_033_M", "MP_MP_Stunt_Tat_033_F", 2450),
                new BusinessTattoo(new List<int>(){ 3, 4, 5, 6 }, "Feather Road Kill", "mpstunt_overlays", "MP_MP_Stunt_Tat_034_M", "MP_MP_Stunt_Tat_034_F", 1850),
                new BusinessTattoo(new List<int>(){ 5 }, "Big Grills", "mpstunt_overlays", "MP_MP_Stunt_Tat_037_M", "MP_MP_Stunt_Tat_037_F", 2450),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Monkey Chopper", "mpstunt_overlays", "MP_MP_Stunt_Tat_040_M", "MP_MP_Stunt_Tat_040_F", 3000),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Brapp", "mpstunt_overlays", "MP_MP_Stunt_Tat_041_M", "MP_MP_Stunt_Tat_041_F", 3000),
                new BusinessTattoo(new List<int>(){ 0, 1 }, "Ram Skull", "mpstunt_overlays", "MP_MP_Stunt_Tat_044_M", "MP_MP_Stunt_Tat_044_F", 3000),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Full Throttle", "mpstunt_overlays", "MP_MP_Stunt_Tat_046_M", "MP_MP_Stunt_Tat_046_F", 3050),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Racing Doll", "mpstunt_overlays", "MP_MP_Stunt_Tat_048_M", "MP_MP_Stunt_Tat_048_F", 3050),
                new BusinessTattoo(new List<int>(){ 0 }, "Blackjack", "multiplayer_overlays", "FM_Tat_Award_M_003", "FM_Tat_Award_F_003", 2000),
                new BusinessTattoo(new List<int>(){ 2 }, "Hustler", "multiplayer_overlays", "FM_Tat_Award_M_004", "FM_Tat_Award_F_004", 9250),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Angel", "multiplayer_overlays", "FM_Tat_Award_M_005", "FM_Tat_Award_F_005", 3500),
                new BusinessTattoo(new List<int>(){ 3, 4 }, "Los Santos Customs", "multiplayer_overlays", "FM_Tat_Award_M_008", "FM_Tat_Award_F_008", 2400),
                new BusinessTattoo(new List<int>(){ 1 }, "Blank Scroll", "multiplayer_overlays", "FM_Tat_Award_M_011", "FM_Tat_Award_F_011", 2700),
                new BusinessTattoo(new List<int>(){ 1 }, "Embellished Scroll", "multiplayer_overlays", "FM_Tat_Award_M_012", "FM_Tat_Award_F_012", 2700),
                new BusinessTattoo(new List<int>(){ 1 }, "Seven Deadly Sins", "multiplayer_overlays", "FM_Tat_Award_M_013", "FM_Tat_Award_F_013", 2000),
                new BusinessTattoo(new List<int>(){ 3, 4 }, "Trust No One", "multiplayer_overlays", "FM_Tat_Award_M_014", "FM_Tat_Award_F_014", 4050),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Clown", "multiplayer_overlays", "FM_Tat_Award_M_016", "FM_Tat_Award_F_016", 3000),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Clown and Gun", "multiplayer_overlays", "FM_Tat_Award_M_017", "FM_Tat_Award_F_017", 3500),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Clown Dual Wield", "multiplayer_overlays", "FM_Tat_Award_M_018", "FM_Tat_Award_F_018", 3000),
                new BusinessTattoo(new List<int>(){ 6, 6 }, "Clown Dual Wield Dollars", "multiplayer_overlays", "FM_Tat_Award_M_019", "FM_Tat_Award_F_019", 3000),
                new BusinessTattoo(new List<int>(){ 2 }, "Faith T", "multiplayer_overlays", "FM_Tat_M_004", "FM_Tat_F_004", 9100),
                new BusinessTattoo(new List<int>(){ 3, 4, 5, 6 }, "Skull on the Cross", "multiplayer_overlays", "FM_Tat_M_009", "FM_Tat_F_009", 1800),
                new BusinessTattoo(new List<int>(){ 1 }, "LS Flames", "multiplayer_overlays", "FM_Tat_M_010", "FM_Tat_F_010", 2000),
                new BusinessTattoo(new List<int>(){ 5 }, "LS Script", "multiplayer_overlays", "FM_Tat_M_011", "FM_Tat_F_011", 3000),
                new BusinessTattoo(new List<int>(){ 2 }, "Los Santos Bills", "multiplayer_overlays", "FM_Tat_M_012", "FM_Tat_F_012", 4500),
                new BusinessTattoo(new List<int>(){ 6 }, "Eagle and Serpent", "multiplayer_overlays", "FM_Tat_M_013", "FM_Tat_F_013", 3050),
                new BusinessTattoo(new List<int>(){ 3, 4, 5, 6 }, "Evil Clown", "multiplayer_overlays", "FM_Tat_M_016", "FM_Tat_F_016", 1550),
                new BusinessTattoo(new List<int>(){ 3, 4, 5, 6 }, "The Wages of Sin", "multiplayer_overlays", "FM_Tat_M_019", "FM_Tat_F_019", 1500),
                new BusinessTattoo(new List<int>(){ 3, 4, 5, 6 }, "Dragon T", "multiplayer_overlays", "FM_Tat_M_020", "FM_Tat_F_020", 1000),
                new BusinessTattoo(new List<int>(){ 0, 1, 2, 8 }, "Flaming Cross", "multiplayer_overlays", "FM_Tat_M_024", "FM_Tat_F_024", 2450),
                new BusinessTattoo(new List<int>(){ 0 }, "LS Bold", "multiplayer_overlays", "FM_Tat_M_025", "FM_Tat_F_025", 2700),
                new BusinessTattoo(new List<int>(){ 2, 8 }, "Trinity Knot", "multiplayer_overlays", "FM_Tat_M_029", "FM_Tat_F_029", 1200),
                new BusinessTattoo(new List<int>(){ 5, 6 }, "Lucky Celtic Dogs", "multiplayer_overlays", "FM_Tat_M_030", "FM_Tat_F_030", 3000),
                new BusinessTattoo(new List<int>(){ 1 }, "Flaming Shamrock", "multiplayer_overlays", "FM_Tat_M_034", "FM_Tat_F_034", 3700),
                new BusinessTattoo(new List<int>(){ 2 }, "Way of the Gun", "multiplayer_overlays", "FM_Tat_M_036", "FM_Tat_F_036", 4500),
                new BusinessTattoo(new List<int>(){ 0, 1 }, "Stone Cross", "multiplayer_overlays", "FM_Tat_M_044", "FM_Tat_F_044", 4000),
                new BusinessTattoo(new List<int>(){ 3, 4, 5, 6 }, "Skulls and Rose", "multiplayer_overlays", "FM_Tat_M_045", "FM_Tat_F_045", 1500),
            },

            // Head
            new List<BusinessTattoo>(){
	            // Передняя шея -   0
                // Левая шея    -   1
                // Правая шея   -   2
                // Задняя шея   -   3
	            // Левая щека - 4
                // Правая щека - 5

                new BusinessTattoo(new List<int>(){ 0 }, "Cash is King", "mpbusiness_overlays", "MP_Buis_M_Neck_000", String.Empty, 2475),
                new BusinessTattoo(new List<int>(){ 1 }, "Bold Dollar Sign", "mpbusiness_overlays", "MP_Buis_M_Neck_001", String.Empty, 2475),
                new BusinessTattoo(new List<int>(){ 2 }, "Script Dollar Sign", "mpbusiness_overlays", "MP_Buis_M_Neck_002", String.Empty, 2475),
                new BusinessTattoo(new List<int>(){ 3 }, "$100", "mpbusiness_overlays", "MP_Buis_M_Neck_003", String.Empty, 2475),
                new BusinessTattoo(new List<int>(){ 1 }, "Val-de-Grace Logo", "mpbusiness_overlays", String.Empty, "MP_Buis_F_Neck_000", 2475),
                new BusinessTattoo(new List<int>(){ 2 }, "Money Rose", "mpbusiness_overlays", String.Empty, "MP_Buis_F_Neck_001", 2475),
                new BusinessTattoo(new List<int>(){ 2 }, "Los Muertos", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_007", "MP_Xmas2_F_Tat_007", 2475),
                new BusinessTattoo(new List<int>(){ 1 }, "Snake Head Color", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_025", "MP_Xmas2_F_Tat_025", 2475),
                new BusinessTattoo(new List<int>(){ 2 }, "Beautiful Death", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_029", "MP_Xmas2_F_Tat_029", 2475),
                new BusinessTattoo(new List<int>(){ 1 }, "Lock & Load", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_003_M", "MP_Gunrunning_Tattoo_003_F", 2475),
                new BusinessTattoo(new List<int>(){ 2 }, "Beautiful Eye", "mphipster_overlays", "FM_Hip_M_Tat_005", "FM_Hip_F_Tat_005", 2475),
                new BusinessTattoo(new List<int>(){ 1 }, "Geo Fox", "mphipster_overlays", "FM_Hip_M_Tat_021", "FM_Hip_F_Tat_021", 2475),
                new BusinessTattoo(new List<int>(){ 5 }, "Morbid Arachnid", "mpbiker_overlays", "MP_MP_Biker_Tat_009_M", "MP_MP_Biker_Tat_009_F", 2475),
                new BusinessTattoo(new List<int>(){ 2 }, "FTW", "mpbiker_overlays", "MP_MP_Biker_Tat_038_M", "MP_MP_Biker_Tat_038_F", 2475),
                new BusinessTattoo(new List<int>(){ 1 }, "Western Stylized", "mpbiker_overlays", "MP_MP_Biker_Tat_051_M", "MP_MP_Biker_Tat_051_F", 2475),
                new BusinessTattoo(new List<int>(){ 1 }, "Sinner", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_011_M", "MP_Smuggler_Tattoo_011_F", 2475),
                new BusinessTattoo(new List<int>(){ 2 }, "Thief", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_012_M", "MP_Smuggler_Tattoo_012_F", 2475),
                new BusinessTattoo(new List<int>(){ 1 }, "Stunt Skull", "mpstunt_overlays", "MP_MP_Stunt_Tat_000_M", "MP_MP_Stunt_Tat_000_F", 2475),
                new BusinessTattoo(new List<int>(){ 5 }, "Scorpion", "mpstunt_overlays", "MP_MP_Stunt_Tat_004_M", "MP_MP_Stunt_Tat_004_F", 3000),
                new BusinessTattoo(new List<int>(){ 2 }, "Toxic Spider", "mpstunt_overlays", "MP_MP_Stunt_Tat_006_M", "MP_MP_Stunt_Tat_006_F", 3000),
                new BusinessTattoo(new List<int>(){ 2 }, "Bat Wheel", "mpstunt_overlays", "MP_MP_Stunt_Tat_017_M", "MP_MP_Stunt_Tat_017_F", 3000),
                //new BusinessTattoo(new List<int>(){ 2 }, "Flaming Quad", "mpstunt_overlays", "MP_MP_Stunt_Tat_042_M", "MP_MP_Stunt_Tat_042_F", 2475),
            },

            // Left Arm
            new List<BusinessTattoo>()
            {
                // Кисть        -   0
                // Bis zum Ellenbogen     -   1
                // Über dem Ellbogen   -   2

                new BusinessTattoo(new List<int>(){ 1 }, "$100 Bill", "mpbusiness_overlays", "MP_Buis_M_LeftArm_000", String.Empty, 2750),
                new BusinessTattoo(new List<int>(){ 1, 2 }, "All-Seeing Eye", "mpbusiness_overlays", "MP_Buis_M_LeftArm_001", String.Empty, 9900),
                new BusinessTattoo(new List<int>(){ 1 }, "Greed is Good", "mpbusiness_overlays", String.Empty, "MP_Buis_F_LArm_000", 2700),
                new BusinessTattoo(new List<int>(){ 1 }, "Skull Rider", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_000", "MP_Xmas2_F_Tat_000", 2720),
                new BusinessTattoo(new List<int>(){ 1 }, "Electric Snake", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_010", "MP_Xmas2_F_Tat_010", 2700),
                new BusinessTattoo(new List<int>(){ 2 }, "8 Ball Skull", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_012", "MP_Xmas2_F_Tat_012", 2700),
                new BusinessTattoo(new List<int>(){ 0 }, "Time's Up Outline", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_020", "MP_Xmas2_F_Tat_020", 1850),
                new BusinessTattoo(new List<int>(){ 0 }, "Time's Up Color", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_021", "MP_Xmas2_F_Tat_021", 1800),
                new BusinessTattoo(new List<int>(){ 0 }, "Sidearm", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_004_M", "MP_Gunrunning_Tattoo_004_F", 3350),
                new BusinessTattoo(new List<int>(){ 2 }, "Bandolier", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_008_M", "MP_Gunrunning_Tattoo_008_F", 2400),
                new BusinessTattoo(new List<int>(){ 1, 2 }, "Spiked Skull", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_015_M", "MP_Gunrunning_Tattoo_015_F", 9800),
                new BusinessTattoo(new List<int>(){ 2 }, "Blood Money", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_016_M", "MP_Gunrunning_Tattoo_016_F", 2000),
                new BusinessTattoo(new List<int>(){ 1 }, "Praying Skull", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_025_M", "MP_Gunrunning_Tattoo_025_F", 2000),
                new BusinessTattoo(new List<int>(){ 2 }, "Serpent Revolver", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_027_M", "MP_Gunrunning_Tattoo_027_F", 2250),
                new BusinessTattoo(new List<int>(){ 1 }, "Diamond Sparkle", "mphipster_overlays", "FM_Hip_M_Tat_003", "FM_Hip_F_Tat_003", 2700),
                new BusinessTattoo(new List<int>(){ 0 }, "Bricks", "mphipster_overlays", "FM_Hip_M_Tat_007", "FM_Hip_F_Tat_007", 1800),
                new BusinessTattoo(new List<int>(){ 2 }, "Mustache", "mphipster_overlays", "FM_Hip_M_Tat_015", "FM_Hip_F_Tat_015", 2700),
                new BusinessTattoo(new List<int>(){ 1 }, "Lightning Bolt", "mphipster_overlays", "FM_Hip_M_Tat_016", "FM_Hip_F_Tat_016", 2700),
                new BusinessTattoo(new List<int>(){ 2 }, "Pizza", "mphipster_overlays", "FM_Hip_M_Tat_026", "FM_Hip_F_Tat_026", 2700),
                new BusinessTattoo(new List<int>(){ 1 }, "Padlock", "mphipster_overlays", "FM_Hip_M_Tat_027", "FM_Hip_F_Tat_027", 3000),
                new BusinessTattoo(new List<int>(){ 1 }, "Thorny Rose", "mphipster_overlays", "FM_Hip_M_Tat_028", "FM_Hip_F_Tat_028", 3000),
                new BusinessTattoo(new List<int>(){ 0 }, "Stop", "mphipster_overlays", "FM_Hip_M_Tat_034", "FM_Hip_F_Tat_034", 1850),
                new BusinessTattoo(new List<int>(){ 2 }, "Sunrise", "mphipster_overlays", "FM_Hip_M_Tat_037", "FM_Hip_F_Tat_037", 2720),
                new BusinessTattoo(new List<int>(){ 1, 2 }, "Sleeve", "mphipster_overlays", "FM_Hip_M_Tat_039", "FM_Hip_F_Tat_039", 1500),
                new BusinessTattoo(new List<int>(){ 2 }, "Triangle White", "mphipster_overlays", "FM_Hip_M_Tat_043", "FM_Hip_F_Tat_043", 2750),
                new BusinessTattoo(new List<int>(){ 0 }, "Peace", "mphipster_overlays", "FM_Hip_M_Tat_048", "FM_Hip_F_Tat_048", 1800),
                new BusinessTattoo(new List<int>(){ 1, 2 }, "Piston Sleeve", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_004_M", "MP_MP_ImportExport_Tat_004_F", 9700),
                new BusinessTattoo(new List<int>(){ 1, 2 }, "Scarlett", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_008_M", "MP_MP_ImportExport_Tat_008_F", 5450),
                new BusinessTattoo(new List<int>(){ 1 }, "No Evil", "mplowrider_overlays", "MP_LR_Tat_005_M", "MP_LR_Tat_005_F", 2490),
                new BusinessTattoo(new List<int>(){ 2 }, "Los Santos Life", "mplowrider_overlays", "MP_LR_Tat_027_M", "MP_LR_Tat_027_F", 2000),
                new BusinessTattoo(new List<int>(){ 1, 2 }, "City Sorrow", "mplowrider_overlays", "MP_LR_Tat_033_M", "MP_LR_Tat_033_F", 9800),
                new BusinessTattoo(new List<int>(){ 1, 2 }, "Toxic Trails", "mpairraces_overlays", "MP_Airraces_Tattoo_003_M", "MP_Airraces_Tattoo_003_F", 4500),
                new BusinessTattoo(new List<int>(){ 1 }, "Urban Stunter", "mpbiker_overlays", "MP_MP_Biker_Tat_012_M", "MP_MP_Biker_Tat_012_F", 2750),
                new BusinessTattoo(new List<int>(){ 2 }, "Macabre Tree", "mpbiker_overlays", "MP_MP_Biker_Tat_016_M", "MP_MP_Biker_Tat_016_F", 3000),
                new BusinessTattoo(new List<int>(){ 2 }, "Cranial Rose", "mpbiker_overlays", "MP_MP_Biker_Tat_020_M", "MP_MP_Biker_Tat_020_F", 2700),
                new BusinessTattoo(new List<int>(){ 1, 2 }, "Live to Ride", "mpbiker_overlays", "MP_MP_Biker_Tat_024_M", "MP_MP_Biker_Tat_024_F", 9800),
                new BusinessTattoo(new List<int>(){ 2 }, "Good Luck", "mpbiker_overlays", "MP_MP_Biker_Tat_025_M", "MP_MP_Biker_Tat_025_F", 1500),
                new BusinessTattoo(new List<int>(){ 2 }, "Chain Fist", "mpbiker_overlays", "MP_MP_Biker_Tat_035_M", "MP_MP_Biker_Tat_035_F", 3600),
                new BusinessTattoo(new List<int>(){ 2 }, "Ride Hard Die Fast", "mpbiker_overlays", "MP_MP_Biker_Tat_045_M", "MP_MP_Biker_Tat_045_F", 2700),
                new BusinessTattoo(new List<int>(){ 1 }, "Muffler Helmet", "mpbiker_overlays", "MP_MP_Biker_Tat_053_M", "MP_MP_Biker_Tat_053_F", 2720),
                new BusinessTattoo(new List<int>(){ 2 }, "Poison Scorpion", "mpbiker_overlays", "MP_MP_Biker_Tat_055_M", "MP_MP_Biker_Tat_055_F", 2700),
                new BusinessTattoo(new List<int>(){ 2 }, "Love Hustle", "mplowrider2_overlays", "MP_LR_Tat_006_M", "MP_LR_Tat_006_F", 2700),
                new BusinessTattoo(new List<int>(){ 1, 2 }, "Skeleton Party", "mplowrider2_overlays", "MP_LR_Tat_018_M", "MP_LR_Tat_018_F", 2700),
                new BusinessTattoo(new List<int>(){ 1 }, "My Crazy Life", "mplowrider2_overlays", "MP_LR_Tat_022_M", "MP_LR_Tat_022_F", 2750),
                new BusinessTattoo(new List<int>(){ 2 }, "Archangel & Mary", "mpluxe_overlays", "MP_LUXE_TAT_020_M", "MP_LUXE_TAT_020_F", 2700),
                new BusinessTattoo(new List<int>(){ 1 }, "Gabriel", "mpluxe_overlays", "MP_LUXE_TAT_021_M", "MP_LUXE_TAT_021_F", 2700),
                new BusinessTattoo(new List<int>(){ 1 }, "Fatal Dagger", "mpluxe2_overlays", "MP_LUXE_TAT_005_M", "MP_LUXE_TAT_005_F", 2700),
                new BusinessTattoo(new List<int>(){ 1 }, "Egyptian Mural", "mpluxe2_overlays", "MP_LUXE_TAT_016_M", "MP_LUXE_TAT_016_F", 2400),
                new BusinessTattoo(new List<int>(){ 2 }, "Divine Goddess", "mpluxe2_overlays", "MP_LUXE_TAT_018_M", "MP_LUXE_TAT_018_F", 2490),
                new BusinessTattoo(new List<int>(){ 1 }, "Python Skull", "mpluxe2_overlays", "MP_LUXE_TAT_028_M", "MP_LUXE_TAT_028_F", 9250),
                new BusinessTattoo(new List<int>(){ 1, 2 }, "Geometric Design LA", "mpluxe2_overlays", "MP_LUXE_TAT_031_M", "MP_LUXE_TAT_031_F", 9800),
                new BusinessTattoo(new List<int>(){ 1 }, "Honor", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_004_M", "MP_Smuggler_Tattoo_004_F", 2700),
                new BusinessTattoo(new List<int>(){ 1 }, "Horrors Of The Deep", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_008_M", "MP_Smuggler_Tattoo_008_F", 2720),
                new BusinessTattoo(new List<int>(){ 1, 2 }, "Mermaid's Curse", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_014_M", "MP_Smuggler_Tattoo_014_F", 9800),
                new BusinessTattoo(new List<int>(){ 2 }, "8 Eyed Skull", "mpstunt_overlays", "MP_MP_Stunt_Tat_001_M", "MP_MP_Stunt_Tat_001_F", 2450),
                new BusinessTattoo(new List<int>(){ 0 }, "Big Cat", "mpstunt_overlays", "MP_MP_Stunt_Tat_002_M", "MP_MP_Stunt_Tat_002_F", 1850),
                new BusinessTattoo(new List<int>(){ 2 }, "Moonlight Ride", "mpstunt_overlays", "MP_MP_Stunt_Tat_008_M", "MP_MP_Stunt_Tat_008_F", 2700),
                new BusinessTattoo(new List<int>(){ 1 }, "Piston Head", "mpstunt_overlays", "MP_MP_Stunt_Tat_022_M", "MP_MP_Stunt_Tat_022_F", 2700),
                new BusinessTattoo(new List<int>(){ 1, 2 }, "Tanked", "mpstunt_overlays", "MP_MP_Stunt_Tat_023_M", "MP_MP_Stunt_Tat_023_F", 5470),
                new BusinessTattoo(new List<int>(){ 1 }, "Stuntman's End", "mpstunt_overlays", "MP_MP_Stunt_Tat_035_M", "MP_MP_Stunt_Tat_035_F", 2700),
                new BusinessTattoo(new List<int>(){ 2 }, "Kaboom", "mpstunt_overlays", "MP_MP_Stunt_Tat_039_M", "MP_MP_Stunt_Tat_039_F", 2720),
                new BusinessTattoo(new List<int>(){ 2 }, "Engine Arm", "mpstunt_overlays", "MP_MP_Stunt_Tat_043_M", "MP_MP_Stunt_Tat_043_F", 2700),
                new BusinessTattoo(new List<int>(){ 1 }, "Burning Heart", "multiplayer_overlays", "FM_Tat_Award_M_001", "FM_Tat_Award_F_001", 2750),
                new BusinessTattoo(new List<int>(){ 2 }, "Racing Blonde", "multiplayer_overlays", "FM_Tat_Award_M_007", "FM_Tat_Award_F_007", 2720),
                new BusinessTattoo(new List<int>(){ 2 }, "Racing Brunette", "multiplayer_overlays", "FM_Tat_Award_M_015", "FM_Tat_Award_F_015", 2750),
                //new BusinessTattoo(new List<int>(){ 1, 2 }, "Serpents", "multiplayer_overlays", "FM_Tat_M_005", "FM_Tat_F_005", 2490),
                //new BusinessTattoo(new List<int>(){ 1, 2 }, "Oriental Mural", "multiplayer_overlays", "FM_Tat_M_006", "FM_Tat_F_006", 9800),
                //new BusinessTattoo(new List<int>(){ 2 }, "Zodiac Skull", "multiplayer_overlays", "FM_Tat_M_015", "FM_Tat_F_015", 2700),
                //new BusinessTattoo(new List<int>(){ 2 }, "Lady M", "multiplayer_overlays", "FM_Tat_M_031", "FM_Tat_F_031", 2720),
                //new BusinessTattoo(new List<int>(){ 2 }, "Dope Skull", "multiplayer_overlays", "FM_Tat_M_041", "FM_Tat_F_041", 2700),
            },
            
            // RightArm
            new List<BusinessTattoo>()
            {
                // Кисть        -   0
                // До локтя     -   1
                // Выше локтя   -   2

                new BusinessTattoo(new List<int>(){ 2 }, "Dollar Skull", "mpbusiness_overlays", "MP_Buis_M_RightArm_000", String.Empty, 2490),
                new BusinessTattoo(new List<int>(){ 1 }, "Green", "mpbusiness_overlays", "MP_Buis_M_RightArm_001", String.Empty, 2490),
                new BusinessTattoo(new List<int>(){ 1 }, "Dollar Sign", "mpbusiness_overlays", String.Empty, "MP_Buis_F_RArm_000", 2700),
                new BusinessTattoo(new List<int>(){ 2 }, "Snake Outline", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_003", "MP_Xmas2_F_Tat_003", 2490),
                new BusinessTattoo(new List<int>(){ 2 }, "Snake Shaded", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_004", "MP_Xmas2_F_Tat_004", 2720),
                new BusinessTattoo(new List<int>(){ 1 }, "Death Before Dishonor", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_008", "MP_Xmas2_F_Tat_008", 2700),
                new BusinessTattoo(new List<int>(){ 1 }, "You're Next Outline", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_022", "MP_Xmas2_F_Tat_022", 3000),
                new BusinessTattoo(new List<int>(){ 1 }, "You're Next Color", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_023", "MP_Xmas2_F_Tat_023", 2700),
                new BusinessTattoo(new List<int>(){ 0 }, "Fuck Luck Outline", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_026", "MP_Xmas2_F_Tat_026", 1850),
                new BusinessTattoo(new List<int>(){ 0 }, "Fuck Luck Color", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_027", "MP_Xmas2_F_Tat_027", 1820),
                new BusinessTattoo(new List<int>(){ 0 }, "Grenade", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_002_M", "MP_Gunrunning_Tattoo_002_F", 1850),
                new BusinessTattoo(new List<int>(){ 2 }, "Have a Nice Day", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_021_M", "MP_Gunrunning_Tattoo_021_F", 2400),
                new BusinessTattoo(new List<int>(){ 1 }, "Combat Reaper", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_024_M", "MP_Gunrunning_Tattoo_024_F", 2720),
                new BusinessTattoo(new List<int>(){ 2 }, "Single Arrow", "mphipster_overlays", "FM_Hip_M_Tat_001", "FM_Hip_F_Tat_001", 2700),
                new BusinessTattoo(new List<int>(){ 1 }, "Bone", "mphipster_overlays", "FM_Hip_M_Tat_004", "FM_Hip_F_Tat_004", 2700),
                new BusinessTattoo(new List<int>(){ 2 }, "Cube", "mphipster_overlays", "FM_Hip_M_Tat_008", "FM_Hip_F_Tat_008", 2700),
                new BusinessTattoo(new List<int>(){ 0 }, "Horseshoe", "mphipster_overlays", "FM_Hip_M_Tat_010", "FM_Hip_F_Tat_010", 1820),
                new BusinessTattoo(new List<int>(){ 1 }, "Spray Can", "mphipster_overlays", "FM_Hip_M_Tat_014", "FM_Hip_F_Tat_014", 1800),
                new BusinessTattoo(new List<int>(){ 1 }, "Eye Triangle", "mphipster_overlays", "FM_Hip_M_Tat_017", "FM_Hip_F_Tat_017", 1850),
                new BusinessTattoo(new List<int>(){ 1 }, "Origami", "mphipster_overlays", "FM_Hip_M_Tat_018", "FM_Hip_F_Tat_018", 2700),
                new BusinessTattoo(new List<int>(){ 1, 2 }, "Geo Pattern", "mphipster_overlays", "FM_Hip_M_Tat_020", "FM_Hip_F_Tat_020", 9800),
                new BusinessTattoo(new List<int>(){ 1 }, "Pencil", "mphipster_overlays", "FM_Hip_M_Tat_022", "FM_Hip_F_Tat_022", 2700),
                new BusinessTattoo(new List<int>(){ 0 }, "Smiley", "mphipster_overlays", "FM_Hip_M_Tat_023", "FM_Hip_F_Tat_023", 1850),
                new BusinessTattoo(new List<int>(){ 2 }, "Shapes", "mphipster_overlays", "FM_Hip_M_Tat_036", "FM_Hip_F_Tat_036",2700),
                new BusinessTattoo(new List<int>(){ 2 }, "Triangle Black", "mphipster_overlays", "FM_Hip_M_Tat_044", "FM_Hip_F_Tat_044",2700),
                new BusinessTattoo(new List<int>(){ 1 }, "Mesh Band", "mphipster_overlays", "FM_Hip_M_Tat_045", "FM_Hip_F_Tat_045", 2750),
                new BusinessTattoo(new List<int>(){ 1, 2 }, "Mechanical Sleeve", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_003_M", "MP_MP_ImportExport_Tat_003_F", 9880),
                new BusinessTattoo(new List<int>(){ 1, 2 }, "Dialed In", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_005_M", "MP_MP_ImportExport_Tat_005_F", 9850),
                new BusinessTattoo(new List<int>(){ 1, 2 }, "Engulfed Block", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_006_M", "MP_MP_ImportExport_Tat_006_F", 9800),
                new BusinessTattoo(new List<int>(){ 1, 2 }, "Drive Forever", "mpimportexport_overlays", "MP_MP_ImportExport_Tat_007_M", "MP_MP_ImportExport_Tat_007_F", 9800),
                new BusinessTattoo(new List<int>(){ 1 }, "Seductress", "mplowrider_overlays", "MP_LR_Tat_015_M", "MP_LR_Tat_015_F", 3980),
                new BusinessTattoo(new List<int>(){ 2 }, "Swooping Eagle", "mpbiker_overlays", "MP_MP_Biker_Tat_007_M", "MP_MP_Biker_Tat_007_F", 2700),
                new BusinessTattoo(new List<int>(){ 2 }, "Lady Mortality", "mpbiker_overlays", "MP_MP_Biker_Tat_014_M", "MP_MP_Biker_Tat_014_F", 2720),
                new BusinessTattoo(new List<int>(){ 2 }, "Eagle Emblem", "mpbiker_overlays", "MP_MP_Biker_Tat_033_M", "MP_MP_Biker_Tat_033_F", 3980),
                new BusinessTattoo(new List<int>(){ 1 }, "Grim Rider", "mpbiker_overlays", "MP_MP_Biker_Tat_042_M", "MP_MP_Biker_Tat_042_F", 2720),
                new BusinessTattoo(new List<int>(){ 2 }, "Skull Chain", "mpbiker_overlays", "MP_MP_Biker_Tat_046_M", "MP_MP_Biker_Tat_046_F", 2700),
                new BusinessTattoo(new List<int>(){ 1, 2 }, "Snake Bike", "mpbiker_overlays", "MP_MP_Biker_Tat_047_M", "MP_MP_Biker_Tat_047_F", 9800),
                new BusinessTattoo(new List<int>(){ 2 }, "These Colors Don't Run", "mpbiker_overlays", "MP_MP_Biker_Tat_049_M", "MP_MP_Biker_Tat_049_F", 2700),
                new BusinessTattoo(new List<int>(){ 2 }, "Mum", "mpbiker_overlays", "MP_MP_Biker_Tat_054_M", "MP_MP_Biker_Tat_054_F", 2750),
                new BusinessTattoo(new List<int>(){ 1 }, "Lady Vamp", "mplowrider2_overlays", "MP_LR_Tat_003_M", "MP_LR_Tat_003_F", 2400),
                new BusinessTattoo(new List<int>(){ 2 }, "Loving Los Muertos", "mplowrider2_overlays", "MP_LR_Tat_028_M", "MP_LR_Tat_028_F", 2720),
                new BusinessTattoo(new List<int>(){ 1 }, "Black Tears", "mplowrider2_overlays", "MP_LR_Tat_035_M", "MP_LR_Tat_035_F", 2750),
                new BusinessTattoo(new List<int>(){ 1 }, "Floral Raven", "mpluxe_overlays", "MP_LUXE_TAT_004_M", "MP_LUXE_TAT_004_F", 2700),
                new BusinessTattoo(new List<int>(){ 1, 2 }, "Mermaid Harpist", "mpluxe_overlays", "MP_LUXE_TAT_013_M", "MP_LUXE_TAT_013_F", 9800),
                new BusinessTattoo(new List<int>(){ 2 }, "Geisha Bloom", "mpluxe_overlays", "MP_LUXE_TAT_019_M", "MP_LUXE_TAT_019_F", 2490),
                new BusinessTattoo(new List<int>(){ 1 }, "Intrometric", "mpluxe2_overlays", "MP_LUXE_TAT_010_M", "MP_LUXE_TAT_010_F", 2490),
                new BusinessTattoo(new List<int>(){ 2 }, "Heavenly Deity", "mpluxe2_overlays", "MP_LUXE_TAT_017_M", "MP_LUXE_TAT_017_F", 2470),
                new BusinessTattoo(new List<int>(){ 2 }, "Floral Print", "mpluxe2_overlays", "MP_LUXE_TAT_026_M", "MP_LUXE_TAT_026_F", 2700),
                new BusinessTattoo(new List<int>(){ 1, 2 }, "Geometric Design RA", "mpluxe2_overlays", "MP_LUXE_TAT_030_M", "MP_LUXE_TAT_030_F", 9800),
                new BusinessTattoo(new List<int>(){ 1 }, "Crackshot", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_001_M", "MP_Smuggler_Tattoo_001_F", 2700),
                new BusinessTattoo(new List<int>(){ 2 }, "Mutiny", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_005_M", "MP_Smuggler_Tattoo_005_F", 3980),
                new BusinessTattoo(new List<int>(){ 1, 2 }, "Stylized Kraken", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_023_M", "MP_Smuggler_Tattoo_023_F", 9800),
                new BusinessTattoo(new List<int>(){ 1 }, "Poison Wrench", "mpstunt_overlays", "MP_MP_Stunt_Tat_003_M", "MP_MP_Stunt_Tat_003_F", 2470),
                new BusinessTattoo(new List<int>(){ 2 }, "Arachnid of Death", "mpstunt_overlays", "MP_MP_Stunt_Tat_009_M", "MP_MP_Stunt_Tat_009_F", 2720),
                new BusinessTattoo(new List<int>(){ 2 }, "Grave Vulture", "mpstunt_overlays", "MP_MP_Stunt_Tat_010_M", "MP_MP_Stunt_Tat_010_F", 2400),
                new BusinessTattoo(new List<int>(){ 1, 2 }, "Coffin Racer", "mpstunt_overlays", "MP_MP_Stunt_Tat_016_M", "MP_MP_Stunt_Tat_016_F", 9800),
                new BusinessTattoo(new List<int>(){ 0 }, "Biker Stallion", "mpstunt_overlays", "MP_MP_Stunt_Tat_036_M", "MP_MP_Stunt_Tat_036_F", 1850),
                new BusinessTattoo(new List<int>(){ 1 }, "One Down Five Up", "mpstunt_overlays", "MP_MP_Stunt_Tat_038_M", "MP_MP_Stunt_Tat_038_F", 2750),
                new BusinessTattoo(new List<int>(){ 1, 2 }, "Seductive Mechanic", "mpstunt_overlays", "MP_MP_Stunt_Tat_049_M", "MP_MP_Stunt_Tat_049_F", 9800),
                new BusinessTattoo(new List<int>(){ 2 }, "Grim Reaper Smoking Gun", "multiplayer_overlays", "FM_Tat_Award_M_002", "FM_Tat_Award_F_002", 2250),
                new BusinessTattoo(new List<int>(){ 1 }, "Ride or Die RA", "multiplayer_overlays", "FM_Tat_Award_M_010", "FM_Tat_Award_F_010", 2700),
                new BusinessTattoo(new List<int>(){ 1, 2 }, "Brotherhood", "multiplayer_overlays", "FM_Tat_M_000", "FM_Tat_F_000", 9800),
                new BusinessTattoo(new List<int>(){ 1, 2 }, "Dragons", "multiplayer_overlays", "FM_Tat_M_001", "FM_Tat_F_001", 9800),
                new BusinessTattoo(new List<int>(){ 2 }, "Dragons and Skull", "multiplayer_overlays", "FM_Tat_M_003", "FM_Tat_F_003", 2250),
                new BusinessTattoo(new List<int>(){ 1, 2 }, "Flower Mural", "multiplayer_overlays", "FM_Tat_M_014", "FM_Tat_F_014", 9800),
                new BusinessTattoo(new List<int>(){ 1, 2, 0 }, "Serpent Skull RA", "multiplayer_overlays", "FM_Tat_M_018", "FM_Tat_F_018", 1500),
                //new BusinessTattoo(new List<int>(){ 2 }, "Virgin Mary", "multiplayer_overlays", "FM_Tat_M_027", "FM_Tat_F_027", 2250),
                //new BusinessTattoo(new List<int>(){ 1 }, "Mermaid", "multiplayer_overlays", "FM_Tat_M_028", "FM_Tat_F_028", 2720),
                //new BusinessTattoo(new List<int>(){ 1 }, "Dagger", "multiplayer_overlays", "FM_Tat_M_038", "FM_Tat_F_038", 2700),
                //new BusinessTattoo(new List<int>(){ 2 }, "Lion", "multiplayer_overlays", "FM_Tat_M_047", "FM_Tat_F_047", 2700),
            },

            // LeftLeg
            new List<BusinessTattoo>()
            {
	            // До колена    -   0
                // Выше колена  -   1

                new BusinessTattoo(new List<int>(){ 0 }, "Single", "mpbusiness_overlays", String.Empty, "MP_Buis_F_LLeg_000", 2720),
                new BusinessTattoo(new List<int>(){ 0 }, "Spider Outline", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_001", "MP_Xmas2_F_Tat_001", 2725),
                new BusinessTattoo(new List<int>(){ 0 }, "Spider Color", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_002", "MP_Xmas2_F_Tat_002", 2720),
                new BusinessTattoo(new List<int>(){ 0 }, "Patriot Skull", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_005_M", "MP_Gunrunning_Tattoo_005_F", 2750),
                new BusinessTattoo(new List<int>(){ 1 }, "Stylized Tiger", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_007_M", "MP_Gunrunning_Tattoo_007_F", 2700),
                new BusinessTattoo(new List<int>(){ 0, 1 }, "Death Skull", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_011_M", "MP_Gunrunning_Tattoo_011_F", 9500),
                new BusinessTattoo(new List<int>(){ 1 }, "Rose Revolver", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_023_M", "MP_Gunrunning_Tattoo_023_F", 2750),
                new BusinessTattoo(new List<int>(){ 0 }, "Squares", "mphipster_overlays", "FM_Hip_M_Tat_009", "FM_Hip_F_Tat_009", 2700),
                new BusinessTattoo(new List<int>(){ 0 }, "Charm", "mphipster_overlays", "FM_Hip_M_Tat_019", "FM_Hip_F_Tat_019", 2720),
                new BusinessTattoo(new List<int>(){ 0 }, "Black Anchor", "mphipster_overlays", "FM_Hip_M_Tat_040", "FM_Hip_F_Tat_040", 2700),
                new BusinessTattoo(new List<int>(){ 0 }, "LS Serpent", "mplowrider_overlays", "MP_LR_Tat_007_M", "MP_LR_Tat_007_F", 2750),
                new BusinessTattoo(new List<int>(){ 0 }, "Presidents", "mplowrider_overlays", "MP_LR_Tat_020_M", "MP_LR_Tat_020_F", 2700),
                new BusinessTattoo(new List<int>(){ 0 }, "Rose Tribute", "mpbiker_overlays", "MP_MP_Biker_Tat_002_M", "MP_MP_Biker_Tat_002_F", 2720),
                new BusinessTattoo(new List<int>(){ 0 }, "Ride or Die LL", "mpbiker_overlays", "MP_MP_Biker_Tat_015_M", "MP_MP_Biker_Tat_015_F", 2000),
                new BusinessTattoo(new List<int>(){ 0 }, "Bad Luck", "mpbiker_overlays", "MP_MP_Biker_Tat_027_M", "MP_MP_Biker_Tat_027_F", 2720),
                new BusinessTattoo(new List<int>(){ 0 }, "Engulfed Skull", "mpbiker_overlays", "MP_MP_Biker_Tat_036_M", "MP_MP_Biker_Tat_036_F", 2250),
                new BusinessTattoo(new List<int>(){ 1 }, "Scorched Soul", "mpbiker_overlays", "MP_MP_Biker_Tat_037_M", "MP_MP_Biker_Tat_037_F", 2720),
                new BusinessTattoo(new List<int>(){ 1 }, "Ride Free", "mpbiker_overlays", "MP_MP_Biker_Tat_044_M", "MP_MP_Biker_Tat_044_F", 2250),
                new BusinessTattoo(new List<int>(){ 1 }, "Bone Cruiser", "mpbiker_overlays", "MP_MP_Biker_Tat_056_M", "MP_MP_Biker_Tat_056_F", 2750),
                new BusinessTattoo(new List<int>(){ 0, 1 }, "Laughing Skull", "mpbiker_overlays", "MP_MP_Biker_Tat_057_M", "MP_MP_Biker_Tat_057_F", 9500),
                new BusinessTattoo(new List<int>(){ 0 }, "Death Us Do Part", "mplowrider2_overlays", "MP_LR_Tat_029_M", "MP_LR_Tat_029_F", 2750),
                new BusinessTattoo(new List<int>(){ 0 }, "Serpent of Death", "mpluxe_overlays", "MP_LUXE_TAT_000_M", "MP_LUXE_TAT_000_F", 2750),
                new BusinessTattoo(new List<int>(){ 0 }, "Cross of Roses", "mpluxe2_overlays", "MP_LUXE_TAT_011_M", "MP_LUXE_TAT_011_F", 2750),
                new BusinessTattoo(new List<int>(){ 0 }, "Dagger Devil", "mpstunt_overlays", "MP_MP_Stunt_Tat_007_M", "MP_MP_Stunt_Tat_007_F", 2400),
                new BusinessTattoo(new List<int>(){ 1 }, "Dirt Track Hero", "mpstunt_overlays", "MP_MP_Stunt_Tat_013_M", "MP_MP_Stunt_Tat_013_F", 2000),
                new BusinessTattoo(new List<int>(){ 0, 1 }, "Golden Cobra", "mpstunt_overlays", "MP_MP_Stunt_Tat_021_M", "MP_MP_Stunt_Tat_021_F", 900),
                new BusinessTattoo(new List<int>(){ 0 }, "Quad Goblin", "mpstunt_overlays", "MP_MP_Stunt_Tat_028_M", "MP_MP_Stunt_Tat_028_F", 2700),
                new BusinessTattoo(new List<int>(){ 0 }, "Stunt Jesus", "mpstunt_overlays", "MP_MP_Stunt_Tat_031_M", "MP_MP_Stunt_Tat_031_F", 2750),
                new BusinessTattoo(new List<int>(){ 0 }, "Dragon and Dagger", "multiplayer_overlays", "FM_Tat_Award_M_009", "FM_Tat_Award_F_009", 2250),
                new BusinessTattoo(new List<int>(){ 0 }, "Melting Skull", "multiplayer_overlays", "FM_Tat_M_002", "FM_Tat_F_002", 2250),
                new BusinessTattoo(new List<int>(){ 0 }, "Dragon Mural", "multiplayer_overlays", "FM_Tat_M_008", "FM_Tat_F_008", 2750),
                new BusinessTattoo(new List<int>(){ 0 }, "Serpent Skull LL", "multiplayer_overlays", "FM_Tat_M_021", "FM_Tat_F_021", 2750),
                new BusinessTattoo(new List<int>(){ 0 }, "Hottie", "multiplayer_overlays", "FM_Tat_M_023", "FM_Tat_F_023", 2750),
                new BusinessTattoo(new List<int>(){ 0 }, "Smoking Dagger", "multiplayer_overlays", "FM_Tat_M_026", "FM_Tat_F_026", 2750),
                new BusinessTattoo(new List<int>(){ 0 }, "Faith LL", "multiplayer_overlays", "FM_Tat_M_032", "FM_Tat_F_032", 2750),
                new BusinessTattoo(new List<int>(){ 0, 1 }, "Chinese Dragon", "multiplayer_overlays", "FM_Tat_M_033", "FM_Tat_F_033", 9500),
                //new BusinessTattoo(new List<int>(){ 0 }, "Dragon LL", "multiplayer_overlays", "FM_Tat_M_035", "FM_Tat_F_035", 2700),
                //new BusinessTattoo(new List<int>(){ 0 }, "Grim Reaper", "multiplayer_overlays", "FM_Tat_M_037", "FM_Tat_F_037", 2250),
            },
            
            // RightLeg
            new List<BusinessTattoo>()
            {
	            // До колена    -   0
                // Выше колена  -   1

                new BusinessTattoo(new List<int>(){ 0 }, "Diamond Crown", "mpbusiness_overlays", String.Empty, "MP_Buis_F_RLeg_000", 2700),
                new BusinessTattoo(new List<int>(){ 0 }, "Floral Dagger", "mpchristmas2_overlays", "MP_Xmas2_M_Tat_014", "MP_Xmas2_F_Tat_014", 2470),
                new BusinessTattoo(new List<int>(){ 0 }, "Combat Skull", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_006_M", "MP_Gunrunning_Tattoo_006_F", 2700),
                new BusinessTattoo(new List<int>(){ 0 }, "Restless Skull", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_026_M", "MP_Gunrunning_Tattoo_026_F", 2750),
                new BusinessTattoo(new List<int>(){ 1 }, "Pistol Ace", "mpgunrunning_overlays", "MP_Gunrunning_Tattoo_030_M", "MP_Gunrunning_Tattoo_030_F", 5280),
                new BusinessTattoo(new List<int>(){ 0 }, "Grub", "mphipster_overlays", "FM_Hip_M_Tat_038", "FM_Hip_F_Tat_038", 2700),
                new BusinessTattoo(new List<int>(){ 0 }, "Sparkplug", "mphipster_overlays", "FM_Hip_M_Tat_042", "FM_Hip_F_Tat_042", 2700),
                new BusinessTattoo(new List<int>(){ 0 }, "Ink Me", "mplowrider_overlays", "MP_LR_Tat_017_M", "MP_LR_Tat_017_F", 2700),
                new BusinessTattoo(new List<int>(){ 0 }, "Dance of Hearts", "mplowrider_overlays", "MP_LR_Tat_023_M", "MP_LR_Tat_023_F", 2750),
                new BusinessTattoo(new List<int>(){ 0, 1 }, "Dragon's Fury", "mpbiker_overlays", "MP_MP_Biker_Tat_004_M", "MP_MP_Biker_Tat_004_F", 9500),
                new BusinessTattoo(new List<int>(){ 0 }, "Western Insignia", "mpbiker_overlays", "MP_MP_Biker_Tat_022_M", "MP_MP_Biker_Tat_022_F", 2700),
                new BusinessTattoo(new List<int>(){ 1 }, "Dusk Rider", "mpbiker_overlays", "MP_MP_Biker_Tat_028_M", "MP_MP_Biker_Tat_028_F", 2700),
                new BusinessTattoo(new List<int>(){ 1 }, "American Made", "mpbiker_overlays", "MP_MP_Biker_Tat_040_M", "MP_MP_Biker_Tat_040_F", 2750),
                new BusinessTattoo(new List<int>(){ 0 }, "STFU", "mpbiker_overlays", "MP_MP_Biker_Tat_048_M", "MP_MP_Biker_Tat_048_F", 2700),
                new BusinessTattoo(new List<int>(){ 0 }, "San Andreas Prayer", "mplowrider2_overlays", "MP_LR_Tat_030_M", "MP_LR_Tat_030_F", 2250),
                new BusinessTattoo(new List<int>(){ 0 }, "Elaborate Los Muertos", "mpluxe_overlays", "MP_LUXE_TAT_001_M", "MP_LUXE_TAT_001_F", 2750),
                new BusinessTattoo(new List<int>(){ 0 }, "Starmetric", "mpluxe2_overlays", "MP_LUXE_TAT_023_M", "MP_LUXE_TAT_023_F", 2450),
                new BusinessTattoo(new List<int>(){ 0, 1 }, "Homeward Bound", "mpsmuggler_overlays", "MP_Smuggler_Tattoo_020_M", "MP_Smuggler_Tattoo_020_F", 9500),
                new BusinessTattoo(new List<int>(){ 0 }, "Demon Spark Plug", "mpstunt_overlays", "MP_MP_Stunt_Tat_005_M", "MP_MP_Stunt_Tat_005_F", 2750),
                new BusinessTattoo(new List<int>(){ 1 }, "Praying Gloves", "mpstunt_overlays", "MP_MP_Stunt_Tat_015_M", "MP_MP_Stunt_Tat_015_F", 2750),
                new BusinessTattoo(new List<int>(){ 0 }, "Piston Angel", "mpstunt_overlays", "MP_MP_Stunt_Tat_020_M", "MP_MP_Stunt_Tat_020_F", 2750),
                new BusinessTattoo(new List<int>(){ 1 }, "Speed Freak", "mpstunt_overlays", "MP_MP_Stunt_Tat_025_M", "MP_MP_Stunt_Tat_025_F", 2700),
                new BusinessTattoo(new List<int>(){ 0 }, "Wheelie Mouse", "mpstunt_overlays", "MP_MP_Stunt_Tat_032_M", "MP_MP_Stunt_Tat_032_F", 2470),
                new BusinessTattoo(new List<int>(){ 0, 1 }, "Severed Hand", "mpstunt_overlays", "MP_MP_Stunt_Tat_045_M", "MP_MP_Stunt_Tat_045_F", 9500),
                new BusinessTattoo(new List<int>(){ 0 }, "Brake Knife", "mpstunt_overlays", "MP_MP_Stunt_Tat_047_M", "MP_MP_Stunt_Tat_047_F", 2470),
                new BusinessTattoo(new List<int>(){ 0 }, "Skull and Sword", "multiplayer_overlays", "FM_Tat_Award_M_006", "FM_Tat_Award_F_006", 2250),
                new BusinessTattoo(new List<int>(){ 0 }, "The Warrior", "multiplayer_overlays", "FM_Tat_M_007", "FM_Tat_F_007", 2750),
                new BusinessTattoo(new List<int>(){ 0 }, "Tribal", "multiplayer_overlays", "FM_Tat_M_017", "FM_Tat_F_017", 2700),
                new BusinessTattoo(new List<int>(){ 0 }, "Fiery Dragon", "multiplayer_overlays", "FM_Tat_M_022", "FM_Tat_F_022", 2750),
                new BusinessTattoo(new List<int>(){ 0 }, "Broken Skull", "multiplayer_overlays", "FM_Tat_M_039", "FM_Tat_F_039", 2720),
                new BusinessTattoo(new List<int>(){ 0, 1 }, "Flaming Skull", "multiplayer_overlays", "FM_Tat_M_040", "FM_Tat_F_040", 9400),
                new BusinessTattoo(new List<int>(){ 0 }, "Flaming Scorpion", "multiplayer_overlays", "FM_Tat_M_042", "FM_Tat_F_042", 2250),
                //new BusinessTattoo(new List<int>(){ 0 }, "Indian Ram", "multiplayer_overlays", "FM_Tat_M_043", "FM_Tat_F_043", 2750)
            }

        };
        public static Dictionary<string, Dictionary<int, List<Tuple<int, string, int>>>> Tuning = new Dictionary<string, Dictionary<int, List<Tuple<int, string, int>>>>()
        {
            { "Panto", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Auspuff", 300),
                    new Tuple<int, string, int>(0, "Titan Auspuff", 300),
                    new Tuple<int, string, int>(1, "Chrome Auspuff", 300),
                    new Tuple<int, string, int>(2, "Tuner-Titan-Auspuff", 300),
                    new Tuple<int, string, int>(3, "Shakotan-Auspuff", 300),
                    new Tuple<int, string, int>(4, "Seiten-Auspuff", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schweller", 400),
                    new Tuple<int, string, int>(0, "Niedrige Schweller", 400),
                    new Tuple<int, string, int>(1, "Sportschweller", 400),
                    new Tuple<int, string, int>(2, "Schweller in Aufklebern", 400),
                    new Tuple<int, string, int>(3, "Carbon Schweller", 400),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Kein Spoiler", 300),
                    new Tuple<int, string, int>(0, "Lackierter Spoiler", 300),
                    new Tuple<int, string, int>(1, "Carbon-Spoiler", 300),
                    new Tuple<int, string, int>(2, "Drift-Spoiler", 300),
                    new Tuple<int, string, int>(3, "Dachträger", 300),
                    new Tuple<int, string, int>(4, "Dachträger mit Gerümpel", 300),
                }},
                { 4, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Kühlergrill", 200),
                    new Tuple<int, string, int>(0, "Kuhfänger", 200),
                    new Tuple<int, string, int>(1, "Kuhfänger mit Aufklebern", 200),
                    new Tuple<int, string, int>(2, "Verstärkter Kuhfänger", 200),
                }},
                { 6, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Dach", 300),
                    new Tuple<int, string, int>(0, "Carbon-Dach", 300),
                    new Tuple<int, string, int>(1, "Carbon-Dach und Kofferraum", 300),
                    new Tuple<int, string, int>(2, "Aufkleber Dach", 300),
                    new Tuple<int, string, int>(3, "Aufkleber Dach und Kofferraum", 300),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Frontsplitter", 400),
                    new Tuple<int, string, int>(1, "Carbonsplitter", 400),
                    new Tuple<int, string, int>(2, "Extreme-Aero-Stoßstange", 400),
                    new Tuple<int, string, int>(3, "Frontstoßstange mit Aufklebern", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Heckstoßstange", 400),
                    new Tuple<int, string, int>(0, "Carbon-Heckstoßstange", 400),
                    new Tuple<int, string, int>(1, "Heckstoßstange mit Aufklebern", 400),
                }},
            }},
            { "Issi2", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Auspuff", 300),
                    new Tuple<int, string, int>(0, "Doppelter Auspuff", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schweller", 400),
                    new Tuple<int, string, int>(0, "Maßgeschneiderter Schweller", 400),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Motorhaube", 500),
                    new Tuple<int, string, int>(0, "Motorhaube mit Lufteinlass", 500),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Frontsplitter", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Heckstoßstange", 400),
                    new Tuple<int, string, int>(0, "Maßgeschneiderte Heckstoßstange", 400),
                }},
            }},
            { "GP1", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Auspuff", 300),
                    new Tuple<int, string, int>(0, "Doppel-Auspuff", 300),
                    new Tuple<int, string, int>(1, "Doppel-Auspuff 2", 300),
                    new Tuple<int, string, int>(2, "Vierfach-Auspuff LM", 300),
                    new Tuple<int, string, int>(3, "Carbon-Auspuff LM", 300),
                    new Tuple<int, string, int>(4, "Auspuff LM", 300),
                    new Tuple<int, string, int>(5, "Großer Auspuff", 300),
                    new Tuple<int, string, int>(6, "Großer gekürzter Auspuff", 300),
                    new Tuple<int, string, int>(7, "Großer Carbon-Auspuff", 300),
                    new Tuple<int, string, int>(8, "Großer Auspuff in Sekundärfarbe", 300),
                    new Tuple<int, string, int>(9, "Carbon-Auspuff Offset", 300),
                    new Tuple<int, string, int>(10, "Auspuff Offset in Sekundärfarbe", 300),
                    new Tuple<int, string, int>(11, "Auspuff-Kit LM", 300),
                    new Tuple<int, string, int>(12, "Carbon-Auspuff-Kit LM", 300),
                    new Tuple<int, string, int>(13, "Auspuff-Kit LM in Sekundärfarbe", 300),
                    new Tuple<int, string, int>(15, "Großes Carbon-Kit", 300),
                    new Tuple<int, string, int>(16, "Großes Kit in Sekundärfarbe", 300),
                    new Tuple<int, string, int>(17, "Auspuff-Kit Offset", 300),
                    new Tuple<int, string, int>(17, "Auspuff-Kit Offset in Sekundärfarbe", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schweller", 400),
                    new Tuple<int, string, int>(0, "Semi-Sport Schweller", 400),
                    new Tuple<int, string, int>(1, "Sportschweller", 400),
                    new Tuple<int, string, int>(2, "Maßgeschneiderter Schweller", 400),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Motorhaube", 500),
                    new Tuple<int, string, int>(0, "Modifizierte Motorhaube", 500),
                    new Tuple<int, string, int>(1, "Carbon-Motorhaube", 500),
                    new Tuple<int, string, int>(2, "Motorhaube mit Lufteinlass", 500),
                    new Tuple<int, string, int>(3, "Motorhaube mit Lufteinlass 2", 500),
                    new Tuple<int, string, int>(4, "Motorhaube mit großem Lufteinlass 1", 500),
                    new Tuple<int, string, int>(5, "Motorhaube mit großem Lufteinlass 2", 500),
                    new Tuple<int, string, int>(6, "Motorhaube LM", 500),
                    new Tuple<int, string, int>(7, "Motorhaube LM (Carbon)", 500),
                    new Tuple<int, string, int>(8, "Sport Motorhaube", 500),
                    new Tuple<int, string, int>(9, "Renn-Motorhaube", 500),
                    new Tuple<int, string, int>(10, "Rennmotorhaube (Carbon)", 500),
                    new Tuple<int, string, int>(11, "GT-Motorhaube", 500),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Kein Spoiler", 500),
                    new Tuple<int, string, int>(0, "erhöter Spoiler", 500),
                    new Tuple<int, string, int>(1, "Spoiler angehoben", 500),
                    new Tuple<int, string, int>(2, "Spoiler angehoben (Carbon)", 500),
                    new Tuple<int, string, int>(3, "Spoiler Branch", 500),
                    new Tuple<int, string, int>(4, "Niedriger Spoiler", 500),
                    new Tuple<int, string, int>(5, "Tuning-Spoiler", 500),
                    new Tuple<int, string, int>(6, "Zweifarbiger Spoiler", 500),
                    new Tuple<int, string, int>(7, "Spoiler LM", 500),
                    new Tuple<int, string, int>(8, "GT Spoiler", 500),
                    new Tuple<int, string, int>(9, "Spoiler angehoben LM", 500),
                    new Tuple<int, string, int>(10, "Carbon-Spoiler angehoben LM", 500),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Normalspur Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Benutzerdefinierte Stoßstange", 400),
                    new Tuple<int, string, int>(1, "Konzept Stoßstange", 400),
                    new Tuple<int, string, int>(2, "Champion Stoßstange", 400),
                    new Tuple<int, string, int>(3, "Sportstoßstange", 400),
                    new Tuple<int, string, int>(4, "Stoßstangen-Tuner", 400),
                    new Tuple<int, string, int>(5, "Stoßstange LM", 400),
                    new Tuple<int, string, int>(6, "Turnier-Stoßstange", 400),
                    new Tuple<int, string, int>(7, "Bumper-Wettbewerb", 400),
                    new Tuple<int, string, int>(8, "GT Stoßstange", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Diffusor", 400),
                    new Tuple<int, string, int>(0, "Carbon-Diffusor", 400),
                    new Tuple<int, string, int>(1, "Farbiger Diffusor", 400),
                }},
            }},
            { "Omnis", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Auspuff", 300),
                    new Tuple<int, string, int>(0, "Tuning-Titan-Auspuff", 300),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Spoiler", 500),
                    new Tuple<int, string, int>(0, "Kein Spoiler", 500),
                    new Tuple<int, string, int>(1, "Riesen-Spoiler", 500),
                }},
                { 7, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Ohne Farbe", 400),
                    new Tuple<int, string, int>(0, "Rallye-Klassiker", 400),
                    new Tuple<int, string, int>(1, "Rallye Retro", 400),
                }},
            }},
            { "Reaper", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Spoiler", 500),
                    new Tuple<int, string, int>(0, "Kleiner Spoiler", 500),
                    new Tuple<int, string, int>(1, "Mitllerer Spoiler", 500),
                    new Tuple<int, string, int>(2, "Hoher Spoiler", 500),
                }},
            }},
            { "Zentorno", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Auspuff", 300),
                    new Tuple<int, string, int>(0, "DoppelAuspuff", 300),
                    new Tuple<int, string, int>(1, "Großer Auspuff", 300),
                    new Tuple<int, string, int>(2, "Doppelter ovaler Auspuff", 300),
                    new Tuple<int, string, int>(3, "Großer ovaler Auspuff", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schweller", 400),
                    new Tuple<int, string, int>(0, "Schwelle in Primärfarbe", 400),
                    new Tuple<int, string, int>(1, "Zusätzliche Farbe für Schwelle", 400),
                    new Tuple<int, string, int>(2, "Carbonschwellen", 400),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Motorhaube", 500),
                    new Tuple<int, string, int>(0, "Hauben ohne Lufteinlässe", 500),
                    new Tuple<int, string, int>(1, "Zusätzliche Farben für die Motorhaube", 500),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Spoiler", 500),
                    new Tuple<int, string, int>(0, "Niedriger Spoiler in Primärfarbe", 500),
                    new Tuple<int, string, int>(1, "Niedriger Spoiler in Sekundärfarbe", 500),
                    new Tuple<int, string, int>(2, "Carbon Spoiler", 500),
                    new Tuple<int, string, int>(3, "Kleiner Spoiler in Primärfarbe", 500),
                    new Tuple<int, string, int>(4, "Kleiner Spoiler in Sekundärfarbe", 500),
                    new Tuple<int, string, int>(5, "Kleiner Carbon-Spoiler", 500),
                    new Tuple<int, string, int>(6, "GT Spoiler", 500),
                }},
            }},
            { "Italigtb2", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Auspuff", 400),
                    new Tuple<int, string, int>(0, "DoppelAuspuff", 400),
                    new Tuple<int, string, int>(1, "Großer Auspuff", 400),
                    new Tuple<int, string, int>(2, "Doppelter ovaler Auspuff", 400),
                    new Tuple<int, string, int>(3, "Großer ovaler Auspuff", 400),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schweller", 400),
                    new Tuple<int, string, int>(0, "Benutzerdefinierte Schwelle 1", 400),
                    new Tuple<int, string, int>(1, "Benutzerdefinierte Schwelle 2", 400),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Motorhaube", 500),
                    new Tuple<int, string, int>(0, "Motorhaube 1", 500),
                    new Tuple<int, string, int>(1, "Motorhaube mit Streifen 1", 500),
                    new Tuple<int, string, int>(2, "Motorhaube mit Streifen 2", 500),
                    new Tuple<int, string, int>(3, "Carbonhaube", 500),
                    new Tuple<int, string, int>(4, "Custom Carbonhaube", 500),
                    new Tuple<int, string, int>(8, "Carbonhaube mit Lufteinlass", 500),
                    new Tuple<int, string, int>(9, "Motorhaube mit zwei Lufteinlässen", 500),
                    new Tuple<int, string, int>(10, "Motohaube mit drei Lufteinlässen", 500),
                    new Tuple<int, string, int>(11, "Motorhaube mit Lufteinlässen 1", 500),
                    new Tuple<int, string, int>(12, "Motohaube mit Lufteinlässen 2", 500),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Spoiler", 500),
                    new Tuple<int, string, int>(0, "Niedriger Spoiler 1", 500),
                    new Tuple<int, string, int>(1, "Niedriger Spoiler 2", 500),
                    new Tuple<int, string, int>(2, "Niedriger Spoiler 3", 500),
                    new Tuple<int, string, int>(3, "Carbon Spoiler 1", 500),
                    new Tuple<int, string, int>(4, "Carbon Spoiler 2", 500),
                    new Tuple<int, string, int>(5, "Carbon Spoiler 3", 500),
                    new Tuple<int, string, int>(6, "Carbon Spoiler 4", 500),
                    new Tuple<int, string, int>(7, "Mittlerer Spoiler", 500),
                    new Tuple<int, string, int>(8, "Medium Carbon Spoiler", 500),
                }},
            }},
            { "Xa21", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Auspuff", 300),
                    new Tuple<int, string, int>(0, "Custom Auspuff", 300),
                    new Tuple<int, string, int>(1, "Doppelter Auspuff", 300),
                    new Tuple<int, string, int>(4, "Doppelseitiger Auspuff", 300),
                    new Tuple<int, string, int>(5, "Vierrohr-Auspuff 1", 300),
                    new Tuple<int, string, int>(11, "Vierrohr-Auspuff 2", 300),
                    new Tuple<int, string, int>(13, "Vierrohr-Auspuff 3", 300),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Motoreinfärbung", 400),
                    new Tuple<int, string, int>(1, "Grundlegende Motorfärbung 1", 400),
                    new Tuple<int, string, int>(2, "Zusätzliche Motorfärbung 1", 400),
                    new Tuple<int, string, int>(4, "Grundlegende Motorfärbung 2", 400),
                    new Tuple<int, string, int>(5, "Zusätzliche Motorfärbung 2", 400),
                    new Tuple<int, string, int>(7, "Grundlegende Motorfärbung 3", 400),
                    new Tuple<int, string, int>(8, "Zusätzliche Motorfärbung 3", 400),
                }},
            }},
            { "Osiris", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 300),
                    new Tuple<int, string, int>(0, "Kohlenstoffrahmen Spoiler", 300),
                    new Tuple<int, string, int>(1, "Angehobener Carbon-Spoiler", 300),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Stossfängerspur", 400),
                    new Tuple<int, string, int>(0, "Stoßstange in Grundfarbe", 400),
                    new Tuple<int, string, int>(1, "Stoßstange in extra Farbe", 400),
                    new Tuple<int, string, int>(2, "Carbon-Stoßstange", 400),
                    new Tuple<int, string, int>(3, "Sportstoßstange in der Grundfarbe", 400),
                    new Tuple<int, string, int>(4, "Sportstoßstange in extra Farbe", 400),
                    new Tuple<int, string, int>(5, "Sport Carbon Stoßstange", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Heckdiffusor", 400),
                    new Tuple<int, string, int>(0, "Carbon-Diffusor", 400),
                }},
            }},
            { "Nero", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Auspuff", 300),
                    new Tuple<int, string, int>(0, "Schwarzer Auspuff", 300),
                    new Tuple<int, string, int>(1, "Vier-Fass-Auspuff", 300),
                    new Tuple<int, string, int>(2, "Schwarzer Vierrohr-Auspuff", 300),
                    new Tuple<int, string, int>(3, "Vierrohr-Auspuff 2", 300),
                    new Tuple<int, string, int>(4, "Schwarzer Vierrohr-Auspuff 2", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schweller", 400),
                    new Tuple<int, string, int>(0, "Spezifische Schweller", 400),
                    new Tuple<int, string, int>(0, "Spezifische Kohlenstoffschwellenwerte", 400),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standardhaube", 500),
                    new Tuple<int, string, int>(0, "Linie auf der Motorhaube", 500),
                    new Tuple<int, string, int>(1, "Doppelte Linie auf der Motorhaube", 500),
                    new Tuple<int, string, int>(2, "Carbonhaube", 500),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Stossfängerspur", 400),
                    new Tuple<int, string, int>(0, "Maßgeschneiderte Stossfängerspur", 400),
                    new Tuple<int, string, int>(0, "Carbon Stoßstangenlanze", 400),
                }},
            }},
            { "Primo", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Auspuff", 300),
                    new Tuple<int, string, int>(0, "Verchromter Auspuff", 300),
                    new Tuple<int, string, int>(1, "Erweiterter Auspuff", 300),
                    new Tuple<int, string, int>(2, "Titan-Auspuff", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schweller", 400),
                    new Tuple<int, string, int>(0, "Spezifische Schweller", 400),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Niedriger Spoiler", 500),
                    new Tuple<int, string, int>(1, "Hoher Spoiler", 500),
                }},
                { 4, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standardgitter", 200),
                    new Tuple<int, string, int>(0, "Verchromtes Gitter", 200),
                    new Tuple<int, string, int>(1, "Sportgrill", 200),
                    new Tuple<int, string, int>(2, "Gitterrost", 200),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Stossfängerspur", 400),
                    new Tuple<int, string, int>(0, "Maßgeschneiderte Stossfängerspur", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Serienmäßige Heckstoßstange", 400),
                    new Tuple<int, string, int>(0, "Maßgeschneiderte Heckstoßstange", 400),
                }},
            }},
            { "Emperor", new Dictionary<int, List<Tuple<int, string, int>>>() { }},
            { "Penetrator", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Auspuff", 300),
                    new Tuple<int, string, int>(0, "Doppel-Titan Auspuff", 300),
                    new Tuple<int, string, int>(1, "Doppeltitan (Chrom) Auspuff", 300),
                    new Tuple<int, string, int>(2, "Sport Auspuff", 300),
                    new Tuple<int, string, int>(3, "Doppel-Titan Sport Auspuff", 300),
                    new Tuple<int, string, int>(4, "Dual-Titan Sport Auspuff", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schwellenwert", 400),
                    new Tuple<int, string, int>(0, "Spezifische Schwellenwert", 400),
                    new Tuple<int, string, int>(1, "Carbonverkleidungen", 400),
                    new Tuple<int, string, int>(2, "Schweller für Halbsportwagen", 400),
                    new Tuple<int, string, int>(3, "Carbonschwellen (Teil)", 400),
                    new Tuple<int, string, int>(4, "Umgekehrte Schwellenwert", 400),
                    new Tuple<int, string, int>(5, "Carbonschwellen (alles)", 400),
                    new Tuple<int, string, int>(6, "GT-Schwellenwert", 400),
                    new Tuple<int, string, int>(7, "Carbon GT (Teil)", 400),
                    new Tuple<int, string, int>(8, "Umgekehrter GT Schwellenwert", 400),
                    new Tuple<int, string, int>(9, "Carbon GT (alles)", 400),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standardhaube", 500),
                    new Tuple<int, string, int>(0, "Standardhaube 2", 500),
                    new Tuple<int, string, int>(1, "Motorhaube mit Lufteinlass", 500),
                    new Tuple<int, string, int>(2, "Mit Lufteinlass (Carbon)", 500),
                    new Tuple<int, string, int>(3, "Standardhaube (Carbon)", 500),
                    new Tuple<int, string, int>(4, "Carbonhaube", 500),
                    new Tuple<int, string, int>(5, "Motorhaube mit Lufteinlass 2", 500),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Drift-Spoiler", 500),
                    new Tuple<int, string, int>(1, "Carbon-Spoiler", 500),
                    new Tuple<int, string, int>(2, "Tuning-Spoiler", 500),
                    new Tuple<int, string, int>(3, "Carbon-Spoiler 2", 500),
                    new Tuple<int, string, int>(4, "GT Spoiler", 500),
                }},
                { 4, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standardmotor", 900),
                    new Tuple<int, string, int>(0, "Modifikation für Motor Stufe 1", 900),
                    new Tuple<int, string, int>(1, "Modifikation für Motor Stufe 2", 900),
                    new Tuple<int, string, int>(2, "Modifikation für Motor Stufe 3", 900),
                    new Tuple<int, string, int>(3, "Modifikation für Motor Stufe 4", 900),
                    new Tuple<int, string, int>(4, "Modifikation für Motor Stufe 5", 900),
                    new Tuple<int, string, int>(5, "Modifikation für Motor Stufe 6", 900),
                }},
                { 6, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standardmotor", 300),
                    new Tuple<int, string, int>(0, "Verchromter Motor", 300),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Stossfängerspur", 400),
                    new Tuple<int, string, int>(0, "Stoßstange mit Kühler", 400),
                    new Tuple<int, string, int>(1, "Stoßfänger Kinn", 400),
                    new Tuple<int, string, int>(2, "Mit Kühler (Carbon)", 400),
                    new Tuple<int, string, int>(3, "Carbon-Splitter", 400),
                    new Tuple<int, string, int>(4, "Raster mit Splitter", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Serienmäßige Heckstoßstange", 400),
                    new Tuple<int, string, int>(0, "Verchromte Splitter", 400),
                    new Tuple<int, string, int>(1, "individuelle Stoßstange", 400),
                    new Tuple<int, string, int>(2, "Frontstoßstange (Carbonfaser)", 400),
                    new Tuple<int, string, int>(3, "Hintere Stoßstange", 400),
                    new Tuple<int, string, int>(4, "Stoßstange Aero", 400),
                    new Tuple<int, string, int>(5, "Heckstoßstange Aero (Carbon)", 400),
                }},
            }},
            { "Bison3", new Dictionary<int, List<Tuple<int, string, int>>>() { }},
            { "Turismor", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Auspuff", 300),
                    new Tuple<int, string, int>(0, "Ovaler Auspuff", 300),
                    new Tuple<int, string, int>(1, "Verchromter Auspuff", 300),
                    new Tuple<int, string, int>(2, "RennAuspuff", 300),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Carbon-Spoiler", 500),
                    new Tuple<int, string, int>(1, "GT Spoiler", 500),
                }},
                { 6, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Dach", 300),
                    new Tuple<int, string, int>(0, "Lackiertes Dach", 300),
                }},
            }},
            { "Jester2", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Auspuff", 300),
                    new Tuple<int, string, int>(0, "Ovaler Auspuff", 300),
                    new Tuple<int, string, int>(1, "Verchromter Auspuff", 300),
                    new Tuple<int, string, int>(2, "RennAuspuff", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schwellenwert", 400),
                    new Tuple<int, string, int>(0, "Spezifische Schwellenwert", 400),
                    new Tuple<int, string, int>(1, "Sportliche Schwellenwert", 400),
                    new Tuple<int, string, int>(2, "Carbonverkleidungen", 400),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Carbon-Spoiler", 500),
                    new Tuple<int, string, int>(1, "Lackierter Spoiler", 500),
                    new Tuple<int, string, int>(2, "Carbon-Spoiler 2", 500),
                    new Tuple<int, string, int>(3, "GT Spoiler", 500),
                }},
                { 6, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Dach", 300),
                    new Tuple<int, string, int>(0, "Heckabweiser", 300),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Stossfängerspur", 400),
                    new Tuple<int, string, int>(0, "Frontsplitter", 400),
                    new Tuple<int, string, int>(1, "Canard Splitter", 400),
                    new Tuple<int, string, int>(2, "Flügelspalter", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Serienmäßige Heckstoßstange", 400),
                    new Tuple<int, string, int>(0, "Lackierter Heckdiffusor", 400),
                    new Tuple<int, string, int>(1, "Carbon-Assoziierter Diffusor", 400),
                }},
            }},
            { "Neon", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schwellenwert", 400),
                    new Tuple<int, string, int>(0, "Schweller in der Grundfarbe", 400),
                    new Tuple<int, string, int>(1, "Zusätzliche Farbschwellenwert", 400),
                    new Tuple<int, string, int>(2, "Carbonschwellenwert", 400),
                    new Tuple<int, string, int>(3, "Racing in der Grundfarbe", 400),
                    new Tuple<int, string, int>(4, "Racing Extra Farbe", 400),
                    new Tuple<int, string, int>(5, "Carbon-Rennen", 400),
                    new Tuple<int, string, int>(6, "Wettbewerbs-Grundfarbe", 400),
                    new Tuple<int, string, int>(7, "Wettbewerb Extra Farbe", 400),
                    new Tuple<int, string, int>(8, "Kohlenstoffwettbewerb", 400),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Motorhaube", 500),
                    new Tuple<int, string, int>(0, "Zwei Streifen Motorhaube", 500),
                    new Tuple<int, string, int>(1, "Einspurige Motorhaube", 500),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Spoiler in Grundfarbe", 500),
                    new Tuple<int, string, int>(1, "Spoiler extra Farbe", 500),
                    new Tuple<int, string, int>(2, "Carbon-Spoiler", 500),
                    new Tuple<int, string, int>(3, "Renn Spoiler", 500),
                    new Tuple<int, string, int>(4, "Tuning Spoiler", 500),
                    new Tuple<int, string, int>(5, "Spoiler-Wettbewerb", 500),
                }},
                { 5, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standardspiegel", 300),
                    new Tuple<int, string, int>(0, "Spiegel 1", 300),
                    new Tuple<int, string, int>(1, "Spiegel 2", 300),
                    new Tuple<int, string, int>(2, "Spiegel 3", 300),
                    new Tuple<int, string, int>(3, "Spiegel 4", 300),
                    new Tuple<int, string, int>(4, "Spiegel 5", 300),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Stossfängerspur", 400),
                    new Tuple<int, string, int>(0, "Splitter ist eine Grundfarbe", 400),
                    new Tuple<int, string, int>(1, "Splitter extra Farbe", 400),
                    new Tuple<int, string, int>(2, "Carbon-Splitter", 400),
                    new Tuple<int, string, int>(3, "Splitter-Wettbewerb", 400),
                    new Tuple<int, string, int>(4, "Wettbewerb extra Farbe", 400),
                    new Tuple<int, string, int>(5, "Kohlenstoffwettbewerb", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Heckdiffusor", 400),
                    new Tuple<int, string, int>(0, "Renn Diffusor", 400),
                    new Tuple<int, string, int>(1, "Renn Diffusor (Carbon)", 400),
                }},
            }},
            { "Massacro2", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Auspuff", 300),
                    new Tuple<int, string, int>(0, "Titan-Düsen", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schwellenwert", 400),
                    new Tuple<int, string, int>(0, "Seitenverkleidung", 400),
                    new Tuple<int, string, int>(1, "Carbonseite", 400),
                    new Tuple<int, string, int>(2, "Rennseite", 400),
                    new Tuple<int, string, int>(3, "Renn Carbonfaser", 400),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standardhaube", 500),
                    new Tuple<int, string, int>(0, "Carbonhaube", 500),
                    new Tuple<int, string, int>(1, "Motorhaube mit Lufteinlass", 500),
                    new Tuple<int, string, int>(2, "Renn Carbon Motorhaube", 500),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Niedriger Spoiler", 500),
                    new Tuple<int, string, int>(1, "Niedriger Carbon Spoiler", 500),
                    new Tuple<int, string, int>(2, "Renn Flügel", 500),
                    new Tuple<int, string, int>(3, "GT-Flügel", 500),
                }},
                { 5, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standardflügel", 300),
                    new Tuple<int, string, int>(0, "Race Lufteinlässe", 300),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Stossfängerspur", 400),
                    new Tuple<int, string, int>(0, "Carbon-Splitter", 400),
                    new Tuple<int, string, int>(1, "Splitter", 400),
                    new Tuple<int, string, int>(2, "Renn Splitter", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Serienmäßige Heckstoßstange", 400),
                    new Tuple<int, string, int>(0, "Hinterer Diffusor", 400),
                    new Tuple<int, string, int>(1, "Racing Heckdiffusor", 400),
                }},
            }},
            { "Turismo2", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Auspuff", 300),
                    new Tuple<int, string, int>(0, "Carbon-Spitzen", 300),
                    new Tuple<int, string, int>(1, "Verchromte Spitzen", 300),
                    new Tuple<int, string, int>(2, "Titan Spitzen", 300),
                    new Tuple<int, string, int>(3, "Breiter Auspuff", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schwellenwert", 400),
                    new Tuple<int, string, int>(0, "Zusätzliche Farbschwellenwert", 400),
                    new Tuple<int, string, int>(1, "Schwellenwert", 400),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standardhaube", 500),
                    new Tuple<int, string, int>(0, "Motorhaube mit Streifen", 500),
                    new Tuple<int, string, int>(1, "Belüftete Motorhaube", 500),
                    new Tuple<int, string, int>(2, "Belüftet mit einem Streifen", 500),
                    new Tuple<int, string, int>(3, "Rennhaube", 500),
                    new Tuple<int, string, int>(4, "Rennen mit einem Strip", 500),
                    new Tuple<int, string, int>(5, "GT Motorhaube", 500),
                    new Tuple<int, string, int>(6, "GT Motorhaube mit Streifen", 500),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Standard-Spoiler", 500),
                    new Tuple<int, string, int>(1, "Farb Spoiler", 500),
                    new Tuple<int, string, int>(2, "Carbon-Spoiler", 500),
                    new Tuple<int, string, int>(3, "GT Flügel", 500),
                    new Tuple<int, string, int>(4, "GT Flügelfarbe", 500),
                    new Tuple<int, string, int>(5, "GT Kotflügel (Carbon)", 500),
                    new Tuple<int, string, int>(6, "Rennflügel", 500),
                    new Tuple<int, string, int>(7, "Rennflügel Extra farbe", 500),
                    new Tuple<int, string, int>(8, "Rennflügel (Carbon)", 500),
                    new Tuple<int, string, int>(9, "Tuning-Spoiler", 500),
                    new Tuple<int, string, int>(10, "Tuning-Farbe", 500),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Stossfängerspur", 400),
                    new Tuple<int, string, int>(0, "Leichte Stoßstange", 400),
                    new Tuple<int, string, int>(1, "Klassische Stoßstange", 400),
                    new Tuple<int, string, int>(2, "Rennstossfängerspur", 400),
                    new Tuple<int, string, int>(3, "Racing Stoßstange (Carbon)", 400),
                    new Tuple<int, string, int>(4, "Frontstoßstange GT", 400),
                    new Tuple<int, string, int>(5, "Stoßstange GT", 400),
                }},
            }},
            { "EntityXF", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Auspuff", 300),
                    new Tuple<int, string, int>(0, "DoppelAuspuff", 300),
                    new Tuple<int, string, int>(1, "Dreifacher Auspuff", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schwellenwert", 400),
                    new Tuple<int, string, int>(0, "Carbonschwellenwert", 400),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 400),
                    new Tuple<int, string, int>(0, "Carbon-Spoiler", 400),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Stossfängerspur", 400),
                    new Tuple<int, string, int>(0, "Splitter mit Canards", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Serienmäßige Heckstoßstange", 400),
                    new Tuple<int, string, int>(0, "Carbon-Assoziierter Diffusor", 400),
                }},
            }},
            { "Banshee2", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Auspuff", 300),
                    new Tuple<int, string, int>(0, "DoppelAuspuff", 300),
                    new Tuple<int, string, int>(1, "RennAuspuff", 300),
                    new Tuple<int, string, int>(2, "Verchromter Auspuff", 300),
                    new Tuple<int, string, int>(3, "DoppelAuspuff 2", 300),
                    new Tuple<int, string, int>(4, "Auspuffdüse", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schwellenwert", 400),
                    new Tuple<int, string, int>(0, "Spezifische Schwellenwert", 400),
                    new Tuple<int, string, int>(1, "Niedrige Schwellenwert", 400),
                    new Tuple<int, string, int>(2, "Schwellenwert für Halbsportarten", 400),
                    new Tuple<int, string, int>(3, "Sportliche Schwellenwert", 400),
                    new Tuple<int, string, int>(4, "Carbonverkleidungen", 400),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standardhaube", 500),
                    new Tuple<int, string, int>(0, "Motorhaube mit Lufteinlass", 500),
                    new Tuple<int, string, int>(1, "Carbonhaube", 500),
                    new Tuple<int, string, int>(2, "Überlagerung von Bögen", 500),
                    new Tuple<int, string, int>(3, "Glatte Motorhaube", 500),
                    new Tuple<int, string, int>(4, "Doppelter Lufteinlass", 500),
                    new Tuple<int, string, int>(5, "Doppelter Lufteinlass (inkl.)", 500),
                    new Tuple<int, string, int>(6, "Filterhaube", 500),
                    new Tuple<int, string, int>(7, "Freilufteinlass", 500),
                    new Tuple<int, string, int>(8, "Filterhaube (Chrom)", 500),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Hebender Spoiler", 500),
                    new Tuple<int, string, int>(1, "Mittlerer Spoiler", 500),
                    new Tuple<int, string, int>(2, "Drift-Spoiler", 500),
                    new Tuple<int, string, int>(3, "GT-Flügel (hoch)", 500),
                    new Tuple<int, string, int>(4, "Spoiler Extreme", 500),
                    new Tuple<int, string, int>(5, "Spoiler Asphalt", 500),
                }},
                { 4, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Hecktür", 300),
                    new Tuple<int, string, int>(0, "Hinterer Kofferraum", 300),
                    new Tuple<int, string, int>(1, "Der Dachkoffer", 300),
                    new Tuple<int, string, int>(2, "Carbon Kofferraum", 300),
                    new Tuple<int, string, int>(3, "Gepäckraum und -verkleidungen (Carbon)", 300),
                }},
                { 5, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standardflügel", 300),
                    new Tuple<int, string, int>(0, "Hintere Klappen", 300),
                    new Tuple<int, string, int>(1, "Heckklappen (Carbon)", 300),
                }},
                { 6, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Dach", 300),
                    new Tuple<int, string, int>(0, "Cabrio", 300),
                }},
                { 7, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Ohne Vinyl", 400),
                    new Tuple<int, string, int>(0, "Vinyl 1", 400),
                    new Tuple<int, string, int>(1, "Vinyl 2", 400),
                    new Tuple<int, string, int>(2, "Vinyl 3", 400),
                    new Tuple<int, string, int>(3, "Vinyl 4", 400),
                    new Tuple<int, string, int>(4, "Vinyl 5", 400),
                    new Tuple<int, string, int>(5, "Vinyl 6", 400),
                    new Tuple<int, string, int>(6, "Vinyl 7", 400),
                    new Tuple<int, string, int>(7, "Vinyl 8", 400),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Stossfängerspur", 400),
                    new Tuple<int, string, int>(0, "Carbon Frontstoßstange", 400),
                    new Tuple<int, string, int>(1, "Überlagerung von Bögen", 400),
                    new Tuple<int, string, int>(2, "Klassische RS Stoßstange", 400),
                    new Tuple<int, string, int>(3, "Driftpuffer RS", 400),
                    new Tuple<int, string, int>(4, "Stoßstange GT", 400),
                    new Tuple<int, string, int>(5, "Stoßfänger Straße SPL", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Ass Stoßstange", 400),
                }},
            }},
            { "Banshee", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Auspuff", 300),
                    new Tuple<int, string, int>(0, "Erweiterter Auspuff", 300),
                    new Tuple<int, string, int>(1, "DoppelAuspuff", 300),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standardhaube", 500),
                    new Tuple<int, string, int>(0, "Motorhaube mit Lufteinlass", 500),
                    new Tuple<int, string, int>(1, "Carbonhaube", 500),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Hebender Spoiler", 500),
                    new Tuple<int, string, int>(1, "Mittlerer Spoiler", 500),
                    new Tuple<int, string, int>(2, "Drift-Spoiler", 500),
                }},
                { 6, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Dach", 300),
                    new Tuple<int, string, int>(0, "Cabrio", 300),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Stossfängerspur", 400),
                    new Tuple<int, string, int>(0, "Carbon Stoßstangenlanze", 400),
                }},
            }},
            { "BestiaGTS", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Auspuff", 300),
                    new Tuple<int, string, int>(0, "Ovaler Auspuff", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schwellenwert", 400),
                    new Tuple<int, string, int>(0, "Carbonverkleidungen", 400),
                    new Tuple<int, string, int>(1, "Schwellenwert für Halbsportarten", 400),
                    new Tuple<int, string, int>(2, "Sportliche Schwellenwert", 400),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standardhaube", 500),
                    new Tuple<int, string, int>(0, "Glatte Motorhaube", 500),
                    new Tuple<int, string, int>(1, "Doppelter Lufteinlass", 500),
                    new Tuple<int, string, int>(2, "Doppelte Carbonfaser", 500),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Niedriger Spoiler", 500),
                    new Tuple<int, string, int>(1, "Mittlerer Spoiler", 500),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Stossfängerspur", 400),
                    new Tuple<int, string, int>(0, "Eurostoßstange", 400),
                    new Tuple<int, string, int>(1, "Racing Stoßstange", 400),
                    new Tuple<int, string, int>(3, "Driftpuffer", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Serienmäßige Heckstoßstange", 400),
                }},
            }},
            { "BJXL", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schweller", 400),
                    new Tuple<int, string, int>(0, "Fußstapfen", 400),
                }},
                { 6, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Dach", 300),
                    new Tuple<int, string, int>(0, "Dachträger", 300),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Normalspur Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Power Stoßstange", 400),
                }},
            }},
            { "Comet2", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Auspuff", 300),
                    new Tuple<int, string, int>(0, "Shotgun Auspuff", 300),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Spoiler", 500),
                    new Tuple<int, string, int>(0, "Angehobener Spoiler", 500),
                    new Tuple<int, string, int>(1, "GT Spoiler", 500),
                }},
                { 5, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 300),
                    new Tuple<int, string, int>(0, "Elytra Flügel", 300),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Stossfängerspur", 400),
                    new Tuple<int, string, int>(0, "Splitter mit Canards", 400),
                    new Tuple<int, string, int>(1, "Spalter mit Canards 2", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Serienmäßige Heckstoßstange", 400),
                }},
            }},
            { "Coquette", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Auspuff", 300),
                    new Tuple<int, string, int>(0, "Ovaler Auspuff", 300),
                    new Tuple<int, string, int>(1, "Verchromter Auspuff", 300),
                    new Tuple<int, string, int>(2, "Erweiterter Auspuff", 300),
                    new Tuple<int, string, int>(3, "Titan-Auspuff", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schwellenwert", 400),
                    new Tuple<int, string, int>(0, "Spezifische Schwellenwert", 400),
                    new Tuple<int, string, int>(1, "Carbonverkleidungen", 400),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standardhaube", 500),
                    new Tuple<int, string, int>(0, "Haube mit Lufteinlass", 500),
                    new Tuple<int, string, int>(1, "Mit doppeltem Lufteinlass", 500),
                    new Tuple<int, string, int>(2, "Carbon Motorhaube 1", 500),
                    new Tuple<int, string, int>(3, "Carbon Motorhaube 2", 500),
                    new Tuple<int, string, int>(4, "Sporthaube", 500),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Hebender Spoiler", 500),
                    new Tuple<int, string, int>(1, "Mittlerer Spoiler", 500),
                    new Tuple<int, string, int>(2, "Tuning Spoiler", 500),
                    new Tuple<int, string, int>(3, "Drift-Spoiler", 500),
                    new Tuple<int, string, int>(4, "GT Spoiler", 500),
                }},
                { 5, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standardflügel", 300),
                    new Tuple<int, string, int>(0, "Carbon-Paneele", 300),
                }},
                { 6, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Dach", 300),
                    new Tuple<int, string, int>(0, "Cabrio", 300),
                    new Tuple<int, string, int>(1, "Spezifisches Dach", 300),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Stossfängerspur", 400),
                    new Tuple<int, string, int>(0, "Frontsplitter", 400),
                    new Tuple<int, string, int>(1, "Lackierter Splitter", 400),
                    new Tuple<int, string, int>(2, "Carbon-Splitter", 400),
                    new Tuple<int, string, int>(3, "Stoßstange Extremo Aero", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Serienmäßige Heckstoßstange", 400),
                    new Tuple<int, string, int>(0, "Lackierte Heckstoßstange", 400),
                    new Tuple<int, string, int>(1, "Carbon-Assoziierter Diffusor", 400),
                    new Tuple<int, string, int>(2, "maßgeschneiderte Heckstoßstange", 400),
                    new Tuple<int, string, int>(3, "Diffusor und Haken aus Carbon", 400),
                }},
            }},
            { "Windsor", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 7, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Keine Färbung", 400),
                    new Tuple<int, string, int>(0, "Sessanta Nove Monogramm", 400),
                    new Tuple<int, string, int>(1, "Mehrfarbig. Sessanta Nove", 400),
                    new Tuple<int, string, int>(2, "Geometer. Sessanta Nove", 400),
                    new Tuple<int, string, int>(3, "Perseus Wings Monogramm", 400),
                    new Tuple<int, string, int>(4, "Monographie Perseus grüne Flügel", 400),
                    new Tuple<int, string, int>(5, "Santo Capra Python", 400),
                    new Tuple<int, string, int>(6, "Santo Capra Cheetah", 400),
                    new Tuple<int, string, int>(7, "Yeti Mall Ninja", 400),
                }},

            }},
            { "Superd", new Dictionary<int, List<Tuple<int, string, int>>>() {

            }},
            { "Huntley", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Chrome Schalldämpfer", 300),
                    new Tuple<int, string, int>(1, "Doppelschalldämpfer", 300),
                    new Tuple<int, string, int>(2, "Dual Titan", 300),
                    new Tuple<int, string, int>(3, "Erweiterter Schalldämpfer", 300),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standardhaube", 500),
                    new Tuple<int, string, int>(0, "Haube mit Lufteinlass", 500),
                    new Tuple<int, string, int>(1, "Mit doppeltem Lufteinlass", 500),
                    new Tuple<int, string, int>(2, "Carbonhaube", 500),
                    new Tuple<int, string, int>(3, "Carbonhaube 2", 500),
                }},
                { 6, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Dach", 300),
                    new Tuple<int, string, int>(0, "Dachträger", 300),
                }},
            }},
            { "Baller3", new Dictionary<int, List<Tuple<int, string, int>>>() {

            }},
            { "Dubsta2", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schalldämpfer", 400),
                    new Tuple<int, string, int>(0, "Titan-Schalldämpfer", 400),
                    new Tuple<int, string, int>(1, "Duales Titan", 400),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standardhaube", 500),
                    new Tuple<int, string, int>(0, "SUV-Motorhaube", 500),
                    new Tuple<int, string, int>(1, "Haube mit einem Ersatzteil", 500),
                }},
                { 5, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard linker Flügel", 300),
                    new Tuple<int, string, int>(0, "Schnorcheln", 300),
                }},
                { 6, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Dach", 300),
                    new Tuple<int, string, int>(0, "Dachträger", 300),
                    new Tuple<int, string, int>(1, "Kofferraum mit den Scheinwerfern", 300),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Stossfängerspur", 400),
                    new Tuple<int, string, int>(0, "Kunguryatnik mit einem Bogen", 400),
                    new Tuple<int, string, int>(1, "Kunguryatnik mit einem Bogen und Scheinwerfern", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Serienmäßige Heckstoßstange", 400),
                }},
            }},
            { "Carbonizzare", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Doppelschalldämpfer", 300),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standardhaube", 500),
                    new Tuple<int, string, int>(0, "Carbonhaube", 500),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 400),
                    new Tuple<int, string, int>(0, "Mittlerer Spoiler", 400),
                    new Tuple<int, string, int>(1, "Hebender Spoiler", 400),
                }},
            }},
            { "Infernus", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Doppelt registriert", 300),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Hebender Spoiler", 500),
                    new Tuple<int, string, int>(1, "GT Spoiler", 500),
                }},
            }},
            { "Elegy2", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Doppelschalldämpfer", 300),
                    new Tuple<int, string, int>(1, "Rennschalldämpfer", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schwellenwert", 400),
                    new Tuple<int, string, int>(0, "Spezifische Schwellenwert 1", 400),
                    new Tuple<int, string, int>(1, "Spezifische Schwellenwert 2", 400),
                    new Tuple<int, string, int>(2, "Spezifische Schwellenwert 3", 400),
                    new Tuple<int, string, int>(3, "Spezifische Schwellenwert 4", 400),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standardhaube", 500),
                    new Tuple<int, string, int>(0, "Haube mit Lufteinlass", 500),
                    new Tuple<int, string, int>(1, "Mit doppeltem Lufteinlass", 500),
                    new Tuple<int, string, int>(2, "Carbonhaube", 500),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Niedriger Spoiler", 500),
                    new Tuple<int, string, int>(1, "Hebender Spoiler", 500),
                    new Tuple<int, string, int>(2, "Tuning Spoiler", 500),
                    new Tuple<int, string, int>(3, "Carbon-Spoiler", 500),
                    new Tuple<int, string, int>(4, "GT Spoiler", 500),
                }},
                { 4, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standardgitter", 200),
                    new Tuple<int, string, int>(0, "Schwarzes Gitter", 200),
                    new Tuple<int, string, int>(1, "Offener Ladeluftkühler", 200),
                }},
                { 6, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Dach", 300),
                    new Tuple<int, string, int>(0, "Carbon-Dach", 300),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Stossfängerspur", 400),
                    new Tuple<int, string, int>(0, "Carbon-Splitter", 400),
                    new Tuple<int, string, int>(1, "Splitter mit Canards", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Serienmäßige Heckstoßstange", 400),
                    new Tuple<int, string, int>(0, "Carbon-Assoziierter Diffusor", 400),
                    new Tuple<int, string, int>(1, "Lackierte Heckstoßstange", 400),
                    new Tuple<int, string, int>(2, "Gefärbte Stoßstange und Diffusor.", 400),
                }},
            }},
            { "Jester", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Ovaler Schalldämpfer", 300),
                    new Tuple<int, string, int>(1, "Verchromtes Titan", 300),
                    new Tuple<int, string, int>(2, "Rennschalldämpfer", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schwellenwert", 400),
                    new Tuple<int, string, int>(0, "Spezifische Schwellenwert", 400),
                    new Tuple<int, string, int>(1, "Sportliche Schwellenwert", 400),
                    new Tuple<int, string, int>(2, "Carbonverkleidungen", 400),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Carbon-Spoiler", 500),
                    new Tuple<int, string, int>(1, "Gefärbter Spoiler", 500),
                    new Tuple<int, string, int>(2, "Carbon-Spoiler 2", 500),
                    new Tuple<int, string, int>(3, "GT Spoiler", 500),
                }},
                { 6, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Dach", 50),
                    new Tuple<int, string, int>(0, "Rückwandabweiser", 10000),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Stossfängerspur", 400),
                    new Tuple<int, string, int>(0, "Frontsplitter", 400),
                    new Tuple<int, string, int>(1, "Splitter mit Canards", 400),
                    new Tuple<int, string, int>(2, "Spalter mit Flügeln", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Serienmäßige Heckstoßstange", 400),
                    new Tuple<int, string, int>(0, "Lackierter Heckdiffusor", 400),
                    new Tuple<int, string, int>(1, "Carbon-Assoziierter Diffusor", 400),
                }},
            }},
            { "Ninef2", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Verchromter Schalldämpfer", 300),
                    new Tuple<int, string, int>(1, "Duales Titan", 300),
                    new Tuple<int, string, int>(2, "Erweiterter Schalldämpfer", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schwellenwert", 400),
                    new Tuple<int, string, int>(0, "Spezifische Schwellenwert", 400),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standardhaube", 500),
                    new Tuple<int, string, int>(0, "Carbonhaube", 500),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Niedriger Spoiler", 500),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Stossfängerspur", 400),
                    new Tuple<int, string, int>(0, "Frontsplitter", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Serienmäßige Heckstoßstange", 400),
                    new Tuple<int, string, int>(0, "Maßgeschneiderte Heckstoßstange", 400),
                }},
            }},
            { "Ninef", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Verchromter Schalldämpfer", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schwellenwert", 400),
                    new Tuple<int, string, int>(0, "Spezifische Schwellenwert", 400),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standardhaube", 500),
                    new Tuple<int, string, int>(0, "Carbonhaube", 500),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Niedriger Spoiler", 500),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Stossfängerspur", 400),
                    new Tuple<int, string, int>(0, "Frontsplitter", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Serienmäßige Heckstoßstange", 400),
                    new Tuple<int, string, int>(0, "Maßgeschneiderte Heckstoßstange", 400),
                }},
            }},
            { "Sultan", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Tuning Titan-Schalldämpfer", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schwellenwert", 400),
                    new Tuple<int, string, int>(0, "Spezifische Schwellenwert", 400),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standardhaube", 500),
                    new Tuple<int, string, int>(0, "Mit doppeltem Lufteinlass", 500),
                    new Tuple<int, string, int>(1, "Carbonhaube 1", 500),
                    new Tuple<int, string, int>(2, "Carbonhaube 2", 500),
                    new Tuple<int, string, int>(3, "Haube mit Lufteinlass", 500),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Niedriger Spoiler", 500),
                    new Tuple<int, string, int>(1, "Hebender Spoiler", 500),
                    new Tuple<int, string, int>(2, "GT Spoiler", 500),
                }},
                { 6, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Dach", 300),
                    new Tuple<int, string, int>(0, "Ein Streifen auf der Windschutzscheibe", 300),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Stossfängerspur", 400),
                    new Tuple<int, string, int>(0, "Frontsplitter", 400),
                    new Tuple<int, string, int>(1, "Verteiler und Ladeluftkühler", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Serienmäßige Heckstoßstange", 400),
                    new Tuple<int, string, int>(0, "Carbon-Assoziierter Diffusor", 400),
                }},
            }},
            { "SultanRS", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Tuning Titan-Schalldämpfer", 300),
                    new Tuple<int, string, int>(1, "Tuning Titan-Schalldämpfer 2", 300),
                    new Tuple<int, string, int>(2, "Doppelschalldämpfer", 300),
                    new Tuple<int, string, int>(3, "Doppelter Kurzschalldämpfer", 300),
                    new Tuple<int, string, int>(4, "Tuning Titan Kurzschalldämpfer", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schwellenwert", 300),
                    new Tuple<int, string, int>(0, "Schwarze Kotflügel", 300),
                    new Tuple<int, string, int>(1, "Hauptfarbenkotflügel", 300),
                    new Tuple<int, string, int>(2, "Zusätzliche farbige Kotflügel", 300),
                    new Tuple<int, string, int>(3, "Spezifische Schwellenwert", 300),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standardhaube", 500),
                    new Tuple<int, string, int>(0, "Mit doppeltem Lufteinlass", 500),
                    new Tuple<int, string, int>(1, "Carbonhaube 1", 500),
                    new Tuple<int, string, int>(2, "Carbonhaube 2", 500),
                    new Tuple<int, string, int>(3, "Carbonhaube 3", 500),
                    new Tuple<int, string, int>(4, "Carbonhaube 4", 500),
                    new Tuple<int, string, int>(5, "Lackierte Kapuze", 500),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Niedriger Spoiler 1", 500),
                    new Tuple<int, string, int>(1, "Hebender Spoiler 1", 500),
                    new Tuple<int, string, int>(2, "GT Spoiler 1", 500),
                    new Tuple<int, string, int>(3, "Niedriger Spoiler 2", 500),
                    new Tuple<int, string, int>(4, "Niedriger Spoiler 3", 500),
                    new Tuple<int, string, int>(5, "Niedriger Spoiler 4", 500),
                    new Tuple<int, string, int>(6, "Niedriger Spoiler 5", 500),
                    new Tuple<int, string, int>(7, "Niedriger Spoiler 6", 500),
                    new Tuple<int, string, int>(8, "Hebender Spoiler 2", 500),
                    new Tuple<int, string, int>(9, "Hebender Spoiler 3", 500),
                    new Tuple<int, string, int>(10, "Carbon-Spoiler 1", 500),
                    new Tuple<int, string, int>(11, "Carbon-Spoiler 2", 500),
                    new Tuple<int, string, int>(12, "Carbon-Spoiler 3", 500),
                    new Tuple<int, string, int>(13, "Massiver Carbon-Spoiler", 500),
                    new Tuple<int, string, int>(14, "Hoher Spoiler", 500),
                    new Tuple<int, string, int>(15, "Combo-Spoiler", 500),
                }},
                { 4, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Kühler", 200),
                    new Tuple<int, string, int>(0, "Spezifischer Kühler", 200),
                    new Tuple<int, string, int>(1, "Sportkühler", 200),
                }},
                { 5, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 400),
                    new Tuple<int, string, int>(0, "Erweiterung der Hauptfarbe", 400),
                    new Tuple<int, string, int>(1, "Schwarzausdehnung", 400),
                    new Tuple<int, string, int>(5, "Maximale Ausdehnung", 400),
                }},
                { 6, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Dach", 300),
                    new Tuple<int, string, int>(0, "Spoiler auf dem Dach", 300),
                    new Tuple<int, string, int>(1, "Scharfes Dach", 300),
                    new Tuple<int, string, int>(2, "Carbon-Dach", 300),
                    new Tuple<int, string, int>(3, "Spoiler mit Carbondach", 300),
                    new Tuple<int, string, int>(4, "Scharfes Carbondach", 300),
                }},
                { 7, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Keine Färbung", 400),
                    new Tuple<int, string, int>(0, "Der Streifen an den Seiten", 400),
                    new Tuple<int, string, int>(1, "Schwarzfärbung SULTAN RS", 400),
                    new Tuple<int, string, int>(2, "Weißfärbung SULTAN RS", 400),
                    new Tuple<int, string, int>(3, "Blauer Streifen an der Seite", 400),
                    new Tuple<int, string, int>(4, "KARIN Färbung", 400),
                    new Tuple<int, string, int>(5, "REDWOOD Färbung", 400),
                    new Tuple<int, string, int>(6, "KARIN 2 Färbung", 400),
                    new Tuple<int, string, int>(7, "Bemalte Einfärbung", 400),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Stossfängerspur", 400),
                    new Tuple<int, string, int>(0, "Frontstoßstange 1", 400),
                    new Tuple<int, string, int>(1, "Frontstoßstange 2", 400),
                    new Tuple<int, string, int>(2, "Frontstoßstange 3", 400),
                    new Tuple<int, string, int>(3, "Frontstoßstange 4", 400),
                    new Tuple<int, string, int>(4, "Frontstoßstange 5", 400),
                    new Tuple<int, string, int>(5, "Frontstoßstange 6", 400),
                    new Tuple<int, string, int>(6, "Frontstoßstange 7", 400),
                    new Tuple<int, string, int>(7, "Frontstoßstange 8", 400),
                    new Tuple<int, string, int>(8, "Frontstoßstange 9", 400),
                    new Tuple<int, string, int>(9, "Frontstoßstange 10", 400),
                    new Tuple<int, string, int>(10, "Frontstoßstange 11", 400),
                    new Tuple<int, string, int>(11, "Frontstoßstange 12", 400),
                    new Tuple<int, string, int>(12, "Frontstoßstange 13", 400),
                    new Tuple<int, string, int>(13, "Frontstoßstange 14", 400),
                    new Tuple<int, string, int>(14, "Frontstoßstange 15", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Serienmäßige Heckstoßstange", 400),
                    new Tuple<int, string, int>(0, "Hintere Stoßstange 1", 400),
                    new Tuple<int, string, int>(1, "Hintere Stoßstange 2", 400),
                    new Tuple<int, string, int>(2, "Hintere Stoßstange 3", 400),
                    new Tuple<int, string, int>(3, "Hintere Stoßstange 4", 400),
                    new Tuple<int, string, int>(4, "Hintere Stoßstange 5", 400),
                    new Tuple<int, string, int>(5, "Hintere Stoßstange 6", 400),
                    new Tuple<int, string, int>(6, "Hintere Stoßstange 7", 400),
                    new Tuple<int, string, int>(7, "Hintere Stoßstange 8", 400),
                }},
            }},
            { "Fugitive", new Dictionary<int, List<Tuple<int, string, int>>>() {

            }},
            { "Tailgater", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Titan-Schalldämpfer", 300),
                    new Tuple<int, string, int>(1, "Duales Titan", 300),
                    new Tuple<int, string, int>(2, "Verchromter Schalldämpfer", 300),
                    new Tuple<int, string, int>(3, "Doppelschalldämpfer", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schwellenwert", 400),
                    new Tuple<int, string, int>(0, "Spezifische Schwellenwert", 400),
                    new Tuple<int, string, int>(1, "Niedrige Schwellenwert", 400),
                    new Tuple<int, string, int>(2, "Schwellenwerte für Halbsportarten", 400),
                    new Tuple<int, string, int>(3, "Sportliche Schwellenwert", 400),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standardhaube", 500),
                    new Tuple<int, string, int>(0, "Haube mit Lufteinlass", 500),
                    new Tuple<int, string, int>(1, "Carbonhaube", 500),
                    new Tuple<int, string, int>(2, "Haube mit Lufteinlass 2", 500),
                    new Tuple<int, string, int>(3, "Sporthaube", 500),
                    new Tuple<int, string, int>(4, "Haube mit Lufteinlass", 500),
                    new Tuple<int, string, int>(5, "Mit doppeltem Lufteinlass", 500),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Lippenspoiler", 500),
                    new Tuple<int, string, int>(1, "Niedriger Spoiler", 500),
                    new Tuple<int, string, int>(2, "Mittlerer Spoiler", 500),
                    new Tuple<int, string, int>(3, "Hebender Spoiler", 500),
                    new Tuple<int, string, int>(4, "Carbon-Spoiler", 500),
                }},
                { 4, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standardgitter", 200),
                    new Tuple<int, string, int>(0, "Schwarzes Gitter", 200),
                    new Tuple<int, string, int>(1, "Verchromtes Gitter", 200),
                    new Tuple<int, string, int>(2, "Gitterrost", 200),
                    new Tuple<int, string, int>(3, "Split-Raster", 200),
                    new Tuple<int, string, int>(4, "Sportgrill", 200),
                }},
                { 5, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standardflügel", 300),
                    new Tuple<int, string, int>(0, "Elytra Flügel", 300),
                    new Tuple<int, string, int>(1, "Verchromte Bögen", 300),
                }},
                { 6, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Dach", 300),
                    new Tuple<int, string, int>(0, "Carbon-Dach", 300),
                    new Tuple<int, string, int>(1, "Dachträger", 300),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Stossfängerspur", 400),
                    new Tuple<int, string, int>(0, "Gefärbter Splitter", 400),
                    new Tuple<int, string, int>(1, "Frontsplitter", 400),
                    new Tuple<int, string, int>(2, "Stoßstange und Splitter", 400),
                    new Tuple<int, string, int>(3, "Verteiler und Ladeluftkühler", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Serienmäßige Heckstoßstange", 400),
                    new Tuple<int, string, int>(0, "Carbon-Assoziierter Diffusor", 400),
                    new Tuple<int, string, int>(1, "Lackierte Heckstoßstange", 400),
                    new Tuple<int, string, int>(2, "Sportliche Heckstoßstange", 400),
                    new Tuple<int, string, int>(3, "lackierte Stoßstange und ein Kegel.", 400),
                }},

            }},
            { "Kuruma", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Doppelschalldämpfer", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schwellenwert", 400),
                    new Tuple<int, string, int>(0, "Schwellenwerte in der Grundfarbe", 400),
                    new Tuple<int, string, int>(1, "Spezifische Schwellenwerte in zusätzlicher Farbe", 400),
                    new Tuple<int, string, int>(2, "Spezifische Kohlenstoffschwellenwert", 400),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Spoiler", 500),
                    new Tuple<int, string, int>(0, "Spoiler extra Farbe", 500),
                    new Tuple<int, string, int>(1, "Niedriger Carbon Spoiler", 500),
                    new Tuple<int, string, int>(2, "Niedriger Spoiler in Grundfarbe", 500),
                    new Tuple<int, string, int>(3, "Mittlerer Carbon Spoiler", 500),
                    new Tuple<int, string, int>(4, "GT Spoiler", 500),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Stossfängerspur", 400),
                    new Tuple<int, string, int>(0, "Spezifische Stoßstange in Grundfarbe", 400),
                    new Tuple<int, string, int>(1, "Spezifische Stoßstange in extra Farbe", 400),
                    new Tuple<int, string, int>(2, "Maßgeschneiderte Carbon-Stoßstange", 400),
                }},
            }},
            { "Sentinel", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Doppelschalldämpfer", 300),
                    new Tuple<int, string, int>(1, "Titan-Schalldämpfer", 300),
                    new Tuple<int, string, int>(2, "Erweiterter Schalldämpfer", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schwellenwert", 400),
                    new Tuple<int, string, int>(0, "Spezifische Schwellenwert", 400),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standardhaube", 500),
                    new Tuple<int, string, int>(0, "Carbonhaube", 500),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Lippenspoiler", 500),
                    new Tuple<int, string, int>(1, "Mittlerer Spoiler", 500),
                    new Tuple<int, string, int>(2, "Hebender Spoiler", 500),
                    new Tuple<int, string, int>(3, "Carbon-Spoiler", 500),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Stossfängerspur", 400),
                    new Tuple<int, string, int>(0, "Offener Ladeluftkühler", 400),
                    new Tuple<int, string, int>(1, "Splitter mit Canards", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Serienmäßige Heckstoßstange", 400),
                    new Tuple<int, string, int>(0, "Carbon-Assoziierter Diffusor", 400),
                    new Tuple<int, string, int>(1, "Diffusor und Haken aus Carbon", 400),
                }},
            }},

            { "F620", new Dictionary<int, List<Tuple<int, string, int>>>() {

            }},

            { "Schwarzer", new Dictionary<int, List<Tuple<int, string, int>>>() {
                    { 0, new List<Tuple<int, string, int>>() {
                        new Tuple<int, string, int>(-1, "Standard Schalldämpfer", 300),
                        new Tuple<int, string, int>(0, "Doppelschalldämpfer", 300),
                        new Tuple<int, string, int>(1, "Dual Titan", 300),
                        new Tuple<int, string, int>(2, "Ovaler Schalldämpfer", 300),
                        new Tuple<int, string, int>(3, "Racing Schalldämpfer", 300),
                    }},
                    { 1, new List<Tuple<int, string, int>>() {
                        new Tuple<int, string, int>(-1, "Standard-Schweller", 400),
                        new Tuple<int, string, int>(0, "Benutzerdefinierte Schweller 1", 400),
                        new Tuple<int, string, int>(1, "Benutzerdefinierte Schweller 2", 400),
                    }},
                    { 2, new List<Tuple<int, string, int>>() {
                        new Tuple<int, string, int>(-1, "Standard Haube", 500),
                        new Tuple<int, string, int>(0, "Carbonhaube", 500),
                    }},
                    { 3, new List<Tuple<int, string, int>>() {
                        new Tuple<int, string, int>(-1, "Nein", 500),
                        new Tuple<int, string, int>(0, "Duck Tail Spoiler", 500),
                        new Tuple<int, string, int>(1, "Angehobener Spoiler", 500),
                        new Tuple<int, string, int>(2, "Carbon-Spoiler", 500),
                    }},
                    { 4, new List<Tuple<int, string, int>>() {
                        new Tuple<int, string, int>(-1, "Standard Grill", 200),
                        new Tuple<int, string, int>(0, "Logo-Grill", 200),
                    }},
                    { 6, new List<Tuple<int, string, int>>() {
                        new Tuple<int, string, int>(-1, "Standarddach", 300),
                        new Tuple<int, string, int>(0, "Carbon Dach", 300),
                    }},
                    { 8, new List<Tuple<int, string, int>>() {
                        new Tuple<int, string, int>(-1, "Normalspur Stoßstange", 400),
                        new Tuple<int, string, int>(0, "Eurobumper", 400),
                        new Tuple<int, string, int>(1, "Ladeluftkühler öffnen", 400),
                        new Tuple<int, string, int>(2, "Splitter und Ladeluftkühler", 400),
                    }},
                    { 9, new List<Tuple<int, string, int>>() {
                        new Tuple<int, string, int>(-1, "Standard hinten. Stoßstange", 400),
                        new Tuple<int, string, int>(0, "Carbon hinten. Diffusor", 400),
                    }},
                }},

            { "Exemplar", new Dictionary<int, List<Tuple<int, string, int>>>() {

            }},

            { "Felon", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Ovaler Schalldämpfer", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standardschwellen", 400),
                    new Tuple<int, string, int>(0, "Benutzerdefinierte Schweller", 400),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Haube", 500),
                    new Tuple<int, string, int>(0, "Haube mit Lufteinlass", 500),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Niedriger Spoiler", 500),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Normalspur Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Frontsplitter", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard hinten. Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Carbon hinten. Diffusor", 400),
                }},
            }},

            { "Schafter2", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Ovaler Schalldämpfer", 300),
                    new Tuple<int, string, int>(1, "Chrome Schalldämpfer", 300),
                    new Tuple<int, string, int>(2, "Doppelschalldämpfer", 300),
                    new Tuple<int, string, int>(3, "Titan Auspuff", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schweller", 400),
                    new Tuple<int, string, int>(0, "Benutzerdefinierte Schweller 1", 400),
                    new Tuple<int, string, int>(1, "Carbon Verkleidungen", 400),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Haube", 500),
                    new Tuple<int, string, int>(0, "Haube mit Lufteinlass", 500),
                    new Tuple<int, string, int>(1, "Carbonhaube 1", 500),
                    new Tuple<int, string, int>(2, "Carbonhaube 2", 500),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Lippenspoiler", 500),
                    new Tuple<int, string, int>(1, "Carbon Spoiler", 500),
                    new Tuple<int, string, int>(2, "Angehobener Spoiler", 500),
                }},
                { 4, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Grill", 200),
                    new Tuple<int, string, int>(0, "Chromgitter", 200),
                    new Tuple<int, string, int>(1, "Sportgitter", 200),
                }},
                { 6, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standarddach", 300),
                    new Tuple<int, string, int>(0, "Carbon Dach", 300),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Normalspur Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Frontsplitter", 400),
                    new Tuple<int, string, int>(1, "Kohlenstoffspalter", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard hinten. Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Benutzerdefinierte hinten. Stoßstange", 400),
                }},
            }},

            { "Patriot", new Dictionary<int, List<Tuple<int, string, int>>>() {

            }},

            { "Cavalcade", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Superior Schalldämpfer", 300),
                }},
                { 4, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Schlitz Kühlergrill", 200),
                    new Tuple<int, string, int>(0, "Mesh-Gitter", 200),
                    new Tuple<int, string, int>(1, "Drahtgeflecht", 200),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Normalspur Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Frontsplitter", 400),
                    new Tuple<int, string, int>(1, "Extreme Aero Stoßstangeo", 400),
                }},
            }},

            { "Landstalker", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Chrome Schalldämpfer", 300),
                }},
                { 6, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standarddach", 300),
                    new Tuple<int, string, int>(0, "Dachträger", 300),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Normalspur Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Frontsplitter", 400),
                }},
            }},

            { "Baller", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Custom Schalldämpferь", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schweller", 400),
                    new Tuple<int, string, int>(0, "Benutzerdefinierte Schweller", 400),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Normalspur Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Benutzerdefinierte Front 1", 400),
                    new Tuple<int, string, int>(1, "Benutzerdefinierte Front 2", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard hinten. Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Custom Heckstoßstange", 400),
                }},
            }},

            { "Seminole", new Dictionary<int, List<Tuple<int, string, int>>>() {

            }},

            { "RancherXL", new Dictionary<int, List<Tuple<int, string, int>>>() {

            }},
            { "Buffalo", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Titan Auspuff Tuner", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schweller", 400),
                    new Tuple<int, string, int>(0, "Benutzerdefinierte Schweller", 400),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Niedriger Spoiler", 500),
                }},
            }},
            { "Gauntlet", new Dictionary<int, List<Tuple<int, string, int>>>() {

            }},


            { "Phoenix", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Ausgedehnter Schalldämpfer", 300),
                    new Tuple<int, string, int>(1, "Titan Auspuff Tuner", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schweller", 400),
                    new Tuple<int, string, int>(0, "Benutzerdefinierte Schweller", 400),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Haube", 500),
                    new Tuple<int, string, int>(0, "Kapuze mit Visier", 500),
                    new Tuple<int, string, int>(1, "Dreifacher Lader", 500),
                    new Tuple<int, string, int>(2, "Kompressor", 500),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Mittelspoiler", 500),
                    new Tuple<int, string, int>(1, "Angehobener Spoiler", 500),
                }},
                { 4, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Grill", 200),
                    new Tuple<int, string, int>(0, "Eisenmaske", 200),
                }},
                { 6, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standarddach", 300),
                    new Tuple<int, string, int>(0, "Glasdach", 300),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Normalspur Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Breiter Frontspoiler", 400),
                    new Tuple<int, string, int>(1, "Custom Spoiler", 400),
                }},
            }},
            { "Radi", new Dictionary<int, List<Tuple<int, string, int>>>() {

            }},
            { "Glendale", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Ausgedehnter Schalldämpfer", 300),
                    new Tuple<int, string, int>(1, "Doppelschalldämpfer", 300),
                    new Tuple<int, string, int>(2, "Shotgun Schalldämpfer", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schweller", 400),
                    new Tuple<int, string, int>(0, "Benutzerdefinierte Schweller", 400),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Haube", 500),
                    new Tuple<int, string, int>(0, "Extra. Haubenfarbe", 500),
                    new Tuple<int, string, int>(1, "Klassische Kapuze", 500),
                    new Tuple<int, string, int>(2, "Extra. klassische Kapuze", 500),
                    new Tuple<int, string, int>(3, "Gestreifte Kapuze", 500),
                    new Tuple<int, string, int>(4, "Extra. Kapuze in einem Streifen", 500),
                }},
                { 6, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standarddach", 300),
                    new Tuple<int, string, int>(0, "Dachträger", 300),
                    new Tuple<int, string, int>(1, "Koffer für die Fahrt", 300),
                    new Tuple<int, string, int>(2, "Geladenes Gepäck", 300),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Normalspur Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Benutzerdefinierte Stoßstange", 400),
                }},
            }},
            { "Serrano", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Ausgedehnter Schalldämpfer", 300),
                    new Tuple<int, string, int>(1, "Doppelschalldämpfer", 300),
                    new Tuple<int, string, int>(2, "Titan Auspuff", 300),
                    new Tuple<int, string, int>(3, "Chrome Schalldämpfer", 300),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Haube", 500),
                    new Tuple<int, string, int>(0, "Carbonhaube", 500),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 300),
                    new Tuple<int, string, int>(0, "Dachspoiler", 300),
                }},
                { 4, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Grill", 200),
                    new Tuple<int, string, int>(0, "Logo-Grill", 200),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Normalspur Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Custom Frontspoiler", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard hinten. Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Custom Heckstoßstange", 400),
                }},
            }},

            { "Zion", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Ausgedehnter Schalldämpfer", 300),
                    new Tuple<int, string, int>(1, "Doppelschalldämpfer", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schweller", 400),
                    new Tuple<int, string, int>(0, "Benutzerdefinierte Schweller", 400),
                }},

                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Angehobener Spoiler", 500),
                    new Tuple<int, string, int>(1, "Mittelspoiler", 500),
                    new Tuple<int, string, int>(2, "Carbon-Spoiler", 500),
                }},
                { 6, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Grill", 200),
                    new Tuple<int, string, int>(0, "Carbon Dach", 200),
                }},
            }},
            { "Surge", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schweller", 400),
                    new Tuple<int, string, int>(0, "Benutzerdefinierte Schweller", 400),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Spoiler-Tuner", 500),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Normalspur Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Frontsplitter", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard hinten. Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Custom Heckstoßstange", 400),
                }},
            }},
            { "Stanier", new Dictionary<int, List<Tuple<int, string, int>>>() {
            }},

            { "Stratum", new Dictionary<int, List<Tuple<int, string, int>>>() {
            }},

            { "Tampa", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Ausgedehnter Schalldämpfer", 300),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Haube", 500),
                    new Tuple<int, string, int>(0, "Einfache Luftansaugung", 500),
                    new Tuple<int, string, int>(1, "Doppelter Lufteinlass", 500),
                    new Tuple<int, string, int>(2, "Dreifaches Super-Ladegerät", 500),
                    new Tuple<int, string, int>(3, "Kompressor", 500),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Drag-Spoiler", 500),
                    new Tuple<int, string, int>(1, "Spoiler Duck Tail", 500),
                    new Tuple<int, string, int>(2, "Niedriger Spoiler", 500),
                }},
                { 4, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Grill", 200),
                    new Tuple<int, string, int>(0, "Geteilter Grill", 200),
                    new Tuple<int, string, int>(1, "Chromgitter", 200),
                    new Tuple<int, string, int>(2, "Grill öffnen", 200),
                    new Tuple<int, string, int>(3, "Grill öffnen", 200),
                }},
                { 6, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standarddach", 300),
                    new Tuple<int, string, int>(0, "Gemaltes Dach", 300),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Normalspur Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Custom Frontspoiler", 400),
                    new Tuple<int, string, int>(1, "Breiter Frontspoiler", 400),
                    new Tuple<int, string, int>(2, "Stoßstange neu lackiert", 400),
                    new Tuple<int, string, int>(3, "Spoiler neu lackiert", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard hinten. Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Lackierte Stoßstange", 400),
                    new Tuple<int, string, int>(1, "Gemalte Reflektoren", 400),
                    new Tuple<int, string, int>(2, "Zurück gemalt", 400),
                }},
            }},

            { "Prairie", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Titan Auspuff Tuner", 300),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Haube", 500),
                    new Tuple<int, string, int>(0, "Carbonhaube", 500),
                    new Tuple<int, string, int>(1, "Leichte Kapuze", 500),
                    new Tuple<int, string, int>(2, "Leichte Kapuze (Carbon)", 500),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Niedriger Spoiler", 500),
                    new Tuple<int, string, int>(1, "Carbon-Spoiler", 500),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Normalspur Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Kartensplitter", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard hinten. Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Kohlenstoffdifferential und Haken", 400),
                }},
            }},

            { "XLS", new Dictionary<int, List<Tuple<int, string, int>>>() {
            }},

            { "Gresley", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Doppelschalldämpfer", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schweller", 400),
                    new Tuple<int, string, int>(0, "Benutzerdefinierte Schweller", 400),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Haube", 500),
                    new Tuple<int, string, int>(0, "Kapuze mit Visier", 500),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Normalspur Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Kohlenstoffspalter", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard hinten. Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Carbon hinten. Diffusor", 400),
                }},
            }},

            { "Surano", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Chrome Schalldämpfer", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schweller", 400),
                    new Tuple<int, string, int>(0, "Benutzerdefinierte Schweller", 400),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Haube", 500),
                    new Tuple<int, string, int>(0, "Haube mit Lufteinlass", 500),
                    new Tuple<int, string, int>(1, "Carbonhaube", 500),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Spoiler", 500),
                    new Tuple<int, string, int>(0, "Lackierter Spoiler", 500),
                    new Tuple<int, string, int>(1, "Angehobener Spoiler", 500),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Normalspur Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Frontsplitter", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard hinten. Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Carbon hinten. Diffusor", 400),
                }},
            }},

            { "Tornado3", new Dictionary<int, List<Tuple<int, string, int>>>() {
            }},
            { "Tornado4", new Dictionary<int, List<Tuple<int, string, int>>>() {
            }},
            { "Emperor2", new Dictionary<int, List<Tuple<int, string, int>>>() {
            }},
            { "Voodoo2", new Dictionary<int, List<Tuple<int, string, int>>>() {

            }},
            { "Regina", new Dictionary<int, List<Tuple<int, string, int>>>() {

            }},
            { "Ingot", new Dictionary<int, List<Tuple<int, string, int>>>() {
            }},
            { "Picador", new Dictionary<int, List<Tuple<int, string, int>>>() {
            }},
            { "Manana", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Doppelrohrschalldämpfer", 300),
                    new Tuple<int, string, int>(1, "Doppelschalldämpfer", 300),
                }},
                { 5, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standardflügel", 300),
                    new Tuple<int, string, int>(0, "Bogenlichter", 300),
                }},
                { 6, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standarddach", 300),
                    new Tuple<int, string, int>(0, "Windschutzscheibenleiste", 300),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Normalspur Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Stoßstange und Unterlippe", 400),
                    new Tuple<int, string, int>(1, "Stoßstangenverkleidung", 400),
                    new Tuple<int, string, int>(2, "Unterlippe", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard hinten. Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Insgesamt Schnurrbart", 400),
                }},
            }},
            { "Asea", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schweller", 300),
                    new Tuple<int, string, int>(0, "Titan Auspuff Tuner", 300),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Haube", 500),
                    new Tuple<int, string, int>(0, "Carbonhaube", 500),
                    new Tuple<int, string, int>(2, "Kapuze in Aufklebern", 500),
                    new Tuple<int, string, int>(3, "Cover und Aufkleber", 500),
                }},
                { 5, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard linker Flügel", 300),
                    new Tuple<int, string, int>(0, "Linksaußen Aufkleber", 300),
                    new Tuple<int, string, int>(1, "Standard rechter Flügel", 300),
                    new Tuple<int, string, int>(2, "Rechter Flügel in Aufklebern.", 300),
                }},
                { 6, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standarddach", 300),
                    new Tuple<int, string, int>(0, "Carbon Dach", 300),
                    new Tuple<int, string, int>(1, "Körper im Aufkleberх", 300),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Normalspur Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Frontsplitter", 400),
                    new Tuple<int, string, int>(1, "Ladeluftkühler öffnen", 400),
                    new Tuple<int, string, int>(2, "Rallye-Stoßstange", 400),
                    new Tuple<int, string, int>(3, "Aufkleber Stoßstange", 400),
                }},
            }},
            { "Elegy", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Auspuff", 300),
                    new Tuple<int, string, int>(5, "Titan Auspuff Tuner", 300),
                    new Tuple<int, string, int>(6, "Doppelschalldämpfer", 300),
                    new Tuple<int, string, int>(7, "Doppelschalldämpfer aus Titan", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schweller", 400),
                    new Tuple<int, string, int>(0, "Benutzerdefinierte Farbschwellen", 400),
                    new Tuple<int, string, int>(0, "Benutzerdefinierte Schwellenr Farbe", 400),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Haube", 500),
                    new Tuple<int, string, int>(0, "Lackierte Kapuze", 500),
                    new Tuple<int, string, int>(2, "Haube mit Lufteinlass 1", 500),
                    new Tuple<int, string, int>(3, "Haube mit Lufteinlass 2", 500),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Niedriger Spoiler 1", 500),
                    new Tuple<int, string, int>(1, "Niedriger Spoiler 2", 500),
                    new Tuple<int, string, int>(2, "Niedriger Spoiler 3", 500),
                    new Tuple<int, string, int>(3, "Niedriger Spoiler 4", 500),
                    new Tuple<int, string, int>(4, "v 5", 500),
                    new Tuple<int, string, int>(5, "Mittlere Farbe Stoßstange 1", 500),
                    new Tuple<int, string, int>(9, "Mittlere Farbe Stoßstange 2", 500),
                    new Tuple<int, string, int>(19, "Custom Spoiler", 500),
                }},
                { 4, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 200),
                    new Tuple<int, string, int>(0, "Kühlergrill 1", 200),
                    new Tuple<int, string, int>(1, "Kühlergrill 2", 200),
                }},
                { 5, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Erweiterung", 500),
                    new Tuple<int, string, int>(2, "Erweiterung 1", 500),
                    new Tuple<int, string, int>(3, "Erweiterung 2", 500),
                }},
                { 7, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Ohne zu färben", 400),
                    new Tuple<int, string, int>(0, "Doppelter weißer Streifen", 400),
                    new Tuple<int, string, int>(1, "Doppelter schwarzer Streifen", 400),
                    new Tuple<int, string, int>(2, "Malvorlagen Rocket", 400),
                    new Tuple<int, string, int>(3, "Luxe Malvorlagen", 400),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Normalspur Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Lackierte Stoßstange", 400),
                    new Tuple<int, string, int>(1, "Carbon Stoßstange 1", 400),
                    new Tuple<int, string, int>(2, "Hauptfarbe Stoßstange", 400),
                    new Tuple<int, string, int>(4, "Carbon Stoßstange 2", 400),
                    new Tuple<int, string, int>(5, "Carbon Stoßstange 3", 400),
                }},
            }},
            { "Baller2", new Dictionary<int, List<Tuple<int, string, int>>>() {
            }},
            { "Cavalcade2", new Dictionary<int, List<Tuple<int, string, int>>>() {
            }},
            { "Rocoto", new Dictionary<int, List<Tuple<int, string, int>>>() {
            }},
            { "Dubsta", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Titan Auspuff ", 300),
                    new Tuple<int, string, int>(1, "Dual Titan ", 300),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Haube", 500),
                    new Tuple<int, string, int>(0, "SUV-Motorhaube", 500),
                    new Tuple<int, string, int>(1, "Haube mit einem Ersatzteil", 500),

                }},
                { 4, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Grill", 200),
                    new Tuple<int, string, int>(0, "Drahtgeflecht", 200),
                    new Tuple<int, string, int>(1, "Schwarzer Grill", 200),
                    new Tuple<int, string, int>(2, "Chromgitter", 200),
                }},
                { 5, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard linker Flügel", 300),
                    new Tuple<int, string, int>(0, "Schnorcheln", 300),
                }},
                { 6, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standarddach", 300),
                    new Tuple<int, string, int>(0, "Dachträger", 300),
                    new Tuple<int, string, int>(1, "Kofferraum mit Scheinwerfern", 300),
                    new Tuple<int, string, int>(2, "Schwarzer Dachträger", 300),
                    new Tuple<int, string, int>(3, "Kofferraum mit Scheinwerfern", 300),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Normalspur Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Chrom-Känguru", 400),
                    new Tuple<int, string, int>(1, "Känguru mit einem Bogen", 400),
                    new Tuple<int, string, int>(2, "Känguru mit Scheinwerfern", 400),
                    new Tuple<int, string, int>(3, "Känguru mit Bogen und Lichtern", 400),
                    new Tuple<int, string, int>(4, "Schwarzes Känguru", 400),
                    new Tuple<int, string, int>(5, "Känguru mit einem Bogen und einem Summen", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard hinten. Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Chromstoßstange", 400),
                    new Tuple<int, string, int>(1, "Schwarze Stoßstange", 400),
                }},
            }},
            { "Oracle2", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Chrome Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Doppelschalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Titan Auspuff", 300),
                }},
            }},
            { "Oracle", new Dictionary<int, List<Tuple<int, string, int>>>() {

            }},
            { "Ruiner", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Ausgedehnter Schalldämpfer", 300),
                    new Tuple<int, string, int>(1, "Dual Titan", 300),
                    new Tuple<int, string, int>(2, "Titan Auspuff Tuner", 300),
                    new Tuple<int, string, int>(3, "Shakotan-Schalldämpfer", 300),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Haube", 500),
                    new Tuple<int, string, int>(0, "Carbonhaube", 500),
                    new Tuple<int, string, int>(1, "Haube mit Lufteinlass", 500),
                    new Tuple<int, string, int>(2, "Motorhauben- und Scheinwerferschutz", 500),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Mittelspoiler", 500),
                    new Tuple<int, string, int>(1, "Angehobener Spoiler", 500),
                    new Tuple<int, string, int>(2, "Spoiler ziehen", 500),
                    new Tuple<int, string, int>(3, "GT Wing", 500),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Normalspur Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Custom Spoiler", 400),
                    new Tuple<int, string, int>(1, "Spoiler und Ölkühler", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Ass. Stoßstange", 400),
                }},
            }},
            { "Minivan", new Dictionary<int, List<Tuple<int, string, int>>>() {

            }},
            { "Blista2", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Twin Muffler Tuner", 300),
                    new Tuple<int, string, int>(1, "Ausgedehnter Schalldämpfer", 300),
                    new Tuple<int, string, int>(2, "Racing Schalldämpfer", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schweller", 400),
                    new Tuple<int, string, int>(0, "Benutzerdefinierte Schweller", 400),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Haube", 500),
                    new Tuple<int, string, int>(0, "Carbonhaube", 500),
                    new Tuple<int, string, int>(1, "Haube mit Lufteinlass", 500),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Niedriger Spoiler", 500),
                    new Tuple<int, string, int>(1, "Lackierter Spoiler", 500),
                    new Tuple<int, string, int>(2, "Spoiler-Tuner", 500),
                }},
                { 6, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standarddach", 300),
                    new Tuple<int, string, int>(0, "Windschutzscheibenleiste", 300),
                }},
            }},
            { "Stalion", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 6, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standarddach", 300),
                    new Tuple<int, string, int>(0, "Cabrio", 300),
                    new Tuple<int, string, int>(0, "Kundenspezifisches Dach", 300),
                }},
            }},
            { "Asterope", new Dictionary<int, List<Tuple<int, string, int>>>() {

            }},
            { "Washington", new Dictionary<int, List<Tuple<int, string, int>>>() {

            }},
            { "Premier", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Ovaler Schalldämpfer", 300),
                    new Tuple<int, string, int>(1, "Ausgedehnter Schalldämpfer", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schweller", 400),
                    new Tuple<int, string, int>(0, "Benutzerdefinierte Schweller", 400),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Spoiler-Tuner", 500),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Normalspur Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Frontsplitter", 400),
                }},
            }},

            { "Intruder", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Chrome Schalldämpfer", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schweller", 400),
                    new Tuple<int, string, int>(0, "Seitenschweller Bippu", 400),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Niedriger Spoiler", 500),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Normalspur Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Custom Frontstoßstange", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard hinten. Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Standard hinten. Stoßstange", 400),
                }},
            }},
            { "Dilettante", new Dictionary<int, List<Tuple<int, string, int>>>() {

            }},
            { "Voodoo", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Doppelschalldämpfer", 300),
                    new Tuple<int, string, int>(1, "Doppelschalldämpfer", 300),
                }},
                { 4, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Grill", 200),
                    new Tuple<int, string, int>(0, "Chromgitter", 200),
                    new Tuple<int, string, int>(1, "Dünnes Chrom. Gitter", 200),
                    new Tuple<int, string, int>(2, "Zahngitter", 200),
                }},
                { 7, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standardfarbe", 400),
                    new Tuple<int, string, int>(0, "Grüne Streifen", 400),
                    new Tuple<int, string, int>(1, "Blaue Streifen", 400),
                    new Tuple<int, string, int>(2, "Grüne Wandstreifen", 400),
                    new Tuple<int, string, int>(3, "Blaue Wandstreifen", 400),
                    new Tuple<int, string, int>(4, "Kunstvoll blau", 400),
                    new Tuple<int, string, int>(5, "Kunstvolles Orange", 400),
                    new Tuple<int, string, int>(6, "Verwickelte Geometrie", 400),
                    new Tuple<int, string, int>(7, "Formen", 400),
                    new Tuple<int, string, int>(8, "Sakkubus", 400),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Normalspur Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Optimiertes Chrome", 400),
                    new Tuple<int, string, int>(1, "Leistungsstarkes Chrome", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard hinten. Stoßstange", 400),
                }},
            }},
            { "FQ2", new Dictionary<int, List<Tuple<int, string, int>>>() {

            }},
            { "Dominator", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Titan Auspuff", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schweller", 400),
                    new Tuple<int, string, int>(0, "Custom Schweller", 400),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Haube", 500),
                    new Tuple<int, string, int>(0, "Carbonhaube", 500),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Duck Tail Spoiler", 500),
                    new Tuple<int, string, int>(1, "Angehobener Spoiler", 500),
                }},
                { 4, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Grill", 200),
                    new Tuple<int, string, int>(0, "Kühlergrill", 200),
                }},
                { 6, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standarddach", 300),
                    new Tuple<int, string, int>(0, "Heckabweiser", 300),
                    new Tuple<int, string, int>(1, "Carbon Dach", 300),
                    new Tuple<int, string, int>(2, "Abweiser und Carbon Dach", 300),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Normalspur Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Frontsplitter", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard hinten. Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Heckstoßstange lackiert", 400),
                }},
            }},
            { "Jackal", new Dictionary<int, List<Tuple<int, string, int>>>() {
                { 0, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Schalldämpfer", 300),
                    new Tuple<int, string, int>(0, "Doppelschalldämpfer", 300),
                }},
                { 1, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard-Schweller", 400),
                    new Tuple<int, string, int>(0, "Custom Schweller", 400),
                }},
                { 2, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard Haube", 500),
                    new Tuple<int, string, int>(0, "Haube mit Lufteinlass", 500),
                    new Tuple<int, string, int>(1, "Haube mit Lufteinlass", 500),
                }},
                { 3, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Nein", 500),
                    new Tuple<int, string, int>(0, "Custom Spoiler 1", 500),
                    new Tuple<int, string, int>(1, "Custom Spoiler 2", 500),
                }},
                { 8, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Normalspur Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Frontsplitter", 400),
                }},
                { 9, new List<Tuple<int, string, int>>() {
                    new Tuple<int, string, int>(-1, "Standard hinten. Stoßstange", 400),
                    new Tuple<int, string, int>(0, "Custom Heckstoßstange", 400),
                }},
            }},
        };
        public static Dictionary<int, Dictionary<string, int>> TuningPrices = new Dictionary<int, Dictionary<string, int>>()
        {
            { 10, new Dictionary<string, int>() { // engine_menu
                { "-1", 900 },
                { "0", 900 },
                { "1", 900 },
                { "2", 900 },
                { "3", 900 },
            }},
            { 11, new Dictionary<string, int>() { // turbo_menu
                { "-1", 1000 },
                { "0", 1000 },
            }},
            { 12, new Dictionary<string, int>() { // horn_menu
                { "-1", 100 },
                { "0", 100 },
                { "1", 100 },
                { "2", 100 },
            }},
            { 13, new Dictionary<string, int>() { // transmission_menu
                { "-1", 800 },
                { "0", 800 },
                { "1", 800 },
                { "2", 800 },
            }},
            { 14, new Dictionary<string, int>() { // glasses_menu
                { "0", 150 },
                { "3", 150 },
                { "2", 150 },
                { "1", 150 },
            }},
            { 15, new Dictionary<string, int>() { // suspention_menu
                { "-1", 700 },
                { "0", 700 },
                { "1", 700 },
                { "2", 700 },
                { "3", 700 },
            }},
            { 16, new Dictionary<string, int>() { // brakes_menu
                { "-1", 200 },
                { "0", 200 },
                { "1", 200 },
                { "2", 200 },
            }},
            { 17, new Dictionary<string, int>() { // lights_menu
                { "-1", 100 },
                { "0", 100 },
                { "1", 100 },
                { "2", 100 },
                { "3", 100 },
                { "4", 100 },
                { "5", 100 },
                { "6", 100 },
                { "7", 100 },
                { "8", 100 },
                { "9", 100 },
                { "10", 100 },
                { "11", 100 },
                { "12", 100 },
            }},
            { 18, new Dictionary<string, int>() { // numbers_menu
                { "0", 100 },
                { "1", 100 },
                { "2", 100 },
                { "3", 100 },
                { "4", 100 },
            }},
        };
        public static Dictionary<int, Dictionary<int, int>> TuningWheels = new Dictionary<int, Dictionary<int, int>>()
        {
            // Sportwagen
            { 0, new Dictionary<int, int>() {
                { -1, 500 },//Standard-Reifen
                { 0, 500 },//Inferno
                { 1, 500 },//Deep Five
                { 2, 500 },//Lozspeed Mk.V
                { 3, 500 },//Diamond Cut
                { 4, 500 },//Chrono
                { 5, 500 },//Feroci RR
                { 6, 500 },//FiftyNine
                { 7, 500 },//Mercie
                { 8, 500 },//Synthetic Z
                { 9, 500 },//organic Type 0
                { 10, 500 },//Endo v.1
                { 11, 500 },//Gt One
                { 12, 500 },//Duper 7
                { 13, 500 },//Uzer
                { 14, 500 },//GroundRide
                { 15, 500 },//S Racer
                { 16, 500 },//Venum
                { 17, 500 },//Cosmo
                { 18, 500 },//Dash VIP
                { 19, 500 },//ice Kid
                { 20, 500 },//ruff Weld
                { 21, 500 },//Wangan Master
                { 22, 500 },//Super Five
                { 23, 500 },//Endo v.2
                { 24, 500 },//Split Six
            }},
            // Musclecar
            { 1, new Dictionary<int, int>() {
                { -1, 500 },//Standard-Reifen
                { 0, 500 },//Classic Five
                { 1, 500 },//Dukes
                { 2, 500 },//Muscle Freak
                { 3, 500 },//Kracka
                { 4, 500 },//Azreal
                { 5, 500 },//Mecha
                { 6, 500 },//Black Top
                { 7, 500 },//Drag SPL
                { 8, 500 },//Revolver
                { 9, 500 },//Classic Rod
                { 10, 500 },//Fairlie
                { 11, 500 },//Spooner
                { 12, 500 },//Stars
                { 13, 500 },//Old School
                { 14, 500 },//El Jefe
                { 15, 500 },//Dodman
                { 16, 500 },//Six Gun
                { 17, 500 },//Mercenary
            }},
            // Lowrider
            { 2, new Dictionary<int, int>() {
                { -1, 500 },//Standard-Reifen
                { 0, 500 },//Flare
                { 1, 500 },//Wired
                { 2, 500 },//Triple Golds
                { 3, 500 },//Big Worm
                { 4, 500 },//Seven Fives
                { 5, 500 },//Split Six
                { 6, 500 },//Fresh Mesh
                { 7, 500 },//Lead Sled
                { 8, 500 },//Turbine
                { 9, 500 },//Super Fin
                { 10, 500 },//Classic Road
                { 11, 500 },//Dollar
                { 12, 500 },//Dukes
                { 13, 500 },//Low Five
                { 14, 500 },//Gooch
            }},
            // Geländewagen
            { 3, new Dictionary<int, int>() {
                { -1, 500 },//Standard-Reifen
                { 0, 500 },//Raider
                { 1, 500 },//Mudslinger
                { 2, 500 },//Nevis
                { 3, 500 },//Cairngorm
                { 4, 500 },//Amazon
                { 5, 500 },//CChallenger
                { 6, 500 },//Dune Basher
                { 7, 500 },//Five Star
                { 8, 500 },//Rock Crawler
                { 9, 500 },//Mil Spec Steelie
            }},
            // SUV
            { 4, new Dictionary<int, int>() {
                { -1, 500 },//Standard-Reifen
                { 0, 500 },//VIP
                { 1, 500 },//Benefactor
                { 2, 500 },//Cosmo
                { 3, 500 },//Bippu
                { 4, 500 },//Royal Six
                { 5, 500 },//Fagorme
                { 6, 500 },//Deluxe
                { 7, 500 },//Iced Out
                { 8, 500 },//Cognoscenti
                { 9, 500 },//LozSpeed Ten
                { 10, 500 },//Supernova
                { 11, 500 },//Obey RS
                { 12, 500 },//LozSpeed Baller
                { 13, 500 },//Extravaganzo
                { 14, 500 },//Sunrise
                { 15, 500 },//Dash VIP
                { 16, 500 },//Cutter
            }},
            // Tuner
            { 5, new Dictionary<int, int>() {
                { -1, 500 },//Standard-Reifen
                { 0, 500 },//Cosmo
                { 1, 500 },//Super Mesh
                { 2, 500 },//Outsider
                { 3, 500 },//Rollas
                { 4, 500 },//Driftmeister
                { 5, 500 },//Slicer
                { 6, 500 },//El Quatro
                { 7, 500 },//Dubbed
                { 8, 500 },//Five Star
                { 9, 500 },//Slideways
                { 10, 500 },//Apex
                { 11, 500 },//Stanced EG
                { 12, 500 },//Countersteer
                { 13, 500 },//Endo v.1
                { 14, 500 },//Endo v.2 Dish
                { 15, 500 },//Gruppe Z
                { 16, 500 },//Choku-Dori
                { 17, 500 },//Chicane
                { 18, 500 },//Saisoku
                { 19, 500 },//Dished Eight
                { 20, 500 },//FujiWara
                { 21, 500 },//Zokusha
                { 22, 500 },//Battle VII
                { 23, 500 },//Rally Master
            }},
            //exklusiv
            { 7, new Dictionary<int, int>() {
                { -1, 500 },// Standard-Reifen
                { 0, 500 },//Shadow
                { 1, 500 },//Hypher
                { 2, 500 },//Blade
                { 3, 500 },//Diamond
                { 4, 500 },//Super Gee
                { 5, 500 },//Chromatic Z
                { 6, 500 },//Mercie Ch.Lip
                { 7, 500 },//Obey RS
                { 8, 500 },//GT Chrome
                { 9, 500 },//Cheetah RR
                { 10, 500 },//Solar
                { 11, 500 },//Split Ten
                { 12, 500 },//Dash VIP
                { 13, 500 },//LozSpeed Ten
                { 14, 500 },//Carbon Inferno
                { 15, 500 },//Carbon Shadow
                { 16, 500 },//Carbonic Z
                { 17, 500 },//Carbon Solar
                { 18, 500 },//Cheetah Carbon R
                { 19, 500 },//Carbon S Racer
            }},
        };

        public static Dictionary<string, int> ProductsCapacity = new Dictionary<string, int>()
        {
            { "Materialien", 90000 },   // tattoo shop
            { "Tattoos", 25000 },
            { "Perücken", 30000 },          // barber-shop
            { "Burger", 25000},           // burger-shot

            { "Wasser", 25000},           // market
            { "Donut", 25000},           // market
            { "Kaffee", 25000},           // market
            { "Gummibärchen", 25000},    // market
            { "Schinken", 25000},    // market
            { "Rose", 25000},
            { "Schwarze Rose", 25000},
            { "Zigarette", 25000},           // market
            { "Funk", 25000},           // market

            { "Hotdog", 25000},
            { "Sandwich", 25000},
            { "eCola", 10000},
            { "Sprunk", 10000},
            { "Brechstange", 500},           // market
            { "Taschenlampe", 5000},
            { "Hammer", 500},
            { "Rohrzange", 500},
            { "Benzinkanister", 500},
            { "Chips", 5000},
            { "Pizza", 5000},
            { "SIM-Karte", 5000},
            { "Schlüsselbund", 500},
            { "Benzin", 20000},         // petrol
            { "Kleidung", 7000},        // clothes
            { "Maske", 1000},           // masks
            { "Ersatzteile", 10000},    // ls customs
            { "Waschmittel", 2000 },     // carwash
            { "Tierfutter", 200 },       // petshop
            { "Aceton", 10000 },
			{ "Rucksack", 10000 },
            { "Sultan", 100 }, // premium
            
            { "SultanRS", 100 },
            { "Kuruma", 100 },
            { "Fugitive", 100 },
            { "Tailgater", 100 },
            { "Sentinel", 100 },
            { "F620", 100 },
            { "Schwarzer", 100 },
            { "Exemplar", 100 },
            { "Felon", 100 },
            { "Schafter2", 100 },
            { "Jackal", 100 },
            { "Oracle2", 100 },
            { "Surano", 100 },
            { "Zion", 100 },
            { "Dominator", 100 },
            { "FQ2", 100 },
            { "Gresley", 100 },
            { "Serrano", 100 },
            { "Dubsta", 100 },
            { "Rocoto", 100 },
            { "Cavalcade2", 100 },
            { "XLS", 100 },
            { "Baller2", 100 },
            { "Elegy", 100 },
            { "Banshee", 100 },
            { "Massacro2", 100 },
            { "GP1", 100 },

            { "Comet2", 100 }, // luxe
            { "Coquette", 100 },
            { "Ninef", 100 },
            { "Ninef2", 100 },
            { "Jester", 100 },
            { "Elegy2", 100 },
            { "Infernus", 100 },
            { "Carbonizzare", 100 },
            { "Dubsta2", 100 },
            { "Baller3", 100 },
            { "Huntley", 100 },
            { "Superd", 100 },
            { "Windsor", 100 },
            { "BestiaGTS", 100 },
            { "Banshee2", 100 },
            { "EntityXF", 100 },
            { "Neon", 100 },
            { "Jester2", 100 },
            { "Turismor", 100 },
            { "Penetrator", 100 },
            { "Omnis", 100 },
            { "Reaper", 100 },
            { "Italigtb2", 100 },
            { "Xa21", 100 },
            { "Osiris", 100 },
            { "Nero", 100 },
            { "Zentorno", 100 },

            { "Tornado3", 100 }, // middle
            { "Tornado4", 100 },
            { "Emperor2", 100 },
            { "Voodoo2", 100 },
            { "Regina", 100 },
            { "Ingot", 100 },
            { "Emperor", 100 },
            { "Picador", 100 },
            { "Minivan", 100 },
            { "Blista2", 100 },
            { "Manana", 100 },
            { "Dilettante", 100 },
            { "Asea", 100 },
            { "Glendale", 100 },
            { "Voodoo", 100 },
            { "Surge", 100 },
            { "Primo", 100 },
            { "Stanier", 100 },
            { "Stratum", 100 },
            { "Tampa", 100 },
            { "Prairie", 100 },
            { "Radi", 100 },
            { "Blista", 100 },
            { "Stalion", 100 },
            { "Asterope", 100 },
            { "Washington", 100 },
            { "Premier", 100 },
            { "Intruder", 100 },
            { "Ruiner", 100 },
            { "Oracle", 100 },
            { "Phoenix", 100 },
            { "Gauntlet", 100 },
            { "Buffalo", 100 },
            { "RancherXL", 100 },
            { "Seminole", 100 },
            { "Baller", 100 },
            { "Landstalker", 100 },
            { "Cavalcade", 100 },
            { "BJXL", 100 },
            { "Patriot", 100 },
            { "Bison3", 100 },
            { "Issi2", 100 },
            { "Panto", 100 },

            { "Faggio2", 100 }, // moto
            { "Sanchez2", 100 },
            { "Enduro", 100 },
            { "PCJ", 100 },
            { "Hexer", 100 },
            { "Lectro", 100 },
            { "Nemesis", 100 },
            { "Hakuchou", 100 },
            { "Ruffian", 100 },
            { "Bmx",100 },
            { "Scorcher",100 },
            { "BF400", 100 },
            { "CarbonRS", 100 },
            { "Bati", 100 },
            { "Double", 100 },
            { "Diablous", 100 },
            { "Cliffhanger", 100 },
            { "Akuma", 100 },
            { "Thrust", 100 },
            { "Nightblade", 100 },
            { "Vindicator", 100 },
            { "Ratbike", 100 },
            { "Blazer", 100 },
            { "Gargoyle", 100 },
            { "Sanctus", 100 },

            { "Pistol", 200 }, // gun shop
            { "CombatPistol", 200 },
            { "Revolver", 200 },
            { "HeavyPistol", 200 },
            { "BullpupShotgun", 200 },
            { "CombatPDW", 200 },
            { "MachinePistol", 200 },
            { "Katuschen", 5000 },
        };
        public static Dictionary<string, int> ProductsOrderPrice = new Dictionary<string, int>()
        {
            {"Materialien",20},
            {"Tattoos",20},
            {"Perücken",20},
            {"Burger",2},

            {"Wasser",1},
            {"Donut",3},
            {"Kaffee",1},
            {"Gummibärchen",3},
            {"Schinken",5},
            {"Rose",3},
            {"Schwarze Rose",3},
            {"Zigarette",3},
            {"Funk",75},
            {"Aceton",15},
            {"Rucksack", 60 },

            {"Hotdog",2},
            {"Sandwich",2},
            {"eCola",3},
            {"Sprunk",3},
            {"Brechstange",25},
            {"Taschenlampe",150},
            {"Hammer",100},
            {"Rohrzange",100},
            {"Benzinkanister",50},
            {"Chips",1},
            {"Pizza",3},
            {"SIM-Karte",50},
            {"Schlüsselbund",100},
            {"Benzin",1},
            {"Kleidung",10},
            {"Maske",5},
            {"Ersatzteile",50},
            {"Waschmittel",25},
            {"Tierfutter", 55 }, // petshop

            {"Sultan",42180},
			{"SultanRS",136800},
            {"Kuruma",155200},
            {"Fugitive",39036},
            {"Tailgater",49197},
            {"Sentinel",51300},
            {"F620",96900},
			
            {"Schwarzer",102600},
            {"Exemplar",77520},
            {"Felon",83220},
            {"Schafter2",145920},
            {"Jackal",71820},
            {"Oracle2",62700},
            {"Surano",203700},
            {"Zion",58140},
            {"Dominator",57000},
            {"FQ2",63840},
            {"Gresley",61560},
            {"Serrano",39571},
            {"Dubsta",108300},
            {"Rocoto",152290},
            {"Cavalcade2",88920},
            {"XLS",92340},
            {"Baller2",85500},
            {"Elegy", 69840 },
            {"Banshee", 150350 },
            {"Massacro2", 242500},
            {"GP1", 776000},
     
            {"Comet2",93480},
            {"Coquette",99180},
            {"Ninef",223100},
            {"Ninef2",242500},
            {"Jester",232800},
            {"Elegy2",129010},
            {"Infernus",266750},
            {"Carbonizzare",226980},
            {"Dubsta2",165300},
            {"Baller3",98040},
            {"Huntley",182400},
            {"Superd",213400},
            {"Windsor",320100},
            {"BestiaGTS", 111550},
            {"Banshee2", 155200 },
            {"EntityXF", 1746000},
            {"Neon", 688700},
            {"Jester2", 364800},
            {"Turismor", 460750},
            {"Penetrator", 921500 },
            {"Omnis", 630500},
            {"Reaper", 426800},
            {"Italigtb2", 446200},
            {"Xa21", 523800},
            {"Osiris", 1164300 },
            {"Nero", 873000},
            {"Zentorno", 1940000 },
         	
         	{"Tornado3",3529},
            {"Tornado4",2743},
            {"Emperor2",4491},
            {"Voodoo2",9975},
            {"Regina",22459},
            {"Ingot",19251},
            {"Emperor",8021},
            {"Picador",23370},
            {"Minivan",34224},
            {"Blista2",23101},
            {"Manana",43849},
            {"Dilettante",25668},
            {"Asea",24598},
            {"Glendale",50266},
            {"Voodoo",36480},
            {"Surge",40461},
            {"Primo",18716},
            {"Stanier",30480},
            {"Stratum",20320},
            {"Tampa",23529},
            {"Prairie",26737},
            {"Radi",18181},
            {"Blista",19892},
            {"Stalion",25668},
            {"Asterope",33689},
            {"Washington",35293},
            {"Premier",27272},
            {"Intruder",36363},
            {"Ruiner",16042},
            {"Oracle",68400},
            {"Phoenix",27807},
            {"Gauntlet",54720},
            {"Buffalo",62700},
            {"RancherXL",44919},
            {"Seminole",47639},
            {"Baller",71820},
            {"Landstalker",64980},
            {"Cavalcade",59280},
            {"BJXL",37432 },
            {"Patriot",77520},
            {"Bison3", 26737 },
            {"Issi2", 23529},
            {"Panto", 38502},


            {"Faggio2",1069},
            {"Sanchez2",17112},
            {"Enduro",6417},
            {"PCJ",7500},
            {"Hexer",28876},
            {"Lectro",16577},
            {"Nemesis",14438},
            {"Hakuchou",37432},
            {"Ruffian",18716},
            {"Bmx",100},
            {"Scorcher",299},
            {"BF400",14973},
            {"CarbonRS",21390},
            {"Bati",27807},
            {"Double",25668},
            {"Diablous",20320},
			
            {"Cliffhanger",18181},
            {"Akuma",19251},
            {"Thrust",19251},
            {"Nightblade", 32085},
            {"Vindicator", 25668},
            {"Ratbike", 3208},
            {"Blazer", 18181},
            {"Gargoyle", 28341 },
            {"Sanctus", 44919},

            {"Pistol",3200},
            {"CombatPistol",3500},
            {"Revolver",4700},
            {"HeavyPistol",5500},
            {"BullpupShotgun",6800},
            {"CombatPDW",6500},
            {"MachinePistol",7600},
            {"Katuschen",4},
        };

        public static List<Product> fillProductList(int type)
        {
            List<Product> products_list = new List<Product>();
            switch (type)
            {
                case 0:
                    foreach (var name in MarketProducts)
                    {
                        Product product = new Product(ProductsOrderPrice[name], 0, 1, name, false);
                        products_list.Add(product);
                    }
                    break;
                case 1:
                    products_list.Add(new Product(ProductsOrderPrice["Benzin"], 0, 0, "Benzin", false));
                    break;
                case 2:
                    foreach (var name in CarsNames[0])
                    {
                        Product product = new Product(ProductsOrderPrice[name], 0, 0, name, false);
                        products_list.Add(product);
                    }
                    break;
                case 3:
                    foreach (var name in CarsNames[1])
                    {
                        Product product = new Product(ProductsOrderPrice[name], 0, 0, name, false);
                        products_list.Add(product);
                    }
                    break;
                case 4:
                    foreach (var name in CarsNames[2])
                    {
                        Product product = new Product(ProductsOrderPrice[name], 0, 0, name, false);
                        products_list.Add(product);
                    }
                    break;
                case 5:
                    foreach (var name in CarsNames[3])
                    {
                        Product product = new Product(ProductsOrderPrice[name], 0, 0, name, false);
                        products_list.Add(product);
                    }
                    break;
                case 6:
                    foreach (var name in GunNames)
                    {
                        Product product = new Product(ProductsOrderPrice[name], 0, 5, name, false);
                        products_list.Add(product);
                    }
                    products_list.Add(new Product(ProductsOrderPrice["Katuschen"], 0, 5, "Katuschen", false));
                    break;
                case 7:
                    products_list.Add(new Product(100, 200, 10, "Kleidung", false));
                    break;
                case 8:
                    foreach (var name in BurgerProducts)
                    {
                        Product product = new Product(ProductsOrderPrice[name], 10, 1, name, false);
                        products_list.Add(product);
                    }
                    break;
                case 9:
                    products_list.Add(new Product(100, 100, 0, "Materialien", false));
                    products_list.Add(new Product(100, 0, 0, "Tattoos", false));
                    break;
                case 10:
                    products_list.Add(new Product(100, 100, 0, "Materialien", false));
                    products_list.Add(new Product(100, 0, 0, "Perücken", false));
                    break;
                case 11:
                    products_list.Add(new Product(100, 50, 0, "Maske", false));
                    break;
                case 12:
                    products_list.Add(new Product(100, 1000, 0, "Ersatzteile", false));
                    break;
                case 13:
                    products_list.Add(new Product(200, 200, 0, "Waschmittel", false));
                    break;
                case 14:
                    products_list.Add(new Product(500000, 20, 0, "Tierfutter", false));
                    break;
            }
            return products_list;
        }

        public static int GetBuyingItemType(string name)
        {
            var type = -1;
            switch (name)
            {
                case "Brechstange":
                    type = (int)ItemType.Crowbar;
                    break;
                case "Taschenlampe":
                    type = (int)ItemType.Flashlight;
                    break;
                case "Hammer":
                    type = (int)ItemType.Hammer;
                    break;
                case "Rohrzange":
                    type = (int)ItemType.Wrench;
                    break;
                case "Benzinkanister":
                    type = (int)ItemType.GasCan;
                    break;
                case "Chips":
                    type = (int)ItemType.Chips;
                    break;
                case "Pizza":
                    type = (int)ItemType.Pizza;
                    break;
                case "Burger":
                    type = (int)ItemType.Burger;
                    break;
                case "Zigarette":
                    type = (int)ItemType.Zigarette;
                    break;
                case "Wasser":
                    type = (int)ItemType.Wasser;
                    break;
                case "Donut":
                    type = (int)ItemType.Donut;
                    break;
                case "Kaffee":
                    type = (int)ItemType.Kaffee;
                    break;
                case "Gummibärchen":
                    type = (int)ItemType.Gummibärchen;
                    break;
                case "Schinken":
                    type = (int)ItemType.Schinken;
                    break;
                case "Rose":
                    type = (int)ItemType.Rose;
                    break;
                case "Schwarze Rose":
                    type = (int)ItemType.SchwarzeRose;
                    break;
                case "Funk":
                    type = (int)ItemType.Funk;
                    break;
                case "Hotdog":
                    type = (int)ItemType.HotDog;
                    break;
                case "Sandwich":
                    type = (int)ItemType.Sandwich;
                    break;
                case "eCola":
                    type = (int)ItemType.eCola;
                    break;
                case "Sprunk":
                    type = (int)ItemType.Sprunk;
                    break;
                case "Schlüsselbund":
                    type = (int)ItemType.KeyRing;
                    break;
                case "Aceton":
                    type = (int)ItemType.Aceton;
                    break;
                case "Rucksack":
                    type = (int)ItemType.ItemBox;                    
                    break;
            }

            return type;
        }

        public static void interactionPressed(Player player)
        {
            if (player.GetData<int>("BIZ_ID") == -1) return;
            if (player.HasData("FOLLOWING"))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Jemand zieht dich mit", 3000);
                return;
            }
            Business biz = BizList[player.GetData<int>("BIZ_ID")];

            if (biz.Owner != "Staat" && !Main.PlayerNames.ContainsValue(biz.Owner))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.JobSms, $"Dieser {BusinessTypeNames[biz.Type]} Laden funktioniert im Moment nicht", 3000);
                return;
            }

            switch (biz.Type)
            {
                case 0:
                    OpenBizShopMenu(player);
                    return;
                case 1:
                    if (!player.IsInVehicle) return;
                    Vehicle vehicle = player.Vehicle;
                    if (vehicle == null) return; //check
                    if (player.VehicleSeat != 0) return;
                    OpenPetrolMenu(player);
                    return;
                case 2:
                case 3:
                case 4:
                case 5:
                    if (player.HasData("FOLLOWER"))
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.JobSms, $"Lass den Mann gehen", 3000);
                        return;
                    }
                    player.SetData("CARROOMID", biz.ID);
                    CarRoom.enterCarroom(player, biz.Products[0].Name);
                    return;
                case 6:
                    player.SetData("GUNSHOP", biz.ID);
                    OpenGunShopMenu(player);
                    return;
                case 7:
                    /*if ((player.GetData<bool>("ON_DUTY") && Fractions.Manager.FractionTypes[Main.Players[player].FractionID] == 2) || player.GetData<bool>("ON_WORK"))
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.JobSms, $"Sie müssen den Arbeitstag beenden", 3000);
                        return;
                    }*/
                    player.SetData("CLOTHES_SHOP", biz.ID);
                    Trigger.ClientEvent(player, "openClothes", biz.Products[0].Price);
                    player.PlayAnimation("amb@world_human_guard_patrol@male@base", "base", 1);
                    NAPI.Entity.SetEntityDimension(player, Dimensions.RequestPrivateDimension(player));
                    return;
                case 8:
                    OpenBizShopMenu(player);
                    return;
                case 9:
                   /* if ((player.GetData<bool>("ON_DUTY") && Fractions.Manager.FractionTypes[Main.Players[player].FractionID] == 2) || player.GetData<bool>("ON_WORK"))
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.JobSms, $"Sie müssen den Arbeitstag beenden", 3000);
                        return;
                    }*/
                    player.SetData("BODY_SHOP", biz.ID);
                    Main.Players[player].ExteriorPos = player.Position;
                    var dim = Dimensions.RequestPrivateDimension(player);
                    NAPI.Entity.SetEntityDimension(player, dim);
                    NAPI.Entity.SetEntityPosition(player, new Vector3(324.9798, 180.6418, 103.6665));
                    player.Rotation = new Vector3(0, 0, 101.0228);
                    player.PlayAnimation("amb@world_human_guard_patrol@male@base", "base", 1);
                    Customization.ClearClothes(player, Main.Players[player].Gender);

                    Trigger.ClientEvent(player, "openBody", false, biz.Products[1].Price);
                    return;
                case 10:
                   /* if ((player.GetData<bool>("ON_DUTY") && Fractions.Manager.FractionTypes[Main.Players[player].FractionID] == 2) || player.GetData<bool>("ON_WORK"))
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie müssen den Arbeitstag beenden", 3000);
                        return;
                    } */
                    player.SetData("BODY_SHOP", biz.ID);
                    dim = Dimensions.RequestPrivateDimension(player);
                    NAPI.Entity.SetEntityDimension(player, dim);
                    player.PlayAnimation("amb@world_human_guard_patrol@male@base", "base", 1);
                    Customization.ClearClothes(player, Main.Players[player].Gender);
                    Trigger.ClientEvent(player, "openBody", true, biz.Products[1].Price);
                    return;
                case 11:
                   /* if ((player.GetData<bool>("ON_DUTY") && Fractions.Manager.FractionTypes[Main.Players[player].FractionID] == 2) || player.GetData<bool>("ON_WORK"))
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.JobSms, $"Sie müssen den Arbeitstag beenden", 3000);
                        return;
                    } */
                    player.SetData("MASKS_SHOP", biz.ID);
                    Trigger.ClientEvent(player, "openMasks", biz.Products[0].Price);
                    player.PlayAnimation("amb@world_human_guard_patrol@male@base", "base", 1);
                    Customization.ApplyMaskFace(player);
                    return;
                case 12:
                    // ENTER TUNNING

                    if (Main.Players[player].FractionID != Fractions.TuningMan.Id)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du bist kein Tuning man!", 3000);
                        return;
                    }

                    // Only check if it is personal car, 
                    if (!player.IsInVehicle || !player.Vehicle.HasData("ACCESS") || player.Vehicle.GetData<string>("ACCESS") != "PERSONAL")
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du solltest in deinen eigenen Wagen sitzen!", 3000);
                        return;
                    }


                    if (player.Vehicle.Class == 13)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Ein Fahrrad kann nicht getunt werden!", 3000);
                        return;
                    }
                    if (player.Vehicle.Class == 8)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.JobSms, $"Das Tuning für Motorräder ist noch nicht verfügbar :( Wir werden vll. bald eine Ausbildung dafür abschließen!", 3000);
                        return;
                    }
                    var vdata = VehicleManager.Vehicles[player.Vehicle.NumberPlate];
                    if (!Tuning.ContainsKey(vdata.Model))
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.JobSms, $"Im Moment, ist Tuning für Ihr Fahrzeug nicht möglich!", 3000);
                        return;
                    }

                    var occupants = VehicleManager.GetVehicleOccupants(player.Vehicle);
                    foreach (var p in occupants)
                    {
                        if (p != player)
                            VehicleManager.WarpPlayerOutOfVehicle(p);
                    }

                    Trigger.ClientEvent(player, "tuningSeatsCheck");
                    return;
                case 13:
                    if (!player.IsInVehicle)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du solltest in einem Auto sitzen!", 3000);
                        return;
                    }
                    Trigger.ClientEvent(player, "openDialog", "CARWASH_PAY", $"Sie wollen das Auto waschen für ${biz.Products[0].Price}$?");
                    return;
                case 14:
                    if (player.HasData("FOLLOWER"))
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Lass den Mann gehen", 3000);
                        return;
                    }
                    player.SetData("PETSHOPID", biz.ID);
                    enterPetShop(player, biz.Products[0].Name);
                    return;

            }
        }

        public static void enterPetShop(Player player, string prodname)
        {
            Main.Players[player].ExteriorPos = player.Position;
            uint mydim = (uint)(player.Value + 500);
            NAPI.Entity.SetEntityDimension(player, mydim);
            NAPI.Entity.SetEntityPosition(player, new Vector3(-758.3929, 319.5044, 175.302));
            player.PlayAnimation("amb@world_human_sunbathe@male@back@base", "base", 39);
            //player.FreezePosition = true;
            player.SetData("INTERACTIONCHECK", 0);
            var prices = new List<int>();
            Business biz = BusinessManager.BizList[player.GetData<int>("PETSHOPID")];
            for (byte i = 0; i != 9; i++)
            {
                prices.Add(biz.Products[0].Price);
            }
            Trigger.ClientEvent(player, "openPetshop", JsonConvert.SerializeObject(PetNames), JsonConvert.SerializeObject(PetHashes), JsonConvert.SerializeObject(prices), mydim);
        }

        [RemoteEvent("petshopBuy")]
        public static void RemoteEvent_petshopBuy(Player player, string petName)
        {
            try
            {
                player.StopAnimation();
                Business biz = BusinessManager.BizList[player.GetData<int>("PETSHOPID")];
                NAPI.Entity.SetEntityPosition(player, new Vector3(biz.EnterPoint.X, biz.EnterPoint.Y, biz.EnterPoint.Z + 1.5));
               // player.FreezePosition = false;
                NAPI.Entity.SetEntityDimension(player, 0);
                Main.Players[player].ExteriorPos = new Vector3();
                Trigger.ClientEvent(player, "destroyCamera");
                Dimensions.DismissPrivateDimension(player);

                Houses.House house = Houses.HouseManager.GetHouse(player, true);
                if (house == null)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast kein Privathaus", 3000);
                    return;
                }
                if (Houses.HouseManager.HouseTypeList[house.Type].PetPosition == null)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.JobSms, $"Ihr Wohnort ist nicht für Haustiere geeignet", 3000);
                    return;
                }
                if (Main.Players[player].Money < biz.Products[0].Price)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Unzureichende Mittel", 3000);
                    return;
                }
                if (!BusinessManager.takeProd(biz.ID, 1, "Tierfutter", biz.Products[0].Price))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.JobSms, "Leider sind diese Haustiere noch nicht im Laden", 3000);
                    return;
                }
                MoneySystem.Wallet.Change(player, -biz.Products[0].Price);
                GameLog.Money($"player({Main.Players[player].UUID})", $"biz({biz.ID})", biz.Products[0].Price, $"buyPet({petName})");
                house.PetName = petName;
                Main.Players[player].PetName = petName;
                Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Sie sind jetzt ein glücklicher Gastgeber {petName}!", 3000);
            }
            catch (Exception e) { Log.Write("PetshopBuy: " + e.Message, nLog.Type.Error); }
        }

        [RemoteEvent("petshopCancel")]
        public static void RemoteEvent_petshopCancel(Player player)
        {
            try
            {
                if (!player.HasData("PETSHOPID")) return;
                player.StopAnimation();
                var enterPoint = BusinessManager.BizList[player.GetData<int>("PETSHOPID")].EnterPoint;
                NAPI.Entity.SetEntityDimension(player, 0);
                NAPI.Entity.SetEntityPosition(player, new Vector3(enterPoint.X, enterPoint.Y, enterPoint.Z + 1.5));
                Main.Players[player].ExteriorPos = new Vector3();
                //player.FreezePosition = false;
                Dimensions.DismissPrivateDimension(player);
                player.ResetData("PETSHOPID");
                Trigger.ClientEvent(player, "destroyCamera");
            }
            catch (Exception e) { Log.Write("petshopCancel: " + e.Message, nLog.Type.Error); }
        }

        public static void Carwash_Pay(Player player)
        {
            try
            {
                if (player.GetData<int>("BIZ_ID") == -1) return;
                Business biz = BizList[player.GetData<int>("BIZ_ID")];

                if (player.IsInVehicle)
                {
                    if (player.VehicleSeat == 0)
                    {
                        if (VehicleStreaming.GetVehicleDirt(player.Vehicle) >= 0.01f)
                        {
                            if (Main.Players[player].Money < biz.Products[0].Price)
                            {
                                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Unzureichende Mittel", 3000);
                                return;
                            }

                            if (!takeProd(biz.ID, 1, "Waschmittel", biz.Products[0].Price))
                            {
                                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Das Produkt ist nicht auf Lager!", 3000);
                                return;
                            }
                            GameLog.Money($"player({Main.Players[player].UUID})", $"biz({biz.ID})", biz.Products[0].Price, "carwash");
                            MoneySystem.Wallet.Change(player, -biz.Products[0].Price);

                            VehicleStreaming.SetVehicleDirt(player.Vehicle, 0.0f);
                            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, "Ihr Fahrzeug wurde gewaschen", 3000);
                        }
                        else
                            Notify.Send(player, NotifyType.Alert, NotifyPosition.MapUp, "Ihr Fahrzeug ist nicht verschmutzt", 3000);
                    }
                    else
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Nur der Fahrer kann das Fahrzeug waschen", 3000);
                }
                return;
            }
            catch (Exception e)
            {
                Log.Write(e.ToString(), nLog.Type.Error);
                return;
            }
        }

        [RemoteEvent("tuningSeatsCheck")]
        public static void RemoteEvent_tuningSeatsCheck(Player player)
        {
            try
            {
                if (Main.Players[player].FractionID != Fractions.TuningMan.Id)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du bist kein Tuning Man!", 3000);
                    return;
                }

                if (!player.IsInVehicle || !player.Vehicle.HasData("ACCESS") || player.Vehicle.GetData<string>("ACCESS") != "PERSONAL")
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du solltest in deinen eigenen Wagen sitzen!", 3000);
                    return;
                }
                if (player.Vehicle.Class == 13)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Ein Fahrrad kann nicht getunt werden!", 3000);
                    return;
                }
                if (player.Vehicle.Class == 8)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.JobSms, $"Das Tuning für Motorräder ist noch nicht verfügbar :( Wir werden vll. bald eine Ausbildung dafür abschließen!", 3000);
                    return;
                }
                var vdata = VehicleManager.Vehicles[player.Vehicle.NumberPlate];
                if (!Tuning.ContainsKey(vdata.Model))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.JobSms, $"Im Moment, ist Tuning für Ihr Fahrzeug nicht möglich!", 3000);
                    return;
                }

                if (player.GetData<int>("BIZ_ID") == -1) return;
                if (player.HasData("FOLLOWING"))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Jemand nimmt dich mit!", 3000);
                    return;
                }
                Business biz = BizList[player.GetData<int>("BIZ_ID")];

                Main.Players[player].TuningShop = biz.ID;

                var veh = player.Vehicle;
                var dim = Dimensions.RequestPrivateDimension(player);
                NAPI.Entity.SetEntityDimension(veh, dim);
                NAPI.Entity.SetEntityDimension(player, dim);

                player.SetIntoVehicle(veh, -1);

                NAPI.Entity.SetEntityPosition(veh, new Vector3(-337.7784, -136.5316, 38.4032));
                NAPI.Entity.SetEntityRotation(veh, new Vector3(0.04308624, 0.07037075, 148.9986));

                var modelPrice = ProductsOrderPrice[VehicleManager.Vehicles[player.Vehicle.NumberPlate].Model];
                var modelPriceMod = (modelPrice < 150000) ? 1 : 2;

                Trigger.ClientEvent(player, "openTun", biz.Products[0].Price, VehicleManager.Vehicles[player.Vehicle.NumberPlate].Model, modelPriceMod, JsonConvert.SerializeObject(VehicleManager.Vehicles[player.Vehicle.NumberPlate].Components));
            }
            catch (Exception e) { Log.Write("tuningSeatsCheck: " + e.Message, nLog.Type.Error); }
        }
        [RemoteEvent("exitTuning")]
        public static void RemoteEvent_exitTuning(Player player)
        {
            try
            {
                int bizID = Main.Players[player].TuningShop;

                var veh = player.Vehicle;
                NAPI.Entity.SetEntityDimension(veh, 0);
                NAPI.Entity.SetEntityDimension(player, 0);

                player.SetIntoVehicle(veh, -1);

                NAPI.Entity.SetEntityPosition(veh, BizList[bizID].EnterPoint + new Vector3(0, 0, 0.5));
                VehicleManager.ApplyCustomization(veh);
                Dimensions.DismissPrivateDimension(player);
                Main.Players[player].TuningShop = -1;
            }
            catch (Exception e) { Log.Write("ExitTuning: " + e.Message, nLog.Type.Error); }
        }

        [RemoteEvent("buyTuning")]
        public static void RemoteEvent_buyTuning(Player player, params object[] arguments)
        {
            try
            {
                if (Main.Players[player].FractionID != Fractions.TuningMan.Id)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.JobSms, $"Du bist kein Tuning Man!", 3000);
                    return;
                }

                if (!Main.Players.ContainsKey(player)) return;

                int bizID = Main.Players[player].TuningShop;
                Business biz = BizList[bizID];

                var cat = Convert.ToInt32(arguments[0].ToString());
                var id = Convert.ToInt32(arguments[1].ToString());

                var wheelsType = -1;
                var r = 0;
                var g = 0;
                var b = 0;

                if (cat == 19)
                    wheelsType = Convert.ToInt32(arguments[2].ToString());
                else if (cat == 20)
                {
                    r = Convert.ToInt32(arguments[2].ToString());
                    g = Convert.ToInt32(arguments[3].ToString());
                    b = Convert.ToInt32(arguments[4].ToString());
                }

                var vehModel = VehicleManager.Vehicles[player.Vehicle.NumberPlate].Model;

                var modelPrice = ProductsOrderPrice[vehModel];
                var modelPriceMod = (modelPrice < 150000) ? 1 : 2;

                var price = 0;
                if (cat <= 9)
                    price = Convert.ToInt32(Tuning[vehModel][cat].FirstOrDefault(el => el.Item1 == id).Item3 * biz.Products[0].Price / 100.0);
                else if (cat <= 18)
                    price = Convert.ToInt32(TuningPrices[cat][id.ToString()] * modelPriceMod * biz.Products[0].Price / 100.0);
                else if (cat == 19)
                    price = Convert.ToInt32(TuningWheels[wheelsType][id] * biz.Products[0].Price / 100.0);
                else
                    price = Convert.ToInt32(5000 * biz.Products[0].Price / 100.0);

                if (Main.Players[player].Money < price)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.JobSms, $"Sie fehlen noch {price - Main.Players[player].Money}$ zum Kauf dieser Modifikation", 3000);
                    Trigger.ClientEvent(player, "tunBuySuccess", -2);
                    return;
                }

                var amount = Convert.ToInt32(price * 0.75 / 2000);
                if (amount <= 0) amount = 1;


                // There is no functionality to fill products for TuningMan fraction
                // In other words products unlimited for fraction TuningMan
               // if (Main.Players[player].FractionID != Fractions.TuningMan.Id)
                {
                    if (!takeProd(biz.ID, amount, "Ersatzteile", price))
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.JobSms, "Dieser Werkstatt gingen die Ersatzteile aus", 3000);
                        Trigger.ClientEvent(player, "tunBuySuccess", -2);
                        return;
                    }
                }

                GameLog.Money($"player({Main.Players[player].UUID})", $"biz({biz.ID})", price, $"buyTuning({player.Vehicle.NumberPlate},{cat},{id})");
                MoneySystem.Wallet.Change(player, -price);
                Trigger.ClientEvent(player, "tunBuySuccess", id);

                var number = player.Vehicle.NumberPlate;

                switch (cat)
                {
                    case 0:
                        VehicleManager.Vehicles[number].Components.Muffler = id;
                        break;
                    case 1:
                        VehicleManager.Vehicles[number].Components.SideSkirt = id;
                        break;
                    case 2:
                        VehicleManager.Vehicles[number].Components.Hood = id;
                        break;
                    case 3:
                        VehicleManager.Vehicles[number].Components.Spoiler = id;
                        break;
                    case 4:
                        VehicleManager.Vehicles[number].Components.Lattice = id;
                        break;
                    case 5:
                        VehicleManager.Vehicles[number].Components.Wings = id;
                        break;
                    case 6:
                        VehicleManager.Vehicles[number].Components.Roof = id;
                        break;
                    case 7:
                        VehicleManager.Vehicles[number].Components.Vinyls = id;
                        break;
                    case 8:
                        VehicleManager.Vehicles[number].Components.FrontBumper = id;
                        break;
                    case 9:
                        VehicleManager.Vehicles[number].Components.RearBumper = id;
                        break;
                    case 10:
                        VehicleManager.Vehicles[number].Components.Engine = id;
                        break;
                    case 11:
                        VehicleManager.Vehicles[number].Components.Turbo = id;
                        break;
                    case 12:
                        VehicleManager.Vehicles[number].Components.Horn = id;
                        break;
                    case 13:
                        VehicleManager.Vehicles[number].Components.Transmission = id;
                        break;
                    case 14:
                        VehicleManager.Vehicles[number].Components.WindowTint = id;
                        break;
                    case 15:
                        VehicleManager.Vehicles[number].Components.Suspension = id;
                        break;
                    case 16:
                        VehicleManager.Vehicles[number].Components.Brakes = id;
                        break;
                    case 17:
                        VehicleManager.Vehicles[number].Components.Headlights = id;
                        player.Vehicle.SetSharedData("hlcolor", id);
                        Trigger.ClientEvent(player, "VehStream_SetVehicleHeadLightColor", player.Vehicle.Handle, id);
                        break;
                    case 18:
                        VehicleManager.Vehicles[number].Components.NumberPlate = id;
                        break;
                    case 19:
                        VehicleManager.Vehicles[number].Components.Wheels = id;
                        VehicleManager.Vehicles[number].Components.WheelsType = wheelsType;
                        break;
                    case 20:
                        if (id == 0)
                            VehicleManager.Vehicles[number].Components.PrimColor = new Color(r, g, b);
                        else
                            VehicleManager.Vehicles[number].Components.SecColor = new Color(r, g, b);
                        break;
                }
                VehicleManager.Save(number);
                Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, "Sie haben diese Modifikation gekauft und installiert", 3000);
                Trigger.ClientEvent(player, "tuningUpd", JsonConvert.SerializeObject(VehicleManager.Vehicles[number].Components));
            }
            catch (Exception e) { Log.Write("buyTuning: " + e.Message, nLog.Type.Error); }
        }

        public static bool takeProd(int bizid, int amount, string prodname, int addMoney)
        {
            try
            {
                Business biz = BizList[bizid];
                foreach (var p in biz.Products)
                {
                    if (p.Name != prodname) continue;
                    if (p.Lefts - amount < 0)
                        return false;

                    p.Lefts -= amount;

                    if (biz.Owner == "Staat") break;
                    Bank.Data bData = Bank.Get(Main.PlayerBankAccs[biz.Owner]);
                    if (bData.ID == 0)
                    {
                        Log.Write($"TakeProd BankID error: {bizid.ToString()}({biz.Owner}) {amount.ToString()} {prodname} {addMoney.ToString()}", nLog.Type.Error);
                        return false;
                    }
                    if (!Bank.Change(bData.ID, addMoney, false))
                    {
                        Log.Write($"TakeProd error: {bizid.ToString()}({biz.Owner}) {amount.ToString()} {prodname} {addMoney.ToString()}", nLog.Type.Error);
                        return false;
                    }
                    GameLog.Money($"biz({bizid})", $"bank({bData.ID})", addMoney, "bizProfit");
                    Log.Write($"{biz.Owner}'s business get {addMoney}$ for '{prodname}'", nLog.Type.Success);
                    break;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static int getPriceOfProd(int bizid, string prodname)
        {
            Business biz = BizList[bizid];
            var price = 0;
            foreach (var p in biz.Products)
            {
                if (p.Name == prodname)
                {
                    price = p.Price;
                    break;
                }
            }
            return price;
        }

        public static Vector3 getNearestBiz(Player player, int type)
        {
            Vector3 nearestBiz = null;
            foreach (var b in BizList)
            {
                Business biz = BizList[b.Key];
                if (biz.Type != type) continue;
                if (nearestBiz == null) nearestBiz = biz.EnterPoint;
                if (player.Position.DistanceTo(biz.EnterPoint) < player.Position.DistanceTo(nearestBiz))
                    nearestBiz = biz.EnterPoint;
            }
            return nearestBiz;
        }

        private static List<int> clothesOutgo = new List<int>()
        {
            1, // Головные уборы
            4, // Верхняя одежда
            3, // Нижняя одежда
            2, // Треники abibas
            1, // Кеды нike
        };

        [RemoteEvent("cancelMasks")]
        public static void RemoteEvent_cancelMasks(Player player)
        {
            try
            {
                player.StopAnimation();
                Customization.ApplyCharacter(player);
                Customization.SetMask(player, Customization.CustomPlayerData[Main.Players[player].UUID].Clothes.Mask.Variation, Customization.CustomPlayerData[Main.Players[player].UUID].Clothes.Mask.Texture);
            }
            catch (Exception e) { Log.Write("cancelMasks: " + e.Message, nLog.Type.Error); }
        }

        [RemoteEvent("buyMasks")]
        public static void RemoteEvent_buyMasks(Player player, int variation, int texture)
        {
            try
            {
                Business biz = BizList[player.GetData<int>("MASKS_SHOP")];
                var prod = biz.Products[0];

                var tempPrice = Customization.Masks.FirstOrDefault(f => f.Variation == variation).Price;

                var price = Convert.ToInt32((tempPrice / 100.0) * prod.Price);

                var tryAdd = nInventory.TryAdd(player, new nItem(ItemType.Top));
                if (tryAdd == -1 || tryAdd > 0)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Nicht genügend Platz im Inventar", 3000);
                    return;
                }
                if (Main.Players[player].Money < price)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Unzureichende Mittel", 3000);
                    return;
                }

                if (!takeProd(biz.ID, 1, "Maske", price))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Das Produkt ist nicht auf Lager!", 3000);
                    return;
                }
                GameLog.Money($"player({Main.Players[player].UUID})", $"biz({biz.ID})", price, "buyMask");
                MoneySystem.Wallet.Change(player, -price);

                Customization.AddClothes(player, ItemType.Mask, variation, texture);

                Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, "Du hast eine neue Maske gekauft. Die wurde in dein Rucksack gestopft!", 3000);
                return;
            }
            catch (Exception e) { Log.Write("buyMasks: " + e.Message, nLog.Type.Error); }
        }

        [RemoteEvent("cancelClothes")]
        public static void RemoteEvent_cancelClothes(Player player)
        {
            try
            {
                player.StopAnimation();
                Customization.ApplyCharacter(player);
                NAPI.Entity.SetEntityDimension(player, 0);
                Dimensions.DismissPrivateDimension(player);
            }
            catch (Exception e) { Log.Write("cancelClothes: " + e.Message, nLog.Type.Error); }
        }

        [RemoteEvent("buyClothes")]
        public static void RemoteEvent_buyClothes(Player player, int type, int variation, int texture)
        {
            try
            {
                Business biz = BizList[player.GetData<int>("CLOTHES_SHOP")];
                var prod = biz.Products[0];

                var tempPrice = 0;
                switch (type)
                {
                    case 0:
                        tempPrice = Customization.Hats[Main.Players[player].Gender].FirstOrDefault(h => h.Variation == variation).Price;
                        break;
                    case 1:
                        tempPrice = Customization.Tops[Main.Players[player].Gender].FirstOrDefault(t => t.Variation == variation).Price;
                        break;
                    case 2:
                        tempPrice = Customization.Underwears[Main.Players[player].Gender].FirstOrDefault(h => h.Value.Top == variation).Value.Price;
                        break;
                    case 3:
                        tempPrice = Customization.Legs[Main.Players[player].Gender].FirstOrDefault(l => l.Variation == variation).Price;
                        break;
                    case 4:
                        tempPrice = Customization.Feets[Main.Players[player].Gender].FirstOrDefault(f => f.Variation == variation).Price;
                        break;
                    case 5:
                        tempPrice = Customization.Gloves[Main.Players[player].Gender].FirstOrDefault(f => f.Variation == variation).Price;
                        break;
                    case 6:
                        tempPrice = Customization.Accessories[Main.Players[player].Gender].FirstOrDefault(f => f.Variation == variation).Price;
                        break;
                    case 7:
                        tempPrice = Customization.Glasses[Main.Players[player].Gender].FirstOrDefault(f => f.Variation == variation).Price;
                        break;
                    case 8:
                        tempPrice = Customization.Jewerly[Main.Players[player].Gender].FirstOrDefault(f => f.Variation == variation).Price;
                        break;
                }

                var price = Convert.ToInt32((tempPrice / 100.0) * prod.Price);

                var tryAdd = nInventory.TryAdd(player, new nItem(ItemType.Top));
                if (tryAdd == -1 || tryAdd > 0)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Nicht genügend Platz im Inventar", 3000);
                    return;
                }
                if (Main.Players[player].Money < price)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Unzureichende Mittel", 3000);
                    return;
                }

                var amount = Convert.ToInt32(price * 0.75 / 50);
                if (amount <= 0) amount = 1;
                if (!takeProd(biz.ID, amount, "Kleidung", price))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Das Produkt ist nicht auf Lager!", 3000);
                    return;
                }
                GameLog.Money($"player({Main.Players[player].UUID})", $"biz({biz.ID})", price, "buyClothes");
                MoneySystem.Wallet.Change(player, -price);

                switch (type)
                {
                    case 0:
                        Customization.AddClothes(player, ItemType.Hat, variation, texture);
                        break;
                    case 1:
                        Customization.AddClothes(player, ItemType.Top, variation, texture);
                        break;
                    case 2:
                        var id = Customization.Underwears[Main.Players[player].Gender].FirstOrDefault(u => u.Value.Top == variation);
                        Customization.AddClothes(player, ItemType.Undershit, id.Key, texture);
                        break;
                    case 3:
                        Customization.AddClothes(player, ItemType.Leg, variation, texture);
                        break;
                    case 4:
                        Customization.AddClothes(player, ItemType.Feet, variation, texture);
                        break;
                    case 5:
                        Customization.AddClothes(player, ItemType.Gloves, variation, texture);
                        break;
                    case 6:
                        Customization.AddClothes(player, ItemType.Accessories, variation, texture);
                        break;
                    case 7:
                        Customization.AddClothes(player, ItemType.Glasses, variation, texture);
                        break;
                    case 8:
                        Customization.AddClothes(player, ItemType.Jewelry, variation, texture);
                        break;
                }

                Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, "Du hast neue Klamotten gekauft. Sie wurden in dein Rucksack gestopft", 3000);
                return;
            }
            catch (Exception e) { Log.Write("BuyClothes: " + e.Message, nLog.Type.Error); }
        }

        [RemoteEvent("cancelBody")]
        public static void RemoteEvent_cancelTattoo(Player player)
        {
            try
            {
                Business biz = BizList[player.GetData<int>("BODY_SHOP")];
                NAPI.Entity.SetEntityDimension(player, 0);
                NAPI.Entity.SetEntityPosition(player, biz.EnterPoint + new Vector3(0, 0, 1.12));
                Main.Players[player].ExteriorPos = new Vector3();
                Customization.ApplyCharacter(player);
            }
            catch (Exception e) { Log.Write("CancelBody: " + e.Message, nLog.Type.Error); }
        }

        [RemoteEvent("buyTattoo")]
        public static void RemoteEvent_buyTattoo(Player player, params object[] arguments)
        {
            try
            {
                var zone = Convert.ToInt32(arguments[0].ToString());
                var tattooID = Convert.ToInt32(arguments[1].ToString());
                var tattoo = BusinessTattoos[zone][tattooID];

                Log.Debug($"buyTattoo zone: {zone} | id: {tattooID}");

                Business biz = BizList[player.GetData<int>("BODY_SHOP")];

                var prod = biz.Products.FirstOrDefault(p => p.Name == "Tattoos");
                double price = tattoo.Price / 100.0 * prod.Price;
                if (Main.Players[player].Money < Convert.ToInt32(price))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Sie haben dafür nicht genug Geld!", 3000);
                    return;
                }

                var amount = Convert.ToInt32(price * 0.75 / 100);
                if (amount <= 0) amount = 1;
                if (!takeProd(biz.ID, amount, "Materialien", Convert.ToInt32(price)))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Dieser Tattoo Salon kann diesen Service aktuell nicht anbieten!", 3000);
                    return;
                }
                GameLog.Money($"player({Main.Players[player].UUID})", $"biz({biz.ID})", Convert.ToInt32(price), "buyTattoo");
                MoneySystem.Wallet.Change(player, -Convert.ToInt32(price));

                var tattooHash = (Main.Players[player].Gender) ? tattoo.MaleHash : tattoo.FemaleHash;
                List<Tattoo> validTattoos = new List<Tattoo>();
                foreach (var t in Customization.CustomPlayerData[Main.Players[player].UUID].Tattoos[zone])
                {
                    var isValid = true;
                    foreach (var slot in tattoo.Slots)
                    {
                        if (t.Slots.Contains(slot))
                        {
                            isValid = false;
                            break;
                        }
                    }
                    if (isValid) validTattoos.Add(t);
                }

                validTattoos.Add(new Tattoo(tattoo.Dictionary, tattooHash, tattoo.Slots));
                Customization.CustomPlayerData[Main.Players[player].UUID].Tattoos[zone] = validTattoos;

                player.SetSharedData("TATTOOS", JsonConvert.SerializeObject(Customization.CustomPlayerData[Main.Players[player].UUID].Tattoos));

                Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Du hast dir das Tattoo {tattoo.Name} für {Convert.ToInt32(price)}$ stechen lassen!", 3000);
            }
            catch (Exception e) { Log.Write("BuyTattoo: " + e.Message, nLog.Type.Error); }
        }

        public static Dictionary<string, List<int>> BarberPrices = new Dictionary<string, List<int>>()
        {
            { "hair", new List<int>() {
                400,
                350,
                350,
                450,
                450,
                600,
                450,
                110,
                450,
                600,
                600,
                400,
                350,
                200,
                750,
                150,
                450,
                600,
                600,
                400,
                350,
                200,
                750,
                150,
            }},
            { "beard", new List<int>() {
                120,
                120,
                120,
                120,
                120,
                160,
                160,
                160,
                120,
                120,
                240,
                240,
                120,
                120,
                240,
                200,
                120,
                160,
                380,
                360,
                360,
                180,
                180,
                260,
                120,
                120,
                240,
                200,
                120,
                160,
                380,
                360,
                360,
                180,
                180,
                260,
                120,
                180,
                180,
            }},
            { "eyebrows", new List<int>() {
                100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100
            }},
            { "chesthair", new List<int>() {
                100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100
            }},
            { "lenses", new List<int>() {
                200,
                400,
                400,
                200,
                200,
                400,
                200,
                400,
                100,
                100,
            }},
            { "lipstick", new List<int>() {
                200,
                400,
                400,
                200,
                200,
                400,
                200,
                400,
                100,
                300,
            }},
            { "blush", new List<int>() {
                200,
                400,
                400,
                200,
                200,
                400,
                200,
            }},
            { "makeup", new List<int>() {
                120,
                120,
                120,
                120,
                120,
                160,
                160,
                160,
                120,
                120,
                240,
                240,
                120,
                120,
                240,
                200,
                120,
                160,
                380,
                360,
                360,
                180,
                180,
                260,
                120,
                120,
                240,
                200,
                120,
                160,
                380,
                360,
                360,
                180,
                180,
                260,
                120,
                180,
                180,
            }},
        };

        [RemoteEvent("buyBarber")]
        public static void RemoteEvent_buyBarber(Player player, string id, int style, int color)
        {
            try
            {
                Log.Debug($"buyBarber: id - {id} | style - {style} | color - {color}");

                Business biz = BizList[player.GetData<int>("BODY_SHOP")];

                if ((id == "lipstick" || id == "blush" || id == "makeup") && Main.Players[player].Gender && style != 255)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Nur für weibliche Personen verfügbar!", 3000);
                    return;
                }

                var prod = biz.Products.FirstOrDefault(p => p.Name == "Perücken");
                double price;
                if (id == "hair")
                {
                    if (style >= 23) price = BarberPrices[id][23] / 100.0 * prod.Price;
                    else price = (style == 255) ? BarberPrices[id][0] / 100.0 * prod.Price : BarberPrices[id][style] / 100.0 * prod.Price;
                }
                else price = (style == 255) ? BarberPrices[id][0] / 100.0 * prod.Price : BarberPrices[id][style] / 100.0 * prod.Price;
                if (Main.Players[player].Money < Convert.ToInt32(price))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Unzureichende Mittel", 3000);
                    return;
                }
                if (!takeProd(biz.ID, 1, "Materialien", Convert.ToInt32(price)))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Dieser Friseur kann diesen Service derzeit aktuell nicht anbieten!", 3000);
                    return;
                }
                GameLog.Money($"player({Main.Players[player].UUID})", $"biz({biz.ID})", Convert.ToInt32(price), "buyBarber");
                MoneySystem.Wallet.Change(player, -Convert.ToInt32(price));

                switch (id)
                {
                    case "hair":
                        Customization.CustomPlayerData[Main.Players[player].UUID].Hair = new HairData(style, color, color);
                        break;
                    case "beard":
                        Customization.CustomPlayerData[Main.Players[player].UUID].Appearance[1].Value = style;
                        Customization.CustomPlayerData[Main.Players[player].UUID].BeardColor = color;
                        break;
                    case "eyebrows":
                        Customization.CustomPlayerData[Main.Players[player].UUID].Appearance[2].Value = style;
                        Customization.CustomPlayerData[Main.Players[player].UUID].EyebrowColor = color;
                        break;
                    case "chesthair":
                        Customization.CustomPlayerData[Main.Players[player].UUID].Appearance[10].Value = style;
                        Customization.CustomPlayerData[Main.Players[player].UUID].ChestHairColor = color;
                        break;
                    case "lenses":
                        Customization.CustomPlayerData[Main.Players[player].UUID].EyeColor = style;
                        break;
                    case "lipstick":
                        Customization.CustomPlayerData[Main.Players[player].UUID].Appearance[8].Value = style;
                        Customization.CustomPlayerData[Main.Players[player].UUID].LipstickColor = color;
                        break;
                    case "blush":
                        Customization.CustomPlayerData[Main.Players[player].UUID].Appearance[5].Value = style;
                        Customization.CustomPlayerData[Main.Players[player].UUID].BlushColor = color;
                        break;
                    case "makeup":
                        Customization.CustomPlayerData[Main.Players[player].UUID].Appearance[4].Value = style;
                        break;
                }

                Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Sie haben beim Friseur {Convert.ToInt32(price)}$ ausgegeben!", 3000);
                return;
            }
            catch (Exception e) { Log.Write("BuyBarber: " + e.Message, nLog.Type.Error); }
        }

        [RemoteEvent("petrol")]
        public static void fillCar(Player player, int lvl)
        {
            try
            {
                if (player == null || !Main.Players.ContainsKey(player)) return;
                Vehicle vehicle = player.Vehicle;
                if (vehicle == null) return; //check
                if (player.VehicleSeat != 0) return;
                if (lvl <= 0)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Geben Sie die richtigen Daten ein", 3000);
                    return;
                }
                if (!vehicle.HasSharedData("PETROL"))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Dieses Auto kann nicht betankt werden", 3000);
                    return;
                }
                if (Core.VehicleStreaming.GetEngineState(vehicle))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Zum betanken des Fahrzeugs bitte den Motor ausschalten", 3000);
                    return;
                }
                int fuel = vehicle.GetSharedData<int>("PETROL");
                if (fuel >= VehicleManager.VehicleTank[vehicle.Class])
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Das Fahrzeug hat einen vollen Tank", 3000);
                    return;
                }

                var isGov = false;
                if (lvl == 9999)
                    lvl = VehicleManager.VehicleTank[vehicle.Class] - fuel;
                else if (lvl == 99999)
                {
                    isGov = true;
                    lvl = VehicleManager.VehicleTank[vehicle.Class] - fuel;
                }

                if (lvl < 0) return;

                int tfuel = fuel + lvl;
                if (tfuel > VehicleManager.VehicleTank[vehicle.Class])
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Geben Sie die richtigen Daten ein", 3000);
                    return;
                }
                Business biz = BizList[player.GetData<int>("BIZ_ID")];
                if (isGov)
                {
                    int frac = Main.Players[player].FractionID;
                    if (Fractions.Manager.FractionTypes[frac] != 2)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Um auf öffentliche Kosten tanken zu können, müssen Sie Mitglied einer Regierungsbehörde sein", 3000);
                        return;
                    }
                    if (!vehicle.HasData("ACCESS") || vehicle.GetData<string>("ACCESS") != "FRACTION" || vehicle.GetData<int>("FRACTION") != frac)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie können nicht auf öffentliche Kosten tanken, nicht mit öffentlichen Verkehrsmitteln", 3000);
                        return;
                    }
                    if (Fractions.Stocks.fracStocks[frac].FuelLeft < lvl * biz.Products[0].Price)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Grenzwert für Benzin für den öffentlichen Verkehr für den Tag ist erschöpft", 3000);
                        return;
                    }
                }
                else
                {
                    if (Main.Players[player].Money < lvl * biz.Products[0].Price)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Unzureichende Mittel (nicht genug {lvl * biz.Products[0].Price - Main.Players[player].Money}$)", 3000);
                        return;
                    }
                }
                if (!takeProd(biz.ID, lvl, "Benzin", lvl * biz.Products[0].Price))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Es gibt nur noch eine Sache an der Tankstelle {biz.Products[0].Lefts}л", 3000);
                    return;
                }
                if (isGov)
                {
                    GameLog.Money($"frac(6)", $"biz({biz.ID})", lvl * biz.Products[0].Price, "buyPetrol");
                    Fractions.Stocks.fracStocks[6].Money -= lvl * biz.Products[0].Price;
                    Fractions.Stocks.fracStocks[Main.Players[player].FractionID].FuelLeft -= lvl * biz.Products[0].Price;
                }
                else
                {
                    GameLog.Money($"player({Main.Players[player].UUID})", $"biz({biz.ID})", lvl * biz.Products[0].Price, "buyPetrol");
                    MoneySystem.Wallet.Change(player, -lvl * biz.Products[0].Price);
                }

                vehicle.SetSharedData("PETROL", tfuel);

                if (NAPI.Data.GetEntityData(vehicle, "ACCESS") == "PERSONAL")
                {
                    var number = NAPI.Vehicle.GetVehicleNumberPlate(vehicle);
                    VehicleManager.Vehicles[number].Fuel += lvl;
                }
                Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Das Fahrzeug ist vollgetankt", 3000);
                //  Commands.RPChat("me", player, $"Betankung des Fahrzeugs");
            }
            catch (Exception e) { Log.Write("Petrol: " + e.Message, nLog.Type.Error); }
        }

        public static void bizNewPrice(Player player, int price, int BizID)
        {
            if (!Main.Players[player].BizIDs.Contains(BizID)) return;
            Business biz = BizList[BizID];
            var prodName = player.GetData<string>("SELECTPROD");

            double minPrice = (biz.Type == 7 || biz.Type == 11 || biz.Type == 12 || prodName == "Tattoos" || prodName == "Perücken" || prodName == "Katuschen") ? 80 : (biz.Type == 1) ? 2 : ProductsOrderPrice[player.GetData<string>("SELECTPROD")] * 0.8;
            double maxPrice = (biz.Type == 7 || biz.Type == 11 || biz.Type == 12 || prodName == "Tattoos" || prodName == "Perücken" || prodName == "Katuschen") ? 150 : (biz.Type == 1) ? 7 : ProductsOrderPrice[player.GetData<string>("SELECTPROD")] * 1.2;

            if (price < minPrice || price > maxPrice)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Ein solcher Preis kann nicht festgelegt werden", 3000);
                OpenBizProductsMenu(player);
                return;
            }
            foreach (var p in biz.Products)
            {
                if (p.Name == prodName)
                {
                    p.Price = price;
                    string ch = (biz.Type == 7 || biz.Type == 11 || biz.Type == 12 || p.Name == "Tattoos" || p.Name == "Perücken") ? "%" : "$";

                    Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Sie haben den Preis von {p.Name} auf {p.Price}% gesetzt!", 3000);   //{ch}
                    if (p.Name == "Benzin") biz.UpdateLabel();
                    OpenBizProductsMenu(player);
                    return;
                }
            }
        }

        public static void bizOrder(Player player, int amount, int BizID)
        {
            if (!Main.Players[player].BizIDs.Contains(BizID)) return;
            Business biz = BizList[BizID];

            if (amount < 1)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Falscher Wert", 3000);
                OpenBizProductsMenu(player);
                return;
            }

            foreach (var p in biz.Products)
            {
                if (p.Name == player.GetData<string>("SELECTPROD"))
                {
                    if (p.Ordered)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast dieses Produkt bereits bestellt", 3000);
                        OpenBizProductsMenu(player);
                        return;
                    }

                    if (biz.Type >= 2 && biz.Type <= 5)
                    {
                        if (amount > 3)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Geben Sie einen Wert von 1 bis 3 an", 3000);
                            OpenBizProductsMenu(player);
                            return;
                        }
                    }
                    else if (biz.Type == 14)
                    {
                        if (amount < 1 || p.Lefts + amount > ProductsCapacity[p.Name])
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Geben Sie einen Wert von 1 ein {ProductsCapacity[p.Name] - p.Lefts}", 3000);
                            OpenBizProductsMenu(player);
                            return;
                        }
                    }
                    else
                    {
                        if (amount < 10 || p.Lefts + amount > ProductsCapacity[p.Name])
                        {
                            var text = "";
                            if (ProductsCapacity[p.Name] - p.Lefts < 10) text = "Sie haben genügend Waren auf Lager";
                            else text = $"Geben Sie 10 bis {ProductsCapacity[p.Name] - p.Lefts}";

                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, text, 3000);
                            OpenBizProductsMenu(player);
                            return;
                        }
                    }

                    var price = (p.Name == "Katuschen") ? 4 : ProductsOrderPrice[p.Name];
                    if (!Bank.Change(Main.Players[player].Bank, -amount * price))
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Zu wenig Guthaben auf dem Konto", 3000);
                        return;
                    }
                    GameLog.Money($"bank({Main.Players[player].Bank})", $"server", amount * price, "bizOrder");
                    var order = new Order(p.Name, amount);
                    p.Ordered = true;

                    var random = new Random();
                    do
                    {
                        order.UID = random.Next(000000, 999999);
                    } while (BusinessManager.Orders.ContainsKey(order.UID));
                    BusinessManager.Orders.Add(order.UID, biz.ID);

                    biz.Orders.Add(order);

                    Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du hast {amount} {p.Name} bestellt. Ihre Bestellnummer lautet: №{order.UID}", 3000);
                    player.SendChatMessage($"Ihre Bestellnummer: {order.UID}");
                    return;
                }
            }
        }

        public static void buyBusinessCommand(Player player)
        {
            if (!player.HasData("BIZ_ID") || player.GetData<int>("BIZ_ID") == -1)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie sollten in der Nähe des Geschäfts sein", 3000);
                return;
            }
            int id = player.GetData<int>("BIZ_ID");
            Business biz = BusinessManager.BizList[id];
            if (Main.Players[player].BizIDs.Count >= Group.GroupMaxBusinesses[Main.Accounts[player].VipLvl])
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du kannst nicht mehr kaufen {Group.GroupMaxBusinesses[Main.Accounts[player].VipLvl]} Geschäft", 3000);
                return;
            }
            if (biz.Owner == "Staat")
            {
                if (!MoneySystem.Wallet.Change(player, -biz.SellPrice))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie haben nicht genug Geld", 3000);
                    return;
                }
                GameLog.Money($"player({Main.Players[player].UUID})", $"server", biz.SellPrice, $"buyBiz({biz.ID})");
                Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Herzlichen Glückwunsch! Du hast ein {BusinessManager.BusinessTypeNames[biz.Type]} gekauft. Vergiss nicht, die Steuer für dein Business am Geldautomaten zu bezahlen!", 3000);
                biz.Owner = player.Name.ToString();
            }
            else if (biz.Owner == player.Name.ToString())
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Dieses Geschäft gehört dir nun!", 3000);
                return;
            }
            else if (biz.Owner != player.Name.ToString())
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Dieses Geschäft gehört einem anderen Spieler!", 3000);
                return;
            }

            biz.UpdateLabel();
            foreach (var p in biz.Products)
                p.Lefts = 0;
            var newOrders = new List<Order>();
            foreach (var o in biz.Orders)
            {
                if (o.Taked) newOrders.Add(o);
                else Orders.Remove(o.UID);
            }
            biz.Orders = newOrders;

            Main.Players[player].BizIDs.Add(id);
            var tax = Convert.ToInt32(biz.SellPrice / 10000);
            MoneySystem.Bank.Accounts[biz.BankID].Balance = tax * 2;

            var split = biz.Owner.Split('_');
            MySQL.Query($"UPDATE characters SET biz='{JsonConvert.SerializeObject(Main.Players[player].BizIDs)}' WHERE firstname='{split[0]}' AND lastname='{split[1]}'");
            MySQL.Query($"UPDATE businesses SET owner='{biz.Owner}' WHERE id='{biz.ID}'");
        }

        public static void createBusinessCommand(Player player, int govPrice, int type)
        {
            if (!Group.CanUseCmd(player, "createbusiness")) return;
            var pos = player.Position;
            pos.Z -= 1.12F;
            string productlist = "";
            List<Product> products_list = BusinessManager.fillProductList(type);
            productlist = JsonConvert.SerializeObject(products_list);
            lastBizID++;

            var bankID = MoneySystem.Bank.Create("", 3, 1000);
            MySQL.Query($"INSERT INTO businesses (id, owner, sellprice, type, products, enterpoint, unloadpoint, money, mafia, orders) " +
                $"VALUES ({lastBizID}, 'Staat', {govPrice}, {type}, '{productlist}', '{JsonConvert.SerializeObject(pos)}', '{JsonConvert.SerializeObject(new Vector3())}', {bankID}, -1, '{JsonConvert.SerializeObject(new List<Order>())}')");

            Business biz = new Business(lastBizID, "Staat", govPrice, type, products_list, pos, new Vector3(), bankID, -1, new List<Order>());
            biz.UpdateLabel();
            BizList.Add(lastBizID, biz);

            if (type == 6)
            {
                MySQL.Query($"INSERT INTO `weapons`(`id`,`lastserial`) VALUES({biz.ID},0)");
            }
            Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Sie haben ein Unternehmen gegründet {BusinessManager.BusinessTypeNames[type]}", 3000);
        }

        public static void createBusinessUnloadpoint(Player player, int bizid)
        {
            if (!Group.CanUseCmd(player, "createunloadpoint")) return;
            var pos = player.Position;
            BizList[bizid].UnloadPoint = pos;
            MySQL.Query($"UPDATE businesses SET unloadpoint='{JsonConvert.SerializeObject(pos)}' WHERE id={bizid}");
            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Entladestelle für Unternehmen erfolgreich erstellt ID: {bizid}", 3000);
        }

        public static void deleteBusinessCommand(Player player, int id)
        {
            if (!Group.CanUseCmd(player, "deletebusiness")) return;
            MySQL.Query($"DELETE FROM businesses WHERE id={id}");
            Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Sie haben das Unternehmen gelöscht", 3000);
            Business biz = BusinessManager.BizList.FirstOrDefault(b => b.Value.ID == id).Value;

            if (biz.Type == 6)
            {
                MySQL.Query($"DELETE FROM `weapons` WHERE id={id}");
            }

            var owner = NAPI.Player.GetPlayerFromName(biz.Owner);
            if (owner == null)
            {
                var split = biz.Owner.Split('_');
                var data = MySQL.QueryRead($"SELECT biz FROM characters WHERE firstname='{split[0]}' AND lastname='{split[1]}'");
                List<int> ownerBizs = new List<int>();
                foreach (DataRow Row in data.Rows)
                    ownerBizs = JsonConvert.DeserializeObject<List<int>>(Row["biz"].ToString());
                ownerBizs.Remove(biz.ID);

                MySQL.Query($"UPDATE characters SET biz='{JsonConvert.SerializeObject(ownerBizs)}' WHERE firstname='{split[0]}' AND lastname='{split[1]}'");
            }
            else
            {
                Main.Players[owner].BizIDs.Remove(id);
                MoneySystem.Wallet.Change(owner, biz.SellPrice);
            }
            biz.Destroy();
            BizList.Remove(biz.ID);
        }

        public static void sellBusinessCommand(Player player, Player target, int price)
        {
            if (!Main.Players.ContainsKey(player) || !Main.Players.ContainsKey(target)) return;

            if (player.Position.DistanceTo(target.Position) > 2)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler ist zu weit weg", 3000);
                return;
            }

            if (Main.Players[player].BizIDs.Count == 0)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast kein Geschäft", 3000);
                return;
            }

            if (Main.Players[target].BizIDs.Count >= Group.GroupMaxBusinesses[Main.Accounts[target].VipLvl])
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler hat ein Maximum an Unternehmen gekauft", 3000);
                return;
            }

            var biz = BizList[Main.Players[player].BizIDs[0]];
            if (price < biz.SellPrice / 2 || price > biz.SellPrice * 3)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.JobSms, $"Du kannst ein Unternehmen nicht für diesen Preis verkaufen. Geben Sie einen Preis ein von {biz.SellPrice / 2}$ vor {biz.SellPrice * 3}$", 3000);
                return;
            }

            if (Main.Players[target].Money < price)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler hat nicht genug Geld", 3000);
                return;
            }

            Trigger.ClientEvent(target, "openDialog", "BUSINESS_BUY", $"{player.Name} angeboten, dich zu kaufen {BusinessTypeNames[biz.Type]} für ${price}");
            target.SetData("SELLER", player);
            target.SetData("SELLPRICE", price);
            target.SetData("SELLBIZID", biz.ID);

            Notify.Send(player, NotifyType.Info, NotifyPosition.JobSms, $"Du hast dem Spieler angeboten ({target.Value}) um Ihr Unternehmen zu kaufen für {price}$", 3000);
        }

        public static void acceptBuyBusiness(Player player)
        {
            Player seller = player.GetData<Player>("SELLER");
            if (!Main.Players.ContainsKey(seller) || !Main.Players.ContainsKey(player)) return;

            if (player.Position.DistanceTo(seller.Position) > 2)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler ist zu weit weg", 3000);
                return;
            }

            var price = player.GetData<int>("SELLPRICE");
            if (Main.Players[player].Money < price)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast nicht genug Geld", 3000);
                return;
            }

            Business biz = BizList[player.GetData<int>("SELLBIZID")];
            if (!Main.Players[seller].BizIDs.Contains(biz.ID))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Das Geschäft gehört nicht mehr dem Spieler", 3000);
                return;
            }

            if (Main.Players[player].BizIDs.Count >= Group.GroupMaxBusinesses[Main.Accounts[player].VipLvl])
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie haben die maximale Anzahl von Unternehmen", 3000);
                return;
            }

            Main.Players[player].BizIDs.Add(biz.ID);
            Main.Players[seller].BizIDs.Remove(biz.ID);

            biz.Owner = player.Name.ToString();
            var split1 = seller.Name.Split('_');
            var split2 = player.Name.Split('_');
            MySQL.Query($"UPDATE characters SET biz='{JsonConvert.SerializeObject(Main.Players[seller].BizIDs)}' WHERE firstname='{split1[0]}' AND lastname='{split1[1]}'");
            MySQL.Query($"UPDATE characters SET biz='{JsonConvert.SerializeObject(Main.Players[player].BizIDs)}' WHERE firstname='{split2[0]}' AND lastname='{split2[1]}'");
            MySQL.Query($"UPDATE businesses SET owner='{biz.Owner}' WHERE id='{biz.ID}'");
            biz.UpdateLabel();

            MoneySystem.Wallet.Change(player, -price);
            MoneySystem.Wallet.Change(seller, price);
            GameLog.Money($"player({Main.Players[player].UUID})", $"player({Main.Players[seller].UUID})", price, $"buyBiz({biz.ID})");

            Notify.Send(player, NotifyType.Info, NotifyPosition.JobSms, $"Du hast bei {seller.Name.Replace('_', ' ')} {BusinessTypeNames[biz.Type]} für {price}$", 3000);
            Notify.Send(seller, NotifyType.Info, NotifyPosition.JobSms, $"{player.Name.Replace('_', ' ')} Ich habe es von dir gekauft {BusinessTypeNames[biz.Type]} für {price}$", 3000);
        }

        #region Menus
        #region manage biz
        public static void OpenBizListMenu(Player player)
        {
            if (Main.Players[player].BizIDs.Count == 0)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast kein Geschäft", 3000);
                return;
            }

            Menu menu = new Menu("bizlist", false, false);
            menu.Callback = callback_bizlist;

            Menu.Item menuItem = new Menu.Item("header", Menu.MenuItem.Header);
            menuItem.Text = "Ihr Geschäft";
            menu.Add(menuItem);

            foreach (var id in Main.Players[player].BizIDs)
            {
                menuItem = new Menu.Item(id.ToString(), Menu.MenuItem.Button);
                menuItem.Text = BusinessManager.BusinessTypeNames[BusinessManager.BizList[id].Type];
                menu.Add(menuItem);
            }

            menuItem = new Menu.Item("close", Menu.MenuItem.Button);
            menuItem.Text = "Schliessen";
            menu.Add(menuItem);

            menu.Open(player);
        }
        private static void callback_bizlist(Player player, Menu menu, Menu.Item item, string eventName, dynamic data)
        {
            switch (item.ID)
            {
                case "close":
                    MenuManager.Close(player);
                    return;
                default:
                    OpenBizManageMenu(player, Convert.ToInt32(item.ID));
                    player.SetData("SELECTEDBIZ", Convert.ToInt32(item.ID));
                    return;
            }
        }

        public static void OpenBizManageMenu(Player player, int id)
        {
            if (!Main.Players[player].BizIDs.Contains(id))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie besitzen dieses Geschäft nicht mehr", 3000);
                return;
            }

            Menu menu = new Menu("bizmanage", false, false);
            menu.Callback = callback_bizmanage;

            Menu.Item menuItem = new Menu.Item("header", Menu.MenuItem.Header);
            menuItem.Text = "Geschäftsführung";
            menu.Add(menuItem);

            menuItem = new Menu.Item("products", Menu.MenuItem.Button);
            menuItem.Text = "Produkte";
            menu.Add(menuItem);

            Business biz = BizList[id];
            menuItem = new Menu.Item("tax", Menu.MenuItem.Card);
            menuItem.Text = $"Steuer: {Convert.ToInt32(biz.SellPrice / 100 * 0.013)}$/h";
            menu.Add(menuItem);

            menuItem = new Menu.Item("money", Menu.MenuItem.Card);
            menuItem.Text = $"Geschäftskonto: {MoneySystem.Bank.Accounts[biz.BankID].Balance}$";
            menu.Add(menuItem);

            menuItem = new Menu.Item("sell", Menu.MenuItem.Button);
            menuItem.Text = "Verkaufe das Geschäft";
            menu.Add(menuItem);

            menuItem = new Menu.Item("close", Menu.MenuItem.Button);
            menuItem.Text = "Schliessen";
            menu.Add(menuItem);

            menu.Open(player);
        }
        private static void callback_bizmanage(Player client, Menu menu, Menu.Item item, string eventName, dynamic data)
        {
            switch (item.ID)
            {
                case "products":
                    MenuManager.Close(client);
                    OpenBizProductsMenu(client);
                    return;
                case "sell":
                    MenuManager.Close(client);
                    OpenBizSellMenu(client);
                    return;
                case "close":
                    MenuManager.Close(client);
                    return;
            }
        }

        public static void OpenBizSellMenu(Player player)
        {
            Menu menu = new Menu("bizsell", false, false);
            menu.Callback = callback_bizsell;

            Menu.Item menuItem = new Menu.Item("header", Menu.MenuItem.Header);
            menuItem.Text = "Geschäft Verkaufen";
            menu.Add(menuItem);

            var bizID = player.GetData<int>("SELECTEDBIZ");
            Business biz = BizList[bizID];
            var price = biz.SellPrice / 100 * 70;
            menuItem = new Menu.Item("govsell", Menu.MenuItem.Button);
            menuItem.Text = $"Verkauf an den Staat (${price})";
            menu.Add(menuItem);

            menuItem = new Menu.Item("back", Menu.MenuItem.Button);
            menuItem.Text = "Zurück";
            menu.Add(menuItem);

            menu.Open(player);
        }
        private static void callback_bizsell(Player client, Menu menu, Menu.Item item, string eventName, dynamic data)
        {
            if (!client.HasData("SELECTEDBIZ") || !Main.Players[client].BizIDs.Contains(client.GetData<int>("SELECTEDBIZ")))
            {
                MenuManager.Close(client);
                return;
            }

            var bizID = client.GetData<int>("SELECTEDBIZ");
            Business biz = BizList[bizID];
            switch (item.ID)
            {
                case "govsell":
                    var price = biz.SellPrice / 100 * 70;
                    MoneySystem.Wallet.Change(client, price);
                    GameLog.Money($"server", $"player({Main.Players[client].UUID})", price, $"sellBiz({biz.ID})");

                    Main.Players[client].BizIDs.Remove(bizID);
                    biz.Owner = "Staat";
                    biz.UpdateLabel();

                    Notify.Send(client, NotifyType.Success, NotifyPosition.MapUp, $"Du hast das Geschäft für {price}$ an den Staat verkauft!", 3000);
                    MenuManager.Close(client);
                    return;
                case "back":
                    MenuManager.Close(client);
                    OpenBizManageMenu(client, bizID);
                    return;
            }
        }

        public static void OpenBizProductsMenu(Player player)
        {
            if (!player.HasData("SELECTEDBIZ") || !Main.Players[player].BizIDs.Contains(player.GetData<int>("SELECTEDBIZ")))
            {
                MenuManager.Close(player);
                return;
            }

            Menu menu = new Menu("bizproducts", false, false);
            menu.Callback = callback_bizprod;

            Menu.Item menuItem = new Menu.Item("header", Menu.MenuItem.Header);
            menuItem.Text = "Produkte";
            menu.Add(menuItem);

            var bizID = player.GetData<int>("SELECTEDBIZ");

            Business biz = BizList[bizID];
            foreach (var p in biz.Products)
            {
                menuItem = new Menu.Item(p.Name, Menu.MenuItem.Button);
                menuItem.Text = p.Name;
                menu.Add(menuItem);
            }

            menuItem = new Menu.Item("back", Menu.MenuItem.Button);
            menuItem.Text = "Zurück";
            menu.Add(menuItem);

            menu.Open(player);
        }
        private static void callback_bizprod(Player client, Menu menu, Menu.Item item, string eventName, dynamic data)
        {
            switch (item.ID)
            {
                case "back":
                    MenuManager.Close(client);
                    OpenBizManageMenu(client, client.GetData<int>("SELECTEDBIZ"));
                    return;
                default:
                    MenuManager.Close(client);
                    OpenBizSettingMenu(client, item.ID);
                    return;
            }
        }

        public static void OpenBizSettingMenu(Player player, string product)
        {
            if (!player.HasData("SELECTEDBIZ") || !Main.Players[player].BizIDs.Contains(player.GetData<int>("SELECTEDBIZ")))
            {
                MenuManager.Close(player);
                return;
            }

            Menu menu = new Menu("bizsetting", false, false);
            menu.Callback = callback_bizsetting;

            Menu.Item menuItem = new Menu.Item("header", Menu.MenuItem.Header);
            menuItem.Text = product;
            menu.Add(menuItem);

            var bizID = player.GetData<int>("SELECTEDBIZ");
            Business biz = BizList[bizID];

            foreach (var p in biz.Products)
                if (p.Name == product)
                {
                    string ch = (biz.Type == 7 || biz.Type == 11 || biz.Type == 12 || product == "Tattoos" || product == "Perücken" || product == "Katuschen") ? "%" : "$";
                    menuItem = new Menu.Item("price", Menu.MenuItem.Card);
                    menuItem.Text = $"Aktueller Preis: {p.Price}$";   //$"Aktueller Preis: {p.Price}{ch}";
                    menu.Add(menuItem);

                    menuItem = new Menu.Item("lefts", Menu.MenuItem.Card);
                    menuItem.Text = $"Menge auf Lager: {p.Lefts}";
                    menu.Add(menuItem);

                    menuItem = new Menu.Item("capacity", Menu.MenuItem.Card);
                    menuItem.Text = $"Lagerkapazität: {ProductsCapacity[p.Name]}";
                    menu.Add(menuItem);

                    menuItem = new Menu.Item("setprice", Menu.MenuItem.Button);
                    menuItem.Text = "Den Preis festlegen";
                    menu.Add(menuItem);

                    var price = (product == "Katuschen") ? 4 : ProductsOrderPrice[product];
                    menuItem = new Menu.Item("order", Menu.MenuItem.Button);
                    menuItem.Text = $"Bestellung: {price}$ pro stück";
                    menu.Add(menuItem);

                    menuItem = new Menu.Item("cancel", Menu.MenuItem.Button);
                    menuItem.Text = "Bestellung stornieren";
                    menu.Add(menuItem);

                    menuItem = new Menu.Item("back", Menu.MenuItem.Button);
                    menuItem.Text = "Zurück";
                    menu.Add(menuItem);

                    player.SetData("SELECTPROD", product);
                    menu.Open(player);
                    return;
                }
        }
        private static void callback_bizsetting(Player client, Menu menu, Menu.Item item, string eventName, dynamic data)
        {
            var bizID = client.GetData<int>("SELECTEDBIZ");
            switch (item.ID)
            {
                case "setprice":
                    MenuManager.Close(client);
                    if (client.GetData<string>("SELECTPROD") == "Materialien")
                    {
                        Notify.Send(client, NotifyType.Error, NotifyPosition.MapUp, $"Es ist unmöglich, einen Preis für dieses Produkt festzulegen", 3000);
                        return;
                    }
                    Main.OpenInputMenu(client, "Einen neuen Preis eingeben:", "biznewprice");
                    return;
                case "order":
                    MenuManager.Close(client);
                    if (client.GetData<string>("SELECTPROD") == "Tattoos" || client.GetData<string>("SELECTPROD") == "Perücken")
                    {
                        Notify.Send(client, NotifyType.Error, NotifyPosition.MapUp, $"Wenn Sie den Verkauf von Dienstleistungen wieder aufnehmen möchten, bestellen Sie Materialien", 3000);
                        return;
                    }
                    Main.OpenInputMenu(client, "Menge eingeben:", "bizorder");
                    return;
                case "cancel":
                    Business biz = BizList[bizID];
                    var prodName = client.GetData<string>("SELECTPROD");

                    foreach (var p in biz.Products)
                    {
                        if (p.Name != prodName) continue;
                        if (p.Ordered)
                        {
                            var order = biz.Orders.FirstOrDefault(o => o.Name == prodName);
                            if (order == null)
                            {
                                p.Ordered = false;
                                return;
                            }
                            if (order.Taked)
                            {
                                Notify.Send(client, NotifyType.Error, NotifyPosition.MapUp, $"Sie können eine Bestellung nicht stornieren, solange sie geliefert wird", 3000);
                                return;
                            }
                            biz.Orders.Remove(order);
                            p.Ordered = false;

                            MoneySystem.Wallet.Change(client, order.Amount * ProductsOrderPrice[prodName]);
                            GameLog.Money($"server", $"player({Main.Players[client].UUID})", order.Amount * ProductsOrderPrice[prodName], $"orderCancel");
                            Notify.Send(client, NotifyType.Info, NotifyPosition.MapUp, $"Sie haben den Auftrag storniert {prodName}", 3000);
                        }
                        else Notify.Send(client, NotifyType.Error, NotifyPosition.MapUp, $"Sie haben diesen Artikel nicht bestellt", 3000);
                        return;
                    }
                    return;
                case "back":
                    MenuManager.Close(client);
                    OpenBizManageMenu(client, bizID);
                    return;
            }
        }
        #endregion

        public static void OpenBizShopMenu(Player player)
        {
            Business biz = BizList[player.GetData<int>("BIZ_ID")];
            List<List<string>> items = new List<List<string>>();

            foreach (var p in biz.Products)
            {
                List<string> item = new List<string>();
                item.Add(p.Name);
                item.Add($"{p.Price}$");
                items.Add(item);
            }
            string json = JsonConvert.SerializeObject(items);
            Trigger.ClientEvent(player, "shop", json);
        }
        [RemoteEvent("shop")]
        public static void Event_ShopCallback(Player client, int index)
        {
            try
            {
                if (!Main.Players.ContainsKey(client)) return;
                if (client.GetData<int>("BIZ_ID") == -1) return;
                Business biz = BizList[client.GetData<int>("BIZ_ID")];

                var prod = biz.Products[index];
                if (Main.Players[client].Money < prod.Price)
                {
                    Notify.Send(client, NotifyType.Error, NotifyPosition.MapUp, "Unzureichende Mittel", 3000);
                    return;
                }

                if (prod.Name == "SIM-Karte")
                {
                    if (!takeProd(biz.ID, 1, prod.Name, prod.Price))
                    {
                        Notify.Send(client, NotifyType.Error, NotifyPosition.MapUp, "Das Produkt ist nicht auf Lager!", 3000);
                        return;
                    }

                    if (Main.Players[client].Sim != -1) Main.SimCards.Remove(Main.Players[client].Sim);
                    Main.Players[client].Sim = Main.GenerateSimcard(Main.Players[client].UUID);
                    Notify.Send(client, NotifyType.Success, NotifyPosition.MapUp, $"Sie haben eine SIM-Karte mit einer Nummer gekauft {Main.Players[client].Sim}", 3000);
                    GUI.Dashboard.sendStats(client);
                }
                else
                {
                    var type = GetBuyingItemType(prod.Name);
                    if (type != -1)
                    {
                        var tryAdd = nInventory.TryAdd(client, new nItem((ItemType)type));
                        if (tryAdd == -1 || tryAdd > 0)
                        {
                            Notify.Send(client, NotifyType.Error, NotifyPosition.MapUp, $"Ihr Inventar kann nicht mehr gespeichert werden {prod.Name}", 3000);
                            return;
                        }
                        else
                        {
                            if (!takeProd(biz.ID, 1, prod.Name, prod.Price))
                            {
                                Notify.Send(client, NotifyType.Error, NotifyPosition.MapUp, "Das Produkt ist nicht auf Lager!", 3000);
                                return;
                            }
                            nItem item = ((ItemType)type == ItemType.KeyRing) ? new nItem(ItemType.KeyRing, 1, "") : new nItem((ItemType)type);
                            nInventory.Add(client, item);
                        }
                        Notify.Send(client, NotifyType.Success, NotifyPosition.MapUp, $"Du hast einen {prod.Name} gekauft", 3000);
                    }
                }
                MoneySystem.Wallet.Change(client, -prod.Price);
                GameLog.Money($"player({Main.Players[client].UUID})", $"biz({biz.ID})", prod.Price, $"buyShop");
            }
            catch (Exception e) { Log.Write($"BuyShop: {e.ToString()}\n{e.StackTrace}", nLog.Type.Error); }
        }

        public static void OpenPetrolMenu(Player player)
        {
            try
            {
                Business biz = BizList[player.GetData<int>("BIZ_ID")];
                Product prod = biz.Products[0];

                Trigger.ClientEvent(player, "openPetrol");
                Notify.Send(player, NotifyType.Info, NotifyPosition.JobSms, $"Preis pro Liter: {prod.Price}$", 7000);
            }
            catch (Exception e) { Log.Write($"Petrol: {e.ToString()}\n{e.StackTrace}", nLog.Type.Error); }
        }
        private static void callback_petrol(Player client, Menu menu, Menu.Item item, string eventName, dynamic data)
        {
            switch (item.ID)
            {
                case "fill":
                    MenuManager.Close(client);
                    Main.OpenInputMenu(client, "Geben Sie die Anzahl der Liter ein:", "fillcar");
                    return;
                case "close":
                    MenuManager.Close(client);
                    return;
            }
        }

        public static void OpenGunShopMenu(Player player)
        {
            List<List<int>> prices = new List<List<int>>();

            Business biz = BizList[player.GetData<int>("GUNSHOP")];
            for (int i = 0; i < 3; i++)
            {
                List<int> p = new List<int>();
                foreach (var g in biz.Products)
                {
                    if (gunsCat[i].Contains(g.Name))
                        p.Add(g.Price);
                }
                prices.Add(p);
            }

            var ammoPrice = biz.Products.FirstOrDefault(p => p.Name == "Katuschen").Price;
            prices.Add(new List<int>());
            foreach (var ammo in AmmoPrices)
                prices[3].Add(Convert.ToInt32(ammo / 100.0 * ammoPrice));

            string json = JsonConvert.SerializeObject(prices);
            //Log.Write(json, nLog.Type.Debug);
            Log.Debug(json);
            Trigger.ClientEvent(player, "openWShop", biz.ID, json);
        }

        [RemoteEvent("wshopammo")]
        public static void Event_WShopAmmo(Player client, string text1, string text2)
        {
            try
            {
                var category = Convert.ToInt32(text1.Replace("wbuyslider", null));
                var needMoney = Convert.ToInt32(text2.Trim('$'));
                var ammo = needMoney / AmmoPrices[category];

                var bizid = client.GetData<int>("GUNSHOP");
                if (!Main.Players[client].Licenses[6])
                {
                    Notify.Send(client, NotifyType.Error, NotifyPosition.MapUp, $"Sie haben keinen Waffenschein", 3000);
                    return;
                }

                if (ammo == 0)
                {
                    Notify.Send(client, NotifyType.Error, NotifyPosition.MapUp, $"Sie haben die Katuschennummer nicht angegeben", 3000);
                    return;
                }

                var tryAdd = nInventory.TryAdd(client, new nItem(AmmoTypes[category], ammo));
                if (tryAdd == -1 || tryAdd > 0)
                {
                    Notify.Send(client, NotifyType.Error, NotifyPosition.MapUp, $"Nicht genügend Platz im Inventar", 3000);
                    return;
                }

                Business biz = BizList[bizid];
                var prod = biz.Products.FirstOrDefault(p => p.Name == "Katuschen");
                var totalPrice = ammo * Convert.ToInt32(AmmoPrices[category] / 100.0 * prod.Price);

                if (Main.Players[client].Money < totalPrice)
                {
                    Notify.Send(client, NotifyType.Error, NotifyPosition.MapUp, $"Unzureichende Mittel", 3000);
                    return;
                }

                if (!takeProd(bizid, Convert.ToInt32(AmmoPrices[category] / 10.0 * ammo), prod.Name, totalPrice))
                {
                    Notify.Send(client, NotifyType.Error, NotifyPosition.MapUp, $"Das Produkt ist nicht auf Lager!", 3000);
                    return;
                }

                MoneySystem.Wallet.Change(client, -totalPrice);
                GameLog.Money($"player({Main.Players[client].UUID})", $"biz({biz.ID})", totalPrice, $"buyWShop(ammo)");
                nInventory.Add(client, new nItem(AmmoTypes[category], ammo));
                Notify.Send(client, NotifyType.Success, NotifyPosition.MapUp, $"Du hast {nInventory.ItemsNames[(int)AmmoTypes[category]]} x{ammo} Für {totalPrice}$", 3000);
                return;
            }
            catch (Exception e) { Log.Write("BuyWeapons: " + e.Message, nLog.Type.Error); }
        }
        private static List<int> AmmoPrices = new List<int>()
        {
            15, // pistol 
            30, // smg 
          //  40, // rifles 
          //  500, // sniperrifles 
            60, // shotguns 
        };
        private static List<ItemType> AmmoTypes = new List<ItemType>()
        {
            ItemType.PistolAmmo, // pistol
            ItemType.SMGAmmo, // smg
          //  ItemType.RiflesAmmo, // rifles
         //   ItemType.SniperAmmo, // sniperrifles
            ItemType.ShotgunsAmmo, // shotguns
        };
        [RemoteEvent("wshop")]
        public static void Event_WShop(Player client, int cat, int index)
        {
            try
            {
                var prodName = gunsCat[cat][index];
                var bizid = client.GetData<int>("GUNSHOP");
                if (!Main.Players[client].Licenses[6])
                {
                    Notify.Send(client, NotifyType.Error, NotifyPosition.MapUp, $"Sie haben keinen Waffenschein", 3000);
                    return;
                }
                Business biz = BizList[bizid];
                var prod = biz.Products.FirstOrDefault(p => p.Name == prodName);

                if (Main.Players[client].Money < prod.Price)
                {
                    Notify.Send(client, NotifyType.Error, NotifyPosition.MapUp, $"Unzureichende Mittel", 3000);
                    return;
                }

                ItemType wType = (ItemType)Enum.Parse(typeof(ItemType), prod.Name);

                var tryAdd = nInventory.TryAdd(client, new nItem(wType));
                if (tryAdd == -1 || tryAdd > 0)
                {
                    Notify.Send(client, NotifyType.Error, NotifyPosition.MapUp, $"Nicht genügend Platz im Inventar", 3000);
                    return;
                }

                if (!takeProd(bizid, 1, prod.Name, prod.Price))
                {
                    Notify.Send(client, NotifyType.Error, NotifyPosition.MapUp, $"Das Produkt ist nicht auf Lager!", 3000);
                    return;
                }

                MoneySystem.Wallet.Change(client, -prod.Price);
                GameLog.Money($"player({Main.Players[client].UUID})", $"biz({biz.ID})", prod.Price, $"buyWShop({prod.Name})");
                Weapons.GiveWeapon(client, wType, Weapons.GetSerial(false, biz.ID));

                Notify.Send(client, NotifyType.Success, NotifyPosition.MapUp, $"Du hast {prod.Name} für {prod.Price}$", 3000);
                return;
            }
            catch (Exception e) { Log.Write("BuyWeapons: " + e.Message, nLog.Type.Error); }
        }
        private static List<List<string>> gunsCat = new List<List<string>>()
        {
            new List<string>()
            {
                "Pistol",
                "CombatPistol",
                "Revolver",
                "HeavyPistol",
            },
            new List<string>()
            {
                "BullpupShotgun",
            },
            new List<string>()
            {
                "CombatPDW",
                "MachinePistol",
            },
        };
        #endregion

        public static void changeOwner(string oldName, string newName)
        {
            List<int> toChange = new List<int>();
            lock (BizList)
            {
                foreach (KeyValuePair<int, Business> biz in BizList)
                {
                    if (biz.Value.Owner != oldName) continue;
                    Log.Write($"The biz was found! [{biz.Key}]");
                    toChange.Add(biz.Key);
                }
                foreach (int id in toChange)
                {
                    BizList[id].Owner = newName;
                    BizList[id].UpdateLabel();
                    BizList[id].Save();
                }
            }
        }
    }

    public class Order
    {
        public Order(string name, int amount, bool taked = false)
        {
            Name = name;
            Amount = amount;
            Taked = taked;
        }

        public string Name { get; set; }
        public int Amount { get; set; }
        [JsonIgnore]
        public bool Taked { get; set; }
        [JsonIgnore]
        public int UID { get; set; }
    }

    public class Product
    {
        public Product(int price, int left, int autosell, string name, bool ordered)
        {
            Price = price;
            Lefts = left;
            Autosell = autosell;
            Name = name;
            Ordered = ordered;
        }

        public int Price { get; set; }
        public int Lefts { get; set; }
        public int Autosell { get; set; }
        public string Name { get; set; }
        public bool Ordered { get; set; }
    }

    public class Business
    {
        public int ID { get; set; }
        public string Owner { get; set; }
        public int SellPrice { get; set; }
        public int Type { get; set; }
        public string Address { get; set; }
        public List<Product> Products { get; set; }
        public int BankID { get; set; }
        public Vector3 EnterPoint { get; set; }
        public Vector3 UnloadPoint { get; set; }
        public int Mafia { get; set; }

        public List<Order> Orders { get; set; }

        [JsonIgnore]
        private Blip blip = null;
        [JsonIgnore]
        private Marker marker = null;
        [JsonIgnore]
        private TextLabel label = null;
        [JsonIgnore]
        private TextLabel mafiaLabel = null;
        [JsonIgnore]
        private ColShape shape = null;
        [JsonIgnore]
        private ColShape truckerShape = null;

        public Business(int id, string owner, int sellPrice, int type, List<Product> products, Vector3 enterPoint, Vector3 unloadPoint, int bankID, int mafia, List<Order> orders)
        {
            ID = id;
            Owner = owner;
            SellPrice = sellPrice;
            Type = type;
            Products = products;
            EnterPoint = enterPoint;
            UnloadPoint = unloadPoint;
            BankID = bankID;
            Mafia = mafia;
            Orders = orders;

            var random = new Random();
            foreach (var o in orders)
            {
                do
                {
                    o.UID = random.Next(000000, 999999);
                } while (BusinessManager.Orders.ContainsKey(o.UID));
                BusinessManager.Orders.Add(o.UID, ID);
            }

            truckerShape = NAPI.ColShape.CreateCylinderColShape(UnloadPoint - new Vector3(0, 0, 1), 8, 10, NAPI.GlobalDimension);
            truckerShape.SetData("BIZID", ID);
            truckerShape.OnEntityEnterColShape += Jobs.Truckers.onEntityEnterDropTrailer;

            float range;
            if (Type == 1) range = 20f;
            else if (Type == 12) range = 5f;
            else range = 1f;
            shape = NAPI.ColShape.CreateCylinderColShape(EnterPoint, range, 3, 0);

            shape.OnEntityEnterColShape += (s, entity) =>
            {
                try
                {
                    NAPI.Data.SetEntityData(entity, "INTERACTIONCHECK", 30);
                    NAPI.Data.SetEntityData(entity, "BIZ_ID", ID);
                }
                catch (Exception e) { Console.WriteLine("shape.OnEntityEnterColshape: " + e.Message); }
            };
            shape.OnEntityExitColShape += (s, entity) =>
            {
                try
                {
                    NAPI.Data.SetEntityData(entity, "INTERACTIONCHECK", 0);
                    NAPI.Data.SetEntityData(entity, "BIZ_ID", -1);
                }
                catch (Exception e) { Console.WriteLine("shape.OnEntityEnterColshape: " + e.Message); }
            };

            blip = NAPI.Blip.CreateBlip(Convert.ToUInt32(BusinessManager.BlipByType[Type]), EnterPoint, 0.8f, Convert.ToByte(BusinessManager.BlipColorByType[Type]), Main.StringToU16(BusinessManager.BusinessTypeNames[Type]), 255, 0, true);
            var textrange = (Type == 1) ? 5F : 20F;
            label = NAPI.TextLabel.CreateTextLabel(Main.StringToU16("Business"), new Vector3(EnterPoint.X, EnterPoint.Y, EnterPoint.Z + 1.5), textrange, 0.5F, 0, new Color(255, 255, 255), true, 0);
            mafiaLabel = NAPI.TextLabel.CreateTextLabel(Main.StringToU16("Mafia: Gehört keinem"), new Vector3(EnterPoint.X, EnterPoint.Y, EnterPoint.Z + 2), 5F, 0.5F, 0, new Color(255, 255, 255), true, 0);
            UpdateLabel();
            if (Type != 1) marker = NAPI.Marker.CreateMarker(1, EnterPoint - new Vector3(0, 0, range - 0.3f), new Vector3(), new Vector3(), range, new Color(255, 255, 255, 220), false, 0);
        }

        public void UpdateLabel()
        {
            string text = $"~w~{BusinessManager.BusinessTypeNames[Type]}\n~g~Besitzer: ~w~{Owner}\n";
            if (Owner != "Staat") text += $"~g~ID: ~w~{ID}\n";
            else text += $"~g~Preis: {SellPrice}$\n~g~ID: ~w~{ID}\n";
            if (Type == 1)
            {
                text += $"~g~Preis für 1l Benzin: {Products[0].Price}$\n";
                text += "~g~Drück E\n";
            }
            label.Text = Main.StringToU16(text);

            if (Mafia != -1) mafiaLabel.Text = $"~g~Info: ~w~{Fractions.Manager.getName(Mafia)}";
            else mafiaLabel.Text = "~g~Info: ~w~Gehört keinem";
        }

        public void Destroy()
        {
            NAPI.Task.Run(() =>
            {
                try
                {
                    blip.Delete();
                    marker.Delete();
                    label.Delete();
                    shape.Delete();
                    truckerShape.Delete();
                }
                catch { }
            });
        }

        public void Save()
        {
            MySQL.Query($"UPDATE businesses SET owner='{this.Owner}',sellprice={this.SellPrice}," +
                    $"products='{JsonConvert.SerializeObject(this.Products)}',money={this.BankID},mafia={this.Mafia},orders='{JsonConvert.SerializeObject(this.Orders)}' WHERE id={this.ID}");
            MoneySystem.Bank.Save(this.BankID);
        }
    }

    public class BusinessTattoo
    {
        public List<int> Slots { get; set; }
        public string Name { get; set; }
        public string Dictionary { get; set; }
        public string MaleHash { get; set; }
        public string FemaleHash { get; set; }
        public int Price { get; set; }

        public BusinessTattoo(List<int> slots, string name, string dictionary, string malehash, string femalehash, int price)
        {
            Slots = slots;
            Name = name;
            Dictionary = dictionary;
            MaleHash = malehash;
            FemaleHash = femalehash;
            Price = price;
        }
    }
}
