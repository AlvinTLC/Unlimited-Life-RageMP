let browser = null;
let lastInteract = 0;
let tabletReady = false;
let tablet = null;
let openSite = 'https://tablet.ulife-rp.eu/tablet.html'

function canInteract() { return lastInteract + 1000 < Date.now() }

//mp.keys.bind(0x72, false, function ()

mp.keys.bind(0x72, false, function() {
    if (browser != null) {
        browser.destroy();
        browser = null;
        mp.gui.cursor.show(false, false);
        mp.game.ui.displayRadar(true);
        return
    }
    if(!mp.gui.cursor.visible) {
     mp.events.callRemote("tablet:request");
 }
});

mp.events.add('fraktablet', () => {
    browser = mp.browsers.new('package://tablet/tablet.html');

    mp.gui.cursor.show(true, true);
    mp.game.ui.displayRadar(false);

})