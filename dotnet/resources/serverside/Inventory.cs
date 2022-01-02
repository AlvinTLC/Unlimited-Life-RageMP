using System;
using System.Collections.Generic;
using System.Text;

namespace UNL.SDK
{
    public enum ItemType
    {
        Mask = -1, // Маска
        Gloves = -3, // Перчатки
        Leg = -4, // Штанишки
        Bag = -5, // Рюкзачок
        Feet = -6, // Обуточки 
        Jewelry = -7, // Аксессуарчики всякие там
        Undershit = -8, // Рубашечки
        BodyArmor = -9, // Бронька
        Unknown = -10, // Вообще хер пойми что это
        Top = -11, // Верх
        Hat = -12, // Шляпы
        Glasses = -13, // Очочки
        Accessories = -14, // Часы/Браслеты

        Debug = 0,
        BagWithMoney = 12,// Сумка с деньгами
        Material = 13,    // Материалы
        Drugs = 14,       // Наркота
        BagWithDrill = 15,// Сумка с дрелью
        HealthKit = 1,    // Erste-Hilfe-Kit
        GasCan = 2,       // Канистра
        Chips = 3,       // Чипсы
        Beer = 4,         // Пиво
        Pizza = 5,        // Пицца
        Burger = 6,       // Бургер
        HotDog = 7,       // Хот-Дог
        Sandwich = 8,     // Сэндвич
        eCola = 9,        // Кока-Кола
        Sprunk = 10,      // Спрайт

        // forrest.js
        Apfel = 1010,
        Trauben = 1011,
        Wein = 1012,
        Holz = 1013,
        Orange = 1014,
        Orangensaft = 1015,
        Eisen = 1016,
        Metalbarren = 1017,
        Erdöl = 1018,
        Öl = 1019,
        Apfelsaft = 1020,

        // forrest2.js
        Kröten = 1021,
        Ephidrin = 1022,
        Marihuana = 1023,
        Joint = 1024,
        Hopfen = 1025,
        Schnaps = 1026,

        Zigarette = 32,
        Funk = 1028,
        Wasser = 34,
        Kaffee = 35,
        Donut = 37,
        Gummibärchen = 36,
        Rose = 1033,
        SchwarzeRose = 1034,
        ATMHackingCard = 1035,
        Kokablatt = 1036,
        Kokain = 1037,
        Aceton = 1038,
        Autobatterie = 1039,
        Lithium = 1040,
        Crystal = 1041,
        Juwel = 1042,
        Schinken = 1043,

        Lockpick = 11,    // Отмычка для замка
        ArmyLockpick = 16,// Военная отмычка
        Pocket = 17,      // Maske
        Cuffs = 18,       // Стяжки
        CarKey = 19,      // Ключи от личной машины
        Present = 40,     // Подарок
        KeyRing = 41,     // Связка ключей
        ItemBox = 42,

        /* Drinks */
        RusDrink1 = 20,
        RusDrink2 = 21,
        RusDrink3 = 22,

        YakDrink1 = 23,
        YakDrink2 = 24,
        YakDrink3 = 25,

        LcnDrink1 = 26,
        LcnDrink2 = 27,
        LcnDrink3 = 28,

        ArmDrink1 = 29,
        ArmDrink2 = 30,
        ArmDrink3 = 31,

        /* Weapons */
        /* Pistols */
        Pistol = 100,
        CombatPistol = 101,
        Pistol50 = 102,
        SNSPistol = 103,
        HeavyPistol = 104,
        VintagePistol = 105,
        MarksmanPistol = 106,
        Revolver = 107,
        APPistol = 108,
        FlareGun = 110,
        DoubleAction = 111,
        PistolMk2 = 112,
        SNSPistolMk2 = 113,
        RevolverMk2 = 114,
        /* SMG */
        MicroSMG = 115,
        MachinePistol = 116,
        SMG = 117,
        AssaultSMG = 118,
        CombatPDW = 119,
        MG = 120,
        CombatMG = 121,
        Gusenberg = 122,
        MiniSMG = 123,
        SMGMk2 = 124,
        CombatMGMk2 = 125,
        /* Rifles */
        AssaultRifle = 126,
        CarbineRifle = 127,
        AdvancedRifle = 128,
        SpecialCarbine = 129,
        BullpupRifle = 130,
        CompactRifle = 131,
        AssaultRifleMk2 = 132,
        CarbineRifleMk2 = 133,
        SpecialCarbineMk2 = 134,
        BullpupRifleMk2 = 135,
        /* Sniper */
        SniperRifle = 136,
        HeavySniper = 137,
        MarksmanRifle = 138,
        HeavySniperMk2 = 139,
        MarksmanRifleMk2 = 140,
        /* Shotguns */
        PumpShotgun = 141,
        SawnOffShotgun = 142,
        BullpupShotgun = 143,
        AssaultShotgun = 144,
        Musket = 145,
        HeavyShotgun = 146,
        DoubleBarrelShotgun = 147,
        SweeperShotgun = 148,
        PumpShotgunMk2 = 149,
        /* MELEE WEAPONS */
        StunGun = 109,
        Knife = 180,
        Nightstick = 181,
        Hammer = 182,
        Bat = 183,
        Crowbar = 184,
        GolfClub = 185,
        Bottle = 186,
        Dagger = 187,
        Hatchet = 188,
        KnuckleDuster = 189,
        Machete = 190,
        Flashlight = 191,
        SwitchBlade = 192,
        PoolCue = 193,
        Wrench = 194,
        BattleAxe = 195,
        /* Throwable Weapons */
        Grenade = 196,
        StickyBomb = 197,
        BZGas = 199,
        Molotov = 220,
        Snowball = 222,
        Ball = 223,
        SmokeGrenade = 224,
        PipeBomb = 225,
        /* Ammo */
        PistolAmmo = 200,
        SMGAmmo = 201,
        RiflesAmmo = 202,
        SniperAmmo = 203,
        ShotgunsAmmo = 204,

        Hay = 234,
        Seed = 235,
    }

    public class nItem
    {
        public int ID { get; internal set; }
        public ItemType Type { get; internal set; }
        public int Count { get; set; }
        public bool IsActive { get; set; }
        public dynamic Data;

        public nItem(ItemType type, int count = 1, dynamic data = null, bool isActive = false)
        {
            ID = Convert.ToInt32(type);
            Type = type;
            Count = count;
            Data = data;
            IsActive = isActive;
        }
    }
}
