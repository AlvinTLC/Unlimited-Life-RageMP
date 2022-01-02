let bizinfo;
var bizinfoWindow = null;
var bizinfoOppened = false;


mp.events.add('initbizinfo', () => {
    bizinfo = mp.browsers.new('package://cef/bizinfo.html');
});
// // //
mp.events.add('bizinfoShow', (data) => {
    if (bizinfo == null) {
		
        bizinfo = mp.browsers.new('package://cef/bizinfo.html');
		//mp.game.graphics.notify('~g~Есть контакт!');
    }

    var jsonHouse = JSON.parse(data);

    bizinfo.execute(`bizinfo.bizid='${jsonHouse['bizid']}'`);
    bizinfo.execute(`bizinfo.nameBiz='${jsonHouse['nameBiz']}'`);
    bizinfo.execute(`bizinfo.owner='${jsonHouse['owner']}'`);
    bizinfo.execute(`bizinfo.mafia='${jsonHouse['mafia']}'`);
    bizinfo.execute(`bizinfo.price='${jsonHouse['price']}$'`);
    bizinfo.execute("bizinfo.showbizinfo();");
    mp.gui.cursor.visible = true;
    global.menuOpened = true;

});
mp.events.add('closebizinfo', () => {
    global.menuOpened = false;
    mp.gui.cursor.visible = false;
    bizinfo.execute('bizinfo.hide();');
});
mp.events.add('buybiz', () => {
    mp.events.callRemote('buybizz');
});


mp.events.add('bizinfoOpen', (data) => {
    if (bizinfo == null) {
        bizinfo = mp.browsers.new('package://cef/bizinfo.html');
    }
    var json = JSON.parse(data);
});