///////////////////////////////////////////////////////////////////////////////////////////////---- Blips----///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


let JvaBlip = mp.blips.new(188, new mp.Vector3(1842.153, 2585.900, 45.890),
    {
        name: 'JVA',
        color: 4,
        shortRange: true,
        scale: 0.50,
});

let AutoVermietungBlip = mp.blips.new(641, new mp.Vector3(-2055.444, -465.5842, 11.84032),
    {
        name: 'Rollervermietung',
        color: 60,
        shortRange: true,
        scale: 0.50,
});

let AutoVermietungBlip1 = mp.blips.new(641, new mp.Vector3(254.7961, -744.7437, 34.63802),
    {
        name: 'Rollervermietung',
        color: 60,
        shortRange: true,        
        scale: 0.50,
});

let AutoVermietungBlip2 = mp.blips.new(641, new mp.Vector3(865.138, -29.76798, 78.76407),
    {
        name: 'Rollervermietung',
        color: 60,
        shortRange: true,
        scale: 0.50,
});

let AutoVermietungBlip3 = mp.blips.new(641, new mp.Vector3(58.70943, 6401.348, 31.00673),
    {
        name: 'Rollervermietung',
        color: 60,
        shortRange: true,
        scale: 0.50,
});

let AutoVermietungBlip4 = mp.blips.new(641, new mp.Vector3(1489.427, 3754.905, 35.00577),
    {
        name: 'Rollervermietung',
        color: 60,
        shortRange: true,
        scale: 0.50,
});


let AutoVermietungBlip5 = mp.blips.new(641, new mp.Vector3(-751.6469, -1347.13, 1.595678),
    {
        name: 'Bootsvermietung',
        color: 60,
        shortRange: true,
        scale: 0.50,
});

let AutoVermietungBlip6 = mp.blips.new(641, new mp.Vector3(-1117.891, -1684.262, 4.363768),
    {
        name: 'Fahrradvermietung',
        color: 60,
        shortRange: true,
        scale: 0.50,
});
let AutoVermietungBlip7 = mp.blips.new(641, new mp.Vector3(100.493675, -1073.0432, 29.372833),
    {
        name: 'Autovermietung',
        color: 60,
        shortRange: true,
        scale: 0.50,
});

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

let log = (message) => {
    return;
    mp.gui.chat.push(`!{Yellow} ${message} 😘`);
};

let colshape_radius = [];

mp.Vector3.Distance = function (v1, v2){
    return Math.abs(Math.sqrt(Math.pow((v2.x - v1.x),2) + Math.pow((v2.y - v1.y),2)+ Math.pow((v2.z - v1.z),2)));
}
createColshapeRadius = (colshape,callback,exitcallback)=>{
    let cols = mp.colshapes.newSphere(colshape.position.x,colshape.position.y,colshape.position.z, colshape.scale);
    cols._id = colshape_radius.length;
    cols.position = colshape.position;
    cols.scale = colshape.scale;
    cols.del = ()=>{
        let pos = player.position;
        if(mp.Vector3.Distance(pos,cols.position) < cols.scale){
            log('keyTip(false)')
            mp.events.call('PressE', false);
            // browserHud.execute('keyTip(false)');
        }
        cols.destroy();
        colshape_radius.splice(cols._id, 1);
    }
    cols.scale = colshape.scale;
    cols.callback = callback;
    cols.exitcallback = exitcallback;
    let colshInfo = {
        id: cols._id,
        colshape: cols,
        callback: callback,
        scale: colshape.scale
    }
    colshape_radius.push(colshInfo);
    return colshInfo;
}

let loggined = true;
let menuvlocked = false;

createmenuv = (info,lock) =>{
    if(loggined === false || menuvlocked === true || chatActive === true) return;
    if(lock) global.menuvlocked = lock;
    // Если передан маркер то если он выйдет из маркера то меню закроется
    if(info.exit_mar){
        info.exit_mar.colshape.exitmenu = 'MAR_EXIT'+info.exit_mar.id;
        info.exitmenu = 'MAR_EXIT'+info.exit_mar.id;
        delete info.exit_mar;
    }
    if(info.exit_cols){
        info.exit_cols.exitmenu = 'COLS_EXIT'+info.exit_cols.id;
        info.exitmenu = 'COLS_EXIT'+info.exit_cols.id;
        delete info.exit_cols;
    }
    // browser.execute(`createMenuv(${JSON.stringify(info)})`);
}
createMarker = (marker,callback,exitcallback)=>{
    let m = mp.markers.new(marker.type, marker.position, marker.scale, {
        visible: marker.visible || true,
        dimension: marker.dimension || 0,
        color: marker.color || [255,255,255,255]
    });
    m.callback = callback;
    m.exitcallback = exitcallback;

    let colshape = mp.colshapes.newSphere(marker.position.x,marker.position.y,marker.position.z, marker.scale,marker.dimension);
    m.colshape = colshape;
    m._id = markers.length;
    m.del = ()=>{
        if(mp.Vector3.Distance(player.position,marker.position) < marker.scale){
            log('keyTip(false)')
            mp.events.call('PressE', false);
            // browserHud.execute('keyTip(false)');
        }
        if(mp.markers.exists(m))m.destroy();
        if(mp.colshapes.exists(colshape))colshape.destroy();
        markers.splice(m._id,1)
    }
    let mark = {
        id: m._id,
        marker: m,
        callback: callback,
        exitcallback: exitcallback,
        colshape: colshape
    }
    if(marker.callremote != undefined) mark.callremote = marker.callremote;
    markers.push(mark);
    return mark;
}

mp.events.add('playerEnterColshape', (shape) => {
    if(!loggined) return;
    let pos = player.position;
    if(!player.vehicle){
        mp.markers.forEach((mark)=>{
            if(player.dimension == mark.dimension && mark.callback &&
                mp.Vector3.Distance(pos,mark.position) < mark.scale &&
                mark.visible){
                log('keyTip(true)Marker');
                mp.events.call('PressE', true);
                insideInteractionArea = true;
                //browserHud.execute('keyTip(true)');
            }
        })
        mp.colshapes.forEach(
            (cols, id) => {
                if(cols.scale && player.dimension == cols.dimension && mp.Vector3.Distance(pos,cols.position) < cols.scale){
                    log('keyTip(true)Shape');
                    mp.events.call('PressE', true);
                    insideInteractionArea = true;
                    // browserHud.execute('keyTip(true)');
                }
            }
        );
    }
    if (shape.checkpoint && shape.callback) shape.callback(shape,shape.marker)
});

mp.events.add('playerExitColshape', (shape) => {
    try {
        if (mp.colshapes.exists(shape)) {
            log('keyTip(false) playerExitColshape');
            mp.events.call('PressE', false);

            // May cause strange results while you inside several shapes
            // Because there is no priority control for that variable
            insideInteractionArea = false;
        }
    } catch (e) {
        log(e);
    }

    if (shape.exitcallback) {
        shape.exitcallback(shape)
    }
});

let canPressE = true;
let insideInteractionArea = false;
let pressE = () => {
    if (! loggedin || ! insideInteractionArea) {
        return;
    }
    if(menuvlocked) return;

    // 1 second timout between E key pressing
    if (canPressE) {
        canPressE = false;
        setTimeout(() => {
            canPressE = true;
        }, 1000);
    } else {
        return;
    }

    let pos = player.position;
    if(!player.vehicle){
        mp.markers.forEach((mark)=>{
            if(player.dimension == mark.dimension && mark.callback &&
                mp.Vector3.Distance(pos,mark.position) < mark.scale){

                log('pressE:markCallback!');
                mark.callback(mark);

                return;
            }
        })
        mp.colshapes.forEach(
            (cols, id) => {
                if(cols.scale && player.dimension == cols.dimension && mp.Vector3.Distance(pos,cols.position) < cols.scale){
                    log('pressE:shapeCallback!');
                    cols.callback(cols);
                    return;
                }
            }
        );
    }
};

const rpc = require('./gamemode/scripts/rage-rpc.min.js');

let player = mp.players.local;

class Job {
    constructor(positionVector, nameString, spriteId, pedString, markersArray,
        menuConfig = {start: 'Get job', finish: 'Get money'}, blipData, legal = true
    ) {
        this.name = nameString;
        this.position = positionVector;
        this.markers = markersArray;

        if (legal) {
            mp.blips.new(spriteId, this.position, {
                name: this.name,
                color: 21,
                dimension: 0,
                shortRange: true,
                alpha: 255
            });
        }

        this.ped = mp.peds.new(mp.game.joaat(pedString), this.position, 260);

        this.markerTake = {
            type: 1,
            color: [0, 255, 0, 60],
            position: new mp.Vector3(507.4201354980469, -637.7301025390625, 23.835050582885742),
            scale: 1.5
        };
        this.markerLay = {
            type: 1,
            color: [0, 255, 0, 60],
            position: new mp.Vector3(510.8154296875, -557.1165161132812, 24.930164337158203),
            scale: 1.5
        };
        this.marTake = null;
        this.marLay = null;

        this.started = false;
        this.processing = false;

        this.blip = null;
        this.createBlipArea = () => {
            if (this.blip === null && blipData && legal) {
                this.blip = mp.blips.new(blipData.sprite, blipData.position, blipData.options);
            }
        };

        // Ped (interaction by pressE)
        createColshapeRadius({position: this.position, scale: 2}, (m) => {
            if (this.started) { // already started
                mp.gui.chat.push(menuConfig.finish);
                // remove items and give new or cash
                mp.events.callRemote('forrest:finishJob', this.name);

                // this.finishThisJob();
            } else {
                mp.gui.chat.push(menuConfig.start);
                // create marker etc.
                mp.events.callRemote('forrest:startJob', this.name);

                this.startThisJob();
            }
        });

        this.startThisJob();
    }

    createTakePoint() {
        if (! this.markers || this.markers.length === 0) {
            return;
        }

        let markerTake = this.markers[Math.floor(Math.random() * (this.markers.length - 1))];
        //mp.game.ui.setNewWaypoint(markerTake.position.x, markerTake.position.y);

        this.marTake = createMarker(markerTake, async (m) => {
            if (this.processing) {
                return;
            }

            this.processing = true;
            mp.events.callRemote('forrest:collectItem', this.name);
            setTimeout(() => {
                m.del();
                this.createTakePoint();
                this.processing = false;
            }, 3000);

        });
    }
    startThisJob() {
        if (! this.started) {
            this.createBlipArea();
            this.createTakePoint();
            this.started = true;
        }
    }
    finishThisJob() {
        this.started = false;

        if (this.marTake && this.marTake.marker) {
            this.marTake.marker.del();
        }

        if (this.marLay && this.marLay.marker) {
            this.marLay.marker.del();
        }
    }
}

rpc.register('forrest:jobStart', (message, info) => {
    let result = false;

    jobs.forEach((job, i) => {
        if (message.name === job.name) {
            job.startThisJob();
            result = true;
        }
    });

    return result;
});
rpc.register('forrest:jobStop', (message, info) => {
    let result = false;

    jobs.forEach((job, i) => {
        if (message.name === job.name) {

            // We don't want to stop this job
            // People will collect chips in forrest
            // For ever :)
            // job.started = false;

            if (job.marTake && job.marTake.marker) {
                job.marTake.marker.del();
            }

            if (job.marLay && job.marLay.marker) {
                job.marLay.marker.del();
            }
        }
    });

    return result;
});


let jobs = [];
jobs.push(new Job(
    new mp.Vector3(2434.36,4974.97,46.57),
    'Apfel Verarbeiter',
    480,
    'a_m_m_afriamer_01',
    [
        {
            type: 1,
            color: [0, 155, 0, 0],
            position: new mp.Vector3(-1827.1207275390625,1968.0631103515625,136.19760131835938),
            scale: 15
        }
    ],
    {start: 'Gehe und sammel Äpfel', finish: '!{Yellow}[Ethan] !{White} Hier kannst du Äpfel Verarbeiten'},
    {
        sprite: 1,
        position: new mp.Vector3(-1827.1207275390625,1968.0631103515625,136.19760131835938),
        options: {
            name: 'Apfelplantage',
            color: 75,
            shortRange: true,
        }
    },
    true
));
jobs.push(new Job(
    new mp.Vector3(-45.42,1918.72,195.36),
    'Trauben Verarbeiter',
    480,
    's_m_m_migrant_01',
    [
        {
            type: 1,
            color: [0, 155, 0, 0],
            position: new mp.Vector3(-1889.1802978515625,1954.0770263671875,148.0841522216797),
            scale: 15
        }
    ],
    {start: 'Gehe und sammel Trauben', finish: '!{Yellow}[Anton] !{White} Hast du viel Trauben?'},
    {
        sprite: 1,
        position: new mp.Vector3(-1889.1802978515625,1954.0770263671875,148.0841522216797),
        options: {
            name: 'Traubenplantage',
            color: 83,
            shortRange: true,
        }
    },
    true
));
jobs.push(new Job(
    new mp.Vector3(2161.57,3372.59,45.38),
    'Holz Verarbeiter',
    480,
    'a_m_0_soucent_02',
    [
        {
            type: 1,
            color: [0, 155, 0, 0],
            position: new mp.Vector3(-450.6014099121094,5802.9287109375,49.79347610473633),
            scale: 15
        }
    ],
    {start: 'Gehe und sammel Holz', finish: '!{Yellow}[David] !{White} Hier kannst du Holz Verarbeiten'},
    {
        sprite: 1,
        position: new mp.Vector3(-450.6014099121094,5802.9287109375,49.79347610473633),
        options: {
            name: 'Holzplantage',
            color: 21,
            shortRange: true,
        }
    },
    true
));
jobs.push(new Job(
    new mp.Vector3(1535.24,2232.23,77.70,92.61),
    'Orangen Verarbeiter',
    480,
    's_f_y_migrant_01',
    [
        {
            type: 1,
            color: [0, 155, 0, 255],
            position: new mp.Vector3(362.2369384765625,6519.38623046875,27.30518341064453),
            scale: 15
        }
    ],
    {start: 'Gehe und sammel Orangen', finish: '!{Yellow}[Rondo] !{White} Hier kannst du Orangen Verarbeiten'},
    {
        sprite: 1,
        position: new mp.Vector3(362.2369384765625,6519.38623046875,27.30518341064453),
        options: {
            name: 'Orangenplantage',
            color: 44,
            shortRange: true,
        }
    },
    true
));
jobs.push(new Job(
    new mp.Vector3(2890.24,4391.54,50.34),
    'Öl Verarbeiter',
    480,
    's_m_y_dockwork_01',
    [
        {
            type: 1,
            color: [0, 155, 0, 0],
            position: new mp.Vector3(580.91,2921.394287109375,39.77791976928711),
            scale: 15
        }
    ],
    {start: 'Gehe und sammel Öl', finish: '!{Yellow}[Dony] !{White} Hier kannst du Öl Verarbeiten'},
    {
        sprite: 415,
        position: new mp.Vector3(580.91,2921.394287109375,39.77791976928711),
        options: {
            name: 'Öl Feld',
            color: 72,
            shortRange: true,
        }
    },
    true
));
jobs.push(new Job(
    new mp.Vector3(-121.47,6204.68,32.38),
    'Metalbarren Verarbeiter',
    480,
    'a_m_m_hillbilly_01',
    [
        {
            type: 1,
            color: [0, 155, 0, 0],
            position: new mp.Vector3(2957.337646484375,2767.924072265625,39.28882598876953),
            scale: 15
        }
    ],
    {start: 'Gehe und sammel Eisen', finish: '!{Yellow}[James] !{White} Hier kannst du Metalbarren Verarbeiten'},
    {
        sprite: 618,
        position: new mp.Vector3(2957.337646484375,2767.924072265625,39.28882598876953),
        options: {
            name: 'Eisengrube',
            color: 10,
            shortRange: true,
        }
    },
    true
));

// forrest2.js
jobs.push(new Job(
    new mp.Vector3(64.70302,7183.059,2.316763,2.086025),
    'Ephidrin Verarbeiter',
    90,
    'a_m_m_mexlabor_01',
    [
        {
            type: 1,
            color: [0, 155, 0, 0],
            position: new mp.Vector3(-2267.26318359375,2530.5263671875,2.3591554164886475),
            scale: 15
        }
    ],
    {start: 'Gehe und sammel Kröten', finish: '!{Yellow}[Alex] !{Randy} Hier kannst du Ephidrin Verarbeiten'},
    false,
    false
));
jobs.push(new Job(
    new mp.Vector3(1072.714,-2316.022,30.33404,184.3265),
    'Joint Verarbeiter',
    264,
    's_m_y_dealer_01',
    [
        {
            type: 1,
            color: [0, 155, 0, 0],
            position: new mp.Vector3(307.9141,4329.338,48.55662),
            scale: 15
        }
    ],
    {start: 'Gehe und sammel Marihuana', finish: '!{Yellow}[Cody] !{White} Hier kannst du Joints Verarbeiten'},
    false,
    false
));
jobs.push(new Job(
    new mp.Vector3(201.93,2461.97,55.69,194.62),
    'Schnaps Verarbeiter',
    194,
    'a_m_o_acult_02',
    [
        {
            type: 1,
            color: [0, 155, 0, 0],
            position: new mp.Vector3(3286.121337890625,5184.939453125,17.415367126464844),
            scale: 15
        }
    ],
    {start: 'Gehe und sammel Hopfen', finish: '!{Yellow}[Mark] !{White} Hier kannst du Schnaps Verarbeiten'},
    false,
    false
));
// forrest3.js
jobs.push(new Job(
    new mp.Vector3(1036.864,-2868.07,11.2601,359.9683), // das noch ändern
    'Ephidrin Dealer',
    56,
    'a_m_y_methhead_01',
    [ ],
    {start: 'Gehe und sammel Kröten', finish: '!{Yellow}[Vlad] !{White} Hier kannst du Ephidrin Verkaufen'},
    false,
    false
));
jobs.push(new Job(
    new mp.Vector3(3541.314,3668.107,28.12189,133.479), //das noch ändern
    'Joint Dealer',
    331,
    'a_m_y_cyclist_01',
    [ ],
    {start: 'Gehe und sammel Marihuana', finish: '!{Yellow}[Daniel] !{White} Hier kannst du Joints Verkaufen'},
    false,
    false
));
jobs.push(new Job(
    new mp.Vector3(-1277.34,-1361.55,4.30), //das noch ändern
    'Schnaps Dealer',
    289,
    'a_m_m_hillbilly_02',
    [ ],
    {start: 'Gehe und sammel Hopfen', finish: '!{Yellow}[Cody] !{White} Hier kannst du Schnaps Verkaufen'},
    false,
    false
));
// forrest4.js
jobs.push(new Job(
    new mp.Vector3(462.72,-693.89,27.40,91.41),
    'Apfel Händler',
    480,
    'a_m_m_eastsa_01',
    [ ],
    {start: 'Gehe und sammel Äpfel', finish: '!{Yellow}[Rick] !{White} Hier kannst du Apfelsaft Verkaufen'},
    false,
    true
));
jobs.push(new Job(
    new mp.Vector3(832.29,-1923.79,30.31),
    'Wein Händler',
    480,
    'a_m_y_downtown_01',
    [ ],
    {start: 'Gehe und sammel Trauben', finish: '!{Yellow}[Ben] !{White} Hier kannst du Wein Verkaufen'},
    false,
    true
));
jobs.push(new Job(
    new mp.Vector3(961.51,-2189.42,30.51,84.49),
    'Eisen Händler',
    480,
    's_m_m_cntrybar_01',
    [ ],
    {start: 'Gehe und sammel Eisen', finish: '!{Yellow}[Tony] !{White} Hier kannst du Eisen Verkaufen'},
    false,
    true
));
jobs.push(new Job(
    new mp.Vector3(-458.2898,-2814.849,7.295927),
    'Öl Händler',
    480,
    's_m_y_construct_01',
    [ ],
    {start: 'Gehe und sammel Öl', finish: '!{Yellow}[Alex] !{White} Hier kannst du Öl Verkaufen'},
    false,
    true
));
jobs.push(new Job(
    new mp.Vector3(-1606.57,-982.28,13.02),
    'Orangen Händler',
    480,
    's_m_y_busboy_01',
    [ ],
    {start: 'Gehe und sammel Orangen', finish: '!{Yellow}[Ralf] !{White} Hier kannst du Orangensaft Verkaufen'},
    false,
    true
));



jobs.push(new Job(
    new mp.Vector3(1074.311, -2450.849, 29.126),
    'Autobatterie Verarbeiter',
    620,
    's_m_m_autoshop_01',
    [
        {
            type: 1,
            color: [0, 155, 0, 0],
            position: new mp.Vector3(-498.627, -1756.206, 18.449),
            scale: 15
        }
    ],
    {start: 'Gehe und sammel Autobatterie', finish: '!{Yellow}[Dandy] !{White} Hier kannst du Autobatterie Verarbeiten'},
    {
        sprite: 527,
        position: new mp.Vector3(-498.627, -1756.206, 18.449),
        options: {
            name: 'Schrottplatz',
            color: 10,
            shortRange: true,
        }
    },
    true
));
jobs.push(new Job(
    new mp.Vector3(-330.2688, -2442.652, 7.358095),
    'Kokain Verarbeiter',
    264,
    'g_m_m_chemwork_01',
    [
        {
            type: 1,
            color: [0, 155, 0, 0],
            position: new mp.Vector3(2217.605, 5577.213, 53.830),
            scale: 15
        }
    ],
    {start: 'Gehe und sammel Kokain', finish: '!{Yellow}[Cody] !{White} Hier kannst du Kokain Verarbeiten'},
    false,
    false
));
jobs.push(new Job(
    new mp.Vector3(2432.881, 4971.12, 42.34756),
    'Crystal Meth Verarbeiter',
    620,
    'g_m_m_chemwork_01',
    [],
    {start: 'Gehe und sammel Ephidrin und Lithium', finish: '!{Yellow}[Brandy] !{White} Hier kannst du Ephidrin Meth Verarbeiten'},
    false,
    false
));
jobs.push(new Job(
    new mp.Vector3(2525.108,2575.219,37.12189,5.041212), 
    'Crystal Dealer',
    331,
    'a_m_m_beach_01',
    [ ],
    {start: 'Gehe und bring mir Crystal Meth', finish: '!{Yellow}[Daniel] !{White} Hier kannst du Crystal Meth Verkaufen'},
    false,
    false
));
jobs.push(new Job(
    new mp.Vector3(-314.3306,181.8943,87.91801,144.9859), //das noch ändern
    'Kokain Dealer',
    331,
    'a_m_y_bevhills_01',
    [ ],
    {start: 'Gehe und bring mir Kokain', finish: '!{Yellow}[Daniel] !{White} Hier kannst du Kokain Verkaufen'},
    false,
    false
));
jobs.push(new Job(
    new mp.Vector3(-315.3306,182.8943,-887.91801,144.9859), //das noch ändern
    'Juwel Händler',
    331,
    'cs_bankman',
    [ ],
    {start: 'Gehe und bring mir Juwelen', finish: '!{Yellow}[Daniel] !{White} Hier kannst du Juwelen Verkaufen'},
    false,
    false
));



mp.keys.bind(0x45, false, pressE);
