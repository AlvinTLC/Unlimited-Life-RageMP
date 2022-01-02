﻿var dirtt = null;
var lastdirt;

mp.game.vehicle.defaultEngineBehaviour = false;
mp.players.local.setConfigFlag(429, true);

/*
if(!mp.game.streaming.hasModelLoaded(mp.game.joaat("freight"))) mp.game.streaming.requestModel(mp.game.joaat("freight"));
while(!mp.game.streaming.hasModelLoaded(mp.game.joaat("freight"))) mp.game.wait(0);
if(!mp.game.streaming.hasModelLoaded(mp.game.joaat("freightcar"))) mp.game.streaming.requestModel(mp.game.joaat("freightcar"));
while(!mp.game.streaming.hasModelLoaded(mp.game.joaat("freightcar")))mp.game.wait(0);
if(!mp.game.streaming.hasModelLoaded(mp.game.joaat("freightgrain"))) mp.game.streaming.requestModel(mp.game.joaat("freightgrain"));
while(!mp.game.streaming.hasModelLoaded(mp.game.joaat("freightgrain"))) mp.game.wait(0);
if(!mp.game.streaming.hasModelLoaded(mp.game.joaat("freightcont1"))) mp.game.streaming.requestModel(mp.game.joaat("freightcont1"));
while(!mp.game.streaming.hasModelLoaded(mp.game.joaat("freightcont1"))) mp.game.wait(0);
if(!mp.game.streaming.hasModelLoaded(mp.game.joaat("freightcont2"))) mp.game.streaming.requestModel(mp.game.joaat("freightcont2"));
while(!mp.game.streaming.hasModelLoaded(mp.game.joaat("freightcont2"))) mp.game.wait(0);
if(!mp.game.streaming.hasModelLoaded(mp.game.joaat("freighttrailer"))) mp.game.streaming.requestModel(mp.game.joaat("freighttrailer"));
while(!mp.game.streaming.hasModelLoaded(mp.game.joaat("freighttrailer"))) mp.game.wait(0);
if(!mp.game.streaming.hasModelLoaded(mp.game.joaat("tankercar"))) mp.game.streaming.requestModel(mp.game.joaat("tankercar"));
while(!mp.game.streaming.hasModelLoaded(mp.game.joaat("tankercar"))) mp.game.wait(0);
if(!mp.game.streaming.hasModelLoaded(mp.game.joaat("metrotrain"))) mp.game.streaming.requestModel(mp.game.joaat("metrotrain"));
while(!mp.game.streaming.hasModelLoaded(mp.game.joaat("metrotrain"))) mp.game.wait(0);

var train = mp.game.vehicle.createMissionTrain(15, 1907.842, -758.90493, 96.14539, true);
var train2 = mp.game.vehicle.createMissionTrain(15, 1904.756, -758.90493, 96.14539, true);
var train3 = mp.game.vehicle.createMissionTrain(24, 40.2,-1201.3,31.0, true);
var train4 = mp.game.vehicle.createMissionTrain(24, -618.0,-1476.8,16.2, true);

mp.game.invoke('0xAA0BC91BE0B796E3', train, 0.0);
mp.game.invoke('0x16469284DB8C62B5', train, 0.0);
mp.game.invoke('0xAA0BC91BE0B796E3', train2, 0.0);
mp.game.invoke('0x16469284DB8C62B5', train2, 0.0);
mp.game.invoke('0xAA0BC91BE0B796E3', train3, 0.0);
mp.game.invoke('0x16469284DB8C62B5', train3, 0.0);
mp.game.invoke('0xAA0BC91BE0B796E3', train4, 0.0);
mp.game.invoke('0x16469284DB8C62B5', train4, 0.0);

mp.events.add("Train_SetPosition", (type, x, y, z) => {
    try {
        switch(type) {
			case 0:
			mp.game.invoke('0x591CA673AA6AB736', train, x, y, z);
			break;
			case 1:
			mp.game.invoke('0x591CA673AA6AB736', train2, x, y, z);
			break;
			case 2:
			mp.game.invoke('0x591CA673AA6AB736', train3, x, y, z);
			break;
			case 3:
			mp.game.invoke('0x591CA673AA6AB736', train4, x, y, z);
			break;
		}
    } catch (e) { }
});
*/

mp.events.add("VehStream_SetEngineStatus", (veh, status, lights, left, right) => {
    try {
        if (veh !== undefined) {
            veh.setEngineOn(status, status, !status);
			veh.setUndriveable(!status);
			if(lights) {
				if(left) veh.setIndicatorLights(1, true);
				else veh.setIndicatorLights(1, false);
				if(right) veh.setIndicatorLights(0, true);
				else veh.setIndicatorLights(0, false);
			}
        }
    } catch (e) { }
});

mp.events.add("VehStream_SetSirenSound", (veh, status) => {
    try {
        if (veh && mp.vehicles.exists(veh)) {
            if (veh !== undefined && veh.getClass() == 18) veh.setSirenSound(status);
        }
    } catch (e) { }
});

mp.events.add("VehStream_SetLockStatus", (veh, status) => {
    try {
        if (veh && mp.vehicles.exists(veh)) {
            if (veh !== undefined) {
                if (status) {
                    veh.setDoorsLocked(2);
					mp.game.audio.playSoundFromEntity(1, "Remote_Control_Close", veh.handle, "PI_Menu_Sounds", true, 0);
                } else {
                    veh.setDoorsLocked(1);
					mp.game.audio.playSoundFromEntity(1, "Remote_Control_Open", veh.handle, "PI_Menu_Sounds", true, 0);
				}
            }
        }
    } catch (e) { }
});


mp.events.add("VehStream_PlayerExitVehicle", (entity) => {
    setTimeout(() => {
        var Status = [];
        let y = 0;
        for (y = 0; y < 8; y++) {
            if (entity.isDoorDamaged(y)) {
                Status.push(2);
            }
            else if (entity.getDoorAngleRatio(y) > 0.15) {
                Status.push(1);
            }
            else {
                Status.push(0);
            }
        }
        mp.events.callRemote("VehStream_SetDoorData", entity, Status[0], Status[1], Status[2], Status[3], Status[4], Status[5], Status[6], Status[7]);

        Status = [];
        if (entity.isWindowIntact(0)) {
            if (entity.getBoneIndexByName("window_rf") === -1) {
                Status.push(1);
            }
            else {
                Status.push(0);
            }
        }
        else {
            Status.push(2);
        }
        if (entity.isWindowIntact(1)) {
            if (entity.getBoneIndexByName("window_lf") === -1) {
                Status.push(1);
            }
            else {
                Status.push(0);
            }
        }
        else {
            Status.push(2);
        }
        if (entity.isWindowIntact(2)) {
            if (entity.getBoneIndexByName("window_rr") === -1) {
                Status.push(1);
            }
            else {
                Status.push(0);
            }
        }
        else {
            Status.push(2);
        }
        if (entity.isWindowIntact(3)) {
            if (entity.getBoneIndexByName("window_lr") === -1) {
                Status.push(1);
            }
            else {
                Status.push(0);
            }
        }
        else {
            Status.push(2);
        }
        mp.events.callRemote("VehStream_SetWindowData", entity, Status[0], Status[1], Status[2], Status[3]);

        Status = [];
        if (!entity.isTyreBurst(0, false)) {
            Status.push(0);
        }
        else if (entity.isTyreBurst(0, false)) {
            Status.push(1);
        }
        else {
            Status.push(2);
        }

        if (!entity.isTyreBurst(1, false)) {
            Status.push(0);
        }
        else if (entity.isTyreBurst(1, false)) {
            Status.push(1);
        }
        else {
            Status.push(2);
        }

        if (!entity.isTyreBurst(2, false)) {
            Status.push(0);
        }
        else if (entity.isTyreBurst(2, false)) {
            Status.push(1);
        }
        else {
            Status.push(2);
        }

        if (!entity.isTyreBurst(3, false)) {
            Status.push(0);
        }
        else if (entity.isTyreBurst(3, false)) {
            Status.push(1);
        }
        else {
            Status.push(2);
        }

        if (!entity.isTyreBurst(4, false)) {
            Status.push(0);
        }
        else if (entity.isTyreBurst(4, false)) {
            Status.push(1);
        }
        else {
            Status.push(2);
        }

        if (!entity.isTyreBurst(5, false)) {
            Status.push(0);
        }
        else if (entity.isTyreBurst(5, false)) {
            Status.push(1);
        }
        else {
            Status.push(2);
        }

        if (!entity.isTyreBurst(6, false)) {
            Status.push(0);
        }
        else if (entity.isTyreBurst(6, false)) {
            Status.push(1);
        }
        else {
            Status.push(2);
        }

        if (!entity.isTyreBurst(7, false)) {
            Status.push(0);
        }
        else if (entity.isTyreBurst(7, false)) {
            Status.push(1);
        }
        else {
            Status.push(2);
        }

        if (!entity.isTyreBurst(45, false)) {
            Status.push(0);
        }
        else if (entity.isTyreBurst(45, false)) {
            Status.push(1);
        }
        else {
            Status.push(2);
        }

        if (!entity.isTyreBurst(47, false)) {
            Status.push(0);
        }
        else if (entity.isTyreBurst(47, false)) {
            Status.push(1);
        }
        else {
            Status.push(2);
        }

        mp.events.callRemote("VehStream_SetWheelData", entity, Status[0], Status[1], Status[2], Status[3], Status[4], Status[5], Status[6], Status[7], Status[8], Status[9]);
    }, 2500);
});

mp.events.add("VehStream_PlayerEnterVehicle", (entity, seat, enginestate) => {
	mp.events.call("VehStream_SetEngineStatus", entity, enginestate, false, false, false);
});
	
mp.events.add("playerEnterVehicle", (entity, seat) => {
    try {
        if (seat == 0) {
            lastdirt = entity.getDirtLevel();
            if (dirtt != null) clearInterval(dirtt);
            dirtt = setInterval(function () {
                dirtlevel(entity);
            }, 20000);

            /*if (entity.getVariable('BOOST') != undefined) {
                var boost = entity.getVariable('BOOST');
                entity.setEnginePowerMultiplier(boost);
                entity.setEngineTorqueMultiplier(boost);
            }*/
        }
    } catch (e) { }
});

mp.events.add("playerLeaveVehicle", (entity) => {
    try {
        if (dirtt != null) {
            clearInterval(dirtt);
            dirtt = null;
        }
    } catch (e) { }
});

mp.events.add("VehStream_SetVehicleDoorStatus_Single", (veh, door, state) => {
    try {
        if (veh && mp.vehicles.exists(veh)) {
            if (veh !== undefined) {
                if (state === 0) {
                    veh.setDoorShut(door, false);
                }
                else if (state === 1) {
                    veh.setDoorOpen(door, false, false);
                }
                else {
                    veh.setDoorBroken(door, true);
                }
            }
        }
    } catch (e) { }
});

mp.events.add("VehStream_SetVehicleDoorStatus", (...args) => {
    try {
        if (args[0] && mp.vehicles.exists(args[0])) {
            if (args[0] !== undefined) {
                let y = 0;
                for (y = 1; y < args.length; y++) {
                    if (args[y] === 0) {
                        args[0].setDoorShut(y - 1, false);
                    }
                    else if (args[y] === 1) {
                        args[0].setDoorOpen(y - 1, false, false);
                    }
                    else {
                        args[0].setDoorBroken(y - 1, true);
                    }
                }
            }
        }
    } catch (e) { }
});

mp.events.add("VehStream_FixStreamIn", (entity, data) => {
    if (entity.type !== "vehicle") return;
    if (entity && mp.vehicles.exists(entity)) {
        let typeor = typeof entity.getVariable('VehicleSyncData');
        let actualData = entity.getVariable('VehicleSyncData');

        //Do it anyway
        entity.setUndriveable(true);
		
		//(if(entity.getClass() == 18) entity.setSirenSound(entity.getVariable('SIRENSOUND'));
        if (typeor !== 'undefined') {
            actualData = JSON.parse(actualData);
            entity.setEngineOn(actualData.Engine, actualData.Engine, !actualData.Engine);
            entity.setUndriveable(true);
            entity.setDirtLevel(actualData.Dirt);

            if (actualData.Locked) entity.setDoorsLocked(2);
            else entity.setDoorsLocked(1);
			
			if(actualData.RightIL) entity.setIndicatorLights(0, true);
			else entity.setIndicatorLights(0, false);
			if(actualData.LeftIL) entity.setIndicatorLights(1, true);
			else entity.setIndicatorLights(1, false);
				
            for (x = 0; x < 8; x++) {
                if (actualData.Door[x] === 1)
                    entity.setDoorOpen(x, false, false);
                else if (actualData.Door[x] === 0)
                    entity.setDoorShut(x, true);
                else
                    entity.setDoorBroken(x, true);
            }
        }

        data = JSON.parse(data);
        entity.setNumberPlateText(data[0]);
        entity.setColours(data[1], data[2]);
        if (data[3] != null) {
            //mp.gui.chat.push('VehStream_FixStreamIn check');
            data = data[3];

            entity.setMod(4, data.Muffler);
            entity.setMod(3, data.SideSkirt);
            entity.setMod(7, data.Hood);
            entity.setMod(0, data.Spoiler);
            entity.setMod(6, data.Lattice);
            entity.setMod(8, data.Wings);
            entity.setMod(10, data.Roof);
            entity.setMod(48, data.Vinyls);
            entity.setMod(1, data.FrontBumper);
            entity.setMod(2, data.RearBumper);

            entity.setMod(11, data.Engine);
            entity.setMod(18, data.Turbo);
            entity.setMod(13, data.Transmission);
            entity.setMod(15, data.Suspension);
            entity.setMod(12, data.Brakes);
			if(data.Headlights >= 0) {
				entity.setMod(22, 0);
				SetHLColor(entity, entity.getVariable('hlcolor'));
			} else entity.setMod(22, data.Headlights);
            entity.setMod(14, data.Horn);

            entity.setWindowTint(data.WindowTint);

            entity.setCustomPrimaryColour(data.PrimColor.Red, data.PrimColor.Green, data.PrimColor.Blue);
            entity.setCustomSecondaryColour(data.SecColor.Red, data.SecColor.Green, data.SecColor.Blue);

            entity.setWheelType(data.WheelsType);
            entity.setMod(23, data.Wheels);
        }
    }
});

	
function dirtlevel(entity) {
    try {
        if (entity && mp.vehicles.exists(entity)) {
            if (localplayer.vehicle == entity && entity.getPedInSeat(-1) == localplayer.handle)
                mp.events.call("VehStream_GetVehicleDirtLevel", entity);
        }
        else {
            if (dirtt != null) {
                clearInterval(dirtt);
                dirtt = null;
            }
        }
    } catch (e) {
    }
};

mp.events.add("VehStream_SetVehicleDirtLevel", (entity, dirt) => {
    try {
        if (entity && mp.vehicles.exists(entity)) {
            if (entity !== undefined) {
                entity.setDirtLevel(dirt);
                if (entity.getPedInSeat(-1) == mp.players.local.handle) {
                    lastdirt = dirt;
                }
            }
        }
    } catch (e) {
    }
});
mp.events.add("VehStream_GetVehicleDirtLevel", (entity) => {
    try {
        if (entity && mp.vehicles.exists(entity)) {
            if (entity !== undefined) {
                if (entity.getPedInSeat(-1) == mp.players.local.handle) {
                    let curdirt = parseFloat(entity.getDirtLevel());
                    let raznica = parseFloat((curdirt - lastdirt));
                    if (raznica >= 0.01) {
                        raznica = raznica/3;
                        let newdirt = parseFloat((lastdirt + raznica));
                        if (newdirt > 15) newdirt = 15;
                        lastdirt = newdirt;
                        mp.events.callRemote("VehStream_SetVehicleDirt", entity, newdirt);
                    }
                }
            }
        }
    } catch (e) {
    }
});

mp.events.add("VehStream_SetVehicleDoorStatus_Single", (veh, door, state) => {
    if (veh !== undefined) {
        if (state === 0) {
            veh.setDoorShut(door, false);
        }
        else if (state === 1) {
            veh.setDoorOpen(door, false, false);
        }
        else {
            veh.setDoorBroken(door, true);
        }
    }
});

mp.events.add("VehStream_SetVehicleDoorStatus", (...args) => {
    if (args[0] !== undefined) {
        let y = 0;
        for (y = 1; y < args.length; y++) {
            if (args[y] === 0) {
                args[0].setDoorShut(y - 1, false);
            }
            else if (args[y] === 1) {
                args[0].setDoorOpen(y - 1, false, false);
            }
            else {
                args[0].setDoorBroken(y - 1, true);
            }
        }
    }
});

mp.events.add("VehStream_SetVehicleWindowStatus_Single", (veh, windw, state) => {
    if (veh !== undefined) {
        if (state === 1) {
            veh.rollDownWindow(windw);
        }
        else if (state === 0) {
            veh.fixWindow(windw);
            veh.rollUpWindow(windw);
        }
        else {
            veh.smashWindow(windw);
        }
    }
});

mp.events.add("VehStream_SetVehicleWindowStatus", (...args) => {
    if (args[0] !== undefined) {
        let y = 0;
        for (y = 1; y < 4; y++) {
            if (args[y] === 1) {
                args[0].rollDownWindow(y - 1);
            }
            else if (args[y] === 0) {
                args[0].fixWindow(y - 1);
                args[0].rollUpWindow(y - 1);
            }
            else {
                args[0].smashWindow(y - 1);
            }
        }
    }
});

mp.events.add("VehStream_SetVehicleWheelStatus_Single", (veh, wheel, state) => {
    if (veh !== undefined) {
        if (wheel === 9) {
            if (state === 1) {
                veh.setTyreBurst(45, false, 1000);
            }
            else if (state === 0) {
                veh.setTyreFixed(45);
            }
            else {
                veh.setTyreBurst(45, true, 1000);
            }
        }
        else if (wheel === 10) {
            if (state === 1) {
                veh.setTyreBurst(47, false, 1000);
            }
            else if (state === 0) {
                veh.setTyreFixed(47);
            }
            else {
                veh.setTyreBurst(47, true, 1000);
            }
        }
        else {
            if (state === 1) {
                veh.setTyreBurst(wheel, false, 1000);
            }
            else if (state === 0) {
                veh.setTyreFixed(wheel);
            }
            else {
                veh.setTyreBurst(wheel, true, 1000);
            }
        }
    }
});

mp.events.add("VehStream_SetVehicleWheelStatus", (...args) => {
    if (args[0] !== undefined) {
        let y = 0;
        for (y = 1; y < args.length; y++) {
            if (y === 9) {
                if (args[y] === 1) {
                    args[0].setTyreBurst(45, false, 1000);
                }
                else if (args[y] === 0) {
                    args[0].setTyreFixed(45);
                }
                else {
                    args[0].setTyreBurst(45, true, 1000);
                }
            }
            else if (y === 10) {
                if (args[y] === 1) {
                    args[0].setTyreBurst(47, false, 1000);
                }
                else if (args[y] === 0) {
                    args[0].setTyreFixed(47);
                }
                else {
                    args[0].setTyreBurst(47, true, 1000);
                }
            }
            else {
                if (args[y] === 1) {
                    args[0].setTyreBurst(y - 1, false, 1000);
                }
                else if (args[y] === 0) {
                    args[0].setTyreFixed(y - 1);
                }
                else {
                    args[0].setTyreBurst(y - 1, true, 1000);
                }
            }
        }
    }
});

//Sync data on stream in
mp.events.add("entityStreamIn", (entity) => {
    try {
        if (entity.type !== "vehicle") return;
        if (entity && mp.vehicles.exists(entity))
        {
            let typeor = typeof entity.getVariable('VehicleSyncData');
            let actualData = entity.getVariable('VehicleSyncData');

            //Needed to stop vehicles from freaking out
            mp.game.streaming.requestCollisionAtCoord(entity.position.x, entity.position.y, entity.position.z);
            //mp.game.invoke(getNative("REQUEST_ADDITIONAL_COLLISION_AT_COORD"), entity.position.x, entity.position.y, entity.position.z);
            entity.setLoadCollisionFlag(true);
            entity.trackVisibility();

            //Set doors unbreakable for a moment
            let x = 0;
            for (x = 0; x < 8; x++) {
                entity.setDoorBreakable(x, false);
            }

            //Do it anyway
            entity.setUndriveable(true);

            if (typeor !== 'undefined') {
                actualData = JSON.parse(actualData);
                entity.setEngineOn(actualData.Engine, true, false);
                entity.setUndriveable(true);

                if (actualData.Locked)
                    entity.setDoorsLocked(2);
                else
                    entity.setDoorsLocked(1);

                for (x = 0; x < 8; x++) {
                    if (actualData.Door[x] === 1)
                        entity.setDoorOpen(x, false, false);
                    else if (actualData.Door[x] === 0)
                        entity.setDoorShut(x, true);
                    else
                        entity.setDoorBroken(x, true);
                }
				
				for (x = 0; x < 4; x++) {
					if (actualData.Window[x] === 0)
						entity.fixWindow(x);
					else if (actualData.Window[x] === 1)
						entity.rollDownWindow(x);
					else
						entity.smashWindow(x);
                }
				
				for (x = 0; x < 8; x++) {
					if (actualData.Wheel[x] === 0)
						entity.setTyreFixed(x);
					else if (actualData.Wheel[x] === 1)
						entity.setTyreBurst(x, false, 0);
					else
						entity.setTyreBurst(x, true, 1000);
				}

                if (typeof entity.getVariable('HeadlightsColor') !== 'undefined') {
                    let headlightsColor = entity.getVariable('HeadlightsColor');
                    if (headlightsColor > 0) {
                        entity.setMod(22, 0);
                        mp.game.invoke(global.getNative("_SET_VEHICLE_HEADLIGHTS_COLOUR"), entity.handle, headlightsColor);
                    }
                    else {
                        entity.setMod(22, headlightsColor);
                    }
                }

                if (typeof entity.getVariable('NeonColor') !== 'undefined') {
                    let neonColors = entity.getVariable('NeonColor');

                    entity.setNeonLightsColour(neonColors[0], neonColors[1], neonColors[2]);

                    entity.setNeonLightEnabled(0, true);
                    entity.setNeonLightEnabled(1, true);
                    entity.setNeonLightEnabled(2, true);
                    entity.setNeonLightEnabled(3, true);
                }
            }
            else
                mp.events.callRemote("VehStream_RequestFixStreamIn", entity);

            //Make doors breakable again
            setTimeout(() => {
                for (x = 0; x < 8; x++) {
                    if (entity && mp.vehicles.exists(entity))
                        entity.setDoorBreakable(x, true);
                }
            }, 1500);
        }
    } catch (e) { }
});

mp.keys.bind(0x60, true, _ => {
    if (localPlayer.vehicle && localPlayer.vehicle.getPedInSeat(-1) === localPlayer.handle && localPlayer.vehicle.getClass() === 18) {
        localPlayer.vehicle.getVariable('silentMode') ? mp.game.graphics.notify(`Silent mode is deactivated.`) : mp.game.graphics.notify(`Silent mode is activated.`);
        mp.events.callRemote('syncSirens', localPlayer.vehicle)
    }
});

mp.events.add('entityStreamIn', (entity) => {
    if (entity.type === 'vehicle' && entity.getClass() === 18 && entity.hasVariable('silentMode')) entity.getVariable('silentMode') ? entity.setSirenSound(true) : entity.setSirenSound(false);
    
});

mp.events.addDataHandler("silentMode", (entity, value) => {
    if (entity.type === "vehicle") entity.setSirenSound(value);
});
mp.events.add("VehStream_SetVehicleIndicatorLights_Single", (veh, light, state) => {
	try {
		if (veh && mp.vehicles.exists(veh)) {
			if (veh !== undefined) {
				if (light == 0) {
					if(state) veh.setIndicatorLights(0, true);
					else veh.setIndicatorLights(0, false);
				} else if(light == 1) {
					if(state) veh.setIndicatorLights(1, true);
					else veh.setIndicatorLights(1, false);
				}
			}
		}
	} catch (e) {
	}
});

mp.events.add("VehStream_SetVehicleIndicatorLights", (...args) => {
	try {
		if (args[0] && mp.vehicles.exists(args[0])) {
			if (args[0] !== undefined) {
				let y = 0;
				if(args[1]) args[0].setIndicatorLights(1, true);
				else args[0].setIndicatorLights(1, false);
				if(args[2]) args[0].setIndicatorLights(0, true);
				else args[0].setIndicatorLights(0, false);
			}
		}
	} catch (e) {
	}
});

mp.events.add("VehStream_SetVehicleHeadLightColor", (entity, color) => {
	try {
		if (entity && mp.vehicles.exists(entity)) {
			if (entity !== undefined) SetHLColor(entity,color);
		}
	} catch (e) {
	}
});

function SetHLColor(vehicle, color) {
	try {
		if (vehicle && mp.vehicles.exists(vehicle)) mp.game.invoke('0xE41033B25D003A07', vehicle.handle, color);
	} catch (e) {
	}
}