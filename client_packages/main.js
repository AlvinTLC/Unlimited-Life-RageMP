var cam = mp.cameras.new('default', new mp.Vector3(0, 0, 0), new mp.Vector3(0, 0, 0), false);
var effect = '';
global.loggedin = false;
global.lastCheck = 0;
global.chatLastCheck = 0;
global.pocketEnabled = false;

//var emscol = mp.colshapes.newSphere(264.5199, -1352.684, 23.446, 50, 0);

var Peds = [
    { Hash: -39239064, Pos: new mp.Vector3(1395.184, 3613.144, 34.9892), Angle: 270.0 }, // Caleb Baker
    { Hash: -1176698112, Pos: new mp.Vector3(166.6278, 2229.249, 90.73845), Angle: 47.0 }, // Matthew Allen
    { Hash: 1161072059, Pos: new mp.Vector3(2887.687, 4387.17, 50.65578), Angle: 174.0 }, // Owen Nelson
    { Hash: -1398552374, Pos: new mp.Vector3(2192.614, 5596.246, 53.75177), Angle: 318.0 }, // Daniel Roberts
    { Hash: -459818001, Pos: new mp.Vector3(-215.4299, 6445.921, 31.30351), Angle: 262.0 }, // Michael Turner
    { Hash: 0x9D0087A8, Pos: new mp.Vector3(480.9385, -1302.576, 29.24353), Angle: 224.0 }, // jimmylishman
    { Hash: 1706635382, Pos: new mp.Vector3(-75.66629, -1414.138, 29.31), Angle: 62.90242 }, // Gang_Family
    { Hash: 588969535, Pos: new mp.Vector3(85.79006, -1957.156, 20.74745), Angle: 320.4474 }, // Carl_Ballard
    { Hash: -812470807, Pos: new mp.Vector3(485.6168, -1529.195, 29.28829), Angle: 56.19691 }, // Chiraq_Bloody
    { Hash: 653210662, Pos: new mp.Vector3(1408.224, -1486.415, 60.65733), Angle: 192.2974 }, // Riki_Veronas
    { Hash: 663522487, Pos: new mp.Vector3(892.2745, -2172.252, 32.28627), Angle: 172.3141 }, // Santano_Amorales
    { Hash: 645279998, Pos: new mp.Vector3(-113.9224, 985.793, 235.754), Angle: 110.9234 }, // Vladimir_Medvedev - продавец дрели и отмычек
    { Hash: -236444766, Pos: new mp.Vector3(-1811.368, 438.4105, 128.7074), Angle: 348.107 }, // Kaha_Panosyan
    { Hash: -1427838341, Pos: new mp.Vector3(-1549.287, -89.35114, 54.92917), Angle: 7.874235 }, // Jotaro_Josuke
    { Hash: -2034368986, Pos: new mp.Vector3(1392.098, 1155.892, 114.4433), Angle: 82.24557 }, // Solomon_Gambino
   /*{ Hash: -1920001264, Pos: new mp.Vector3(452.2527, -993.119, 30.68958), Angle: 357.7483 }, // Alonzo_Harris
    { Hash: 368603149, Pos: new mp.Vector3(441.169, -978.3074, 30.6896), Angle: 160.1411 }, // Nancy_Spungen
    { Hash: 1581098148, Pos: new mp.Vector3(454.121, -980.0575, 30.68959), Angle: 86.12 }, // Bones_Bulldog */
    { Hash: 941695432, Pos: new mp.Vector3(149.1317, -758.3485, 242.152), Angle: 66.82055 }, //  Steve_Hain
    { Hash: 1558115333, Pos: new mp.Vector3(120.0836, -726.7773, 242.152), Angle: 248.3546 }, // Michael Bisping
    { Hash: 1925237458, Pos: new mp.Vector3(-2347.958, 3268.936, 32.81076), Angle: 240.8822 }, // Ronny_Pain
    { Hash: 988062523, Pos: new mp.Vector3(-538.2553, -198.7066, 47.42305), Angle: 0.01 }, // Anthony_Young 253.9357, 228.9332, 101.6832
    { Hash: 2120901815, Pos: new mp.Vector3(-537.9737, -186.6059, 47.42305), Angle: 90.01 }, // Lorens_Hope 262.7953, 220.5285, 101.6832
    { Hash: 826475330, Pos: new mp.Vector3(-234.94113, -922.2413, 32.30251), Angle: -20.477097 }, // Heady_Hunter 247.6933, 219.5379, 106.2869
   /* { Hash: -1420211530, Pos: new mp.Vector3(309.561, -561.0858, 43.28403), Angle: 223.6044 }, // Bdesma_Katsuni - медик тату +
    { Hash: 1092080539, Pos: new mp.Vector3(311.7008, -594.1584, 43.28402), Angle: 360.05 }, // Steve_Hobs - Медик лекарь +
    { Hash: -1306051250, Pos: new mp.Vector3(302.4196, -598.45, 43.28402), Angle: 90.05 }, // Billy_Bob - Медик гардеробщик + */
    { Hash: -907676309, Pos: new mp.Vector3(724.8585, 134.1029, 80.95643), Angle: 245.0083 }, // Ronny_Bolls
	{ Hash: 940330470, Pos: new mp.Vector3(458.7059, -995.118, 25.35196), Angle: 176.8092 }, // Rashkovsky
	{ Hash: 1596003233, Pos: new mp.Vector3(459.7471, -1000.333, 24.91329), Angle: 177.2829 }, // Muscle Prisoner
	{ Hash: 0xC8BB1E52, Pos: new mp.Vector3(-641.2701, -1288.171, 10.78), Angle: 263.1987 }, // Мужик с самбрейро Diego Gringo
	
	//EMS GARAGE -423.39996, -341.0975, 22.329397
	{ Hash: -1040164288, Pos: new mp.Vector3(-423.39996, -341.0975, 24.229397), Angle: 110.735954 }, // EMS GARAGE
	//LSPD GARAGE 457.70844, -1007.76044, 28.289936
	{ Hash: -1699520669, Pos: new mp.Vector3(457.57587, -1007.6677, 28.291332), Angle: 173.12534 }, // LSPD GARAGE
	//USMS GARAGE
	{ Hash: 512955554, Pos: new mp.Vector3(862.45514, -1346.4543, 26.042505), Angle: 88.99795 }, // USMS GARAGE
	
	//test 
	{ Hash: 0x69591CF7, Pos: new mp.Vector3(-140.0252, -882.9423, 29.53704), Angle: 118.2594 }, // spawnPlayercars
    { Hash: 0x69591CF7, Pos: new mp.Vector3(235.1766, 363.6552, 105.9), Angle: 115.267 }, // Автошкола мапеды
    { Hash: 0x69591CF7, Pos: new mp.Vector3(325.984, -1371.204, 31.90908), Angle: 93.7813 }, // ЕМС мапеды
	
	//Krankenhaus / Hospital -------------------------------------------------------------------------------------------------------------------------------
	{ Hash: -1286380898, Pos: new mp.Vector3(-435.24512, -324.165, 34.9108), Angle: 151.55 }, // Hospital Guy at Receiption +
	{ Hash: -1420211530, Pos: new mp.Vector3(-467.28265, -294.61368, 34.91), Angle: -95.19 }, // Hospital Girl +
	//Police/polizei ---------------------------------------------------------------------------------------------------------------------------------------
	//{ Hash: 1581098148, Pos: new mp.Vector3(443.59723, -979.7177, 30.68931), Angle: 85.19 }, // Police Guy at Receiption
	{ Hash: 1669696074, Pos: new mp.Vector3(484.62146, -1003.71027, 25.734661), Angle: 7.63 }, // Police Guns
	//Jobs -------------------------------------------------------------------------------------------------------------------------------------------------
	{ Hash: -907676309, Pos: new mp.Vector3(104.326126, -657.7652, 45.12385), Angle: 68.46 }, // Window Washer
	{ Hash: -1453933154, Pos: new mp.Vector3(-514.14764, -1019.1516, 23.46395), Angle: -88.40 }, // Construction
    { Hash: -973145378, Pos: new mp.Vector3(151.32138, -986.2304, 30.991936), Angle: -69.68 }, // Street_Cleaner
	//FARMER -----------------------------------------------------------------------------------------------------------------------------------------------
	{ Hash: 1822107721, Pos: new mp.Vector3(1444.0062, 1132.4636, 114.313936), Angle: -173.38 }, // Farmer
	//Diving
	{ Hash: 1822107721, Pos: new mp.Vector3(1695.9841, 43.06114, 161.76741), Angle: -96.58 }, // Diving
	//Animals ----------------------------------------------------------------------------------------------------------------------------------------------
    { Hash: -1323586730, Pos: new mp.Vector3(1449.663, 1123.5315, 113.834206), Angle: -108.23 }, // Farm Animal
    { Hash: -1323586730, Pos: new mp.Vector3(1448.094, 1120.8497, 113.834206), Angle: -163.66 }, // Farm Animal
    { Hash: -1323586730, Pos: new mp.Vector3(1445.082, 1117.4768, 113.834206), Angle: -161.47 }, // Farm Animal
    { Hash: -1323586730, Pos: new mp.Vector3(1448.949, 1116.6320, 113.834206), Angle: -72.83 }, // Farm Animal
    { Hash: -1323586730, Pos: new mp.Vector3(1453.249, 1120.7473, 113.834206), Angle: -17.23 }, // Farm Animal
    { Hash: -1323586730, Pos: new mp.Vector3(1452.587, 1116.3901, 113.834206), Angle: 102.69 }, // Farm Animal
    { Hash: -1323586730, Pos: new mp.Vector3(1444.345, 1109.5630, 113.834206), Angle: 173.75 }, // Farm Animal
    { Hash: -1323586730, Pos: new mp.Vector3(1448.373, 1114.3622, 113.834206), Angle: 114.33	}, // Farm Animal
    { Hash: -1323586730, Pos: new mp.Vector3(1446.832, 1106.6280, 113.834206), Angle: 114.35 }, // Farm Animal
    { Hash: -1323586730, Pos: new mp.Vector3(1443.702, 1103.7104, 113.834206), Angle: 97.73 }, // Farm Animal
    { Hash: 1794449327, Pos: new mp.Vector3(1446.969, 1102.1240, 113.584206), Angle: -91.45 }, // Farm Animal
    { Hash: 1794449327, Pos: new mp.Vector3(1461.216, 1108.1991, 113.584206), Angle: -44.06 }, // Farm Animal
    { Hash: 1794449327, Pos: new mp.Vector3(1461.513, 1104.0800, 113.584206), Angle: -176.44 }, // Farm Animal
    { Hash: 1794449327, Pos: new mp.Vector3(1468.620, 1101.3174, 113.584206), Angle: -112.65 }, // Farm Animal
    { Hash: 1794449327, Pos: new mp.Vector3(1472.296, 1106.1450, 113.584206), Angle: -76.14 }, // Farm Animal
    { Hash: 1794449327, Pos: new mp.Vector3(1475.019, 1102.8010, 113.584206), Angle: -131.81 }, // Farm Animal
    { Hash: 1794449327, Pos: new mp.Vector3(1476.331, 1110.9491, 113.584206), Angle: -2.71 }, // Farm Animal
    { Hash: 1794449327, Pos: new mp.Vector3(1476.016, 1115.2994, 113.584206), Angle: 68.36 }, // Farm Animal
    { Hash: 1794449327, Pos: new mp.Vector3(1469.279, 1116.8567, 113.584206), Angle: 55.27 }, // Farm Animal
    { Hash: 1794449327, Pos: new mp.Vector3(1468.241, 1121.9067, 113.584206), Angle: -2.41 }, // Farm Animal
	
	{ Hash: 1457690978, Pos: new mp.Vector3(1423.5248, 1113.4574, 113.425224), Angle: -131.81 }, // Farm Animal
    { Hash: 1457690978, Pos: new mp.Vector3(1421.5929, 1113.3555, 113.59895), Angle: -2.71 }, // Farm Animal
    { Hash: 1457690978, Pos: new mp.Vector3(1423.9218, 1114.4484, 113.38585), Angle: 68.36 }, // Farm Animal
    { Hash: 1457690978, Pos: new mp.Vector3(1424.0009, 1111.8756, 113.353676), Angle: 55.27 }, // Farm Animal
    { Hash: 1457690978, Pos: new mp.Vector3(1422.2526, 1110.4105, 113.353676), Angle: -2.41 }, // Farm Animal
	//Gardner-------------------------------------------------------------------------------------------------------------------------
	{ Hash: -2039072303, Pos: new mp.Vector3(-949.17444, 332.02942, 71.31934), Angle: -6.22 }, // Gardener
	//Loader -------------------------------------------------------------------------------------------------------------------------
	{ Hash: 1644266841, Pos: new mp.Vector3(1229.4194, -3234.0862, 6.0287633), Angle: -3.67},   //  Loader
	//Recycler -----------------------------------------------------------------------------------------------------------------------
    { Hash: 1413662315, Pos: new mp.Vector3(-428.69785, -1728.2903, 19.783838), Angle: 70.60},   //  Recycler
    //24/7 ---------------------------------------------------------------------------------------------------------------------------
    { Hash: 1162230285, Pos: new mp.Vector3(-46.98783, -1758.2107, 29.420994), Angle: 49.90}, 
    { Hash: 416176080, Pos: new mp.Vector3(24.490149, -1346.9807, 29.497025), Angle: -90.44},  
    { Hash: 416176080, Pos: new mp.Vector3(1134.1812, -982.718, 46.41584), Angle: -83.17}, 
    { Hash: 416176080, Pos: new mp.Vector3(1164.7172, -323.07434, 69.20507), Angle: 101.01},
    { Hash: 233415434, Pos: new mp.Vector3(-706.14624, -913.8626, 19.215591), Angle: 90.73},  
    { Hash: 416176080, Pos: new mp.Vector3(-1221.942, -908.254, 12.326345), Angle: 34.77},
    { Hash: 416176080, Pos: new mp.Vector3(-1486.186, -378.06015, 40.163425), Angle: 134.58},
    { Hash: 416176080, Pos: new mp.Vector3(372.63403, 326.56915, 103.566376), Angle: -103.30},
    { Hash: 416176080, Pos: new mp.Vector3(-1820.2755, 794.3063, 138.08946), Angle: 134.47},
    { Hash: 416176080, Pos: new mp.Vector3(-2966.4395, 390.97043, 15.043312), Angle: 88.76},
    { Hash: 416176080, Pos: new mp.Vector3(-3039.1372, 584.4372, 7.90893), Angle: 18.28},
    { Hash: 416176080, Pos: new mp.Vector3(-3242.351, 1000.02277, 12.830707), Angle: -6.52},
    { Hash: 416176080, Pos: new mp.Vector3(2557.1536, 380.8577, 108.62295), Angle: -0.90},
    { Hash: 416176080, Pos: new mp.Vector3(549.0378, 2671.302, 42.15653), Angle: 96.19},
    { Hash: 416176080, Pos: new mp.Vector3(1165.9176, 2710.8457, 38.157707), Angle: 179.62},
    { Hash: 1162230285, Pos: new mp.Vector3(1391.4415, 3605.8906, 34.98092), Angle: -158.06}, 
    { Hash: 1162230285, Pos: new mp.Vector3(1960.0853, 3740.0493, 32.34375), Angle: -61.59}, 
    { Hash: 1162230285, Pos: new mp.Vector3(2678.027, 3279.4412, 55.24113), Angle: -30.87},
    { Hash: 1162230285, Pos: new mp.Vector3(1697.3198, 4923.485, 42.06367), Angle: -33.75}, 
    { Hash: 1162230285, Pos: new mp.Vector3(1727.9005, 6415.2363, 35.037224), Angle: -115.13}, 
    // Bank ----------------------------------------------------------------------------------------------------------------------------
    { Hash: -1022961931, Pos: new mp.Vector3(149.44063, -1042.199, 29.367992), Angle: -18.93}, 
    { Hash: -1022961931, Pos: new mp.Vector3(-1211.9559, -331.94427, 37.780945), Angle: 19.43}, 
    { Hash: -1022961931, Pos: new mp.Vector3(313.7987, -280.45612, 54.1647), Angle: -18.44}, 
    { Hash: 1012965715, Pos: new mp.Vector3(-2961.1682, 482.9524, 15.697003), Angle: 91.72}, 
    { Hash: 2058033618, Pos: new mp.Vector3(1174.9559, 2708.214, 38.087967), Angle: -179.08}, 
    { Hash: 2093736314, Pos: new mp.Vector3(-110.17193, 6468.9263, 31.626722), Angle: 135.45}, 
    { Hash: 1074457665, Pos: new mp.Vector3(-31.312395, -1106.4996, 26.422354), Angle: -20.786491}, //PDM
    { Hash: 797459875, Pos: new mp.Vector3(114.17128, -140.46912, 54.86113), Angle: 161.09895}, //Vip autohaus
    { Hash: 1982350912, Pos: new mp.Vector3(-54.245304, 67.10422, 71.96088), Angle: 70.514336}, // Autohaus Vinewood
    { Hash: 1982350912, Pos: new mp.Vector3(289.06998, -1157.0549, 29.244246), Angle: -5.8093762}, // Mottorad händler
    { Hash: 1660909656, Pos: new mp.Vector3(1324.5143, -1650.1093, 52.27503), Angle: 130.13057}, // Tattoo1
    { Hash: 117698822, Pos: new mp.Vector3(319.77847, 180.8352, 103.58651), Angle: -109.72099}, // Tattoo2
    { Hash: 945854168, Pos: new mp.Vector3(-1152.2983, -1423.7765, 4.95446), Angle: 123.535835}, // Tattoo3
    { Hash: 1113448868, Pos: new mp.Vector3(-3170.4795, 1073.0822, 20.829187), Angle: -23.828903}, // Tattoo4
    { Hash: 1068876755, Pos: new mp.Vector3(-292.0519, 6199.7446, 31.487787), Angle: -130.37611}, // Tattoo5
    { Hash: 442429178, Pos: new mp.Vector3(1862.6208, 3748.397, 33.03211), Angle: 37.83855}, // Tattoo6
    { Hash: 2014052797, Pos: new mp.Vector3(1134.76042, -1708.0603, 29.291626), Angle: 143.65237}, // Barber1
    { Hash: 442429178, Pos: new mp.Vector3(1211.5034, -470.70483, 66.20801), Angle: 77.58462}, // Barber2
    { Hash: 1146800212, Pos: new mp.Vector3(-31.0023, -151.62404, 57.0765), Angle: -14.105802}, // Barber3
    { Hash: 808859815, Pos: new mp.Vector3(-1284.262, -1115.5663, 6.9901114), Angle: 92.38414}, // Barber4
    { Hash: 1206185632, Pos: new mp.Vector3(100.493675, -1073.0432, 29.372833), Angle: -20.02 },
];
///////////////////////// Npc Die Rumlaufen //////////////////////////////////
//mp.game.ped.removeScenarioBlockingArea(0,true);								//
//mp.game.streaming.setPedPopulationBudget(3);								//
//mp.game.ped.setCreateRandomCops(false);										//
//mp.game.vehicle.setRandomBoats(true);										//
//mp.game.vehicle.setRandomTrains(true);										//
//mp.game.vehicle.setGarbageTrucks(true);										//
//mp.game.streaming.setVehiclePopulationBudget(3);							//
//mp.game.invoke('0x34AD89078831A4BC'); // SET_ALL_VEHICLE_GENERATORS_ACTIVE	//
//mp.game.vehicle.setAllLowPriorityVehicleGeneratorsActive(true);				//
//mp.game.vehicle.setNumberOfParkedVehicles(-1);								//
//mp.game.vehicle.displayDistantVehicles(true);								//
//mp.game.graphics.disableVehicleDistantlights(false);						//
//////////////////////////////////////////////////////////////////////////////
/*mp.colshapes.forEach( 
	(colshape) => {
		if(colshape == emscol) mp.gui.chat.push("You are near EMS");
	}
);*/

setTimeout(function () {
    Peds.forEach(ped => {
        mp.peds.new(ped.Hash, ped.Pos, ped.Angle, 0);
    });
}, 10000);

mp.game.gameplay.disableAutomaticRespawn(true);
mp.game.gameplay.ignoreNextRestart(true);
mp.game.gameplay.setFadeInAfterDeathArrest(false);
mp.game.gameplay.setFadeOutAfterDeath(false);
mp.game.gameplay.setFadeInAfterLoad(false);

mp.events.add('freeze', function (toggle) {
    localplayer.freezePosition(toggle);
});

mp.events.add('destroyCamera', function () {
    cam.destroy();
    mp.game.cam.renderScriptCams(false, false, 3000, true, true);
});

mp.events.add('carRoom', function () {
    cam = mp.cameras.new('default', new mp.Vector3(-42.3758, -1101.672, 26.42235), new mp.Vector3(0, 0, 0), 50); /*Вращение спавна камеры - место*/
    cam.pointAtCoord(-42.3758, -1101.672, 26.42235); /*Позиция спавна камеры - место*/
    cam.setActive(true);
    mp.game.cam.renderScriptCams(true, false, 0, true, false);
});

mp.events.add('screenFadeOut', function (duration) {
    mp.game.cam.doScreenFadeOut(duration);
});

mp.events.add('screenFadeIn', function (duration) {
    mp.game.cam.doScreenFadeIn(duration);
});

mp.keys.bind(Keys.VK_E, false, function () { // E key
    if (!loggedin || chatActive || editing || new Date().getTime() - lastCheck < 1000 || global.menuOpened) return;
    mp.events.callRemote('interactionPressed');
    lastCheck = new Date().getTime();
    global.acheat.pos();
});

var lastScreenEffect = "";
mp.events.add('startScreenEffect', function (effectName, duration, looped) {
	try {
		lastScreenEffect = effectName;
		mp.game.graphics.startScreenEffect(effectName, duration, looped);
	} catch (e) { }
});

mp.events.add('stopScreenEffect', function (effectName) {
	try {
		var effect = (effectName == undefined) ? lastScreenEffect : effectName;
		mp.game.graphics.stopScreenEffect(effect);
	} catch (e) { }
});

mp.events.add('stopAndStartScreenEffect', function (stopEffect, startEffect, duration, looped) {
	try {
		mp.game.graphics.stopScreenEffect(stopEffect);
		mp.game.graphics.startScreenEffect(startEffect, duration, looped);
	} catch (e) { }
});

mp.events.add('setHUDVisible', function (arg) {
    mp.game.ui.displayHud(arg);
    mp.gui.chat.show(arg);
    mp.game.ui.displayRadar(arg);
});
mp.events.add('setHUDVisible', function (arg) {
    mp.game.ui.displayHud(arg);
    mp.gui.chat.show(arg);
    mp.game.ui.displayRadar(arg);
});
mp.events.add('setPocketEnabled', function (state) {
    pocketEnabled = state;
    if (state) {
        mp.gui.execute("fx.set('inpocket')");
        mp.game.invoke(getNative("SET_FOLLOW_PED_CAM_VIEW_MODE"), 4);
    }
    else {
        mp.gui.execute("fx.reset()");
    }
});

mp.keys.bind(Keys.VK_Y, false, function () {
    if (!loggedin || chatActive || editing || new Date().getTime() - lastCheck < 1000 || global.menuOpened) return;
    mp.events.callRemote('acceptPressed');
    lastCheck = new Date().getTime();
});

mp.keys.bind(Keys.VK_N, false, function () {
    if (!loggedin || chatActive || editing || new Date().getTime() - lastCheck < 1000 || global.menuOpened) return;
    mp.events.callRemote('cancelPressed');
    lastCheck = new Date().getTime();
});

mp.events.add('connected', function () {
    mp.game.ui.displayHud(false);
    cam = mp.cameras.new('default', startCamPos, startCamRot, 90.0);
    cam.setActive(true);
    mp.game.graphics.startScreenEffect('SwitchSceneMichael', 5000, false);
    var effect = 'SwitchSceneMichael';
});

mp.events.add('ready', function () {
    mp.game.ui.displayHud(true);
    //cam.setActive(false);
    //mp.game.graphics.stopScreenEffect(effect);
});

mp.events.add('kick', function (notify) {
    mp.events.call('notify', 4, 9, notify, 10000);
    mp.events.callRemote('kickclient');
});

mp.events.add('loggedIn', function () {
    loggedin = true;
});

mp.events.add('setFollow', function (toggle, entity) {
    if (toggle) {
        if (entity && mp.players.exists(entity))
            localplayer.taskFollowToOffsetOf(entity.handle, 0, 0, 0, 1, -1, 1, true)
    }
    else
        localplayer.clearTasks();
});

setInterval(function () {
    if (localplayer.getArmour() <= 0 && localplayer.getVariable('HASARMOR') === true) {
        mp.events.callRemote('deletearmor');
    }
}, 600);

mp.keys.bind(Keys.VK_U, false, function () { // Animations selector
    if (!loggedin || chatActive || editing || new Date().getTime() - lastCheck < 1000 || global.menuOpened) return;
    if (localplayer.isInAnyVehicle(true)) return;
    OpenCircle("Категории", 0);
});

mp.keys.bind(Keys.VK_L, false, function () { // L key
    if (!loggedin || chatActive || editing || new Date().getTime() - lastCheck < 1000 || global.menuOpened) return;
    mp.events.callRemote('lockCarPressed');
    lastCheck = new Date().getTime();
});

mp.keys.bind(Keys.VK_LEFT, true, () => {
	if(mp.gui.cursor.visible || !loggedin) return;
	if(localplayer.vehicle) {
		if(localplayer.vehicle.getPedInSeat(-1) != localplayer.handle) return;
		if(new Date().getTime() - lastCheck > 500) {
			lastCheck = new Date().getTime();
			if(localplayer.vehicle.getVariable('leftlight') == true) mp.events.callRemote("VehStream_SetIndicatorLightsData", localplayer.vehicle, 0, 0);
			else mp.events.callRemote("VehStream_SetIndicatorLightsData", localplayer.vehicle, 1, 0);
		}
	}
});

mp.keys.bind(Keys.VK_RIGHT, true, () => {
	if(mp.gui.cursor.visible || !loggedin) return;
	if(localplayer.vehicle) {
		if(localplayer.vehicle.getPedInSeat(-1) != localplayer.handle) return;
		if(new Date().getTime() - lastCheck > 500) {
			lastCheck = new Date().getTime();
			if(localplayer.vehicle.getVariable('rightlight') == true) mp.events.callRemote("VehStream_SetIndicatorLightsData", localplayer.vehicle, 0, 0);
			else mp.events.callRemote("VehStream_SetIndicatorLightsData", localplayer.vehicle, 0, 1);
		}
	}
});

mp.keys.bind(Keys.VK_DOWN, true, () => {
	if(mp.gui.cursor.visible || !loggedin) return;
	if(localplayer.vehicle) {
		if(localplayer.vehicle.getPedInSeat(-1) != localplayer.handle) return;
		if(new Date().getTime() - lastCheck > 500) {
			lastCheck = new Date().getTime();
			if(localplayer.vehicle.getVariable('leftlight') == true && localplayer.vehicle.getVariable('rightlight') == true) mp.events.callRemote("VehStream_SetIndicatorLightsData", localplayer.vehicle, 0, 0);
			else mp.events.callRemote("VehStream_SetIndicatorLightsData", localplayer.vehicle, 1, 1);
		}
	}
});

mp.keys.bind(Keys.VK_B, false, function () { // B key
    if (!loggedin || chatActive || editing || new Date().getTime() - lastCheck < 400 || global.menuOpened) return;
    if (localplayer.isInAnyVehicle(false) && localplayer.vehicle.getSpeed() <= 3) {
        lastCheck = new Date().getTime();
        mp.events.callRemote('engineCarPressed');
    }
});

mp.keys.bind(Keys.VK_M, false, function () { // M key
    if (!loggedin || chatActive || editing || global.menuCheck() || cuffed || localplayer.getVariable('InDeath') == true) return;
    mp.events.callRemote('openPlayerMenu');
    lastCheck = new Date().getTime();
});

mp.keys.bind(Keys.VK_X, false, function () { // X key
    if (!loggedin || chatActive || editing || new Date().getTime() - lastCheck < 1000 || global.menuOpened) return;
    mp.events.callRemote('playerPressCuffBut');
    lastCheck = new Date().getTime();
});

mp.keys.bind(Keys.VK_Z, false, function () { // Z key
    if (!loggedin || chatActive || editing || new Date().getTime() - lastCheck < 1000 || global.menuOpened) return;
	if(localplayer.vehicle) {
		if(localplayer.vehicle.getPedInSeat(-1) != localplayer.handle) CheckMyWaypoint();
		else {
			if (localplayer.vehicle.getClass() == 18) mp.events.callRemote('syncSirenSound', localplayer.vehicle);
		}
	} else mp.events.callRemote('playerPressFollowBut');
    lastCheck = new Date().getTime();
});

function CheckMyWaypoint() {
	try {
		if(mp.game.invoke('0x1DD1F58F493F1DA5')) {
			let foundblip = false;
			let blipIterator = mp.game.invoke('0x186E5D252FA50E7D');
			let totalBlipsFound = mp.game.invoke('0x9A3FF3DE163034E8');
			let FirstInfoId = mp.game.invoke('0x1BEDE233E6CD2A1F', blipIterator);
			let NextInfoId = mp.game.invoke('0x14F96AA50D6FBEA7', blipIterator);
			for (let i = FirstInfoId, blipCount = 0; blipCount != totalBlipsFound; blipCount++, i = NextInfoId) {
				if (mp.game.invoke('0x1FC877464A04FC4F', i) == 8) {
					var coord = mp.game.ui.getBlipInfoIdCoord(i);
					foundblip = true;
					break;
				}
			}
			if(foundblip) mp.events.callRemote('syncWaypoint', coord.x, coord.y);
		}
	} catch (e) { }
}

mp.events.add('syncWP', function (bX, bY, type) {
    if(!mp.game.invoke('0x1DD1F58F493F1DA5')) {
		mp.game.ui.setNewWaypoint(bX, bY);
		if(type == 0) mp.events.call('notify', 2, 9, "Der Fahrgast hat dir seine Reisedaten mitgeteilt!", 3000);
		else if(type == 1) mp.events.call('notify', 2, 9, "Die Person in der Kontaktliste deines Telefons hat dir seine Standortmarkierung mitgeteilt!", 3000);
	} else {
		if(type == 0) mp.events.call('notify', 4, 9, "Der Fahrgast hat versucht, dir die Routeninformationen zu geben, aber du hast bereits eine andere Route eingestellt.", 5000);
		else if(type == 1) mp.events.call('notify', 4, 9, "Die Person in der Kontaktliste Ihres Telefons hat versucht, dir ihr Standort-Tag zu geben, aber du hast bereits ein anderes Tag.", 5000);
	}
});

mp.keys.bind(Keys.VK_U, false, function () { // U key
    if (!loggedin || chatActive || editing || global.menuOpened || new Date().getTime() - lastCheck < 1000) return;
    mp.events.callRemote('openCopCarMenu');
    lastCheck = new Date().getTime();
});

mp.keys.bind(Keys.VK_F2, false, function () { // Курсор
    if (chatActive || (global.menuOpened && mp.gui.cursor.visible)) return;
    mp.gui.cursor.visible = !mp.gui.cursor.visible;
});

mp.keys.bind(Keys.VK_F6, false, function () { // F6 key
    /*if (global.menuCheck()) return;
    if (!mp.game.recorder.isRecording()) {
        mp.game.recorder.start(1);
    } else {
        mp.game.recorder.stop();
    }*/
});

var lastPos = new mp.Vector3(0, 0, 0);

mp.game.gameplay.setFadeInAfterDeathArrest(false);
mp.game.gameplay.setFadeInAfterLoad(false);

var deathTimerOn = false;
var deathTimer = 0;

mp.events.add('DeathTimer', (time) => {
    if (time === false)
        deathTimerOn = false;
    else {
        deathTimerOn = true;
        deathTimer = new Date().getTime() + time;
    }
});

mp.events.add('render', () => {
    if (localplayer.getVariable('InDeath') == true) {
        mp.game.controls.disableAllControlActions(2);
        mp.game.controls.enableControlAction(2, 1, true);
        mp.game.controls.enableControlAction(2, 2, true);
        mp.game.controls.enableControlAction(2, 3, true);
        mp.game.controls.enableControlAction(2, 4, true);
        mp.game.controls.enableControlAction(2, 5, true);
        mp.game.controls.enableControlAction(2, 6, true);
    }

    if (deathTimerOn) {
        var secondsLeft = Math.trunc((deathTimer - new Date().getTime()) / 1000);
        var minutes = Math.trunc(secondsLeft / 60);
        var seconds = secondsLeft % 60;
        mp.game.graphics.drawText(`Es gibt noch so viel, für das man sterben kann. ${minutes}:${seconds}`, [0.5, 0.8], {
            font: 0,
            color: [255, 255, 255, 200],
            scale: [0.35, 0.35],
            outline: true
        });
    }

    if (mp.game.controls.isControlPressed(0, 32) || 
        mp.game.controls.isControlPressed(0, 33) || 
        mp.game.controls.isControlPressed(0, 321) ||
        mp.game.controls.isControlPressed(0, 34) || 
        mp.game.controls.isControlPressed(0, 35) || 
        mp.game.controls.isControlPressed(0, 24) || 
        localplayer.getVariable('InDeath') == true) 
    {
        afkSecondsCount = 0;
    }
    else if (localplayer.isInAnyVehicle(false) && localplayer.vehicle.getSpeed() != 0) 
    {
        afkSecondsCount = 0;
    } 
    else if(spectating) 
    { // Чтобы не кикало Administratorа в режиме слежки
		afkSecondsCount = 0;
	}
});

mp.events.add("playerRuleTriggered", (rule, counter) => {
    if (rule === 'ping' && counter > 5) {
        mp.events.call('notify', 4, 2, "Dein Ping ist zu hoch. Später wiederkommen", 5000);
        mp.events.callRemote("kickclient");
    }
    /*if (rule === 'packetLoss' && counter => 10) {
        mp.events.call('notify', 4, 2, "У Вас большая потеря пакетов. Зайдите позже", 5000);
        mp.events.callRemote("kickclient");
    }*/
});