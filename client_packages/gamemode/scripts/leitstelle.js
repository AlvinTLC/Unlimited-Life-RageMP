mp.events.add("client:police:leitstellensystem", (link) => {
     akten = mp.browsers.new('package://cef/Leitstelle/index.html');
     mp.gui.cursor.show(true, true);
     mp.gui.chat.activate(false);
});

mp.events.add("client:police:closeLeitstelle", () => {
mp.gui.cursor.show(false);

	if(akten === null) {
	  return;
	}

	akten.destroy();
	akten = null;
});

mp.keys.bind(0x45, true, function() {
    mp.events.callRemote('server:Keybind:KeyE');
});
