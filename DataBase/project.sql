/*
 Navicat Premium Data Transfer

 Source Server         : server
 Source Server Type    : MySQL
 Source Server Version : 100603
 Source Host           : localhost:3306
 Source Schema         : project

 Target Server Type    : MySQL
 Target Server Version : 100603
 File Encoding         : 65001

 Date: 14/12/2021 21:37:05
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for accounts
-- ----------------------------
DROP TABLE IF EXISTS `accounts`;
CREATE TABLE `accounts`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `login` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_bin NOT NULL,
  `email` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `password` varchar(256) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `hwid` varchar(256) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `ip` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `socialclub` varchar(256) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `viplvl` tinyint NULL DEFAULT NULL,
  `vipdate` datetime NULL DEFAULT NULL,
  `promocodes` varchar(128) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `present` tinyint NULL DEFAULT 0,
  `character1` int NULL DEFAULT NULL,
  `character2` int NULL DEFAULT NULL,
  `character3` int NULL DEFAULT NULL,
  `ulife` int NULL DEFAULT NULL,
  `whitelist` tinyint NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `login`(`login`) USING BTREE,
  INDEX `email`(`email`) USING BTREE,
  INDEX `password`(`password`) USING BTREE,
  INDEX `hwid`(`hwid`) USING BTREE,
  INDEX `ip`(`ip`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 93 CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of accounts
-- ----------------------------
INSERT INTO `accounts` VALUES (49, 'TIMATI', 'Timati@tim.de', '96cae35ce8a9b0244178bf28e4966c2ce1b8385723a96a6b838858cdd6ca0a1e', NULL, '127.0.0.1', 'TIMATI', 0, '2020-12-23 12:31:29', '[\"ulife\"]', 1, 853521, 829846, -2, 80, 1);

-- ----------------------------
-- Table structure for adminaccess
-- ----------------------------
DROP TABLE IF EXISTS `adminaccess`;
CREATE TABLE `adminaccess`  (
  `command` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `isadmin` tinyint NOT NULL,
  `minrank` tinyint NOT NULL,
  PRIMARY KEY (`command`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of adminaccess
-- ----------------------------
INSERT INTO `adminaccess` VALUES ('a', 1, 8);
INSERT INTO `adminaccess` VALUES ('addpromo', 1, 8);
INSERT INTO `adminaccess` VALUES ('admins', 1, 7);
INSERT INTO `adminaccess` VALUES ('afuel', 1, 7);
INSERT INTO `adminaccess` VALUES ('agm', 1, 7);
INSERT INTO `adminaccess` VALUES ('allspawncar', 1, 8);
INSERT INTO `adminaccess` VALUES ('armorelp', 1, 7);
INSERT INTO `adminaccess` VALUES ('armorset', 1, 8);
INSERT INTO `adminaccess` VALUES ('ban', 1, 4);
INSERT INTO `adminaccess` VALUES ('checkdim', 1, 7);
INSERT INTO `adminaccess` VALUES ('createbizinfo', 1, 7);
INSERT INTO `adminaccess` VALUES ('createbusiness', 1, 8);
INSERT INTO `adminaccess` VALUES ('createmp', 1, 8);
INSERT INTO `adminaccess` VALUES ('createrod', 1, 8);
INSERT INTO `adminaccess` VALUES ('createsafe', 1, 8);
INSERT INTO `adminaccess` VALUES ('createunloadpoint', 1, 8);
INSERT INTO `adminaccess` VALUES ('delacar', 1, 8);
INSERT INTO `adminaccess` VALUES ('delacars', 1, 7);
INSERT INTO `adminaccess` VALUES ('deladmin', 1, 7);
INSERT INTO `adminaccess` VALUES ('deletebusiness', 1, 8);
INSERT INTO `adminaccess` VALUES ('deljob', 1, 8);
INSERT INTO `adminaccess` VALUES ('delleader', 1, 4);
INSERT INTO `adminaccess` VALUES ('demorgan', 1, 7);
INSERT INTO `adminaccess` VALUES ('fixcar', 1, 4);
INSERT INTO `adminaccess` VALUES ('giveammo', 1, 4);
INSERT INTO `adminaccess` VALUES ('giveexp', 1, 4);
INSERT INTO `adminaccess` VALUES ('givelic', 1, 4);
INSERT INTO `adminaccess` VALUES ('givelost', 1, 7);
INSERT INTO `adminaccess` VALUES ('givemoney', 1, 4);
INSERT INTO `adminaccess` VALUES ('global', 1, 7);
INSERT INTO `adminaccess` VALUES ('gm', 1, 7);
INSERT INTO `adminaccess` VALUES ('guns', 1, 7);
INSERT INTO `adminaccess` VALUES ('hp', 1, 4);
INSERT INTO `adminaccess` VALUES ('id', 1, 8);
INSERT INTO `adminaccess` VALUES ('inv', 1, 7);
INSERT INTO `adminaccess` VALUES ('kick', 1, 7);
INSERT INTO `adminaccess` VALUES ('kill', 1, 4);
INSERT INTO `adminaccess` VALUES ('metp', 1, 7);
INSERT INTO `adminaccess` VALUES ('mpveh', 1, 8);
INSERT INTO `adminaccess` VALUES ('mute', 1, 7);
INSERT INTO `adminaccess` VALUES ('newfracveh', 1, 8);
INSERT INTO `adminaccess` VALUES ('newjobveh', 1, 8);
INSERT INTO `adminaccess` VALUES ('newrentveh', 1, 8);
INSERT INTO `adminaccess` VALUES ('offban', 1, 7);
INSERT INTO `adminaccess` VALUES ('oguns', 1, 7);
INSERT INTO `adminaccess` VALUES ('payday', 1, 8);
INSERT INTO `adminaccess` VALUES ('removesafe', 1, 8);
INSERT INTO `adminaccess` VALUES ('rescar', 1, 7);
INSERT INTO `adminaccess` VALUES ('revive', 1, 7);
INSERT INTO `adminaccess` VALUES ('save', 1, 8);
INSERT INTO `adminaccess` VALUES ('savefveh', 1, 8);
INSERT INTO `adminaccess` VALUES ('savejveh', 1, 8);
INSERT INTO `adminaccess` VALUES ('sendcreator', 1, 8);
INSERT INTO `adminaccess` VALUES ('setadmin', 1, 8);
INSERT INTO `adminaccess` VALUES ('setadminrank', 1, 8);
INSERT INTO `adminaccess` VALUES ('setcolour', 1, 8);
INSERT INTO `adminaccess` VALUES ('setdim', 1, 7);
INSERT INTO `adminaccess` VALUES ('setfracveh', 1, 8);
INSERT INTO `adminaccess` VALUES ('setleader', 1, 4);
INSERT INTO `adminaccess` VALUES ('setproductbyindex', 1, 8);
INSERT INTO `adminaccess` VALUES ('setvehdirt', 1, 8);
INSERT INTO `adminaccess` VALUES ('sp', 1, 8);
INSERT INTO `adminaccess` VALUES ('st', 1, 8);
INSERT INTO `adminaccess` VALUES ('startmp', 1, 5);
INSERT INTO `adminaccess` VALUES ('statebox', 1, 7);
INSERT INTO `adminaccess` VALUES ('stats', 1, 8);
INSERT INTO `adminaccess` VALUES ('stop', 1, 7);
INSERT INTO `adminaccess` VALUES ('stopmp', 1, 5);
INSERT INTO `adminaccess` VALUES ('stt', 1, 4);
INSERT INTO `adminaccess` VALUES ('sw', 1, 8);
INSERT INTO `adminaccess` VALUES ('tp', 1, 4);
INSERT INTO `adminaccess` VALUES ('tpc', 1, 4);
INSERT INTO `adminaccess` VALUES ('vehc', 1, 4);
INSERT INTO `adminaccess` VALUES ('warn', 1, 7);
INSERT INTO `adminaccess` VALUES ('whitelist', 1, 7);

-- ----------------------------
-- Table structure for advertised
-- ----------------------------
DROP TABLE IF EXISTS `advertised`;
CREATE TABLE `advertised`  (
  `ID` int UNSIGNED NOT NULL AUTO_INCREMENT,
  `Author` varchar(40) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `AuthorSIM` int NOT NULL,
  `AD` varchar(150) CHARACTER SET utf8mb3 COLLATE utf8mb3_bin NOT NULL,
  `Editor` varchar(40) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `EditedAD` varchar(150) CHARACTER SET utf8mb3 COLLATE utf8mb3_bin NULL DEFAULT NULL,
  `Opened` datetime NOT NULL,
  `Closed` datetime NULL DEFAULT NULL,
  `Status` tinyint NULL DEFAULT 0,
  PRIMARY KEY (`ID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 16 CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of advertised
-- ----------------------------
INSERT INTO `advertised` VALUES (8, 'Volt_Alphatester', -1, 'Hurensohn kauft Nutten', 'Chris_Connor', 'Hurensohn kauft Nutten', '2020-12-18 20:11:52', '2021-01-05 18:52:56', 1);
INSERT INTO `advertised` VALUES (9, 'Wiesel_Alphatester', -1, 'Wiesel s neues animalisches Parfüm jetzt bei Douglas verfügbar!', 'Chris_Connor', 'Wiesel s neues animalisches Parfüm jetzt bei Douglas verfügbar!', '2021-01-02 02:38:40', '2021-01-05 18:52:54', 1);
INSERT INTO `advertised` VALUES (10, 'Volt_Alphatester', 9641547, 'heute grosses BUGFIXXEN', 'Chris_Connor', 'heute grosses BUGFIxxen', '2021-01-05 18:56:23', '2021-01-05 18:56:59', 1);
INSERT INTO `advertised` VALUES (11, 'Volt_Alphatester', 2323864, 'ali kauft nur heute deine mutter', NULL, NULL, '2021-01-09 17:15:26', '0001-01-01 00:00:00', 0);
INSERT INTO `advertised` VALUES (12, 'Marcus_Stenhouse', 1356817, 'TETSTETSETSTESTESTETSTES', NULL, NULL, '2021-01-13 20:22:46', '0001-01-01 00:00:00', 0);
INSERT INTO `advertised` VALUES (13, 'Timati_Blackstar', 1430970, 'jooooooooooooooooooooooooooooooo', NULL, NULL, '2021-02-07 21:43:44', '0001-01-01 00:00:00', 0);
INSERT INTO `advertised` VALUES (14, 'Alexander_Rusev', -1, '43242343242343242', NULL, NULL, '2021-02-14 00:00:31', '0001-01-01 00:00:00', 0);
INSERT INTO `advertised` VALUES (15, 'Dustin_Johnsen', 6598661, 'was geht hier so ab', NULL, NULL, '2021-02-28 13:03:58', '0001-01-01 00:00:00', 0);

-- ----------------------------
-- Table structure for alcoclubs
-- ----------------------------
DROP TABLE IF EXISTS `alcoclubs`;
CREATE TABLE `alcoclubs`  (
  `id` int NOT NULL,
  `mats` int NOT NULL,
  `alco1` int NOT NULL,
  `alco2` int NOT NULL,
  `alco3` int NOT NULL,
  `pricemod` int NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of alcoclubs
-- ----------------------------
INSERT INTO `alcoclubs` VALUES (10, 10000, 421, 311, 218, 0);
INSERT INTO `alcoclubs` VALUES (11, 10000, 0, 0, 0, 0);
INSERT INTO `alcoclubs` VALUES (12, 10000, 488, 382, 281, 0);
INSERT INTO `alcoclubs` VALUES (13, 0, 0, 0, 0, 0);

-- ----------------------------
-- Table structure for aparts
-- ----------------------------
DROP TABLE IF EXISTS `aparts`;
CREATE TABLE `aparts`  (
  `id` int NOT NULL,
  `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `pos` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `garpos` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `houses` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `heading` float(255, 0) NULL DEFAULT NULL
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of aparts
-- ----------------------------
INSERT INTO `aparts` VALUES (1000, 'Pillbox Hill', '{\"x\":-267.33832,\"y\":-739.86145,\"z\":33.296776}', '{\"x\":-258.17505,\"y\":-749.8903,\"z\":31.715536}', '[166,167]', 163);

-- ----------------------------
-- Table structure for banned
-- ----------------------------
DROP TABLE IF EXISTS `banned`;
CREATE TABLE `banned`  (
  `uuid` int NOT NULL,
  `name` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `account` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `time` datetime NOT NULL,
  `until` datetime NOT NULL,
  `ishard` tinyint NOT NULL,
  `ip` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `socialclub` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `hwid` varchar(256) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `reason` varchar(128) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `byadmin` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`uuid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of banned
-- ----------------------------

-- ----------------------------
-- Table structure for businesses
-- ----------------------------
DROP TABLE IF EXISTS `businesses`;
CREATE TABLE `businesses`  (
  `id` int NOT NULL,
  `owner` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `sellprice` int NOT NULL,
  `type` tinyint NOT NULL,
  `products` varchar(8192) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `enterpoint` varchar(256) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `unloadpoint` varchar(256) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `money` int NOT NULL,
  `mafia` tinyint NOT NULL,
  `orders` varchar(8192) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `bizinfo` varchar(256) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of businesses
-- ----------------------------
INSERT INTO `businesses` VALUES (0, 'Staat', 100000, 0, '[{\"Price\":150,\"Lefts\":9999995,\"Autosell\":1,\"Name\":\"Taschenlampe\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999997,\"Autosell\":1,\"Name\":\"Hammer\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999997,\"Autosell\":1,\"Name\":\"Rohrzange\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999997,\"Autosell\":1,\"Name\":\"Benzinkanister\",\"Ordered\":false},{\"Price\":1,\"Lefts\":9999994,\"Autosell\":1,\"Name\":\"Chips\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999978,\"Autosell\":1,\"Name\":\"Pizza\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999985,\"Autosell\":1,\"Name\":\"SIM-Karte\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999995,\"Autosell\":1,\"Name\":\"Schlüsselbund\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999992,\"Autosell\":1,\"Name\":\"Zigarette\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999971,\"Autosell\":1,\"Name\":\"Wasser\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999981,\"Autosell\":1,\"Name\":\"Kaffee\",\"Ordered\":true},{\"Price\":3,\"Lefts\":9999996,\"Autosell\":1,\"Name\":\"Gummibärchen\",\"Ordered\":true},{\"Price\":3,\"Lefts\":9999981,\"Autosell\":1,\"Name\":\"Donut\",\"Ordered\":true},{\"Price\":5,\"Lefts\":9999995,\"Autosell\":1,\"Name\":\"Schinken\",\"Ordered\":true},{\"Price\":15,\"Lefts\":9999997,\"Autosell\":1,\"Name\":\"Aceton\",\"Ordered\":true},{\"Price\":60,\"Lefts\":9999996,\"Autosell\":1,\"Name\":\"Rucksack\",\"Ordered\":true}]', '{\"x\":25.972094,\"y\":-1346.7352,\"z\":28.377026}', '{\"x\":15.893962,\"y\":-1347.3087,\"z\":29.29152}', 930677, -1, '[{\"Name\":\"Zigarette\",\"Amount\":2500},{\"Name\":\"Wasser\",\"Amount\":2500},{\"Name\":\"Kaffee\",\"Amount\":2500},{\"Name\":\"Gummibärchen\",\"Amount\":2500},{\"Name\":\"Donut\",\"Amount\":2500},{\"Name\":\"Schinken\",\"Amount\":2500},{\"Name\":\"Aceton\",\"Amount\":1000},{\"Name\":\"Rucksack\",\"Amount\":1000}]', NULL);
INSERT INTO `businesses` VALUES (1, 'Staat', 100000, 0, '[{\"Price\":150,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Taschenlampe\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Hammer\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999998,\"Autosell\":1,\"Name\":\"Rohrzange\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Benzinkanister\",\"Ordered\":false},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Chips\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Pizza\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999998,\"Autosell\":1,\"Name\":\"SIM-Karte\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Schlüsselbund\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999998,\"Autosell\":1,\"Name\":\"Zigarette\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999995,\"Autosell\":1,\"Name\":\"Wasser\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999998,\"Autosell\":1,\"Name\":\"Kaffee\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Gummibärchen\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Donut\",\"Ordered\":true},{\"Price\":5,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Schinken\",\"Ordered\":true},{\"Price\":15,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Aceton\",\"Ordered\":false},{\"Price\":60,\"Lefts\":99990999,\"Autosell\":1,\"Name\":\"Rucksack\",\"Ordered\":false}]', '{\"x\":-47.933422,\"y\":-1757.3499,\"z\":28.301}', '{\"x\":-56.499863,\"y\":-1743.8435,\"z\":29.335625}', 315784, -1, '[{\"Name\":\"Taschenlampe\",\"Amount\":500},{\"Name\":\"Hammer\",\"Amount\":50},{\"Name\":\"Rohrzange\",\"Amount\":50},{\"Name\":\"Benzinkanister\",\"Amount\":50},{\"Name\":\"Chips\",\"Amount\":500},{\"Name\":\"Pizza\",\"Amount\":500},{\"Name\":\"SIM-Karte\",\"Amount\":500},{\"Name\":\"Schlüsselbund\",\"Amount\":50},{\"Name\":\"Zigarette\",\"Amount\":2500},{\"Name\":\"Wasser\",\"Amount\":2500},{\"Name\":\"Kaffee\",\"Amount\":2500},{\"Name\":\"Gummibärchen\",\"Amount\":2500},{\"Name\":\"Donut\",\"Amount\":2500},{\"Name\":\"Schinken\",\"Amount\":2500},{\"Name\":\"Aceton\",\"Amount\":1000},{\"Name\":\"Rucksack\",\"Amount\":1000}]', NULL);
INSERT INTO `businesses` VALUES (2, 'Staat', 100000, 0, '[{\"Price\":150,\"Lefts\":9999998,\"Autosell\":1,\"Name\":\"Taschenlampe\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999998,\"Autosell\":1,\"Name\":\"Hammer\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Rohrzange\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999998,\"Autosell\":1,\"Name\":\"Benzinkanister\",\"Ordered\":false},{\"Price\":1,\"Lefts\":9999996,\"Autosell\":1,\"Name\":\"Chips\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999998,\"Autosell\":1,\"Name\":\"Pizza\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"SIM-Karte\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999997,\"Autosell\":1,\"Name\":\"Schlüsselbund\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999998,\"Autosell\":1,\"Name\":\"Zigarette\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999997,\"Autosell\":1,\"Name\":\"Wasser\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999997,\"Autosell\":1,\"Name\":\"Kaffee\",\"Ordered\":true},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Gummibärchen\",\"Ordered\":true},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Donut\",\"Ordered\":true},{\"Price\":5,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Schinken\",\"Ordered\":true},{\"Price\":15,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Aceton\",\"Ordered\":true},{\"Price\":60,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Rucksack\",\"Ordered\":true}]', '{\"x\":1136.1569,\"y\":-982.4919,\"z\":45.295807}', '{\"x\":1147.5743,\"y\":-985.0457,\"z\":45.970474}', 606937, -1, '[{\"Name\":\"Taschenlampe\",\"Amount\":500},{\"Name\":\"Hammer\",\"Amount\":50},{\"Name\":\"Rohrzange\",\"Amount\":50},{\"Name\":\"Benzinkanister\",\"Amount\":50},{\"Name\":\"Chips\",\"Amount\":500},{\"Name\":\"Pizza\",\"Amount\":500},{\"Name\":\"SIM-Karte\",\"Amount\":500},{\"Name\":\"Schlüsselbund\",\"Amount\":50},{\"Name\":\"Zigarette\",\"Amount\":2500},{\"Name\":\"Wasser\",\"Amount\":2500},{\"Name\":\"Kaffee\",\"Amount\":2500},{\"Name\":\"Gummibärchen\",\"Amount\":2500},{\"Name\":\"Donut\",\"Amount\":2500},{\"Name\":\"Schinken\",\"Amount\":2500},{\"Name\":\"Aceton\",\"Amount\":1000},{\"Name\":\"Rucksack\",\"Amount\":1000},{\"Name\":\"Aceton\",\"Amount\":1000},{\"Name\":\"Rucksack\",\"Amount\":1000}]', NULL);
INSERT INTO `businesses` VALUES (3, 'Staat', 100000, 0, '[{\"Price\":150,\"Lefts\":9999997,\"Autosell\":1,\"Name\":\"Taschenlampe\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Hammer\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Rohrzange\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999998,\"Autosell\":1,\"Name\":\"Benzinkanister\",\"Ordered\":false},{\"Price\":1,\"Lefts\":9999997,\"Autosell\":1,\"Name\":\"Chips\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999984,\"Autosell\":1,\"Name\":\"Pizza\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999998,\"Autosell\":1,\"Name\":\"SIM-Karte\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999998,\"Autosell\":1,\"Name\":\"Schlüsselbund\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999991,\"Autosell\":1,\"Name\":\"Zigarette\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999978,\"Autosell\":1,\"Name\":\"Wasser\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999998,\"Autosell\":1,\"Name\":\"Kaffee\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Gummibärchen\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Donut\",\"Ordered\":true},{\"Price\":5,\"Lefts\":9999997,\"Autosell\":1,\"Name\":\"Schinken\",\"Ordered\":true},{\"Price\":15,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Aceton\",\"Ordered\":true},{\"Price\":60,\"Lefts\":99990999,\"Autosell\":1,\"Name\":\"Rucksack\",\"Ordered\":false}]', '{\"x\":1163.2045,\"y\":-323.33908,\"z\":68.08507}', '{\"x\":1153.9094,\"y\":-331.04886,\"z\":68.927155}', 537436, -1, '[{\"Name\":\"Taschenlampe\",\"Amount\":500},{\"Name\":\"Hammer\",\"Amount\":50},{\"Name\":\"Rohrzange\",\"Amount\":50},{\"Name\":\"Benzinkanister\",\"Amount\":50},{\"Name\":\"Chips\",\"Amount\":500},{\"Name\":\"Pizza\",\"Amount\":500},{\"Name\":\"SIM-Karte\",\"Amount\":500},{\"Name\":\"Schlüsselbund\",\"Amount\":50},{\"Name\":\"Zigarette\",\"Amount\":2500},{\"Name\":\"Wasser\",\"Amount\":2500},{\"Name\":\"Kaffee\",\"Amount\":2500},{\"Name\":\"Gummibärchen\",\"Amount\":2500},{\"Name\":\"Donut\",\"Amount\":2500},{\"Name\":\"Schinken\",\"Amount\":2500},{\"Name\":\"Aceton\",\"Amount\":1000},{\"Name\":\"Rucksack\",\"Amount\":1000},{\"Name\":\"Aceton\",\"Amount\":1000}]', NULL);
INSERT INTO `businesses` VALUES (4, 'Staat', 100000, 0, '[{\"Price\":150,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Taschenlampe\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999998,\"Autosell\":1,\"Name\":\"Hammer\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Rohrzange\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Benzinkanister\",\"Ordered\":false},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Chips\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999996,\"Autosell\":1,\"Name\":\"Pizza\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"SIM-Karte\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Schlüsselbund\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Zigarette\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999992,\"Autosell\":1,\"Name\":\"Wasser\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999997,\"Autosell\":1,\"Name\":\"Kaffee\",\"Ordered\":true},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Gummibärchen\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Donut\",\"Ordered\":true},{\"Price\":5,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Schinken\",\"Ordered\":true},{\"Price\":15,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Aceton\",\"Ordered\":false},{\"Price\":60,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Rucksack\",\"Ordered\":false}]', '{\"x\":374.4605,\"y\":326.20264,\"z\":102.446365}', '{\"x\":375.69516,\"y\":317.7242,\"z\":103.42288}', 531145, -1, '[{\"Name\":\"Taschenlampe\",\"Amount\":500},{\"Name\":\"Hammer\",\"Amount\":50},{\"Name\":\"Rohrzange\",\"Amount\":50},{\"Name\":\"Benzinkanister\",\"Amount\":50},{\"Name\":\"Chips\",\"Amount\":500},{\"Name\":\"Pizza\",\"Amount\":500},{\"Name\":\"SIM-Karte\",\"Amount\":500},{\"Name\":\"Schlüsselbund\",\"Amount\":50},{\"Name\":\"Zigarette\",\"Amount\":2500},{\"Name\":\"Wasser\",\"Amount\":2500},{\"Name\":\"Kaffee\",\"Amount\":2500},{\"Name\":\"Gummibärchen\",\"Amount\":2500},{\"Name\":\"Donut\",\"Amount\":2500},{\"Name\":\"Schinken\",\"Amount\":2500},{\"Name\":\"Aceton\",\"Amount\":1000},{\"Name\":\"Rucksack\",\"Amount\":1000}]', NULL);
INSERT INTO `businesses` VALUES (5, 'Staat', 100000, 0, '[{\"Price\":150,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Taschenlampe\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Hammer\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Rohrzange\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Benzinkanister\",\"Ordered\":false},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Chips\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Pizza\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999996,\"Autosell\":1,\"Name\":\"SIM-Karte\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Schlüsselbund\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Zigarette\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Wasser\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Kaffee\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Gummibärchen\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Donut\",\"Ordered\":true},{\"Price\":5,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Schinken\",\"Ordered\":true},{\"Price\":15,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Aceton\",\"Ordered\":false},{\"Price\":60,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Rucksack\",\"Ordered\":false}]', '{\"x\":-1223.1259,\"y\":-906.7461,\"z\":11.206355}', '{\"x\":-1226.1012,\"y\":-896.7665,\"z\":12.39524}', 891677, -1, '[{\"Name\":\"Taschenlampe\",\"Amount\":500},{\"Name\":\"Hammer\",\"Amount\":50},{\"Name\":\"Rohrzange\",\"Amount\":50},{\"Name\":\"Benzinkanister\",\"Amount\":50},{\"Name\":\"Chips\",\"Amount\":500},{\"Name\":\"Pizza\",\"Amount\":500},{\"Name\":\"SIM-Karte\",\"Amount\":500},{\"Name\":\"Schlüsselbund\",\"Amount\":50},{\"Name\":\"Zigarette\",\"Amount\":2500},{\"Name\":\"Wasser\",\"Amount\":2500},{\"Name\":\"Kaffee\",\"Amount\":2500},{\"Name\":\"Gummibärchen\",\"Amount\":2500},{\"Name\":\"Donut\",\"Amount\":2500},{\"Name\":\"Schinken\",\"Amount\":2500},{\"Name\":\"Aceton\",\"Amount\":1000},{\"Name\":\"Rucksack\",\"Amount\":1000}]', NULL);
INSERT INTO `businesses` VALUES (6, 'Staat', 100000, 0, '[{\"Price\":150,\"Lefts\":9999998,\"Autosell\":1,\"Name\":\"Taschenlampe\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999998,\"Autosell\":1,\"Name\":\"Hammer\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999998,\"Autosell\":1,\"Name\":\"Rohrzange\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999996,\"Autosell\":1,\"Name\":\"Benzinkanister\",\"Ordered\":false},{\"Price\":1,\"Lefts\":9999997,\"Autosell\":1,\"Name\":\"Chips\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999990,\"Autosell\":1,\"Name\":\"Pizza\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999994,\"Autosell\":1,\"Name\":\"SIM-Karte\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999997,\"Autosell\":1,\"Name\":\"Schlüsselbund\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999997,\"Autosell\":1,\"Name\":\"Zigarette\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999983,\"Autosell\":1,\"Name\":\"Wasser\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999998,\"Autosell\":1,\"Name\":\"Kaffee\",\"Ordered\":true},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Gummibärchen\",\"Ordered\":true},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Donut\",\"Ordered\":true},{\"Price\":5,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Schinken\",\"Ordered\":true},{\"Price\":15,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Aceton\",\"Ordered\":false},{\"Price\":60,\"Lefts\":9999996,\"Autosell\":1,\"Name\":\"Rucksack\",\"Ordered\":true}]', '{\"x\":-707.70154,\"y\":-913.8857,\"z\":18.09559}', '{\"x\":-714.9318,\"y\":-919.99805,\"z\":19.013916}', 686993, -1, '[{\"Name\":\"Taschenlampe\",\"Amount\":500},{\"Name\":\"Hammer\",\"Amount\":50},{\"Name\":\"Rohrzange\",\"Amount\":50},{\"Name\":\"Benzinkanister\",\"Amount\":50},{\"Name\":\"Chips\",\"Amount\":500},{\"Name\":\"Pizza\",\"Amount\":500},{\"Name\":\"SIM-Karte\",\"Amount\":500},{\"Name\":\"Schlüsselbund\",\"Amount\":50},{\"Name\":\"Zigarette\",\"Amount\":2500},{\"Name\":\"Wasser\",\"Amount\":2500},{\"Name\":\"Kaffee\",\"Amount\":2500},{\"Name\":\"Gummibärchen\",\"Amount\":2500},{\"Name\":\"Donut\",\"Amount\":2500},{\"Name\":\"Schinken\",\"Amount\":2500},{\"Name\":\"Aceton\",\"Amount\":1000},{\"Name\":\"Rucksack\",\"Amount\":1000},{\"Name\":\"Rucksack\",\"Amount\":1000}]', NULL);
INSERT INTO `businesses` VALUES (7, 'Staat', 100000, 0, '[{\"Price\":150,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Taschenlampe\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Hammer\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Rohrzange\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Benzinkanister\",\"Ordered\":false},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Chips\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Pizza\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"SIM-Karte\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Schlüsselbund\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Zigarette\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Wasser\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Kaffee\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Gummibärchen\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Donut\",\"Ordered\":true},{\"Price\":5,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Schinken\",\"Ordered\":true},{\"Price\":15,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Aceton\",\"Ordered\":false},{\"Price\":60,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Rucksack\",\"Ordered\":false}]', '{\"x\":-1487.4161,\"y\":-379.3365,\"z\":39.043427}', '{\"x\":-1506.005,\"y\":-384.0162,\"z\":40.726383}', 35587, -1, '[{\"Name\":\"Taschenlampe\",\"Amount\":500},{\"Name\":\"Hammer\",\"Amount\":50},{\"Name\":\"Rohrzange\",\"Amount\":50},{\"Name\":\"Benzinkanister\",\"Amount\":50},{\"Name\":\"Chips\",\"Amount\":500},{\"Name\":\"Pizza\",\"Amount\":500},{\"Name\":\"SIM-Karte\",\"Amount\":500},{\"Name\":\"Schlüsselbund\",\"Amount\":50},{\"Name\":\"Zigarette\",\"Amount\":2500},{\"Name\":\"Wasser\",\"Amount\":2500},{\"Name\":\"Kaffee\",\"Amount\":2500},{\"Name\":\"Gummibärchen\",\"Amount\":2500},{\"Name\":\"Donut\",\"Amount\":2500},{\"Name\":\"Schinken\",\"Amount\":2500},{\"Name\":\"Aceton\",\"Amount\":1000},{\"Name\":\"Rucksack\",\"Amount\":1000}]', NULL);
INSERT INTO `businesses` VALUES (8, 'Staat', 100000, 0, '[{\"Price\":150,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Taschenlampe\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Hammer\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Rohrzange\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Benzinkanister\",\"Ordered\":false},{\"Price\":1,\"Lefts\":9999998,\"Autosell\":1,\"Name\":\"Chips\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Pizza\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"SIM-Karte\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Schlüsselbund\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Zigarette\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Wasser\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Kaffee\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Gummibärchen\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Donut\",\"Ordered\":true},{\"Price\":5,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Schinken\",\"Ordered\":true},{\"Price\":15,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Aceton\",\"Ordered\":false},{\"Price\":60,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Rucksack\",\"Ordered\":false}]', '{\"x\":-1821.1328,\"y\":793.39703,\"z\":136.99524}', '{\"x\":-1822.1677,\"y\":782.9886,\"z\":137.94331}', 360522, -1, '[{\"Name\":\"Taschenlampe\",\"Amount\":500},{\"Name\":\"Hammer\",\"Amount\":50},{\"Name\":\"Rohrzange\",\"Amount\":50},{\"Name\":\"Benzinkanister\",\"Amount\":50},{\"Name\":\"Chips\",\"Amount\":500},{\"Name\":\"Pizza\",\"Amount\":500},{\"Name\":\"SIM-Karte\",\"Amount\":500},{\"Name\":\"Schlüsselbund\",\"Amount\":50},{\"Name\":\"Zigarette\",\"Amount\":2500},{\"Name\":\"Wasser\",\"Amount\":2500},{\"Name\":\"Kaffee\",\"Amount\":2500},{\"Name\":\"Gummibärchen\",\"Amount\":2500},{\"Name\":\"Donut\",\"Amount\":2500},{\"Name\":\"Schinken\",\"Amount\":2500},{\"Name\":\"Aceton\",\"Amount\":1000},{\"Name\":\"Rucksack\",\"Amount\":1000}]', NULL);
INSERT INTO `businesses` VALUES (9, 'Staat', 100000, 0, '[{\"Price\":150,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Taschenlampe\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Hammer\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Rohrzange\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Benzinkanister\",\"Ordered\":false},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Chips\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Pizza\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"SIM-Karte\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Schlüsselbund\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Zigarette\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Wasser\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Kaffee\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Gummibärchen\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Donut\",\"Ordered\":true},{\"Price\":5,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Schinken\",\"Ordered\":true},{\"Price\":15,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Aceton\",\"Ordered\":false},{\"Price\":60,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Rucksack\",\"Ordered\":false}]', '{\"x\":-2968.025,\"y\":391.0095,\"z\":13.923312}', '{\"x\":-2979.3022,\"y\":394.42947,\"z\":15.029839}', 39117, -1, '[{\"Name\":\"Taschenlampe\",\"Amount\":500},{\"Name\":\"Hammer\",\"Amount\":50},{\"Name\":\"Rohrzange\",\"Amount\":50},{\"Name\":\"Benzinkanister\",\"Amount\":50},{\"Name\":\"Chips\",\"Amount\":500},{\"Name\":\"Pizza\",\"Amount\":500},{\"Name\":\"SIM-Karte\",\"Amount\":500},{\"Name\":\"Schlüsselbund\",\"Amount\":50},{\"Name\":\"Zigarette\",\"Amount\":2500},{\"Name\":\"Wasser\",\"Amount\":2500},{\"Name\":\"Kaffee\",\"Amount\":2500},{\"Name\":\"Gummibärchen\",\"Amount\":2500},{\"Name\":\"Donut\",\"Amount\":2500},{\"Name\":\"Schinken\",\"Amount\":2500},{\"Name\":\"Aceton\",\"Amount\":1000},{\"Name\":\"Rucksack\",\"Amount\":1000}]', NULL);
INSERT INTO `businesses` VALUES (10, 'Staat', 100000, 0, '[{\"Price\":150,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Taschenlampe\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Hammer\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Rohrzange\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Benzinkanister\",\"Ordered\":false},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Chips\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Pizza\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"SIM-Karte\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Schlüsselbund\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Zigarette\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Wasser\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999997,\"Autosell\":1,\"Name\":\"Kaffee\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Gummibärchen\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Donut\",\"Ordered\":true},{\"Price\":5,\"Lefts\":99990998,\"Autosell\":1,\"Name\":\"Schinken\",\"Ordered\":true},{\"Price\":15,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Aceton\",\"Ordered\":false},{\"Price\":60,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Rucksack\",\"Ordered\":false}]', '{\"x\":-3039.7656,\"y\":585.9168,\"z\":6.788929}', '{\"x\":-3031.241,\"y\":589.5498,\"z\":7.6683393}', 89437, -1, '[{\"Name\":\"Taschenlampe\",\"Amount\":500},{\"Name\":\"Hammer\",\"Amount\":50},{\"Name\":\"Rohrzange\",\"Amount\":50},{\"Name\":\"Benzinkanister\",\"Amount\":50},{\"Name\":\"Chips\",\"Amount\":500},{\"Name\":\"Pizza\",\"Amount\":500},{\"Name\":\"SIM-Karte\",\"Amount\":500},{\"Name\":\"Schlüsselbund\",\"Amount\":50},{\"Name\":\"Zigarette\",\"Amount\":2500},{\"Name\":\"Wasser\",\"Amount\":2500},{\"Name\":\"Kaffee\",\"Amount\":2500},{\"Name\":\"Gummibärchen\",\"Amount\":2500},{\"Name\":\"Donut\",\"Amount\":2500},{\"Name\":\"Schinken\",\"Amount\":2500},{\"Name\":\"Aceton\",\"Amount\":1000},{\"Name\":\"Rucksack\",\"Amount\":1000}]', NULL);
INSERT INTO `businesses` VALUES (11, 'Staat', 100000, 0, '[{\"Price\":150,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Taschenlampe\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Hammer\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Rohrzange\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Benzinkanister\",\"Ordered\":false},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Chips\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Pizza\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"SIM-Karte\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Schlüsselbund\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Zigarette\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999992,\"Autosell\":1,\"Name\":\"Wasser\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Kaffee\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Gummibärchen\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99990998,\"Autosell\":1,\"Name\":\"Donut\",\"Ordered\":true},{\"Price\":5,\"Lefts\":99990998,\"Autosell\":1,\"Name\":\"Schinken\",\"Ordered\":true},{\"Price\":15,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Aceton\",\"Ordered\":false},{\"Price\":60,\"Lefts\":99990999,\"Autosell\":1,\"Name\":\"Rucksack\",\"Ordered\":false}]', '{\"x\":-3242.2437,\"y\":1001.4528,\"z\":11.710707}', '{\"x\":-3236.5637,\"y\":999.3205,\"z\":12.536004}', 710297, -1, '[{\"Name\":\"Taschenlampe\",\"Amount\":500},{\"Name\":\"Hammer\",\"Amount\":50},{\"Name\":\"Rohrzange\",\"Amount\":50},{\"Name\":\"Benzinkanister\",\"Amount\":50},{\"Name\":\"Chips\",\"Amount\":500},{\"Name\":\"Pizza\",\"Amount\":500},{\"Name\":\"SIM-Karte\",\"Amount\":500},{\"Name\":\"Schlüsselbund\",\"Amount\":50},{\"Name\":\"Zigarette\",\"Amount\":2500},{\"Name\":\"Wasser\",\"Amount\":2500},{\"Name\":\"Kaffee\",\"Amount\":2500},{\"Name\":\"Gummibärchen\",\"Amount\":2500},{\"Name\":\"Donut\",\"Amount\":2500},{\"Name\":\"Schinken\",\"Amount\":2500},{\"Name\":\"Aceton\",\"Amount\":1000},{\"Name\":\"Rucksack\",\"Amount\":1000}]', NULL);
INSERT INTO `businesses` VALUES (12, 'Staat', 100000, 0, '[{\"Price\":150,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Taschenlampe\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Hammer\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Rohrzange\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Benzinkanister\",\"Ordered\":false},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Chips\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Pizza\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"SIM-Karte\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Schlüsselbund\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Zigarette\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Wasser\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Kaffee\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Gummibärchen\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Donut\",\"Ordered\":true},{\"Price\":5,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Schinken\",\"Ordered\":true},{\"Price\":15,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Aceton\",\"Ordered\":false},{\"Price\":60,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Rucksack\",\"Ordered\":false}]', '{\"x\":547.7974,\"y\":2671.186,\"z\":41.036495}', '{\"x\":550.8215,\"y\":2680.6514,\"z\":42.136276}', 555576, -1, '[{\"Name\":\"Taschenlampe\",\"Amount\":500},{\"Name\":\"Hammer\",\"Amount\":50},{\"Name\":\"Rohrzange\",\"Amount\":50},{\"Name\":\"Benzinkanister\",\"Amount\":50},{\"Name\":\"Chips\",\"Amount\":500},{\"Name\":\"Pizza\",\"Amount\":500},{\"Name\":\"SIM-Karte\",\"Amount\":500},{\"Name\":\"Schlüsselbund\",\"Amount\":50},{\"Name\":\"Zigarette\",\"Amount\":2500},{\"Name\":\"Wasser\",\"Amount\":2500},{\"Name\":\"Kaffee\",\"Amount\":2500},{\"Name\":\"Gummibärchen\",\"Amount\":2500},{\"Name\":\"Donut\",\"Amount\":2500},{\"Name\":\"Schinken\",\"Amount\":2500},{\"Name\":\"Aceton\",\"Amount\":1000},{\"Name\":\"Rucksack\",\"Amount\":1000}]', NULL);
INSERT INTO `businesses` VALUES (13, 'Staat', 100000, 0, '[{\"Price\":150,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Taschenlampe\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Hammer\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Rohrzange\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Benzinkanister\",\"Ordered\":false},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Chips\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Pizza\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"SIM-Karte\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Schlüsselbund\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Zigarette\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Wasser\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Kaffee\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Gummibärchen\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Donut\",\"Ordered\":true},{\"Price\":5,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Schinken\",\"Ordered\":true},{\"Price\":15,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Aceton\",\"Ordered\":false},{\"Price\":60,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Rucksack\",\"Ordered\":false}]', '{\"x\":1166.0199,\"y\":2708.7722,\"z\":37.03771}', '{\"x\":1162.8328,\"y\":2698.1707,\"z\":37.9455}', 799631, -1, '[{\"Name\":\"Taschenlampe\",\"Amount\":500},{\"Name\":\"Hammer\",\"Amount\":50},{\"Name\":\"Rohrzange\",\"Amount\":50},{\"Name\":\"Benzinkanister\",\"Amount\":50},{\"Name\":\"Chips\",\"Amount\":500},{\"Name\":\"Pizza\",\"Amount\":500},{\"Name\":\"SIM-Karte\",\"Amount\":500},{\"Name\":\"Schlüsselbund\",\"Amount\":50},{\"Name\":\"Zigarette\",\"Amount\":2500},{\"Name\":\"Wasser\",\"Amount\":2500},{\"Name\":\"Kaffee\",\"Amount\":2500},{\"Name\":\"Gummibärchen\",\"Amount\":2500},{\"Name\":\"Donut\",\"Amount\":2500},{\"Name\":\"Schinken\",\"Amount\":2500},{\"Name\":\"Aceton\",\"Amount\":1000},{\"Name\":\"Rucksack\",\"Amount\":1000}]', NULL);
INSERT INTO `businesses` VALUES (14, 'Staat', 100000, 0, '[{\"Price\":150,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Taschenlampe\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Hammer\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Rohrzange\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Benzinkanister\",\"Ordered\":false},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Chips\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Pizza\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"SIM-Karte\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Schlüsselbund\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Zigarette\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Wasser\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Kaffee\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Gummibärchen\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Donut\",\"Ordered\":true},{\"Price\":5,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Schinken\",\"Ordered\":true},{\"Price\":15,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Aceton\",\"Ordered\":false},{\"Price\":60,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Rucksack\",\"Ordered\":false}]', '{\"x\":1391.9446,\"y\":3604.7659,\"z\":33.860928}', '{\"x\":1392.4324,\"y\":3594.3335,\"z\":34.900078}', 775049, -1, '[{\"Name\":\"Taschenlampe\",\"Amount\":500},{\"Name\":\"Hammer\",\"Amount\":50},{\"Name\":\"Rohrzange\",\"Amount\":50},{\"Name\":\"Benzinkanister\",\"Amount\":50},{\"Name\":\"Chips\",\"Amount\":500},{\"Name\":\"Pizza\",\"Amount\":500},{\"Name\":\"SIM-Karte\",\"Amount\":500},{\"Name\":\"Schlüsselbund\",\"Amount\":50},{\"Name\":\"Zigarette\",\"Amount\":2500},{\"Name\":\"Wasser\",\"Amount\":2500},{\"Name\":\"Kaffee\",\"Amount\":2500},{\"Name\":\"Gummibärchen\",\"Amount\":2500},{\"Name\":\"Donut\",\"Amount\":2500},{\"Name\":\"Schinken\",\"Amount\":2500},{\"Name\":\"Aceton\",\"Amount\":1000},{\"Name\":\"Rucksack\",\"Amount\":1000}]', NULL);
INSERT INTO `businesses` VALUES (15, 'Staat', 100000, 0, '[{\"Price\":150,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Taschenlampe\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Hammer\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Rohrzange\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Benzinkanister\",\"Ordered\":false},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Chips\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999995,\"Autosell\":1,\"Name\":\"Pizza\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"SIM-Karte\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Schlüsselbund\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999995,\"Autosell\":1,\"Name\":\"Zigarette\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999994,\"Autosell\":1,\"Name\":\"Wasser\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Kaffee\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Gummibärchen\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Donut\",\"Ordered\":true},{\"Price\":5,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Schinken\",\"Ordered\":true},{\"Price\":15,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Aceton\",\"Ordered\":false},{\"Price\":60,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Rucksack\",\"Ordered\":false}]', '{\"x\":1961.4637,\"y\":3740.8193,\"z\":31.223742}', '{\"x\":1963.9078,\"y\":3733.9766,\"z\":32.219055}', 129303, -1, '[{\"Name\":\"Taschenlampe\",\"Amount\":500},{\"Name\":\"Hammer\",\"Amount\":50},{\"Name\":\"Rohrzange\",\"Amount\":50},{\"Name\":\"Benzinkanister\",\"Amount\":50},{\"Name\":\"Chips\",\"Amount\":500},{\"Name\":\"Pizza\",\"Amount\":500},{\"Name\":\"SIM-Karte\",\"Amount\":500},{\"Name\":\"Schlüsselbund\",\"Amount\":50},{\"Name\":\"Zigarette\",\"Amount\":2500},{\"Name\":\"Wasser\",\"Amount\":2500},{\"Name\":\"Kaffee\",\"Amount\":2500},{\"Name\":\"Gummibärchen\",\"Amount\":2500},{\"Name\":\"Donut\",\"Amount\":2500},{\"Name\":\"Schinken\",\"Amount\":2500},{\"Name\":\"Aceton\",\"Amount\":1000},{\"Name\":\"Rucksack\",\"Amount\":1000}]', NULL);
INSERT INTO `businesses` VALUES (16, 'Staat', 100000, 0, '[{\"Price\":150,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Taschenlampe\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Hammer\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Rohrzange\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Benzinkanister\",\"Ordered\":false},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Chips\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Pizza\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"SIM-Karte\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Schlüsselbund\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Zigarette\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Wasser\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Kaffee\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Gummibärchen\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Donut\",\"Ordered\":true},{\"Price\":5,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Schinken\",\"Ordered\":true},{\"Price\":15,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Aceton\",\"Ordered\":false},{\"Price\":60,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Rucksack\",\"Ordered\":false}]', '{\"x\":1698.0037,\"y\":4924.524,\"z\":40.94368}', '{\"x\":1696.8308,\"y\":4933.89,\"z\":42.078106}', 852392, -1, '[{\"Name\":\"Taschenlampe\",\"Amount\":500},{\"Name\":\"Hammer\",\"Amount\":50},{\"Name\":\"Rohrzange\",\"Amount\":50},{\"Name\":\"Benzinkanister\",\"Amount\":50},{\"Name\":\"Chips\",\"Amount\":500},{\"Name\":\"Pizza\",\"Amount\":500},{\"Name\":\"SIM-Karte\",\"Amount\":500},{\"Name\":\"Schlüsselbund\",\"Amount\":50},{\"Name\":\"Zigarette\",\"Amount\":2500},{\"Name\":\"Wasser\",\"Amount\":2500},{\"Name\":\"Kaffee\",\"Amount\":2500},{\"Name\":\"Gummibärchen\",\"Amount\":2500},{\"Name\":\"Donut\",\"Amount\":2500},{\"Name\":\"Schinken\",\"Amount\":2500},{\"Name\":\"Aceton\",\"Amount\":1000},{\"Name\":\"Rucksack\",\"Amount\":1000}]', NULL);
INSERT INTO `businesses` VALUES (17, 'Staat', 100000, 0, '[{\"Price\":150,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Taschenlampe\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Hammer\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Rohrzange\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Benzinkanister\",\"Ordered\":false},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Chips\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Pizza\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"SIM-Karte\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Schlüsselbund\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Zigarette\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Wasser\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Kaffee\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Gummibärchen\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Donut\",\"Ordered\":true},{\"Price\":5,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Schinken\",\"Ordered\":true},{\"Price\":15,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Aceton\",\"Ordered\":false},{\"Price\":60,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Rucksack\",\"Ordered\":false}]', '{\"x\":1729.447,\"y\":6414.4414,\"z\":33.917225}', '{\"x\":1721.8699,\"y\":6410.917,\"z\":34.025326}', 558652, -1, '[{\"Name\":\"Taschenlampe\",\"Amount\":500},{\"Name\":\"Hammer\",\"Amount\":50},{\"Name\":\"Rohrzange\",\"Amount\":50},{\"Name\":\"Benzinkanister\",\"Amount\":50},{\"Name\":\"Chips\",\"Amount\":500},{\"Name\":\"Pizza\",\"Amount\":500},{\"Name\":\"SIM-Karte\",\"Amount\":500},{\"Name\":\"Schlüsselbund\",\"Amount\":50},{\"Name\":\"Zigarette\",\"Amount\":2500},{\"Name\":\"Wasser\",\"Amount\":2500},{\"Name\":\"Kaffee\",\"Amount\":2500},{\"Name\":\"Gummibärchen\",\"Amount\":2500},{\"Name\":\"Donut\",\"Amount\":2500},{\"Name\":\"Schinken\",\"Amount\":2500},{\"Name\":\"Aceton\",\"Amount\":1000},{\"Name\":\"Rucksack\",\"Amount\":1000}]', NULL);
INSERT INTO `businesses` VALUES (18, 'Staat', 100000, 0, '[{\"Price\":150,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Taschenlampe\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Hammer\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Rohrzange\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Benzinkanister\",\"Ordered\":false},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Chips\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Pizza\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"SIM-Karte\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Schlüsselbund\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Zigarette\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Wasser\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Kaffee\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Gummibärchen\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Donut\",\"Ordered\":true},{\"Price\":5,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Schinken\",\"Ordered\":true},{\"Price\":15,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Aceton\",\"Ordered\":false},{\"Price\":60,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Rucksack\",\"Ordered\":false}]', '{\"x\":2678.833,\"y\":3280.77,\"z\":54.121136}', '{\"x\":2682.0874,\"y\":3275.4607,\"z\":55.240562}', 835522, -1, '[{\"Name\":\"Taschenlampe\",\"Amount\":500},{\"Name\":\"Hammer\",\"Amount\":50},{\"Name\":\"Rohrzange\",\"Amount\":50},{\"Name\":\"Benzinkanister\",\"Amount\":50},{\"Name\":\"Chips\",\"Amount\":500},{\"Name\":\"Pizza\",\"Amount\":500},{\"Name\":\"SIM-Karte\",\"Amount\":500},{\"Name\":\"Schlüsselbund\",\"Amount\":50},{\"Name\":\"Zigarette\",\"Amount\":2500},{\"Name\":\"Wasser\",\"Amount\":2500},{\"Name\":\"Kaffee\",\"Amount\":2500},{\"Name\":\"Gummibärchen\",\"Amount\":2500},{\"Name\":\"Donut\",\"Amount\":2500},{\"Name\":\"Schinken\",\"Amount\":2500},{\"Name\":\"Aceton\",\"Amount\":1000},{\"Name\":\"Rucksack\",\"Amount\":1000}]', NULL);
INSERT INTO `businesses` VALUES (19, 'Staat', 100000, 0, '[{\"Price\":150,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Taschenlampe\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Hammer\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Rohrzange\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Benzinkanister\",\"Ordered\":false},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Chips\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Pizza\",\"Ordered\":false},{\"Price\":50,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"SIM-Karte\",\"Ordered\":false},{\"Price\":100,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Schlüsselbund\",\"Ordered\":false},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Zigarette\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Wasser\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Kaffee\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Gummibärchen\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Donut\",\"Ordered\":true},{\"Price\":5,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Schinken\",\"Ordered\":true},{\"Price\":15,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Aceton\",\"Ordered\":false},{\"Price\":60,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Rucksack\",\"Ordered\":false}]', '{\"x\":2557.2651,\"y\":382.33893,\"z\":107.502945}', '{\"x\":2563.022,\"y\":381.20016,\"z\":108.49405}', 834910, -1, '[{\"Name\":\"Taschenlampe\",\"Amount\":500},{\"Name\":\"Hammer\",\"Amount\":50},{\"Name\":\"Rohrzange\",\"Amount\":50},{\"Name\":\"Benzinkanister\",\"Amount\":50},{\"Name\":\"Chips\",\"Amount\":500},{\"Name\":\"Pizza\",\"Amount\":500},{\"Name\":\"SIM-Karte\",\"Amount\":500},{\"Name\":\"Schlüsselbund\",\"Amount\":50},{\"Name\":\"Zigarette\",\"Amount\":2500},{\"Name\":\"Wasser\",\"Amount\":2500},{\"Name\":\"Kaffee\",\"Amount\":2500},{\"Name\":\"Gummibärchen\",\"Amount\":2500},{\"Name\":\"Donut\",\"Amount\":2500},{\"Name\":\"Schinken\",\"Amount\":2500},{\"Name\":\"Aceton\",\"Amount\":1000},{\"Name\":\"Rucksack\",\"Amount\":1000}]', NULL);
INSERT INTO `businesses` VALUES (20, 'Staat', 100000, 1, '[{\"Price\":1,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Benzin\",\"Ordered\":true}]', '{\"x\":2577.5322,\"y\":362.94925,\"z\":107.33727}', '{\"x\":2580.9705,\"y\":352.2714,\"z\":108.457344}', 932262, -1, '[{\"Name\":\"Benzin\",\"Amount\":2000}]', NULL);
INSERT INTO `businesses` VALUES (21, 'Staat', 100000, 1, '[{\"Price\":1,\"Lefts\":9999880,\"Autosell\":0,\"Name\":\"Benzin\",\"Ordered\":true}]', '{\"x\":2681.6843,\"y\":3262.3052,\"z\":54.120525}', '{\"x\":2689.9612,\"y\":3269.5623,\"z\":55.240524}', 175801, -1, '[{\"Name\":\"Benzin\",\"Amount\":2000}]', NULL);
INSERT INTO `businesses` VALUES (22, 'Staat', 100000, 1, '[{\"Price\":1,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Benzin\",\"Ordered\":true}]', '{\"x\":1783.3706,\"y\":3327.9407,\"z\":40.165497}', '{\"x\":1788.2319,\"y\":3332.5632,\"z\":41.194153}', 446972, -1, '[{\"Name\":\"Benzin\",\"Amount\":2000}]', NULL);
INSERT INTO `businesses` VALUES (23, 'Staat', 100000, 1, '[{\"Price\":1,\"Lefts\":9999948,\"Autosell\":0,\"Name\":\"Benzin\",\"Ordered\":true}]', '{\"x\":2002.4747,\"y\":3775.9885,\"z\":31.060785}', '{\"x\":1992.0779,\"y\":3761.7573,\"z\":32.180714}', 662892, -1, '[{\"Name\":\"Benzin\",\"Amount\":2000}]', NULL);
INSERT INTO `businesses` VALUES (24, 'Staat', 100000, 1, '[{\"Price\":1,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Benzin\",\"Ordered\":true}]', '{\"x\":1687.999,\"y\":4929.989,\"z\":40.958107}', '{\"x\":1679.9633,\"y\":4921.3667,\"z\":42.076286}', 787644, -1, '[{\"Name\":\"Benzin\",\"Amount\":2000}]', NULL);
INSERT INTO `businesses` VALUES (25, 'Staat', 100000, 1, '[{\"Price\":1,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Benzin\",\"Ordered\":true}]', '{\"x\":1704.3513,\"y\":6419.2935,\"z\":31.51798}', '{\"x\":1693.342,\"y\":6428.457,\"z\":32.62834}', 141612, -1, '[{\"Name\":\"Benzin\",\"Amount\":2000}]', NULL);
INSERT INTO `businesses` VALUES (26, 'Staat', 100000, 1, '[{\"Price\":1,\"Lefts\":9999992,\"Autosell\":0,\"Name\":\"Benzin\",\"Ordered\":true}]', '{\"x\":183.71237,\"y\":6602.543,\"z\":30.72901}', '{\"x\":200.57169,\"y\":6622.218,\"z\":31.599367}', 216722, -1, '[{\"Name\":\"Benzin\",\"Amount\":2000}]', NULL);
INSERT INTO `businesses` VALUES (27, 'Staat', 100000, 1, '[{\"Price\":1,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Benzin\",\"Ordered\":true}]', '{\"x\":-93.27098,\"y\":6416.2183,\"z\":30.355282}', '{\"x\":-80.08007,\"y\":6422.028,\"z\":31.490456}', 516433, -1, '[{\"Name\":\"Benzin\",\"Amount\":2000}]', NULL);
INSERT INTO `businesses` VALUES (28, 'Staat', 100000, 1, '[{\"Price\":1,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Benzin\",\"Ordered\":true}]', '{\"x\":-2553.841,\"y\":2330.522,\"z\":31.940027}', '{\"x\":-2562.9756,\"y\":2319.8691,\"z\":33.060047}', 120279, -1, '[{\"Name\":\"Benzin\",\"Amount\":2000}]', NULL);
INSERT INTO `businesses` VALUES (29, 'Staat', 100000, 1, '[{\"Price\":1,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Benzin\",\"Ordered\":true}]', '{\"x\":51.150963,\"y\":2781.6335,\"z\":56.764008}', '{\"x\":64.9638,\"y\":2781.7,\"z\":57.8783}', 701329, -1, '[{\"Name\":\"Benzin\",\"Amount\":2000}]', NULL);
INSERT INTO `businesses` VALUES (30, 'Staat', 100000, 1, '[{\"Price\":1,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Benzin\",\"Ordered\":true}]', '{\"x\":262.0915,\"y\":2610.5864,\"z\":43.762592}', '{\"x\":277.6783,\"y\":2602.1555,\"z\":44.51823}', 728026, -1, '[{\"Name\":\"Benzin\",\"Amount\":2000}]', NULL);
INSERT INTO `businesses` VALUES (31, 'Staat', 100000, 1, '[{\"Price\":1,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Benzin\",\"Ordered\":true}]', '{\"x\":-1802.1952,\"y\":799.5343,\"z\":137.39346}', '{\"x\":-1817.6722,\"y\":804.47815,\"z\":138.58087}', 651177, -1, '[{\"Name\":\"Benzin\",\"Amount\":2000}]', NULL);
INSERT INTO `businesses` VALUES (32, 'Staat', 100000, 1, '[{\"Price\":1,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Benzin\",\"Ordered\":true}]', '{\"x\":-1434.0037,\"y\":-280.3034,\"z\":45.08766}', '{\"x\":-1414.526,\"y\":-281.9531,\"z\":46.31333}', 850340, -1, '[{\"Name\":\"Benzin\",\"Amount\":2000}]', NULL);
INSERT INTO `businesses` VALUES (33, 'Staat', 100000, 1, '[{\"Price\":1,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Benzin\",\"Ordered\":true}]', '{\"x\":-2092.5342,\"y\":-321.20724,\"z\":11.908093}', '{\"x\":-2077.2605,\"y\":-320.2983,\"z\":13.147014}', 902942, -1, '[{\"Name\":\"Benzin\",\"Amount\":2000}]', NULL);
INSERT INTO `businesses` VALUES (34, 'Staat', 100000, 1, '[{\"Price\":1,\"Lefts\":9999680,\"Autosell\":0,\"Name\":\"Benzin\",\"Ordered\":true}]', '{\"x\":-720.0122,\"y\":-935.8699,\"z\":17.89702}', '{\"x\":-724.67847,\"y\":-916.33167,\"z\":19.0139}', 990347, -1, '[{\"Name\":\"Benzin\",\"Amount\":2000}]', NULL);
INSERT INTO `businesses` VALUES (35, 'Staat', 100000, 1, '[{\"Price\":1,\"Lefts\":9999999,\"Autosell\":0,\"Name\":\"Benzin\",\"Ordered\":true}]', '{\"x\":-525.9035,\"y\":-1210.7319,\"z\":17.064856}', '{\"x\":-518.846,\"y\":-1222.5631,\"z\":18.300432}', 828907, -1, '[{\"Name\":\"Benzin\",\"Amount\":2000}]', NULL);
INSERT INTO `businesses` VALUES (36, 'Staat', 100000, 1, '[{\"Price\":1,\"Lefts\":9999901,\"Autosell\":0,\"Name\":\"Benzin\",\"Ordered\":true}]', '{\"x\":617.31067,\"y\":267.51834,\"z\":101.96938}', '{\"x\":637.64026,\"y\":255.98769,\"z\":103.152664}', 925485, -1, '[{\"Name\":\"Benzin\",\"Amount\":2000}]', NULL);
INSERT INTO `businesses` VALUES (37, 'Staat', 100000, 1, '[{\"Price\":1,\"Lefts\":99990993,\"Autosell\":0,\"Name\":\"Benzin\",\"Ordered\":true}]', '{\"x\":1181.8533,\"y\":-334.5947,\"z\":68.05661}', '{\"x\":1180.7788,\"y\":-315.50778,\"z\":69.17735}', 723357, -1, '[{\"Name\":\"Benzin\",\"Amount\":2000}]', NULL);
INSERT INTO `businesses` VALUES (38, 'Staat', 100000, 1, '[{\"Price\":1,\"Lefts\":9999989,\"Autosell\":0,\"Name\":\"Benzin\",\"Ordered\":true}]', '{\"x\":-75.127144,\"y\":-1760.7467,\"z\":28.420712}', '{\"x\":-77.97101,\"y\":-1746.3726,\"z\":29.407785}', 640623, -1, '[{\"Name\":\"Benzin\",\"Amount\":2000}]', NULL);
INSERT INTO `businesses` VALUES (39, 'Staat', 100000, 1, '[{\"Price\":1,\"Lefts\":9999902,\"Autosell\":0,\"Name\":\"Benzin\",\"Ordered\":true}]', '{\"x\":814.6629,\"y\":-1028.8214,\"z\":25.144245}', '{\"x\":806.68463,\"y\":-1045.4208,\"z\":26.657442}', 26538, -1, '[{\"Name\":\"Benzin\",\"Amount\":2000}]', NULL);
INSERT INTO `businesses` VALUES (40, 'Staat', 100000, 1, '[{\"Price\":1,\"Lefts\":9999853,\"Autosell\":0,\"Name\":\"Benzin\",\"Ordered\":true}]', '{\"x\":260.1057,\"y\":-1258.1235,\"z\":28.022892}', '{\"x\":251.42366,\"y\":-1270.8828,\"z\":29.219006}', 378407, -1, '[{\"Name\":\"Benzin\",\"Amount\":2000}]', NULL);
INSERT INTO `businesses` VALUES (41, 'Staat', 100000, 1, '[{\"Price\":1,\"Lefts\":9999974,\"Autosell\":0,\"Name\":\"Benzin\",\"Ordered\":true}]', '{\"x\":1207.476,\"y\":-1402.7478,\"z\":34.09829}', '{\"x\":1218.8715,\"y\":-1387.7352,\"z\":35.18534}', 226772, -1, '[{\"Name\":\"Benzin\",\"Amount\":2000}]', NULL);
INSERT INTO `businesses` VALUES (42, 'Staat', 100000, 1, '[{\"Price\":1,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Benzin\",\"Ordered\":true}]', '{\"x\":172.90228,\"y\":-1564.5527,\"z\":28.15733}', '{\"x\":159.53943,\"y\":-1565.8539,\"z\":29.248213}', 246198, -1, '[{\"Name\":\"Benzin\",\"Amount\":2000}]', NULL);
INSERT INTO `businesses` VALUES (44, 'Staat', 100000, 6, '[{\"Price\":3200,\"Lefts\":999910000,\"Autosell\":5,\"Name\":\"Pistol\",\"Ordered\":true},{\"Price\":3500,\"Lefts\":99991000,\"Autosell\":5,\"Name\":\"CombatPistol\",\"Ordered\":true},{\"Price\":4700,\"Lefts\":99991000,\"Autosell\":5,\"Name\":\"Revolver\",\"Ordered\":true},{\"Price\":5500,\"Lefts\":99991000,\"Autosell\":5,\"Name\":\"HeavyPistol\",\"Ordered\":true},{\"Price\":6800,\"Lefts\":99991000,\"Autosell\":5,\"Name\":\"BullpupShotgun\",\"Ordered\":true},{\"Price\":6500,\"Lefts\":99991000,\"Autosell\":5,\"Name\":\"CombatPDW\",\"Ordered\":true},{\"Price\":7600,\"Lefts\":99991000,\"Autosell\":5,\"Name\":\"MachinePistol\",\"Ordered\":true},{\"Price\":4,\"Lefts\":99991000,\"Autosell\":5,\"Name\":\"Katuschen\",\"Ordered\":true}]', '{\"x\":21.945244,\"y\":-1107.1622,\"z\":28.677025}', '{\"x\":0.0,\"y\":0.0,\"z\":0.0}', 392729, -1, '[{\"Name\":\"Pistol\",\"Amount\":20},{\"Name\":\"CombatPistol\",\"Amount\":20},{\"Name\":\"Revolver\",\"Amount\":20},{\"Name\":\"HeavyPistol\",\"Amount\":20},{\"Name\":\"BullpupShotgun\",\"Amount\":20},{\"Name\":\"CombatPDW\",\"Amount\":20},{\"Name\":\"MachinePistol\",\"Amount\":20},{\"Name\":\"Katuschen\",\"Amount\":500}]', NULL);
INSERT INTO `businesses` VALUES (45, 'Staat', 100000, 5, '[{\"Price\":1069,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Faggio2\",\"Ordered\":true},{\"Price\":17112,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Sanchez2\",\"Ordered\":true},{\"Price\":6417,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Enduro\",\"Ordered\":true},{\"Price\":7500,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"PCJ\",\"Ordered\":true},{\"Price\":28876,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Hexer\",\"Ordered\":true},{\"Price\":16577,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Lectro\",\"Ordered\":true},{\"Price\":14438,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Nemesis\",\"Ordered\":true},{\"Price\":37432,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Hakuchou\",\"Ordered\":true},{\"Price\":18716,\"Lefts\":9999999,\"Autosell\":0,\"Name\":\"Ruffian\",\"Ordered\":true},{\"Price\":100,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Bmx\",\"Ordered\":true},{\"Price\":299,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Scorcher\",\"Ordered\":true},{\"Price\":14973,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"BF400\",\"Ordered\":true},{\"Price\":21390,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"CarbonRS\",\"Ordered\":true},{\"Price\":27807,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Bati\",\"Ordered\":true},{\"Price\":25668,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Double\",\"Ordered\":true},{\"Price\":20320,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Diablous\",\"Ordered\":true},{\"Price\":18181,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Cliffhanger\",\"Ordered\":true},{\"Price\":19251,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Akuma\",\"Ordered\":true},{\"Price\":19251,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Thrust\",\"Ordered\":true},{\"Price\":32085,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Nightblade\",\"Ordered\":true},{\"Price\":25668,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Vindicator\",\"Ordered\":true},{\"Price\":3208,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Ratbike\",\"Ordered\":true},{\"Price\":18181,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Blazer\",\"Ordered\":true},{\"Price\":28341,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Gargoyle\",\"Ordered\":true},{\"Price\":44919,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Sanctus\",\"Ordered\":true}]', '{\"x\":289.3517,\"y\":-1154.6215,\"z\":28.124224}', '{\"x\":316.09958,\"y\":-1165.8745,\"z\":29.292067}', 970199, -1, '[{\"Name\":\"Faggio2\",\"Amount\":10},{\"Name\":\"Sanchez2\",\"Amount\":10},{\"Name\":\"Enduro\",\"Amount\":10},{\"Name\":\"PCJ\",\"Amount\":10},{\"Name\":\"Hexer\",\"Amount\":10},{\"Name\":\"Lectro\",\"Amount\":10},{\"Name\":\"Nemesis\",\"Amount\":10},{\"Name\":\"Hakuchou\",\"Amount\":10},{\"Name\":\"Ruffian\",\"Amount\":10},{\"Name\":\"Bmx\",\"Amount\":10},{\"Name\":\"Scorcher\",\"Amount\":10},{\"Name\":\"BF400\",\"Amount\":10},{\"Name\":\"CarbonRS\",\"Amount\":10},{\"Name\":\"Bati\",\"Amount\":10},{\"Name\":\"Double\",\"Amount\":10},{\"Name\":\"Diablous\",\"Amount\":10},{\"Name\":\"Cliffhanger\",\"Amount\":10},{\"Name\":\"Akuma\",\"Amount\":10},{\"Name\":\"Thrust\",\"Amount\":10},{\"Name\":\"Nightblade\",\"Amount\":10},{\"Name\":\"Vindicator\",\"Amount\":10},{\"Name\":\"Ratbike\",\"Amount\":10},{\"Name\":\"Blazer\",\"Amount\":10},{\"Name\":\"Gargoyle\",\"Amount\":10},{\"Name\":\"Sanctus\",\"Amount\":10}]', NULL);
INSERT INTO `businesses` VALUES (46, 'Staat', 100000, 3, '[{\"Price\":93480,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Comet2\",\"Ordered\":true},{\"Price\":99180,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Coquette\",\"Ordered\":true},{\"Price\":223100,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Ninef\",\"Ordered\":true},{\"Price\":242500,\"Lefts\":9999999,\"Autosell\":0,\"Name\":\"Ninef2\",\"Ordered\":true},{\"Price\":232800,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Jester\",\"Ordered\":true},{\"Price\":129010,\"Lefts\":9999997,\"Autosell\":0,\"Name\":\"Elegy2\",\"Ordered\":true},{\"Price\":266750,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Infernus\",\"Ordered\":true},{\"Price\":226980,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Carbonizzare\",\"Ordered\":true},{\"Price\":165300,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Dubsta2\",\"Ordered\":true},{\"Price\":98040,\"Lefts\":99990999,\"Autosell\":0,\"Name\":\"Baller3\",\"Ordered\":true},{\"Price\":182400,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Huntley\",\"Ordered\":true},{\"Price\":213400,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Superd\",\"Ordered\":true},{\"Price\":320100,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Windsor\",\"Ordered\":true},{\"Price\":111550,\"Lefts\":99990999,\"Autosell\":0,\"Name\":\"BestiaGTS\",\"Ordered\":true},{\"Price\":155200,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Banshee2\",\"Ordered\":true},{\"Price\":1746000,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"EntityXF\",\"Ordered\":true},{\"Price\":688700,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Neon\",\"Ordered\":true},{\"Price\":364800,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Jester2\",\"Ordered\":true},{\"Price\":460750,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Turismor\",\"Ordered\":true},{\"Price\":921500,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Penetrator\",\"Ordered\":true},{\"Price\":630500,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Omnis\",\"Ordered\":true},{\"Price\":426800,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Reaper\",\"Ordered\":true},{\"Price\":446200,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Italigtb2\",\"Ordered\":true},{\"Price\":523800,\"Lefts\":9999999,\"Autosell\":0,\"Name\":\"Xa21\",\"Ordered\":true},{\"Price\":1164300,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Osiris\",\"Ordered\":true},{\"Price\":873000,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Nero\",\"Ordered\":true},{\"Price\":1940000,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Zentorno\",\"Ordered\":true}]', '{\"x\":113.59224,\"y\":-142.11147,\"z\":53.742634}', '{\"x\":103.3072,\"y\":-149.90686,\"z\":54.749386}', 130458, -1, '[{\"Name\":\"Comet2\",\"Amount\":10},{\"Name\":\"Coquette\",\"Amount\":10},{\"Name\":\"Ninef\",\"Amount\":10},{\"Name\":\"Ninef2\",\"Amount\":10},{\"Name\":\"Jester\",\"Amount\":10},{\"Name\":\"Elegy2\",\"Amount\":10},{\"Name\":\"Infernus\",\"Amount\":10},{\"Name\":\"Carbonizzare\",\"Amount\":10},{\"Name\":\"Dubsta2\",\"Amount\":10},{\"Name\":\"Baller3\",\"Amount\":10},{\"Name\":\"Huntley\",\"Amount\":10},{\"Name\":\"Superd\",\"Amount\":10},{\"Name\":\"Windsor\",\"Amount\":10},{\"Name\":\"BestiaGTS\",\"Amount\":10},{\"Name\":\"Banshee2\",\"Amount\":10},{\"Name\":\"EntityXF\",\"Amount\":10},{\"Name\":\"Neon\",\"Amount\":10},{\"Name\":\"Jester2\",\"Amount\":10},{\"Name\":\"Turismor\",\"Amount\":10},{\"Name\":\"Penetrator\",\"Amount\":10},{\"Name\":\"Omnis\",\"Amount\":10},{\"Name\":\"Reaper\",\"Amount\":10},{\"Name\":\"Italigtb2\",\"Amount\":10},{\"Name\":\"Xa21\",\"Amount\":10},{\"Name\":\"Osiris\",\"Amount\":10},{\"Name\":\"Nero\",\"Amount\":10},{\"Name\":\"Zentorno\",\"Amount\":10}]', NULL);
INSERT INTO `businesses` VALUES (47, 'Staat', 100000, 2, '[{\"Price\":42180,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Sultan\",\"Ordered\":true},{\"Price\":136800,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"SultanRS\",\"Ordered\":true},{\"Price\":155200,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Kuruma\",\"Ordered\":true},{\"Price\":39036,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Fugitive\",\"Ordered\":true},{\"Price\":49197,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Tailgater\",\"Ordered\":true},{\"Price\":51300,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Sentinel\",\"Ordered\":true},{\"Price\":96900,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"F620\",\"Ordered\":true},{\"Price\":102600,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Schwarzer\",\"Ordered\":true},{\"Price\":77520,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Exemplar\",\"Ordered\":true},{\"Price\":83220,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Felon\",\"Ordered\":true},{\"Price\":145920,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Schafter2\",\"Ordered\":true},{\"Price\":71820,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Jackal\",\"Ordered\":true},{\"Price\":62700,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Oracle2\",\"Ordered\":true},{\"Price\":203700,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Surano\",\"Ordered\":true},{\"Price\":58140,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Zion\",\"Ordered\":true},{\"Price\":57000,\"Lefts\":9999999,\"Autosell\":0,\"Name\":\"Dominator\",\"Ordered\":true},{\"Price\":63840,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"FQ2\",\"Ordered\":true},{\"Price\":61560,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Gresley\",\"Ordered\":true},{\"Price\":39571,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Serrano\",\"Ordered\":true},{\"Price\":108300,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Dubsta\",\"Ordered\":true},{\"Price\":152290,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Rocoto\",\"Ordered\":true},{\"Price\":88920,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Cavalcade2\",\"Ordered\":true},{\"Price\":92340,\"Lefts\":9999999,\"Autosell\":0,\"Name\":\"XLS\",\"Ordered\":true},{\"Price\":85500,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Baller2\",\"Ordered\":true},{\"Price\":69840,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Elegy\",\"Ordered\":true},{\"Price\":150350,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Banshee\",\"Ordered\":true},{\"Price\":242500,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Massacro2\",\"Ordered\":true},{\"Price\":776000,\"Lefts\":9999999,\"Autosell\":0,\"Name\":\"GP1\",\"Ordered\":true}]', '{\"x\":-55.680775,\"y\":67.54389,\"z\":70.83}', '{\"x\":-75.73583,\"y\":59.209778,\"z\":71.84209}', 453018, -1, '[{\"Name\":\"Sultan\",\"Amount\":10},{\"Name\":\"SultanRS\",\"Amount\":10},{\"Name\":\"Kuruma\",\"Amount\":10},{\"Name\":\"Fugitive\",\"Amount\":10},{\"Name\":\"Tailgater\",\"Amount\":10},{\"Name\":\"Sentinel\",\"Amount\":10},{\"Name\":\"F620\",\"Amount\":10},{\"Name\":\"Schwarzer\",\"Amount\":10},{\"Name\":\"Exemplar\",\"Amount\":10},{\"Name\":\"Felon\",\"Amount\":10},{\"Name\":\"Schafter2\",\"Amount\":10},{\"Name\":\"Jackal\",\"Amount\":10},{\"Name\":\"Oracle2\",\"Amount\":10},{\"Name\":\"Surano\",\"Amount\":10},{\"Name\":\"Zion\",\"Amount\":10},{\"Name\":\"Dominator\",\"Amount\":10},{\"Name\":\"FQ2\",\"Amount\":10},{\"Name\":\"Gresley\",\"Amount\":10},{\"Name\":\"Serrano\",\"Amount\":10},{\"Name\":\"Dubsta\",\"Amount\":10},{\"Name\":\"Rocoto\",\"Amount\":10},{\"Name\":\"Cavalcade2\",\"Amount\":10},{\"Name\":\"XLS\",\"Amount\":10},{\"Name\":\"Baller2\",\"Amount\":10},{\"Name\":\"Elegy\",\"Amount\":10},{\"Name\":\"Banshee\",\"Amount\":10},{\"Name\":\"Massacro2\",\"Amount\":10},{\"Name\":\"GP1\",\"Amount\":10}]', NULL);
INSERT INTO `businesses` VALUES (48, 'Staat', 100000, 4, '[{\"Price\":3529,\"Lefts\":9999999,\"Autosell\":0,\"Name\":\"Tornado3\",\"Ordered\":true},{\"Price\":2743,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Tornado4\",\"Ordered\":true},{\"Price\":4491,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Emperor2\",\"Ordered\":true},{\"Price\":9975,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Voodoo2\",\"Ordered\":true},{\"Price\":22459,\"Lefts\":9999999,\"Autosell\":0,\"Name\":\"Regina\",\"Ordered\":true},{\"Price\":19251,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Ingot\",\"Ordered\":true},{\"Price\":8021,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Emperor\",\"Ordered\":true},{\"Price\":23370,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Picador\",\"Ordered\":true},{\"Price\":34224,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Minivan\",\"Ordered\":true},{\"Price\":23101,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Blista2\",\"Ordered\":true},{\"Price\":43849,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Manana\",\"Ordered\":true},{\"Price\":25668,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Dilettante\",\"Ordered\":true},{\"Price\":24598,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Asea\",\"Ordered\":true},{\"Price\":50266,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Glendale\",\"Ordered\":true},{\"Price\":36480,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Voodoo\",\"Ordered\":true},{\"Price\":40461,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Surge\",\"Ordered\":true},{\"Price\":18716,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Primo\",\"Ordered\":true},{\"Price\":30480,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Stanier\",\"Ordered\":true},{\"Price\":20320,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Stratum\",\"Ordered\":true},{\"Price\":23529,\"Lefts\":9999997,\"Autosell\":0,\"Name\":\"Tampa\",\"Ordered\":true},{\"Price\":26737,\"Lefts\":99990999,\"Autosell\":0,\"Name\":\"Prairie\",\"Ordered\":true},{\"Price\":18181,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Radi\",\"Ordered\":true},{\"Price\":19892,\"Lefts\":9999997,\"Autosell\":0,\"Name\":\"Blista\",\"Ordered\":true},{\"Price\":25668,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Stalion\",\"Ordered\":true},{\"Price\":33689,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Asterope\",\"Ordered\":true},{\"Price\":35293,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Washington\",\"Ordered\":true},{\"Price\":27272,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Premier\",\"Ordered\":true},{\"Price\":36363,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Intruder\",\"Ordered\":true},{\"Price\":16042,\"Lefts\":9999999,\"Autosell\":0,\"Name\":\"Ruiner\",\"Ordered\":true},{\"Price\":68400,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Oracle\",\"Ordered\":true},{\"Price\":27807,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Phoenix\",\"Ordered\":true},{\"Price\":54720,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Gauntlet\",\"Ordered\":true},{\"Price\":62700,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Buffalo\",\"Ordered\":true},{\"Price\":44919,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"RancherXL\",\"Ordered\":true},{\"Price\":47639,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Seminole\",\"Ordered\":true},{\"Price\":71820,\"Lefts\":9999999,\"Autosell\":0,\"Name\":\"Baller\",\"Ordered\":true},{\"Price\":64980,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Landstalker\",\"Ordered\":true},{\"Price\":59280,\"Lefts\":9999999,\"Autosell\":0,\"Name\":\"Cavalcade\",\"Ordered\":true},{\"Price\":37432,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"BJXL\",\"Ordered\":true},{\"Price\":77520,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Patriot\",\"Ordered\":true},{\"Price\":26737,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Bison3\",\"Ordered\":true},{\"Price\":23529,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Issi2\",\"Ordered\":true},{\"Price\":38502,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Panto\",\"Ordered\":true}]', '{\"x\":-30.649624,\"y\":-1104.4791,\"z\":25.302336}', '{\"x\":-44.82458,\"y\":-1115.8655,\"z\":26.434563}', 358780, -1, '[{\"Name\":\"Tornado3\",\"Amount\":10},{\"Name\":\"Tornado4\",\"Amount\":10},{\"Name\":\"Emperor2\",\"Amount\":10},{\"Name\":\"Voodoo2\",\"Amount\":10},{\"Name\":\"Regina\",\"Amount\":10},{\"Name\":\"Ingot\",\"Amount\":10},{\"Name\":\"Emperor\",\"Amount\":10},{\"Name\":\"Picador\",\"Amount\":10},{\"Name\":\"Minivan\",\"Amount\":10},{\"Name\":\"Blista2\",\"Amount\":10},{\"Name\":\"Manana\",\"Amount\":10},{\"Name\":\"Dilettante\",\"Amount\":10},{\"Name\":\"Asea\",\"Amount\":10},{\"Name\":\"Glendale\",\"Amount\":10},{\"Name\":\"Voodoo\",\"Amount\":10},{\"Name\":\"Surge\",\"Amount\":10},{\"Name\":\"Primo\",\"Amount\":10},{\"Name\":\"Stanier\",\"Amount\":10},{\"Name\":\"Stratum\",\"Amount\":10},{\"Name\":\"Tampa\",\"Amount\":10},{\"Name\":\"Prairie\",\"Amount\":10},{\"Name\":\"Radi\",\"Amount\":10},{\"Name\":\"Blista\",\"Amount\":10},{\"Name\":\"Stalion\",\"Amount\":10},{\"Name\":\"Asterope\",\"Amount\":10},{\"Name\":\"Washington\",\"Amount\":10},{\"Name\":\"Premier\",\"Amount\":10},{\"Name\":\"Intruder\",\"Amount\":10},{\"Name\":\"Ruiner\",\"Amount\":10},{\"Name\":\"Oracle\",\"Amount\":10},{\"Name\":\"Phoenix\",\"Amount\":10},{\"Name\":\"Gauntlet\",\"Amount\":10},{\"Name\":\"Buffalo\",\"Amount\":10},{\"Name\":\"RancherXL\",\"Amount\":10},{\"Name\":\"Seminole\",\"Amount\":10},{\"Name\":\"Baller\",\"Amount\":10},{\"Name\":\"Landstalker\",\"Amount\":10},{\"Name\":\"Cavalcade\",\"Amount\":10},{\"Name\":\"BJXL\",\"Amount\":10},{\"Name\":\"Patriot\",\"Amount\":10},{\"Name\":\"Bison3\",\"Amount\":10},{\"Name\":\"Issi2\",\"Amount\":10},{\"Name\":\"Panto\",\"Amount\":10}]', NULL);
INSERT INTO `businesses` VALUES (49, 'Staat', 100000, 11, '[{\"Price\":100,\"Lefts\":99994999,\"Autosell\":0,\"Name\":\"Masken\",\"Ordered\":true}]', '{\"x\":451.40958,\"y\":-801.7556,\"z\":26.410145}', '{\"x\":453.5247,\"y\":-810.41156,\"z\":27.701628}', 885020, -1, '[{\"Name\":\"Masken\",\"Amount\":100}]', NULL);
INSERT INTO `businesses` VALUES (50, 'Staat', 100000, 11, '[{\"Price\":100,\"Lefts\":99995000,\"Autosell\":0,\"Name\":\"Masken\",\"Ordered\":true}]', '{\"x\":-1337.1019,\"y\":-1278.3806,\"z\":3.7467809}', '{\"x\":-1345.9202,\"y\":-1286.3628,\"z\":4.838157}', 519877, -1, '[{\"Name\":\"Masken\",\"Amount\":100}]', NULL);
INSERT INTO `businesses` VALUES (51, 'Staat', 100000, 7, '[{\"Price\":100,\"Lefts\":99997,\"Autosell\":10,\"Name\":\"Kleidung\",\"Ordered\":true}]', '{\"x\":424.87982,\"y\":-806.19214,\"z\":28.371126}', '{\"x\":413.56116,\"y\":-802.2092,\"z\":29.314978}', 124481, -1, '[{\"Name\":\"Kleidung\",\"Amount\":700}]', NULL);
INSERT INTO `businesses` VALUES (52, 'Staat', 100000, 7, '[{\"Price\":100,\"Lefts\":9998258,\"Autosell\":10,\"Name\":\"Kleidung\",\"Ordered\":true}]', '{\"x\":124.367325,\"y\":-224.29436,\"z\":53.437836}', '{\"x\":136.4857,\"y\":-202.14915,\"z\":54.45523}', 955313, -1, '[{\"Name\":\"Kleidung\",\"Amount\":700}]', NULL);
INSERT INTO `businesses` VALUES (53, 'Staat', 100000, 7, '[{\"Price\":100,\"Lefts\":99991524,\"Autosell\":10,\"Name\":\"Kleidung\",\"Ordered\":true}]', '{\"x\":-710.611,\"y\":-153.84297,\"z\":36.29514}', '{\"x\":-724.69696,\"y\":-156.34737,\"z\":37.05282}', 923129, -1, '[{\"Name\":\"Kleidung\",\"Amount\":700}]', NULL);
INSERT INTO `businesses` VALUES (54, 'Staat', 100000, 7, '[{\"Price\":100,\"Lefts\":99997040,\"Autosell\":10,\"Name\":\"Kleidung\",\"Ordered\":true}]', '{\"x\":-161.83803,\"y\":-302.93274,\"z\":38.613285}', '{\"x\":-151.10387,\"y\":-308.70206,\"z\":38.565704}', 345312, -1, '[]', NULL);
INSERT INTO `businesses` VALUES (55, 'Staat', 100000, 7, '[{\"Price\":100,\"Lefts\":99992000,\"Autosell\":10,\"Name\":\"Kleidung\",\"Ordered\":true}]', '{\"x\":-1451.9366,\"y\":-236.88278,\"z\":48.68754}', '{\"x\":-1457.8407,\"y\":-227.18132,\"z\":49.132748}', 727377, -1, '[{\"Name\":\"Kleidung\",\"Amount\":700}]', NULL);
INSERT INTO `businesses` VALUES (56, 'Staat', 100000, 7, '[{\"Price\":100,\"Lefts\":99992000,\"Autosell\":10,\"Name\":\"Kleidung\",\"Ordered\":true}]', '{\"x\":-1191.295,\"y\":-768.0598,\"z\":16.20069}', '{\"x\":-1214.8947,\"y\":-783.7184,\"z\":17.316103}', 127352, -1, '[{\"Name\":\"Kleidung\",\"Amount\":700}]', NULL);
INSERT INTO `businesses` VALUES (57, 'Staat', 100000, 7, '[{\"Price\":100,\"Lefts\":99995000,\"Autosell\":10,\"Name\":\"Kleidung\",\"Ordered\":true}]', '{\"x\":-819.23413,\"y\":-1073.8416,\"z\":10.208109}', '{\"x\":-821.80646,\"y\":-1088.608,\"z\":11.013381}', 438568, -1, '[{\"Name\":\"Kleidung\",\"Amount\":700}]', NULL);
INSERT INTO `businesses` VALUES (58, 'Staat', 100000, 7, '[{\"Price\":100,\"Lefts\":99991904,\"Autosell\":10,\"Name\":\"Kleidung\",\"Ordered\":true}]', '{\"x\":77.30829,\"y\":-1390.5344,\"z\":28.256144}', '{\"x\":87.747154,\"y\":-1401.72,\"z\":29.162518}', 824362, -1, '[{\"Name\":\"Kleidung\",\"Amount\":700}]', NULL);
INSERT INTO `businesses` VALUES (59, 'Staat', 100000, 7, '[{\"Price\":100,\"Lefts\":99992000,\"Autosell\":10,\"Name\":\"Kleidung\",\"Ordered\":true}]', '{\"x\":-3172.5388,\"y\":1043.1136,\"z\":19.743214}', '{\"x\":-3164.214,\"y\":1070.197,\"z\":20.680527}', 718396, -1, '[{\"Name\":\"Kleidung\",\"Amount\":700}]', NULL);
INSERT INTO `businesses` VALUES (60, 'Staat', 100000, 7, '[{\"Price\":100,\"Lefts\":99992000,\"Autosell\":10,\"Name\":\"Kleidung\",\"Ordered\":true}]', '{\"x\":-1098.5682,\"y\":2710.56,\"z\":17.987871}', '{\"x\":-1097.0502,\"y\":2701.7285,\"z\":18.927456}', 33990, -1, '[{\"Name\":\"Kleidung\",\"Amount\":700}]', NULL);
INSERT INTO `businesses` VALUES (61, 'Staat', 100000, 7, '[{\"Price\":100,\"Lefts\":99991516,\"Autosell\":10,\"Name\":\"Kleidung\",\"Ordered\":true}]', '{\"x\":615.3248,\"y\":2764.1475,\"z\":40.968094}', '{\"x\":614.66315,\"y\":2739.0767,\"z\":41.911545}', 58502, -1, '[{\"Name\":\"Kleidung\",\"Amount\":700}]', NULL);
INSERT INTO `businesses` VALUES (62, 'Staat', 100000, 7, '[{\"Price\":100,\"Lefts\":99992000,\"Autosell\":10,\"Name\":\"Kleidung\",\"Ordered\":true}]', '{\"x\":1198.8292,\"y\":2708.2507,\"z\":37.102642}', '{\"x\":1193.8125,\"y\":2697.1936,\"z\":37.959824}', 875154, -1, '[{\"Name\":\"Kleidung\",\"Amount\":700}]', NULL);
INSERT INTO `businesses` VALUES (63, 'Staat', 100000, 7, '[{\"Price\":100,\"Lefts\":99992000,\"Autosell\":10,\"Name\":\"Kleidung\",\"Ordered\":true}]', '{\"x\":1692.0734,\"y\":4820.272,\"z\":40.943127}', '{\"x\":1681.2778,\"y\":4824.514,\"z\":42.015514}', 127390, -1, '[{\"Name\":\"Kleidung\",\"Amount\":700}]', NULL);
INSERT INTO `businesses` VALUES (64, 'Staat', 100000, 7, '[{\"Price\":100,\"Lefts\":99992000,\"Autosell\":10,\"Name\":\"Kleidung\",\"Ordered\":true}]', '{\"x\":1.8060646,\"y\":6512.0273,\"z\":30.75785}', '{\"x\":-1.0943323,\"y\":6522.526,\"z\":31.30212}', 344777, -1, '[{\"Name\":\"Kleidung\",\"Amount\":700}]', NULL);
INSERT INTO `businesses` VALUES (65, 'Staat', 100000, 9, '[{\"Price\":100,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Verbrauchsmaterial\",\"Ordered\":true},{\"Price\":100,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Tattoos\",\"Ordered\":true}]', '{\"x\":-290.47882,\"y\":6198.596,\"z\":30.381056}', '{\"x\":-285.33453,\"y\":6201.3276,\"z\":31.317516}', 821346, -1, '[{\"Name\":\"Verbrauchsmaterial\",\"Amount\":9000},{\"Name\":\"Tattoos\",\"Amount\":2500}]', NULL);
INSERT INTO `businesses` VALUES (66, 'Staat', 100000, 9, '[{\"Price\":100,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Verbrauchsmaterial\",\"Ordered\":true},{\"Price\":100,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Tattoos\",\"Ordered\":true}]', '{\"x\":1861.2169,\"y\":3749.9756,\"z\":31.926271}', '{\"x\":1852.157,\"y\":3746.9688,\"z\":33.0592}', 142223, -1, '[{\"Name\":\"Verbrauchsmaterial\",\"Amount\":9000},{\"Name\":\"Tattoos\",\"Amount\":2500}]', NULL);
INSERT INTO `businesses` VALUES (67, 'Staat', 100000, 9, '[{\"Price\":100,\"Lefts\":99990,\"Autosell\":0,\"Name\":\"Verbrauchsmaterial\",\"Ordered\":true},{\"Price\":100,\"Lefts\":99990,\"Autosell\":0,\"Name\":\"Tattoos\",\"Ordered\":true}]', '{\"x\":321.58618,\"y\":180.28737,\"z\":102.46651}', '{\"x\":298.08646,\"y\":174.60709,\"z\":104.008965}', 394806, -1, '[]', NULL);
INSERT INTO `businesses` VALUES (68, 'Staat', 100000, 9, '[{\"Price\":100,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Verbrauchsmaterial\",\"Ordered\":true},{\"Price\":100,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Tattoos\",\"Ordered\":true}]', '{\"x\":-1153.8303,\"y\":-1424.6412,\"z\":3.8344622}', '{\"x\":-1154.4989,\"y\":-1413.8309,\"z\":4.847532}', 22451, -1, '[{\"Name\":\"Verbrauchsmaterial\",\"Amount\":9000},{\"Name\":\"Tattoos\",\"Amount\":2500}]', NULL);
INSERT INTO `businesses` VALUES (69, 'Staat', 100000, 9, '[{\"Price\":100,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Verbrauchsmaterial\",\"Ordered\":true},{\"Price\":100,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Tattoos\",\"Ordered\":true}]', '{\"x\":-3169.5112,\"y\":1074.8917,\"z\":19.709185}', '{\"x\":-3164.0244,\"y\":1070.3713,\"z\":20.680626}', 662157, -1, '[{\"Name\":\"Verbrauchsmaterial\",\"Amount\":9000},{\"Name\":\"Tattoos\",\"Amount\":2500}]', NULL);
INSERT INTO `businesses` VALUES (70, 'Staat', 100000, 9, '[{\"Price\":100,\"Lefts\":9999888,\"Autosell\":0,\"Name\":\"Verbrauchsmaterial\",\"Ordered\":true},{\"Price\":100,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Tattoos\",\"Ordered\":true}]', '{\"x\":1322.5927,\"y\":-1651.5089,\"z\":51.15502}', '{\"x\":1318.3759,\"y\":-1639.0361,\"z\":52.34871}', 657984, -1, '[{\"Name\":\"Verbrauchsmaterial\",\"Amount\":9000},{\"Name\":\"Tattoos\",\"Amount\":2500}]', NULL);
INSERT INTO `businesses` VALUES (71, 'Staat', 100000, 10, '[{\"Price\":100,\"Lefts\":9999996,\"Autosell\":0,\"Name\":\"Verbrauchsmaterial\",\"Ordered\":true},{\"Price\":100,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Perücken\",\"Ordered\":true}]', '{\"x\":133.16072,\"y\":-1709.757,\"z\":28.17162}', '{\"x\":124.71333,\"y\":-1712.994,\"z\":29.070063}', 968918, -1, '[{\"Name\":\"Verbrauchsmaterial\",\"Amount\":9000},{\"Name\":\"Perücken\",\"Amount\":3000}]', NULL);
INSERT INTO `businesses` VALUES (72, 'Staat', 100000, 10, '[{\"Price\":100,\"Lefts\":9999999,\"Autosell\":0,\"Name\":\"Verbrauchsmaterial\",\"Ordered\":true},{\"Price\":100,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Perücken\",\"Ordered\":true}]', '{\"x\":1209.5071,\"y\":-470.204,\"z\":65.08801}', '{\"x\":1199.5908,\"y\":-463.46436,\"z\":66.24102}', 101741, -1, '[{\"Name\":\"Verbrauchsmaterial\",\"Amount\":9000},{\"Name\":\"Perücken\",\"Amount\":3000}]', NULL);
INSERT INTO `businesses` VALUES (73, 'Staat', 100000, 10, '[{\"Price\":100,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Verbrauchsmaterial\",\"Ordered\":true},{\"Price\":100,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Perücken\",\"Ordered\":true}]', '{\"x\":-30.193626,\"y\":-149.68477,\"z\":55.956505}', '{\"x\":-27.974424,\"y\":-138.62822,\"z\":56.918636}', 13508, -1, '[{\"Name\":\"Verbrauchsmaterial\",\"Amount\":9000},{\"Name\":\"Perücken\",\"Amount\":3000}]', NULL);
INSERT INTO `businesses` VALUES (74, 'Staat', 100000, 10, '[{\"Price\":100,\"Lefts\":9999998,\"Autosell\":0,\"Name\":\"Verbrauchsmaterial\",\"Ordered\":true},{\"Price\":100,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Perücken\",\"Ordered\":true}]', '{\"x\":-821.5079,\"y\":-185.41676,\"z\":36.44893}', '{\"x\":-829.248,\"y\":-189.0509,\"z\":37.616367}', 340591, -1, '[{\"Name\":\"Verbrauchsmaterial\",\"Amount\":9000},{\"Name\":\"Perücken\",\"Amount\":3000}]', NULL);
INSERT INTO `businesses` VALUES (75, 'Staat', 100000, 10, '[{\"Price\":100,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Verbrauchsmaterial\",\"Ordered\":true},{\"Price\":100,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Perücken\",\"Ordered\":true}]', '{\"x\":-1286.3701,\"y\":-1115.6727,\"z\":5.870113}', '{\"x\":-1295.3693,\"y\":-1114.8357,\"z\":6.726266}', 964428, -1, '[{\"Name\":\"Verbrauchsmaterial\",\"Amount\":9000},{\"Name\":\"Perücken\",\"Amount\":3000}]', NULL);
INSERT INTO `businesses` VALUES (76, 'Staat', 100000, 10, '[{\"Price\":100,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Verbrauchsmaterial\",\"Ordered\":true},{\"Price\":100,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Perücken\",\"Ordered\":true}]', '{\"x\":1932.0237,\"y\":3726.3213,\"z\":31.724428}', '{\"x\":1933.8889,\"y\":3719.696,\"z\":32.73379}', 233543, -1, '[{\"Name\":\"Verbrauchsmaterial\",\"Amount\":9000},{\"Name\":\"Perücken\",\"Amount\":3000}]', NULL);
INSERT INTO `businesses` VALUES (77, 'Staat', 100000, 10, '[{\"Price\":100,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Verbrauchsmaterial\",\"Ordered\":true},{\"Price\":100,\"Lefts\":99991000,\"Autosell\":0,\"Name\":\"Perücken\",\"Ordered\":true}]', '{\"x\":-279.2398,\"y\":6231.7817,\"z\":30.575516}', '{\"x\":-284.36264,\"y\":6240.288,\"z\":31.260262}', 624884, -1, '[{\"Name\":\"Verbrauchsmaterial\",\"Amount\":9000},{\"Name\":\"Perücken\",\"Amount\":3000}]', NULL);
INSERT INTO `businesses` VALUES (78, 'Staat', 100000, 8, '[{\"Price\":2,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Burger\",\"Ordered\":true},{\"Price\":2,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Hotdog\",\"Ordered\":true},{\"Price\":2,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Sandwich\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"eCola\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Sprunk\",\"Ordered\":true},{\"Price\":1,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Wasser\",\"Ordered\":true},{\"Price\":1,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Kaffee\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Donut\",\"Ordered\":true}]', '{\"x\":1591.3612,\"y\":6450.3467,\"z\":24.19714}', '{\"x\":1583.6106,\"y\":6449.9424,\"z\":25.186108}', 736989, -1, '[{\"Name\":\"Burger\",\"Amount\":2500},{\"Name\":\"Hotdog\",\"Amount\":2500},{\"Name\":\"Sandwich\",\"Amount\":2500},{\"Name\":\"eCola\",\"Amount\":1000},{\"Name\":\"Sprunk\",\"Amount\":1000},{\"Name\":\"Wasser\",\"Amount\":2500},{\"Name\":\"Kaffee\",\"Amount\":2500},{\"Name\":\"Donut\",\"Amount\":2500}]', NULL);
INSERT INTO `businesses` VALUES (79, 'Staat', 100000, 8, '[{\"Price\":2,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Burger\",\"Ordered\":true},{\"Price\":2,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Hotdog\",\"Ordered\":true},{\"Price\":2,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Sandwich\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"eCola\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Sprunk\",\"Ordered\":true},{\"Price\":1,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Wasser\",\"Ordered\":true},{\"Price\":1,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Kaffee\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Donut\",\"Ordered\":true}]', '{\"x\":2580.7356,\"y\":464.51584,\"z\":107.501686}', '{\"x\":2588.7239,\"y\":449.77167,\"z\":108.455666}', 671602, -1, '[{\"Name\":\"Burger\",\"Amount\":2500},{\"Name\":\"Hotdog\",\"Amount\":2500},{\"Name\":\"Sandwich\",\"Amount\":2500},{\"Name\":\"eCola\",\"Amount\":1000},{\"Name\":\"Sprunk\",\"Amount\":1000},{\"Name\":\"Wasser\",\"Amount\":2500},{\"Name\":\"Kaffee\",\"Amount\":2500},{\"Name\":\"Donut\",\"Amount\":2500}]', NULL);
INSERT INTO `businesses` VALUES (80, 'Staat', 100000, 8, '[{\"Price\":2,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Burger\",\"Ordered\":true},{\"Price\":2,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Hotdog\",\"Ordered\":true},{\"Price\":2,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Sandwich\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"eCola\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Sprunk\",\"Ordered\":true},{\"Price\":1,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Wasser\",\"Ordered\":true},{\"Price\":1,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Kaffee\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Donut\",\"Ordered\":true}]', '{\"x\":-1181.6752,\"y\":-883.26807,\"z\":12.679766}', '{\"x\":-1172.4398,\"y\":-876.26044,\"z\":14.13642}', 653306, -1, '[{\"Name\":\"Burger\",\"Amount\":2500},{\"Name\":\"Hotdog\",\"Amount\":2500},{\"Name\":\"Sandwich\",\"Amount\":2500},{\"Name\":\"eCola\",\"Amount\":1000},{\"Name\":\"Sprunk\",\"Amount\":1000},{\"Name\":\"Wasser\",\"Amount\":2500},{\"Name\":\"Kaffee\",\"Amount\":2500},{\"Name\":\"Donut\",\"Amount\":2500}]', NULL);
INSERT INTO `businesses` VALUES (81, 'Staat', 100000, 8, '[{\"Price\":2,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Burger\",\"Ordered\":true},{\"Price\":2,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Hotdog\",\"Ordered\":true},{\"Price\":2,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Sandwich\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"eCola\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Sprunk\",\"Ordered\":true},{\"Price\":1,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Wasser\",\"Ordered\":true},{\"Price\":1,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Kaffee\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Donut\",\"Ordered\":true}]', '{\"x\":80.86259,\"y\":273.47882,\"z\":109.081474}', '{\"x\":93.86368,\"y\":274.05502,\"z\":109.89422}', 196562, -1, '[{\"Name\":\"Burger\",\"Amount\":2500},{\"Name\":\"Hotdog\",\"Amount\":2500},{\"Name\":\"Sandwich\",\"Amount\":2500},{\"Name\":\"eCola\",\"Amount\":1000},{\"Name\":\"Sprunk\",\"Amount\":1000},{\"Name\":\"Wasser\",\"Amount\":2500},{\"Name\":\"Kaffee\",\"Amount\":2500},{\"Name\":\"Donut\",\"Amount\":2500}]', NULL);
INSERT INTO `businesses` VALUES (82, 'Staat', 100000, 8, '[{\"Price\":2,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Burger\",\"Ordered\":true},{\"Price\":2,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Hotdog\",\"Ordered\":true},{\"Price\":2,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Sandwich\",\"Ordered\":true},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"eCola\",\"Ordered\":true},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Sprunk\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Wasser\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Kaffee\",\"Ordered\":true},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Donut\",\"Ordered\":true}]', '{\"x\":-138.10857,\"y\":-256.82632,\"z\":42.474968}', '{\"x\":-134.05104,\"y\":-262.01263,\"z\":42.979355}', 958272, -1, '[{\"Name\":\"Burger\",\"Amount\":2500},{\"Name\":\"Hotdog\",\"Amount\":2500},{\"Name\":\"Sandwich\",\"Amount\":2500},{\"Name\":\"eCola\",\"Amount\":1000},{\"Name\":\"Sprunk\",\"Amount\":1000},{\"Name\":\"Wasser\",\"Amount\":2500},{\"Name\":\"Kaffee\",\"Amount\":2500},{\"Name\":\"Donut\",\"Amount\":2500}]', NULL);
INSERT INTO `businesses` VALUES (83, 'Staat', 100000, 8, '[{\"Price\":2,\"Lefts\":9999996,\"Autosell\":1,\"Name\":\"Burger\",\"Ordered\":true},{\"Price\":2,\"Lefts\":9999997,\"Autosell\":1,\"Name\":\"Hotdog\",\"Ordered\":true},{\"Price\":2,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Sandwich\",\"Ordered\":true},{\"Price\":3,\"Lefts\":9999996,\"Autosell\":1,\"Name\":\"eCola\",\"Ordered\":true},{\"Price\":3,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Sprunk\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999997,\"Autosell\":1,\"Name\":\"Wasser\",\"Ordered\":true},{\"Price\":1,\"Lefts\":9999999,\"Autosell\":1,\"Name\":\"Kaffee\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99991000,\"Autosell\":1,\"Name\":\"Donut\",\"Ordered\":true}]', '{\"x\":49.52165,\"y\":-1000.26074,\"z\":28.237396}', '{\"x\":58.134094,\"y\":-996.3499,\"z\":29.209106}', 547312, -1, '[{\"Name\":\"Burger\",\"Amount\":2500},{\"Name\":\"Hotdog\",\"Amount\":2500},{\"Name\":\"Sandwich\",\"Amount\":2500},{\"Name\":\"eCola\",\"Amount\":1000},{\"Name\":\"Sprunk\",\"Amount\":1000},{\"Name\":\"Wasser\",\"Amount\":2500},{\"Name\":\"Kaffee\",\"Amount\":2500},{\"Name\":\"Donut\",\"Amount\":2500}]', NULL);
INSERT INTO `businesses` VALUES (84, 'Staat', 100000, 12, '[{\"Price\":100,\"Lefts\":9999957,\"Autosell\":0,\"Name\":\"Ersatzteile\",\"Ordered\":true}]', '{\"x\":-212.56126,\"y\":-1323.4978,\"z\":29.770384}', '{\"x\":-206.14058,\"y\":-1305.0844,\"z\":31.361525}', 773997, -1, '[{\"Name\":\"Ersatzteile\",\"Amount\":1000}]', NULL);
INSERT INTO `businesses` VALUES (85, 'Staat', 1000000, 7, '[{\"Price\":100,\"Lefts\":99997221,\"Autosell\":10,\"Name\":\"Kleidung\",\"Ordered\":true}]', '{\"x\":199.88576,\"y\":-872.6184,\"z\":29.593042}', '{\"x\":207.39307,\"y\":-872.2928,\"z\":30.69142}', 124678, -1, '[{\"Name\":\"Kleidung\",\"Amount\":700}]', NULL);
INSERT INTO `businesses` VALUES (86, 'Staat', 10000000, 0, '[{\"Price\":150,\"Lefts\":999999,\"Autosell\":1,\"Name\":\"Taschenlampe\",\"Ordered\":true},{\"Price\":100,\"Lefts\":99990,\"Autosell\":1,\"Name\":\"Hammer\",\"Ordered\":true},{\"Price\":100,\"Lefts\":99990,\"Autosell\":1,\"Name\":\"Rohrzange\",\"Ordered\":true},{\"Price\":50,\"Lefts\":99990,\"Autosell\":1,\"Name\":\"Benzinkanister\",\"Ordered\":true},{\"Price\":1,\"Lefts\":99990,\"Autosell\":1,\"Name\":\"Chips\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99990,\"Autosell\":1,\"Name\":\"Pizza\",\"Ordered\":true},{\"Price\":50,\"Lefts\":99988,\"Autosell\":1,\"Name\":\"SIM-Karte\",\"Ordered\":true},{\"Price\":100,\"Lefts\":99990,\"Autosell\":1,\"Name\":\"Schlüsselbund\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99990,\"Autosell\":1,\"Name\":\"Zigarette\",\"Ordered\":true},{\"Price\":1,\"Lefts\":99980,\"Autosell\":1,\"Name\":\"Wasser\",\"Ordered\":true},{\"Price\":1,\"Lefts\":99990,\"Autosell\":1,\"Name\":\"Kaffee\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99990,\"Autosell\":1,\"Name\":\"Gummibärchen\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99990,\"Autosell\":1,\"Name\":\"Donut\",\"Ordered\":true},{\"Price\":5,\"Lefts\":99981,\"Autosell\":1,\"Name\":\"Schinken\",\"Ordered\":true},{\"Price\":15,\"Lefts\":99990,\"Autosell\":1,\"Name\":\"Aceton\",\"Ordered\":true},{\"Price\":60,\"Lefts\":99990,\"Autosell\":1,\"Name\":\"Rucksack\",\"Ordered\":true}]', '{\"x\":190.0616,\"y\":-889.46027,\"z\":29.593086}', '{\"x\":196.64299,\"y\":-901.2877,\"z\":30.691437}', 257615, -1, '[{\"Name\":\"Taschenlampe\",\"Amount\":500},{\"Name\":\"Hammer\",\"Amount\":50},{\"Name\":\"Rohrzange\",\"Amount\":50},{\"Name\":\"Benzinkanister\",\"Amount\":50},{\"Name\":\"Chips\",\"Amount\":500},{\"Name\":\"Pizza\",\"Amount\":500},{\"Name\":\"SIM-Karte\",\"Amount\":500},{\"Name\":\"Schlüsselbund\",\"Amount\":50},{\"Name\":\"Zigarette\",\"Amount\":2500},{\"Name\":\"Wasser\",\"Amount\":2500},{\"Name\":\"Kaffee\",\"Amount\":2500},{\"Name\":\"Gummibärchen\",\"Amount\":2500},{\"Name\":\"Donut\",\"Amount\":2500},{\"Name\":\"Schinken\",\"Amount\":2500},{\"Name\":\"Aceton\",\"Amount\":1000},{\"Name\":\"Rucksack\",\"Amount\":1000}]', NULL);
INSERT INTO `businesses` VALUES (87, 'Staat', 10000000, 7, '[{\"Price\":100,\"Lefts\":99999020,\"Autosell\":10,\"Name\":\"Kleidung\",\"Ordered\":true}]', '{\"x\":-1023.4774,\"y\":-2815.1023,\"z\":20.198557}', '{\"x\":-1029.1655,\"y\":-2805.5288,\"z\":21.314465}', 968602, -1, '[{\"Name\":\"Kleidung\",\"Amount\":700}]', NULL);
INSERT INTO `businesses` VALUES (88, 'Staat', 10000000, 0, '[{\"Price\":150,\"Lefts\":99999998,\"Autosell\":1,\"Name\":\"Taschenlampe\",\"Ordered\":false},{\"Price\":100,\"Lefts\":99989,\"Autosell\":1,\"Name\":\"Hammer\",\"Ordered\":true},{\"Price\":100,\"Lefts\":99989,\"Autosell\":1,\"Name\":\"Rohrzange\",\"Ordered\":true},{\"Price\":50,\"Lefts\":99989,\"Autosell\":1,\"Name\":\"Benzinkanister\",\"Ordered\":true},{\"Price\":1,\"Lefts\":99989,\"Autosell\":1,\"Name\":\"Chips\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99989,\"Autosell\":1,\"Name\":\"Pizza\",\"Ordered\":true},{\"Price\":50,\"Lefts\":99989,\"Autosell\":1,\"Name\":\"SIM-Karte\",\"Ordered\":true},{\"Price\":100,\"Lefts\":99990,\"Autosell\":1,\"Name\":\"Schlüsselbund\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99990,\"Autosell\":1,\"Name\":\"Zigarette\",\"Ordered\":true},{\"Price\":1,\"Lefts\":99990,\"Autosell\":1,\"Name\":\"Wasser\",\"Ordered\":true},{\"Price\":1,\"Lefts\":99989,\"Autosell\":1,\"Name\":\"Kaffee\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99989,\"Autosell\":1,\"Name\":\"Gummibärchen\",\"Ordered\":true},{\"Price\":3,\"Lefts\":99989,\"Autosell\":1,\"Name\":\"Donut\",\"Ordered\":true},{\"Price\":5,\"Lefts\":99989,\"Autosell\":1,\"Name\":\"Schinken\",\"Ordered\":true},{\"Price\":15,\"Lefts\":99989,\"Autosell\":1,\"Name\":\"Aceton\",\"Ordered\":true},{\"Price\":60,\"Lefts\":99990,\"Autosell\":1,\"Name\":\"Rucksack\",\"Ordered\":true}]', '{\"x\":-1072.3718,\"y\":-2768.379,\"z\":20.200176}', '{\"x\":-1073.0536,\"y\":-2750.9617,\"z\":21.314442}', 84486, -1, '[{\"Name\":\"Hammer\",\"Amount\":50},{\"Name\":\"Rohrzange\",\"Amount\":50},{\"Name\":\"Benzinkanister\",\"Amount\":50},{\"Name\":\"Chips\",\"Amount\":500},{\"Name\":\"Pizza\",\"Amount\":500},{\"Name\":\"SIM-Karte\",\"Amount\":500},{\"Name\":\"Schlüsselbund\",\"Amount\":50},{\"Name\":\"Zigarette\",\"Amount\":2500},{\"Name\":\"Wasser\",\"Amount\":2500},{\"Name\":\"Kaffee\",\"Amount\":2500},{\"Name\":\"Gummibärchen\",\"Amount\":2500},{\"Name\":\"Donut\",\"Amount\":2500},{\"Name\":\"Schinken\",\"Amount\":2500},{\"Name\":\"Aceton\",\"Amount\":1000},{\"Name\":\"Rucksack\",\"Amount\":1000}]', NULL);
INSERT INTO `businesses` VALUES (89, 'Staat', 10000000, 8, '[{\"Price\":2,\"Lefts\":999909,\"Autosell\":1,\"Name\":\"Burger\",\"Ordered\":true},{\"Price\":2,\"Lefts\":999910,\"Autosell\":1,\"Name\":\"Hotdog\",\"Ordered\":true},{\"Price\":2,\"Lefts\":999910,\"Autosell\":1,\"Name\":\"Sandwich\",\"Ordered\":true},{\"Price\":3,\"Lefts\":999910,\"Autosell\":1,\"Name\":\"eCola\",\"Ordered\":true},{\"Price\":3,\"Lefts\":999909,\"Autosell\":1,\"Name\":\"Sprunk\",\"Ordered\":true},{\"Price\":1,\"Lefts\":999910,\"Autosell\":1,\"Name\":\"Wasser\",\"Ordered\":true},{\"Price\":1,\"Lefts\":999910,\"Autosell\":1,\"Name\":\"Kaffee\",\"Ordered\":true},{\"Price\":3,\"Lefts\":999910,\"Autosell\":1,\"Name\":\"Donut\",\"Ordered\":true}]', '{\"x\":-1063.5107,\"y\":-2736.6812,\"z\":20.20235}', '{\"x\":-1067.8511,\"y\":-2741.2678,\"z\":21.314447}', 624628, -1, '[{\"Name\":\"Burger\",\"Amount\":2500},{\"Name\":\"Hotdog\",\"Amount\":2500},{\"Name\":\"Sandwich\",\"Amount\":2500},{\"Name\":\"eCola\",\"Amount\":1000},{\"Name\":\"Sprunk\",\"Amount\":1000},{\"Name\":\"Wasser\",\"Amount\":2500},{\"Name\":\"Kaffee\",\"Amount\":2500},{\"Name\":\"Donut\",\"Amount\":2500}]', NULL);

-- ----------------------------
-- Table structure for characters
-- ----------------------------
DROP TABLE IF EXISTS `characters`;
CREATE TABLE `characters`  (
  `uuid` int NOT NULL,
  `firstname` varchar(25) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `lastname` varchar(25) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `gender` tinyint NOT NULL,
  `health` tinyint NOT NULL,
  `armor` tinyint NOT NULL,
  `lvl` smallint NOT NULL,
  `exp` smallint NOT NULL,
  `money` bigint NOT NULL,
  `bank` int NOT NULL,
  `work` tinyint NOT NULL,
  `fraction` tinyint NOT NULL,
  `fractionlvl` tinyint NOT NULL,
  `arrest` int NOT NULL,
  `demorgan` int NOT NULL,
  `wanted` varchar(256) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `biz` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `adminlvl` tinyint NOT NULL,
  `licenses` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `unwarn` datetime NOT NULL,
  `unmute` int NOT NULL,
  `warns` tinyint NOT NULL,
  `lastveh` varchar(20) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT '',
  `onduty` tinyint NOT NULL,
  `lasthour` int NOT NULL,
  `hotel` int NOT NULL,
  `hotelleft` int NOT NULL,
  `contacts` varchar(2048) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `achiev` longtext CHARACTER SET utf8mb3 COLLATE utf8mb3_bin NULL,
  `sim` int NULL DEFAULT NULL,
  `PetName` varchar(128) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL DEFAULT '0',
  `createdate` timestamp NOT NULL DEFAULT current_timestamp,
  `pos` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `spawnpos` float(11, 0) NULL DEFAULT NULL,
  `birthdate` datetime(6) NULL DEFAULT NULL,
  `workid` int NULL DEFAULT NULL,
  `fractionid` int NULL DEFAULT NULL,
  `demorgantime` int NULL DEFAULT NULL,
  `wantedlvl` int NULL DEFAULT NULL,
  `lasthourmin` int NULL DEFAULT NULL,
  `arrestime` int NULL DEFAULT NULL,
  `achievements` tinyint NULL DEFAULT NULL,
  `voicemuted` tinyint NULL DEFAULT NULL,
  `insidehouseid` int NULL DEFAULT NULL,
  `insidegarageid` int NULL DEFAULT NULL,
  `exteriorpos` float(11, 0) NULL DEFAULT NULL,
  `insidehotelid` int NULL DEFAULT NULL,
  `tuningshop` int NULL DEFAULT NULL,
  `isalive` tinyint NULL DEFAULT NULL,
  `isspawned` tinyint NULL DEFAULT NULL,
  `level` int NULL DEFAULT NULL,
  `whogive` varchar(11) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `date` date NULL DEFAULT NULL,
  `reason` varchar(11) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL DEFAULT '0',
  `position` float(11, 0) NOT NULL DEFAULT 0,
  `eat` int NOT NULL,
  `water` int NOT NULL,
  `lastbonus` int NOT NULL,
  `isbonused` tinyint(1) NOT NULL,
  PRIMARY KEY (`uuid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of characters
-- ----------------------------
INSERT INTO `characters` VALUES (7029, 'Phillip', 'Coulson', 1, 100, 100, 1, 3, 1020018697, 264368, 7, 7, 18, 0, 0, 'null', '[]', 0, '[false,true,false,false,false,false,false,false]', '2021-02-16 19:05:25', 0, 0, '', 1, 8, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', -1, 'null', '2021-02-16 19:05:25', '{\"x\":-58.003326,\"y\":-748.43225,\"z\":44.166847}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 29, 28, 70, 0);
INSERT INTO `characters` VALUES (8605, 'Frost', 'Jack', 1, 31, 0, 1, 0, 16713, 893223, 7, 7, 18, 0, 0, 'null', '[]', 0, '[false,true,false,false,false,false,false,false]', '2021-02-14 18:50:56', 0, 0, '', 1, 49, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', -1, 'null', '2021-02-14 18:50:56', '{\"x\":-476.77972,\"y\":-341.2171,\"z\":34.378014}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 40, 40, 216, 0);
INSERT INTO `characters` VALUES (23854, 'Volt', 'Alphatester', 1, 85, 0, 8, 23, 870016533, 873885, 7, 18, 14, 0, 0, 'null', '[52]', 0, '[true,true,true,true,true,true,false,false]', '2020-12-13 12:33:27', 0, 0, '', 1, 118, -1, 0, '{\"1\":\"1\",\"1669102\":\"Kevin Mall USMS\"}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', 6402400, 'null', '2020-12-13 12:33:27', '{\"x\":-187.70143,\"y\":-184.6373,\"z\":43.718983}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 0, 2, 204, 0);
INSERT INTO `characters` VALUES (37645, 'Fuchs', 'Admin', 1, 20, 0, 0, 0, 450, 748910, 7, 0, 0, 0, 0, 'null', '[]', 0, '[false,false,false,false,false,false,false,false]', '2021-02-20 18:57:48', 0, 0, '', 0, 11, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', -1, 'null', '2021-02-20 18:57:48', '{\"x\":-468.638,\"y\":-288.962,\"z\":34.911}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 93, 93, 11, 0);
INSERT INTO `characters` VALUES (40048, 'David', 'Maranyan', 1, 20, 0, 0, 0, 500, 736193, 0, 0, 0, 0, 0, 'null', '[]', 0, '[false,false,false,false,false,false,false,false]', '2020-12-19 15:51:12', 0, 0, '', 0, 2, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', -1, 'null', '2020-12-19 15:51:12', '{\"x\":-468.638,\"y\":-288.962,\"z\":34.911}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 100, 100, 2, 0);
INSERT INTO `characters` VALUES (44375, 'Mike', 'Mike', 1, 20, 0, 0, 0, 500, 422389, 7, 0, 0, 0, 0, 'null', '[]', 0, '[false,false,false,false,false,false,false,false]', '2021-02-24 17:47:00', 0, 0, '', 0, 7, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', -1, 'null', '2021-02-24 17:47:00', '{\"x\":-468.638,\"y\":-288.962,\"z\":34.911}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 97, 97, 7, 0);
INSERT INTO `characters` VALUES (94329, 'Chris', 'Connor', 1, 53, 0, 4, 9, 18126442, 736555, 0, 7, 18, 0, 0, 'null', '[]', 10, '[false,false,false,false,false,false,false,false]', '2020-12-19 22:31:53', 0, 0, '', 0, 55, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', 3874648, 'null', '2020-12-19 22:31:53', '{\"x\":-2201.2559,\"y\":4263.1025,\"z\":48.00562}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 27, 9, 205, 0);
INSERT INTO `characters` VALUES (108026, 'Jack', 'Ryan', 1, 20, 0, 1, 4, 4669, 893479, 7, 7, 18, 0, 0, 'null', '[]', 0, '[false,false,false,false,false,false,false,false]', '2021-01-13 19:56:47', 0, 0, '', 1, 4, -1, 0, '{\"8386861\":\"8386861\"}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', 8473426, 'null', '2021-01-13 19:56:47', '{\"x\":455.61328,\"y\":-1007.3714,\"z\":29.388826}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 38, 41, 63, 0);
INSERT INTO `characters` VALUES (118639, 'Andrei', 'Vassiljev', 1, 20, 0, 1, 3, 8106, 102250, 7, 0, 0, 0, 0, 'null', '[]', 0, '[false,true,false,false,false,false,false,false]', '2021-02-16 18:41:41', 0, 0, '', 0, 28, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', -1, 'null', '2021-02-16 18:41:41', '{\"x\":-468.638,\"y\":-288.962,\"z\":34.911}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 36, 38, 45, 0);
INSERT INTO `characters` VALUES (125749, 'Jojo', 'Jones', 0, 64, 0, 1, 3, 761, 348930, 7, 0, 0, 0, 0, 'null', '[]', 0, '[false,false,false,false,false,false,false,false]', '2021-02-08 14:52:32', 0, 0, '', 0, 36, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', -1, 'null', '2021-02-08 14:52:32', '{\"x\":2001.0593,\"y\":3802.601,\"z\":31.602495}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 94, 91, 94, 0);
INSERT INTO `characters` VALUES (143916, 'Patte', 'Test', 1, 80, 0, 8, 9, 1388928465, 518518, 7, 18, 14, 0, 0, 'null', '[]', 0, '[false,false,false,false,false,false,false,false]', '2020-12-13 20:02:35', 0, 0, '', 0, 43, -1, 0, '{\"1430970\":\"1430970\"}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', 1669102, 'null', '2020-12-13 20:02:35', '{\"x\":844.75256,\"y\":-1281.8707,\"z\":24.312757}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 20, 17, 0, 0);
INSERT INTO `characters` VALUES (161355, 'Vladimir', 'Putin', 1, 30, 0, 0, 1, 49235494, 762793, 0, 0, 0, 0, 0, 'null', '[]', 0, '[false,false,false,false,false,false,false,false]', '2021-01-27 15:35:28', 0, 0, '', 0, 16, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', -1, 'null', '2021-01-27 15:35:28', '{\"x\":233.89082,\"y\":-374.17487,\"z\":44.351444}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 46, 44, 34, 0);
INSERT INTO `characters` VALUES (191970, 'Marcus', 'Stenhouse', 1, 100, 0, 2, 1, 26157, 693908, 7, 7, 17, 0, 0, 'null', '[]', 0, '[true,true,false,false,false,false,false,false]', '2021-01-13 18:27:20', 0, 0, '', 1, 49, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', 8386861, 'null', '2021-01-13 18:27:20', '{\"x\":459.83118,\"y\":-978.67957,\"z\":25.945866}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 39, 37, 108, 0);
INSERT INTO `characters` VALUES (207288, 'Alessandro', 'Mart', 1, 96, 0, 0, 2, 4571, 733346, 7, 7, 18, 0, 0, 'null', '[]', 10, '[false,false,false,false,false,false,false,false]', '2021-03-03 10:09:55', 0, 0, '', 1, 13, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', -1, 'null', '2021-03-03 10:09:55', '{\"x\":1206.9381,\"y\":-2988.5178,\"z\":5.874217}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 59, 51, 84, 0);
INSERT INTO `characters` VALUES (253404, 'Fillip', 'Kirkorov', 1, 100, 0, 1, 3, 10500, 87830, 7, 0, 0, 0, 0, 'null', '[]', 0, '[false,false,false,false,false,false,false,false]', '2021-02-20 21:40:34', 0, 0, '', 0, 6, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', -1, 'null', '2021-02-20 21:40:34', '{\"x\":-484.1201,\"y\":-284.28732,\"z\":35.493706}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 40, 38, 26, 0);
INSERT INTO `characters` VALUES (267969, 'Wiesel', 'Alphatester', 1, 53, 100, 4, 2, 448921, 335091, 7, 18, 14, 0, 0, 'null', '[]', 0, '[false,false,false,false,false,false,false,false]', '2020-12-14 15:42:36', 0, 0, '', 1, 13, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', -1, 'null', '2020-12-14 15:42:36', '{\"x\":839.0242,\"y\":-1287.8564,\"z\":24.320372}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 34, 36, 25, 0);
INSERT INTO `characters` VALUES (270190, 'Jack', 'Frost', 1, 100, 19, 0, 2, 9967858, 244577, 7, 18, 14, 0, 0, 'null', '[]', 0, '[false,false,false,false,false,false,false,false]', '2021-01-13 18:32:18', 0, 0, '', 0, 6, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', -1, 'null', '2021-01-13 18:32:18', '{\"x\":796.9255,\"y\":-1248.43,\"z\":27.138773}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 62, 56, 86, 0);
INSERT INTO `characters` VALUES (284859, 'Dustin', 'Johnsen', 1, 100, 100, 0, 0, 317, 37223, 7, 7, 18, 0, 0, 'null', '[]', 0, '[false,false,false,false,false,false,false,false]', '2021-02-28 12:53:28', 0, 0, '', 1, 30, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', 6598661, 'null', '2021-02-28 12:53:28', '{\"x\":428.61472,\"y\":-1001.9969,\"z\":30.711071}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 33, 34, 30, 0);
INSERT INTO `characters` VALUES (319512, 'Kiralee', 'May', 0, 46, 100, 1, 0, 344807, 527940, 7, 7, 18, 0, 0, 'null', '[]', 0, '[false,false,false,false,false,false,false,false]', '2021-01-13 18:37:44', 0, 0, '', 1, 35, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', -1, 'null', '2021-01-13 18:37:44', '{\"x\":392.44818,\"y\":-1034.519,\"z\":29.473032}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 37, 19, 153, 0);
INSERT INTO `characters` VALUES (333333, 'Corbiezx', 'Dev', 1, 100, 0, 4, 2, 999221613, 698544, 7, 0, 0, 0, 0, 'null', '[1]', 0, '[true,true,true,false,false,false,false,false]', '2020-12-06 14:47:35', 0, 0, '', 0, 112, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', -1, 'null', '2020-12-06 14:47:35', '{\"x\":-861.81726,\"y\":-413.86197,\"z\":36.653507}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 37, 36, 146, 0);
INSERT INTO `characters` VALUES (395557, 'Admyan', 'Admyanin', 1, 20, 0, 5, 8, 17272299, 862248, 7, 18, 14, 0, 0, 'null', '[]', 0, '[false,true,false,false,false,false,false,false]', '2020-12-13 13:42:41', 0, 0, '', 0, 35, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', 8342561, 'null', '2020-12-13 13:42:41', '{\"x\":4818.294,\"y\":-4846.5522,\"z\":6.4589067}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 38, 38, 146, 0);
INSERT INTO `characters` VALUES (404355, 'Codeyx', 'Aplhatester', 1, 100, 58, 0, 2, 9976789, 264729, 7, 18, 14, 0, 0, 'null', '[]', 0, '[false,false,false,false,false,false,false,false]', '2021-01-13 18:17:26', 0, 0, '', 0, 32, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', -1, 'null', '2021-01-13 18:17:26', '{\"x\":48.20398,\"y\":-767.01013,\"z\":44.513527}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 46, 30, 118, 0);
INSERT INTO `characters` VALUES (409064, 'Louis', 'Clark', 1, 20, 0, 2, 1, 980220, 834594, 7, 0, 0, 0, 0, 'null', '[]', 10, '[false,false,false,false,false,false,false,false]', '2020-12-20 22:55:54', 0, 0, '', 0, 10, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', -1, 'null', '2020-12-20 22:55:54', '{\"x\":-161.66554,\"y\":-303.20993,\"z\":39.733273}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 31, 33, 298, 0);
INSERT INTO `characters` VALUES (450104, 'Admin', 'Administrator', 1, 100, 0, 0, 0, 500, 480686, 0, 0, 0, 0, 0, 'null', '[]', 0, '[false,false,false,false,false,false,false,false]', '2021-01-13 20:23:31', 0, 0, '', 0, 0, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', -1, 'null', '2021-01-13 20:23:31', '{\"x\":3372.995,\"y\":5183.807,\"z\":0.3402423}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 100, 100, 0, 0);
INSERT INTO `characters` VALUES (481975, 'Test', 'Penis', 1, 30, 0, 8, 2, 713541000, 864756, 7, 7, 18, 0, 0, 'null', '[]', 0, '[true,true,true,true,true,false,false,false]', '2020-12-13 12:28:01', 0, 0, '', 1, 26, -1, 0, '{\"7960323\":\"Justin\"}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', 6573410, 'null', '2020-12-13 12:28:01', '{\"x\":392.44818,\"y\":-1034.519,\"z\":29.473032}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 13, 6, 0, 0);
INSERT INTO `characters` VALUES (521642, 'Michelle', 'Connor', 1, 100, 0, 0, 0, 500, 260769, 0, 0, 0, 0, 0, 'null', '[]', 0, '[false,false,false,false,false,false,false,false]', '2021-02-18 22:29:29', 0, 0, '', 0, 15, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', -1, 'null', '2021-02-18 22:29:29', '{\"x\":-1131.175,\"y\":-2744.1738,\"z\":21.317032}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 92, 90, 15, 0);
INSERT INTO `characters` VALUES (551558, 'Tobias', 'Boemer', 1, 86, 0, 0, 1, 842253, 526173, 0, 9, 14, 0, 0, 'null', '[]', 10, '[true,true,true,true,true,true,false,false]', '2021-02-18 23:18:12', 0, 0, '', 0, 67, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', -1, 'null', '2021-02-18 23:18:12', '{\"x\":1996.0143,\"y\":3072.575,\"z\":47.049736}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 85, 70, 127, 0);
INSERT INTO `characters` VALUES (577249, 'Mila', 'Jung', 0, 100, 0, 1, 0, 36500, 464145, 7, 0, 0, 0, 0, 'null', '[]', 0, '[false,false,false,false,false,false,false,false]', '2021-02-14 22:02:23', 0, 0, '', 0, 50, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', -1, 'null', '2021-02-14 22:02:23', '{\"x\":-55.20751,\"y\":-1761.59,\"z\":28.949215}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 30, 28, 108, 0);
INSERT INTO `characters` VALUES (586263, 'Roman', 'Novan', 1, 26, 0, 0, 0, 500, 87564, 0, 0, 0, 0, 0, 'null', '[]', 0, '[false,false,false,false,false,false,false,false]', '2021-01-12 17:19:55', 0, 0, '', 0, 2, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', -1, 'null', '2021-01-12 17:19:55', '{\"x\":-437.03665,\"y\":-344.6001,\"z\":34.910683}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 98, 98, 2, 0);
INSERT INTO `characters` VALUES (604391, 'Qwe', 'Qwe', 1, 100, 0, 0, 0, 500, 393208, 0, 0, 0, 0, 0, 'null', '[]', 0, '[false,false,false,false,false,false,false,false]', '2021-02-14 16:45:52', 0, 0, '', 0, 1, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', -1, 'null', '2021-02-14 16:45:52', '{\"x\":3372.995,\"y\":5183.807,\"z\":0.3402423}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 100, 100, 1, 0);
INSERT INTO `characters` VALUES (643213, 'Jeff', 'Dexter', 1, 20, 0, 0, 1, 19820750, 231326, 7, 18, 14, 0, 0, 'null', '[]', 0, '[false,false,false,false,false,false,false,false]', '2021-01-13 18:58:12', 0, 0, '', 1, 17, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', -1, 'null', '2021-01-13 18:58:12', '{\"x\":781.2846,\"y\":-989.69354,\"z\":26.151493}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 36, 37, 64, 0);
INSERT INTO `characters` VALUES (650974, 'Mike', 'Odell', 1, 54, 0, 0, 0, 500, 549835, 0, 0, 0, 0, 0, 'null', '[]', 0, '[false,false,false,false,false,false,false,false]', '2021-02-24 17:39:51', 0, 0, '', 0, 3, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', -1, 'null', '2021-02-24 17:39:51', '{\"x\":1142.9026,\"y\":265.88113,\"z\":-51.840874}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 94, 98, 3, 0);
INSERT INTO `characters` VALUES (668527, 'Alexander', 'Rusev', 1, 62, 0, 0, 0, 450, 311177, 7, 0, 0, 0, 0, 'null', '[]', 0, '[false,false,false,false,false,false,false,false]', '2021-02-14 18:47:29', 0, 0, '', 0, 24, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', -1, 'null', '2021-02-14 18:47:29', '{\"x\":386.8136,\"y\":-956.2544,\"z\":29.974905}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 87, 80, 24, 0);
INSERT INTO `characters` VALUES (683251, 'John', 'Razor', 1, 100, 0, 0, 2, 21457, 265715, 7, 7, 18, 0, 0, 'null', '[]', 0, '[false,true,false,false,false,false,false,false]', '2021-02-21 15:28:37', 0, 0, '', 0, 23, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', 8836313, 'null', '2021-02-21 15:28:37', '{\"x\":1208.322,\"y\":-2982.1038,\"z\":6.317154}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 98, 98, 135, 0);
INSERT INTO `characters` VALUES (719676, 'James', 'Hills', 1, 51, 0, 0, 1, 4419, 280283, 7, 7, 18, 0, 0, 'null', '[]', 0, '[false,false,false,false,false,false,false,false]', '2021-02-24 16:32:14', 0, 0, '', 1, 24, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', 2428639, 'null', '2021-02-24 16:32:14', '{\"x\":-439.29538,\"y\":-365.96057,\"z\":33.30528}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 37, 36, 52, 0);
INSERT INTO `characters` VALUES (809369, 'Simon', 'Salzmann', 1, 20, 0, 0, 0, 400, 903021, 7, 0, 0, 0, 0, 'null', '[]', 0, '[false,false,false,false,false,false,false,false]', '2021-01-13 20:27:46', 0, 0, '', 0, 17, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', -1, 'null', '2021-01-13 20:27:46', '{\"x\":-466.54404,\"y\":-286.79874,\"z\":34.911926}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 89, 88, 17, 0);
INSERT INTO `characters` VALUES (812832, 'Evotrix', 'Evotrix', 1, 100, 0, 1, 0, 13872, 896745, 7, 7, 18, 0, 0, 'null', '[]', 0, '[false,false,false,false,false,false,false,false]', '2021-01-13 18:11:53', 0, 0, '', 1, 40, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', 1757739, 'null', '2021-01-13 18:11:53', '{\"x\":364.87344,\"y\":-1050.3131,\"z\":29.461926}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 38, 38, 165, 0);
INSERT INTO `characters` VALUES (826547, 'Codeyx', 'Alphatester', 0, 97, 0, 0, 0, 396, 679355, 7, 0, 0, 0, 0, 'null', '[]', 0, '[false,false,false,false,false,false,false,false]', '2020-12-20 22:26:06', 0, 0, '', 0, 46, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', -1, 'null', '2020-12-20 22:26:06', '{\"x\":-53.38996,\"y\":-1748.3855,\"z\":29.42101}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 28, 22, 46, 0);
INSERT INTO `characters` VALUES (829846, 'Sanja', 'Lolipop', 1, 20, 0, 0, 0, 500, 353286, 0, 0, 0, 0, 0, 'null', '[]', 0, '[false,false,false,false,false,false,false,false]', '2021-02-21 09:03:32', 0, 0, '', 0, 3, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', -1, 'null', '2021-02-21 09:03:32', '{\"x\":-468.638,\"y\":-288.962,\"z\":34.911}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 40, 40, 3, 0);
INSERT INTO `characters` VALUES (837306, 'Natcules', 'Hart', 1, 25, 0, 0, 2, 123, 80498, 7, 0, 0, 0, 0, 'null', '[]', 0, '[false,false,false,false,false,false,false,false]', '2021-03-21 17:39:04', 0, 0, '', 0, 7, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', -1, 'null', '2021-03-21 17:39:04', '{\"x\":244.6313,\"y\":-742.1086,\"z\":34.627842}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 83, 54, 82, 0);
INSERT INTO `characters` VALUES (853521, 'Timati', 'Blackstar', 1, 94, 0, 9, 21, 75536492, 378972, 7, 7, 18, 0, 0, 'null', '[]', 10, '[false,false,false,false,false,false,false,false]', '2020-12-13 12:31:14', 0, 0, '', 0, 41, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', 1397780, 'null', '2020-12-13 12:31:14', '{\"x\":173.5913,\"y\":-1010.35565,\"z\":29.325161}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 0, 2, 261, 0);
INSERT INTO `characters` VALUES (910388, 'Theo', 'Schmidt', 1, 60, 0, 1, 3, 651, 711927, 7, 0, 0, 0, 0, 'null', '[]', 0, '[false,false,false,false,false,false,false,false]', '2021-02-14 21:58:46', 0, 0, '', 0, 53, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', -1, 'null', '2021-02-14 21:58:46', '{\"x\":-55.112724,\"y\":-1750.7401,\"z\":33.972645}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 85, 82, 108, 0);
INSERT INTO `characters` VALUES (927412, 'Rikardo', 'Discord', 1, 58, 0, 1, 3, 8293350, 920173, 0, 7, 18, 0, 0, 'null', '[]', 10, '[false,false,false,false,false,false,false,false]', '2021-02-14 16:42:29', 0, 0, '', 0, 37, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', 4927352, 'null', '2021-02-14 16:42:29', '{\"x\":409.14984,\"y\":-976.3127,\"z\":29.418274}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 89, 79, 51, 0);
INSERT INTO `characters` VALUES (960128, 'Sky', 'Net', 1, 100, 0, 0, 0, 989999, 729832, 7, 0, 0, 0, 0, 'null', '[]', 0, '[false,false,false,false,false,false,false,false]', '2021-02-20 21:22:12', 0, 0, '', 0, 12, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', -1, 'null', '2021-02-20 21:22:12', '{\"x\":1143.8424,\"y\":268.59665,\"z\":-51.840897}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 40, 40, 12, 0);
INSERT INTO `characters` VALUES (985352, 'Hanz', 'Wurst', 1, 20, 0, 4, 8, 1993031141, 137043, 7, 18, 14, 0, 0, 'null', '[]', 10, '[false,false,false,false,false,false,false,false]', '2020-12-13 20:24:14', 0, 0, '', 1, 19, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', -1, 'null', '2020-12-13 20:24:14', '{\"x\":-468.638,\"y\":-288.962,\"z\":34.911}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 40, 40, 0, 0);
INSERT INTO `characters` VALUES (987292, 'General', 'Fickschnitzel', 0, 100, 0, 1, 3, 18843414, 666269, 7, 0, 0, 0, 0, 'null', '[]', 10, '[false,true,false,false,false,false,false,false]', '2020-12-22 05:00:16', 0, 0, '', 0, 48, -1, 0, '{}', '[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]', -1, 'null', '2020-12-22 05:00:16', '{\"x\":-991.81805,\"y\":-1103.5428,\"z\":2.150312}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', 0, 34, 34, 64, 0);

-- ----------------------------
-- Table structure for containers
-- ----------------------------
DROP TABLE IF EXISTS `containers`;
CREATE TABLE `containers`  (
  `id` int NOT NULL,
  `name` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  `price` int NOT NULL DEFAULT 0,
  `donate` tinyint(1) NULL DEFAULT 0,
  `position` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  `rotation` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `loot` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of containers
-- ----------------------------
INSERT INTO `containers` VALUES (0, 'Low', 2500, 0, '{\"x\":1214,\"y\":-2970,\"z\":4.8}', '{\"x\":0,\"y\":0,\"z\":-180}', '{\"lc200\":\"40\", \"m5\":\"30\", \"m5e60\":\"15\", \"lexgs350f\":\"10\",\"m8\":\"5\"}\r\n');
INSERT INTO `containers` VALUES (1, 'Medium', 4500, 0, '{\"x\":1218.6,\"y\":-2970,\"z\":4.8}', '{\"x\":0,\"y\":0,\"z\":-180}', '{\"c63coupe\":\"40\", \"e63amg\":\"30\", \"2019m5\":\"15\", \"BRABUS700\":\"10\", \"mgt\":\"5\"}\r\n');
INSERT INTO `containers` VALUES (2, 'Премиум+', 7000, 0, '{\"x\":1214,\"y\":-2990,\"z\":4.8}', '{\"x\":0,\"y\":0,\"z\":-180}', '{\"g65\":\"40\", \"gle6c\":\"30\", \"gt63samg\":\"15\", \"gallardo\":\"10\", \"brabus850\":\"5\"}\r\n');
INSERT INTO `containers` VALUES (3, 'Prämie+', 9000, 0, '{\"x\":1218.6,\"y\":-2990,\"z\":4.8}', '{\"x\":0,\"y\":0,\"z\":-180}', '{\"e63\":\"40\", \"e63amg\":\"30\", \"g63amg6x6cop\":\"15\", \"18perfomante\":\"10\",\"g65\":\"5\"}\r\n');
INSERT INTO `containers` VALUES (5, 'Low', 25000, 0, '{\"x\":1218.6,\"y\":-3010,\"z\":4.8}', '{\"x\":0,\"y\":0,\"z\":-180}', '{\"lc200\":\"40\", \"m5\":\"30\", \"m5e60\":\"15\", \"lexgs350f\":\"10\",\"m8\":\"5\"}\r\n');

-- ----------------------------
-- Table structure for customization
-- ----------------------------
DROP TABLE IF EXISTS `customization`;
CREATE TABLE `customization`  (
  `uuid` int NOT NULL,
  `gender` tinyint NOT NULL,
  `parents` varchar(128) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `features` varchar(256) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `appearance` varchar(512) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `hair` varchar(256) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `clothes` varchar(2048) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `accessory` varchar(1024) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `tattoos` varchar(2048) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `eyebrowc` smallint NOT NULL,
  `beardc` smallint NOT NULL,
  `eyec` smallint NOT NULL,
  `blushc` smallint NOT NULL,
  `lipstickc` smallint NOT NULL,
  `chesthairc` smallint NOT NULL,
  `iscreated` tinyint NOT NULL,
  PRIMARY KEY (`uuid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of customization
-- ----------------------------
INSERT INTO `customization` VALUES (7029, 0, '{\"Father\":0,\"Mother\":21,\"Similarity\":0.5,\"SkinSimilarity\":0.5}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":2,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":15,\"Texture\":0},\"Leg\":{\"Variation\":102,\"Texture\":4},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":1,\"Texture\":0},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":146,\"Texture\":1}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 0, 0, 0, 0, 0, 1);
INSERT INTO `customization` VALUES (8605, 0, '{\"Father\":8,\"Mother\":28,\"Similarity\":0.5,\"SkinSimilarity\":0.0}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":10,\"Opacity\":100.0},{\"Value\":1,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":21,\"Color\":12,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":15,\"Texture\":0},\"Leg\":{\"Variation\":102,\"Texture\":5},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":1,\"Texture\":0},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":146,\"Texture\":0}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[{\"Dictionary\":\"mpchristmas2_overlays\",\"Hash\":\"MP_Xmas2_M_Tat_010\",\"Slots\":[1]}],\"3\":[{\"Dictionary\":\"mpchristmas2_overlays\",\"Hash\":\"MP_Xmas2_M_Tat_003\",\"Slots\":[2]}],\"4\":[],\"5\":[]}', 12, 4, 3, 0, 0, 12, 1);
INSERT INTO `customization` VALUES (23854, 0, '{\"Father\":1,\"Mother\":21,\"Similarity\":1.0,\"SkinSimilarity\":0.7}', '[0.5,0.5,0.5,0.6,0.4,0.0,0.5,0.5,0.5,0.4,0.4,0.3,0.6,0.4,0.5,0.4,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":9,\"Opacity\":100.0},{\"Value\":9,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":10,\"Color\":8,\"HighlightColor\":8}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":10,\"Texture\":0},\"Torso\":{\"Variation\":95,\"Texture\":0},\"Leg\":{\"Variation\":102,\"Texture\":4},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":32,\"Texture\":3},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":26,\"Texture\":2}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":13,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":4,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 8, 0, 2, 0, 0, 1, 1);
INSERT INTO `customization` VALUES (37645, 0, '{\"Father\":2,\"Mother\":21,\"Similarity\":0.5,\"SkinSimilarity\":0.5}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":0,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":15,\"Texture\":0},\"Leg\":{\"Variation\":102,\"Texture\":1},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":1,\"Texture\":1},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":146,\"Texture\":4}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 0, 0, 0, 0, 0, 1);
INSERT INTO `customization` VALUES (40048, 0, '{\"Father\":8,\"Mother\":28,\"Similarity\":0.5,\"SkinSimilarity\":0.5}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":0,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":15,\"Texture\":0},\"Leg\":{\"Variation\":102,\"Texture\":0},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":1,\"Texture\":2},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":146,\"Texture\":3}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 0, 0, 0, 0, 0, 1);
INSERT INTO `customization` VALUES (44375, 0, '{\"Father\":0,\"Mother\":21,\"Similarity\":0.5,\"SkinSimilarity\":0.5}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":0,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":15,\"Texture\":0},\"Leg\":{\"Variation\":102,\"Texture\":1},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":1,\"Texture\":1},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":146,\"Texture\":1}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 0, 0, 0, 0, 0, 1);
INSERT INTO `customization` VALUES (94329, 0, '{\"Father\":0,\"Mother\":21,\"Similarity\":0.5,\"SkinSimilarity\":0.5}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":1,\"Opacity\":100.0},{\"Value\":4,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":21,\"Color\":6,\"HighlightColor\":6}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":14,\"Texture\":0},\"Leg\":{\"Variation\":13,\"Texture\":0},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":1,\"Texture\":0},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":38,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":62,\"Texture\":0}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 5, 0, 0, 0, 0, 1);
INSERT INTO `customization` VALUES (108026, 0, '{\"Father\":0,\"Mother\":21,\"Similarity\":0.5,\"SkinSimilarity\":0.5}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":2,\"Opacity\":100.0},{\"Value\":0,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":2,\"Color\":6,\"HighlightColor\":6}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":0,\"Texture\":0},\"Leg\":{\"Variation\":4,\"Texture\":0},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":1,\"Texture\":0},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":34,\"Texture\":0}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 3, 6, 0, 0, 0, 0, 1);
INSERT INTO `customization` VALUES (118639, 0, '{\"Father\":5,\"Mother\":26,\"Similarity\":1.0,\"SkinSimilarity\":0.0}', '[1.0,1.0,-1.0,1.0,-0.2,-0.1,0.0,0.0,0.0,0.0,0.0,0.0,-0.8,1.0,1.0,1.0,1.0,1.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":10,\"Opacity\":100.0},{\"Value\":9,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":13,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":0,\"Texture\":0},\"Leg\":{\"Variation\":102,\"Texture\":0},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":1,\"Texture\":3},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":146,\"Texture\":6}}', '{\"Hat\":{\"Variation\":2,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 0, 0, 0, 0, 0, 1);
INSERT INTO `customization` VALUES (125749, 0, '{\"Father\":2,\"Mother\":24,\"Similarity\":0.7,\"SkinSimilarity\":0.7}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":0,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":5,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":0,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":0,\"Color\":8,\"HighlightColor\":8}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":15,\"Texture\":0},\"Leg\":{\"Variation\":27,\"Texture\":0},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":3,\"Texture\":2},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":13,\"Texture\":0}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 1, 0, 2, 0, 6, 0, 1);
INSERT INTO `customization` VALUES (143916, 0, '{\"Father\":0,\"Mother\":23,\"Similarity\":0.6,\"SkinSimilarity\":0.5}', '[1.0,1.0,-1.0,-1.0,1.0,0.0,1.0,1.0,1.0,1.0,1.0,1.0,1.0,1.0,1.0,1.0,1.0,1.0,1.0,1.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":0,\"Opacity\":100.0},{\"Value\":5,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":1,\"Opacity\":100.0}]', '{\"Hair\":10,\"Color\":1,\"HighlightColor\":1}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":5,\"Texture\":0},\"Torso\":{\"Variation\":40,\"Texture\":0},\"Leg\":{\"Variation\":9,\"Texture\":7},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":81,\"Texture\":0},\"Accessory\":{\"Variation\":177,\"Texture\":1},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":111,\"Texture\":3}}', '{\"Hat\":{\"Variation\":5,\"Texture\":0},\"Glasses\":{\"Variation\":9,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[{\"Dictionary\":\"mpbusiness_overlays\",\"Hash\":\"MP_Buis_M_Chest_001\",\"Slots\":[0]},{\"Dictionary\":\"mpchristmas2_overlays\",\"Hash\":\"MP_Xmas2_M_Tat_006\",\"Slots\":[3,4,5,6]}],\"1\":[],\"2\":[{\"Dictionary\":\"mpbiker_overlays\",\"Hash\":\"MP_MP_Biker_Tat_016_M\",\"Slots\":[2]}],\"3\":[{\"Dictionary\":\"mpchristmas2_overlays\",\"Hash\":\"MP_Xmas2_M_Tat_004\",\"Slots\":[2]}],\"4\":[],\"5\":[]}', 0, 0, 0, 0, 0, 0, 1);
INSERT INTO `customization` VALUES (161355, 0, '{\"Father\":3,\"Mother\":21,\"Similarity\":0.5,\"SkinSimilarity\":0.5}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":0,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":4,\"Texture\":0},\"Torso\":{\"Variation\":28,\"Texture\":0},\"Leg\":{\"Variation\":0,\"Texture\":0},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":1,\"Texture\":0},\"Accessory\":{\"Variation\":17,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":3,\"Texture\":0}}', '{\"Hat\":{\"Variation\":2,\"Texture\":0},\"Glasses\":{\"Variation\":1,\"Texture\":1},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":0,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 0, 0, 0, 0, 0, 1);
INSERT INTO `customization` VALUES (191970, 0, '{\"Father\":0,\"Mother\":21,\"Similarity\":0.5,\"SkinSimilarity\":0.5}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":7,\"Opacity\":100.0},{\"Value\":0,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":0,\"Opacity\":100.0}]', '{\"Hair\":19,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":15,\"Texture\":0},\"Leg\":{\"Variation\":102,\"Texture\":5},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":1,\"Texture\":0},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":15,\"Texture\":0}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[{\"Dictionary\":\"mpstunt_overlays\",\"Hash\":\"MP_MP_Stunt_Tat_006_M\",\"Slots\":[2]}],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 0, 0, 0, 0, 0, 1);
INSERT INTO `customization` VALUES (207288, 0, '{\"Father\":1,\"Mother\":21,\"Similarity\":0.5,\"SkinSimilarity\":0.5}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":0,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":15,\"Texture\":0},\"Leg\":{\"Variation\":102,\"Texture\":2},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":1,\"Texture\":2},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":146,\"Texture\":6}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 0, 0, 0, 0, 0, 1);
INSERT INTO `customization` VALUES (253404, 0, '{\"Father\":1,\"Mother\":22,\"Similarity\":0.7,\"SkinSimilarity\":1.0}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":0,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":15,\"Texture\":0},\"Leg\":{\"Variation\":102,\"Texture\":3},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":1,\"Texture\":0},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":146,\"Texture\":2}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 0, 0, 0, 0, 0, 1);
INSERT INTO `customization` VALUES (267969, 0, '{\"Father\":7,\"Mother\":24,\"Similarity\":0.4,\"SkinSimilarity\":0.3}', '[0.3,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":0,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":0,\"Texture\":0},\"Leg\":{\"Variation\":102,\"Texture\":1},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":1,\"Texture\":2},\"Accessory\":{\"Variation\":177,\"Texture\":1},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":146,\"Texture\":4}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 0, 0, 0, 0, 0, 1);
INSERT INTO `customization` VALUES (270190, 0, '{\"Father\":0,\"Mother\":21,\"Similarity\":0.5,\"SkinSimilarity\":0.5}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":2,\"Opacity\":100.0},{\"Value\":1,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":13,\"Color\":2,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":0,\"Texture\":0},\"Leg\":{\"Variation\":102,\"Texture\":3},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":1,\"Texture\":3},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":146,\"Texture\":7}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 2, 2, 0, 0, 0, 2, 1);
INSERT INTO `customization` VALUES (284859, 0, '{\"Father\":2,\"Mother\":21,\"Similarity\":0.5,\"SkinSimilarity\":0.5}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":0,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":15,\"Texture\":0},\"Leg\":{\"Variation\":102,\"Texture\":2},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":1,\"Texture\":1},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":146,\"Texture\":2}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 0, 0, 0, 0, 0, 1);
INSERT INTO `customization` VALUES (319512, 0, '{\"Father\":0,\"Mother\":21,\"Similarity\":0.5,\"SkinSimilarity\":0.5}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":1,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":1,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":4,\"Color\":3,\"HighlightColor\":3}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":15,\"Texture\":0},\"Leg\":{\"Variation\":43,\"Texture\":4},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":3,\"Texture\":10},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":30,\"Texture\":5}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 3, 0, 1, 0, 5, 0, 1);
INSERT INTO `customization` VALUES (333333, 0, '{\"Father\":0,\"Mother\":21,\"Similarity\":0.5,\"SkinSimilarity\":0.5}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":0,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":15,\"Texture\":0},\"Leg\":{\"Variation\":102,\"Texture\":5},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":1,\"Texture\":2},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":15,\"Texture\":0}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 0, 0, 0, 0, 0, 1);
INSERT INTO `customization` VALUES (395557, 0, '{\"Father\":43,\"Mother\":24,\"Similarity\":1.0,\"SkinSimilarity\":0.9}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":0,\"Opacity\":100.0},{\"Value\":2,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":4,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":14,\"Texture\":0},\"Leg\":{\"Variation\":102,\"Texture\":1},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":1,\"Texture\":1},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":4,\"Texture\":0}}', '{\"Hat\":{\"Variation\":7,\"Texture\":2},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 0, 2, 0, 0, 0, 1);
INSERT INTO `customization` VALUES (404355, 0, '{\"Father\":4,\"Mother\":24,\"Similarity\":1.0,\"SkinSimilarity\":1.0}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":0,\"Opacity\":100.0},{\"Value\":1,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":19,\"Color\":11,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":6,\"Texture\":0},\"Torso\":{\"Variation\":48,\"Texture\":0},\"Leg\":{\"Variation\":102,\"Texture\":3},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":81,\"Texture\":0},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":13,\"Texture\":2}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 11, 11, 0, 0, 0, 11, 1);
INSERT INTO `customization` VALUES (409064, 0, '{\"Father\":8,\"Mother\":23,\"Similarity\":0.9,\"SkinSimilarity\":0.0}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":0,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":0,\"Texture\":0},\"Leg\":{\"Variation\":102,\"Texture\":4},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":1,\"Texture\":0},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":146,\"Texture\":0}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 0, 0, 0, 0, 0, 1);
INSERT INTO `customization` VALUES (450104, 0, '{\"Father\":0,\"Mother\":0,\"Similarity\":1.0,\"SkinSimilarity\":1.0}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0}]', '{\"Hair\":0,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":15,\"Texture\":0},\"Leg\":{\"Variation\":21,\"Texture\":0},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":34,\"Texture\":0},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":15,\"Texture\":0}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 0, 0, 0, 0, 0, 0);
INSERT INTO `customization` VALUES (481975, 0, '{\"Father\":1,\"Mother\":23,\"Similarity\":0.5,\"SkinSimilarity\":0.5}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":10,\"Opacity\":100.0},{\"Value\":1,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":0,\"Opacity\":100.0}]', '{\"Hair\":19,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":4,\"Texture\":0},\"Leg\":{\"Variation\":24,\"Texture\":0},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":18,\"Texture\":0},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":111,\"Texture\":3}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[{\"Dictionary\":\"mpvinewood_overlays\",\"Hash\":\"MP_Vinewood_Tat_021_M\",\"Slots\":[3,4,5,6]}],\"1\":[{\"Dictionary\":\"mpchristmas2_overlays\",\"Hash\":\"MP_Xmas2_M_Tat_024\",\"Slots\":[1]}],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 0, 2, 0, 0, 0, 1);
INSERT INTO `customization` VALUES (521642, 0, '{\"Father\":0,\"Mother\":0,\"Similarity\":1.0,\"SkinSimilarity\":1.0}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0}]', '{\"Hair\":0,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":15,\"Texture\":0},\"Leg\":{\"Variation\":21,\"Texture\":0},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":34,\"Texture\":0},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":15,\"Texture\":0}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 0, 0, 0, 0, 0, 0);
INSERT INTO `customization` VALUES (551558, 0, '{\"Father\":0,\"Mother\":21,\"Similarity\":0.5,\"SkinSimilarity\":0.5}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":0,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":15,\"Texture\":0},\"Leg\":{\"Variation\":102,\"Texture\":3},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":1,\"Texture\":0},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":146,\"Texture\":9}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 0, 0, 0, 0, 0, 1);
INSERT INTO `customization` VALUES (577249, 0, '{\"Father\":12,\"Mother\":25,\"Similarity\":0.1,\"SkinSimilarity\":0.2}', '[-0.7,0.4,0.3,0.3,0.2,0.0,0.2,0.0,0.3,0.1,-1.0,0.0,0.0,-0.5,-1.0,0.5,-1.0,-0.3,-0.3,-0.5]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":5,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":81,\"Color\":6,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":15,\"Texture\":0},\"Leg\":{\"Variation\":43,\"Texture\":0},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":3,\"Texture\":1},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":30,\"Texture\":2}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 6, 6, 3, 0, 0, 6, 1);
INSERT INTO `customization` VALUES (586263, 0, '{\"Father\":2,\"Mother\":22,\"Similarity\":0.2,\"SkinSimilarity\":0.0}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":8,\"Opacity\":100.0},{\"Value\":2,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":3,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":15,\"Texture\":0},\"Leg\":{\"Variation\":102,\"Texture\":5},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":1,\"Texture\":3},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":146,\"Texture\":2}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 0, 0, 0, 0, 0, 1);
INSERT INTO `customization` VALUES (602449, 0, '{\"Father\":0,\"Mother\":0,\"Similarity\":1.0,\"SkinSimilarity\":1.0}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0}]', '{\"Hair\":0,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":15,\"Texture\":0},\"Leg\":{\"Variation\":21,\"Texture\":0},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":34,\"Texture\":0},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":15,\"Texture\":0}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 0, 0, 0, 0, 0, 0);
INSERT INTO `customization` VALUES (604391, 0, '{\"Father\":0,\"Mother\":0,\"Similarity\":1.0,\"SkinSimilarity\":1.0}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0}]', '{\"Hair\":0,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":15,\"Texture\":0},\"Leg\":{\"Variation\":21,\"Texture\":0},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":34,\"Texture\":0},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":15,\"Texture\":0}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 0, 0, 0, 0, 0, 0);
INSERT INTO `customization` VALUES (643213, 0, '{\"Father\":0,\"Mother\":31,\"Similarity\":0.7,\"SkinSimilarity\":0.2}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.2,-0.7,-0.8,0.0,0.0,0.5,0.0,-0.1,0.0,0.0,0.0,0.0,0.3,-0.5]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":2,\"Opacity\":100.0},{\"Value\":12,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":21,\"Color\":2,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":0,\"Texture\":0},\"Leg\":{\"Variation\":4,\"Texture\":0},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":1,\"Texture\":2},\"Accessory\":{\"Variation\":177,\"Texture\":1},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":146,\"Texture\":1}}', '{\"Hat\":{\"Variation\":5,\"Texture\":0},\"Glasses\":{\"Variation\":5,\"Texture\":2},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":4,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[{\"Dictionary\":\"mpbusiness_overlays\",\"Hash\":\"MP_Buis_M_Back_000\",\"Slots\":[3,4]},{\"Dictionary\":\"mphipster_overlays\",\"Hash\":\"FM_Hip_M_Tat_006\",\"Slots\":[7]},{\"Dictionary\":\"mplowrider_overlays\",\"Hash\":\"MP_LR_Tat_002_M\",\"Slots\":[0,1]},{\"Dictionary\":\"mpairraces_overlays\",\"Hash\":\"MP_Airraces_Tattoo_001_M\",\"Slots\":[5,6]},{\"Dictionary\":\"mpbiker_overlays\",\"Hash\":\"MP_MP_Biker_Tat_003_M\",\"Slots\":[2]}],\"1\":[{\"Dictionary\":\"mpbusiness_overlays\",\"Hash\":\"MP_Buis_M_Neck_003\",\"Slots\":[3]},{\"Dictionary\":\"mpchristmas2_overlays\",\"Hash\":\"MP_Xmas2_M_Tat_007\",\"Slots\":[2]},{\"Dictionary\":\"mpbusiness_overlays\",\"Hash\":\"MP_Buis_M_Neck_000\",\"Slots\":[0]},{\"Dictionary\":\"mphipster_overlays\",\"Hash\":\"FM_Hip_M_Tat_021\",\"Slots\":[1]},{\"Dictionary\":\"mpbiker_overlays\",\"Hash\":\"MP_MP_Biker_Tat_009_M\",\"Slots\":[5]}],\"2\":[{\"Dictionary\":\"mpchristmas2_overlays\",\"Hash\":\"MP_Xmas2_M_Tat_020\",\"Slots\":[0]},{\"Dictionary\":\"mplowrider_overlays\",\"Hash\":\"MP_LR_Tat_027_M\",\"Slots\":[2]},{\"Dictionary\":\"mpbiker_overlays\",\"Hash\":\"MP_MP_Biker_Tat_053_M\",\"Slots\":[1]}],\"3\":[{\"Dictionary\":\"mpchristmas2_overlays\",\"Hash\":\"MP_Xmas2_M_Tat_026\",\"Slots\":[0]},{\"Dictionary\":\"mplowrider2_overlays\",\"Hash\":\"MP_LR_Tat_028_M\",\"Slots\":[2]},{\"Dictionary\":\"mplowrider_overlays\",\"Hash\":\"MP_LR_Tat_015_M\",\"Slots\":[1]}],\"4\":[{\"Dictionary\":\"mplowrider_overlays\",\"Hash\":\"MP_LR_Tat_020_M\",\"Slots\":[0]},{\"Dictionary\":\"mpgunrunning_overlays\",\"Hash\":\"MP_Gunrunning_Tattoo_007_M\",\"Slots\":[1]}],\"5\":[{\"Dictionary\":\"mpgunrunning_overlays\",\"Hash\":\"MP_Gunrunning_Tattoo_030_M\",\"Slots\":[1]},{\"Dictionary\":\"mplowrider_overlays\",\"Hash\":\"MP_LR_Tat_023_M\",\"Slots\":[0]}]}', 2, 2, 2, 0, 0, 2, 1);
INSERT INTO `customization` VALUES (650974, 0, '{\"Father\":0,\"Mother\":21,\"Similarity\":0.5,\"SkinSimilarity\":0.5}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":0,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":15,\"Texture\":0},\"Leg\":{\"Variation\":102,\"Texture\":1},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":1,\"Texture\":3},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":146,\"Texture\":4}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 0, 0, 0, 0, 0, 1);
INSERT INTO `customization` VALUES (668527, 0, '{\"Father\":8,\"Mother\":30,\"Similarity\":0.6,\"SkinSimilarity\":1.0}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":10,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":3,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":15,\"Texture\":0},\"Leg\":{\"Variation\":102,\"Texture\":4},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":1,\"Texture\":2},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":146,\"Texture\":5}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 0, 0, 0, 0, 0, 1);
INSERT INTO `customization` VALUES (683251, 0, '{\"Father\":0,\"Mother\":21,\"Similarity\":0.5,\"SkinSimilarity\":0.5}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":2,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":0,\"Texture\":0},\"Leg\":{\"Variation\":102,\"Texture\":0},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":1,\"Texture\":2},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":146,\"Texture\":4}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[{\"Dictionary\":\"mpbusiness_overlays\",\"Hash\":\"MP_Buis_M_Chest_000\",\"Slots\":[1]}],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 0, 0, 0, 0, 0, 1);
INSERT INTO `customization` VALUES (719676, 0, '{\"Father\":1,\"Mother\":23,\"Similarity\":0.0,\"SkinSimilarity\":0.5}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":0,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":0,\"Texture\":0},\"Leg\":{\"Variation\":102,\"Texture\":0},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":1,\"Texture\":2},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":146,\"Texture\":4}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 0, 0, 0, 0, 0, 1);
INSERT INTO `customization` VALUES (724857, 0, '{\"Father\":0,\"Mother\":0,\"Similarity\":1.0,\"SkinSimilarity\":1.0}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0},{\"Value\":255,\"Opacity\":1.0}]', '{\"Hair\":0,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":15,\"Texture\":0},\"Leg\":{\"Variation\":21,\"Texture\":0},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":34,\"Texture\":0},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":15,\"Texture\":0}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 0, 0, 0, 0, 0, 0);
INSERT INTO `customization` VALUES (809369, 0, '{\"Father\":0,\"Mother\":21,\"Similarity\":0.5,\"SkinSimilarity\":0.5}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":0,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":15,\"Texture\":0},\"Leg\":{\"Variation\":102,\"Texture\":3},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":1,\"Texture\":0},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":146,\"Texture\":2}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 0, 0, 0, 0, 0, 1);
INSERT INTO `customization` VALUES (812832, 0, '{\"Father\":0,\"Mother\":21,\"Similarity\":0.5,\"SkinSimilarity\":0.5}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":0,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":15,\"Texture\":0},\"Leg\":{\"Variation\":102,\"Texture\":5},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":1,\"Texture\":0},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":146,\"Texture\":1}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 0, 0, 0, 0, 0, 1);
INSERT INTO `customization` VALUES (826547, 0, '{\"Father\":15,\"Mother\":21,\"Similarity\":1.0,\"SkinSimilarity\":0.0}', '[-1.0,1.0,-0.8,-1.0,0.0,0.0,1.0,-1.0,-1.0,-1.0,-1.0,0.0,0.0,0.0,-1.0,-1.0,-1.0,-1.0,-1.0,-1.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":2,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":7,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":15,\"Texture\":0},\"Leg\":{\"Variation\":43,\"Texture\":9},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":3,\"Texture\":7},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":30,\"Texture\":1}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 0, 1, 0, 0, 0, 1);
INSERT INTO `customization` VALUES (829846, 0, '{\"Father\":0,\"Mother\":21,\"Similarity\":0.5,\"SkinSimilarity\":0.5}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":0,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":15,\"Texture\":0},\"Leg\":{\"Variation\":102,\"Texture\":3},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":1,\"Texture\":0},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":146,\"Texture\":5}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 0, 0, 0, 0, 0, 1);
INSERT INTO `customization` VALUES (837306, 0, '{\"Father\":0,\"Mother\":21,\"Similarity\":0.5,\"SkinSimilarity\":0.5}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":0,\"Opacity\":100.0},{\"Value\":0,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":2,\"Color\":1,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":15,\"Texture\":0},\"Leg\":{\"Variation\":102,\"Texture\":4},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":1,\"Texture\":2},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":146,\"Texture\":2}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 1, 1, 1, 0, 0, 1, 1);
INSERT INTO `customization` VALUES (845464, 0, '{\"Father\":2,\"Mother\":23,\"Similarity\":0.5,\"SkinSimilarity\":0.1}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":1,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":15,\"Texture\":0},\"Leg\":{\"Variation\":102,\"Texture\":1},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":1,\"Texture\":2},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":146,\"Texture\":2}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 0, 0, 0, 0, 0, 1);
INSERT INTO `customization` VALUES (853521, 0, '{\"Father\":0,\"Mother\":21,\"Similarity\":0.5,\"SkinSimilarity\":0.5}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":21,\"Opacity\":100.0},{\"Value\":1,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":33,\"Color\":1,\"HighlightColor\":1}', '{\"Mask\":{\"Variation\":51,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":0,\"Texture\":0},\"Leg\":{\"Variation\":4,\"Texture\":2},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":31,\"Texture\":3},\"Accessory\":{\"Variation\":90,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":0,\"Texture\":0}}', '{\"Hat\":{\"Variation\":45,\"Texture\":1},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":14,\"Texture\":2},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 1, 0, 0, 0, 0, 1, 1);
INSERT INTO `customization` VALUES (910388, 0, '{\"Father\":42,\"Mother\":21,\"Similarity\":0.5,\"SkinSimilarity\":0.0}', '[0.0,-0.1,0.1,0.3,0.1,0.0,-0.3,-0.2,0.1,-1.0,-1.0,0.2,0.7,-0.6,-0.4,-0.1,-1.0,-0.4,-1.0,-1.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":0,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":13,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":8,\"Texture\":0},\"Leg\":{\"Variation\":42,\"Texture\":1},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":4,\"Texture\":2},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":38,\"Texture\":0}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 0, 3, 0, 0, 0, 1);
INSERT INTO `customization` VALUES (927412, 0, '{\"Father\":2,\"Mother\":23,\"Similarity\":0.7,\"SkinSimilarity\":0.5}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":1,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":14,\"Texture\":0},\"Leg\":{\"Variation\":4,\"Texture\":0},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":57,\"Texture\":0},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":4,\"Texture\":0}}', '{\"Hat\":{\"Variation\":4,\"Texture\":0},\"Glasses\":{\"Variation\":5,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 0, 0, 0, 0, 0, 1);
INSERT INTO `customization` VALUES (960128, 0, '{\"Father\":0,\"Mother\":21,\"Similarity\":0.5,\"SkinSimilarity\":0.5}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":0,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":15,\"Texture\":0},\"Leg\":{\"Variation\":102,\"Texture\":4},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":1,\"Texture\":2},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":146,\"Texture\":5}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[],\"3\":[],\"4\":[],\"5\":[]}', 0, 0, 0, 0, 0, 0, 1);
INSERT INTO `customization` VALUES (985352, 0, '{\"Father\":0,\"Mother\":21,\"Similarity\":0.5,\"SkinSimilarity\":0.5}', '[0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":0,\"Color\":0,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":5,\"Texture\":0},\"Torso\":{\"Variation\":30,\"Texture\":0},\"Leg\":{\"Variation\":9,\"Texture\":13},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":81,\"Texture\":0},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":251,\"Texture\":1}}', '{\"Hat\":{\"Variation\":5,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[{\"Dictionary\":\"mpbusiness_overlays\",\"Hash\":\"MP_Buis_M_Chest_001\",\"Slots\":[0]},{\"Dictionary\":\"mpbusiness_overlays\",\"Hash\":\"MP_Buis_M_Chest_000\",\"Slots\":[1]},{\"Dictionary\":\"mpimportexport_overlays\",\"Hash\":\"MP_MP_ImportExport_Tat_011_M\",\"Slots\":[5,6]},{\"Dictionary\":\"mplowrider_overlays\",\"Hash\":\"MP_LR_Tat_004_M\",\"Slots\":[7]},{\"Dictionary\":\"mpairraces_overlays\",\"Hash\":\"MP_Airraces_Tattoo_006_M\",\"Slots\":[2]}],\"1\":[{\"Dictionary\":\"mpgunrunning_overlays\",\"Hash\":\"MP_Gunrunning_Tattoo_003_M\",\"Slots\":[1]}],\"2\":[{\"Dictionary\":\"mpgunrunning_overlays\",\"Hash\":\"MP_Gunrunning_Tattoo_004_M\",\"Slots\":[0]},{\"Dictionary\":\"mpgunrunning_overlays\",\"Hash\":\"MP_Gunrunning_Tattoo_015_M\",\"Slots\":[1,2]}],\"3\":[{\"Dictionary\":\"mpchristmas2_overlays\",\"Hash\":\"MP_Xmas2_M_Tat_004\",\"Slots\":[2]},{\"Dictionary\":\"mpgunrunning_overlays\",\"Hash\":\"MP_Gunrunning_Tattoo_002_M\",\"Slots\":[0]},{\"Dictionary\":\"mpgunrunning_overlays\",\"Hash\":\"MP_Gunrunning_Tattoo_024_M\",\"Slots\":[1]}],\"4\":[{\"Dictionary\":\"mpgunrunning_overlays\",\"Hash\":\"MP_Gunrunning_Tattoo_011_M\",\"Slots\":[0,1]}],\"5\":[{\"Dictionary\":\"mpbiker_overlays\",\"Hash\":\"MP_MP_Biker_Tat_004_M\",\"Slots\":[0,1]}]}', 0, 0, 0, 0, 0, 0, 1);
INSERT INTO `customization` VALUES (987292, 0, '{\"Father\":3,\"Mother\":23,\"Similarity\":0.8,\"SkinSimilarity\":0.2}', '[0.4,0.9,-0.9,0.7,0.0,0.0,-0.8,0.7,-0.9,0.6,-1.0,0.9,-0.9,0.8,-0.8,-0.8,0.0,0.0,0.0,0.0]', '[{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":2,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0},{\"Value\":255,\"Opacity\":100.0}]', '{\"Hair\":1,\"Color\":1,\"HighlightColor\":0}', '{\"Mask\":{\"Variation\":0,\"Texture\":0},\"Gloves\":{\"Variation\":0,\"Texture\":0},\"Torso\":{\"Variation\":15,\"Texture\":0},\"Leg\":{\"Variation\":43,\"Texture\":1},\"Bag\":{\"Variation\":0,\"Texture\":0},\"Feet\":{\"Variation\":3,\"Texture\":12},\"Accessory\":{\"Variation\":0,\"Texture\":0},\"Undershit\":{\"Variation\":15,\"Texture\":0},\"Bodyarmor\":{\"Variation\":0,\"Texture\":0},\"Decals\":{\"Variation\":0,\"Texture\":0},\"Top\":{\"Variation\":15,\"Texture\":0}}', '{\"Hat\":{\"Variation\":-1,\"Texture\":0},\"Glasses\":{\"Variation\":-1,\"Texture\":0},\"Ear\":{\"Variation\":-1,\"Texture\":0},\"Watches\":{\"Variation\":-1,\"Texture\":0},\"Bracelets\":{\"Variation\":-1,\"Texture\":0}}', '{\"0\":[],\"1\":[],\"2\":[{\"Dictionary\":\"mpchristmas2_overlays\",\"Hash\":\"MP_Xmas2_F_Tat_012\",\"Slots\":[2]}],\"3\":[{\"Dictionary\":\"mpchristmas2_overlays\",\"Hash\":\"MP_Xmas2_F_Tat_027\",\"Slots\":[0]}],\"4\":[],\"5\":[{\"Dictionary\":\"mpgunrunning_overlays\",\"Hash\":\"MP_Gunrunning_Tattoo_026_F\",\"Slots\":[0]}]}', 1, 1, 2, 0, 0, 1, 1);

-- ----------------------------
-- Table structure for e_candidates
-- ----------------------------
DROP TABLE IF EXISTS `e_candidates`;
CREATE TABLE `e_candidates`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `election` int NULL DEFAULT NULL,
  `name` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `votes` int NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Records of e_candidates
-- ----------------------------

-- ----------------------------
-- Table structure for e_points
-- ----------------------------
DROP TABLE IF EXISTS `e_points`;
CREATE TABLE `e_points`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `election` int NULL DEFAULT NULL,
  `position` float(255, 0) NULL DEFAULT NULL,
  `dimension` int NULL DEFAULT NULL,
  `opened` tinyint NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Records of e_points
-- ----------------------------

-- ----------------------------
-- Table structure for e_voters
-- ----------------------------
DROP TABLE IF EXISTS `e_voters`;
CREATE TABLE `e_voters`  (
  `election` int NULL DEFAULT NULL,
  `login` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `votedfor` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL
) ENGINE = InnoDB CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Records of e_voters
-- ----------------------------

-- ----------------------------
-- Table structure for farmer
-- ----------------------------
DROP TABLE IF EXISTS `farmer`;
CREATE TABLE `farmer`  (
  `uuid` int NOT NULL,
  `level` int NULL DEFAULT NULL,
  `exp` int NULL DEFAULT NULL,
  `allpoints` int NULL DEFAULT NULL,
  PRIMARY KEY (`uuid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_bin ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of farmer
-- ----------------------------
INSERT INTO `farmer` VALUES (94329, 1, 19, 19);
INSERT INTO `farmer` VALUES (191970, 1, 90, 90);
INSERT INTO `farmer` VALUES (333333, 1, 0, 0);
INSERT INTO `farmer` VALUES (683251, 1, 10, 10);
INSERT INTO `farmer` VALUES (853521, 1, 8, 8);

-- ----------------------------
-- Table structure for fractionaccess
-- ----------------------------
DROP TABLE IF EXISTS `fractionaccess`;
CREATE TABLE `fractionaccess`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `fraction` int NULL DEFAULT NULL,
  `commands` varchar(4096) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `weapons` varchar(4096) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 21 CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of fractionaccess
-- ----------------------------
INSERT INTO `fractionaccess` VALUES (1, 1, '{\"invite\": \"9\",  \"uninvite\": \"9\",  \"openstock\": \"10\",  \"setrank\": \"9\",  \"pocket\": \"1\",  \"openweaponstock\": \"9\",  \"takemoney\": \"9\",  \"takemedkits\": \"9\",  \"takedrugs\": \"9\",  \"takemats\": \"9\",  \"capture\": \"9\", \"takestock\": \"9\", \"buydrugs\": \"9\"}', NULL);
INSERT INTO `fractionaccess` VALUES (2, 2, '{\"invite\": \"9\",  \"uninvite\": \"9\",  \"openstock\": \"10\",  \"setrank\": \"9\",  \"pocket\": \"1\",  \"openweaponstock\": \"9\",  \"takemoney\": \"9\",  \"takemedkits\": \"9\",  \"takedrugs\": \"9\",  \"takemats\": \"9\",  \"capture\": \"9\", \"takestock\": \"9\", \"buydrugs\": \"9\"}', NULL);
INSERT INTO `fractionaccess` VALUES (3, 3, '{\"invite\": \"9\",  \"uninvite\": \"9\",  \"openstock\": \"10\",  \"setrank\": \"9\",  \"pocket\": \"1\",  \"openweaponstock\": \"9\",  \"takemoney\": \"9\",  \"takemedkits\": \"9\",  \"takedrugs\": \"9\",  \"takemats\": \"9\",  \"capture\": \"9\", \"takestock\": \"9\", \"buydrugs\": \"9\"}', NULL);
INSERT INTO `fractionaccess` VALUES (4, 4, '{\"invite\": \"9\",  \"uninvite\": \"9\",  \"openstock\": \"10\",  \"setrank\": \"9\",  \"pocket\": \"1\",  \"openweaponstock\": \"9\",  \"takemoney\": \"9\",  \"takemedkits\": \"9\",  \"takedrugs\": \"9\",  \"takemats\": \"9\",  \"capture\": \"9\", \"takestock\": \"9\", \"buydrugs\": \"9\"}', NULL);
INSERT INTO `fractionaccess` VALUES (5, 5, '{\"invite\": \"9\",  \"uninvite\": \"9\",  \"openstock\": \"10\",  \"setrank\": \"9\",  \"pocket\": \"1\",  \"openweaponstock\": \"9\",  \"takemoney\": \"9\",  \"takemedkits\": \"9\",  \"takedrugs\": \"9\",  \"takemats\": \"9\",  \"capture\": \"9\", \"takestock\": \"9\", \"buydrugs\": \"9\"}', NULL);
INSERT INTO `fractionaccess` VALUES (6, 6, '{\"invite\": \"19\",  \"uninvite\": \"19\",  \"setrank\": \"19\",  \"ticket\": \"5\",  \"arrest\": \"19\",  \"rfp\": \"19\",  \"follow\": \"10\",  \"su\": \"5\",  \"incar\": \"5\",  \"pull\": \"5\",  \"openstock\": \"20\",  \"givegunlic\": \"5\",  \"takegunlic\": \"5\",  \"cuff\": \"1\",  \"dep\": \"1\",  \"gov\": \"1\"}', '{\"govgun\":\"1\", \"armor\":\"1\", \"Medkits\":\"1\", \"PistolAmmo\":\"1\", \"SMGAmmo\":\"1\", \"RiflesAmmo\":\"1\"}');
INSERT INTO `fractionaccess` VALUES (7, 7, '{\"invite\": \"17\",  \"uninvite\": \"17\",  \"setrank\": \"15\",  \"ticket\": \"1\",  \"arrest\": \"1\",  \"pd\": \"1\", \"rfp\": \"1\",  \"follow\": \"1\",  \"su\": \"1\",  \"incar\": \"1\",  \"pull\": \"1\",  \"warg\": \"15\",  \"openweaponstock\": \"15\",  \"openstock\": \"14\",  \"givegunlic\": \"11\",  \"takegunlic\": \"11\",  \"cuff\": \"1\",  \"dep\": \"1\",  \"gov\": \"1\"}', '{\"lspdgun\":\"1\", \"armor\":\"1\", \"Medkits\":\"1\", \"PistolAmmo\":\"1\", \"SMGAmmo\":\"1\", \"ShotgunsAmmo\":\"1\", \"RiflesAmmo\":\"1\"}');
INSERT INTO `fractionaccess` VALUES (8, 8, '{\"invite\": \"10\",  \"uninvite\": \"10\",  \"openstock\": \"11\",  \"setrank\": \"10\",  \"heal\": \"1\",  \"accept\": \"1\",  \"medkit\": \"5\",  \"givemedlic\": \"6\",  \"ems\": \"1\", \"dep\": \"1\",  \"gov\": \"1\"}', '{\"Medkits\":\"1\"}');
INSERT INTO `fractionaccess` VALUES (9, 9, '{\"invite\": \"13\",  \"uninvite\": \"13\",  \"setrank\": \"13\",  \"ticket\": \"1\",  \"arrest\": \"1\",  \"rfp\": \"1\",  \"follow\": \"1\",  \"su\": \"1\",  \"incar\": \"1\",  \"pull\": \"1\",  \"warg\": \"10\",  \"openweaponstock\": \"12\",  \"openstock\": \"14\",  \"givegunlic\": \"1\",  \"takegunlic\": \"1\",  \"cuff\": \"1\",  \"dep\": \"1\",  \"gov\": \"1\"}', '{\"fbigun\":\"1\", \"armor\":\"1\", \"Medkits\":\"1\"}');
INSERT INTO `fractionaccess` VALUES (10, 10, '{\"invite\": \"9\",  \"uninvite\": \"9\",  \"openstock\": \"9\",  \"setrank\": \"9\",  \"pocket\": \"1\",  \"takebiz\": \"10\",  \"bizwar\": \"10\",  \"openweaponstock\": \"9\",  \"takemoney\": \"9\",  \"takemedkits\": \"9\",  \"takedrugs\": \"9\",  \"takemats\": \"9\",  \"cuff\": \"1\", \"takestock\": \"9\", \"buydrugs\": \"9\"}', NULL);
INSERT INTO `fractionaccess` VALUES (11, 11, '{\"invite\": \"9\",  \"uninvite\": \"9\",  \"openstock\": \"9\",  \"setrank\": \"9\",  \"pocket\": \"1\",  \"takebiz\": \"10\",  \"bizwar\": \"10\",  \"openweaponstock\": \"9\",  \"takemoney\": \"9\",  \"takemedkits\": \"9\",  \"takedrugs\": \"9\",  \"takemats\": \"9\",  \"cuff\": \"1\", \"takestock\": \"9\", \"buydrugs\": \"9\", \"takestock\": \"9\", \"buydrugs\": \"9\"}', NULL);
INSERT INTO `fractionaccess` VALUES (12, 12, '{\"invite\": \"9\",  \"uninvite\": \"9\",  \"openstock\": \"9\",  \"setrank\": \"9\",  \"pocket\": \"1\",  \"takebiz\": \"10\",  \"bizwar\": \"10\",  \"openweaponstock\": \"9\",  \"takemoney\": \"9\",  \"takemedkits\": \"9\",  \"takedrugs\": \"9\",  \"takemats\": \"9\",  \"cuff\": \"1\", \"takestock\": \"9\", \"buydrugs\": \"9\"}', NULL);
INSERT INTO `fractionaccess` VALUES (13, 13, '{\"invite\": \"9\",  \"uninvite\": \"9\",  \"openstock\": \"9\",  \"setrank\": \"9\",  \"pocket\": \"1\",  \"takebiz\": \"10\",  \"bizwar\": \"10\",  \"openweaponstock\": \"9\",  \"takemoney\": \"9\",  \"takemedkits\": \"9\",  \"takedrugs\": \"9\",  \"takemats\": \"9\",  \"cuff\": \"1\", \"takestock\": \"9\", \"buydrugs\": \"9\"}', NULL);
INSERT INTO `fractionaccess` VALUES (14, 14, '{\"invite\": \"14\",  \"uninvite\": \"14\", \"arrest\": \"1\",  \"rfp\": \"1\",  \"follow\": \"1\",  \"su\": \"1\",  \"incar\": \"1\",  \"pull\": \"1\",  \"setrank\": \"14\",  \"openweaponstock\": \"12\",  \"openstock\": \"14\",  \"dep\": \"1\",  \"gov\": \"1\"}', '{\"armygun\":\"1\", \"armor\":\"1\", \"Medkits\":\"1\", \"PistolAmmo\":\"1\", \"RiflesAmmo\":\"1\", \"SMGAmmo\":\"1\"}');
INSERT INTO `fractionaccess` VALUES (15, 15, '{\"invite\": \"17\",  \"uninvite\": \"17\",  \"setrank\": \"17\",  \"delad\": \"1\"}', NULL);
INSERT INTO `fractionaccess` VALUES (16, 16, '{\"invite\": \"1\",  \"uninvite\": \"1\",  \"openstock\": \"1\",  \"setrank\": \"1\",  \"pocket\": \"1\",  \"openweaponstock\": \"1\",  \"takemoney\": \"1\",  \"takemedkits\": \"1\",  \"takedrugs\": \"1\",  \"takemats\": \"7\"}', NULL);
INSERT INTO `fractionaccess` VALUES (17, 17, '{\"invite\": \"7\",  \"uninvite\": \"7\",  \"openstock\": \"8\",  \"setrank\": \"7\",  \"pocket\": \"1\",  \"openweaponstock\": \"7\",  \"takemoney\": \"7\",  \"takemedkits\": \"7\",  \"takedrugs\": \"7\",  \"takemats\": \"7\"}', NULL);
INSERT INTO `fractionaccess` VALUES (18, 18, '{\"invite\": \"12\",  \"uninvite\": \"12\",  \"openstock\": \"2\",  \"setrank\": \"12\",  \"pocket\": \"2\",  \"openweaponstock\": \"2\",  \"takemoney\": \"10\",  \"takemedkits\": \"2\",  \"takedrugs\": \"10\",  \"takemats\": \"10\"}', '{\"USMSgun\":\"1\", \"armor\":\"1\", \"Medkits\":\"1\"}');
INSERT INTO `fractionaccess` VALUES (19, 19, '{\"invite\": \"1\",  \"uninvite\": \"1\",  \"setrank\": \"1\"}', '{\"tuningManGetItem\":\"1\"}');
INSERT INTO `fractionaccess` VALUES (20, 20, '{\"invite\": \"1\",  \"uninvite\": \"1\",  \"setrank\": \"1\"}', '{\"mechitems\":\"1\"}');

-- ----------------------------
-- Table structure for fractionranks
-- ----------------------------
DROP TABLE IF EXISTS `fractionranks`;
CREATE TABLE `fractionranks`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `fraction` int NULL DEFAULT NULL,
  `rank` int NULL DEFAULT NULL,
  `payday` int NULL DEFAULT NULL,
  `name` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `clothesm` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `clothesf` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 246 CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of fractionranks
-- ----------------------------
INSERT INTO `fractionranks` VALUES (1, 7, 1, 200, 'Rekrut', 'police_1', 'police_1');
INSERT INTO `fractionranks` VALUES (2, 7, 2, 400, 'Police Officer I', 'police_1', 'police_1');
INSERT INTO `fractionranks` VALUES (3, 7, 3, 600, 'Police Officer II', 'police_2', 'police_2');
INSERT INTO `fractionranks` VALUES (4, 7, 4, 800, 'Police Officer III', 'police_2', 'police_2');
INSERT INTO `fractionranks` VALUES (5, 7, 5, 1100, 'Police Detective I', 'police_3', 'police_3');
INSERT INTO `fractionranks` VALUES (6, 7, 6, 1400, 'Police Detective II', 'police_4', 'police_4');
INSERT INTO `fractionranks` VALUES (7, 7, 7, 1600, 'Police Detective III', 'police_4', 'police_4');
INSERT INTO `fractionranks` VALUES (8, 7, 8, 1400, 'Police Seargeant I', 'police_4', 'police_4');
INSERT INTO `fractionranks` VALUES (9, 7, 9, 1600, 'Police Seargeant II', 'police_5', 'police_5');
INSERT INTO `fractionranks` VALUES (10, 7, 10, 1900, 'Police Lieutenant I', 'police_6', 'police_6');
INSERT INTO `fractionranks` VALUES (11, 7, 11, 2000, 'Police Lieutenant II', 'police_7', 'police_7');
INSERT INTO `fractionranks` VALUES (12, 7, 12, 2300, 'Police Captain I', 'police_8', 'police_8');
INSERT INTO `fractionranks` VALUES (13, 7, 13, 2600, 'Police Captain II', 'police_8', 'police_8');
INSERT INTO `fractionranks` VALUES (14, 7, 14, 2900, 'Police Captain III', 'police_8', 'police_8');
INSERT INTO `fractionranks` VALUES (15, 14, 1, 300, 'Recruit', 'army_1', 'army_1');
INSERT INTO `fractionranks` VALUES (16, 14, 2, 500, 'Private', 'army_2', 'army_2');
INSERT INTO `fractionranks` VALUES (17, 14, 3, 650, 'Specialist', 'army_3', 'army_3');
INSERT INTO `fractionranks` VALUES (18, 14, 4, 700, 'Corporal', 'army_4', 'army_4');
INSERT INTO `fractionranks` VALUES (19, 14, 5, 800, 'Sergeant', 'army_5', 'army_5');
INSERT INTO `fractionranks` VALUES (20, 14, 6, 950, 'Staff Sergeant', 'army_6', 'army_6');
INSERT INTO `fractionranks` VALUES (21, 14, 7, 1100, 'Master Segeant', 'army_7', 'army_7');
INSERT INTO `fractionranks` VALUES (22, 14, 8, 1350, 'Sergeant Major', 'army_8', 'army_8');
INSERT INTO `fractionranks` VALUES (23, 14, 9, 1600, 'Warrant Officer', 'army_9', 'army_9');
INSERT INTO `fractionranks` VALUES (24, 14, 10, 1750, 'Lieutenant', 'army_10', 'army_10');
INSERT INTO `fractionranks` VALUES (25, 14, 11, 1900, 'Captain', 'army_11', 'army_11');
INSERT INTO `fractionranks` VALUES (26, 14, 12, 2100, 'Major', 'army_12', 'army_12');
INSERT INTO `fractionranks` VALUES (27, 14, 13, 2300, 'Lieutenant Colonel', 'army_13', 'army_13');
INSERT INTO `fractionranks` VALUES (28, 14, 14, 2400, 'Colonel', 'army_14', 'army_14');
INSERT INTO `fractionranks` VALUES (29, 14, 15, 2500, 'General', 'army_15', 'army_15');
INSERT INTO `fractionranks` VALUES (30, 6, 1, 300, 'Trainee', 'city_1', 'city_1');
INSERT INTO `fractionranks` VALUES (31, 6, 2, 500, 'Jurist', 'city_1', 'city_1');
INSERT INTO `fractionranks` VALUES (32, 6, 3, 500, 'Secretary', 'city_1', 'city_1');
INSERT INTO `fractionranks` VALUES (33, 6, 4, 500, 'Officer USSS', 'city_1', 'city_1');
INSERT INTO `fractionranks` VALUES (34, 6, 5, 1000, 'Junior Lawyer', 'city_2', 'city_2');
INSERT INTO `fractionranks` VALUES (35, 6, 6, 1000, 'Secretary Assistant', 'city_2', 'city_2');
INSERT INTO `fractionranks` VALUES (36, 6, 7, 1000, 'USSS Agent', 'city_3', 'city_3');
INSERT INTO `fractionranks` VALUES (37, 6, 8, 1600, 'Lawyer', 'city_3', 'city_3');
INSERT INTO `fractionranks` VALUES (38, 6, 9, 1600, 'HR Manager', 'city_4', 'city_4');
INSERT INTO `fractionranks` VALUES (39, 6, 10, 1600, 'Special Agent USSS', 'city_4', 'city_4');
INSERT INTO `fractionranks` VALUES (40, 6, 11, 2000, 'Prosecuto', 'city_5', 'city_5');
INSERT INTO `fractionranks` VALUES (41, 6, 12, 2000, 'Event Manager', 'city_5', 'city_5');
INSERT INTO `fractionranks` VALUES (42, 6, 13, 2000, 'Head USSS', 'city_6', 'city_6');
INSERT INTO `fractionranks` VALUES (43, 6, 14, 2300, 'Judge', 'city_6', 'city_6');
INSERT INTO `fractionranks` VALUES (44, 6, 15, 2300, 'Chief of Staff', 'city_6', 'city_6');
INSERT INTO `fractionranks` VALUES (46, 6, 16, 2300, 'USSS Director', 'city_7', 'city_7');
INSERT INTO `fractionranks` VALUES (47, 6, 17, 2500, 'Advisor', 'city_7', 'city_7');
INSERT INTO `fractionranks` VALUES (48, 6, 18, 2500, 'Mayor', 'city_8', 'city_8');
INSERT INTO `fractionranks` VALUES (49, 6, 19, 2500, 'Minister', 'city_8', 'city_8');
INSERT INTO `fractionranks` VALUES (50, 6, 20, 2700, 'Governor', 'city_9', 'city_9');
INSERT INTO `fractionranks` VALUES (51, 8, 1, 300, 'Pharmacist', 'ems_1', 'ems_1');
INSERT INTO `fractionranks` VALUES (52, 8, 2, 600, 'Intern', 'ems_1', 'ems_1');
INSERT INTO `fractionranks` VALUES (53, 8, 3, 850, 'Paramedic', 'ems_1', 'ems_1');
INSERT INTO `fractionranks` VALUES (54, 8, 4, 900, 'Therapist', 'ems_1', 'ems_1');
INSERT INTO `fractionranks` VALUES (55, 8, 5, 1150, 'Diagnostician', 'ems_1', 'ems_1');
INSERT INTO `fractionranks` VALUES (56, 8, 6, 1300, 'Surgeon', 'ems_2', 'ems_2');
INSERT INTO `fractionranks` VALUES (57, 8, 7, 1500, 'Anesthesiologist', 'ems_2', 'ems_2');
INSERT INTO `fractionranks` VALUES (58, 8, 8, 1750, 'Cardiologist', 'ems_3', 'ems_3');
INSERT INTO `fractionranks` VALUES (59, 8, 9, 1900, 'Chief Department', 'ems_4', 'ems_4');
INSERT INTO `fractionranks` VALUES (60, 8, 10, 2100, 'Deputy Head Physician', 'ems_4', 'ems_4');
INSERT INTO `fractionranks` VALUES (61, 8, 11, 2500, 'Head Physician', 'ems_4', 'ems_4');
INSERT INTO `fractionranks` VALUES (62, 9, 1, 300, 'Trainee', 'null', 'null');
INSERT INTO `fractionranks` VALUES (63, 9, 2, 400, 'Jr.Agent', 'null', 'null');
INSERT INTO `fractionranks` VALUES (64, 9, 3, 550, 'Agent', 'null', 'null');
INSERT INTO `fractionranks` VALUES (65, 9, 4, 600, 'Sen.Agent', 'null', 'null');
INSERT INTO `fractionranks` VALUES (66, 9, 5, 750, 'Senior Lead Agent', 'null', 'null');
INSERT INTO `fractionranks` VALUES (67, 9, 6, 950, 'Special Agent I', 'null', 'null');
INSERT INTO `fractionranks` VALUES (68, 9, 7, 1100, 'Special Agent II', 'null', 'null');
INSERT INTO `fractionranks` VALUES (69, 9, 8, 1250, 'Special Agent III', 'null', 'null');
INSERT INTO `fractionranks` VALUES (70, 9, 9, 1400, 'Secret Agent', 'null', 'null');
INSERT INTO `fractionranks` VALUES (71, 9, 10, 1650, 'Dep.Head', 'null', 'null');
INSERT INTO `fractionranks` VALUES (72, 9, 11, 1850, 'Head', 'null', 'null');
INSERT INTO `fractionranks` VALUES (73, 9, 12, 2100, 'Assistant of Director', 'null', 'null');
INSERT INTO `fractionranks` VALUES (74, 9, 13, 2300, 'Deputy of Director', 'null', 'null');
INSERT INTO `fractionranks` VALUES (75, 9, 14, 2500, 'Director', 'null', 'null');
INSERT INTO `fractionranks` VALUES (76, 15, 1, 300, 'Стажер', NULL, NULL);
INSERT INTO `fractionranks` VALUES (77, 15, 2, 500, 'Журналист', NULL, NULL);
INSERT INTO `fractionranks` VALUES (78, 15, 3, 700, 'Специалист', NULL, NULL);
INSERT INTO `fractionranks` VALUES (79, 15, 4, 900, 'Наставник', NULL, NULL);
INSERT INTO `fractionranks` VALUES (80, 15, 5, 1200, 'Фотограф', NULL, NULL);
INSERT INTO `fractionranks` VALUES (81, 15, 6, 1300, 'Рекрутёр', NULL, NULL);
INSERT INTO `fractionranks` VALUES (82, 15, 7, 1100, 'Рерайтер', NULL, NULL);
INSERT INTO `fractionranks` VALUES (83, 15, 8, 1300, 'Младший Редактор', NULL, NULL);
INSERT INTO `fractionranks` VALUES (84, 15, 9, 1400, 'Оператор', NULL, NULL);
INSERT INTO `fractionranks` VALUES (85, 15, 10, 1500, 'Менеджер по персоналу', NULL, NULL);
INSERT INTO `fractionranks` VALUES (86, 15, 11, 1700, 'Старший Редактор', NULL, NULL);
INSERT INTO `fractionranks` VALUES (87, 15, 12, 1800, 'Продюссер', NULL, NULL);
INSERT INTO `fractionranks` VALUES (88, 15, 13, 1750, 'Старший Менеджер', NULL, NULL);
INSERT INTO `fractionranks` VALUES (89, 15, 14, 2000, 'Главный Редактор', NULL, NULL);
INSERT INTO `fractionranks` VALUES (90, 15, 15, 2200, 'Главный Ведущий', NULL, NULL);
INSERT INTO `fractionranks` VALUES (91, 15, 16, 2100, 'Главный Менеджер', NULL, NULL);
INSERT INTO `fractionranks` VALUES (92, 15, 17, 2300, 'Заместитель Директора', NULL, NULL);
INSERT INTO `fractionranks` VALUES (93, 15, 18, 2500, 'Генеральный Директор', NULL, NULL);
INSERT INTO `fractionranks` VALUES (94, 17, 1, 300, 'Стажёр', NULL, NULL);
INSERT INTO `fractionranks` VALUES (95, 17, 2, 400, 'Оперативник', NULL, NULL);
INSERT INTO `fractionranks` VALUES (96, 17, 3, 550, 'Агент', NULL, NULL);
INSERT INTO `fractionranks` VALUES (97, 17, 4, 600, 'Специалист', NULL, NULL);
INSERT INTO `fractionranks` VALUES (98, 17, 5, 900, 'Заместитель главы отдела', NULL, NULL);
INSERT INTO `fractionranks` VALUES (99, 17, 6, 1200, 'Глава отдела', NULL, NULL);
INSERT INTO `fractionranks` VALUES (100, 17, 7, 1800, 'Заместитель директора', NULL, NULL);
INSERT INTO `fractionranks` VALUES (101, 17, 8, 3000, 'Директор', NULL, NULL);
INSERT INTO `fractionranks` VALUES (102, 16, 1, 0, 'Hangaround', NULL, NULL);
INSERT INTO `fractionranks` VALUES (103, 16, 2, 0, 'Prospect', NULL, NULL);
INSERT INTO `fractionranks` VALUES (104, 16, 3, 0, 'Member', NULL, NULL);
INSERT INTO `fractionranks` VALUES (105, 16, 4, 0, 'Road Captain', NULL, NULL);
INSERT INTO `fractionranks` VALUES (106, 16, 5, 0, 'Treasurer', NULL, NULL);
INSERT INTO `fractionranks` VALUES (107, 16, 6, 0, 'Sergeant at Arms', NULL, NULL);
INSERT INTO `fractionranks` VALUES (108, 16, 7, 0, 'Vice President', NULL, NULL);
INSERT INTO `fractionranks` VALUES (109, 16, 8, 0, 'President', NULL, NULL);
INSERT INTO `fractionranks` VALUES (110, 10, 1, 0, 'Novizio', NULL, NULL);
INSERT INTO `fractionranks` VALUES (111, 10, 2, 0, 'Testato', NULL, NULL);
INSERT INTO `fractionranks` VALUES (112, 10, 3, 0, 'Associato', NULL, NULL);
INSERT INTO `fractionranks` VALUES (113, 10, 4, 0, 'Controlato', NULL, NULL);
INSERT INTO `fractionranks` VALUES (114, 10, 5, 0, 'Soldato', NULL, NULL);
INSERT INTO `fractionranks` VALUES (115, 10, 6, 0, 'Aiutante', NULL, NULL);
INSERT INTO `fractionranks` VALUES (116, 10, 7, 0, 'Capo', NULL, NULL);
INSERT INTO `fractionranks` VALUES (117, 10, 8, 0, 'Strado Boss', NULL, NULL);
INSERT INTO `fractionranks` VALUES (118, 10, 9, 0, 'Congseleri', NULL, NULL);
INSERT INTO `fractionranks` VALUES (119, 10, 10, 0, 'GodFather', NULL, NULL);
INSERT INTO `fractionranks` VALUES (120, 11, 1, 0, 'Шпана', NULL, NULL);
INSERT INTO `fractionranks` VALUES (121, 11, 2, 0, 'Бычара', NULL, NULL);
INSERT INTO `fractionranks` VALUES (122, 11, 3, 0, 'Мужики', NULL, NULL);
INSERT INTO `fractionranks` VALUES (123, 11, 4, 0, 'Браток', NULL, NULL);
INSERT INTO `fractionranks` VALUES (124, 11, 5, 0, 'Бродяга', NULL, NULL);
INSERT INTO `fractionranks` VALUES (125, 11, 6, 0, 'Блатной', NULL, NULL);
INSERT INTO `fractionranks` VALUES (126, 11, 7, 0, 'Авторитет', NULL, NULL);
INSERT INTO `fractionranks` VALUES (127, 11, 8, 0, 'Смотрящий', NULL, NULL);
INSERT INTO `fractionranks` VALUES (128, 11, 9, 0, 'Положенец', NULL, NULL);
INSERT INTO `fractionranks` VALUES (129, 11, 10, 0, 'Вор в законе', NULL, NULL);
INSERT INTO `fractionranks` VALUES (130, 12, 1, 0, 'Wakasu', NULL, NULL);
INSERT INTO `fractionranks` VALUES (131, 12, 2, 0, 'Ke_Dai', NULL, NULL);
INSERT INTO `fractionranks` VALUES (132, 12, 3, 0, 'Sata-gasira', NULL, NULL);
INSERT INTO `fractionranks` VALUES (133, 12, 4, 0, 'Vaka-gasira', NULL, NULL);
INSERT INTO `fractionranks` VALUES (134, 12, 5, 0, 'Co-kubintu', NULL, NULL);
INSERT INTO `fractionranks` VALUES (135, 12, 6, 0, 'Kambu', NULL, NULL);
INSERT INTO `fractionranks` VALUES (136, 12, 7, 0, 'Oazi', NULL, NULL);
INSERT INTO `fractionranks` VALUES (137, 12, 8, 0, 'Saiko Komon', NULL, NULL);
INSERT INTO `fractionranks` VALUES (138, 12, 9, 0, 'Oyabun', NULL, NULL);
INSERT INTO `fractionranks` VALUES (139, 12, 10, 0, 'Kumite', NULL, NULL);
INSERT INTO `fractionranks` VALUES (140, 13, 1, 0, 'Джаел', NULL, NULL);
INSERT INTO `fractionranks` VALUES (141, 13, 2, 0, 'Лав Тха', NULL, NULL);
INSERT INTO `fractionranks` VALUES (142, 13, 3, 0, 'Хардах', NULL, NULL);
INSERT INTO `fractionranks` VALUES (143, 13, 4, 0, 'Анцагорц', NULL, NULL);
INSERT INTO `fractionranks` VALUES (144, 13, 5, 0, 'Джепкир', NULL, NULL);
INSERT INTO `fractionranks` VALUES (145, 13, 6, 0, 'Йехпаир', NULL, NULL);
INSERT INTO `fractionranks` VALUES (146, 13, 7, 0, 'Найох', NULL, NULL);
INSERT INTO `fractionranks` VALUES (147, 13, 8, 0, 'Гох', NULL, NULL);
INSERT INTO `fractionranks` VALUES (148, 13, 9, 0, 'Кероп', NULL, NULL);
INSERT INTO `fractionranks` VALUES (149, 13, 10, 0, 'Кавор', NULL, NULL);
INSERT INTO `fractionranks` VALUES (150, 1, 1, 0, 'New Blood', NULL, NULL);
INSERT INTO `fractionranks` VALUES (151, 1, 2, 0, 'Little Homie', NULL, NULL);
INSERT INTO `fractionranks` VALUES (153, 1, 3, 0, 'Big Homie', NULL, NULL);
INSERT INTO `fractionranks` VALUES (154, 1, 4, 0, 'Mobsta', NULL, NULL);
INSERT INTO `fractionranks` VALUES (155, 1, 5, 0, 'Playa', NULL, NULL);
INSERT INTO `fractionranks` VALUES (156, 1, 6, 0, 'Killa', NULL, NULL);
INSERT INTO `fractionranks` VALUES (157, 1, 7, 0, 'Enforcer', NULL, NULL);
INSERT INTO `fractionranks` VALUES (158, 1, 8, 0, 'Lieutenant', NULL, NULL);
INSERT INTO `fractionranks` VALUES (159, 1, 9, 0, 'OG', NULL, NULL);
INSERT INTO `fractionranks` VALUES (160, 1, 10, 0, 'Boss Nigga', NULL, NULL);
INSERT INTO `fractionranks` VALUES (164, 2, 1, 0, 'Youngsta', NULL, NULL);
INSERT INTO `fractionranks` VALUES (165, 2, 2, 0, 'Gangsta', NULL, NULL);
INSERT INTO `fractionranks` VALUES (166, 2, 3, 0, 'Big Gangsta', NULL, NULL);
INSERT INTO `fractionranks` VALUES (167, 2, 4, 0, 'Hustla', NULL, NULL);
INSERT INTO `fractionranks` VALUES (168, 2, 5, 0, 'Folk', NULL, NULL);
INSERT INTO `fractionranks` VALUES (169, 2, 6, 0, 'Rich Nigga', NULL, NULL);
INSERT INTO `fractionranks` VALUES (170, 2, 7, 0, 'Block Nigga', NULL, NULL);
INSERT INTO `fractionranks` VALUES (171, 2, 8, 0, 'Lieutenant', NULL, NULL);
INSERT INTO `fractionranks` VALUES (172, 2, 9, 0, 'Ogirinal Gangsta', NULL, NULL);
INSERT INTO `fractionranks` VALUES (173, 2, 10, 0, 'Boss', NULL, NULL);
INSERT INTO `fractionranks` VALUES (177, 3, 1, 0, 'Forastero', NULL, NULL);
INSERT INTO `fractionranks` VALUES (178, 3, 2, 0, 'Fusilero', NULL, NULL);
INSERT INTO `fractionranks` VALUES (179, 3, 3, 0, 'Combatiente', NULL, NULL);
INSERT INTO `fractionranks` VALUES (180, 3, 4, 0, 'Norteno', NULL, NULL);
INSERT INTO `fractionranks` VALUES (181, 3, 5, 0, 'Gran Norteno', NULL, NULL);
INSERT INTO `fractionranks` VALUES (182, 3, 6, 0, 'Viejo Norteno', NULL, NULL);
INSERT INTO `fractionranks` VALUES (183, 3, 7, 0, 'Asesino', NULL, NULL);
INSERT INTO `fractionranks` VALUES (184, 3, 8, 0, 'El Capitan', NULL, NULL);
INSERT INTO `fractionranks` VALUES (185, 3, 9, 0, 'Representate', NULL, NULL);
INSERT INTO `fractionranks` VALUES (186, 3, 10, 0, 'El Padrino', NULL, NULL);
INSERT INTO `fractionranks` VALUES (190, 4, 1, 0, 'Informante', NULL, NULL);
INSERT INTO `fractionranks` VALUES (191, 4, 2, 0, 'Informante Primero', NULL, NULL);
INSERT INTO `fractionranks` VALUES (192, 4, 3, 0, 'Los Maton', NULL, NULL);
INSERT INTO `fractionranks` VALUES (193, 4, 4, 0, 'Maton Grande', NULL, NULL);
INSERT INTO `fractionranks` VALUES (194, 4, 5, 0, 'Contrancato', NULL, NULL);
INSERT INTO `fractionranks` VALUES (195, 4, 6, 0, 'El Sicario', NULL, NULL);
INSERT INTO `fractionranks` VALUES (196, 4, 7, 0, 'Contable', NULL, NULL);
INSERT INTO `fractionranks` VALUES (197, 4, 8, 0, 'Clica Teniente', NULL, NULL);
INSERT INTO `fractionranks` VALUES (198, 4, 9, 0, 'Clica Comandante', NULL, NULL);
INSERT INTO `fractionranks` VALUES (199, 4, 10, 0, 'Cosejo', NULL, NULL);
INSERT INTO `fractionranks` VALUES (203, 5, 1, 0, 'Associato', NULL, NULL);
INSERT INTO `fractionranks` VALUES (204, 5, 2, 0, 'Novato', NULL, NULL);
INSERT INTO `fractionranks` VALUES (205, 5, 3, 0, 'Conectado', NULL, NULL);
INSERT INTO `fractionranks` VALUES (206, 5, 4, 0, 'Sureno', NULL, NULL);
INSERT INTO `fractionranks` VALUES (207, 5, 5, 0, 'Gran Sureno', NULL, NULL);
INSERT INTO `fractionranks` VALUES (208, 5, 6, 0, 'Viejo Sureno', NULL, NULL);
INSERT INTO `fractionranks` VALUES (209, 5, 7, 0, 'Mafioso Original', NULL, NULL);
INSERT INTO `fractionranks` VALUES (210, 5, 8, 0, 'Lugarteniente', NULL, NULL);
INSERT INTO `fractionranks` VALUES (211, 5, 9, 0, 'El Padrino', NULL, NULL);
INSERT INTO `fractionranks` VALUES (212, 5, 10, 0, 'El Jefe', NULL, NULL);
INSERT INTO `fractionranks` VALUES (224, 18, 1, 750, 'Rekrut', 'USMS', 'USMS');
INSERT INTO `fractionranks` VALUES (225, 18, 2, 1500, 'U.S. Marshal I', 'USMS', 'USMS');
INSERT INTO `fractionranks` VALUES (226, 18, 3, 2000, 'U.S. Marshal II', 'USMS', 'USMS');
INSERT INTO `fractionranks` VALUES (227, 18, 4, 2300, 'U.S. Marshal III', 'USMS', 'USMS');
INSERT INTO `fractionranks` VALUES (228, 18, 5, 2500, 'U.S. Marshal IV', 'USMS', 'USMS');
INSERT INTO `fractionranks` VALUES (229, 18, 6, 2700, 'Deputy U.S. Marhsal I', 'USMS', 'USMS');
INSERT INTO `fractionranks` VALUES (230, 18, 14, 6000, 'Director of Marshal Service', 'USMS', 'USMS');
INSERT INTO `fractionranks` VALUES (231, 18, 7, 3000, 'Deputy U.S. Marhsal II', 'USMS', 'USMS');
INSERT INTO `fractionranks` VALUES (232, 18, 8, 3200, 'Deputy U.S. Marhsal III', 'USMS', 'USMS');
INSERT INTO `fractionranks` VALUES (233, 18, 9, 3500, 'Deputy U.S. Marhsal IV', 'USMS', 'USMS');
INSERT INTO `fractionranks` VALUES (234, 18, 10, 3700, 'Supervisor Deputy U.S. Marshal', 'USMS', 'USMS');
INSERT INTO `fractionranks` VALUES (235, 18, 11, 4000, 'Senior Supervisor Deputy U.S. Marshal', 'USMS', 'USMS');
INSERT INTO `fractionranks` VALUES (236, 18, 12, 4500, 'Deputy Chief of Staff', 'USMS', 'USMS');
INSERT INTO `fractionranks` VALUES (238, 18, 13, 5000, 'Deputy Director', 'USMS', 'USMS');
INSERT INTO `fractionranks` VALUES (239, 19, 1, 2000, 'Tuningman', NULL, NULL);
INSERT INTO `fractionranks` VALUES (241, 7, 15, 3300, 'Commander', 'police_8', 'police_8');
INSERT INTO `fractionranks` VALUES (242, 7, 16, 3700, 'Deputy Chief', 'police_8', 'police_8');
INSERT INTO `fractionranks` VALUES (243, 7, 17, 4100, 'Assistant Chief', 'police_8', 'police_8');
INSERT INTO `fractionranks` VALUES (244, 7, 18, 4500, 'Chief of Police', 'police_8', 'police_8');
INSERT INTO `fractionranks` VALUES (245, 20, 1, 2000, 'ACLS', NULL, NULL);

-- ----------------------------
-- Table structure for fractions
-- ----------------------------
DROP TABLE IF EXISTS `fractions`;
CREATE TABLE `fractions`  (
  `id` tinyint NOT NULL,
  `drugs` int NOT NULL,
  `money` bigint NOT NULL,
  `mats` int NOT NULL,
  `medkits` int NOT NULL,
  `lastserial` int NOT NULL,
  `weapons` varchar(16392) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `isopen` tinyint NOT NULL,
  `fuellimit` int NOT NULL,
  `fuelleft` int NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of fractions
-- ----------------------------
INSERT INTO `fractions` VALUES (1, 0, 124000, 10000, 300, 1, '[]', 1, 200, 150);
INSERT INTO `fractions` VALUES (2, 0, 124000, 10000, 300, 1, '[]', 1, 200, 150);
INSERT INTO `fractions` VALUES (3, 0, 124000, 10000, 300, 1, '[]', 1, 200, 150);
INSERT INTO `fractions` VALUES (4, 0, 2164000, 10000, 300, 1, '[]', 1, 200, 150);
INSERT INTO `fractions` VALUES (5, 0, 124000, 10000, 300, 1, '[]', 1, 200, 150);
INSERT INTO `fractions` VALUES (6, 0, 135171, 10000, 300, 8, '[{\"Data\":\"100600002\",\"ID\":122,\"Type\":122,\"Count\":1,\"IsActive\":false},{\"Data\":null,\"ID\":201,\"Type\":201,\"Count\":1,\"IsActive\":false}]', 1, 200, 200);
INSERT INTO `fractions` VALUES (7, 0, 100000, 6154, 293, 215, '[]', 1, 200, 200);
INSERT INTO `fractions` VALUES (8, 0, 100000, 10000, 300, 20, '[]', 1, 200, 200);
INSERT INTO `fractions` VALUES (9, 0, 100000, 10000, 300, 14, '[]', 1, 200, 200);
INSERT INTO `fractions` VALUES (10, 0, 100000, 10000, 300, 1, '[{\"Data\":\"1010xxxxx\",\"ID\":100,\"Type\":100,\"Count\":1,\"IsActive\":false}]', 1, 200, 150);
INSERT INTO `fractions` VALUES (11, 0, 100000, 10000, 300, 1, '[]', 1, 200, 150);
INSERT INTO `fractions` VALUES (12, 0, 100000, 10000, 300, 1, '[]', 1, 200, 150);
INSERT INTO `fractions` VALUES (13, 0, 100000, 10000, 300, 1, '[]', 1, 200, 150);
INSERT INTO `fractions` VALUES (14, 0, 100000, 10000, 300, 6, '[]', 1, 200, 200);
INSERT INTO `fractions` VALUES (15, 0, 100000, 10000, 300, 1, '[]', 1, 200, 150);
INSERT INTO `fractions` VALUES (16, 0, 100000, 10000, 300, 1, '[]', 1, 200, 200);
INSERT INTO `fractions` VALUES (17, 0, 100000, 10000, 300, 1, '[]', 1, 200, 150);
INSERT INTO `fractions` VALUES (18, 0, 100000, 10000, 300, 96, '[{\"Data\":\"101800030\",\"ID\":119,\"Type\":119,\"Count\":1,\"IsActive\":false}]', 1, 200, 200);
INSERT INTO `fractions` VALUES (19, 0, 100000, 10000, 300, 1, '[]', 1, 200, 200);
INSERT INTO `fractions` VALUES (20, 0, 100000, 10000, 300, 1, '[]', 1, 200, 200);

-- ----------------------------
-- Table structure for fractionvehicles
-- ----------------------------
DROP TABLE IF EXISTS `fractionvehicles`;
CREATE TABLE `fractionvehicles`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `fraction` tinyint NOT NULL,
  `number` varchar(25) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `model` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `position` varchar(256) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `rotation` varchar(256) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `color1` int NULL DEFAULT NULL,
  `color2` int NULL DEFAULT NULL,
  `rank` tinyint NOT NULL,
  `colorprim` varchar(11) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `colorsec` varchar(11) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `components` varchar(2048) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 631 CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Records of fractionvehicles
-- ----------------------------
INSERT INTO `fractionvehicles` VALUES (309, 1, 'gfam001', 'faction', '{\"x\":-80.14371,\"y\":-1429.02332,\"z\":29.67202}', '{\"x\":0.0,\"y\":0.0,\"z\":360.6278}', NULL, NULL, 1, '53', '59', '{}');
INSERT INTO `fractionvehicles` VALUES (310, 1, 'gfam002', 'faction', '{\"x\":-88.8976,\"y\":-1404.10229,\"z\":29.320755}', '{\"x\":0.0,\"y\":0.0,\"z\":0.122748673}', NULL, NULL, 1, '53', '59', '{}');
INSERT INTO `fractionvehicles` VALUES (311, 1, 'gfam003', 'faction', '{\"x\":-89.2411,\"y\":-1395.88745,\"z\":29.32077}', '{\"x\":0.0,\"y\":0.0,\"z\":1.32206631}', NULL, NULL, 1, '53', '59', '{}');
INSERT INTO `fractionvehicles` VALUES (312, 1, 'gfam004', 'faction', '{\"x\":-89.07395,\"y\":-1389.51147,\"z\":29.3207664}', '{\"x\":0.0,\"y\":0.0,\"z\":6.40100145}', NULL, NULL, 1, '53', '59', '{}');
INSERT INTO `fractionvehicles` VALUES (313, 1, 'gfam005', 'faction', '{\"x\":-81.4566,\"y\":-1416.91223,\"z\":29.3243523}', '{\"x\":0.0,\"y\":0.0,\"z\":268.5108}', NULL, NULL, 1, '53', '59', '{}');
INSERT INTO `fractionvehicles` VALUES (314, 1, 'gfam006', 'faction', '{\"x\":-74.67419,\"y\":-1417.01672,\"z\":29.3244858}', '{\"x\":0.0,\"y\":0.0,\"z\":270.88324}', NULL, NULL, 1, '53', '59', '{}');
INSERT INTO `fractionvehicles` VALUES (315, 1, 'gfam007', 'faction', '{\"x\":-68.11085,\"y\":-1416.84766,\"z\":29.3242779}', '{\"x\":0.0,\"y\":0.0,\"z\":267.914063}', NULL, NULL, 1, '53', '59', '{}');
INSERT INTO `fractionvehicles` VALUES (316, 1, 'gfam008', 'faction', '{\"x\":-60.1837044,\"y\":-1417.2334,\"z\":29.32528}', '{\"x\":0.0,\"y\":0.0,\"z\":269.4701}', NULL, NULL, 1, '53', '59', '{}');
INSERT INTO `fractionvehicles` VALUES (317, 1, 'gfam009', 'faction', '{\"x\":-52.5145378,\"y\":-1416.96143,\"z\":29.32414}', '{\"x\":0.0,\"y\":0.0,\"z\":270.724243}', NULL, NULL, 1, '53', '59', '{}');
INSERT INTO `fractionvehicles` VALUES (318, 1, 'gfam010', 'faction', '{\"x\":-46.28377,\"y\":-1416.63232,\"z\":29.3236237}', '{\"x\":0.0,\"y\":0.0,\"z\":267.868652}', NULL, NULL, 1, '53', '59', '{}');
INSERT INTO `fractionvehicles` VALUES (320, 1, 'gfam012', 'speedo', '{\"x\":-101.383118,\"y\":-1411.1000,\"z\":29.5705471}', '{\"x\":0.0,\"y\":0.0,\"z\":182.423035}', NULL, NULL, 1, '53', '59', '{}');
INSERT INTO `fractionvehicles` VALUES (322, 1, 'gfam014', 'speedo', '{\"x\":-112.383118,\"y\":-1412.138,\"z\":29.9672852}', '{\"x\":0.0,\"y\":0.0,\"z\":187.283478}', NULL, NULL, 1, '53', '59', '{}');
INSERT INTO `fractionvehicles` VALUES (324, 1, 'gfam016', 'bmx', '{\"x\":-84.9753647,\"y\":-1401.577,\"z\":29.3207531}', '{\"x\":0.0,\"y\":0.0,\"z\":269.193573}', NULL, NULL, 1, '53', '59', '{}');
INSERT INTO `fractionvehicles` VALUES (325, 1, 'gfam017', 'bmx', '{\"x\":-84.9753647,\"y\":-1403.577,\"z\":29.3207531}', '{\"x\":0.0,\"y\":0.0,\"z\":281.292328}', NULL, NULL, 1, '53', '59', '{}');
INSERT INTO `fractionvehicles` VALUES (326, 1, 'gfam018', 'bmx', '{\"x\":-84.9753647,\"y\":-1404.577,\"z\":29.32077}', '{\"x\":0.0,\"y\":0.0,\"z\":272.76413}', NULL, NULL, 1, '53', '59', '{}');
INSERT INTO `fractionvehicles` VALUES (327, 1, 'gfam019', 'bmx', '{\"x\":-84.9753647,\"y\":-1406.577,\"z\":29.32077}', '{\"x\":0.0,\"y\":0.0,\"z\":276.7098}', NULL, NULL, 1, '53', '59', '{}');
INSERT INTO `fractionvehicles` VALUES (328, 1, 'gfam020', 'bmx', '{\"x\":-84.9753647,\"y\":-1400.577,\"z\":29.3717175}', '{\"x\":0.0,\"y\":0.0,\"z\":270.189056}', NULL, NULL, 1, '53', '59', '{}');
INSERT INTO `fractionvehicles` VALUES (329, 9, 'FIB001', 'fbi', '{\"x\":96.73938,\"y\":-727.910767,\"z\":33.27976}', '{\"x\":0.0,\"y\":0.0,\"z\":342.00}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (330, 9, 'FIB002', 'fbi', '{\"x\":100.398766,\"y\":-729.283752,\"z\":33.2797775}', '{\"x\":0.0,\"y\":0.0,\"z\":342.00}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (331, 9, 'FIB003', 'fbi', '{\"x\":104.10537,\"y\":-730.826538,\"z\":33.2799263}', '{\"x\":0.0,\"y\":0.0,\"z\":342.00}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (335, 9, 'FIB007', 'fbi', '{\"x\":133.163071,\"y\":-741.7258,\"z\":33.2797241}', '{\"x\":0.0,\"y\":0.0,\"z\":342.00}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (337, 9, 'FIB009', 'fbi', '{\"x\":140.847427,\"y\":-744.5273,\"z\":33.2799225}', '{\"x\":0.0,\"y\":0.0,\"z\":342.00}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (338, 9, 'FIB010', 'fbi', '{\"x\":147.377243,\"y\":-746.9895,\"z\":33.28007}', '{\"x\":0.0,\"y\":0.0,\"z\":342.00}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (339, 9, 'FIB011', 'fbi', '{\"x\":151.113251,\"y\":-748.3934,\"z\":33.2795029}', '{\"x\":0.0,\"y\":0.0,\"z\":342.00}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (342, 9, 'FIB014', 'fbi2', '{\"x\":113.643692,\"y\":-716.106567,\"z\":33.25495}', '{\"x\":0.0,\"y\":0.0,\"z\":168.00}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (343, 9, 'FIB015', 'fbi2', '{\"x\":117.578911,\"y\":-717.4488,\"z\":33.2554665}', '{\"x\":0.0,\"y\":0.0,\"z\":168.00}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (347, 9, 'FIB019', 'fbi2', '{\"x\":132.8339,\"y\":-722.981262,\"z\":33.2554321}', '{\"x\":0.0,\"y\":0.0,\"z\":168.00}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (348, 9, 'FIB020', 'fbi2', '{\"x\":136.592224,\"y\":-724.369,\"z\":33.2554131}', '{\"x\":0.0,\"y\":0.0,\"z\":168.00}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (350, 9, 'FIB022', 'fbi2', '{\"x\":143.945709,\"y\":-727.16394,\"z\":33.255146}', '{\"x\":0.0,\"y\":0.0,\"z\":168.00}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (353, 9, 'FIB025', 'riot', '{\"x\":103.472954,\"y\":-693.394836,\"z\":33.2703362}', '{\"x\":0.0,\"y\":0.0,\"z\":160.00}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (354, 9, 'FIB026', 'riot', '{\"x\":107.28688,\"y\":-694.746948,\"z\":33.2707}', '{\"x\":0.0,\"y\":0.0,\"z\":160.00}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (355, 9, 'FIB027', 'riot', '{\"x\":111.015076,\"y\":-696.053833,\"z\":33.2700348}', '{\"x\":0.0,\"y\":0.0,\"z\":160.00}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (356, 9, 'FIB028', 'riot', '{\"x\":114.852348,\"y\":-697.429565,\"z\":33.2703323}', '{\"x\":0.0,\"y\":0.0,\"z\":160.00}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (357, 9, 'FIB029', 'riot', '{\"x\":118.612015,\"y\":-698.783752,\"z\":33.26977}', '{\"x\":0.0,\"y\":0.0,\"z\":160.00}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (358, 9, 'FIB030', 'riot', '{\"x\":122.446739,\"y\":-700.1433,\"z\":33.2702065}', '{\"x\":0.0,\"y\":0.0,\"z\":160.00}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (359, 9, 'FIB031', 'riot', '{\"x\":126.27063,\"y\":-701.5034,\"z\":33.2700577}', '{\"x\":0.0,\"y\":0.0,\"z\":160.00}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (360, 9, 'FIB032', 'police4', '{\"x\":147.71405,\"y\":-687.551636,\"z\":33.23549}', '{\"x\":0.0,\"y\":0.0,\"z\":250.00}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (361, 9, 'FIB033', 'police4', '{\"x\":149.024185,\"y\":-683.9838,\"z\":33.2366}', '{\"x\":0.0,\"y\":0.0,\"z\":250.00}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (362, 9, 'FIB034', 'police4', '{\"x\":163.756912,\"y\":-683.201,\"z\":33.2323456}', '{\"x\":0.0,\"y\":0.0,\"z\":160.00}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (363, 9, 'FIB035', 'police4', '{\"x\":169.68927,\"y\":-685.3635,\"z\":33.23108}', '{\"x\":0.0,\"y\":0.0,\"z\":160.00}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (364, 9, 'FIB036', 'police4', '{\"x\":173.322708,\"y\":-686.6598,\"z\":33.2306175}', '{\"x\":0.0,\"y\":0.0,\"z\":160.00}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (365, 9, 'FIB037', 'police4', '{\"x\":176.868225,\"y\":-688.0144,\"z\":33.23026}', '{\"x\":0.0,\"y\":0.0,\"z\":160.00}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (366, 9, 'FIB038', 'police4', '{\"x\":180.347824,\"y\":-695.6496,\"z\":33.23131}', '{\"x\":0.0,\"y\":0.0,\"z\":73.00}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (367, 9, 'FIB039', 'police4', '{\"x\":179.066589,\"y\":-699.154846,\"z\":33.2328873}', '{\"x\":0.0,\"y\":0.0,\"z\":73.00}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (368, 9, 'FIB040', 'police4', '{\"x\":176.21019,\"y\":-706.8655,\"z\":33.23504}', '{\"x\":0.0,\"y\":0.0,\"z\":73.00}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (369, 9, 'FIB041', 'police4', '{\"x\":175.028976,\"y\":-710.0858,\"z\":33.2367363}', '{\"x\":0.0,\"y\":0.0,\"z\":73.00}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (381, 9, 'FIB042', 'frogger', '{\"x\":200.431213,\"y\":-722.2529,\"z\":47.07696}', '{\"x\":0.0,\"y\":0.0,\"z\":113.534058}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (394, 5, 'gbld001', 'faction', '{\"x\":508.438324,\"y\":-1518.026,\"z\":29.2526722}', '{\"x\":0.173853874,\"y\":-0.14359805,\"z\":140.983917}', NULL, NULL, 1, '28', '44', '{}');
INSERT INTO `fractionvehicles` VALUES (395, 5, 'gbld002', 'faction', '{\"x\":506.222961,\"y\":-1516.04907,\"z\":29.2524338}', '{\"x\":0.166785955,\"y\":-0.150400862,\"z\":139.191559}', NULL, NULL, 1, '28', '44', '{}');
INSERT INTO `fractionvehicles` VALUES (396, 5, 'gbld003', 'faction', '{\"x\":503.739441,\"y\":-1513.82446,\"z\":29.2528458}', '{\"x\":0.192652881,\"y\":-0.158341616,\"z\":140.4931}', NULL, NULL, 1, '28', '44', '{}');
INSERT INTO `fractionvehicles` VALUES (397, 5, 'gbld004', 'faction', '{\"x\":502.478424,\"y\":-1526.80444,\"z\":29.2526054}', '{\"x\":-0.185995191,\"y\":0.1577599,\"z\":318.148651}', NULL, NULL, 1, '28', '44', '{}');
INSERT INTO `fractionvehicles` VALUES (398, 5, 'gbld005', 'faction', '{\"x\":500.2518,\"y\":-1524.83765,\"z\":29.25275}', '{\"x\":-0.185610533,\"y\":0.155115426,\"z\":317.9222}', NULL, NULL, 1, '28', '44', '{}');
INSERT INTO `fractionvehicles` VALUES (399, 5, 'gbld006', 'faction', '{\"x\":497.6542,\"y\":-1522.62109,\"z\":29.253603}', '{\"x\":-0.182715014,\"y\":0.142584234,\"z\":320.145752}', NULL, NULL, 1, '28', '44', '{}');
INSERT INTO `fractionvehicles` VALUES (400, 5, 'gbld007', 'faction', '{\"x\":495.243042,\"y\":-1520.54248,\"z\":29.253561}', '{\"x\":-0.1826344,\"y\":0.155614823,\"z\":318.2519}', NULL, NULL, 1, '28', '44', '{}');
INSERT INTO `fractionvehicles` VALUES (401, 5, 'gbld008', 'faction', '{\"x\":492.822021,\"y\":-1518.68677,\"z\":29.2536469}', '{\"x\":-0.144370139,\"y\":0.108716555,\"z\":318.331}', NULL, NULL, 1, '28', '44', '{}');
INSERT INTO `fractionvehicles` VALUES (402, 5, 'gbld009', 'faction', '{\"x\":488.237823,\"y\":-1543.21008,\"z\":29.22829}', '{\"x\":-0.666125536,\"y\":1.15736985,\"z\":229.1723}', NULL, NULL, 1, '28', '44', '{}');
INSERT INTO `fractionvehicles` VALUES (403, 5, 'gbld010', 'faction', '{\"x\":483.7829,\"y\":-1539.41846,\"z\":29.2207184}', '{\"x\":-1.263475,\"y\":1.24952865,\"z\":229.454834}', NULL, NULL, 1, '28', '44', '{}');
INSERT INTO `fractionvehicles` VALUES (405, 5, 'gbld012', 'speedo', '{\"x\":471.1469,\"y\":-1518.45215,\"z\":29.5294456}', '{\"x\":0.00169263291,\"y\":-0.140449822,\"z\":102.648224}', NULL, NULL, 1, '28', '44', '{}');
INSERT INTO `fractionvehicles` VALUES (407, 5, 'gbld014', 'speedo', '{\"x\":478.217468,\"y\":-1545.54285,\"z\":29.5124664}', '{\"x\":0.41271764,\"y\":-0.510377645,\"z\":51.98416}', NULL, NULL, 1, '28', '44', '{}');
INSERT INTO `fractionvehicles` VALUES (414, 5, 'gbld020', 'bmx', '{\"x\":474.2103,\"y\":-1527.51831,\"z\":29.1964245}', '{\"x\":-2.26192784,\"y\":-3.53680372,\"z\":328.231781}', NULL, NULL, 1, '28', '44', '{}');
INSERT INTO `fractionvehicles` VALUES (415, 5, 'gbld021', 'bmx', '{\"x\":475.045,\"y\":-1528.40161,\"z\":29.1948051}', '{\"x\":-3.070988,\"y\":-4.756816,\"z\":328.871429}', NULL, NULL, 1, '28', '44', '{}');
INSERT INTO `fractionvehicles` VALUES (416, 5, 'gbld022', 'bmx', '{\"x\":474.227051,\"y\":-1524.98486,\"z\":29.1897488}', '{\"x\":-2.504996,\"y\":3.74262428,\"z\":218.266}', NULL, NULL, 1, '28', '44', '{}');
INSERT INTO `fractionvehicles` VALUES (417, 5, 'gbld023', 'bmx', '{\"x\":475.254425,\"y\":-1524.46228,\"z\":29.1873741}', '{\"x\":-3.09887671,\"y\":4.987608,\"z\":216.277115}', NULL, NULL, 1, '28', '44', '{}');
INSERT INTO `fractionvehicles` VALUES (418, 5, 'gbld024', 'bmx', '{\"x\":475.932678,\"y\":-1529.16089,\"z\":29.1956024}', '{\"x\":-2.47350168,\"y\":-4.18694353,\"z\":330.4465}', NULL, NULL, 1, '28', '44', '{}');
INSERT INTO `fractionvehicles` VALUES (419, 2, 'gbls001', 'faction', '{\"x\":93.54604,\"y\":-1943.82788,\"z\":20.5874615}', '{\"x\":-0.464328259,\"y\":1.87919021,\"z\":204.473892}', NULL, NULL, 1, '145', '148', '{}');
INSERT INTO `fractionvehicles` VALUES (420, 2, 'gbls002', 'faction', '{\"x\":102.31881,\"y\":-1951.37988,\"z\":20.5946484}', '{\"x\":-2.34368563,\"y\":0.7738141,\"z\":257.105164}', NULL, NULL, 1, '145', '148', '{}');
INSERT INTO `fractionvehicles` VALUES (421, 2, 'gbls003', 'faction', '{\"x\":113.035629,\"y\":-1948.08972,\"z\":20.5924969}', '{\"x\":-1.67801929,\"y\":-1.45561945,\"z\":313.136475}', NULL, NULL, 1, '145', '148', '{}');
INSERT INTO `fractionvehicles` VALUES (422, 2, 'gbls004', 'faction', '{\"x\":115.8235,\"y\":-1937.566,\"z\":20.5935345}', '{\"x\":0.444844455,\"y\":-2.67781115,\"z\":13.96936}', NULL, NULL, 1, '145', '148', '{}');
INSERT INTO `fractionvehicles` VALUES (423, 2, 'gbls005', 'faction', '{\"x\":106.394974,\"y\":-1928.58789,\"z\":20.58865}', '{\"x\":2.02620316,\"y\":-0.7036577,\"z\":74.83917}', NULL, NULL, 1, '145', '148', '{}');
INSERT INTO `fractionvehicles` VALUES (424, 2, 'gbls006', 'faction', '{\"x\":86.07657,\"y\":-1951.07373,\"z\":20.8059654}', '{\"x\":0.218119115,\"y\":-0.4487372,\"z\":317.85434}', NULL, NULL, 1, '145', '148', '{}');
INSERT INTO `fractionvehicles` VALUES (425, 2, 'gbls007', 'faction', '{\"x\":90.04288,\"y\":-1955.00464,\"z\":20.8027115}', '{\"x\":0.242341116,\"y\":0.8481083,\"z\":319.386139}', NULL, NULL, 1, '145', '148', '{}');
INSERT INTO `fractionvehicles` VALUES (426, 2, 'gbls008', 'faction', '{\"x\":128.546631,\"y\":-1937.71606,\"z\":20.5996838}', '{\"x\":0.5231274,\"y\":-0.911313,\"z\":116.289368}', NULL, NULL, 1, '145', '148', '{}');
INSERT INTO `fractionvehicles` VALUES (427, 2, 'gbls009', 'faction', '{\"x\":130.323959,\"y\":-1940.224,\"z\":20.5610676}', '{\"x\":-3.3437438,\"y\":-0.5582189,\"z\":115.408936}', NULL, NULL, 1, '145', '148', '{}');
INSERT INTO `fractionvehicles` VALUES (428, 2, 'gbls010', 'faction', '{\"x\":78.5409,\"y\":-1942.39355,\"z\":20.81991}', '{\"x\":0.0586320236,\"y\":0.236578032,\"z\":319.754}', NULL, NULL, 1, '145', '148', '{}');
INSERT INTO `fractionvehicles` VALUES (430, 2, 'gbls012', 'speedo', '{\"x\":74.27999,\"y\":-1921.02075,\"z\":21.2310276}', '{\"x\":-3.52391672,\"y\":-0.748359561,\"z\":50.6565552}', NULL, NULL, 1, '145', '148', '{}');
INSERT INTO `fractionvehicles` VALUES (432, 2, 'gbls014', 'speedo', '{\"x\":80.4420853,\"y\":-1913.6228,\"z\":21.2536736}', '{\"x\":0.25328964,\"y\":-3.901758,\"z\":50.4927063}', NULL, NULL, 1, '145', '148', '{}');
INSERT INTO `fractionvehicles` VALUES (434, 2, 'gbls016', 'bmx', '{\"x\":115.030792,\"y\":-1957.05676,\"z\":20.72363}', '{\"x\":2.41426682,\"y\":2.475234,\"z\":117.132416}', NULL, NULL, 1, '145', '148', '{}');
INSERT INTO `fractionvehicles` VALUES (435, 2, 'gbls017', 'bmx', '{\"x\":99.9245148,\"y\":-1917.75391,\"z\":20.7615433}', '{\"x\":1.42571867,\"y\":-2.45858979,\"z\":45.0227661}', NULL, NULL, 1, '145', '148', '{}');
INSERT INTO `fractionvehicles` VALUES (436, 2, 'gbls018', 'bmx', '{\"x\":118.379356,\"y\":-1923.67249,\"z\":20.8131218}', '{\"x\":3.86334,\"y\":-1.87159419,\"z\":64.07709}', NULL, NULL, 1, '145', '148', '{}');
INSERT INTO `fractionvehicles` VALUES (437, 2, 'gbls019', 'bmx', '{\"x\":108.506439,\"y\":-1959.056,\"z\":20.74166}', '{\"x\":-3.78530574,\"y\":0.5014872,\"z\":267.6352}', NULL, NULL, 1, '145', '148', '{}');
INSERT INTO `fractionvehicles` VALUES (438, 2, 'gbls020', 'bmx', '{\"x\":81.4941254,\"y\":-1945.77271,\"z\":20.7418518}', '{\"x\":-3.446658,\"y\":-1.02942371,\"z\":292.8267}', NULL, NULL, 1, '145', '148', '{}');
INSERT INTO `fractionvehicles` VALUES (439, 3, 'gvgs001', 'faction', '{\"x\":1406.56775,\"y\":-1507.55676,\"z\":59.1612663}', '{\"x\":-3.75532722,\"y\":4.785205,\"z\":204.981613}', NULL, NULL, 1, '42', '126', '{}');
INSERT INTO `fractionvehicles` VALUES (440, 3, 'gvgs002', 'faction', '{\"x\":1408.86035,\"y\":-1504.96045,\"z\":59.43662}', '{\"x\":-0.680049956,\"y\":5.44269753,\"z\":205.1053}', NULL, NULL, 1, '42', '126', '{}');
INSERT INTO `fractionvehicles` VALUES (441, 3, 'gvgs003', 'faction', '{\"x\":1402.32251,\"y\":-1528.57227,\"z\":58.1521263}', '{\"x\":0.460193336,\"y\":4.055108,\"z\":57.3209229}', NULL, NULL, 1, '42', '126', '{}');
INSERT INTO `fractionvehicles` VALUES (442, 3, 'gvgs004', 'faction', '{\"x\":1394.87866,\"y\":-1533.00134,\"z\":57.4828033}', '{\"x\":1.10108054,\"y\":3.62958479,\"z\":41.99536}', NULL, NULL, 1, '42', '126', '{}');
INSERT INTO `fractionvehicles` VALUES (443, 3, 'gvgs005', 'faction', '{\"x\":1388.48816,\"y\":-1523.01514,\"z\":57.106308}', '{\"x\":-1.69296324,\"y\":4.112758,\"z\":295.603516}', NULL, NULL, 1, '42', '126', '{}');
INSERT INTO `fractionvehicles` VALUES (444, 3, 'gvgs006', 'faction', '{\"x\":1395.589,\"y\":-1519.48254,\"z\":57.66324}', '{\"x\":-0.738260269,\"y\":4.411017,\"z\":295.622}', NULL, NULL, 1, '42', '126', '{}');
INSERT INTO `fractionvehicles` VALUES (445, 3, 'gvgs007', 'faction', '{\"x\":1381.78809,\"y\":-1536.50659,\"z\":56.717205}', '{\"x\":3.24909353,\"y\":7.32367134,\"z\":298.010284}', NULL, NULL, 1, '42', '126', '{}');
INSERT INTO `fractionvehicles` VALUES (446, 3, 'gvgs008', 'faction', '{\"x\":1357.08276,\"y\":-1535.74512,\"z\":54.6095276}', '{\"x\":-5.51120043,\"y\":5.170312,\"z\":103.783783}', NULL, NULL, 1, '42', '126', '{}');
INSERT INTO `fractionvehicles` VALUES (447, 3, 'gvgs009', 'faction', '{\"x\":1362.76978,\"y\":-1520.54333,\"z\":56.7155838}', '{\"x\":-7.104959,\"y\":14.9726114,\"z\":203.405075}', NULL, NULL, 1, '42', '126', '{}');
INSERT INTO `fractionvehicles` VALUES (448, 3, 'gvgs010', 'faction', '{\"x\":1346.56641,\"y\":-1548.49036,\"z\":53.5696678}', '{\"x\":1.13479161,\"y\":5.298847,\"z\":40.61441}', NULL, NULL, 1, '42', '126', '{}');
INSERT INTO `fractionvehicles` VALUES (450, 3, 'gvgs012', 'speedo', '{\"x\":1363.51135,\"y\":-1534.343,\"z\":55.6247559}', '{\"x\":-9.238305,\"y\":4.969624,\"z\":101.763855}', NULL, NULL, 1, '42', '126', '{}');
INSERT INTO `fractionvehicles` VALUES (452, 3, 'gvgs014', 'speedo', '{\"x\":1407.59949,\"y\":-1494.884,\"z\":59.69632}', '{\"x\":-0.457396954,\"y\":5.77347231,\"z\":206.116684}', NULL, NULL, 1, '42', '126', '{}');
INSERT INTO `fractionvehicles` VALUES (454, 3, 'gvgs016', 'bmx', '{\"x\":1388.736,\"y\":-1539.23511,\"z\":56.59865}', '{\"x\":2.19380569,\"y\":-3.63321853,\"z\":33.8293457}', NULL, NULL, 1, '42', '126', '{}');
INSERT INTO `fractionvehicles` VALUES (455, 3, 'gvgs017', 'bmx', '{\"x\":1395.25793,\"y\":-1540.10645,\"z\":57.7560539}', '{\"x\":3.60135484,\"y\":-2.67747521,\"z\":54.0252075}', NULL, NULL, 1, '42', '126', '{}');
INSERT INTO `fractionvehicles` VALUES (456, 3, 'gvgs018', 'bmx', '{\"x\":1380.66345,\"y\":-1518.58716,\"z\":57.7310829}', '{\"x\":0.2707448,\"y\":6.967332,\"z\":126.522308}', NULL, NULL, 1, '42', '126', '{}');
INSERT INTO `fractionvehicles` VALUES (457, 3, 'gvgs019', 'bmx', '{\"x\":1352.66541,\"y\":-1533.29138,\"z\":54.29279}', '{\"x\":0.426707417,\"y\":3.08787847,\"z\":197.4619}', NULL, NULL, 1, '42', '126', '{}');
INSERT INTO `fractionvehicles` VALUES (458, 3, 'gvgs020', 'bmx', '{\"x\":1400.52441,\"y\":-1533.10718,\"z\":57.89538}', '{\"x\":2.81994963,\"y\":0.409944355,\"z\":72.53699}', NULL, NULL, 1, '42', '126', '{}');
INSERT INTO `fractionvehicles` VALUES (459, 4, 'gmrb001', 'faction', '{\"x\":863.487,\"y\":-2177.161,\"z\":30.498951}', '{\"x\":0.0,\"y\":0.0,\"z\":173.509644}', NULL, NULL, 1, '80', '79', '{}');
INSERT INTO `fractionvehicles` VALUES (460, 4, 'gmrb002', 'faction', '{\"x\":861.4365,\"y\":-2195.2356,\"z\":30.5063934}', '{\"x\":0.0,\"y\":0.0,\"z\":173.504776}', NULL, NULL, 1, '80', '79', '{}');
INSERT INTO `fractionvehicles` VALUES (461, 4, 'gmrb003', 'faction', '{\"x\":853.381836,\"y\":-2179.83765,\"z\":30.5997353}', '{\"x\":0.0,\"y\":0.0,\"z\":176.290421}', NULL, NULL, 1, '80', '79', '{}');
INSERT INTO `fractionvehicles` VALUES (462, 4, 'gmrb004', 'faction', '{\"x\":850.25415,\"y\":-2179.69678,\"z\":30.2975121}', '{\"x\":0.0,\"y\":0.0,\"z\":179.175781}', NULL, NULL, 1, '80', '79', '{}');
INSERT INTO `fractionvehicles` VALUES (463, 4, 'gmrb005', 'faction', '{\"x\":847.0161,\"y\":-2179.3208,\"z\":30.2982464}', '{\"x\":0.0,\"y\":0.0,\"z\":183.1396}', NULL, NULL, 1, '80', '79', '{}');
INSERT INTO `fractionvehicles` VALUES (464, 4, 'gmrb006', 'faction', '{\"x\":843.6608,\"y\":-2179.46338,\"z\":30.2967224}', '{\"x\":0.0,\"y\":0.0,\"z\":185.813126}', NULL, NULL, 1, '80', '79', '{}');
INSERT INTO `fractionvehicles` VALUES (465, 4, 'gmrb007', 'faction', '{\"x\":834.594055,\"y\":-2161.05176,\"z\":29.924099}', '{\"x\":0.0,\"y\":0.0,\"z\":359.393982}', NULL, NULL, 1, '80', '79', '{}');
INSERT INTO `fractionvehicles` VALUES (466, 4, 'gmrb008', 'faction', '{\"x\":834.615356,\"y\":-2167.05249,\"z\":30.1656837}', '{\"x\":0.0,\"y\":0.0,\"z\":1.38340342}', NULL, NULL, 1, '80', '79', '{}');
INSERT INTO `fractionvehicles` VALUES (467, 4, 'gmrb009', 'faction', '{\"x\":858.7408,\"y\":-2166.61133,\"z\":30.6281433}', '{\"x\":0.0,\"y\":0.0,\"z\":352.034576}', NULL, NULL, 1, '80', '79', '{}');
INSERT INTO `fractionvehicles` VALUES (468, 4, 'gmrb010', 'faction', '{\"x\":891.8968,\"y\":-2184.63281,\"z\":30.5146}', '{\"x\":0.0,\"y\":0.0,\"z\":262.135071}', NULL, NULL, 1, '80', '79', '{}');
INSERT INTO `fractionvehicles` VALUES (470, 4, 'gmrb012', 'speedo', '{\"x\":874.3041,\"y\":-2176.60278,\"z\":30.519371}', '{\"x\":0.0,\"y\":0.0,\"z\":179.325409}', NULL, NULL, 1, '80', '79', '{}');
INSERT INTO `fractionvehicles` VALUES (472, 4, 'gmrb014', 'speedo', '{\"x\":880.738953,\"y\":-2198.07349,\"z\":30.5193577}', '{\"x\":0.0,\"y\":0.0,\"z\":1.81545782}', NULL, NULL, 1, '80', '79', '{}');
INSERT INTO `fractionvehicles` VALUES (474, 4, 'gmrb016', 'bmx', '{\"x\":853.9964,\"y\":-2207.52344,\"z\":30.665844}', '{\"x\":0.0,\"y\":0.0,\"z\":265.98587}', NULL, NULL, 1, '80', '79', '{}');
INSERT INTO `fractionvehicles` VALUES (475, 4, 'gmrb017', 'bmx', '{\"x\":831.8595,\"y\":-2189.65674,\"z\":30.31206}', '{\"x\":0.0,\"y\":0.0,\"z\":337.805084}', NULL, NULL, 1, '80', '79', '{}');
INSERT INTO `fractionvehicles` VALUES (476, 4, 'gmrb018', 'bmx', '{\"x\":890.7353,\"y\":-2206.81055,\"z\":30.5095367}', '{\"x\":0.0,\"y\":0.0,\"z\":166.098373}', NULL, NULL, 1, '80', '79', '{}');
INSERT INTO `fractionvehicles` VALUES (477, 4, 'gmrb019', 'bmx', '{\"x\":890.2946,\"y\":-2221.12476,\"z\":30.50964}', '{\"x\":0.0,\"y\":0.0,\"z\":0.223939136}', NULL, NULL, 1, '80', '79', '{}');
INSERT INTO `fractionvehicles` VALUES (478, 4, 'gmrb020', 'bmx', '{\"x\":882.907349,\"y\":-2231.90015,\"z\":30.5674915}', '{\"x\":0.0,\"y\":0.0,\"z\":165.346542}', NULL, NULL, 1, '80', '79', '{}');
INSERT INTO `fractionvehicles` VALUES (479, 10, 'lcn001', 'oracle2', '{\"x\":1357.3866,\"y\":1137.48657,\"z\":113.542076}', '{\"x\":0.06838197,\"y\":0.14632684,\"z\":64.54315}', NULL, NULL, 1, '2', '3', '{}');
INSERT INTO `fractionvehicles` VALUES (480, 10, 'lcn002', 'oracle2', '{\"x\":1353.85046,\"y\":1156.24878,\"z\":113.759}', '{\"x\":0.0,\"y\":0.0,\"z\":139.105713}', NULL, NULL, 1, '2', '3', '{}');
INSERT INTO `fractionvehicles` VALUES (481, 10, 'lcn003', 'oracle2', '{\"x\":1358.56592,\"y\":1164.06543,\"z\":113.620689}', '{\"x\":0.0,\"y\":0.0,\"z\":353.761627}', NULL, NULL, 1, '2', '3', '{}');
INSERT INTO `fractionvehicles` VALUES (482, 10, 'lcn004', 'dubsta2', '{\"x\":1368.51758,\"y\":1129.93176,\"z\":113.960533}', '{\"x\":1.47221708,\"y\":0.491839,\"z\":17.7206116}', NULL, NULL, 1, '2', '3', '{}');
INSERT INTO `fractionvehicles` VALUES (483, 10, 'lcn005', 'dubsta2', '{\"x\":1369.14258,\"y\":1155.52734,\"z\":113.75898}', '{\"x\":0.0,\"y\":0.0,\"z\":47.0907974}', NULL, NULL, 1, '2', '3', '{}');
INSERT INTO `fractionvehicles` VALUES (484, 10, 'lcn006', 'patriot2', '{\"x\":1431.22839,\"y\":1129.17078,\"z\":114.508034}', '{\"x\":-0.140944734,\"y\":0.9158334,\"z\":179.184021}', NULL, NULL, 1, '2', '3', '{}');
INSERT INTO `fractionvehicles` VALUES (485, 10, 'lcn007', 'speedo', '{\"x\":1401.93347,\"y\":1116.3761,\"z\":115.076469}', '{\"x\":-0.00385902356,\"y\":-0.130277723,\"z\":88.68283}', NULL, NULL, 1, '2', '3', '{}');
INSERT INTO `fractionvehicles` VALUES (486, 11, 'rusm001', 'superd', '{\"x\":-108.17733,\"y\":1011.48853,\"z\":235.76004}', '{\"x\":0.0,\"y\":0.0,\"z\":110.39978}', NULL, NULL, 1, '12', '13', '{}');
INSERT INTO `fractionvehicles` VALUES (487, 11, 'rusm002', 'superd', '{\"x\":-106.601669,\"y\":1008.37628,\"z\":235.760056}', '{\"x\":0.0,\"y\":0.0,\"z\":115.576439}', NULL, NULL, 1, '12', '13', '{}');
INSERT INTO `fractionvehicles` VALUES (488, 11, 'rusm003', 'superd', '{\"x\":-105.512077,\"y\":1005.07111,\"z\":235.760056}', '{\"x\":0.0,\"y\":0.0,\"z\":107.630005}', NULL, NULL, 1, '12', '13', '{}');
INSERT INTO `fractionvehicles` VALUES (489, 11, 'rusm004', 'speedo', '{\"x\":-124.404579,\"y\":1008.22778,\"z\":235.732117}', '{\"x\":0.0,\"y\":0.0,\"z\":202.203812}', NULL, NULL, 1, '12', '13', '{}');
INSERT INTO `fractionvehicles` VALUES (490, 11, 'rusm005', 'xls', '{\"x\":-120.190567,\"y\":973.8219,\"z\":235.899368}', '{\"x\":0.0,\"y\":0.0,\"z\":26.94308}', NULL, NULL, 1, '12', '13', '{}');
INSERT INTO `fractionvehicles` VALUES (491, 11, 'rusm006', 'cognoscenti', '{\"x\":-116.310631,\"y\":973.8624,\"z\":235.795242}', '{\"x\":0.0,\"y\":0.0,\"z\":21.1067734}', NULL, NULL, 1, '12', '13', '{}');
INSERT INTO `fractionvehicles` VALUES (492, 11, 'rusm007', 'superd', '{\"x\":-132.444016,\"y\":1005.26636,\"z\":235.732117}', '{\"x\":0.0,\"y\":0.0,\"z\":191.082718}', NULL, NULL, 1, '12', '13', '{}');
INSERT INTO `fractionvehicles` VALUES (493, 12, 'ykdm001', 'tailgater', '{\"x\":-1538.27966,\"y\":-86.23496,\"z\":54.1345329}', '{\"x\":0.0,\"y\":0.0,\"z\":0.9880484}', NULL, NULL, 1, '12', '13', '{}');
INSERT INTO `fractionvehicles` VALUES (494, 12, 'ykdm002', 'tailgater', '{\"x\":-1578.83777,\"y\":-81.175,\"z\":54.13445}', '{\"x\":0.0,\"y\":0.0,\"z\":277.248077}', NULL, NULL, 1, '12', '13', '{}');
INSERT INTO `fractionvehicles` VALUES (495, 12, 'ykdm003', 'tailgater', '{\"x\":-1559.4043,\"y\":-86.0607147,\"z\":54.1344681}', '{\"x\":0.0,\"y\":0.0,\"z\":9.045747}', NULL, NULL, 1, '12', '13', '{}');
INSERT INTO `fractionvehicles` VALUES (496, 12, 'ykdm004', 'tailgater', '{\"x\":-1567.35437,\"y\":-75.3813248,\"z\":54.1344757}', '{\"x\":0.0,\"y\":0.0,\"z\":273.593231}', NULL, NULL, 1, '12', '13', '{}');
INSERT INTO `fractionvehicles` VALUES (497, 12, 'ykdm005', 'speedo', '{\"x\":-1577.77039,\"y\":-76.37124,\"z\":54.1344528}', '{\"x\":0.0,\"y\":0.0,\"z\":285.423553}', NULL, NULL, 1, '12', '13', '{}');
INSERT INTO `fractionvehicles` VALUES (498, 12, 'ykdm006', 'stretch', '{\"x\":-1568.69019,\"y\":-96.899826,\"z\":54.5289955}', '{\"x\":0.0,\"y\":0.0,\"z\":6.55273676}', NULL, NULL, 1, '12', '13', '{}');
INSERT INTO `fractionvehicles` VALUES (499, 12, 'ykdm007', 'xls', '{\"x\":-1553.41528,\"y\":-71.9817047,\"z\":54.1344681}', '{\"x\":0.0,\"y\":0.0,\"z\":295.4885}', NULL, NULL, 1, '12', '13', '{}');
INSERT INTO `fractionvehicles` VALUES (500, 13, 'armn001', 'washington', '{\"x\":-1791.02393,\"y\":462.888733,\"z\":128.308167}', '{\"x\":0.0,\"y\":0.0,\"z\":118.354485}', NULL, NULL, 1, '12', '13', '{}');
INSERT INTO `fractionvehicles` VALUES (501, 13, 'armn002', 'washington', '{\"x\":-1789.76331,\"y\":459.946655,\"z\":128.308029}', '{\"x\":0.0,\"y\":0.0,\"z\":126.632217}', NULL, NULL, 1, '12', '13', '{}');
INSERT INTO `fractionvehicles` VALUES (502, 13, 'armn003', 'washington', '{\"x\":-1787.90063,\"y\":456.2751,\"z\":128.308029}', '{\"x\":0.0,\"y\":0.0,\"z\":126.794586}', NULL, NULL, 1, '12', '13', '{}');
INSERT INTO `fractionvehicles` VALUES (503, 13, 'armn004', 'washington', '{\"x\":-1796.90649,\"y\":461.3541,\"z\":128.308167}', '{\"x\":0.0,\"y\":0.0,\"z\":110.967484}', NULL, NULL, 1, '12', '13', '{}');
INSERT INTO `fractionvehicles` VALUES (504, 13, 'armn005', 'stafford', '{\"x\":-1805.247,\"y\":453.269836,\"z\":128.304016}', '{\"x\":0.0,\"y\":0.0,\"z\":92.1178055}', NULL, NULL, 1, '12', '13', '{}');
INSERT INTO `fractionvehicles` VALUES (505, 13, 'armn006', 'freecrawler', '{\"x\":-1804.18872,\"y\":390.723969,\"z\":112.58091}', '{\"x\":0.0,\"y\":0.0,\"z\":56.16869}', NULL, NULL, 1, '12', '13', '{}');
INSERT INTO `fractionvehicles` VALUES (506, 13, 'armn007', 'freecrawler', '{\"x\":-1796.12976,\"y\":391.12146,\"z\":112.784691}', '{\"x\":0.0,\"y\":0.0,\"z\":101.395}', NULL, NULL, 1, '12', '13', '{}');
INSERT INTO `fractionvehicles` VALUES (507, 15, 'news01', 'rumpo', '{\"x\":-557.0485,\"y\":-937.7524,\"z\":23.8528461}', '{\"x\":0.0,\"y\":0.0,\"z\":271.788}', NULL, NULL, 1, '150', '150', '{}');
INSERT INTO `fractionvehicles` VALUES (508, 15, 'news02', 'rumpo', '{\"x\":-557.769043,\"y\":-933.330444,\"z\":23.8582325}', '{\"x\":0.0,\"y\":0.0,\"z\":271.189972}', NULL, NULL, 1, '150', '150', '{}');
INSERT INTO `fractionvehicles` VALUES (509, 15, 'news03', 'rumpo', '{\"x\":-557.328735,\"y\":-929.3448,\"z\":23.8599281}', '{\"x\":0.0,\"y\":0.0,\"z\":273.513977}', NULL, NULL, 1, '150', '150', '{}');
INSERT INTO `fractionvehicles` VALUES (510, 15, 'news04', 'rumpo', '{\"x\":-557.1263,\"y\":-925.1671,\"z\":24.38958}', '{\"x\":-0.0707163662,\"y\":-0.166396514,\"z\":272.2627}', NULL, NULL, 1, '30', '150', '{\"PrimColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"SecColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"PrimModColor\":-1,\"SecModColor\":-1,\"Muffler\":-1,\"SideSkirt\":-1,\"Hood\":-1,\"Spoiler\":-1,\"Lattice\":-1,\"Wings\":-1,\"Roof\":-1,\"Vinyls\":-1,\"FrontBumper\":-1,\"RearBumper\":-1,\"Engine\":-1,\"Turbo\":-1,\"Horn\":-1,\"Transmission\":-1,\"WindowTint\":0,\"Suspension\":-1,\"Brakes\":-1,\"Headlights\":-1,\"NumberPlate\":0,\"Wheels\":-1,\"WheelsType\":0,\"WheelsColor\":0,\"NeonColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":0},\"Armor\":-1}');
INSERT INTO `fractionvehicles` VALUES (511, 15, 'news05', 'rumpo', '{\"x\":-543.9273,\"y\":-889.0469,\"z\":25.1191883}', '{\"x\":0.0,\"y\":0.0,\"z\":181.893234}', NULL, NULL, 1, '150', '150', '{}');
INSERT INTO `fractionvehicles` VALUES (512, 15, 'news06', 'felon2', '{\"x\":-543.579834,\"y\":-915.9572,\"z\":24.0400124}', '{\"x\":0.0,\"y\":0.0,\"z\":60.00}', NULL, NULL, 1, '150', '150', '{}');
INSERT INTO `fractionvehicles` VALUES (513, 15, 'news07', 'felon2', '{\"x\":-541.6017,\"y\":-912.585144,\"z\":24.040081}', '{\"x\":0.0,\"y\":0.0,\"z\":60.00}', NULL, NULL, 1, '150', '150', '{}');
INSERT INTO `fractionvehicles` VALUES (514, 15, 'news08', 'felon2', '{\"x\":-539.5398,\"y\":-909.082458,\"z\":24.0396919}', '{\"x\":0.0,\"y\":0.0,\"z\":60.00}', NULL, NULL, 1, '150', '150', '{}');
INSERT INTO `fractionvehicles` VALUES (515, 15, 'news09', 'felon2', '{\"x\":-537.038,\"y\":-905.2604,\"z\":24.041914}', '{\"x\":0.0,\"y\":0.0,\"z\":60.00}', NULL, NULL, 1, '150', '150', '{}');
INSERT INTO `fractionvehicles` VALUES (516, 15, 'news10', 'faggio3', '{\"x\":-567.1367,\"y\":-902.128235,\"z\":23.9873581}', '{\"x\":0.0,\"y\":0.0,\"z\":270.765381}', NULL, NULL, 1, '150', '150', '{}');
INSERT INTO `fractionvehicles` VALUES (517, 15, 'news11', 'faggio3', '{\"x\":-567.4513,\"y\":-904.3514,\"z\":23.9146214}', '{\"x\":0.0,\"y\":0.0,\"z\":280.1582}', NULL, NULL, 1, '150', '150', '{}');
INSERT INTO `fractionvehicles` VALUES (518, 15, 'news12', 'maverick', '{\"x\":-583.6342,\"y\":-930.5051,\"z\":36.8333244}', '{\"x\":0.0,\"y\":0.0,\"z\":274.947144}', NULL, NULL, 1, '150', '150', '{}');
INSERT INTO `fractionvehicles` VALUES (519, 17, 'mws001', 'mesa3', '{\"x\":749.095154,\"y\":1301.9856,\"z\":360.56662}', '{\"x\":0.243812919,\"y\":-0.004237836,\"z\":179.0321}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (520, 17, 'mws002', 'mesa3', '{\"x\":745.5606,\"y\":1302.12061,\"z\":360.5667}', '{\"x\":0.246569425,\"y\":-0.007851777,\"z\":178.469055}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (521, 17, 'mws003', 'mesa3', '{\"x\":741.879333,\"y\":1302.11194,\"z\":360.566559}', '{\"x\":0.21481064,\"y\":-0.00308045442,\"z\":179.161621}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (522, 17, 'mws004', 'mesa3', '{\"x\":748.4424,\"y\":1277.84631,\"z\":360.56662}', '{\"x\":-0.08861413,\"y\":-0.004870967,\"z\":356.9263}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (523, 17, 'mws005', 'mesa3', '{\"x\":744.314148,\"y\":1277.9668,\"z\":360.56665}', '{\"x\":-0.23827678,\"y\":0.0164294653,\"z\":356.031}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (524, 17, 'mws006', 'baller6', '{\"x\":730.6622,\"y\":1298.12476,\"z\":360.7095}', '{\"x\":0.0168389753,\"y\":0.08510483,\"z\":266.952454}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (525, 17, 'mws007', 'baller6', '{\"x\":730.5428,\"y\":1294.28418,\"z\":360.708527}', '{\"x\":-0.04936464,\"y\":0.03884536,\"z\":267.343872}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (526, 17, 'mws008', 'baller6', '{\"x\":730.2249,\"y\":1290.47412,\"z\":360.708557}', '{\"x\":0.00508734537,\"y\":0.0567729734,\"z\":265.919556}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (527, 17, 'mws009', 'swift', '{\"x\":696.444153,\"y\":1282.45911,\"z\":360.295837}', '{\"x\":0.0,\"y\":0.0,\"z\":280.549164}', NULL, NULL, 1, '0', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (528, 16, 'lst001', 'zombieb', '{\"x\":963.693237,\"y\":-120.18763,\"z\":74.35306}', '{\"x\":0.0,\"y\":0.0,\"z\":224.002747}', NULL, NULL, 1, '153', '159', '{}');
INSERT INTO `fractionvehicles` VALUES (529, 16, 'lst002', 'zombieb', '{\"x\":964.8745,\"y\":-118.767769,\"z\":74.35313}', '{\"x\":0.0,\"y\":0.0,\"z\":225.763519}', NULL, NULL, 1, '153', '159', '{}');
INSERT INTO `fractionvehicles` VALUES (530, 16, 'lst003', 'zombieb', '{\"x\":966.196045,\"y\":-117.290886,\"z\":74.3531342}', '{\"x\":0.0,\"y\":0.0,\"z\":235.711884}', NULL, NULL, 1, '153', '159', '{}');
INSERT INTO `fractionvehicles` VALUES (531, 16, 'lst004', 'zombieb', '{\"x\":968.6089,\"y\":-115.134308,\"z\":74.35312}', '{\"x\":0.0,\"y\":0.0,\"z\":220.239548}', NULL, NULL, 1, '153', '159', '{}');
INSERT INTO `fractionvehicles` VALUES (532, 16, 'lst005', 'zombieb', '{\"x\":970.0626,\"y\":-113.615753,\"z\":74.35313}', '{\"x\":0.0,\"y\":0.0,\"z\":231.956833}', NULL, NULL, 1, '153', '159', '{}');
INSERT INTO `fractionvehicles` VALUES (533, 16, 'lst006', 'zombieb', '{\"x\":971.464966,\"y\":-111.897812,\"z\":74.35313}', '{\"x\":0.0,\"y\":0.0,\"z\":220.708267}', NULL, NULL, 1, '153', '159', '{}');
INSERT INTO `fractionvehicles` VALUES (534, 16, 'lst007', 'zombieb', '{\"x\":974.304932,\"y\":-113.357208,\"z\":74.35312}', '{\"x\":0.0,\"y\":0.0,\"z\":139.274872}', NULL, NULL, 1, '153', '159', '{}');
INSERT INTO `fractionvehicles` VALUES (535, 16, 'lst008', 'chimera', '{\"x\":970.225464,\"y\":-143.611938,\"z\":74.3497}', '{\"x\":0.0,\"y\":0.0,\"z\":325.567566}', NULL, NULL, 1, '153', '159', '{}');
INSERT INTO `fractionvehicles` VALUES (536, 16, 'lst009', 'chimera', '{\"x\":968.153,\"y\":-142.9781,\"z\":74.4096146}', '{\"x\":0.0,\"y\":0.0,\"z\":339.5104}', NULL, NULL, 1, '153', '159', '{}');
INSERT INTO `fractionvehicles` VALUES (537, 16, 'lst010', 'chimera', '{\"x\":966.437439,\"y\":-141.878113,\"z\":74.4566956}', '{\"x\":0.0,\"y\":0.0,\"z\":349.915039}', NULL, NULL, 1, '153', '159', '{}');
INSERT INTO `fractionvehicles` VALUES (538, 16, 'lst011', 'daemon', '{\"x\":952.7196,\"y\":-133.08551,\"z\":74.4579544}', '{\"x\":0.0,\"y\":0.0,\"z\":337.92218}', NULL, NULL, 1, '153', '159', '{}');
INSERT INTO `fractionvehicles` VALUES (539, 16, 'lst012', 'daemon', '{\"x\":953.5281,\"y\":-133.861115,\"z\":74.461174}', '{\"x\":0.0,\"y\":0.0,\"z\":322.9354}', NULL, NULL, 1, '153', '159', '{}');
INSERT INTO `fractionvehicles` VALUES (540, 16, 'lst013', 'daemon', '{\"x\":954.5854,\"y\":-134.777252,\"z\":74.46402}', '{\"x\":0.0,\"y\":0.0,\"z\":329.3086}', NULL, NULL, 1, '153', '159', '{}');
INSERT INTO `fractionvehicles` VALUES (541, 16, 'lst014', 'daemon', '{\"x\":955.792542,\"y\":-135.588913,\"z\":74.4647751}', '{\"x\":0.0,\"y\":0.0,\"z\":311.564484}', NULL, NULL, 1, '153', '159', '{}');
INSERT INTO `fractionvehicles` VALUES (542, 16, 'lst015', 'sovereign', '{\"x\":948.975952,\"y\":-123.597664,\"z\":74.36979}', '{\"x\":0.0,\"y\":0.0,\"z\":221.526627}', NULL, NULL, 1, '153', '158', '{}');
INSERT INTO `fractionvehicles` VALUES (543, 16, 'lst016', 'sovereign', '{\"x\":950.152649,\"y\":-122.073662,\"z\":74.35307}', '{\"x\":0.0,\"y\":0.0,\"z\":231.079514}', NULL, NULL, 1, '153', '158', '{}');
INSERT INTO `fractionvehicles` VALUES (544, 16, 'lst017', 'sovereign', '{\"x\":951.37616,\"y\":-120.55439,\"z\":74.35307}', '{\"x\":0.0,\"y\":0.0,\"z\":217.4599}', NULL, NULL, 1, '153', '158', '{}');
INSERT INTO `fractionvehicles` VALUES (545, 16, 'lst018', 'ratloader', '{\"x\":1010.90558,\"y\":-115.4023,\"z\":73.60785}', '{\"x\":-0.0213064812,\"y\":-1.03816783,\"z\":58.79605}', NULL, NULL, 1, '153', '158', '{}');
INSERT INTO `fractionvehicles` VALUES (546, 16, 'lst019', 'ratloader', '{\"x\":982.901,\"y\":-147.55658,\"z\":74.24047}', '{\"x\":0.0,\"y\":0.0,\"z\":55.0353737}', NULL, NULL, 1, '153', '158', '{}');
INSERT INTO `fractionvehicles` VALUES (547, 14, 'ussr01', 'crusader', '{\"x\":-2305.55957,\"y\":3277.67651,\"z\":32.8339233}', '{\"x\":0.127212435,\"y\":-0.09080506,\"z\":57.572937}', NULL, NULL, 1, '59', '128', '{}');
INSERT INTO `fractionvehicles` VALUES (548, 14, 'ussr02', 'crusader', '{\"x\":-2303.83057,\"y\":3280.73657,\"z\":32.8341255}', '{\"x\":0.126458675,\"y\":-0.09476417,\"z\":57.06732}', NULL, NULL, 1, '59', '128', '{}');
INSERT INTO `fractionvehicles` VALUES (549, 14, 'ussr03', 'crusader', '{\"x\":-2307.316,\"y\":3274.72437,\"z\":32.83411}', '{\"x\":0.123962931,\"y\":-0.09971731,\"z\":55.1713562}', NULL, NULL, 1, '59', '128', '{}');
INSERT INTO `fractionvehicles` VALUES (550, 14, 'ussr04', 'crusader', '{\"x\":-2309.10571,\"y\":3271.63916,\"z\":32.83451}', '{\"x\":0.152727365,\"y\":-0.101563521,\"z\":57.2301941}', NULL, NULL, 1, '59', '128', '{}');
INSERT INTO `fractionvehicles` VALUES (551, 14, 'ussr05', 'crusader', '{\"x\":-2310.58984,\"y\":3268.86865,\"z\":32.8349648}', '{\"x\":0.131477281,\"y\":-0.0976963639,\"z\":56.7662964}', NULL, NULL, 1, '59', '128', '{}');
INSERT INTO `fractionvehicles` VALUES (552, 14, 'ussr06', 'crusader', '{\"x\":-2312.03442,\"y\":3266.408,\"z\":32.8349533}', '{\"x\":-0.0165792443,\"y\":0.0160712022,\"z\":56.26834}', NULL, NULL, 1, '59', '128', '{}');
INSERT INTO `fractionvehicles` VALUES (553, 14, 'ussr07', 'crusader', '{\"x\":-2287.40356,\"y\":3324.903,\"z\":32.8341064}', '{\"x\":-0.134600937,\"y\":0.0766833648,\"z\":243.443909}', NULL, NULL, 1, '59', '158', '{}');
INSERT INTO `fractionvehicles` VALUES (554, 14, 'ussr08', 'crusader', '{\"x\":-2285.82227,\"y\":3327.83887,\"z\":32.8340874}', '{\"x\":-0.134223431,\"y\":0.07665489,\"z\":243.472641}', NULL, NULL, 1, '59', '158', '{}');
INSERT INTO `fractionvehicles` VALUES (555, 14, 'ussr09', 'crusader', '{\"x\":-2284.07,\"y\":3331.14,\"z\":32.8340836}', '{\"x\":-0.131471872,\"y\":0.07886958,\"z\":241.890808}', NULL, NULL, 1, '59', '158', '{}');
INSERT INTO `fractionvehicles` VALUES (556, 14, 'ussr10', 'crusader', '{\"x\":-2282.451,\"y\":3334.09277,\"z\":32.830925}', '{\"x\":0.0337237529,\"y\":0.0598958768,\"z\":242.196564}', NULL, NULL, 1, '59', '158', '{}');
INSERT INTO `fractionvehicles` VALUES (557, 14, 'ussr11', 'crusader', '{\"x\":-2280.87158,\"y\":3337.173,\"z\":32.8239059}', '{\"x\":-0.0327498466,\"y\":0.0615957677,\"z\":242.219}', NULL, NULL, 1, '59', '158', '{}');
INSERT INTO `fractionvehicles` VALUES (558, 14, 'ussr12', 'crusader', '{\"x\":-2279.28442,\"y\":3340.10376,\"z\":32.82264}', '{\"x\":-0.012388072,\"y\":0.0808081,\"z\":241.33548}', NULL, NULL, 1, '59', '158', '{}');
INSERT INTO `fractionvehicles` VALUES (562, 14, 'ussr16', 'barracks', '{\"x\":-2231.044,\"y\":3275.12671,\"z\":32.92962}', '{\"x\":-0.3679547,\"y\":-0.6554983,\"z\":241.465683}', NULL, NULL, 1, '59', '158', '{}');
INSERT INTO `fractionvehicles` VALUES (563, 14, 'ussr17', 'barracks', '{\"x\":-2233.40332,\"y\":3271.13916,\"z\":32.929306}', '{\"x\":-0.3672826,\"y\":-0.658600152,\"z\":241.499268}', NULL, NULL, 1, '59', '158', '{}');
INSERT INTO `fractionvehicles` VALUES (564, 14, 'ussr18', 'barracks', '{\"x\":-2235.367,\"y\":3267.05176,\"z\":32.9296379}', '{\"x\":-0.374527454,\"y\":-0.65016526,\"z\":240.567657}', NULL, NULL, 1, '59', '158', '{}');
INSERT INTO `fractionvehicles` VALUES (566, 14, 'ussr20', 'skylift', '{\"x\":-2057.43652,\"y\":3099.04663,\"z\":32.810318}', '{\"x\":0.0,\"y\":0.0,\"z\":331.0688}', NULL, NULL, 1, '59', '158', '{}');
INSERT INTO `fractionvehicles` VALUES (568, 14, 'ussr22', 'buzzard2', '{\"x\":-2188.0415,\"y\":3169.357,\"z\":32.8101463}', '{\"x\":0.0,\"y\":0.0,\"z\":328.401947}', NULL, NULL, 1, '59', '158', '{}');
INSERT INTO `fractionvehicles` VALUES (569, 14, 'ussr23', 'buzzard2', '{\"x\":-2333.96387,\"y\":3352.255,\"z\":32.8328056}', '{\"x\":0.0,\"y\":0.0,\"z\":230.744354}', NULL, NULL, 1, '59', '158', '{}');
INSERT INTO `fractionvehicles` VALUES (590, 7, 'LSPD01', 'police2', '{\"x\":408.39517,\"y\":-979.7635,\"z\":29.891113}', '{\"x\":0.029443776,\"y\":0.040546317,\"z\":51.571808}', 111, 0, 2, '131', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (591, 7, 'LSPD02', 'police2', '{\"x\":407.89975,\"y\":-984.31445,\"z\":29.88733}', '{\"x\":0.04633358,\"y\":-0.04913538,\"z\":52.528873}', 111, 0, 2, '131', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (592, 7, 'LSPD03', 'police', '{\"x\":407.64417,\"y\":-988.492,\"z\":29.88115}', '{\"x\":0.019017272,\"y\":0.048963446,\"z\":51.418396}', 111, 0, 1, '131', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (593, 7, 'LSPD04', 'police', '{\"x\":408.02292,\"y\":-993.1572,\"z\":29.881224}', '{\"x\":0.049935147,\"y\":-0.0029116608,\"z\":52.45105}', 111, 0, 1, '131', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (594, 7, 'LSPD05', 'police3', '{\"x\":407.8185,\"y\":-998.1308,\"z\":30.029554}', '{\"x\":0.059315212,\"y\":-0.0043415884,\"z\":48.97948}', 111, 0, 2, '131', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (595, 7, 'LSPD06', 'police4', '{\"x\":446.47784,\"y\":-1025.5865,\"z\":29.24446}', '{\"x\":-0.6297113,\"y\":1.0654908,\"z\":3.8705997}', 111, 0, 5, '131', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (596, 7, 'LSPD07', 'police4', '{\"x\":442.53436,\"y\":-1025.3594,\"z\":29.302256}', '{\"x\":-1.1853315,\"y\":1.099341,\"z\":3.884048}', 111, 0, 5, '131', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (597, 7, 'LSPD08', 'police4', '{\"x\":438.6375,\"y\":-1026.1902,\"z\":29.387547}', '{\"x\":-0.5960169,\"y\":1.0847474,\"z\":4.295057}', 111, 0, 5, '131', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (598, 7, 'LSPD09', 'police4', '{\"x\":426.1329,\"y\":-976.48566,\"z\":26.393974}', '{\"x\":0.120146595,\"y\":0.2563684,\"z\":-88.93168}', 111, 0, 5, '131', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (600, 7, 'LSPD11', 'trubuffals2', '{\"x\":425.8618,\"y\":-982.3111,\"z\":26.394035}', '{\"x\":0.15781999,\"y\":0.25508437,\"z\":-90.75371}', 111, 0, 9, '131', '0', '{}');
INSERT INTO `fractionvehicles` VALUES (601, 8, 'LSMC', 'emsnspeedo', '{\"x\":-428.2657,\"y\":-333.93015,\"z\":25.01391}', '{\"x\":0.057709113,\"y\":-0.041239638,\"z\":-158.63747}', 1, 1, 2, '1', '1', '{}');
INSERT INTO `fractionvehicles` VALUES (602, 8, 'LSMC1', 'emsnspeedo', '{\"x\":-432.40607,\"y\":-334.8802,\"z\":25.014547}', '{\"x\":-0.044841938,\"y\":0.007171206,\"z\":-159.37495}', 1, 1, 2, '1', '1', '{}');
INSERT INTO `fractionvehicles` VALUES (603, 8, 'LSMC2', 'emsnspeedo', '{\"x\":-436.4794,\"y\":-336.13443,\"z\":25.013903}', '{\"x\":-0.05094926,\"y\":0.045504242,\"z\":-156.00755}', 1, 1, 2, '1', '1', '{}');
INSERT INTO `fractionvehicles` VALUES (604, 8, 'LSMC3', 'emsnspeedo', '{\"x\":-440.47546,\"y\":-337.6149,\"z\":25.01303}', '{\"x\":0.07689102,\"y\":-0.027959486,\"z\":-158.64238}', 1, 1, 2, '1', '1', '{}');
INSERT INTO `fractionvehicles` VALUES (605, 8, 'LSMC4', 'emsnspeedo', '{\"x\":-444.09042,\"y\":-339.39084,\"z\":25.013683}', '{\"x\":0.08882164,\"y\":-0.030663766,\"z\":-159.22932}', 1, 1, 2, '1', '1', '{}');
INSERT INTO `fractionvehicles` VALUES (606, 8, 'LSMC5', 'emsnspeedo', '{\"x\":-447.97006,\"y\":-340.9683,\"z\":25.013784}', '{\"x\":-0.03747764,\"y\":-0.35279876,\"z\":-160.81223}', 1, 1, 2, '1', '1', '{}');
INSERT INTO `fractionvehicles` VALUES (607, 18, 'USMS01', 'hwaybuffals', '{\"x\":844.4882,\"y\":-1334.847,\"z\":26.767807}', '{\"x\":0.46876547,\"y\":0.77999705,\"z\":-113.048256}', 1, 1, 1, '1', '1', '{}');
INSERT INTO `fractionvehicles` VALUES (608, 18, 'USMS02', 'hwaybuffals', '{\"x\":844.66644,\"y\":-1340.6688,\"z\":26.732521}', '{\"x\":0.79536545,\"y\":0.21471989,\"z\":-115.59227}', 1, 1, 1, '1', '1', '{}');
INSERT INTO `fractionvehicles` VALUES (609, 18, 'USMS03', 'hwaybuffals', '{\"x\":844.45593,\"y\":-1346.5631,\"z\":26.740618}', '{\"x\":0.64192367,\"y\":0.23555112,\"z\":-113.415924}', 1, 1, 1, '1', '1', '{}');
INSERT INTO `fractionvehicles` VALUES (610, 18, 'xk2101', 'xls2poli', '{\"x\":833.99713,\"y\":-1413.9824,\"z\":27.06734}', '{\"x\":-0.11095049,\"y\":0.2563453,\"z\":-28.497725}', 1, 1, 1, '1', '1', '{}');
INSERT INTO `fractionvehicles` VALUES (611, 18, 'xs9801', 'xls2poli', '{\"x\":827.9026,\"y\":-1414.0388,\"z\":27.072922}', '{\"x\":0.02537356,\"y\":-0.002449666,\"z\":-28.066616}', 1, 1, 1, '1', '1', '{}');
INSERT INTO `fractionvehicles` VALUES (612, 8, 'EMS06', 'lspdcara', '{\"x\":-431.56305,\"y\":-350.4905,\"z\":24.85984}', '{\"x\":1.8008915,\"y\":0.031965073,\"z\":19.553844}', 1, 1, 2, '1', '1', '{}');
INSERT INTO `fractionvehicles` VALUES (613, 8, 'EMS07', 'lspdcara', '{\"x\":-439.1443,\"y\":-352.85553,\"z\":24.3646}', '{\"x\":1.6761576,\"y\":-0.010727343,\"z\":20.269344}', 1, 1, 2, '1', '1', '{\"PrimColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"SecColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"NeonColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":0},\"PrimModColor\":-1,\"SecModColor\":-1,\"Muffler\":-1,\"SideSkirt\":-1,\"Hood\":-1,\"Spoiler\":-1,\"Lattice\":-1,\"Wings\":-1,\"Roof\":-1,\"Vinyls\":-1,\"FrontBumper\":-1,\"RearBumper\":-1,\"Engine\":-1,\"Turbo\":-1,\"Horn\":-1,\"Transmission\":-1,\"WindowTint\":0,\"Suspension\":-1,\"Brakes\":-1,\"Headlights\":-1,\"HeadlightColor\":0,\"NumberPlate\":0,\"Wheels\":-1,\"WheelsType\":0,\"WheelsColor\":0,\"Armor\":-1}');
INSERT INTO `fractionvehicles` VALUES (614, 7, 'OverW', 'polmav', '{\"x\":-725.4648,\"y\":-1444.5697,\"z\":6.389532}', '{\"x\":0.15666981,\"y\":-0.0072330823,\"z\":140.09612}', 131, 131, 3, '1', '1', '{}');
INSERT INTO `fractionvehicles` VALUES (615, 18, 'USMS04', 'hwaybuffals', '{\"x\":844.34863,\"y\":-1352.6228,\"z\":26.75026}', '{\"x\":0.36103144,\"y\":0.22192588,\"z\":-112.79282}', 131, 131, 2, '1', '1', '{}');
INSERT INTO `fractionvehicles` VALUES (616, 18, 'USMS05', 'hwaybuffals', '{\"x\":827.61707,\"y\":-1333.7642,\"z\":26.774052}', '{\"x\":0.0760962,\"y\":0.15528776,\"z\":63.841175}', 131, 131, 2, '1', '1', '{}');
INSERT INTO `fractionvehicles` VALUES (617, 18, 'USMS06', 'hwaybuffals', '{\"x\":828.39594,\"y\":-1339.1903,\"z\":26.759981}', '{\"x\":0.2934177,\"y\":0.20934066,\"z\":63.74569}', 131, 131, 2, '1', '1', '{}');
INSERT INTO `fractionvehicles` VALUES (618, 18, 'USMS07', 'hwaybuffals', '{\"x\":828.32794,\"y\":-1345.2605,\"z\":26.7591}', '{\"x\":0.1998474,\"y\":0.3089079,\"z\":62.79382}', 131, 131, 2, '1', '1', '{}');
INSERT INTO `fractionvehicles` VALUES (619, 18, 'USMS08', 'hwaybuffals', '{\"x\":827.9913,\"y\":-1351.1497,\"z\":26.762121}', '{\"x\":0.22638242,\"y\":0.3203398,\"z\":66.90791}', 131, 131, 2, '1', '1', '{}');
INSERT INTO `fractionvehicles` VALUES (620, 18, 'dshshjs', 'tor_fib_armor1', '{\"x\":852.07605,\"y\":-1404.9299,\"z\":27.037218}', '{\"x\":-0.096662834,\"y\":-0.013450209,\"z\":34.10564}', 22, 22, 2, '1', '1', '{}');
INSERT INTO `fractionvehicles` VALUES (621, 18, 'fdjsfijd', 'tor_fib_armor1', '{\"x\":854.12494,\"y\":-1399.103,\"z\":27.042902}', '{\"x\":-0.2229054,\"y\":-0.06781639,\"z\":37.550667}', 22, 22, 2, '1', '1', '{}');
INSERT INTO `fractionvehicles` VALUES (622, 18, 'fjdshjfl', 'tor_fib_armor1', '{\"x\":857.199,\"y\":-1393.7701,\"z\":27.055483}', '{\"x\":-0.299608,\"y\":-0.12467898,\"z\":39.10054}', 22, 22, 2, '1', '1', '{}');
INSERT INTO `fractionvehicles` VALUES (623, 18, 'dhasjhds', 'tor_fib_gresley', '{\"x\":817.91815,\"y\":-1356.3109,\"z\":27.061016}', '{\"x\":-0.024778146,\"y\":0.0175749,\"z\":-179.66463}', 22, 22, 6, '1', '1', '{}');
INSERT INTO `fractionvehicles` VALUES (624, 18, 'lfkjhjhe', 'tor_fib_gresley', '{\"x\":818.33435,\"y\":-1348.9769,\"z\":27.062286}', '{\"x\":-0.15769084,\"y\":-0.11015398,\"z\":178.54347}', 22, 22, 6, '1', '1', '{}');
INSERT INTO `fractionvehicles` VALUES (625, 18, '187', 'tor_fib_speedo', '{\"x\":818.20245,\"y\":-1341.5496,\"z\":26.860163}', '{\"x\":0.02272078,\"y\":0.066937074,\"z\":179.57617}', 22, 22, 2, '1', '1', '{}');
INSERT INTO `fractionvehicles` VALUES (626, 18, 'S20030', 'tor_fib_novak', '{\"x\":866.1629,\"y\":-1378.5704,\"z\":26.59395}', '{\"x\":-0.048948612,\"y\":-1.3620398,\"z\":38.78819}', 22, 22, 13, '1', '1', '{}');
INSERT INTO `fractionvehicles` VALUES (627, 18, 'S20031', 'tor_fib_novak', '{\"x\":862.70496,\"y\":-1383.0607,\"z\":26.596405}', '{\"x\":-0.56002384,\"y\":-0.5033767,\"z\":37.673393}', 22, 22, 13, '1', '1', '{}');
INSERT INTO `fractionvehicles` VALUES (628, 18, 'PBUSMS', 'pbus', '{\"x\":832.46094,\"y\":-1401.7969,\"z\":27.41045}', '{\"x\":-0.0768621,\"y\":0.08135334,\"z\":-91.50232}', 1, 1, 2, '1', '1', '{}');
INSERT INTO `fractionvehicles` VALUES (629, 7, 'LSPDT', 'pigeonp', '{\"x\":441.9348,\"y\":-979.2827,\"z\":26.136515}', '{\"x\":-0.8278005,\"y\":0.13222758,\"z\":91.352806}', 131, 131, 1, '131', '131', '{}');
INSERT INTO `fractionvehicles` VALUES (630, 7, 'LSPDT2', 'pigeonp', '{\"x\":441.70685,\"y\":-982.14105,\"z\":26.136961}', '{\"x\":-0.7335421,\"y\":0.102650724,\"z\":90.26026}', 131, 131, 1, '131', '131', '{}');

-- ----------------------------
-- Table structure for furniture
-- ----------------------------
DROP TABLE IF EXISTS `furniture`;
CREATE TABLE `furniture`  (
  `uuid` int NOT NULL,
  `furniture` varchar(4096) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `data` varchar(4096) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`uuid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of furniture
-- ----------------------------
INSERT INTO `furniture` VALUES (0, '{}', '{}');
INSERT INTO `furniture` VALUES (1, '{}', '{}');
INSERT INTO `furniture` VALUES (2, '{}', '{}');
INSERT INTO `furniture` VALUES (3, '{}', '{}');
INSERT INTO `furniture` VALUES (4, '{}', '{}');
INSERT INTO `furniture` VALUES (5, '{}', '{}');
INSERT INTO `furniture` VALUES (6, '{}', '{}');
INSERT INTO `furniture` VALUES (7, '{}', '{}');
INSERT INTO `furniture` VALUES (8, '{}', '{}');
INSERT INTO `furniture` VALUES (9, '{}', '{}');
INSERT INTO `furniture` VALUES (10, '{}', '{}');
INSERT INTO `furniture` VALUES (11, '{}', '{}');
INSERT INTO `furniture` VALUES (12, '{}', '{}');
INSERT INTO `furniture` VALUES (13, '{}', '{}');
INSERT INTO `furniture` VALUES (14, '{}', '{}');
INSERT INTO `furniture` VALUES (15, '{}', '{}');
INSERT INTO `furniture` VALUES (16, '{}', '{}');
INSERT INTO `furniture` VALUES (17, '{}', '{}');
INSERT INTO `furniture` VALUES (18, '{}', '{}');
INSERT INTO `furniture` VALUES (19, '{}', '{}');
INSERT INTO `furniture` VALUES (20, '{}', '{}');
INSERT INTO `furniture` VALUES (21, '{}', '{}');
INSERT INTO `furniture` VALUES (22, '{}', '{}');
INSERT INTO `furniture` VALUES (23, '{}', '{}');
INSERT INTO `furniture` VALUES (24, '{}', '{}');
INSERT INTO `furniture` VALUES (25, '{}', '{}');
INSERT INTO `furniture` VALUES (26, '{}', '{}');
INSERT INTO `furniture` VALUES (27, '{}', '{}');
INSERT INTO `furniture` VALUES (28, '{}', '{}');
INSERT INTO `furniture` VALUES (29, '{}', '{}');
INSERT INTO `furniture` VALUES (30, '{}', '{}');
INSERT INTO `furniture` VALUES (31, '{}', '{}');
INSERT INTO `furniture` VALUES (32, '{}', '{}');
INSERT INTO `furniture` VALUES (33, '{}', '{}');
INSERT INTO `furniture` VALUES (34, '{}', '{}');
INSERT INTO `furniture` VALUES (35, '{}', '{}');
INSERT INTO `furniture` VALUES (36, '{}', '{}');
INSERT INTO `furniture` VALUES (37, '{}', '{}');
INSERT INTO `furniture` VALUES (38, '{}', '{}');
INSERT INTO `furniture` VALUES (39, '{}', '{}');
INSERT INTO `furniture` VALUES (40, '{}', '{}');
INSERT INTO `furniture` VALUES (41, '{}', '{}');
INSERT INTO `furniture` VALUES (42, '{}', '{}');
INSERT INTO `furniture` VALUES (43, '{}', '{}');
INSERT INTO `furniture` VALUES (44, '{}', '{}');
INSERT INTO `furniture` VALUES (45, '{}', '{}');
INSERT INTO `furniture` VALUES (46, '{}', '{}');
INSERT INTO `furniture` VALUES (47, '{}', '{}');
INSERT INTO `furniture` VALUES (48, '{}', '{}');
INSERT INTO `furniture` VALUES (49, '{}', '{}');
INSERT INTO `furniture` VALUES (50, '{}', '{}');
INSERT INTO `furniture` VALUES (51, '{}', '{}');
INSERT INTO `furniture` VALUES (52, '{}', '{}');
INSERT INTO `furniture` VALUES (53, '{}', '{}');
INSERT INTO `furniture` VALUES (54, '{}', '{}');
INSERT INTO `furniture` VALUES (55, '{}', '{}');
INSERT INTO `furniture` VALUES (56, '{}', '{}');
INSERT INTO `furniture` VALUES (57, '{}', '{}');
INSERT INTO `furniture` VALUES (58, '{}', '{}');
INSERT INTO `furniture` VALUES (59, '{}', '{}');
INSERT INTO `furniture` VALUES (60, '{}', '{}');
INSERT INTO `furniture` VALUES (61, '{}', '{}');
INSERT INTO `furniture` VALUES (62, '{}', '{}');
INSERT INTO `furniture` VALUES (63, '{}', '{}');
INSERT INTO `furniture` VALUES (64, '{}', '{}');
INSERT INTO `furniture` VALUES (65, '{}', '{}');
INSERT INTO `furniture` VALUES (66, '{}', '{}');
INSERT INTO `furniture` VALUES (67, '{}', '{}');
INSERT INTO `furniture` VALUES (68, '{}', '{}');
INSERT INTO `furniture` VALUES (69, '{}', '{}');
INSERT INTO `furniture` VALUES (70, '{}', '{}');
INSERT INTO `furniture` VALUES (71, '{}', '{}');
INSERT INTO `furniture` VALUES (72, '{}', '{}');
INSERT INTO `furniture` VALUES (73, '{}', '{}');
INSERT INTO `furniture` VALUES (74, '{}', '{}');
INSERT INTO `furniture` VALUES (75, '{}', '{}');
INSERT INTO `furniture` VALUES (76, '{}', '{}');
INSERT INTO `furniture` VALUES (77, '{}', '{}');
INSERT INTO `furniture` VALUES (78, '{}', '{}');
INSERT INTO `furniture` VALUES (79, '{}', '{}');
INSERT INTO `furniture` VALUES (80, '{}', '{}');
INSERT INTO `furniture` VALUES (81, '{}', '{}');
INSERT INTO `furniture` VALUES (82, '{}', '{}');
INSERT INTO `furniture` VALUES (83, '{}', '{}');
INSERT INTO `furniture` VALUES (84, '{}', '{}');
INSERT INTO `furniture` VALUES (85, '{}', '{}');
INSERT INTO `furniture` VALUES (86, '{}', '{}');
INSERT INTO `furniture` VALUES (87, '{}', '{}');
INSERT INTO `furniture` VALUES (88, '{}', '{}');
INSERT INTO `furniture` VALUES (89, '{}', '{}');
INSERT INTO `furniture` VALUES (90, '{}', '{}');
INSERT INTO `furniture` VALUES (91, '{}', '{}');
INSERT INTO `furniture` VALUES (92, '{}', '{}');
INSERT INTO `furniture` VALUES (93, '{}', '{}');
INSERT INTO `furniture` VALUES (94, '{}', '{}');
INSERT INTO `furniture` VALUES (95, '{}', '{}');
INSERT INTO `furniture` VALUES (96, '{}', '{}');
INSERT INTO `furniture` VALUES (97, '{}', '{}');
INSERT INTO `furniture` VALUES (98, '{}', '{}');
INSERT INTO `furniture` VALUES (99, '{}', '{}');
INSERT INTO `furniture` VALUES (100, '{}', '{}');
INSERT INTO `furniture` VALUES (101, '{}', '{}');
INSERT INTO `furniture` VALUES (102, '{}', '{}');
INSERT INTO `furniture` VALUES (103, '{}', '{}');
INSERT INTO `furniture` VALUES (104, '{}', '{}');
INSERT INTO `furniture` VALUES (105, '{}', '{}');
INSERT INTO `furniture` VALUES (106, '{}', '{}');
INSERT INTO `furniture` VALUES (107, '{}', '{}');
INSERT INTO `furniture` VALUES (108, '{}', '{}');
INSERT INTO `furniture` VALUES (109, '{}', '{}');
INSERT INTO `furniture` VALUES (110, '{}', '{}');
INSERT INTO `furniture` VALUES (111, '{}', '{}');
INSERT INTO `furniture` VALUES (112, '{}', '{}');
INSERT INTO `furniture` VALUES (113, '{}', '{}');
INSERT INTO `furniture` VALUES (114, '{}', '{}');
INSERT INTO `furniture` VALUES (115, '{}', '{}');
INSERT INTO `furniture` VALUES (116, '{}', '{}');
INSERT INTO `furniture` VALUES (117, '{}', '{}');
INSERT INTO `furniture` VALUES (118, '{}', '{}');
INSERT INTO `furniture` VALUES (119, '{}', '{}');
INSERT INTO `furniture` VALUES (120, '{}', '{}');
INSERT INTO `furniture` VALUES (121, '{}', '{}');
INSERT INTO `furniture` VALUES (122, '{}', '{}');
INSERT INTO `furniture` VALUES (123, '{}', '{}');
INSERT INTO `furniture` VALUES (124, '{}', '{}');
INSERT INTO `furniture` VALUES (125, '{}', '{}');
INSERT INTO `furniture` VALUES (126, '{}', '{}');
INSERT INTO `furniture` VALUES (127, '{}', '{}');
INSERT INTO `furniture` VALUES (128, '{}', '{}');
INSERT INTO `furniture` VALUES (129, '{}', '{}');
INSERT INTO `furniture` VALUES (130, '{}', '{}');
INSERT INTO `furniture` VALUES (131, '{}', '{}');
INSERT INTO `furniture` VALUES (132, '{}', '{}');
INSERT INTO `furniture` VALUES (133, '{}', '{}');
INSERT INTO `furniture` VALUES (134, '{}', '{}');
INSERT INTO `furniture` VALUES (135, '{}', '{}');
INSERT INTO `furniture` VALUES (136, '{}', '{}');
INSERT INTO `furniture` VALUES (137, '{}', '{}');
INSERT INTO `furniture` VALUES (138, '{}', '{}');
INSERT INTO `furniture` VALUES (139, '{}', '{}');
INSERT INTO `furniture` VALUES (140, '{}', '{}');
INSERT INTO `furniture` VALUES (141, '{}', '{}');
INSERT INTO `furniture` VALUES (142, '{}', '{}');
INSERT INTO `furniture` VALUES (143, '{}', '{}');
INSERT INTO `furniture` VALUES (144, '{}', '{}');
INSERT INTO `furniture` VALUES (145, '{}', '{}');
INSERT INTO `furniture` VALUES (146, '{}', '{}');
INSERT INTO `furniture` VALUES (147, '{}', '{}');
INSERT INTO `furniture` VALUES (148, '{}', '{}');
INSERT INTO `furniture` VALUES (149, '{}', '{}');
INSERT INTO `furniture` VALUES (150, '{}', '{}');
INSERT INTO `furniture` VALUES (151, '{}', '{}');
INSERT INTO `furniture` VALUES (152, '{}', '{}');
INSERT INTO `furniture` VALUES (153, '{}', '{}');
INSERT INTO `furniture` VALUES (154, '{}', '{}');
INSERT INTO `furniture` VALUES (155, '{}', '{}');
INSERT INTO `furniture` VALUES (156, '{}', '{}');
INSERT INTO `furniture` VALUES (157, '{}', '{}');
INSERT INTO `furniture` VALUES (158, '{}', '{}');
INSERT INTO `furniture` VALUES (159, '{}', '{}');
INSERT INTO `furniture` VALUES (160, '{}', '{}');
INSERT INTO `furniture` VALUES (161, '{}', '{}');
INSERT INTO `furniture` VALUES (162, '{}', '{}');
INSERT INTO `furniture` VALUES (163, '{}', '{}');
INSERT INTO `furniture` VALUES (164, '{}', '{}');
INSERT INTO `furniture` VALUES (165, '{}', '{}');
INSERT INTO `furniture` VALUES (166, '{}', '{}');
INSERT INTO `furniture` VALUES (167, '{}', '{}');
INSERT INTO `furniture` VALUES (168, '{}', '{}');
INSERT INTO `furniture` VALUES (169, '{}', '{}');
INSERT INTO `furniture` VALUES (170, '{}', '{}');
INSERT INTO `furniture` VALUES (171, '{}', '{}');
INSERT INTO `furniture` VALUES (172, '{}', '{}');
INSERT INTO `furniture` VALUES (173, '{}', '{}');
INSERT INTO `furniture` VALUES (174, '{}', '{}');
INSERT INTO `furniture` VALUES (175, '{}', '{}');
INSERT INTO `furniture` VALUES (176, '{}', '{}');
INSERT INTO `furniture` VALUES (177, '{}', '{}');
INSERT INTO `furniture` VALUES (178, '{}', '{}');
INSERT INTO `furniture` VALUES (179, '{}', '{}');
INSERT INTO `furniture` VALUES (180, '{}', '{}');
INSERT INTO `furniture` VALUES (181, '{}', '{}');
INSERT INTO `furniture` VALUES (182, '{}', '{}');
INSERT INTO `furniture` VALUES (183, '{}', '{}');
INSERT INTO `furniture` VALUES (184, '{}', '{}');
INSERT INTO `furniture` VALUES (185, '{}', '{}');
INSERT INTO `furniture` VALUES (186, '{}', '{}');
INSERT INTO `furniture` VALUES (187, '{}', '{}');
INSERT INTO `furniture` VALUES (188, '{}', '{}');
INSERT INTO `furniture` VALUES (189, '{}', '{}');
INSERT INTO `furniture` VALUES (190, '{}', '{}');
INSERT INTO `furniture` VALUES (191, '{}', '{}');
INSERT INTO `furniture` VALUES (192, '{}', '{}');
INSERT INTO `furniture` VALUES (193, '{}', '{}');
INSERT INTO `furniture` VALUES (194, '{}', '{}');
INSERT INTO `furniture` VALUES (195, '{}', '{}');
INSERT INTO `furniture` VALUES (196, '{}', '{}');
INSERT INTO `furniture` VALUES (197, '{\"0\":{\"Name\":\"Waffentresor\",\"Model\":\"prop_ld_int_safe_01\",\"ID\":0,\"Position\":null,\"Rotation\":null,\"IsSet\":false},\"1\":{\"Name\":\"Waffentresor\",\"Model\":\"prop_ld_int_safe_01\",\"ID\":1,\"Position\":null,\"Rotation\":null,\"IsSet\":false}}', '{\"0\":[],\"1\":[]}');
INSERT INTO `furniture` VALUES (198, '{}', '{}');
INSERT INTO `furniture` VALUES (199, '{}', '{}');
INSERT INTO `furniture` VALUES (200, '{}', '{}');
INSERT INTO `furniture` VALUES (201, '{}', '{}');
INSERT INTO `furniture` VALUES (202, '{}', '{}');
INSERT INTO `furniture` VALUES (203, '{}', '{}');
INSERT INTO `furniture` VALUES (204, '{}', '{}');
INSERT INTO `furniture` VALUES (205, '{}', '{}');
INSERT INTO `furniture` VALUES (206, '{}', '{}');
INSERT INTO `furniture` VALUES (207, '{}', '{}');
INSERT INTO `furniture` VALUES (208, '{}', '{}');
INSERT INTO `furniture` VALUES (209, '{}', '{}');
INSERT INTO `furniture` VALUES (210, '{}', '{}');
INSERT INTO `furniture` VALUES (211, '{}', '{}');
INSERT INTO `furniture` VALUES (212, '{}', '{}');
INSERT INTO `furniture` VALUES (213, '{}', '{}');
INSERT INTO `furniture` VALUES (214, '{}', '{}');
INSERT INTO `furniture` VALUES (215, '{}', '{}');
INSERT INTO `furniture` VALUES (216, '{}', '{}');
INSERT INTO `furniture` VALUES (217, '{}', '{}');
INSERT INTO `furniture` VALUES (218, '{}', '{}');
INSERT INTO `furniture` VALUES (219, '{}', '{}');
INSERT INTO `furniture` VALUES (220, '{}', '{}');
INSERT INTO `furniture` VALUES (221, '{}', '{}');
INSERT INTO `furniture` VALUES (222, '{}', '{}');
INSERT INTO `furniture` VALUES (223, '{}', '{}');
INSERT INTO `furniture` VALUES (224, '{}', '{}');
INSERT INTO `furniture` VALUES (225, '{}', '{}');
INSERT INTO `furniture` VALUES (226, '{}', '{}');
INSERT INTO `furniture` VALUES (227, '{}', '{}');
INSERT INTO `furniture` VALUES (228, '{}', '{}');
INSERT INTO `furniture` VALUES (229, '{}', '{}');
INSERT INTO `furniture` VALUES (230, '{}', '{}');
INSERT INTO `furniture` VALUES (231, '{}', '{}');
INSERT INTO `furniture` VALUES (232, '{}', '{}');
INSERT INTO `furniture` VALUES (233, '{}', '{}');
INSERT INTO `furniture` VALUES (234, '{}', '{}');
INSERT INTO `furniture` VALUES (235, '{}', '{}');
INSERT INTO `furniture` VALUES (236, '{}', '{}');
INSERT INTO `furniture` VALUES (237, '{}', '{}');
INSERT INTO `furniture` VALUES (238, '{}', '{}');
INSERT INTO `furniture` VALUES (239, '{}', '{}');
INSERT INTO `furniture` VALUES (240, '{}', '{}');
INSERT INTO `furniture` VALUES (241, '{}', '{}');
INSERT INTO `furniture` VALUES (242, '{}', '{}');
INSERT INTO `furniture` VALUES (243, '{}', '{}');
INSERT INTO `furniture` VALUES (244, '{}', '{}');
INSERT INTO `furniture` VALUES (245, '{}', '{}');
INSERT INTO `furniture` VALUES (246, '{}', '{}');
INSERT INTO `furniture` VALUES (247, '{}', '{}');
INSERT INTO `furniture` VALUES (248, '{}', '{}');
INSERT INTO `furniture` VALUES (249, '{}', '{}');
INSERT INTO `furniture` VALUES (250, '{}', '{}');
INSERT INTO `furniture` VALUES (251, '{}', '{}');
INSERT INTO `furniture` VALUES (252, '{}', '{}');
INSERT INTO `furniture` VALUES (253, '{}', '{}');
INSERT INTO `furniture` VALUES (254, '{}', '{}');
INSERT INTO `furniture` VALUES (255, '{}', '{}');
INSERT INTO `furniture` VALUES (256, '{}', '{}');
INSERT INTO `furniture` VALUES (257, '{}', '{}');
INSERT INTO `furniture` VALUES (258, '{}', '{}');
INSERT INTO `furniture` VALUES (259, '{}', '{}');
INSERT INTO `furniture` VALUES (260, '{}', '{}');
INSERT INTO `furniture` VALUES (261, '{}', '{}');
INSERT INTO `furniture` VALUES (262, '{}', '{}');
INSERT INTO `furniture` VALUES (263, '{}', '{}');
INSERT INTO `furniture` VALUES (264, '{}', '{}');
INSERT INTO `furniture` VALUES (265, '{}', '{}');
INSERT INTO `furniture` VALUES (266, '{}', '{}');
INSERT INTO `furniture` VALUES (267, '{}', '{}');
INSERT INTO `furniture` VALUES (268, '{}', '{}');
INSERT INTO `furniture` VALUES (269, '{}', '{}');
INSERT INTO `furniture` VALUES (270, '{}', '{}');
INSERT INTO `furniture` VALUES (271, '{}', '{}');
INSERT INTO `furniture` VALUES (272, '{}', '{}');
INSERT INTO `furniture` VALUES (273, '{}', '{}');
INSERT INTO `furniture` VALUES (274, '{}', '{}');
INSERT INTO `furniture` VALUES (275, '{}', '{}');
INSERT INTO `furniture` VALUES (276, '{}', '{}');
INSERT INTO `furniture` VALUES (277, '{}', '{}');
INSERT INTO `furniture` VALUES (278, '{}', '{}');
INSERT INTO `furniture` VALUES (279, '{}', '{}');
INSERT INTO `furniture` VALUES (280, '{}', '{}');
INSERT INTO `furniture` VALUES (281, '{}', '{}');
INSERT INTO `furniture` VALUES (282, '{}', '{}');
INSERT INTO `furniture` VALUES (283, '{}', '{}');
INSERT INTO `furniture` VALUES (284, '{}', '{}');
INSERT INTO `furniture` VALUES (285, '{}', '{}');
INSERT INTO `furniture` VALUES (286, '{}', '{}');
INSERT INTO `furniture` VALUES (287, '{}', '{}');
INSERT INTO `furniture` VALUES (288, '{}', '{}');
INSERT INTO `furniture` VALUES (289, '{}', '{}');
INSERT INTO `furniture` VALUES (290, '{}', '{}');
INSERT INTO `furniture` VALUES (291, '{}', '{}');
INSERT INTO `furniture` VALUES (292, '{}', '{}');
INSERT INTO `furniture` VALUES (293, '{}', '{}');
INSERT INTO `furniture` VALUES (294, '{}', '{}');
INSERT INTO `furniture` VALUES (295, '{}', '{}');
INSERT INTO `furniture` VALUES (296, '{}', '{}');
INSERT INTO `furniture` VALUES (297, '{}', '{}');
INSERT INTO `furniture` VALUES (298, '{}', '{}');
INSERT INTO `furniture` VALUES (299, '{}', '{}');
INSERT INTO `furniture` VALUES (300, '{}', '{}');
INSERT INTO `furniture` VALUES (301, '{}', '{}');
INSERT INTO `furniture` VALUES (302, '{}', '{}');
INSERT INTO `furniture` VALUES (303, '{}', '{}');
INSERT INTO `furniture` VALUES (304, '{}', '{}');
INSERT INTO `furniture` VALUES (305, '{}', '{}');
INSERT INTO `furniture` VALUES (306, '{}', '{}');
INSERT INTO `furniture` VALUES (307, '{}', '{}');
INSERT INTO `furniture` VALUES (308, '{}', '{}');
INSERT INTO `furniture` VALUES (309, '{}', '{}');
INSERT INTO `furniture` VALUES (310, '{}', '{}');
INSERT INTO `furniture` VALUES (311, '{}', '{}');
INSERT INTO `furniture` VALUES (312, '{}', '{}');
INSERT INTO `furniture` VALUES (313, '{}', '{}');
INSERT INTO `furniture` VALUES (314, '{}', '{}');
INSERT INTO `furniture` VALUES (315, '{}', '{}');
INSERT INTO `furniture` VALUES (316, '{}', '{}');
INSERT INTO `furniture` VALUES (317, '{}', '{}');
INSERT INTO `furniture` VALUES (318, '{}', '{}');
INSERT INTO `furniture` VALUES (319, '{}', '{}');
INSERT INTO `furniture` VALUES (320, '{}', '{}');
INSERT INTO `furniture` VALUES (321, '{}', '{}');
INSERT INTO `furniture` VALUES (322, '{}', '{}');
INSERT INTO `furniture` VALUES (323, '{}', '{}');
INSERT INTO `furniture` VALUES (324, '{}', '{}');
INSERT INTO `furniture` VALUES (325, '{}', '{}');
INSERT INTO `furniture` VALUES (326, '{}', '{}');
INSERT INTO `furniture` VALUES (327, '{}', '{}');
INSERT INTO `furniture` VALUES (328, '{}', '{}');
INSERT INTO `furniture` VALUES (329, '{}', '{}');
INSERT INTO `furniture` VALUES (330, '{}', '{}');
INSERT INTO `furniture` VALUES (331, '{}', '{}');
INSERT INTO `furniture` VALUES (332, '{}', '{}');
INSERT INTO `furniture` VALUES (333, '{}', '{}');
INSERT INTO `furniture` VALUES (334, '{}', '{}');
INSERT INTO `furniture` VALUES (335, '{}', '{}');
INSERT INTO `furniture` VALUES (336, '{}', '{}');
INSERT INTO `furniture` VALUES (337, '{}', '{}');
INSERT INTO `furniture` VALUES (338, '{}', '{}');
INSERT INTO `furniture` VALUES (339, '{}', '{}');
INSERT INTO `furniture` VALUES (340, '{}', '{}');
INSERT INTO `furniture` VALUES (341, '{}', '{}');
INSERT INTO `furniture` VALUES (342, '{}', '{}');
INSERT INTO `furniture` VALUES (343, '{}', '{}');
INSERT INTO `furniture` VALUES (344, '{}', '{}');
INSERT INTO `furniture` VALUES (345, '{}', '{}');
INSERT INTO `furniture` VALUES (346, '{}', '{}');
INSERT INTO `furniture` VALUES (347, '{}', '{}');
INSERT INTO `furniture` VALUES (348, '{}', '{}');
INSERT INTO `furniture` VALUES (349, '{}', '{}');
INSERT INTO `furniture` VALUES (350, '{}', '{}');
INSERT INTO `furniture` VALUES (351, '{}', '{}');
INSERT INTO `furniture` VALUES (352, '{}', '{}');
INSERT INTO `furniture` VALUES (353, '{}', '{}');
INSERT INTO `furniture` VALUES (354, '{}', '{}');
INSERT INTO `furniture` VALUES (355, '{}', '{}');
INSERT INTO `furniture` VALUES (356, '{}', '{}');
INSERT INTO `furniture` VALUES (357, '{}', '{}');
INSERT INTO `furniture` VALUES (358, '{}', '{}');
INSERT INTO `furniture` VALUES (359, '{}', '{}');
INSERT INTO `furniture` VALUES (360, '{}', '{}');
INSERT INTO `furniture` VALUES (361, '{}', '{}');
INSERT INTO `furniture` VALUES (362, '{}', '{}');
INSERT INTO `furniture` VALUES (363, '{}', '{}');
INSERT INTO `furniture` VALUES (364, '{}', '{}');
INSERT INTO `furniture` VALUES (365, '{}', '{}');
INSERT INTO `furniture` VALUES (366, '{}', '{}');
INSERT INTO `furniture` VALUES (367, '{}', '{}');
INSERT INTO `furniture` VALUES (368, '{}', '{}');
INSERT INTO `furniture` VALUES (369, '{}', '{}');
INSERT INTO `furniture` VALUES (370, '{}', '{}');
INSERT INTO `furniture` VALUES (371, '{}', '{}');
INSERT INTO `furniture` VALUES (372, '{}', '{}');
INSERT INTO `furniture` VALUES (373, '{}', '{}');
INSERT INTO `furniture` VALUES (374, '{}', '{}');
INSERT INTO `furniture` VALUES (375, '{}', '{}');
INSERT INTO `furniture` VALUES (376, '{}', '{}');
INSERT INTO `furniture` VALUES (377, '{}', '{}');
INSERT INTO `furniture` VALUES (378, '{}', '{}');
INSERT INTO `furniture` VALUES (379, '{}', '{}');
INSERT INTO `furniture` VALUES (380, '{}', '{}');
INSERT INTO `furniture` VALUES (381, '{}', '{}');
INSERT INTO `furniture` VALUES (382, '{}', '{}');
INSERT INTO `furniture` VALUES (383, '{}', '{}');
INSERT INTO `furniture` VALUES (384, '{}', '{}');
INSERT INTO `furniture` VALUES (385, '{}', '{}');
INSERT INTO `furniture` VALUES (386, '{}', '{}');
INSERT INTO `furniture` VALUES (387, '{}', '{}');
INSERT INTO `furniture` VALUES (388, '{}', '{}');
INSERT INTO `furniture` VALUES (389, '{}', '{}');
INSERT INTO `furniture` VALUES (390, '{}', '{}');
INSERT INTO `furniture` VALUES (391, '{}', '{}');
INSERT INTO `furniture` VALUES (392, '{}', '{}');
INSERT INTO `furniture` VALUES (393, '{}', '{}');
INSERT INTO `furniture` VALUES (394, '{}', '{}');
INSERT INTO `furniture` VALUES (395, '{}', '{}');
INSERT INTO `furniture` VALUES (396, '{}', '{}');
INSERT INTO `furniture` VALUES (397, '{}', '{}');
INSERT INTO `furniture` VALUES (398, '{}', '{}');
INSERT INTO `furniture` VALUES (399, '{}', '{}');
INSERT INTO `furniture` VALUES (400, '{}', '{}');
INSERT INTO `furniture` VALUES (401, '{}', '{}');
INSERT INTO `furniture` VALUES (402, '{}', '{}');
INSERT INTO `furniture` VALUES (403, '{}', '{}');
INSERT INTO `furniture` VALUES (404, '{}', '{}');
INSERT INTO `furniture` VALUES (405, '{}', '{}');
INSERT INTO `furniture` VALUES (406, '{}', '{}');
INSERT INTO `furniture` VALUES (407, '{}', '{}');
INSERT INTO `furniture` VALUES (408, '{}', '{}');
INSERT INTO `furniture` VALUES (409, '{}', '{}');
INSERT INTO `furniture` VALUES (410, '{}', '{}');
INSERT INTO `furniture` VALUES (411, '{}', '{}');
INSERT INTO `furniture` VALUES (412, '{}', '{}');
INSERT INTO `furniture` VALUES (413, '{}', '{}');
INSERT INTO `furniture` VALUES (414, '{}', '{}');
INSERT INTO `furniture` VALUES (415, '{}', '{}');
INSERT INTO `furniture` VALUES (416, '{}', '{}');
INSERT INTO `furniture` VALUES (417, '{}', '{}');
INSERT INTO `furniture` VALUES (418, '{}', '{}');
INSERT INTO `furniture` VALUES (419, '{}', '{}');
INSERT INTO `furniture` VALUES (420, '{}', '{}');
INSERT INTO `furniture` VALUES (421, '{}', '{}');
INSERT INTO `furniture` VALUES (422, '{}', '{}');
INSERT INTO `furniture` VALUES (423, '{}', '{}');
INSERT INTO `furniture` VALUES (424, '{}', '{}');
INSERT INTO `furniture` VALUES (425, '{}', '{}');
INSERT INTO `furniture` VALUES (426, '{}', '{}');
INSERT INTO `furniture` VALUES (427, '{}', '{}');
INSERT INTO `furniture` VALUES (428, '{}', '{}');
INSERT INTO `furniture` VALUES (429, '{}', '{}');
INSERT INTO `furniture` VALUES (430, '{}', '{}');
INSERT INTO `furniture` VALUES (431, '{}', '{}');
INSERT INTO `furniture` VALUES (432, '{}', '{}');
INSERT INTO `furniture` VALUES (433, '{}', '{}');
INSERT INTO `furniture` VALUES (434, '{}', '{}');
INSERT INTO `furniture` VALUES (435, '{}', '{}');
INSERT INTO `furniture` VALUES (436, '{}', '{}');
INSERT INTO `furniture` VALUES (437, '{}', '{}');
INSERT INTO `furniture` VALUES (438, '{}', '{}');
INSERT INTO `furniture` VALUES (439, '{}', '{}');
INSERT INTO `furniture` VALUES (440, '{}', '{}');
INSERT INTO `furniture` VALUES (441, '{}', '{}');
INSERT INTO `furniture` VALUES (442, '{}', '{}');
INSERT INTO `furniture` VALUES (443, '{}', '{}');
INSERT INTO `furniture` VALUES (444, '{}', '{}');
INSERT INTO `furniture` VALUES (445, '{}', '{}');
INSERT INTO `furniture` VALUES (446, '{}', '{}');
INSERT INTO `furniture` VALUES (447, '{}', '{}');
INSERT INTO `furniture` VALUES (448, '{}', '{}');
INSERT INTO `furniture` VALUES (449, '{}', '{}');
INSERT INTO `furniture` VALUES (450, '{}', '{}');
INSERT INTO `furniture` VALUES (451, '{}', '{}');
INSERT INTO `furniture` VALUES (452, '{}', '{}');
INSERT INTO `furniture` VALUES (453, '{}', '{}');
INSERT INTO `furniture` VALUES (454, '{}', '{}');
INSERT INTO `furniture` VALUES (455, '{}', '{}');
INSERT INTO `furniture` VALUES (456, '{}', '{}');
INSERT INTO `furniture` VALUES (457, '{}', '{}');
INSERT INTO `furniture` VALUES (458, '{}', '{}');
INSERT INTO `furniture` VALUES (459, '{}', '{}');
INSERT INTO `furniture` VALUES (460, '{}', '{}');
INSERT INTO `furniture` VALUES (461, '{}', '{}');
INSERT INTO `furniture` VALUES (462, '{}', '{}');
INSERT INTO `furniture` VALUES (463, '{}', '{}');
INSERT INTO `furniture` VALUES (464, '{}', '{}');
INSERT INTO `furniture` VALUES (465, '{}', '{}');
INSERT INTO `furniture` VALUES (466, '{}', '{}');
INSERT INTO `furniture` VALUES (467, '{}', '{}');
INSERT INTO `furniture` VALUES (468, '{}', '{}');
INSERT INTO `furniture` VALUES (469, '{}', '{}');
INSERT INTO `furniture` VALUES (470, '{}', '{}');
INSERT INTO `furniture` VALUES (471, '{}', '{}');
INSERT INTO `furniture` VALUES (472, '{}', '{}');
INSERT INTO `furniture` VALUES (473, '{}', '{}');
INSERT INTO `furniture` VALUES (474, '{}', '{}');
INSERT INTO `furniture` VALUES (475, '{}', '{}');
INSERT INTO `furniture` VALUES (476, '{}', '{}');
INSERT INTO `furniture` VALUES (477, '{}', '{}');
INSERT INTO `furniture` VALUES (478, '{}', '{}');
INSERT INTO `furniture` VALUES (479, '{}', '{}');
INSERT INTO `furniture` VALUES (480, '{}', '{}');
INSERT INTO `furniture` VALUES (481, '{}', '{}');
INSERT INTO `furniture` VALUES (482, '{}', '{}');
INSERT INTO `furniture` VALUES (483, '{}', '{}');
INSERT INTO `furniture` VALUES (484, '{}', '{}');
INSERT INTO `furniture` VALUES (485, '{}', '{}');
INSERT INTO `furniture` VALUES (486, '{}', '{}');
INSERT INTO `furniture` VALUES (487, '{}', '{}');
INSERT INTO `furniture` VALUES (488, '{}', '{}');
INSERT INTO `furniture` VALUES (489, '{}', '{}');
INSERT INTO `furniture` VALUES (490, '{}', '{}');
INSERT INTO `furniture` VALUES (491, '{}', '{}');
INSERT INTO `furniture` VALUES (492, '{}', '{}');
INSERT INTO `furniture` VALUES (493, '{}', '{}');
INSERT INTO `furniture` VALUES (494, '{}', '{}');
INSERT INTO `furniture` VALUES (495, '{}', '{}');
INSERT INTO `furniture` VALUES (496, '{}', '{}');
INSERT INTO `furniture` VALUES (497, '{}', '{}');
INSERT INTO `furniture` VALUES (498, '{}', '{}');
INSERT INTO `furniture` VALUES (499, '{}', '{}');
INSERT INTO `furniture` VALUES (500, '{}', '{}');
INSERT INTO `furniture` VALUES (501, '{}', '{}');
INSERT INTO `furniture` VALUES (502, '{}', '{}');
INSERT INTO `furniture` VALUES (503, '{}', '{}');
INSERT INTO `furniture` VALUES (504, '{}', '{}');
INSERT INTO `furniture` VALUES (505, '{}', '{}');
INSERT INTO `furniture` VALUES (506, '{}', '{}');
INSERT INTO `furniture` VALUES (507, '{}', '{}');
INSERT INTO `furniture` VALUES (508, '{}', '{}');
INSERT INTO `furniture` VALUES (509, '{}', '{}');
INSERT INTO `furniture` VALUES (510, '{}', '{}');
INSERT INTO `furniture` VALUES (511, '{}', '{}');
INSERT INTO `furniture` VALUES (512, '{}', '{}');
INSERT INTO `furniture` VALUES (513, '{}', '{}');
INSERT INTO `furniture` VALUES (514, '{}', '{}');
INSERT INTO `furniture` VALUES (515, '{}', '{}');
INSERT INTO `furniture` VALUES (516, '{}', '{}');
INSERT INTO `furniture` VALUES (517, '{}', '{}');
INSERT INTO `furniture` VALUES (518, '{}', '{}');
INSERT INTO `furniture` VALUES (519, '{}', '{}');
INSERT INTO `furniture` VALUES (520, '{}', '{}');
INSERT INTO `furniture` VALUES (521, '{}', '{}');
INSERT INTO `furniture` VALUES (522, '{}', '{}');
INSERT INTO `furniture` VALUES (523, '{}', '{}');
INSERT INTO `furniture` VALUES (524, '{}', '{}');
INSERT INTO `furniture` VALUES (525, '{}', '{}');
INSERT INTO `furniture` VALUES (526, '{}', '{}');
INSERT INTO `furniture` VALUES (527, '{}', '{}');
INSERT INTO `furniture` VALUES (528, '{}', '{}');
INSERT INTO `furniture` VALUES (529, '{}', '{}');
INSERT INTO `furniture` VALUES (530, '{}', '{}');
INSERT INTO `furniture` VALUES (531, '{}', '{}');
INSERT INTO `furniture` VALUES (532, '{}', '{}');
INSERT INTO `furniture` VALUES (533, '{}', '{}');
INSERT INTO `furniture` VALUES (534, '{}', '{}');
INSERT INTO `furniture` VALUES (535, '{}', '{}');
INSERT INTO `furniture` VALUES (536, '{}', '{}');
INSERT INTO `furniture` VALUES (537, '{}', '{}');
INSERT INTO `furniture` VALUES (538, '{}', '{}');
INSERT INTO `furniture` VALUES (539, '{}', '{}');
INSERT INTO `furniture` VALUES (540, '{}', '{}');
INSERT INTO `furniture` VALUES (541, '{}', '{}');
INSERT INTO `furniture` VALUES (542, '{}', '{}');
INSERT INTO `furniture` VALUES (543, '{}', '{}');
INSERT INTO `furniture` VALUES (544, '{}', '{}');
INSERT INTO `furniture` VALUES (545, '{}', '{}');
INSERT INTO `furniture` VALUES (546, '{}', '{}');
INSERT INTO `furniture` VALUES (547, '{}', '{}');
INSERT INTO `furniture` VALUES (548, '{\"0\":{\"Name\":\"Waffentresor\",\"Model\":\"prop_ld_int_safe_01\",\"ID\":0,\"Position\":null,\"Rotation\":null,\"IsSet\":false},\"1\":{\"Name\":\"Waffentresor\",\"Model\":\"prop_ld_int_safe_01\",\"ID\":1,\"Position\":null,\"Rotation\":null,\"IsSet\":false}}', '{\"0\":[],\"1\":[]}');
INSERT INTO `furniture` VALUES (549, '{}', '{}');
INSERT INTO `furniture` VALUES (550, '{}', '{}');
INSERT INTO `furniture` VALUES (551, '{}', '{}');
INSERT INTO `furniture` VALUES (552, '{}', '{}');
INSERT INTO `furniture` VALUES (553, '{}', '{}');
INSERT INTO `furniture` VALUES (554, '{}', '{}');
INSERT INTO `furniture` VALUES (555, '{}', '{}');
INSERT INTO `furniture` VALUES (556, '{}', '{}');
INSERT INTO `furniture` VALUES (557, '{}', '{}');
INSERT INTO `furniture` VALUES (558, '{}', '{}');
INSERT INTO `furniture` VALUES (559, '{}', '{}');
INSERT INTO `furniture` VALUES (560, '{}', '{}');
INSERT INTO `furniture` VALUES (561, '{}', '{}');
INSERT INTO `furniture` VALUES (562, '{}', '{}');
INSERT INTO `furniture` VALUES (563, '{}', '{}');
INSERT INTO `furniture` VALUES (564, '{}', '{}');
INSERT INTO `furniture` VALUES (565, '{}', '{}');
INSERT INTO `furniture` VALUES (566, '{}', '{}');
INSERT INTO `furniture` VALUES (567, '{}', '{}');
INSERT INTO `furniture` VALUES (568, '{}', '{}');
INSERT INTO `furniture` VALUES (569, '{}', '{}');
INSERT INTO `furniture` VALUES (570, '{}', '{}');
INSERT INTO `furniture` VALUES (571, '{}', '{}');
INSERT INTO `furniture` VALUES (572, '{}', '{}');
INSERT INTO `furniture` VALUES (573, '{}', '{}');
INSERT INTO `furniture` VALUES (574, '{}', '{}');
INSERT INTO `furniture` VALUES (575, '{}', '{}');
INSERT INTO `furniture` VALUES (576, '{}', '{}');
INSERT INTO `furniture` VALUES (577, '{}', '{}');
INSERT INTO `furniture` VALUES (578, '{}', '{}');
INSERT INTO `furniture` VALUES (579, '{}', '{}');
INSERT INTO `furniture` VALUES (580, '{}', '{}');
INSERT INTO `furniture` VALUES (581, '{}', '{}');
INSERT INTO `furniture` VALUES (582, '{}', '{}');
INSERT INTO `furniture` VALUES (583, '{}', '{}');
INSERT INTO `furniture` VALUES (584, '{}', '{}');
INSERT INTO `furniture` VALUES (585, '{}', '{}');
INSERT INTO `furniture` VALUES (586, '{}', '{}');
INSERT INTO `furniture` VALUES (587, '{}', '{}');
INSERT INTO `furniture` VALUES (588, '{}', '{}');
INSERT INTO `furniture` VALUES (589, '{}', '{}');
INSERT INTO `furniture` VALUES (590, '{}', '{}');
INSERT INTO `furniture` VALUES (591, '{}', '{}');
INSERT INTO `furniture` VALUES (592, '{}', '{}');
INSERT INTO `furniture` VALUES (593, '{}', '{}');
INSERT INTO `furniture` VALUES (594, '{}', '{}');
INSERT INTO `furniture` VALUES (595, '{}', '{}');
INSERT INTO `furniture` VALUES (596, '{}', '{}');
INSERT INTO `furniture` VALUES (597, '{}', '{}');
INSERT INTO `furniture` VALUES (598, '{}', '{}');
INSERT INTO `furniture` VALUES (599, '{}', '{}');
INSERT INTO `furniture` VALUES (600, '{}', '{}');
INSERT INTO `furniture` VALUES (601, '{}', '{}');
INSERT INTO `furniture` VALUES (602, '{}', '{}');
INSERT INTO `furniture` VALUES (603, '{}', '{}');
INSERT INTO `furniture` VALUES (604, '{}', '{}');
INSERT INTO `furniture` VALUES (605, '{}', '{}');
INSERT INTO `furniture` VALUES (606, '{}', '{}');
INSERT INTO `furniture` VALUES (607, '{}', '{}');
INSERT INTO `furniture` VALUES (608, '{}', '{}');
INSERT INTO `furniture` VALUES (609, '{}', '{}');
INSERT INTO `furniture` VALUES (610, '{}', '{}');
INSERT INTO `furniture` VALUES (611, '{}', '{}');
INSERT INTO `furniture` VALUES (612, '{}', '{}');
INSERT INTO `furniture` VALUES (613, '{}', '{}');
INSERT INTO `furniture` VALUES (614, '{}', '{}');
INSERT INTO `furniture` VALUES (615, '{}', '{}');
INSERT INTO `furniture` VALUES (616, '{}', '{}');
INSERT INTO `furniture` VALUES (617, '{}', '{}');
INSERT INTO `furniture` VALUES (618, '{}', '{}');
INSERT INTO `furniture` VALUES (619, '{}', '{}');
INSERT INTO `furniture` VALUES (620, '{}', '{}');
INSERT INTO `furniture` VALUES (621, '{}', '{}');
INSERT INTO `furniture` VALUES (622, '{}', '{}');
INSERT INTO `furniture` VALUES (623, '{}', '{}');
INSERT INTO `furniture` VALUES (624, '{}', '{}');
INSERT INTO `furniture` VALUES (625, '{}', '{}');
INSERT INTO `furniture` VALUES (626, '{}', '{}');
INSERT INTO `furniture` VALUES (627, '{}', '{}');
INSERT INTO `furniture` VALUES (628, '{}', '{}');
INSERT INTO `furniture` VALUES (629, '{}', '{}');
INSERT INTO `furniture` VALUES (630, '{}', '{}');
INSERT INTO `furniture` VALUES (631, '{}', '{}');
INSERT INTO `furniture` VALUES (632, '{}', '{}');
INSERT INTO `furniture` VALUES (633, '{}', '{}');
INSERT INTO `furniture` VALUES (634, '{}', '{}');
INSERT INTO `furniture` VALUES (635, '{}', '{}');
INSERT INTO `furniture` VALUES (636, '{}', '{}');
INSERT INTO `furniture` VALUES (637, '{}', '{}');
INSERT INTO `furniture` VALUES (638, '{}', '{}');
INSERT INTO `furniture` VALUES (639, '{}', '{}');
INSERT INTO `furniture` VALUES (640, '{}', '{}');
INSERT INTO `furniture` VALUES (641, '{}', '{}');
INSERT INTO `furniture` VALUES (642, '{}', '{}');
INSERT INTO `furniture` VALUES (643, '{}', '{}');
INSERT INTO `furniture` VALUES (644, '{}', '{}');
INSERT INTO `furniture` VALUES (645, '{}', '{}');
INSERT INTO `furniture` VALUES (646, '{}', '{}');
INSERT INTO `furniture` VALUES (647, '{}', '{}');
INSERT INTO `furniture` VALUES (648, '{}', '{}');
INSERT INTO `furniture` VALUES (649, '{}', '{}');
INSERT INTO `furniture` VALUES (650, '{}', '{}');
INSERT INTO `furniture` VALUES (651, '{}', '{}');
INSERT INTO `furniture` VALUES (652, '{}', '{}');
INSERT INTO `furniture` VALUES (653, '{}', '{}');
INSERT INTO `furniture` VALUES (654, '{}', '{}');
INSERT INTO `furniture` VALUES (655, '{}', '{}');
INSERT INTO `furniture` VALUES (656, '{}', '{}');
INSERT INTO `furniture` VALUES (657, '{}', '{}');
INSERT INTO `furniture` VALUES (658, '{}', '{}');
INSERT INTO `furniture` VALUES (659, '{}', '{}');
INSERT INTO `furniture` VALUES (660, '{}', '{}');
INSERT INTO `furniture` VALUES (661, '{}', '{}');
INSERT INTO `furniture` VALUES (662, '{}', '{}');
INSERT INTO `furniture` VALUES (663, '{}', '{}');
INSERT INTO `furniture` VALUES (664, '{}', '{}');
INSERT INTO `furniture` VALUES (665, '{}', '{}');
INSERT INTO `furniture` VALUES (666, '{}', '{}');
INSERT INTO `furniture` VALUES (667, '{}', '{}');
INSERT INTO `furniture` VALUES (668, '{}', '{}');
INSERT INTO `furniture` VALUES (669, '{}', '{}');
INSERT INTO `furniture` VALUES (670, '{}', '{}');
INSERT INTO `furniture` VALUES (671, '{}', '{}');
INSERT INTO `furniture` VALUES (672, '{}', '{}');
INSERT INTO `furniture` VALUES (673, '{}', '{}');
INSERT INTO `furniture` VALUES (674, '{}', '{}');
INSERT INTO `furniture` VALUES (675, '{}', '{}');
INSERT INTO `furniture` VALUES (676, '{}', '{}');
INSERT INTO `furniture` VALUES (677, '{}', '{}');
INSERT INTO `furniture` VALUES (678, '{}', '{}');
INSERT INTO `furniture` VALUES (679, '{}', '{}');
INSERT INTO `furniture` VALUES (680, '{}', '{}');
INSERT INTO `furniture` VALUES (681, '{}', '{}');
INSERT INTO `furniture` VALUES (682, '{}', '{}');
INSERT INTO `furniture` VALUES (683, '{}', '{}');
INSERT INTO `furniture` VALUES (684, '{}', '{}');
INSERT INTO `furniture` VALUES (685, '{}', '{}');
INSERT INTO `furniture` VALUES (686, '{}', '{}');
INSERT INTO `furniture` VALUES (687, '{}', '{}');
INSERT INTO `furniture` VALUES (688, '{}', '{}');
INSERT INTO `furniture` VALUES (689, '{}', '{}');
INSERT INTO `furniture` VALUES (690, '{}', '{}');
INSERT INTO `furniture` VALUES (691, '{}', '{}');
INSERT INTO `furniture` VALUES (692, '{}', '{}');
INSERT INTO `furniture` VALUES (693, '{}', '{}');
INSERT INTO `furniture` VALUES (694, '{}', '{}');
INSERT INTO `furniture` VALUES (695, '{}', '{}');
INSERT INTO `furniture` VALUES (696, '{}', '{}');
INSERT INTO `furniture` VALUES (697, '{}', '{}');
INSERT INTO `furniture` VALUES (698, '{}', '{}');
INSERT INTO `furniture` VALUES (699, '{}', '{}');
INSERT INTO `furniture` VALUES (700, '{}', '{}');
INSERT INTO `furniture` VALUES (701, '{}', '{}');
INSERT INTO `furniture` VALUES (702, '{}', '{}');
INSERT INTO `furniture` VALUES (703, '{}', '{}');
INSERT INTO `furniture` VALUES (704, '{}', '{}');
INSERT INTO `furniture` VALUES (705, '{}', '{}');
INSERT INTO `furniture` VALUES (706, '{}', '{}');
INSERT INTO `furniture` VALUES (707, '{}', '{}');
INSERT INTO `furniture` VALUES (708, '{}', '{}');
INSERT INTO `furniture` VALUES (709, '{}', '{}');
INSERT INTO `furniture` VALUES (710, '{}', '{}');
INSERT INTO `furniture` VALUES (711, '{}', '{}');
INSERT INTO `furniture` VALUES (712, '{}', '{}');
INSERT INTO `furniture` VALUES (713, '{}', '{}');
INSERT INTO `furniture` VALUES (714, '{}', '{}');
INSERT INTO `furniture` VALUES (715, '{}', '{}');
INSERT INTO `furniture` VALUES (716, '{}', '{}');
INSERT INTO `furniture` VALUES (717, '{}', '{}');
INSERT INTO `furniture` VALUES (718, '{}', '{}');
INSERT INTO `furniture` VALUES (719, '{}', '{}');
INSERT INTO `furniture` VALUES (720, '{}', '{}');
INSERT INTO `furniture` VALUES (721, '{}', '{}');
INSERT INTO `furniture` VALUES (722, '{}', '{}');
INSERT INTO `furniture` VALUES (1000, '{\"0\":{\"Name\":\"Оружейный сейф\",\"Model\":\"prop_ld_int_safe_01\",\"ID\":0,\"Position\":{\"x\":-24.818,\"y\":-593.115,\"z\":89.62},\"Rotation\":{\"x\":0.0,\"y\":0.0,\"z\":159.7},\"IsSet\":true}}', '{\"0\":[]}');
INSERT INTO `furniture` VALUES (1001, '{}', '{}');
INSERT INTO `furniture` VALUES (1002, '{}', '{}');
INSERT INTO `furniture` VALUES (1003, '{}', '{}');
INSERT INTO `furniture` VALUES (1004, '{}', '{}');
INSERT INTO `furniture` VALUES (1005, '{}', '{}');
INSERT INTO `furniture` VALUES (1006, '{}', '{}');
INSERT INTO `furniture` VALUES (1007, '{}', '{}');
INSERT INTO `furniture` VALUES (1008, '{}', '{}');
INSERT INTO `furniture` VALUES (1009, '{}', '{}');
INSERT INTO `furniture` VALUES (1010, '{}', '{}');
INSERT INTO `furniture` VALUES (1011, '{}', '{}');
INSERT INTO `furniture` VALUES (1012, '{}', '{}');
INSERT INTO `furniture` VALUES (1013, '{}', '{}');
INSERT INTO `furniture` VALUES (1014, '{}', '{}');
INSERT INTO `furniture` VALUES (1015, '{}', '{}');
INSERT INTO `furniture` VALUES (1016, '{}', '{}');
INSERT INTO `furniture` VALUES (1017, '{}', '{}');
INSERT INTO `furniture` VALUES (1018, '{}', '{}');
INSERT INTO `furniture` VALUES (1019, '{}', '{}');
INSERT INTO `furniture` VALUES (1020, '{}', '{}');
INSERT INTO `furniture` VALUES (1021, '{}', '{}');
INSERT INTO `furniture` VALUES (1022, '{}', '{}');
INSERT INTO `furniture` VALUES (1023, '{}', '{}');
INSERT INTO `furniture` VALUES (1024, '{}', '{}');
INSERT INTO `furniture` VALUES (1025, '{}', '{}');
INSERT INTO `furniture` VALUES (1026, '{}', '{}');
INSERT INTO `furniture` VALUES (1027, '{}', '{}');
INSERT INTO `furniture` VALUES (1028, '{}', '{}');
INSERT INTO `furniture` VALUES (1029, '{}', '{}');
INSERT INTO `furniture` VALUES (1030, '{}', '{}');
INSERT INTO `furniture` VALUES (1031, '{}', '{}');
INSERT INTO `furniture` VALUES (1032, '{}', '{}');
INSERT INTO `furniture` VALUES (1033, '{}', '{}');
INSERT INTO `furniture` VALUES (1034, '{}', '{}');
INSERT INTO `furniture` VALUES (1035, '{}', '{}');
INSERT INTO `furniture` VALUES (1036, '{}', '{}');
INSERT INTO `furniture` VALUES (1037, '{}', '{}');
INSERT INTO `furniture` VALUES (1038, '{}', '{}');
INSERT INTO `furniture` VALUES (1039, '{}', '{}');
INSERT INTO `furniture` VALUES (1040, '{}', '{}');
INSERT INTO `furniture` VALUES (1041, '{}', '{}');
INSERT INTO `furniture` VALUES (1042, '{}', '{}');
INSERT INTO `furniture` VALUES (1043, '{}', '{}');
INSERT INTO `furniture` VALUES (1044, '{}', '{}');
INSERT INTO `furniture` VALUES (1045, '{}', '{}');
INSERT INTO `furniture` VALUES (1046, '{}', '{}');
INSERT INTO `furniture` VALUES (1047, '{}', '{}');
INSERT INTO `furniture` VALUES (1048, '{}', '{}');
INSERT INTO `furniture` VALUES (1049, '{}', '{}');
INSERT INTO `furniture` VALUES (1050, '{}', '{}');
INSERT INTO `furniture` VALUES (1051, '{}', '{}');
INSERT INTO `furniture` VALUES (1052, '{}', '{}');
INSERT INTO `furniture` VALUES (1053, '{}', '{}');
INSERT INTO `furniture` VALUES (1054, '{}', '{}');
INSERT INTO `furniture` VALUES (1055, '{}', '{}');
INSERT INTO `furniture` VALUES (1056, '{}', '{}');
INSERT INTO `furniture` VALUES (1057, '{}', '{}');
INSERT INTO `furniture` VALUES (1058, '{}', '{}');
INSERT INTO `furniture` VALUES (1059, '{}', '{}');
INSERT INTO `furniture` VALUES (1060, '{}', '{}');
INSERT INTO `furniture` VALUES (1061, '{}', '{}');
INSERT INTO `furniture` VALUES (1062, '{}', '{}');
INSERT INTO `furniture` VALUES (1063, '{}', '{}');
INSERT INTO `furniture` VALUES (1064, '{}', '{}');
INSERT INTO `furniture` VALUES (1065, '{}', '{}');
INSERT INTO `furniture` VALUES (1066, '{}', '{}');
INSERT INTO `furniture` VALUES (1067, '{}', '{}');
INSERT INTO `furniture` VALUES (1068, '{}', '{}');
INSERT INTO `furniture` VALUES (1069, '{}', '{}');
INSERT INTO `furniture` VALUES (1070, '{}', '{}');
INSERT INTO `furniture` VALUES (1071, '{}', '{}');
INSERT INTO `furniture` VALUES (1072, '{}', '{}');
INSERT INTO `furniture` VALUES (1073, '{}', '{}');
INSERT INTO `furniture` VALUES (1074, '{}', '{}');
INSERT INTO `furniture` VALUES (1075, '{}', '{}');
INSERT INTO `furniture` VALUES (1076, '{}', '{}');
INSERT INTO `furniture` VALUES (1077, '{}', '{}');
INSERT INTO `furniture` VALUES (1078, '{}', '{}');
INSERT INTO `furniture` VALUES (1079, '{}', '{}');
INSERT INTO `furniture` VALUES (1080, '{}', '{}');
INSERT INTO `furniture` VALUES (1081, '{}', '{}');
INSERT INTO `furniture` VALUES (1082, '{}', '{}');
INSERT INTO `furniture` VALUES (1083, '{}', '{}');
INSERT INTO `furniture` VALUES (1084, '{}', '{}');
INSERT INTO `furniture` VALUES (1085, '{}', '{}');
INSERT INTO `furniture` VALUES (1086, '{}', '{}');
INSERT INTO `furniture` VALUES (1087, '{}', '{}');
INSERT INTO `furniture` VALUES (1088, '{}', '{}');
INSERT INTO `furniture` VALUES (1089, '{}', '{}');
INSERT INTO `furniture` VALUES (1090, '{}', '{}');
INSERT INTO `furniture` VALUES (1091, '{}', '{}');
INSERT INTO `furniture` VALUES (1092, '{}', '{}');
INSERT INTO `furniture` VALUES (1093, '{}', '{}');
INSERT INTO `furniture` VALUES (1094, '{}', '{}');
INSERT INTO `furniture` VALUES (1095, '{}', '{}');
INSERT INTO `furniture` VALUES (1096, '{}', '{}');
INSERT INTO `furniture` VALUES (1097, '{}', '{}');
INSERT INTO `furniture` VALUES (1098, '{}', '{}');
INSERT INTO `furniture` VALUES (1099, '{}', '{}');
INSERT INTO `furniture` VALUES (1100, '{}', '{}');
INSERT INTO `furniture` VALUES (1101, '{}', '{}');
INSERT INTO `furniture` VALUES (1102, '{}', '{}');
INSERT INTO `furniture` VALUES (1103, '{}', '{}');
INSERT INTO `furniture` VALUES (1104, '{}', '{}');
INSERT INTO `furniture` VALUES (1105, '{}', '{}');
INSERT INTO `furniture` VALUES (1106, '{}', '{}');
INSERT INTO `furniture` VALUES (1107, '{}', '{}');
INSERT INTO `furniture` VALUES (1108, '{}', '{}');
INSERT INTO `furniture` VALUES (1109, '{}', '{}');
INSERT INTO `furniture` VALUES (1110, '{}', '{}');
INSERT INTO `furniture` VALUES (1111, '{}', '{}');
INSERT INTO `furniture` VALUES (1112, '{}', '{}');
INSERT INTO `furniture` VALUES (1113, '{}', '{}');
INSERT INTO `furniture` VALUES (1114, '{}', '{}');
INSERT INTO `furniture` VALUES (1115, '{}', '{}');
INSERT INTO `furniture` VALUES (1116, '{}', '{}');
INSERT INTO `furniture` VALUES (1117, '{}', '{}');
INSERT INTO `furniture` VALUES (1118, '{}', '{}');
INSERT INTO `furniture` VALUES (1119, '{}', '{}');
INSERT INTO `furniture` VALUES (1120, '{}', '{}');
INSERT INTO `furniture` VALUES (1121, '{}', '{}');
INSERT INTO `furniture` VALUES (1122, '{}', '{}');
INSERT INTO `furniture` VALUES (1123, '{}', '{}');
INSERT INTO `furniture` VALUES (1124, '{}', '{}');
INSERT INTO `furniture` VALUES (1125, '{}', '{}');
INSERT INTO `furniture` VALUES (1126, '{}', '{}');
INSERT INTO `furniture` VALUES (1127, '{}', '{}');
INSERT INTO `furniture` VALUES (1128, '{}', '{}');
INSERT INTO `furniture` VALUES (1129, '{}', '{}');
INSERT INTO `furniture` VALUES (1130, '{}', '{}');
INSERT INTO `furniture` VALUES (1131, '{}', '{}');
INSERT INTO `furniture` VALUES (1132, '{}', '{}');
INSERT INTO `furniture` VALUES (1133, '{}', '{}');
INSERT INTO `furniture` VALUES (1134, '{}', '{}');
INSERT INTO `furniture` VALUES (1135, '{}', '{}');
INSERT INTO `furniture` VALUES (1136, '{}', '{}');
INSERT INTO `furniture` VALUES (1137, '{}', '{}');
INSERT INTO `furniture` VALUES (1138, '{}', '{}');
INSERT INTO `furniture` VALUES (1139, '{}', '{}');
INSERT INTO `furniture` VALUES (1140, '{}', '{}');
INSERT INTO `furniture` VALUES (1141, '{}', '{}');
INSERT INTO `furniture` VALUES (1142, '{}', '{}');
INSERT INTO `furniture` VALUES (1143, '{}', '{}');
INSERT INTO `furniture` VALUES (1144, '{}', '{}');
INSERT INTO `furniture` VALUES (1145, '{}', '{}');
INSERT INTO `furniture` VALUES (1146, '{}', '{}');
INSERT INTO `furniture` VALUES (1147, '{}', '{}');
INSERT INTO `furniture` VALUES (1148, '{}', '{}');
INSERT INTO `furniture` VALUES (1149, '{}', '{}');
INSERT INTO `furniture` VALUES (1150, '{}', '{}');
INSERT INTO `furniture` VALUES (1151, '{}', '{}');
INSERT INTO `furniture` VALUES (1152, '{}', '{}');
INSERT INTO `furniture` VALUES (1153, '{}', '{}');
INSERT INTO `furniture` VALUES (1154, '{}', '{}');
INSERT INTO `furniture` VALUES (1155, '{}', '{}');
INSERT INTO `furniture` VALUES (1156, '{}', '{}');
INSERT INTO `furniture` VALUES (1157, '{}', '{}');
INSERT INTO `furniture` VALUES (1158, '{}', '{}');
INSERT INTO `furniture` VALUES (1159, '{}', '{}');
INSERT INTO `furniture` VALUES (1160, '{}', '{}');
INSERT INTO `furniture` VALUES (1161, '{}', '{}');
INSERT INTO `furniture` VALUES (1162, '{}', '{}');
INSERT INTO `furniture` VALUES (1163, '{}', '{}');
INSERT INTO `furniture` VALUES (1164, '{}', '{}');
INSERT INTO `furniture` VALUES (1165, '{}', '{}');
INSERT INTO `furniture` VALUES (1166, '{}', '{}');
INSERT INTO `furniture` VALUES (1167, '{}', '{}');
INSERT INTO `furniture` VALUES (1168, '{}', '{}');
INSERT INTO `furniture` VALUES (1169, '{}', '{}');
INSERT INTO `furniture` VALUES (1170, '{}', '{}');
INSERT INTO `furniture` VALUES (1171, '{}', '{}');
INSERT INTO `furniture` VALUES (1172, '{}', '{}');
INSERT INTO `furniture` VALUES (1173, '{}', '{}');
INSERT INTO `furniture` VALUES (1174, '{}', '{}');
INSERT INTO `furniture` VALUES (1175, '{}', '{}');
INSERT INTO `furniture` VALUES (1176, '{}', '{}');
INSERT INTO `furniture` VALUES (1177, '{}', '{}');
INSERT INTO `furniture` VALUES (1178, '{}', '{}');
INSERT INTO `furniture` VALUES (1179, '{}', '{}');
INSERT INTO `furniture` VALUES (1180, '{}', '{}');
INSERT INTO `furniture` VALUES (1181, '{}', '{}');
INSERT INTO `furniture` VALUES (1182, '{}', '{}');
INSERT INTO `furniture` VALUES (1183, '{}', '{}');
INSERT INTO `furniture` VALUES (1184, '{}', '{}');
INSERT INTO `furniture` VALUES (1185, '{}', '{}');
INSERT INTO `furniture` VALUES (1186, '{}', '{}');
INSERT INTO `furniture` VALUES (1187, '{}', '{}');
INSERT INTO `furniture` VALUES (1188, '{}', '{}');
INSERT INTO `furniture` VALUES (1189, '{}', '{}');
INSERT INTO `furniture` VALUES (1190, '{}', '{}');
INSERT INTO `furniture` VALUES (1191, '{}', '{}');
INSERT INTO `furniture` VALUES (1192, '{}', '{}');
INSERT INTO `furniture` VALUES (1193, '{}', '{}');
INSERT INTO `furniture` VALUES (1194, '{}', '{}');
INSERT INTO `furniture` VALUES (1195, '{}', '{}');
INSERT INTO `furniture` VALUES (1196, '{}', '{}');
INSERT INTO `furniture` VALUES (1197, '{}', '{}');
INSERT INTO `furniture` VALUES (1198, '{}', '{}');
INSERT INTO `furniture` VALUES (1199, '{}', '{}');
INSERT INTO `furniture` VALUES (1200, '{}', '{}');
INSERT INTO `furniture` VALUES (1201, '{}', '{}');
INSERT INTO `furniture` VALUES (1202, '{}', '{}');
INSERT INTO `furniture` VALUES (1203, '{}', '{}');
INSERT INTO `furniture` VALUES (1204, '{}', '{}');
INSERT INTO `furniture` VALUES (1205, '{}', '{}');
INSERT INTO `furniture` VALUES (1206, '{}', '{}');
INSERT INTO `furniture` VALUES (1207, '{}', '{}');
INSERT INTO `furniture` VALUES (1208, '{}', '{}');
INSERT INTO `furniture` VALUES (1209, '{}', '{}');
INSERT INTO `furniture` VALUES (1210, '{}', '{}');
INSERT INTO `furniture` VALUES (1211, '{}', '{}');
INSERT INTO `furniture` VALUES (1212, '{}', '{}');
INSERT INTO `furniture` VALUES (1213, '{}', '{}');
INSERT INTO `furniture` VALUES (1214, '{}', '{}');
INSERT INTO `furniture` VALUES (1215, '{}', '{}');
INSERT INTO `furniture` VALUES (1216, '{}', '{}');
INSERT INTO `furniture` VALUES (1217, '{}', '{}');
INSERT INTO `furniture` VALUES (1218, '{}', '{}');
INSERT INTO `furniture` VALUES (1219, '{}', '{}');
INSERT INTO `furniture` VALUES (1220, '{}', '{}');
INSERT INTO `furniture` VALUES (1221, '{}', '{}');
INSERT INTO `furniture` VALUES (1222, '{}', '{}');
INSERT INTO `furniture` VALUES (1223, '{}', '{}');
INSERT INTO `furniture` VALUES (1224, '{}', '{}');
INSERT INTO `furniture` VALUES (1225, '{}', '{}');
INSERT INTO `furniture` VALUES (1226, '{}', '{}');
INSERT INTO `furniture` VALUES (1227, '{}', '{}');
INSERT INTO `furniture` VALUES (1228, '{}', '{}');
INSERT INTO `furniture` VALUES (1229, '{}', '{}');
INSERT INTO `furniture` VALUES (1230, '{}', '{}');
INSERT INTO `furniture` VALUES (1231, '{}', '{}');
INSERT INTO `furniture` VALUES (1232, '{}', '{}');
INSERT INTO `furniture` VALUES (1233, '{}', '{}');
INSERT INTO `furniture` VALUES (1234, '{}', '{}');
INSERT INTO `furniture` VALUES (1235, '{}', '{}');
INSERT INTO `furniture` VALUES (1236, '{}', '{}');
INSERT INTO `furniture` VALUES (1237, '{}', '{}');
INSERT INTO `furniture` VALUES (1238, '{}', '{}');
INSERT INTO `furniture` VALUES (1239, '{}', '{}');
INSERT INTO `furniture` VALUES (1240, '{}', '{}');
INSERT INTO `furniture` VALUES (1241, '{}', '{}');
INSERT INTO `furniture` VALUES (1242, '{}', '{}');
INSERT INTO `furniture` VALUES (1243, '{}', '{}');
INSERT INTO `furniture` VALUES (1244, '{}', '{}');
INSERT INTO `furniture` VALUES (1245, '{}', '{}');
INSERT INTO `furniture` VALUES (1246, '{}', '{}');
INSERT INTO `furniture` VALUES (1247, '{}', '{}');
INSERT INTO `furniture` VALUES (1248, '{}', '{}');
INSERT INTO `furniture` VALUES (1249, '{}', '{}');
INSERT INTO `furniture` VALUES (1250, '{}', '{}');
INSERT INTO `furniture` VALUES (1251, '{}', '{}');
INSERT INTO `furniture` VALUES (1252, '{}', '{}');
INSERT INTO `furniture` VALUES (1253, '{}', '{}');
INSERT INTO `furniture` VALUES (1254, '{}', '{}');
INSERT INTO `furniture` VALUES (1255, '{}', '{}');
INSERT INTO `furniture` VALUES (1256, '{}', '{}');
INSERT INTO `furniture` VALUES (1257, '{}', '{}');
INSERT INTO `furniture` VALUES (1258, '{}', '{}');
INSERT INTO `furniture` VALUES (1259, '{}', '{}');
INSERT INTO `furniture` VALUES (1260, '{}', '{}');
INSERT INTO `furniture` VALUES (1261, '{}', '{}');
INSERT INTO `furniture` VALUES (1262, '{}', '{}');
INSERT INTO `furniture` VALUES (1263, '{}', '{}');
INSERT INTO `furniture` VALUES (1264, '{}', '{}');
INSERT INTO `furniture` VALUES (1265, '{}', '{}');
INSERT INTO `furniture` VALUES (1266, '{}', '{}');
INSERT INTO `furniture` VALUES (1267, '{}', '{}');
INSERT INTO `furniture` VALUES (1268, '{}', '{}');
INSERT INTO `furniture` VALUES (1269, '{}', '{}');
INSERT INTO `furniture` VALUES (1270, '{}', '{}');
INSERT INTO `furniture` VALUES (1271, '{}', '{}');
INSERT INTO `furniture` VALUES (1272, '{}', '{}');
INSERT INTO `furniture` VALUES (1273, '{}', '{}');
INSERT INTO `furniture` VALUES (1274, '{}', '{}');
INSERT INTO `furniture` VALUES (1275, '{}', '{}');
INSERT INTO `furniture` VALUES (1276, '{}', '{}');
INSERT INTO `furniture` VALUES (1277, '{}', '{}');
INSERT INTO `furniture` VALUES (1278, '{}', '{}');
INSERT INTO `furniture` VALUES (1279, '{}', '{}');
INSERT INTO `furniture` VALUES (1280, '{}', '{}');
INSERT INTO `furniture` VALUES (1281, '{}', '{}');
INSERT INTO `furniture` VALUES (1282, '{}', '{}');
INSERT INTO `furniture` VALUES (1283, '{}', '{}');
INSERT INTO `furniture` VALUES (1284, '{}', '{}');
INSERT INTO `furniture` VALUES (1285, '{}', '{}');
INSERT INTO `furniture` VALUES (1286, '{}', '{}');
INSERT INTO `furniture` VALUES (1287, '{}', '{}');
INSERT INTO `furniture` VALUES (1288, '{}', '{}');
INSERT INTO `furniture` VALUES (1289, '{}', '{}');
INSERT INTO `furniture` VALUES (1290, '{}', '{}');
INSERT INTO `furniture` VALUES (1291, '{}', '{}');
INSERT INTO `furniture` VALUES (1292, '{}', '{}');
INSERT INTO `furniture` VALUES (1293, '{}', '{}');
INSERT INTO `furniture` VALUES (1294, '{}', '{}');
INSERT INTO `furniture` VALUES (1295, '{}', '{}');
INSERT INTO `furniture` VALUES (1296, '{}', '{}');
INSERT INTO `furniture` VALUES (1297, '{}', '{}');
INSERT INTO `furniture` VALUES (1298, '{}', '{}');
INSERT INTO `furniture` VALUES (1299, '{}', '{}');
INSERT INTO `furniture` VALUES (1300, '{}', '{}');
INSERT INTO `furniture` VALUES (1301, '{}', '{}');
INSERT INTO `furniture` VALUES (1302, '{}', '{}');
INSERT INTO `furniture` VALUES (1303, '{}', '{}');
INSERT INTO `furniture` VALUES (1304, '{}', '{}');
INSERT INTO `furniture` VALUES (1305, '{}', '{}');
INSERT INTO `furniture` VALUES (1306, '{}', '{}');
INSERT INTO `furniture` VALUES (1307, '{}', '{}');
INSERT INTO `furniture` VALUES (1308, '{}', '{}');
INSERT INTO `furniture` VALUES (1309, '{}', '{}');
INSERT INTO `furniture` VALUES (1310, '{}', '{}');
INSERT INTO `furniture` VALUES (1311, '{}', '{}');
INSERT INTO `furniture` VALUES (1312, '{}', '{}');
INSERT INTO `furniture` VALUES (1313, '{}', '{}');
INSERT INTO `furniture` VALUES (1314, '{}', '{}');
INSERT INTO `furniture` VALUES (1315, '{}', '{}');
INSERT INTO `furniture` VALUES (1316, '{}', '{}');
INSERT INTO `furniture` VALUES (1317, '{}', '{}');
INSERT INTO `furniture` VALUES (1318, '{}', '{}');
INSERT INTO `furniture` VALUES (1319, '{}', '{}');
INSERT INTO `furniture` VALUES (1320, '{}', '{}');
INSERT INTO `furniture` VALUES (1321, '{}', '{}');
INSERT INTO `furniture` VALUES (1322, '{}', '{}');
INSERT INTO `furniture` VALUES (1323, '{}', '{}');
INSERT INTO `furniture` VALUES (1324, '{}', '{}');
INSERT INTO `furniture` VALUES (1325, '{}', '{}');
INSERT INTO `furniture` VALUES (1326, '{}', '{}');
INSERT INTO `furniture` VALUES (1327, '{}', '{}');
INSERT INTO `furniture` VALUES (1328, '{}', '{}');
INSERT INTO `furniture` VALUES (1329, '{}', '{}');
INSERT INTO `furniture` VALUES (1330, '{}', '{}');
INSERT INTO `furniture` VALUES (1331, '{}', '{}');
INSERT INTO `furniture` VALUES (1332, '{}', '{}');
INSERT INTO `furniture` VALUES (1333, '{}', '{}');
INSERT INTO `furniture` VALUES (1334, '{}', '{}');
INSERT INTO `furniture` VALUES (1335, '{}', '{}');
INSERT INTO `furniture` VALUES (1336, '{}', '{}');
INSERT INTO `furniture` VALUES (1337, '{}', '{}');
INSERT INTO `furniture` VALUES (1338, '{}', '{}');
INSERT INTO `furniture` VALUES (1339, '{}', '{}');
INSERT INTO `furniture` VALUES (1340, '{}', '{}');
INSERT INTO `furniture` VALUES (1341, '{}', '{}');
INSERT INTO `furniture` VALUES (1342, '{}', '{}');
INSERT INTO `furniture` VALUES (1343, '{}', '{}');
INSERT INTO `furniture` VALUES (1344, '{}', '{}');
INSERT INTO `furniture` VALUES (1345, '{}', '{}');
INSERT INTO `furniture` VALUES (1346, '{}', '{}');
INSERT INTO `furniture` VALUES (1347, '{}', '{}');
INSERT INTO `furniture` VALUES (1348, '{}', '{}');
INSERT INTO `furniture` VALUES (1349, '{}', '{}');
INSERT INTO `furniture` VALUES (1350, '{}', '{}');
INSERT INTO `furniture` VALUES (1351, '{}', '{}');
INSERT INTO `furniture` VALUES (1352, '{}', '{}');
INSERT INTO `furniture` VALUES (1353, '{}', '{}');
INSERT INTO `furniture` VALUES (1354, '{}', '{}');
INSERT INTO `furniture` VALUES (1355, '{}', '{}');
INSERT INTO `furniture` VALUES (1356, '{}', '{}');
INSERT INTO `furniture` VALUES (1357, '{}', '{}');
INSERT INTO `furniture` VALUES (1358, '{}', '{}');
INSERT INTO `furniture` VALUES (1359, '{}', '{}');
INSERT INTO `furniture` VALUES (1360, '{}', '{}');
INSERT INTO `furniture` VALUES (1361, '{}', '{}');
INSERT INTO `furniture` VALUES (1362, '{}', '{}');
INSERT INTO `furniture` VALUES (1363, '{}', '{}');
INSERT INTO `furniture` VALUES (1364, '{}', '{}');
INSERT INTO `furniture` VALUES (1365, '{}', '{}');
INSERT INTO `furniture` VALUES (1366, '{}', '{}');
INSERT INTO `furniture` VALUES (1367, '{}', '{}');
INSERT INTO `furniture` VALUES (1368, '{}', '{}');
INSERT INTO `furniture` VALUES (1369, '{}', '{}');
INSERT INTO `furniture` VALUES (1370, '{}', '{}');
INSERT INTO `furniture` VALUES (1371, '{}', '{}');
INSERT INTO `furniture` VALUES (1372, '{}', '{}');
INSERT INTO `furniture` VALUES (1373, '{}', '{}');
INSERT INTO `furniture` VALUES (1374, '{}', '{}');
INSERT INTO `furniture` VALUES (1375, '{}', '{}');
INSERT INTO `furniture` VALUES (1376, '{}', '{}');
INSERT INTO `furniture` VALUES (1377, '{}', '{}');
INSERT INTO `furniture` VALUES (1378, '{}', '{}');
INSERT INTO `furniture` VALUES (1379, '{}', '{}');
INSERT INTO `furniture` VALUES (1380, '{}', '{}');
INSERT INTO `furniture` VALUES (1381, '{}', '{}');
INSERT INTO `furniture` VALUES (1382, '{}', '{}');
INSERT INTO `furniture` VALUES (1383, '{}', '{}');
INSERT INTO `furniture` VALUES (1384, '{}', '{}');
INSERT INTO `furniture` VALUES (1385, '{}', '{}');
INSERT INTO `furniture` VALUES (1386, '{}', '{}');
INSERT INTO `furniture` VALUES (1387, '{}', '{}');
INSERT INTO `furniture` VALUES (1388, '{}', '{}');
INSERT INTO `furniture` VALUES (1389, '{}', '{}');
INSERT INTO `furniture` VALUES (1390, '{}', '{}');
INSERT INTO `furniture` VALUES (1391, '{}', '{}');
INSERT INTO `furniture` VALUES (1392, '{}', '{}');
INSERT INTO `furniture` VALUES (1393, '{}', '{}');
INSERT INTO `furniture` VALUES (1394, '{}', '{}');
INSERT INTO `furniture` VALUES (1395, '{}', '{}');
INSERT INTO `furniture` VALUES (1396, '{}', '{}');
INSERT INTO `furniture` VALUES (1397, '{}', '{}');
INSERT INTO `furniture` VALUES (1398, '{}', '{}');
INSERT INTO `furniture` VALUES (1399, '{}', '{}');
INSERT INTO `furniture` VALUES (1400, '{}', '{}');
INSERT INTO `furniture` VALUES (1401, '{}', '{}');
INSERT INTO `furniture` VALUES (1402, '{}', '{}');
INSERT INTO `furniture` VALUES (1403, '{}', '{}');
INSERT INTO `furniture` VALUES (1404, '{}', '{}');
INSERT INTO `furniture` VALUES (1405, '{}', '{}');
INSERT INTO `furniture` VALUES (1406, '{}', '{}');
INSERT INTO `furniture` VALUES (1407, '{}', '{}');
INSERT INTO `furniture` VALUES (1408, '{}', '{}');
INSERT INTO `furniture` VALUES (1409, '{}', '{}');
INSERT INTO `furniture` VALUES (1410, '{}', '{}');
INSERT INTO `furniture` VALUES (1411, '{}', '{}');
INSERT INTO `furniture` VALUES (1412, '{}', '{}');
INSERT INTO `furniture` VALUES (1413, '{}', '{}');
INSERT INTO `furniture` VALUES (1414, '{}', '{}');
INSERT INTO `furniture` VALUES (1415, '{}', '{}');
INSERT INTO `furniture` VALUES (1416, '{}', '{}');
INSERT INTO `furniture` VALUES (1417, '{}', '{}');
INSERT INTO `furniture` VALUES (1418, '{}', '{}');
INSERT INTO `furniture` VALUES (1419, '{}', '{}');
INSERT INTO `furniture` VALUES (1420, '{}', '{}');

-- ----------------------------
-- Table structure for gangspoints
-- ----------------------------
DROP TABLE IF EXISTS `gangspoints`;
CREATE TABLE `gangspoints`  (
  `id` smallint NOT NULL,
  `gangid` tinyint NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of gangspoints
-- ----------------------------
INSERT INTO `gangspoints` VALUES (0, 4);
INSERT INTO `gangspoints` VALUES (1, 1);
INSERT INTO `gangspoints` VALUES (2, 4);
INSERT INTO `gangspoints` VALUES (3, 4);
INSERT INTO `gangspoints` VALUES (4, 4);
INSERT INTO `gangspoints` VALUES (5, 4);
INSERT INTO `gangspoints` VALUES (6, 4);
INSERT INTO `gangspoints` VALUES (7, 4);
INSERT INTO `gangspoints` VALUES (8, 4);
INSERT INTO `gangspoints` VALUES (9, 4);
INSERT INTO `gangspoints` VALUES (10, 4);
INSERT INTO `gangspoints` VALUES (11, 5);
INSERT INTO `gangspoints` VALUES (12, 4);
INSERT INTO `gangspoints` VALUES (13, 4);
INSERT INTO `gangspoints` VALUES (14, 4);
INSERT INTO `gangspoints` VALUES (15, 4);
INSERT INTO `gangspoints` VALUES (16, 4);
INSERT INTO `gangspoints` VALUES (17, 4);
INSERT INTO `gangspoints` VALUES (18, 4);
INSERT INTO `gangspoints` VALUES (19, 4);
INSERT INTO `gangspoints` VALUES (20, 4);
INSERT INTO `gangspoints` VALUES (21, 4);
INSERT INTO `gangspoints` VALUES (22, 4);
INSERT INTO `gangspoints` VALUES (23, 4);
INSERT INTO `gangspoints` VALUES (24, 4);
INSERT INTO `gangspoints` VALUES (25, 4);
INSERT INTO `gangspoints` VALUES (26, 4);
INSERT INTO `gangspoints` VALUES (27, 4);
INSERT INTO `gangspoints` VALUES (28, 4);
INSERT INTO `gangspoints` VALUES (29, 4);
INSERT INTO `gangspoints` VALUES (30, 4);
INSERT INTO `gangspoints` VALUES (31, 4);
INSERT INTO `gangspoints` VALUES (32, 4);
INSERT INTO `gangspoints` VALUES (33, 4);
INSERT INTO `gangspoints` VALUES (34, 4);
INSERT INTO `gangspoints` VALUES (35, 4);
INSERT INTO `gangspoints` VALUES (36, 2);
INSERT INTO `gangspoints` VALUES (37, 4);
INSERT INTO `gangspoints` VALUES (38, 4);
INSERT INTO `gangspoints` VALUES (39, 4);
INSERT INTO `gangspoints` VALUES (40, 4);
INSERT INTO `gangspoints` VALUES (41, 4);
INSERT INTO `gangspoints` VALUES (42, 4);
INSERT INTO `gangspoints` VALUES (43, 4);
INSERT INTO `gangspoints` VALUES (44, 4);
INSERT INTO `gangspoints` VALUES (45, 4);
INSERT INTO `gangspoints` VALUES (46, 4);
INSERT INTO `gangspoints` VALUES (47, 4);
INSERT INTO `gangspoints` VALUES (48, 4);
INSERT INTO `gangspoints` VALUES (49, 4);
INSERT INTO `gangspoints` VALUES (50, 4);
INSERT INTO `gangspoints` VALUES (51, 4);
INSERT INTO `gangspoints` VALUES (52, 4);
INSERT INTO `gangspoints` VALUES (53, 4);
INSERT INTO `gangspoints` VALUES (54, 4);
INSERT INTO `gangspoints` VALUES (55, 4);
INSERT INTO `gangspoints` VALUES (56, 4);
INSERT INTO `gangspoints` VALUES (57, 4);
INSERT INTO `gangspoints` VALUES (58, 4);
INSERT INTO `gangspoints` VALUES (59, 4);
INSERT INTO `gangspoints` VALUES (60, 4);
INSERT INTO `gangspoints` VALUES (61, 4);
INSERT INTO `gangspoints` VALUES (62, 4);
INSERT INTO `gangspoints` VALUES (63, 4);
INSERT INTO `gangspoints` VALUES (64, 4);
INSERT INTO `gangspoints` VALUES (65, 4);
INSERT INTO `gangspoints` VALUES (66, 4);
INSERT INTO `gangspoints` VALUES (67, 4);
INSERT INTO `gangspoints` VALUES (68, 4);
INSERT INTO `gangspoints` VALUES (69, 4);
INSERT INTO `gangspoints` VALUES (70, 4);
INSERT INTO `gangspoints` VALUES (71, 4);
INSERT INTO `gangspoints` VALUES (72, 4);
INSERT INTO `gangspoints` VALUES (73, 4);
INSERT INTO `gangspoints` VALUES (74, 4);
INSERT INTO `gangspoints` VALUES (75, 4);
INSERT INTO `gangspoints` VALUES (76, 4);
INSERT INTO `gangspoints` VALUES (77, 4);
INSERT INTO `gangspoints` VALUES (78, 4);
INSERT INTO `gangspoints` VALUES (79, 4);
INSERT INTO `gangspoints` VALUES (80, 4);
INSERT INTO `gangspoints` VALUES (81, 4);
INSERT INTO `gangspoints` VALUES (82, 4);
INSERT INTO `gangspoints` VALUES (83, 4);
INSERT INTO `gangspoints` VALUES (84, 4);
INSERT INTO `gangspoints` VALUES (85, 4);
INSERT INTO `gangspoints` VALUES (86, 4);
INSERT INTO `gangspoints` VALUES (87, 4);
INSERT INTO `gangspoints` VALUES (88, 4);
INSERT INTO `gangspoints` VALUES (89, 3);

-- ----------------------------
-- Table structure for garages
-- ----------------------------
DROP TABLE IF EXISTS `garages`;
CREATE TABLE `garages`  (
  `id` int NOT NULL,
  `type` int NOT NULL,
  `position` text CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `rotation` text CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of garages
-- ----------------------------
INSERT INTO `garages` VALUES (1, 0, '{\"x\":306.3308,\"y\":-2022.97266,\"z\":19.6641884}', '{\"x\":0.28919673,\"y\":1.22567761,\"z\":323.386475}');
INSERT INTO `garages` VALUES (2, 0, '{\"x\":308.8353,\"y\":-2024.99878,\"z\":19.7369423}', '{\"x\":1.06888866,\"y\":1.86222208,\"z\":320.153564}');
INSERT INTO `garages` VALUES (3, 0, '{\"x\":310.9863,\"y\":-2026.833,\"z\":19.8331432}', '{\"x\":0.183384642,\"y\":1.33615971,\"z\":318.941772}');
INSERT INTO `garages` VALUES (4, 0, '{\"x\":313.418121,\"y\":-2028.68054,\"z\":19.8751354}', '{\"x\":-0.408967763,\"y\":1.27423179,\"z\":320.255}');
INSERT INTO `garages` VALUES (5, 0, '{\"x\":315.613129,\"y\":-2030.99768,\"z\":19.908802}', '{\"x\":-0.3189787,\"y\":1.16797006,\"z\":321.3879}');
INSERT INTO `garages` VALUES (6, 0, '{\"x\":318.153717,\"y\":-2032.72278,\"z\":19.946291}', '{\"x\":-0.861367643,\"y\":1.51783919,\"z\":321.728424}');
INSERT INTO `garages` VALUES (7, 0, '{\"x\":320.338165,\"y\":-2034.82373,\"z\":19.9719162}', '{\"x\":-1.13484228,\"y\":1.58200169,\"z\":323.152039}');
INSERT INTO `garages` VALUES (8, 0, '{\"x\":322.261017,\"y\":-2036.68115,\"z\":19.99203}', '{\"x\":-1.19117165,\"y\":1.60068321,\"z\":319.796173}');
INSERT INTO `garages` VALUES (9, 0, '{\"x\":324.517639,\"y\":-2038.71912,\"z\":20.0285625}', '{\"x\":-1.0797,\"y\":2.114232,\"z\":318.8557}');
INSERT INTO `garages` VALUES (10, 0, '{\"x\":326.9625,\"y\":-2040.42468,\"z\":20.0917721}', '{\"x\":-1.14468527,\"y\":2.22789121,\"z\":320.267822}');
INSERT INTO `garages` VALUES (11, 0, '{\"x\":329.635864,\"y\":-2042.15515,\"z\":20.1467438}', '{\"x\":-1.620252,\"y\":1.97530138,\"z\":322.061584}');
INSERT INTO `garages` VALUES (12, 0, '{\"x\":331.873871,\"y\":-2044.58044,\"z\":20.1528625}', '{\"x\":-2.22251964,\"y\":1.94977212,\"z\":323.346252}');
INSERT INTO `garages` VALUES (13, 0, '{\"x\":337.235382,\"y\":-2036.19043,\"z\":20.6593723}', '{\"x\":-2.74894452,\"y\":4.157428,\"z\":50.4411}');
INSERT INTO `garages` VALUES (14, 0, '{\"x\":332.349518,\"y\":-2031.36267,\"z\":20.5320721}', '{\"x\":-2.57961249,\"y\":3.56527781,\"z\":142.436981}');
INSERT INTO `garages` VALUES (15, 0, '{\"x\":330.096741,\"y\":-2029.56934,\"z\":20.4761944}', '{\"x\":-2.0694766,\"y\":3.20174432,\"z\":141.220428}');
INSERT INTO `garages` VALUES (16, 0, '{\"x\":327.83963,\"y\":-2027.4762,\"z\":20.410532}', '{\"x\":-1.88560247,\"y\":3.52513337,\"z\":138.358643}');
INSERT INTO `garages` VALUES (17, 0, '{\"x\":325.487366,\"y\":-2025.57629,\"z\":20.32554}', '{\"x\":-1.64253938,\"y\":3.78871322,\"z\":138.910278}');
INSERT INTO `garages` VALUES (18, 0, '{\"x\":323.442871,\"y\":-2023.77478,\"z\":20.240221}', '{\"x\":-1.5254786,\"y\":3.74738765,\"z\":141.045959}');
INSERT INTO `garages` VALUES (19, 0, '{\"x\":321.320343,\"y\":-2021.936,\"z\":20.154644}', '{\"x\":-1.5038389,\"y\":3.39848781,\"z\":139.221069}');
INSERT INTO `garages` VALUES (20, 0, '{\"x\":318.789368,\"y\":-2019.561,\"z\":20.077467}', '{\"x\":-1.89252675,\"y\":3.71154356,\"z\":140.796814}');
INSERT INTO `garages` VALUES (21, 0, '{\"x\":316.229034,\"y\":-2017.77246,\"z\":19.9434}', '{\"x\":-0.7808737,\"y\":3.98979783,\"z\":142.484863}');
INSERT INTO `garages` VALUES (22, 5, '{\"x\":-720.073059,\"y\":77.06146,\"z\":55.187767}', '{\"x\":-0.0349616669,\"y\":0.0018839445,\"z\":24.11026}');
INSERT INTO `garages` VALUES (23, 5, '{\"x\":-839.5977,\"y\":115.562653,\"z\":54.7263641}', '{\"x\":-0.868290544,\"y\":-1.03349531,\"z\":185.059448}');
INSERT INTO `garages` VALUES (24, 5, '{\"x\":-1284.41028,\"y\":645.960938,\"z\":138.672791}', '{\"x\":-9.029148,\"y\":-1.20455337,\"z\":192.367523}');
INSERT INTO `garages` VALUES (25, 0, '{\"x\":249.21608,\"y\":-2045.05457,\"z\":17.2363777}', '{\"x\":-1.799938,\"y\":-1.747228,\"z\":228.752121}');
INSERT INTO `garages` VALUES (26, 0, '{\"x\":245.993744,\"y\":-2034.65686,\"z\":17.6080589}', '{\"x\":-1.00205374,\"y\":-0.8073587,\"z\":230.445251}');
INSERT INTO `garages` VALUES (27, 0, '{\"x\":271.0536,\"y\":-2015.42615,\"z\":18.6916027}', '{\"x\":-4.06587648,\"y\":1.38689816,\"z\":228.800323}');
INSERT INTO `garages` VALUES (28, 0, '{\"x\":282.9607,\"y\":-2004.2887,\"z\":19.5377674}', '{\"x\":-1.02644587,\"y\":0.678154469,\"z\":231.920517}');
INSERT INTO `garages` VALUES (29, 0, '{\"x\":285.727478,\"y\":-1985.20972,\"z\":20.488102}', '{\"x\":-1.7765857,\"y\":1.48308778,\"z\":229.842743}');
INSERT INTO `garages` VALUES (30, 0, '{\"x\":297.630249,\"y\":-1976.62354,\"z\":21.6905155}', '{\"x\":-0.7729907,\"y\":-1.39846814,\"z\":229.27742}');
INSERT INTO `garages` VALUES (31, 0, '{\"x\":312.766754,\"y\":-1968.02075,\"z\":22.8737774}', '{\"x\":-3.91278315,\"y\":2.41042948,\"z\":227.295959}');
INSERT INTO `garages` VALUES (32, 0, '{\"x\":318.031738,\"y\":-1945.0249,\"z\":23.9743843}', '{\"x\":-0.02894735,\"y\":0.0252609439,\"z\":230.088379}');
INSERT INTO `garages` VALUES (33, 5, '{\"x\":-671.367,\"y\":911.0317,\"z\":229.662338}', '{\"x\":-3.53258061,\"y\":-5.238803,\"z\":322.197418}');
INSERT INTO `garages` VALUES (34, 5, '{\"x\":-720.0269,\"y\":77.20651,\"z\":55.1878967}', '{\"x\":-0.051017,\"y\":0.000413143222,\"z\":22.6382751}');
INSERT INTO `garages` VALUES (35, 0, '{\"x\":363.735046,\"y\":-1902.79248,\"z\":24.106842}', '{\"x\":-1.12205279,\"y\":0.323424518,\"z\":226.161957}');
INSERT INTO `garages` VALUES (36, 0, '{\"x\":387.1604,\"y\":-1892.97693,\"z\":24.4496956}', '{\"x\":-3.121445,\"y\":-0.2529854,\"z\":222.302414}');
INSERT INTO `garages` VALUES (37, 0, '{\"x\":397.689148,\"y\":-1875.31616,\"z\":25.54629}', '{\"x\":2.81966186,\"y\":-1.745343,\"z\":224.632813}');
INSERT INTO `garages` VALUES (38, 0, '{\"x\":407.1065,\"y\":-1862.09375,\"z\":26.13337}', '{\"x\":-2.31543159,\"y\":2.31594276,\"z\":225.369492}');
INSERT INTO `garages` VALUES (39, 0, '{\"x\":427.972015,\"y\":-1852.81274,\"z\":26.8568}', '{\"x\":-3.22140026,\"y\":-0.4109345,\"z\":227.224609}');
INSERT INTO `garages` VALUES (40, 0, '{\"x\":435.3803,\"y\":-1835.29211,\"z\":27.3125172}', '{\"x\":0.0447110273,\"y\":0.0262333378,\"z\":223.739777}');
INSERT INTO `garages` VALUES (41, -1, '{\"x\":1320.19592,\"y\":-1542.74219,\"z\":49.6629143}', '{\"x\":2.497576,\"y\":8.364815,\"z\":286.366547}');
INSERT INTO `garages` VALUES (42, -1, '{\"x\":1336.82507,\"y\":-1548.56323,\"z\":52.15735}', '{\"x\":7.192618,\"y\":6.485021,\"z\":40.60083}');
INSERT INTO `garages` VALUES (43, -1, '{\"x\":1335.77185,\"y\":-1537.84985,\"z\":51.5434761}', '{\"x\":2.162478,\"y\":5.68301,\"z\":267.791931}');
INSERT INTO `garages` VALUES (44, -1, '{\"x\":1357.69617,\"y\":-1543.89954,\"z\":53.9452324}', '{\"x\":-4.859586,\"y\":5.43450737,\"z\":285.00235}');
INSERT INTO `garages` VALUES (45, -1, '{\"x\":1372.50415,\"y\":-1520.87134,\"z\":56.63756}', '{\"x\":-7.509435,\"y\":-1.7256465,\"z\":198.060974}');
INSERT INTO `garages` VALUES (46, -1, '{\"x\":1381.08618,\"y\":-1534.58813,\"z\":56.05348}', '{\"x\":-2.37047315,\"y\":2.66947579,\"z\":112.165131}');
INSERT INTO `garages` VALUES (47, 5, '{\"x\":-1578.539,\"y\":-81.304184,\"z\":53.014492}', '{\"x\":0.0,\"y\":0.0,\"z\":271.9421}');
INSERT INTO `garages` VALUES (48, 5, '{\"x\":-2597.154,\"y\":1929.70508,\"z\":166.639267}', '{\"x\":0.263080865,\"y\":-0.146755368,\"z\":276.5194}');
INSERT INTO `garages` VALUES (51, 0, '{\"x\":486.0619,\"y\":-1825.51392,\"z\":27.5278625}', '{\"x\":5.12384129,\"y\":7.42071438,\"z\":51.6329651}');
INSERT INTO `garages` VALUES (52, 2, '{\"x\":1272.68079,\"y\":-1609.693,\"z\":53.40714}', '{\"x\":2.662431,\"y\":1.80316436,\"z\":34.05356}');
INSERT INTO `garages` VALUES (53, 0, '{\"x\":1272.53833,\"y\":-1609.09155,\"z\":53.3752975}', '{\"x\":2.94997621,\"y\":2.25117755,\"z\":31.6286926}');
INSERT INTO `garages` VALUES (54, 0, '{\"x\":1255.319,\"y\":-1624.02942,\"z\":52.6687469}', '{\"x\":-1.62896574,\"y\":0.548742235,\"z\":33.5834045}');
INSERT INTO `garages` VALUES (55, 0, '{\"x\":1237.46191,\"y\":-1632.59436,\"z\":51.34475}', '{\"x\":2.38310885,\"y\":1.92086911,\"z\":32.8804932}');
INSERT INTO `garages` VALUES (56, 0, '{\"x\":1226.87927,\"y\":-1602.90088,\"z\":51.2316628}', '{\"x\":-5.16306067,\"y\":1.93204129,\"z\":216.002884}');
INSERT INTO `garages` VALUES (57, 0, '{\"x\":1215.04651,\"y\":-1620.75391,\"z\":47.6456337}', '{\"x\":-2.50345635,\"y\":8.589683,\"z\":120.030243}');
INSERT INTO `garages` VALUES (58, 0, '{\"x\":1211.72021,\"y\":-1632.84338,\"z\":46.2046165}', '{\"x\":-6.576692,\"y\":6.93613243,\"z\":117.994812}');
INSERT INTO `garages` VALUES (59, 0, '{\"x\":1197.08667,\"y\":-1631.97278,\"z\":43.60098}', '{\"x\":-3.58387756,\"y\":13.21006,\"z\":120.129852}');
INSERT INTO `garages` VALUES (60, 0, '{\"x\":1190.59778,\"y\":-1645.99109,\"z\":40.97751}', '{\"x\":-7.44967461,\"y\":10.9841528,\"z\":125.791046}');
INSERT INTO `garages` VALUES (61, 0, '{\"x\":1255.62427,\"y\":-1748.72913,\"z\":47.4014244}', '{\"x\":-7.51972675,\"y\":8.056554,\"z\":116.880066}');
INSERT INTO `garages` VALUES (62, 0, '{\"x\":1257.42224,\"y\":-1742.14526,\"z\":48.2755127}', '{\"x\":-3.153002,\"y\":9.777723,\"z\":115.285553}');
INSERT INTO `garages` VALUES (63, 0, '{\"x\":1303.05994,\"y\":-1742.25525,\"z\":53.178997}', '{\"x\":-0.0253155921,\"y\":-0.00386442267,\"z\":22.0980835}');
INSERT INTO `garages` VALUES (64, 0, '{\"x\":1302.38989,\"y\":-1706.38025,\"z\":54.40888}', '{\"x\":-0.853291333,\"y\":1.66952026,\"z\":201.106125}');
INSERT INTO `garages` VALUES (65, 0, '{\"x\":1331.50928,\"y\":-1735.23877,\"z\":55.48606}', '{\"x\":1.59788787,\"y\":4.67061138,\"z\":20.12738}');
INSERT INTO `garages` VALUES (66, 0, '{\"x\":1330.642,\"y\":-1707.98022,\"z\":55.4928246}', '{\"x\":0.9193066,\"y\":7.688298,\"z\":108.542572}');
INSERT INTO `garages` VALUES (67, 0, '{\"x\":1357.75989,\"y\":-1701.55432,\"z\":59.78902}', '{\"x\":5.958617,\"y\":9.955576,\"z\":281.9417}');
INSERT INTO `garages` VALUES (68, 0, '{\"x\":1366.08057,\"y\":-1706.30029,\"z\":61.4777832}', '{\"x\":2.612745,\"y\":8.462314,\"z\":284.3271}');
INSERT INTO `garages` VALUES (69, 0, '{\"x\":338.689423,\"y\":-207.432449,\"z\":53.3860626}', '{\"x\":-0.0286574066,\"y\":-0.03321916,\"z\":69.03137}');
INSERT INTO `garages` VALUES (70, 0, '{\"x\":337.073059,\"y\":-210.549728,\"z\":53.3860779}', '{\"x\":-0.03045334,\"y\":-0.0234385915,\"z\":69.27985}');
INSERT INTO `garages` VALUES (71, 0, '{\"x\":335.2934,\"y\":-213.683731,\"z\":53.38689}', '{\"x\":-0.0366404019,\"y\":-0.0370753855,\"z\":69.57056}');
INSERT INTO `garages` VALUES (72, 0, '{\"x\":334.5663,\"y\":-216.910034,\"z\":53.3857155}', '{\"x\":-0.00981767,\"y\":-0.06480524,\"z\":68.26727}');
INSERT INTO `garages` VALUES (73, 0, '{\"x\":318.0429,\"y\":-199.75856,\"z\":53.3864365}', '{\"x\":0.0244453438,\"y\":0.0337880068,\"z\":248.865631}');
INSERT INTO `garages` VALUES (74, 0, '{\"x\":316.369446,\"y\":-202.847244,\"z\":53.3859444}', '{\"x\":0.0113720419,\"y\":0.0351227932,\"z\":250.714386}');
INSERT INTO `garages` VALUES (75, 0, '{\"x\":316.3564,\"y\":-206.328278,\"z\":53.3868828}', '{\"x\":0.008085202,\"y\":-0.008400725,\"z\":249.9972}');
INSERT INTO `garages` VALUES (76, -1, '{\"x\":884.4358,\"y\":2857.17432,\"z\":55.9393044}', '{\"x\":0.8850095,\"y\":-2.008708,\"z\":135.350952}');
INSERT INTO `garages` VALUES (77, 0, '{\"x\":314.4841,\"y\":-209.319763,\"z\":53.386692}', '{\"x\":0.006119401,\"y\":-0.0142939324,\"z\":250.13681}');
INSERT INTO `garages` VALUES (78, 0, '{\"x\":299.4307,\"y\":-235.421234,\"z\":53.2754021}', '{\"x\":2.00261474,\"y\":-0.5240554,\"z\":5.993408}');
INSERT INTO `garages` VALUES (79, 0, '{\"x\":294.9674,\"y\":-233.501144,\"z\":53.2645149}', '{\"x\":2.30583048,\"y\":-0.8914507,\"z\":16.9040833}');
INSERT INTO `garages` VALUES (80, 0, '{\"x\":289.138184,\"y\":-231.330475,\"z\":53.2630157}', '{\"x\":2.38933349,\"y\":-0.734292746,\"z\":10.6377258}');
INSERT INTO `garages` VALUES (81, 0, '{\"x\":283.8979,\"y\":-229.5558,\"z\":53.264492}', '{\"x\":2.16082239,\"y\":-0.8021306,\"z\":10.9349976}');
INSERT INTO `garages` VALUES (82, 0, '{\"x\":278.4013,\"y\":-227.42569,\"z\":53.25782}', '{\"x\":2.26965976,\"y\":-0.7527467,\"z\":12.1389465}');
INSERT INTO `garages` VALUES (83, 0, '{\"x\":273.6913,\"y\":-225.658768,\"z\":53.25429}', '{\"x\":2.241158,\"y\":-0.737162232,\"z\":12.3921509}');
INSERT INTO `garages` VALUES (84, 0, '{\"x\":325.165649,\"y\":-202.968353,\"z\":53.3859367}', '{\"x\":0.0255312733,\"y\":0.011880585,\"z\":158.718689}');
INSERT INTO `garages` VALUES (85, 0, '{\"x\":331.028,\"y\":-204.88118,\"z\":53.3859978}', '{\"x\":0.03445293,\"y\":-0.0247219913,\"z\":161.260132}');
INSERT INTO `garages` VALUES (86, 0, '{\"x\":318.888062,\"y\":-215.542542,\"z\":53.386158}', '{\"x\":0.0157712717,\"y\":-0.0133516146,\"z\":201.226166}');
INSERT INTO `garages` VALUES (87, 0, '{\"x\":326.713837,\"y\":-219.5422,\"z\":53.3864}', '{\"x\":0.0113845831,\"y\":0.005491041,\"z\":121.897}');
INSERT INTO `garages` VALUES (88, 0, '{\"x\":464.3061,\"y\":227.01976,\"z\":102.495689}', '{\"x\":-1.03883469,\"y\":0.410801917,\"z\":248.234161}');
INSERT INTO `garages` VALUES (89, 0, '{\"x\":465.795441,\"y\":230.5596,\"z\":102.509552}', '{\"x\":-0.00146061834,\"y\":0.0379303843,\"z\":251.550613}');
INSERT INTO `garages` VALUES (90, 0, '{\"x\":467.289429,\"y\":234.39267,\"z\":102.509796}', '{\"x\":0.012947293,\"y\":0.0241468,\"z\":249.4003}');
INSERT INTO `garages` VALUES (91, 0, '{\"x\":468.584747,\"y\":238.6321,\"z\":102.510727}', '{\"x\":-0.0213605464,\"y\":-0.07618909,\"z\":250.546051}');
INSERT INTO `garages` VALUES (92, 0, '{\"x\":469.8492,\"y\":242.338242,\"z\":102.509682}', '{\"x\":0.0169439986,\"y\":0.00245638634,\"z\":248.038025}');
INSERT INTO `garages` VALUES (93, 0, '{\"x\":471.330231,\"y\":246.1607,\"z\":102.510048}', '{\"x\":0.0194613244,\"y\":0.0313623659,\"z\":250.761963}');
INSERT INTO `garages` VALUES (94, 0, '{\"x\":472.697174,\"y\":250.188782,\"z\":102.510742}', '{\"x\":-0.0102892295,\"y\":0.00576520246,\"z\":252.381592}');
INSERT INTO `garages` VALUES (95, 0, '{\"x\":473.932159,\"y\":254.084564,\"z\":102.508713}', '{\"x\":0.121276908,\"y\":-0.0109282611,\"z\":251.2284}');
INSERT INTO `garages` VALUES (96, 0, '{\"x\":475.470734,\"y\":258.04422,\"z\":102.479584}', '{\"x\":0.5845486,\"y\":0.17094247,\"z\":249.9827}');
INSERT INTO `garages` VALUES (97, 0, '{\"x\":458.610443,\"y\":264.922,\"z\":102.492485}', '{\"x\":-0.1277766,\"y\":-0.300711185,\"z\":251.122742}');
INSERT INTO `garages` VALUES (98, 0, '{\"x\":457.78125,\"y\":261.181183,\"z\":102.503365}', '{\"x\":0.365515649,\"y\":-0.12888433,\"z\":249.344452}');
INSERT INTO `garages` VALUES (99, 0, '{\"x\":456.218475,\"y\":257.097443,\"z\":102.50914}', '{\"x\":0.0102523761,\"y\":0.0249551032,\"z\":250.643555}');
INSERT INTO `garages` VALUES (100, 0, '{\"x\":455.257324,\"y\":253.469025,\"z\":102.509}', '{\"x\":0.0119437166,\"y\":-0.00105391315,\"z\":252.003769}');
INSERT INTO `garages` VALUES (101, 0, '{\"x\":453.5889,\"y\":249.668015,\"z\":102.508629}', '{\"x\":0.00175176514,\"y\":0.045195926,\"z\":249.74588}');
INSERT INTO `garages` VALUES (102, 0, '{\"x\":451.9187,\"y\":246.041687,\"z\":102.509727}', '{\"x\":0.0119487839,\"y\":0.05059236,\"z\":251.440155}');
INSERT INTO `garages` VALUES (103, 0, '{\"x\":450.586975,\"y\":241.768036,\"z\":102.53981}', '{\"x\":2.47902226,\"y\":0.3897109,\"z\":249.321243}');
INSERT INTO `garages` VALUES (104, 0, '{\"x\":461.5311,\"y\":218.980057,\"z\":102.399963}', '{\"x\":-0.07675684,\"y\":0.0557640344,\"z\":251.183563}');
INSERT INTO `garages` VALUES (105, 0, '{\"x\":1245.33569,\"y\":-578.3461,\"z\":68.6225052}', '{\"x\":-1.43313062,\"y\":-1.58510745,\"z\":268.80954}');
INSERT INTO `garages` VALUES (106, 0, '{\"x\":1087.624,\"y\":-494.912018,\"z\":64.11845}', '{\"x\":0.7972066,\"y\":7.671755,\"z\":77.98639}');
INSERT INTO `garages` VALUES (107, 0, '{\"x\":1099.60217,\"y\":-473.4788,\"z\":66.23935}', '{\"x\":-0.0697012,\"y\":-0.04404292,\"z\":258.1921}');
INSERT INTO `garages` VALUES (108, 0, '{\"x\":1247.68262,\"y\":-585.9273,\"z\":68.4728546}', '{\"x\":-0.223666325,\"y\":-2.24953246,\"z\":268.508667}');
INSERT INTO `garages` VALUES (109, 0, '{\"x\":1100.55823,\"y\":-429.046143,\"z\":66.69184}', '{\"x\":-0.0126298852,\"y\":0.0187053755,\"z\":263.178772}');
INSERT INTO `garages` VALUES (110, 0, '{\"x\":1102.534,\"y\":-418.798,\"z\":66.45352}', '{\"x\":-0.206143469,\"y\":-0.00196203124,\"z\":266.1228}');
INSERT INTO `garages` VALUES (111, 0, '{\"x\":1253.264,\"y\":-624.618347,\"z\":68.68353}', '{\"x\":-0.109507367,\"y\":0.026978014,\"z\":296.07193}');
INSERT INTO `garages` VALUES (112, 1, '{\"x\":1103.13269,\"y\":-418.732544,\"z\":66.45389}', '{\"x\":-0.2228218,\"y\":-0.00367670413,\"z\":266.5146}');
INSERT INTO `garages` VALUES (113, 1, '{\"x\":1109.57153,\"y\":-400.587036,\"z\":67.38448}', '{\"x\":-2.59004927,\"y\":1.42168164,\"z\":259.771057}');
INSERT INTO `garages` VALUES (114, 1, '{\"x\":1100.66321,\"y\":-429.2656,\"z\":66.69355}', '{\"x\":-0.012686356,\"y\":-0.09285552,\"z\":265.705933}');
INSERT INTO `garages` VALUES (115, 0, '{\"x\":1272.4552,\"y\":-658.3094,\"z\":67.0632858}', '{\"x\":-1.0834645,\"y\":-0.8362635,\"z\":294.050354}');
INSERT INTO `garages` VALUES (116, 1, '{\"x\":1100.71887,\"y\":-473.4664,\"z\":66.23889}', '{\"x\":-0.04933191,\"y\":0.08591936,\"z\":257.960449}');
INSERT INTO `garages` VALUES (117, 1, '{\"x\":1087.575,\"y\":-494.790955,\"z\":64.1101761}', '{\"x\":0.640300453,\"y\":8.050416,\"z\":258.181641}');
INSERT INTO `garages` VALUES (118, 0, '{\"x\":1278.128,\"y\":-672.383545,\"z\":65.3826752}', '{\"x\":-2.497266,\"y\":2.76653433,\"z\":273.8769}');
INSERT INTO `garages` VALUES (119, 1, '{\"x\":1049.65833,\"y\":-488.216858,\"z\":63.2258949}', '{\"x\":0.0884470344,\"y\":-0.07090199,\"z\":79.46625}');
INSERT INTO `garages` VALUES (120, 0, '{\"x\":1262.52576,\"y\":-715.3399,\"z\":63.8376961}', '{\"x\":-1.82200146,\"y\":0.5446887,\"z\":239.033447}');
INSERT INTO `garages` VALUES (121, 1, '{\"x\":1047.24866,\"y\":-481.314362,\"z\":63.2209}', '{\"x\":0.040182095,\"y\":0.009386889,\"z\":80.04773}');
INSERT INTO `garages` VALUES (122, 1, '{\"x\":1055.60083,\"y\":-444.283356,\"z\":65.26678}', '{\"x\":-0.007669042,\"y\":-0.0148725687,\"z\":79.36035}');
INSERT INTO `garages` VALUES (123, 1, '{\"x\":1021.70935,\"y\":-463.710754,\"z\":63.202404}', '{\"x\":-0.0230655838,\"y\":0.0980145261,\"z\":215.519272}');
INSERT INTO `garages` VALUES (124, 1, '{\"x\":1225.14526,\"y\":-725.610168,\"z\":59.9280968}', '{\"x\":-0.557817161,\"y\":1.17124367,\"z\":183.269135}');
INSERT INTO `garages` VALUES (125, 0, '{\"x\":1021.70935,\"y\":-463.7108,\"z\":63.2025337}', '{\"x\":-0.0286171064,\"y\":0.0840764344,\"z\":215.519}');
INSERT INTO `garages` VALUES (126, 0, '{\"x\":960.349,\"y\":-500.281616,\"z\":60.6045227}', '{\"x\":3.1479156,\"y\":7.80949831,\"z\":37.1507568}');
INSERT INTO `garages` VALUES (127, 1, '{\"x\":1219.66809,\"y\":-704.4649,\"z\":59.90569}', '{\"x\":-1.34009778,\"y\":4.927871,\"z\":97.95355}');
INSERT INTO `garages` VALUES (128, 0, '{\"x\":949.1304,\"y\":-514.953,\"z\":59.53536}', '{\"x\":0.03486505,\"y\":0.266992539,\"z\":208.348389}');
INSERT INTO `garages` VALUES (129, 0, '{\"x\":918.6786,\"y\":-528.3561,\"z\":58.5049}', '{\"x\":-0.4046844,\"y\":0.354094982,\"z\":204.115372}');
INSERT INTO `garages` VALUES (130, 1, '{\"x\":1216.80078,\"y\":-665.1646,\"z\":62.18194}', '{\"x\":-0.0494381972,\"y\":4.03767252,\"z\":100.704285}');
INSERT INTO `garages` VALUES (131, 1, '{\"x\":918.679138,\"y\":-528.355652,\"z\":58.502}', '{\"x\":-0.332031846,\"y\":0.391545147,\"z\":204.100159}');
INSERT INTO `garages` VALUES (132, 1, '{\"x\":893.5571,\"y\":-550.0491,\"z\":57.4259262}', '{\"x\":0.06382326,\"y\":-0.003048866,\"z\":118.843445}');
INSERT INTO `garages` VALUES (133, 1, '{\"x\":1200.7666,\"y\":-612.714,\"z\":64.62527}', '{\"x\":-3.38694143,\"y\":19.4603348,\"z\":94.04059}');
INSERT INTO `garages` VALUES (134, 1, '{\"x\":925.1945,\"y\":-564.265137,\"z\":57.266758}', '{\"x\":0.0514621958,\"y\":-0.0775566,\"z\":25.7148743}');
INSERT INTO `garages` VALUES (135, 1, '{\"x\":1190.0177,\"y\":-597.2199,\"z\":63.3016319}', '{\"x\":-0.8304979,\"y\":1.43844318,\"z\":97.59369}');
INSERT INTO `garages` VALUES (136, 1, '{\"x\":954.8513,\"y\":-546.8967,\"z\":58.66506}', '{\"x\":0.285051674,\"y\":0.184990034,\"z\":26.7031555}');
INSERT INTO `garages` VALUES (137, 1, '{\"x\":1187.46985,\"y\":-570.1218,\"z\":63.6670761}', '{\"x\":-0.695391536,\"y\":1.2029618,\"z\":91.9111938}');
INSERT INTO `garages` VALUES (138, 0, '{\"x\":978.391968,\"y\":-527.1095,\"z\":59.4197426}', '{\"x\":0.07711594,\"y\":-0.245876908,\"z\":28.5651855}');
INSERT INTO `garages` VALUES (139, 0, '{\"x\":955.0326,\"y\":-547.1715,\"z\":58.6671448}', '{\"x\":0.3169186,\"y\":0.140928552,\"z\":31.6431885}');
INSERT INTO `garages` VALUES (140, 0, '{\"x\":1002.30475,\"y\":-512.4376,\"z\":59.9951324}', '{\"x\":0.114781208,\"y\":0.0120711252,\"z\":25.51538}');
INSERT INTO `garages` VALUES (141, 1, '{\"x\":1189.23877,\"y\":-554.4206,\"z\":63.92257}', '{\"x\":-0.287544429,\"y\":1.57268691,\"z\":87.13931}');
INSERT INTO `garages` VALUES (142, 0, '{\"x\":1007.61505,\"y\":-562.4639,\"z\":59.5006065}', '{\"x\":0.07054026,\"y\":-0.06311035,\"z\":81.08258}');
INSERT INTO `garages` VALUES (143, 0, '{\"x\":1252.20007,\"y\":-522.886658,\"z\":68.31953}', '{\"x\":-0.6192333,\"y\":0.493680745,\"z\":256.132874}');
INSERT INTO `garages` VALUES (144, 0, '{\"x\":1006.17493,\"y\":-588.7831,\"z\":58.42779}', '{\"x\":-0.868751168,\"y\":-0.47154817,\"z\":78.5694}');
INSERT INTO `garages` VALUES (145, 0, '{\"x\":1254.93445,\"y\":-490.975067,\"z\":68.7808762}', '{\"x\":-0.0389284529,\"y\":-2.36447716,\"z\":256.169159}');
INSERT INTO `garages` VALUES (146, 0, '{\"x\":977.916138,\"y\":-617.5301,\"z\":58.1444931}', '{\"x\":0.270840168,\"y\":0.179828733,\"z\":303.311768}');
INSERT INTO `garages` VALUES (147, 1, '{\"x\":977.916138,\"y\":-617.5301,\"z\":58.1444931}', '{\"x\":0.270840168,\"y\":0.179828733,\"z\":303.311768}');
INSERT INTO `garages` VALUES (148, 0, '{\"x\":977.197632,\"y\":-618.0029,\"z\":58.14552}', '{\"x\":0.163959026,\"y\":0.1741228,\"z\":303.308319}');
INSERT INTO `garages` VALUES (149, 0, '{\"x\":1279.20935,\"y\":-474.976685,\"z\":68.28411}', '{\"x\":0.50531733,\"y\":2.07106447,\"z\":167.854736}');
INSERT INTO `garages` VALUES (150, 0, '{\"x\":957.4825,\"y\":-602.5785,\"z\":58.67886}', '{\"x\":-0.0483961925,\"y\":0.0424351655,\"z\":26.1150818}');
INSERT INTO `garages` VALUES (151, 0, '{\"x\":971.1037,\"y\":-583.8947,\"z\":58.57815}', '{\"x\":0.804914951,\"y\":-0.39390558,\"z\":33.0009766}');
INSERT INTO `garages` VALUES (152, 0, '{\"x\":1273.89978,\"y\":-452.3247,\"z\":68.5728149}', '{\"x\":0.234122232,\"y\":-5.891609,\"z\":272.6256}');
INSERT INTO `garages` VALUES (153, 0, '{\"x\":1264.853,\"y\":-417.2029,\"z\":68.43116}', '{\"x\":0.7356279,\"y\":-0.8158244,\"z\":302.409637}');
INSERT INTO `garages` VALUES (154, 1, '{\"x\":1006.213,\"y\":-732.2785,\"z\":56.875145}', '{\"x\":-1.90030444,\"y\":3.15926361,\"z\":312.7031}');
INSERT INTO `garages` VALUES (155, 1, '{\"x\":977.8475,\"y\":-712.8274,\"z\":57.08815}', '{\"x\":1.30915117,\"y\":-1.05340958,\"z\":132.510864}');
INSERT INTO `garages` VALUES (156, 2, '{\"x\":1295.64783,\"y\":-567.1588,\"z\":70.5048447}', '{\"x\":5.10433531,\"y\":2.381178,\"z\":344.5135}');
INSERT INTO `garages` VALUES (157, 1, '{\"x\":971.800232,\"y\":-686.5727,\"z\":57.0930977}', '{\"x\":1.90412974,\"y\":-4.43482971,\"z\":308.015045}');
INSERT INTO `garages` VALUES (158, 1, '{\"x\":942.749146,\"y\":-670.8171,\"z\":57.3117676}', '{\"x\":0.0249165781,\"y\":-0.0234176032,\"z\":118.263824}');
INSERT INTO `garages` VALUES (159, 1, '{\"x\":947.763367,\"y\":-656.3432,\"z\":57.32238}', '{\"x\":-0.240860164,\"y\":0.3544743,\"z\":127.805634}');
INSERT INTO `garages` VALUES (160, 2, '{\"x\":1308.52954,\"y\":-534.3686,\"z\":70.63211}', '{\"x\":-0.196971744,\"y\":1.1242063,\"z\":162.170471}');
INSERT INTO `garages` VALUES (161, 1, '{\"x\":914.178955,\"y\":-643.3315,\"z\":57.16266}', '{\"x\":-0.0184148084,\"y\":-0.003968732,\"z\":319.047363}');
INSERT INTO `garages` VALUES (162, 1, '{\"x\":914.0002,\"y\":-629.9238,\"z\":57.3492241}', '{\"x\":-0.0123535749,\"y\":0.008640971,\"z\":137.965942}');
INSERT INTO `garages` VALUES (163, 1, '{\"x\":871.989,\"y\":-601.3488,\"z\":57.5176048}', '{\"x\":0.205374539,\"y\":-0.123517059,\"z\":135.762878}');
INSERT INTO `garages` VALUES (164, 1, '{\"x\":871.5414,\"y\":-590.30835,\"z\":57.35508}', '{\"x\":2.92190385,\"y\":-4.44438028,\"z\":314.728119}');
INSERT INTO `garages` VALUES (165, 1, '{\"x\":844.424866,\"y\":-566.831238,\"z\":57.0096}', '{\"x\":-0.0342931971,\"y\":0.108552672,\"z\":99.51471}');
INSERT INTO `garages` VALUES (166, 1, '{\"x\":840.477844,\"y\":-541.1765,\"z\":56.6267738}', '{\"x\":0.0234103464,\"y\":0.08434274,\"z\":84.82837}');
INSERT INTO `garages` VALUES (167, 2, '{\"x\":1319.3175,\"y\":-574.4844,\"z\":72.27612}', '{\"x\":3.02859759,\"y\":2.164169,\"z\":335.0465}');
INSERT INTO `garages` VALUES (168, 1, '{\"x\":853.7288,\"y\":-517.41156,\"z\":56.62882}', '{\"x\":-0.0331812054,\"y\":-0.048909016,\"z\":48.41922}');
INSERT INTO `garages` VALUES (169, 1, '{\"x\":870.501953,\"y\":-502.654266,\"z\":56.7984123}', '{\"x\":0.05727596,\"y\":0.06058478,\"z\":44.80609}');
INSERT INTO `garages` VALUES (170, 2, '{\"x\":1317.29736,\"y\":-537.301636,\"z\":71.31095}', '{\"x\":-1.37489665,\"y\":2.52849841,\"z\":159.575317}');
INSERT INTO `garages` VALUES (171, 1, '{\"x\":911.7531,\"y\":-483.870941,\"z\":58.3372955}', '{\"x\":0.01969726,\"y\":-0.135987446,\"z\":23.5276489}');
INSERT INTO `garages` VALUES (172, 2, '{\"x\":1352.95337,\"y\":-554.5135,\"z\":73.45657}', '{\"x\":4.484163,\"y\":-0.24870798,\"z\":155.6814}');
INSERT INTO `garages` VALUES (173, 1, '{\"x\":930.8844,\"y\":-477.2382,\"z\":60.0028534}', '{\"x\":0.0206314512,\"y\":0.14721781,\"z\":26.074585}');
INSERT INTO `garages` VALUES (174, 1, '{\"x\":940.9149,\"y\":-465.6165,\"z\":60.5531349}', '{\"x\":0.08872915,\"y\":0.02500134,\"z\":30.0944824}');
INSERT INTO `garages` VALUES (175, 2, '{\"x\":1351.65576,\"y\":-595.1947,\"z\":73.67215}', '{\"x\":-0.139340371,\"y\":-0.0586860739,\"z\":315.727}');
INSERT INTO `garages` VALUES (176, 1, '{\"x\":974.545654,\"y\":-451.842926,\"z\":61.7211075}', '{\"x\":0.5560082,\"y\":0.567770958,\"z\":34.9042969}');
INSERT INTO `garages` VALUES (177, 2, '{\"x\":1362.13977,\"y\":-555.8651,\"z\":73.6721954}', '{\"x\":0.103256129,\"y\":0.104736246,\"z\":158.260376}');
INSERT INTO `garages` VALUES (178, 1, '{\"x\":989.1693,\"y\":-437.279846,\"z\":63.04582}', '{\"x\":0.3987098,\"y\":-0.564513147,\"z\":303.696472}');
INSERT INTO `garages` VALUES (179, 1, '{\"x\":1010.96265,\"y\":-417.389862,\"z\":64.25387}', '{\"x\":-0.0236302614,\"y\":0.0008021625,\"z\":36.5239258}');
INSERT INTO `garages` VALUES (180, 2, '{\"x\":1359.79932,\"y\":-601.3592,\"z\":73.6721344}', '{\"x\":-0.0602567755,\"y\":-0.126523986,\"z\":358.176941}');
INSERT INTO `garages` VALUES (181, 1, '{\"x\":1018.1806,\"y\":-413.3934,\"z\":65.24978}', '{\"x\":0.0149722081,\"y\":-0.317216545,\"z\":33.6077881}');
INSERT INTO `garages` VALUES (182, 2, '{\"x\":1379.20044,\"y\":-597.211365,\"z\":73.6721344}', '{\"x\":0.07139139,\"y\":-0.125930473,\"z\":51.68228}');
INSERT INTO `garages` VALUES (183, 1, '{\"x\":1051.06335,\"y\":-381.098419,\"z\":67.15389}', '{\"x\":0.0371558778,\"y\":0.04714894,\"z\":40.2737732}');
INSERT INTO `garages` VALUES (184, 1, '{\"x\":1403.15955,\"y\":-571.409546,\"z\":73.6416}', '{\"x\":0.0606115125,\"y\":0.0595534146,\"z\":291.444458}');
INSERT INTO `garages` VALUES (185, 2, '{\"x\":1399.20459,\"y\":-572.7282,\"z\":73.63977}', '{\"x\":0.04078417,\"y\":-0.09676619,\"z\":291.065643}');
INSERT INTO `garages` VALUES (186, 1, '{\"x\":-1020.56409,\"y\":-1132.97083,\"z\":1.44207549}', '{\"x\":0.752301,\"y\":0.06137582,\"z\":29.1805725}');
INSERT INTO `garages` VALUES (187, 1, '{\"x\":-1026.79553,\"y\":-1129.73462,\"z\":1.46546412}', '{\"x\":0.4794352,\"y\":-0.1391713,\"z\":209.593826}');
INSERT INTO `garages` VALUES (188, 1, '{\"x\":-1037.74512,\"y\":-1142.70862,\"z\":1.41373253}', '{\"x\":2.30583453,\"y\":1.1927948,\"z\":300.306671}');
INSERT INTO `garages` VALUES (189, 1, '{\"x\":-1045.07178,\"y\":-1141.05054,\"z\":1.43891644}', '{\"x\":-0.822091,\"y\":-0.294718444,\"z\":208.520279}');
INSERT INTO `garages` VALUES (190, 1, '{\"x\":-1047.32556,\"y\":-1152.12549,\"z\":1.45843124}', '{\"x\":0.0111408429,\"y\":0.00162937632,\"z\":209.011078}');
INSERT INTO `garages` VALUES (191, 1, '{\"x\":-1060.04517,\"y\":-1154.2439,\"z\":1.44051182}', '{\"x\":0.5729067,\"y\":0.216861069,\"z\":31.7667542}');
INSERT INTO `garages` VALUES (192, 1, '{\"x\":-1076.13208,\"y\":-1159.05237,\"z\":1.437269}', '{\"x\":-0.9270952,\"y\":-0.202749744,\"z\":211.678833}');
INSERT INTO `garages` VALUES (193, 1, '{\"x\":-1074.91443,\"y\":-1164.36829,\"z\":1.45443487}', '{\"x\":0.0992424041,\"y\":0.637545049,\"z\":299.0922}');
INSERT INTO `garages` VALUES (194, 1, '{\"x\":-987.374451,\"y\":-1112.71289,\"z\":1.415707}', '{\"x\":1.42232037,\"y\":0.6017128,\"z\":209.780884}');
INSERT INTO `garages` VALUES (195, 1, '{\"x\":-988.370361,\"y\":-1107.73047,\"z\":1.41902757}', '{\"x\":-1.109633,\"y\":-1.73071051,\"z\":298.298}');
INSERT INTO `garages` VALUES (196, 1, '{\"x\":-974.129761,\"y\":-1104.47217,\"z\":1.44381511}', '{\"x\":0.485567749,\"y\":0.158071056,\"z\":298.1047}');
INSERT INTO `garages` VALUES (197, 1, '{\"x\":-978.724,\"y\":-1102.55066,\"z\":1.37468791}', '{\"x\":-0.7199251,\"y\":0.08148,\"z\":300.014038}');
INSERT INTO `garages` VALUES (198, 1, '{\"x\":-961.733337,\"y\":-1102.06641,\"z\":1.450155}', '{\"x\":-0.00532346824,\"y\":-0.0127413329,\"z\":209.7345}');
INSERT INTO `garages` VALUES (199, 1, '{\"x\":-950.8731,\"y\":-1098.19067,\"z\":1.44941056}', '{\"x\":-0.0553956181,\"y\":-0.0260298569,\"z\":30.5349426}');
INSERT INTO `garages` VALUES (200, 1, '{\"x\":-955.7924,\"y\":-1083.86792,\"z\":1.45005262}', '{\"x\":0.02449257,\"y\":0.003847679,\"z\":211.98526}');
INSERT INTO `garages` VALUES (201, 1, '{\"x\":-1164.28809,\"y\":-1091.807,\"z\":1.38970828}', '{\"x\":-1.03897285,\"y\":-0.7540575,\"z\":117.188171}');
INSERT INTO `garages` VALUES (202, 1, '{\"x\":-934.666565,\"y\":-1080.31055,\"z\":1.41126227}', '{\"x\":1.19615328,\"y\":1.20349014,\"z\":29.7527771}');
INSERT INTO `garages` VALUES (203, 1, '{\"x\":-1156.56067,\"y\":-1132.91113,\"z\":2.13388777}', '{\"x\":0.159938008,\"y\":-0.6436362,\"z\":119.922668}');
INSERT INTO `garages` VALUES (204, 1, '{\"x\":-936.2235,\"y\":-1074.63489,\"z\":1.45000088}', '{\"x\":0.0278339125,\"y\":-0.009307106,\"z\":119.212616}');
INSERT INTO `garages` VALUES (205, 1, '{\"x\":-1154.92139,\"y\":-1136.49939,\"z\":2.12227583}', '{\"x\":-0.0250774939,\"y\":-0.341819882,\"z\":119.529419}');
INSERT INTO `garages` VALUES (206, 1, '{\"x\":-1148.6062,\"y\":-1145.40088,\"z\":2.203151}', '{\"x\":-1.416801,\"y\":-0.600740731,\"z\":120.770813}');
INSERT INTO `garages` VALUES (207, 1, '{\"x\":-985.3437,\"y\":-986.271545,\"z\":1.31576872}', '{\"x\":1.3718158,\"y\":1.53974891,\"z\":298.8178}');
INSERT INTO `garages` VALUES (208, 1, '{\"x\":-991.4487,\"y\":-985.902832,\"z\":1.42633975}', '{\"x\":-1.56448174,\"y\":-0.7805287,\"z\":118.526611}');
INSERT INTO `garages` VALUES (209, 1, '{\"x\":-1009.79449,\"y\":-1009.33759,\"z\":1.4498986}', '{\"x\":0.029744748,\"y\":0.0170502178,\"z\":210.659561}');
INSERT INTO `garages` VALUES (210, 1, '{\"x\":-1144.75366,\"y\":-1153.16675,\"z\":2.13982654}', '{\"x\":0.160849214,\"y\":0.272933781,\"z\":121.532745}');
INSERT INTO `garages` VALUES (211, 1, '{\"x\":-1019.48181,\"y\":-1002.23535,\"z\":1.44128335}', '{\"x\":-0.580399,\"y\":-0.339477181,\"z\":119.686035}');
INSERT INTO `garages` VALUES (212, 1, '{\"x\":-1141.99,\"y\":-1155.59607,\"z\":2.09106469}', '{\"x\":-1.07376325,\"y\":-0.768052,\"z\":298.4376}');
INSERT INTO `garages` VALUES (213, 1, '{\"x\":-1022.61804,\"y\":-1014.03345,\"z\":1.4500984}', '{\"x\":0.01875926,\"y\":0.008423615,\"z\":207.732208}');
INSERT INTO `garages` VALUES (214, 1, '{\"x\":-1138.195,\"y\":-1166.39,\"z\":2.03514218}', '{\"x\":0.383401781,\"y\":-0.698455334,\"z\":120.19873}');
INSERT INTO `garages` VALUES (215, 1, '{\"x\":-1038.19189,\"y\":-1019.56921,\"z\":1.43423092}', '{\"x\":0.389801383,\"y\":0.62490344,\"z\":31.039856}');
INSERT INTO `garages` VALUES (216, 1, '{\"x\":-1131.41235,\"y\":-1172.57239,\"z\":1.68354809}', '{\"x\":-0.0462847427,\"y\":-0.3512429,\"z\":300.3929}');
INSERT INTO `garages` VALUES (217, 1, '{\"x\":-1042.56079,\"y\":-1011.59991,\"z\":1.4499259}', '{\"x\":0.0232487936,\"y\":0.0162906125,\"z\":208.714127}');
INSERT INTO `garages` VALUES (218, 1, '{\"x\":-1117.16223,\"y\":-1186.05981,\"z\":1.474132}', '{\"x\":-0.783168435,\"y\":-0.61519134,\"z\":301.081543}');
INSERT INTO `garages` VALUES (219, 1, '{\"x\":-1076.27185,\"y\":-1045.60669,\"z\":1.44991064}', '{\"x\":-0.008779396,\"y\":-0.00512478361,\"z\":28.90213}');
INSERT INTO `garages` VALUES (220, 1, '{\"x\":-1110.916,\"y\":-1229.83069,\"z\":1.91737556}', '{\"x\":0.54313457,\"y\":0.3063169,\"z\":112.331848}');
INSERT INTO `garages` VALUES (221, 1, '{\"x\":-1095.86572,\"y\":-1044.18384,\"z\":1.468074}', '{\"x\":-0.222340539,\"y\":0.3622868,\"z\":297.4236}');
INSERT INTO `garages` VALUES (222, 1, '{\"x\":-1111.344,\"y\":-1238.289,\"z\":1.74403107}', '{\"x\":-3.42407823,\"y\":4.11955833,\"z\":30.1307678}');
INSERT INTO `garages` VALUES (223, 1, '{\"x\":-1107.49792,\"y\":-1049.10107,\"z\":1.45032823}', '{\"x\":0.0464611761,\"y\":0.0161469318,\"z\":209.274628}');
INSERT INTO `garages` VALUES (224, 1, '{\"x\":-1211.7052,\"y\":-1025.91687,\"z\":1.4779377}', '{\"x\":-0.26253742,\"y\":-0.09793696,\"z\":303.866425}');
INSERT INTO `garages` VALUES (225, 1, '{\"x\":-1100.55481,\"y\":-1053.85181,\"z\":1.42328382}', '{\"x\":1.01984811,\"y\":0.5297388,\"z\":31.3685}');
INSERT INTO `garages` VALUES (226, 1, '{\"x\":-1203.77063,\"y\":-1037.45471,\"z\":1.47790945}', '{\"x\":0.228082672,\"y\":0.105697252,\"z\":121.558777}');
INSERT INTO `garages` VALUES (227, 1, '{\"x\":-1116.91333,\"y\":-1064.77991,\"z\":1.41449428}', '{\"x\":2.12574172,\"y\":1.60902786,\"z\":300.128357}');
INSERT INTO `garages` VALUES (228, 1, '{\"x\":-1199.438,\"y\":-1055.89258,\"z\":1.47515273}', '{\"x\":0.197239026,\"y\":0.775881648,\"z\":200.772}');
INSERT INTO `garages` VALUES (229, 1, '{\"x\":-1121.663,\"y\":-1051.509,\"z\":1.45019937}', '{\"x\":-0.000280248525,\"y\":-0.000172483822,\"z\":29.3138123}');
INSERT INTO `garages` VALUES (230, 1, '{\"x\":-1190.09851,\"y\":-1066.3728,\"z\":1.47792876}', '{\"x\":0.205737486,\"y\":0.103701524,\"z\":119.650513}');
INSERT INTO `garages` VALUES (231, 1, '{\"x\":-1130.23853,\"y\":-1072.06934,\"z\":1.41611636}', '{\"x\":1.43402112,\"y\":0.4180223,\"z\":31.8911133}');
INSERT INTO `garages` VALUES (232, 1, '{\"x\":-1187.41406,\"y\":-1077.17957,\"z\":1.47772682}', '{\"x\":0.234099671,\"y\":0.1019552,\"z\":119.488586}');
INSERT INTO `garages` VALUES (233, 1, '{\"x\":-3083.822,\"y\":220.11496,\"z\":13.323823}', '{\"x\":-0.0734182745,\"y\":-0.316258729,\"z\":317.679138}');
INSERT INTO `garages` VALUES (234, 1, '{\"x\":-3176.35,\"y\":1296.17249,\"z\":14.1447029}', '{\"x\":-2.14095449,\"y\":0.0257356558,\"z\":248.467743}');
INSERT INTO `garages` VALUES (235, 1, '{\"x\":-3097.48,\"y\":746.3721,\"z\":20.5535374}', '{\"x\":-2.75234056,\"y\":-2.74950266,\"z\":231.196945}');
INSERT INTO `garages` VALUES (236, 1, '{\"x\":-3183.09326,\"y\":1277.52844,\"z\":12.3478613}', '{\"x\":-1.505761,\"y\":1.63139236,\"z\":254.415283}');
INSERT INTO `garages` VALUES (237, 1, '{\"x\":-3186.3916,\"y\":1223.08667,\"z\":9.652463}', '{\"x\":-0.92195034,\"y\":0.5286771,\"z\":262.6923}');
INSERT INTO `garages` VALUES (238, 1, '{\"x\":-3101.7793,\"y\":716.678345,\"z\":19.8090744}', '{\"x\":-2.95656,\"y\":0.06049772,\"z\":284.764343}');
INSERT INTO `garages` VALUES (239, 1, '{\"x\":-3188.82471,\"y\":1197.47131,\"z\":9.136649}', '{\"x\":-0.249107748,\"y\":1.52993619,\"z\":261.077362}');
INSERT INTO `garages` VALUES (240, 1, '{\"x\":-3073.214,\"y\":656.738,\"z\":10.5922394}', '{\"x\":4.62549829,\"y\":-10.1233826,\"z\":131.0523}');
INSERT INTO `garages` VALUES (241, 1, '{\"x\":-3028.5166,\"y\":572.996338,\"z\":6.994729}', '{\"x\":0.7134291,\"y\":-4.66594172,\"z\":282.474731}');
INSERT INTO `garages` VALUES (242, 1, '{\"x\":-3189.84375,\"y\":1184.323,\"z\":9.020672}', '{\"x\":0.579500258,\"y\":1.48629451,\"z\":172.291443}');
INSERT INTO `garages` VALUES (243, 1, '{\"x\":-3033.48413,\"y\":555.631,\"z\":6.835764}', '{\"x\":-0.221507922,\"y\":-0.05199334,\"z\":273.989258}');
INSERT INTO `garages` VALUES (244, 1, '{\"x\":-3195.288,\"y\":1158.85266,\"z\":9.203925}', '{\"x\":-0.438517421,\"y\":-1.92088163,\"z\":250.258392}');
INSERT INTO `garages` VALUES (245, 1, '{\"x\":-3029.60474,\"y\":520.956238,\"z\":6.68331337}', '{\"x\":-0.898285568,\"y\":-1.34478652,\"z\":264.103149}');
INSERT INTO `garages` VALUES (246, 1, '{\"x\":-3203.34058,\"y\":1138.75354,\"z\":9.520713}', '{\"x\":-0.166529864,\"y\":-0.6466618,\"z\":245.673615}');
INSERT INTO `garages` VALUES (247, 1, '{\"x\":-3032.354,\"y\":499.250427,\"z\":6.1273756}', '{\"x\":-0.38465178,\"y\":0.5690849,\"z\":260.778229}');
INSERT INTO `garages` VALUES (248, 1, '{\"x\":-3041.00366,\"y\":478.9607,\"z\":6.10768747}', '{\"x\":0.351669252,\"y\":0.168873861,\"z\":74.6613159}');
INSERT INTO `garages` VALUES (249, 1, '{\"x\":-3220.26953,\"y\":1105.46912,\"z\":10.133337}', '{\"x\":-0.436739415,\"y\":-1.77705717,\"z\":250.174835}');
INSERT INTO `garages` VALUES (250, 1, '{\"x\":-3058.43,\"y\":442.045319,\"z\":5.68972635}', '{\"x\":-0.397248834,\"y\":-0.211871058,\"z\":246.969879}');
INSERT INTO `garages` VALUES (251, 1, '{\"x\":-3225.26074,\"y\":1086.02087,\"z\":10.3454762}', '{\"x\":2.49012041,\"y\":3.08568859,\"z\":163.318176}');
INSERT INTO `garages` VALUES (252, 1, '{\"x\":-3074.05322,\"y\":395.4868,\"z\":6.296767}', '{\"x\":-0.334301353,\"y\":-0.151056319,\"z\":253.110825}');
INSERT INTO `garages` VALUES (253, 1, '{\"x\":-3079.09131,\"y\":371.3547,\"z\":6.454534}', '{\"x\":0.252038419,\"y\":0.0115334466,\"z\":73.79617}');
INSERT INTO `garages` VALUES (254, 1, '{\"x\":-3228.87817,\"y\":1071.49207,\"z\":10.6137037}', '{\"x\":1.3889339,\"y\":2.00661564,\"z\":259.6368}');
INSERT INTO `garages` VALUES (255, 1, '{\"x\":-3088.90771,\"y\":340.757141,\"z\":6.73259354}', '{\"x\":0.0264017247,\"y\":-1.0401696,\"z\":72.86447}');
INSERT INTO `garages` VALUES (256, 1, '{\"x\":-3234.214,\"y\":1051.80237,\"z\":10.8445864}', '{\"x\":0.847446859,\"y\":2.048419,\"z\":264.133423}');
INSERT INTO `garages` VALUES (257, 1, '{\"x\":-3091.54346,\"y\":322.526947,\"z\":6.83644438}', '{\"x\":0.205824941,\"y\":0.299209,\"z\":256.090546}');
INSERT INTO `garages` VALUES (258, 1, '{\"x\":-3237.45923,\"y\":1034.438,\"z\":11.3443632}', '{\"x\":0.863197744,\"y\":0.311722457,\"z\":264.31424}');
INSERT INTO `garages` VALUES (259, 1, '{\"x\":-3098.4314,\"y\":306.96814,\"z\":7.696529}', '{\"x\":0.174656123,\"y\":-0.505830944,\"z\":72.06604}');
INSERT INTO `garages` VALUES (260, 1, '{\"x\":-3233.67749,\"y\":948.544861,\"z\":12.935}', '{\"x\":0.4756325,\"y\":3.64241624,\"z\":282.395325}');
INSERT INTO `garages` VALUES (261, 1, '{\"x\":-3101.21851,\"y\":289.30307,\"z\":8.296385}', '{\"x\":1.71394682,\"y\":-0.568213642,\"z\":74.7679443}');
INSERT INTO `garages` VALUES (262, 1, '{\"x\":-3231.31055,\"y\":939.9434,\"z\":13.3769951}', '{\"x\":1.31681061,\"y\":-1.97647893,\"z\":289.755371}');
INSERT INTO `garages` VALUES (263, 1, '{\"x\":-3104.529,\"y\":253.233429,\"z\":11.4870186}', '{\"x\":4.23592949,\"y\":-7.69576645,\"z\":282.548828}');
INSERT INTO `garages` VALUES (264, 1, '{\"x\":-3224.07178,\"y\":924.786438,\"z\":13.6074057}', '{\"x\":0.377418429,\"y\":0.239076212,\"z\":300.0449}');
INSERT INTO `garages` VALUES (265, 1, '{\"x\":-3216.69165,\"y\":915.48645,\"z\":13.6735916}', '{\"x\":-1.2557385,\"y\":1.26585507,\"z\":317.835175}');
INSERT INTO `garages` VALUES (266, 3, '{\"x\":-3017.53345,\"y\":739.515259,\"z\":26.91748}', '{\"x\":0.300706,\"y\":0.2718161,\"z\":111.663666}');
INSERT INTO `garages` VALUES (267, 2, '{\"x\":-2993.62964,\"y\":705.2482,\"z\":27.826683}', '{\"x\":0.167383239,\"y\":0.142676964,\"z\":114.953979}');
INSERT INTO `garages` VALUES (268, 2, '{\"x\":-2998.526,\"y\":687.6408,\"z\":24.5723476}', '{\"x\":-3.60436177,\"y\":12.529417,\"z\":106.122559}');
INSERT INTO `garages` VALUES (269, 2, '{\"x\":-2980.22949,\"y\":655.269836,\"z\":24.9218845}', '{\"x\":-2.27306533,\"y\":8.730806,\"z\":104.973267}');
INSERT INTO `garages` VALUES (270, 2, '{\"x\":-2980.47632,\"y\":612.7522,\"z\":19.5368}', '{\"x\":0.536404431,\"y\":1.90520787,\"z\":101.836639}');
INSERT INTO `garages` VALUES (271, -1, '{\"x\":339.266174,\"y\":2568.31543,\"z\":42.85872}', '{\"x\":0.488704264,\"y\":-0.274137378,\"z\":209.4793}');
INSERT INTO `garages` VALUES (272, -1, '{\"x\":361.5359,\"y\":2573.83667,\"z\":42.8522377}', '{\"x\":-0.0200520232,\"y\":-0.0112498375,\"z\":27.1528625}');
INSERT INTO `garages` VALUES (273, -1, '{\"x\":376.538147,\"y\":2578.99463,\"z\":42.8525162}', '{\"x\":-0.0262214858,\"y\":-0.00559048029,\"z\":19.0576172}');
INSERT INTO `garages` VALUES (274, -1, '{\"x\":396.0783,\"y\":2589.6792,\"z\":42.8524437}', '{\"x\":-0.0283325221,\"y\":-0.0106838914,\"z\":108.840881}');
INSERT INTO `garages` VALUES (275, -1, '{\"x\":1137.634,\"y\":2656.98779,\"z\":37.5812874}', '{\"x\":-0.00412730547,\"y\":-0.0618062951,\"z\":92.3717957}');
INSERT INTO `garages` VALUES (276, -1, '{\"x\":386.986847,\"y\":2638.28223,\"z\":43.8287773}', '{\"x\":0.0464484878,\"y\":-0.0430518426,\"z\":30.2751465}');
INSERT INTO `garages` VALUES (277, -1, '{\"x\":1137.86169,\"y\":2651.05933,\"z\":37.5771255}', '{\"x\":-0.01179523,\"y\":0.129020676,\"z\":88.4283142}');
INSERT INTO `garages` VALUES (278, -1, '{\"x\":374.568237,\"y\":2633.32471,\"z\":43.83094}', '{\"x\":-0.0315650776,\"y\":-0.0202927049,\"z\":30.1107178}');
INSERT INTO `garages` VALUES (279, -1, '{\"x\":1135.23438,\"y\":2647.24268,\"z\":37.5739479}', '{\"x\":0.212600678,\"y\":-0.007507281,\"z\":359.6101}');
INSERT INTO `garages` VALUES (280, -1, '{\"x\":361.671844,\"y\":2628.701,\"z\":43.8302727}', '{\"x\":-0.04460643,\"y\":-0.0201458838,\"z\":30.4292}');
INSERT INTO `garages` VALUES (281, -1, '{\"x\":1131.34753,\"y\":2647.041,\"z\":37.5732574}', '{\"x\":0.09655002,\"y\":-0.0292111449,\"z\":359.48645}');
INSERT INTO `garages` VALUES (282, -1, '{\"x\":348.887817,\"y\":2624.26074,\"z\":43.83308}', '{\"x\":0.00536757,\"y\":-0.0207648519,\"z\":29.9164429}');
INSERT INTO `garages` VALUES (283, -1, '{\"x\":1127.75684,\"y\":2648.526,\"z\":37.5743523}', '{\"x\":0.104055084,\"y\":-0.0219079,\"z\":4.250885}');
INSERT INTO `garages` VALUES (284, -1, '{\"x\":336.972961,\"y\":2619.44238,\"z\":43.8303833}', '{\"x\":0.0626243353,\"y\":0.113149062,\"z\":24.5472412}');
INSERT INTO `garages` VALUES (285, -1, '{\"x\":1124.1521,\"y\":2647.86426,\"z\":37.5736046}', '{\"x\":0.146706864,\"y\":-0.218193248,\"z\":2.904358}');
INSERT INTO `garages` VALUES (286, -1, '{\"x\":1120.68213,\"y\":2647.52661,\"z\":37.5735054}', '{\"x\":0.0624286979,\"y\":-0.009876269,\"z\":1.33822632}');
INSERT INTO `garages` VALUES (287, -1, '{\"x\":1116.80579,\"y\":2647.63,\"z\":37.5732956}', '{\"x\":0.07218886,\"y\":0.00603483524,\"z\":358.759369}');
INSERT INTO `garages` VALUES (288, -1, '{\"x\":1112.11816,\"y\":2647.40967,\"z\":37.573616}', '{\"x\":0.110817686,\"y\":-0.0127833765,\"z\":357.795715}');
INSERT INTO `garages` VALUES (289, -1, '{\"x\":1111.05139,\"y\":2652.13062,\"z\":37.57321}', '{\"x\":0.00162625534,\"y\":-0.0697201043,\"z\":270.907654}');
INSERT INTO `garages` VALUES (290, -1, '{\"x\":1111.173,\"y\":2656.58813,\"z\":37.5720444}', '{\"x\":0.0200523678,\"y\":-0.124936782,\"z\":270.196}');
INSERT INTO `garages` VALUES (291, -1, '{\"x\":1105.64685,\"y\":2662.86768,\"z\":37.55273}', '{\"x\":-0.150976181,\"y\":0.00699682534,\"z\":0.6168823}');
INSERT INTO `garages` VALUES (292, -1, '{\"x\":885.5021,\"y\":2846.403,\"z\":56.25335}', '{\"x\":0.517142355,\"y\":-0.2696134,\"z\":134.812958}');
INSERT INTO `garages` VALUES (293, -1, '{\"x\":870.9132,\"y\":2872.78149,\"z\":56.47126}', '{\"x\":0.108919546,\"y\":-1.38271713,\"z\":187.970367}');
INSERT INTO `garages` VALUES (294, -1, '{\"x\":857.3363,\"y\":2850.93921,\"z\":57.1373672}', '{\"x\":0.3338655,\"y\":-3.11990285,\"z\":247.611542}');
INSERT INTO `garages` VALUES (295, -1, '{\"x\":1870.45227,\"y\":3915.199,\"z\":32.30007}', '{\"x\":0.23196499,\"y\":-0.995937347,\"z\":195.423141}');
INSERT INTO `garages` VALUES (296, -1, '{\"x\":1893.62158,\"y\":3887.66113,\"z\":32.1383667}', '{\"x\":-0.335304648,\"y\":1.39673448,\"z\":118.777893}');
INSERT INTO `garages` VALUES (297, -1, '{\"x\":1894.821,\"y\":3860.945,\"z\":31.7945786}', '{\"x\":-1.27140474,\"y\":0.9099434,\"z\":210.359024}');
INSERT INTO `garages` VALUES (298, -1, '{\"x\":1932.125,\"y\":3882.79761,\"z\":31.7507572}', '{\"x\":-2.73432231,\"y\":-2.88893056,\"z\":208.259842}');
INSERT INTO `garages` VALUES (299, -1, '{\"x\":1932.42175,\"y\":3925.94165,\"z\":31.6942635}', '{\"x\":-1.80084383,\"y\":1.61926091,\"z\":233.756409}');
INSERT INTO `garages` VALUES (300, -1, '{\"x\":1909.9668,\"y\":3812.92334,\"z\":31.595068}', '{\"x\":2.16436362,\"y\":-4.694561,\"z\":35.322113}');
INSERT INTO `garages` VALUES (301, -1, '{\"x\":1923.47021,\"y\":3792.63428,\"z\":31.6232777}', '{\"x\":-1.38343835,\"y\":0.355577439,\"z\":211.2028}');
INSERT INTO `garages` VALUES (302, -1, '{\"x\":1980.66187,\"y\":3806.673,\"z\":31.4924622}', '{\"x\":2.23509359,\"y\":1.258016,\"z\":118.858063}');
INSERT INTO `garages` VALUES (303, -1, '{\"x\":1901.50586,\"y\":3765.10425,\"z\":31.8918419}', '{\"x\":-3.66153884,\"y\":-2.23537683,\"z\":209.988861}');
INSERT INTO `garages` VALUES (304, -1, '{\"x\":1892.838,\"y\":3814.45728,\"z\":31.6823864}', '{\"x\":0.9756285,\"y\":-1.84914231,\"z\":304.979248}');
INSERT INTO `garages` VALUES (305, -1, '{\"x\":1838.0979,\"y\":3771.7312,\"z\":32.714138}', '{\"x\":-1.91330361,\"y\":2.52236915,\"z\":208.671936}');
INSERT INTO `garages` VALUES (306, -1, '{\"x\":1754.25842,\"y\":3832.59424,\"z\":34.00901}', '{\"x\":1.03904676,\"y\":-0.669008732,\"z\":29.1123962}');
INSERT INTO `garages` VALUES (307, -1, '{\"x\":1723.46143,\"y\":3818.41235,\"z\":34.2157326}', '{\"x\":-2.5360682,\"y\":-1.8612262,\"z\":121.629028}');
INSERT INTO `garages` VALUES (308, -1, '{\"x\":1741.60034,\"y\":3772.92,\"z\":33.2098236}', '{\"x\":-0.09607381,\"y\":-4.763753,\"z\":210.036346}');
INSERT INTO `garages` VALUES (309, -1, '{\"x\":1767.22363,\"y\":3756.77515,\"z\":33.10628}', '{\"x\":-0.0586666428,\"y\":-0.295788735,\"z\":297.474}');
INSERT INTO `garages` VALUES (310, -1, '{\"x\":1779.36938,\"y\":3784.82861,\"z\":33.049942}', '{\"x\":3.27997637,\"y\":1.4150995,\"z\":119.682678}');
INSERT INTO `garages` VALUES (311, -1, '{\"x\":1737.74683,\"y\":3853.712,\"z\":33.9757919}', '{\"x\":2.07664561,\"y\":-1.767333,\"z\":214.242126}');
INSERT INTO `garages` VALUES (312, -1, '{\"x\":1691.07959,\"y\":3874.91357,\"z\":34.0976944}', '{\"x\":0.270841,\"y\":0.456633627,\"z\":312.3515}');
INSERT INTO `garages` VALUES (313, -1, '{\"x\":1752.68848,\"y\":3892.02246,\"z\":34.04631}', '{\"x\":-0.8044237,\"y\":0.31718564,\"z\":33.4364}');
INSERT INTO `garages` VALUES (314, -1, '{\"x\":1778.482,\"y\":3929.04443,\"z\":33.6716652}', '{\"x\":0.252341568,\"y\":-1.49795473,\"z\":106.184387}');
INSERT INTO `garages` VALUES (315, -1, '{\"x\":1801.873,\"y\":3932.862,\"z\":33.13928}', '{\"x\":2.329348,\"y\":-0.99685353,\"z\":12.1304321}');
INSERT INTO `garages` VALUES (316, -1, '{\"x\":1847.12939,\"y\":3921.54,\"z\":32.4092979}', '{\"x\":0.3726753,\"y\":-1.71102035,\"z\":282.144135}');
INSERT INTO `garages` VALUES (317, -1, '{\"x\":3696.57739,\"y\":4563.236,\"z\":24.5691319}', '{\"x\":3.39417481,\"y\":-0.60899514,\"z\":179.4129}');
INSERT INTO `garages` VALUES (318, -1, '{\"x\":3713.927,\"y\":4522.55225,\"z\":20.9878387}', '{\"x\":-0.4463577,\"y\":1.58383667,\"z\":137.357666}');
INSERT INTO `garages` VALUES (319, 0, '{\"x\":3331.62769,\"y\":5157.06055,\"z\":17.6260185}', '{\"x\":0.07703561,\"y\":-0.17194131,\"z\":152.837463}');
INSERT INTO `garages` VALUES (320, -1, '{\"x\":21.5043068,\"y\":6658.784,\"z\":30.84612}', '{\"x\":-0.413007051,\"y\":0.163321078,\"z\":182.347}');
INSERT INTO `garages` VALUES (321, -1, '{\"x\":-15.0782337,\"y\":6643.795,\"z\":30.4228268}', '{\"x\":-0.751192331,\"y\":0.06746805,\"z\":208.699966}');
INSERT INTO `garages` VALUES (322, -1, '{\"x\":-7.18539667,\"y\":6620.34131,\"z\":30.5853176}', '{\"x\":6.05935764,\"y\":3.86339784,\"z\":31.16092}');
INSERT INTO `garages` VALUES (323, -1, '{\"x\":-51.4084244,\"y\":6589.88428,\"z\":29.6790276}', '{\"x\":10.1445866,\"y\":7.21803665,\"z\":40.4060974}');
INSERT INTO `garages` VALUES (324, -1, '{\"x\":-7.778161,\"y\":6560.04443,\"z\":31.3033829}', '{\"x\":-0.009667761,\"y\":-0.0165917277,\"z\":44.7089233}');
INSERT INTO `garages` VALUES (325, -1, '{\"x\":21.1077385,\"y\":6576.929,\"z\":31.2303715}', '{\"x\":-5.14247274,\"y\":-5.043249,\"z\":44.229126}');
INSERT INTO `garages` VALUES (326, -1, '{\"x\":46.0893974,\"y\":6601.052,\"z\":31.26825}', '{\"x\":-2.69610739,\"y\":-3.7525866,\"z\":49.38916}');
INSERT INTO `garages` VALUES (327, -1, '{\"x\":-120.728607,\"y\":6559.544,\"z\":28.8461246}', '{\"x\":-0.239958048,\"y\":-0.258422822,\"z\":224.723}');
INSERT INTO `garages` VALUES (328, -1, '{\"x\":-108.8279,\"y\":6538.317,\"z\":29.1161289}', '{\"x\":0.7220967,\"y\":0.7343003,\"z\":46.7844849}');
INSERT INTO `garages` VALUES (329, -1, '{\"x\":-191.364563,\"y\":6422.042,\"z\":31.1087151}', '{\"x\":2.23944163,\"y\":2.78114247,\"z\":45.4631042}');
INSERT INTO `garages` VALUES (330, -1, '{\"x\":-232.157883,\"y\":6419.55664,\"z\":30.597929}', '{\"x\":1.78611517,\"y\":0.181137308,\"z\":217.91066}');
INSERT INTO `garages` VALUES (331, -1, '{\"x\":-207.160568,\"y\":6407.952,\"z\":31.0694771}', '{\"x\":2.19140863,\"y\":2.16443229,\"z\":224.183914}');
INSERT INTO `garages` VALUES (332, -1, '{\"x\":-227.636978,\"y\":6391.90869,\"z\":30.800148}', '{\"x\":0.438066185,\"y\":2.21514988,\"z\":214.42247}');
INSERT INTO `garages` VALUES (333, -1, '{\"x\":-262.3484,\"y\":6402.196,\"z\":30.2679367}', '{\"x\":-0.9070187,\"y\":0.154452771,\"z\":203.735489}');
INSERT INTO `garages` VALUES (334, -1, '{\"x\":-257.1984,\"y\":6362.292,\"z\":30.8133011}', '{\"x\":0.0251292922,\"y\":0.0133445561,\"z\":222.9628}');
INSERT INTO `garages` VALUES (335, -1, '{\"x\":-272.4165,\"y\":6359.09668,\"z\":31.3845081}', '{\"x\":6.04398775,\"y\":4.13225365,\"z\":41.1732178}');
INSERT INTO `garages` VALUES (336, -1, '{\"x\":-320.785736,\"y\":6319.62842,\"z\":30.74524}', '{\"x\":8.166174,\"y\":7.975442,\"z\":225.322235}');
INSERT INTO `garages` VALUES (337, -1, '{\"x\":-353.8614,\"y\":6335.393,\"z\":29.1726437}', '{\"x\":-0.0459854864,\"y\":0.203361183,\"z\":217.514328}');
INSERT INTO `garages` VALUES (338, -1, '{\"x\":-346.530731,\"y\":6313.2124,\"z\":29.2107849}', '{\"x\":-1.83178842,\"y\":-0.94834125,\"z\":310.268341}');
INSERT INTO `garages` VALUES (339, -1, '{\"x\":-395.4197,\"y\":6311.336,\"z\":28.3466549}', '{\"x\":2.69906664,\"y\":3.26014447,\"z\":39.4135132}');
INSERT INTO `garages` VALUES (340, -1, '{\"x\":-433.3022,\"y\":6260.16064,\"z\":29.5997868}', '{\"x\":0.4293684,\"y\":2.523392,\"z\":73.7939148}');
INSERT INTO `garages` VALUES (341, -1, '{\"x\":-352.716644,\"y\":6272.92432,\"z\":30.4512768}', '{\"x\":2.49317169,\"y\":3.29736066,\"z\":220.713379}');
INSERT INTO `garages` VALUES (342, -1, '{\"x\":-348.547333,\"y\":6216.41553,\"z\":30.8214436}', '{\"x\":-0.0208056532,\"y\":0.0229722634,\"z\":44.35327}');
INSERT INTO `garages` VALUES (343, -1, '{\"x\":-365.556061,\"y\":6197.093,\"z\":30.8210716}', '{\"x\":0.00685042469,\"y\":0.0316427834,\"z\":223.871078}');
INSERT INTO `garages` VALUES (344, -1, '{\"x\":-376.7708,\"y\":6182.595,\"z\":30.82299}', '{\"x\":-0.025243083,\"y\":-0.01876156,\"z\":43.5739136}');
INSERT INTO `garages` VALUES (345, -1, '{\"x\":-99.01574,\"y\":6334.18457,\"z\":30.82329}', '{\"x\":0.02403561,\"y\":-0.0271471832,\"z\":134.210571}');
INSERT INTO `garages` VALUES (346, -1, '{\"x\":-100.653847,\"y\":6338.919,\"z\":30.8228149}', '{\"x\":-0.0239097457,\"y\":-0.0212897137,\"z\":45.1802368}');
INSERT INTO `garages` VALUES (347, -1, '{\"x\":-98.27438,\"y\":6341.90234,\"z\":30.8219814}', '{\"x\":0.0135265011,\"y\":0.0171065349,\"z\":46.96689}');
INSERT INTO `garages` VALUES (348, -1, '{\"x\":-95.4736,\"y\":6344.57471,\"z\":30.8234787}', '{\"x\":0.0266801957,\"y\":0.0286765471,\"z\":226.245361}');
INSERT INTO `garages` VALUES (349, -1, '{\"x\":-93.21443,\"y\":6347.593,\"z\":30.8230839}', '{\"x\":0.0618182272,\"y\":0.0467431955,\"z\":227.806152}');
INSERT INTO `garages` VALUES (350, -1, '{\"x\":-80.0602,\"y\":6333.65674,\"z\":30.85692}', '{\"x\":0.05864316,\"y\":0.0848633051,\"z\":45.76416}');
INSERT INTO `garages` VALUES (351, -1, '{\"x\":-90.09242,\"y\":6349.781,\"z\":30.8228264}', '{\"x\":0.0240972359,\"y\":0.006195926,\"z\":224.853531}');
INSERT INTO `garages` VALUES (352, -1, '{\"x\":-87.4392853,\"y\":6352.36572,\"z\":30.82281}', '{\"x\":0.0214036684,\"y\":0.0186708849,\"z\":222.944626}');
INSERT INTO `garages` VALUES (353, -1, '{\"x\":-77.90317,\"y\":6336.797,\"z\":30.857645}', '{\"x\":-0.07245632,\"y\":0.00287244213,\"z\":43.7928772}');
INSERT INTO `garages` VALUES (354, -1, '{\"x\":-84.83293,\"y\":6355.41943,\"z\":30.8227959}', '{\"x\":0.0147266882,\"y\":0.02266172,\"z\":223.461578}');
INSERT INTO `garages` VALUES (355, -1, '{\"x\":-74.8333,\"y\":6339.487,\"z\":30.8567924}', '{\"x\":0.053966105,\"y\":0.0817429,\"z\":48.14624}');
INSERT INTO `garages` VALUES (356, -1, '{\"x\":-72.58706,\"y\":6341.96338,\"z\":30.857132}', '{\"x\":0.0381822661,\"y\":0.08402469,\"z\":44.2583}');
INSERT INTO `garages` VALUES (357, -1, '{\"x\":-77.4312057,\"y\":6347.253,\"z\":30.8576813}', '{\"x\":0.09697165,\"y\":0.0490933135,\"z\":222.6652}');
INSERT INTO `garages` VALUES (358, -1, '{\"x\":-79.609375,\"y\":6344.204,\"z\":30.8577652}', '{\"x\":0.07187016,\"y\":0.0201954953,\"z\":224.98}');
INSERT INTO `garages` VALUES (359, -1, '{\"x\":-82.5818558,\"y\":6341.686,\"z\":30.8578949}', '{\"x\":0.110455647,\"y\":0.06406615,\"z\":225.033661}');
INSERT INTO `garages` VALUES (360, -1, '{\"x\":-85.52991,\"y\":6338.681,\"z\":30.85716}', '{\"x\":-0.03547873,\"y\":-0.0529998653,\"z\":225.884659}');
INSERT INTO `garages` VALUES (361, 5, '{\"x\":-1890.06567,\"y\":121.119591,\"z\":81.0312958}', '{\"x\":-0.476954937,\"y\":0.7157803,\"z\":308.403168}');
INSERT INTO `garages` VALUES (362, 2, '{\"x\":-1936.91406,\"y\":181.533585,\"z\":83.99607}', '{\"x\":0.3867278,\"y\":-1.16262615,\"z\":314.387726}');
INSERT INTO `garages` VALUES (363, 4, '{\"x\":-1870.35229,\"y\":190.533417,\"z\":83.6621246}', '{\"x\":-0.01804998,\"y\":-0.01816322,\"z\":126.961853}');
INSERT INTO `garages` VALUES (364, 3, '{\"x\":-1902.92554,\"y\":240.1581,\"z\":85.618576}', '{\"x\":0.0246907678,\"y\":-0.118303828,\"z\":114.698456}');
INSERT INTO `garages` VALUES (365, 3, '{\"x\":-1921.415,\"y\":284.551666,\"z\":88.44011}', '{\"x\":-0.05090821,\"y\":-0.107315578,\"z\":102.770752}');
INSERT INTO `garages` VALUES (366, 3, '{\"x\":-1939.27063,\"y\":362.177429,\"z\":92.97706}', '{\"x\":-3.40319061,\"y\":3.0429666,\"z\":186.330627}');
INSERT INTO `garages` VALUES (367, 3, '{\"x\":-1941.2937,\"y\":385.7709,\"z\":95.8745346}', '{\"x\":0.0158126317,\"y\":0.104503565,\"z\":279.236542}');
INSERT INTO `garages` VALUES (368, 3, '{\"x\":-1938.87354,\"y\":560.380554,\"z\":114.490112}', '{\"x\":-7.22986555,\"y\":2.57419968,\"z\":70.27008}');
INSERT INTO `garages` VALUES (369, 4, '{\"x\":-1938.87231,\"y\":560.3821,\"z\":114.482811}', '{\"x\":-7.25178766,\"y\":2.504152,\"z\":70.270874}');
INSERT INTO `garages` VALUES (370, 4, '{\"x\":-1938.6156,\"y\":581.2324,\"z\":118.611389}', '{\"x\":-0.3778486,\"y\":7.81009865,\"z\":72.79608}');
INSERT INTO `garages` VALUES (371, 4, '{\"x\":-1887.49036,\"y\":628.3023,\"z\":129.3669}', '{\"x\":-0.07606759,\"y\":0.0252563562,\"z\":135.31665}');
INSERT INTO `garages` VALUES (372, 3, '{\"x\":-1887.49011,\"y\":628.302734,\"z\":129.36409}', '{\"x\":-0.0163918678,\"y\":-0.0247395728,\"z\":135.316864}');
INSERT INTO `garages` VALUES (373, 3, '{\"x\":-1975.35913,\"y\":624.4347,\"z\":121.898422}', '{\"x\":-0.298516929,\"y\":-0.104489155,\"z\":67.17929}');
INSERT INTO `garages` VALUES (374, 4, '{\"x\":-1975.35913,\"y\":624.434631,\"z\":121.893661}', '{\"x\":-0.317875862,\"y\":-0.148132309,\"z\":67.1789856}');
INSERT INTO `garages` VALUES (375, 3, '{\"x\":-2013.87671,\"y\":484.8731,\"z\":106.478683}', '{\"x\":-0.772639,\"y\":-3.100074,\"z\":75.01541}');
INSERT INTO `garages` VALUES (376, 4, '{\"x\":-2010.82715,\"y\":454.340942,\"z\":102.0338}', '{\"x\":-0.08475461,\"y\":-0.355176926,\"z\":109.990387}');
INSERT INTO `garages` VALUES (377, 3, '{\"x\":-2001.41187,\"y\":380.004181,\"z\":93.8501358}', '{\"x\":0.0449904,\"y\":0.09887204,\"z\":0.473510742}');
INSERT INTO `garages` VALUES (378, 4, '{\"x\":-1997.05725,\"y\":293.02124,\"z\":91.13192}', '{\"x\":-0.0327906273,\"y\":-0.0607722551,\"z\":104.240784}');
INSERT INTO `garages` VALUES (379, 3, '{\"x\":-1980.42017,\"y\":259.255249,\"z\":86.5806}', '{\"x\":0.08684491,\"y\":0.2112571,\"z\":109.530457}');
INSERT INTO `garages` VALUES (380, 3, '{\"x\":-1949.09534,\"y\":201.3582,\"z\":85.46914}', '{\"x\":1.27814281,\"y\":-5.93521547,\"z\":292.960083}');
INSERT INTO `garages` VALUES (381, 3, '{\"x\":-1937.48352,\"y\":181.514343,\"z\":84.00223}', '{\"x\":0.0411784947,\"y\":-0.975878954,\"z\":130.262024}');
INSERT INTO `garages` VALUES (382, 4, '{\"x\":-1857.30481,\"y\":324.61554,\"z\":88.07312}', '{\"x\":0.634698331,\"y\":0.1622505,\"z\":13.8666382}');
INSERT INTO `garages` VALUES (383, 4, '{\"x\":-1792.39539,\"y\":346.6928,\"z\":87.9206848}', '{\"x\":-0.1274703,\"y\":-0.13579002,\"z\":245.6596}');
INSERT INTO `garages` VALUES (384, 4, '{\"x\":-1748.13489,\"y\":366.823578,\"z\":89.0925}', '{\"x\":-0.01497556,\"y\":0.106471449,\"z\":297.854431}');
INSERT INTO `garages` VALUES (385, 3, '{\"x\":-1665.04956,\"y\":387.917664,\"z\":88.68083}', '{\"x\":1.365875,\"y\":0.737544358,\"z\":355.490143}');
INSERT INTO `garages` VALUES (386, 3, '{\"x\":-573.217468,\"y\":401.141479,\"z\":100.241264}', '{\"x\":0.196814492,\"y\":0.107946783,\"z\":211.485016}');
INSERT INTO `garages` VALUES (387, 3, '{\"x\":-575.4849,\"y\":400.081451,\"z\":100.23687}', '{\"x\":-0.155974612,\"y\":-0.05580883,\"z\":22.9853821}');
INSERT INTO `garages` VALUES (388, 3, '{\"x\":-604.0962,\"y\":397.755463,\"z\":101.300728}', '{\"x\":5.68234253,\"y\":0.373348147,\"z\":186.290421}');
INSERT INTO `garages` VALUES (389, 3, '{\"x\":-627.9096,\"y\":399.931427,\"z\":100.761978}', '{\"x\":2.01732945,\"y\":0.119519904,\"z\":184.878754}');
INSERT INTO `garages` VALUES (390, 3, '{\"x\":-514.4488,\"y\":425.210419,\"z\":96.5313339}', '{\"x\":4.20352936,\"y\":0.92179805,\"z\":43.252533}');
INSERT INTO `garages` VALUES (391, 3, '{\"x\":-536.217163,\"y\":484.421844,\"z\":102.593437}', '{\"x\":1.8543849,\"y\":2.56911087,\"z\":236.741226}');
INSERT INTO `garages` VALUES (392, 3, '{\"x\":-514.4175,\"y\":389.4025,\"z\":93.3423538}', '{\"x\":0.778904438,\"y\":1.12455571,\"z\":61.4201965}');
INSERT INTO `garages` VALUES (393, 3, '{\"x\":-490.3629,\"y\":410.308075,\"z\":98.66416}', '{\"x\":-1.32350361,\"y\":3.04503441,\"z\":153.968079}');
INSERT INTO `garages` VALUES (394, 3, '{\"x\":-455.72583,\"y\":378.018433,\"z\":104.292786}', '{\"x\":2.01803541,\"y\":0.0324485451,\"z\":5.904724}');
INSERT INTO `garages` VALUES (395, 3, '{\"x\":-393.222,\"y\":431.509,\"z\":111.816025}', '{\"x\":-2.44978261,\"y\":-4.51148939,\"z\":69.38309}');
INSERT INTO `garages` VALUES (396, 4, '{\"x\":-393.220032,\"y\":431.5082,\"z\":111.817261}', '{\"x\":-2.45739222,\"y\":-4.589269,\"z\":69.4160156}');
INSERT INTO `garages` VALUES (397, 3, '{\"x\":-351.865021,\"y\":426.085571,\"z\":110.206772}', '{\"x\":8.61084652,\"y\":3.094852,\"z\":196.866943}');
INSERT INTO `garages` VALUES (398, 3, '{\"x\":-318.164642,\"y\":431.491516,\"z\":109.351532}', '{\"x\":5.259579,\"y\":0.5552866,\"z\":199.659012}');
INSERT INTO `garages` VALUES (399, 3, '{\"x\":-96.57412,\"y\":428.120575,\"z\":112.637596}', '{\"x\":-0.716875434,\"y\":-0.258992136,\"z\":169.05188}');
INSERT INTO `garages` VALUES (400, 3, '{\"x\":15.2201939,\"y\":376.3611,\"z\":111.836884}', '{\"x\":-3.09096169,\"y\":2.9854672,\"z\":333.0981}');
INSERT INTO `garages` VALUES (401, 3, '{\"x\":25.5241737,\"y\":368.519623,\"z\":112.194725}', '{\"x\":-2.052587,\"y\":2.87318349,\"z\":304.247467}');
INSERT INTO `garages` VALUES (402, 3, '{\"x\":-184.243637,\"y\":419.149323,\"z\":110.316666}', '{\"x\":1.11823928,\"y\":0.284144282,\"z\":192.916779}');
INSERT INTO `garages` VALUES (403, 3, '{\"x\":-200.525314,\"y\":408.430328,\"z\":110.3346}', '{\"x\":7.424261,\"y\":1.52511108,\"z\":185.843781}');
INSERT INTO `garages` VALUES (404, 3, '{\"x\":-258.432953,\"y\":395.875671,\"z\":109.588669}', '{\"x\":0.404778838,\"y\":0.103894167,\"z\":192.929718}');
INSERT INTO `garages` VALUES (405, 3, '{\"x\":-305.567535,\"y\":378.1059,\"z\":109.908737}', '{\"x\":0.139871955,\"y\":0.1319299,\"z\":196.5821}');
INSERT INTO `garages` VALUES (406, 3, '{\"x\":-347.6364,\"y\":368.6656,\"z\":109.576935}', '{\"x\":0.438087016,\"y\":0.7338548,\"z\":206.082581}');
INSERT INTO `garages` VALUES (407, 3, '{\"x\":-380.518433,\"y\":345.3649,\"z\":108.806656}', '{\"x\":1.40941787,\"y\":1.00230968,\"z\":184.146057}');
INSERT INTO `garages` VALUES (408, 3, '{\"x\":-398.2808,\"y\":338.417938,\"z\":108.289467}', '{\"x\":0.250001073,\"y\":0.008103753,\"z\":180.411041}');
INSERT INTO `garages` VALUES (409, 3, '{\"x\":-432.51886,\"y\":344.262146,\"z\":105.485069}', '{\"x\":0.321726024,\"y\":4.104519,\"z\":181.243057}');
INSERT INTO `garages` VALUES (410, 3, '{\"x\":-473.7385,\"y\":351.963928,\"z\":103.65406}', '{\"x\":3.24812841,\"y\":-1.644716,\"z\":156.101563}');
INSERT INTO `garages` VALUES (411, 3, '{\"x\":-525.578064,\"y\":527.313049,\"z\":111.72377}', '{\"x\":4.86199045,\"y\":4.79756641,\"z\":224.687378}');
INSERT INTO `garages` VALUES (412, 3, '{\"x\":-482.631165,\"y\":548.555969,\"z\":119.522675}', '{\"x\":10.2334528,\"y\":-2.7675066,\"z\":163.487366}');
INSERT INTO `garages` VALUES (413, 3, '{\"x\":-469.806671,\"y\":540.6635,\"z\":120.753181}', '{\"x\":12.783555,\"y\":-0.124422185,\"z\":180.3752}');
INSERT INTO `garages` VALUES (414, 4, '{\"x\":-439.387177,\"y\":542.742859,\"z\":121.504425}', '{\"x\":10.4252272,\"y\":0.584079444,\"z\":160.080322}');
INSERT INTO `garages` VALUES (415, 3, '{\"x\":-401.91217,\"y\":510.8589,\"z\":119.773453}', '{\"x\":0.24037616,\"y\":-0.08149384,\"z\":149.7497}');
INSERT INTO `garages` VALUES (416, 3, '{\"x\":-359.2192,\"y\":515.487854,\"z\":119.411751}', '{\"x\":-5.014753,\"y\":4.77183,\"z\":315.5539}');
INSERT INTO `garages` VALUES (417, 3, '{\"x\":-314.6103,\"y\":481.54776,\"z\":112.774376}', '{\"x\":-5.16540051,\"y\":7.48513174,\"z\":296.287354}');
INSERT INTO `garages` VALUES (418, 3, '{\"x\":-354.57074,\"y\":474.454559,\"z\":112.230522}', '{\"x\":-2.40136,\"y\":2.849325,\"z\":106.795288}');
INSERT INTO `garages` VALUES (419, 3, '{\"x\":-318.242523,\"y\":431.675964,\"z\":109.328117}', '{\"x\":5.946087,\"y\":0.3261604,\"z\":189.188324}');
INSERT INTO `garages` VALUES (420, 3, '{\"x\":-245.3115,\"y\":493.8704,\"z\":125.3757}', '{\"x\":10.3304682,\"y\":7.57431936,\"z\":207.588348}');
INSERT INTO `garages` VALUES (421, 3, '{\"x\":-189.139114,\"y\":501.969818,\"z\":134.007339}', '{\"x\":5.2590723,\"y\":6.751808,\"z\":89.05121}');
INSERT INTO `garages` VALUES (422, 3, '{\"x\":21.7900276,\"y\":544.5429,\"z\":175.598618}', '{\"x\":0.0660519749,\"y\":0.118901029,\"z\":242.965988}');
INSERT INTO `garages` VALUES (423, 3, '{\"x\":51.44721,\"y\":561.8542,\"z\":179.853912}', '{\"x\":-0.843181849,\"y\":1.54275012,\"z\":210.478134}');
INSERT INTO `garages` VALUES (424, 3, '{\"x\":97.53255,\"y\":566.8623,\"z\":182.0429}', '{\"x\":8.453413,\"y\":1.696122,\"z\":3.94778442}');
INSERT INTO `garages` VALUES (425, 2, '{\"x\":131.22789,\"y\":567.6368,\"z\":183.159241}', '{\"x\":10.111455,\"y\":2.25997972,\"z\":188.27597}');
INSERT INTO `garages` VALUES (426, 3, '{\"x\":210.415527,\"y\":608.4594,\"z\":186.533737}', '{\"x\":1.83391583,\"y\":11.2689619,\"z\":63.3864136}');
INSERT INTO `garages` VALUES (427, 3, '{\"x\":229.137711,\"y\":680.8338,\"z\":189.211792}', '{\"x\":-2.549955,\"y\":3.88248229,\"z\":287.006561}');
INSERT INTO `garages` VALUES (428, 4, '{\"x\":229.138016,\"y\":680.832764,\"z\":189.215485}', '{\"x\":-2.68649626,\"y\":3.94372725,\"z\":286.962158}');
INSERT INTO `garages` VALUES (429, 4, '{\"x\":218.801239,\"y\":756.2561,\"z\":204.321091}', '{\"x\":1.66691637,\"y\":2.66931653,\"z\":242.458923}');
INSERT INTO `garages` VALUES (430, 3, '{\"x\":314.6278,\"y\":567.436157,\"z\":154.047058}', '{\"x\":2.29318738,\"y\":-2.67208457,\"z\":118.244446}');
INSERT INTO `garages` VALUES (431, 3, '{\"x\":317.4449,\"y\":494.1141,\"z\":152.460052}', '{\"x\":1.18807125,\"y\":-6.75394869,\"z\":111.091705}');
INSERT INTO `garages` VALUES (432, 4, '{\"x\":317.445862,\"y\":494.116119,\"z\":152.463043}', '{\"x\":1.2753973,\"y\":-6.85312,\"z\":111.108459}');
INSERT INTO `garages` VALUES (433, 3, '{\"x\":327.235535,\"y\":481.902832,\"z\":150.716782}', '{\"x\":1.07199669,\"y\":-6.540867,\"z\":222.063248}');
INSERT INTO `garages` VALUES (434, 3, '{\"x\":353.4941,\"y\":436.539124,\"z\":146.4754}', '{\"x\":8.5598135,\"y\":-16.4182835,\"z\":115.439209}');
INSERT INTO `garages` VALUES (435, 3, '{\"x\":391.658722,\"y\":430.3679,\"z\":143.1693}', '{\"x\":14.7441006,\"y\":-4.0730505,\"z\":174.034424}');
INSERT INTO `garages` VALUES (436, 4, '{\"x\":237.5766,\"y\":527.9727,\"z\":140.1476}', '{\"x\":-2.82924581,\"y\":-1.43904209,\"z\":298.8474}');
INSERT INTO `garages` VALUES (437, 3, '{\"x\":173.78389,\"y\":471.4963,\"z\":141.478516}', '{\"x\":0.171291724,\"y\":-0.03639029,\"z\":168.713684}');
INSERT INTO `garages` VALUES (438, 3, '{\"x\":113.456436,\"y\":498.264679,\"z\":146.718811}', '{\"x\":-0.133389458,\"y\":-0.0410745852,\"z\":14.3138428}');
INSERT INTO `garages` VALUES (439, 3, '{\"x\":105.519073,\"y\":479.4264,\"z\":146.822281}', '{\"x\":-2.32810688,\"y\":-2.33528686,\"z\":105.125458}');
INSERT INTO `garages` VALUES (440, 3, '{\"x\":89.3104858,\"y\":488.701,\"z\":147.419449}', '{\"x\":-3.645418,\"y\":-2.02821946,\"z\":26.04599}');
INSERT INTO `garages` VALUES (441, 3, '{\"x\":65.1379242,\"y\":455.645142,\"z\":146.410889}', '{\"x\":0.6633442,\"y\":2.13464522,\"z\":214.220535}');
INSERT INTO `garages` VALUES (442, 4, '{\"x\":65.1380539,\"y\":455.646454,\"z\":146.414948}', '{\"x\":0.763820469,\"y\":2.09649873,\"z\":214.222839}');
INSERT INTO `garages` VALUES (443, 3, '{\"x\":56.3135262,\"y\":468.832733,\"z\":146.4126}', '{\"x\":-5.15363359,\"y\":-0.7904937,\"z\":21.79004}');
INSERT INTO `garages` VALUES (444, 3, '{\"x\":0.3434922,\"y\":467.914917,\"z\":145.469589}', '{\"x\":3.85496855,\"y\":-1.25065374,\"z\":45.63159}');
INSERT INTO `garages` VALUES (445, 3, '{\"x\":-73.81686,\"y\":494.564758,\"z\":144.096527}', '{\"x\":3.33096361,\"y\":-0.7377843,\"z\":163.221741}');
INSERT INTO `garages` VALUES (446, 3, '{\"x\":-123.297729,\"y\":509.111,\"z\":142.585159}', '{\"x\":10.3550854,\"y\":1.34590089,\"z\":170.197815}');
INSERT INTO `garages` VALUES (447, 4, '{\"x\":-520.654541,\"y\":575.2078,\"z\":120.595284}', '{\"x\":0.5505894,\"y\":-2.88649464,\"z\":101.953491}');
INSERT INTO `garages` VALUES (448, 4, '{\"x\":-525.3975,\"y\":645.0897,\"z\":137.560074}', '{\"x\":-7.813028,\"y\":2.08910823,\"z\":293.328247}');
INSERT INTO `garages` VALUES (449, 3, '{\"x\":-519.31134,\"y\":694.3775,\"z\":149.970337}', '{\"x\":-2.32446432,\"y\":17.227499,\"z\":276.0352}');
INSERT INTO `garages` VALUES (450, 3, '{\"x\":-460.7233,\"y\":639.7052,\"z\":143.759567}', '{\"x\":0.114062853,\"y\":0.162942216,\"z\":228.559891}');
INSERT INTO `garages` VALUES (451, 3, '{\"x\":-465.4031,\"y\":674.1574,\"z\":147.613129}', '{\"x\":-8.364553,\"y\":8.259234,\"z\":316.2492}');
INSERT INTO `garages` VALUES (452, 3, '{\"x\":-394.0842,\"y\":670.5584,\"z\":162.73317}', '{\"x\":1.76570225,\"y\":6.37917,\"z\":181.6517}');
INSERT INTO `garages` VALUES (453, 3, '{\"x\":-394.016724,\"y\":670.530762,\"z\":162.520874}', '{\"x\":0.8881121,\"y\":5.68122673,\"z\":0.9760132}');
INSERT INTO `garages` VALUES (454, 3, '{\"x\":-344.434174,\"y\":664.3105,\"z\":168.734741}', '{\"x\":6.8524375,\"y\":-0.4077313,\"z\":352.0085}');
INSERT INTO `garages` VALUES (455, 4, '{\"x\":-339.9644,\"y\":631.8674,\"z\":171.7205}', '{\"x\":0.02163937,\"y\":-0.0224345252,\"z\":236.2494}');
INSERT INTO `garages` VALUES (456, 3, '{\"x\":-300.858948,\"y\":632.531738,\"z\":175.053864}', '{\"x\":1.8382349,\"y\":1.01744878,\"z\":300.4169}');
INSERT INTO `garages` VALUES (457, 3, '{\"x\":-276.112854,\"y\":598.1894,\"z\":181.04982}', '{\"x\":-0.0160546675,\"y\":-0.03115281,\"z\":176.3667}');
INSERT INTO `garages` VALUES (458, 3, '{\"x\":-242.8201,\"y\":611.9391,\"z\":186.697266}', '{\"x\":-6.963156,\"y\":9.930413,\"z\":326.9072}');
INSERT INTO `garages` VALUES (459, 3, '{\"x\":-224.108978,\"y\":590.793152,\"z\":189.4988}', '{\"x\":-4.56470871,\"y\":1.52172709,\"z\":178.821777}');
INSERT INTO `garages` VALUES (460, 4, '{\"x\":-196.807953,\"y\":619.2301,\"z\":197.236938}', '{\"x\":-1.930082,\"y\":-0.2830855,\"z\":359.93045}');
INSERT INTO `garages` VALUES (461, 3, '{\"x\":-178.301147,\"y\":586.097168,\"z\":196.994873}', '{\"x\":-0.134471536,\"y\":-0.0401135832,\"z\":181.510376}');
INSERT INTO `garages` VALUES (462, 4, '{\"x\":-143.809723,\"y\":595.0252,\"z\":203.195435}', '{\"x\":0.2816686,\"y\":2.94591665,\"z\":183.58783}');
INSERT INTO `garages` VALUES (463, 4, '{\"x\":-513.633667,\"y\":624.3163,\"z\":132.150085}', '{\"x\":-3.07024837,\"y\":-20.2059135,\"z\":293.819916}');
INSERT INTO `garages` VALUES (464, 3, '{\"x\":-559.072266,\"y\":688.1234,\"z\":144.747864}', '{\"x\":-0.0284494888,\"y\":0.0100072874,\"z\":344.166534}');
INSERT INTO `garages` VALUES (465, 3, '{\"x\":-522.4102,\"y\":711.9981,\"z\":152.06839}', '{\"x\":-23.950325,\"y\":-3.77337265,\"z\":13.1083374}');
INSERT INTO `garages` VALUES (466, 3, '{\"x\":-497.369659,\"y\":745.706665,\"z\":162.163849}', '{\"x\":0.00654471945,\"y\":0.0246613212,\"z\":67.98627}');
INSERT INTO `garages` VALUES (467, 3, '{\"x\":-484.813843,\"y\":797.13385,\"z\":179.978714}', '{\"x\":-7.93640947,\"y\":-0.258676559,\"z\":167.725342}');
INSERT INTO `garages` VALUES (468, 3, '{\"x\":-552.423767,\"y\":829.4139,\"z\":196.996765}', '{\"x\":-6.589411,\"y\":-1.710059,\"z\":162.1969}');
INSERT INTO `garages` VALUES (469, 3, '{\"x\":-609.0231,\"y\":864.854553,\"z\":212.679184}', '{\"x\":-4.436074,\"y\":-2.993023,\"z\":158.112915}');
INSERT INTO `garages` VALUES (470, 4, '{\"x\":-676.127136,\"y\":903.7377,\"z\":229.912674}', '{\"x\":-0.1673368,\"y\":0.0727789253,\"z\":143.041473}');
INSERT INTO `garages` VALUES (471, 4, '{\"x\":-748.404053,\"y\":820.187561,\"z\":212.7215}', '{\"x\":0.7768731,\"y\":0.2827148,\"z\":136.809631}');
INSERT INTO `garages` VALUES (472, 4, '{\"x\":-811.069336,\"y\":805.7863,\"z\":201.498947}', '{\"x\":0.8310197,\"y\":0.379410267,\"z\":200.122665}');
INSERT INTO `garages` VALUES (473, 3, '{\"x\":-851.274,\"y\":790.4348,\"z\":191.095428}', '{\"x\":-1.5523814,\"y\":0.113875665,\"z\":185.387146}');
INSERT INTO `garages` VALUES (474, 3, '{\"x\":-905.016846,\"y\":782.103455,\"z\":185.517365}', '{\"x\":6.97108936,\"y\":2.29495668,\"z\":189.3788}');
INSERT INTO `garages` VALUES (475, 3, '{\"x\":-918.5481,\"y\":810.048035,\"z\":183.668564}', '{\"x\":-0.0107242316,\"y\":0.0008805333,\"z\":9.379456}');
INSERT INTO `garages` VALUES (476, 3, '{\"x\":-956.7317,\"y\":802.2442,\"z\":176.99791}', '{\"x\":3.52364349,\"y\":2.58828688,\"z\":5.661377}');
INSERT INTO `garages` VALUES (477, 3, '{\"x\":-996.4413,\"y\":810.6595,\"z\":171.80304}', '{\"x\":-0.424393415,\"y\":3.069008,\"z\":179.826111}');
INSERT INTO `garages` VALUES (478, 3, '{\"x\":-965.1972,\"y\":762.8898,\"z\":174.770126}', '{\"x\":0.723111749,\"y\":0.9463938,\"z\":224.633743}');
INSERT INTO `garages` VALUES (479, 3, '{\"x\":-1001.39154,\"y\":784.7924,\"z\":170.88298}', '{\"x\":-1.12544513,\"y\":4.72289228,\"z\":111.515808}');
INSERT INTO `garages` VALUES (480, 4, '{\"x\":-1041.27112,\"y\":796.8855,\"z\":166.607758}', '{\"x\":4.620543,\"y\":3.20184135,\"z\":14.8683167}');
INSERT INTO `garages` VALUES (481, 3, '{\"x\":-1054.16223,\"y\":768.742859,\"z\":167.011383}', '{\"x\":0.324085027,\"y\":-3.08059764,\"z\":96.12329}');
INSERT INTO `garages` VALUES (482, 3, '{\"x\":-1107.64392,\"y\":796.85144,\"z\":164.705566}', '{\"x\":-4.69878,\"y\":-0.52779156,\"z\":8.516663}');
INSERT INTO `garages` VALUES (483, 3, '{\"x\":-1115.04236,\"y\":769.0133,\"z\":162.691238}', '{\"x\":5.48912764,\"y\":2.33820224,\"z\":207.590836}');
INSERT INTO `garages` VALUES (484, 3, '{\"x\":-1123.95715,\"y\":790.394043,\"z\":162.866577}', '{\"x\":-7.991196,\"y\":-6.115117,\"z\":54.51422}');
INSERT INTO `garages` VALUES (485, 3, '{\"x\":-1159.34729,\"y\":740.0949,\"z\":154.779}', '{\"x\":1.574946,\"y\":2.52733016,\"z\":227.297638}');
INSERT INTO `garages` VALUES (486, 3, '{\"x\":-1200.41064,\"y\":689.877258,\"z\":146.475174}', '{\"x\":1.50764751,\"y\":9.099041,\"z\":67.8705444}');
INSERT INTO `garages` VALUES (487, 3, '{\"x\":-1223.47827,\"y\":663.119934,\"z\":143.248718}', '{\"x\":9.051219,\"y\":14.1380329,\"z\":233.408844}');
INSERT INTO `garages` VALUES (488, 3, '{\"x\":-1250.79871,\"y\":666.1788,\"z\":142.1462}', '{\"x\":-0.360724628,\"y\":-0.08941669,\"z\":18.4104919}');
INSERT INTO `garages` VALUES (489, 3, '{\"x\":-1235.55933,\"y\":653.2947,\"z\":141.8696}', '{\"x\":9.803303,\"y\":8.696431,\"z\":113.78537}');
INSERT INTO `garages` VALUES (490, 3, '{\"x\":-1286.58521,\"y\":650.4122,\"z\":139.23494}', '{\"x\":-2.06927514,\"y\":-0.5121721,\"z\":23.4772034}');
INSERT INTO `garages` VALUES (491, 3, '{\"x\":-1287.62085,\"y\":624.4757,\"z\":138.274429}', '{\"x\":4.5563283,\"y\":4.86915827,\"z\":221.939865}');
INSERT INTO `garages` VALUES (492, 3, '{\"x\":-1343.257,\"y\":612.0369,\"z\":133.077164}', '{\"x\":-0.527695,\"y\":-2.58402228,\"z\":275.0728}');
INSERT INTO `garages` VALUES (493, 3, '{\"x\":-1364.09937,\"y\":603.9584,\"z\":133.2131}', '{\"x\":-0.1611457,\"y\":0.3134007,\"z\":105.66922}');
INSERT INTO `garages` VALUES (494, 3, '{\"x\":-1358.485,\"y\":579.800049,\"z\":130.775635}', '{\"x\":-1.0782758,\"y\":1.32879925,\"z\":72.32782}');
INSERT INTO `garages` VALUES (495, 3, '{\"x\":-1358.418,\"y\":552.634033,\"z\":129.502686}', '{\"x\":10.5000906,\"y\":13.3781223,\"z\":233.355316}');
INSERT INTO `garages` VALUES (496, 3, '{\"x\":-1411.99231,\"y\":559.6732,\"z\":124.030762}', '{\"x\":-22.90776,\"y\":-1.36139226,\"z\":101.238251}');
INSERT INTO `garages` VALUES (497, 3, '{\"x\":-1454.34021,\"y\":533.9593,\"z\":118.619164}', '{\"x\":-6.92659044,\"y\":-2.797507,\"z\":72.96921}');
INSERT INTO `garages` VALUES (498, 3, '{\"x\":-1470.80469,\"y\":511.01947,\"z\":117.035721}', '{\"x\":-2.58284974,\"y\":-0.720741749,\"z\":192.706268}');
INSERT INTO `garages` VALUES (499, 3, '{\"x\":-1487.92578,\"y\":527.5914,\"z\":117.604607}', '{\"x\":0.025849646,\"y\":0.016689213,\"z\":212.5488}');
INSERT INTO `garages` VALUES (500, 3, '{\"x\":-1496.4054,\"y\":417.012573,\"z\":110.440445}', '{\"x\":-0.0407940969,\"y\":-0.03685148,\"z\":223.969788}');
INSERT INTO `garages` VALUES (501, 4, '{\"x\":-1552.40967,\"y\":427.391144,\"z\":108.72699}', '{\"x\":3.9126482,\"y\":0.250678658,\"z\":96.28113}');
INSERT INTO `garages` VALUES (502, 3, '{\"x\":-661.7799,\"y\":805.804443,\"z\":198.52037}', '{\"x\":-6.17845726,\"y\":-0.784275532,\"z\":184.827118}');
INSERT INTO `garages` VALUES (503, 3, '{\"x\":-594.867737,\"y\":808.532043,\"z\":190.214645}', '{\"x\":0.804412246,\"y\":-1.69167411,\"z\":331.527283}');
INSERT INTO `garages` VALUES (504, 3, '{\"x\":-595.1351,\"y\":753.8886,\"z\":183.048477}', '{\"x\":0.0211250409,\"y\":0.0160954334,\"z\":78.36322}');
INSERT INTO `garages` VALUES (505, 2, '{\"x\":-573.1003,\"y\":754.887,\"z\":184.02095}', '{\"x\":-0.237034708,\"y\":2.61280584,\"z\":245.569351}');
INSERT INTO `garages` VALUES (506, 3, '{\"x\":-577.3674,\"y\":742.494141,\"z\":183.260025}', '{\"x\":-1.3223182,\"y\":5.374974,\"z\":252.2452}');
INSERT INTO `garages` VALUES (507, 3, '{\"x\":-670.309143,\"y\":750.207947,\"z\":173.2058}', '{\"x\":-5.456044,\"y\":2.617772,\"z\":181.24556}');
INSERT INTO `garages` VALUES (508, 3, '{\"x\":-695.9677,\"y\":705.9461,\"z\":156.6361}', '{\"x\":7.530169,\"y\":-16.8645668,\"z\":162.990967}');
INSERT INTO `garages` VALUES (509, 3, '{\"x\":-615.9028,\"y\":676.836731,\"z\":149.2131}', '{\"x\":2.66021848,\"y\":-1.98280418,\"z\":172.954346}');
INSERT INTO `garages` VALUES (510, 3, '{\"x\":-666.7311,\"y\":669.4791,\"z\":149.748627}', '{\"x\":-0.306516737,\"y\":0.1296902,\"z\":257.5401}');
INSERT INTO `garages` VALUES (511, 4, '{\"x\":-709.9111,\"y\":643.689,\"z\":154.50853}', '{\"x\":-0.04109626,\"y\":0.0277437828,\"z\":168.775757}');
INSERT INTO `garages` VALUES (512, 3, '{\"x\":-670.524231,\"y\":646.0281,\"z\":148.713}', '{\"x\":-1.13120317,\"y\":4.32650375,\"z\":261.266}');
INSERT INTO `garages` VALUES (513, 3, '{\"x\":-684.6076,\"y\":602.859,\"z\":142.940338}', '{\"x\":-1.87512553,\"y\":1.28185606,\"z\":55.09485}');
INSERT INTO `garages` VALUES (514, 3, '{\"x\":-723.525757,\"y\":592.2462,\"z\":141.182388}', '{\"x\":-0.8433826,\"y\":0.191339433,\"z\":10.014679}');
INSERT INTO `garages` VALUES (515, 3, '{\"x\":-743.0438,\"y\":601.8779,\"z\":141.448364}', '{\"x\":7.03913164,\"y\":-5.09511948,\"z\":329.2552}');
INSERT INTO `garages` VALUES (516, 3, '{\"x\":-753.923767,\"y\":628.758362,\"z\":141.9369}', '{\"x\":0.9594732,\"y\":-5.160264,\"z\":301.872559}');
INSERT INTO `garages` VALUES (517, 3, '{\"x\":-768.264832,\"y\":665.269,\"z\":144.431641}', '{\"x\":4.86678648,\"y\":-10.454114,\"z\":116.0813}');
INSERT INTO `garages` VALUES (518, 3, '{\"x\":-809.823059,\"y\":703.3434,\"z\":146.476517}', '{\"x\":1.78949952,\"y\":-0.582614541,\"z\":201.926849}');
INSERT INTO `garages` VALUES (519, 3, '{\"x\":-864.1763,\"y\":698.492859,\"z\":148.369812}', '{\"x\":-0.96806854,\"y\":-0.238533154,\"z\":154.0747}');
INSERT INTO `garages` VALUES (520, 3, '{\"x\":-884.2854,\"y\":705.082153,\"z\":149.270142}', '{\"x\":-3.104808,\"y\":-2.48178172,\"z\":81.98013}');
INSERT INTO `garages` VALUES (521, 3, '{\"x\":-913.521057,\"y\":695.873535,\"z\":150.755463}', '{\"x\":0.769333541,\"y\":-1.38761425,\"z\":169.978149}');
INSERT INTO `garages` VALUES (522, 3, '{\"x\":-949.628357,\"y\":686.739441,\"z\":152.910919}', '{\"x\":0.03211933,\"y\":0.0110619646,\"z\":181.152451}');
INSERT INTO `garages` VALUES (523, 3, '{\"x\":-1004.90942,\"y\":713.5253,\"z\":163.144577}', '{\"x\":-7.879491,\"y\":0.5364449,\"z\":357.075562}');
INSERT INTO `garages` VALUES (524, 2, '{\"x\":-1004.90845,\"y\":713.526,\"z\":163.144958}', '{\"x\":-7.82770061,\"y\":0.437577635,\"z\":357.0847}');
INSERT INTO `garages` VALUES (525, 3, '{\"x\":-1022.18964,\"y\":691.2388,\"z\":160.502136}', '{\"x\":-1.687566,\"y\":0.0320693478,\"z\":179.581909}');
INSERT INTO `garages` VALUES (526, 3, '{\"x\":-982.019836,\"y\":693.582,\"z\":156.418381}', '{\"x\":-2.31813717,\"y\":-7.20604753,\"z\":96.67313}');
INSERT INTO `garages` VALUES (527, 3, '{\"x\":-1418.17932,\"y\":466.143,\"z\":108.790459}', '{\"x\":7.436594,\"y\":-3.320999,\"z\":164.755981}');
INSERT INTO `garages` VALUES (528, 3, '{\"x\":-1373.20007,\"y\":452.075653,\"z\":104.502251}', '{\"x\":0.923652351,\"y\":6.199307,\"z\":263.588531}');
INSERT INTO `garages` VALUES (529, 3, '{\"x\":-1322.996,\"y\":447.57254,\"z\":99.0974}', '{\"x\":1.07088685,\"y\":-0.420573771,\"z\":181.679642}');
INSERT INTO `garages` VALUES (530, 3, '{\"x\":-1270.23779,\"y\":451.352325,\"z\":94.2}', '{\"x\":-2.33792472,\"y\":-3.85642266,\"z\":226.491867}');
INSERT INTO `garages` VALUES (531, 3, '{\"x\":-1270.47119,\"y\":507.8967,\"z\":96.58537}', '{\"x\":-0.696651757,\"y\":-4.243904,\"z\":359.881165}');
INSERT INTO `garages` VALUES (532, 3, '{\"x\":-1231.00525,\"y\":461.48938,\"z\":91.16019}', '{\"x\":2.01607633,\"y\":-1.05603433,\"z\":193.28241}');
INSERT INTO `garages` VALUES (533, 3, '{\"x\":-1176.99927,\"y\":455.5716,\"z\":85.97146}', '{\"x\":-0.221057609,\"y\":-0.165419608,\"z\":265.872223}');
INSERT INTO `garages` VALUES (534, 3, '{\"x\":-1164.46472,\"y\":479.224457,\"z\":85.41104}', '{\"x\":-0.609541,\"y\":-0.267082185,\"z\":2.27584839}');
INSERT INTO `garages` VALUES (535, 3, '{\"x\":-1115.23108,\"y\":483.2143,\"z\":81.49316}', '{\"x\":-0.03345479,\"y\":-0.0176169947,\"z\":350.255585}');
INSERT INTO `garages` VALUES (536, 3, '{\"x\":-1098.16614,\"y\":439.674225,\"z\":74.61923}', '{\"x\":0.0392837152,\"y\":0.05797326,\"z\":87.14316}');
INSERT INTO `garages` VALUES (537, 3, '{\"x\":-1064.91028,\"y\":437.594452,\"z\":73.19719}', '{\"x\":-0.0263144337,\"y\":-0.08410076,\"z\":278.1754}');
INSERT INTO `garages` VALUES (538, 3, '{\"x\":-1075.95532,\"y\":465.7713,\"z\":77.03843}', '{\"x\":-1.61493552,\"y\":1.03451645,\"z\":330.145569}');
INSERT INTO `garages` VALUES (539, 3, '{\"x\":-1044.72253,\"y\":501.07193,\"z\":83.4519348}', '{\"x\":-1.672367,\"y\":-1.11217988,\"z\":44.97455}');
INSERT INTO `garages` VALUES (540, 3, '{\"x\":-1014.07074,\"y\":487.8369,\"z\":78.74353}', '{\"x\":1.02321088,\"y\":1.06156528,\"z\":158.267578}');
INSERT INTO `garages` VALUES (541, 3, '{\"x\":-1011.25159,\"y\":510.315765,\"z\":79.02462}', '{\"x\":-1.76326323,\"y\":-0.409733325,\"z\":2.75540161}');
INSERT INTO `garages` VALUES (542, 3, '{\"x\":-993.539063,\"y\":488.729553,\"z\":81.74319}', '{\"x\":0.210900262,\"y\":-0.0034693277,\"z\":190.345215}');
INSERT INTO `garages` VALUES (543, 3, '{\"x\":-975.089661,\"y\":518.807068,\"z\":80.9485}', '{\"x\":-0.163167,\"y\":0.235144526,\"z\":327.0825}');
INSERT INTO `garages` VALUES (544, 3, '{\"x\":-940.5181,\"y\":444.388367,\"z\":79.88881}', '{\"x\":0.258921325,\"y\":-0.0852299258,\"z\":155.390381}');
INSERT INTO `garages` VALUES (545, 4, '{\"x\":-940.5168,\"y\":444.387939,\"z\":79.8885}', '{\"x\":0.2331396,\"y\":-0.205998421,\"z\":155.389954}');
INSERT INTO `garages` VALUES (546, 3, '{\"x\":-990.595032,\"y\":421.594757,\"z\":74.65253}', '{\"x\":-0.3070083,\"y\":-0.416426122,\"z\":23.9503479}');
INSERT INTO `garages` VALUES (547, 3, '{\"x\":-1208.96411,\"y\":558.4015,\"z\":98.97323}', '{\"x\":-14.016223,\"y\":0.830851555,\"z\":3.13601685}');
INSERT INTO `garages` VALUES (548, 3, '{\"x\":-1158.12451,\"y\":567.163,\"z\":101.199547}', '{\"x\":0.0981274843,\"y\":0.0615812652,\"z\":13.4711}');
INSERT INTO `garages` VALUES (549, 3, '{\"x\":-1158.05444,\"y\":547.450134,\"z\":100.2241}', '{\"x\":-1.47022212,\"y\":2.14623761,\"z\":289.0485}');
INSERT INTO `garages` VALUES (550, 3, '{\"x\":-1134.783,\"y\":549.5058,\"z\":101.547134}', '{\"x\":11.8532209,\"y\":4.068873,\"z\":219.323471}');
INSERT INTO `garages` VALUES (551, 3, '{\"x\":-1105.55042,\"y\":549.547668,\"z\":101.9997}', '{\"x\":1.14249051,\"y\":1.03460276,\"z\":216.6273}');
INSERT INTO `garages` VALUES (552, 3, '{\"x\":-1096.17407,\"y\":599.3339,\"z\":102.431549}', '{\"x\":0.007893325,\"y\":0.04407991,\"z\":34.40045}');
INSERT INTO `garages` VALUES (553, 3, '{\"x\":-1037.892,\"y\":590.2505,\"z\":102.612022}', '{\"x\":4.92155027,\"y\":-0.0250703283,\"z\":183.811691}');
INSERT INTO `garages` VALUES (554, 3, '{\"x\":-987.8019,\"y\":586.7104,\"z\":101.688362}', '{\"x\":2.851083,\"y\":-0.6807389,\"z\":182.088516}');
INSERT INTO `garages` VALUES (555, 3, '{\"x\":-946.3865,\"y\":594.7631,\"z\":100.372108}', '{\"x\":-0.0515157469,\"y\":0.0662767142,\"z\":341.2866}');
INSERT INTO `garages` VALUES (556, 3, '{\"x\":-954.839539,\"y\":579.06366,\"z\":100.411705}', '{\"x\":3.42285085,\"y\":-4.26476431,\"z\":127.21106}');
INSERT INTO `garages` VALUES (557, 3, '{\"x\":-933.920532,\"y\":569.847839,\"z\":99.33654}', '{\"x\":4.57690763,\"y\":-4.504255,\"z\":149.233276}');
INSERT INTO `garages` VALUES (558, 3, '{\"x\":-911.124146,\"y\":589.068542,\"z\":100.370255}', '{\"x\":0.282563955,\"y\":-0.08949582,\"z\":326.140778}');
INSERT INTO `garages` VALUES (559, 3, '{\"x\":-910.7373,\"y\":553.120056,\"z\":95.33627}', '{\"x\":-10.7640686,\"y\":3.90862322,\"z\":133.303772}');
INSERT INTO `garages` VALUES (560, 3, '{\"x\":-872.778931,\"y\":540.9969,\"z\":91.59354}', '{\"x\":-9.89554,\"y\":8.393225,\"z\":317.004425}');
INSERT INTO `garages` VALUES (561, 3, '{\"x\":-847.4851,\"y\":514.7722,\"z\":89.98887}', '{\"x\":0.0513105951,\"y\":-0.121297158,\"z\":278.015137}');
INSERT INTO `garages` VALUES (562, 3, '{\"x\":-875.4125,\"y\":498.572479,\"z\":90.33811}', '{\"x\":0.765985668,\"y\":-1.93331563,\"z\":101.538818}');
INSERT INTO `garages` VALUES (563, 3, '{\"x\":-845.056152,\"y\":460.932648,\"z\":87.19222}', '{\"x\":-1.39833319,\"y\":10.1181469,\"z\":280.352234}');
INSERT INTO `garages` VALUES (564, 3, '{\"x\":-862.943848,\"y\":463.566833,\"z\":87.38125}', '{\"x\":1.26785922,\"y\":-8.756319,\"z\":103.962067}');
INSERT INTO `garages` VALUES (565, 3, '{\"x\":-806.375061,\"y\":425.085876,\"z\":90.94898}', '{\"x\":-0.488576025,\"y\":0.475839436,\"z\":187.8853}');
INSERT INTO `garages` VALUES (566, 3, '{\"x\":-755.6159,\"y\":438.779175,\"z\":99.2197342}', '{\"x\":2.3393383,\"y\":4.417657,\"z\":201.507431}');
INSERT INTO `garages` VALUES (567, 3, '{\"x\":-767.699,\"y\":468.056915,\"z\":99.61076}', '{\"x\":2.770103,\"y\":3.20333338,\"z\":35.9471436}');
INSERT INTO `garages` VALUES (568, 3, '{\"x\":-734.1118,\"y\":443.879547,\"z\":106.259644}', '{\"x\":0.446924776,\"y\":0.188947827,\"z\":211.662735}');
INSERT INTO `garages` VALUES (569, 3, '{\"x\":-716.7658,\"y\":495.654816,\"z\":108.645912}', '{\"x\":0.0162292458,\"y\":0.05824936,\"z\":27.55774}');
INSERT INTO `garages` VALUES (570, 3, '{\"x\":-690.3391,\"y\":510.6095,\"z\":109.731049}', '{\"x\":0.03263803,\"y\":0.02652882,\"z\":17.250061}');
INSERT INTO `garages` VALUES (571, 3, '{\"x\":-660.0487,\"y\":489.8539,\"z\":109.20121}', '{\"x\":1.9151727,\"y\":-1.34876311,\"z\":283.778625}');
INSERT INTO `garages` VALUES (572, 3, '{\"x\":-633.0753,\"y\":522.795044,\"z\":109.05117}', '{\"x\":-0.11541979,\"y\":0.348532915,\"z\":9.786102}');
INSERT INTO `garages` VALUES (573, 3, '{\"x\":-615.0242,\"y\":492.592773,\"z\":107.773186}', '{\"x\":14.6354971,\"y\":2.23107,\"z\":187.067291}');
INSERT INTO `garages` VALUES (574, 4, '{\"x\":-575.150146,\"y\":496.090271,\"z\":106.010506}', '{\"x\":11.1715,\"y\":0.47111696,\"z\":191.4893}');
INSERT INTO `garages` VALUES (575, 1, '{\"x\":77.38936,\"y\":-1935.06946,\"z\":20.1851521}', '{\"x\":2.54431415,\"y\":-1.256147,\"z\":318.105438}');
INSERT INTO `garages` VALUES (576, 0, '{\"x\":53.7480621,\"y\":-1878.02979,\"z\":21.6544914}', '{\"x\":-3.63131881,\"y\":0.9226608,\"z\":135.942444}');
INSERT INTO `garages` VALUES (577, 0, '{\"x\":46.5663452,\"y\":-1915.205,\"z\":20.989954}', '{\"x\":0.596267641,\"y\":0.6228704,\"z\":320.308838}');
INSERT INTO `garages` VALUES (578, 0, '{\"x\":40.68064,\"y\":-1854.55554,\"z\":22.2006969}', '{\"x\":-0.04983826,\"y\":0.03465881,\"z\":314.5436}');
INSERT INTO `garages` VALUES (579, 0, '{\"x\":10.7845678,\"y\":-1845.46216,\"z\":23.7188778}', '{\"x\":-3.97469115,\"y\":1.1170963,\"z\":321.7771}');
INSERT INTO `garages` VALUES (580, 0, '{\"x\":34.1948967,\"y\":-1893.78589,\"z\":21.5225487}', '{\"x\":-0.446701854,\"y\":-0.591674447,\"z\":319.638123}');
INSERT INTO `garages` VALUES (581, 0, '{\"x\":18.6308784,\"y\":-1879.70679,\"z\":22.3544674}', '{\"x\":-0.2277754,\"y\":-2.89903164,\"z\":321.36087}');
INSERT INTO `garages` VALUES (582, 0, '{\"x\":-49.7368774,\"y\":-1798.76526,\"z\":26.4953842}', '{\"x\":-3.244296,\"y\":-0.101986468,\"z\":157.7846}');
INSERT INTO `garages` VALUES (583, 0, '{\"x\":3.07958555,\"y\":-1875.06323,\"z\":23.03005}', '{\"x\":-1.59528744,\"y\":-1.73270726,\"z\":318.437164}');
INSERT INTO `garages` VALUES (584, 0, '{\"x\":-56.1618042,\"y\":-1785.157,\"z\":27.214386}', '{\"x\":-0.0286757555,\"y\":-0.0622597225,\"z\":317.507965}');
INSERT INTO `garages` VALUES (585, 0, '{\"x\":-22.219408,\"y\":-1851.77319,\"z\":24.4286213}', '{\"x\":-1.68897939,\"y\":-0.79726547,\"z\":319.918945}');
INSERT INTO `garages` VALUES (586, 0, '{\"x\":-29.1189079,\"y\":-1852.76978,\"z\":25.100069}', '{\"x\":-1.25521684,\"y\":-1.99046743,\"z\":139.647125}');
INSERT INTO `garages` VALUES (587, 0, '{\"x\":-53.0929832,\"y\":-1455.546,\"z\":31.38017}', '{\"x\":-0.6901591,\"y\":-1.0939635,\"z\":184.449249}');
INSERT INTO `garages` VALUES (588, 0, '{\"x\":-41.0519638,\"y\":-1459.87756,\"z\":30.898}', '{\"x\":2.27995229,\"y\":-3.43595648,\"z\":270.722565}');
INSERT INTO `garages` VALUES (589, 0, '{\"x\":-38.3895569,\"y\":-1448.35156,\"z\":30.836916}', '{\"x\":0.4888895,\"y\":0.0351118371,\"z\":183.8384}');
INSERT INTO `garages` VALUES (590, 0, '{\"x\":7.216839,\"y\":-1452.69568,\"z\":29.8394833}', '{\"x\":-1.44254947,\"y\":0.2835136,\"z\":169.6933}');
INSERT INTO `garages` VALUES (591, 0, '{\"x\":-8.010869,\"y\":-1531.20923,\"z\":29.1229382}', '{\"x\":-1.00543475,\"y\":-1.025139,\"z\":141.555054}');
INSERT INTO `garages` VALUES (592, 0, '{\"x\":-4.91187763,\"y\":-1532.8584,\"z\":29.0353088}', '{\"x\":-1.16423953,\"y\":-1.74601,\"z\":140.724548}');
INSERT INTO `garages` VALUES (593, 0, '{\"x\":-2.27349663,\"y\":-1535.14624,\"z\":28.90485}', '{\"x\":-1.42387092,\"y\":-1.71064651,\"z\":140.1124}');
INSERT INTO `garages` VALUES (594, 0, '{\"x\":1.05641651,\"y\":-1537.1886,\"z\":28.7517}', '{\"x\":-1.520658,\"y\":-0.9879014,\"z\":139.149963}');
INSERT INTO `garages` VALUES (595, 0, '{\"x\":-59.5555878,\"y\":-1492.60571,\"z\":31.0938358}', '{\"x\":-0.660406649,\"y\":-0.247501329,\"z\":137.2673}');
INSERT INTO `garages` VALUES (596, 0, '{\"x\":-7.91139555,\"y\":-1553.44824,\"z\":28.7908363}', '{\"x\":-2.61295152,\"y\":-3.28995776,\"z\":231.932831}');
INSERT INTO `garages` VALUES (597, 0, '{\"x\":-55.7934036,\"y\":-1495.328,\"z\":31.0042324}', '{\"x\":-1.27580965,\"y\":-1.57754731,\"z\":140.591156}');
INSERT INTO `garages` VALUES (598, 0, '{\"x\":-10.491663,\"y\":-1556.817,\"z\":28.78197}', '{\"x\":-2.76628947,\"y\":-3.4621098,\"z\":231.968369}');
INSERT INTO `garages` VALUES (599, 0, '{\"x\":-60.4197044,\"y\":-1502.4635,\"z\":31.233036}', '{\"x\":6.31992149,\"y\":-7.38646269,\"z\":228.5792}');
INSERT INTO `garages` VALUES (600, 0, '{\"x\":-66.10895,\"y\":-1497.33313,\"z\":31.3703365}', '{\"x\":4.137382,\"y\":-5.0344243,\"z\":229.445724}');
INSERT INTO `garages` VALUES (601, 0, '{\"x\":-12.8860922,\"y\":-1559.83032,\"z\":28.7775326}', '{\"x\":-2.95012331,\"y\":-3.41965866,\"z\":230.799255}');
INSERT INTO `garages` VALUES (602, 0, '{\"x\":-54.3304825,\"y\":-1501.62451,\"z\":30.73622}', '{\"x\":-2.77870917,\"y\":0.07062269,\"z\":48.0249634}');
INSERT INTO `garages` VALUES (603, 0, '{\"x\":-49.8267174,\"y\":-1505.52478,\"z\":30.5237}', '{\"x\":-2.85922384,\"y\":-0.4574167,\"z\":49.0658569}');
INSERT INTO `garages` VALUES (604, 0, '{\"x\":-17.52505,\"y\":-1532.47,\"z\":29.1705933}', '{\"x\":-2.723525,\"y\":-0.0242035426,\"z\":53.006897}');
INSERT INTO `garages` VALUES (605, 0, '{\"x\":-44.0828476,\"y\":-1510.20264,\"z\":30.27636}', '{\"x\":-2.699595,\"y\":-0.06933615,\"z\":51.3114}');
INSERT INTO `garages` VALUES (606, 0, '{\"x\":-24.2815018,\"y\":-1527.2937,\"z\":29.4662323}', '{\"x\":-1.63461244,\"y\":-0.6061791,\"z\":51.6393738}');
INSERT INTO `garages` VALUES (607, 0, '{\"x\":-38.74572,\"y\":-1509.55139,\"z\":30.238802}', '{\"x\":-1.23042524,\"y\":-1.77354145,\"z\":137.469818}');
INSERT INTO `garages` VALUES (608, 0, '{\"x\":-30.0415878,\"y\":-1526.04187,\"z\":29.8212051}', '{\"x\":5.74802637,\"y\":-6.59203243,\"z\":49.6642761}');
INSERT INTO `garages` VALUES (609, 0, '{\"x\":-35.32902,\"y\":-1512.07861,\"z\":30.0516949}', '{\"x\":-1.50478625,\"y\":-2.03839517,\"z\":139.39679}');
INSERT INTO `garages` VALUES (610, 0, '{\"x\":-9.1586895,\"y\":-1543.59363,\"z\":28.79504}', '{\"x\":1.5091877,\"y\":-3.28884649,\"z\":47.1331177}');
INSERT INTO `garages` VALUES (611, 0, '{\"x\":-40.333683,\"y\":-1519.03918,\"z\":30.2871552}', '{\"x\":4.463183,\"y\":-6.378689,\"z\":228.554153}');
INSERT INTO `garages` VALUES (612, 0, '{\"x\":-15.7357,\"y\":-1539.251,\"z\":29.19351}', '{\"x\":1.41735,\"y\":-5.721473,\"z\":52.8265076}');
INSERT INTO `garages` VALUES (613, 0, '{\"x\":-44.9708672,\"y\":-1515.26685,\"z\":30.46629}', '{\"x\":3.75216651,\"y\":-6.009626,\"z\":228.148743}');
INSERT INTO `garages` VALUES (614, 0, '{\"x\":-82.26419,\"y\":-1492.19141,\"z\":31.93886}', '{\"x\":1.36137617,\"y\":-3.755104,\"z\":320.386}');
INSERT INTO `garages` VALUES (615, 0, '{\"x\":-88.6767,\"y\":-1499.78259,\"z\":32.54743}', '{\"x\":1.22960842,\"y\":-3.4220202,\"z\":319.85}');
INSERT INTO `garages` VALUES (616, 0, '{\"x\":-96.46523,\"y\":-1508.86133,\"z\":32.87205}', '{\"x\":-0.2347982,\"y\":-1.59849787,\"z\":319.512115}');
INSERT INTO `garages` VALUES (617, 0, '{\"x\":-98.79,\"y\":-1527.74072,\"z\":32.89755}', '{\"x\":1.99898338,\"y\":-2.328384,\"z\":48.92285}');
INSERT INTO `garages` VALUES (618, 0, '{\"x\":-89.8447342,\"y\":-1535.36877,\"z\":32.7530479}', '{\"x\":0.305642158,\"y\":-3.967781,\"z\":49.1694031}');
INSERT INTO `garages` VALUES (619, 0, '{\"x\":-88.893074,\"y\":-1583.90967,\"z\":30.5132446}', '{\"x\":2.05725956,\"y\":-4.86659527,\"z\":48.0827026}');
INSERT INTO `garages` VALUES (620, 0, '{\"x\":-90.77688,\"y\":-1586.40247,\"z\":30.7371063}', '{\"x\":2.54621172,\"y\":-3.035803,\"z\":48.5638428}');
INSERT INTO `garages` VALUES (621, 0, '{\"x\":-94.33599,\"y\":-1590.439,\"z\":30.9640045}', '{\"x\":0.881941438,\"y\":-0.460131377,\"z\":47.27066}');
INSERT INTO `garages` VALUES (622, 0, '{\"x\":-99.33916,\"y\":-1591.85693,\"z\":30.9316654}', '{\"x\":2.383423,\"y\":2.49592638,\"z\":50.79309}');
INSERT INTO `garages` VALUES (623, 0, '{\"x\":-101.060631,\"y\":-1594.129,\"z\":30.96408}', '{\"x\":1.94436729,\"y\":1.5362221,\"z\":52.73474}');
INSERT INTO `garages` VALUES (624, 0, '{\"x\":-103.381157,\"y\":-1596.927,\"z\":31.0108585}', '{\"x\":1.4785409,\"y\":0.7976163,\"z\":52.5664673}');
INSERT INTO `garages` VALUES (625, 0, '{\"x\":-107.500351,\"y\":-1604.007,\"z\":31.1338024}', '{\"x\":0.998339534,\"y\":0.06284492,\"z\":48.60373}');
INSERT INTO `garages` VALUES (626, 0, '{\"x\":-109.668358,\"y\":-1606.48462,\"z\":31.1371956}', '{\"x\":0.8992263,\"y\":0.04360554,\"z\":51.9414673}');
INSERT INTO `garages` VALUES (627, 0, '{\"x\":-112.934372,\"y\":-1607.924,\"z\":31.1955128}', '{\"x\":1.4881196,\"y\":0.365959883,\"z\":51.06021}');
INSERT INTO `garages` VALUES (628, 0, '{\"x\":-114.895935,\"y\":-1610.60083,\"z\":31.2555542}', '{\"x\":1.62035358,\"y\":0.265124053,\"z\":52.3174744}');
INSERT INTO `garages` VALUES (629, 0, '{\"x\":-116.494377,\"y\":-1612.46472,\"z\":31.30253}', '{\"x\":1.60694039,\"y\":0.226651162,\"z\":52.47809}');
INSERT INTO `garages` VALUES (630, 0, '{\"x\":-118.331047,\"y\":-1614.60974,\"z\":31.35317}', '{\"x\":1.24308133,\"y\":0.376994,\"z\":50.6983337}');
INSERT INTO `garages` VALUES (631, 0, '{\"x\":-120.02742,\"y\":-1616.9895,\"z\":31.39602}', '{\"x\":1.56830692,\"y\":0.586389661,\"z\":51.71762}');
INSERT INTO `garages` VALUES (632, 0, '{\"x\":-147.066208,\"y\":-1640.60791,\"z\":32.2936172}', '{\"x\":-5.069619,\"y\":-8.147945,\"z\":142.5188}');
INSERT INTO `garages` VALUES (633, 0, '{\"x\":-150.778732,\"y\":-1645.64111,\"z\":32.3761368}', '{\"x\":-5.61880445,\"y\":-8.502747,\"z\":143.097839}');
INSERT INTO `garages` VALUES (634, 0, '{\"x\":-155.027344,\"y\":-1651.59253,\"z\":32.3907127}', '{\"x\":-3.718309,\"y\":-6.29298,\"z\":143.949585}');
INSERT INTO `garages` VALUES (635, 0, '{\"x\":-160.148849,\"y\":-1656.729,\"z\":32.5542831}', '{\"x\":-3.15401864,\"y\":-4.132018,\"z\":140.868042}');
INSERT INTO `garages` VALUES (636, 0, '{\"x\":-165.480484,\"y\":-1662.75073,\"z\":32.6763153}', '{\"x\":-3.991056,\"y\":-3.84984779,\"z\":126.978455}');
INSERT INTO `garages` VALUES (637, 0, '{\"x\":-118.346794,\"y\":-1615.14539,\"z\":31.3756485}', '{\"x\":0.549308956,\"y\":1.61647749,\"z\":53.72992}');
INSERT INTO `garages` VALUES (638, 0, '{\"x\":-167.161438,\"y\":-1669.939,\"z\":32.5163651}', '{\"x\":3.61911964,\"y\":-0.172969058,\"z\":279.58374}');
INSERT INTO `garages` VALUES (639, 0, '{\"x\":-122.050407,\"y\":-1619.25684,\"z\":31.4362869}', '{\"x\":1.85915494,\"y\":0.832845449,\"z\":231.6178}');
INSERT INTO `garages` VALUES (640, 0, '{\"x\":-160.953964,\"y\":-1666.88733,\"z\":32.3975449}', '{\"x\":2.80633378,\"y\":0.788521647,\"z\":305.7153}');
INSERT INTO `garages` VALUES (641, 0, '{\"x\":-124.02137,\"y\":-1621.36475,\"z\":31.47642}', '{\"x\":1.98222148,\"y\":0.876586258,\"z\":231.803268}');
INSERT INTO `garages` VALUES (642, 0, '{\"x\":-156.6213,\"y\":-1662.85815,\"z\":32.28168}', '{\"x\":1.75462079,\"y\":0.7118428,\"z\":322.247223}');
INSERT INTO `garages` VALUES (643, 0, '{\"x\":-126.674866,\"y\":-1624.652,\"z\":31.53847}', '{\"x\":1.24470806,\"y\":0.3495833,\"z\":230.128632}');
INSERT INTO `garages` VALUES (644, 0, '{\"x\":-151.517975,\"y\":-1660.93286,\"z\":32.1829834}', '{\"x\":0.514186442,\"y\":-2.00167775,\"z\":47.0144958}');
INSERT INTO `garages` VALUES (645, 0, '{\"x\":-150.934662,\"y\":-1656.71057,\"z\":32.10991}', '{\"x\":1.26646972,\"y\":-0.663332164,\"z\":320.520966}');
INSERT INTO `garages` VALUES (646, 0, '{\"x\":-59.57225,\"y\":-1627.0708,\"z\":28.60905}', '{\"x\":-4.433962,\"y\":-5.110978,\"z\":140.669739}');
INSERT INTO `garages` VALUES (647, 0, '{\"x\":-147.373367,\"y\":-1651.41748,\"z\":32.0591431}', '{\"x\":1.27896392,\"y\":0.4778212,\"z\":320.657135}');
INSERT INTO `garages` VALUES (648, 0, '{\"x\":-64.0662,\"y\":-1631.81287,\"z\":28.6189632}', '{\"x\":-5.613682,\"y\":-6.129993,\"z\":137.405273}');
INSERT INTO `garages` VALUES (649, 0, '{\"x\":-143.256,\"y\":-1646.96973,\"z\":31.9812145}', '{\"x\":1.12699735,\"y\":0.599597633,\"z\":323.6214}');
INSERT INTO `garages` VALUES (650, 0, '{\"x\":-68.26936,\"y\":-1636.584,\"z\":28.61885}', '{\"x\":-5.414927,\"y\":-6.560246,\"z\":141.658936}');
INSERT INTO `garages` VALUES (651, 0, '{\"x\":-116.803185,\"y\":-1696.62488,\"z\":28.5337238}', '{\"x\":1.79202628,\"y\":1.86489892,\"z\":319.5541}');
INSERT INTO `garages` VALUES (652, 0, '{\"x\":-101.286827,\"y\":-1585.91309,\"z\":30.9725933}', '{\"x\":-2.09853625,\"y\":-3.54309583,\"z\":137.600159}');
INSERT INTO `garages` VALUES (653, 0, '{\"x\":-101.265915,\"y\":-1677.88892,\"z\":28.5070038}', '{\"x\":1.20095539,\"y\":1.42787027,\"z\":320.4127}');
INSERT INTO `garages` VALUES (654, 0, '{\"x\":-104.144196,\"y\":-1589.25513,\"z\":31.0331631}', '{\"x\":-1.89921117,\"y\":-3.70421576,\"z\":140.28894}');
INSERT INTO `garages` VALUES (655, 0, '{\"x\":-108.420769,\"y\":-1591.83826,\"z\":31.2282619}', '{\"x\":0.7214312,\"y\":-3.50817561,\"z\":49.2781067}');
INSERT INTO `garages` VALUES (656, 0, '{\"x\":-114.463921,\"y\":-1601.5697,\"z\":31.5221767}', '{\"x\":-5.48631239,\"y\":-7.167551,\"z\":50.8046875}');
INSERT INTO `garages` VALUES (657, 0, '{\"x\":-117.426704,\"y\":-1605.1405,\"z\":31.6567}', '{\"x\":-6.7893796,\"y\":-9.194781,\"z\":142.241882}');
INSERT INTO `garages` VALUES (658, 0, '{\"x\":-120.944954,\"y\":-1609.73865,\"z\":31.6810646}', '{\"x\":-6.09197855,\"y\":-8.607331,\"z\":140.886414}');
INSERT INTO `garages` VALUES (659, 0, '{\"x\":-125.921425,\"y\":-1615.66309,\"z\":31.7243786}', '{\"x\":-6.69348669,\"y\":-7.956857,\"z\":138.8555}');
INSERT INTO `garages` VALUES (660, 0, '{\"x\":-96.77432,\"y\":-1565.89209,\"z\":31.8690014}', '{\"x\":-4.874179,\"y\":-1.3256464,\"z\":49.2508545}');
INSERT INTO `garages` VALUES (661, 0, '{\"x\":-109.241112,\"y\":-1598.81519,\"z\":31.0735474}', '{\"x\":-2.08564186,\"y\":-4.495352,\"z\":140.057068}');
INSERT INTO `garages` VALUES (662, 0, '{\"x\":-101.615417,\"y\":-1561.88818,\"z\":32.29444}', '{\"x\":-4.458017,\"y\":-1.09924018,\"z\":50.17163}');
INSERT INTO `garages` VALUES (663, 0, '{\"x\":-106.636444,\"y\":-1557.85486,\"z\":32.6774635}', '{\"x\":-4.17003345,\"y\":-0.6913957,\"z\":47.5681152}');
INSERT INTO `garages` VALUES (664, 0, '{\"x\":-116.231522,\"y\":-1549.70593,\"z\":33.22462}', '{\"x\":-3.14170122,\"y\":0.808439553,\"z\":50.0285034}');
INSERT INTO `garages` VALUES (665, 0, '{\"x\":-134.039063,\"y\":-1549.39636,\"z\":33.4917336}', '{\"x\":-1.12146544,\"y\":-2.45289946,\"z\":138.296082}');
INSERT INTO `garages` VALUES (666, 0, '{\"x\":-141.887848,\"y\":-1558.59656,\"z\":33.7135048}', '{\"x\":-1.0354414,\"y\":-3.85877013,\"z\":139.966034}');
INSERT INTO `garages` VALUES (667, 0, '{\"x\":-146.803131,\"y\":-1564.70667,\"z\":33.8804321}', '{\"x\":-2.72523952,\"y\":-3.52721882,\"z\":140.703583}');
INSERT INTO `garages` VALUES (668, 0, '{\"x\":-151.806946,\"y\":-1570.38293,\"z\":33.9901428}', '{\"x\":-2.65890574,\"y\":-4.39854,\"z\":137.918549}');
INSERT INTO `garages` VALUES (669, 0, '{\"x\":-157.476471,\"y\":-1577.17114,\"z\":34.05546}', '{\"x\":-1.796594,\"y\":-3.89037728,\"z\":141.303955}');
INSERT INTO `garages` VALUES (670, 0, '{\"x\":498.594055,\"y\":-1803.57153,\"z\":27.7924461}', '{\"x\":0.798637,\"y\":1.0473386,\"z\":50.1570129}');
INSERT INTO `garages` VALUES (671, 0, '{\"x\":502.4527,\"y\":-1797.95972,\"z\":27.7808075}', '{\"x\":0.8572605,\"y\":1.35250354,\"z\":59.4672241}');
INSERT INTO `garages` VALUES (672, 0, '{\"x\":500.154083,\"y\":-1778.24463,\"z\":27.69482}', '{\"x\":0.9131438,\"y\":-2.501954,\"z\":199.405945}');
INSERT INTO `garages` VALUES (673, 0, '{\"x\":491.291718,\"y\":-1782.552,\"z\":27.72812}', '{\"x\":-0.6848127,\"y\":2.117577,\"z\":12.6673889}');
INSERT INTO `garages` VALUES (674, 0, '{\"x\":488.749573,\"y\":-1757.31641,\"z\":27.754406}', '{\"x\":0.618652761,\"y\":2.84191,\"z\":339.5143}');
INSERT INTO `garages` VALUES (675, 0, '{\"x\":480.0731,\"y\":-1746.14307,\"z\":28.1653919}', '{\"x\":-0.589806557,\"y\":-1.3263787,\"z\":69.02118}');
INSERT INTO `garages` VALUES (676, 0, '{\"x\":489.1724,\"y\":-1721.872,\"z\":28.69449}', '{\"x\":-0.5196083,\"y\":-1.30525553,\"z\":248.1739}');
INSERT INTO `garages` VALUES (677, 0, '{\"x\":498.0295,\"y\":-1702.86377,\"z\":28.703846}', '{\"x\":-0.7595629,\"y\":-0.98100996,\"z\":52.7914734}');
INSERT INTO `garages` VALUES (678, 0, '{\"x\":440.769165,\"y\":-1696.43445,\"z\":28.6049614}', '{\"x\":0.3376071,\"y\":0.377766877,\"z\":48.63626}');
INSERT INTO `garages` VALUES (679, 0, '{\"x\":427.19986,\"y\":-1711.83289,\"z\":28.5875168}', '{\"x\":0.7588754,\"y\":0.9205871,\"z\":48.26996}');
INSERT INTO `garages` VALUES (680, 0, '{\"x\":422.763275,\"y\":-1728.72986,\"z\":28.5792046}', '{\"x\":-0.012040128,\"y\":-0.011193553,\"z\":50.18521}');
INSERT INTO `garages` VALUES (681, 0, '{\"x\":399.0759,\"y\":-1753.12378,\"z\":28.6211643}', '{\"x\":0.317550361,\"y\":-0.256089181,\"z\":49.92978}');
INSERT INTO `garages` VALUES (682, 0, '{\"x\":347.852051,\"y\":-1809.35535,\"z\":27.8424034}', '{\"x\":1.28628361,\"y\":3.70382047,\"z\":48.2507935}');
INSERT INTO `garages` VALUES (683, 0, '{\"x\":337.027985,\"y\":-1820.06177,\"z\":27.2475624}', '{\"x\":-0.6495012,\"y\":2.4114902,\"z\":50.1866455}');
INSERT INTO `garages` VALUES (684, 0, '{\"x\":332.495026,\"y\":-1833.0575,\"z\":26.7604561}', '{\"x\":-3.360286,\"y\":-0.475667924,\"z\":225.694382}');
INSERT INTO `garages` VALUES (685, 0, '{\"x\":305.066,\"y\":-1850.504,\"z\":26.0584469}', '{\"x\":-0.84559083,\"y\":-1.567502,\"z\":138.87265}');
INSERT INTO `garages` VALUES (686, 0, '{\"x\":300.7123,\"y\":-1794.34546,\"z\":27.1289616}', '{\"x\":-2.17694736,\"y\":-0.104290307,\"z\":228.98732}');
INSERT INTO `garages` VALUES (687, 0, '{\"x\":308.9566,\"y\":-1793.66187,\"z\":27.11474}', '{\"x\":0.180741459,\"y\":3.30066919,\"z\":320.689}');
INSERT INTO `garages` VALUES (688, 0, '{\"x\":321.2123,\"y\":-1771.19275,\"z\":28.0983143}', '{\"x\":-2.44323468,\"y\":-0.5328104,\"z\":228.2942}');
INSERT INTO `garages` VALUES (689, 0, '{\"x\":333.750732,\"y\":-1764.059,\"z\":28.22088}', '{\"x\":0.745718062,\"y\":2.6323998,\"z\":320.0994}');
INSERT INTO `garages` VALUES (690, 0, '{\"x\":329.4516,\"y\":-1750.76782,\"z\":28.62355}', '{\"x\":-1.69706631,\"y\":1.35687852,\"z\":48.7147522}');
INSERT INTO `garages` VALUES (691, 0, '{\"x\":268.342224,\"y\":-1689.14893,\"z\":28.4654846}', '{\"x\":-2.06180763,\"y\":-1.64241648,\"z\":140.700012}');
INSERT INTO `garages` VALUES (692, 0, '{\"x\":267.250366,\"y\":-1701.53918,\"z\":28.58462}', '{\"x\":0.74214375,\"y\":1.13275278,\"z\":50.308136}');
INSERT INTO `garages` VALUES (693, 1, '{\"x\":-1742.83655,\"y\":-700.6773,\"z\":9.393715}', '{\"x\":0.388006747,\"y\":-0.559765637,\"z\":320.739044}');
INSERT INTO `garages` VALUES (694, 0, '{\"x\":259.733032,\"y\":-1714.173,\"z\":28.6193085}', '{\"x\":0.06033561,\"y\":0.834810555,\"z\":229.412109}');
INSERT INTO `garages` VALUES (695, 0, '{\"x\":238.1731,\"y\":-1724.99512,\"z\":28.2356014}', '{\"x\":-0.7707955,\"y\":-1.3422823,\"z\":318.522949}');
INSERT INTO `garages` VALUES (696, 0, '{\"x\":210.6155,\"y\":-1730.82532,\"z\":28.39051}', '{\"x\":-4.567065,\"y\":-2.31578159,\"z\":206.4562}');
INSERT INTO `garages` VALUES (697, 0, '{\"x\":225.670563,\"y\":-1718.94592,\"z\":28.43957}', '{\"x\":-2.45480919,\"y\":-3.034482,\"z\":229.379639}');
INSERT INTO `garages` VALUES (698, 0, '{\"x\":234.970627,\"y\":-1713.72607,\"z\":28.2977562}', '{\"x\":1.37447059,\"y\":1.96896625,\"z\":320.236023}');
INSERT INTO `garages` VALUES (699, 0, '{\"x\":242.156418,\"y\":-1699.67566,\"z\":28.4518223}', '{\"x\":-2.11593056,\"y\":-2.35003161,\"z\":230.738647}');
INSERT INTO `garages` VALUES (700, 0, '{\"x\":255.2131,\"y\":-1682.86536,\"z\":28.5245571}', '{\"x\":-1.3581537,\"y\":-1.10133338,\"z\":50.08847}');
INSERT INTO `garages` VALUES (701, 0, '{\"x\":268.240356,\"y\":-1894.75427,\"z\":25.8379745}', '{\"x\":-1.95378566,\"y\":0.435078681,\"z\":140.746216}');
INSERT INTO `garages` VALUES (702, 0, '{\"x\":268.329224,\"y\":-1906.35315,\"z\":25.764267}', '{\"x\":-1.14171636,\"y\":1.70841277,\"z\":49.275116}');
INSERT INTO `garages` VALUES (703, 2, '{\"x\":-1767.23889,\"y\":-677.425354,\"z\":9.511841}', '{\"x\":1.1179477,\"y\":-2.688978,\"z\":320.950317}');
INSERT INTO `garages` VALUES (704, 0, '{\"x\":-1767.23865,\"y\":-677.4248,\"z\":9.512162}', '{\"x\":1.087279,\"y\":-2.69966936,\"z\":320.9544}');
INSERT INTO `garages` VALUES (705, 0, '{\"x\":260.09137,\"y\":-1918.67773,\"z\":24.8616829}', '{\"x\":-3.59406447,\"y\":1.21838,\"z\":229.767715}');
INSERT INTO `garages` VALUES (706, 0, '{\"x\":238.145432,\"y\":-1930.28931,\"z\":23.24471}', '{\"x\":-5.15332747,\"y\":-1.03958261,\"z\":322.45163}');
INSERT INTO `garages` VALUES (707, 0, '{\"x\":149.2664,\"y\":-1983.91687,\"z\":17.5254974}', '{\"x\":1.35197294,\"y\":2.06690526,\"z\":321.6503}');
INSERT INTO `garages` VALUES (708, 0, '{\"x\":164.769577,\"y\":-1965.05237,\"z\":18.138958}', '{\"x\":-0.810914159,\"y\":2.17370224,\"z\":321.373077}');
INSERT INTO `garages` VALUES (709, 0, '{\"x\":165.798691,\"y\":-1956.24536,\"z\":18.6297264}', '{\"x\":-2.339756,\"y\":2.796703,\"z\":228.139435}');
INSERT INTO `garages` VALUES (710, 0, '{\"x\":191.467316,\"y\":-1922.152,\"z\":21.6502457}', '{\"x\":-2.8387053,\"y\":1.45079327,\"z\":228.12674}');
INSERT INTO `garages` VALUES (711, 0, '{\"x\":202.769409,\"y\":-1905.90442,\"z\":23.14603}', '{\"x\":-4.26498938,\"y\":-0.6741861,\"z\":51.5102539}');
INSERT INTO `garages` VALUES (712, 0, '{\"x\":188.374542,\"y\":-1896.08374,\"z\":23.0633221}', '{\"x\":-1.70273519,\"y\":1.13032472,\"z\":65.59656}');
INSERT INTO `garages` VALUES (713, 0, '{\"x\":176.392975,\"y\":-1885.02234,\"z\":23.42869}', '{\"x\":-3.82908869,\"y\":2.21133876,\"z\":154.347717}');
INSERT INTO `garages` VALUES (714, 0, '{\"x\":158.6727,\"y\":-1898.72461,\"z\":22.3130531}', '{\"x\":-0.5404229,\"y\":-1.31493068,\"z\":333.3827}');
INSERT INTO `garages` VALUES (715, 0, '{\"x\":139.115265,\"y\":-1868.21741,\"z\":23.52044}', '{\"x\":-2.99377227,\"y\":-0.507475138,\"z\":155.73291}');
INSERT INTO `garages` VALUES (716, 0, '{\"x\":138.402679,\"y\":-1892.11536,\"z\":22.67938}', '{\"x\":0.7692209,\"y\":-0.5719198,\"z\":333.7619}');
INSERT INTO `garages` VALUES (717, 0, '{\"x\":122.89653,\"y\":-1876.923,\"z\":23.077589}', '{\"x\":-3.64774919,\"y\":0.4082245,\"z\":65.6429443}');
INSERT INTO `garages` VALUES (718, 0, '{\"x\":115.789917,\"y\":-1863.31641,\"z\":23.95492}', '{\"x\":-2.89815235,\"y\":-0.8173172,\"z\":63.76767}');
INSERT INTO `garages` VALUES (719, 0, '{\"x\":106.970474,\"y\":-1870.46313,\"z\":23.4432869}', '{\"x\":-2.28170085,\"y\":1.02833724,\"z\":74.61856}');
INSERT INTO `garages` VALUES (720, 1, '{\"x\":-1767.18372,\"y\":-677.430847,\"z\":9.512257}', '{\"x\":1.01145113,\"y\":-2.75680137,\"z\":323.854919}');
INSERT INTO `garages` VALUES (721, 1, '{\"x\":-1777.62146,\"y\":-667.4426,\"z\":9.644677}', '{\"x\":-0.488002926,\"y\":-0.0105390577,\"z\":320.063049}');
INSERT INTO `garages` VALUES (722, 1, '{\"x\":-1785.29932,\"y\":-659.676941,\"z\":9.692551}', '{\"x\":0.8380012,\"y\":-0.7343196,\"z\":322.374573}');
INSERT INTO `garages` VALUES (723, 1, '{\"x\":-1795.798,\"y\":-644.898254,\"z\":10.1363459}', '{\"x\":-1.669631,\"y\":-0.0709583461,\"z\":45.56781}');
INSERT INTO `garages` VALUES (724, 1, '{\"x\":-1806.5509,\"y\":-642.374,\"z\":10.1620064}', '{\"x\":-0.205793157,\"y\":0.157164663,\"z\":140.374786}');
INSERT INTO `garages` VALUES (725, 1, '{\"x\":-1812.513,\"y\":-637.0956,\"z\":10.1999016}', '{\"x\":-0.0301903877,\"y\":0.0215532221,\"z\":135.334229}');
INSERT INTO `garages` VALUES (726, 0, '{\"x\":136.393829,\"y\":-1826.8197,\"z\":26.3005219}', '{\"x\":-0.7280152,\"y\":3.59260917,\"z\":49.05652}');
INSERT INTO `garages` VALUES (727, 1, '{\"x\":-1812.3717,\"y\":-636.9456,\"z\":10.2012186}', '{\"x\":-0.120789453,\"y\":0.09292436,\"z\":140.260559}');
INSERT INTO `garages` VALUES (728, 1, '{\"x\":-1826.71436,\"y\":-625.211,\"z\":10.3293724}', '{\"x\":-0.6080305,\"y\":1.74113393,\"z\":139.46991}');
INSERT INTO `garages` VALUES (729, 0, '{\"x\":369.3394,\"y\":-1978.11047,\"z\":23.478178}', '{\"x\":-1.7811178,\"y\":-0.666220963,\"z\":160.0951}');
INSERT INTO `garages` VALUES (730, 0, '{\"x\":366.704681,\"y\":-1977.28687,\"z\":23.5189133}', '{\"x\":-1.84382939,\"y\":-0.229420692,\"z\":161.901}');
INSERT INTO `garages` VALUES (731, 0, '{\"x\":366.703552,\"y\":-1977.28589,\"z\":23.5204639}', '{\"x\":-1.75243711,\"y\":-0.154197842,\"z\":161.895447}');
INSERT INTO `garages` VALUES (732, 1, '{\"x\":-1826.78625,\"y\":-625.3139,\"z\":10.3259134}', '{\"x\":-0.5235788,\"y\":1.72219121,\"z\":139.525}');
INSERT INTO `garages` VALUES (733, 1, '{\"x\":-1832.95178,\"y\":-616.3282,\"z\":10.4914761}', '{\"x\":-3.08800459,\"y\":2.50437832,\"z\":133.8883}');
INSERT INTO `garages` VALUES (734, 0, '{\"x\":366.704926,\"y\":-1977.286,\"z\":23.52067}', '{\"x\":-1.80458558,\"y\":-0.276862562,\"z\":161.924622}');
INSERT INTO `garages` VALUES (735, 2, '{\"x\":-1865.59229,\"y\":-590.367249,\"z\":11.0444183}', '{\"x\":1.92145908,\"y\":-1.92743647,\"z\":137.467834}');
INSERT INTO `garages` VALUES (736, 0, '{\"x\":363.979218,\"y\":-1975.96753,\"z\":23.581625}', '{\"x\":-2.70288348,\"y\":-0.4292972,\"z\":159.054321}');
INSERT INTO `garages` VALUES (737, 2, '{\"x\":-1879.04688,\"y\":-579.155762,\"z\":11.041173}', '{\"x\":1.2389611,\"y\":-0.6905973,\"z\":140.441711}');
INSERT INTO `garages` VALUES (738, 2, '{\"x\":-1888.17737,\"y\":-571.0601,\"z\":11.0490093}', '{\"x\":0.7879304,\"y\":-0.719240248,\"z\":138.59259}');
INSERT INTO `garages` VALUES (739, 0, '{\"x\":361.342529,\"y\":-1974.5498,\"z\":23.66348}', '{\"x\":-2.32279444,\"y\":-0.252438366,\"z\":163.000977}');
INSERT INTO `garages` VALUES (740, 5, '{\"x\":-2610.22656,\"y\":1683.91016,\"z\":141.545651}', '{\"x\":0.0,\"y\":0.0,\"z\":55.4047539}');
INSERT INTO `garages` VALUES (741, 2, '{\"x\":-1901.133,\"y\":-561.437866,\"z\":11.0685139}', '{\"x\":0.306938052,\"y\":-0.282681048,\"z\":138.9338}');
INSERT INTO `garages` VALUES (742, 2, '{\"x\":-1907.33765,\"y\":-552.1616,\"z\":11.0614986}', '{\"x\":1.03008437,\"y\":-0.601627648,\"z\":146.195313}');
INSERT INTO `garages` VALUES (743, 2, '{\"x\":-1913.56738,\"y\":-544.3592,\"z\":11.0574636}', '{\"x\":0.152947247,\"y\":-0.46820116,\"z\":322.542175}');
INSERT INTO `garages` VALUES (744, 2, '{\"x\":-1939.36584,\"y\":-530.1286,\"z\":11.10017}', '{\"x\":0.179781884,\"y\":-0.008230539,\"z\":141.272064}');
INSERT INTO `garages` VALUES (745, 2, '{\"x\":-1932.8147,\"y\":-534.405945,\"z\":11.0883846}', '{\"x\":0.02662749,\"y\":-0.06404749,\"z\":137.318817}');
INSERT INTO `garages` VALUES (746, 2, '{\"x\":-1953.77307,\"y\":-515.865662,\"z\":11.1450911}', '{\"x\":-0.680190563,\"y\":0.09211762,\"z\":321.393463}');
INSERT INTO `garages` VALUES (747, 2, '{\"x\":-1958.795,\"y\":-507.457947,\"z\":11.1154795}', '{\"x\":0.5208345,\"y\":-0.44147715,\"z\":47.8936768}');
INSERT INTO `garages` VALUES (748, 2, '{\"x\":-1967.63489,\"y\":-502.64505,\"z\":11.1109638}', '{\"x\":-0.197089851,\"y\":-0.38168332,\"z\":319.610931}');
INSERT INTO `garages` VALUES (749, 2, '{\"x\":-1959.24353,\"y\":-507.441681,\"z\":11.1181307}', '{\"x\":0.487959653,\"y\":-0.456117,\"z\":41.7030029}');
INSERT INTO `garages` VALUES (750, 2, '{\"x\":-1967.44263,\"y\":-501.9487,\"z\":11.1150465}', '{\"x\":0.5372975,\"y\":-1.3442502,\"z\":319.905273}');
INSERT INTO `garages` VALUES (751, 5, '{\"x\":-1939.5033,\"y\":580.34436,\"z\":118.455574}', '{\"x\":-0.267579615,\"y\":8.443619,\"z\":69.40637}');
INSERT INTO `garages` VALUES (752, 5, '{\"x\":1413.79626,\"y\":1117.78162,\"z\":113.717918}', '{\"x\":0.0,\"y\":0.0,\"z\":352.834381}');
INSERT INTO `garages` VALUES (753, 5, '{\"x\":-1662.84631,\"y\":-298.545166,\"z\":51.2644577}', '{\"x\":-2.25575352,\"y\":-1.016543,\"z\":51.9095764}');
INSERT INTO `garages` VALUES (754, 5, '{\"x\":-1490.22,\"y\":20.1579742,\"z\":54.2952881}', '{\"x\":-0.201414481,\"y\":-0.028115781,\"z\":184.019379}');
INSERT INTO `garages` VALUES (755, 3, '{\"x\":-1939.42712,\"y\":462.136658,\"z\":101.922287}', '{\"x\":-0.9280014,\"y\":3.40976071,\"z\":97.2038}');
INSERT INTO `garages` VALUES (756, 5, '{\"x\":-3190.903,\"y\":819.6127,\"z\":8.610911}', '{\"x\":0.0,\"y\":0.0,\"z\":301.675323}');
INSERT INTO `garages` VALUES (757, 4, '{\"x\":-1096.2959,\"y\":358.090271,\"z\":68.1563644}', '{\"x\":-0.727452636,\"y\":0.407940924,\"z\":359.7718}');
INSERT INTO `garages` VALUES (758, 4, '{\"x\":-104.2828,\"y\":823.8885,\"z\":235.375015}', '{\"x\":-0.468397737,\"y\":-0.07669419,\"z\":10.25119}');
INSERT INTO `garages` VALUES (759, 4, '{\"x\":-169.07132,\"y\":919.7096,\"z\":235.305954}', '{\"x\":-0.3558404,\"y\":0.337864518,\"z\":316.608246}');
INSERT INTO `garages` VALUES (760, 4, '{\"x\":-1096.25867,\"y\":356.819244,\"z\":68.07653}', '{\"x\":0.0544856749,\"y\":0.299196929,\"z\":1.18127441}');
INSERT INTO `garages` VALUES (761, 4, '{\"x\":-170.309631,\"y\":919.2121,\"z\":235.231613}', '{\"x\":0.0684275851,\"y\":-0.04062779,\"z\":314.112274}');
INSERT INTO `garages` VALUES (762, 5, '{\"x\":-170.474945,\"y\":919.2476,\"z\":235.23143}', '{\"x\":0.0318946838,\"y\":-0.0508156866,\"z\":314.843475}');
INSERT INTO `garages` VALUES (763, -1, '{\"x\":1969.38037,\"y\":3822.43774,\"z\":32.0205841}', '{\"x\":0.117234275,\"y\":-0.191620573,\"z\":122.701874}');
INSERT INTO `garages` VALUES (1000, 2, '{\"x\":0.38037,\"y\":0.43774,\"z\":0.0205841}', '{\"x\":0.38037,\"y\":0.43774,\"z\":0.0205841}');
INSERT INTO `garages` VALUES (1001, 2, '{\"x\":0.38037,\"y\":0.43774,\"z\":0.0205841}', '{\"x\":0.38037,\"y\":0.43774,\"z\":0.0205841}');
INSERT INTO `garages` VALUES (1002, 2, '{\"x\":0.38037,\"y\":0.43774,\"z\":0.0205841}', '{\"x\":0.38037,\"y\":0.43774,\"z\":0.0205841}');
INSERT INTO `garages` VALUES (1003, 2, '{\"x\":0.38037,\"y\":0.43774,\"z\":0.0205841}', '{\"x\":0.38037,\"y\":0.43774,\"z\":0.0205841}');
INSERT INTO `garages` VALUES (1004, 2, '{\"x\":0.38037,\"y\":0.43774,\"z\":0.0205841}', '{\"x\":0.38037,\"y\":0.43774,\"z\":0.0205841}');
INSERT INTO `garages` VALUES (1005, 2, '{\"x\":0.38037,\"y\":0.43774,\"z\":0.0205841}', '{\"x\":0.38037,\"y\":0.43774,\"z\":0.0205841}');
INSERT INTO `garages` VALUES (1006, 2, '{\"x\":0.38037,\"y\":0.43774,\"z\":0.0205841}', '{\"x\":0.38037,\"y\":0.43774,\"z\":0.0205841}');

-- ----------------------------
-- Table structure for houses
-- ----------------------------
DROP TABLE IF EXISTS `houses`;
CREATE TABLE `houses`  (
  `id` int NOT NULL,
  `owner` text CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `type` varchar(11) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `position` text CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `price` text CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `locked` tinyint NOT NULL,
  `garage` text CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `bank` text CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `roommates` text CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `apart` int NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of houses
-- ----------------------------
INSERT INTO `houses` VALUES (0, '', '2', '{\"x\":317.21393,\"y\":-2043.4792,\"z\":19.816385}', '40000', 1, '2', '214323', '[]', -1);
INSERT INTO `houses` VALUES (1, '', '2', '{\"x\":313.82245,\"y\":-2040.6072,\"z\":19.816381}', '40000', 0, '1', '868093', '[]', -1);
INSERT INTO `houses` VALUES (2, '', '2', '{\"x\":324.326,\"y\":-2049.711,\"z\":19.812498}', '40000', 0, '3', '618509', '[]', -1);
INSERT INTO `houses` VALUES (3, '', '2', '{\"x\":325.673,\"y\":-2050.7927,\"z\":19.816387}', '40000', 0, '4', '23158', '[]', -1);
INSERT INTO `houses` VALUES (4, '', '2', '{\"x\":333.16333,\"y\":-2056.7703,\"z\":19.816381}', '40000', 0, '5', '878164', '[]', -1);
INSERT INTO `houses` VALUES (5, '', '2', '{\"x\":334.5466,\"y\":-2058.1025,\"z\":19.816397}', '40000', 0, '6', '285119', '[]', -1);
INSERT INTO `houses` VALUES (6, '', '2', '{\"x\":341.80325,\"y\":-2064.2751,\"z\":19.819237}', '40000', 0, '7', '699680', '[]', -1);
INSERT INTO `houses` VALUES (7, '', '2', '{\"x\":345.54675,\"y\":-2067.419,\"z\":19.81643}', '40000', 0, '8', '366070', '[]', -1);
INSERT INTO `houses` VALUES (8, '', '2', '{\"x\":356.74585,\"y\":-2074.6848,\"z\":20.617907}', '40000', 0, '9', '526597', '[]', -1);
INSERT INTO `houses` VALUES (9, '', '2', '{\"x\":357.8474,\"y\":-2073.3677,\"z\":20.624485}', '40000', 0, '10', '849743', '[]', -1);
INSERT INTO `houses` VALUES (10, '', '2', '{\"x\":365.2743,\"y\":-2064.4656,\"z\":20.624401}', '40000', 0, '11', '241559', '[]', -1);
INSERT INTO `houses` VALUES (11, '', '2', '{\"x\":371.08908,\"y\":-2057.14,\"z\":20.624393}', '40000', 0, '12', '794814', '[]', -1);
INSERT INTO `houses` VALUES (12, '', '2', '{\"x\":372.24136,\"y\":-2055.7915,\"z\":20.624512}', '40000', 0, '13', '236504', '[]', -1);
INSERT INTO `houses` VALUES (13, '', '2', '{\"x\":364.15555,\"y\":-2045.9303,\"z\":21.23399}', '40000', 0, '14', '552377', '[]', -1);
INSERT INTO `houses` VALUES (14, '', '2', '{\"x\":360.4447,\"y\":-2042.9016,\"z\":21.234333}', '40000', 0, '15', '431560', '[]', -1);
INSERT INTO `houses` VALUES (15, '', '2', '{\"x\":353.61108,\"y\":-2036.2603,\"z\":21.234123}', '40000', 0, '16', '723530', '[]', -1);
INSERT INTO `houses` VALUES (16, '', '2', '{\"x\":352.12994,\"y\":-2035.1763,\"z\":21.234295}', '40000', 0, '17', '259808', '[]', -1);
INSERT INTO `houses` VALUES (17, '', '2', '{\"x\":344.73532,\"y\":-2028.9391,\"z\":21.232815}', '40000', 0, '18', '172933', '[]', -1);
INSERT INTO `houses` VALUES (18, '', '2', '{\"x\":343.40808,\"y\":-2027.8845,\"z\":21.234293}', '40000', 0, '19', '822643', '[]', -1);
INSERT INTO `houses` VALUES (19, '', '2', '{\"x\":336.057,\"y\":-2021.6538,\"z\":21.233143}', '40000', 0, '20', '179979', '[]', -1);
INSERT INTO `houses` VALUES (20, '', '2', '{\"x\":332.33127,\"y\":-2018.6263,\"z\":21.234287}', '40000', 0, '21', '440530', '[]', -1);
INSERT INTO `houses` VALUES (21, '', '3', '{\"x\":1090.521,\"y\":-484.41043,\"z\":64.536095}', '110000', 1, '117', '397757', '[]', -1);
INSERT INTO `houses` VALUES (22, '', '2', '{\"x\":236.38484,\"y\":-2045.9293,\"z\":17.259996}', '40000', 0, '25', '883059', '[]', -1);
INSERT INTO `houses` VALUES (23, '', '6', '{\"x\":-698.5782,\"y\":46.89701,\"z\":42.907898}', '800000', 1, '34', '654016', '[]', -1);
INSERT INTO `houses` VALUES (24, '', '2', '{\"x\":251.1861,\"y\":-2030.0282,\"z\":17.586128}', '40000', 0, '26', '934310', '[]', -1);
INSERT INTO `houses` VALUES (25, '', '2', '{\"x\":256.73178,\"y\":-2023.6107,\"z\":18.146286}', '40000', 0, '27', '510099', '[]', -1);
INSERT INTO `houses` VALUES (26, '', '2', '{\"x\":279.9102,\"y\":-1993.6504,\"z\":19.683743}', '40000', 0, '28', '254906', '[]', -1);
INSERT INTO `houses` VALUES (27, '', '2', '{\"x\":291.2865,\"y\":-1980.5872,\"z\":20.480524}', '40000', 0, '29', '252558', '[]', -1);
INSERT INTO `houses` VALUES (28, '', '2', '{\"x\":296.24048,\"y\":-1972.3716,\"z\":21.780952}', '40000', 0, '30', '434460', '[]', -1);
INSERT INTO `houses` VALUES (29, '', '2', '{\"x\":312.3926,\"y\":-1956.4044,\"z\":23.495216}', '40000', 0, '31', '844283', '[]', -1);
INSERT INTO `houses` VALUES (30, '', '2', '{\"x\":324.02527,\"y\":-1937.8783,\"z\":23.898966}', '40000', 1, '32', '436090', '[]', -1);
INSERT INTO `houses` VALUES (31, '', '2', '{\"x\":368.25314,\"y\":-1895.98,\"z\":24.058517}', '40000', 1, '35', '12400', '[]', -1);
INSERT INTO `houses` VALUES (32, '', '2', '{\"x\":385.3333,\"y\":-1882.003,\"z\":24.911942}', '40000', 1, '36', '789215', '[]', -1);
INSERT INTO `houses` VALUES (33, '', '2', '{\"x\":399.5597,\"y\":-1864.9646,\"z\":25.596336}', '40000', 0, '37', '441895', '[]', -1);
INSERT INTO `houses` VALUES (34, '', '2', '{\"x\":412.92792,\"y\":-1856.4076,\"z\":26.199396}', '40000', 0, '38', '202126', '[]', -1);
INSERT INTO `houses` VALUES (35, '', '2', '{\"x\":427.38678,\"y\":-1841.858,\"z\":27.33266}', '40000', 0, '39', '338770', '[]', -1);
INSERT INTO `houses` VALUES (36, '', '2', '{\"x\":440.27365,\"y\":-1829.7914,\"z\":27.237883}', '40000', 0, '40', '517218', '[]', -1);
INSERT INTO `houses` VALUES (37, '', '1', '{\"x\":1315.76,\"y\":-1526.7816,\"z\":50.68083}', '35000', 1, '41', '810384', '[]', -1);
INSERT INTO `houses` VALUES (38, '', '1', '{\"x\":1327.1919,\"y\":-1552.804,\"z\":52.931526}', '35000', 1, '42', '179196', '[]', -1);
INSERT INTO `houses` VALUES (39, '', '1', '{\"x\":1360.4197,\"y\":-1555.7731,\"z\":55.22131}', '25000', 1, '44', '165586', '[]', -1);
INSERT INTO `houses` VALUES (40, '', '1', '{\"x\":1338.1855,\"y\":-1524.5396,\"z\":53.46191}', '35000', 1, '43', '959886', '[]', -1);
INSERT INTO `houses` VALUES (41, '', '1', '{\"x\":1382.0878,\"y\":-1544.6637,\"z\":55.98719}', '25000', 1, '46', '350018', '[]', -1);
INSERT INTO `houses` VALUES (42, '', '1', '{\"x\":1379.2502,\"y\":-1515.0702,\"z\":57.315636}', '35000', 1, '45', '52626', '[]', -1);
INSERT INTO `houses` VALUES (43, '', '2', '{\"x\":1286.6776,\"y\":-1604.3154,\"z\":53.704887}', '60000', 1, '53', '685129', '[]', -1);
INSERT INTO `houses` VALUES (44, '', '2', '{\"x\":1261.5793,\"y\":-1616.8215,\"z\":53.6229}', '40000', 1, '54', '520202', '[]', -1);
INSERT INTO `houses` VALUES (45, '', '2', '{\"x\":1245.3737,\"y\":-1626.9296,\"z\":52.162445}', '40000', 0, '55', '255654', '[]', -1);
INSERT INTO `houses` VALUES (46, '', '2', '{\"x\":1230.731,\"y\":-1591.1416,\"z\":52.646114}', '40000', 0, '56', '779744', '[]', -1);
INSERT INTO `houses` VALUES (47, '', '2', '{\"x\":1205.7739,\"y\":-1607.4316,\"z\":49.6187}', '40000', 0, '57', '22532', '[]', -1);
INSERT INTO `houses` VALUES (48, '', '2', '{\"x\":1214.5049,\"y\":-1644.3094,\"z\":47.52601}', '40000', 0, '58', '426091', '[]', -1);
INSERT INTO `houses` VALUES (49, '', '2', '{\"x\":1193.0111,\"y\":-1622.6552,\"z\":44.101456}', '40000', 0, '59', '238025', '[]', -1);
INSERT INTO `houses` VALUES (50, '', '2', '{\"x\":1193.675,\"y\":-1656.4889,\"z\":41.906387}', '40000', 0, '60', '301799', '[]', -1);
INSERT INTO `houses` VALUES (51, '', '2', '{\"x\":1354.9104,\"y\":-1690.5558,\"z\":59.37117}', '40000', 0, '67', '620254', '[]', -1);
INSERT INTO `houses` VALUES (52, '', '2', '{\"x\":1365.5804,\"y\":-1721.7289,\"z\":64.4994}', '40000', 0, '68', '166818', '[]', -1);
INSERT INTO `houses` VALUES (53, '', '2', '{\"x\":1312.0833,\"y\":-1697.6171,\"z\":57.105373}', '40000', 0, '66', '578341', '[]', -1);
INSERT INTO `houses` VALUES (54, '', '2', '{\"x\":1314.5975,\"y\":-1733.0747,\"z\":53.57811}', '40000', 0, '65', '37771', '[]', -1);
INSERT INTO `houses` VALUES (55, '', '2', '{\"x\":1289.31,\"y\":-1710.7499,\"z\":54.35495}', '40000', 0, '64', '816565', '[]', -1);
INSERT INTO `houses` VALUES (56, '', '2', '{\"x\":1294.9944,\"y\":-1739.803,\"z\":53.151768}', '40000', 0, '63', '985033', '[]', -1);
INSERT INTO `houses` VALUES (57, '', '2', '{\"x\":1250.7135,\"y\":-1734.2885,\"z\":50.91199}', '40000', 0, '62', '964491', '[]', -1);
INSERT INTO `houses` VALUES (58, '', '2', '{\"x\":1259.1494,\"y\":-1761.9723,\"z\":48.53826}', '40000', 0, '61', '88847', '[]', -1);
INSERT INTO `houses` VALUES (59, '', '2', '{\"x\":1264.9614,\"y\":-702.8916,\"z\":63.59785}', '40000', 1, '120', '368065', '[]', -1);
INSERT INTO `houses` VALUES (60, '', '2', '{\"x\":1270.9791,\"y\":-683.3786,\"z\":64.91164}', '40000', 1, '118', '30214', '[]', -1);
INSERT INTO `houses` VALUES (61, '', '2', '{\"x\":1265.4755,\"y\":-648.4172,\"z\":66.80146}', '60000', 1, '115', '447123', '[]', -1);
INSERT INTO `houses` VALUES (62, '', '2', '{\"x\":1251.1211,\"y\":-621.2679,\"z\":68.29324}', '40000', 1, '111', '931609', '[]', -1);
INSERT INTO `houses` VALUES (63, '', '2', '{\"x\":1240.7615,\"y\":-601.63617,\"z\":68.6631}', '40000', 1, '108', '682313', '[]', -1);
INSERT INTO `houses` VALUES (64, '', '2', '{\"x\":1241.595,\"y\":-566.28125,\"z\":68.53742}', '60000', 1, '105', '413654', '[]', -1);
INSERT INTO `houses` VALUES (65, '', '2', '{\"x\":1251.015,\"y\":-515.58594,\"z\":68.223755}', '60000', 1, '143', '229160', '[]', -1);
INSERT INTO `houses` VALUES (66, '', '2', '{\"x\":1251.6835,\"y\":-494.16214,\"z\":68.78691}', '40000', 1, '145', '5600', '[]', -1);
INSERT INTO `houses` VALUES (67, '', '2', '{\"x\":1259.6887,\"y\":-480.04218,\"z\":69.06891}', '40000', 1, '149', '794608', '[]', -1);
INSERT INTO `houses` VALUES (68, '', '2', '{\"x\":1265.895,\"y\":-458.11258,\"z\":69.396866}', '60000', 1, '152', '350251', '[]', -1);
INSERT INTO `houses` VALUES (69, '', '2', '{\"x\":1262.5609,\"y\":-429.72662,\"z\":68.89474}', '40000', 1, '153', '92790', '[]', -1);
INSERT INTO `houses` VALUES (70, '', '3', '{\"x\":1229.4763,\"y\":-725.34235,\"z\":59.836483}', '110000', 0, '124', '206312', '[]', -1);
INSERT INTO `houses` VALUES (71, '', '3', '{\"x\":1223.0345,\"y\":-696.829,\"z\":59.683956}', '110000', 0, '127', '449422', '[]', -1);
INSERT INTO `houses` VALUES (72, '', '3', '{\"x\":1221.4639,\"y\":-669.2767,\"z\":62.413536}', '110000', 0, '130', '993735', '[]', -1);
INSERT INTO `houses` VALUES (73, '', '3', '{\"x\":1207.3943,\"y\":-620.2879,\"z\":65.31863}', '110000', 0, '133', '657058', '[]', -1);
INSERT INTO `houses` VALUES (74, '', '3', '{\"x\":1203.6174,\"y\":-598.47,\"z\":66.943535}', '110000', 1, '135', '220091', '[]', -1);
INSERT INTO `houses` VALUES (75, '', '3', '{\"x\":1201.0294,\"y\":-575.5069,\"z\":68.01912}', '110000', 0, '137', '90512', '[]', -1);
INSERT INTO `houses` VALUES (76, '', '3', '{\"x\":1204.8898,\"y\":-557.7646,\"z\":68.49516}', '110000', 0, '141', '345132', '[]', -1);
INSERT INTO `houses` VALUES (77, '', '4', '{\"x\":1303.1842,\"y\":-527.40405,\"z\":70.34066}', '120000', 1, '160', '197930', '[]', -1);
INSERT INTO `houses` VALUES (78, '', '4', '{\"x\":1301.0547,\"y\":-574.2354,\"z\":70.6122}', '120000', 1, '156', '133815', '[]', -1);
INSERT INTO `houses` VALUES (79, '', '4', '{\"x\":1328.378,\"y\":-535.91547,\"z\":71.320816}', '120000', 1, '170', '678657', '[]', -1);
INSERT INTO `houses` VALUES (80, '', '4', '{\"x\":1323.4315,\"y\":-582.99384,\"z\":72.126305}', '120000', 1, '167', '730353', '[]', -1);
INSERT INTO `houses` VALUES (81, '', '4', '{\"x\":1348.3075,\"y\":-546.93604,\"z\":72.77166}', '120000', 1, '172', '232375', '[]', -1);
INSERT INTO `houses` VALUES (82, '', '4', '{\"x\":1373.106,\"y\":-555.63025,\"z\":73.56568}', '120000', 1, '177', '826465', '[]', -1);
INSERT INTO `houses` VALUES (83, '', '4', '{\"x\":1388.8884,\"y\":-569.6225,\"z\":73.37649}', '120000', 1, '185', '196436', '[]', -1);
INSERT INTO `houses` VALUES (84, '', '4', '{\"x\":1386.1523,\"y\":-593.5735,\"z\":73.36508}', '120000', 1, '182', '542485', '[]', -1);
INSERT INTO `houses` VALUES (85, '', '4', '{\"x\":1367.296,\"y\":-606.444,\"z\":73.590935}', '120000', 1, '180', '815834', '[]', -1);
INSERT INTO `houses` VALUES (86, '', '4', '{\"x\":1341.5103,\"y\":-597.4519,\"z\":73.580925}', '120000', 1, '175', '845580', '[]', -1);
INSERT INTO `houses` VALUES (87, '', '3', '{\"x\":1098.5468,\"y\":-464.77454,\"z\":66.19316}', '110000', 1, '116', '210874', '[]', -1);
INSERT INTO `houses` VALUES (88, '', '3', '{\"x\":1099.4657,\"y\":-438.73495,\"z\":66.670555}', '110000', 0, '114', '404125', '[]', -1);
INSERT INTO `houses` VALUES (89, '', '3', '{\"x\":1100.7571,\"y\":-411.31638,\"z\":66.433846}', '110000', 1, '112', '385560', '[]', -1);
INSERT INTO `houses` VALUES (90, '', '3', '{\"x\":1114.381,\"y\":-391.329,\"z\":67.83453}', '110000', 0, '113', '353736', '[]', -1);
INSERT INTO `houses` VALUES (91, '', '3', '{\"x\":1056.2174,\"y\":-448.981,\"z\":65.13746}', '110000', 0, '122', '552726', '[]', -1);
INSERT INTO `houses` VALUES (92, '', '3', '{\"x\":1051.1207,\"y\":-470.47116,\"z\":63.166462}', '110000', 0, '121', '721538', '[]', -1);
INSERT INTO `houses` VALUES (93, '', '3', '{\"x\":1046.3667,\"y\":-497.75708,\"z\":62.935436}', '110000', 0, '119', '811129', '[]', -1);
INSERT INTO `houses` VALUES (94, '', '3', '{\"x\":1060.5464,\"y\":-378.39767,\"z\":67.09629}', '110000', 0, '183', '135372', '[]', -1);
INSERT INTO `houses` VALUES (95, '', '3', '{\"x\":1029.0269,\"y\":-408.603,\"z\":65.001305}', '110000', 0, '181', '512764', '[]', -1);
INSERT INTO `houses` VALUES (96, '', '3', '{\"x\":1010.3889,\"y\":-423.41785,\"z\":64.22189}', '110000', 0, '179', '418408', '[]', -1);
INSERT INTO `houses` VALUES (97, '', '3', '{\"x\":987.52185,\"y\":-432.9656,\"z\":62.928654}', '110000', 1, '178', '370312', '[]', -1);
INSERT INTO `houses` VALUES (98, '', '3', '{\"x\":967.16425,\"y\":-451.5857,\"z\":61.665436}', '110000', 0, '176', '271476', '[]', -1);
INSERT INTO `houses` VALUES (99, '', '3', '{\"x\":944.48016,\"y\":-463.072,\"z\":60.43346}', '110000', 0, '174', '291043', '[]', -1);
INSERT INTO `houses` VALUES (100, '', '3', '{\"x\":921.8205,\"y\":-477.87653,\"z\":59.963627}', '110000', 0, '173', '250055', '[]', -1);
INSERT INTO `houses` VALUES (101, '', '3', '{\"x\":906.19684,\"y\":-489.47696,\"z\":58.27557}', '110000', 1, '171', '985135', '[]', -1);
INSERT INTO `houses` VALUES (102, '', '3', '{\"x\":878.3909,\"y\":-497.9359,\"z\":56.9827}', '110000', 0, '169', '672279', '[]', -1);
INSERT INTO `houses` VALUES (103, '', '3', '{\"x\":861.4952,\"y\":-509.03656,\"z\":56.598328}', '110000', 0, '168', '333301', '[]', -1);
INSERT INTO `houses` VALUES (104, '', '3', '{\"x\":850.381,\"y\":-532.64374,\"z\":56.778877}', '110000', 1, '166', '31713', '[]', -1);
INSERT INTO `houses` VALUES (105, '', '3', '{\"x\":844.10065,\"y\":-562.6532,\"z\":56.84359}', '110000', 1, '165', '852375', '[]', -1);
INSERT INTO `houses` VALUES (106, '', '3', '{\"x\":861.73535,\"y\":-583.5375,\"z\":57.02173}', '110000', 1, '164', '626518', '[]', -1);
INSERT INTO `houses` VALUES (107, '', '3', '{\"x\":886.9701,\"y\":-608.1028,\"z\":57.31994}', '110000', 1, '163', '509759', '[]', -1);
INSERT INTO `houses` VALUES (108, '', '3', '{\"x\":903.1155,\"y\":-615.6634,\"z\":57.332832}', '110000', 1, '162', '358251', '[]', -1);
INSERT INTO `houses` VALUES (109, '', '3', '{\"x\":928.7755,\"y\":-639.7979,\"z\":57.10878}', '110000', 0, '161', '947258', '[]', -1);
INSERT INTO `houses` VALUES (110, '', '3', '{\"x\":943.7115,\"y\":-653.63824,\"z\":57.297947}', '110000', 0, '159', '471433', '[]', -1);
INSERT INTO `houses` VALUES (111, '', '3', '{\"x\":959.9991,\"y\":-669.83887,\"z\":57.329754}', '110000', 1, '158', '787103', '[]', -1);
INSERT INTO `houses` VALUES (112, '', '3', '{\"x\":970.76013,\"y\":-701.45667,\"z\":57.565655}', '110000', 0, '157', '830677', '[]', -1);
INSERT INTO `houses` VALUES (113, '', '3', '{\"x\":979.2583,\"y\":-716.1747,\"z\":57.07779}', '110000', 1, '155', '410188', '[]', -1);
INSERT INTO `houses` VALUES (114, '', '3', '{\"x\":996.72614,\"y\":-729.5223,\"z\":56.694695}', '110000', 1, '154', '637711', '[]', -1);
INSERT INTO `houses` VALUES (115, '', '2', '{\"x\":1014.4416,\"y\":-469.1557,\"z\":63.38299}', '40000', 1, '125', '797838', '[]', -1);
INSERT INTO `houses` VALUES (116, '', '2', '{\"x\":1005.95056,\"y\":-511.32846,\"z\":59.71394}', '40000', 1, '140', '620656', '[]', -1);
INSERT INTO `houses` VALUES (117, '', '2', '{\"x\":969.9736,\"y\":-502.31137,\"z\":61.020966}', '40000', 1, '126', '735174', '[]', -1);
INSERT INTO `houses` VALUES (118, '', '2', '{\"x\":946.00116,\"y\":-518.9806,\"z\":59.505447}', '40000', 1, '128', '139828', '[]', -1);
INSERT INTO `houses` VALUES (119, '', '3', '{\"x\":924.24756,\"y\":-525.8362,\"z\":58.668957}', '110000', 0, '131', '597819', '[]', -1);
INSERT INTO `houses` VALUES (120, '', '3', '{\"x\":893.02374,\"y\":-540.7058,\"z\":57.386604}', '110000', 0, '132', '383578', '[]', -1);
INSERT INTO `houses` VALUES (121, '', '3', '{\"x\":919.76825,\"y\":-569.7781,\"z\":57.24634}', '110000', 1, '134', '794724', '[]', -1);
INSERT INTO `houses` VALUES (122, '', '2', '{\"x\":965.33167,\"y\":-542.05493,\"z\":58.606144}', '40000', 1, '139', '390483', '[]', -1);
INSERT INTO `houses` VALUES (123, '', '2', '{\"x\":987.8692,\"y\":-525.9945,\"z\":59.56474}', '40000', 1, '138', '964690', '[]', -1);
INSERT INTO `houses` VALUES (124, '', '2', '{\"x\":1009.807,\"y\":-572.4869,\"z\":59.46886}', '40000', 1, '142', '739053', '[]', -1);
INSERT INTO `houses` VALUES (125, '', '2', '{\"x\":999.6056,\"y\":-593.8989,\"z\":58.49772}', '40000', 1, '144', '653585', '[]', -1);
INSERT INTO `houses` VALUES (126, '', '2', '{\"x\":993.86993,\"y\":-620.5413,\"z\":57.898975}', '40000', 1, '148', '727883', '[]', -1);
INSERT INTO `houses` VALUES (127, '', '2', '{\"x\":964.1757,\"y\":-596.0862,\"z\":58.782673}', '40000', 0, '150', '182606', '[]', -1);
INSERT INTO `houses` VALUES (128, '', '2', '{\"x\":976.5081,\"y\":-580.467,\"z\":58.729977}', '40000', 1, '151', '521686', '[]', -1);
INSERT INTO `houses` VALUES (129, '', '2', '{\"x\":309.46964,\"y\":-208.01523,\"z\":53.096897}', '40000', 0, '83', '707326', '[]', -1);
INSERT INTO `houses` VALUES (130, '', '2', '{\"x\":311.19888,\"y\":-203.46202,\"z\":53.0675}', '40000', 1, '82', '672103', '[]', -1);
INSERT INTO `houses` VALUES (131, '', '2', '{\"x\":313.2263,\"y\":-198.17963,\"z\":53.077423}', '40000', 1, '81', '974819', '[]', -1);
INSERT INTO `houses` VALUES (132, '', '2', '{\"x\":315.73755,\"y\":-195.02574,\"z\":53.062515}', '40000', 0, '80', '926452', '[]', -1);
INSERT INTO `houses` VALUES (133, '', '2', '{\"x\":319.3413,\"y\":-196.1717,\"z\":53.05803}', '40000', 0, '79', '842771', '[]', -1);
INSERT INTO `houses` VALUES (134, '', '2', '{\"x\":321.40015,\"y\":-196.96545,\"z\":53.106503}', '40000', 0, '78', '428603', '[]', -1);
INSERT INTO `houses` VALUES (135, '', '2', '{\"x\":307.59848,\"y\":-213.20831,\"z\":53.10168}', '40000', 0, '84', '745216', '[]', -1);
INSERT INTO `houses` VALUES (136, '', '2', '{\"x\":307.08258,\"y\":-216.53252,\"z\":53.101784}', '40000', 0, '85', '560095', '[]', -1);
INSERT INTO `houses` VALUES (137, '', '2', '{\"x\":310.77478,\"y\":-217.99457,\"z\":53.101807}', '40000', 1, '86', '493165', '[]', -1);
INSERT INTO `houses` VALUES (138, '', '2', '{\"x\":313.00623,\"y\":-218.80687,\"z\":53.101917}', '60000', 1, '87', '164723', '[]', -1);
INSERT INTO `houses` VALUES (139, '', '2', '{\"x\":329.28738,\"y\":-225.23036,\"z\":53.10178}', '60000', 1, '77', '690108', '[]', -1);
INSERT INTO `houses` VALUES (140, '', '2', '{\"x\":331.4496,\"y\":-225.95514,\"z\":53.10178}', '40000', 1, '75', '189317', '[]', -1);
INSERT INTO `houses` VALUES (141, '', '2', '{\"x\":334.9322,\"y\":-227.28891,\"z\":53.101784}', '40000', 0, '74', '335822', '[]', -1);
INSERT INTO `houses` VALUES (142, '', '2', '{\"x\":337.14066,\"y\":-224.64986,\"z\":53.101784}', '40000', 1, '73', '852621', '[]', -1);
INSERT INTO `houses` VALUES (143, '', '2', '{\"x\":339.15082,\"y\":-219.40901,\"z\":53.101784}', '40000', 1, '72', '456866', '[]', -1);
INSERT INTO `houses` VALUES (144, '', '2', '{\"x\":340.85522,\"y\":-214.97108,\"z\":53.10182}', '40000', 1, '71', '914125', '[]', -1);
INSERT INTO `houses` VALUES (145, '', '2', '{\"x\":342.9597,\"y\":-209.48753,\"z\":53.101807}', '40000', 0, '70', '566631', '[]', -1);
INSERT INTO `houses` VALUES (146, '', '2', '{\"x\":344.61954,\"y\":-205.16414,\"z\":53.104267}', '40000', 1, '69', '722047', '[]', -1);
INSERT INTO `houses` VALUES (147, '', '2', '{\"x\":520.11505,\"y\":228.76344,\"z\":103.62405}', '40000', 1, '96', '311350', '[]', -1);
INSERT INTO `houses` VALUES (148, '', '2', '{\"x\":527.4529,\"y\":226.09406,\"z\":103.62458}', '40000', 0, '97', '173419', '[]', -1);
INSERT INTO `houses` VALUES (149, '', '2', '{\"x\":531.60376,\"y\":222.09155,\"z\":103.61813}', '40000', 0, '98', '337533', '[]', -1);
INSERT INTO `houses` VALUES (150, '', '2', '{\"x\":528.2401,\"y\":213.97,\"z\":103.62444}', '40000', 1, '99', '892106', '[]', -1);
INSERT INTO `houses` VALUES (151, '', '2', '{\"x\":526.01996,\"y\":207.4017,\"z\":103.62412}', '40000', 1, '100', '683233', '[]', -1);
INSERT INTO `houses` VALUES (152, '', '2', '{\"x\":523.2421,\"y\":199.67238,\"z\":103.62426}', '40000', 1, '101', '230484', '[]', -1);
INSERT INTO `houses` VALUES (153, '', '2', '{\"x\":520.6013,\"y\":192.19632,\"z\":103.62466}', '40000', 1, '102', '673655', '[]', -1);
INSERT INTO `houses` VALUES (154, '', '2', '{\"x\":515.28064,\"y\":190.85217,\"z\":103.62498}', '40000', 0, '103', '907463', '[]', -1);
INSERT INTO `houses` VALUES (155, '', '2', '{\"x\":509.07703,\"y\":193.1034,\"z\":103.62498}', '40000', 0, '104', '455329', '[]', -1);
INSERT INTO `houses` VALUES (156, '', '2', '{\"x\":485.43167,\"y\":201.72672,\"z\":103.62497}', '40000', 0, '88', '594652', '[]', -1);
INSERT INTO `houses` VALUES (157, '', '2', '{\"x\":481.95316,\"y\":205.7631,\"z\":103.6248}', '40000', 0, '89', '707587', '[]', -1);
INSERT INTO `houses` VALUES (158, '', '2', '{\"x\":484.47354,\"y\":212.78642,\"z\":103.62419}', '40000', 0, '90', '594246', '[]', -1);
INSERT INTO `houses` VALUES (159, '', '2', '{\"x\":487.43835,\"y\":220.80852,\"z\":103.6242}', '40000', 1, '91', '378127', '[]', -1);
INSERT INTO `houses` VALUES (160, '', '2', '{\"x\":489.61893,\"y\":226.93057,\"z\":103.62467}', '40000', 0, '92', '124493', '[]', -1);
INSERT INTO `houses` VALUES (161, '', '2', '{\"x\":496.7859,\"y\":237.37482,\"z\":103.62491}', '40000', 0, '93', '443912', '[]', -1);
INSERT INTO `houses` VALUES (162, '', '2', '{\"x\":504.90823,\"y\":234.4458,\"z\":103.62442}', '40000', 0, '94', '988071', '[]', -1);
INSERT INTO `houses` VALUES (163, '', '2', '{\"x\":511.23877,\"y\":231.99352,\"z\":103.624084}', '40000', 0, '95', '650924', '[]', -1);
INSERT INTO `houses` VALUES (164, '', '6', '{\"x\":-1549.4196,\"y\":-90.46821,\"z\":53.809185}', '1500000', 1, '47', '275156', '[]', -1);
INSERT INTO `houses` VALUES (165, '', '6', '{\"x\":-2587.844,\"y\":1910.8741,\"z\":166.37897}', '2000000', 1, '48', '496613', '[]', -1);
INSERT INTO `houses` VALUES (166, '', '7', '{\"x\":-267.33832,\"y\":-739.86145,\"z\":33.296776}', '25000', 0, '1000', '644323', '[]', 1000);
INSERT INTO `houses` VALUES (167, '', '7', '{\"x\":-267.33832,\"y\":-739.86145,\"z\":33.296776}', '25000', 1, '1001', '28671', '[]', 1000);
INSERT INTO `houses` VALUES (168, '', '2', '{\"x\":495.56943,\"y\":-1823.0178,\"z\":27.749702}', '40000', 0, '51', '981584', '[]', -1);
INSERT INTO `houses` VALUES (169, '', '3', '{\"x\":-1024.6201,\"y\":-1139.4546,\"z\":1.6252726}', '110000', 0, '186', '892493', '[]', -1);
INSERT INTO `houses` VALUES (170, '', '3', '{\"x\":-1034.6089,\"y\":-1147.0815,\"z\":1.0385987}', '110000', 0, '188', '237743', '[]', -1);
INSERT INTO `houses` VALUES (171, '', '3', '{\"x\":-1045.9878,\"y\":-1159.8147,\"z\":1.0385994}', '110000', 0, '190', '127492', '[]', -1);
INSERT INTO `houses` VALUES (172, '', '3', '{\"x\":-1063.4043,\"y\":-1160.2498,\"z\":1.6254233}', '110000', 0, '191', '570451', '[]', -1);
INSERT INTO `houses` VALUES (173, '', '3', '{\"x\":-1068.1332,\"y\":-1163.57,\"z\":1.6252908}', '110000', 0, '193', '449719', '[]', -1);
INSERT INTO `houses` VALUES (174, '', '3', '{\"x\":-1127.9177,\"y\":-1080.781,\"z\":3.1026907}', '110000', 0, '231', '408503', '[]', -1);
INSERT INTO `houses` VALUES (175, '', '3', '{\"x\":-1074.0911,\"y\":-1152.7974,\"z\":1.0385963}', '110000', 0, '192', '47756', '[]', -1);
INSERT INTO `houses` VALUES (176, '', '3', '{\"x\":-1122.3341,\"y\":-1046.3596,\"z\":1.0303549}', '110000', 0, '229', '942102', '[]', -1);
INSERT INTO `houses` VALUES (177, '', '3', '{\"x\":-1114.1323,\"y\":-1069.2777,\"z\":1.0303558}', '110000', 0, '227', '933616', '[]', -1);
INSERT INTO `houses` VALUES (178, '', '3', '{\"x\":-1104.0731,\"y\":-1060.0085,\"z\":1.6124631}', '110000', 0, '225', '50566', '[]', -1);
INSERT INTO `houses` VALUES (179, '', '3', '{\"x\":-1108.7986,\"y\":-1040.9379,\"z\":1.030356}', '110000', 0, '223', '172423', '[]', -1);
INSERT INTO `houses` VALUES (180, '', '3', '{\"x\":-1040.5928,\"y\":-1135.9958,\"z\":1.038597}', '110000', 0, '189', '931536', '[]', -1);
INSERT INTO `houses` VALUES (181, '', '3', '{\"x\":-1092.0944,\"y\":-1039.9689,\"z\":1.030356}', '110000', 0, '221', '416533', '[]', -1);
INSERT INTO `houses` VALUES (182, '', '3', '{\"x\":-1068.4581,\"y\":-1049.1835,\"z\":5.2916627}', '110000', 1, '219', '9188', '[]', -1);
INSERT INTO `houses` VALUES (183, '', '3', '{\"x\":-1033.9913,\"y\":-1128.038,\"z\":1.0385967}', '110000', 1, '187', '184154', '[]', -1);
INSERT INTO `houses` VALUES (184, '', '3', '{\"x\":-1151.8959,\"y\":-1132.7695,\"z\":1.6296958}', '110000', 0, '203', '815218', '[]', -1);
INSERT INTO `houses` VALUES (185, '', '3', '{\"x\":-1041.5599,\"y\":-1025.7587,\"z\":1.6262716}', '110000', 0, '215', '988868', '[]', -1);
INSERT INTO `houses` VALUES (186, '', '3', '{\"x\":-1051.4618,\"y\":-1006.6263,\"z\":5.290491}', '110000', 0, '217', '744336', '[]', -1);
INSERT INTO `houses` VALUES (187, '', '3', '{\"x\":-1022.07227,\"y\":-1022.89484,\"z\":1.0303613}', '110000', 0, '213', '252798', '[]', -1);
INSERT INTO `houses` VALUES (188, '', '3', '{\"x\":-1023.0248,\"y\":-997.83386,\"z\":1.0301944}', '110000', 0, '211', '935306', '[]', -1);
INSERT INTO `houses` VALUES (189, '', '3', '{\"x\":-1008.50903,\"y\":-1015.2959,\"z\":1.0303081}', '110000', 0, '209', '973273', '[]', -1);
INSERT INTO `houses` VALUES (190, '', '3', '{\"x\":-1149.7931,\"y\":-1136.4124,\"z\":1.6242789}', '110000', 0, '205', '150565', '[]', -1);
INSERT INTO `houses` VALUES (191, '', '3', '{\"x\":-1142.5839,\"y\":-1144.1827,\"z\":1.7279204}', '110000', 0, '206', '852506', '[]', -1);
INSERT INTO `houses` VALUES (192, '', '3', '{\"x\":-990.67334,\"y\":-975.7802,\"z\":3.102696}', '110000', 0, '208', '898917', '[]', -1);
INSERT INTO `houses` VALUES (193, '', '3', '{\"x\":-978.5899,\"y\":-990.83215,\"z\":3.425321}', '110000', 0, '207', '786594', '[]', -1);
INSERT INTO `houses` VALUES (194, '', '3', '{\"x\":-1139.7964,\"y\":-1150.3866,\"z\":1.7054292}', '110000', 0, '210', '565615', '[]', -1);
INSERT INTO `houses` VALUES (195, '', '3', '{\"x\":-1135.6958,\"y\":-1153.1522,\"z\":1.6276563}', '110000', 0, '212', '745403', '[]', -1);
INSERT INTO `houses` VALUES (196, '', '3', '{\"x\":-1133.2269,\"y\":-1164.0406,\"z\":1.5752105}', '110000', 0, '214', '347749', '[]', -1);
INSERT INTO `houses` VALUES (197, '', '3', '{\"x\":-991.81805,\"y\":-1103.5428,\"z\":1.030312}', '110000', 0, '195', '201698', '[]', -1);
INSERT INTO `houses` VALUES (198, '', '3', '{\"x\":-1125.8105,\"y\":-1171.967,\"z\":1.2359425}', '110000', 1, '216', '181710', '[]', -1);
INSERT INTO `houses` VALUES (199, '', '3', '{\"x\":-985.80096,\"y\":-1121.8561,\"z\":3.4255795}', '110000', 0, '194', '417513', '[]', -1);
INSERT INTO `houses` VALUES (200, '', '3', '{\"x\":-1113.677,\"y\":-1193.6775,\"z\":1.2545439}', '110000', 0, '218', '705980', '[]', -1);
INSERT INTO `houses` VALUES (201, '', '3', '{\"x\":-977.70703,\"y\":-1092.3331,\"z\":3.1025543}', '110000', 0, '197', '734141', '[]', -1);
INSERT INTO `houses` VALUES (202, '', '3', '{\"x\":-1107.5906,\"y\":-1223.047,\"z\":1.4413348}', '110000', 0, '220', '329765', '[]', -1);
INSERT INTO `houses` VALUES (203, '', '3', '{\"x\":-978.10034,\"y\":-1108.2756,\"z\":1.0303131}', '110000', 0, '196', '280925', '[]', -1);
INSERT INTO `houses` VALUES (204, '', '3', '{\"x\":-1100.1569,\"y\":-1231.935,\"z\":2.0631351}', '110000', 0, '222', '99790', '[]', -1);
INSERT INTO `houses` VALUES (205, '', '3', '{\"x\":-952.3773,\"y\":-1077.5182,\"z\":1.5523206}', '110000', 0, '200', '764615', '[]', -1);
INSERT INTO `houses` VALUES (206, '', '3', '{\"x\":-948.4526,\"y\":-1107.6423,\"z\":1.0518461}', '110000', 0, '199', '112782', '[]', -1);
INSERT INTO `houses` VALUES (207, '', '3', '{\"x\":-943.18134,\"y\":-1075.3136,\"z\":1.6252724}', '110000', 0, '204', '780764', '[]', -1);
INSERT INTO `houses` VALUES (208, '', '3', '{\"x\":-1161.3701,\"y\":-1100.0197,\"z\":1.099821}', '110000', 0, '201', '265153', '[]', -1);
INSERT INTO `houses` VALUES (209, '', '3', '{\"x\":-3089.334,\"y\":221.13765,\"z\":12.998801}', '110000', 0, '233', '859707', '[]', -1);
INSERT INTO `houses` VALUES (210, '', '3', '{\"x\":-938.7285,\"y\":-1087.8195,\"z\":1.0303108}', '110000', 0, '202', '513225', '[]', -1);
INSERT INTO `houses` VALUES (211, '', '3', '{\"x\":-1182.8634,\"y\":-1064.3195,\"z\":1.0304111}', '110000', 0, '230', '661034', '[]', -1);
INSERT INTO `houses` VALUES (212, '', '3', '{\"x\":-1190.9622,\"y\":-1054.7097,\"z\":1.0304302}', '110000', 0, '228', '657022', '[]', -1);
INSERT INTO `houses` VALUES (213, '', '3', '{\"x\":-1200.5728,\"y\":-1031.8401,\"z\":1.0303913}', '110000', 0, '226', '421823', '[]', -1);
INSERT INTO `houses` VALUES (214, '', '3', '{\"x\":-959.7608,\"y\":-1109.7554,\"z\":1.0303129}', '110000', 0, '198', '446589', '[]', -1);
INSERT INTO `houses` VALUES (215, '', '3', '{\"x\":-1204.5652,\"y\":-1022.03156,\"z\":4.8251147}', '110000', 0, '224', '707959', '[]', -1);
INSERT INTO `houses` VALUES (216, '', '3', '{\"x\":-1177.6936,\"y\":-1073.3519,\"z\":4.7863784}', '110000', 0, '232', '434724', '[]', -1);
INSERT INTO `houses` VALUES (217, '', '3', '{\"x\":-3225.1714,\"y\":910.9689,\"z\":12.873272}', '110000', 0, '265', '803918', '[]', -1);
INSERT INTO `houses` VALUES (218, '', '3', '{\"x\":-3228.9346,\"y\":927.1513,\"z\":12.849764}', '110000', 0, '264', '835705', '[]', -1);
INSERT INTO `houses` VALUES (219, '', '3', '{\"x\":-3232.7734,\"y\":934.72906,\"z\":12.678426}', '110000', 0, '262', '286286', '[]', -1);
INSERT INTO `houses` VALUES (220, '', '3', '{\"x\":-3238.3984,\"y\":952.7047,\"z\":12.223186}', '110000', 0, '260', '752276', '[]', -1);
INSERT INTO `houses` VALUES (221, '', '3', '{\"x\":-3105.415,\"y\":246.82912,\"z\":11.376629}', '110000', 1, '263', '607852', '[]', -1);
INSERT INTO `houses` VALUES (222, '', '3', '{\"x\":-3251.2473,\"y\":1027.4392,\"z\":10.637702}', '110000', 0, '258', '52600', '[]', -1);
INSERT INTO `houses` VALUES (223, '', '3', '{\"x\":-3105.9666,\"y\":286.69604,\"z\":7.8521185}', '110000', 0, '261', '8311', '[]', -1);
INSERT INTO `houses` VALUES (224, '', '3', '{\"x\":-3254.7795,\"y\":1063.6849,\"z\":10.0261965}', '110000', 0, '256', '741929', '[]', -1);
INSERT INTO `houses` VALUES (225, '', '3', '{\"x\":-3105.9922,\"y\":311.80682,\"z\":7.261034}', '110000', 0, '259', '385236', '[]', -1);
INSERT INTO `houses` VALUES (226, '', '3', '{\"x\":-3232.8523,\"y\":1068.204,\"z\":9.913505}', '110000', 0, '254', '228573', '[]', -1);
INSERT INTO `houses` VALUES (227, '', '3', '{\"x\":-3110.6626,\"y\":335.11655,\"z\":6.373348}', '110000', 0, '257', '783856', '[]', -1);
INSERT INTO `houses` VALUES (228, '', '3', '{\"x\":-3232.1023,\"y\":1081.7463,\"z\":9.68725}', '110000', 0, '251', '884102', '[]', -1);
INSERT INTO `houses` VALUES (229, '', '3', '{\"x\":-3225.113,\"y\":1112.6859,\"z\":9.6765585}', '110000', 0, '249', '663098', '[]', -1);
INSERT INTO `houses` VALUES (230, '', '3', '{\"x\":-3093.7979,\"y\":349.29553,\"z\":6.424457}', '110000', 1, '255', '700006', '[]', -1);
INSERT INTO `houses` VALUES (231, '', '3', '{\"x\":-3091.5034,\"y\":379.24567,\"z\":5.99182}', '110000', 0, '253', '740405', '[]', -1);
INSERT INTO `houses` VALUES (232, '', '3', '{\"x\":-3220.0178,\"y\":1138.4219,\"z\":8.775405}', '110000', 0, '246', '751906', '[]', -1);
INSERT INTO `houses` VALUES (233, '', '3', '{\"x\":-3088.885,\"y\":392.2552,\"z\":10.332986}', '110000', 0, '252', '633051', '[]', -1);
INSERT INTO `houses` VALUES (234, '', '3', '{\"x\":-3200.3906,\"y\":1165.4545,\"z\":8.534345}', '110000', 0, '244', '466442', '[]', -1);
INSERT INTO `houses` VALUES (235, '', '3', '{\"x\":-3195.1545,\"y\":1179.2573,\"z\":8.538896}', '110000', 0, '242', '197396', '[]', -1);
INSERT INTO `houses` VALUES (236, '', '3', '{\"x\":-3059.424,\"y\":453.17688,\"z\":5.235004}', '110000', 0, '250', '86768', '[]', -1);
INSERT INTO `houses` VALUES (237, '', '3', '{\"x\":-3193.5596,\"y\":1208.3815,\"z\":8.305224}', '110000', 0, '239', '728262', '[]', -1);
INSERT INTO `houses` VALUES (238, '', '3', '{\"x\":-3047.4783,\"y\":482.99692,\"z\":5.6596475}', '110000', 0, '248', '84364', '[]', -1);
INSERT INTO `houses` VALUES (239, '', '3', '{\"x\":-3200.4326,\"y\":1232.5524,\"z\":8.928323}', '110000', 0, '237', '50603', '[]', -1);
INSERT INTO `houses` VALUES (240, '', '3', '{\"x\":-3039.5378,\"y\":492.74747,\"z\":5.6526327}', '110000', 0, '247', '876086', '[]', -1);
INSERT INTO `houses` VALUES (241, '', '3', '{\"x\":-3031.8206,\"y\":524.97424,\"z\":6.303022}', '110000', 0, '245', '963571', '[]', -1);
INSERT INTO `houses` VALUES (242, '', '3', '{\"x\":-3190.9888,\"y\":1297.7476,\"z\":17.972502}', '110000', 1, '234', '987644', '[]', -1);
INSERT INTO `houses` VALUES (243, '', '3', '{\"x\":-3037.2334,\"y\":558.8576,\"z\":6.3876824}', '110000', 0, '243', '75599', '[]', -1);
INSERT INTO `houses` VALUES (244, '', '3', '{\"x\":-3107.7524,\"y\":718.89526,\"z\":19.534058}', '110000', 0, '238', '460048', '[]', -1);
INSERT INTO `houses` VALUES (245, '', '3', '{\"x\":-3029.968,\"y\":568.62445,\"z\":6.70734}', '110000', 0, '241', '489529', '[]', -1);
INSERT INTO `houses` VALUES (246, '', '3', '{\"x\":-3078.0293,\"y\":658.95874,\"z\":10.546582}', '110000', 0, '240', '195485', '[]', -1);
INSERT INTO `houses` VALUES (247, '', '3', '{\"x\":-3187.3713,\"y\":1274.0477,\"z\":11.554646}', '110000', 0, '236', '477094', '[]', -1);
INSERT INTO `houses` VALUES (248, '', '3', '{\"x\":-3101.6753,\"y\":743.9611,\"z\":20.16481}', '110000', 0, '235', '340005', '[]', -1);
INSERT INTO `houses` VALUES (249, '', '5', '{\"x\":-3017.0728,\"y\":746.7931,\"z\":26.661707}', '680000', 0, '266', '857655', '[]', -1);
INSERT INTO `houses` VALUES (250, '', '4', '{\"x\":-2993.0356,\"y\":707.5565,\"z\":27.576683}', '135000', 1, '267', '310679', '[]', -1);
INSERT INTO `houses` VALUES (251, '', '4', '{\"x\":-2994.6333,\"y\":682.6437,\"z\":23.922121}', '135000', 1, '268', '543830', '[]', -1);
INSERT INTO `houses` VALUES (252, '', '4', '{\"x\":-2972.5637,\"y\":642.66425,\"z\":24.871944}', '135000', 1, '269', '365991', '[]', -1);
INSERT INTO `houses` VALUES (253, '', '4', '{\"x\":-2977.0312,\"y\":609.35535,\"z\":19.126158}', '135000', 1, '270', '895423', '[]', -1);
INSERT INTO `houses` VALUES (254, '', '0', '{\"x\":404.4113,\"y\":2584.4111,\"z\":42.399563}', '15000', 1, '274', '665236', '[]', -1);
INSERT INTO `houses` VALUES (255, '', '0', '{\"x\":382.85144,\"y\":2576.4922,\"z\":43.4084}', '15000', 1, '273', '98128', '[]', -1);
INSERT INTO `houses` VALUES (256, '', '0', '{\"x\":367.06638,\"y\":2571.6025,\"z\":43.412342}', '15000', 1, '272', '681541', '[]', -1);
INSERT INTO `houses` VALUES (257, '', '0', '{\"x\":348.40973,\"y\":2565.7805,\"z\":42.399563}', '15000', 1, '271', '321454', '[]', -1);
INSERT INTO `houses` VALUES (258, '', '1', '{\"x\":1142.3237,\"y\":2654.7756,\"z\":37.031277}', '35000', 1, '275', '538995', '[]', -1);
INSERT INTO `houses` VALUES (259, '', '1', '{\"x\":392.64557,\"y\":2634.1316,\"z\":43.552406}', '25000', 1, '276', '714553', '[]', -1);
INSERT INTO `houses` VALUES (260, '', '1', '{\"x\":1142.3225,\"y\":2651.2898,\"z\":37.02085}', '35000', 1, '277', '536042', '[]', -1);
INSERT INTO `houses` VALUES (261, '', '1', '{\"x\":1142.3359,\"y\":2643.5515,\"z\":37.02488}', '35000', 1, '279', '328925', '[]', -1);
INSERT INTO `houses` VALUES (262, '', '1', '{\"x\":380.0019,\"y\":2629.2908,\"z\":43.551815}', '25000', 1, '278', '896660', '[]', -1);
INSERT INTO `houses` VALUES (263, '', '1', '{\"x\":1141.2671,\"y\":2641.733,\"z\":37.02376}', '35000', 1, '281', '602053', '[]', -1);
INSERT INTO `houses` VALUES (264, '', '1', '{\"x\":367.0556,\"y\":2624.4587,\"z\":43.552395}', '35000', 1, '280', '159702', '[]', -1);
INSERT INTO `houses` VALUES (265, '', '1', '{\"x\":1136.5342,\"y\":2641.7288,\"z\":37.023773}', '35000', 1, '283', '772819', '[]', -1);
INSERT INTO `houses` VALUES (266, '', '1', '{\"x\":354.34656,\"y\":2619.7268,\"z\":43.5524}', '25000', 1, '282', '909126', '[]', -1);
INSERT INTO `houses` VALUES (267, '', '1', '{\"x\":1132.8906,\"y\":2641.7278,\"z\":37.02377}', '35000', 1, '285', '23971', '[]', -1);
INSERT INTO `houses` VALUES (268, '', '1', '{\"x\":341.7568,\"y\":2614.9712,\"z\":43.55206}', '35000', 1, '284', '955380', '[]', -1);
INSERT INTO `houses` VALUES (269, '', '1', '{\"x\":1125.1903,\"y\":2641.7341,\"z\":37.023766}', '25000', 0, '286', '249194', '[]', -1);
INSERT INTO `houses` VALUES (270, '', '1', '{\"x\":1121.4471,\"y\":2641.729,\"z\":37.023766}', '25000', 0, '287', '621191', '[]', -1);
INSERT INTO `houses` VALUES (271, '', '1', '{\"x\":1106.0933,\"y\":2649.0977,\"z\":37.020935}', '25000', 0, '290', '706461', '[]', -1);
INSERT INTO `houses` VALUES (272, '', '1', '{\"x\":1114.7832,\"y\":2641.7395,\"z\":37.02376}', '25000', 0, '288', '719554', '[]', -1);
INSERT INTO `houses` VALUES (273, '', '1', '{\"x\":1107.3281,\"y\":2641.7395,\"z\":37.023754}', '25000', 0, '289', '785102', '[]', -1);
INSERT INTO `houses` VALUES (274, '', '1', '{\"x\":1106.0929,\"y\":2652.9092,\"z\":37.020935}', '25000', 0, '291', '410198', '[]', -1);
INSERT INTO `houses` VALUES (275, '', '0', '{\"x\":890.83093,\"y\":2854.9014,\"z\":55.88039}', '15000', 1, '292', '788704', '[]', -1);
INSERT INTO `houses` VALUES (276, '', '0', '{\"x\":866.6161,\"y\":2878.4666,\"z\":56.756233}', '15000', 1, '293', '620207', '[]', -1);
INSERT INTO `houses` VALUES (277, '', '0', '{\"x\":848.14325,\"y\":2864.0728,\"z\":57.365692}', '15000', 1, '294', '976999', '[]', -1);
INSERT INTO `houses` VALUES (278, '', '0', '{\"x\":1936.5677,\"y\":3891.723,\"z\":31.84624}', '15000', 1, '298', '548262', '[]', -1);
INSERT INTO `houses` VALUES (279, '', '1', '{\"x\":1880.463,\"y\":3920.7778,\"z\":32.095516}', '25000', 1, '295', '252400', '[]', -1);
INSERT INTO `houses` VALUES (280, '', '1', '{\"x\":1919.017,\"y\":3913.779,\"z\":32.321644}', '25000', 1, '299', '189751', '[]', -1);
INSERT INTO `houses` VALUES (281, '', '0', '{\"x\":1777.5178,\"y\":3799.9714,\"z\":33.404064}', '15000', 0, '0', '751477', '[]', -1);
INSERT INTO `houses` VALUES (282, '', '0', '{\"x\":1902.342,\"y\":3866.919,\"z\":31.946104}', '15000', 1, '297', '443851', '[]', -1);
INSERT INTO `houses` VALUES (283, '', '1', '{\"x\":1925.0564,\"y\":3824.7112,\"z\":31.319975}', '35000', 1, '300', '26447', '[]', -1);
INSERT INTO `houses` VALUES (284, '', '1', '{\"x\":1932.9567,\"y\":3804.831,\"z\":31.789896}', '25000', 1, '301', '352419', '[]', -1);
INSERT INTO `houses` VALUES (285, '', '1', '{\"x\":3725.3044,\"y\":4525.6323,\"z\":21.350494}', '25000', 0, '318', '156176', '[]', -1);
INSERT INTO `houses` VALUES (286, '', '1', '{\"x\":1898.9744,\"y\":3781.705,\"z\":31.756887}', '35000', 1, '303', '374414', '[]', -1);
INSERT INTO `houses` VALUES (287, '', '1', '{\"x\":1880.6449,\"y\":3810.571,\"z\":31.658827}', '25000', 0, '304', '856482', '[]', -1);
INSERT INTO `houses` VALUES (288, '', '1', '{\"x\":1843.5087,\"y\":3778.0342,\"z\":32.465626}', '35000', 1, '305', '967814', '[]', -1);
INSERT INTO `houses` VALUES (289, '', '1', '{\"x\":1777.3702,\"y\":3738.1147,\"z\":33.535122}', '25000', 1, '309', '368314', '[]', -1);
INSERT INTO `houses` VALUES (290, '', '1', '{\"x\":1737.9492,\"y\":3709.1165,\"z\":33.015812}', '25000', 0, '0', '515853', '[]', -1);
INSERT INTO `houses` VALUES (291, '', '1', '{\"x\":1748.8414,\"y\":3783.505,\"z\":33.71492}', '25000', 1, '308', '765312', '[]', -1);
INSERT INTO `houses` VALUES (292, '', '1', '{\"x\":3688.075,\"y\":4562.674,\"z\":24.063055}', '25000', 0, '317', '189268', '[]', -1);
INSERT INTO `houses` VALUES (293, '', '1', '{\"x\":1763.7247,\"y\":3823.5752,\"z\":33.647816}', '25000', 0, '306', '369810', '[]', -1);
INSERT INTO `houses` VALUES (294, '', '1', '{\"x\":1733.6875,\"y\":3808.7456,\"z\":33.99911}', '25000', 1, '307', '514559', '[]', -1);
INSERT INTO `houses` VALUES (295, '', '1', '{\"x\":1728.4426,\"y\":3851.7559,\"z\":33.66497}', '25000', 1, '311', '547162', '[]', -1);
INSERT INTO `houses` VALUES (296, '', '1', '{\"x\":1744.3151,\"y\":3887.0454,\"z\":34.420128}', '25000', 0, '313', '66911', '[]', -1);
INSERT INTO `houses` VALUES (297, '', '1', '{\"x\":1691.6143,\"y\":3865.6763,\"z\":33.787598}', '35000', 1, '312', '385591', '[]', -1);
INSERT INTO `houses` VALUES (298, '', '1', '{\"x\":1661.2681,\"y\":3819.9575,\"z\":34.34819}', '25000', 0, '0', '915895', '[]', -1);
INSERT INTO `houses` VALUES (299, '', '1', '{\"x\":1781.5725,\"y\":3911.2158,\"z\":33.789616}', '25000', 0, '0', '687227', '[]', -1);
INSERT INTO `houses` VALUES (300, '', '1', '{\"x\":1803.5354,\"y\":3913.6704,\"z\":35.93693}', '25000', 1, '315', '580401', '[]', -1);
INSERT INTO `houses` VALUES (301, '', '1', '{\"x\":1845.7836,\"y\":3914.3928,\"z\":32.341145}', '25000', 1, '316', '171515', '[]', -1);
INSERT INTO `houses` VALUES (302, '', '2', '{\"x\":3310.7437,\"y\":5176.449,\"z\":18.494587}', '60000', 1, '319', '521713', '[]', -1);
INSERT INTO `houses` VALUES (303, '', '1', '{\"x\":35.4,\"y\":6663.1553,\"z\":31.070398}', '25000', 0, '320', '90812', '[]', -1);
INSERT INTO `houses` VALUES (304, '', '1', '{\"x\":-9.662527,\"y\":6654.1963,\"z\":30.57881}', '25000', 1, '321', '236464', '[]', -1);
INSERT INTO `houses` VALUES (305, '', '1', '{\"x\":1.6569208,\"y\":6612.475,\"z\":30.959627}', '25000', 0, '322', '604217', '[]', -1);
INSERT INTO `houses` VALUES (306, '', '1', '{\"x\":25.093637,\"y\":6601.8423,\"z\":31.350431}', '25000', 0, '326', '824275', '[]', -1);
INSERT INTO `houses` VALUES (307, '', '1', '{\"x\":11.582365,\"y\":6578.3755,\"z\":31.950834}', '25000', 0, '325', '580888', '[]', -1);
INSERT INTO `houses` VALUES (308, '', '1', '{\"x\":-15.30009,\"y\":6557.416,\"z\":32.120365}', '25000', 0, '324', '485225', '[]', -1);
INSERT INTO `houses` VALUES (309, '', '1', '{\"x\":-44.48674,\"y\":6581.9375,\"z\":31.055529}', '25000', 0, '323', '876530', '[]', -1);
INSERT INTO `houses` VALUES (310, '', '1', '{\"x\":-130.71378,\"y\":6551.9224,\"z\":28.75267}', '25000', 0, '327', '477919', '[]', -1);
INSERT INTO `houses` VALUES (311, '', '1', '{\"x\":-105.572586,\"y\":6528.503,\"z\":29.046915}', '25000', 0, '328', '704540', '[]', -1);
INSERT INTO `houses` VALUES (312, '', '1', '{\"x\":-188.89255,\"y\":6409.558,\"z\":31.176737}', '25000', 0, '329', '773191', '[]', -1);
INSERT INTO `houses` VALUES (313, '', '1', '{\"x\":-213.52187,\"y\":6396.3315,\"z\":31.965078}', '25000', 0, '331', '286595', '[]', -1);
INSERT INTO `houses` VALUES (314, '', '1', '{\"x\":-238.34024,\"y\":6423.6577,\"z\":30.342304}', '25000', 0, '330', '524802', '[]', -1);
INSERT INTO `houses` VALUES (315, '', '1', '{\"x\":-272.45032,\"y\":6401.1196,\"z\":30.384962}', '25000', 0, '333', '784564', '[]', -1);
INSERT INTO `houses` VALUES (316, '', '1', '{\"x\":-248.1171,\"y\":6370.113,\"z\":30.732088}', '25000', 0, '334', '885072', '[]', -1);
INSERT INTO `houses` VALUES (317, '', '1', '{\"x\":-227.13084,\"y\":6377.498,\"z\":30.63917}', '25000', 0, '332', '870214', '[]', -1);
INSERT INTO `houses` VALUES (318, '', '1', '{\"x\":-280.65012,\"y\":6350.5674,\"z\":31.480787}', '25000', 0, '335', '249634', '[]', -1);
INSERT INTO `houses` VALUES (319, '', '1', '{\"x\":-302.12656,\"y\":6327.077,\"z\":31.7674}', '25000', 0, '336', '3526', '[]', -1);
INSERT INTO `houses` VALUES (320, '', '1', '{\"x\":-332.9248,\"y\":6302.151,\"z\":31.968119}', '25000', 0, '338', '398406', '[]', -1);
INSERT INTO `houses` VALUES (321, '', '1', '{\"x\":-368.2299,\"y\":6341.5967,\"z\":28.723629}', '25000', 0, '337', '52645', '[]', -1);
INSERT INTO `houses` VALUES (322, '', '1', '{\"x\":-407.27188,\"y\":6314.181,\"z\":27.821283}', '25000', 0, '339', '56155', '[]', -1);
INSERT INTO `houses` VALUES (323, '', '1', '{\"x\":-437.78424,\"y\":6272.1226,\"z\":28.948261}', '25000', 1, '340', '587066', '[]', -1);
INSERT INTO `houses` VALUES (324, '', '1', '{\"x\":-468.10614,\"y\":6206.0894,\"z\":28.432848}', '25000', 0, '0', '733339', '[]', -1);
INSERT INTO `houses` VALUES (325, '', '1', '{\"x\":-374.32278,\"y\":6191.1616,\"z\":30.609537}', '25000', 1, '344', '855877', '[]', -1);
INSERT INTO `houses` VALUES (326, '', '1', '{\"x\":-357.02274,\"y\":6207.44,\"z\":30.722282}', '25000', 0, '343', '517194', '[]', -1);
INSERT INTO `houses` VALUES (327, '', '1', '{\"x\":-347.4574,\"y\":6225.418,\"z\":30.764097}', '35000', 1, '342', '349744', '[]', -1);
INSERT INTO `houses` VALUES (328, '', '1', '{\"x\":-360.16263,\"y\":6260.535,\"z\":30.78171}', '35000', 1, '341', '270543', '[]', -1);
INSERT INTO `houses` VALUES (329, '', '1', '{\"x\":-103.33752,\"y\":6330.7056,\"z\":34.38071}', '25000', 0, '350', '863034', '[]', -1);
INSERT INTO `houses` VALUES (330, '', '1', '{\"x\":-106.61586,\"y\":6333.971,\"z\":34.380714}', '25000', 0, '353', '721794', '[]', -1);
INSERT INTO `houses` VALUES (331, '', '1', '{\"x\":-107.522255,\"y\":6339.8467,\"z\":34.380714}', '25000', 0, '355', '234616', '[]', -1);
INSERT INTO `houses` VALUES (332, '', '1', '{\"x\":-102.25848,\"y\":6345.111,\"z\":34.380806}', '25000', 0, '356', '61105', '[]', -1);
INSERT INTO `houses` VALUES (333, '', '1', '{\"x\":-98.94812,\"y\":6348.405,\"z\":34.380806}', '25000', 0, '357', '861033', '[]', -1);
INSERT INTO `houses` VALUES (334, '', '1', '{\"x\":-93.64157,\"y\":6353.8447,\"z\":34.380806}', '25000', 0, '358', '671997', '[]', -1);
INSERT INTO `houses` VALUES (335, '', '1', '{\"x\":-90.26204,\"y\":6357.08,\"z\":34.380806}', '25000', 0, '359', '18237', '[]', -1);
INSERT INTO `houses` VALUES (336, '', '1', '{\"x\":-84.9899,\"y\":6362.376,\"z\":34.380806}', '25000', 1, '360', '229765', '[]', -1);
INSERT INTO `houses` VALUES (337, '', '1', '{\"x\":-84.970764,\"y\":6362.385,\"z\":30.455889}', '25000', 1, '354', '353040', '[]', -1);
INSERT INTO `houses` VALUES (338, '', '1', '{\"x\":-90.178024,\"y\":6357.144,\"z\":30.455889}', '25000', 0, '352', '789981', '[]', -1);
INSERT INTO `houses` VALUES (339, '', '1', '{\"x\":-93.4302,\"y\":6353.927,\"z\":30.455889}', '25000', 0, '351', '748201', '[]', -1);
INSERT INTO `houses` VALUES (340, '', '1', '{\"x\":-98.81999,\"y\":6348.5464,\"z\":30.455889}', '25000', 0, '349', '331900', '[]', -1);
INSERT INTO `houses` VALUES (341, '', '1', '{\"x\":-107.61434,\"y\":6339.752,\"z\":30.455889}', '25000', 0, '348', '793524', '[]', -1);
INSERT INTO `houses` VALUES (342, '', '1', '{\"x\":-109.63105,\"y\":6336.986,\"z\":30.456177}', '25000', 0, '347', '371257', '[]', -1);
INSERT INTO `houses` VALUES (343, '', '1', '{\"x\":-106.8208,\"y\":6334.1953,\"z\":30.456177}', '25000', 0, '346', '91285', '[]', -1);
INSERT INTO `houses` VALUES (344, '', '1', '{\"x\":-103.37009,\"y\":6330.7246,\"z\":30.456177}', '25000', 0, '345', '890393', '[]', -1);
INSERT INTO `houses` VALUES (345, '', '5', '{\"x\":-1899.0621,\"y\":132.3318,\"z\":80.86464}', '680000', 1, '361', '811312', '[]', -1);
INSERT INTO `houses` VALUES (346, '', '4', '{\"x\":-1932.0637,\"y\":162.63026,\"z\":83.53263}', '135000', 1, '362', '992120', '[]', -1);
INSERT INTO `houses` VALUES (347, '', '6', '{\"x\":-1929.3365,\"y\":595.309,\"z\":121.16483}', '999999', 1, '751', '902671', '[]', -1);
INSERT INTO `houses` VALUES (348, '', '5', '{\"x\":-1905.4836,\"y\":252.84344,\"z\":85.332855}', '680000', 0, '364', '845006', '[]', -1);
INSERT INTO `houses` VALUES (349, '', '5', '{\"x\":-1922.3376,\"y\":298.48926,\"z\":88.16725}', '680000', 0, '365', '729994', '[]', -1);
INSERT INTO `houses` VALUES (350, '', '5', '{\"x\":-1931.2698,\"y\":362.62375,\"z\":92.84668}', '680000', 0, '366', '662089', '[]', -1);
INSERT INTO `houses` VALUES (351, '', '5', '{\"x\":-1940.5282,\"y\":387.66113,\"z\":95.590164}', '680000', 0, '367', '196695', '[]', -1);
INSERT INTO `houses` VALUES (352, '', '6', '{\"x\":-1937.4115,\"y\":551.1088,\"z\":113.90328}', '950000', 0, '369', '135958', '[]', -1);
INSERT INTO `houses` VALUES (353, '', '5', '{\"x\":-1942.7102,\"y\":449.56766,\"z\":101.808044}', '680000', 0, '755', '912369', '[]', -1);
INSERT INTO `houses` VALUES (354, '', '6', '{\"x\":1393.8802,\"y\":1141.8655,\"z\":113.33125}', '5000000', 1, '752', '288822', '[]', -1);
INSERT INTO `houses` VALUES (355, '', '5', '{\"x\":-2014.7576,\"y\":499.70175,\"z\":106.05168}', '680000', 0, '375', '527757', '[]', -1);
INSERT INTO `houses` VALUES (356, '', '6', '{\"x\":-1974.6754,\"y\":631.0488,\"z\":121.55838}', '950000', 0, '374', '115360', '[]', -1);
INSERT INTO `houses` VALUES (357, '', '5', '{\"x\":-1896.0889,\"y\":642.4385,\"z\":129.08899}', '680000', 0, '372', '934645', '[]', -1);
INSERT INTO `houses` VALUES (358, '', '6', '{\"x\":-2011.0374,\"y\":445.2098,\"z\":101.89589}', '950000', 0, '376', '357472', '[]', -1);
INSERT INTO `houses` VALUES (359, '', '5', '{\"x\":-2008.8997,\"y\":367.6806,\"z\":93.69429}', '680000', 0, '377', '380585', '[]', -1);
INSERT INTO `houses` VALUES (360, '', '5', '{\"x\":-1995.7122,\"y\":300.9669,\"z\":90.84465}', '680000', 0, '378', '87023', '[]', -1);
INSERT INTO `houses` VALUES (361, '', '5', '{\"x\":-1970.3492,\"y\":246.06813,\"z\":86.69215}', '680000', 0, '379', '474531', '[]', -1);
INSERT INTO `houses` VALUES (362, '', '5', '{\"x\":-1961.2059,\"y\":211.86632,\"z\":85.68288}', '680000', 0, '380', '310345', '[]', -1);
INSERT INTO `houses` VALUES (363, '', '6', '{\"x\":-1861.2134,\"y\":310.50775,\"z\":87.99489}', '950000', 0, '382', '622190', '[]', -1);
INSERT INTO `houses` VALUES (364, '', '6', '{\"x\":-1807.8989,\"y\":333.1602,\"z\":88.44795}', '950000', 0, '383', '154737', '[]', -1);
INSERT INTO `houses` VALUES (365, '', '6', '{\"x\":-1733.3485,\"y\":378.84158,\"z\":88.60527}', '950000', 0, '384', '243304', '[]', -1);
INSERT INTO `houses` VALUES (366, '', '5', '{\"x\":-1673.3578,\"y\":385.63803,\"z\":88.22829}', '680000', 0, '385', '643436', '[]', -1);
INSERT INTO `houses` VALUES (367, '', '6', '{\"x\":-1539.875,\"y\":420.70972,\"z\":108.89398}', '950000', 0, '501', '912157', '[]', -1);
INSERT INTO `houses` VALUES (368, '', '5', '{\"x\":-1495.8696,\"y\":436.9247,\"z\":111.377884}', '680000', 0, '500', '614597', '[]', -1);
INSERT INTO `houses` VALUES (369, '', '5', '{\"x\":-1453.8715,\"y\":512.36255,\"z\":116.67611}', '680000', 0, '498', '506566', '[]', -1);
INSERT INTO `houses` VALUES (370, '', '5', '{\"x\":-1452.851,\"y\":545.7552,\"z\":119.87768}', '680000', 0, '497', '554799', '[]', -1);
INSERT INTO `houses` VALUES (371, '', '5', '{\"x\":-1500.5686,\"y\":523.1619,\"z\":117.152245}', '680000', 0, '499', '532033', '[]', -1);
INSERT INTO `houses` VALUES (372, '', '5', '{\"x\":373.87817,\"y\":427.8261,\"z\":144.56422}', '680000', 0, '435', '80233', '[]', -1);
INSERT INTO `houses` VALUES (373, '', '5', '{\"x\":-1405.0667,\"y\":561.91846,\"z\":124.28614}', '680000', 0, '496', '501432', '[]', -1);
INSERT INTO `houses` VALUES (374, '', '5', '{\"x\":-1405.4446,\"y\":526.86804,\"z\":122.711296}', '680000', 0, '0', '671625', '[]', -1);
INSERT INTO `houses` VALUES (375, '', '5', '{\"x\":346.40756,\"y\":440.707,\"z\":146.61446}', '680000', 0, '434', '604880', '[]', -1);
INSERT INTO `houses` VALUES (376, '', '5', '{\"x\":331.42145,\"y\":465.25217,\"z\":150.1385}', '680000', 0, '433', '681386', '[]', -1);
INSERT INTO `houses` VALUES (377, '', '5', '{\"x\":-1364.2859,\"y\":570.1966,\"z\":133.85277}', '680000', 0, '494', '964869', '[]', -1);
INSERT INTO `houses` VALUES (378, '', '5', '{\"x\":-1346.4839,\"y\":560.6025,\"z\":129.41148}', '680000', 0, '495', '696671', '[]', -1);
INSERT INTO `houses` VALUES (379, '', '6', '{\"x\":315.84683,\"y\":502.06168,\"z\":152.05977}', '950000', 0, '432', '922026', '[]', -1);
INSERT INTO `houses` VALUES (380, '', '5', '{\"x\":318.63788,\"y\":551.91614,\"z\":154.904}', '680000', 0, '430', '863756', '[]', -1);
INSERT INTO `houses` VALUES (381, '', '5', '{\"x\":-1337.2506,\"y\":606.1237,\"z\":133.25967}', '680000', 0, '492', '614522', '[]', -1);
INSERT INTO `houses` VALUES (382, '', '5', '{\"x\":-1291.8268,\"y\":650.42487,\"z\":140.38167}', '680000', 0, '490', '504736', '[]', -1);
INSERT INTO `houses` VALUES (383, '', '6', '{\"x\":228.52219,\"y\":765.76355,\"z\":203.855}', '950000', 0, '429', '540547', '[]', -1);
INSERT INTO `houses` VALUES (384, '', '5', '{\"x\":-1277.6189,\"y\":629.9066,\"z\":142.057}', '680000', 0, '491', '200946', '[]', -1);
INSERT INTO `houses` VALUES (385, '', '5', '{\"x\":-1248.6995,\"y\":642.80756,\"z\":141.5989}', '680000', 0, '489', '525099', '[]', -1);
INSERT INTO `houses` VALUES (386, '', '6', '{\"x\":232.16504,\"y\":672.1103,\"z\":188.85696}', '950000', 0, '428', '98659', '[]', -1);
INSERT INTO `houses` VALUES (387, '', '5', '{\"x\":216.3614,\"y\":620.38916,\"z\":186.63554}', '680000', 0, '426', '148734', '[]', -1);
INSERT INTO `houses` VALUES (388, '', '5', '{\"x\":-1255.1908,\"y\":667.0593,\"z\":141.70218}', '680000', 0, '488', '572212', '[]', -1);
INSERT INTO `houses` VALUES (389, '', '5', '{\"x\":-1218.4614,\"y\":665.21564,\"z\":143.41475}', '680000', 0, '487', '144240', '[]', -1);
INSERT INTO `houses` VALUES (390, '', '5', '{\"x\":-1196.6981,\"y\":693.5487,\"z\":146.30585}', '680000', 0, '486', '902875', '[]', -1);
INSERT INTO `houses` VALUES (391, '', '4', '{\"x\":127.996155,\"y\":566.00226,\"z\":182.83948}', '300000', 0, '425', '295118', '[]', -1);
INSERT INTO `houses` VALUES (392, '', '5', '{\"x\":-1165.8541,\"y\":726.92664,\"z\":154.48676}', '680000', 0, '485', '995566', '[]', -1);
INSERT INTO `houses` VALUES (393, '', '5', '{\"x\":85.313034,\"y\":561.71765,\"z\":181.65286}', '680000', 0, '424', '409397', '[]', -1);
INSERT INTO `houses` VALUES (394, '', '5', '{\"x\":-1117.8062,\"y\":761.6993,\"z\":163.16867}', '680000', 0, '483', '661178', '[]', -1);
INSERT INTO `houses` VALUES (395, '', '5', '{\"x\":-1130.8876,\"y\":784.44135,\"z\":162.76773}', '680000', 0, '484', '857367', '[]', -1);
INSERT INTO `houses` VALUES (396, '', '5', '{\"x\":45.728165,\"y\":555.6951,\"z\":179.1533}', '680000', 0, '423', '483180', '[]', -1);
INSERT INTO `houses` VALUES (397, '', '5', '{\"x\":-1100.783,\"y\":797.8896,\"z\":166.13622}', '680000', 0, '482', '749066', '[]', -1);
INSERT INTO `houses` VALUES (398, '', '6', '{\"x\":224.01083,\"y\":513.4255,\"z\":139.80305}', '950000', 0, '436', '936546', '[]', -1);
INSERT INTO `houses` VALUES (399, '', '6', '{\"x\":-1067.5906,\"y\":795.73376,\"z\":165.8616}', '950000', 0, '480', '647090', '[]', -1);
INSERT INTO `houses` VALUES (400, '', '5', '{\"x\":-1056.329,\"y\":761.591,\"z\":166.19601}', '680000', 0, '481', '167876', '[]', -1);
INSERT INTO `houses` VALUES (401, '', '5', '{\"x\":-999.764,\"y\":816.7882,\"z\":171.92955}', '680000', 0, '477', '79964', '[]', -1);
INSERT INTO `houses` VALUES (402, '', '5', '{\"x\":167.46576,\"y\":473.78683,\"z\":141.39328}', '680000', 1, '437', '288075', '[]', -1);
INSERT INTO `houses` VALUES (403, '', '5', '{\"x\":-998.5163,\"y\":768.4995,\"z\":170.4622}', '680000', 0, '479', '338441', '[]', -1);
INSERT INTO `houses` VALUES (404, '', '5', '{\"x\":119.76637,\"y\":494.84262,\"z\":146.22292}', '680000', 0, '438', '175195', '[]', -1);
INSERT INTO `houses` VALUES (405, '', '5', '{\"x\":106.76859,\"y\":466.70874,\"z\":146.43658}', '680000', 0, '439', '130056', '[]', -1);
INSERT INTO `houses` VALUES (406, '', '5', '{\"x\":-972.0222,\"y\":752.4696,\"z\":175.2609}', '680000', 0, '478', '116463', '[]', -1);
INSERT INTO `houses` VALUES (407, '', '5', '{\"x\":80.05565,\"y\":486.28745,\"z\":147.08168}', '680000', 0, '440', '634524', '[]', -1);
INSERT INTO `houses` VALUES (408, '', '5', '{\"x\":-962.87537,\"y\":814.26337,\"z\":176.63972}', '680000', 0, '476', '240745', '[]', -1);
INSERT INTO `houses` VALUES (409, '', '6', '{\"x\":57.31598,\"y\":449.8481,\"z\":145.9114}', '950000', 0, '442', '683940', '[]', -1);
INSERT INTO `houses` VALUES (410, '', '5', '{\"x\":43.01547,\"y\":468.80426,\"z\":146.9759}', '680000', 0, '443', '846370', '[]', -1);
INSERT INTO `houses` VALUES (411, '', '5', '{\"x\":-7.989691,\"y\":467.8914,\"z\":144.72484}', '680000', 0, '444', '150490', '[]', -1);
INSERT INTO `houses` VALUES (412, '', '5', '{\"x\":-921.3041,\"y\":813.99927,\"z\":183.2165}', '680000', 0, '475', '237975', '[]', -1);
INSERT INTO `houses` VALUES (413, '', '5', '{\"x\":-912.1289,\"y\":777.1782,\"z\":185.88976}', '680000', 0, '474', '435444', '[]', -1);
INSERT INTO `houses` VALUES (414, '', '5', '{\"x\":-867.2085,\"y\":784.7591,\"z\":190.81421}', '680000', 0, '473', '516828', '[]', -1);
INSERT INTO `houses` VALUES (415, '', '6', '{\"x\":-823.9686,\"y\":805.8879,\"z\":201.66373}', '950000', 0, '472', '472500', '[]', -1);
INSERT INTO `houses` VALUES (416, '', '6', '{\"x\":-747.335,\"y\":808.3581,\"z\":213.91054}', '950000', 1, '471', '969793', '[]', -1);
INSERT INTO `houses` VALUES (417, '', '6', '{\"x\":-658.34296,\"y\":886.2582,\"z\":228.18355}', '950000', 1, '470', '769796', '[]', -1);
INSERT INTO `houses` VALUES (418, '', '5', '{\"x\":-596.9457,\"y\":851.4015,\"z\":210.35825}', '680000', 1, '469', '421244', '[]', -1);
INSERT INTO `houses` VALUES (419, '', '5', '{\"x\":-536.9134,\"y\":818.2344,\"z\":196.3904}', '680000', 0, '468', '629637', '[]', -1);
INSERT INTO `houses` VALUES (420, '', '5', '{\"x\":-494.0884,\"y\":795.90155,\"z\":183.2205}', '680000', 0, '467', '144645', '[]', -1);
INSERT INTO `houses` VALUES (421, '', '5', '{\"x\":-495.53036,\"y\":738.5051,\"z\":161.911}', '680000', 0, '466', '494702', '[]', -1);
INSERT INTO `houses` VALUES (422, '', '5', '{\"x\":-498.54782,\"y\":683.315,\"z\":150.7416}', '680000', 0, '449', '339945', '[]', -1);
INSERT INTO `houses` VALUES (423, '', '5', '{\"x\":-544.76514,\"y\":694.4628,\"z\":144.95444}', '680000', 0, '464', '470357', '[]', -1);
INSERT INTO `houses` VALUES (424, '', '5', '{\"x\":-606.09155,\"y\":672.4675,\"z\":150.47694}', '680000', 0, '509', '603690', '[]', -1);
INSERT INTO `houses` VALUES (425, '', '5', '{\"x\":-661.7964,\"y\":678.901,\"z\":152.7906}', '680000', 0, '510', '259682', '[]', -1);
INSERT INTO `houses` VALUES (426, '', '5', '{\"x\":-699.5523,\"y\":705.8612,\"z\":157.0933}', '680000', 0, '508', '536465', '[]', -1);
INSERT INTO `houses` VALUES (427, '', '6', '{\"x\":-700.7833,\"y\":646.92035,\"z\":154.25516}', '950000', 0, '511', '670835', '[]', -1);
INSERT INTO `houses` VALUES (428, '', '5', '{\"x\":-668.8076,\"y\":637.938,\"z\":148.4091}', '680000', 0, '512', '840252', '[]', -1);
INSERT INTO `houses` VALUES (429, '', '5', '{\"x\":-685.62714,\"y\":595.9283,\"z\":142.83673}', '680000', 0, '513', '814256', '[]', -1);
INSERT INTO `houses` VALUES (430, '', '5', '{\"x\":-765.6667,\"y\":650.50024,\"z\":144.57906}', '680000', 0, '517', '121701', '[]', -1);
INSERT INTO `houses` VALUES (431, '', '5', '{\"x\":-819.4365,\"y\":696.581,\"z\":146.98987}', '680000', 0, '518', '932318', '[]', -1);
INSERT INTO `houses` VALUES (432, '', '5', '{\"x\":-1032.7463,\"y\":686.13074,\"z\":160.18277}', '680000', 0, '525', '28323', '[]', -1);
INSERT INTO `houses` VALUES (433, '', '5', '{\"x\":-1064.8279,\"y\":726.907,\"z\":164.35454}', '680000', 0, '0', '49581', '[]', -1);
INSERT INTO `houses` VALUES (434, '', '5', '{\"x\":-1413.4268,\"y\":462.1297,\"z\":108.08856}', '680000', 0, '527', '754150', '[]', -1);
INSERT INTO `houses` VALUES (435, '', '5', '{\"x\":-1258.8275,\"y\":446.91925,\"z\":93.615685}', '680000', 0, '530', '783793', '[]', -1);
INSERT INTO `houses` VALUES (436, '', '5', '{\"x\":-1371.523,\"y\":443.9831,\"z\":104.73713}', '680000', 0, '528', '326448', '[]', -1);
INSERT INTO `houses` VALUES (437, '', '5', '{\"x\":-1308.0754,\"y\":448.98724,\"z\":99.849625}', '680000', 0, '529', '166296', '[]', -1);
INSERT INTO `houses` VALUES (438, '', '5', '{\"x\":-1277.8875,\"y\":496.88818,\"z\":96.77037}', '680000', 1, '531', '365352', '[]', -1);
INSERT INTO `houses` VALUES (439, '', '5', '{\"x\":-1041.1444,\"y\":506.77505,\"z\":83.26086}', '680000', 0, '539', '70891', '[]', -1);
INSERT INTO `houses` VALUES (440, '', '5', '{\"x\":-1215.7657,\"y\":457.88565,\"z\":90.94349}', '680000', 0, '532', '408636', '[]', -1);
INSERT INTO `houses` VALUES (441, '', '5', '{\"x\":-1158.9276,\"y\":481.84064,\"z\":84.97381}', '680000', 0, '534', '464133', '[]', -1);
INSERT INTO `houses` VALUES (442, '', '5', '{\"x\":-1174.4851,\"y\":440.04755,\"z\":85.729805}', '680000', 0, '533', '907988', '[]', -1);
INSERT INTO `houses` VALUES (443, '', '5', '{\"x\":-1122.5725,\"y\":486.26755,\"z\":81.23566}', '680000', 0, '535', '888270', '[]', -1);
INSERT INTO `houses` VALUES (444, '', '5', '{\"x\":-1094.9061,\"y\":427.30215,\"z\":74.759735}', '680000', 0, '536', '297869', '[]', -1);
INSERT INTO `houses` VALUES (445, '', '5', '{\"x\":-1062.6489,\"y\":475.7873,\"z\":80.200516}', '680000', 0, '538', '752385', '[]', -1);
INSERT INTO `houses` VALUES (446, '', '5', '{\"x\":-967.0514,\"y\":510.5783,\"z\":80.94611}', '680000', 0, '543', '57143', '[]', -1);
INSERT INTO `houses` VALUES (447, '', '5', '{\"x\":-1009.4161,\"y\":479.33646,\"z\":78.294525}', '680000', 0, '540', '560123', '[]', -1);
INSERT INTO `houses` VALUES (448, '', '5', '{\"x\":-987.0399,\"y\":487.18338,\"z\":81.336525}', '680000', 0, '542', '892567', '[]', -1);
INSERT INTO `houses` VALUES (449, '', '5', '{\"x\":-1193.0609,\"y\":564.04095,\"z\":99.21944}', '680000', 0, '547', '188679', '[]', -1);
INSERT INTO `houses` VALUES (450, '', '5', '{\"x\":-1006.94775,\"y\":513.5894,\"z\":78.65024}', '680000', 0, '541', '887573', '[]', -1);
INSERT INTO `houses` VALUES (451, '', '5', '{\"x\":-1052.1615,\"y\":432.5526,\"z\":76.12784}', '680000', 0, '537', '713382', '[]', -1);
INSERT INTO `houses` VALUES (452, '', '6', '{\"x\":-949.99896,\"y\":465.07162,\"z\":79.68011}', '950000', 0, '545', '327823', '[]', -1);
INSERT INTO `houses` VALUES (453, '', '5', '{\"x\":-968.708,\"y\":436.97266,\"z\":79.64518}', '680000', 0, '546', '306909', '[]', -1);
INSERT INTO `houses` VALUES (454, '', '5', '{\"x\":-866.8054,\"y\":457.63278,\"z\":87.16105}', '680000', 0, '564', '502446', '[]', -1);
INSERT INTO `houses` VALUES (455, '', '5', '{\"x\":-884.4837,\"y\":517.70044,\"z\":91.32284}', '680000', 0, '562', '673172', '[]', -1);
INSERT INTO `houses` VALUES (456, '', '5', '{\"x\":-842.7625,\"y\":466.8764,\"z\":86.47579}', '680000', 0, '563', '740017', '[]', -1);
INSERT INTO `houses` VALUES (457, '', '5', '{\"x\":-848.4961,\"y\":508.59247,\"z\":89.69699}', '680000', 1, '561', '817716', '[]', -1);
INSERT INTO `houses` VALUES (458, '', '5', '{\"x\":-873.4159,\"y\":562.9013,\"z\":95.499435}', '680000', 0, '560', '734749', '[]', -1);
INSERT INTO `houses` VALUES (459, '', '5', '{\"x\":-904.5793,\"y\":588.1194,\"z\":100.07077}', '680000', 0, '558', '915512', '[]', -1);
INSERT INTO `houses` VALUES (460, '', '5', '{\"x\":-958.1424,\"y\":607.0159,\"z\":105.18598}', '680000', 0, '555', '593590', '[]', -1);
INSERT INTO `houses` VALUES (461, '', '5', '{\"x\":-907.5026,\"y\":544.9085,\"z\":99.08775}', '680000', 0, '559', '445627', '[]', -1);
INSERT INTO `houses` VALUES (462, '', '5', '{\"x\":-925.13794,\"y\":561.4822,\"z\":99.03812}', '680000', 0, '557', '794271', '[]', -1);
INSERT INTO `houses` VALUES (463, '', '5', '{\"x\":-947.9108,\"y\":567.7681,\"z\":100.385925}', '680000', 0, '556', '426487', '[]', -1);
INSERT INTO `houses` VALUES (464, '', '5', '{\"x\":-974.43353,\"y\":581.8272,\"z\":102.02878}', '680000', 0, '554', '562240', '[]', -1);
INSERT INTO `houses` VALUES (465, '', '5', '{\"x\":-1022.5179,\"y\":586.9396,\"z\":102.30835}', '680000', 0, '553', '914050', '[]', -1);
INSERT INTO `houses` VALUES (466, '', '5', '{\"x\":-1090.0221,\"y\":548.5026,\"z\":102.513306}', '680000', 1, '551', '122167', '[]', -1);
INSERT INTO `houses` VALUES (467, '', '5', '{\"x\":-1107.8263,\"y\":594.46436,\"z\":103.33458}', '680000', 0, '552', '188394', '[]', -1);
INSERT INTO `houses` VALUES (468, '', '5', '{\"x\":-853.1139,\"y\":694.676,\"z\":147.9218}', '680000', 0, '519', '681293', '[]', -1);
INSERT INTO `houses` VALUES (469, '', '5', '{\"x\":-884.54266,\"y\":699.51654,\"z\":150.1513}', '680000', 0, '520', '733033', '[]', -1);
INSERT INTO `houses` VALUES (470, '', '5', '{\"x\":-908.56104,\"y\":693.6847,\"z\":150.316}', '680000', 0, '521', '146052', '[]', -1);
INSERT INTO `houses` VALUES (471, '', '5', '{\"x\":-931.43994,\"y\":690.8923,\"z\":152.34668}', '680000', 0, '522', '803498', '[]', -1);
INSERT INTO `houses` VALUES (472, '', '4', '{\"x\":-1019.4217,\"y\":719.40106,\"z\":162.87617}', '135000', 0, '524', '404444', '[]', -1);
INSERT INTO `houses` VALUES (473, '', '5', '{\"x\":-595.9587,\"y\":780.4487,\"z\":188.1882}', '680000', 0, '504', '350354', '[]', -1);
INSERT INTO `houses` VALUES (474, '', '5', '{\"x\":-655.18066,\"y\":802.9306,\"z\":197.87036}', '680000', 0, '502', '221001', '[]', -1);
INSERT INTO `houses` VALUES (475, '', '5', '{\"x\":-664.52856,\"y\":742.1652,\"z\":173.16397}', '680000', 0, '507', '680510', '[]', -1);
INSERT INTO `houses` VALUES (476, '', '5', '{\"x\":-586.99414,\"y\":806.64545,\"z\":190.12747}', '680000', 0, '503', '586713', '[]', -1);
INSERT INTO `houses` VALUES (477, '', '4', '{\"x\":-565.7297,\"y\":761.13165,\"z\":184.30504}', '135000', 0, '505', '451674', '[]', -1);
INSERT INTO `houses` VALUES (478, '', '5', '{\"x\":-579.66003,\"y\":732.66656,\"z\":183.12761}', '680000', 0, '506', '172488', '[]', -1);
INSERT INTO `houses` VALUES (479, '', '6', '{\"x\":-515.20636,\"y\":629.11523,\"z\":132.49081}', '950000', 0, '463', '851303', '[]', -1);
INSERT INTO `houses` VALUES (480, '', '6', '{\"x\":-520.7059,\"y\":594.2283,\"z\":119.71651}', '950000', 0, '447', '202539', '[]', -1);
INSERT INTO `houses` VALUES (481, '', '5', '{\"x\":-554.45374,\"y\":541.2011,\"z\":109.58708}', '680000', 0, '0', '976341', '[]', -1);
INSERT INTO `houses` VALUES (482, '', '6', '{\"x\":-595.451,\"y\":530.355,\"z\":106.63464}', '950000', 0, '573', '778266', '[]', -1);
INSERT INTO `houses` VALUES (483, '', '5', '{\"x\":-640.7032,\"y\":520.586,\"z\":108.76282}', '680000', 0, '572', '651573', '[]', -1);
INSERT INTO `houses` VALUES (484, '', '5', '{\"x\":-678.824,\"y\":512.10706,\"z\":112.40597}', '680000', 0, '570', '926682', '[]', -1);
INSERT INTO `houses` VALUES (485, '', '5', '{\"x\":-741.51166,\"y\":484.74908,\"z\":108.58711}', '680000', 0, '569', '408318', '[]', -1);
INSERT INTO `houses` VALUES (486, '', '5', '{\"x\":-784.81934,\"y\":459.63394,\"z\":99.26595}', '680000', 0, '567', '604496', '[]', -1);
INSERT INTO `houses` VALUES (487, '', '5', '{\"x\":-824.7701,\"y\":421.99423,\"z\":91.00422}', '680000', 0, '565', '721413', '[]', -1);
INSERT INTO `houses` VALUES (488, '', '5', '{\"x\":-762.359,\"y\":430.7837,\"z\":99.076485}', '680000', 1, '566', '547134', '[]', -1);
INSERT INTO `houses` VALUES (489, '', '5', '{\"x\":-717.8248,\"y\":448.632,\"z\":105.7891}', '680000', 0, '568', '80979', '[]', -1);
INSERT INTO `houses` VALUES (490, '', '5', '{\"x\":-666.9529,\"y\":471.52792,\"z\":113.01651}', '680000', 0, '571', '43777', '[]', -1);
INSERT INTO `houses` VALUES (491, '', '5', '{\"x\":-622.74286,\"y\":488.88422,\"z\":107.75714}', '680000', 0, '573', '508730', '[]', -1);
INSERT INTO `houses` VALUES (492, '', '6', '{\"x\":-580.2862,\"y\":491.49707,\"z\":107.78287}', '950000', 0, '574', '431545', '[]', -1);
INSERT INTO `houses` VALUES (493, '', '5', '{\"x\":-526.4975,\"y\":517.31616,\"z\":111.81892}', '680000', 0, '411', '449839', '[]', -1);
INSERT INTO `houses` VALUES (494, '', '5', '{\"x\":-500.6564,\"y\":552.1302,\"z\":119.48459}', '680000', 0, '412', '477299', '[]', -1);
INSERT INTO `houses` VALUES (495, '', '5', '{\"x\":-476.59937,\"y\":647.7096,\"z\":143.26662}', '680000', 0, '450', '963008', '[]', -1);
INSERT INTO `houses` VALUES (496, '', '5', '{\"x\":-446.1294,\"y\":686.1808,\"z\":151.99614}', '680000', 0, '451', '669861', '[]', -1);
INSERT INTO `houses` VALUES (497, '', '5', '{\"x\":-400.0996,\"y\":664.9456,\"z\":162.71004}', '680000', 0, '453', '481501', '[]', -1);
INSERT INTO `houses` VALUES (498, '', '5', '{\"x\":-353.19022,\"y\":668.2028,\"z\":167.95386}', '680000', 0, '454', '326031', '[]', -1);
INSERT INTO `houses` VALUES (499, '', '6', '{\"x\":-339.77927,\"y\":625.5653,\"z\":170.23708}', '950000', 0, '455', '383818', '[]', -1);
INSERT INTO `houses` VALUES (500, '', '5', '{\"x\":-307.7282,\"y\":643.4849,\"z\":175.01233}', '680000', 0, '456', '630218', '[]', -1);
INSERT INTO `houses` VALUES (501, '', '5', '{\"x\":-293.486,\"y\":600.98804,\"z\":180.45552}', '680000', 0, '457', '868748', '[]', -1);
INSERT INTO `houses` VALUES (502, '', '5', '{\"x\":-246.05464,\"y\":622.0161,\"z\":186.69038}', '680000', 0, '458', '878829', '[]', -1);
INSERT INTO `houses` VALUES (503, '', '5', '{\"x\":-232.55621,\"y\":588.20447,\"z\":189.4163}', '680000', 0, '459', '159535', '[]', -1);
INSERT INTO `houses` VALUES (504, '', '5', '{\"x\":-185.29655,\"y\":591.1711,\"z\":196.70303}', '680000', 0, '461', '42627', '[]', -1);
INSERT INTO `houses` VALUES (505, '', '6', '{\"x\":-189.41528,\"y\":618.31995,\"z\":198.5412}', '950000', 0, '460', '84075', '[]', -1);
INSERT INTO `houses` VALUES (506, '', '6', '{\"x\":-126.36009,\"y\":588.275,\"z\":203.58662}', '950000', 0, '462', '308938', '[]', -1);
INSERT INTO `houses` VALUES (507, '', '5', '{\"x\":-533.08136,\"y\":709.5449,\"z\":152.03221}', '680000', 0, '465', '977467', '[]', -1);
INSERT INTO `houses` VALUES (508, '', '5', '{\"x\":-66.89165,\"y\":490.06693,\"z\":143.76482}', '680000', 0, '445', '85909', '[]', -1);
INSERT INTO `houses` VALUES (509, '', '5', '{\"x\":-109.926094,\"y\":501.89963,\"z\":142.33472}', '680000', 0, '446', '821935', '[]', -1);
INSERT INTO `houses` VALUES (510, '', '5', '{\"x\":-174.30469,\"y\":502.66296,\"z\":136.2998}', '680000', 0, '421', '86459', '[]', -1);
INSERT INTO `houses` VALUES (511, '', '5', '{\"x\":-230.2369,\"y\":487.92697,\"z\":127.64802}', '680000', 0, '420', '288343', '[]', -1);
INSERT INTO `houses` VALUES (512, '', '5', '{\"x\":-311.8611,\"y\":475.02115,\"z\":110.70425}', '680000', 0, '417', '645228', '[]', -1);
INSERT INTO `houses` VALUES (513, '', '5', '{\"x\":-348.789,\"y\":515.00287,\"z\":119.52777}', '680000', 0, '416', '883444', '[]', -1);
INSERT INTO `houses` VALUES (514, '', '5', '{\"x\":-355.89542,\"y\":469.98926,\"z\":111.526596}', '680000', 0, '418', '712973', '[]', -1);
INSERT INTO `houses` VALUES (515, '', '5', '{\"x\":-305.24026,\"y\":431.0382,\"z\":109.35356}', '680000', 0, '419', '617247', '[]', -1);
INSERT INTO `houses` VALUES (516, '', '5', '{\"x\":-340.62982,\"y\":424.012,\"z\":109.92886}', '680000', 0, '397', '667360', '[]', -1);
INSERT INTO `houses` VALUES (517, '', '6', '{\"x\":-401.18158,\"y\":427.6621,\"z\":111.278206}', '950000', 0, '396', '142699', '[]', -1);
INSERT INTO `houses` VALUES (518, '', '5', '{\"x\":-450.9438,\"y\":395.68512,\"z\":103.657585}', '680000', 0, '394', '499804', '[]', -1);
INSERT INTO `houses` VALUES (519, '', '5', '{\"x\":-500.38812,\"y\":398.32642,\"z\":97.16857}', '680000', 0, '392', '153922', '[]', -1);
INSERT INTO `houses` VALUES (520, '', '5', '{\"x\":-516.46655,\"y\":433.3117,\"z\":96.688286}', '680000', 0, '390', '309554', '[]', -1);
INSERT INTO `houses` VALUES (521, '', '5', '{\"x\":-536.8082,\"y\":477.20178,\"z\":102.07365}', '680000', 0, '391', '400753', '[]', -1);
INSERT INTO `houses` VALUES (522, '', '5', '{\"x\":-560.8958,\"y\":402.99646,\"z\":100.68787}', '680000', 0, '387', '641259', '[]', -1);
INSERT INTO `houses` VALUES (523, '', '5', '{\"x\":-595.6735,\"y\":393.0638,\"z\":100.76246}', '680000', 0, '388', '600314', '[]', -1);
INSERT INTO `houses` VALUES (524, '', '5', '{\"x\":-615.1386,\"y\":398.2653,\"z\":100.506546}', '680000', 0, '389', '689257', '[]', -1);
INSERT INTO `houses` VALUES (525, '', '5', '{\"x\":-458.9567,\"y\":537.06067,\"z\":120.340195}', '680000', 0, '413', '637321', '[]', -1);
INSERT INTO `houses` VALUES (526, '', '6', '{\"x\":-425.98935,\"y\":535.1217,\"z\":121.305954}', '950000', 0, '414', '371953', '[]', -1);
INSERT INTO `houses` VALUES (527, '', '5', '{\"x\":-386.7754,\"y\":504.14993,\"z\":119.29269}', '680000', 0, '415', '954604', '[]', -1);
INSERT INTO `houses` VALUES (528, '', '5', '{\"x\":37.695103,\"y\":365.6088,\"z\":114.921}', '680000', 0, '401', '873053', '[]', -1);
INSERT INTO `houses` VALUES (529, '', '5', '{\"x\":-6.407986,\"y\":409.38214,\"z\":119.167984}', '680000', 0, '400', '257992', '[]', -1);
INSERT INTO `houses` VALUES (530, '', '5', '{\"x\":-72.91693,\"y\":428.515,\"z\":111.91823}', '680000', 0, '399', '10649', '[]', -1);
INSERT INTO `houses` VALUES (531, '', '5', '{\"x\":-166.18448,\"y\":424.05096,\"z\":110.685844}', '680000', 0, '402', '105213', '[]', -1);
INSERT INTO `houses` VALUES (532, '', '5', '{\"x\":-214.0007,\"y\":399.55838,\"z\":110.1832}', '680000', 0, '403', '125643', '[]', -1);
INSERT INTO `houses` VALUES (533, '', '5', '{\"x\":-239.16475,\"y\":381.92706,\"z\":111.503136}', '680000', 0, '404', '788669', '[]', -1);
INSERT INTO `houses` VALUES (534, '', '5', '{\"x\":-297.94138,\"y\":380.11572,\"z\":110.976814}', '680000', 0, '405', '221085', '[]', -1);
INSERT INTO `houses` VALUES (535, '', '5', '{\"x\":-327.97714,\"y\":369.619,\"z\":108.88605}', '680000', 0, '406', '333790', '[]', -1);
INSERT INTO `houses` VALUES (536, '', '5', '{\"x\":-371.92267,\"y\":343.51663,\"z\":108.822525}', '680000', 0, '407', '97513', '[]', -1);
INSERT INTO `houses` VALUES (537, '', '5', '{\"x\":-409.5644,\"y\":341.729,\"z\":107.78744}', '680000', 0, '408', '618732', '[]', -1);
INSERT INTO `houses` VALUES (538, '', '5', '{\"x\":-444.26862,\"y\":342.81985,\"z\":104.50075}', '680000', 0, '409', '608946', '[]', -1);
INSERT INTO `houses` VALUES (539, '', '5', '{\"x\":-469.4648,\"y\":329.63055,\"z\":103.6268}', '680000', 0, '410', '842607', '[]', -1);
INSERT INTO `houses` VALUES (540, '', '5', '{\"x\":-477.15323,\"y\":413.12378,\"z\":102.001755}', '680000', 1, '393', '99380', '[]', -1);
INSERT INTO `houses` VALUES (541, '', '5', '{\"x\":-1367.3893,\"y\":610.6732,\"z\":132.75946}', '680000', 0, '493', '627027', '[]', -1);
INSERT INTO `houses` VALUES (542, '', '5', '{\"x\":-704.22003,\"y\":588.38617,\"z\":141.16162}', '680000', 0, '514', '635504', '[]', -1);
INSERT INTO `houses` VALUES (543, '', '5', '{\"x\":-732.9815,\"y\":593.85443,\"z\":141.15854}', '680000', 0, '515', '725198', '[]', -1);
INSERT INTO `houses` VALUES (544, '', '5', '{\"x\":-753.291,\"y\":620.40564,\"z\":141.69801}', '680000', 0, '516', '994518', '[]', -1);
INSERT INTO `houses` VALUES (545, '', '5', '{\"x\":-973.9475,\"y\":684.3711,\"z\":156.91426}', '680000', 0, '526', '755432', '[]', -1);
INSERT INTO `houses` VALUES (546, '', '5', '{\"x\":-1167.1442,\"y\":568.66956,\"z\":100.70734}', '680000', 0, '548', '863501', '[]', -1);
INSERT INTO `houses` VALUES (547, '', '5', '{\"x\":-1146.4308,\"y\":545.89496,\"z\":100.7864}', '680000', 0, '549', '548100', '[]', -1);
INSERT INTO `houses` VALUES (548, '', '5', '{\"x\":-1125.3414,\"y\":548.306,\"z\":101.44553}', '680000', 1, '550', '736865', '[]', -1);
INSERT INTO `houses` VALUES (549, '', '2', '{\"x\":54.507584,\"y\":-1873.1533,\"z\":21.685823}', '40000', 1, '576', '860051', '[]', -1);
INSERT INTO `houses` VALUES (550, '', '2', '{\"x\":38.994743,\"y\":-1911.5231,\"z\":20.8335}', '40000', 1, '577', '295649', '[]', -1);
INSERT INTO `houses` VALUES (551, '', '2', '{\"x\":22.971544,\"y\":-1896.824,\"z\":21.84587}', '40000', 1, '580', '527162', '[]', -1);
INSERT INTO `houses` VALUES (552, '', '2', '{\"x\":46.052135,\"y\":-1864.2408,\"z\":22.159449}', '40000', 0, '578', '981695', '[]', -1);
INSERT INTO `houses` VALUES (553, '', '2', '{\"x\":5.2595563,\"y\":-1884.3308,\"z\":22.577288}', '40000', 0, '581', '172109', '[]', -1);
INSERT INTO `houses` VALUES (554, '', '2', '{\"x\":21.269876,\"y\":-1844.6995,\"z\":23.481733}', '40000', 0, '579', '74265', '[]', -1);
INSERT INTO `houses` VALUES (555, '', '2', '{\"x\":-4.7860303,\"y\":-1872.1412,\"z\":23.031008}', '40000', 1, '583', '229466', '[]', -1);
INSERT INTO `houses` VALUES (556, '', '2', '{\"x\":-20.468283,\"y\":-1858.9578,\"z\":24.28867}', '40000', 0, '585', '227490', '[]', -1);
INSERT INTO `houses` VALUES (557, '', '2', '{\"x\":-34.204323,\"y\":-1847.1104,\"z\":25.073517}', '40000', 0, '586', '278515', '[]', -1);
INSERT INTO `houses` VALUES (558, '', '2', '{\"x\":-41.98147,\"y\":-1792.1174,\"z\":26.708235}', '40000', 1, '582', '470276', '[]', -1);
INSERT INTO `houses` VALUES (559, '', '2', '{\"x\":-50.338356,\"y\":-1783.36,\"z\":27.180824}', '40000', 1, '584', '405305', '[]', -1);
INSERT INTO `houses` VALUES (560, '', '2', '{\"x\":-64.521324,\"y\":-1449.4934,\"z\":31.404966}', '40000', 0, '587', '712121', '[]', -1);
INSERT INTO `houses` VALUES (561, '', '2', '{\"x\":-45.500698,\"y\":-1445.4417,\"z\":31.309595}', '40000', 0, '588', '354333', '[]', -1);
INSERT INTO `houses` VALUES (562, '', '2', '{\"x\":-32.29717,\"y\":-1446.3658,\"z\":30.771402}', '40000', 1, '589', '104415', '[]', -1);
INSERT INTO `houses` VALUES (563, '', '2', '{\"x\":16.681368,\"y\":-1443.8362,\"z\":29.830486}', '40000', 1, '590', '827915', '[]', -1);
INSERT INTO `houses` VALUES (564, '', '2', '{\"x\":-26.580673,\"y\":-1544.2452,\"z\":29.556757}', '40000', 0, '592', '811286', '[]', -1);
INSERT INTO `houses` VALUES (565, '', '2', '{\"x\":-19.652914,\"y\":-1550.8369,\"z\":32.701385}', '40000', 0, '601', '981245', '[]', -1);
INSERT INTO `houses` VALUES (566, '', '2', '{\"x\":-19.664066,\"y\":-1550.7651,\"z\":29.556759}', '40000', 0, '593', '162701', '[]', -1);
INSERT INTO `houses` VALUES (567, '', '2', '{\"x\":-24.86339,\"y\":-1556.9331,\"z\":29.566841}', '40000', 1, '594', '856558', '[]', -1);
INSERT INTO `houses` VALUES (568, '', '2', '{\"x\":-26.5758,\"y\":-1544.3081,\"z\":32.701385}', '40000', 0, '604', '662359', '[]', -1);
INSERT INTO `houses` VALUES (569, '', '2', '{\"x\":-35.735973,\"y\":-1555.3458,\"z\":29.55676}', '40000', 0, '596', '379183', '[]', -1);
INSERT INTO `houses` VALUES (570, '', '2', '{\"x\":-36.061066,\"y\":-1537.012,\"z\":33.501408}', '40000', 0, '606', '519735', '[]', -1);
INSERT INTO `houses` VALUES (571, '', '2', '{\"x\":-44.596527,\"y\":-1547.0435,\"z\":30.327816}', '40000', 0, '598', '48628', '[]', -1);
INSERT INTO `houses` VALUES (572, '', '2', '{\"x\":-44.531796,\"y\":-1547.1132,\"z\":33.501415}', '40000', 0, '608', '533751', '[]', -1);
INSERT INTO `houses` VALUES (573, '', '2', '{\"x\":-36.143864,\"y\":-1536.959,\"z\":30.356253}', '40000', 0, '591', '657196', '[]', -1);
INSERT INTO `houses` VALUES (574, '', '2', '{\"x\":-35.686573,\"y\":-1555.3004,\"z\":32.70144}', '40000', 0, '610', '54543', '[]', -1);
INSERT INTO `houses` VALUES (575, '', '2', '{\"x\":-28.157928,\"y\":-1560.8616,\"z\":32.70144}', '40000', 0, '612', '682525', '[]', -1);
INSERT INTO `houses` VALUES (576, '', '2', '{\"x\":-53.154873,\"y\":-1523.7019,\"z\":32.316147}', '40000', 0, '600', '765247', '[]', -1);
INSERT INTO `houses` VALUES (577, '', '2', '{\"x\":-59.908333,\"y\":-1517.122,\"z\":32.316143}', '40000', 0, '599', '916059', '[]', -1);
INSERT INTO `houses` VALUES (578, '', '2', '{\"x\":-65.04577,\"y\":-1512.9163,\"z\":32.316143}', '40000', 1, '597', '605795', '[]', -1);
INSERT INTO `houses` VALUES (579, '', '2', '{\"x\":-71.78605,\"y\":-1508.2107,\"z\":32.316143}', '40000', 0, '595', '933824', '[]', -1);
INSERT INTO `houses` VALUES (580, '', '2', '{\"x\":-77.762215,\"y\":-1515.2776,\"z\":33.125294}', '40000', 0, '607', '773819', '[]', -1);
INSERT INTO `houses` VALUES (581, '', '2', '{\"x\":-59.25706,\"y\":-1530.8522,\"z\":33.115288}', '40000', 0, '602', '823852', '[]', -1);
INSERT INTO `houses` VALUES (582, '', '2', '{\"x\":-62.318886,\"y\":-1532.611,\"z\":33.115234}', '40000', 0, '603', '217739', '[]', -1);
INSERT INTO `houses` VALUES (583, '', '2', '{\"x\":-69.30563,\"y\":-1526.8704,\"z\":33.11523}', '40000', 0, '605', '13002', '[]', -1);
INSERT INTO `houses` VALUES (584, '', '2', '{\"x\":-69.291534,\"y\":-1526.8539,\"z\":36.29958}', '40000', 0, '618', '962342', '[]', -1);
INSERT INTO `houses` VALUES (585, '', '2', '{\"x\":-62.20933,\"y\":-1532.7034,\"z\":36.29958}', '40000', 0, '617', '483485', '[]', -1);
INSERT INTO `houses` VALUES (586, '', '2', '{\"x\":-59.173977,\"y\":-1530.9158,\"z\":36.2996}', '40000', 0, '616', '123516', '[]', -1);
INSERT INTO `houses` VALUES (587, '', '2', '{\"x\":-53.265766,\"y\":-1523.7341,\"z\":35.504974}', '40000', 0, '615', '953533', '[]', -1);
INSERT INTO `houses` VALUES (588, '', '2', '{\"x\":-60.093933,\"y\":-1517.0701,\"z\":35.504917}', '40000', 0, '614', '714405', '[]', -1);
INSERT INTO `houses` VALUES (589, '', '2', '{\"x\":-65.073616,\"y\":-1512.7775,\"z\":35.504917}', '40000', 0, '613', '991618', '[]', -1);
INSERT INTO `houses` VALUES (590, '', '2', '{\"x\":-71.74645,\"y\":-1508.0681,\"z\":35.50491}', '40000', 0, '611', '106301', '[]', -1);
INSERT INTO `houses` VALUES (591, '', '2', '{\"x\":-77.70023,\"y\":-1515.0905,\"z\":36.299618}', '40000', 0, '609', '818997', '[]', -1);
INSERT INTO `houses` VALUES (592, '', '2', '{\"x\":-97.76659,\"y\":-1612.285,\"z\":31.192297}', '40000', 0, '627', '148456', '[]', -1);
INSERT INTO `houses` VALUES (593, '', '2', '{\"x\":-109.73996,\"y\":-1628.6893,\"z\":31.787573}', '40000', 0, '619', '203641', '[]', -1);
INSERT INTO `houses` VALUES (594, '', '2', '{\"x\":-105.466606,\"y\":-1632.7499,\"z\":31.786913}', '40000', 0, '620', '130486', '[]', -1);
INSERT INTO `houses` VALUES (595, '', '2', '{\"x\":-97.22861,\"y\":-1639.1959,\"z\":30.982985}', '40000', 0, '621', '745046', '[]', -1);
INSERT INTO `houses` VALUES (596, '', '2', '{\"x\":-89.57164,\"y\":-1630.0858,\"z\":30.38562}', '40000', 0, '622', '522613', '[]', -1);
INSERT INTO `houses` VALUES (597, '', '2', '{\"x\":-83.631294,\"y\":-1622.9899,\"z\":30.356823}', '40000', 0, '623', '807588', '[]', -1);
INSERT INTO `houses` VALUES (598, '', '2', '{\"x\":-80.208954,\"y\":-1607.9242,\"z\":30.36061}', '40000', 0, '624', '913911', '[]', -1);
INSERT INTO `houses` VALUES (599, '', '2', '{\"x\":-87.84027,\"y\":-1601.588,\"z\":31.19193}', '40000', 0, '625', '13273', '[]', -1);
INSERT INTO `houses` VALUES (600, '', '2', '{\"x\":-93.442825,\"y\":-1607.1605,\"z\":31.19193}', '40000', 0, '626', '592732', '[]', -1);
INSERT INTO `houses` VALUES (601, '', '2', '{\"x\":-109.51052,\"y\":-1628.4205,\"z\":35.169033}', '40000', 0, '628', '6943', '[]', -1);
INSERT INTO `houses` VALUES (602, '', '2', '{\"x\":-105.44352,\"y\":-1632.7395,\"z\":35.16907}', '40000', 0, '629', '885739', '[]', -1);
INSERT INTO `houses` VALUES (603, '', '2', '{\"x\":-97.03608,\"y\":-1638.9807,\"z\":34.36672}', '40000', 0, '0', '357682', '[]', -1);
INSERT INTO `houses` VALUES (604, '', '2', '{\"x\":-98.07757,\"y\":-1638.9246,\"z\":34.364155}', '40000', 0, '637', '340317', '[]', -1);
INSERT INTO `houses` VALUES (605, '', '2', '{\"x\":-89.45096,\"y\":-1630.0259,\"z\":33.56921}', '40000', 0, '639', '247021', '[]', -1);
INSERT INTO `houses` VALUES (606, '', '2', '{\"x\":-83.552055,\"y\":-1622.9105,\"z\":33.56919}', '40000', 0, '641', '993410', '[]', -1);
INSERT INTO `houses` VALUES (607, '', '2', '{\"x\":-80.35456,\"y\":-1607.783,\"z\":33.569164}', '40000', 0, '643', '324500', '[]', -1);
INSERT INTO `houses` VALUES (608, '', '2', '{\"x\":-87.80262,\"y\":-1601.46,\"z\":34.36918}', '40000', 0, '646', '117567', '[]', -1);
INSERT INTO `houses` VALUES (609, '', '2', '{\"x\":-93.45783,\"y\":-1607.1619,\"z\":34.36918}', '40000', 0, '648', '391738', '[]', -1);
INSERT INTO `houses` VALUES (610, '', '2', '{\"x\":-97.87138,\"y\":-1612.2793,\"z\":34.369183}', '40000', 0, '650', '464217', '[]', -1);
INSERT INTO `houses` VALUES (611, '', '2', '{\"x\":-123.010994,\"y\":-1591.1661,\"z\":33.087578}', '40000', 0, '652', '311429', '[]', -1);
INSERT INTO `houses` VALUES (612, '', '2', '{\"x\":-118.83944,\"y\":-1586.0868,\"z\":33.09297}', '40000', 0, '661', '672719', '[]', -1);
INSERT INTO `houses` VALUES (613, '', '2', '{\"x\":-114.00114,\"y\":-1579.5698,\"z\":33.057053}', '40000', 0, '659', '536450', '[]', -1);
INSERT INTO `houses` VALUES (614, '', '2', '{\"x\":-120.03088,\"y\":-1574.5863,\"z\":33.0563}', '40000', 1, '658', '631485', '[]', -1);
INSERT INTO `houses` VALUES (615, '', '2', '{\"x\":-134.24168,\"y\":-1580.2543,\"z\":33.088108}', '40000', 0, '657', '888268', '[]', -1);
INSERT INTO `houses` VALUES (616, '', '2', '{\"x\":-140.17705,\"y\":-1587.3103,\"z\":33.123653}', '40000', 0, '656', '136594', '[]', -1);
INSERT INTO `houses` VALUES (617, '', '2', '{\"x\":-147.84352,\"y\":-1596.5183,\"z\":33.711304}', '40000', 0, '655', '91413', '[]', -1);
INSERT INTO `houses` VALUES (618, '', '2', '{\"x\":-140.20703,\"y\":-1599.597,\"z\":33.711304}', '40000', 0, '654', '865572', '[]', -1);
INSERT INTO `houses` VALUES (619, '', '2', '{\"x\":-140.20647,\"y\":-1599.5968,\"z\":37.09262}', '40000', 0, '664', '327801', '[]', -1);
INSERT INTO `houses` VALUES (620, '', '2', '{\"x\":-147.76701,\"y\":-1596.3575,\"z\":37.09262}', '40000', 0, '0', '857730', '[]', -1);
INSERT INTO `houses` VALUES (621, '', '2', '{\"x\":-147.35692,\"y\":-1596.9929,\"z\":37.09262}', '40000', 0, '663', '209166', '[]', -1);
INSERT INTO `houses` VALUES (622, '', '2', '{\"x\":-140.28319,\"y\":-1587.5214,\"z\":36.28799}', '40000', 0, '0', '142153', '[]', -1);
INSERT INTO `houses` VALUES (623, '', '2', '{\"x\":-134.35182,\"y\":-1580.4497,\"z\":36.28781}', '40000', 0, '660', '670740', '[]', -1);
INSERT INTO `houses` VALUES (624, '', '2', '{\"x\":-120.04712,\"y\":-1574.4065,\"z\":36.287758}', '40000', 0, '665', '272883', '[]', -1);
INSERT INTO `houses` VALUES (625, '', '2', '{\"x\":-113.95048,\"y\":-1579.5452,\"z\":36.287758}', '40000', 0, '666', '700737', '[]', -1);
INSERT INTO `houses` VALUES (626, '', '2', '{\"x\":-118.86298,\"y\":-1586.1145,\"z\":36.287758}', '40000', 0, '667', '900171', '[]', -1);
INSERT INTO `houses` VALUES (627, '', '2', '{\"x\":-123.04479,\"y\":-1591.0935,\"z\":36.287758}', '40000', 0, '668', '330111', '[]', -1);
INSERT INTO `houses` VALUES (628, '', '2', '{\"x\":-124.10496,\"y\":-1671.2809,\"z\":31.444326}', '40000', 0, '634', '526710', '[]', -1);
INSERT INTO `houses` VALUES (629, '', '2', '{\"x\":-131.5975,\"y\":-1665.5233,\"z\":31.444376}', '40000', 0, '633', '309495', '[]', -1);
INSERT INTO `houses` VALUES (630, '', '2', '{\"x\":-138.70619,\"y\":-1658.8625,\"z\":32.216488}', '40000', 0, '632', '159913', '[]', -1);
INSERT INTO `houses` VALUES (631, '', '2', '{\"x\":-128.94463,\"y\":-1647.2295,\"z\":32.18854}', '40000', 0, '638', '957658', '[]', -1);
INSERT INTO `houses` VALUES (632, '', '2', '{\"x\":-121.17577,\"y\":-1653.255,\"z\":31.444372}', '40000', 0, '636', '2149', '[]', -1);
INSERT INTO `houses` VALUES (633, '', '2', '{\"x\":-114.41429,\"y\":-1659.7363,\"z\":31.444323}', '40000', 0, '635', '592522', '[]', -1);
INSERT INTO `houses` VALUES (634, '', '2', '{\"x\":-114.138916,\"y\":-1659.5535,\"z\":34.59425}', '40000', 0, '642', '341093', '[]', -1);
INSERT INTO `houses` VALUES (635, '', '2', '{\"x\":-121.146286,\"y\":-1653.322,\"z\":34.59419}', '40000', 0, '644', '766876', '[]', -1);
INSERT INTO `houses` VALUES (636, '', '2', '{\"x\":-128.98921,\"y\":-1647.468,\"z\":35.39423}', '40000', 0, '645', '938111', '[]', -1);
INSERT INTO `houses` VALUES (637, '', '2', '{\"x\":-138.74933,\"y\":-1658.9755,\"z\":35.394157}', '40000', 0, '649', '860056', '[]', -1);
INSERT INTO `houses` VALUES (638, '', '2', '{\"x\":-131.68988,\"y\":-1665.4889,\"z\":34.594254}', '40000', 0, '651', '672684', '[]', -1);
INSERT INTO `houses` VALUES (639, '', '2', '{\"x\":-124.143776,\"y\":-1671.3268,\"z\":34.5942}', '40000', 0, '653', '715321', '[]', -1);
INSERT INTO `houses` VALUES (640, '', '2', '{\"x\":-130.8,\"y\":-1679.3898,\"z\":33.79423}', '40000', 0, '647', '490074', '[]', -1);
INSERT INTO `houses` VALUES (641, '', '2', '{\"x\":-107.416214,\"y\":-1651.5476,\"z\":33.76107}', '40000', 0, '640', '799014', '[]', -1);
INSERT INTO `houses` VALUES (642, '', '2', '{\"x\":500.44565,\"y\":-1813.1892,\"z\":27.771206}', '40000', 0, '670', '835966', '[]', -1);
INSERT INTO `houses` VALUES (643, '', '2', '{\"x\":512.54694,\"y\":-1790.611,\"z\":27.800652}', '40000', 0, '671', '322668', '[]', -1);
INSERT INTO `houses` VALUES (644, '', '2', '{\"x\":514.1463,\"y\":-1780.9916,\"z\":27.793676}', '40000', 0, '672', '527402', '[]', -1);
INSERT INTO `houses` VALUES (645, '', '2', '{\"x\":472.0646,\"y\":-1775.1328,\"z\":27.95087}', '40000', 0, '673', '794871', '[]', -1);
INSERT INTO `houses` VALUES (646, '', '2', '{\"x\":474.46445,\"y\":-1757.6873,\"z\":27.972652}', '40000', 0, '674', '146279', '[]', -1);
INSERT INTO `houses` VALUES (647, '', '2', '{\"x\":479.67358,\"y\":-1735.6665,\"z\":28.031023}', '40000', 0, '675', '612005', '[]', -1);
INSERT INTO `houses` VALUES (648, '', '2', '{\"x\":489.52353,\"y\":-1714.1128,\"z\":28.586884}', '40000', 1, '676', '572155', '[]', -1);
INSERT INTO `houses` VALUES (649, '', '2', '{\"x\":500.57962,\"y\":-1697.1343,\"z\":28.669264}', '40000', 0, '677', '242216', '[]', -1);
INSERT INTO `houses` VALUES (650, '', '2', '{\"x\":443.32425,\"y\":-1707.3574,\"z\":28.588802}', '40000', 0, '678', '608453', '[]', -1);
INSERT INTO `houses` VALUES (651, '', '2', '{\"x\":431.23718,\"y\":-1725.4254,\"z\":28.481434}', '40000', 1, '679', '431200', '[]', -1);
INSERT INTO `houses` VALUES (652, '', '2', '{\"x\":419.1788,\"y\":-1735.586,\"z\":28.487694}', '40000', 1, '680', '942014', '[]', -1);
INSERT INTO `houses` VALUES (653, '', '2', '{\"x\":405.77347,\"y\":-1751.1404,\"z\":28.590328}', '40000', 0, '681', '586110', '[]', -1);
INSERT INTO `houses` VALUES (654, '', '3', '{\"x\":-1754.1006,\"y\":-708.9139,\"z\":9.276973}', '110000', 1, '693', '155542', '[]', -1);
INSERT INTO `houses` VALUES (655, '', '2', '{\"x\":348.52423,\"y\":-1820.8679,\"z\":27.774092}', '40000', 0, '682', '383566', '[]', -1);
INSERT INTO `houses` VALUES (656, '', '2', '{\"x\":338.61844,\"y\":-1829.5798,\"z\":27.216906}', '40000', 0, '683', '864789', '[]', -1);
INSERT INTO `houses` VALUES (657, '', '2', '{\"x\":329.40802,\"y\":-1845.9221,\"z\":26.628094}', '40000', 0, '684', '215000', '[]', -1);
INSERT INTO `houses` VALUES (658, '', '2', '{\"x\":320.32162,\"y\":-1854.0667,\"z\":26.390915}', '40000', 0, '685', '84800', '[]', -1);
INSERT INTO `houses` VALUES (659, '', '2', '{\"x\":288.67334,\"y\":-1792.6144,\"z\":26.968767}', '40000', 1, '686', '639578', '[]', -1);
INSERT INTO `houses` VALUES (660, '', '2', '{\"x\":300.27554,\"y\":-1783.6993,\"z\":27.318659}', '60000', 1, '687', '346849', '[]', -1);
INSERT INTO `houses` VALUES (661, '', '2', '{\"x\":304.40216,\"y\":-1775.5066,\"z\":27.981037}', '40000', 0, '688', '663299', '[]', -1);
INSERT INTO `houses` VALUES (662, '', '2', '{\"x\":320.6257,\"y\":-1759.9213,\"z\":28.51747}', '40000', 1, '689', '797788', '[]', -1);
INSERT INTO `houses` VALUES (663, '', '2', '{\"x\":333.02374,\"y\":-1740.8269,\"z\":28.610525}', '60000', 1, '690', '808070', '[]', -1);
INSERT INTO `houses` VALUES (664, '', '2', '{\"x\":282.01117,\"y\":-1694.9333,\"z\":28.526932}', '40000', 0, '691', '231825', '[]', -1);
INSERT INTO `houses` VALUES (665, '', '2', '{\"x\":269.60538,\"y\":-1712.76,\"z\":28.5488}', '40000', 0, '692', '506558', '[]', -1);
INSERT INTO `houses` VALUES (666, '', '2', '{\"x\":257.58527,\"y\":-1722.8977,\"z\":28.53413}', '40000', 1, '694', '309280', '[]', -1);
INSERT INTO `houses` VALUES (667, '', '2', '{\"x\":250.1072,\"y\":-1730.792,\"z\":28.549473}', '40000', 0, '695', '80197', '[]', -1);
INSERT INTO `houses` VALUES (668, '', '2', '{\"x\":197.59573,\"y\":-1725.801,\"z\":28.543646}', '40000', 0, '696', '195358', '[]', -1);
INSERT INTO `houses` VALUES (669, '', '2', '{\"x\":216.36693,\"y\":-1717.2985,\"z\":28.557793}', '40000', 0, '697', '864608', '[]', -1);
INSERT INTO `houses` VALUES (670, '', '2', '{\"x\":222.57892,\"y\":-1702.4877,\"z\":28.576872}', '40000', 1, '698', '950155', '[]', -1);
INSERT INTO `houses` VALUES (671, '', '2', '{\"x\":240.65765,\"y\":-1687.7922,\"z\":28.57961}', '40000', 0, '699', '276537', '[]', -1);
INSERT INTO `houses` VALUES (672, '', '2', '{\"x\":252.83719,\"y\":-1670.6849,\"z\":28.543165}', '40000', 0, '700', '418727', '[]', -1);
INSERT INTO `houses` VALUES (673, '', '3', '{\"x\":-1770.884,\"y\":-677.5725,\"z\":9.267259}', '110000', 0, '720', '150251', '[]', -1);
INSERT INTO `houses` VALUES (674, '', '3', '{\"x\":-1788.0238,\"y\":-672.0008,\"z\":9.532007}', '110000', 1, '721', '837725', '[]', -1);
INSERT INTO `houses` VALUES (675, '', '3', '{\"x\":-1800.028,\"y\":-667.1721,\"z\":9.481781}', '110000', 0, '722', '58717', '[]', -1);
INSERT INTO `houses` VALUES (676, '', '3', '{\"x\":-1803.8324,\"y\":-661.8749,\"z\":9.606813}', '110000', 0, '723', '373198', '[]', -1);
INSERT INTO `houses` VALUES (677, '', '3', '{\"x\":-1813.9103,\"y\":-656.6996,\"z\":9.769047}', '110000', 0, '724', '819484', '[]', -1);
INSERT INTO `houses` VALUES (678, '', '3', '{\"x\":-1816.8712,\"y\":-636.77,\"z\":9.818936}', '110000', 0, '727', '143339', '[]', -1);
INSERT INTO `houses` VALUES (679, '', '3', '{\"x\":-1836.5178,\"y\":-631.8368,\"z\":9.6311865}', '110000', 0, '732', '478010', '[]', -1);
INSERT INTO `houses` VALUES (680, '', '3', '{\"x\":-1838.9058,\"y\":-629.55914,\"z\":10.127707}', '110000', 0, '733', '554459', '[]', -1);
INSERT INTO `houses` VALUES (681, '', '4', '{\"x\":-1869.7599,\"y\":-590.407,\"z\":10.74065}', '135000', 0, '735', '288166', '[]', -1);
INSERT INTO `houses` VALUES (682, '', '4', '{\"x\":-1883.4708,\"y\":-578.888,\"z\":10.731897}', '135000', 1, '737', '757955', '[]', -1);
INSERT INTO `houses` VALUES (683, '', '4', '{\"x\":-1901.3081,\"y\":-586.16223,\"z\":10.752401}', '135000', 0, '738', '284494', '[]', -1);
INSERT INTO `houses` VALUES (684, '', '4', '{\"x\":-1898.5444,\"y\":-572.4745,\"z\":10.725463}', '135000', 1, '741', '701041', '[]', -1);
INSERT INTO `houses` VALUES (685, '', '4', '{\"x\":-1919.8204,\"y\":-569.8601,\"z\":10.792077}', '135000', 0, '742', '728712', '[]', -1);
INSERT INTO `houses` VALUES (686, '', '4', '{\"x\":-1918.726,\"y\":-542.57104,\"z\":10.705331}', '135000', 0, '743', '15645', '[]', -1);
INSERT INTO `houses` VALUES (687, '', '2', '{\"x\":282.78876,\"y\":-1899.192,\"z\":26.147552}', '40000', 0, '701', '416037', '[]', -1);
INSERT INTO `houses` VALUES (688, '', '2', '{\"x\":270.43274,\"y\":-1917.0096,\"z\":25.060331}', '40000', 0, '702', '436981', '[]', -1);
INSERT INTO `houses` VALUES (689, '', '2', '{\"x\":258.246,\"y\":-1927.0323,\"z\":24.324776}', '40000', 0, '705', '957526', '[]', -1);
INSERT INTO `houses` VALUES (690, '', '2', '{\"x\":250.85056,\"y\":-1934.9801,\"z\":23.579933}', '40000', 0, '706', '902086', '[]', -1);
INSERT INTO `houses` VALUES (691, '', '2', '{\"x\":144.29149,\"y\":-1968.8965,\"z\":17.737623}', '40000', 0, '707', '723112', '[]', -1);
INSERT INTO `houses` VALUES (692, '', '2', '{\"x\":148.87831,\"y\":-1960.5217,\"z\":18.33841}', '60000', 1, '708', '775256', '[]', -1);
INSERT INTO `houses` VALUES (693, '', '2', '{\"x\":165.21893,\"y\":-1944.7496,\"z\":19.115427}', '40000', 0, '709', '33106', '[]', -1);
INSERT INTO `houses` VALUES (694, '', '2', '{\"x\":179.2849,\"y\":-1923.925,\"z\":20.251019}', '40000', 0, '710', '368473', '[]', -1);
INSERT INTO `houses` VALUES (695, '', '4', '{\"x\":-1945.7944,\"y\":-544.7225,\"z\":10.743664}', '135000', 0, '745', '826774', '[]', -1);
INSERT INTO `houses` VALUES (696, '', '4', '{\"x\":-1946.948,\"y\":-544.0176,\"z\":10.743866}', '135000', 0, '744', '1226', '[]', -1);
INSERT INTO `houses` VALUES (697, '', '2', '{\"x\":208.58432,\"y\":-1895.2852,\"z\":23.694138}', '40000', 0, '711', '27897', '[]', -1);
INSERT INTO `houses` VALUES (698, '', '2', '{\"x\":192.45172,\"y\":-1883.3203,\"z\":23.936726}', '40000', 1, '712', '90843', '[]', -1);
INSERT INTO `houses` VALUES (699, '', '4', '{\"x\":-1964.3634,\"y\":-520.7873,\"z\":11.060844}', '135000', 0, '746', '20844', '[]', -1);
INSERT INTO `houses` VALUES (700, '', '2', '{\"x\":171.60435,\"y\":-1871.552,\"z\":23.280228}', '40000', 0, '713', '485592', '[]', -1);
INSERT INTO `houses` VALUES (701, '', '2', '{\"x\":148.88351,\"y\":-1904.5387,\"z\":22.411234}', '40000', 0, '714', '66082', '[]', -1);
INSERT INTO `houses` VALUES (702, '', '2', '{\"x\":150.09863,\"y\":-1864.6908,\"z\":23.471405}', '40000', 0, '715', '416648', '[]', -1);
INSERT INTO `houses` VALUES (703, '', '4', '{\"x\":-1969.4323,\"y\":-516.6045,\"z\":10.713116}', '135000', 0, '749', '707545', '[]', -1);
INSERT INTO `houses` VALUES (704, '', '2', '{\"x\":128.32123,\"y\":-1896.9858,\"z\":22.554195}', '40000', 0, '716', '292060', '[]', -1);
INSERT INTO `houses` VALUES (705, '', '4', '{\"x\":-1977.7839,\"y\":-509.23978,\"z\":10.730008}', '135000', 1, '750', '331916', '[]', -1);
INSERT INTO `houses` VALUES (706, '', '2', '{\"x\":115.43027,\"y\":-1887.9585,\"z\":22.808224}', '40000', 0, '717', '12473', '[]', -1);
INSERT INTO `houses` VALUES (707, '', '2', '{\"x\":130.63153,\"y\":-1853.2479,\"z\":24.114365}', '40000', 0, '718', '791763', '[]', -1);
INSERT INTO `houses` VALUES (708, '', '2', '{\"x\":104.041885,\"y\":-1885.3953,\"z\":23.198776}', '40000', 0, '719', '748384', '[]', -1);
INSERT INTO `houses` VALUES (709, '', '2', '{\"x\":152.80495,\"y\":-1823.7618,\"z\":26.748653}', '40000', 0, '726', '96826', '[]', -1);
INSERT INTO `houses` VALUES (710, '', '2', '{\"x\":385.23523,\"y\":-1995.536,\"z\":23.114977}', '40000', 0, '729', '10368', '[]', -1);
INSERT INTO `houses` VALUES (711, '', '2', '{\"x\":383.56644,\"y\":-1994.9474,\"z\":23.114977}', '40000', 0, '734', '45305', '[]', -1);
INSERT INTO `houses` VALUES (712, '', '2', '{\"x\":374.5884,\"y\":-1991.4457,\"z\":23.114922}', '40000', 0, '736', '71662', '[]', -1);
INSERT INTO `houses` VALUES (713, '', '2', '{\"x\":363.95206,\"y\":-1987.8237,\"z\":23.113703}', '40000', 0, '739', '606788', '[]', -1);
INSERT INTO `houses` VALUES (714, '', '4', '{\"x\":-2603.2346,\"y\":1686.2687,\"z\":141.54755}', '10000000', 1, '740', '85120', '[]', -1);
INSERT INTO `houses` VALUES (715, '', '6', '{\"x\":-1873.1367,\"y\":202.09323,\"z\":83.2552}', '950000', 0, '363', '58683', '[]', -1);
INSERT INTO `houses` VALUES (716, '', '6', '{\"x\":-1467.5907,\"y\":34.970257,\"z\":53.424877}', '5000000', 1, '754', '905343', '[]', -1);
INSERT INTO `houses` VALUES (717, '', '4', '{\"x\":-3215.7952,\"y\":816.05347,\"z\":7.8109055}', '13000000', 0, '756', '513295', '[]', -1);
INSERT INTO `houses` VALUES (718, '', '4', '{\"x\":-1135.5074,\"y\":375.77808,\"z\":70.17979}', '2000000', 0, '760', '107030', '[]', -1);
INSERT INTO `houses` VALUES (719, '', '4', '{\"x\":-86.05045,\"y\":834.51746,\"z\":234.80011}', '2000000', 1, '758', '503112', '[]', -1);
INSERT INTO `houses` VALUES (720, '', '4', '{\"x\":-151.74422,\"y\":910.728,\"z\":234.53563}', '2000000', 1, '762', '490914', '[]', -1);
INSERT INTO `houses` VALUES (721, '', '1', '{\"x\":1973.884,\"y\":3814.9824,\"z\":32.30409}', '25000', 1, '763', '722421', '[]', -1);

-- ----------------------------
-- Table structure for inventory
-- ----------------------------
DROP TABLE IF EXISTS `inventory`;
CREATE TABLE `inventory`  (
  `uuid` int NOT NULL,
  `items` varchar(4096) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`uuid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of inventory
-- ----------------------------
INSERT INTO `inventory` VALUES (7029, '[{\"Data\":\"146_1_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":true},{\"Data\":\"102_4_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"1_0_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true},{\"Data\":null,\"ID\":200,\"Type\":200,\"Count\":12,\"IsActive\":false},{\"Data\":\"100\",\"ID\":-9,\"Type\":-9,\"Count\":1,\"IsActive\":true},{\"Data\":null,\"ID\":204,\"Type\":204,\"Count\":22,\"IsActive\":false},{\"Data\":\"100700203\",\"ID\":141,\"Type\":141,\"Count\":1,\"IsActive\":false},{\"Data\":\"100700195\",\"ID\":117,\"Type\":117,\"Count\":1,\"IsActive\":false}]');
INSERT INTO `inventory` VALUES (8605, '[{\"Data\":\"0\",\"ID\":-9,\"Type\":-9,\"Count\":1,\"IsActive\":true},{\"Data\":\"V248E_0\",\"ID\":19,\"Type\":19,\"Count\":1,\"IsActive\":false}]');
INSERT INTO `inventory` VALUES (23854, '[{\"Data\":\"13_0_True\",\"ID\":-13,\"Type\":-13,\"Count\":1,\"IsActive\":true},{\"Data\":\"4_0_True\",\"ID\":-14,\"Type\":-14,\"Count\":1,\"IsActive\":true},{\"Data\":\"10_0_True\",\"ID\":-3,\"Type\":-3,\"Count\":1,\"IsActive\":true},{\"Data\":\"102_4_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"S143T_0\",\"ID\":19,\"Type\":19,\"Count\":1,\"IsActive\":false},{\"Data\":[{\"Data\":null,\"ID\":34,\"Type\":34,\"Count\":1,\"IsActive\":false}],\"ID\":42,\"Type\":42,\"Count\":1,\"IsActive\":false},{\"Data\":\"\",\"ID\":41,\"Type\":41,\"Count\":1,\"IsActive\":false},{\"Data\":\"A464Y_0\",\"ID\":19,\"Type\":19,\"Count\":1,\"IsActive\":false},{\"Data\":\"P775O_0\",\"ID\":19,\"Type\":19,\"Count\":1,\"IsActive\":false},{\"Data\":\"11_2_True\",\"ID\":-8,\"Type\":-8,\"Count\":1,\"IsActive\":true},{\"Data\":\"32_3_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true}]');
INSERT INTO `inventory` VALUES (37645, '[{\"Data\":\"146_4_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":true},{\"Data\":\"102_1_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"1_1_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true}]');
INSERT INTO `inventory` VALUES (40048, '[{\"Data\":\"146_3_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":true},{\"Data\":\"102_0_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"1_2_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true}]');
INSERT INTO `inventory` VALUES (44375, '[{\"Data\":\"146_1_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":true},{\"Data\":\"102_1_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"1_1_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true}]');
INSERT INTO `inventory` VALUES (94329, '[{\"Data\":\"146_9_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":false},{\"Data\":\"102_1_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":false},{\"Data\":\"1_0_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":false},{\"Data\":\"177_1_true\",\"ID\":-7,\"Type\":-7,\"Count\":1,\"IsActive\":false},{\"Data\":\"0\",\"ID\":-9,\"Type\":-9,\"Count\":1,\"IsActive\":false},{\"Data\":\"1_1_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":false},{\"Data\":\"14_0_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":false},{\"Data\":\"A431V_0\",\"ID\":19,\"Type\":19,\"Count\":1,\"IsActive\":false},{\"Data\":null,\"ID\":1028,\"Type\":1028,\"Count\":2,\"IsActive\":false},{\"Data\":\"62_0_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":true},{\"Data\":\"13_0_True\",\"ID\":-8,\"Type\":-8,\"Count\":1,\"IsActive\":true},{\"Data\":\"13_0_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"1_0_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true},{\"Data\":\"10_0_True\",\"ID\":-8,\"Type\":-8,\"Count\":1,\"IsActive\":false},{\"Data\":\"26_0_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":false},{\"Data\":null,\"ID\":235,\"Type\":235,\"Count\":32,\"IsActive\":false},{\"Data\":null,\"ID\":234,\"Type\":234,\"Count\":6,\"IsActive\":false}]');
INSERT INTO `inventory` VALUES (108026, '[{\"Data\":\"146_2_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":false},{\"Data\":\"102_5_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":false},{\"Data\":\"1_0_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true},{\"Data\":\"\",\"ID\":41,\"Type\":41,\"Count\":1,\"IsActive\":false},{\"Data\":\"13_0_True\",\"ID\":-8,\"Type\":-8,\"Count\":1,\"IsActive\":true},{\"Data\":\"4_0_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true}]');
INSERT INTO `inventory` VALUES (118639, '[{\"Data\":\"102_0_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"1_3_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true},{\"Data\":null,\"ID\":35,\"Type\":35,\"Count\":3,\"IsActive\":false},{\"Data\":\"2_0_True\",\"ID\":-12,\"Type\":-12,\"Count\":1,\"IsActive\":false},{\"Data\":\"2_0_True\",\"ID\":-12,\"Type\":-12,\"Count\":1,\"IsActive\":true},{\"Data\":\"146_6_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":true}]');
INSERT INTO `inventory` VALUES (125749, '[{\"Data\":\"30_3_False\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":true},{\"Data\":\"43_13_False\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":false},{\"Data\":\"3_2_False\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true},{\"Data\":null,\"ID\":37,\"Type\":37,\"Count\":1,\"IsActive\":false},{\"Data\":\"3_0_False\",\"ID\":-8,\"Type\":-8,\"Count\":1,\"IsActive\":true},{\"Data\":\"27_0_False\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":null,\"ID\":5,\"Type\":5,\"Count\":4,\"IsActive\":false},{\"Data\":null,\"ID\":34,\"Type\":34,\"Count\":2,\"IsActive\":false},{\"Data\":null,\"ID\":32,\"Type\":32,\"Count\":2,\"IsActive\":false}]');
INSERT INTO `inventory` VALUES (143916, '[{\"Data\":\"81_0_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true},{\"Data\":\"9_7_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"5_0_True\",\"ID\":-3,\"Type\":-3,\"Count\":1,\"IsActive\":true},{\"Data\":\"9_0_True\",\"ID\":-13,\"Type\":-13,\"Count\":1,\"IsActive\":true},{\"Data\":\"111_3_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":true},{\"Data\":\"5_0_True\",\"ID\":-12,\"Type\":-12,\"Count\":1,\"IsActive\":true},{\"Data\":\"177_1_true\",\"ID\":-7,\"Type\":-7,\"Count\":1,\"IsActive\":true},{\"Data\":\"0\",\"ID\":-9,\"Type\":-9,\"Count\":1,\"IsActive\":true},{\"Data\":[{\"Data\":null,\"ID\":36,\"Type\":36,\"Count\":1,\"IsActive\":false},{\"Data\":null,\"ID\":35,\"Type\":35,\"Count\":2,\"IsActive\":false},{\"Data\":null,\"ID\":34,\"Type\":34,\"Count\":1,\"IsActive\":false}],\"ID\":42,\"Type\":42,\"Count\":1,\"IsActive\":false}]');
INSERT INTO `inventory` VALUES (158989, '[{\"Data\":\"146_8_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":true},{\"Data\":\"102_4_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"1_1_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true}]');
INSERT INTO `inventory` VALUES (161355, '[{\"Data\":\"2_0_True\",\"ID\":-12,\"Type\":-12,\"Count\":1,\"IsActive\":true},{\"Data\":\"3_0_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":true},{\"Data\":\"0_0_True\",\"ID\":-8,\"Type\":-8,\"Count\":1,\"IsActive\":false},{\"Data\":\"0_0_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"1_0_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true},{\"Data\":\"4_0_True\",\"ID\":-3,\"Type\":-3,\"Count\":1,\"IsActive\":true},{\"Data\":\"0_0_True\",\"ID\":-14,\"Type\":-14,\"Count\":1,\"IsActive\":true},{\"Data\":\"1_1_True\",\"ID\":-13,\"Type\":-13,\"Count\":1,\"IsActive\":true},{\"Data\":\"17_0_True\",\"ID\":-7,\"Type\":-7,\"Count\":1,\"IsActive\":true},{\"Data\":\"U457C_0\",\"ID\":19,\"Type\":19,\"Count\":1,\"IsActive\":false},{\"Data\":null,\"ID\":1010,\"Type\":1010,\"Count\":2,\"IsActive\":false}]');
INSERT INTO `inventory` VALUES (191970, '[{\"Data\":\"146_9_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":false},{\"Data\":\"102_5_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"1_0_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true},{\"Data\":\"0\",\"ID\":-9,\"Type\":-9,\"Count\":1,\"IsActive\":true},{\"Data\":null,\"ID\":9,\"Type\":9,\"Count\":5,\"IsActive\":false},{\"Data\":null,\"ID\":8,\"Type\":8,\"Count\":15,\"IsActive\":false},{\"Data\":\"G151O_0\",\"ID\":19,\"Type\":19,\"Count\":1,\"IsActive\":false}]');
INSERT INTO `inventory` VALUES (207288, '[{\"Data\":\"146_6_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":true},{\"Data\":\"102_2_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"1_2_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true},{\"Data\":null,\"ID\":35,\"Type\":35,\"Count\":1,\"IsActive\":false},{\"Data\":\"2_0_True\",\"ID\":-12,\"Type\":-12,\"Count\":1,\"IsActive\":false},{\"Data\":null,\"ID\":1028,\"Type\":1028,\"Count\":1,\"IsActive\":false}]');
INSERT INTO `inventory` VALUES (253404, '[{\"Data\":\"146_2_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":true},{\"Data\":\"102_3_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"1_0_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true},{\"Data\":null,\"ID\":35,\"Type\":35,\"Count\":3,\"IsActive\":false},{\"Data\":null,\"ID\":37,\"Type\":37,\"Count\":3,\"IsActive\":false}]');
INSERT INTO `inventory` VALUES (267969, '[{\"Data\":\"146_4_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":true},{\"Data\":\"102_1_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"1_2_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true},{\"Data\":\"\",\"ID\":41,\"Type\":41,\"Count\":1,\"IsActive\":false},{\"Data\":\"Q826C_0\",\"ID\":19,\"Type\":19,\"Count\":1,\"IsActive\":false},{\"Data\":null,\"ID\":1028,\"Type\":1028,\"Count\":1,\"IsActive\":false},{\"Data\":\"101800069\",\"ID\":109,\"Type\":109,\"Count\":1,\"IsActive\":false},{\"Data\":\"101800070\",\"ID\":101,\"Type\":101,\"Count\":1,\"IsActive\":false},{\"Data\":\"101800071\",\"ID\":119,\"Type\":119,\"Count\":1,\"IsActive\":false},{\"Data\":null,\"ID\":201,\"Type\":201,\"Count\":73,\"IsActive\":false},{\"Data\":null,\"ID\":200,\"Type\":200,\"Count\":21,\"IsActive\":false},{\"Data\":null,\"ID\":202,\"Type\":202,\"Count\":60,\"IsActive\":false},{\"Data\":\"177_1_true\",\"ID\":-7,\"Type\":-7,\"Count\":1,\"IsActive\":true},{\"Data\":\"100\",\"ID\":-9,\"Type\":-9,\"Count\":1,\"IsActive\":true},{\"Data\":\"101800072\",\"ID\":137,\"Type\":137,\"Count\":1,\"IsActive\":false},{\"Data\":null,\"ID\":203,\"Type\":203,\"Count\":8,\"IsActive\":false}]');
INSERT INTO `inventory` VALUES (270190, '[{\"Data\":\"146_7_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":true},{\"Data\":\"102_3_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"1_3_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true},{\"Data\":\"101800076\",\"ID\":109,\"Type\":109,\"Count\":1,\"IsActive\":false},{\"Data\":\"101800077\",\"ID\":101,\"Type\":101,\"Count\":1,\"IsActive\":false},{\"Data\":null,\"ID\":200,\"Type\":200,\"Count\":62,\"IsActive\":false},{\"Data\":\"19\",\"ID\":-9,\"Type\":-9,\"Count\":1,\"IsActive\":true},{\"Data\":null,\"ID\":1028,\"Type\":1028,\"Count\":1,\"IsActive\":false},{\"Data\":\"V275V_0\",\"ID\":19,\"Type\":19,\"Count\":1,\"IsActive\":false}]');
INSERT INTO `inventory` VALUES (284859, '[{\"Data\":\"146_2_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":true},{\"Data\":\"102_2_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"1_1_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true},{\"Data\":[],\"ID\":42,\"Type\":42,\"Count\":1,\"IsActive\":false},{\"Data\":null,\"ID\":1028,\"Type\":1028,\"Count\":1,\"IsActive\":false},{\"Data\":\"100\",\"ID\":-9,\"Type\":-9,\"Count\":1,\"IsActive\":true},{\"Data\":\"100700211\",\"ID\":100,\"Type\":100,\"Count\":1,\"IsActive\":false},{\"Data\":\"100700212\",\"ID\":117,\"Type\":117,\"Count\":1,\"IsActive\":false},{\"Data\":null,\"ID\":204,\"Type\":204,\"Count\":6,\"IsActive\":false},{\"Data\":\"100700213\",\"ID\":109,\"Type\":109,\"Count\":1,\"IsActive\":false},{\"Data\":\"100700214\",\"ID\":141,\"Type\":141,\"Count\":1,\"IsActive\":false}]');
INSERT INTO `inventory` VALUES (319512, '[{\"Data\":\"30_5_False\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":true},{\"Data\":\"43_4_False\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"3_10_False\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true},{\"Data\":\"100700136\",\"ID\":109,\"Type\":109,\"Count\":1,\"IsActive\":false},{\"Data\":\"100\",\"ID\":-9,\"Type\":-9,\"Count\":1,\"IsActive\":true},{\"Data\":null,\"ID\":201,\"Type\":201,\"Count\":30,\"IsActive\":false},{\"Data\":null,\"ID\":204,\"Type\":204,\"Count\":6,\"IsActive\":false},{\"Data\":null,\"ID\":1028,\"Type\":1028,\"Count\":2,\"IsActive\":false},{\"Data\":\"100700137\",\"ID\":100,\"Type\":100,\"Count\":1,\"IsActive\":false},{\"Data\":\"100700138\",\"ID\":181,\"Type\":181,\"Count\":1,\"IsActive\":false},{\"Data\":null,\"ID\":200,\"Type\":200,\"Count\":12,\"IsActive\":false}]');
INSERT INTO `inventory` VALUES (333333, '[{\"Data\":\"26_8_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":false},{\"Data\":\"103_5_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"5_2_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true},{\"Data\":null,\"ID\":1030,\"Type\":1030,\"Count\":5,\"IsActive\":false},{\"Data\":null,\"ID\":1031,\"Type\":1031,\"Count\":5,\"IsActive\":false},{\"Data\":null,\"ID\":9,\"Type\":9,\"Count\":2,\"IsActive\":false},{\"Data\":\"N407L_0\",\"ID\":19,\"Type\":19,\"Count\":1,\"IsActive\":false},{\"Data\":\"A561S_0\",\"ID\":19,\"Type\":19,\"Count\":1,\"IsActive\":false},{\"Data\":\"G438R_0\",\"ID\":19,\"Type\":19,\"Count\":1,\"IsActive\":false},{\"Data\":\"G438R_0\",\"ID\":19,\"Type\":19,\"Count\":1,\"IsActive\":false},{\"Data\":\"F857F_0\",\"ID\":19,\"Type\":19,\"Count\":1,\"IsActive\":false},{\"Data\":\"201200001\",\"ID\":188,\"Type\":188,\"Count\":1,\"IsActive\":false},{\"Data\":null,\"ID\":201,\"Type\":201,\"Count\":3,\"IsActive\":false},{\"Data\":\"201200020\",\"ID\":119,\"Type\":119,\"Count\":1,\"IsActive\":false},{\"Data\":\"J013K_0\",\"ID\":19,\"Type\":19,\"Count\":1,\"IsActive\":false},{\"Data\":\"U764C_0\",\"ID\":19,\"Type\":19,\"Count\":1,\"IsActive\":false},{\"Data\":\"146_9_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":false},{\"Data\":\"102_5_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"1_2_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true}]');
INSERT INTO `inventory` VALUES (395557, '[{\"Data\":\"146_7_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":false},{\"Data\":\"102_1_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"1_1_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true},{\"Data\":\"7_2_True\",\"ID\":-12,\"Type\":-12,\"Count\":1,\"IsActive\":true},{\"Data\":\"4_0_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":true},{\"Data\":[],\"ID\":42,\"Type\":42,\"Count\":1,\"IsActive\":false},{\"Data\":\"\",\"ID\":41,\"Type\":41,\"Count\":1,\"IsActive\":false},{\"Data\":\"L584T_0\",\"ID\":19,\"Type\":19,\"Count\":1,\"IsActive\":false},{\"Data\":\"Y344J_0\",\"ID\":19,\"Type\":19,\"Count\":1,\"IsActive\":false},{\"Data\":\"U318N_0\",\"ID\":19,\"Type\":19,\"Count\":1,\"IsActive\":false},{\"Data\":\"2_0_True\",\"ID\":-12,\"Type\":-12,\"Count\":1,\"IsActive\":false},{\"Data\":\"101800048\",\"ID\":137,\"Type\":137,\"Count\":1,\"IsActive\":false},{\"Data\":null,\"ID\":201,\"Type\":201,\"Count\":30,\"IsActive\":false},{\"Data\":null,\"ID\":200,\"Type\":200,\"Count\":12,\"IsActive\":false},{\"Data\":null,\"ID\":203,\"Type\":203,\"Count\":5,\"IsActive\":false},{\"Data\":\"177_1_true\",\"ID\":-7,\"Type\":-7,\"Count\":1,\"IsActive\":false},{\"Data\":\"101800049\",\"ID\":127,\"Type\":127,\"Count\":1,\"IsActive\":false}]');
INSERT INTO `inventory` VALUES (404355, '[{\"Data\":\"146_3_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":true},{\"Data\":\"102_3_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"1_1_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":false},{\"Data\":\"6_2_True\",\"ID\":-8,\"Type\":-8,\"Count\":1,\"IsActive\":true},{\"Data\":\"101800091\",\"ID\":109,\"Type\":109,\"Count\":1,\"IsActive\":false},{\"Data\":\"101800092\",\"ID\":101,\"Type\":101,\"Count\":1,\"IsActive\":false},{\"Data\":\"101800093\",\"ID\":119,\"Type\":119,\"Count\":1,\"IsActive\":false},{\"Data\":\"101800094\",\"ID\":127,\"Type\":127,\"Count\":1,\"IsActive\":false},{\"Data\":\"101800095\",\"ID\":137,\"Type\":137,\"Count\":1,\"IsActive\":false},{\"Data\":\"58\",\"ID\":-9,\"Type\":-9,\"Count\":1,\"IsActive\":true},{\"Data\":null,\"ID\":200,\"Type\":200,\"Count\":94,\"IsActive\":false},{\"Data\":null,\"ID\":201,\"Type\":201,\"Count\":115,\"IsActive\":false},{\"Data\":null,\"ID\":202,\"Type\":202,\"Count\":120,\"IsActive\":false},{\"Data\":null,\"ID\":133,\"Type\":133,\"Count\":1,\"IsActive\":false},{\"Data\":null,\"ID\":1028,\"Type\":1028,\"Count\":1,\"IsActive\":false},{\"Data\":\"81_0_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true},{\"Data\":\"6_0_True\",\"ID\":-3,\"Type\":-3,\"Count\":1,\"IsActive\":true}]');
INSERT INTO `inventory` VALUES (409064, '[{\"Data\":\"146_0_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":true},{\"Data\":\"102_4_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"1_0_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true},{\"Data\":\"2_0_True\",\"ID\":-8,\"Type\":-8,\"Count\":1,\"IsActive\":false},{\"Data\":\"4_1_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":false}]');
INSERT INTO `inventory` VALUES (450104, '[]');
INSERT INTO `inventory` VALUES (481975, '[{\"Data\":\"K085F_0\",\"ID\":19,\"Type\":19,\"Count\":1,\"IsActive\":false},{\"Data\":\"D565O_0\",\"ID\":19,\"Type\":19,\"Count\":1,\"IsActive\":false},{\"Data\":\"E564V_0\",\"ID\":19,\"Type\":19,\"Count\":1,\"IsActive\":false},{\"Data\":\"T658D_0\",\"ID\":19,\"Type\":19,\"Count\":1,\"IsActive\":false},{\"Data\":\"Y003R_0\",\"ID\":19,\"Type\":19,\"Count\":1,\"IsActive\":false},{\"Data\":\"111_3_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":true},{\"Data\":\"24_0_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"18_0_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true},{\"Data\":\"D236M_0\",\"ID\":19,\"Type\":19,\"Count\":1,\"IsActive\":false},{\"Data\":\"X525S_0\",\"ID\":19,\"Type\":19,\"Count\":1,\"IsActive\":false},{\"Data\":\"G034O_0\",\"ID\":19,\"Type\":19,\"Count\":1,\"IsActive\":false},{\"Data\":\"100700073\",\"ID\":117,\"Type\":117,\"Count\":1,\"IsActive\":false},{\"Data\":null,\"ID\":37,\"Type\":37,\"Count\":3,\"IsActive\":false},{\"Data\":null,\"ID\":1028,\"Type\":1028,\"Count\":1,\"IsActive\":false},{\"Data\":\"100700074\",\"ID\":109,\"Type\":109,\"Count\":1,\"IsActive\":false},{\"Data\":null,\"ID\":8,\"Type\":8,\"Count\":3,\"IsActive\":false},{\"Data\":null,\"ID\":201,\"Type\":201,\"Count\":71,\"IsActive\":false}]');
INSERT INTO `inventory` VALUES (521642, '[]');
INSERT INTO `inventory` VALUES (551558, '[{\"Data\":\"146_9_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":true},{\"Data\":\"102_3_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"1_0_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true},{\"Data\":\"2_0_True\",\"ID\":-12,\"Type\":-12,\"Count\":1,\"IsActive\":false},{\"Data\":\"I417Q_0\",\"ID\":19,\"Type\":19,\"Count\":1,\"IsActive\":false},{\"Data\":null,\"ID\":34,\"Type\":34,\"Count\":4,\"IsActive\":false},{\"Data\":null,\"ID\":1043,\"Type\":1043,\"Count\":1,\"IsActive\":false},{\"Data\":[],\"ID\":42,\"Type\":42,\"Count\":1,\"IsActive\":false},{\"Data\":null,\"ID\":37,\"Type\":37,\"Count\":2,\"IsActive\":false}]');
INSERT INTO `inventory` VALUES (577249, '[{\"Data\":\"30_2_False\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":true},{\"Data\":\"43_0_False\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"3_1_False\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true}]');
INSERT INTO `inventory` VALUES (586263, '[{\"Data\":\"146_2_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":true},{\"Data\":\"102_5_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"1_3_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true}]');
INSERT INTO `inventory` VALUES (602449, '[]');
INSERT INTO `inventory` VALUES (604391, '[]');
INSERT INTO `inventory` VALUES (643213, '[{\"Data\":\"146_1_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":true},{\"Data\":\"1_2_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true},{\"Data\":\"177_1_true\",\"ID\":-7,\"Type\":-7,\"Count\":1,\"IsActive\":true},{\"Data\":\"15_0_True\",\"ID\":-8,\"Type\":-8,\"Count\":1,\"IsActive\":true},{\"Data\":\"5_2_True\",\"ID\":-13,\"Type\":-13,\"Count\":1,\"IsActive\":true},{\"Data\":\"4_0_True\",\"ID\":-14,\"Type\":-14,\"Count\":1,\"IsActive\":true},{\"Data\":\"5_0_True\",\"ID\":-12,\"Type\":-12,\"Count\":1,\"IsActive\":true},{\"Data\":\"4_0_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"101800085\",\"ID\":137,\"Type\":137,\"Count\":1,\"IsActive\":false},{\"Data\":\"101800086\",\"ID\":101,\"Type\":101,\"Count\":1,\"IsActive\":false},{\"Data\":\"101800087\",\"ID\":119,\"Type\":119,\"Count\":1,\"IsActive\":false}]');
INSERT INTO `inventory` VALUES (650974, '[{\"Data\":\"146_4_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":true},{\"Data\":\"102_1_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"1_3_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true}]');
INSERT INTO `inventory` VALUES (668527, '[{\"Data\":\"146_5_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":true},{\"Data\":\"102_4_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"1_2_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true}]');
INSERT INTO `inventory` VALUES (683251, '[{\"Data\":\"146_4_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":true},{\"Data\":\"102_0_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"1_2_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true},{\"Data\":\"100700208\",\"ID\":109,\"Type\":109,\"Count\":1,\"IsActive\":false},{\"Data\":null,\"ID\":234,\"Type\":234,\"Count\":10,\"IsActive\":false},{\"Data\":null,\"ID\":34,\"Type\":34,\"Count\":5,\"IsActive\":false},{\"Data\":null,\"ID\":1043,\"Type\":1043,\"Count\":4,\"IsActive\":false},{\"Data\":\"100700209\",\"ID\":117,\"Type\":117,\"Count\":1,\"IsActive\":false},{\"Data\":[],\"ID\":42,\"Type\":42,\"Count\":1,\"IsActive\":false}]');
INSERT INTO `inventory` VALUES (719676, '[{\"Data\":\"146_4_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":true},{\"Data\":\"102_0_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"1_2_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true},{\"Data\":null,\"ID\":191,\"Type\":191,\"Count\":1,\"IsActive\":false},{\"Data\":null,\"ID\":182,\"Type\":182,\"Count\":1,\"IsActive\":false},{\"Data\":null,\"ID\":194,\"Type\":194,\"Count\":1,\"IsActive\":false},{\"Data\":null,\"ID\":2,\"Type\":2,\"Count\":1,\"IsActive\":false},{\"Data\":null,\"ID\":200,\"Type\":200,\"Count\":96,\"IsActive\":false},{\"Data\":null,\"ID\":1028,\"Type\":1028,\"Count\":1,\"IsActive\":false}]');
INSERT INTO `inventory` VALUES (829846, '[{\"Data\":\"146_5_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":true},{\"Data\":\"102_3_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"1_0_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true}]');
INSERT INTO `inventory` VALUES (837306, '[{\"Data\":\"146_2_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":true},{\"Data\":\"102_4_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"1_2_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true},{\"Data\":[],\"ID\":42,\"Type\":42,\"Count\":1,\"IsActive\":false},{\"Data\":null,\"ID\":1043,\"Type\":1043,\"Count\":1,\"IsActive\":false}]');
INSERT INTO `inventory` VALUES (853521, '[{\"Data\":null,\"ID\":1028,\"Type\":1028,\"Count\":3,\"IsActive\":false},{\"Data\":\"100700196\",\"ID\":141,\"Type\":141,\"Count\":1,\"IsActive\":false},{\"Data\":\"G436Y_0\",\"ID\":19,\"Type\":19,\"Count\":1,\"IsActive\":false},{\"Data\":\"100700204\",\"ID\":181,\"Type\":181,\"Count\":1,\"IsActive\":false},{\"Data\":\"100700205\",\"ID\":100,\"Type\":100,\"Count\":1,\"IsActive\":false},{\"Data\":\"100700206\",\"ID\":117,\"Type\":117,\"Count\":1,\"IsActive\":false},{\"Data\":\"100700207\",\"ID\":109,\"Type\":109,\"Count\":1,\"IsActive\":false},{\"Data\":\"0\",\"ID\":-9,\"Type\":-9,\"Count\":1,\"IsActive\":true},{\"Data\":null,\"ID\":235,\"Type\":235,\"Count\":8,\"IsActive\":false},{\"Data\":null,\"ID\":234,\"Type\":234,\"Count\":8,\"IsActive\":false},{\"Data\":null,\"ID\":1014,\"Type\":1014,\"Count\":4,\"IsActive\":false},{\"Data\":null,\"ID\":204,\"Type\":204,\"Count\":9,\"IsActive\":false},{\"Data\":\"51_0_True\",\"ID\":-1,\"Type\":-1,\"Count\":1,\"IsActive\":true},{\"Data\":null,\"ID\":201,\"Type\":201,\"Count\":17,\"IsActive\":false}]');
INSERT INTO `inventory` VALUES (910388, '[{\"Data\":\"146_8_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":true},{\"Data\":\"102_5_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":false},{\"Data\":\"1_1_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":false},{\"Data\":null,\"ID\":6,\"Type\":6,\"Count\":1,\"IsActive\":false},{\"Data\":\"15_0_True\",\"ID\":-8,\"Type\":-8,\"Count\":1,\"IsActive\":true},{\"Data\":\"42_1_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"4_2_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true},{\"Data\":\"100700199\",\"ID\":109,\"Type\":109,\"Count\":1,\"IsActive\":false},{\"Data\":null,\"ID\":34,\"Type\":34,\"Count\":3,\"IsActive\":false}]');
INSERT INTO `inventory` VALUES (927412, '[{\"Data\":\"4_0_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":true},{\"Data\":\"4_0_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"57_0_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true},{\"Data\":\"4_0_True\",\"ID\":-12,\"Type\":-12,\"Count\":1,\"IsActive\":true},{\"Data\":\"5_0_True\",\"ID\":-13,\"Type\":-13,\"Count\":1,\"IsActive\":true},{\"Data\":\"I365L_0\",\"ID\":19,\"Type\":19,\"Count\":1,\"IsActive\":false},{\"Data\":\"\",\"ID\":41,\"Type\":41,\"Count\":1,\"IsActive\":false},{\"Data\":\"J465N_0\",\"ID\":19,\"Type\":19,\"Count\":1,\"IsActive\":false},{\"Data\":null,\"ID\":1028,\"Type\":1028,\"Count\":1,\"IsActive\":false},{\"Data\":\"100700202\",\"ID\":109,\"Type\":109,\"Count\":1,\"IsActive\":false}]');
INSERT INTO `inventory` VALUES (960128, '[{\"Data\":\"146_5_True\",\"ID\":-11,\"Type\":-11,\"Count\":1,\"IsActive\":true},{\"Data\":\"102_4_True\",\"ID\":-4,\"Type\":-4,\"Count\":1,\"IsActive\":true},{\"Data\":\"1_2_True\",\"ID\":-6,\"Type\":-6,\"Count\":1,\"IsActive\":true},{\"Data\":\"100700194\",\"ID\":100,\"Type\":100,\"Count\":1,\"IsActive\":false}]');

-- ----------------------------
-- Table structure for money
-- ----------------------------
DROP TABLE IF EXISTS `money`;
CREATE TABLE `money`  (
  `id` varchar(155) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `holder` varchar(155) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `balance` varchar(155) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `type` varchar(155) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of money
-- ----------------------------
INSERT INTO `money` VALUES ('101741', '', '1000', '3');
INSERT INTO `money` VALUES ('102250', 'Andrei_Vassiljev', '0', '1');
INSERT INTO `money` VALUES ('10368', '', '0', '2');
INSERT INTO `money` VALUES ('104415', '', '16', '2');
INSERT INTO `money` VALUES ('105213', '', '0', '2');
INSERT INTO `money` VALUES ('106169', '', '0', '3');
INSERT INTO `money` VALUES ('106301', '', '0', '2');
INSERT INTO `money` VALUES ('10649', '', '0', '2');
INSERT INTO `money` VALUES ('107030', '', '0', '2');
INSERT INTO `money` VALUES ('112782', '', '0', '2');
INSERT INTO `money` VALUES ('115360', '', '0', '2');
INSERT INTO `money` VALUES ('11610', '', '0', '3');
INSERT INTO `money` VALUES ('116463', '', '0', '2');
INSERT INTO `money` VALUES ('117567', '', '0', '2');
INSERT INTO `money` VALUES ('120279', '', '1000', '3');
INSERT INTO `money` VALUES ('120354', '', '987', '3');
INSERT INTO `money` VALUES ('121701', '', '0', '2');
INSERT INTO `money` VALUES ('122167', '', '0', '2');
INSERT INTO `money` VALUES ('1226', '', '0', '2');
INSERT INTO `money` VALUES ('123516', '', '0', '2');
INSERT INTO `money` VALUES ('12400', '', '0', '2');
INSERT INTO `money` VALUES ('124481', '', '1000', '3');
INSERT INTO `money` VALUES ('124493', '', '0', '2');
INSERT INTO `money` VALUES ('124678', '', '1000', '3');
INSERT INTO `money` VALUES ('12473', '', '0', '2');
INSERT INTO `money` VALUES ('125643', '', '0', '2');
INSERT INTO `money` VALUES ('126597', '', '0', '1');
INSERT INTO `money` VALUES ('127352', '', '1000', '3');
INSERT INTO `money` VALUES ('127390', '', '1000', '3');
INSERT INTO `money` VALUES ('127492', '', '0', '2');
INSERT INTO `money` VALUES ('128310', '', '0', '3');
INSERT INTO `money` VALUES ('1290', '', '0', '3');
INSERT INTO `money` VALUES ('129303', '', '1000', '3');
INSERT INTO `money` VALUES ('13002', '', '0', '2');
INSERT INTO `money` VALUES ('130056', '', '272', '2');
INSERT INTO `money` VALUES ('130458', '', '1000', '3');
INSERT INTO `money` VALUES ('130486', '', '0', '2');
INSERT INTO `money` VALUES ('13273', '', '0', '2');
INSERT INTO `money` VALUES ('133815', '', '0', '2');
INSERT INTO `money` VALUES ('13508', '', '1000', '3');
INSERT INTO `money` VALUES ('135372', '', '0', '2');
INSERT INTO `money` VALUES ('135958', '', '0', '2');
INSERT INTO `money` VALUES ('136144', '', '584', '3');
INSERT INTO `money` VALUES ('136439', '', '1000', '3');
INSERT INTO `money` VALUES ('136594', '', '0', '2');
INSERT INTO `money` VALUES ('137043', 'Hanz_Wurst', '3000000', '1');
INSERT INTO `money` VALUES ('139828', '', '0', '2');
INSERT INTO `money` VALUES ('141134', '', '0', '3');
INSERT INTO `money` VALUES ('141612', '', '1000', '3');
INSERT INTO `money` VALUES ('141732', '', '0', '3');
INSERT INTO `money` VALUES ('142153', '', '0', '2');
INSERT INTO `money` VALUES ('142223', '', '1000', '3');
INSERT INTO `money` VALUES ('142699', '', '0', '2');
INSERT INTO `money` VALUES ('143339', '', '0', '2');
INSERT INTO `money` VALUES ('144240', '', '0', '2');
INSERT INTO `money` VALUES ('144645', '', '0', '2');
INSERT INTO `money` VALUES ('145634', '', '0', '3');
INSERT INTO `money` VALUES ('146052', '', '0', '2');
INSERT INTO `money` VALUES ('146279', '', '0', '2');
INSERT INTO `money` VALUES ('148456', '', '0', '2');
INSERT INTO `money` VALUES ('148734', '', '0', '2');
INSERT INTO `money` VALUES ('150251', '', '0', '2');
INSERT INTO `money` VALUES ('150490', '', '9928', '2');
INSERT INTO `money` VALUES ('150565', '', '0', '2');
INSERT INTO `money` VALUES ('153922', '', '0', '2');
INSERT INTO `money` VALUES ('154737', '', '0', '2');
INSERT INTO `money` VALUES ('155383', '', '1000', '3');
INSERT INTO `money` VALUES ('155542', '', '0', '2');
INSERT INTO `money` VALUES ('156176', '', '0', '2');
INSERT INTO `money` VALUES ('15645', '', '0', '2');
INSERT INTO `money` VALUES ('159535', '', '0', '2');
INSERT INTO `money` VALUES ('159702', '', '0', '2');
INSERT INTO `money` VALUES ('159913', '', '0', '2');
INSERT INTO `money` VALUES ('162701', '', '0', '2');
INSERT INTO `money` VALUES ('164712', '', '584', '3');
INSERT INTO `money` VALUES ('164723', '', '-8', '2');
INSERT INTO `money` VALUES ('165586', '', '0', '2');
INSERT INTO `money` VALUES ('165995', '', '0', '3');
INSERT INTO `money` VALUES ('166296', '', '0', '2');
INSERT INTO `money` VALUES ('166818', '', '0', '2');
INSERT INTO `money` VALUES ('167876', '', '0', '2');
INSERT INTO `money` VALUES ('169342', '', '584', '3');
INSERT INTO `money` VALUES ('171515', '', '0', '2');
INSERT INTO `money` VALUES ('172109', '', '0', '2');
INSERT INTO `money` VALUES ('172423', '', '0', '2');
INSERT INTO `money` VALUES ('172488', '', '0', '2');
INSERT INTO `money` VALUES ('172933', '', '0', '2');
INSERT INTO `money` VALUES ('173419', '', '0', '2');
INSERT INTO `money` VALUES ('173617', '', '0', '3');
INSERT INTO `money` VALUES ('175195', '', '0', '2');
INSERT INTO `money` VALUES ('175801', '', '1000', '3');
INSERT INTO `money` VALUES ('179059', '', '1000', '3');
INSERT INTO `money` VALUES ('179196', '', '0', '2');
INSERT INTO `money` VALUES ('179979', '', '0', '2');
INSERT INTO `money` VALUES ('181710', '', '-12', '2');
INSERT INTO `money` VALUES ('18237', '', '0', '2');
INSERT INTO `money` VALUES ('182606', '', '0', '2');
INSERT INTO `money` VALUES ('182811', '', '0', '3');
INSERT INTO `money` VALUES ('184154', '', '0', '2');
INSERT INTO `money` VALUES ('185218', '', '1000', '3');
INSERT INTO `money` VALUES ('185732', '', '1000', '3');
INSERT INTO `money` VALUES ('188394', '', '0', '2');
INSERT INTO `money` VALUES ('188595', '', '584', '3');
INSERT INTO `money` VALUES ('188679', '', '0', '2');
INSERT INTO `money` VALUES ('189268', '', '0', '2');
INSERT INTO `money` VALUES ('189317', '', '-4', '2');
INSERT INTO `money` VALUES ('189751', '', '0', '2');
INSERT INTO `money` VALUES ('193645', '', '0', '3');
INSERT INTO `money` VALUES ('195358', '', '0', '2');
INSERT INTO `money` VALUES ('195485', '', '0', '2');
INSERT INTO `money` VALUES ('196070', '', '584', '3');
INSERT INTO `money` VALUES ('196436', '', '0', '2');
INSERT INTO `money` VALUES ('196562', '', '1000', '3');
INSERT INTO `money` VALUES ('196695', '', '0', '2');
INSERT INTO `money` VALUES ('197396', '', '0', '2');
INSERT INTO `money` VALUES ('197930', '', '0', '2');
INSERT INTO `money` VALUES ('198153', '', '584', '3');
INSERT INTO `money` VALUES ('199445', '', '584', '3');
INSERT INTO `money` VALUES ('200946', '', '0', '2');
INSERT INTO `money` VALUES ('201698', '', '490', '2');
INSERT INTO `money` VALUES ('202126', '', '0', '2');
INSERT INTO `money` VALUES ('202414', '', '0', '3');
INSERT INTO `money` VALUES ('202539', '', '0', '2');
INSERT INTO `money` VALUES ('203641', '', '0', '2');
INSERT INTO `money` VALUES ('206312', '', '0', '2');
INSERT INTO `money` VALUES ('20844', '', '0', '2');
INSERT INTO `money` VALUES ('209166', '', '0', '2');
INSERT INTO `money` VALUES ('209512', '', '0', '3');
INSERT INTO `money` VALUES ('210874', '', '0', '2');
INSERT INTO `money` VALUES ('213493', '', '0', '3');
INSERT INTO `money` VALUES ('214323', '', '-1', '2');
INSERT INTO `money` VALUES ('2149', '', '0', '2');
INSERT INTO `money` VALUES ('215000', '', '0', '2');
INSERT INTO `money` VALUES ('216722', '', '1000', '3');
INSERT INTO `money` VALUES ('217197', '', '0', '1');
INSERT INTO `money` VALUES ('217739', '', '0', '2');
INSERT INTO `money` VALUES ('220091', '', '0', '2');
INSERT INTO `money` VALUES ('221001', '', '0', '2');
INSERT INTO `money` VALUES ('221085', '', '0', '2');
INSERT INTO `money` VALUES ('223786', '', '584', '3');
INSERT INTO `money` VALUES ('22451', '', '1000', '3');
INSERT INTO `money` VALUES ('22532', '', '0', '2');
INSERT INTO `money` VALUES ('226772', '', '1000', '3');
INSERT INTO `money` VALUES ('227490', '', '0', '2');
INSERT INTO `money` VALUES ('228573', '', '0', '2');
INSERT INTO `money` VALUES ('229160', '', '0', '2');
INSERT INTO `money` VALUES ('229466', '', '0', '2');
INSERT INTO `money` VALUES ('229765', '', '0', '2');
INSERT INTO `money` VALUES ('230484', '', '0', '2');
INSERT INTO `money` VALUES ('231326', 'Jeff_Dexter', '0', '1');
INSERT INTO `money` VALUES ('23158', '', '0', '2');
INSERT INTO `money` VALUES ('231825', '', '0', '2');
INSERT INTO `money` VALUES ('232375', '', '0', '2');
INSERT INTO `money` VALUES ('233543', '', '1000', '3');
INSERT INTO `money` VALUES ('234616', '', '0', '2');
INSERT INTO `money` VALUES ('236464', '', '0', '2');
INSERT INTO `money` VALUES ('236504', '', '0', '2');
INSERT INTO `money` VALUES ('237743', '', '0', '2');
INSERT INTO `money` VALUES ('237975', '', '0', '2');
INSERT INTO `money` VALUES ('238025', '', '0', '2');
INSERT INTO `money` VALUES ('239700', '', '0', '3');
INSERT INTO `money` VALUES ('23971', '', '0', '2');
INSERT INTO `money` VALUES ('240745', '', '0', '2');
INSERT INTO `money` VALUES ('241559', '', '0', '2');
INSERT INTO `money` VALUES ('242216', '', '0', '2');
INSERT INTO `money` VALUES ('243304', '', '0', '2');
INSERT INTO `money` VALUES ('244577', 'Jack_Frost', '0', '1');
INSERT INTO `money` VALUES ('246198', '', '1000', '3');
INSERT INTO `money` VALUES ('247021', '', '0', '2');
INSERT INTO `money` VALUES ('249194', '', '0', '2');
INSERT INTO `money` VALUES ('249634', '', '0', '2');
INSERT INTO `money` VALUES ('250055', '', '0', '2');
INSERT INTO `money` VALUES ('252400', '', '0', '2');
INSERT INTO `money` VALUES ('252558', '', '0', '2');
INSERT INTO `money` VALUES ('252798', '', '0', '2');
INSERT INTO `money` VALUES ('254906', '', '0', '2');
INSERT INTO `money` VALUES ('255654', '', '0', '2');
INSERT INTO `money` VALUES ('257615', '', '1000', '3');
INSERT INTO `money` VALUES ('257992', '', '0', '2');
INSERT INTO `money` VALUES ('259682', '', '0', '2');
INSERT INTO `money` VALUES ('259808', '', '0', '2');
INSERT INTO `money` VALUES ('260769', 'Michelle_Connor', '0', '1');
INSERT INTO `money` VALUES ('262647', '', '0', '3');
INSERT INTO `money` VALUES ('264368', 'Phillip_Coulson', '0', '1');
INSERT INTO `money` VALUES ('26447', '', '0', '2');
INSERT INTO `money` VALUES ('264729', 'Codeyx_Aplhatester', '0', '1');
INSERT INTO `money` VALUES ('265153', '', '0', '2');
INSERT INTO `money` VALUES ('26538', '', '1000', '3');
INSERT INTO `money` VALUES ('265715', 'John_Razor', '100', '1');
INSERT INTO `money` VALUES ('265811', '', '0', '3');
INSERT INTO `money` VALUES ('2666', '', '968', '3');
INSERT INTO `money` VALUES ('268064', '', '584', '3');
INSERT INTO `money` VALUES ('270543', '', '0', '2');
INSERT INTO `money` VALUES ('271476', '', '0', '2');
INSERT INTO `money` VALUES ('272165', '', '1000', '3');
INSERT INTO `money` VALUES ('272883', '', '0', '2');
INSERT INTO `money` VALUES ('272933', '', '1495', '3');
INSERT INTO `money` VALUES ('27376', '', '0', '1');
INSERT INTO `money` VALUES ('275156', '', '-180', '2');
INSERT INTO `money` VALUES ('276537', '', '0', '2');
INSERT INTO `money` VALUES ('278515', '', '0', '2');
INSERT INTO `money` VALUES ('27897', '', '0', '2');
INSERT INTO `money` VALUES ('280283', 'James_Hills', '0', '1');
INSERT INTO `money` VALUES ('280925', '', '0', '2');
INSERT INTO `money` VALUES ('281958', '', '584', '3');
INSERT INTO `money` VALUES ('282122', '', '0', '3');
INSERT INTO `money` VALUES ('28323', '', '0', '2');
INSERT INTO `money` VALUES ('283498', '', '1000', '3');
INSERT INTO `money` VALUES ('283900', '', '0', '1');
INSERT INTO `money` VALUES ('284494', '', '0', '2');
INSERT INTO `money` VALUES ('284537', '', '0', '3');
INSERT INTO `money` VALUES ('285119', '', '0', '2');
INSERT INTO `money` VALUES ('286286', '', '0', '2');
INSERT INTO `money` VALUES ('286595', '', '0', '2');
INSERT INTO `money` VALUES ('28671', '', '-1', '2');
INSERT INTO `money` VALUES ('288075', '', '0', '2');
INSERT INTO `money` VALUES ('288166', '', '0', '2');
INSERT INTO `money` VALUES ('288343', '', '0', '2');
INSERT INTO `money` VALUES ('288822', '', '0', '2');
INSERT INTO `money` VALUES ('291043', '', '0', '2');
INSERT INTO `money` VALUES ('292060', '', '0', '2');
INSERT INTO `money` VALUES ('295118', '', '0', '2');
INSERT INTO `money` VALUES ('295649', '', '-4', '2');
INSERT INTO `money` VALUES ('297869', '', '0', '2');
INSERT INTO `money` VALUES ('299737', '', '0', '3');
INSERT INTO `money` VALUES ('301799', '', '0', '2');
INSERT INTO `money` VALUES ('30214', '', '0', '2');
INSERT INTO `money` VALUES ('306909', '', '0', '2');
INSERT INTO `money` VALUES ('308938', '', '0', '2');
INSERT INTO `money` VALUES ('309280', '', '0', '2');
INSERT INTO `money` VALUES ('309495', '', '0', '2');
INSERT INTO `money` VALUES ('309554', '', '0', '2');
INSERT INTO `money` VALUES ('310345', '', '0', '2');
INSERT INTO `money` VALUES ('310391', '', '584', '3');
INSERT INTO `money` VALUES ('310679', '', '0', '2');
INSERT INTO `money` VALUES ('311177', 'Alexander_Rusev', '0', '1');
INSERT INTO `money` VALUES ('311350', '', '0', '2');
INSERT INTO `money` VALUES ('311429', '', '0', '2');
INSERT INTO `money` VALUES ('315784', '', '1000', '3');
INSERT INTO `money` VALUES ('31713', '', '0', '2');
INSERT INTO `money` VALUES ('320320', '', '0', '3');
INSERT INTO `money` VALUES ('321454', '', '0', '2');
INSERT INTO `money` VALUES ('322668', '', '0', '2');
INSERT INTO `money` VALUES ('324500', '', '0', '2');
INSERT INTO `money` VALUES ('325221', '', '584', '3');
INSERT INTO `money` VALUES ('326031', '', '0', '2');
INSERT INTO `money` VALUES ('326448', '', '0', '2');
INSERT INTO `money` VALUES ('327801', '', '0', '2');
INSERT INTO `money` VALUES ('327823', '', '0', '2');
INSERT INTO `money` VALUES ('328061', '', '584', '3');
INSERT INTO `money` VALUES ('328613', '', '0', '3');
INSERT INTO `money` VALUES ('328925', '', '0', '2');
INSERT INTO `money` VALUES ('329765', '', '0', '2');
INSERT INTO `money` VALUES ('330111', '', '0', '2');
INSERT INTO `money` VALUES ('330318', '', '584', '3');
INSERT INTO `money` VALUES ('33106', '', '0', '2');
INSERT INTO `money` VALUES ('331900', '', '0', '2');
INSERT INTO `money` VALUES ('331916', '', '0', '2');
INSERT INTO `money` VALUES ('332202', '', '1000', '3');
INSERT INTO `money` VALUES ('333301', '', '0', '2');
INSERT INTO `money` VALUES ('333778', '', '0', '3');
INSERT INTO `money` VALUES ('333790', '', '0', '2');
INSERT INTO `money` VALUES ('33434', '', '0', '3');
INSERT INTO `money` VALUES ('335091', 'Wiesel_Alphatester', '26', '1');
INSERT INTO `money` VALUES ('335785', '', '0', '3');
INSERT INTO `money` VALUES ('335822', '', '0', '2');
INSERT INTO `money` VALUES ('335887', '', '0', '3');
INSERT INTO `money` VALUES ('337533', '', '0', '2');
INSERT INTO `money` VALUES ('338441', '', '0', '2');
INSERT INTO `money` VALUES ('338770', '', '0', '2');
INSERT INTO `money` VALUES ('33990', '', '1000', '3');
INSERT INTO `money` VALUES ('339945', '', '0', '2');
INSERT INTO `money` VALUES ('340005', '', '0', '2');
INSERT INTO `money` VALUES ('340317', '', '0', '2');
INSERT INTO `money` VALUES ('340591', '', '1000', '3');
INSERT INTO `money` VALUES ('341093', '', '0', '2');
INSERT INTO `money` VALUES ('343561', '', '1000', '3');
INSERT INTO `money` VALUES ('344214', '', '0', '3');
INSERT INTO `money` VALUES ('344777', '', '1000', '3');
INSERT INTO `money` VALUES ('345132', '', '0', '2');
INSERT INTO `money` VALUES ('345312', '', '20', '3');
INSERT INTO `money` VALUES ('346849', '', '0', '2');
INSERT INTO `money` VALUES ('347749', '', '0', '2');
INSERT INTO `money` VALUES ('348930', 'Jojo_Jones', '0', '1');
INSERT INTO `money` VALUES ('349744', '', '0', '2');
INSERT INTO `money` VALUES ('350018', '', '0', '2');
INSERT INTO `money` VALUES ('350251', '', '0', '2');
INSERT INTO `money` VALUES ('350354', '', '0', '2');
INSERT INTO `money` VALUES ('352081', '', '584', '3');
INSERT INTO `money` VALUES ('352419', '', '0', '2');
INSERT INTO `money` VALUES ('3526', '', '0', '2');
INSERT INTO `money` VALUES ('353040', '', '0', '2');
INSERT INTO `money` VALUES ('353286', 'Sanja_Lolipop', '0', '1');
INSERT INTO `money` VALUES ('353637', '', '0', '3');
INSERT INTO `money` VALUES ('353736', '', '0', '2');
INSERT INTO `money` VALUES ('354333', '', '0', '2');
INSERT INTO `money` VALUES ('354814', '', '0', '3');
INSERT INTO `money` VALUES ('35587', '', '1000', '3');
INSERT INTO `money` VALUES ('357472', '', '0', '2');
INSERT INTO `money` VALUES ('357682', '', '0', '2');
INSERT INTO `money` VALUES ('358251', '', '0', '2');
INSERT INTO `money` VALUES ('358780', '', '1000', '3');
INSERT INTO `money` VALUES ('360522', '', '1000', '3');
INSERT INTO `money` VALUES ('362014', '', '584', '3');
INSERT INTO `money` VALUES ('365352', '', '0', '2');
INSERT INTO `money` VALUES ('365991', '', '0', '2');
INSERT INTO `money` VALUES ('366070', '', '0', '2');
INSERT INTO `money` VALUES ('368065', '', '0', '2');
INSERT INTO `money` VALUES ('368314', '', '0', '2');
INSERT INTO `money` VALUES ('368473', '', '0', '2');
INSERT INTO `money` VALUES ('368581', '', '0', '3');
INSERT INTO `money` VALUES ('369810', '', '0', '2');
INSERT INTO `money` VALUES ('370312', '', '0', '2');
INSERT INTO `money` VALUES ('371257', '', '0', '2');
INSERT INTO `money` VALUES ('371953', '', '0', '2');
INSERT INTO `money` VALUES ('37223', 'Dustin_Johnsen', '105', '1');
INSERT INTO `money` VALUES ('373198', '', '0', '2');
INSERT INTO `money` VALUES ('374414', '', '0', '2');
INSERT INTO `money` VALUES ('376545', '', '968', '3');
INSERT INTO `money` VALUES ('376556', '', '0', '3');
INSERT INTO `money` VALUES ('37771', '', '0', '2');
INSERT INTO `money` VALUES ('378127', '', '0', '2');
INSERT INTO `money` VALUES ('378407', '', '1000', '3');
INSERT INTO `money` VALUES ('378972', 'Timati_Blackstar', '109998', '1');
INSERT INTO `money` VALUES ('379041', '', '584', '3');
INSERT INTO `money` VALUES ('379183', '', '0', '2');
INSERT INTO `money` VALUES ('380585', '', '0', '2');
INSERT INTO `money` VALUES ('383564', '', '584', '3');
INSERT INTO `money` VALUES ('383566', '', '0', '2');
INSERT INTO `money` VALUES ('383578', '', '0', '2');
INSERT INTO `money` VALUES ('383818', '', '0', '2');
INSERT INTO `money` VALUES ('384271', '', '584', '3');
INSERT INTO `money` VALUES ('384287', '', '0', '3');
INSERT INTO `money` VALUES ('385236', '', '0', '2');
INSERT INTO `money` VALUES ('385560', '', '0', '2');
INSERT INTO `money` VALUES ('385591', '', '0', '2');
INSERT INTO `money` VALUES ('389517', '', '968', '3');
INSERT INTO `money` VALUES ('390483', '', '0', '2');
INSERT INTO `money` VALUES ('39117', '', '1000', '3');
INSERT INTO `money` VALUES ('391738', '', '0', '2');
INSERT INTO `money` VALUES ('392248', '', '0', '3');
INSERT INTO `money` VALUES ('392729', '', '1000', '3');
INSERT INTO `money` VALUES ('393208', 'Qwe_Qwe', '0', '1');
INSERT INTO `money` VALUES ('394806', '', '0', '3');
INSERT INTO `money` VALUES ('396822', '', '987', '3');
INSERT INTO `money` VALUES ('397757', '', '0', '2');
INSERT INTO `money` VALUES ('398406', '', '0', '2');
INSERT INTO `money` VALUES ('400128', '', '584', '3');
INSERT INTO `money` VALUES ('400194', '', '584', '3');
INSERT INTO `money` VALUES ('400376', '', '584', '3');
INSERT INTO `money` VALUES ('400753', '', '0', '2');
INSERT INTO `money` VALUES ('401096', '', '0', '3');
INSERT INTO `money` VALUES ('404125', '', '0', '2');
INSERT INTO `money` VALUES ('404444', '', '0', '2');
INSERT INTO `money` VALUES ('405305', '', '-4', '2');
INSERT INTO `money` VALUES ('408318', '', '0', '2');
INSERT INTO `money` VALUES ('408503', '', '0', '2');
INSERT INTO `money` VALUES ('408636', '', '0', '2');
INSERT INTO `money` VALUES ('409350', '', '0', '3');
INSERT INTO `money` VALUES ('409397', '', '0', '2');
INSERT INTO `money` VALUES ('41002', '', '0', '3');
INSERT INTO `money` VALUES ('410188', '', '0', '2');
INSERT INTO `money` VALUES ('410198', '', '0', '2');
INSERT INTO `money` VALUES ('410448', '', '0', '3');
INSERT INTO `money` VALUES ('410731', 'Gangsta_DOg', '0', '1');
INSERT INTO `money` VALUES ('413654', '', '0', '2');
INSERT INTO `money` VALUES ('416037', '', '0', '2');
INSERT INTO `money` VALUES ('416533', '', '0', '2');
INSERT INTO `money` VALUES ('416648', '', '0', '2');
INSERT INTO `money` VALUES ('417018', '', '584', '3');
INSERT INTO `money` VALUES ('417513', '', '0', '2');
INSERT INTO `money` VALUES ('418408', '', '0', '2');
INSERT INTO `money` VALUES ('418727', '', '0', '2');
INSERT INTO `money` VALUES ('41956', '', '584', '3');
INSERT INTO `money` VALUES ('421244', '', '0', '2');
INSERT INTO `money` VALUES ('421823', '', '0', '2');
INSERT INTO `money` VALUES ('422389', 'Mike_Mike', '0', '1');
INSERT INTO `money` VALUES ('422463', '', '584', '3');
INSERT INTO `money` VALUES ('425907', '', '584', '3');
INSERT INTO `money` VALUES ('426091', '', '0', '2');
INSERT INTO `money` VALUES ('42627', '', '0', '2');
INSERT INTO `money` VALUES ('426487', '', '0', '2');
INSERT INTO `money` VALUES ('428603', '', '0', '2');
INSERT INTO `money` VALUES ('431200', '', '0', '2');
INSERT INTO `money` VALUES ('431545', '', '0', '2');
INSERT INTO `money` VALUES ('431560', '', '0', '2');
INSERT INTO `money` VALUES ('434198', '', '0', '3');
INSERT INTO `money` VALUES ('434460', '', '0', '2');
INSERT INTO `money` VALUES ('434724', '', '0', '2');
INSERT INTO `money` VALUES ('435378', '', '584', '3');
INSERT INTO `money` VALUES ('435444', '', '0', '2');
INSERT INTO `money` VALUES ('436090', '', '0', '2');
INSERT INTO `money` VALUES ('436981', '', '0', '2');
INSERT INTO `money` VALUES ('43777', '', '0', '2');
INSERT INTO `money` VALUES ('438568', '', '1000', '3');
INSERT INTO `money` VALUES ('440530', '', '0', '2');
INSERT INTO `money` VALUES ('441895', '', '0', '2');
INSERT INTO `money` VALUES ('443851', '', '0', '2');
INSERT INTO `money` VALUES ('443912', '', '0', '2');
INSERT INTO `money` VALUES ('444228', '', '584', '3');
INSERT INTO `money` VALUES ('445627', '', '0', '2');
INSERT INTO `money` VALUES ('446589', '', '0', '2');
INSERT INTO `money` VALUES ('446972', '', '1000', '3');
INSERT INTO `money` VALUES ('447123', '', '0', '2');
INSERT INTO `money` VALUES ('449422', '', '0', '2');
INSERT INTO `money` VALUES ('449719', '', '0', '2');
INSERT INTO `money` VALUES ('449839', '', '0', '2');
INSERT INTO `money` VALUES ('451674', '', '0', '2');
INSERT INTO `money` VALUES ('453018', '', '1000', '3');
INSERT INTO `money` VALUES ('45305', '', '0', '2');
INSERT INTO `money` VALUES ('454317', '', '1000', '3');
INSERT INTO `money` VALUES ('455329', '', '0', '2');
INSERT INTO `money` VALUES ('456866', '', '0', '2');
INSERT INTO `money` VALUES ('4595', '', '584', '3');
INSERT INTO `money` VALUES ('460048', '', '0', '2');
INSERT INTO `money` VALUES ('46118', '', '584', '3');
INSERT INTO `money` VALUES ('464133', '', '0', '2');
INSERT INTO `money` VALUES ('464145', 'Mila_Jung', '0', '1');
INSERT INTO `money` VALUES ('464217', '', '0', '2');
INSERT INTO `money` VALUES ('466442', '', '0', '2');
INSERT INTO `money` VALUES ('467400', '', '0', '3');
INSERT INTO `money` VALUES ('467530', '', '968', '3');
INSERT INTO `money` VALUES ('468774', '', '0', '3');
INSERT INTO `money` VALUES ('470276', '', '0', '2');
INSERT INTO `money` VALUES ('470357', '', '0', '2');
INSERT INTO `money` VALUES ('471423', '', '0', '1');
INSERT INTO `money` VALUES ('471433', '', '0', '2');
INSERT INTO `money` VALUES ('472500', '', '0', '2');
INSERT INTO `money` VALUES ('472932', '', '0', '1');
INSERT INTO `money` VALUES ('474531', '', '0', '2');
INSERT INTO `money` VALUES ('47621', '', '0', '3');
INSERT INTO `money` VALUES ('476756', '', '1000', '3');
INSERT INTO `money` VALUES ('477094', '', '0', '2');
INSERT INTO `money` VALUES ('477299', '', '0', '2');
INSERT INTO `money` VALUES ('47756', '', '0', '2');
INSERT INTO `money` VALUES ('477919', '', '0', '2');
INSERT INTO `money` VALUES ('478010', '', '0', '2');
INSERT INTO `money` VALUES ('480686', 'Admin_Administrator', '0', '1');
INSERT INTO `money` VALUES ('480927', '', '584', '3');
INSERT INTO `money` VALUES ('481501', '', '0', '2');
INSERT INTO `money` VALUES ('483180', '', '0', '2');
INSERT INTO `money` VALUES ('483485', '', '0', '2');
INSERT INTO `money` VALUES ('484926', '', '0', '3');
INSERT INTO `money` VALUES ('485225', '', '0', '2');
INSERT INTO `money` VALUES ('485592', '', '0', '2');
INSERT INTO `money` VALUES ('48628', '', '0', '2');
INSERT INTO `money` VALUES ('486929', '', '584', '3');
INSERT INTO `money` VALUES ('489529', '', '0', '2');
INSERT INTO `money` VALUES ('490074', '', '0', '2');
INSERT INTO `money` VALUES ('490914', '', '800', '2');
INSERT INTO `money` VALUES ('492165', '', '968', '3');
INSERT INTO `money` VALUES ('493165', '', '-4', '2');
INSERT INTO `money` VALUES ('493466', '', '0', '3');
INSERT INTO `money` VALUES ('494702', '', '0', '2');
INSERT INTO `money` VALUES ('49581', '', '0', '2');
INSERT INTO `money` VALUES ('496613', '', '-240', '2');
INSERT INTO `money` VALUES ('499804', '', '0', '2');
INSERT INTO `money` VALUES ('501432', '', '0', '2');
INSERT INTO `money` VALUES ('502078', '', '584', '3');
INSERT INTO `money` VALUES ('502446', '', '0', '2');
INSERT INTO `money` VALUES ('503112', '', '-240', '2');
INSERT INTO `money` VALUES ('504736', '', '0', '2');
INSERT INTO `money` VALUES ('505585', '', '0', '1');
INSERT INTO `money` VALUES ('50566', '', '0', '2');
INSERT INTO `money` VALUES ('505910', '', '0', '3');
INSERT INTO `money` VALUES ('50603', '', '0', '2');
INSERT INTO `money` VALUES ('506558', '', '0', '2');
INSERT INTO `money` VALUES ('506566', '', '0', '2');
INSERT INTO `money` VALUES ('507812', '', '584', '3');
INSERT INTO `money` VALUES ('508730', '', '0', '2');
INSERT INTO `money` VALUES ('508976', '', '968', '3');
INSERT INTO `money` VALUES ('509759', '', '0', '2');
INSERT INTO `money` VALUES ('510099', '', '0', '2');
INSERT INTO `money` VALUES ('510748', '', '0', '3');
INSERT INTO `money` VALUES ('512764', '', '0', '2');
INSERT INTO `money` VALUES ('513225', '', '0', '2');
INSERT INTO `money` VALUES ('513295', '', '-1560', '2');
INSERT INTO `money` VALUES ('514559', '', '0', '2');
INSERT INTO `money` VALUES ('515853', '', '0', '2');
INSERT INTO `money` VALUES ('516433', '', '1000', '3');
INSERT INTO `money` VALUES ('516828', '', '0', '2');
INSERT INTO `money` VALUES ('517194', '', '0', '2');
INSERT INTO `money` VALUES ('517218', '', '0', '2');
INSERT INTO `money` VALUES ('518518', 'Patte_Test', '114390', '1');
INSERT INTO `money` VALUES ('519735', '', '0', '2');
INSERT INTO `money` VALUES ('519877', '', '1000', '3');
INSERT INTO `money` VALUES ('520202', '', '0', '2');
INSERT INTO `money` VALUES ('521686', '', '0', '2');
INSERT INTO `money` VALUES ('521713', '', '0', '2');
INSERT INTO `money` VALUES ('522613', '', '0', '2');
INSERT INTO `money` VALUES ('523792', '', '584', '3');
INSERT INTO `money` VALUES ('524802', '', '0', '2');
INSERT INTO `money` VALUES ('525099', '', '0', '2');
INSERT INTO `money` VALUES ('525786', '', '909', '3');
INSERT INTO `money` VALUES ('52600', '', '0', '2');
INSERT INTO `money` VALUES ('526173', 'Tobias_Boemer', '2000000', '1');
INSERT INTO `money` VALUES ('52626', '', '0', '2');
INSERT INTO `money` VALUES ('52645', '', '0', '2');
INSERT INTO `money` VALUES ('526597', '', '0', '2');
INSERT INTO `money` VALUES ('526612', '', '0', '3');
INSERT INTO `money` VALUES ('526710', '', '0', '2');
INSERT INTO `money` VALUES ('527162', '', '0', '2');
INSERT INTO `money` VALUES ('527402', '', '0', '2');
INSERT INTO `money` VALUES ('527757', '', '0', '2');
INSERT INTO `money` VALUES ('527940', 'Kiralee_May', '1224128', '1');
INSERT INTO `money` VALUES ('531145', '', '1000', '3');
INSERT INTO `money` VALUES ('532033', '', '0', '2');
INSERT INTO `money` VALUES ('532613', '', '0', '3');
INSERT INTO `money` VALUES ('533751', '', '0', '2');
INSERT INTO `money` VALUES ('534922', '', '0', '2');
INSERT INTO `money` VALUES ('536042', '', '0', '2');
INSERT INTO `money` VALUES ('536450', '', '0', '2');
INSERT INTO `money` VALUES ('536465', '', '0', '2');
INSERT INTO `money` VALUES ('53681', '', '584', '3');
INSERT INTO `money` VALUES ('537436', '', '1000', '3');
INSERT INTO `money` VALUES ('537600', '', '0', '3');
INSERT INTO `money` VALUES ('538523', '', '968', '3');
INSERT INTO `money` VALUES ('538995', '', '0', '2');
INSERT INTO `money` VALUES ('539359', '', '0', '2');
INSERT INTO `money` VALUES ('540547', '', '0', '2');
INSERT INTO `money` VALUES ('542485', '', '0', '2');
INSERT INTO `money` VALUES ('543830', '', '0', '2');
INSERT INTO `money` VALUES ('54543', '', '0', '2');
INSERT INTO `money` VALUES ('547134', '', '-80', '2');
INSERT INTO `money` VALUES ('547162', '', '0', '2');
INSERT INTO `money` VALUES ('547312', '', '1000', '3');
INSERT INTO `money` VALUES ('548100', '', '0', '2');
INSERT INTO `money` VALUES ('548262', '', '0', '2');
INSERT INTO `money` VALUES ('54959', '', '0', '3');
INSERT INTO `money` VALUES ('549835', 'Mike_Odell', '0', '1');
INSERT INTO `money` VALUES ('552377', '', '0', '2');
INSERT INTO `money` VALUES ('552726', '', '0', '2');
INSERT INTO `money` VALUES ('554268', '', '968', '3');
INSERT INTO `money` VALUES ('554459', '', '0', '2');
INSERT INTO `money` VALUES ('554799', '', '0', '2');
INSERT INTO `money` VALUES ('555576', '', '1000', '3');
INSERT INTO `money` VALUES ('558652', '', '1000', '3');
INSERT INTO `money` VALUES ('559377', '', '584', '3');
INSERT INTO `money` VALUES ('5600', '', '0', '2');
INSERT INTO `money` VALUES ('560095', '', '0', '2');
INSERT INTO `money` VALUES ('560123', '', '0', '2');
INSERT INTO `money` VALUES ('56077', '', '584', '3');
INSERT INTO `money` VALUES ('56155', '', '0', '2');
INSERT INTO `money` VALUES ('562240', '', '0', '2');
INSERT INTO `money` VALUES ('565615', '', '0', '2');
INSERT INTO `money` VALUES ('566631', '', '0', '2');
INSERT INTO `money` VALUES ('568719', '', '922', '3');
INSERT INTO `money` VALUES ('570451', '', '0', '2');
INSERT INTO `money` VALUES ('57143', '', '0', '2');
INSERT INTO `money` VALUES ('572155', '', '0', '2');
INSERT INTO `money` VALUES ('572212', '', '0', '2');
INSERT INTO `money` VALUES ('578341', '', '0', '2');
INSERT INTO `money` VALUES ('579844', '', '0', '3');
INSERT INTO `money` VALUES ('580401', '', '0', '2');
INSERT INTO `money` VALUES ('580888', '', '0', '2');
INSERT INTO `money` VALUES ('584640', '', '584', '3');
INSERT INTO `money` VALUES ('58502', '', '1000', '3');
INSERT INTO `money` VALUES ('586110', '', '0', '2');
INSERT INTO `money` VALUES ('586343', '', '584', '3');
INSERT INTO `money` VALUES ('586713', '', '0', '2');
INSERT INTO `money` VALUES ('58683', '', '0', '2');
INSERT INTO `money` VALUES ('587066', '', '0', '2');
INSERT INTO `money` VALUES ('58717', '', '0', '2');
INSERT INTO `money` VALUES ('587794', '', '584', '3');
INSERT INTO `money` VALUES ('592522', '', '0', '2');
INSERT INTO `money` VALUES ('592732', '', '0', '2');
INSERT INTO `money` VALUES ('593443', '', '584', '3');
INSERT INTO `money` VALUES ('593590', '', '0', '2');
INSERT INTO `money` VALUES ('594246', '', '0', '2');
INSERT INTO `money` VALUES ('594498', '', '584', '3');
INSERT INTO `money` VALUES ('594652', '', '0', '2');
INSERT INTO `money` VALUES ('597819', '', '0', '2');
INSERT INTO `money` VALUES ('600314', '', '0', '2');
INSERT INTO `money` VALUES ('600683', '', '0', '3');
INSERT INTO `money` VALUES ('602053', '', '0', '2');
INSERT INTO `money` VALUES ('603690', '', '0', '2');
INSERT INTO `money` VALUES ('604217', '', '0', '2');
INSERT INTO `money` VALUES ('60427', '', '584', '3');
INSERT INTO `money` VALUES ('604496', '', '0', '2');
INSERT INTO `money` VALUES ('604606', '', '0', '3');
INSERT INTO `money` VALUES ('604880', '', '0', '2');
INSERT INTO `money` VALUES ('605597', '', '909', '3');
INSERT INTO `money` VALUES ('605795', '', '-5', '2');
INSERT INTO `money` VALUES ('606630', '', '0', '3');
INSERT INTO `money` VALUES ('606788', '', '0', '2');
INSERT INTO `money` VALUES ('606937', '', '1000', '3');
INSERT INTO `money` VALUES ('607852', '', '0', '2');
INSERT INTO `money` VALUES ('608389', '', '0', '3');
INSERT INTO `money` VALUES ('608453', '', '0', '2');
INSERT INTO `money` VALUES ('608946', '', '0', '2');
INSERT INTO `money` VALUES ('609676', '', '584', '3');
INSERT INTO `money` VALUES ('610466', '', '0', '3');
INSERT INTO `money` VALUES ('61105', '', '0', '2');
INSERT INTO `money` VALUES ('612005', '', '0', '2');
INSERT INTO `money` VALUES ('614522', '', '0', '2');
INSERT INTO `money` VALUES ('614597', '', '0', '2');
INSERT INTO `money` VALUES ('617247', '', '0', '2');
INSERT INTO `money` VALUES ('618509', '', '0', '2');
INSERT INTO `money` VALUES ('618732', '', '0', '2');
INSERT INTO `money` VALUES ('620207', '', '0', '2');
INSERT INTO `money` VALUES ('620254', '', '0', '2');
INSERT INTO `money` VALUES ('620656', '', '0', '2');
INSERT INTO `money` VALUES ('621191', '', '0', '2');
INSERT INTO `money` VALUES ('622190', '', '0', '2');
INSERT INTO `money` VALUES ('624506', '', '0', '3');
INSERT INTO `money` VALUES ('624628', '', '1000', '3');
INSERT INTO `money` VALUES ('624884', '', '1000', '3');
INSERT INTO `money` VALUES ('626518', '', '0', '2');
INSERT INTO `money` VALUES ('627027', '', '0', '2');
INSERT INTO `money` VALUES ('627989', '', '0', '3');
INSERT INTO `money` VALUES ('628577', '', '584', '3');
INSERT INTO `money` VALUES ('629637', '', '0', '2');
INSERT INTO `money` VALUES ('630218', '', '0', '2');
INSERT INTO `money` VALUES ('631485', '', '0', '2');
INSERT INTO `money` VALUES ('633051', '', '0', '2');
INSERT INTO `money` VALUES ('634524', '', '272', '2');
INSERT INTO `money` VALUES ('635504', '', '0', '2');
INSERT INTO `money` VALUES ('637321', '', '0', '2');
INSERT INTO `money` VALUES ('637608', '', '1000', '3');
INSERT INTO `money` VALUES ('637711', '', '0', '2');
INSERT INTO `money` VALUES ('639578', '', '0', '2');
INSERT INTO `money` VALUES ('63989', '', '0', '3');
INSERT INTO `money` VALUES ('640623', '', '1000', '3');
INSERT INTO `money` VALUES ('641259', '', '0', '2');
INSERT INTO `money` VALUES ('643436', '', '0', '2');
INSERT INTO `money` VALUES ('644323', '', '-3', '2');
INSERT INTO `money` VALUES ('645228', '', '0', '2');
INSERT INTO `money` VALUES ('647090', '', '0', '2');
INSERT INTO `money` VALUES ('648965', '', '0', '3');
INSERT INTO `money` VALUES ('650924', '', '0', '2');
INSERT INTO `money` VALUES ('651177', '', '1000', '3');
INSERT INTO `money` VALUES ('651573', '', '0', '2');
INSERT INTO `money` VALUES ('652494', '', '0', '3');
INSERT INTO `money` VALUES ('652953', '', '584', '3');
INSERT INTO `money` VALUES ('653306', '', '1000', '3');
INSERT INTO `money` VALUES ('653585', '', '0', '2');
INSERT INTO `money` VALUES ('654016', '', '-96', '2');
INSERT INTO `money` VALUES ('656869', '', '584', '3');
INSERT INTO `money` VALUES ('657022', '', '0', '2');
INSERT INTO `money` VALUES ('657058', '', '0', '2');
INSERT INTO `money` VALUES ('657196', '', '0', '2');
INSERT INTO `money` VALUES ('657984', '', '1000', '3');
INSERT INTO `money` VALUES ('66082', '', '0', '2');
INSERT INTO `money` VALUES ('661034', '', '0', '2');
INSERT INTO `money` VALUES ('661178', '', '0', '2');
INSERT INTO `money` VALUES ('662089', '', '0', '2');
INSERT INTO `money` VALUES ('662157', '', '1000', '3');
INSERT INTO `money` VALUES ('662359', '', '0', '2');
INSERT INTO `money` VALUES ('662892', '', '1000', '3');
INSERT INTO `money` VALUES ('663098', '', '0', '2');
INSERT INTO `money` VALUES ('663299', '', '0', '2');
INSERT INTO `money` VALUES ('664005', '', '1000', '3');
INSERT INTO `money` VALUES ('664576', '', '0', '3');
INSERT INTO `money` VALUES ('665236', '', '0', '2');
INSERT INTO `money` VALUES ('666269', 'General_Fickschnitzel', '1000000', '1');
INSERT INTO `money` VALUES ('667360', '', '0', '2');
INSERT INTO `money` VALUES ('66911', '', '0', '2');
INSERT INTO `money` VALUES ('669219', '', '584', '3');
INSERT INTO `money` VALUES ('669861', '', '0', '2');
INSERT INTO `money` VALUES ('670740', '', '0', '2');
INSERT INTO `money` VALUES ('670835', '', '0', '2');
INSERT INTO `money` VALUES ('671602', '', '1000', '3');
INSERT INTO `money` VALUES ('671625', '', '0', '2');
INSERT INTO `money` VALUES ('671997', '', '0', '2');
INSERT INTO `money` VALUES ('672103', '', '0', '2');
INSERT INTO `money` VALUES ('672279', '', '0', '2');
INSERT INTO `money` VALUES ('672684', '', '0', '2');
INSERT INTO `money` VALUES ('672719', '', '0', '2');
INSERT INTO `money` VALUES ('673172', '', '0', '2');
INSERT INTO `money` VALUES ('673655', '', '-4', '2');
INSERT INTO `money` VALUES ('674651', '', '584', '3');
INSERT INTO `money` VALUES ('678657', '', '0', '2');
INSERT INTO `money` VALUES ('679355', 'Codeyx_Alphatester', '0', '1');
INSERT INTO `money` VALUES ('680510', '', '0', '2');
INSERT INTO `money` VALUES ('681226', '', '909', '3');
INSERT INTO `money` VALUES ('681293', '', '0', '2');
INSERT INTO `money` VALUES ('681386', '', '0', '2');
INSERT INTO `money` VALUES ('681541', '', '0', '2');
INSERT INTO `money` VALUES ('682313', '', '0', '2');
INSERT INTO `money` VALUES ('682525', '', '0', '2');
INSERT INTO `money` VALUES ('683233', '', '0', '2');
INSERT INTO `money` VALUES ('683940', '', '0', '2');
INSERT INTO `money` VALUES ('685129', '', '0', '2');
INSERT INTO `money` VALUES ('686993', '', '1000', '3');
INSERT INTO `money` VALUES ('687227', '', '0', '2');
INSERT INTO `money` VALUES ('689257', '', '0', '2');
INSERT INTO `money` VALUES ('690068', '', '0', '3');
INSERT INTO `money` VALUES ('690108', '', '0', '2');
INSERT INTO `money` VALUES ('69149', '', '584', '3');
INSERT INTO `money` VALUES ('693908', 'Marcus_Stenhouse', '114', '1');
INSERT INTO `money` VALUES ('6943', '', '0', '2');
INSERT INTO `money` VALUES ('696671', '', '0', '2');
INSERT INTO `money` VALUES ('696957', '', '0', '3');
INSERT INTO `money` VALUES ('698544', '', '0', '1');
INSERT INTO `money` VALUES ('699680', '', '0', '2');
INSERT INTO `money` VALUES ('700006', '', '0', '2');
INSERT INTO `money` VALUES ('700737', '', '0', '2');
INSERT INTO `money` VALUES ('701041', '', '0', '2');
INSERT INTO `money` VALUES ('701329', '', '1000', '3');
INSERT INTO `money` VALUES ('701828', '', '584', '3');
INSERT INTO `money` VALUES ('704540', '', '0', '2');
INSERT INTO `money` VALUES ('705980', '', '0', '2');
INSERT INTO `money` VALUES ('706461', '', '0', '2');
INSERT INTO `money` VALUES ('707326', '', '300', '2');
INSERT INTO `money` VALUES ('707545', '', '0', '2');
INSERT INTO `money` VALUES ('707587', '', '0', '2');
INSERT INTO `money` VALUES ('707959', '', '0', '2');
INSERT INTO `money` VALUES ('70891', '', '0', '2');
INSERT INTO `money` VALUES ('710297', '', '1000', '3');
INSERT INTO `money` VALUES ('711927', 'Theo_Schmidt', '9000', '1');
INSERT INTO `money` VALUES ('71203', '', '584', '3');
INSERT INTO `money` VALUES ('712121', '', '-4', '2');
INSERT INTO `money` VALUES ('712973', '', '0', '2');
INSERT INTO `money` VALUES ('713340', '', '0', '3');
INSERT INTO `money` VALUES ('713382', '', '0', '2');
INSERT INTO `money` VALUES ('714210', '', '0', '3');
INSERT INTO `money` VALUES ('714405', '', '0', '2');
INSERT INTO `money` VALUES ('714553', '', '0', '2');
INSERT INTO `money` VALUES ('715194', '', '0', '3');
INSERT INTO `money` VALUES ('715321', '', '0', '2');
INSERT INTO `money` VALUES ('71662', '', '0', '2');
INSERT INTO `money` VALUES ('718396', '', '1000', '3');
INSERT INTO `money` VALUES ('718725', '', '584', '3');
INSERT INTO `money` VALUES ('719554', '', '0', '2');
INSERT INTO `money` VALUES ('721413', '', '0', '2');
INSERT INTO `money` VALUES ('721538', '', '0', '2');
INSERT INTO `money` VALUES ('721794', '', '0', '2');
INSERT INTO `money` VALUES ('722047', '', '0', '2');
INSERT INTO `money` VALUES ('722421', '', '0', '2');
INSERT INTO `money` VALUES ('723112', '', '0', '2');
INSERT INTO `money` VALUES ('723357', '', '1000', '3');
INSERT INTO `money` VALUES ('723530', '', '0', '2');
INSERT INTO `money` VALUES ('724126', '', '1000', '3');
INSERT INTO `money` VALUES ('725198', '', '0', '2');
INSERT INTO `money` VALUES ('726694', '', '968', '3');
INSERT INTO `money` VALUES ('727042', 'Gangsta_Cat', '0', '1');
INSERT INTO `money` VALUES ('727377', '', '1000', '3');
INSERT INTO `money` VALUES ('727883', '', '0', '2');
INSERT INTO `money` VALUES ('728026', '', '1000', '3');
INSERT INTO `money` VALUES ('728262', '', '0', '2');
INSERT INTO `money` VALUES ('728689', '', '584', '3');
INSERT INTO `money` VALUES ('728712', '', '0', '2');
INSERT INTO `money` VALUES ('729832', 'Sky_Net', '0', '1');
INSERT INTO `money` VALUES ('729994', '', '0', '2');
INSERT INTO `money` VALUES ('730353', '', '0', '2');
INSERT INTO `money` VALUES ('733033', '', '0', '2');
INSERT INTO `money` VALUES ('733339', '', '0', '2');
INSERT INTO `money` VALUES ('733346', 'Alessandro_Mart', '0', '1');
INSERT INTO `money` VALUES ('734141', '', '0', '2');
INSERT INTO `money` VALUES ('734749', '', '0', '2');
INSERT INTO `money` VALUES ('735174', '', '0', '2');
INSERT INTO `money` VALUES ('736193', 'David_Maranyan', '0', '1');
INSERT INTO `money` VALUES ('736555', 'Chris_Connor', '20', '1');
INSERT INTO `money` VALUES ('736865', '', '-16', '2');
INSERT INTO `money` VALUES ('736989', '', '1000', '3');
INSERT INTO `money` VALUES ('73881', '', '584', '3');
INSERT INTO `money` VALUES ('739053', '', '0', '2');
INSERT INTO `money` VALUES ('740017', '', '0', '2');
INSERT INTO `money` VALUES ('740405', '', '0', '2');
INSERT INTO `money` VALUES ('741929', '', '0', '2');
INSERT INTO `money` VALUES ('74265', '', '0', '2');
INSERT INTO `money` VALUES ('744336', '', '0', '2');
INSERT INTO `money` VALUES ('745046', '', '0', '2');
INSERT INTO `money` VALUES ('745216', '', '0', '2');
INSERT INTO `money` VALUES ('745219', '', '0', '3');
INSERT INTO `money` VALUES ('745403', '', '0', '2');
INSERT INTO `money` VALUES ('748201', '', '0', '2');
INSERT INTO `money` VALUES ('748384', '', '0', '2');
INSERT INTO `money` VALUES ('748458', '', '584', '3');
INSERT INTO `money` VALUES ('748910', 'Fuchs_Admin', '0', '1');
INSERT INTO `money` VALUES ('749066', '', '0', '2');
INSERT INTO `money` VALUES ('751477', '', '0', '2');
INSERT INTO `money` VALUES ('751906', '', '0', '2');
INSERT INTO `money` VALUES ('752276', '', '0', '2');
INSERT INTO `money` VALUES ('752385', '', '0', '2');
INSERT INTO `money` VALUES ('753153', '', '0', '3');
INSERT INTO `money` VALUES ('754150', '', '0', '2');
INSERT INTO `money` VALUES ('755432', '', '0', '2');
INSERT INTO `money` VALUES ('75599', '', '0', '2');
INSERT INTO `money` VALUES ('757955', '', '-18', '2');
INSERT INTO `money` VALUES ('762743', '', '584', '3');
INSERT INTO `money` VALUES ('762793', 'Vladimir_Putin', '0', '1');
INSERT INTO `money` VALUES ('764615', '', '0', '2');
INSERT INTO `money` VALUES ('765247', '', '0', '2');
INSERT INTO `money` VALUES ('765312', '', '0', '2');
INSERT INTO `money` VALUES ('766275', '', '0', '1');
INSERT INTO `money` VALUES ('766865', '', '1000', '3');
INSERT INTO `money` VALUES ('766876', '', '0', '2');
INSERT INTO `money` VALUES ('769338', '', '0', '3');
INSERT INTO `money` VALUES ('769796', '', '-116', '2');
INSERT INTO `money` VALUES ('772819', '', '0', '2');
INSERT INTO `money` VALUES ('773191', '', '0', '2');
INSERT INTO `money` VALUES ('773819', '', '0', '2');
INSERT INTO `money` VALUES ('773997', '', '1000', '3');
INSERT INTO `money` VALUES ('775049', '', '1000', '3');
INSERT INTO `money` VALUES ('775256', '', '0', '2');
INSERT INTO `money` VALUES ('776690', '', '584', '3');
INSERT INTO `money` VALUES ('776722', '', '0', '3');
INSERT INTO `money` VALUES ('778266', '', '0', '2');
INSERT INTO `money` VALUES ('779744', '', '0', '2');
INSERT INTO `money` VALUES ('780764', '', '0', '2');
INSERT INTO `money` VALUES ('781268', '', '0', '1');
INSERT INTO `money` VALUES ('783793', '', '0', '2');
INSERT INTO `money` VALUES ('783856', '', '0', '2');
INSERT INTO `money` VALUES ('784564', '', '0', '2');
INSERT INTO `money` VALUES ('785102', '', '0', '2');
INSERT INTO `money` VALUES ('786594', '', '0', '2');
INSERT INTO `money` VALUES ('787103', '', '0', '2');
INSERT INTO `money` VALUES ('787644', '', '1000', '3');
INSERT INTO `money` VALUES ('788669', '', '0', '2');
INSERT INTO `money` VALUES ('788704', '', '0', '2');
INSERT INTO `money` VALUES ('789215', '', '0', '2');
INSERT INTO `money` VALUES ('789981', '', '0', '2');
INSERT INTO `money` VALUES ('791763', '', '0', '2');
INSERT INTO `money` VALUES ('792270', '', '0', '3');
INSERT INTO `money` VALUES ('7929', '', '0', '3');
INSERT INTO `money` VALUES ('793524', '', '0', '2');
INSERT INTO `money` VALUES ('794271', '', '0', '2');
INSERT INTO `money` VALUES ('794608', '', '0', '2');
INSERT INTO `money` VALUES ('794724', '', '0', '2');
INSERT INTO `money` VALUES ('794814', '', '0', '2');
INSERT INTO `money` VALUES ('794871', '', '0', '2');
INSERT INTO `money` VALUES ('795581', '', '584', '3');
INSERT INTO `money` VALUES ('797788', '', '0', '2');
INSERT INTO `money` VALUES ('797838', '', '0', '2');
INSERT INTO `money` VALUES ('797847', 'Test_Test', '0', '1');
INSERT INTO `money` VALUES ('799014', '', '0', '2');
INSERT INTO `money` VALUES ('799631', '', '1000', '3');
INSERT INTO `money` VALUES ('79964', '', '272', '2');
INSERT INTO `money` VALUES ('800434', '', '0', '3');
INSERT INTO `money` VALUES ('80197', '', '0', '2');
INSERT INTO `money` VALUES ('80233', '', '0', '2');
INSERT INTO `money` VALUES ('803498', '', '0', '2');
INSERT INTO `money` VALUES ('803918', '', '0', '2');
INSERT INTO `money` VALUES ('804284', '', '0', '3');
INSERT INTO `money` VALUES ('80498', 'Natcules_Hart', '0', '1');
INSERT INTO `money` VALUES ('807588', '', '0', '2');
INSERT INTO `money` VALUES ('807671', '', '584', '3');
INSERT INTO `money` VALUES ('808070', '', '0', '2');
INSERT INTO `money` VALUES ('80979', '', '0', '2');
INSERT INTO `money` VALUES ('810384', '', '0', '2');
INSERT INTO `money` VALUES ('811129', '', '0', '2');
INSERT INTO `money` VALUES ('811286', '', '0', '2');
INSERT INTO `money` VALUES ('811312', '', '-80', '2');
INSERT INTO `money` VALUES ('814256', '', '0', '2');
INSERT INTO `money` VALUES ('814340', '', '0', '3');
INSERT INTO `money` VALUES ('815214', '', '0', '3');
INSERT INTO `money` VALUES ('815218', '', '0', '2');
INSERT INTO `money` VALUES ('815834', '', '0', '2');
INSERT INTO `money` VALUES ('816565', '', '0', '2');
INSERT INTO `money` VALUES ('817639', '', '0', '3');
INSERT INTO `money` VALUES ('817716', '', '184', '2');
INSERT INTO `money` VALUES ('818997', '', '0', '2');
INSERT INTO `money` VALUES ('819484', '', '0', '2');
INSERT INTO `money` VALUES ('821346', '', '1000', '3');
INSERT INTO `money` VALUES ('821503', '', '0', '3');
INSERT INTO `money` VALUES ('821935', '', '0', '2');
INSERT INTO `money` VALUES ('822643', '', '0', '2');
INSERT INTO `money` VALUES ('823852', '', '0', '2');
INSERT INTO `money` VALUES ('824275', '', '0', '2');
INSERT INTO `money` VALUES ('824362', '', '1000', '3');
INSERT INTO `money` VALUES ('826465', '', '0', '2');
INSERT INTO `money` VALUES ('826774', '', '0', '2');
INSERT INTO `money` VALUES ('827915', '', '0', '2');
INSERT INTO `money` VALUES ('828262', '', '584', '3');
INSERT INTO `money` VALUES ('828907', '', '1000', '3');
INSERT INTO `money` VALUES ('830677', '', '0', '2');
INSERT INTO `money` VALUES ('8311', '', '0', '2');
INSERT INTO `money` VALUES ('834594', 'Louis_Clark', '0', '1');
INSERT INTO `money` VALUES ('834908', '', '0', '3');
INSERT INTO `money` VALUES ('834910', '', '1000', '3');
INSERT INTO `money` VALUES ('835522', '', '1000', '3');
INSERT INTO `money` VALUES ('835705', '', '0', '2');
INSERT INTO `money` VALUES ('835966', '', '0', '2');
INSERT INTO `money` VALUES ('837725', '', '0', '2');
INSERT INTO `money` VALUES ('838761', '', '1000', '3');
INSERT INTO `money` VALUES ('840252', '', '0', '2');
INSERT INTO `money` VALUES ('84075', '', '0', '2');
INSERT INTO `money` VALUES ('842316', '', '0', '3');
INSERT INTO `money` VALUES ('842607', '', '0', '2');
INSERT INTO `money` VALUES ('842771', '', '0', '2');
INSERT INTO `money` VALUES ('84364', '', '0', '2');
INSERT INTO `money` VALUES ('844283', '', '0', '2');
INSERT INTO `money` VALUES ('84486', '', '1000', '3');
INSERT INTO `money` VALUES ('845006', '', '0', '2');
INSERT INTO `money` VALUES ('845580', '', '0', '2');
INSERT INTO `money` VALUES ('845797', '', '584', '3');
INSERT INTO `money` VALUES ('846370', '', '0', '2');
INSERT INTO `money` VALUES ('84800', '', '0', '2');
INSERT INTO `money` VALUES ('849743', '', '0', '2');
INSERT INTO `money` VALUES ('850340', '', '1000', '3');
INSERT INTO `money` VALUES ('85120', '', '0', '2');
INSERT INTO `money` VALUES ('851303', '', '0', '2');
INSERT INTO `money` VALUES ('852375', '', '0', '2');
INSERT INTO `money` VALUES ('852392', '', '1000', '3');
INSERT INTO `money` VALUES ('852506', '', '0', '2');
INSERT INTO `money` VALUES ('852621', '', '-4', '2');
INSERT INTO `money` VALUES ('85481', '', '0', '1');
INSERT INTO `money` VALUES ('855142', '', '584', '3');
INSERT INTO `money` VALUES ('855877', '', '0', '2');
INSERT INTO `money` VALUES ('856482', '', '0', '2');
INSERT INTO `money` VALUES ('856558', '', '0', '2');
INSERT INTO `money` VALUES ('857063', '', '0', '3');
INSERT INTO `money` VALUES ('857367', '', '0', '2');
INSERT INTO `money` VALUES ('857655', '', '0', '2');
INSERT INTO `money` VALUES ('857730', '', '0', '2');
INSERT INTO `money` VALUES ('858783', '', '0', '3');
INSERT INTO `money` VALUES ('85909', '', '0', '2');
INSERT INTO `money` VALUES ('859593', '', '584', '3');
INSERT INTO `money` VALUES ('859707', '', '0', '2');
INSERT INTO `money` VALUES ('860051', '', '0', '2');
INSERT INTO `money` VALUES ('860056', '', '0', '2');
INSERT INTO `money` VALUES ('860649', '', '0', '2');
INSERT INTO `money` VALUES ('861033', '', '0', '2');
INSERT INTO `money` VALUES ('862248', 'Admyan_Admyanin', '6170', '1');
INSERT INTO `money` VALUES ('862433', '', '0', '3');
INSERT INTO `money` VALUES ('863034', '', '0', '2');
INSERT INTO `money` VALUES ('863501', '', '0', '2');
INSERT INTO `money` VALUES ('863756', '', '0', '2');
INSERT INTO `money` VALUES ('86459', '', '0', '2');
INSERT INTO `money` VALUES ('864608', '', '330', '2');
INSERT INTO `money` VALUES ('864756', 'Test_Penis', '260181990', '1');
INSERT INTO `money` VALUES ('864789', '', '0', '2');
INSERT INTO `money` VALUES ('865572', '', '0', '2');
INSERT INTO `money` VALUES ('86768', '', '0', '2');
INSERT INTO `money` VALUES ('867727', '', '0', '3');
INSERT INTO `money` VALUES ('868093', '', '0', '2');
INSERT INTO `money` VALUES ('868748', '', '0', '2');
INSERT INTO `money` VALUES ('870214', '', '0', '2');
INSERT INTO `money` VALUES ('87023', '', '0', '2');
INSERT INTO `money` VALUES ('873053', '', '0', '2');
INSERT INTO `money` VALUES ('873885', 'Volt_Alphatester', '91090566', '1');
INSERT INTO `money` VALUES ('875154', '', '1000', '3');
INSERT INTO `money` VALUES ('87564', 'Roman_Novan', '0', '1');
INSERT INTO `money` VALUES ('876086', '', '0', '2');
INSERT INTO `money` VALUES ('876530', '', '0', '2');
INSERT INTO `money` VALUES ('878164', '', '0', '2');
INSERT INTO `money` VALUES ('878243', '', '1000', '3');
INSERT INTO `money` VALUES ('87830', 'Fillip_Kirkorov', '0', '1');
INSERT INTO `money` VALUES ('878829', '', '0', '2');
INSERT INTO `money` VALUES ('883059', '', '0', '2');
INSERT INTO `money` VALUES ('883444', '', '0', '2');
INSERT INTO `money` VALUES ('884102', '', '0', '2');
INSERT INTO `money` VALUES ('885020', '', '1000', '3');
INSERT INTO `money` VALUES ('885072', '', '0', '2');
INSERT INTO `money` VALUES ('885739', '', '0', '2');
INSERT INTO `money` VALUES ('887573', '', '0', '2');
INSERT INTO `money` VALUES ('887619', '', '0', '3');
INSERT INTO `money` VALUES ('888268', '', '0', '2');
INSERT INTO `money` VALUES ('888270', '', '0', '2');
INSERT INTO `money` VALUES ('88847', '', '0', '2');
INSERT INTO `money` VALUES ('890393', '', '0', '2');
INSERT INTO `money` VALUES ('891677', '', '1000', '3');
INSERT INTO `money` VALUES ('891916', '', '1000', '3');
INSERT INTO `money` VALUES ('892038', '', '1000', '3');
INSERT INTO `money` VALUES ('892106', '', '0', '2');
INSERT INTO `money` VALUES ('892493', '', '0', '2');
INSERT INTO `money` VALUES ('892567', '', '0', '2');
INSERT INTO `money` VALUES ('892650', '', '0', '3');
INSERT INTO `money` VALUES ('893223', 'Frost_Jack', '500', '1');
INSERT INTO `money` VALUES ('893479', 'Jack_Ryan', '0', '1');
INSERT INTO `money` VALUES ('89437', '', '1000', '3');
INSERT INTO `money` VALUES ('895423', '', '0', '2');
INSERT INTO `money` VALUES ('895471', '', '0', '3');
INSERT INTO `money` VALUES ('896660', '', '0', '2');
INSERT INTO `money` VALUES ('896745', 'Evotrix_Evotrix', '0', '1');
INSERT INTO `money` VALUES ('898917', '', '0', '2');
INSERT INTO `money` VALUES ('900171', '', '0', '2');
INSERT INTO `money` VALUES ('900907', '', '1000', '3');
INSERT INTO `money` VALUES ('902086', '', '0', '2');
INSERT INTO `money` VALUES ('902652', '', '584', '3');
INSERT INTO `money` VALUES ('902671', '', '0', '2');
INSERT INTO `money` VALUES ('902875', '', '0', '2');
INSERT INTO `money` VALUES ('902942', '', '1000', '3');
INSERT INTO `money` VALUES ('903021', 'Simon_Salzmann', '0', '1');
INSERT INTO `money` VALUES ('90512', '', '0', '2');
INSERT INTO `money` VALUES ('905219', '', '0', '1');
INSERT INTO `money` VALUES ('905343', '', '-678', '2');
INSERT INTO `money` VALUES ('907463', '', '0', '2');
INSERT INTO `money` VALUES ('907988', '', '0', '2');
INSERT INTO `money` VALUES ('90812', '', '0', '2');
INSERT INTO `money` VALUES ('90843', '', '0', '2');
INSERT INTO `money` VALUES ('909126', '', '0', '2');
INSERT INTO `money` VALUES ('910669', '', '0', '3');
INSERT INTO `money` VALUES ('912157', '', '0', '2');
INSERT INTO `money` VALUES ('912369', '', '0', '2');
INSERT INTO `money` VALUES ('91285', '', '0', '2');
INSERT INTO `money` VALUES ('913004', '', '0', '3');
INSERT INTO `money` VALUES ('913911', '', '0', '2');
INSERT INTO `money` VALUES ('914050', '', '0', '2');
INSERT INTO `money` VALUES ('914125', '', '0', '2');
INSERT INTO `money` VALUES ('91413', '', '0', '2');
INSERT INTO `money` VALUES ('915512', '', '0', '2');
INSERT INTO `money` VALUES ('915895', '', '0', '2');
INSERT INTO `money` VALUES ('916059', '', '0', '2');
INSERT INTO `money` VALUES ('9188', '', '0', '2');
INSERT INTO `money` VALUES ('92010', '', '0', '3');
INSERT INTO `money` VALUES ('920173', 'Rikardo_Discord', '0', '1');
INSERT INTO `money` VALUES ('922026', '', '0', '2');
INSERT INTO `money` VALUES ('922450', '', '584', '3');
INSERT INTO `money` VALUES ('923129', '', '1000', '3');
INSERT INTO `money` VALUES ('925485', '', '1000', '3');
INSERT INTO `money` VALUES ('926452', '', '0', '2');
INSERT INTO `money` VALUES ('926682', '', '0', '2');
INSERT INTO `money` VALUES ('927792', '', '0', '3');
INSERT INTO `money` VALUES ('92790', '', '0', '2');
INSERT INTO `money` VALUES ('928220', '', '1000', '3');
INSERT INTO `money` VALUES ('929268', '', '584', '3');
INSERT INTO `money` VALUES ('930677', '', '1000', '3');
INSERT INTO `money` VALUES ('930946', '', '1000', '3');
INSERT INTO `money` VALUES ('931202', '', '1000', '3');
INSERT INTO `money` VALUES ('931536', '', '0', '2');
INSERT INTO `money` VALUES ('931609', '', '0', '2');
INSERT INTO `money` VALUES ('932262', '', '1000', '3');
INSERT INTO `money` VALUES ('932318', '', '0', '2');
INSERT INTO `money` VALUES ('93345', '', '0', '3');
INSERT INTO `money` VALUES ('933616', '', '0', '2');
INSERT INTO `money` VALUES ('933824', '', '0', '2');
INSERT INTO `money` VALUES ('934310', '', '0', '2');
INSERT INTO `money` VALUES ('934645', '', '0', '2');
INSERT INTO `money` VALUES ('935306', '', '0', '2');
INSERT INTO `money` VALUES ('935555', '', '1000', '3');
INSERT INTO `money` VALUES ('936546', '', '0', '2');
INSERT INTO `money` VALUES ('938111', '', '0', '2');
INSERT INTO `money` VALUES ('942014', '', '0', '2');
INSERT INTO `money` VALUES ('942102', '', '0', '2');
INSERT INTO `money` VALUES ('945890', '', '1000', '3');
INSERT INTO `money` VALUES ('947258', '', '0', '2');
INSERT INTO `money` VALUES ('950155', '', '330', '2');
INSERT INTO `money` VALUES ('953533', '', '0', '2');
INSERT INTO `money` VALUES ('954604', '', '-80', '2');
INSERT INTO `money` VALUES ('955313', '', '2122', '3');
INSERT INTO `money` VALUES ('955380', '', '0', '2');
INSERT INTO `money` VALUES ('957483', '', '0', '3');
INSERT INTO `money` VALUES ('957526', '', '0', '2');
INSERT INTO `money` VALUES ('957658', '', '0', '2');
INSERT INTO `money` VALUES ('957832', '', '0', '1');
INSERT INTO `money` VALUES ('958272', '', '1000', '3');
INSERT INTO `money` VALUES ('959886', '', '0', '2');
INSERT INTO `money` VALUES ('962342', '', '0', '2');
INSERT INTO `money` VALUES ('963008', '', '0', '2');
INSERT INTO `money` VALUES ('963571', '', '0', '2');
INSERT INTO `money` VALUES ('964428', '', '1000', '3');
INSERT INTO `money` VALUES ('964491', '', '0', '2');
INSERT INTO `money` VALUES ('964690', '', '0', '2');
INSERT INTO `money` VALUES ('964869', '', '0', '2');
INSERT INTO `money` VALUES ('964885', '', '0', '3');
INSERT INTO `money` VALUES ('967814', '', '0', '2');
INSERT INTO `money` VALUES ('96826', '', '0', '2');
INSERT INTO `money` VALUES ('968602', '', '1000', '3');
INSERT INTO `money` VALUES ('968918', '', '1000', '3');
INSERT INTO `money` VALUES ('969793', '', '0', '2');
INSERT INTO `money` VALUES ('970199', '', '1000', '3');
INSERT INTO `money` VALUES ('972606', '', '1000', '3');
INSERT INTO `money` VALUES ('973273', '', '0', '2');
INSERT INTO `money` VALUES ('974819', '', '0', '2');
INSERT INTO `money` VALUES ('97513', '', '0', '2');
INSERT INTO `money` VALUES ('975718', '', '0', '3');
INSERT INTO `money` VALUES ('976341', '', '0', '2');
INSERT INTO `money` VALUES ('976999', '', '0', '2');
INSERT INTO `money` VALUES ('977467', '', '0', '2');
INSERT INTO `money` VALUES ('977859', '', '584', '3');
INSERT INTO `money` VALUES ('981245', '', '0', '2');
INSERT INTO `money` VALUES ('98128', '', '0', '2');
INSERT INTO `money` VALUES ('981584', '', '0', '2');
INSERT INTO `money` VALUES ('981695', '', '0', '2');
INSERT INTO `money` VALUES ('985033', '', '0', '2');
INSERT INTO `money` VALUES ('985135', '', '0', '2');
INSERT INTO `money` VALUES ('98659', '', '0', '2');
INSERT INTO `money` VALUES ('987644', '', '0', '2');
INSERT INTO `money` VALUES ('987905', '', '0', '2');
INSERT INTO `money` VALUES ('988071', '', '0', '2');
INSERT INTO `money` VALUES ('988868', '', '0', '2');
INSERT INTO `money` VALUES ('990347', '', '1000', '3');
INSERT INTO `money` VALUES ('991618', '', '0', '2');
INSERT INTO `money` VALUES ('992120', '', '0', '2');
INSERT INTO `money` VALUES ('993410', '', '0', '2');
INSERT INTO `money` VALUES ('993735', '', '0', '2');
INSERT INTO `money` VALUES ('99380', '', '-80', '2');
INSERT INTO `money` VALUES ('994518', '', '0', '2');
INSERT INTO `money` VALUES ('995227', '', '0', '3');
INSERT INTO `money` VALUES ('995566', '', '0', '2');
INSERT INTO `money` VALUES ('996', '', '1000', '3');
INSERT INTO `money` VALUES ('996891', '', '0', '3');
INSERT INTO `money` VALUES ('99790', '', '0', '2');

-- ----------------------------
-- Table structure for othervehicles
-- ----------------------------
DROP TABLE IF EXISTS `othervehicles`;
CREATE TABLE `othervehicles`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `type` tinyint NOT NULL,
  `number` varchar(25) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `model` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `position` varchar(256) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `rotation` varchar(256) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `color1` int NOT NULL,
  `color2` int NOT NULL,
  `price` int NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 332 CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of othervehicles
-- ----------------------------
INSERT INTO `othervehicles` VALUES (1, 0, 'rent', 'cruiser', '{\"x\":-844.1944,\"y\":-1321.1344,\"z\":5.08096}', '{\"x\":-4.00849628,\"y\":-6.117489,\"z\":140.030212}', 70, 42, 50);
INSERT INTO `othervehicles` VALUES (2, 0, 'rent', 'cruiser', '{\"x\":-843.802734,\"y\":-1322.31348,\"z\":5.079115}', '{\"x\":-3.97063756,\"y\":-7.57881832,\"z\":142.738037}', 70, 42, 50);
INSERT INTO `othervehicles` VALUES (3, 0, 'rent', 'cruiser', '{\"x\":-843.319336,\"y\":-1323.318,\"z\":5.08051634}', '{\"x\":-3.55976367,\"y\":-6.959935,\"z\":145.080017}', 70, 42, 50);
INSERT INTO `othervehicles` VALUES (4, 0, 'rent', 'cruiser', '{\"x\":-842.9949,\"y\":-1324.7677,\"z\":5.07761955}', '{\"x\":-4.270945,\"y\":-8.084972,\"z\":144.118011}', 70, 42, 50);
INSERT INTO `othervehicles` VALUES (5, 0, 'rent', 'cruiser', '{\"x\":-842.5004,\"y\":-1326.37952,\"z\":5.080857}', '{\"x\":-4.394575,\"y\":-7.39102364,\"z\":145.085663}', 70, 42, 50);
INSERT INTO `othervehicles` VALUES (6, 0, 'rent', 'cruiser', '{\"x\":-841.9387,\"y\":-1327.788,\"z\":5.078144}', '{\"x\":-4.12077761,\"y\":-7.419406,\"z\":143.3158}', 70, 42, 50);
INSERT INTO `othervehicles` VALUES (7, 0, 'rent', 'cruiser', '{\"x\":-841.3492,\"y\":-1329.28845,\"z\":5.080419}', '{\"x\":-4.77372026,\"y\":-7.04710531,\"z\":140.932861}', 70, 42, 50);
INSERT INTO `othervehicles` VALUES (8, 0, 'rent', 'cruiser', '{\"x\":-840.797852,\"y\":-1330.7854,\"z\":5.079022}', '{\"x\":-5.65174532,\"y\":-7.504999,\"z\":137.929871}', 70, 42, 50);
INSERT INTO `othervehicles` VALUES (9, 0, 'rent', 'cruiser', '{\"x\":-840.3169,\"y\":-1332.182,\"z\":5.080368}', '{\"x\":-4.687352,\"y\":-7.48711872,\"z\":143.705872}', 70, 42, 50);
INSERT INTO `othervehicles` VALUES (10, 0, 'rent', 'cruiser', '{\"x\":-839.7424,\"y\":-1333.6,\"z\":5.08416939}', '{\"x\":-3.68514752,\"y\":-5.53667259,\"z\":141.629211}', 70, 42, 50);
INSERT INTO `othervehicles` VALUES (11, 0, 'rent', 'cruiser', '{\"x\":-841.185,\"y\":-1319.8728,\"z\":5.08000135}', '{\"x\":8.08027649,\"y\":-0.5500353,\"z\":259.203278}', 70, 42, 50);
INSERT INTO `othervehicles` VALUES (12, 0, 'rent', 'cruiser', '{\"x\":-840.6913,\"y\":-1321.163,\"z\":5.079195}', '{\"x\":8.745192,\"y\":-0.2514499,\"z\":259.067566}', 70, 42, 50);
INSERT INTO `othervehicles` VALUES (13, 0, 'rent', 'cruiser', '{\"x\":-840.1486,\"y\":-1322.51965,\"z\":5.080748}', '{\"x\":8.689598,\"y\":-0.9050389,\"z\":258.594147}', 70, 42, 50);
INSERT INTO `othervehicles` VALUES (14, 0, 'rent', 'cruiser', '{\"x\":-839.6829,\"y\":-1323.84424,\"z\":5.07808542}', '{\"x\":7.98438263,\"y\":-0.4792574,\"z\":257.437225}', 70, 42, 50);
INSERT INTO `othervehicles` VALUES (15, 0, 'rent', 'cruiser', '{\"x\":-839.1949,\"y\":-1325.23523,\"z\":5.078613}', '{\"x\":8.797824,\"y\":-0.757986546,\"z\":259.115936}', 70, 42, 50);
INSERT INTO `othervehicles` VALUES (16, 0, 'rent', 'cruiser', '{\"x\":-838.8531,\"y\":-1326.42651,\"z\":5.07964659}', '{\"x\":7.43445539,\"y\":0.00478636427,\"z\":258.536926}', 70, 42, 50);
INSERT INTO `othervehicles` VALUES (17, 0, 'rent', 'cruiser', '{\"x\":-838.3938,\"y\":-1327.52283,\"z\":5.080911}', '{\"x\":8.109847,\"y\":-0.703625858,\"z\":258.81958}', 70, 42, 50);
INSERT INTO `othervehicles` VALUES (18, 0, 'rent', 'cruiser', '{\"x\":-838.003052,\"y\":-1328.54626,\"z\":5.07854271}', '{\"x\":8.35567,\"y\":-0.5755739,\"z\":256.3075}', 70, 42, 50);
INSERT INTO `othervehicles` VALUES (19, 0, 'rent', 'cruiser', '{\"x\":-837.62616,\"y\":-1329.75,\"z\":5.083466}', '{\"x\":6.94939,\"y\":-1.76625657,\"z\":251.189056}', 70, 42, 50);
INSERT INTO `othervehicles` VALUES (20, 0, 'rent', 'cruiser', '{\"x\":-836.962463,\"y\":-1330.995,\"z\":5.081229}', '{\"x\":7.90130568,\"y\":-2.06780481,\"z\":250.909546}', 70, 42, 50);
INSERT INTO `othervehicles` VALUES (37, 8, 'AutoMechanic1', 'Bison2', '{\"x\":485.582733,\"y\":-1279.30334,\"z\":30.0668449}', '{\"x\":-1.48978257,\"y\":0.156541124,\"z\":60.9873047}', 88, 88, 100);
INSERT INTO `othervehicles` VALUES (38, 8, 'AutoMechanic2', 'Bison2', '{\"x\":474.0387,\"y\":-1283.839,\"z\":30.0816975}', '{\"x\":-0.301389724,\"y\":-0.28525582,\"z\":302.63385}', 88, 88, 100);
INSERT INTO `othervehicles` VALUES (39, 8, 'AutoMechanic3', 'Bison2', '{\"x\":474.077026,\"y\":-1279.00269,\"z\":30.0822887}', '{\"x\":-0.4086137,\"y\":-0.373357,\"z\":310.1617}', 88, 88, 100);
INSERT INTO `othervehicles` VALUES (40, 3, 'Taxi1', 'g63', '{\"x\":897.388367,\"y\":-183.329437,\"z\":74.3744659}', '{\"x\":-0.012443644,\"y\":1.83493483,\"z\":238.851959}', 255, 0, 100);
INSERT INTO `othervehicles` VALUES (41, 3, 'Taxi2', 'lc200', '{\"x\":899.229553,\"y\":-180.237885,\"z\":74.43087}', '{\"x\":0.3705143,\"y\":2.73933721,\"z\":238.4718}', 255, 0, 100);
INSERT INTO `othervehicles` VALUES (42, 3, 'Taxi3', 'Taxi', '{\"x\":903.396667,\"y\":-191.790634,\"z\":74.40568}', '{\"x\":0.252618581,\"y\":0.0996404439,\"z\":57.8040466}', 255, 0, 100);
INSERT INTO `othervehicles` VALUES (43, 3, 'Taxi4', 'Taxi', '{\"x\":905.180542,\"y\":-189.088531,\"z\":74.4464}', '{\"x\":-1.31885517,\"y\":2.2723906,\"z\":57.31079}', 255, 0, 100);
INSERT INTO `othervehicles` VALUES (44, 3, 'Taxi5', 'Taxi', '{\"x\":906.994568,\"y\":-186.408752,\"z\":74.63495}', '{\"x\":-1.97620273,\"y\":2.59219265,\"z\":57.6801147}', 255, 0, 100);
INSERT INTO `othervehicles` VALUES (45, 3, 'Taxi6', 'Taxi', '{\"x\":908.7,\"y\":-183.544525,\"z\":74.76126}', '{\"x\":-1.24403143,\"y\":0.287140846,\"z\":57.13156}', 255, 0, 100);
INSERT INTO `othervehicles` VALUES (46, 3, 'Taxi7', 'Taxi', '{\"x\":920.8526,\"y\":-163.593,\"z\":75.4308243}', '{\"x\":-0.833465636,\"y\":1.88155913,\"z\":100.359314}', 255, 0, 100);
INSERT INTO `othervehicles` VALUES (47, 3, 'Taxi8', 'Taxi', '{\"x\":918.629944,\"y\":-167.255112,\"z\":75.23791}', '{\"x\":-1.91875553,\"y\":3.46611857,\"z\":101.3515}', 255, 0, 100);
INSERT INTO `othervehicles` VALUES (48, 3, 'Taxi9', 'Taxi', '{\"x\":916.5947,\"y\":-170.742188,\"z\":75.05742}', '{\"x\":-0.8125094,\"y\":3.784994,\"z\":100.261353}', 255, 0, 100);
INSERT INTO `othervehicles` VALUES (49, 3, 'Taxi10', 'Taxi', '{\"x\":913.804443,\"y\":-159.476,\"z\":75.41494}', '{\"x\":-4.349511,\"y\":2.71827626,\"z\":193.595215}', 255, 0, 100);
INSERT INTO `othervehicles` VALUES (50, 3, 'Taxi11', 'Taxi', '{\"x\":911.6057,\"y\":-163.585541,\"z\":74.97877}', '{\"x\":-3.56606269,\"y\":4.70030165,\"z\":194.053879}', 255, 0, 100);
INSERT INTO `othervehicles` VALUES (51, 3, 'Taxi12', 'Taxi', '{\"x\":1968.85571,\"y\":3772.61987,\"z\":32.80019}', '{\"x\":-0.00622653775,\"y\":-0.04684552,\"z\":118.886505}', 255, 0, 100);
INSERT INTO `othervehicles` VALUES (52, 3, 'Taxi13', 'Taxi', '{\"x\":1967.60437,\"y\":3775.11084,\"z\":32.8018951}', '{\"x\":0.012439806,\"y\":-0.101037912,\"z\":120.22876}', 255, 0, 100);
INSERT INTO `othervehicles` VALUES (53, 3, 'Taxi14', 'Taxi', '{\"x\":1965.71973,\"y\":3778.65137,\"z\":32.80533}', '{\"x\":0.006334837,\"y\":-0.08994107,\"z\":118.66333}', 255, 0, 100);
INSERT INTO `othervehicles` VALUES (54, 3, 'Taxi15', 'Taxi', '{\"x\":1963.19226,\"y\":3766.23633,\"z\":32.8027267}', '{\"x\":-0.0429883,\"y\":-0.06385263,\"z\":30.8551941}', 255, 0, 100);
INSERT INTO `othervehicles` VALUES (55, 3, 'Taxi16', 'Taxi', '{\"x\":1959.79736,\"y\":3764.25415,\"z\":32.80459}', '{\"x\":-0.004975404,\"y\":-0.062801145,\"z\":30.35913}', 255, 0, 100);
INSERT INTO `othervehicles` VALUES (56, 3, 'Taxi17', 'Taxi', '{\"x\":1956.32336,\"y\":3762.2168,\"z\":32.8067627}', '{\"x\":-0.00589618925,\"y\":-0.07380671,\"z\":30.9676514}', 255, 0, 100);
INSERT INTO `othervehicles` VALUES (57, 3, 'Taxi18', 'Taxi', '{\"x\":1953.295,\"y\":3760.609,\"z\":32.80915}', '{\"x\":-0.0312475022,\"y\":-0.0731073841,\"z\":29.2828674}', 255, 0, 100);
INSERT INTO `othervehicles` VALUES (58, 3, 'Taxi19', 'Taxi', '{\"x\":1949.79468,\"y\":3758.61523,\"z\":32.81167}', '{\"x\":-0.06915528,\"y\":-0.0793456659,\"z\":29.7415466}', 255, 0, 100);
INSERT INTO `othervehicles` VALUES (59, 3, 'Taxi20', 'Taxi', '{\"x\":1781.031,\"y\":4583.871,\"z\":38.16792}', '{\"x\":-1.703033,\"y\":-1.97973716,\"z\":6.86053467}', 255, 0, 100);
INSERT INTO `othervehicles` VALUES (60, 3, 'Taxi21', 'Taxi', '{\"x\":1784.92847,\"y\":4584.317,\"z\":38.0887375}', '{\"x\":-3.537191,\"y\":-1.58987772,\"z\":2.73522949}', 255, 0, 100);
INSERT INTO `othervehicles` VALUES (61, 3, 'Taxi22', 'Taxi', '{\"x\":1789.51672,\"y\":4585.058,\"z\":37.97475}', '{\"x\":-4.0977807,\"y\":-2.86091471,\"z\":3.89215088}', 255, 0, 100);
INSERT INTO `othervehicles` VALUES (62, 3, 'Taxi23', 'Taxi', '{\"x\":1793.59875,\"y\":4585.00342,\"z\":37.7647438}', '{\"x\":-5.22894764,\"y\":-2.451439,\"z\":4.01269531}', 255, 0, 100);
INSERT INTO `othervehicles` VALUES (63, 3, 'Taxi24', 'Taxi', '{\"x\":1797.5459,\"y\":4585.622,\"z\":37.69883}', '{\"x\":-8.033358,\"y\":-1.94962525,\"z\":3.41564941}', 255, 0, 100);
INSERT INTO `othervehicles` VALUES (64, 3, 'Taxi25', 'Taxi', '{\"x\":1801.38208,\"y\":4585.971,\"z\":37.5613976}', '{\"x\":-9.869283,\"y\":-3.65801978,\"z\":3.4699707}', 255, 0, 100);
INSERT INTO `othervehicles` VALUES (65, 0, 'Faggio1', 'Faggio2', '{\"x\":1807.07056,\"y\":4595.165,\"z\":37.8848953}', '{\"x\":-0.411622167,\"y\":-10.6783361,\"z\":183.724365}', 255, 0, 100);
INSERT INTO `othervehicles` VALUES (66, 0, 'Faggio2', 'Faggio2', '{\"x\":1811.0061,\"y\":4595.86963,\"z\":37.833374}', '{\"x\":-0.785446167,\"y\":-9.208833,\"z\":189.662781}', 255, 0, 100);
INSERT INTO `othervehicles` VALUES (67, 0, 'Faggio3', 'Faggio2', '{\"x\":1814.42212,\"y\":4602.4126,\"z\":38.028038}', '{\"x\":-0.436489582,\"y\":-9.635398,\"z\":181.465485}', 100, 0, 100);
INSERT INTO `othervehicles` VALUES (68, 0, 'Faggio4', 'Faggio2', '{\"x\":1818.01123,\"y\":4602.56836,\"z\":37.7609}', '{\"x\":-1.31310964,\"y\":-11.6954908,\"z\":181.9882}', 100, 0, 100);
INSERT INTO `othervehicles` VALUES (79, 6, 'Trucker1', 'Packer', '{\"x\":-2191.55542,\"y\":4264.191,\"z\":49.6402931}', '{\"x\":-1.04965568,\"y\":3.7486918,\"z\":327.906372}', 1, 0, 0);
INSERT INTO `othervehicles` VALUES (80, 6, 'Trucker2', 'Packer', '{\"x\":-2197.687,\"y\":4268.308,\"z\":49.4834442}', '{\"x\":-1.91134632,\"y\":2.10574555,\"z\":329.156036}', 1, 0, 0);
INSERT INTO `othervehicles` VALUES (81, 6, 'Trucker3', 'Packer', '{\"x\":-2195.45142,\"y\":4246.07861,\"z\":48.9866867}', '{\"x\":1.70401943,\"y\":0.853427649,\"z\":216.889252}', 1, 0, 0);
INSERT INTO `othervehicles` VALUES (82, 6, 'Trucker4', 'Packer', '{\"x\":-2206.03638,\"y\":4248.81152,\"z\":48.7085762}', '{\"x\":2.15488338,\"y\":2.63953257,\"z\":217.0375}', 1, 0, 0);
INSERT INTO `othervehicles` VALUES (83, 6, 'Trucker5', 'Packer', '{\"x\":-2211.476,\"y\":4245.26025,\"z\":48.6099739}', '{\"x\":2.018111,\"y\":2.23651361,\"z\":220.424713}', 1, 0, 0);
INSERT INTO `othervehicles` VALUES (84, 6, 'Trucker6', 'Packer', '{\"x\":-2214.97656,\"y\":4239.744,\"z\":48.53418}', '{\"x\":0.121423572,\"y\":3.767467,\"z\":217.840332}', 1, 0, 0);
INSERT INTO `othervehicles` VALUES (85, 6, 'Trucker7', 'Packer', '{\"x\":-2218.58838,\"y\":4234.16162,\"z\":48.3767738}', '{\"x\":0.6610417,\"y\":3.643266,\"z\":218.672668}', 1, 0, 0);
INSERT INTO `othervehicles` VALUES (86, 6, 'Trucker8', 'Packer', '{\"x\":-2223.924,\"y\":4231.04736,\"z\":48.1095543}', '{\"x\":1.25295985,\"y\":3.14926839,\"z\":219.093216}', 1, 0, 0);
INSERT INTO `othervehicles` VALUES (87, 6, 'Trucker9', 'Packer', '{\"x\":588.3336,\"y\":-3037.88281,\"z\":7.15359735}', '{\"x\":0.3092742,\"y\":-0.05034604,\"z\":359.484344}', 1, 0, 0);
INSERT INTO `othervehicles` VALUES (88, 6, 'Trucker10', 'Packer', '{\"x\":581.282043,\"y\":-3037.53979,\"z\":7.153557}', '{\"x\":0.330842942,\"y\":0.004739575,\"z\":359.272}', 1, 0, 0);
INSERT INTO `othervehicles` VALUES (89, 6, 'Trucker11', 'Packer', '{\"x\":574.4649,\"y\":-3037.787,\"z\":7.1533637}', '{\"x\":0.319341123,\"y\":-0.02917519,\"z\":358.6705}', 1, 0, 0);
INSERT INTO `othervehicles` VALUES (90, 6, 'Trucker12', 'Packer', '{\"x\":568.0455,\"y\":-3037.80713,\"z\":7.154893}', '{\"x\":0.325739026,\"y\":-0.06158014,\"z\":0.104705811}', 1, 0, 0);
INSERT INTO `othervehicles` VALUES (91, 6, 'Trucker13', 'Packer', '{\"x\":561.3156,\"y\":-3038.04248,\"z\":7.15316868}', '{\"x\":0.404813,\"y\":-0.0632859245,\"z\":358.991425}', 1, 0, 0);
INSERT INTO `othervehicles` VALUES (92, 6, 'Trucker14', 'Packer', '{\"x\":554.840332,\"y\":-3037.89673,\"z\":7.154951}', '{\"x\":0.338403583,\"y\":-0.0481502563,\"z\":359.5388}', 1, 0, 0);
INSERT INTO `othervehicles` VALUES (93, 6, 'Trucker15', 'Packer', '{\"x\":516.944,\"y\":-3053.38916,\"z\":7.15395975}', '{\"x\":-0.3999805,\"y\":0.13048242,\"z\":180.061646}', 1, 0, 0);
INSERT INTO `othervehicles` VALUES (94, 6, 'Trucker16', 'Packer', '{\"x\":509.71933,\"y\":-3053.54688,\"z\":7.153177}', '{\"x\":-0.3425616,\"y\":-0.131781489,\"z\":177.352112}', 1, 0, 0);
INSERT INTO `othervehicles` VALUES (95, 6, 'Trucker17', 'Packer', '{\"x\":543.172241,\"y\":-3052.49365,\"z\":7.15371}', '{\"x\":-0.3669652,\"y\":0.07903574,\"z\":181.977676}', 1, 0, 0);
INSERT INTO `othervehicles` VALUES (96, 6, 'Trucker18', 'Packer', '{\"x\":321.2908,\"y\":3405.94653,\"z\":37.8232765}', '{\"x\":0.175822139,\"y\":-0.452296078,\"z\":255.104828}', 1, 0, 0);
INSERT INTO `othervehicles` VALUES (97, 6, 'Trucker19', 'Packer', '{\"x\":323.7081,\"y\":3413.975,\"z\":37.7560577}', '{\"x\":0.393859535,\"y\":-0.655415833,\"z\":255.209991}', 1, 0, 0);
INSERT INTO `othervehicles` VALUES (98, 6, 'Trucker20', 'Packer', '{\"x\":325.991272,\"y\":3421.69263,\"z\":37.63206}', '{\"x\":0.900526,\"y\":-1.01001966,\"z\":255.583527}', 1, 0, 0);
INSERT INTO `othervehicles` VALUES (99, 6, 'Trucker21', 'Packer', '{\"x\":339.676453,\"y\":3412.384,\"z\":37.7087059}', '{\"x\":1.70152831,\"y\":-0.7524773,\"z\":49.27304}', 1, 0, 0);
INSERT INTO `othervehicles` VALUES (100, 6, 'Trucker22', 'Packer', '{\"x\":344.67215,\"y\":3415.56445,\"z\":37.5891151}', '{\"x\":1.74646962,\"y\":-0.1522889,\"z\":48.289032}', 1, 0, 0);
INSERT INTO `othervehicles` VALUES (101, 6, 'Trucker23', 'Packer', '{\"x\":349.402832,\"y\":3416.42114,\"z\":37.5282555}', '{\"x\":2.08998084,\"y\":-0.226286247,\"z\":48.6077271}', 1, 0, 0);
INSERT INTO `othervehicles` VALUES (102, 6, 'Trucker24', 'Packer', '{\"x\":351.6971,\"y\":3418.95386,\"z\":37.4199066}', '{\"x\":2.52936316,\"y\":-0.469010949,\"z\":48.91458}', 1, 0, 0);
INSERT INTO `othervehicles` VALUES (103, 6, 'Trucker25', 'Packer', '{\"x\":357.451,\"y\":3420.8728,\"z\":37.27037}', '{\"x\":2.92233372,\"y\":-0.425912976,\"z\":55.1236267}', 1, 0, 0);
INSERT INTO `othervehicles` VALUES (104, 4, 'Bus1', 'Coach', '{\"x\":-2163.0393,\"y\":-418.6403,\"z\":14.70599}', '{\"x\":-0.41483918,\"y\":-0.28908786,\"z\":23.558035}', 1, 0, 150);
INSERT INTO `othervehicles` VALUES (105, 4, 'Bus2', 'Coach', '{\"x\":-2157.3782,\"y\":-415.2895,\"z\":14.718211}', '{\"x\":-0.23362397,\"y\":0.042555515,\"z\":31.379574}', 1, 0, 150);
INSERT INTO `othervehicles` VALUES (106, 4, 'Bus3', 'Coach', '{\"x\":-2152.0908,\"y\":-411.8091,\"z\":14.702844}', '{\"x\":-0.11958276,\"y\":0.21737152,\"z\":37.93961}', 1, 0, 150);
INSERT INTO `othervehicles` VALUES (107, 4, 'Bus4', 'Coach', '{\"x\":-2145.5115,\"y\":-405.21005,\"z\":14.665874}', '{\"x\":-0.1803301,\"y\":0.31062773,\"z\":41.823326}', 1, 0, 150);
INSERT INTO `othervehicles` VALUES (108, 4, 'Bus5', 'Coach', '{\"x\":-2140.8728,\"y\":-401.14655,\"z\":14.623959}', '{\"x\":-0.15649724,\"y\":0.31475368,\"z\":49.587845}', 1, 0, 150);
INSERT INTO `othervehicles` VALUES (109, 4, 'Bus6', 'Coach', '{\"x\":-2136.705,\"y\":-396.8573,\"z\":14.570805}', '{\"x\":-0.11637041,\"y\":0.65762395,\"z\":52.00448}', 1, 0, 150);
INSERT INTO `othervehicles` VALUES (112, 7, 'Collector1', 'Stockade', '{\"x\":-154.926819,\"y\":6356.911,\"z\":32.1005249}', '{\"x\":0.162521288,\"y\":-0.176660031,\"z\":227.374039}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (113, 7, 'Collector2', 'Stockade', '{\"x\":-152.299438,\"y\":6359.64453,\"z\":32.09771}', '{\"x\":-0.0461428352,\"y\":0.120323732,\"z\":225.1862}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (114, 7, 'Collector3', 'Stockade', '{\"x\":-149.808319,\"y\":6362.229,\"z\":32.10279}', '{\"x\":-0.110519849,\"y\":-0.298514068,\"z\":224.665085}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (115, 7, 'Collector4', 'Stockade', '{\"x\":-140.633575,\"y\":6345.857,\"z\":32.0955353}', '{\"x\":0.0277665071,\"y\":-0.00358198956,\"z\":44.6865234}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (116, 7, 'Collector5', 'Stockade', '{\"x\":-136.789581,\"y\":6347.165,\"z\":32.09828}', '{\"x\":-0.145547464,\"y\":-0.1639286,\"z\":45.2725525}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (117, 7, 'Collector6', 'Stockade', '{\"x\":-134.43103,\"y\":6349.55029,\"z\":32.1011238}', '{\"x\":0.003572349,\"y\":-0.1238485,\"z\":47.0074463}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (118, 7, 'Collector7', 'Stockade', '{\"x\":-136.83461,\"y\":6356.91162,\"z\":32.0962448}', '{\"x\":-0.0275422819,\"y\":0.0220229775,\"z\":224.550079}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (119, 7, 'Collector8', 'Stockade', '{\"x\":-1499.03943,\"y\":-510.689636,\"z\":33.4140968}', '{\"x\":0.0764982551,\"y\":-0.0484641232,\"z\":214.098862}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (120, 7, 'Collector9', 'Stockade', '{\"x\":-1494.6416,\"y\":-508.3092,\"z\":33.4138374}', '{\"x\":-0.191771075,\"y\":0.2592091,\"z\":214.681091}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (121, 7, 'Collector10', 'Stockade', '{\"x\":-1489.86023,\"y\":-504.220581,\"z\":33.4131546}', '{\"x\":0.0399361253,\"y\":0.0953535,\"z\":212.66362}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (122, 7, 'Collector11', 'Stockade', '{\"x\":-1484.03259,\"y\":-500.99173,\"z\":33.41321}', '{\"x\":0.007696443,\"y\":0.1439063,\"z\":213.324753}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (123, 7, 'Collector12', 'Stockade', '{\"x\":-1479.42639,\"y\":-497.575623,\"z\":33.41342}', '{\"x\":0.053416688,\"y\":0.0952896252,\"z\":212.134171}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (124, 7, 'Collector13', 'Stockade', '{\"x\":-1474.89392,\"y\":-493.582764,\"z\":33.41332}', '{\"x\":0.0535697937,\"y\":0.107037954,\"z\":212.9091}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (125, 7, 'Collector14', 'Stockade', '{\"x\":-1493.3418,\"y\":-524.314148,\"z\":33.413166}', '{\"x\":-0.09787964,\"y\":-0.137130529,\"z\":33.4915466}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (126, 7, 'Collector15', 'Stockade', '{\"x\":-1488.56384,\"y\":-520.8915,\"z\":33.4133949}', '{\"x\":-0.0841272548,\"y\":-0.110411756,\"z\":33.3035278}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (127, 7, 'Collector16', 'Stockade', '{\"x\":-1485.03552,\"y\":-517.3563,\"z\":33.4129028}', '{\"x\":-0.0470654927,\"y\":-0.04184341,\"z\":35.06198}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (128, 7, 'Collector17', 'Stockade', '{\"x\":-1480.68323,\"y\":-512.4451,\"z\":33.4148979}', '{\"x\":-0.156427547,\"y\":0.190794647,\"z\":33.1499329}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (129, 7, 'Collector18', 'Stockade', '{\"x\":-1475.5293,\"y\":-509.091675,\"z\":33.4134178}', '{\"x\":-0.111730404,\"y\":-0.06243464,\"z\":31.8569336}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (130, 7, 'Collector19', 'Stockade', '{\"x\":-1470.15417,\"y\":-505.841644,\"z\":33.4132729}', '{\"x\":-0.1240672,\"y\":0.005834359,\"z\":34.70523}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (131, 7, 'Collector20', 'Stockade', '{\"x\":-1465.9198,\"y\":-501.975067,\"z\":33.41399}', '{\"x\":-0.151278481,\"y\":0.223418072,\"z\":34.6671753}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (132, 7, 'Collector21', 'Stockade', '{\"x\":871.9234,\"y\":-1253.02136,\"z\":27.0680943}', '{\"x\":0.707915664,\"y\":-1.359446,\"z\":37.8200073}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (133, 7, 'Collector22', 'Stockade', '{\"x\":880.306946,\"y\":-1256.379,\"z\":26.9661217}', '{\"x\":3.379768,\"y\":-2.94718575,\"z\":37.1398926}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (134, 7, 'Collector23', 'Stockade', '{\"x\":885.0839,\"y\":-1253.69373,\"z\":26.7360573}', '{\"x\":0.553115845,\"y\":-1.64279151,\"z\":37.6706238}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (135, 7, 'Collector24', 'Stockade', '{\"x\":893.685852,\"y\":-1255.41284,\"z\":26.47813}', '{\"x\":0.6596476,\"y\":-1.90148735,\"z\":40.8482666}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (136, 7, 'Collector25', 'Stockade', '{\"x\":862.695068,\"y\":-1244.62085,\"z\":27.1263485}', '{\"x\":0.9053199,\"y\":-0.762982368,\"z\":221.236938}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (137, 7, 'Collector26', 'Stockade', '{\"x\":844.071045,\"y\":-1224.47974,\"z\":26.70138}', '{\"x\":1.87908113,\"y\":0.13136898,\"z\":37.9768677}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (138, 7, 'Collector27', 'Stockade', '{\"x\":848.664551,\"y\":-1224.91626,\"z\":26.75021}', '{\"x\":1.30692661,\"y\":0.5000823,\"z\":34.0383}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (139, 7, 'Collector28', 'Stockade', '{\"x\":852.9279,\"y\":-1223.0304,\"z\":26.7292881}', '{\"x\":1.72216547,\"y\":0.6053027,\"z\":25.7286987}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (140, 7, 'Collector29', 'Stockade', '{\"x\":858.6562,\"y\":-1226.37415,\"z\":26.8367672}', '{\"x\":1.51666415,\"y\":-0.542022347,\"z\":22.6694946}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (141, 7, 'Collector30', 'Stockade', '{\"x\":863.43634,\"y\":-1223.29,\"z\":26.73632}', '{\"x\":1.65737617,\"y\":-1.45998621,\"z\":26.62915}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (142, 7, 'Collector31', 'Stockade', '{\"x\":868.727234,\"y\":-1222.90637,\"z\":26.5569286}', '{\"x\":1.81207287,\"y\":-2.167034,\"z\":18.71811}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (143, 7, 'Collector32', 'Stockade', '{\"x\":873.0454,\"y\":-1222.25134,\"z\":26.4114914}', '{\"x\":1.172196,\"y\":-1.958075,\"z\":21.310791}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (144, 7, 'Collector33', 'Stockade', '{\"x\":926.227661,\"y\":-1253.187,\"z\":26.092289}', '{\"x\":-0.0181671474,\"y\":-0.0167957563,\"z\":34.71106}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (145, 7, 'Collector34', 'Stockade', '{\"x\":937.5102,\"y\":-1243.95154,\"z\":26.25003}', '{\"x\":0.402142227,\"y\":-0.9052662,\"z\":33.1820068}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (146, 7, 'Collector35', 'Stockade', '{\"x\":936.380859,\"y\":-1234.95435,\"z\":26.210165}', '{\"x\":-0.7428039,\"y\":-0.0135916444,\"z\":35.0440063}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (147, 7, 'Collector36', 'Stockade', '{\"x\":942.243,\"y\":-1230.34888,\"z\":26.2655678}', '{\"x\":-0.219437972,\"y\":0.02275397,\"z\":36.3935852}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (148, 7, 'Collector37', 'Stockade', '{\"x\":947.9617,\"y\":-1227.84216,\"z\":26.2783947}', '{\"x\":-0.5907817,\"y\":-0.4326067,\"z\":36.76947}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (149, 7, 'Collector38', 'Stockade', '{\"x\":918.1111,\"y\":-1258.71912,\"z\":26.1418056}', '{\"x\":0.171220258,\"y\":-0.512202144,\"z\":36.21521}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (150, 7, 'Collector39', 'Stockade', '{\"x\":910.511536,\"y\":-1264.26587,\"z\":26.1939659}', '{\"x\":0.13556999,\"y\":-0.446292073,\"z\":34.79651}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (151, 7, 'Collector40', 'Stockade', '{\"x\":947.898254,\"y\":-1212.81653,\"z\":26.4047871}', '{\"x\":-0.142012447,\"y\":-0.486120462,\"z\":20.6871338}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (152, 7, 'Collector41', 'Stockade', '{\"x\":943.308044,\"y\":-1212.18359,\"z\":26.38647}', '{\"x\":-0.2649176,\"y\":0.4523629,\"z\":30.9993286}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (153, 7, 'Collector42', 'Stockade', '{\"x\":933.935364,\"y\":-1215.70142,\"z\":26.2964344}', '{\"x\":-0.412756354,\"y\":0.6943975,\"z\":13.4101868}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (154, 7, 'Collector43', 'Stockade', '{\"x\":927.866943,\"y\":-1215.18164,\"z\":26.2581329}', '{\"x\":-0.40032196,\"y\":0.3380064,\"z\":14.973938}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (155, 7, 'Collector44', 'Stockade', '{\"x\":924.950134,\"y\":-1219.41565,\"z\":26.2109013}', '{\"x\":-0.292770833,\"y\":0.545239151,\"z\":8.226257}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (156, 7, 'Collector45', 'Stockade', '{\"x\":920.691162,\"y\":-1219.10278,\"z\":26.18706}', '{\"x\":-0.463563442,\"y\":0.161489636,\"z\":3.94042969}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (157, 7, 'Collector46', 'Stockade', '{\"x\":916.0894,\"y\":-1220.23462,\"z\":26.1637878}', '{\"x\":-0.120337807,\"y\":0.183025673,\"z\":6.29229736}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (158, 7, 'Collector47', 'Stockade', '{\"x\":911.1925,\"y\":-1221.85986,\"z\":26.135437}', '{\"x\":0.0598089658,\"y\":0.3356249,\"z\":9.94360352}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (159, 7, 'Collector48', 'Stockade', '{\"x\":905.4956,\"y\":-1221.39539,\"z\":26.1173744}', '{\"x\":-0.1447776,\"y\":-0.0962473,\"z\":8.788422}', 80, 0, 100);
INSERT INTO `othervehicles` VALUES (161, 0, 'rent001', 'Faggio2', '{\"x\":-537.6912,\"y\":37.4568634,\"z\":52.57992}', '{\"x\":0.0,\"y\":0.0,\"z\":272.503754}', 20, 24, 100);
INSERT INTO `othervehicles` VALUES (162, 0, 'rent002', 'Faggio2', '{\"x\":-536.4992,\"y\":47.90942,\"z\":52.5798874}', '{\"x\":0.0,\"y\":0.0,\"z\":273.3239}', 45, 85, 100);
INSERT INTO `othervehicles` VALUES (163, 0, 'rent003', 'Faggio2', '{\"x\":-536.067566,\"y\":51.13285,\"z\":52.57992}', '{\"x\":0.0,\"y\":0.0,\"z\":277.058472}', 58, 104, 100);
INSERT INTO `othervehicles` VALUES (164, 0, 'rent004', 'Faggio2', '{\"x\":-521.2624,\"y\":52.70471,\"z\":52.5798874}', '{\"x\":0.0,\"y\":0.0,\"z\":82.3512}', 158, 15, 100);
INSERT INTO `othervehicles` VALUES (165, 0, 'rent005', 'Faggio2', '{\"x\":-520.368469,\"y\":59.68205,\"z\":52.5798874}', '{\"x\":0.0,\"y\":0.0,\"z\":81.8675}', 18, 109, 100);
INSERT INTO `othervehicles` VALUES (166, 0, 'rent006', 'Faggio2', '{\"x\":-522.895447,\"y\":29.76363,\"z\":52.5798836}', '{\"x\":0.0,\"y\":0.0,\"z\":359.3082}', 100, 42, 100);
INSERT INTO `othervehicles` VALUES (167, 0, 'rent007', 'Faggio2', '{\"x\":-510.592529,\"y\":51.6423759,\"z\":52.5798874}', '{\"x\":0.0,\"y\":0.0,\"z\":100.615166}', 151, 15, 100);
INSERT INTO `othervehicles` VALUES (168, 0, 'rent008', 'Faggio2', '{\"x\":-509.303284,\"y\":65.68838,\"z\":52.57989}', '{\"x\":0.0,\"y\":0.0,\"z\":87.33792}', 150, 156, 100);
INSERT INTO `othervehicles` VALUES (169, 0, 'rent009', 'Faggio2', '{\"x\":-494.1933,\"y\":60.9701233,\"z\":52.5799255}', '{\"x\":0.0,\"y\":0.0,\"z\":94.34355}', 50, 45, 100);
INSERT INTO `othervehicles` VALUES (170, 0, 'rent010', 'Faggio2', '{\"x\":-495.684784,\"y\":47.276825,\"z\":52.5798874}', '{\"x\":0.0,\"y\":0.0,\"z\":90.22618}', 55, 75, 100);
INSERT INTO `othervehicles` VALUES (171, 0, 'rent011', 'Faggio2', '{\"x\":-496.3294,\"y\":43.9348,\"z\":52.5798874}', '{\"x\":0.0,\"y\":0.0,\"z\":83.91351}', 75, 75, 100);
INSERT INTO `othervehicles` VALUES (172, 0, 'rent012', 'Faggio2', '{\"x\":-496.616516,\"y\":36.0492134,\"z\":52.57989}', '{\"x\":0.0,\"y\":0.0,\"z\":93.94292}', 89, 98, 100);
INSERT INTO `othervehicles` VALUES (173, 0, 'rent013', 'faggio', '{\"x\":-502.6995,\"y\":67.91519,\"z\":56.4961433}', '{\"x\":0.0,\"y\":0.0,\"z\":259.766541}', 89, 98, 100);
INSERT INTO `othervehicles` VALUES (174, 0, 'rent014', 'faggio', '{\"x\":-503.396973,\"y\":61.5034256,\"z\":56.49611}', '{\"x\":0.0,\"y\":0.0,\"z\":268.233063}', 89, 98, 100);
INSERT INTO `othervehicles` VALUES (175, 0, 'rent015', 'faggio', '{\"x\":-504.297119,\"y\":57.8105774,\"z\":56.49615}', '{\"x\":0.0,\"y\":0.0,\"z\":263.977173}', 89, 98, 100);
INSERT INTO `othervehicles` VALUES (176, 0, 'rent016', 'faggio', '{\"x\":-504.9665,\"y\":47.8137321,\"z\":56.4961472}', '{\"x\":0.0,\"y\":0.0,\"z\":263.845367}', 89, 98, 100);
INSERT INTO `othervehicles` VALUES (177, 0, 'rent017', 'faggio', '{\"x\":-493.9284,\"y\":53.88264,\"z\":56.49611}', '{\"x\":0.0,\"y\":0.0,\"z\":79.16916}', 89, 98, 100);
INSERT INTO `othervehicles` VALUES (178, 0, 'rent018', 'faggio', '{\"x\":-495.026154,\"y\":39.990406,\"z\":56.49614}', '{\"x\":0.0,\"y\":0.0,\"z\":90.02419}', 89, 98, 100);
INSERT INTO `othervehicles` VALUES (179, 0, 'rent019', 'faggio', '{\"x\":-494.562042,\"y\":36.219017,\"z\":56.4961128}', '{\"x\":0.0,\"y\":0.0,\"z\":83.09523}', 89, 98, 100);
INSERT INTO `othervehicles` VALUES (180, 0, 'rentb', 'seashark', '{\"x\":-1624.608,\"y\":-1169.67712,\"z\":0.190488875}', '{\"x\":0.0,\"y\":0.0,\"z\":108.13456}', 1, 1, 150);
INSERT INTO `othervehicles` VALUES (181, 0, 'rentb1', 'seashark', '{\"x\":-1626.17786,\"y\":-1167.76941,\"z\":0.5527314}', '{\"x\":0.0,\"y\":0.0,\"z\":40.1383}', 1, 1, 150);
INSERT INTO `othervehicles` VALUES (182, 0, 'rentb2', 'seashark', '{\"x\":-1627.60327,\"y\":-1166.11426,\"z\":0.835619}', '{\"x\":0.0,\"y\":0.0,\"z\":313.393738}', 1, 1, 150);
INSERT INTO `othervehicles` VALUES (183, 0, 'rentb3', 'seashark', '{\"x\":-1629.98547,\"y\":-1163.29907,\"z\":0.3016748}', '{\"x\":0.0,\"y\":0.0,\"z\":88.43083}', 1, 1, 100);
INSERT INTO `othervehicles` VALUES (185, 0, 'rent1', 'faggio', '{\"x\":-785.0813,\"y\":-1295.1007,\"z\":4.3943734}', '{\"x\":0.0,\"y\":0.0,\"z\":167.9515}', 1, 1, 100);
INSERT INTO `othervehicles` VALUES (186, 0, 'rent2', 'faggio', '{\"x\":-794.64026,\"y\":-1293.5544,\"z\":5.0003767}', '{\"x\":0.0,\"y\":0.0,\"z\":-10.845671}', 1, 1, 100);
INSERT INTO `othervehicles` VALUES (187, 0, 'rent3', 'faggio', '{\"x\":-797.76544,\"y\":-1293.1201,\"z\":5.0003767}', '{\"x\":0.0,\"y\":0.0,\"z\":-14.346443}', 1, 1, 100);
INSERT INTO `othervehicles` VALUES (188, 0, 'rent4', 'faggio', '{\"x\":-801.0977,\"y\":-1292.7926,\"z\":5.0003767}', '{\"x\":0.0,\"y\":0.0,\"z\":-9.860184}', 1, 1, 100);
INSERT INTO `othervehicles` VALUES (189, 0, 'rent5', 'faggio', '{\"x\":-803.97906,\"y\":-1292.104,\"z\":5.0003786}', '{\"x\":0.0,\"y\":0.0,\"z\":-13.326587}', 1, 1, 100);
INSERT INTO `othervehicles` VALUES (190, 0, 'rent6', 'faggio', '{\"x\":-807.10077,\"y\":-1290.6826,\"z\":5.0003786}', '{\"x\":0.0,\"y\":0.0,\"z\":-13.498475}', 1, 1, 100);
INSERT INTO `othervehicles` VALUES (191, 0, 'rent7', 'faggio', '{\"x\":-810.19434,\"y\":-1290.6709,\"z\":5.000377}', '{\"x\":0.0,\"y\":0.0,\"z\":-9.55079}', 1, 1, 100);
INSERT INTO `othervehicles` VALUES (192, 0, 'rent8', 'faggio', '{\"x\":-813.23193,\"y\":-1290.1016,\"z\":5.000377}', '{\"x\":0.0,\"y\":0.0,\"z\":-4.4170833}', 1, 1, 100);
INSERT INTO `othervehicles` VALUES (193, 0, '1', 'scorcher', '{\"x\":4494.6885,\"y\":-4513.587,\"z\":4.0181255}', '{\"x\":0.0,\"y\":0.0,\"z\":21.847301}', 5, 5, 50);
INSERT INTO `othervehicles` VALUES (194, 0, '2', 'scorcher', '{\"x\":4497.252,\"y\":-4513.2275,\"z\":4.014994}', '{\"x\":0.0,\"y\":0.0,\"z\":18.62154}', 4, 5, 50);
INSERT INTO `othervehicles` VALUES (195, 0, '3', 'scorcher', '{\"x\":4499.88,\"y\":-4512.49,\"z\":4.054307}', '{\"x\":0.0,\"y\":0.0,\"z\":39.225105}', 4, 5, 50);
INSERT INTO `othervehicles` VALUES (196, 0, '4', 'scorcher', '{\"x\":4492.7847,\"y\":-4514.191,\"z\":4.0145555}', '{\"x\":0.0,\"y\":0.0,\"z\":6.7956963}', 4, 5, 50);
INSERT INTO `othervehicles` VALUES (197, 0, '5', 'scorcher', '{\"x\":4491.192,\"y\":-4514.8276,\"z\":4.0101423}', '{\"x\":0.0,\"y\":0.0,\"z\":25.382442}', 4, 5, 50);
INSERT INTO `othervehicles` VALUES (198, 0, '6', 'scorcher', '{\"x\":4489.3135,\"y\":-4515.6777,\"z\":4.2039747}', '{\"x\":0.0,\"y\":0.0,\"z\":-0.9449703}', 4, 5, 50);
INSERT INTO `othervehicles` VALUES (199, 0, '7', 'scorcher', '{\"x\":4501.786,\"y\":-4513.5117,\"z\":4.183186}', '{\"x\":0.0,\"y\":0.0,\"z\":-37.55697}', 4, 5, 50);
INSERT INTO `othervehicles` VALUES (200, 0, '8', 'scorcher', '{\"x\":4503.2515,\"y\":-4514.069,\"z\":4.2114544}', '{\"x\":0.0,\"y\":0.0,\"z\":-26.905685}', 4, 5, 50);
INSERT INTO `othervehicles` VALUES (201, 0, '10', 'scorcher', '{\"x\":4504.0913,\"y\":-4515.7686,\"z\":4.2270775}', '{\"x\":0.0,\"y\":0.0,\"z\":-68.85764}', 4, 5, 50);
INSERT INTO `othervehicles` VALUES (202, 0, '11', 'scorcher', '{\"x\":4504.101,\"y\":-4517.2144,\"z\":4.328993}', '{\"x\":0.0,\"y\":0.0,\"z\":-80.98717}', 4, 5, 50);
INSERT INTO `othervehicles` VALUES (203, 0, '12', 'scorcher', '{\"x\":4504.6157,\"y\":-4518.679,\"z\":4.3533406}', '{\"x\":0.0,\"y\":0.0,\"z\":-80.6262}', 4, 5, 50);
INSERT INTO `othervehicles` VALUES (204, 0, '13', 'scorcher', '{\"x\":4505.007,\"y\":-4520.0767,\"z\":4.283218}', '{\"x\":0.0,\"y\":0.0,\"z\":-74.03146}', 4, 5, 50);
INSERT INTO `othervehicles` VALUES (205, 0, '40', 'faggio', '{\"x\":253.53912,\"y\":-746.4861,\"z\":34.637157}', '{\"x\":0.0,\"y\":0.0,\"z\":152.05766}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (206, 0, '41', 'faggio', '{\"x\":249.95575,\"y\":-744.747,\"z\":34.63759}', '{\"x\":0.0,\"y\":0.0,\"z\":155.9595}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (207, 0, '42', 'faggio', '{\"x\":246.8186,\"y\":-743.3304,\"z\":34.63124}', '{\"x\":0.0,\"y\":0.0,\"z\":154.26357}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (208, 0, '43', 'faggio', '{\"x\":243.78177,\"y\":-741.74316,\"z\":34.625748}', '{\"x\":0.0,\"y\":0.0,\"z\":155.75897}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (209, 0, '44', 'faggio', '{\"x\":240.80559,\"y\":-740.48883,\"z\":34.625458}', '{\"x\":0.0,\"y\":0.0,\"z\":153.87968}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (210, 0, '45', 'faggio', '{\"x\":237.56462,\"y\":-738.5457,\"z\":34.623135}', '{\"x\":0.0,\"y\":0.0,\"z\":157.19138}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (211, 0, '46', 'faggio', '{\"x\":233.92033,\"y\":-738.5878,\"z\":34.58863}', '{\"x\":0.0,\"y\":0.0,\"z\":158.88159}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (212, 0, '47', 'faggio', '{\"x\":244.55733,\"y\":-759.3691,\"z\":34.63827}', '{\"x\":0.0,\"y\":0.0,\"z\":-26.64212}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (213, 0, '48', 'faggio', '{\"x\":247.79718,\"y\":-760.12036,\"z\":34.641167}', '{\"x\":0.0,\"y\":0.0,\"z\":-31.741446}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (214, 0, '49', 'faggio', '{\"x\":251.25322,\"y\":-761.41376,\"z\":34.6414}', '{\"x\":0.0,\"y\":0.0,\"z\":-29.827763}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (215, 0, '50', 'faggio', '{\"x\":254.46056,\"y\":-763.04395,\"z\":34.641045}', '{\"x\":0.0,\"y\":0.0,\"z\":-23.783058}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (216, 0, '51', 'faggio', '{\"x\":261.76105,\"y\":-765.7052,\"z\":34.64512}', '{\"x\":0.0,\"y\":0.0,\"z\":66.25153}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (217, 0, '52', 'faggio', '{\"x\":263.71127,\"y\":-762.9198,\"z\":34.644173}', '{\"x\":0.0,\"y\":0.0,\"z\":63.020035}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (218, 0, '53', 'faggio', '{\"x\":264.85614,\"y\":-759.2911,\"z\":34.64265}', '{\"x\":0.0,\"y\":0.0,\"z\":65.6843}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (219, 0, '54', 'faggio', '{\"x\":227.92453,\"y\":-753.97205,\"z\":34.64219}', '{\"x\":0.0,\"y\":0.0,\"z\":-32.663902}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (220, 0, '55', 'faggio', '{\"x\":224.68285,\"y\":-752.19696,\"z\":34.6379}', '{\"x\":0.0,\"y\":0.0,\"z\":-22.809032}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (221, 0, '56', 'faggio', '{\"x\":221.52933,\"y\":-750.6437,\"z\":34.63955}', '{\"x\":0.0,\"y\":0.0,\"z\":-25.627989}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (222, 0, 's1', 'seashark3', '{\"x\":-723.2726,\"y\":-1318.7495,\"z\":1.827922}', '{\"x\":0.0,\"y\":0.0,\"z\":-106.00823}', 5, 5, 500);
INSERT INTO `othervehicles` VALUES (223, 0, 's2', 'seashark3', '{\"x\":-717.2443,\"y\":-1323.5715,\"z\":2.315609}', '{\"x\":0.0,\"y\":0.0,\"z\":-106.00823}', 5, 5, 500);
INSERT INTO `othervehicles` VALUES (224, 0, 's3', 'seashark3', '{\"x\":-720.0455,\"y\":-1329.7336,\"z\":2.4878438}', '{\"x\":0.0,\"y\":0.0,\"z\":-106.00823}', 5, 5, 500);
INSERT INTO `othervehicles` VALUES (225, 0, 's4', 'seashark3', '{\"x\":-724.9918,\"y\":-1325.3477,\"z\":1.906848}', '{\"x\":0.0,\"y\":0.0,\"z\":-106.00823}', 5, 5, 500);
INSERT INTO `othervehicles` VALUES (226, 0, 's5', 'seashark3', '{\"x\":-728.60693,\"y\":-1327.1858,\"z\":1.7095783}', '{\"x\":0.0,\"y\":0.0,\"z\":-106.00823}', 5, 5, 500);
INSERT INTO `othervehicles` VALUES (227, 0, 's6', 'seashark3', '{\"x\":-725.1976,\"y\":-1330.3914,\"z\":2.2819498}', '{\"x\":0.0,\"y\":0.0,\"z\":-106.00823}', 5, 5, 500);
INSERT INTO `othervehicles` VALUES (228, 0, 's7', 'seashark3', '{\"x\":4850.073,\"y\":-4919.016,\"z\":4.018611}', '{\"x\":0.0,\"y\":0.0,\"z\":-106.00823}', 5, 5, 500);
INSERT INTO `othervehicles` VALUES (229, 0, 's8', 'seashark3', '{\"x\":4850.452,\"y\":-4923.3867,\"z\":3.1271636}', '{\"x\":0.0,\"y\":0.0,\"z\":-106.00823}', 5, 5, 500);
INSERT INTO `othervehicles` VALUES (230, 0, 's9', 'seashark3', '{\"x\":4848.389,\"y\":-4927.6265,\"z\":1.9332694}', '{\"x\":0.0,\"y\":0.0,\"z\":-106.00823}', 5, 5, 500);
INSERT INTO `othervehicles` VALUES (231, 0, 's10', 'seashark3', '{\"x\":4846.6973,\"y\":-4933.0186,\"z\":1.9332694}', '{\"x\":0.0,\"y\":0.0,\"z\":-106.00823}', 5, 5, 500);
INSERT INTO `othervehicles` VALUES (232, 0, 's11', 'seashark3', '{\"x\":4847.2173,\"y\":-4930.8926,\"z\":1.9332694}', '{\"x\":0.0,\"y\":0.0,\"z\":-106.00823}', 5, 5, 500);
INSERT INTO `othervehicles` VALUES (233, 0, 's12', 'seashark3', '{\"x\":4852.066,\"y\":-4917.0166,\"z\":2.3729987}', '{\"x\":0.0,\"y\":0.0,\"z\":-106.00823}', 5, 5, 500);
INSERT INTO `othervehicles` VALUES (234, 0, 'sp1', 'speeder', '{\"x\":-730.43005,\"y\":-1335.2402,\"z\":2.5476818}', '{\"x\":0.0,\"y\":0.0,\"z\":-106.00823}', 5, 5, 5000);
INSERT INTO `othervehicles` VALUES (235, 0, 'sp2', 'speeder', '{\"x\":-736.585,\"y\":-1341.5834,\"z\":1.6295533}', '{\"x\":0.0,\"y\":0.0,\"z\":-106.00823}', 5, 5, 5000);
INSERT INTO `othervehicles` VALUES (236, 0, 'sp3', 'speeder', '{\"x\":-740.84955,\"y\":-1349.9893,\"z\":1.6295533}', '{\"x\":0.0,\"y\":0.0,\"z\":-106.00823}', 5, 5, 5000);
INSERT INTO `othervehicles` VALUES (237, 0, 'sp4', 'speeder', '{\"x\":-749.2083,\"y\":-1353.9706,\"z\":2.322211}', '{\"x\":0.0,\"y\":0.0,\"z\":-106.00823}', 5, 5, 5000);
INSERT INTO `othervehicles` VALUES (238, 0, 'sp5', 'speeder', '{\"x\":5104.537,\"y\":-4630.8574,\"z\":4.015776}', '{\"x\":0.0,\"y\":0.0,\"z\":-106.00823}', 5, 5, 5000);
INSERT INTO `othervehicles` VALUES (241, 0, 'sp8', 'speeder', '{\"x\":5147.449,\"y\":-4660.6494,\"z\":2.618836}', '{\"x\":0.0,\"y\":0.0,\"z\":-106.00823}', 5, 5, 5000);
INSERT INTO `othervehicles` VALUES (242, 0, 'sp9', 'speeder', '{\"x\":5098.305,\"y\":-4649.514,\"z\":2.633089}', '{\"x\":0.0,\"y\":0.0,\"z\":-106.00823}', 5, 5, 5000);
INSERT INTO `othervehicles` VALUES (243, 0, 'sp10', 'speeder', '{\"x\":5115.5425,\"y\":-4660.167,\"z\":3.2587004}', '{\"x\":0.0,\"y\":0.0,\"z\":-106.00823}', 5, 5, 5000);
INSERT INTO `othervehicles` VALUES (244, 0, '57', 'faggio', '{\"x\":-2065.1055,\"y\":-454.18088,\"z\":11.719756}', '{\"x\":0.0,\"y\":0.0,\"z\":-48.191067}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (245, 0, '58', 'faggio', '{\"x\":-2061.7717,\"y\":-455.82074,\"z\":11.665916}', '{\"x\":0.0,\"y\":0.0,\"z\":-50.534462}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (246, 0, '59', 'faggio', '{\"x\":-2059.7698,\"y\":-458.16745,\"z\":11.691497}', '{\"x\":0.0,\"y\":0.0,\"z\":39.127705}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (247, 0, '60', 'faggio', '{\"x\":-2057.111,\"y\":-460.39896,\"z\":11.687236}', '{\"x\":0.0,\"y\":0.0,\"z\":-44.88509}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (248, 0, '61', 'faggio', '{\"x\":-2049.8975,\"y\":-466.6766,\"z\":11.698639}', '{\"x\":0.0,\"y\":0.0,\"z\":-42.238026}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (249, 0, '62', 'faggio', '{\"x\":-2047.9941,\"y\":-469.10983,\"z\":11.737003}', '{\"x\":0.0,\"y\":0.0,\"z\":-48.59786}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (250, 0, '63', 'faggio', '{\"x\":-2045.0997,\"y\":-470.67255,\"z\":11.701286}', '{\"x\":0.0,\"y\":0.0,\"z\":-43.825127}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (251, 0, '64', 'faggio', '{\"x\":-2042.6111,\"y\":-472.37387,\"z\":11.667741}', '{\"x\":0.0,\"y\":0.0,\"z\":-38.164295}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (252, 0, '65', 'faggio', '{\"x\":-2050.777,\"y\":-448.21698,\"z\":11.422445}', '{\"x\":0.0,\"y\":0.0,\"z\":138.06032}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (253, 0, '66', 'faggio', '{\"x\":-2048.734,\"y\":-450.37985,\"z\":11.417484}', '{\"x\":0.0,\"y\":0.0,\"z\":140.23756}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (254, 0, '67', 'faggio', '{\"x\":-2045.9309,\"y\":-452.1772,\"z\":11.425674}', '{\"x\":0.0,\"y\":0.0,\"z\":131.36244}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (255, 0, '68', 'faggio', '{\"x\":-2043.6472,\"y\":-454.07465,\"z\":11.425474}', '{\"x\":0.0,\"y\":0.0,\"z\":135.99194}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (256, 0, '69', 'faggio', '{\"x\":-2041.5818,\"y\":-456.31638,\"z\":11.419281}', '{\"x\":0.0,\"y\":0.0,\"z\":138.9484}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (257, 0, '70', 'faggio', '{\"x\":-2039.1482,\"y\":-458.54996,\"z\":11.415914}', '{\"x\":0.0,\"y\":0.0,\"z\":131.80362}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (258, 0, '71', 'faggio', '{\"x\":-2036.7998,\"y\":-460.9574,\"z\":11.411126}', '{\"x\":0.0,\"y\":0.0,\"z\":127.83304}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (259, 0, '71', 'faggio2', '{\"x\":1478.3218,\"y\":3749.822,\"z\":33.72012}', '{\"x\":0.0,\"y\":0.0,\"z\":-159.20163}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (260, 0, '72', 'faggio2', '{\"x\":1480.4846,\"y\":3751.2969,\"z\":33.746433}', '{\"x\":0.0,\"y\":0.0,\"z\":-153.82156}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (261, 0, '73', 'faggio2', '{\"x\":1483.4678,\"y\":3753.03,\"z\":33.777943}', '{\"x\":0.0,\"y\":0.0,\"z\":-162.51906}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (262, 0, '74', 'faggio2', '{\"x\":1485.9232,\"y\":3754.5198,\"z\":33.8066}', '{\"x\":0.0,\"y\":0.0,\"z\":-152.84752}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (263, 0, '75', 'faggio2', '{\"x\":1474.8342,\"y\":3747.786,\"z\":33.67435}', '{\"x\":0.0,\"y\":0.0,\"z\":-158.93806}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (264, 0, '76', 'faggio', '{\"x\":50.03592,\"y\":6393.998,\"z\":31.225761}', '{\"x\":0.0,\"y\":0.0,\"z\":-150.7906}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (265, 0, '77', 'faggio', '{\"x\":47.68719,\"y\":6391.6055,\"z\":31.225767}', '{\"x\":0.0,\"y\":0.0,\"z\":-159.62561}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (266, 0, '78', 'faggio', '{\"x\":44.475803,\"y\":6389.3286,\"z\":31.225765}', '{\"x\":0.0,\"y\":0.0,\"z\":-154.23409}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (267, 0, '79', 'faggio', '{\"x\":41.832485,\"y\":6386.4175,\"z\":31.225784}', '{\"x\":0.0,\"y\":0.0,\"z\":-154.469}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (268, 0, '79', 'faggio', '{\"x\":38.81295,\"y\":6383.5146,\"z\":31.225763}', '{\"x\":0.0,\"y\":0.0,\"z\":-149.59885}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (269, 0, '80', 'faggio', '{\"x\":36.303425,\"y\":6380.9673,\"z\":31.225763}', '{\"x\":0.0,\"y\":0.0,\"z\":-150.69893}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (270, 0, '81', 'faggio', '{\"x\":859.08765,\"y\":-17.379545,\"z\":78.764145}', '{\"x\":0.0,\"y\":0.0,\"z\":51.92759}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (271, 0, '82', 'faggio', '{\"x\":856.79095,\"y\":-20.122683,\"z\":78.76404}', '{\"x\":0.0,\"y\":0.0,\"z\":49.64721}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (272, 0, '83', 'faggio', '{\"x\":855.2446,\"y\":-22.881815,\"z\":78.764015}', '{\"x\":0.0,\"y\":0.0,\"z\":57.800404}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (273, 0, '84', 'faggio', '{\"x\":853.26807,\"y\":-25.791082,\"z\":78.76411}', '{\"x\":0.0,\"y\":0.0,\"z\":57.061268}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (274, 0, '85', 'faggio', '{\"x\":851.4578,\"y\":-28.732342,\"z\":78.76404}', '{\"x\":0.0,\"y\":0.0,\"z\":53.76677}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (275, 0, '86', 'Scorcher', '{\"x\":-1114.5198,\"y\":-1688.0718,\"z\":4.3712554}', '{\"x\":0.0,\"y\":0.0,\"z\":-52.654404}', 5, 5, 50);
INSERT INTO `othervehicles` VALUES (276, 0, '87', 'Scorcher', '{\"x\":-1115.9236,\"y\":-1686.8855,\"z\":4.3687778}', '{\"x\":0.0,\"y\":0.0,\"z\":-60.97375}', 5, 5, 50);
INSERT INTO `othervehicles` VALUES (277, 0, '88', 'Scorcher', '{\"x\":-1117.147,\"y\":-1685.4303,\"z\":4.365853}', '{\"x\":0.0,\"y\":0.0,\"z\":-68.54252}', 5, 5, 50);
INSERT INTO `othervehicles` VALUES (278, 0, '89', 'Scorcher', '{\"x\":-1118.1531,\"y\":-1684.5071,\"z\":4.364386}', '{\"x\":0.0,\"y\":0.0,\"z\":-51.880913}', 5, 5, 50);
INSERT INTO `othervehicles` VALUES (279, 0, '90', 'Scorcher', '{\"x\":-1119.2462,\"y\":-1683.2887,\"z\":4.3631124}', '{\"x\":0.0,\"y\":0.0,\"z\":-58.859535}', 5, 5, 50);
INSERT INTO `othervehicles` VALUES (280, 0, '91', 'Scorcher', '{\"x\":-1120.209,\"y\":-1681.5911,\"z\":4.3624315}', '{\"x\":0.0,\"y\":0.0,\"z\":-64.06772}', 5, 5, 50);
INSERT INTO `othervehicles` VALUES (281, 0, '92', 'Scorcher', '{\"x\":-1121.512,\"y\":-1679.508,\"z\":4.3619204}', '{\"x\":0.0,\"y\":0.0,\"z\":-78.48334}', 5, 5, 50);
INSERT INTO `othervehicles` VALUES (282, 0, '93', 'Scorcher', '{\"x\":-1105.2617,\"y\":-1701.5104,\"z\":4.3716125}', '{\"x\":0.0,\"y\":0.0,\"z\":-57.587574}', 5, 5, 50);
INSERT INTO `othervehicles` VALUES (283, 0, '94', 'TriBike', '{\"x\":-1104.0177,\"y\":-1703.0662,\"z\":4.3710585}', '{\"x\":0.0,\"y\":0.0,\"z\":-35.425568}', 5, 5, 50);
INSERT INTO `othervehicles` VALUES (284, 0, '95', 'TriBike', '{\"x\":-1101.0337,\"y\":-1702.0825,\"z\":4.3709693}', '{\"x\":0.0,\"y\":0.0,\"z\":-44.856445}', 5, 5, 50);
INSERT INTO `othervehicles` VALUES (285, 0, '96', 'TriBike', '{\"x\":-1123.516,\"y\":-1676.213,\"z\":4.3558865}', '{\"x\":0.0,\"y\":0.0,\"z\":-50.482895}', 5, 5, 50);
INSERT INTO `othervehicles` VALUES (286, 0, '97', 'TriBike', '{\"x\":-1125.0656,\"y\":-1673.4811,\"z\":4.3548064}', '{\"x\":0.0,\"y\":0.0,\"z\":-59.443954}', 5, 5, 50);
INSERT INTO `othervehicles` VALUES (287, 0, '98', 'faggio', '{\"x\":-791.2697,\"y\":-1293.9999,\"z\":5.000378}', '{\"x\":0.0,\"y\":0.0,\"z\":-14.163107}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (288, 0, '99', 'faggio', '{\"x\":-788.2659,\"y\":-1295.4768,\"z\":5.00038}', '{\"x\":0.0,\"y\":0.0,\"z\":-16.208557}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (289, 0, '100', 'faggio', '{\"x\":-782.02826,\"y\":-1296.3281,\"z\":5.0003777}', '{\"x\":0.0,\"y\":0.0,\"z\":-15.492357}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (290, 0, '101', 'faggio', '{\"x\":-786.2819,\"y\":-1301.3394,\"z\":5.000379}', '{\"x\":0.0,\"y\":0.0,\"z\":166.51915}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (291, 0, '102', 'faggio', '{\"x\":-789.3299,\"y\":-1300.6486,\"z\":5.000382}', '{\"x\":0.0,\"y\":0.0,\"z\":157.13982}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (292, 0, '103', 'faggio', '{\"x\":-792.3561,\"y\":-1299.3418,\"z\":5.000407}', '{\"x\":0.0,\"y\":0.0,\"z\":165.25862}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (293, 0, '104', 'faggio', '{\"x\":-795.50757,\"y\":-1298.0582,\"z\":5.00038}', '{\"x\":0.0,\"y\":0.0,\"z\":163.59705}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (294, 0, '105', 'faggio', '{\"x\":-798.6093,\"y\":-1297.6871,\"z\":5.00038}', '{\"x\":0.0,\"y\":0.0,\"z\":168.45001}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (295, 0, '106', 'faggio', '{\"x\":-816.7985,\"y\":-1290.0852,\"z\":5.0003824}', '{\"x\":0.0,\"y\":0.0,\"z\":-18.826979}', 5, 5, 100);
INSERT INTO `othervehicles` VALUES (298, 0, 'Air3', 'Faggio3', '{\"x\":-973.2364,\"y\":-2692.6477,\"z\":13.830687}', '{\"x\":0.0,\"y\":0.0,\"z\":150.1268}', 12, 12, 50);
INSERT INTO `othervehicles` VALUES (299, 0, 'Air4', 'faggio', '{\"x\":-970.3385,\"y\":-2694.5786,\"z\":13.830678}', '{\"x\":0.0,\"y\":0.0,\"z\":147.27347}', 12, 12, 50);
INSERT INTO `othervehicles` VALUES (300, 0, 'Air5', 'faggio', '{\"x\":-967.80774,\"y\":-2696.3445,\"z\":13.830678}', '{\"x\":0.0,\"y\":0.0,\"z\":151.18105}', 12, 12, 50);
INSERT INTO `othervehicles` VALUES (301, 0, 'Air6', 'faggio', '{\"x\":-964.6446,\"y\":-2697.6455,\"z\":13.830677}', '{\"x\":0.0,\"y\":0.0,\"z\":150.41902}', 12, 12, 50);
INSERT INTO `othervehicles` VALUES (302, 0, 'Air7', 'faggio', '{\"x\":-961.7438,\"y\":-2699.3467,\"z\":13.831036}', '{\"x\":0.0,\"y\":0.0,\"z\":149.62259}', 12, 12, 50);
INSERT INTO `othervehicles` VALUES (303, 0, 'Air8', 'faggio', '{\"x\":-960.4416,\"y\":-2709.9553,\"z\":13.831037}', '{\"x\":0.0,\"y\":0.0,\"z\":7.878582}', 12, 12, 50);
INSERT INTO `othervehicles` VALUES (304, 0, 'Air9', 'faggio', '{\"x\":-963.64655,\"y\":-2710.3713,\"z\":13.830687}', '{\"x\":0.0,\"y\":0.0,\"z\":8.772394}', 12, 12, 50);
INSERT INTO `othervehicles` VALUES (305, 0, 'Air10', 'faggio', '{\"x\":-966.53204,\"y\":-2711.006,\"z\":13.830677}', '{\"x\":0.0,\"y\":0.0,\"z\":8.05047}', 12, 12, 50);
INSERT INTO `othervehicles` VALUES (306, 0, 'Air11', 'faggio', '{\"x\":-969.98334,\"y\":-2711.4136,\"z\":13.843634}', '{\"x\":0.0,\"y\":0.0,\"z\":4.011124}', 12, 12, 50);
INSERT INTO `othervehicles` VALUES (307, 0, 'Air12', 'faggio', '{\"x\":-973.2211,\"y\":-2711.2712,\"z\":13.852916}', '{\"x\":0.0,\"y\":0.0,\"z\":-2.7497795}', 12, 12, 50);
INSERT INTO `othervehicles` VALUES (308, 0, 'Air13', 'faggio', '{\"x\":-976.8757,\"y\":-2711.1057,\"z\":13.850298}', '{\"x\":0.0,\"y\":0.0,\"z\":-9.831537}', 12, 12, 50);
INSERT INTO `othervehicles` VALUES (309, 0, 'Air15', 'faggio', '{\"x\":-979.876,\"y\":-2710.3723,\"z\":13.844358}', '{\"x\":0.0,\"y\":0.0,\"z\":-10.765457}', 12, 12, 50);
INSERT INTO `othervehicles` VALUES (310, 0, 'Air16', 'faggio', '{\"x\":-983.08356,\"y\":-2709.8838,\"z\":13.830678}', '{\"x\":0.0,\"y\":0.0,\"z\":-21.428202}', 12, 12, 50);
INSERT INTO `othervehicles` VALUES (311, 0, 'Air17', 'faggio', '{\"x\":-986.6709,\"y\":-2708.5298,\"z\":13.830678}', '{\"x\":0.0,\"y\":0.0,\"z\":-25.948843}', 12, 12, 50);
INSERT INTO `othervehicles` VALUES (312, 0, 'Air18', 'faggio', '{\"x\":-989.60394,\"y\":-2707.046,\"z\":13.830678}', '{\"x\":0.0,\"y\":0.0,\"z\":-29.959543}', 12, 12, 50);
INSERT INTO `othervehicles` VALUES (313, 0, 'Air1', 'Faggio', '{\"x\":-979.1039,\"y\":-2688.8088,\"z\":13.830677}', '{\"x\":0.0,\"y\":0.0,\"z\":153.85677}', 12, 12, 50);
INSERT INTO `othervehicles` VALUES (314, 0, 'Air2', 'faggio', '{\"x\":-975.9649,\"y\":-2690.7373,\"z\":13.830678}', '{\"x\":0.0,\"y\":0.0,\"z\":143.131}', 12, 12, 50);
INSERT INTO `othervehicles` VALUES (315, 0, 'Air21', 'faggio', '{\"x\":-1028.7235,\"y\":-2660.532,\"z\":13.830762}', '{\"x\":0.0,\"y\":0.0,\"z\":145.72649}', 12, 12, 50);
INSERT INTO `othervehicles` VALUES (316, 0, 'Air22', 'faggio', '{\"x\":-1031.4967,\"y\":-2658.0957,\"z\":13.830763}', '{\"x\":0.0,\"y\":0.0,\"z\":146.33957}', 12, 12, 50);
INSERT INTO `othervehicles` VALUES (317, 0, 'Air24', 'faggio', '{\"x\":-1034.2755,\"y\":-2656.3315,\"z\":13.830762}', '{\"x\":0.0,\"y\":0.0,\"z\":150.09242}', 12, 12, 50);
INSERT INTO `othervehicles` VALUES (318, 0, 'Air25', 'faggio', '{\"x\":-1037.1409,\"y\":-2654.8367,\"z\":13.830752}', '{\"x\":0.0,\"y\":0.0,\"z\":144.24828}', 12, 12, 50);
INSERT INTO `othervehicles` VALUES (319, 0, 'Air26', 'faggio', '{\"x\":-1040.0157,\"y\":-2653.117,\"z\":13.830762}', '{\"x\":0.0,\"y\":0.0,\"z\":151.10658}', 12, 12, 50);
INSERT INTO `othervehicles` VALUES (320, 0, 'Air27', 'faggio', '{\"x\":-1043.4829,\"y\":-2651.7913,\"z\":13.830762}', '{\"x\":0.0,\"y\":0.0,\"z\":144.63786}', 12, 12, 50);
INSERT INTO `othervehicles` VALUES (321, 0, 'Air28', 'faggio', '{\"x\":-1046.2126,\"y\":-2650.1826,\"z\":13.83075}', '{\"x\":0.0,\"y\":0.0,\"z\":146.84949}', 12, 12, 50);
INSERT INTO `othervehicles` VALUES (322, 0, 'Air29', 'faggio', '{\"x\":-1056.2788,\"y\":-2654.9353,\"z\":13.830753}', '{\"x\":0.0,\"y\":0.0,\"z\":-74.41534}', 12, 12, 50);
INSERT INTO `othervehicles` VALUES (323, 0, 'Air30', 'faggio', '{\"x\":-1055.5503,\"y\":-2657.898,\"z\":13.830762}', '{\"x\":0.0,\"y\":0.0,\"z\":-74.810684}', 12, 12, 50);
INSERT INTO `othervehicles` VALUES (324, 0, 'Air31', 'faggio', '{\"x\":-1054.7155,\"y\":-2660.987,\"z\":13.830763}', '{\"x\":0.0,\"y\":0.0,\"z\":-69.41342}', 12, 12, 50);
INSERT INTO `othervehicles` VALUES (325, 0, 'Air32', 'faggio', '{\"x\":-1052.7567,\"y\":-2663.792,\"z\":13.830751}', '{\"x\":0.0,\"y\":0.0,\"z\":-71.905785}', 12, 12, 50);
INSERT INTO `othervehicles` VALUES (326, 0, 'Air33', 'faggio', '{\"x\":-1050.8286,\"y\":-2666.8472,\"z\":13.83076}', '{\"x\":0.0,\"y\":0.0,\"z\":-61.04823}', 12, 12, 50);
INSERT INTO `othervehicles` VALUES (327, 0, 'Air35', 'faggio', '{\"x\":-1048.9015,\"y\":-2669.6565,\"z\":13.830761}', '{\"x\":0.0,\"y\":0.0,\"z\":-53.066933}', 12, 12, 50);
INSERT INTO `othervehicles` VALUES (328, 0, 'Air36', 'faggio', '{\"x\":-1046.9146,\"y\":-2672.0671,\"z\":13.830761}', '{\"x\":0.0,\"y\":0.0,\"z\":-56.149437}', 12, 12, 50);
INSERT INTO `othervehicles` VALUES (329, 0, 'Air37', 'faggio', '{\"x\":-1044.6216,\"y\":-2674.4158,\"z\":13.830751}', '{\"x\":0.0,\"y\":0.0,\"z\":-41.47027}', 12, 12, 50);
INSERT INTO `othervehicles` VALUES (330, 0, 'Air38', 'faggio', '{\"x\":-1042.0846,\"y\":-2676.6436,\"z\":13.830756}', '{\"x\":0.0,\"y\":0.0,\"z\":-40.685318}', 12, 12, 50);
INSERT INTO `othervehicles` VALUES (331, 0, 'Air39', 'faggio', '{\"x\":-1039.3319,\"y\":-2678.8003,\"z\":13.830766}', '{\"x\":0.0,\"y\":0.0,\"z\":-32.681103}', 12, 12, 50);

-- ----------------------------
-- Table structure for promocodes
-- ----------------------------
DROP TABLE IF EXISTS `promocodes`;
CREATE TABLE `promocodes`  (
  `name` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `type` tinyint NULL DEFAULT NULL,
  `count` int NULL DEFAULT NULL,
  `owner` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `donate` int NULL DEFAULT 0,
  PRIMARY KEY (`name`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of promocodes
-- ----------------------------

-- ----------------------------
-- Table structure for questions
-- ----------------------------
DROP TABLE IF EXISTS `questions`;
CREATE TABLE `questions`  (
  `ID` int UNSIGNED NOT NULL AUTO_INCREMENT,
  `Author` varchar(40) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Question` varchar(150) CHARACTER SET utf8mb3 COLLATE utf8mb3_bin NOT NULL,
  `Respondent` varchar(40) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `Response` varchar(150) CHARACTER SET utf8mb3 COLLATE utf8mb3_bin NULL DEFAULT NULL,
  `Opened` datetime NOT NULL,
  `Closed` datetime NULL DEFAULT NULL,
  `Status` tinyint NULL DEFAULT 0,
  PRIMARY KEY (`ID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 53 CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Records of questions
-- ----------------------------
INSERT INTO `questions` VALUES (46, 'Volt_Alphatester', 'hallo', 'Alexander_Rusev', 'wie kann ich helfen ', '2020-12-14 17:30:10', '2020-12-14 17:30:26', 1);
INSERT INTO `questions` VALUES (47, 'Volt_Alphatester', 'Neues Auto vorm PD', 'Alexander_Rusev', 'komme', '2020-12-14 17:58:21', '2020-12-14 18:00:57', 1);
INSERT INTO `questions` VALUES (48, 'Volt_Alphatester', 'Patte RDM', 'Volt_Alphatester', 'ok', '2020-12-15 01:28:06', '2020-12-23 01:34:48', 1);
INSERT INTO `questions` VALUES (49, 'Volt_Alphatester', 'hallo', 'Volt_Alphatester', 'ok', '2020-12-15 02:35:10', '2020-12-23 01:34:53', 1);
INSERT INTO `questions` VALUES (50, 'Volt_Alphatester', 'Hallo jemand hier ?', 'Volt_Alphatester', 'ok', '2020-12-17 21:28:14', '2020-12-23 01:34:56', 1);
INSERT INTO `questions` VALUES (51, 'Hanz_Wurst', 'ist ein ficker', 'Volt_Alphatester', 'ahoy', '2020-12-23 01:35:23', '2020-12-23 01:35:57', 1);
INSERT INTO `questions` VALUES (52, 'James_Hills', '.', NULL, NULL, '2021-02-24 16:45:53', '0001-01-01 00:00:00', 0);

-- ----------------------------
-- Table structure for rodings
-- ----------------------------
DROP TABLE IF EXISTS `rodings`;
CREATE TABLE `rodings`  (
  `id` int NOT NULL,
  `radius` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `pos` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of rodings
-- ----------------------------

-- ----------------------------
-- Table structure for safes
-- ----------------------------
DROP TABLE IF EXISTS `safes`;
CREATE TABLE `safes`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `pos` varchar(256) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `minamount` int NOT NULL,
  `maxamount` int NOT NULL,
  `address` varchar(256) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `rotation` varchar(256) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `idkey` int NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of safes
-- ----------------------------

-- ----------------------------
-- Table structure for shortcuts
-- ----------------------------
DROP TABLE IF EXISTS `shortcuts`;
CREATE TABLE `shortcuts`  (
  `name` varchar(35) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `num1animA` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT 'anim@heists@fleeca_bank@ig_7_jetski_owner',
  `num1animB` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT 'owner_idle',
  `num1animC` int NULL DEFAULT 1,
  `num1animD` int NULL DEFAULT 33,
  `num1name` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT 'Sitzen (Männl.)',
  `num2animA` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT 'missfbi3_sniping',
  `num2animB` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT 'dance_m_default',
  `num2animC` int NULL DEFAULT 1,
  `num2animD` int NULL DEFAULT 33,
  `num2name` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT 'Ghetto',
  `num3animA` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT 'missbigscore1switch_trevor_piss',
  `num3animB` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT 'piss_loop',
  `num3animC` int NULL DEFAULT 1,
  `num3animD` int NULL DEFAULT 33,
  `num3name` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT 'Pinkeln',
  `num4animA` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT 'rcmnigel1c',
  `num4animB` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT 'hailing_whistle_waive_a',
  `num4animC` int NULL DEFAULT 1,
  `num4animD` int NULL DEFAULT 49,
  `num4name` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT 'Pfeifen',
  `num5animA` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT 'anim@mp_player_intupperface_palm',
  `num5animB` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT 'idle_a',
  `num5animC` int NULL DEFAULT 1,
  `num5animD` int NULL DEFAULT 49,
  `num5name` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT 'Facepalm',
  `num6animA` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT 'amb@world_human_clipboard@male@idle_a',
  `num6animB` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT 'idle_c',
  `num6animC` int NULL DEFAULT 1,
  `num6animD` int NULL DEFAULT 49,
  `num6name` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT 'Notiere',
  `num7animA` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT 'anim@mp_player_intupperwave',
  `num7animB` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT 'idle_a',
  `num7animC` int NULL DEFAULT 1,
  `num7animD` int NULL DEFAULT 49,
  `num7name` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT 'Winken',
  `num8animA` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT 'anim@mp_player_intupperthumbs_up',
  `num8animB` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT 'idle_a',
  `num8animC` int NULL DEFAULT 1,
  `num8animD` int NULL DEFAULT 49,
  `num8name` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT 'Daumen hoch',
  `num9animA` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT 'anim@mp_player_intselfiethe_bird',
  `num9animB` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT 'idle_a',
  `num9animC` int NULL DEFAULT 1,
  `num9animD` int NULL DEFAULT 49,
  `num9name` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT 'Fuck you',
  PRIMARY KEY (`name`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of shortcuts
-- ----------------------------
INSERT INTO `shortcuts` VALUES ('YourName', 'anim@heists@fleeca_bank@ig_7_jetski_owner', 'owner_idle', 1, 33, 'Sitzen (Männl.)', 'missfbi3_sniping', 'dance_m_default', 1, 33, 'Ghetto', 'missbigscore1switch_trevor_piss', 'piss_loop', 1, 33, 'Pinkeln', 'rcmnigel1c', 'hailing_whistle_waive_a', 1, 49, 'Pfeifen', 'anim@mp_player_intupperface_palm', 'idle_a', 1, 49, 'Facepalm', 'amb@world_human_clipboard@male@idle_a', 'idle_c', 1, 49, 'Notiere', 'anim@mp_player_intupperwave', 'idle_a', 1, 49, 'Winken', 'anim@mp_player_intupperthumbs_up', 'idle_a', 1, 49, 'Daumen hoch', 'anim@mp_player_intselfiethe_bird', 'idle_a', 1, 49, 'Fuck you');

-- ----------------------------
-- Table structure for unitpay_payments
-- ----------------------------
DROP TABLE IF EXISTS `unitpay_payments`;
CREATE TABLE `unitpay_payments`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `unitpayId` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `account` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `sum` float NOT NULL,
  `itemsCount` int NOT NULL DEFAULT 1,
  `dateCreate` datetime NOT NULL,
  `dateComplete` datetime NULL DEFAULT NULL,
  `status` tinyint NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of unitpay_payments
-- ----------------------------

-- ----------------------------
-- Table structure for vehicles
-- ----------------------------
DROP TABLE IF EXISTS `vehicles`;
CREATE TABLE `vehicles`  (
  `number` varchar(25) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `holder` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `model` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `health` int NOT NULL,
  `fuel` int NOT NULL,
  `price` int NOT NULL,
  `components` varchar(2048) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `items` varchar(8196) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `position` varchar(256) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT '{}',
  `rotation` varchar(256) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT '{}',
  `dirt` float(255, 0) NULL DEFAULT 0,
  `keynum` int NOT NULL DEFAULT 0,
  PRIMARY KEY (`number`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of vehicles
-- ----------------------------
INSERT INTO `vehicles` VALUES ('A431V', 'Chris_Connor', 'Dominator', 1000, 92, 0, '{\"PrimColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"SecColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"NeonColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":0},\"PrimModColor\":-1,\"SecModColor\":-1,\"Muffler\":-1,\"SideSkirt\":-1,\"Hood\":-1,\"Spoiler\":-1,\"Lattice\":-1,\"Wings\":-1,\"Roof\":-1,\"Vinyls\":-1,\"FrontBumper\":-1,\"RearBumper\":-1,\"Engine\":-1,\"Turbo\":-1,\"Horn\":-1,\"Transmission\":-1,\"WindowTint\":0,\"Suspension\":-1,\"Brakes\":-1,\"Headlights\":-1,\"HeadlightColor\":0,\"NumberPlate\":0,\"Wheels\":-1,\"WheelsType\":0,\"WheelsColor\":0,\"Armor\":-1}', '[]', '', '', 0, 0);
INSERT INTO `vehicles` VALUES ('A464Y', 'Volt_Alphatester', 'Ruffian', 1000, 100, 0, '{\"PrimColor\":{\"Red\":225,\"Green\":225,\"Blue\":225,\"Alpha\":255},\"SecColor\":{\"Red\":225,\"Green\":225,\"Blue\":225,\"Alpha\":255},\"NeonColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":0},\"PrimModColor\":-1,\"SecModColor\":-1,\"Muffler\":-1,\"SideSkirt\":-1,\"Hood\":-1,\"Spoiler\":-1,\"Lattice\":-1,\"Wings\":-1,\"Roof\":-1,\"Vinyls\":-1,\"FrontBumper\":-1,\"RearBumper\":-1,\"Engine\":-1,\"Turbo\":-1,\"Horn\":-1,\"Transmission\":-1,\"WindowTint\":0,\"Suspension\":-1,\"Brakes\":-1,\"Headlights\":-1,\"HeadlightColor\":0,\"NumberPlate\":0,\"Wheels\":-1,\"WheelsType\":0,\"WheelsColor\":0,\"Armor\":-1}', '[]', '', '', 0, 0);
INSERT INTO `vehicles` VALUES ('A561S', 'Corbiezx_Dev', 'Elegy2', 1000, 95, 0, '{\"PrimColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"SecColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"NeonColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":0},\"PrimModColor\":-1,\"SecModColor\":-1,\"Muffler\":-1,\"SideSkirt\":-1,\"Hood\":-1,\"Spoiler\":3,\"Lattice\":-1,\"Wings\":-1,\"Roof\":-1,\"Vinyls\":-1,\"FrontBumper\":-1,\"RearBumper\":-1,\"Engine\":3,\"Turbo\":0,\"Horn\":-1,\"Transmission\":-1,\"WindowTint\":1,\"Suspension\":3,\"Brakes\":-1,\"Headlights\":-1,\"HeadlightColor\":0,\"NumberPlate\":0,\"Wheels\":-1,\"WheelsType\":0,\"WheelsColor\":0,\"Armor\":-1}', '[]', '', '', 0, 0);
INSERT INTO `vehicles` VALUES ('C215L', 'John_Razor', 'e63', 1000, 100, 0, '{\"PrimColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"SecColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"NeonColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":0},\"PrimModColor\":-1,\"SecModColor\":-1,\"Muffler\":-1,\"SideSkirt\":-1,\"Hood\":-1,\"Spoiler\":-1,\"Lattice\":-1,\"Wings\":-1,\"Roof\":-1,\"Vinyls\":-1,\"FrontBumper\":-1,\"RearBumper\":-1,\"Engine\":-1,\"Turbo\":-1,\"Horn\":-1,\"Transmission\":-1,\"WindowTint\":0,\"Suspension\":-1,\"Brakes\":-1,\"Headlights\":-1,\"HeadlightColor\":0,\"NumberPlate\":0,\"Wheels\":-1,\"WheelsType\":0,\"WheelsColor\":0,\"Armor\":-1}', '[]', NULL, NULL, 0, 0);
INSERT INTO `vehicles` VALUES ('D106B', 'Patte_Test', 'c63coupe', 1000, 100, 0, '{\"PrimColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"SecColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"NeonColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":0},\"PrimModColor\":-1,\"SecModColor\":-1,\"Muffler\":-1,\"SideSkirt\":-1,\"Hood\":-1,\"Spoiler\":-1,\"Lattice\":-1,\"Wings\":-1,\"Roof\":-1,\"Vinyls\":-1,\"FrontBumper\":-1,\"RearBumper\":-1,\"Engine\":-1,\"Turbo\":-1,\"Horn\":-1,\"Transmission\":-1,\"WindowTint\":0,\"Suspension\":-1,\"Brakes\":-1,\"Headlights\":-1,\"HeadlightColor\":0,\"NumberPlate\":0,\"Wheels\":-1,\"WheelsType\":0,\"WheelsColor\":0,\"Armor\":-1}', '[]', '', '', 0, 0);
INSERT INTO `vehicles` VALUES ('D236M', 'Test_Penis', 'Xa21', 1000, 100, 0, '{\"PrimColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"SecColor\":{\"Red\":255,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"NeonColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":0},\"PrimModColor\":-1,\"SecModColor\":-1,\"Muffler\":13,\"SideSkirt\":-1,\"Hood\":-1,\"Spoiler\":-1,\"Lattice\":-1,\"Wings\":-1,\"Roof\":-1,\"Vinyls\":-1,\"FrontBumper\":-1,\"RearBumper\":-1,\"Engine\":3,\"Turbo\":0,\"Horn\":-1,\"Transmission\":2,\"WindowTint\":1,\"Suspension\":3,\"Brakes\":-1,\"Headlights\":-1,\"HeadlightColor\":0,\"NumberPlate\":0,\"Wheels\":-1,\"WheelsType\":0,\"WheelsColor\":0,\"Armor\":-1}', '[]', '', '', 0, 0);
INSERT INTO `vehicles` VALUES ('D565O', 'Patte_Test', 'SultanRS', 1000, 99, 0, '{\"PrimColor\":{\"Red\":198,\"Green\":198,\"Blue\":198,\"Alpha\":255},\"SecColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"NeonColor\":{\"Red\":255,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"PrimModColor\":-1,\"SecModColor\":-1,\"Muffler\":4,\"SideSkirt\":-1,\"Hood\":-1,\"Spoiler\":-1,\"Lattice\":-1,\"Wings\":-1,\"Roof\":-1,\"Vinyls\":-1,\"FrontBumper\":-1,\"RearBumper\":-1,\"Engine\":3,\"Turbo\":0,\"Horn\":-1,\"Transmission\":2,\"WindowTint\":1,\"Suspension\":3,\"Brakes\":-1,\"Headlights\":-1,\"HeadlightColor\":0,\"NumberPlate\":0,\"Wheels\":1,\"WheelsType\":7,\"WheelsColor\":0,\"Armor\":-1}', '[]', '{\"x\":-53.08537,\"y\":-1455.5538,\"z\":31.420717}', '{\"x\":-0.88394916,\"y\":-1.023163,\"z\":-175.51363}', 0, 0);
INSERT INTO `vehicles` VALUES ('E564V', 'Test_Penis', 'Schafter3', 1000, 93, 0, '{\"PrimColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"SecColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"NeonColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":0},\"PrimModColor\":-1,\"SecModColor\":-1,\"Muffler\":-1,\"SideSkirt\":-1,\"Hood\":-1,\"Spoiler\":-1,\"Lattice\":-1,\"Wings\":-1,\"Roof\":-1,\"Vinyls\":-1,\"FrontBumper\":-1,\"RearBumper\":-1,\"Engine\":-1,\"Turbo\":-1,\"Horn\":-1,\"Transmission\":-1,\"WindowTint\":0,\"Suspension\":-1,\"Brakes\":-1,\"Headlights\":-1,\"HeadlightColor\":0,\"NumberPlate\":0,\"Wheels\":-1,\"WheelsType\":0,\"WheelsColor\":0,\"Armor\":-1}', '[]', '', '', 0, 0);
INSERT INTO `vehicles` VALUES ('F802T', 'Hanz_Wurst', 'Zentorno', 1000, 70, 0, '{\"PrimColor\":{\"Red\":209,\"Green\":63,\"Blue\":0,\"Alpha\":255},\"SecColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"NeonColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":0},\"PrimModColor\":-1,\"SecModColor\":-1,\"Muffler\":-1,\"SideSkirt\":-1,\"Hood\":-1,\"Spoiler\":-1,\"Lattice\":-1,\"Wings\":-1,\"Roof\":-1,\"Vinyls\":-1,\"FrontBumper\":-1,\"RearBumper\":-1,\"Engine\":3,\"Turbo\":0,\"Horn\":-1,\"Transmission\":-1,\"WindowTint\":0,\"Suspension\":-1,\"Brakes\":-1,\"Headlights\":-1,\"HeadlightColor\":0,\"NumberPlate\":0,\"Wheels\":-1,\"WheelsType\":0,\"WheelsColor\":0,\"Armor\":-1}', '[]', '', '', 0, 0);
INSERT INTO `vehicles` VALUES ('G034O', 'Test_Penis', 'Elegy2', 1000, 100, 0, '{\"PrimColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"SecColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"NeonColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":0},\"PrimModColor\":-1,\"SecModColor\":-1,\"Muffler\":-1,\"SideSkirt\":-1,\"Hood\":-1,\"Spoiler\":-1,\"Lattice\":-1,\"Wings\":-1,\"Roof\":-1,\"Vinyls\":-1,\"FrontBumper\":-1,\"RearBumper\":-1,\"Engine\":-1,\"Turbo\":-1,\"Horn\":-1,\"Transmission\":-1,\"WindowTint\":0,\"Suspension\":-1,\"Brakes\":-1,\"Headlights\":-1,\"HeadlightColor\":0,\"NumberPlate\":0,\"Wheels\":-1,\"WheelsType\":0,\"WheelsColor\":0,\"Armor\":-1}', '[]', '', '', 0, 0);
INSERT INTO `vehicles` VALUES ('G151O', 'Marcus_Stenhouse', 'Ruiner', 1000, 118, 0, '{\"PrimColor\":{\"Red\":225,\"Green\":225,\"Blue\":225,\"Alpha\":255},\"SecColor\":{\"Red\":225,\"Green\":225,\"Blue\":225,\"Alpha\":255},\"NeonColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":0},\"PrimModColor\":-1,\"SecModColor\":-1,\"Muffler\":-1,\"SideSkirt\":-1,\"Hood\":-1,\"Spoiler\":-1,\"Lattice\":-1,\"Wings\":-1,\"Roof\":-1,\"Vinyls\":-1,\"FrontBumper\":-1,\"RearBumper\":-1,\"Engine\":-1,\"Turbo\":-1,\"Horn\":-1,\"Transmission\":-1,\"WindowTint\":0,\"Suspension\":-1,\"Brakes\":-1,\"Headlights\":-1,\"HeadlightColor\":0,\"NumberPlate\":0,\"Wheels\":-1,\"WheelsType\":0,\"WheelsColor\":0,\"Armor\":-1}', '[]', NULL, NULL, 0, 0);
INSERT INTO `vehicles` VALUES ('G436Y', 'Timati_Blackstar', 'e63amg', 1000, 100, 0, '{\"PrimColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"SecColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"NeonColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":0},\"PrimModColor\":-1,\"SecModColor\":-1,\"Muffler\":-1,\"SideSkirt\":-1,\"Hood\":-1,\"Spoiler\":-1,\"Lattice\":-1,\"Wings\":-1,\"Roof\":-1,\"Vinyls\":-1,\"FrontBumper\":-1,\"RearBumper\":-1,\"Engine\":-1,\"Turbo\":-1,\"Horn\":-1,\"Transmission\":-1,\"WindowTint\":0,\"Suspension\":-1,\"Brakes\":-1,\"Headlights\":-1,\"HeadlightColor\":0,\"NumberPlate\":0,\"Wheels\":-1,\"WheelsType\":0,\"WheelsColor\":0,\"Armor\":-1}', '[]', '{\"x\":-106.00503,\"y\":839.78156,\"z\":234.92009}', '{\"x\":-0.8922081,\"y\":0.22452652,\"z\":-6.657615}', 0, 0);
INSERT INTO `vehicles` VALUES ('I365L', 'Rikardo_Discord', 'Baller3', 1000, 207, 0, '{\"PrimColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"SecColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"NeonColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":0},\"PrimModColor\":-1,\"SecModColor\":-1,\"Muffler\":-1,\"SideSkirt\":-1,\"Hood\":-1,\"Spoiler\":-1,\"Lattice\":-1,\"Wings\":-1,\"Roof\":-1,\"Vinyls\":-1,\"FrontBumper\":-1,\"RearBumper\":-1,\"Engine\":-1,\"Turbo\":-1,\"Horn\":-1,\"Transmission\":-1,\"WindowTint\":0,\"Suspension\":-1,\"Brakes\":-1,\"Headlights\":-1,\"HeadlightColor\":0,\"NumberPlate\":0,\"Wheels\":-1,\"WheelsType\":0,\"WheelsColor\":0,\"Armor\":-1}', '[]', '', '', 0, 0);
INSERT INTO `vehicles` VALUES ('I417Q', 'Tobias_Boemer', 'BestiaGTS', 1000, 100, 0, '{\"PrimColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"SecColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"NeonColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":0},\"PrimModColor\":-1,\"SecModColor\":-1,\"Muffler\":-1,\"SideSkirt\":-1,\"Hood\":-1,\"Spoiler\":-1,\"Lattice\":-1,\"Wings\":-1,\"Roof\":-1,\"Vinyls\":-1,\"FrontBumper\":-1,\"RearBumper\":-1,\"Engine\":-1,\"Turbo\":-1,\"Horn\":-1,\"Transmission\":-1,\"WindowTint\":0,\"Suspension\":-1,\"Brakes\":-1,\"Headlights\":-1,\"HeadlightColor\":0,\"NumberPlate\":0,\"Wheels\":-1,\"WheelsType\":0,\"WheelsColor\":0,\"Armor\":-1}', '[]', '', '', 0, 0);
INSERT INTO `vehicles` VALUES ('J465N', 'Rikardo_Discord', 'Prairie', 1000, 100, 0, '{\"PrimColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"SecColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"NeonColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":0},\"PrimModColor\":-1,\"SecModColor\":-1,\"Muffler\":-1,\"SideSkirt\":-1,\"Hood\":-1,\"Spoiler\":-1,\"Lattice\":-1,\"Wings\":-1,\"Roof\":-1,\"Vinyls\":-1,\"FrontBumper\":-1,\"RearBumper\":-1,\"Engine\":-1,\"Turbo\":-1,\"Horn\":-1,\"Transmission\":-1,\"WindowTint\":0,\"Suspension\":-1,\"Brakes\":-1,\"Headlights\":-1,\"HeadlightColor\":0,\"NumberPlate\":0,\"Wheels\":-1,\"WheelsType\":0,\"WheelsColor\":0,\"Armor\":-1}', '[]', '', '', 0, 0);
INSERT INTO `vehicles` VALUES ('K085F', 'Test_Penis', 'Reaper', 1000, 156, 0, '{\"PrimColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"SecColor\":{\"Red\":255,\"Green\":39,\"Blue\":0,\"Alpha\":255},\"NeonColor\":{\"Red\":0,\"Green\":46,\"Blue\":255,\"Alpha\":255},\"PrimModColor\":-1,\"SecModColor\":-1,\"Muffler\":-1,\"SideSkirt\":-1,\"Hood\":-1,\"Spoiler\":1,\"Lattice\":-1,\"Wings\":-1,\"Roof\":-1,\"Vinyls\":-1,\"FrontBumper\":-1,\"RearBumper\":-1,\"Engine\":3,\"Turbo\":0,\"Horn\":-1,\"Transmission\":2,\"WindowTint\":1,\"Suspension\":2,\"Brakes\":2,\"Headlights\":8,\"HeadlightColor\":0,\"NumberPlate\":2,\"Wheels\":1,\"WheelsType\":7,\"WheelsColor\":0,\"Armor\":-1}', '[]', '', '', 0, 0);
INSERT INTO `vehicles` VALUES ('N407L', 'Corbiezx_Dev', 'Jester', 1000, 70, 0, '{\"PrimColor\":{\"Red\":59,\"Green\":2,\"Blue\":2,\"Alpha\":255},\"SecColor\":{\"Red\":255,\"Green\":255,\"Blue\":255,\"Alpha\":255},\"NeonColor\":{\"Red\":255,\"Green\":1,\"Blue\":1,\"Alpha\":255},\"PrimModColor\":-1,\"SecModColor\":-1,\"Muffler\":2,\"SideSkirt\":-1,\"Hood\":-1,\"Spoiler\":0,\"Lattice\":-1,\"Wings\":-1,\"Roof\":-1,\"Vinyls\":-1,\"FrontBumper\":-1,\"RearBumper\":-1,\"Engine\":3,\"Turbo\":0,\"Horn\":-1,\"Transmission\":-1,\"WindowTint\":0,\"Suspension\":2,\"Brakes\":-1,\"Headlights\":8,\"HeadlightColor\":0,\"NumberPlate\":0,\"Wheels\":-1,\"WheelsType\":0,\"WheelsColor\":0,\"Armor\":-1}', '[]', '{\"x\":-489.57358,\"y\":-277.1914,\"z\":34.79197}', '{\"x\":0.81630504,\"y\":-3.180442,\"z\":89.743904}', 0, 0);
INSERT INTO `vehicles` VALUES ('N733W', 'Hanz_Wurst', 'Comet2', 1000, 100, 0, '{\"PrimColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"SecColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"NeonColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":0},\"PrimModColor\":-1,\"SecModColor\":-1,\"Muffler\":-1,\"SideSkirt\":-1,\"Hood\":-1,\"Spoiler\":-1,\"Lattice\":-1,\"Wings\":-1,\"Roof\":-1,\"Vinyls\":-1,\"FrontBumper\":-1,\"RearBumper\":-1,\"Engine\":-1,\"Turbo\":-1,\"Horn\":-1,\"Transmission\":-1,\"WindowTint\":0,\"Suspension\":-1,\"Brakes\":-1,\"Headlights\":-1,\"HeadlightColor\":0,\"NumberPlate\":0,\"Wheels\":-1,\"WheelsType\":0,\"WheelsColor\":0,\"Armor\":-1}', '[]', '', '', 0, 0);
INSERT INTO `vehicles` VALUES ('P775O', 'Volt_Alphatester', 'Elegy2', 1000, 100, 0, '{\"PrimColor\":{\"Red\":225,\"Green\":225,\"Blue\":225,\"Alpha\":255},\"SecColor\":{\"Red\":225,\"Green\":225,\"Blue\":225,\"Alpha\":255},\"NeonColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":0},\"PrimModColor\":-1,\"SecModColor\":-1,\"Muffler\":-1,\"SideSkirt\":-1,\"Hood\":-1,\"Spoiler\":-1,\"Lattice\":-1,\"Wings\":-1,\"Roof\":-1,\"Vinyls\":-1,\"FrontBumper\":-1,\"RearBumper\":-1,\"Engine\":-1,\"Turbo\":-1,\"Horn\":-1,\"Transmission\":-1,\"WindowTint\":0,\"Suspension\":-1,\"Brakes\":-1,\"Headlights\":-1,\"HeadlightColor\":0,\"NumberPlate\":0,\"Wheels\":-1,\"WheelsType\":0,\"WheelsColor\":0,\"Armor\":-1}', '[]', '', '', 0, 0);
INSERT INTO `vehicles` VALUES ('Q826C', 'Wiesel_Alphatester', 'GP1', 1000, 100, 0, '{\"PrimColor\":{\"Red\":255,\"Green\":115,\"Blue\":0,\"Alpha\":255},\"SecColor\":{\"Red\":255,\"Green\":115,\"Blue\":0,\"Alpha\":255},\"NeonColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":0},\"PrimModColor\":-1,\"SecModColor\":-1,\"Muffler\":-1,\"SideSkirt\":-1,\"Hood\":-1,\"Spoiler\":-1,\"Lattice\":-1,\"Wings\":-1,\"Roof\":-1,\"Vinyls\":-1,\"FrontBumper\":-1,\"RearBumper\":-1,\"Engine\":-1,\"Turbo\":-1,\"Horn\":-1,\"Transmission\":-1,\"WindowTint\":0,\"Suspension\":-1,\"Brakes\":-1,\"Headlights\":-1,\"HeadlightColor\":0,\"NumberPlate\":0,\"Wheels\":-1,\"WheelsType\":0,\"WheelsColor\":0,\"Armor\":-1}', '[]', '', '', 0, 0);
INSERT INTO `vehicles` VALUES ('R204H', 'Volt_Alphatester', 'Nightblade', 1000, 107, 0, '{\"PrimColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"SecColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"NeonColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":0},\"PrimModColor\":-1,\"SecModColor\":-1,\"Muffler\":-1,\"SideSkirt\":-1,\"Hood\":-1,\"Spoiler\":-1,\"Lattice\":-1,\"Wings\":-1,\"Roof\":-1,\"Vinyls\":-1,\"FrontBumper\":-1,\"RearBumper\":-1,\"Engine\":-1,\"Turbo\":-1,\"Horn\":-1,\"Transmission\":-1,\"WindowTint\":0,\"Suspension\":-1,\"Brakes\":-1,\"Headlights\":-1,\"HeadlightColor\":0,\"NumberPlate\":0,\"Wheels\":-1,\"WheelsType\":0,\"WheelsColor\":0,\"Armor\":-1}', '[]', '', '', 0, 0);
INSERT INTO `vehicles` VALUES ('S143T', 'Volt_Alphatester', 'Neon', 1000, 104, 0, '{\"PrimColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"SecColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"NeonColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":0},\"PrimModColor\":-1,\"SecModColor\":-1,\"Muffler\":-1,\"SideSkirt\":-1,\"Hood\":-1,\"Spoiler\":-1,\"Lattice\":-1,\"Wings\":-1,\"Roof\":-1,\"Vinyls\":-1,\"FrontBumper\":-1,\"RearBumper\":-1,\"Engine\":-1,\"Turbo\":-1,\"Horn\":-1,\"Transmission\":-1,\"WindowTint\":0,\"Suspension\":-1,\"Brakes\":-1,\"Headlights\":-1,\"HeadlightColor\":0,\"NumberPlate\":0,\"Wheels\":-1,\"WheelsType\":0,\"WheelsColor\":0,\"Armor\":-1}', '[{\"Data\":null,\"ID\":3,\"Type\":3,\"Count\":1,\"IsActive\":false}]', '', '', 0, 0);
INSERT INTO `vehicles` VALUES ('T706E', 'Hanz_Wurst', 'Comet2', 1000, 100, 0, '{\"PrimColor\":{\"Red\":0,\"Green\":230,\"Blue\":0,\"Alpha\":255},\"SecColor\":{\"Red\":0,\"Green\":230,\"Blue\":0,\"Alpha\":255},\"NeonColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":0},\"PrimModColor\":-1,\"SecModColor\":-1,\"Muffler\":-1,\"SideSkirt\":-1,\"Hood\":-1,\"Spoiler\":-1,\"Lattice\":-1,\"Wings\":-1,\"Roof\":-1,\"Vinyls\":-1,\"FrontBumper\":-1,\"RearBumper\":-1,\"Engine\":-1,\"Turbo\":-1,\"Horn\":-1,\"Transmission\":-1,\"WindowTint\":0,\"Suspension\":-1,\"Brakes\":-1,\"Headlights\":-1,\"HeadlightColor\":0,\"NumberPlate\":0,\"Wheels\":-1,\"WheelsType\":0,\"WheelsColor\":0,\"Armor\":-1}', '[]', '', '', 0, 0);
INSERT INTO `vehicles` VALUES ('U318N', 'Admyan_Admyanin', 'XLS', 1000, 100, 0, '{\"PrimColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"SecColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"NeonColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":0},\"PrimModColor\":-1,\"SecModColor\":-1,\"Muffler\":-1,\"SideSkirt\":-1,\"Hood\":-1,\"Spoiler\":-1,\"Lattice\":-1,\"Wings\":-1,\"Roof\":-1,\"Vinyls\":-1,\"FrontBumper\":-1,\"RearBumper\":-1,\"Engine\":-1,\"Turbo\":-1,\"Horn\":-1,\"Transmission\":-1,\"WindowTint\":0,\"Suspension\":-1,\"Brakes\":-1,\"Headlights\":-1,\"HeadlightColor\":0,\"NumberPlate\":0,\"Wheels\":-1,\"WheelsType\":0,\"WheelsColor\":0,\"Armor\":-1}', '[]', '', '', 0, 0);
INSERT INTO `vehicles` VALUES ('U457C', 'Vladimir_Putin', 'Ninef2', 1000, 100, 0, '{\"PrimColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"SecColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"NeonColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":0},\"PrimModColor\":-1,\"SecModColor\":-1,\"Muffler\":-1,\"SideSkirt\":-1,\"Hood\":-1,\"Spoiler\":-1,\"Lattice\":-1,\"Wings\":-1,\"Roof\":-1,\"Vinyls\":-1,\"FrontBumper\":-1,\"RearBumper\":-1,\"Engine\":-1,\"Turbo\":-1,\"Horn\":-1,\"Transmission\":-1,\"WindowTint\":0,\"Suspension\":-1,\"Brakes\":-1,\"Headlights\":-1,\"HeadlightColor\":0,\"NumberPlate\":0,\"Wheels\":-1,\"WheelsType\":0,\"WheelsColor\":0,\"Armor\":-1}', '[]', NULL, NULL, 0, 0);
INSERT INTO `vehicles` VALUES ('V248E', 'Frost_Jack', 'Tampa', 1000, 133, 0, '{\"PrimColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"SecColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"NeonColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":0},\"PrimModColor\":-1,\"SecModColor\":-1,\"Muffler\":-1,\"SideSkirt\":-1,\"Hood\":-1,\"Spoiler\":-1,\"Lattice\":-1,\"Wings\":-1,\"Roof\":-1,\"Vinyls\":-1,\"FrontBumper\":-1,\"RearBumper\":-1,\"Engine\":-1,\"Turbo\":-1,\"Horn\":-1,\"Transmission\":-1,\"WindowTint\":0,\"Suspension\":-1,\"Brakes\":-1,\"Headlights\":-1,\"HeadlightColor\":0,\"NumberPlate\":0,\"Wheels\":-1,\"WheelsType\":0,\"WheelsColor\":0,\"Armor\":-1}', '[]', NULL, NULL, 0, 0);
INSERT INTO `vehicles` VALUES ('V275V', 'Jack_Frost', 'Tampa', 1000, 100, 0, '{\"PrimColor\":{\"Red\":255,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"SecColor\":{\"Red\":255,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"NeonColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":0},\"PrimModColor\":-1,\"SecModColor\":-1,\"Muffler\":0,\"SideSkirt\":-1,\"Hood\":2,\"Spoiler\":2,\"Lattice\":2,\"Wings\":-1,\"Roof\":0,\"Vinyls\":-1,\"FrontBumper\":3,\"RearBumper\":2,\"Engine\":3,\"Turbo\":0,\"Horn\":-1,\"Transmission\":2,\"WindowTint\":1,\"Suspension\":3,\"Brakes\":2,\"Headlights\":11,\"HeadlightColor\":0,\"NumberPlate\":2,\"Wheels\":1,\"WheelsType\":7,\"WheelsColor\":0,\"Armor\":-1}', '[]', NULL, NULL, 0, 0);
INSERT INTO `vehicles` VALUES ('V368I', 'Hanz_Wurst', 'Coquette', 1000, 98, 0, '{\"PrimColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"SecColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"NeonColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":0},\"PrimModColor\":-1,\"SecModColor\":-1,\"Muffler\":-1,\"SideSkirt\":-1,\"Hood\":-1,\"Spoiler\":-1,\"Lattice\":-1,\"Wings\":-1,\"Roof\":-1,\"Vinyls\":-1,\"FrontBumper\":-1,\"RearBumper\":-1,\"Engine\":-1,\"Turbo\":-1,\"Horn\":-1,\"Transmission\":-1,\"WindowTint\":0,\"Suspension\":-1,\"Brakes\":-1,\"Headlights\":-1,\"HeadlightColor\":0,\"NumberPlate\":0,\"Wheels\":-1,\"WheelsType\":0,\"WheelsColor\":0,\"Armor\":-1}', '[]', '', '', 0, 0);
INSERT INTO `vehicles` VALUES ('W184G', 'Timati_Blackstar', 'lc200', 1000, 100, 0, '{\"PrimColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"SecColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":255},\"NeonColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":0},\"PrimModColor\":-1,\"SecModColor\":-1,\"Muffler\":-1,\"SideSkirt\":-1,\"Hood\":-1,\"Spoiler\":-1,\"Lattice\":-1,\"Wings\":-1,\"Roof\":-1,\"Vinyls\":-1,\"FrontBumper\":-1,\"RearBumper\":-1,\"Engine\":-1,\"Turbo\":-1,\"Horn\":-1,\"Transmission\":-1,\"WindowTint\":0,\"Suspension\":-1,\"Brakes\":-1,\"Headlights\":-1,\"HeadlightColor\":0,\"NumberPlate\":0,\"Wheels\":-1,\"WheelsType\":0,\"WheelsColor\":0,\"Armor\":-1}', '[]', '', '', 0, 0);
INSERT INTO `vehicles` VALUES ('Y344J', 'Admyan_Admyanin', 'Blista', 1000, 100, 0, '{\"PrimColor\":{\"Red\":255,\"Green\":115,\"Blue\":0,\"Alpha\":255},\"SecColor\":{\"Red\":255,\"Green\":115,\"Blue\":0,\"Alpha\":255},\"NeonColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":0},\"PrimModColor\":-1,\"SecModColor\":-1,\"Muffler\":-1,\"SideSkirt\":-1,\"Hood\":-1,\"Spoiler\":-1,\"Lattice\":-1,\"Wings\":-1,\"Roof\":-1,\"Vinyls\":-1,\"FrontBumper\":-1,\"RearBumper\":-1,\"Engine\":-1,\"Turbo\":-1,\"Horn\":-1,\"Transmission\":-1,\"WindowTint\":0,\"Suspension\":-1,\"Brakes\":-1,\"Headlights\":-1,\"HeadlightColor\":0,\"NumberPlate\":0,\"Wheels\":-1,\"WheelsType\":0,\"WheelsColor\":0,\"Armor\":-1}', '[]', '', '', 0, 0);
INSERT INTO `vehicles` VALUES ('Y455J', 'Hanz_Wurst', 'Comet2', 1000, 100, 0, '{\"PrimColor\":{\"Red\":0,\"Green\":230,\"Blue\":0,\"Alpha\":255},\"SecColor\":{\"Red\":0,\"Green\":230,\"Blue\":0,\"Alpha\":255},\"NeonColor\":{\"Red\":0,\"Green\":0,\"Blue\":0,\"Alpha\":0},\"PrimModColor\":-1,\"SecModColor\":-1,\"Muffler\":-1,\"SideSkirt\":-1,\"Hood\":-1,\"Spoiler\":-1,\"Lattice\":-1,\"Wings\":-1,\"Roof\":-1,\"Vinyls\":-1,\"FrontBumper\":-1,\"RearBumper\":-1,\"Engine\":-1,\"Turbo\":-1,\"Horn\":-1,\"Transmission\":-1,\"WindowTint\":0,\"Suspension\":-1,\"Brakes\":-1,\"Headlights\":-1,\"HeadlightColor\":0,\"NumberPlate\":0,\"Wheels\":-1,\"WheelsType\":0,\"WheelsColor\":0,\"Armor\":-1}', '[]', '', '', 0, 0);

-- ----------------------------
-- Table structure for weapons
-- ----------------------------
DROP TABLE IF EXISTS `weapons`;
CREATE TABLE `weapons`  (
  `id` tinyint NOT NULL,
  `lastserial` int NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of weapons
-- ----------------------------
INSERT INTO `weapons` VALUES (12, 26);
INSERT INTO `weapons` VALUES (44, 0);

SET FOREIGN_KEY_CHECKS = 1;
