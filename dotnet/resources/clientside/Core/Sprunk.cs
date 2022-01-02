using GTANetworkAPI;
using UNL.SDK;
using System;
using System.Collections.Generic;

namespace ULife.Core
{
    class Sprunk : Script
    {
        private static nLog Log = new nLog("Sprunk");

        public class SprunkPoint
        {
            public string name;
            public ItemType item;
            public int price;
            public Vector3 position;

            public SprunkPoint(string name, ItemType item, int price, Vector3 position)
            {
                this.name = name;
                this.item = item;
                this.price = price;
                this.position = position;
            }

            public void use(Player player)
            {
                // Check money and price
                if (Main.Players[player].Money < this.price)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Nicht genug Geld", 3000);
                }
                else
                {
                    // Give item
                    //player.PlayAnimation(
                    //    "amb@prop_human_movie_bulb@base",
                    //    "base",
                    //    1
                    //);
                    //player.FreezePosition = true;
                    NAPI.Task.Run(() =>
                    {
                        MoneySystem.Wallet.Change(player, -this.price);
                        
                        nInventory.Add(player, new nItem(this.item, 1));
                        //NAPI.Player.PlaySoundFrontEnd(player, "PROPERTY_PURCHASE", "HUD_AWARDS");
                        
                        player.StopAnimation();
                        //player.FreezePosition = false;
                    }, 3000);
                    Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, "Du hast 1x " + this.name + " gekauft", 3000);
                }
            }
        }

        public List<SprunkPoint> points = new List<SprunkPoint>()
        {
            //Sprunk
            new SprunkPoint("Sprunk", ItemType.Sprunk, 10, new Vector3(-936.1364, -2346.5886, -0.23213412)),
            new SprunkPoint("Sprunk", ItemType.Sprunk, 10, new Vector3(-269.76718, -2022.7058, 30.145603)),
            new SprunkPoint("Sprunk", ItemType.Sprunk, 10, new Vector3(-1231.477, -1448.3748, 4.27113)),
            new SprunkPoint("Sprunk", ItemType.Sprunk, 10, new Vector3(-1269.999, -1427.0697, 4.3516936)),
            new SprunkPoint("Sprunk", ItemType.Sprunk, 10, new Vector3(-1711.2877, -1133-2372, 13.129549)),
            new SprunkPoint("Sprunk", ItemType.Sprunk, 10, new Vector3(-1269.999, -1427.0697, 4.3516936)),
            new SprunkPoint("Sprunk", ItemType.Sprunk, 10, new Vector3(-1711.2877, -1133-2372, 13.129549)),
            new SprunkPoint("Sprunk", ItemType.Sprunk, 10, new Vector3(-1696.003, -1127.5222, 13.152284)),
            new SprunkPoint("Sprunk", ItemType.Sprunk, 10, new Vector3(-433.37946, -353.03668, 34.910706)),
            new SprunkPoint("Sprunk", ItemType.Sprunk, 10, new Vector3(-33.4762, -783.36536, 33.964474)),
            new SprunkPoint("Sprunk", ItemType.Sprunk, 10, new Vector3(-328.10498, -737.578, 38.779938)),
            new SprunkPoint("Sprunk", ItemType.Sprunk, 10, new Vector3(-33.55203, -783.0521, 43.60603)),
            new SprunkPoint("Sprunk", ItemType.Sprunk, 10, new Vector3(829.7812, -1288.1079, 24.320343)),
            new SprunkPoint("Sprunk", ItemType.Sprunk, 10, new Vector3(846.6553, -1285.4288, 28.233168)),
            new SprunkPoint("Sprunk", ItemType.Sprunk, 10, new Vector3(111.5206, -141.4898, 54.862675)),
            new SprunkPoint("Sprunk", ItemType.Sprunk, 10, new Vector3(190.82176, -920.64404, 31.194414)),
            new SprunkPoint("Sprunk", ItemType.Sprunk, 10, new Vector3(-1099.386, -822.9471, 19.00144)),
            new SprunkPoint("Sprunk", ItemType.Sprunk, 10, new Vector3(-433.39197, -342.54688, 34.910736)),
            new SprunkPoint("Sprunk", ItemType.Sprunk, 10, new Vector3(190.46605, -920.5409, 31.1944)),
            new SprunkPoint("Sprunk", ItemType.Sprunk, 10, new Vector3(-1086.3130, -2846.4707, 27.509670)),
            new SprunkPoint("Sprunk", ItemType.Sprunk, 10, new Vector3(-1107.8572, -2834.0480, 27.509665)),
            new SprunkPoint("Sprunk", ItemType.Sprunk, 10, new Vector3(-1086.2275, -2764.2556, 21.313736)),
            new SprunkPoint("Sprunk", ItemType.Sprunk, 10, new Vector3(-1054.0880, -2782.0880, 21.314468)),
            new SprunkPoint("Sprunk", ItemType.Sprunk, 10, new Vector3(-1027.2678, -2797.6775, 21.314457)),
            new SprunkPoint("Sprunk", ItemType.Sprunk, 10, new Vector3(-1022.4550, -2790.0300, 26.314419)),
            new SprunkPoint("Sprunk", ItemType.Sprunk, 10, new Vector3(-1058.6432, -2777.6836, 26.314432)),
            new SprunkPoint("Sprunk", ItemType.Sprunk, 10, new Vector3(-1020.0403, -2785.7488, 26.316580)),
            new SprunkPoint("Sprunk", ItemType.Sprunk, 10, new Vector3(-1033.4978, -2770.3032, 21.314460)),
            //Cola
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(-1099.969, -2735.4204, -7.4101315)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(-1067.2039, -2696.451, -7.4100733)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(-934.6264, -2346.2375, -0.21396002)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(-274.94492, -2041.5867, 30.14558)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(-246.66927, -2002.9303, 30.145588)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(-1123.3821, -1644.1195, 4.6627707)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(-1193.8798, -1623.5393, 4.4057665)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(-1147.9844, -1600.9502, 4.3901796)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(-1171, -1574.4774, 4.6636276)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(-1230.3081, -1447.6406, 4.269686)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(-1251.3008, -1450.5436, 4.349799)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(-1268.9977, -1428.5072, 4.3516765)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(-1692.2751, -1088.1544, 13.152965)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(-1709.7522, -1134.0586, 13.138564)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(-1695.0415, -1125.9297, 13.152284)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(-433.20395, -341.65308, 34.910713)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(-795.13947, -126.32495, 19.950338)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(-839.8246, -151.6606, 19.950348)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(-325.46262, 738.6419, 33.964134)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(-310.07968, -739.3915, 33.964592)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(-334.77408, -784.99963, 38.779793)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(-325.61652, -738.4981, 43.604954)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(475.9441, -1003.0916, 25.729696)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(471.10123, -993.08856, 30.689327)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(446.97482, -980.702, 30.689342)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(471.54544, -996.1666, 34.217045)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(829.921, -1289.456, 24.320343)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(848.24615, -1285.5114, 28.233168)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(-596.6732, -932.3948, 23.877567)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(-588.4121, -915.0299, 23.877562)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(192.1471, -920.93005, 31.193632)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(19.776087, -1114.1554, 29.797039)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(470.76224, -993.2083, 30.689337)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(446.76385, -980.7372, 30.689)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(471.37964, -996.2898, 34.217)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(-433.13602, -341.57516, 34.91073)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(191.94252, -921.346, 31.19421)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(-1032.3956, -2771.0742, 21.31446)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(-1021.5092, -2785.0068, 26.316504)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(-1059.7554, -2779.5117, 26.314432)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(-1027.9279, -2798.9546, 21.314455)),
            new SprunkPoint("eCola", ItemType.eCola, 9, new Vector3(-1054.786, -2783.1318, 21.314468)),
            //Coffee
            new SprunkPoint("Kaffee", ItemType.Kaffee, 15, new Vector3(-1074.8394, -2735.388, 0.8148941)),
            new SprunkPoint("Kaffee", ItemType.Kaffee, 15, new Vector3(446.4358, -979.4675, 30.68934)),
            new SprunkPoint("Kaffee", ItemType.Kaffee, 15, new Vector3(444.7758, -997.60095, 30.689331)),
            new SprunkPoint("Kaffee", ItemType.Kaffee, 15, new Vector3(437.30795, -987.47296, 30.689331)),
            new SprunkPoint("Kaffee", ItemType.Kaffee, 15, new Vector3(444.22256, -988.59827, 34.18719)),
            new SprunkPoint("Kaffee", ItemType.Kaffee, 15, new Vector3(474.22852, -984.9667, 34.21704)),
            new SprunkPoint("Kaffee", ItemType.Kaffee, 15, new Vector3(845.69226, -1298.0138, 24.320353)),
            new SprunkPoint("Kaffee", ItemType.Kaffee, 15, new Vector3(-536.6172, -182.91388, 38.20831)),
            new SprunkPoint("Kaffee", ItemType.Kaffee, 15, new Vector3(-819.10315, -117.47055, 28.175356)),
            new SprunkPoint("Kaffee", ItemType.Kaffee, 15, new Vector3(481.22562, -990.87384, 30.689354)),
            new SprunkPoint("Kaffee", ItemType.Kaffee, 15, new Vector3(469.09998, -990.79803, 30.689327)),
            new SprunkPoint("Kaffee", ItemType.Kaffee, 15, new Vector3(446.4358, -979.4675, 30.68934)),
            new SprunkPoint("Kaffee", ItemType.Kaffee, 15, new Vector3(444.7758, -997.60095, 30.689331)),
            new SprunkPoint("Kaffee", ItemType.Kaffee, 15, new Vector3(437.30795, -987.47296, 30.689331)),
            new SprunkPoint("Kaffee", ItemType.Kaffee, 15, new Vector3(444.22256, -988.59827, 34.18719)),
            new SprunkPoint("Kaffee", ItemType.Kaffee, 15, new Vector3(474.22852, -984.9667, 34.21704)),
            new SprunkPoint("Kaffee", ItemType.Kaffee, 15, new Vector3(845.69226, -1298.0138, 24.320353)),
            new SprunkPoint("Kaffee", ItemType.Kaffee, 15, new Vector3(835.9324, -1309.0038, 28.233177)),
            new SprunkPoint("Kaffee", ItemType.Kaffee, 15, new Vector3(829.2195, -1281.9755, 28.233181)),
            new SprunkPoint("Kaffee", ItemType.Kaffee, 15, new Vector3(144.1529, -167.54977, 60.48838)),
            new SprunkPoint("Kaffee", ItemType.Kaffee, 15, new Vector3(141.7658, -159.25124, 60.48837)),
            new SprunkPoint("Kaffee", ItemType.Kaffee, 15, new Vector3(134.64566, -163.9636, 60.48842)),
            new SprunkPoint("Kaffee", ItemType.Kaffee, 15, new Vector3(113.29323, -139.26451, 60.48834)),
            new SprunkPoint("Kaffee", ItemType.Kaffee, 15, new Vector3(-71.650894, 78.31038, 71.61299)),
            new SprunkPoint("Kaffee", ItemType.Kaffee, 15, new Vector3(469.00436, -990.8109, 30.6896)),
            new SprunkPoint("Kaffee", ItemType.Kaffee, 15, new Vector3(446.46277, -979.6431, 30.689)),
            new SprunkPoint("Kaffee", ItemType.Kaffee, 15, new Vector3(444.61047, -997.6082, 30.689)),
            new SprunkPoint("Kaffee", ItemType.Kaffee, 15, new Vector3(437.29495, -987.56134, 30.689)),
            new SprunkPoint("Kaffee", ItemType.Kaffee, 15, new Vector3(474.45584, -984.9653, 34.217)),
            new SprunkPoint("Kaffee", ItemType.Kaffee, 15, new Vector3(-1108.3245, -2834.7952, 27.510933)),
            new SprunkPoint("Kaffee", ItemType.Kaffee, 15, new Vector3(-1086.6567, -2847.2993, 27.510946)),
            //Donut
            new SprunkPoint("Donut", ItemType.Donut, 19, new Vector3(-1085.1665, -2763.4265, 21.313366)),
            //Water
            new SprunkPoint("Wasser", ItemType.Wasser, 4, new Vector3(952.1473, -114.9885, 75.0116)),
            new SprunkPoint("Wasser", ItemType.Wasser, 4, new Vector3(-1062.5597, -2792.3115, 21.314455)),
            new SprunkPoint("Wasser", ItemType.Wasser, 4, new Vector3(-1059.0237, -2786.2573, 21.314455)),
            new SprunkPoint("Wasser", ItemType.Wasser, 4, new Vector3(-1091.9708, -2802.1428, 21.314459)),
            new SprunkPoint("Wasser", ItemType.Wasser, 4, new Vector3(-1094.0924, -2801.0227, 21.314434)),
            new SprunkPoint("Wasser", ItemType.Wasser, 4, new Vector3(-1093.9843, -2788.8113, 21.314444)),
            //Chips
            new SprunkPoint("Chips", ItemType.Chips, 4, new Vector3(-937.584, -2346.9294, -0.276783)),
            new SprunkPoint("Chips", ItemType.Chips, 4, new Vector3(-1272.8314, -1423.1914, 4.34982)),
            new SprunkPoint("Chips", ItemType.Chips, 4, new Vector3(-1707.3629, -1135.2545, 13.148634)),
            new SprunkPoint("Chips", ItemType.Chips, 4, new Vector3(-1272.8314, -1423.1914, 4.34982)),
            new SprunkPoint("Chips", ItemType.Chips, 4, new Vector3(-1693.2795, -1123.2241, 13.152284)),
            new SprunkPoint("Chips", ItemType.Chips, 4, new Vector3(-1640.6099, -1073.6294, 13.018517)),
            new SprunkPoint("Chips", ItemType.Chips, 4, new Vector3(-819.8595, -116.04798, 28.175356)),
            new SprunkPoint("Chips", ItemType.Chips, 4, new Vector3(438.59796, -987.7432, 30.689331)),
            new SprunkPoint("Chips", ItemType.Chips, 4, new Vector3(113.91241, -138.11331, 60.48838)),
            new SprunkPoint("Chips", ItemType.Chips, 4, new Vector3(-588.4102, -913.93854, 23.877562)),
            new SprunkPoint("Chips", ItemType.Chips, 4, new Vector3(470.62997, -985.24756, 34.217)),            
            new SprunkPoint("Chips", ItemType.Chips, 4, new Vector3(-1034.7794, -2769.6692, 21.31446)),
            new SprunkPoint("Chips", ItemType.Chips, 4, new Vector3(-1026.6152, -2796.231, 21.314457)),
            new SprunkPoint("Chips", ItemType.Chips, 4, new Vector3(-1053.3021, -2780.9475, 21.314468)),
            new SprunkPoint("Chips", ItemType.Chips, 4, new Vector3(-1109.2397, -2836.6685, 27.513905)),
            new SprunkPoint("Chips", ItemType.Chips, 4, new Vector3(-1087.7227, -2848.8115, 27.513582)),
            //Sandwich
            new SprunkPoint("Sandwich", ItemType.Sandwich, 6, new Vector3(-32.37337, -1670.755, 29.4797)),
            new SprunkPoint("Sandwich", ItemType.Sandwich, 6, new Vector3(-1232.5247, -1449.1398, 4.269394)),
            new SprunkPoint("Sandwich", ItemType.Sandwich, 6, new Vector3(-1199.3945, -1527.7755, 4.3826985)),
            new SprunkPoint("Sandwich", ItemType.Sandwich, 6, new Vector3(-1230.264, -1480.4473, 4.3282075)),
            new SprunkPoint("Sandwich", ItemType.Sandwich, 6, new Vector3(-1707.3629, -1135.2545, 13.148634)),
            new SprunkPoint("Sandwich", ItemType.Sandwich, 6, new Vector3(-432.98288, -340.2569, 34.910732)),
            new SprunkPoint("Sandwich", ItemType.Sandwich, 6, new Vector3(477.4192, -1003.062, 25.729696)),
            new SprunkPoint("Sandwich", ItemType.Sandwich, 6, new Vector3(470.66937, -985.2408, 34.21704)),
            new SprunkPoint("Sandwich", ItemType.Sandwich, 6, new Vector3(-595.32574, -932.4411, 23.877567)),
            new SprunkPoint("Sandwich", ItemType.Sandwich, 6, new Vector3(-32.37337, -1670.755, 29.4797)),
        };


        [RemoteEvent("sprunk:use")]
        public void OnUse(Player c)
        {
            //Log.Write("sprunk use by " + c.Name);
            foreach (SprunkPoint point in points)
            {
                if (c.Position.DistanceTo(point.position) < 1)
                {
                    point.use(c);
                    break;
                }
            }
        }

        [ServerEvent(Event.PlayerSpawn)]
        public void OnPlayerSpawn(Player player)
        {

            Log.Write("Player spawned");

            List<Vector3> positions = new List<Vector3> { };
            foreach (SprunkPoint point in points)
            {
                positions.Add(point.position);
            }

            Log.Write(positions.ToString());

            player.TriggerEvent("sprunk:syncPositions", positions);
        }

    }
}
