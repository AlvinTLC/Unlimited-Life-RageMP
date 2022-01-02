let infoped = null
let colEntered = false
let pedLocation = {x:-1032.1105,y:-2736.8042,z:20.169273}

mp.peds.new(mp.game.joaat('cs_bankman'), new mp.Vector3(pedLocation.x, pedLocation.y, pedLocation.z), 97.40323, mp.players.local.dimension)
mp.labels.new("~orange~Thomas Norris", new mp.Vector3(pedLocation.x, pedLocation.y, pedLocation.z+1.1), {los: true, font: 4, drawDistance: 5,})
mp.labels.new("Klicke auf ~b~E", new mp.Vector3(pedLocation.x, pedLocation.y, pedLocation.z+1), {los: true, font: 4, drawDistance: 5,})
mp.blips.new(480, new mp.Vector3(pedLocation.x, pedLocation.y, 0), {name: 'Information', scale: 1, color: 5, shortRange: true})

mp.markers.new(27, new mp.Vector3(pedLocation.x, pedLocation.y, pedLocation.z-0.95), 1.5)
let colInfo = mp.colshapes.newCircle(pedLocation.x, pedLocation.y, 1.5, mp.players.local.dimension)

mp.events.add('playerEnterColshape', (shape) => {
    if(shape == colInfo) {
        colEntered = true
    }
});

mp.events.add("playerExitColshape", (shape) => {
    if(shape == colInfo) {
        colEntered = false
    }
})

mp.keys.bind(0x45, true, function () {
    if (colEntered == true && infoped == null) {
        infoped = mp.browsers.new("package://ped/cef/infoped.html")
        mp.gui.cursor.show(true, true)
    } else if (colEntered == true && infoped.active == false){
        infoped.active = true
        mp.gui.cursor.show(false, false)
    }
})

mp.events.add('closePedInfo', () => {
    infoped.active = false
    mp.gui.cursor.show(false, false)
})
