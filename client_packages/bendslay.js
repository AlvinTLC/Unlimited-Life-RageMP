mp.Vector3.getDistanceBetweenPoints3D = function (v1, v2) {
  return Math.abs(
    Math.sqrt(
      Math.pow(v2.x - v1.x, 2) +
        Math.pow(v2.y - v1.y, 2) +
        Math.pow(v2.z - v1.z, 2)
    )
  );
}; // function calculating the distance between two points in the space X; Y; Z;

global.chren = mp.browsers.new('package://cef/bets/chren.html')
let lpCasinoTable = null;
let casinoTableToJoin = null;
let casinoSeatToJoin = null;
let goToSeatInterval = null;
let interactingWithTable = null;
let rouletteCamera = null;
let canDoBets = false;
let betObject = null;
let closestChipSpot = null;
let interactingWithTableTimeout = null;
var objectg = null;
var objectgg = null;
var objectggg = null;
var objectgggg = null;




mp.game.streaming.requestIpl('vw_casino_main');
mp.game.streaming.requestAnimDict("anim_casino_a@amb@casino@games@lucky7wheel@male");
const k = global.LUCKY = mp.objects.new(mp.game.joaat("vw_prop_vw_luckywheel_02a"), new mp.Vector3(1111.05, 229.81, -49.16), {
     dimension: 0,
     rotation: new mp.Vector3(0, 0, 0)
});

var D = null;
mp.events.add("client_casino_luckywheel_spin", e => {
 if (0 === k.handle) return;
const t = k.getRotation(2).z;
k.setRotation(0, 0, t, 2, !0), clearInterval(D);
const a = 1800 + 18 * e;
let o = 0;
D = setInterval(() => 0 === k.handle ? clearInterval(D) : (o += o < .6 * a ? 4.5 : o < .65 * a ? 4 : o < .7 * a ? 3.5 : o < .8 * a ? 2.5 : o < .9 * a ? 1.5 : o < .92 * a ? 1.2 : o < .94 * a ? 1 : o < .96 * a ? .9 : o < .98 * a ? .6 : .3,  o >= a ? void clearInterval(D) : void k.setRotation(0, -o, t, 2, !0)), 15)
setTimeout(() => {
mp.events.callRemote("server_casino_luckywheel_getGift", e);
}, 18000)
}),
mp.events.add("client_casino_luckywheel_player_spin", (e, t) => {
const a = mp.players.local;
mp.players.exists(a) && 0 !== a.handle && (a.taskGoStraightToCoord(1109.914, 228.9987, -49.59585, 1, 3e3, -25, 1), setTimeout(() => {
mp.players.exists(a) && 0 !== a.handle && (a.taskPlayAnim("anim_casino_a@amb@casino@games@lucky7wheel@male", "enter_to_armraisedidle", 1, 1, 3e3, 2, !1, !0, !0, !0), setTimeout(() => {
mp.players.exists(a) && 0 !== a.handle && (setTimeout(() => {
mp.events.call("client_casino_luckywheel_spin", t), a === mp.players.local
}, 500), a.taskPlayAnim("anim_casino_a@amb@casino@games@lucky7wheel@male", "armraisedidle_to_spinningidle_high", 1, 1, 2e3, 1, !1, !0, !0, !0))
}, 3e3))
}, 3e3))
});
let tablesPos = 
[
	[ "vw_prop_casino_roulette_01", 1144.4254150390625, 269.3034973144531, -52.880850830078125 ],
	[ "vw_prop_casino_roulette_01", 1151.2305908203125, 263.14093017578125, -52.880850830078125 ],
	[ "vw_prop_casino_roulette_01b", 1148.9163818359375, 248.62892150878906, -52.08075408935547 ],
	[ "vw_prop_casino_roulette_01b", 1143.677978515625, 251.36131286621094, -52.0807502746582 ],
	[ "vw_prop_casino_roulette_01b", 1133.1802978515625, 262.3916320800781, -52.08075408935547 ], 
	[ "vw_prop_casino_roulette_01b", 1129.9976806640625, 266.93695068359375, -52.0807502746582 ], 
];

let tablesBets = 
[
	[ 500, 2500 ],
	[ 1000, 5000 ],
	[ 3000, 15000 ],
	[ 7000, 35000 ],
	[ 10000, 50000 ],
	[ 20000, 100000 ]
];

let pedModels =
[
	"S_M_Y_Casino_01", "S_F_Y_Casino_01", "S_M_Y_Casino_01", "S_F_Y_Casino_01", "S_M_Y_Casino_01", "S_F_Y_Casino_01"
]





mp.game.streaming.requestIpl('vw_casino_main');
mp.blips.new(679, new mp.Vector3(935.8140869140625, 46.942176818847656, 81.09580993652344), { name: "Diamond Casino & Resort", color: 4, shortRange: true, scale: 1.0 });


//chips change
mp.peds.new(mp.game.joaat("S_F_Y_Casino_01"), new mp.Vector3(1117.7528076171875, 220.12098693847656, -49.43511962890625), 90.0, 0);
//mp.labels.new("Beverly", new mp.Vector3(1117.7528076171875, 220.12098693847656, -49.43511962890625+1.1), { los: true, font: 0, drawDistance: 5.0 } );



// [ //barman m
	// [ 0, 3, 0, 0],
	// [ 1, 1, 0, 0],
	// [ 2, 3, 0, 0],
	// [ 3, 1, 0, 0],
	// [ 4, 0, 0, 0],
	// [ 6, 1, 0, 0],
	// [ 7, 2, 0, 0],
	// [ 8, 3, 0, 0],
	// [ 10, 1, 0, 0],
	// [ 11, 1, 0, 0],
// ],
// [ //barman m
		// [ 0, 2, 0, 0],
		// [ 1, 1, 0, 0],
		// [ 2, 3, 0, 0],
		// [ 3, 1, 3, 0],
		// [ 4, 0, 0, 0],
		// [ 6, 1, 0, 0],
		// [ 7, 2, 0, 0],
		// [ 8, 3, 0, 0],
		// [ 10, 1, 0, 0],
		// [ 11, 1, 0, 0],
	// ]
	// [//barman m
		// [ 0, 4, 1, 0],
		// [ 1, 1, 0, 0],
		// [ 2, 4, 0, 0],
		// [ 3, 1, 0, 0],
		// [ 4, 0, 0, 0],
		// [ 6, 1, 0, 0],
		// [ 7, 2, 0, 0],
		// [ 8, 3, 0, 0],
		// [ 10, 1, 0, 0],
		// [ 11, 1, 0, 0],
	// ]
	// [//barman f
		// [ 0, 1, 1, 0],
		// [ 1, 0, 0, 0],
		// [ 2, 1, 0, 0],
		// [ 3, 0, 3, 0],
		// [ 4, 0, 0, 0],
		// [ 6, 0, 0, 0],
		// [ 7, 0, 0, 0],
		// [ 8, 0, 0, 0],
		// [ 10, 0, 0, 0],
		// [ 11, 0, 0, 0],
	// ]
	// [//barman f
		// [ 0, 1, 1, 0],
		// [ 1, 0, 0, 0],
		// [ 2, 1, 1, 0],
		// [ 3, 1, 3, 0],
		// [ 4, 0, 0, 0],
		// [ 6, 0, 0, 0],
		// [ 7, 2, 0, 0],
		// [ 8, 1, 0, 0],
		// [ 10, 0, 0, 0],
		// [ 11, 0, 0, 0],
	// ]
	// [//barman f
		// [ 0, 3, 0, 0],
		// [ 1, 0, 0, 0],
		// [ 2, 3, 0, 0],
		// [ 3, 0, 1, 0],
		// [ 4, 1, 0, 0],
		// [ 6, 1, 0, 0],
		// [ 7, 1, 0, 0],
		// [ 8, 0, 0, 0],
		// [ 10, 0, 0, 0],
		// [ 11, 0, 0, 0],
	// ]
	// [//barman f
		// [ 0, 3, 1, 0],
		// [ 1, 0, 0, 0],
		// [ 2, 3, 1, 0],
		// [ 3, 1, 1, 0],
		// [ 4, 1, 0, 0],
		// [ 6, 1, 0, 0],
		// [ 7, 2, 0, 0],
		// [ 8, 1, 0, 0],
		// [ 10, 0, 0, 0],
		// [ 11, 0, 0, 0],
	// ]

let pedModelVariations =
[
	[ //S_M_Y_Casino_01
		[ 0, 2, 2, 0],
		[ 1, 1, 0, 0],
		[ 2, 4, 0, 0],
		[ 3, 0, 3, 0],
		[ 4, 0, 0, 0],
		[ 6, 1, 0, 0],
		[ 7, 2, 0, 0],
		[ 8, 1, 0, 0],
		[ 10, 1, 0, 0],
		[ 11, 1, 0, 0]
	],
	[//S_F_Y_Casino_01
		[ 0, 2, 0, 0],
		[ 1, 0, 0, 0],
		[ 2, 2, 0, 0],
		[ 3, 2, 3, 0],
		[ 4, 0, 0, 0],
		[ 6, 0, 0, 0],
		[ 7, 0, 0, 0],
		[ 8, 2, 0, 0],
		[ 10, 0, 0, 0],
		[ 11, 0, 0, 0]
	],
	[ //S_M_Y_Casino_01
		[ 0, 2, 1, 0],
		[ 1, 1, 0, 0],
		[ 2, 2, 0, 0],
		[ 3, 0, 3, 0],
		[ 4, 0, 0, 0],
		[ 6, 1, 0, 0],
		[ 7, 2, 0, 0],
		[ 8, 1, 0, 0],
		[ 10, 1, 0, 0],
		[ 11, 1, 0, 0]
	],
	[//S_F_Y_Casino_01
		[ 0, 2, 1, 0],
		[ 1, 0, 0, 0],
		[ 2, 2, 1, 0],
		[ 3, 3, 3, 0],
		[ 4, 1, 0, 0],
		[ 6, 1, 0, 0],
		[ 7, 2, 0, 0],
		[ 8, 3, 0, 0],
		[ 10, 0, 0, 0],
		[ 11, 0, 0, 0]
	],
	[ //S_M_Y_Casino_01
		[ 0, 4, 2, 0],
		[ 1, 1, 0, 0],
		[ 2, 3, 0, 0],
		[ 3, 0, 0, 0],
		[ 4, 0, 0, 0],
		[ 6, 1, 0, 0],
		[ 7, 2, 0, 0],
		[ 8, 1, 0, 0],
		[ 10, 1, 0, 0],
		[ 11, 1, 0, 0]
	],
	[//S_F_Y_Casino_01
		[ 0, 4, 0, 0],
		[ 1, 0, 0, 0],
		[ 2, 4, 0, 0],
		[ 3, 2, 1, 0],
		[ 4, 1, 0, 0],
		[ 6, 1, 0, 0],
		[ 7, 1, 0, 0],
		[ 8, 2, 0, 0],
		[ 10, 0, 0, 0],
		[ 11, 0, 0, 0]
	],
	[ //S_M_Y_Casino_01 (not used)
		[ 0, 4, 0, 0],
		[ 1, 1, 0, 0],
		[ 2, 0, 0, 0],
		[ 3, 0, 0, 0],
		[ 4, 0, 0, 0],
		[ 6, 1, 0, 0],
		[ 7, 2, 0, 0],
		[ 8, 1, 0, 0],
		[ 10, 1, 0, 0],
		[ 11, 1, 0, 0]
	]
]

let tableSeatsPos =
[
	[-0.7, -1.28, 1, 0],
	[1.22, -1.38, 1, 0],
	[1.78, -0.62, 1, 90],
	[1.27, 1.02, 1, 180]
]


let tablebetsnew =
[
   [ 500, 1000, 1500, 2000, 2500 ],
   [ 1000, 2000, 3000, 4000, 5000 ],
   [ 3000, 6000, 9000, 12000, 15000 ],
   [ 7000, 14000, 21000, 29000, 35000 ],
   [ 10000, 20000, 30000, 40000, 50000 ],
   [ 20000, 40000, 60000, 80000, 100000 ]
];



let money = 0;
let bet = 0;
mp.keys.bind(0x44, true, () =>  // D
{
	//if(!localplayer.getVariable('ingames')) return;
	if(bet >= 4) bet = 0;
	else bet++;
	money = tablebetsnew[lpCasinoTable][bet];
	chren.execute(`chren.bet='${money}'`);
});
mp.keys.bind(0x41, true, () =>  // A
{
	//if(!localplayer.getVariable('ingames')) return;
	if(bet == 0) bet = 4;
	else bet--;
	money = tablebetsnew[lpCasinoTable][bet];
	chren.execute(`chren.bet='${money}'`);
});


mp.events.add('casinomoney', (temp) => {
	 chren.execute(`chren.balance='${temp}'`);
});
mp.events.add('seatsactive',() => {
	if(casinoTableToJoin != null){
     rouletteData[casinoTableToJoin].table.setCollision(false, false);
     money = tablebetsnew[casinoTableToJoin][0];
	 chren.execute('chren.show = true');
	 chren.execute(`chren.minbet='${tablesBets[casinoTableToJoin][0]}'`);
	 chren.execute(`chren.maxbet='${tablesBets[casinoTableToJoin][1]}'`);
	 chren.execute(`chren.bet='${money}'`);
	 mp.events.call('showHUD', false);
	}
});



mp.events.add('seatsdisable', () => {
	 chren.execute('chren.show = false');
	 mp.events.call('showHUD', true);
});



let rouletteData = [];

for(var i=0; i < tablesPos.length; i++)
{
	rouletteData[i] = {};
	rouletteData[i].table = mp.objects.new(mp.game.joaat(tablesPos[i][0]), new mp.Vector3(tablesPos[i][1], tablesPos[i][2], tablesPos[i][3]));
	rouletteData[i].ball = mp.objects.new(87196104, new mp.Vector3(tablesPos[i][1]-0.734742, tablesPos[i][2]-0.16617, tablesPos[i][3]));
	rouletteData[i].ped = mp.peds.new(mp.game.joaat(pedModels[i]), new mp.Vector3(tablesPos[i][1], tablesPos[i][2]+0.7, tablesPos[i][3]+1), 180, 0); //-0.001587
	rouletteData[i].ped.croupier = i;
	
	for(var c=0; c < tableSeatsPos.length; c++)
	{
		var newShape = mp.colshapes.newSphere(tablesPos[i][1]+tableSeatsPos[c][0], tablesPos[i][2]+tableSeatsPos[c][1], tablesPos[i][3]+tableSeatsPos[c][2], 0.8);
		mp.markers.new(1, new mp.Vector3(tablesPos[i][1]+tableSeatsPos[c][0], tablesPos[i][2]+tableSeatsPos[c][1], tablesPos[i][3]+tableSeatsPos[c][2]-1.7), 0.8);
		newShape.casinoTable = i;
		newShape.seatID = c;
	}
	
	for(var c=0; c < pedModelVariations[i].length; c++)
	{
		rouletteData[i].ped.setComponentVariation(pedModelVariations[i][c][0], pedModelVariations[i][c][1], pedModelVariations[i][c][2], pedModelVariations[i][c][3]);
	}
}

mp.events.add('playerEnterColshape', (shape) => {

	if(shape.casinoTable !== undefined && lpCasinoTable == null && interactingWithTable == null)
	{
		casinoTableToJoin = shape.casinoTable;
		casinoSeatToJoin = shape.seatID;

		mp.game.audio.playSound(-1, "BACK", "HUD_AMMO_SHOP_SOUNDSET", true, 0, true);
		mp.game.graphics.notify(`~g~[E]~s~ Сесть за стол~n~Ставка: ~b~${tablesBets[casinoTableToJoin][0]}~s~ - ~b~${tablesBets[casinoTableToJoin][1]}~s~ фишек`);
	}
});

mp.events.add('playerExitColshape', (shape) => {
	if(shape.casinoTable !== undefined)
	{
		casinoTableToJoin = null;
		casinoSeatToJoin = null;
	}
});


let rot = 0;
mp.game.entity.createModelHideExcludingScriptObjects(1100.077,219.9723,-50.04865, 10.0, 2733879850, true);
let podium = mp.objects.new(2733879850, new mp.Vector3(1100.077,219.9723,-50.084865));
let carcasin = mp.vehicles.new(mp.game.joaat("zentorno"), new mp.Vector3(1100.077,219.9723,-50.07865),
{
    color: [[247, 134, 22],[247,134,22]],
    locked: true
});
carcasin.doNotChangeAlpha = true;
carcasin.freezePosition(true);
let rotatePodiumColshape = mp.colshapes.newSphere(1100.077,219.9723,-50.04865, 50.0);
mp.events.add("playerEnterColshape", (shape) => {

    if(shape == rotatePodiumColshape)
    {
        mp.events.add("render", rotate);
    }
});
mp.events.add("playerExitColshape", (shape) => {

    if(shape == rotatePodiumColshape)
    {
        mp.events.remove("render", rotate);
    }
});
function rotate()
{
    rot+=0.05;
    if(rot >= 360) rot = 0;
    podium.rotation = new mp.Vector3(0, 0, rot);
    carcasin.setHeading(rot);
}

global.loadAnim = function(dict)
{
    new Promise((resolve, reject) => {

        const timer = setInterval(() => {

            if(mp.game.streaming.hasAnimDictLoaded(dict))
            {
                //mp.gui.chat.push(`Anim ${dict} has been loaded!`);
                clearInterval(timer);
                resolve();
            }
            else
            {
                //mp.gui.chat.push(`Anim ${dict} is not loaded`);
                mp.game.streaming.requestAnimDict(dict);
            }

        }, 300);
    });
}


let animInfo = null;
mp.events.add("initRoulette", (jsonString) => 
{
	animInfo = JSON.parse(jsonString);
	
	loadAnim(animInfo.tableLib);
	loadAnim(animInfo.dealerLib);
	loadAnim(animInfo.dealerLib+"_female");
	
	mp.events.add("render", rouletteRender);
	
	mp.events.add('entityStreamIn', (entity) => {
		if(entity.type == "ped" && entity.croupier != null) 
		{
			if(entity.model == mp.game.joaat('S_M_Y_Casino_01')) entity.taskPlayAnim(animInfo.dealerLib, "idle", 8.0, 1, -1, 1, 0.0, false, false, false);
			else entity.taskPlayAnim(animInfo.dealerLib+"_female", "idle", 8.0, 1, -1, 1, 0.0, false, false, false);
			
			
			
			var id = entity.croupier;
			
			rouletteData[id].ball.position = new mp.Vector3(tablesPos[id][1]-0.734742, tablesPos[id][2]-0.16617, tablesPos[id][3]);
			
			for(var c=0; c < pedModelVariations[id].length; c++)
			{
				entity.setComponentVariation(pedModelVariations[id][c][0], pedModelVariations[id][c][1], pedModelVariations[id][c][2], pedModelVariations[id][c][3]);
			}
		}
	});
});

function rouletteRender() 
{
	
	for(var i=0; i < rouletteData.length; i++)
	{
		if(rouletteData[i].table.isPlayingAnim(animInfo.tableLib, animInfo.tableStart, 3))
		{
			if(rouletteData[i].table.getAnimCurrentTime(animInfo.tableLib, animInfo.tableStart) > 0.9425)
			{
				rouletteData[i].table.playAnim(animInfo.tableMain, animInfo.tableLib, 1000.0, true, true, true, 0, animInfo.speed);
			}
		}
		
		if(rouletteData[i].ball.isPlayingAnim(animInfo.tableLib, animInfo.ballStart, 3))
		{
			if(rouletteData[i].ball.getAnimCurrentTime(animInfo.tableLib, animInfo.ballStart) > 0.99)
			{
				rouletteData[i].ball.position = new mp.Vector3(tablesPos[i][1]-0.734742, tablesPos[i][2]-0.16617, tablesPos[i][3]+1.0715);
				rouletteData[i].ball.rotation = new mp.Vector3(0.0, 0.0, animInfo.ballRot);
				
				rouletteData[i].ball.playAnim(animInfo.ballMain, animInfo.tableLib, 1000.0, true, true, false, 0, animInfo.speed);
			}
		}
		
		if(rouletteData[i].table.isPlayingAnim(animInfo.tableLib, animInfo.tableMain, 3))
		{
			
			if(rouletteData[i].table.getAnimCurrentTime(animInfo.tableLib, animInfo.tableMain) >= 0.9 && Date.now()-rouletteData[i].lastSpinTime > 1000)
			{
				rouletteData[i].spins++;
				rouletteData[i].lastSpinTime = Date.now();
			}
			if(rouletteData[i].spins == rouletteData[i].needSpins-1)
			{
				rouletteData[i].ball.setAnimSpeed(animInfo.tableLib, animInfo.ballMain, 0.71);
			}
			if(rouletteData[i].spins == rouletteData[i].needSpins && rouletteData[i].table.getAnimCurrentTime(animInfo.tableLib, animInfo.tableMain) > 0.99)
			{
				rouletteData[i].table.playAnim(rouletteData[i].endTable, animInfo.tableLib, 1000.0, false, true, true, 0, animInfo.speed);
				
				rouletteData[i].ball.position = new mp.Vector3(tablesPos[i][1]-0.734742, tablesPos[i][2]-0.16617, tablesPos[i][3]+1.0715);
				rouletteData[i].ball.rotation = new mp.Vector3(0.0, 0.0, animInfo.ballRot);
				rouletteData[i].ball.playAnim(rouletteData[i].endBall, animInfo.tableLib, 1000.0, false, true, true, 0, animInfo.speed);
			}
		}
	}
}




mp.keys.bind(0x45, true, () =>  // E
{
		
	if(mp.players.local.isDead() || mp.gui.cursor.visible || interactingWithTable != null) return false;
	
	if(lpCasinoTable != null)
	{
		mp.events.callRemote("leaveCasinoSeat",casinoTableToJoin,casinoSeatToJoin);
		interactingWithTable = lpCasinoTable;
		rouletteData[lpCasinoTable].table.setCollision(true, false);
		lpCasinoTable = null;
		if(rouletteCamera != null) destroyRouletteCamera();
		if(canDoBets) canDoBets = false;
		interactingWithTableTimeout = setTimeout(
			function()
			{
				interactingWithTable = null;
				interactingWithTableTimeout = null;
			},2000
		);
	}
	else
	{
		if(casinoTableToJoin == null) return false;
		
		interactingWithTable = casinoTableToJoin;
		money = tablebetsnew[casinoTableToJoin][0];
		
		mp.players.local.position = new mp.Vector3(tablesPos[casinoTableToJoin][1]+tableSeatsPos[casinoSeatToJoin][0], tablesPos[casinoTableToJoin][2]+tableSeatsPos[casinoSeatToJoin][1], tablesPos[casinoTableToJoin][3]+tableSeatsPos[casinoSeatToJoin][2]);
		mp.players.local.setHeading(tableSeatsPos[casinoSeatToJoin][3]);
		
		
		
		mp.events.callRemote("occupyCasinoSeat", casinoTableToJoin, casinoSeatToJoin);
		
		interactingWithTableTimeout = setTimeout(
			function()
			{
				interactingWithTable = null;
				interactingWithTableTimeout = null;
				//rouletteData[lpCasinoTable].table.setCollision(true, false);
			},2000
		);
		
		// mp.players.local.taskGoStraightToCoord(
			// tablesPos[casinoTableToJoin][1]+tableSeatsPos[casinoSeatToJoin][0],
			// tablesPos[casinoTableToJoin][2]+tableSeatsPos[casinoSeatToJoin][1],
			// tablesPos[casinoTableToJoin][3]+tableSeatsPos[casinoSeatToJoin][2],
			// 1.15, // speed
			// 3000, // timeout
			// tableSeatsPos[casinoSeatToJoin][3], // heading
			// 0.5 // slide (?)
		// );
		
		// setTimeout(
			// function()
			// {
				// if(goToSeatInterval != null)
				// {
					// clearInterval(goToSeatInterval);
					// goToSeatInterval = null;
				// }
			// },3000
		// );
		
		// goToSeatInterval = setInterval(checkPlayerCanSit, 200, casinoTableToJoin, casinoSeatToJoin);
	}	
});






mp.events.add("cancelInteractingWithTable", () => 
{
	rouletteData[interactingWithTable].table.setCollision(true, false);
	interactingWithTable = null;
	if(interactingWithTableTimeout != null)
	{
		clearTimeout(interactingWithTableTimeout);
		interactingWithTableTimeout = null;
	}
});

// function checkPlayerCanSit(table, seat)
// {
	// var heading = mp.players.local.getHeading();
	// if(mp.Vector3.getDistanceBetweenPoints3D(mp.players.local.position, new mp.Vector3(tablesPos[table][1]+tableSeatsPos[seat][0], tablesPos[table][2]+tableSeatsPos[seat][1], tablesPos[table][3]+tableSeatsPos[seat][2])) < 0.01 )
	// {
		// mp.players.local.setHeading(tableSeatsPos[seat][3]);
		// mp.events.callRemote("occupyCasinoSeat", table, seat);
		// clearInterval(goToSeatInterval);
		// goToSeatInterval = null;
		
		// interactingWithTableTimeout = setTimeout(
			// function()
			// {
				// interactingWithTable = null;
				// interactingWithTableTimeout = null;
			// },5500
		// );
	// }
// }

mp.events.add('playerDeath', (player) => 
{
	if(player == mp.players.local) 
	{
		if(interactingWithTable != null) interactingWithTable = null;
		if(rouletteCamera != null) destroyRouletteCamera();
		if(canDoBets) canDoBets = false;
	}
});





mp.events.add("playerSitAtCasinoTable", (player, tableID) => {
	
	if(player == mp.players.local) 
	{
		lpCasinoTable = casinoTableToJoin;
		mp.game.graphics.notify(`~g~ЛКМ - сделать ставку J - вид на стол`);
	}
	else
	{
		rouletteData[tableID].table.setNoCollision(player.handle, false);
	}
});

// mp.events.add("playerLeaveCasinoTable", (player, tableID) => {
	
	// rouletteData[tableID].table.setCollision(true, false);
// });

mp.events.add("rouletteAllowBets", (toggle) => {
	
	canDoBets = toggle;
	if(toggle) mp.game.graphics.notify("Сделайте ставки");
	else mp.game.graphics.notify("Ставки сделаны");
});
mp.events.add("chipsserver", (toggle) => {
	
	objectg = mp.objects.new(mp.game.joaat("vw_prop_chip_100dollar_x1"), new mp.Vector3(tablesPos[lpCasinoTable][1]+tableChipsOffsets[toggle][0], tablesPos[lpCasinoTable][2]+tableChipsOffsets[toggle][1], tablesPos[lpCasinoTable][3]+tableChipsOffsets[toggle][2]))
});
mp.events.add("chipsserver2", (toggle) => {
	
	objectgg = mp.objects.new(mp.game.joaat("vw_prop_chip_100dollar_x1"), new mp.Vector3(tablesPos[lpCasinoTable][1]+tableChipsOffsets[toggle][0], tablesPos[lpCasinoTable][2]+tableChipsOffsets[toggle][1], tablesPos[lpCasinoTable][3]+tableChipsOffsets[toggle][2]))
	
});
mp.events.add("chipsserver3", (toggle) => {
	
	objectggg = mp.objects.new(mp.game.joaat("vw_prop_chip_100dollar_x1"), new mp.Vector3(tablesPos[lpCasinoTable][1]+tableChipsOffsets[toggle][0], tablesPos[lpCasinoTable][2]+tableChipsOffsets[toggle][1], tablesPos[lpCasinoTable][3]+tableChipsOffsets[toggle][2]))
	
});

mp.events.add("deleteObjectsd", () => {
	
	objectg.destroy();
	objectg = null;
	
});
mp.events.add("deleteObjectsd2", () => {
    objectgg.destroy();
	objectgg = null;
});
mp.events.add("deleteObjectsd3", () => {
    objectggg.destroy();
	objectggg = null;
});




mp.events.add("spinRouletteWheel", (table, needSpins, endTable, endBall) => {
	
	rouletteData[table].table.playAnim(animInfo.tableStart, animInfo.tableLib, 1000.0, false, true, true, 0, animInfo.speed); // loop, freezeLastFrame, ?
	
	rouletteData[table].ball.position = new mp.Vector3(tablesPos[table][1]-0.734742, tablesPos[table][2]-0.16617, tablesPos[table][3]+1.0715);
	rouletteData[table].ball.rotation = new mp.Vector3(0.0, 0.0, animInfo.ballRot);
	
	rouletteData[table].ball.playAnim(animInfo.ballStart, animInfo.tableLib, 1000.0, false, true, false, 0, animInfo.speed); // loop, freezeLastFrame, ?
	rouletteData[table].spins = 0;
	rouletteData[table].lastSpinTime = 0;
	rouletteData[table].needSpins = needSpins;
	rouletteData[table].endTable = endTable;
	rouletteData[table].endBall = endBall;
	
	if(rouletteData[table].ped.model == mp.game.joaat('S_M_Y_Casino_01')) rouletteData[table].ped.taskPlayAnim(animInfo.dealerLib, "spin_wheel", 8.0, 1, -1, 2, 0.0, false, false, false);
	else rouletteData[table].ped.taskPlayAnim(animInfo.dealerLib+"_female", "spin_wheel", 8.0, 1, -1, 2, 0.0, false, false, false);
	
	setTimeout(
		function()
		{
			if(rouletteData[table].ped.model == mp.game.joaat('S_M_Y_Casino_01')) rouletteData[table].ped.taskPlayAnim(animInfo.dealerLib, "idle", 8.0, 1, -1, 1, 0.0, false, false, false);
			else rouletteData[table].ped.taskPlayAnim(animInfo.dealerLib+"_female", "idle", 8.0, 1, -1, 1, 0.0, false, false, false);
		}, 8000
	);
});

mp.events.add("clearRouletteTable", (table) => 
{
	if(rouletteData[table].ped.model == mp.game.joaat('S_M_Y_Casino_01')) rouletteData[table].ped.taskPlayAnim(animInfo.dealerLib, "clear_chips_zone2", 8.0, 1, -1, 2, 0.0, false, false, false);
	else rouletteData[table].ped.taskPlayAnim(animInfo.dealerLib+"_female", "clear_chips_zone2", 8.0, 1, -1, 2, 0.0, false, false, false);
	
	setTimeout(
		function()
		{
			if(rouletteData[table].ped.model == mp.game.joaat('S_M_Y_Casino_01')) rouletteData[table].ped.taskPlayAnim(animInfo.dealerLib, "idle", 8.0, 1, -1, 1, 0.0, false, false, false);
			else rouletteData[table].ped.taskPlayAnim(animInfo.dealerLib+"_female", "idle", 8.0, 1, -1, 1, 0.0, false, false, false);
		}, 2000
	);
});










 











mp.keys.bind(0x4A, true, () =>  // J
{
		
	if(mp.players.local.isDead() || mp.gui.cursor.visible || interactingWithTable != null || lpCasinoTable == null) return false;
	
	if(rouletteCamera != null)
	{
		destroyRouletteCamera();
	}
	else
	{
		rouletteCamera = mp.cameras.new('default', new mp.Vector3(tablesPos[lpCasinoTable][1], tablesPos[lpCasinoTable][2]-1, tablesPos[lpCasinoTable][3]+3), new mp.Vector3(0,0,0), 45);
		rouletteCamera.setRot(-75.0, 0.0, 0.0, 2);
		rouletteCamera.setActive(true);
		mp.game.cam.renderScriptCams(true, false, 0, true, false);
	}	
});

function destroyRouletteCamera()
{
	rouletteCamera.destroy(true);
	rouletteCamera = null;
    mp.game.cam.renderScriptCams(false, false, 0, true, false);
}

mp.events.add('render', () => 
{
	if(canDoBets && rouletteCamera && betObject == null)
	{
		betObject = mp.objects.new(mp.game.joaat("vw_prop_chip_100dollar_x1"), new mp.Vector3(tablesPos[lpCasinoTable][1], tablesPos[lpCasinoTable][2], tablesPos[lpCasinoTable][3]));
		betObject.setCollision(false, false);
	}
	
	if(betObject != null)
	{
		if(!canDoBets || rouletteCamera == null)
		{
			betObject.destroy();
			betObject = null;
			clearTableMarkers();
		}
	}
	
	if(rouletteCamera != null && lpCasinoTable != null)
	{
		if(betObject != null)
		{
			if(mp.game.controls.isDisabledControlJustReleased(0, 25) && !mp.gui.cursor.visible) // RMB
			{
				if(closestChipSpot != null)
				{
					mp.events.callRemote("removeRouletteBet", closestChipSpot);
				}
			}
			
			if(mp.game.controls.isDisabledControlJustReleased(0, 24) && !mp.gui.cursor.visible) // LMB
			{
				if(closestChipSpot != null){
					mp.events.callRemote("makeRouletteBet", closestChipSpot, money , tablebetsnew[lpCasinoTable][bet]);
				}
				
			}
			
			let drawObj = getCameraHitCoord();
			if(drawObj != null)
			{
				// let height = betObject.getHeight(editorFocusObject.position.x, editorFocusObject.position.y, editorFocusObject.position.z, false, true);
				//drawObj.position.z += height / 2;
				drawObj.position.z = tablesPos[lpCasinoTable][3]+0.95;
				betObject.setCoordsNoOffset(drawObj.position.x, drawObj.position.y, drawObj.position.z, false, false, false);
				
				getClosestChipSpot(new mp.Vector3(drawObj.position.x, drawObj.position.y, drawObj.position.z));
			}
		}
		
		let rightAxisX = mp.game.controls.getDisabledControlNormal(0, 220);
		let rightAxisY = mp.game.controls.getDisabledControlNormal(0, 221);
		
		let leftAxisX = 0;
		let leftAxisY = 0;
		
		let pos = rouletteCamera.getCoord();
		let rr = rouletteCamera.getDirection();
		let vector = new mp.Vector3(0, 0, 0);
		vector.x = rr.x * leftAxisY;
		vector.y = rr.y * leftAxisY;
		vector.z = rr.z * leftAxisY;
		
		let upVector = new mp.Vector3(0, 0, 1);
		let rightVector = getCrossProduct(getNormalizedVector(rr), getNormalizedVector(upVector));
		rightVector.x *= leftAxisX * 0.5;
		rightVector.y *= leftAxisX * 0.5;
		rightVector.z *= leftAxisX * 0.5;
		
		let rot = rouletteCamera.getRot(2);
		
		let rotx = rot.x + rightAxisY * -5.0;
		if(rotx > 89) rotx = 89;
		if(rotx < -89) rotx = -89;
		
		rouletteCamera.setRot(rotx, 0.0, rot.z + rightAxisX * -5.0, 2);
	}
});





function getCameraHitCoord()
{
	let position = rouletteCamera.getCoord();
	let direction = rouletteCamera.getDirection();
	let farAway = new mp.Vector3((direction.x * 150) + position.x, (direction.y * 150) + position.y, (direction.z * 150) + position.z);
	
	let hitData = mp.raycasting.testPointToPoint(position, farAway, mp.players.local);
	
	if(hitData != undefined)
	{
		return hitData;
	}
	return null;
}

function getNormalizedVector(vector)
{
	let mag = Math.sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);
	vector.x = vector.x / mag;
	vector.y = vector.y / mag;
	vector.z = vector.z / mag;
	return vector;
}

function getCrossProduct(v1, v2)
{
	let vector = new mp.Vector3(0, 0, 0);
	vector.x = v1.y * v2.z - v1.z * v2.y;
	vector.y = v1.z * v2.x - v1.x * v2.z;
	vector.z = v1.x * v2.y - v1.y * v2.x;
	return vector;
}







let tableMarkers = [];
const tableMarkersOffsets =
{
	"0": [-0.137451171875, -0.146942138671875, 0.9449996948242188],
	"00": [-0.1387939453125, 0.10546875, 0.9449996948242188],
	"1": [-0.0560302734375, -0.1898193359375, 0.9449996948242188],
	"2": [-0.0567626953125, -0.024017333984375, 0.9449996948242188],
	"3": [-0.056884765625, 0.141632080078125, 0.9449996948242188],
	"4": [0.02392578125, -0.187347412109375, 0.9449996948242188],
	"5": [0.0240478515625, -0.02471923828125, 0.9449996948242188],
	"6": [0.02392578125, 0.1422119140625, 0.9449996948242188],
	"7": [0.1038818359375, -0.18902587890625, 0.9449996948242188],
	"8": [0.1044921875, -0.023834228515625, 0.9449996948242188],
	"9": [0.10546875, 0.1419677734375, 0.9449996948242188],
	"10": [0.18701171875, -0.188385009765625, 0.9449996948242188],
	"11": [0.18603515625, -0.0238037109375, 0.9449996948242188],
	"12": [0.1851806640625, 0.143157958984375, 0.9449996948242188],
	"13": [0.2677001953125, -0.18780517578125, 0.9449996948242188],
	"14": [0.26806640625, -0.02301025390625, 0.9449996948242188],
	"15": [0.26611328125, 0.143310546875, 0.9449996948242188],
	"16": [0.3497314453125, -0.18829345703125, 0.9449996948242188],
	"17": [0.349609375, -0.023101806640625, 0.9449996948242188],
	"18": [0.3497314453125, 0.142242431640625, 0.9449996948242188],
	"19": [0.4307861328125, -0.18829345703125, 0.9449996948242188],
	"20": [0.4312744140625, -0.02392578125, 0.9449996948242188],
	"21": [0.431884765625, 0.1416015625, 0.9449996948242188],
	"22": [0.51220703125, -0.188873291015625, 0.9449996948242188],
	"23": [0.5123291015625, -0.023773193359375, 0.9449996948242188],
	"24": [0.511962890625, 0.14215087890625, 0.9449996948242188],
	"25": [0.5931396484375, -0.18890380859375, 0.9449996948242188],
	"26": [0.59375, -0.023651123046875, 0.9449996948242188],
	"27": [0.59375, 0.14080810546875, 0.9449996948242188],
	"28": [0.67529296875, -0.189849853515625, 0.9449996948242188],
	"29": [0.6751708984375, -0.02337646484375, 0.9449996948242188],
	"30": [0.674560546875, 0.141845703125, 0.9449996948242188],
	"31": [0.756591796875, -0.18798828125, 0.9449996948242188],
	"32": [0.7547607421875, -0.0234375, 0.9449996948242188],
	"33": [0.7554931640625, 0.14263916015625, 0.9449996948242188],
	"34": [0.836669921875, -0.188323974609375, 0.9449996948242188],
	"35": [0.8365478515625, -0.0244140625, 0.9449996948242188],
	"36": [0.8359375, 0.14276123046875, 0.9449996948242188]
};

const tableChipsOffsets =
[
	[-0.154541015625, -0.150604248046875, 0.9449996948242188, ["0"]],
	[-0.1561279296875, 0.11505126953125, 0.9449996948242188, ["00"]],
	[-0.059326171875, -0.18701171875, 0.9449996948242188, ["1"]],
	[-0.058349609375, -0.019378662109375, 0.9449996948242188, ["2"]],
	[-0.0587158203125, 0.142059326171875, 0.9449996948242188, ["3"]],
	[0.02294921875, -0.1920166015625, 0.9449996948242188, ["4"]],
	[0.023193359375, -0.01947021484375, 0.9449996948242188, ["5"]],
	[0.024658203125, 0.147369384765625, 0.9449996948242188, ["6"]],
	[0.105224609375, -0.1876220703125, 0.9449996948242188, ["7"]],
	[0.1055908203125, -0.028472900390625, 0.9449996948242188, ["8"]],
	[0.10400390625, 0.147430419921875, 0.9449996948242188, ["9"]],
	[0.187744140625, -0.191802978515625, 0.9449996948242188, ["10"]],
	[0.1866455078125, -0.02667236328125, 0.9449996948242188, ["11"]],
	[0.1842041015625, 0.145965576171875, 0.9449996948242188, ["12"]],
	[0.2696533203125, -0.182464599609375, 0.9449996948242188, ["13"]],
	[0.265869140625, -0.027862548828125, 0.9449996948242188, ["14"]],
	[0.2667236328125, 0.138946533203125, 0.9449996948242188, ["15"]],
	[0.35009765625, -0.186126708984375, 0.9449996948242188, ["16"]],
	[0.348876953125, -0.027740478515625, 0.9449996948242188, ["17"]],
	[0.3497314453125, 0.14715576171875, 0.9449996948242188, ["18"]],
	[0.43212890625, -0.17864990234375, 0.9449996948242188, ["19"]],
	[0.4337158203125, -0.02508544921875, 0.9449996948242188, ["20"]],
	[0.430419921875, 0.138336181640625, 0.9449996948242188, ["21"]],
	[0.51416015625, -0.18603515625, 0.9449996948242188, ["22"]],
	[0.5135498046875, -0.02301025390625, 0.9449996948242188, ["23"]],
	[0.5146484375, 0.14239501953125, 0.9449996948242188, ["24"]],
	[0.59130859375, -0.192413330078125, 0.9449996948242188, ["25"]],
	[0.596923828125, -0.022216796875, 0.9449996948242188, ["26"]],
	[0.5924072265625, 0.14385986328125, 0.9449996948242188, ["27"]],
	[0.6749267578125, -0.187286376953125, 0.9449996948242188, ["28"]],
	[0.67431640625, -0.0262451171875, 0.9449996948242188, ["29"]],
	[0.6756591796875, 0.140594482421875, 0.9449996948242188, ["30"]],
	[0.7542724609375, -0.19415283203125, 0.9449996948242188, ["31"]],
	[0.7542724609375, -0.01898193359375, 0.9449996948242188, ["32"]],
	[0.75439453125, 0.1448974609375, 0.9449996948242188, ["33"]],
	[0.8392333984375, -0.18951416015625, 0.9449996948242188, ["34"]],
	[0.837646484375, -0.023468017578125, 0.9449996948242188, ["35"]],
	[0.8380126953125, 0.14227294921875, 0.9449996948242188, ["36"]],
	
	[0.0643310546875, -0.304718017578125, 0.9449996948242188, ["1","2","3","4","5","6","7","8","9","10","11","12"]], //1st12
	[0.392822265625, -0.304779052734375, 0.9449996948242188, ["13","14","15","16","17","18","19","20","21","22","23","24"]],//2nd12
	[0.712158203125, -0.30303955078125, 0.9449996948242188, ["25","26","27","28","29","30","31","32","33","34","35","36"]],//3rd12
	[0.9222412109375, -0.185882568359375, 0.9449996948242188, ["1","4","7","10","13","16","19","22","25","28","31","34"]],//2to1
	[0.9229736328125, -0.0181884765625, 0.9449996948242188, ["2","5","8","11","14","17","20","23","26","29","32","35"]],//2to1
	[0.9248046875, 0.14849853515625, 0.9449996948242188, ["3","6","9","12","15","18","21","24","27","30","33","36"]],//2to1
	[-0.011474609375, -0.378875732421875, 0.9449996948242188, ["1","2","3","4","5","6","7","8","9","10","11","12","13","14","15","16","17","18"]],//1-18
	[0.142822265625, -0.375732421875, 0.9449996948242188, ["2","4","6","8","10","12","14","16","18","20","22","24","26","28","30","32","34","36"]], //even
	[0.308349609375, -0.37542724609375, 0.9449996948242188, ["1","3","5","7","9","12","14","16","18","19","21","23","25","27","30","32","34","36"]],//red
	[0.4713134765625, -0.376861572265625, 0.9449996948242188, ["2","4","6","8","10","11","13","15","17","20","22","24","26","28","29","31","33","35"]],//black
	[0.6341552734375, -0.376495361328125, 0.9449996948242188, ["1","3","5","7","9","11","13","15","17","19","21","23","25","27","29","31","33","35"]],//odd
	[0.7926025390625, -0.382232666015625, 0.9449996948242188, ["19","20","21","22","23","24","25","26","27","28","29","30","31","32","33","34","35","36"]]//19-36
];



function clearTableMarkers()
{
	for(var i=0; i < tableMarkers.length; i++)
	{
		tableMarkers[i].destroy();
	}
	tableMarkers = [];
}

function getClosestChipSpot(vector)
{
	var spot = null;
	var prevDistance = 0.05;
	var dist = null;
	
	for(var i=0; i < tableChipsOffsets.length; i++)
	{
		dist = mp.Vector3.getDistanceBetweenPoints3D(vector, new mp.Vector3(tablesPos[lpCasinoTable][1]+tableChipsOffsets[i][0], tablesPos[lpCasinoTable][2]+tableChipsOffsets[i][1], tablesPos[lpCasinoTable][3]+tableChipsOffsets[i][2]));
		if(dist <= prevDistance)
		{
			spot = i;
			prevDistance = dist;
		}
	}
	
	if(spot != closestChipSpot)
	{
		closestChipSpot = spot;
		clearTableMarkers();
		
		if(spot != null)
		{
			var key = null;
			var obj = null;
			for(var i=0; i < tableChipsOffsets[spot][3].length; i++)
			{
				key = tableChipsOffsets[spot][3][i];
				if(key == "00" || key == "0")
				{
					obj = mp.objects.new(269022546, new mp.Vector3(tablesPos[lpCasinoTable][1]+tableMarkersOffsets[key][0], tablesPos[lpCasinoTable][2]+tableMarkersOffsets[key][1], tablesPos[lpCasinoTable][3]+tableMarkersOffsets[key][2]));
					obj.setCollision(false, false);
					tableMarkers.push(obj);
				}
				else
				{
					tableMarkers.push(mp.objects.new(3267450776, new mp.Vector3(tablesPos[lpCasinoTable][1]+tableMarkersOffsets[key][0], tablesPos[lpCasinoTable][2]+tableMarkersOffsets[key][1], tablesPos[lpCasinoTable][3]+tableMarkersOffsets[key][2])));
				}
			}
		}
	}
	
}



