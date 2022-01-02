// HOUSE //
global.house = mp.browsers.new('package://cef/HouseMenu.html');

mp.events.add('HouseMenu', (id, Owner, Type, Locked, Price, Garage, Roommates) => {
	if (global.menuCheck()) return;
    menuOpen();
	house.execute(`HouseMenu.set('${id}','${Owner}','${Type}','${Locked}','${Price}','${Garage}','${Roommates}')`);
	house.execute('HouseMenu.active=1');
});

mp.events.add('HouseMenuBuy', (id, Owner, Type, Locked, Price, Garage, Roommates) => {
	if (global.menuCheck()) return;
    menuOpen();
	house.execute(`HouseMenuBuy.set('${id}','${Owner}','${Type}','${Locked}','${Price}','${Garage}','${Roommates}')`);
	house.execute('HouseMenuBuy.active=1');
});

mp.events.add("GoHouseMenu", (id) => {
    mp.events.callRemote("GoHouseMenuS", id);
	house.execute('HouseMenu.active=0');
	global.menuClose();
    mp.gui.cursor.visible = false;
});

mp.events.add('CloseHouseMenu', () => {
	house.execute('HouseMenu.active=0');
	global.menuClose();
    mp.gui.cursor.visible = false;
});

mp.events.add('CloseHouseMenuBuy', () => {
	house.execute('HouseMenuBuy.active=0');
    mp.gui.cursor.visible = false;
	global.menuClose();
});
/*Закрыть меню*/
mp.events.add('CloseExitHouseMenu', () => {
	house.execute('ExitHouseMenu.active=0');
    mp.gui.cursor.visible = false;
	global.menuClose();
});
/*Закрыть меню конец*/
mp.events.add("buyHouseMenu", (id) => {
    mp.events.callRemote("buyHouseMenuS", id);
	house.execute('HouseMenuBuy.active=0');
	global.menuClose();
    mp.gui.cursor.visible = false;
});

mp.events.add("ExitHouseMenu", () => {
	if (global.menuCheck()) return;
    menuOpen();
	house.execute('ExitHouseMenu.active=1');
});

mp.events.add("exitHouse", () => {
	mp.events.callRemote("ExitHouseMenuE"); 
	house.execute('ExitHouseMenu.active=0');
    mp.gui.cursor.visible = false;
	global.menuClose();
});
mp.events.add("Interior", (id) => {
    mp.events.callRemote("GoHouseInterS", id); //Войти в дом
    house.execute('HouseMenuBuy.active=0'); //После покупки зайти в дом
    mp.gui.cursor.visible = false;
    global.menuClose();
});
