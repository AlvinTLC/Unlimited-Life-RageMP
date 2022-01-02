var itemsData = {
    "-1": "Maske",
    "-3": "Handschuhe",
    "-4": "Hose",
    "-5": "Rucksack",
    "-6": "Schuhe",
    "-7": "Zubehör",
    "-8": "Unterwäsche",
    "-9": "Panzerung",
    "-10": "Juwelen",
    "-11": "Oberbekleidung",
    "-12": "Kopfbedeckung",
    "-13": "Gläser",
    "-14": "Zubehör",
    0: "Prüfling",
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
    11: "Dietrich",
    12: "Geldsack",
    13: "Materialien",
    14: "Drogen",
    15: "Bohrtasche",
    16: "Militärische Dietriche",
    17: "Tasche",
    18: "Krawatten",
    19: "Autoschlüssel",
    40: "Geschenk",
    41: "Schlüsselbund",

    20: "Auf einer Zitronenschale",
    21: "Auf einer Preiselbeere",
    22: "Russischer Standard",
    23: "Asahi",
    24: "Midori",
    25: "Yamazaki",
    26: "Martini Asti",
    27: "Sambuca",
    28: "Campari",
    29: "Jivan",
    30: "Ararat",
    31: "Noyan Tapan",

    100: "Pistole",
    101: "Kampfpistole",
    102: "Pistole .50",
    103: "SNS-Pistole",
    104: "Schwere Pistole",
    105: "Vintage Pistol",
    106: "Scharfschützenpistole",
    107: "Revolver",
    108: "AP-Pistole",
    109: "Betäubungspistole",
    110: "Leuchtpistole",
    111: "Double Action",
    112: "Pistole Mk2",
    113: "SNSPistol Mk2",
    114: "Revolver Mk2",

    115: "Micro SMG",
    116: "Maschinenpistole",
    117: "SMG",
    118: "Assault SMG",
    119: "Combat PDW",
    120: "MG",
    121: "Combat MG",
    122: "Gusenberg",
    123: "Mini SMG",
    124: "SMG Mk2",
    125: "Combat MG Mk2",

    126: "Sturmgewehr",
    127: "Karabiner-Gewehr",
    128: "Advanced Rifle",
    129: "Spezial-Karabiner",
    130: "Bullpup Rifle",
    131: "Compact Rifle",
    132: "Assault Rifle Mk2",
    133: "Carbine Rifle Mk2",
    134: "Spezial-Karabiner Mk2",
    135: "Bullpup Rifle Mk2",

    136: "Scharfschützengewehr",
    137: "Schwerer Scharfschütze",
    138: "Marksman Rifle",
    139: "Heavy Sniper Mk2",
    140: "Marksman Rifle Mk2",

    141: "Pump Shotgun",
    142: "SawnOff Shotgun",
    143: "Bullpup Shotgun",
    144: "Assault Shotgun",
    145: "Muskete",
    146: "Schwere Schrotflinte",
    147: "Doppelläufige Schrotflinte",
    148: "Kehrmaschine Schrotflinte",
    149: "Pump Shotgun Mk2",

    180: "Messer",
    181: "Stock",
    182: "Hammer",
    183: "Fledermaus",
    184: "Schrott",
    185: "Golfschläger",
    186: "Flasche",
    187: "Dolch",
    188: "Axt",
    189: "Knuckles",
    190: "Machete",
    191: "Flashlight",
    192: "Schweizer Messer",
    193: "Cue",
    194: "Taste",    
    195: "Streitaxt",

    200: "Pistolenlehre",
    201: "Kleinkaliber",
    202: "Maschinengewehr-Kaliber",
    203: "Scharfschützenkaliber",
    204: "Schrotflinte",
	
	/* Fischen */
	205: "Angelrute",
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
}

Vue.component('item', {
	template: '<div :class="test"><div class="item" :class="{active: isactive}" @click.right.prevent="select">\
    <img :src="src"><p>{{name}}</p><span>{{count}}</span><p class="sub">{{subdata}}</p></div></div>',
    props: ['id', 'index', 'count', 'isactive', 'type', 'subdata'],
    data: function () {
        return {
            src: 'items/' + this.id + '.png',
            name: itemsData[this.id],
			test: 'h item' + this.id + 'eq',
        }
    },
    methods: {
        select: function (event) {
            board.sType = (this.type == 'inv') ? 1 : 0;
            board.sID = this.id;
            board.sIndex = this.index;
            context.type = (this.type == 'inv') ? 1 : 0;
        }
    }
})
var board = new Vue({
    el: ".board",
    data: {
        active: false,
        outside: false,
        outType: 0,
        outHead: "Extern",
        stats: [1, 2, "88005553535", "Admin", 0, 0, "123456789$", "987654321$", "", 9999999, 9999999, 100, 100],
        items: [[1, 5, 1], [5, 10, 0], [10, 500, 0], [11, 100, 0]],
        outitems: [[1, 5], [5, 10], [10, 500]],
        sIndex: 0,
        sType: 0,
        sID: 0,
        key: 0,
    },
    methods: {
        context: function (event) {
            if (clickInsideElement(event, 'item')) {
                context.show(event.pageX, event.pageY)
            } else {
                context.hide()
            }
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
        itemsSet: function (json) {
            this.key++
            this.items = json
        },
        itemUpd: function (index, data) {
            this.key++
            this.items[index] = data
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
        active: false,
        style: '',
        type: true
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