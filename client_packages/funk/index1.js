
'use strict';
let FunkBrowser = undefined;
let player = mp.players.local;
var showing = false;


mp.keys.bind(global.Keys.VK_ALT, 'Client:Funk:Open', () => {

    // If the Browser is undefined then he create the browser
	if(FunkBrowser === undefined && showing === false) {
		showing = true;
    	// Create the Browser
		mp.events.call('INVENTORY::TOGGLE', false);
    FunkBrowser = mp.browsers.new("package://cef/funk/index.html");
		mp.gui.cursor.visible = true;
    } else {
		if(mp.gui.cursor.visible === false) mp.gui.cursor.visible = true;
	}
});

mp.events.add('Client:Funk:Close', () => {
    // Destory the Browser and set it at undefined
	FunkBrowser.destroy();
  FunkBrowser = undefined;
	showing = false;
	mp.gui.cursor.visible = false;
});

mp.events.add('Client:Funk:ChangeFrequenz', (frequenz) => {
	mp.events.callRemote('Server:Funk:ChangeFrequenz', frequenz);
});


