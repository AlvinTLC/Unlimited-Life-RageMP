var itemsData = {
    "-1": "Maske",
    "-3": "Handschuhe",
    "-4": "Hosen",
    42: "Rucksack",
    "-6": "Schuhe",
    "-7": "Zubehör",
    "-8": "Unterwäsche",
    "-9": "Schutzweste",
    "-10": "Dekorationen",
    "-11": "Oberbekleidung",
    "-12": "Kopfbedeckung",
    "-13": "Brillen",
    "-14": "Zubehör",
    0: "Test Item",
    1: "Erste-Hilfe-Kasten",
    2: "Kanister",
    3: "Chips",
    4: "Bier",
    5: "Pizza",
    6: "Burger",
    7: "Hot Dog",
    8: "Sandwich",
    9: "eCola",
    10: "Sprunk",
    11: "Dietrich", //?? Отмычка для замков
    12: "Tasche voller Geld", // kein plan was das bedeuten soll. Сумка с деньгами
    13: "Materialien",
    14: "Marihuana",
    15: "Bohrertasche",
    16: "Militärische Dietriche",
    17: "Sack",
    18: "Krawatten",
    19: "Autoschlüssel",
    32: "Zigarette",
    40: "Geschenk",
    41: "Schlüsselbund",

    20: `"Auf einer Zitronenschale"`,
    21: `"Auf Preiselbeeren"`,
    22: `"Russischer Standard"`,
    23: `"Asahi"`,
    24: `"Midori"`,
    25: `"Yamazaki"`,
    26: `"Martini Asti"`,
    27: `"Sambuca"`,
    28: `"Campari"`,
    29: `"Jivan"`,
    30: `"Ararat"`,
    31: `"Noyan Tapan"`,

    100: "Pistol",
    101: "Combat Pistol",
    102: "Pistol .50",
    103: "SNS Pistol",
    104: "Heavy Pistol",
    105: "Vintage Pistol",
    106: "Marksman Pistol",
    107: "Revolver",
    108: "AP Pistol",
    109: "Stun Gun",
    110: "Flare Gun",
    111: "Double Action",
    112: "Pistol Mk2",
    113: "SNSPistol Mk2",
    114: "Revolver Mk2",

    115: "Micro SMG",
    116: "Machine Pistol",
    117: "SMG",
    118: "Assault SMG",
    119: "Combat PDW",
    120: "MG",
    121: "Combat MG",
    122: "Gusenberg",
    123: "Mini SMG",
    124: "SMG Mk2",
    125: "Combat MG Mk2",

    126: "Assault Rifle",
    127: "Carbine Rifle",
    128: "Advanced Rifle",
    129: "Special Carbine",
    130: "Bullpup Rifle",
    131: "Compact Rifle",
    132: "Assault Rifle Mk2",
    133: "Carbine Rifle Mk2",
    134: "Special Carbine Mk2",
    135: "Bullpup Rifle Mk2",

    136: "Sniper Rifle",
    137: "Heavy Sniper",
    138: "Marksman Rifle",
    139: "Heavy Sniper Mk2",
    140: "Marksman Rifle Mk2",

    141: "Pump Shotgun",
    142: "SawnOff Shotgun",
    143: "Bullpup Shotgun",
    144: "Assault Shotgun",
    145: "Musket",
    146: "Heavy Shotgun",
    147: "Double Barrel Shotgun",
    148: "Sweeper Shotgun",
    149: "Pump Shotgun Mk2",

    180: "Messer",
    181: "Der Knüppel",
    182: "Hammer",
    183: "Die Fledermaus",
    184: "Schrott",
    185: "Golf Putter",
    186: "Flasche",
    187: "Dolch",
    188: "Axt",
    189: "Achsschenkel",
    190: "Machete",
    191: "Taschenlampe",
    192: "Schweizer Messer",
    193: "Cue",
    194: "Schlüssel",
    195: "Eine Streitaxt",

    200: "Pistolenkaliber",
    201: "Kleinkaliber",
    202: "Automatik-Kaliber",
    203: "Scharfschützenkaliber",
    204: "Schrotflinte",
	
	//Fischen
	205: "Angelrute",
	206: "Verbesserte Angelrute",
	207: "MK2 Angelrute",
    208: "Köder",
    209: "Schmelzen",
    210: "Kunja",
    211: "Lachs",
    212: "Barsch",
    213: "Störung",
    214: "Skate",
	215: "Thunfisch",
	216: "Aal",
	217: "Schwarzer Amur",
	218: "Hecht",
	
	// AlcoShop
	219: "Martini Asti",
	220: "Sambuca",
	221: "Wodka mit Zitrone",
	222: "Wodka auf Preiselbeeren",
	223: "Russischer Standard",
	224: "Cognac Jivan",
	225: "Ararat Cognac",
	226: "Bier vom Fass",
	227: "Bier in Flaschen",
	228: "Wasserpfeife",
    //FarmerMarkt
    234: "Ernte",
    235: "Saatgut",
	// Reparatur
	250: "Reparatur. Bausatz",
	251: "Bandage",
	252: "Erste-Hilfe-Kasten", 
	253: "Tabletten",
	254: "Adrenalin-Spritze",
	//Bauernhof
	255: "Coca-Blätter",
	//Taucher
	256: "Gold",
    257: "Eisen",
    1024: "Joint",
    1028: "Funk",
    1029: "Wasser",
    1031: "Donut",
    1030: "Kaffee",
    1043: "Schinken",
}

var itemsInfo = {
	"-1": "Die Maske wird helfen, Ihre Identität zu verbergen.",
    "-3": "Handschuhe",
    "-4": "Hose",
    42: "Rucksack",
    "-6": "Schuhe",
    "-7": "Schmuck/Krawatte",
    "-8": "Unterwäsche",
    "-9": "Körperpanzerung - hilft Ihnen, weniger Schussschaden zu erleiden",
    "-10": "Sprunk - hilft, gegen den Durst",
    "-11": "Oberbekleidung",
    "-12": "Kopfbedeckung",
    "-13": "Gläser",
    "-14": "Uhren/Armbänder",
    1: "Erste-Hilfe-Set - hilft bei der Wiederbelebung oder Wiederherstellung der Gesundheit",
    2: "Ein Kanister Benzin - hilft, das Fahrzeug überall aufzutanken",
    3: "Packung Chips - wird helfen, den Hunger zu stillen",
    4: "Alkoholfreies Bier zum Abschluss",
    5: "Pizza - wird helfen, den Hunger zu stillen",
    6: "Burger, hilf, den Hunger zu stillen",
    7: "Hotdog, helfen Sie, den Hunger zu stillen",
	8: "Sandwich zur Wiederherstellung des Hungers",
	9: "Cola gegen den Durst",
	10: "Sprunk, um den Durst zu stillen",
	11: "Lock pick - hilft Schlösser knacken",
	12: "Tasche mit Geld - höchstwahrscheinlich gestohlenes Geld",
	13: "Materialien - helfen bei der Herstellung von Waffen",
	14: "Marihuana-Beutel - wird helfen, die Gesundheit wiederherzustellen",
	15: "Bag of drills - will help to open the vault",
	16: "Militärischer Dietrich - hilft, militärische Ausrüstung zu verstecken",
	17: "Tasche - wenn man sie einem Mann aufsetzt, wird er nicht sehen",
	18: "Krawatten - werden helfen, einen Mann zu binden",
	19: "Schlüssel - hilft beim Öffnen Ihrer persönlichen TK",
	20: "Schnaps - gibt alkoholische Wirkung",
	21: "Alkohol hat eine alkoholische Wirkung",
	22: "Alkohol hat eine alkoholische Wirkung",
	23: "Alkohol hat eine alkoholische Wirkung",
	24: "Alkohol hat eine alkoholische Wirkung",
	25: "Alkohol hat eine alkoholische Wirkung",
	26: "Alkohol hat eine alkoholische Wirkung",
	27: "Alkohol hat eine alkoholische Wirkung",
    28: "Alkohol hat eine alkoholische Wirkung",
    32: "Zigaretten schaden deine Gesundheit",
    234: "Ernte",
    235: "Saatgut",
    1024: "Joint zum kiffen",
    1029: "Wasser schmeckt stumpf",
    1030: "Donut",
    1031: "Kaffee",
    1043: "Leckerer Schinken :P",
}

Vue.component('item', {
	template: '<div :class="test"><div class="item" v-bind:title="name" v-bind:weight="(weight*count).toFixed(2)" :fastslot="fast_slot" v-bind:class="{active: isactive}" @click.right.prevent="select"> \
    <img :src="src"><span>{{count}}</span><!--<p class="sub">{{subdata}}</p>--><p class="names">{{name}}<br><a>{{info}}</a><b>{{count}} St.</b></p></div></div>',
    props: ['id', 'index', 'count', 'isactive', 'type', 'subdata'],
    data: function () {
        return {
            src: 'items/' + this.id + '.png',
			title: itemsData[this.id],
            name: itemsData[this.id],
            info: itemsInfo[this.id],
			test: 'item' + this.id + 'ma',
        }
    },
    methods: {
        select: function (event) {
            board.sType = (this.type == 'inv') ? 1 : 0;
            board.sID = this.id;
            board.sIndex = this.index;
            context.type = (this.type == 'inv') ? 1 : 0;
			context.fastSlot = this.fast_slot
        }
    }
})
var board = new Vue({
    el: ".board",
    data: {
        active: false,
        outside: false,
		zohan: ["Level", "Warns", "Datum der Einreise", "Telefonnummer", "Kontonummer", "Reisepassnummer", "Fraktion", "Rang", "Arbeit", "Status"],
		outType: 0,
        outHead: "Дополнительный инвентарь", 
		//		0        1  	 2 		     3 		        4	   5            6		  7			  8				9	  10	  11        12	      13    
		stats: ["15", "30/60", "777 777", "Администрация", "2", "A B C D", "01.05.1980", "Строитель", "CityHall", "17", "Vovan", "Putin", "333 666", "4276 7700"],
        items: [[-6, 5, 1],[-7, 5, 1],[-8, 5, 1],[-9, 5, 1],[-11, 5, 1],[-12, 5, 1],[-13, 5, 1],[-14, 5, 1],[-1, 5, 1],[-3, 5, 1],[-4, 5, 1],[1, 5, 1],[1, 5, 1],[5, 10, 0],[5, 10, 0],[5, 10, 0],[5, 10, 0],[5, 10, 0],[5, 10, 0], [5, 10, 0], [10, 500, 0], [1, 5, 1],[5, 10, 0],[5, 10, 0],[5, 10, 0],[5, 10, 0],[5, 10, 0],[5, 10, 0], [5, 10, 0], [10, 500, 0], [11, 100, 0],[5, 10, 0], [5, 10, 0], [10, 500, 0], [11, 100, 0],[5, 10, 0], [5, 10, 0], [10, 500, 0], [11, 100, 0],[5, 10, 0], [5, 10, 0], [10, 500, 0], [11, 100, 0],[5, 10, 0], [5, 10, 0], [10, 500, 0], [11, 100, 0], [10, 500, 0], [11, 100, 0],[5, 10, 0], [5, 10, 0], [10, 500, 0], [11, 100, 0],[5, 10, 0], [5, 10, 0], [10, 500, 0], [11, 100, 0],[5, 10, 0], [5, 10, 0], [10, 500, 0], [11, 100, 0], [10, 500, 0], [11, 100, 0],[5, 10, 0], [5, 10, 0], [10, 500, 0], [11, 100, 0],[5, 10, 0], [5, 10, 0], [10, 500, 0], [11, 100, 0],[5, 10, 0], [5, 10, 0], [10, 500, 0], [11, 100, 0]],
        outitems: [[1, 5, 1],[5, 10, 0],[5, 10, 0],[5, 10, 0],[5, 10, 0],[5, 10, 0],[5, 10, 0], [5, 10, 0], [10, 500, 0], [11, 100, 0],[5, 10, 0],[5, 10, 0],[5, 10, 0], [5, 10, 0], [10, 500, 0], [11, 100, 0],[5, 10, 0],[5, 10, 0],[5, 10, 0], [5, 10, 0], [10, 500, 0], [11, 100, 0]],
		money: 0,
		donate: 0,
		bank: 0, 
		page: 1,
		statis: 0,
        sIndex: 0,
        sType: 0,
        sID: 0,
        key: 0,
		arraymax: 0,
        balance: 0,
        menu: 0,
        totrans: null,
        aftertrans: null,
        fname: null,
        pause:0,
        lname: null
    },
    methods: {
        context: function (event) {
            if (clickInsideElement(event, 'item')) {
                context.show(event.pageX, event.pageY)
            } else {
                context.hide()
            }
        },
		        close: function(){
            this.active = false
            this.balance = 0;
            this.menu = 0;
            this.totrans = null;
            this.aftertrans = null;
			this.fname = null;
			this.lname = null;
        },
        onInputTrans: function(){
            if(!this.check(this.totrans)){
                this.totrans = null;
                this.aftertrans = null;
            } else {
				if(Number(this.totrans) < 0) this.totrans = 0;
                this.aftertrans = Number(this.totrans) * 1000;
            }
        },
        onInputName: function(){
            if(this.check(this.fname) || this.check(this.lname)){
                this.fname = null;
                this.lname = null;
            }
        },
        check: function(str) {
            return (/[^a-zA-Z]/g.test(str));
        },
        back: function(){
            this.menu = 4;
        },
        open: function(id){
            this.menu = id;
        },
		
        wheel: function(id){
            this.pause = new Date().getTime();
            let data = null;
            mp.trigger("wheel", id, data);
        },
        buy: function(id){
            if (new Date().getTime() - this.pause < 5000) {
                mp.events.call('notify', 4, 9, "Warte 5 Sekunden lang", 3000);
                return;
            }
            this.pause = new Date().getTime();
            let data = null;
            switch(id){
                case 1:
                data = this.fname+"_"+this.lname;
                break;
                case 2:
                data = this.totrans;
                break;
                case 9:
                    data = this.totrans;
                    break;
                default:
                break;
            }
            mp.trigger("donbuy", id, data);
        },
		show: function(stars){
			this.balance = stars;
		},
        hide: function (event) {
            context.hide()
        },
        outSet: function (json) {
            this.key++
            this.outType = json[0]
            this.outHead = json[1]
            this.outitems = json[2]
        },
		pages: function(id){
            this.page = id;
        },
		statsid: function(id){
            this.statis = id;
        },
		itemsSet: function(t) {
                this.key++, this.items = t, this.usedFastSlots = [!1, !1, !1, !1, !1];
                for (let t = 1; t < 6; t++) mp.trigger("bindSlotKey", 0, t, !1);
                for (let t = 0; t < this.items.length; t++) {
                    const s = this.items[t];
                    s[6] > 0 && (this.usedFastSlots[s[6]] = !0, mp.trigger("bindSlotKey", t, s[6], !0))
                }
                this.updateWeight()
            },
            itemUpd: function(t, s) {
                this.key++, this.items[t] = s, this.updateWeight()
            }, 
			updateWeight: function() {
                let t = 0;
                this.items.forEach(s => {
                    t += s[4] * s[1]
                }), this.weight = t
            },
            useFastSlot: function(t) {
                this.usedFastSlots[t] || (this.selectFastSlot = !1, this.sFastSlot = t, this.items[board.sIndex][6] = this.sFastSlot, this.usedFastSlots[t] = !0, mp.trigger("useFastSlot", this.sIndex, this.sFastSlot, 0))
            },
            unsetFastSlot: function() {
                let t = this.items[board.sIndex][6];
                this.usedFastSlots[t] = !1, this.items[board.sIndex][6] = 0, this.key++, mp.trigger("useFastSlot", this.sIndex, 0, t)
            },
        send: function (id) {
            let type = (this.sType) ? 0 : this.outType
            mp.trigger('boardCB', id, type, this.sIndex)
        }
    }
})
var context = new Vue({
    el: ".context_menu",
    data: {
		men: ["Verwenden", "Übertragen", "Abrufen", "Wegwerfen"],
        active: false,
        style: '',
        type: true,
        fastSlot: -1
    },
    methods: {
        show: function (x, y) {
            this.style = `left:${x}px;top:${y}px;`
            this.active = true
        },
        hide: function () {
            this.active = false
        },
        btn: function (id) {
            this.hide()
            board.send(id)
        },
        setFastSlot: function() {
		board.usedFastSlots.includes(!1) && (this.hide(), board.selectFastSlot = !0)
            },
            unsetFastSlot: function() {
                this.hide(), board.unsetFastSlot()
            }
    }
})
function clickInsideElement(e, className) {
    var el = e.srcElement || e.target;
    if (el.classList.contains(className)) {
        return el;
    } else {
        while (el = el.parentNode) {
            if (el.classList && el.classList.contains(className)) {
                return el;
            }
        }
    }
    return false;
}