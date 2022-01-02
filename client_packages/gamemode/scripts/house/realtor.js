const localPlayer = mp.players.local;
//1KR
global.realtorMenu = mp.browsers.new('package://cef/realtor.html');

mp.events.add("openRealtorMenu", (priceInfo) => {
	if(!global.loggedin) return;
	global.menuOpen();
	global.realtorMenu.active = true;
	setTimeout(function () { 
		global.realtorMenu.execute(`realtorMenu.active=true`);
		global.realtorMenu.execute(`realtorMenu.priceInfo=${priceInfo}`);
	}, 250);
});

mp.events.add("closeRealtorMenu", () => {
	setTimeout(function () { 
		global.menuClose();
		global.realtorMenu.active = false;
	}, 100);
});

mp.events.add("LoadHouse", (houses) => {
	var _houses = JSON.parse(houses);
	global.realtorMenu.execute(`realtorMenu.houses=${houses}`);
});

mp.events.add("SelectHouseClass", (hclass) => {
	mp.events.callRemote("LoadHouseToMenu", hclass);
});

mp.events.add("buyInfoHome", (x, y) => {
	mp.events.callRemote("buyRealtorInfoHome", x, y);
});

mp.events.add("getStreetAndAreaHouse", (x, y, z) => {
	var street = mp.game.pathfind.getStreetNameAtCoord(x, y, z, 0, 0);
    let areahouse  = mp.game.zone.getNameOfZone(x, y, z);
	
	global.realtorMenu.execute(`realtorMenu.street='${mp.game.ui.getStreetNameFromHashKey(street.streetName)}'`);
    global.realtorMenu.execute(`realtorMenu.crossingRoad='${mp.game.ui.getLabelText(areahouse)}'`);
});