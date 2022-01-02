let localPlayer = mp.players.local;

mp.keys.bind(0x60, true, _ => {
    if (localPlayer.vehicle && localPlayer.vehicle.getPedInSeat(-1) === localPlayer.handle && localPlayer.vehicle.getClass() === 18) {
        localPlayer.vehicle.getVariable('silentMode') ? mp.game.graphics.notify("Code 2 Deaktiviert") : mp.game.graphics.notify("Code 2 Aktiv");
        mp.events.callRemote('syncSirens', localPlayer.vehicle)
    }
});

mp.events.add('entityStreamIn', (entity) => {
    if (entity.type === 'vehicle' && entity.getClass() === 18 && entity.hasVariable('silentMode')) entity.getVariable('silentMode') ? entity.setSirenSound(true) : entity.setSirenSound(false);

});

mp.events.addDataHandler("silentMode", (entity, value) => {
    if (entity.type === "vehicle") entity.setSirenSound(value);
});