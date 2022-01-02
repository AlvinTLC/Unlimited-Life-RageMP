let browser = mp.browsers.new('package://cef2/ipad-wrapper.html');
/*const player = mp.players.local;
mp.keys.bind(0x26, false, function () {
    if (browser != null) {
        browser.destroy();
        browser = null;
        mp.gui.cursor.show(false, false);
        mp.game.ui.displayRadar(true);
        return
    }
    if (mp.gui.cursor.visible)
        return;
	
    browser = mp.browsers.new('package://cef2/ipad-wrapper.html');
    mp.gui.cursor.show(true, true);
    mp.game.ui.displayRadar(true);
    
    
})

mp.events.add("telephone.callSpecial", () => {
      mp.gui.chat.push("Вызываем такси");
	  mp.gui.chat.push('/taxi');
    });
*/
global.board2 = mp.browsers.new('package://cef2/board2.html'); //статистика
global.openOutType = -1;

mp.keys.bind(0x4D, false, function () { // открыть
	
	if (!loggedin) return;
	if (chatActive) return;
	browser.execute('cb3.click()');
	mp.gui.cursor.show(true, true);
	/*
    if (!global.board2Open)
    {
		browser.execute('ipad-wrapper.fadeIn(1).show()');
		
		mp.events.call('donate2', 3);
		mp.events.call('board2', 4);
	}
    else
    {
		browser.execute('ipad-wrapper.fadeOut(2');
		
		mp.events.call('donate2', 2);
		mp.events.call('board2', 2);
	}
	*/
	
});

function openboard2() {

	if(board2 == null) return;
	if (global.menuCheck()) return;
	board2.execute('board2.active=true');
	global.board2Open = true;
}

function closeboard2() {
	
	if(board2 == null) return;
	board2.execute('board2.active=false');
    global.board2Open = false;
	mp.gui.cursor.show(true, true);
	
}
function miniboard2() {
	
	if(board2 == null) return;
    board2.execute(`board2.mini()`);
    global.board2Open = false;
	mp.gui.cursor.show(false, false);
	
}
function maxboard2() {
	
	if(board2 == null) return;
    board2.execute(`board2.max()`);
	global.board2Open = true;
	
}
// // //
// 0 - Open
// 1 - Close
// 2 - Statistics data
// 3 - Inventory data
// 4 - Outside data
// 5 - Outside on/off
// // //
var last
mp.events.add('board2', (act, data, index) => {
    if (board2 === null)
        global.board2 = mp.browsers.new('package://cef2/board2.html');
//    mp.gui.chat.push(`act: ${act} | data: ${data}`);

	switch(act){
		case 0:
			openboard2();
			break;
        case 1:
			closeboard2();
			break;
        case 2:
			board2.execute(`board2.stats=${data}`);
			break;
		case 3:
			miniboard2();
			break;
		case 4:
			maxboard2();
			break;
	}
});

var reds = 0;  //Donate
var donate2Opened = false;
global.donate2 = mp.browsers.new('package://cef2/donate2.html');
function opendonate2() {

	if(donate2 == null) return;
	if (global.menuCheck()) return;
    donate2Opened = true;
	donate2.active=true
    donate2.execute(`donate.show(${reds})`);
	
}

function closedonate2() {
	
	if(donate2 == null) return;
    donate2.execute(`donate.close()`);
    donate2Opened = false;
	mp.gui.cursor.show(true, true);
	
}
function minidonate2() {
	
	if(donate2 == null) return;
    donate2.execute(`donate.mini()`);
    donate2Opened = false;
	mp.gui.cursor.show(false, false);
	
}
function maxdonate2() {
	
	if(donate2 == null) return;
    donate2.execute(`donate.max()`);
	donate2Opened = true;
	
}
mp.events.add('donate2', (act, data, index) => {
    if (donate2 === null)
        global.donate2 = mp.browsers.new('package://cef2/donate2.html');
    //mp.gui.chat.push(`act: ${act} | data: ${data}`);

	switch(act){
		case 0:
			opendonate2();
			break;
        case 1:
			closedonate2();
			break;
		case 2:
			minidonate2();
			break;
		case 3:
			maxdonate2();
			break;
	}
});

mp.events.add('donbuy', (id, data) => {
    mp.events.callRemote("donate", id, data);
});
mp.events.add('redset', (reds_) => {
    reds = reds_;
    if (menu != null)
        menu.execute(`donate.balance=${reds}`);
});
mp.events.add('openInput2', (h, d, l, c) => {
    if (global.menuCheck()) return;
    input.set(h, d, l, c);
    input.open();
})
mp.events.add('addnews', () => {
mp.events.call('openInput2', 'Объявление', '6$ за каждые 20 символов', 100, 'make_ad');
});
mp.events.add('calltax', () => {
mp.events.callRemote('callst');
});
mp.events.add('callmeh', () => {
mp.events.callRemote('callsm');
});
mp.events.add('callmed', () => {
mp.events.callRemote('callsme');
});
mp.events.add('callment', () => {
mp.events.call('openInput2', 'Вызвать полицию', 'Что произошло?', 30, 'call_police');
});