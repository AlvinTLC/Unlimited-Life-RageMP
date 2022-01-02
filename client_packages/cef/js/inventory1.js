var inventory = new Vue({
    el: ".vinventory",
    data: {
        active: false,
		
		limits: {
            invent: 20,
            trunk: 20,
		},

		initInvent: [],
        invent: [],
        
		trunktoggled: false,
		initTrunk: [],
		trunk: [],
		trunktype: 0,
        trunktitle: "",
		
		sType: 0,

        items: {
            "-1": 
            {
                name: "Maske",
                type: ""
            },
            "-3":
			{
                name: "Handschuhe",
                type: ""
            },
            "-4":
			{
                name: "Hosen",
                type: ""
            },
            "-6":
			{
                name: "Schuhe",
                type: ""
            },
            "-7":
			{
                name: "Zubehör",
                type: ""
            },
            "-8":
			{
                name: "Unterwäsche",
                type: ""
            },
            "-9":
			{
                name: "Schutzweste",
                type: ""
            },
            "-10":
			{
                name: "Dekorationen",
                type: ""
            },
            "-11":
			{
                name: "Oberbekleidung",
                type: ""
            },
            "-12":
			{
                name: "Kopfbedeckung",
                type: ""
            },
            "-13":
			{
                name: "Brillen",
                type: ""
            },
            "-14":
			{
                name: "Zubehör",
                type: ""
            },
            0:
			{
                name: "Test Item",
                type: ""
            },
            1:
			{
                name: "Erste-Hilfe-Kasten",
                type: ""
            },
            2:
			{
                name: "Kanister",
                type: ""
            },
            3:
			{
                name: "Chips",
                type: ""
            },
            4:
			{
                name: "Bier",
                type: ""
            },
            5:
			{
                name: "Pizza",
                type: ""
            },
            6:
			{
                name: "Burger",
                type: ""
            },
            7:
			{
				name: "Hot Dog",
            	type: ""
			},
			8:
			{
				name: "Sandwich",
            	type: ""
			},
			9:
			{
				name: "eCola",
            	type: ""
			},
			10:
			{
				name: "Sprunk",
            	type: ""
			},
			11:
			{
				name: "Dietrich",
            	type: ""
			},
			12:
			{
				name: "Tasche voller Geld",
            	type: ""
			},
			13:
			{
				name: "Materialien",
            	type: ""
			},
			14:
			{
				name: "Drogen",
            	type: ""
			},
			15:
			{
				name: "Bohrertasche",
            	type: ""
			},
			16:
			{
				name: "Bohrertasche",
            	type: ""
			},
			17:
			{
				name: "Sack",
            	type: ""
			},
			18:
			{
				name: "Krawatten",
            	type: ""
			},
			19:
			{
				name: "Autoschlüssel",
            	type: ""
			},
			40:
			{
				name: "Geschenk",
            	type: ""
			},
			41:
			{
				name: "Schlüsselbund",
                type: ""
			},
			1888:
			{
				name: "Rucksack",
                type: ""
            },
            20: 
            {
                name: "\"Auf einer Zitronenschale\"",
            	type: ""
			},
			21:
            {
                name: "\"Auf Preiselbeeren\"",
            	type: ""
			},
			22:
            {
                name: "\"Russischer Standard\"",
            	type: ""
			},
			23:
            {
                name: "\"Asahi\"",
            	type: ""
			},
			24:
            {
                name: "\"Midori\"",
            	type: ""
			},
			25:
            {
                name: "\"Yamazaki\"",
            	type: ""
			},
			26:
            {
                name: "\"Martini Asti\"",
            	type: ""
			},
			27:
            {
                name: "\"Sambuca\"",
            	type: ""
			},
			28:
            {
                name: "\"Campari\"",
            	type: ""
			},
			29:
            {
                name: "\"Jivan\"",
            	type: ""
			},
			30:
            {
                name: "\"Ararat\"",
            	type: ""
			},
			31:
            {
                name: "\"Noyan Tapan\"",
                type: ""
            },
            100:
			{
				name: "Pistol",
                type: "weapon"
			},
			101:
			{
				name: "Combat Pistol",
            	type: "weapon"
			},
			102:
			{
				name: "Pistol .50",
            	type: "weapon"
			},
			103:
			{
				name: "SNS Pistol",
            	type: "weapon"
			},
			104:
			{
				name: "Heavy Pistol",
            	type: "weapon"
			},
			105:
			{
				name: "Vintage Pistol",
            	type: "weapon"
			},
			106:
			{
				name: "Marksman Pistol",
            	type: "weapon"
			},
			107:
			{
				name: "Revolver",
            	type: "weapon"
			},
			108:
			{
				name: "AP Pistol",
            	type: "weapon"
			},
			109:
			{
				name: "Stun Gun",
            	type: "weapon"
			},
			110:
			{
				name: "Flare Gun",
            	type: "weapon"
			},
			111:
			{
				name: "Double Action",
            	type: "weapon"
			},
			112:
			{
				name: "Pistol Mk2",
            	type: "weapon"
			},
			113:
			{
				name: "SNSPistol Mk2",
            	type: "weapon"
			},
			114:
			{
				name: "Revolver Mk2",
                type: "weapon"
            },
            115:
			{
				name: "Micro SMG",
            	type: "weapon"
			},
			116:
			{
				name: "Machine Pistol",
            	type: "weapon"
			},
			117:
			{
				name: "SMG",
            	type: "weapon"
			},
			118:
			{
				name: "Assault SMG",
            	type: "weapon"
			},
			119:
			{
				name: "Combat PDW",
            	type: "weapon"
			},
			120:
			{
				name: "MG",
            	type: "weapon"
			},
			121:
			{
				name: "Combat MG",
            	type: "weapon"
			},
			122:
			{
				name: "Gusenberg",
            	type: "weapon"
			},
			123:
			{
				name: "Mini SMG",
            	type: ""
			},
			124:
			{
				name: "SMG Mk2",
            	type: ""
			},
			125:
			{
				name: "Combat MG Mk2",
                type: ""
            },
            126:
			{
				name: "Assault Rifle",
            	type: ""
			},
			127:
			{
				name: "Carbine Rifle",
            	type: ""
			},
			128:
			{
				name: "Advanced Rifle",
            	type: ""
			},
			129:
			{
				name: "Special Carbine",
            	type: ""
			},
			130:
			{
				name: "Bullpup Rifle",
            	type: ""
			},
			131:
			{
				name: "Compact Rifle",
            	type: ""
			},
			132:
			{
				name: "Assault Rifle Mk2",
            	type: ""
			},
			133:
			{
				name: "Carbine Rifle Mk2",
            	type: ""
			},
			134:
			{
				name: "Special Carbine Mk2",
            	type: ""
			},
			135:
			{
				name: "Bullpup Rifle Mk2",
                type: ""
            },
            136:
			{
				name: "Sniper Rifle",
            	type: ""
			},
			137:
			{
				name: "Heavy Sniper",
            	type: ""
			},
			138:
			{
				name: "Marksman Rifle",
            	type: ""
			},
			139:
			{
				name: "Heavy Sniper Mk2",
            	type: ""
			},
			140:
			{
				name: "Marksman Rifle Mk2",
                type: ""
            },
            141:
			{
				name: "Pump Shotgun",
            	type: ""
			},
			142:
			{
				name: "SawnOff Shotgun",
            	type: ""
			},
			143:
			{
				name: "Bullpup Shotgun",
            	type: ""
			},
			144:
			{
				name: "Assault Shotgun",
            	type: ""
			},
			145:
			{
				name: "Musket",
            	type: ""
			},
			146:
			{
				name: "Heavy Shotgun",
            	type: ""
			},
			147:
			{
				name: "Double Barrel Shotgun",
            	type: ""
			},
			148:
			{
				name: "Sweeper Shotgun",
            	type: ""
			},
			149:
			{
				name: "Pump Shotgun Mk2",
                type: ""
            },
            180:
			{
				name: "Messer",
            	type: ""
			},
			181:
			{
				name: "Der Knüppel",
            	type: ""
			},
			182:
			{
				name: "Hammer",
            	type: ""
			},
			183:
			{
				name: "Die Fledermaus",
            	type: ""
			},
			184:
			{
				name: "Schrott",
            	type: ""
			},
			185:
			{
				name: "Golf Putter",
            	type: ""
			},
			186:
			{
				name: "Flasche",
            	type: ""
			},
			187:
			{
				name: "Dolch",
            	type: ""
			},
			188:
			{
				name: "Axt",
            	type: ""
			},
			189:
			{
				name: "Achsschenkel",
            	type: ""
			},
			190:
			{
				name: "Machete",
            	type: ""
			},
			191:
			{
				name: "Taschenlampe",
            	type: ""
			},
			192:
			{
				name: "Schweizer Messer",
            	type: ""
			},
			193:
			{
				name: "Cue",
            	type: ""
			},
			194:
			{
				name: "Taste",
            	type: ""
			},
			195:
			{
				name: "Eine Streitaxt",
                type: ""
            },
            200:
			{
				name: "Pistolenkaliber",
            	type: ""
			},
			201:
			{
				name: "Kleinkaliber",
            	type: ""
			},
			202:
			{
				name: "Automatik-Kaliber",
            	type: ""
			},
			203:
			{
				name: "Scharfschützenkaliber",
            	type: ""
			},
			204:
			{
                name: "Fraktion",
                type: ""
            }
        },   
	
        // Player stats
        username: "",
        level: 0,
        exp: "",
        fractionname: "",
        fractionlevel: 0,
        jobname: "",
        phonenumber: "",
        status: "",
        warnscount: "",
        licensecount: "",
        registerdate: "",
        passid: "",
        bankid: "",
    },
    methods: {
        ToggleInventory: function(toggle) {
            inventory.active = toggle;

            if(toggle === false)
            {
				if(JSON.stringify(inventory.initInvent) != JSON.stringify(inventory.invent))
				{
					inventory.initInvent = inventory.invent;
					mp.trigger("inventory", 7, JSON.stringify(inventory.invent));
				}
				
				if(inventory.trunktoggled && JSON.stringify(inventory.initTrunk) != JSON.stringify(inventory.trunk))
				{
					inventory.initTrunk = inventory.trunk;
					mp.trigger("inventory", 8, JSON.stringify(inventory.trunk));
					mp.trigger("inventory", 9);
				}
				else mp.trigger("inventory", 9);
            }
            else
            {
                $(`#grid-1 .dropbox`).remove();
                $(`#grid-2 .dropbox`).remove();

                $('#grid-1').append(dropbox);
		        $('#grid-2').append(dropbox);
            }
        },
        CloseInventory: function() {
            mp.trigger("inventory", 1);
        },
        UpdateStats: function (data) {
			
            data = JSON.parse(data);

            inventory.username = data[0];
            inventory.level = data[1];
            inventory.exp = data[2];
            inventory.fractionname = data[3];
            inventory.fractionlevel = data[4];
            inventory.jobname = data[5];
            inventory.phonenumber = data[6];
            inventory.status = data[7];
            inventory.warnscount = data[8];
            inventory.licensecount = data[9];
            inventory.registerdate = data[10];
            inventory.passid = data[11];
            inventory.bankid = data[12];
			
        },
        UpdatePlayerItems: function(data) {
            
            clearItem(`inventory`);
            data = JSON.parse(data);
            for(var i = 0; i < data.length; i++)
            {
                if(i < count_max[1])
                {
					var newitem = {type: data[i][0], count: data[i][1], active: data[i][2], serial: data[i][3]};
					inventory.initInvent[i] = newitem;
                    addItem(`inventory`, newitem);
                }
            }
        },
        UpdatePlayerItem: function(index, data) {

            if(index < count_max[1])
            {
                var newitem = {type: data[0], count: data[1], active: data[2], serial: data[3]};
                updateItem(`inventory`, index, newitem);
            }
        },
        
        UpdateTrunkItems: function(data) {

            clearItem(`trunk`);
			data = JSON.parse(data);
			inventory.trunktype = data[0];
            inventory.trunktitle = data[1];
            for(var i = 0; i < data[2].length; i++)
            {
                if(i < count_max[2])
                {
					var newitem = {type: data[2][i][0], count: data[2][i][1], active: data[2][i][2], serial: data[2][i][3]};
					inventory.initTrunk[i] = newitem;
                    addItem(`trunk`, newitem);
                }
            }
		},
		
		ContextHandler: function(act, element) {

			if(JSON.stringify(inventory.initInvent) != JSON.stringify(inventory.invent))
			{
				inventory.initInvent = inventory.invent;
				mp.trigger("inventory", 7, JSON.stringify(inventory.invent));
			}

			//let type = (this.sType) ? 0 : this.trunktype;
			mp.trigger("inventoryContext", act, type, element);
		}
    }
});