const rpc = require('./gamemode/scripts/rage-rpc.min.js');
const NativeUI = require("./gamemode/scripts/nativeui.js");
const Menu = NativeUI.Menu;
const UIMenuItem = NativeUI.UIMenuItem;
const UIMenuListItem = NativeUI.UIMenuListItem;
const UIMenuCheckboxItem = NativeUI.UIMenuCheckboxItem;
const UIMenuSliderItem = NativeUI.UIMenuSliderItem;
const BadgeStyle = NativeUI.BadgeStyle;
const Point = NativeUI.Point;
const ItemsCollection = NativeUI.ItemsCollection;
const Color = NativeUI.Color;
const ListItem = NativeUI.ListItem;
const ScreenRes = mp.game.graphics.getScreenResolution(0,0);
const MenuPoint = new Point(ScreenRes.x +150, 50);

// mp.game.object.doorControl(1425919976, -631.9554, -236.3333, 38.2065, false, -631.9554, -236.3333, 38.2065); //Links
// mp.game.object.doorControl(9467943, -630.4265, -238.4375, 38.2065, false, -630.4265, -238.4375, 38.2065); //Rechts



// rpc.register("robbery:openMenu", async (message) => {
//     const ui_main_door1 = new Menu(message.name, "", MenuPoint);
//     ui_main_door1.Visible = false;
//     ui_main_door1.AddItem( new UIMenuItem("Eingangstür aufbrechen", "Löst den stillen Alarm aus!"));
//     ui_main_door1.AddItem( new UIMenuItem("Schließen", ""));
//     ui_main_door1.Visible = true;

//     return await new Promise((resolve, reject) => {
//         ui_main_door1.ItemSelect.on((item, index, value) => {
//             if (item.Text === 'Eingangstür aufbrechen') {
//                 // rpc.callServer('robbery:enter', message.name);
//                 ui_main_door1.Close();
//                 resolve({status: 1});
//             } else if (item.Text === 'Schließen') {
//                 ui_main_door1.Close();
//                 resolve({status: 0});
//             }
//         });
//     });
// });

let currentMenu;
let createMenu = (name) => {
    const ui_main_door1 = new Menu(name, "", MenuPoint);
    ui_main_door1.AddItem( new UIMenuItem("Eingangstür aufbrechen", "Löst den stillen Alarm aus!"));
    ui_main_door1.AddItem( new UIMenuItem("Schließen", ""));
    ui_main_door1.Visible = true;
    ui_main_door1.ItemSelect.on((item, index, value) => {
        if (item.Text === 'Eingangstür aufbrechen') {
            ui_main_door1.Close();
            mp.events.callRemote("robbery:etranceEvent");
        } else if (item.Text === 'Schließen') {
            ui_main_door1.Close();
        }
    });
    return ui_main_door1;
};

mp.events.add("robbery:hideMenu", () => {
    try {
        if (currentMenu) {
            currentMenu.Close();
        };
    } catch (e) {

    }

});
mp.events.add("robbery:openMenu", async (name) => {
    currentMenu = createMenu(name);
});


let coolDown = false;
mp.keys.bind(0x46, true, () => {
    if (! coolDown) {
        coolDown = true;
        // node js
        // rpc.callServer('robbery:start');
        mp.events.callRemote("robbery:start");

        setTimeout(() => {
            coolDown = false;
        }, 3000);
    }
});


let jewelryMarkers = {};
// rpc.register("robbery:loadMarkers", (message) => {
//     try {
//         jewelryMarkers[message.name].forEach(marker => marker.destroy());
//     } catch {}

//     jewelryMarkers[message.name] = [];
// 	message.markers.forEach(marker => {
//         mp.gui.chat.push(`${marker[0]}, ${marker[1]}, ${marker[2]}`);
//         jewelryMarkers[message.name].push(mp.markers.new(29, new mp.Vector3(marker[0], marker[1], marker[2]), 1,
//         {
//             direction: new mp.Vector3(marker[0], marker[1], marker[2]),
//             rotation: new mp.Vector3(0, 0, 0),
//             color: [255, 255, 255, 100],
//             visible: true,
//             dimension: 0
//         }));
//     });
// });

mp.events.add("robbery:loadMarkers", (name, markers) => {
    try {
        jewelryMarkers[name].forEach(marker => marker.destroy());
    } catch {}

    // mp.gui.chat.push(name);
    // mp.gui.chat.push(JSON.stringify(markers));

    jewelryMarkers[name] = [];
	markers.forEach(marker => {
        jewelryMarkers[name].push(mp.markers.new(29, new mp.Vector3(marker.x, marker.y, marker.z), 1,
        {
            direction: new mp.Vector3(marker.x, marker.y, marker.z),
            rotation: new mp.Vector3(0, 0, 0),
            color: [255, 255, 255, 100],
            visible: true,
            dimension: 0
        }));
    });

});

// rpc.register('robbery:destroyMarker', (message) => {
//     try {
//         jewelryMarkers[message.name][message.id].destroy();
//     } catch {}
// });

mp.events.add("robbery:destroyMarker", (name, id) => {
    // mp.gui.chat.push('destroing marker for ' + name + ' with id ' + id)
    try {
        jewelryMarkers[name][id].destroy();
    } catch {}
});
