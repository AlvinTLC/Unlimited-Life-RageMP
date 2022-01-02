//SPIKES
let spikes = {}
let colshape_toggle = false;

function createspike(player, spike, pos) {
  if(mp.players.exists(player)) {
    player.playAnimation("amb@world_human_gardener_plant@male@idle_a", "idle_b", 1, 49)
    let objSpike = mp.objects.new(mp.joaat("p_stinger_04"), pos, [0, 0, 0]);
    objSpike.rotation = new mp.Vector3(0, 0, player.heading);
    let colshape = mp.colshapes.newSphere(pos.x, pos.y, pos.z, 3);
    if (spike === "spike1") spikes[player.name].spike1 = objSpike;
    else {
        spikes[player.name].spike2 = objSpike;
    };
    setTimeout(_ => {
        try{
            if (mp.players.exists(player)) player.stopAnimation();
        } catch (e){
            console.log("ERROR - Spikes - createspike: " +e);
        }
    }, 1000);
    player.call(`notification`, ["3", "Nagelband wurde ausgelegt"]);
    mp.events.add("playerEnterColshape", (player, shape) => {
        if (!colshape_toggle) {
            return false;
        }
        if (mp.players.exists(player) && mp.vehicles.exists(player.vehicle)) {
          if (shape == colshape && player.vehicle) {
              player.call("client:spikes:breaktyres", [player.vehicle])
          }
        }
    });
  }
}

mp.events.add("server:spikes:setspike", (player) => {  // DA NOCH KEIN POLIZEIMENU ERSTMAL ÜBER COMMANDS ZUM TESTEN!
  if(mp.players.exists(player)) {
    var playerPos = player.position;
    var xDistance = 1.3;
    var yDistance = 1.3;
    var StartingRotation = player.heading;
    var newAngle = 360.0 - ((StartingRotation + 360.0) % 360.0);
    var x = playerPos.x + xDistance * Math.sin(newAngle * Math.PI / 180.0);
    var y = playerPos.y + yDistance * Math.cos(newAngle * Math.PI / 180.0);
    var newPosition = new mp.Vector3(x, y, playerPos.z -= 1, player.heading);
    if(spikes[player.name] === undefined) {
        spikes[player.name] = {
            spike1: null,
            spike2: null
        };
    };
    if(player.vehicle){
        player.notify("Du willst das deine reifen platzen?");
    }
    else if (spikes[player.name].spike1 === null) {
        createspike(player, "spike1", newPosition)
        colshape_toggle = true;
    } else if (spikes[player.name].spike2 === null) {
        createspike(player, "spike2", newPosition)
        colshape_toggle = true;
    } else {
        player.notify("Du kannst nicht mehr wie 2 Nagelbänder legen");
        return false;
    };
  }
});

mp.events.add("server:spikes:removespike", (player) => {
  if(mp.players.exists(player)) {
    if (spikes[player.name] === undefined || spikes[player.name].spike1 === null)
        return player.notify("Du hast keine Nagelbänder ausgelegt!");

    if (spikes[player.name].spike1 != null) {
        let object = spikes[player.name].spike1;
        if (object) object.destroy();
        spikes[player.name].spike1 = null;
        colshape_toggle = false;
    };

    if (spikes[player.name].spike2 != null) {
        let object = spikes[player.name].spike2;
        if (object) object.destroy();
        spikes[player.name].spike2 = null;
        colshape_toggle = false;
    };

    player.call(`notification`, ["2", "Alle Nagelbänder wurden entfernt"]);
  }
});