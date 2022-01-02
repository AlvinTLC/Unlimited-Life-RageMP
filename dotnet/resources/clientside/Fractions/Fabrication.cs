using System;
using System.Collections.Generic;
using GTANetworkAPI;
using ULife.Core;
using UNL.SDK;
using System.Data;

namespace ULife.Fractions
{
    class AlcoFabrication : Script
    {
        private static nLog Log = new nLog("AlcoFabrication");
        private static Dictionary<int, Vector3> EnterAlcoShop = new Dictionary<int, Vector3>()
        {
            { 10, new Vector3(-1388.761, -586.3921, -29.09945) }, //Вход ТП в Бахам мамас
            { 12, new Vector3(-564.5512, 275.6993, -81.98249) }, //Вход ТП в Теки-Ла-Ла
            { 13, new Vector3(-430.1028, 261.2774, -81.88689) }, //Вход ТП в Камиди клаб
            { 14, new Vector3(4520.1646, -4515.3203, 3.3644614) }, //Вход ТП в Камиди клаб
            { 15, new Vector3(-436.1006, -359.90604, 33.949818) }, //Вход ТП в Камиди клаб
            { 16, new Vector3(-1073.0256, -2742.1228, 20.303743) }, //Вход ТП в Камиди клаб
        };
        private static Dictionary<int, Vector3> ExitAlcoShop = new Dictionary<int, Vector3>()
        {
            { 10, new Vector3(-1387.458, -588.3003, -29.19951) }, //Выход ТП из Бахамы мамас
            { 12, new Vector3(-564.487, 277.4747, -82.01633) }, //Выход ТП из Теки-Ла-Ла
            { 13, new Vector3(380.9767, -1001.358, -150.12004) }, //Выход ТП из Камиди клаб
            { 14, new Vector3(1697.774, 3291.435, 47.80036) }, //Выход ТП из Камиди клаб
            { 15, new Vector3(-418.7705, -344.68835, 23.2317) }, //Выход ТП из Камиди клаб
            { 16, new Vector3(-1071.2521, -2742.9534, 20.313765) }, //Выход ТП из Камиди клаб
    };
        private static Dictionary<int, string> ClubsNames = new Dictionary<int, string>()
        {
            { 10, "Bahama Mamas West" },
            { 11, "Vanila Unicorn" },
            { 12, "Tequi-la-la" },
            { 13, "Split Sides West Comedy Club" },
            { 14, "Timati TP" },
            { 15, "Krankenhaus Garage" },
            { 16, "airport" },
        };

        public static Dictionary<int, Stock> ClubsStocks = new Dictionary<int, Stock>();
        private static int MaxMats = 4000;
        private static Dictionary<int, Vector3> UnloadPoints = new Dictionary<int, Vector3>()
        {
            { 10, new Vector3(-1404.037, -633.443, 27.55337) }, // Выгрузка товара Бахама-мамас
            { 11, new Vector3(141.3792, -1281.576, 28.2172) }, // Выгрузка товара Стриптиз клуб
            { 12, new Vector3(-564.1531, 302.2027, 82.038) }, // Выгрузка товара Теки-Ла-Ла
            { 13, new Vector3(-452.4567, 290.8813, 82.113) }, // Выгрузка товара Камиди клаб
        };
        private static Dictionary<int, Vector3> BuyPoints = new Dictionary<int, Vector3>()
        {
            { 10, new Vector3(-1394.523, -602.7082, 29.19955) }, // Бахама мамас барная стойка покупка алкоголя
            { 11, new Vector3(126.4378, -1282.892, 28.15849) }, // Стрип клуб барная стойка покупка алкоголя
            { 12, new Vector3(-560.0757, 286.7839, 81.05637) }, // Теки-Ла-Ла барная стойка покупка алкоголя
            { 13, new Vector3(374.3211, -997.8187, -100.1199) }, // Камиди клаб барная стойка покупка алкоголя
        };

        private static List<int> DrinksPrices = new List<int>() { 75, 115, 150 };
        private static List<int> DrinksMats = new List<int>() { 5, 7, 10 };
        private static Dictionary<int, List<ItemType>> DrinksInClubs = new Dictionary<int, List<ItemType>>()
        {
            { 10, new List<ItemType>(){ItemType.LcnDrink1, ItemType.LcnDrink2, ItemType.LcnDrink3} },
            { 11, new List<ItemType>(){ItemType.RusDrink1, ItemType.RusDrink2, ItemType.RusDrink3} },
            { 12, new List<ItemType>(){ItemType.YakDrink1, ItemType.YakDrink2, ItemType.YakDrink3} },
            { 13, new List<ItemType>(){ItemType.ArmDrink1, ItemType.ArmDrink2, ItemType.ArmDrink3} },
        };

        public static Dictionary<ItemType, Vector3> AlcoPosOffset = new Dictionary<ItemType, Vector3>()
        {
            { ItemType.LcnDrink1, new Vector3(0.15, -0.25, -0.1) },
            { ItemType.LcnDrink2, new Vector3(0.15, -0.25, -0.1) },
            { ItemType.LcnDrink3, new Vector3(0.15, -0.23, -0.1) },
            { ItemType.RusDrink1, new Vector3(0.15, -0.23, -0.1) },
            { ItemType.RusDrink2, new Vector3(0.15, -0.23, -0.1) },
            { ItemType.RusDrink3, new Vector3(0.15, -0.23, -0.1) },
            { ItemType.YakDrink1, new Vector3(0.12, -0.02, -0.03) },
            { ItemType.YakDrink2, new Vector3(0.15, -0.23, -0.10) },
            { ItemType.YakDrink3, new Vector3(0.15, 0.03, -0.06) },
            { ItemType.ArmDrink1, new Vector3(0.15, -0.18, -0.10) },
            { ItemType.ArmDrink2, new Vector3(0.15, -0.18, -0.10) },
            { ItemType.ArmDrink3, new Vector3(0.15, -0.18, -0.10) },
        };
        public static Dictionary<ItemType, Vector3> AlcoRotOffset = new Dictionary<ItemType, Vector3>()
        {
            { ItemType.LcnDrink1, new Vector3(-80, 0, 0) },
            { ItemType.LcnDrink2, new Vector3(-80, 0, 0) },
            { ItemType.LcnDrink3, new Vector3(-80, 0, 0) },
            { ItemType.RusDrink1, new Vector3(-80, 0, 0) },
            { ItemType.RusDrink2, new Vector3(-80, 0, 0) },
            { ItemType.RusDrink3, new Vector3(-80, 0, 0) },
            { ItemType.YakDrink1, new Vector3(-80, 0, 0) },
            { ItemType.YakDrink2, new Vector3(-80, 0, 0) },
            { ItemType.YakDrink3, new Vector3(-80, 0, 0) },
            { ItemType.ArmDrink1, new Vector3(-80, 0, 0) },
            { ItemType.ArmDrink2, new Vector3(-80, 0, 0) },
            { ItemType.ArmDrink3, new Vector3(-80, 0, 0) },
        };

        [ServerEvent(Event.ResourceStart)]
        public void Event_ResourceStart()
        {
            try
            {
                NAPI.World.DeleteWorldProp(NAPI.Util.GetHashKey("prop_strip_door_01"), new Vector3(127.9552, -1298.503, 29.41962), 30f); //X:127,9552 Y:-1298,503 Z:29,41962 - СтрипТизКлуб door
                NAPI.World.DeleteWorldProp(NAPI.Util.GetHashKey("v_ilev_roc_door4"), new Vector3(-565.1712, 276.6259, 83.28626), 30f); // Дверь в Теки ла-Ла

                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("apa_mp_h_stn_chairarm_03"), new Vector3(-1397.15088, -598.213379, 29.3224068), new Vector3(0, 0, -18.1152821), 255, NAPI.GlobalDimension); // Bahama mamas 
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("apa_mp_h_stn_chairarm_03"), new Vector3(-1397.08069, -600.813477, 29.3224068), new Vector3(0, -0, -138.115219), 255, NAPI.GlobalDimension); // Bahama mamas 
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("apa_mp_h_stn_chairarm_03"), new Vector3(-1399.99353, -600.623291, 29.3224068), new Vector3(0, -0, 119.884583), 255, NAPI.GlobalDimension); // Bahama mamas 
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("apa_mp_h_stn_chairarm_03"), new Vector3(-1401.09326, -601.223145, 29.3224068), new Vector3(0, 0, -24.1148987), 255, NAPI.GlobalDimension); // Bahama mamas 
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("apa_mp_h_stn_chairarm_03"), new Vector3(-1399.75366, -602.2229, 29.3224068), new Vector3(0, 0, -41.9143143), 255, NAPI.GlobalDimension); // Bahama mamas 
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("apa_mp_h_stn_chairarm_03"), new Vector3(-1399.51343, -604.222656, 29.3224068), new Vector3(0, -0, -94.9140701), 255, NAPI.GlobalDimension); // Bahama mamas 
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("apa_mp_h_stn_chairarm_03"), new Vector3(-1401.00488, -606.364746, 29.3224068), new Vector3(0, -0, -161.913498), 255, NAPI.GlobalDimension); // Bahama mamas 
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("apa_mp_h_stn_chairarm_03"), new Vector3(-1403.46729, -604.663086, 29.3224068), new Vector3(0, -0, 129.486343), 255, NAPI.GlobalDimension); // Bahama mamas 
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("apa_mp_h_stn_chairarm_03"), new Vector3(-1404.37708, -603.463379, 29.3224068), new Vector3(0, -0, 124.486282), 255, NAPI.GlobalDimension); // Bahama mamas 
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("apa_mp_h_stn_chairarm_03"), new Vector3(-1400.23792, -610.231201, 29.3224068), new Vector3(0, 0, 55.4857788), 255, NAPI.GlobalDimension); // Bahama mamas 
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("apa_mp_h_stn_chairarm_03"), new Vector3(-1397.53857, -613.230469, 29.3224068), new Vector3(0, -0, -174.514252), 255, NAPI.GlobalDimension); // Bahama mamas 
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("apa_mp_h_stn_chairarm_03"), new Vector3(-1395.72827, -611.990723, 29.3224068), new Vector3(0, -0, -104.513588), 255, NAPI.GlobalDimension); // Bahama mamas 
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("apa_mp_h_stn_chairarm_03"), new Vector3(-1396.07861, -609.95874, 29.3224068), new Vector3(0, 0, -55.5132561), 255, NAPI.GlobalDimension); // Bahama mamas 
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("apa_mp_h_stn_chairarm_03"), new Vector3(-1397.49976, -608.927734, 29.3224068), new Vector3(0, 0, -20.513237), 255, NAPI.GlobalDimension); // Bahama mamas 
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("apa_mp_h_stn_chairarm_03"), new Vector3(-1396.10718, -615.662598, 29.3224068), new Vector3(0, -0, -127.513763), 255, NAPI.GlobalDimension); // Bahama mamas 

                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("prop_huge_display_01"), new Vector3(371.9039, -990.349854, -98.0589447), new Vector3(0, 0, -89.7690125), 255, NAPI.GlobalDimension); // comedy club door
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("prop_huge_display_01"), new Vector3(376.57428, -990.049927, -96.4589691), new Vector3(0, -0, -179.769073), 255, NAPI.GlobalDimension);
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("prop_huge_display_01"), new Vector3(372.103912, -1004.65002, -98.0589447), new Vector3(0, 0, -89.7690048), 255, NAPI.GlobalDimension);
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("prop_huge_display_01"), new Vector3(377.604248, -1004.15015, -98.0589447), new Vector3(0, 0, 0.23099421), 255, NAPI.GlobalDimension);
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("prop_huge_display_01"), new Vector3(383.774689, -1004.15015, -98.0589447), new Vector3(0, -0, 90.2309723), 255, NAPI.GlobalDimension);
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("prop_huge_display_01"), new Vector3(381.704498, -992.852905, -98.0589447), new Vector3(0, -0, 90.2309647), 255, NAPI.GlobalDimension);
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("prop_huge_display_01"), new Vector3(388.004883, -998.751465, -98.0589447), new Vector3(0, -0, -179.769104), 255, NAPI.GlobalDimension);
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("prop_huge_display_01"), new Vector3(370.503998, -998.349854, -98.0589447), new Vector3(0, 0, -89.7690048), 255, NAPI.GlobalDimension);
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("prop_huge_display_01"), new Vector3(365.674225, -996.549805, -98.4589691), new Vector3(0, -0, -179.769073), 255, NAPI.GlobalDimension);
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("prop_huge_display_01"), new Vector3(365.594147, -998.883057, -98.4589691), new Vector3(0, 0, 0.231002808), 255, NAPI.GlobalDimension);
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("lr_prop_clubstool_01"), new Vector3(376.016602, -999.739929, -100.028435), new Vector3(0, 0, 89.774147), 255, NAPI.GlobalDimension);
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("lr_prop_clubstool_01"), new Vector3(375.938019, -1000.87671, -100.028435), new Vector3(0, 0, 81.4817657), 255, NAPI.GlobalDimension);
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("lr_prop_clubstool_01"), new Vector3(375.919434, -1001.87073, -100.028435), new Vector3(0, -0, 109.426132), 255, NAPI.GlobalDimension);
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("lr_prop_clubstool_01"), new Vector3(376.111938, -1003.08606, -100.028435), new Vector3(0, -0, 136.909775), 255, NAPI.GlobalDimension);
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("lr_prop_clubstool_01"), new Vector3(375.815247, -990.539917, -99.7284622), new Vector3(0, 0, -4.8109498), 255, NAPI.GlobalDimension);
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("p_yoga_mat_03_s"), new Vector3(373.065887, -999.187195, -98.9689713), new Vector3(8.40430744e-07, 89.9999466, 179.998123), 255, NAPI.GlobalDimension);
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("hei_heist_kit_bin_01"), new Vector3(373.325378, -999.457397, -99.9999771), new Vector3(0, 0, 47.6214714), 255, NAPI.GlobalDimension);
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("prop_bench_06"), new Vector3(-847.1567, -1314.837, 3.880184), new Vector3(0, 0, 110.00), 255, NAPI.GlobalDimension);//Лавка у причала
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("prop_rub_litter_03b"), new Vector3(-862.1754, -1324.023, 0.58), new Vector3(0, 0, 10.0), 255, NAPI.GlobalDimension);//Мусор из бумаг
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("prop_rub_binbag_01b"), new Vector3(-847.4643, -1327.516, 1.0), new Vector3(0, 0, 112.7887), 255, NAPI.GlobalDimension);//Пакетный мусор
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("prop_hotdogstand_01"), new Vector3(-640.3412, -1287.854, 9.68), new Vector3(0, 0, 72.83), 255, NAPI.GlobalDimension);//Ларек для пиво Frank
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("prop_pallet_03a"), new Vector3(-542.2328, -1510.072, 4.5), new Vector3(0, 0, 157.0604), 255, NAPI.GlobalDimension);// Поддон для мусора (Френк)


                //builder cement
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("prop_conslift_lift"), new Vector3(-182.2164, -1016.441, 31.37329), new Vector3(0, 0, -110), 255, NAPI.GlobalDimension);// lift builder
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("prop_conslift_lift"), new Vector3(-182.2239, -1016.448, 115.5188), new Vector3(0, 0, 70), 255, NAPI.GlobalDimension);// lift builder
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("prop_conslift_lift"), new Vector3(-182.1539, -1016.408, 31.37329), new Vector3(0, 0, 70), 255, NAPI.GlobalDimension);// lift builder
                NAPI.Object.CreateObject(NAPI.Util.GetHashKey("prop_conslift_lift"), new Vector3(-182.4364, -1016.441, 115.5188), new Vector3(0, 0, -110), 255, NAPI.GlobalDimension);// lift builder




                /*NAPI.Blip.CreateBlip(93, new Vector3(-1388.761, -586.3921, 29.09945), 0.50f, 45, "Bahama Mamas", 255, 0, true);
                NAPI.Blip.CreateBlip(121, new Vector3(141.3792, -1281.576, 28.2172), 0.50f, 45, "Vanilla Unicorn", 255, 0, true);
                NAPI.Blip.CreateBlip(136, new Vector3(-564.5512, 275.6993, 81.98249), 0.50f, 45, "Tekila-La-La", 255, 0, true);
                NAPI.Blip.CreateBlip(205, new Vector3(-430.1028, 261.2774, 81.88689), 0.50f, 45, "Comedy", 255, 0, true); */



                var result = MySQL.QueryRead("SELECT * FROM alcoclubs");
                if (result == null || result.Rows.Count == 0)
                {
                    Log.Write("DB alcoclubs return null result.", nLog.Type.Warn);
                    return;
                }
                foreach (DataRow Row in result.Rows)
                {
                    var id = Convert.ToInt32(Row["id"]);
                    var stock = new Stock(Convert.ToInt32(Row["mats"]), Convert.ToInt32(Row["alco1"]), Convert.ToInt32(Row["alco2"]), Convert.ToInt32(Row["alco3"]),
                        Convert.ToSingle(Convert.ToInt32(Row["pricemod"]) / 100), UnloadPoints[id] + new Vector3(0, 0, 0.8));
                    ClubsStocks.Add(id, stock);
                }

                #region Enter AlcoShops
                foreach (var pair in EnterAlcoShop)
                {
                    var colShape = NAPI.ColShape.CreateCylinderColShape(pair.Value, 1f, 2, NAPI.GlobalDimension);
                    colShape.SetData("ID", pair.Key);
                    colShape.OnEntityEnterColShape += (s, e) =>
                    {
                        try
                        {
                            e.SetData("CLUB", s.GetData<int>("ID"));
                            e.SetData("INTERACTIONCHECK", 54);
                        }
                        catch (Exception ex) { Log.Write("EnterAlco_OnEntityEnterColShape: " + ex.Message, nLog.Type.Error); }
                    };
                    colShape.OnEntityExitColShape += (s, e) =>
                    {
                        try
                        {
                            e.SetData("INTERACTIONCHECK", 0);
                            e.SetData("CLUB", -1);
                        }
                        catch (Exception ex) { Log.Write("EnterAlco_OnEntityExitColShape: " + ex.Message, nLog.Type.Error); }
                    };

                    NAPI.Marker.CreateMarker(1, pair.Value - new Vector3(0, 0, 0.7), new Vector3(), new Vector3(), 1, new Color(255, 255, 255, 220), false, NAPI.GlobalDimension);
                    //NAPI.TextLabel.CreateTextLabel($"~g~Club\n\"{ClubsNames[pair.Key]}\"", pair.Value + new Vector3(0, 0, 0.5), 5f, 0.3f, 0, new Color(255, 255, 255), true, NAPI.GlobalDimension);
                }
                #endregion
                #region Exit AlcoShops
                foreach (var pair in ExitAlcoShop)
                {
                    var colShape = NAPI.ColShape.CreateCylinderColShape(pair.Value, 1f, 2, NAPI.GlobalDimension);
                    colShape.SetData("ID", pair.Key);
                    colShape.OnEntityEnterColShape += (s, e) =>
                    {
                        try
                        {
                            e.SetData("CLUB", s.GetData<int>("ID"));
                            e.SetData("INTERACTIONCHECK", 55);
                        }
                        catch (Exception ex) { Log.Write("ExitAlco_OnEntityEnterColShape: " + ex.Message, nLog.Type.Error); }
                    };
                    colShape.OnEntityExitColShape += (s, e) =>
                    {
                        try
                        {
                            e.SetData("INTERACTIONCHECK", 0);
                        }
                        catch (Exception ex) { Log.Write("ExitAlco_OnEntityExitColShape: " + ex.Message, nLog.Type.Error); }
                    };

                    NAPI.Marker.CreateMarker(1, pair.Value - new Vector3(0, 0, 0.7), new Vector3(), new Vector3(), 1, new Color(255, 255, 255, 220), false, NAPI.GlobalDimension);
                    //NAPI.TextLabel.CreateTextLabel($"~g~Exit", pair.Value + new Vector3(0, 0, 0.5), 5f, 0.3f, 0, new Color(255, 255, 255), true, NAPI.GlobalDimension);
                }
                #endregion
                #region Unloadpoints
                foreach (var pair in UnloadPoints)
                {
                    var colShape = NAPI.ColShape.CreateCylinderColShape(pair.Value, 5, 5, NAPI.GlobalDimension);
                    colShape.SetData("ID", pair.Key);
                    colShape.OnEntityEnterColShape += (s, e) =>
                    {
                        try
                        {
                            e.SetData("CLUB", s.GetData<int>("ID"));
                            e.SetData("INTERACTIONCHECK", 56);
                        }
                        catch (Exception ex) { Log.Write("Unloadpoints_OnEntityEnterColShape: " + ex.Message, nLog.Type.Error); }
                    };
                    colShape.OnEntityExitColShape += (s, e) =>
                    {
                        try
                        {
                            e.SetData("INTERACTIONCHECK", 0);
                        }
                        catch (Exception ex) { Log.Write("Unloadpoints_OnEntityExitColShape: " + ex.Message, nLog.Type.Error); }
                    };

                    NAPI.Marker.CreateMarker(1, pair.Value - new Vector3(0, 0, 4.5), new Vector3(), new Vector3(), 5, new Color(255, 0, 0, 220), false, NAPI.GlobalDimension);
                    //NAPI.TextLabel.CreateTextLabel($"~g~Unload all materials", pair.Value + new Vector3(0, 0, 0.5), 5f, 0.3f, 0, new Color(255, 255, 255), true, NAPI.GlobalDimension);
                }
                #endregion
                #region BuyPoints
                foreach (var pair in BuyPoints)
                {
                    var colShape = NAPI.ColShape.CreateCylinderColShape(pair.Value, 1.5f, 2, NAPI.GlobalDimension);
                    colShape.SetData("ID", pair.Key);
                    colShape.OnEntityEnterColShape += (s, e) =>
                    {
                        try
                        {
                            e.SetData("CLUB", s.GetData<int>("ID"));
                            e.SetData("INTERACTIONCHECK", 57);
                        }
                        catch (Exception ex) { Log.Write("BuyPoints_OnEntityEnterColShape: " + ex.Message, nLog.Type.Error); }
                    };
                    colShape.OnEntityExitColShape += (s, e) =>
                    {
                        try
                        {
                            e.SetData("INTERACTIONCHECK", 0);
                        }
                        catch (Exception ex) { Log.Write("BuyPoints_OnEntityExitColShape: " + ex.Message, nLog.Type.Error); }
                    };

                    NAPI.Marker.CreateMarker(1, pair.Value - new Vector3(0, 0, 0.7), new Vector3(), new Vector3(), 1, new Color(255, 255, 255, 220), false, NAPI.GlobalDimension);
                    //NAPI.TextLabel.CreateTextLabel($"~g~Buy/Manage alcohol", pair.Value + new Vector3(0, 0, 0.5), 5f, 0.3f, 0, new Color(255, 255, 255), true, NAPI.GlobalDimension);
                }
                #endregion
            }
            catch (Exception e) { Log.Write("ServerStart: " + e.Message, nLog.Type.Error); }
        }

        public static void Event_InteractPressed(Player player, int id)
        {
            switch (id)
            {
                case 54:
                    NAPI.Entity.SetEntityPosition(player, ExitAlcoShop[player.GetData<int>("CLUB")] + new Vector3(0, 0, 1.2));
                    return;
                case 55:
                    NAPI.Entity.SetEntityPosition(player, EnterAlcoShop[player.GetData<int>("CLUB")] + new Vector3(0, 0, 1.2));
                    return;
                case 56:
                    if (!Main.Players.ContainsKey(player)) return;

                    if (Main.Players[player].FractionID != player.GetData<int>("CLUB"))
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du bist kein Mitglied {Fractions.Manager.getName(player.GetData<int>("CLUB"))}", 3000);
                        return;
                    }

                    if (!player.IsInVehicle)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Du musst im Auto sitzen", 3000);
                        return;
                    }

                    int club = player.GetData<int>("CLUB");

                    var matCount = VehicleInventory.GetCountOfType(player.Vehicle, ItemType.Material);
                    if (matCount == 0)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Es ist kein Material im Auto", 3000);
                        return;
                    }

                    if (ClubsStocks[club].Materials >= MaxMats)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Das Lager ist voll", 3000);
                        return;
                    }

                    VehicleInventory.Remove(player.Vehicle, ItemType.Material, matCount);
                    ClubsStocks[club].Materials += matCount;
                    ClubsStocks[club].UpdateLabel();
                    Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, "Du hast das ganze Material aus deinem Auto ins Clubhaus Lager getan", 3000);
                    return;
                case 57:
                    if (!Main.Players.ContainsKey(player)) return;
                    OpenBuyAlcoholMenu(player);
                    return;
            }
        }

        public static void ResistTimer(Player player)
        {
            if (!Main.Players.ContainsKey(player)) return;

            if (player.GetData<int>("RESIST_TIME") == 0)
            {
                Trigger.ClientEvent(player, "stopScreenEffect", "PPFilter");
                Trigger.ClientEvent(player, "setResistStage", 0);

                player.ResetData("RESIST_BAN");
                //Main.StopT(player.GetData("RESIST_TIMER"), "timer_27");
                Timers.Stop(player.GetData<string>("RESIST_TIMER"));
            }
            else
                player.SetData("RESIST_TIME", player.GetData<int>("RESIST_TIME") - 1);
        }

        public static void SaveAlco()
        {
            try
            {
                foreach (var club in ClubsStocks)
                {
                    MySQL.Query($"UPDATE alcoclubs SET alco1={club.Value.Alco1},alco2={club.Value.Alco2},alco3={club.Value.Alco3}," +
                        $"pricemod={Convert.ToInt32(club.Value.PriceModifier * 100)},mats={club.Value.Materials} WHERE id={club.Key}");
                }
            }
            catch (Exception e) { Log.Write("SaveAlco: " + e.Message, nLog.Type.Error); }
        }

        #region Buy Menu
        public static void OpenBuyAlcoholMenu(Player player)
        {
            int club = player.GetData<int>("CLUB");
            var isOwner = (Main.Players[player].FractionID == club && Manager.isLeader(player, club)) ? true : false;
            var stock = new List<int>()
            {
                ClubsStocks[club].Materials,
                ClubsStocks[club].Alco1,
                ClubsStocks[club].Alco2,
                ClubsStocks[club].Alco3,
            };
            Trigger.ClientEvent(player, "openAlco", club, ClubsStocks[club].PriceModifier, isOwner, stock);
        }
        [RemoteEvent("menu_alco")]
        public static void RemoteEvent_alcoMenu(Player player, int action, int index)
        {
            try
            {
                if (player.GetData<int>("CLUB") == -1) return;

                int club = player.GetData<int>("CLUB");
                List<int> alcoCounts = new List<int>() { ClubsStocks[club].Alco1, ClubsStocks[club].Alco2, ClubsStocks[club].Alco3 };
                ItemType invItem = DrinksInClubs[club][index];

                switch (action)
                {
                    case 0: // buy
                        if (alcoCounts[index] <= 0)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Nicht genügend Ware auf Lager", 3000);
                            return;
                        }
                        var tryAdd = nInventory.TryAdd(player, new nItem(invItem));
                        if (tryAdd == -1 || tryAdd > 0)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Nicht genug Platz im Lager", 3000);
                            return;
                        }
                        if (!MoneySystem.Wallet.Change(player, -Convert.ToInt32(DrinksPrices[index] * ClubsStocks[club].PriceModifier)))
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Du hast nicht genügend Geldmittel", 3000);
                            return;
                        }
                        Stocks.fracStocks[club].Money += Convert.ToInt32(DrinksPrices[index] * ClubsStocks[club].PriceModifier);
                        GameLog.Money($"player({Main.Players[player].UUID})", $"frac({club})", Convert.ToInt32(DrinksPrices[index] * ClubsStocks[club].PriceModifier), $"buyAlco");
                        nInventory.Add(player, new nItem(invItem));

                        switch (index)
                        {
                            case 0:
                                ClubsStocks[club].Alco1--;
                                return;
                            case 1:
                                ClubsStocks[club].Alco2--;
                                return;
                            case 2:
                                ClubsStocks[club].Alco3--;
                                return;
                        }
                        ClubsStocks[club].UpdateLabel();
                        OpenBuyAlcoholMenu(player);
                        Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du hast gekauft {nInventory.ItemsNames[(int)invItem]}", 3000);
                        return;
                    case 1: // take
                        if (alcoCounts[index] <= 0)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Nicht genügend Ware auf Lager", 3000);
                            return;
                        }
                        tryAdd = nInventory.TryAdd(player, new nItem(invItem));
                        if (tryAdd == -1 || tryAdd > 0)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Nicht genug Platz im Lager", 3000);
                            return;
                        }
                        nInventory.Add(player, new nItem(invItem));

                        switch (index)
                        {
                            case 0:
                                ClubsStocks[club].Alco1--;
                                return;
                            case 1:
                                ClubsStocks[club].Alco2--;
                                return;
                            case 2:
                                ClubsStocks[club].Alco3--;
                                return;
                        }
                        ClubsStocks[club].UpdateLabel();
                        OpenBuyAlcoholMenu(player);
                        Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du hast {nInventory.ItemsNames[(int)invItem]}. Vorrätig {alcoCounts[index] - 1}Stück", 3000);
                        return;
                    case 2: // craft
                        if (alcoCounts[index] >= 80)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Es gibt eine maximale {nInventory.ItemsNames[(int)invItem]}", 3000);
                            return;
                        }
                        if (ClubsStocks[club].Materials < DrinksMats[index])
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Es ist nicht genügend Material vorrätig", 3000);
                            return;
                        }

                        ClubsStocks[club].Materials -= DrinksMats[index];
                        switch (index)
                        {
                            case 0:
                                ClubsStocks[club].Alco1++;
                                return;
                            case 1:
                                ClubsStocks[club].Alco2++;
                                return;
                            case 2:
                                ClubsStocks[club].Alco3++;
                                return;
                        }

                        ClubsStocks[club].UpdateLabel();
                        OpenBuyAlcoholMenu(player);
                        Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du hast {nInventory.ItemsNames[(int)invItem]}. Vorrätig {alcoCounts[index] + 1}Stück", 3000);
                        return;
                    case 3: // setprice
                        Trigger.ClientEvent(player, "openInput", "Preis einstellen", "Preis für Alkohol in Prozenten eingeben", 3, "club_setprice");
                        return;
                }
            }
            catch (Exception e) { Log.Write("menu_alco: " + e.Message, nLog.Type.Error); }
        }
        public static void SetAlcoholPrice(Player player, int price)
        {
            if (!Main.Players.ContainsKey(player) || !Manager.isLeader(player, Main.Players[player].FractionID) || !ClubsStocks.ContainsKey(Main.Players[player].FractionID)) return;

            if (price < 50 || price > 150)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Stellen Sie den Preis von 50 % bis 150 % ein", 3000);
                return;
            }

            ClubsStocks[Main.Players[player].FractionID].PriceModifier = price / 100.0f;
            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Sie haben den Preis für alkoholische Getränke auf {price}% geändert", 3000);
        }
        #endregion

        internal class Stock
        {
            public int Materials { get; set; }
            public int Alco1 { get; set; }
            public int Alco2 { get; set; }
            public int Alco3 { get; set; }
            public float PriceModifier { get; set; }

            public TextLabel Label { get; set; }

            public Stock(int mats, int a1, int a2, int a3, float price, Vector3 pos)
            {
                //Label = NAPI.TextLabel.CreateTextLabel($"~g~Materials: {mats}\nAlcohol: {a1 + a2 + a3}", pos, 30f, 0.3f, 0, new Color());

                Materials = mats;
                Alco1 = a1;
                Alco2 = a2;
                Alco3 = a3;
                PriceModifier = price;
            }

            public void UpdateLabel()
            {
                //Label.Text = $"~g~Materials: {Materials}\nAlcohol: {Alco1 + Alco2 + Alco3}";
            }
        }
    }
}
