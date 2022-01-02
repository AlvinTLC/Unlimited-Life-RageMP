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
                name: "Маска",
                type: ""
            },
            "-3":
			{
                name: "Перчатки",
                type: ""
            },
            "-4":
			{
                name: "Штаны",
                type: ""
            },
            "-5":
			{
                name: "Рюкзак",
                type: ""
            },
            "-6":
			{
                name: "Обувь",
                type: ""
            },
            "-7":
			{
                name: "Аксессуар",
                type: ""
            },
            "-8":
			{
                name: "Нижняя одежда",
                type: ""
            },
            "-9":
			{
                name: "Бронежилет",
                type: ""
            },
            "-10":
			{
                name: "Украшения",
                type: ""
            },
            "-11":
			{
                name: "Верхняя одежда",
                type: ""
            },
            "-12":
			{
                name: "Головной убор",
                type: ""
            },
            "-13":
			{
                name: "Очки",
                type: ""
            },
            "-14":
			{
                name: "Аксессуар",
                type: ""
            },
            0:
			{
                name: "Test Item",
                type: ""
            },
            1:
			{
                name: "Аптечка",
                type: ""
            },
            2:
			{
                name: "Канистра",
                type: ""
            },
            3:
			{
                name: "Чипсы",
                type: ""
            },
            4:
			{
                name: "Пиво",
                type: ""
            },
            5:
			{
                name: "Пицца",
                type: ""
            },
            6:
			{
                name: "Бургер",
                type: ""
            },
            7:
			{
				name: "Хот-Дог",
            	type: ""
			},
			8:
			{
				name: "Сэндвич",
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
				name: "Отмычка для замков",
            	type: ""
			},
			12:
			{
				name: "Сумка с деньгами",
            	type: ""
			},
			13:
			{
				name: "Материалы",
            	type: ""
			},
			14:
			{
				name: "Наркотики",
            	type: ""
			},
			15:
			{
				name: "Сумка с дрелью",
            	type: ""
			},
			16:
			{
				name: "Военная отмычка",
            	type: ""
			},
			17:
			{
				name: "Мешок",
            	type: ""
			},
			18:
			{
				name: "Стяжки",
            	type: ""
			},
			19:
			{
				name: "Ключи от машины",
            	type: ""
			},
			40:
			{
				name: "Подарок",
            	type: ""
			},
			41:
			{
				name: "Связка ключей",
                type: ""
            },
            20: 
            {
                name: "\"На корке лимона\"",
            	type: ""
			},
			21:
            {
                name: "\"На бруснике\"",
            	type: ""
			},
			22:
            {
                name: "\"Русский стандарт\"",
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
                name: "\"Дживан\"",
            	type: ""
			},
			30:
            {
                name: "\"Арарат\"",
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
				name: "Нож",
            	type: ""
			},
			181:
			{
				name: "Дубинка",
            	type: ""
			},
			182:
			{
				name: "Молоток",
            	type: ""
			},
			183:
			{
				name: "Бита",
            	type: ""
			},
			184:
			{
				name: "Лом",
            	type: ""
			},
			185:
			{
				name: "Гольф клюшка",
            	type: ""
			},
			186:
			{
				name: "Бутылка",
            	type: ""
			},
			187:
			{
				name: "Кинжал",
            	type: ""
			},
			188:
			{
				name: "Топор",
            	type: ""
			},
			189:
			{
				name: "Кастет",
            	type: ""
			},
			190:
			{
				name: "Мачете",
            	type: ""
			},
			191:
			{
				name: "Фонарик",
            	type: ""
			},
			192:
			{
				name: "Швейцарский нож",
            	type: ""
			},
			193:
			{
				name: "Кий",
            	type: ""
			},
			194:
			{
				name: "Ключ",
            	type: ""
			},
			195:
			{
				name: "Боевой топор",
                type: ""
            },
            200:
			{
				name: "Пистолетный калибр",
            	type: ""
			},
			201:
			{
				name: "Малый калибр",
            	type: ""
			},
			202:
			{
				name: "Автоматный калибр",
            	type: ""
			},
			203:
			{
				name: "Снайперский калибр",
            	type: ""
			},
			204:
			{
                name: "Дробь",
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