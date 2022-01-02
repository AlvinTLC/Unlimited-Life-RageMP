// const rpc = require('rage-rpc');

// let JEWELRIES_STORAGE= {};


// rpc.register("robbery:start", (message, info) => {
//     let player = info.player;

//     for (let key in JEWELRIES_STORAGE) {
//         let jewelry = JEWELRIES_STORAGE[key];
//         try {
//             // Rob store
//             jewelry.colshapes.forEach((j, id) => {
//                 if (j.isPointWithin(player.position)) {
//                     jewelry.robberyAction(player, id);
//                 }
//             });

//             // Open menu
//             if (jewelry.entrance.isPointWithin(player.position)) {
//                 jewelry.openMenu(player);
//             }
//         } catch {
//             console.log('robbery: colshapes error');
//         }
//     }
// });

// class Jewelry {
//     constructor(name = 'Juwelier', x, y, z, colshapes = []) {
//         this.name = name;
//         this.x = x;
//         this.y = y;
//         this.z = z;
//         this.colshapes = [];
        
//         this.policeOnDuty = true; // TODO: Check by database or events from C#

//         this.entrance = mp.colshapes.newSphere(x, y, z, 0.3);
//         this.marker = mp.markers.new(29, new mp.Vector3(x, y, z), 1, {
//             direction: new mp.Vector3(x, y, z),
//             rotation: new mp.Vector3(0, 0, 0),
//             color: [0, 255, 0, 100],
//             visible: true,
//             dimension: 0
//         });

//         // Constructor simplifying
//         if (colshapes.length === 0) {
//             colshapes = [[x, y, z]];
//         }
//         // Storing original jewelries positions (as [ [x, y, z], ... ])
//         this.jewelriesPosition = colshapes;
//         // Creating jewelries colshapes
//         colshapes.forEach(j => {
//             this.colshapes.push(mp.colshapes.newSphere(j[0], j[1], j[2], 0.3));
//         });

//         // Last date when the store was opened (robbed)
//         this.lastEntranceAt = 0;
//         // Last date when element was taken from the store  (robbed)
//         this.lastActionAt = {};
//         // Time in ms for opening store
//         this.entranceHandlerDuration = 3000;
//         // Time in ms for taking element from store
//         this.jewelrlyHandlerDuration = 6000;
//         // Original store state (if set to false)
//         this.locked = true; // if you change it to false, then store 

//         this.robberyWeaponHash = 0x84BD7BFD;
//         this.entranceAnimation = ['amb@medic@standing@kneel@base', 'base'];
//         this.robberyAnimation = ['missheist_jewel', 'smash_case'];
//         this.robberyCooldown = 600000;

//         JEWELRIES_STORAGE[this.name] = this;
//     }

//     setBlip(id, color, customName = false) {
//         this.blip = mp.blips.new(id, new mp.Vector3(this.x, this.y, 0),
//             {
//                 name: customName ? customName : this.name,
//                 color: color,
//                 shortRange: true,
//         });
//     }

//     set entranceDuration (ms) {
//         this.entranceHandlerDuration = ms;
//     }

//     set robberyActionDuration (ms) {
//         this.jewelrlyHandlerDuration = ms;
//     }

//     robberyPossible() {
//         return this.policeOnDuty && Date.now() > (this.lastEntranceAt + this.robberyCooldown);
//     }

//     entranceHandler(player) {
//         if (this.robberyPossible() && mp.players.exists(player)) {
//             // TODO: remove `!`
//             if (player.weapon !== this.robberyWeaponHash) {

//                 this.locked = false;
//                 this.lastEntranceAt = Date.now();
//                 this.marker.destroy();
                
//                 player.playAnimation(this.entranceAnimation[0], this.entranceAnimation[1], 1, 33);

//                 setTimeout(_ => {
//                     if (mp.players.exists(player)) {
//                         player.stopAnimation();
//                         // Place markers on client side
//                         rpc.callClient(player, "robbery:loadMarkers", {name: this.name, markers: this.jewelriesPosition}).then(() => {
//                             // Waiting
//                         });
//                     }
//                     player.call('notify', [3, 9, "Eingangstür wurde aufgebrochen!", 3000]);
//                 }, this.entranceHandlerDuration);



//                 // Lock a store in some time after robbery
//                 // and clean markers
//                 setTimeout(() => {
//                     this.locked = true;
//                     this.jewelriesPosition.forEach((pos, id) => {
//                         rpc.callClient(player, 'robbery:destroyMarker', {name: this.name, id: id});
//                     });

//                     this.marker = mp.markers.new(29, new mp.Vector3(this.x, this.y, this.z), 1, {
//                         direction: new mp.Vector3(this.x, this.y, this.z),
//                         rotation: new mp.Vector3(0, 0, 0),
//                         color: [0, 255, 0, 100],
//                         visible: true,
//                         dimension: 0
//                     });
//                 }, this.robberyCooldown);
//             } else {
//                 player.call('notify', [4, 9, 
//                     "Seems you need a " + this.robberyWeaponHash, 3000]
//                 );
//             }

//         } else {
//             player.call('notify', [4, 9, 'It is to late to rob this store', 3000]);
//         }
//     }

//     robberyActionPossible(id) {
//         if (! this.lastActionAt[id]) {
//             this.lastActionAt[id] = 0;
//         }

//         return this.policeOnDuty && ! this.locked && Date.now() > this.lastActionAt[id] + this.robberyCooldown;
//     }

//     robberyAction(player, id) {
//         if (mp.players.exists(player)) {        
//             if (this.robberyActionPossible(id)) {
//                 this.lastActionAt[id] = Date.now();
//                 player.playAnimation(this.robberyAnimation[0], this.robberyAnimation[1], 1, 33);
//                 // mp.game.graphics.startParticleFxNonLoopedOnEntity(effectName, entity, offsetX, offsetY, offsetZ, rotX, rotY, rotZ, scale, axisX, axisY, axisZ);
//                 player.setVariable("ROBBING",true);
                
//                 let robMoney = "" + Math.floor(Math.random() * 5000);
//                 let newAm = parseFloat(parseFloat(player.data.money) + parseFloat(robMoney));

//                 setTimeout(_ => {
//                     if (mp.players.exists(player)) {
//                         player.stopAnimation();
//                     }
//                     rpc.callClient(player,'robbery:destroyMarker', {name: this.name, id: id});
    
//                     // TODO: Update money
//                     player.call('notify', [4, 9, "Du hast "+robMoney+"$ ausgeraubt", 3000]);
//                     player.setVariable("ROBBING",false);   

//                 }, this.jewelrlyHandlerDuration);
//             } else {
//                 player.call('notify', [4, 9,  "Es wurde bereits alles leergeräumt!!", 3000]);
//             }    
//         }    
//     }

//     openMenu(player) {
//         rpc.callClient(player, "robbery:openMenu", {name: this.name}).then((r) => {
//             if (r.status === 1) {
//                 this.entranceHandler(player);
//             }
//         });
//     }
// }

// let atm1 = new Jewelry('ATM',
//     -635.480712890625, -237.48617553710938, 38.0731201171875, 
//     [
//         [-635.480712890625, -238.48617553710938, 38.0731201171875]
//     ]
// );
// atm1.setBlip(59, 1);
// atm1.entranceDuration = 3000;
// atm1.robberyActionDuration = 3000;
// atm1.robberyCooldown = 10000;
// atm1.entranceAnimation = ['weapons@first_person@aim_idle@p_m_zero@melee@unarmed@aimtrans@blocking_to_idle', 'aim_trans_med'];
// atm1.robberyAnimation = ['weapons@first_person@aim_idle@p_m_zero@melee@unarmed@aimtrans@blocking_to_idle', 'aim_trans_med'];
// atm1.locked = false;

// new Jewelry('Jewelry Store', -631.480712890625, -237.48617553710938, 38.0731201171875, [
//     // [-631.480712890625, -237.48617553710938, 38.0731201171875],
//     // [-631.480712890625, -237.48617553710938, 38.0731201171875],
//     // [-626.711181640625, -238.49594116210938, 38.05702209472656],
//     // [-625.6416015625, -237.75608825683594, 38.05702209472656],
//     // [-626.7786254882812, -235.41543579101562, 38.05703353881836],
//     // [-625.7470092773438, -234.59706115722656, 38.05703353881836],
//     // [-626.9330444335938, -233.1335906982422, 38.05703353881836],
//     // [-627.9407958984375, -233.90432739257812, 38.05703353881836],
//     // [-624.4215087890625, -231.12767028808594, 38.05703353881836],
//     // [-622.9570922851562, -233.14566040039062, 38.05703353881836],
//     // [-620.1578369140625, -233.43927001953125, 38.05703353881836],
//     // [-619.7055053710938, -230.3838348388672, 38.05703353881836],
//     // [-621.044189453125, -228.51296997070312, 38.05703353881836],
//     // [-624.034423828125, -228.0968780517578, 38.05703353881836],
//     // [-625.005126953125, -227.93511962890625, 38.05703353881836],
//     // [-623.908203125, -227.0521240234375, 38.05703353881836],
//     // [-620.4435424804688, -226.5618896484375, 38.056983947753906],
//     // [-619.615966796875, -227.6772003173828, 38.056983947753906],
//     // [-618.3448486328125, -229.50592041015625, 38.0570182800293],
//     // [-617.4960327148438, -230.62796020507812, 38.0570182800293],
//     // [-619.16650390625, -233.5838165283203, 38.0570182800293],
//     // [-620.327880859375, -234.52496337890625, 38.0570182800293],
// ]);
