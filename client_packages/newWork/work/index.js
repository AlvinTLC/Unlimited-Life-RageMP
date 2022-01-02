/*
 * Created by BlackGold
 * Garbage truck module for RageMp v1.0
 * Open-source license
 * Cannot be used for sale
 */

let i = 0;
let blip = null;
let browser = null;
let inShape = false;
let checkPoint = null;
let inCheckPoint = false;

mp.events.add("playerEnterColshape", (shape) => {
    if (shape.name == "Garbage") {
        mp.game.graphics.notify('Нажмите ~g~ E ~g~!');
        inShape = true;
    }
});

mp.events.add("playerExitColshape", (shape) => {
    if (shape.name == "Garbage") {
        inShape = false;
    }
});

mp.events.add("menuCancel", () => {
    if (browser != null) {
        browser.destroy();
        browser = null;
        mp.gui.cursor.show(false, false);
    }
});

// E
mp.keys.bind(0x45, true, function () {
    if (inShape && browser == null) {
        browser = mp.browsers.new("package://newWork/work/web/index.html");
        mp.gui.cursor.show(true, true);
    } else if (browser.active == false){
        browser.active = true;
        mp.gui.cursor.show(true, true);
    }
});

mp.events.add("WORK:START", () => {
    mp.game.graphics.notify('~g~Вы начили работу!');

    if (browser != null) {
        browser.active = false;
        mp.gui.cursor.show(false, false);
    }
    blip = mp.blips.new(1, new mp.Vector3(64.5654, -9.9216, 68.0513),
        {
            color: 5,
            shortRange: false,
            dimension: 0
        });

    blip.setRoute(true)
    checkPoint = mp.checkpoints.new(1, new mp.Vector3(64.5654, -9.9216, 68.0513), 5,
        {
            direction: new mp.Vector3(64.5654, -9.9216, 68.0513),
            color: [255, 255, 255, 255],
            visible: true,
            dimension: 0
        });
    mp.events.callRemote('SERVER:WORK:START');
});

mp.events.add("WORK:END",() => {
    mp.game.graphics.notify('~r~Вы закончили работу!');

    if (browser != null) {
        browser.destroy();
        browser = null;
        mp.gui.cursor.show(false, false);
    }

    if (blip != null && checkPoint != null) {
        blip.destroy();
        checkPoint.destroy();
        mp.events.callRemote('SERVER:WORK:END');
    }
});

//Зарплата (Можно установить и на серверной части в эвенте WORK:GARBAGE:SET:MONEY)
let salary = 5000;
mp.events.add("playerEnterCheckpoint", () => {
    inCheckPoint = true;
    mp.game.graphics.notify('~g~Машина собирает мусор');
    setTimeout(function () {
        if (inCheckPoint) {
            if (blip != null && checkPoint != null) {
                blip.destroy();
                checkPoint.destroy();
                mp.events.callRemote('WORK:GARBAGE:SET:MONEY', salary);
            }
            if (i < wayPoints.length) {
                blip = mp.blips.new(1, new mp.Vector3(wayPoints[i].x, wayPoints[i].y, wayPoints[i].z),
                    {
                        color: 5,
                        shortRange: false,
                        dimension: 0
                    });

                blip.setRoute(true)
                checkPoint = mp.checkpoints.new(1, new mp.Vector3(wayPoints[i].x, wayPoints[i].y, wayPoints[i].z), 5,
                    {
                        direction: new mp.Vector3(0, 0, 0),
                        color: [255, 255, 255, 255],
                        visible: true,
                        dimension: 0
                    });
            }
            i++;
            if (i == 3) i = 0;
        }else{
            mp.game.graphics.notify('Вернитесь в ~r~круг!');
        }
    }, 5000);
});

mp.events.add("playerExitCheckpoint",() => {
    inCheckPoint = false;

});


// Координаты чекпоинтов (можно менять добовлять удалять)
let wayPoints = [
    {x: 166.6279, y: -48.9784, z: 67.1238},
    {x: 378.7660, y: -132.4813, z: 63.9103},
    {x: 469.7218, y: -35.5125, z: 78.6428},
];