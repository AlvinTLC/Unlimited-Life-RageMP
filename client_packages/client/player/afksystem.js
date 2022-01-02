global.afkSecondsCount = 0;

setInterval(function () {
    if (!global.menuOpened) {

        afkSecondsCount++;
        if (afkSecondsCount >= 900) {
			if(localplayer.getVariable('IS_ADMIN') == true) afkSecondsCount = 0;
			else {
				mp.gui.chat.push('Du wurdest wegen AFK über 15 Minuten aus dem Spiel entfernt.');
				mp.events.callRemote('kickclient');
			}
        }
    }
}, 1000);