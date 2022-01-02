mp.game.audio.setRadioToStationName("OFF");
mp.game.audio.setUserRadioControlEnabled(true);

mp.events.add("render", () => {

    if (mp.players.local.vehicle) {
        mp.game.audio.setRadioToStationName("OFF");
        mp.game.audio.setUserRadioControlEnabled(true);
    }

});