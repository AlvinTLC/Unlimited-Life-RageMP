//Police
//let Leistelle = mp.colshapes.newSphere(442.02337646484375,-978.910888671875,29.689594268798828, 2, 0); //AbschleppHof
//let Leistelle1 = mp.colshapes.newSphere(-1114.161, -832.473, 30.75697, 2, 0); //Flyk
//let Leistelle2 = mp.colshapes.newSphere(-1113.278, -832.9185, 34.36106, 2, 0); //Patte
//let Leistelle3 = mp.colshapes.newSphere(-1099.679, -842.8081, 30.75685, 2, 0); //Rekruten
//let Leistelle4 = mp.colshapes.newSphere(-547.7374, -197.6723, 60.91293, 2, 0); //Andre
//let Leistelle10 = mp.colshapes.newSphere(-547.7477, -197.5413, 56.28802, 2, 0); //Rakim

mp.events.add("server:Keybind:KeyE", (player) => {
	//if (fractionData = "police")
  if (mp.players.exists(player)) {
    if(Leistelle.isPointWithin(player.position)) {
        player.call("client:police:leitstellensystem");
    }
  }
});

mp.events.add("server:Keybind:KeyE", (player) => {
	//if (fractionData = "police")
  if (mp.players.exists(player)) {
    if(Leistelle1.isPointWithin(player.position)) {
        player.call("client:police:leitstellensystem");
    }
  }
});

mp.events.add("server:Keybind:KeyE", (player) => {
	//if (fractionData = "police")
  if (mp.players.exists(player)) {
    if(Leistelle2.isPointWithin(player.position)) {
        player.call("client:police:leitstellensystem");
    }
  }
});

mp.events.add("server:Keybind:KeyE", (player) => {
	//if (fractionData = "police")
  if (mp.players.exists(player)) {
    if(Leistelle3.isPointWithin(player.position)) {
        player.call("client:police:leitstellensystem");
    }
  }
});

mp.events.add("server:Keybind:KeyE", (player) => {
	//if (fractionData = "police")
  if (mp.players.exists(player)) {
    if(Leistelle4.isPointWithin(player.position)) {
        player.call("client:police:leitstellensystem");
    }
  }
});

mp.events.add("server:Keybind:KeyE", (player) => {
	//if (fractionData = "police")
  if (mp.players.exists(player)) {
    if(Leistelle10.isPointWithin(player.position)) {
        player.call("client:police:leitstellensystem");
    }
  }
});
//Medic
//let Leistelle5 = mp.colshapes.newSphere(339.9114, -581.9561, 28.79147, 2, 0); //EingangsHalle
//let Leistelle6 = mp.colshapes.newSphere(327.1725, -595.4479, 28.79148, 2, 0); //Büro1
//let Leistelle7 = mp.colshapes.newSphere(316.3271, -592.7938, 28.79148, 2, 0); //Büro1

mp.events.add("server:Keybind:KeyE", (player) => {
	//if (fractionData = "police")
  if (mp.players.exists(player)) {
    if(Leistelle5.isPointWithin(player.position)) {
        player.call("client:police:leitstellensystem");
    }
  }
});

mp.events.add("server:Keybind:KeyE", (player) => {
	//if (fractionData = "police")
  if (mp.players.exists(player)) {
    if(Leistelle6.isPointWithin(player.position)) {
        player.call("client:police:leitstellensystem");
    }
  }
});

mp.events.add("server:Keybind:KeyE", (player) => {
	//if (fractionData = "police")
  if (mp.players.exists(player)) {
    if(Leistelle7.isPointWithin(player.position)) {
        player.call("client:police:leitstellensystem");
    }
  }
});

//Rathaus
//let Leistelle8 = mp.colshapes.newSphere(-560.3539, -209.1445, 42.70131, 2, 0); //Anwalt
//let Leistelle9 = mp.colshapes.newSphere(-547.9728, -197.602, 69.97534, 2, 0); //Bürgermeister

mp.events.add("server:Keybind:KeyE", (player) => {
	//if (fractionData = "police")
  if (mp.players.exists(player)) {
    if(Leistelle8.isPointWithin(player.position)) {
        player.call("client:police:leitstellensystem");
    }
  }
});

mp.events.add("server:Keybind:KeyE", (player) => {
	//if (fractionData = "police")
  if (mp.players.exists(player)) {
    if(Leistelle9.isPointWithin(player.position)) {
        player.call("client:police:leitstellensystem");
    }
  }
});