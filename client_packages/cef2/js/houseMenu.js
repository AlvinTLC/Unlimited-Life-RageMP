$(document).ready(() => {
    var houseMenu = new Vue({
        el: "#houseMenu",
        data: {
            render: false,
            houseId: 2,
            houseOwner: "",
            houseAddress: "",
            houseLock: "",
            houseLockAction: "Открыт",
            lockIcon: "",
            housePrice: 1,
            houseRooms: 1,
			houseGarage: "",
            houseGaragePlace: "",
            houseStatus: "Свободен",
            houseClass: "",
			houseSquare: 13,
			houseOwnerOpen: false
        },
        methods: {
            active: function() {
                return $("#houseMenu").css("display") != "none";
            },
			showMenu: function (id, interior, owner, address, type, lock, rooms, garage, garagecount, price, rooms, square) {
				if (lockOpen.name.length > 0 && !lockOpen.name.includes("house")) return;
				if (lockOpen.name.includes("iPad") && lockOpen.status) return;
				if (window.consoleAPI.active() || window.modalAPI.active()) return;
                this.$data.houseId = id;
                this.$data.houseOwner = owner;
                this.$data.houseAddress = address + ", дом №" + id;
                this.$data.houseClass = globalConstants.houseClasses[type];

                /*if (interior === 1) {
                    this.$data.houseRooms = 2;
                    this.$data.houseSquare = 65;
                } else if (interior === 2) {
                    this.$data.houseRooms = 1;
                    this.$data.houseSquare = 35;
                } else if (interior === 3) {
                    this.$data.houseRooms = 3;
                    this.$data.houseSquare = 90;
                } else if (interior === 4) {
                    this.$data.houseRooms = 4;
                    this.$data.houseSquare = 160;
                }*/
                this.$data.houseRooms = rooms;
                this.$data.houseSquare = square;


				if (lock) this.$data.houseLockAction = "Закрыт";
				else this.$data.houseLockAction = "Открыт";

                if (owner.length > 3) this.$data.houseStatus = "Занят";
                else this.$data.houseStatus = "Свободен";

                this.$data.houseGarage = garage;

                if (garagecount) this.$data.houseGaragePlace = "1 место";
                else this.$data.houseGaragePlace = "Отсутствует";

				this.$data.housePrice = price;

				$(".house-control").hide();
				this.houseOwnerOpen = false;
				$("#houseMenu").show();
				$("#houseMenu .house .container").show();
				if (!owner) $("#house_buy").show();
				else $("#house_owner").show();
				lockOpen.lock(true, "house");
                mp.trigger(`setHouseMenuActive`, true);
			},
			reconOwnerMenu: function (lock) {
				if (!this.houseOwnerOpen) {
					this.showOwnerMenu(lock);
					lockOpen.lock(true, "house");
					setCursor(true);
				} else {
					this.hideOwnerMenu();
					lockOpen.lock(false, "house");
					setCursor(false);
				}
			},
			showOwnerMenu: function (lock) {
				if (lockOpen.name.length > 0 && !lockOpen.name.includes("house")) return;
				if (window.consoleAPI.active() || window.modalAPI.active()) return;
                if (lock) {
					this.$data.houseLockAction = "Закрыт";
                    // this.$data.lockIcon = "img/houseMenu/lock-lock.png";
                } else {
                    this.$data.houseLockAction = "Открыт";
                    // this.$data.lockIcon = "img/houseMenu/open-lock.png";
                }

				$("#house_buy").hide();
				$("#house_owner").hide();
				$("#houseMenu .house .container").hide();

                $("#houseMenu").show();
				$(".house-control").show();
				this.houseOwnerOpen = true;
				lockOpen.lock(true, "house");
                mp.trigger(`setHouseMenuActive`, true);
			},
			hideOwnerMenu: function () {
				$("#houseMenu").hide();
				$(".house-control").hide();
				this.houseOwnerOpen = false;
				lockOpen.lock(false, "house");
                mp.trigger(`setHouseMenuActive`, false);
            },
            lockUnlockHouse: function() {
                mp.trigger("lockUnlockHouse");
            },
            inspectHouse: function() {
                mp.trigger("inspectHouse");
            },
            enterHouse: function() {
                mp.trigger("enterHouse");
            },
			enterGarage: function () {
				return mp.trigger(`nError`, `Гараж временно недоступен!`);
                // mp.trigger("enterGarage");
            },
            sellHouseToGov: function() {
                mp.trigger("sellHouseToGov");
            },
            sellHouseToPlayer: function() {
                mp.trigger("sellHouseToPlayer");
            },
            showHousePlan: function() {
                $(".house-info").hide();
                $(".house-plan").show();
            },
            backToMenu: function() {
                $(".house-plan").hide();
                $(".house-info").show();
            },
            buyHouse: function() {
                mp.trigger("buyHouse");
            },
            invitePlayer: function() {
                mp.trigger("invitePlayer");
            },
            exitMenu: function() {
				$("#houseMenu").hide();
				$("#houseMenu .house .container").hide();
				$("#house_buy").hide();
				$("#house_owner").hide();
				$(".house-control").hide();
				this.houseOwnerOpen = false;
				lockOpen.lock(false, "house");
                mp.trigger("exitHouseMenu", false);
                mp.trigger(`setHouseMenuActive`, false);
            }
        }
    });
});
