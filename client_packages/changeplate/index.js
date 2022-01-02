global.changer = mp.browsers.new('package://changeplate/changeplate.html'); //статистика
global.openOutType = -1;
global.changerOpen = false;

function opens() {

	if(changer == null) return;
	if (global.menuCheck()) return;
    menuOpen();
	changer.execute(`changeplatehtml.active=true`);
	global.changerOpen = true;
}

function closeds() {
	if(changer == null) return;
    menuClose();
	changer.execute(`changeplatehtml.active=false`);
    global.changerOpen = false;
	
}

mp.events.add('changer', (act, data) => {
    if (changer === null)
        global.changer = mp.browsers.new('package://changeplate/changeplate.html');
    //mp.gui.chat.push(`act: ${act} | data: ${data}`);

	switch(act){
		case 0:
			opens();
			break;
        case 1:
			closeds();
			break;
		case 2:
			changer.execute(`changeplatehtml.oldnumber=${data}`);
			break;
	}
});
mp.events.add('newnumber', (newnumber, moneysystem) => {
mp.events.callRemote('changeplate', newnumber, moneysystem);
});