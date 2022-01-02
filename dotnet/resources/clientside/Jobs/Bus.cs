using GTANetworkAPI;
using System;
using System.Collections.Generic;
using ULife.Core;
using UNL.SDK;

namespace ULife.Jobs
{
    class Bus : Script
    {
        private static List<int> BuswaysPayments = new List<int>()
        {
            6, 8, 6, 8, 8, 16
        };
        private static nLog Log = new nLog("Bus");

        private static int BusRentCost = 100;
        private static List<String> BusWaysNames = new List<String>
        {
            "Route № 1",
            "Route № 2",
            "Route № 3",
            "Route № 4",
            "Route № 5",
            "Route № 6",
        };
        private static List<List<BusCheck>> BusWays = new List<List<BusCheck>>()
        {
            new List<BusCheck>() // busway1
            {
                new BusCheck(new Vector3(-2188.1514, -377.64554, 13.349202), false), // 1
                new BusCheck(new Vector3(-2151.5764, -294.1024, 13.172105), false), // 2
                new BusCheck(new Vector3(-1815.1372, -321.47284, 43.062702), true), // 3
                new BusCheck(new Vector3(-1631.9811, -324.39838, 50.939117), false), // 4
                new BusCheck(new Vector3(-1421.1635, 60.509937, 52.393513), true), // 5
                new BusCheck(new Vector3(-1299.992, 207.67429, 58.8961), false), // 6
                new BusCheck(new Vector3(-987.7676, 253.04689, 68.1487), false), // 7
                new BusCheck(new Vector3(-704.5135, 236.00946, 80.51268), false), // 8
                new BusCheck(new Vector3(-406.76495, 229.31963, 83.52951), true), // 9
                new BusCheck(new Vector3(-174.66011, 251.84021, 93.22326), false), // 10
                new BusCheck(new Vector3(271.62106, 156.17651, 104.50337), true), // 11
                new BusCheck(new Vector3(480.63348, 88.72525, 97.45915), false), // 12
                new BusCheck(new Vector3(657.7397, 17.296492, 85.33537), false), // 13
                new BusCheck(new Vector3(542.9657, -84.759674, 67.50061), false), // 14
                new BusCheck(new Vector3(398.7723, -391.1806, 46.977974), false), // 15
                new BusCheck(new Vector3(304.93546, -417.9063, 45.05159), false), // 16
                new BusCheck(new Vector3(251.24438, -573.02673, 43.309868), true), // 17
                new BusCheck(new Vector3(172.35959, -788.3894, 31.61221), false), // 18
                new BusCheck(new Vector3(109.19699, -961.1655, 29.601717), false), // 19
                new BusCheck(new Vector3(-8.306731, -952.57715, 29.566566), false), // 20
                new BusCheck(new Vector3(-106.609436, -907.13806, 29.354212), true), // 21
                new BusCheck(new Vector3(-389.1681, -834.126, 31.708996), false), // 22
                new BusCheck(new Vector3(-574.11444, -829.2594, 26.712202), false), // 23
                new BusCheck(new Vector3(-634.8458, -712.763, 29.582819), false), // 24
                new BusCheck(new Vector3(-725.48987, -648.75006, 30.370829), false), // 25
                new BusCheck(new Vector3(-1026.549, -708.4296, 20.694466), false), // 26
                new BusCheck(new Vector3(-1250.4337, -888.1836, 12.072328), false), // 27
                new BusCheck(new Vector3(-1411.1173, -769.0529, 22.101067), false), // 28
                new BusCheck(new Vector3(-1666.8625, -543.4441, 35.003296), true), // 29
                new BusCheck(new Vector3(-1722.4226, -553.81396, 37.525513), false), // 30
                new BusCheck(new Vector3(-1943.158, -425.24185, 18.941729), false), // 31
                new BusCheck(new Vector3(-2164.218, -344.46457, 13.343652), false), // 32

            },
            new List<BusCheck>() // busway2
            {
                new BusCheck(new Vector3(-2188.1514, -377.64554, 13.349202), false), // 1 
                new BusCheck(new Vector3(-2164.6194, -356.14435, 13.31945), false), // 2 
                new BusCheck(new Vector3(-1813.8817, -519.8641, 30.347847), false), // 3 
                new BusCheck(new Vector3(-1678.1516, -568.2519, 34.590584), false), // 4 
                new BusCheck(new Vector3(-1463.4518, -740.666, 24.444664), false), // 5 
                new BusCheck(new Vector3(-1305.9891, -879.6369, 12.563886), false), // 6 
                new BusCheck(new Vector3(-1197.1165, -874.6588, 13.551588), true), // 7 
                new BusCheck(new Vector3(-1096.5769, -789.5816, 19.17222), false), // 8
                new BusCheck(new Vector3(-838.827, -1007.7619, 13.582674), false), // 9
                new BusCheck(new Vector3(-676.38086, -1277.2551, 10.655426), true), // 10
                new BusCheck(new Vector3(-676.38086, -1277.2551, 10.655426), false), // 11
                new BusCheck(new Vector3(-770.92175, -1673.208, 28.248875), false), // 12
                new BusCheck(new Vector3(-711.84033, -1983.7816, 25.880787), false), // 13
                new BusCheck(new Vector3(-954.51605, -2370.542, 20.250017), false), // 14
                new BusCheck(new Vector3(-1021.216, -2737.3367, 20.231997), true), // 15
                new BusCheck(new Vector3(-895.5046, -2694.4497, 20.292591), false), // 16
                new BusCheck(new Vector3(-738.9344, -2420.3628, 14.709247), false), // 17
                new BusCheck(new Vector3(-751.0758, -2358.0864, 15.065346), false), // 18
                new BusCheck(new Vector3(-972.41016, -1839.4272, 19.709679), false), // 19
                new BusCheck(new Vector3(-730.7036, -1577.1055, 14.566332), false), // 20
                new BusCheck(new Vector3(-674.65027, -1471.3057, 10.700088), false), // 21
                new BusCheck(new Vector3(-637.3105, -1327.649, 10.806154), false), // 22
                new BusCheck(new Vector3(-693.4021, -1199.8673, 10.649996), true), // 23
                new BusCheck(new Vector3(-905.82684, -882.9615, 15.73861), false), // 24
                new BusCheck(new Vector3(-1114.5848, -714.26526, 20.773945), false), // 25
                new BusCheck(new Vector3(-1253.8558, -552.02264, 29.89725), false), // 26
                new BusCheck(new Vector3(-1362.7257, -411.77502, 36.575573), false), // 27
                new BusCheck(new Vector3(-1552.1545, -490.30624, 35.789967), false), // 28
                new BusCheck(new Vector3(-1782.5511, -533.59924, 33.36151), false), // 29
                new BusCheck(new Vector3(-2042.156, -379.77917, 11.097501), false), // 30
                new BusCheck(new Vector3(-2170.512, -343.7631, 13.3386965), false), // 31
                
            },
            new List<BusCheck>() // busway3
            {
                new BusCheck(new Vector3(-2238.6604, -336.89987, 13.608087), false), // 1
                new BusCheck(new Vector3(-2424.662, -235.84048, 16.206848), false), // 2
                new BusCheck(new Vector3(-2672.2883, -50.83568, 16.426498), false), // 3
                new BusCheck(new Vector3(-3030.3499, 202.23242, 16.242992), false), // 4
                new BusCheck(new Vector3(-3027.6123, 608.01105, 7.8556333), true), // 5
                new BusCheck(new Vector3(-3090.6824, 736.3857, 21.344877), false), // 6
                new BusCheck(new Vector3(-3093.5527, 793.22186, 19.10147), false), // 7
                new BusCheck(new Vector3(-3150.3794, 893.44604, 14.794761), false), // 8
                new BusCheck(new Vector3(-3224.7366, 974.3691, 12.965047), true), // 9
                new BusCheck(new Vector3(-3181.2114, 1183.129, 9.602755), false), // 10
                new BusCheck(new Vector3(-3110.9446, 1317.1221, 20.294851), false), // 11
                new BusCheck(new Vector3(-3060.3853, 1376.0884, 20.704393), false), // 12
                new BusCheck(new Vector3(-3035.3503, 1805.3328, 34.15243), false), // 13
                new BusCheck(new Vector3(-2793.119, 2207.3403, 26.979803), false), // 14
                new BusCheck(new Vector3(-2606.2866, 2954.4502, 16.806925), false), // 15
                new BusCheck(new Vector3(-2451.2754, 3722.7764, 15.952158), true), // 16
                new BusCheck(new Vector3(-2278.0596, 4204.4277, 41.523838), false), // 17
                new BusCheck(new Vector3(-1977.7473, 4534.3438, 57.215736), false), // 18
                new BusCheck(new Vector3(-1414.0787, 5069.032, 61.331165), false), // 19
                new BusCheck(new Vector3(-1256.976, 5257.7515, 50.432137), false), // 20
                new BusCheck(new Vector3(-1136.4421, 5286.7324, 52.58372), false), // 21
                new BusCheck(new Vector3(-1136.4421, 5286.7324, 52.58372), false), // 22
                new BusCheck(new Vector3(-552.1847, 5711.101, 37.319397), false), // 23
                new BusCheck(new Vector3(-158.0463, 6204.2173, 31.36298), true), // 24
                new BusCheck(new Vector3(130.29648, 6507.1597, 31.640343), false), // 25
                new BusCheck(new Vector3(91.95901, 6594.1523, 31.682154), false), // 26
                new BusCheck(new Vector3(32.51762, 6572.099, 31.512407), false), // 27
                new BusCheck(new Vector3(-413.28882, 6126.9697, 31.47766), false), // 28
                new BusCheck(new Vector3(-412.96652, 6005.1084, 31.711515), false), // 29
                new BusCheck(new Vector3(-917.89343, 5425.086, 37.242893), false), // 30
                new BusCheck(new Vector3(-1164.113, 5275.9497, 53.70552), false), // 31
                new BusCheck(new Vector3(-1611.4404, 4896.43, 61.33202), false), // 32
                new BusCheck(new Vector3(-2203.0615, 4374.8047, 53.835), false), // 33
                new BusCheck(new Vector3(-2538.3337, 3487.0122, 13.931398), false), // 34
                new BusCheck(new Vector3(-2692.9336, 2440.013, 16.83775), false), // 35
                new BusCheck(new Vector3(-3046.8513, 1738.994, 36.770744), false), // 36
                new BusCheck(new Vector3(-3074.8113, 1378.4015, 20.604069), false), // 37
                new BusCheck(new Vector3(-3234.4001, 968.1731, 13.156341), true), // 38
                new BusCheck(new Vector3(-3174.1248, 906.69086, 14.729084), false), // 39
                new BusCheck(new Vector3(-3104.021, 785.9435, 19.089117), false), // 40
                new BusCheck(new Vector3(-2448.9067, -241.06499, 16.646051), false), // 41
                new BusCheck(new Vector3(-2216.8838, -354.73477, 13.421798), false), // 42
            },
            new List<BusCheck>() // busway4
            {
                new BusCheck(new Vector3(-2193.0464, -374.59735, 13.356007), false), // 1 
                new BusCheck(new Vector3(-2153.549, -301.86267, 13.154232), false), // 2               
                new BusCheck(new Vector3(-1873.1625, -227.61069, 38.377842), false), // 3
                new BusCheck(new Vector3(-1575.5234, -200.17804, 55.632786), false), // 4
                new BusCheck(new Vector3(-1425.6979, -348.0423, 42.841343), false), // 5
                new BusCheck(new Vector3(-1327.7262, -371.7935, 36.807377), false), // 6
                new BusCheck(new Vector3(-1058.0721, -215.1143, 37.96308), false), // 7
                new BusCheck(new Vector3(-941.81525, -253.81099, 39.173008), false), // 8
                new BusCheck(new Vector3(-393.947, -397.22418, 31.915613), false), // 9
                new BusCheck(new Vector3(-136.23793, -355.95547, 35.112003), true), // 10
                new BusCheck(new Vector3(1.7604187, -275.65906, 47.543404), false), // 11
                new BusCheck(new Vector3(236.0849, -369.76086, 44.391247), true), // 12
                new BusCheck(new Vector3(252.10811, -572.23505, 43.330032), true), // 13
                new BusCheck(new Vector3(116.02084, -942.4737, 29.838804), false), // 14
                new BusCheck(new Vector3(6.055313, -956.4309, 29.536179), false), // 15
                new BusCheck(new Vector3(-350.8888, -842.4693, 31.76133), false), // 16
                new BusCheck(new Vector3(-789.0122, -833.5597, 21.184935), false), // 17
                new BusCheck(new Vector3(-1102.2438, -720.2893, 20.247805), false), // 18
                new BusCheck(new Vector3(-1249.483, -607.9775, 27.266582), false), // 19
                new BusCheck(new Vector3(-1424.6119, -725.1522, 23.488188), false), // 20
                new BusCheck(new Vector3(-1669.2574, -542.68524, 35.129704), true), // 21
                new BusCheck(new Vector3(-1726.1886, -556.32434, 37.46405), false), // 22
                new BusCheck(new Vector3(-1939.1718, -428.34213, 19.254171), false), // 23
                new BusCheck(new Vector3(-2149.8347, -348.48068, 13.297486), false), // 24
            },
            new List<BusCheck>() // busway5
            {
                new BusCheck(new Vector3(-2201.336, -367.39465, 13.243897), false), // 1 
                new BusCheck(new Vector3(-1936.3597, -513.2621, 11.89613), false), // 2
                new BusCheck(new Vector3(-1615.8907, -749.1217, 11.520832), false), // 3
                new BusCheck(new Vector3(-1094.0009, -640.44604, 14.703336), false), // 4
                new BusCheck(new Vector3(-735.9255, -525.61835, 25.235367), false), // 5
                new BusCheck(new Vector3(-258.59384, -524.7513, 25.904158), false), // 6
                new BusCheck(new Vector3(81.083176, -542.7748, 33.86699), false), // 7
                new BusCheck(new Vector3(252.51564, -543.06696, 43.2866), false), // 8
                new BusCheck(new Vector3(297.97885, -505.74527, 43.395138), false), // 9
                new BusCheck(new Vector3(447.7233, -364.88153, 47.155018), false), // 10
                new BusCheck(new Vector3(569.9866, -357.5029, 43.69454), false), // 11
                new BusCheck(new Vector3(641.07446, -304.99203, 43.745186), false), // 12
                new BusCheck(new Vector3(846.7257, 67.61756, 67.52379), true), // 13
                new BusCheck(new Vector3(1172.0366, 451.50687, 82.55458), false), // 14
                new BusCheck(new Vector3(1700.1229, 1404.7124, 86.353035), false), // 15
                new BusCheck(new Vector3(1755.3539, 1707.0474, 82.61311), false), // 16
                new BusCheck(new Vector3(1834.9352, 2099.0122, 72.15951), false), // 17
                new BusCheck(new Vector3(2008.6681, 2557.374, 54.656277), false), // 18
                new BusCheck(new Vector3(2295.8933, 2785.8684, 42.525352), false), // 19
                new BusCheck(new Vector3(2416.984, 2903.1199, 49.405514), false), // 20
                new BusCheck(new Vector3(2281.331, 3004.621, 46.169075), false), // 21
                new BusCheck(new Vector3(1836.937, 3271.969, 44.060154), false), // 22
                new BusCheck(new Vector3(1649.6163, 3599.3516, 35.56158), false), // 23
                new BusCheck(new Vector3(1562.3936, 3736.847, 34.58596), false), // 24
                new BusCheck(new Vector3(1625.8722, 3816.9849, 35.0409), true), // 25
                new BusCheck(new Vector3(1805.294, 3937.9617, 33.859116), false), // 26
                new BusCheck(new Vector3(1994.1124, 3835.546, 32.402336), false), // 27
                new BusCheck(new Vector3(1890.446, 3754.7146, 32.575703), true), // 28
                new BusCheck(new Vector3(1682.91, 3630.9783, 35.491344), false), // 29
                new BusCheck(new Vector3(1679.1803, 3533.8345, 35.753876), false), // 30
                new BusCheck(new Vector3(1862.7921, 3224.7935, 45.251156), false), // 31
                new BusCheck(new Vector3(2047.3595, 3059.8374, 46.53033), false), // 32
                new BusCheck(new Vector3(1687.9933, 2875.4792, 43.159782), false), // 33
                new BusCheck(new Vector3(1687.9933, 2875.4792, 43.159782), false), // 34
                new BusCheck(new Vector3(1107.0427, 2692.2207, 38.65585), true), // 35
                new BusCheck(new Vector3(882.5467, 2700.3083, 40.925), false), // 36
                new BusCheck(new Vector3(502.95132, 2685.8867, 42.86264), false), // 37
                new BusCheck(new Vector3(104.52303, 2702.38, 53.394993), false), // 38
                new BusCheck(new Vector3(-112.524445, 2839.717, 51.093063), false), // 39
                new BusCheck(new Vector3(-395.0252, 2870.454, 40.266068), false), // 40
                new BusCheck(new Vector3(-939.4868, 2758.3682, 25.242502), false), // 41
                new BusCheck(new Vector3(-1135.5762, 2658.9539, 17.341106), true), // 42
                new BusCheck(new Vector3(-1618.2854, 2421.8643, 26.310083), false), // 43
                new BusCheck(new Vector3(-2276.9814, 2265.8333, 32.907326), false), // 44
                new BusCheck(new Vector3(-2689.8652, 2287.1516, 20.055618), false), // 45
                new BusCheck(new Vector3(-3012.2544, 1952.6118, 29.346706), false), // 46
                new BusCheck(new Vector3(-3093.4182, 1335.1218, 20.328548), false), // 47
                new BusCheck(new Vector3(-3161.4316, 991.6864, 16.413155), false), // 48
                new BusCheck(new Vector3(-3034.2727, 694.68475, 23.02685), false), // 49
                new BusCheck(new Vector3(-2842.3794, 47.296234, 14.590558), false), // 50
                new BusCheck(new Vector3(-2245.9783, -351.32913, 13.4927), false), // 51
                
            },
            new List<BusCheck>() // busway6
            {
                new BusCheck(new Vector3(-2194.7366, -372.26367, 13.274414), false), // 1
                new BusCheck(new Vector3(-2142.357, -367.42242, 13.178695), false), // 2
                new BusCheck(new Vector3(-1848.1344, -583.6207, 11.597867), false), // 3
                new BusCheck(new Vector3(-1618.3676, -747.92944, 11.519567), false), // 4
                new BusCheck(new Vector3(-1075.3773, -629.6275, 16.471981), false), // 5
                new BusCheck(new Vector3(-844.55566, -557.34076, 22.66486), false), // 6
                new BusCheck(new Vector3(-660.64136, -560.08966, 34.79159), false), // 7
                new BusCheck(new Vector3(-641.1154, -634.5239, 32.138405), false), // 8
                new BusCheck(new Vector3(-340.5553, -666.082, 32.26873), false), // 9
                new BusCheck(new Vector3(227.10289, -854.4704, 30.036442), true), // 10
                new BusCheck(new Vector3(450.9083, -859.52765, 33.652924), false), // 11
                new BusCheck(new Vector3(1129.0404, -843.921, 53.82794), false), // 12
                new BusCheck(new Vector3(1181.8799, -532.7369, 64.88826), false), // 13
                new BusCheck(new Vector3(713.6039, -3.0909858, 84.00817), false), // 14
                new BusCheck(new Vector3(427.0218, 127.60469, 100.61613), true), // 15
                new BusCheck(new Vector3(238.71793, 191.65956, 105.318794), false), // 16
                new BusCheck(new Vector3(-402.59943, 251.64067, 83.29293), true), // 17
                new BusCheck(new Vector3(-835.4923, 228.89041, 74.01578), false), // 18
                new BusCheck(new Vector3(-1195.6919, 252.29968, 67.87797), false), // 19
                new BusCheck(new Vector3(-1443.2391, 61.303654, 52.441517), false), // 20
                new BusCheck(new Vector3(-1476.3832, -96.72469, 50.920456), false), // 21
                new BusCheck(new Vector3(-1676.4113, -337.60117, 49.106537), true), // 22
                new BusCheck(new Vector3(-1834.7935, -251.35571, 40.688053), false), // 23
                new BusCheck(new Vector3(-2172.655, -310.8095, 12.9656315), false), // 24
            },
        };

        #region BusStations
        private static Dictionary<string, Vector3> BusStations = new Dictionary<string, Vector3>()
        {
            { "LSPD", new Vector3(394.8946, -990.8792, 30.60689) },
            { "Hauptplatz", new Vector3(-528.8386, -328.6082, 36.34783) },
            { "FIB", new Vector3(-1621.519, -532.9644, 35.70459) },
            { "Westliches Ghetto", new Vector3(19.75618, -1533.853, 30.54906) },
            { "Flughafen", new Vector3(-1032.82, -2723.92, 14.99705) },
            { "Hotel am Flughafen", new Vector3(-888.1733, -2186.11, 9.900888) },
            { "Fahrschule", new Vector3(-663.498, -1244.046, 11.90458) },
            { "Rasenmäher Job", new Vector3(-1354.111, -43.5153, 52.53339) },
            { "Kraftwerk", new Vector3(740.4898, 100.5469, 81.29053) },
            { "Taxi Park", new Vector3(918.1192, -188.8451, 74.84467) },
            { "Lkw-Haltestelle", new Vector3(602.8403, -3018.18, 6.131153) },
            { "östliches Ghetto", new Vector3(837.6479, -1807.675, 29.10327) },
            { "Parkplatz für die Kollektoren", new Vector3(807.4769, -1195.802, 27.39124) },
            { "Mechaniker-Dock", new Vector3(449.7962, -1249.931, 30.22602) },
            { "Chu-Masch", new Vector3(-3104.435, 1097.097, 20.59407) },
            { "Paletto-Bucht", new Vector3(-151.3444, 6211.825, 31.31864) },
            { "Sandy Shores", new Vector3(1856.94, 3669.111, 34.11074) },
        };
        #endregion

        [ServerEvent(Event.ResourceStart)]
        public void onResourceStartHandler()
        {
            try
            {
                for (int a = 0; a < BusWays.Count; a++)
                {
                    for (int x = 0; x < BusWays[a].Count; x++)
                    {
                        var col = NAPI.ColShape.CreateCylinderColShape(BusWays[a][x].Pos, 4, 3, 0);
                        col.OnEntityEnterColShape += busCheckpointEnterWay;
                        col.SetData("WORKWAY", a);
                        col.SetData("NUMBER", x);
                    }
                }

                foreach (var station in BusStations)
                    NAPI.TextLabel.CreateTextLabel($"", station.Value, 30f, 0.4f, 0, new Color(255, 255, 255), true, NAPI.GlobalDimension);// 16_08_20 ~w~Автобусная остановка\n~b~{station.Key}

            }
            catch (Exception e) { Log.Write("ResourceStart: " + e.Message, nLog.Type.Error); }
        }

        public static List<CarInfo> CarInfos = new List<CarInfo>();
        public static void busCarsSpawner()
        {
            // создаём автобусы
            for (int a = 0; a < CarInfos.Count; a++)
            {
                var veh = NAPI.Vehicle.CreateVehicle(CarInfos[a].Model, CarInfos[a].Position, CarInfos[a].Rotation.Z, CarInfos[a].Color1, CarInfos[a].Color2, CarInfos[a].Number);
                Core.VehicleStreaming.SetEngineState(veh, false);
                NAPI.Data.SetEntityData(veh, "ACCESS", "WORK");
                NAPI.Data.SetEntityData(veh, "WORK", 4);
                NAPI.Data.SetEntityData(veh, "TYPE", "BUS");
                NAPI.Data.SetEntityData(veh, "NUMBER", a);
                NAPI.Data.SetEntityData(veh, "ON_WORK", false);
                NAPI.Data.SetEntityData(veh, "DRIVER", null);
                veh.SetSharedData("PETROL", VehicleManager.VehicleTank[veh.Class]); //Shared
            }
        }

        public static void onPlayerDissconnectedHandler(Player player, DisconnectionType type, string reason)
        {
            try
            {
                if (!Main.Players.ContainsKey(player)) return;
                if (Main.Players[player].WorkID == 4 &&
                    NAPI.Data.GetEntityData(player, "WORK") != null)
                {
                    var vehicle = NAPI.Data.GetEntityData(player, "WORK");
                    respawnBusCar(vehicle);
                }
            }
            catch (Exception e) { Log.Write("PlayerDisconnected: " + e.Message, nLog.Type.Error); }
        }

        public static void respawnBusCar(Vehicle veh)
        {
            try
            {
                int i = NAPI.Data.GetEntityData(veh, "NUMBER");

                NAPI.Entity.SetEntityPosition(veh, CarInfos[i].Position);
                NAPI.Entity.SetEntityRotation(veh, CarInfos[i].Rotation);
                VehicleManager.RepairCar(veh);
                Core.VehicleStreaming.SetEngineState(veh, false);
                Core.VehicleStreaming.SetLockStatus(veh, false);
                NAPI.Data.SetEntityData(veh, "WORK", 4);
                NAPI.Data.SetEntityData(veh, "TYPE", "BUS");
                NAPI.Data.SetEntityData(veh, "NUMBER", i);
                NAPI.Data.SetEntityData(veh, "ON_WORK", false);
                NAPI.Data.SetEntityData(veh, "ACCESS", "WORK");
                NAPI.Data.SetEntityData(veh, "DRIVER", null);
                veh.SetSharedData("PETROL", VehicleManager.VehicleTank[veh.Class]); //Shared
            }
            catch (Exception e) { Log.Write("respawnBusCar: " + e.Message, nLog.Type.Error); }
        }

        public static Vector3 GetNearestStation(Vector3 position)
        {
            Vector3 station = BusStations["LSPD"];
            foreach (var pos in BusStations.Values)
            {
                if (position.DistanceTo(pos) < position.DistanceTo(station))
                    station = pos;
            }
            return station;
        }

        #region BusWays

        private static void busCheckpointEnterWay(ColShape shape, Player player)
        {
            try
            {
                if (!NAPI.Player.IsPlayerInAnyVehicle(player)) return;
                var vehicle = player.Vehicle;
                if (NAPI.Data.GetEntityData(vehicle, "TYPE") != "BUS") return;
                if (Main.Players[player].WorkID != 4 || !player.GetData<bool>("ON_WORK") || player.GetData<int>("WORKWAY") != shape.GetData<int>("WORKWAY")) return;
                var way = player.GetData<int>("WORKWAY");

                if (shape.GetData<int>("NUMBER") != player.GetData<int>("WORKCHECK")) return;
                var check = NAPI.Data.GetEntityData(player, "WORKCHECK");

                if (player.GetData<bool>("BUS_ONSTOP") == true) return;
                if (!BusWays[way][check].IsStop)
                {


                    foreach (var p in Main.GetPlayersInRadiusOfPosition(player.Position, 30))
                        p.SendChatMessage("!{#3ADF00} CheckPoint true ");



                    if (NAPI.Data.GetEntityData(player, "WORKCHECK") != check) return;
                    if (check + 1 != BusWays[way].Count) check++;
                    else check = 0;

                    var direction = (check + 1 != BusWays[way].Count) ? BusWays[way][check + 1].Pos - new Vector3(0, 0, 0.12) : BusWays[way][0].Pos - new Vector3(0, 0, 1.12);
                    var color = (BusWays[way][check].IsStop) ? new Color(255, 255, 255) : new Color(255, 0, 0);
                    Trigger.ClientEvent(player, "createCheckpoint", 3, 1, BusWays[way][check].Pos - new Vector3(0, 0, 1.12), 4, 0, color.Red, color.Green, color.Blue, direction);
                    Trigger.ClientEvent(player, "createWaypoint", BusWays[way][check].Pos.X, BusWays[way][check].Pos.Y);
                    Trigger.ClientEvent(player, "createWorkBlip", BusWays[way][check].Pos);

                    NAPI.Data.SetEntityData(player, "WORKCHECK", check);
                    var payment = Convert.ToInt32(BuswaysPayments[way] * Group.GroupPayAdd[Main.Accounts[player].VipLvl] * Main.oldconfig.PaydayMultiplier);
                    //NAPI.Data.SetEntityData(player, "PAYMENT", NAPI.Data.GetEntityData(player, "PAYMENT") + payment);
                    MoneySystem.Wallet.Change(player, payment);
                    GameLog.Money($"server", $"player({Main.Players[player].UUID})", payment, $"busCheck");
                }
                else
                {
                    if (NAPI.Data.GetEntityData(player, "WORKCHECK") != check) return;
                    Trigger.ClientEvent(player, "deleteCheckpoint", 3, 0);
                    Trigger.ClientEvent(player, "deleteWorkBlip");

                    NAPI.Data.SetEntityData(player, "BUS_ONSTOP", true);
                    Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Anhalten. Nach 10 Sekunden kannst du deine Route fortsetzen", 3000);
                    player.SetData("BUS_TIMER", Timers.StartOnce(10000, () => timer_busStop(player, way, check)));

                    foreach (var p in Main.GetPlayersInRadiusOfPosition(player.Position, 30))
                        p.SendChatMessage("!{#3ADF00}In 10 Sekunden fährt ein Bus ab." + BusWaysNames[way]);
                }
            }
            catch (Exception ex) { Log.Write("busCheckpointEnterWay: " + ex.Message, nLog.Type.Error); }
        }

        private static void timer_busStop(Player player, int way, int check)
        {
            NAPI.Task.Run(() =>
            {
                try
                {
                    NAPI.Data.SetEntityData(player, "BUS_ONSTOP", false);
                    Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Du kannst weiterfahren", 3000);
                    var payment = Convert.ToInt32(BuswaysPayments[way] * Group.GroupPayAdd[Main.Accounts[player].VipLvl] * Main.oldconfig.PaydayMultiplier);
                    //NAPI.Data.SetEntityData(player, "PAYMENT", NAPI.Data.GetEntityData(player, "PAYMENT") + payment);
                    MoneySystem.Wallet.Change(player, payment);
                    GameLog.Money($"server", $"player({Main.Players[player].UUID})", payment, $"busCheck");
                    if (check + 1 != BusWays[way].Count) check++;
                    else check = 0;

                    var direction = (check + 1 < BusWays[way].Count) ? BusWays[way][check + 1].Pos - new Vector3(0, 0, 0.12) : BusWays[way][0].Pos - new Vector3(0, 0, 1.12);
                    var color = (BusWays[way][check].IsStop) ? new Color(255, 255, 255) : new Color(255, 0, 0);
                    NAPI.ClientEvent.TriggerClientEvent(player, "createCheckpoint", 3, 1, BusWays[way][check].Pos - new Vector3(0, 0, 1.12), 4, 0, color.Red, color.Green, color.Blue, direction);
                    NAPI.ClientEvent.TriggerClientEvent(player, "createWaypoint", BusWays[way][check].Pos.X, BusWays[way][check].Pos.Y);
                    NAPI.ClientEvent.TriggerClientEvent(player, "createWorkBlip", BusWays[way][check].Pos);

                    player.SetData("WORKCHECK", check);
                    //Main.StopT(player.GetData("BUS_TIMER"), "timer_23");
                    Timers.Stop(player.GetData<string>("BUS_TIMER"));
                    player.ResetData("BUS_TIMER");

                    foreach (var p in Main.GetPlayersInRadiusOfPosition(player.Position, 30))
                        p.SendChatMessage("!{#3ADF00}Der Bus fährt auf der Strecke " + BusWaysNames[way]);
                }
                catch (Exception e)
                {
                    Log.Write("EXCEPTION AT \"TIMER_BUS_STOP\":\n" + e.ToString(), nLog.Type.Error);
                }
            });
        }
        #endregion

        [ServerEvent(Event.PlayerExitVehicle)]
        public void onPlayerExitVehicleHandler(Player player, Vehicle vehicle)
        {
            try
            {
                if (NAPI.Data.GetEntityData(vehicle, "TYPE") == "BUS" &&
                    Main.Players[player].WorkID == 4 &&
                    NAPI.Data.GetEntityData(player, "ON_WORK") &&
                    NAPI.Data.GetEntityData(player, "WORK") == vehicle)
                {
                    Notify.Send(player, NotifyType.Warning, NotifyPosition.MapUp, $"Wenn du dich nicht innerhalb von 60 Sekunden in das Fahrzeug begibst, ist der Arbeitstag vorbei", 3000);
                    NAPI.Data.SetEntityData(player, "IN_WORK_CAR", false);
                    if (player.HasData("WORK_CAR_EXIT_TIMER"))
                        //Main.StopT(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"), "timer_24");
                        Timers.Stop(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"));
                    NAPI.Data.SetEntityData(player, "CAR_EXIT_TIMER_COUNT", 0);
                    //NAPI.Data.SetEntityData(player, "WORK_CAR_EXIT_TIMER", Main.StartT(1000, 1000, (o) => timer_playerExitWorkVehicle(player, vehicle), "BUS_EXIT_CAR_TIMER"));
                    NAPI.Data.SetEntityData(player, "WORK_CAR_EXIT_TIMER", Timers.Start(1000, () => timer_playerExitWorkVehicle(player, vehicle)));
                }
            }
            catch (Exception e) { Log.Write("PlayerExitVehicle: " + e.Message, nLog.Type.Error); }
        }

        private void timer_playerExitWorkVehicle(Player player, Vehicle vehicle)
        {
            NAPI.Task.Run(() =>
            {
                try
                {
                    if (!player.HasData("WORK_CAR_EXIT_TIMER")) return;
                    if (NAPI.Data.GetEntityData(player, "IN_WORK_CAR"))
                    {
                        //Main.StopT(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"), "timer_25");
                        Timers.Stop(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"));
                        NAPI.Data.ResetEntityData(player, "WORK_CAR_EXIT_TIMER");
                        return;
                    }
                    if (NAPI.Data.GetEntityData(player, "CAR_EXIT_TIMER_COUNT") > 60)
                    {
                        respawnBusCar(vehicle);
                        
                        NAPI.Data.SetEntityData(player, "ON_WORK", false);
                        NAPI.Data.SetEntityData(player, "WORK", null);
                        Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Du bist für den Tag fertig", 3000);
                        Trigger.ClientEvent(player, "deleteCheckpoint", 3, 0);
                        Trigger.ClientEvent(player, "deleteWorkBlip");

                        //Main.StopT(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"), "timer_26");
                        Timers.Stop(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"));
                        NAPI.Data.ResetEntityData(player, "WORK_CAR_EXIT_TIMER");
                        Main.Players[player].WorkID = 0;
                        player.SetData("PAYMENT", 0);
                        return;
                    }
                    NAPI.Data.SetEntityData(player, "CAR_EXIT_TIMER_COUNT", NAPI.Data.GetEntityData(player, "CAR_EXIT_TIMER_COUNT") + 1);
                    

                }

                catch (Exception e)
                {
                    Log.Write("Timer_PlayerExitWorkVehicle:\n" + e.ToString(), nLog.Type.Error);
                }
            });
        }

        [ServerEvent(Event.PlayerEnterVehicle)]
        public void onPlayerEnterVehicleHandler(Player player, Vehicle vehicle, sbyte seatid)
        {
            try
            {
                Main.Players[player].WorkID = 4;
                if (NAPI.Data.GetEntityData(vehicle, "TYPE") != "BUS") return;
                if (player.VehicleSeat == 0)
                {
                    if (!Main.Players[player].Licenses[2])
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du besitzt keine Lizenz der Kategorie C", 3000);
                        VehicleManager.WarpPlayerOutOfVehicle(player);
                        return;
                    }
                    if (Main.Players[player].WorkID == 4)
                    {
                        if (vehicle.GetData<Player>("DRIVER") == null)
                        {
                            if (player.GetData<string>("WORK") == null)
                            {
                                if (Main.Players[player].Money >= BusRentCost)
                                {
                                    Trigger.ClientEvent(player, "openDialog", "BUS_RENT", $"Miete den Bus für ${BusRentCost}?");
                                }
                                else
                                {
                                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast nicht genug " + (BusRentCost - Main.Players[player].Money) + "$ für eine Miete", 3000);
                                    VehicleManager.WarpPlayerOutOfVehicle(player);
                                }
                            }
                            else
                                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast bereits einen Bus gemietet", 3000);
                        }
                        else
                        {
                            if (NAPI.Data.GetEntityData(player, "WORK") != vehicle)
                            {
                                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Bus hat bereits einen Fahrer", 3000);
                                VehicleManager.WarpPlayerOutOfVehicle(player);
                            }
                            else
                                NAPI.Data.SetEntityData(player, "IN_WORK_CAR", true);
                        }
                    }
                    else
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du arbeitest nicht als Busfahrer, du kannst dir einen Job bei der Arbeitsargentur besorgen", 3000);
                        VehicleManager.WarpPlayerOutOfVehicle(player);
                    }
                }
                else
                {
                    if (NAPI.Data.GetEntityData(vehicle, "ON_WORK"))
                    {
                        var price = 30;
                        if (Main.Players[player].Money >= price)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Sie haben Ihr Fahrgeld bezahlt {price}$", 3000);
                            MoneySystem.Wallet.Change(player, -price);
                            Fractions.Stocks.fracStocks[6].Money += price;
                            GameLog.Money($"player({Main.Players[player].UUID})", $"frac(6)", price, $"busPay");
                        }
                        else
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast nicht genug Geld, um den Fahrpreis zu zahlen", 3000);
                            VehicleManager.WarpPlayerOutOfVehicle(player);
                        }
                    }
                    else
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Fahrer ist gerade nicht im Bus", 3000);
                        VehicleManager.WarpPlayerOutOfVehicle(player);
                    }
                }
            }
            catch (Exception e) { Log.Write("PlayerEnterVehicle: " + e.Message, nLog.Type.Error); }

        }

        public static void acceptBusRent(Player player)
        {
            if (NAPI.Player.IsPlayerInAnyVehicle(player) && player.VehicleSeat == 0 && player.Vehicle.GetData<string>("TYPE") == "BUS")
            {
                var ways = new Dictionary<int, int>
                        {
                            { 0, 0 },
                            { 1, 0 },
                            { 2, 0 },
                            { 3, 0 },
                            { 4, 0 },
                            { 5, 0 }
                        };
                foreach (var p in NAPI.Pools.GetAllPlayers())
                {
                    if (!Main.Players.ContainsKey(p)) continue;
                    if (Main.Players[p].WorkID != 4 || !p.GetData<bool>("ON_WORK")) continue;
                    ways[p.GetData<int>("WORKWAY")]++;
                }

                var way = -1;
                for (int i = 0; i < ways.Count; i++)
                    if (ways[i] == 0)
                    {
                        way = i;
                        break;
                    }
                if (way == -1)
                {
                    for (int i = 0; i < ways.Count; i++)
                        if (ways[i] == 1)
                        {
                            way = i;
                            break;
                        }
                }
                if (way == -1) way = 0;

                var vehicle = player.Vehicle;
                NAPI.Data.SetEntityData(player, "IN_WORK_CAR", true);
                NAPI.Data.SetEntityData(player, "ON_WORK", true);
                MoneySystem.Wallet.Change(player, -BusRentCost);
                GameLog.Money($"player({Main.Players[player].UUID})", $"server", BusRentCost, $"busRent");

                Core.VehicleStreaming.SetEngineState(vehicle, true);
                NAPI.Data.SetEntityData(vehicle, "DRIVER", player);
                NAPI.Data.SetEntityData(vehicle, "ON_WORK", true);
                NAPI.Data.SetEntityData(vehicle, "DRIVER", player);

                NAPI.Data.SetEntityData(player, "WORKWAY", way);
                NAPI.Data.SetEntityData(player, "WORKCHECK", 0);
                Trigger.ClientEvent(player, "createCheckpoint", 3, 1, BusWays[way][0].Pos - new Vector3(0, 0, 1.12), 4, 0, 255, 0, 0, BusWays[way][1].Pos - new Vector3(0, 0, 1.12));
                Trigger.ClientEvent(player, "createWaypoint", BusWays[way][0].Pos.X, BusWays[way][0].Pos.Y);
                Trigger.ClientEvent(player, "createWorkBlip", BusWays[way][0].Pos);

                Main.Players[player].WorkID = 4;

                NAPI.Data.SetEntityData(player, "WORK", vehicle);

                //BasicSync.AttachLabelToObject("~y~" + BusWaysNames[way] + "\n~w~Проезд: ~g~15$", new Vector3(0, 0, 1.5), vehicle);
                Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Du hast den Bus gemietet, dir wurde eine Route zugewiesen {BusWaysNames[way]}", 3000);
            }
            else
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du musst im Bus sein", 3000);
            }
        }

        internal class BusCheck
        {
            public Vector3 Pos { get; }
            public bool IsStop { get; }

            public BusCheck(Vector3 pos, bool isStop = false)
            {
                Pos = pos;
                IsStop = isStop;
            }
        }
    }
}
