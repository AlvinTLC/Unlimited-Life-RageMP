/*Меню покупки в дом с улицы*/
var HouseMenuBuy = new Vue({
    el: ".HouseMenuBuy",
    data: {
        active: false,
        header: "Informationen",
        id: 0,
        owner: "Zustand",
        type: 0,
        locked: false,
        price: 0,
        garage: 0,
        roommates: 0,
    },
    methods: {
        set: function (id, Owner, Type, Locked, Price, Garage, Roommates) {
            this.id = id;
            this.owner = Owner;
            this.type = Type;
            this.locked = Locked;
            this.price = Price;
            this.garage = Garage;
            this.roommates = Roommates;
        },
        exit: function () {
            this.active = false;
            mp.trigger('CloseHouseMenuBuy');
        },
        buy: function (id) {
            mp.trigger("buyHouseMenu", id);
        }

    }
});

/*Меню входа в дом с улицы*/
var HouseMenu = new Vue({
    el: ".HouseMenu",
    data: {
        active: false,
        header: "Informationen",
        id: 0,
        owner: "Spieler",
        type: 0,
        locked: false,
        price: 0,
        garage: 0,
        roommates: 0,
    },
    methods: {
        set: function (id, Owner, Type, Locked, Price, Garage, Roommates) {
            this.id = id;
            this.owner = Owner;
            this.type = Type;
            this.locked = Locked;
            this.price = Price;
            this.garage = Garage;
            this.roommates = Roommates;
        },
        exit: function () {
            this.active = false;
            mp.trigger('CloseHouseMenu');
        },
        select: function (id) {
            mp.trigger("selectSchool", id);
        },
        enter: function (id) {
            mp.trigger("GoHouseMenu", id);
        }

    }
});
/*меню Выход-Гараж-Закрыть*/
var ExitHouseMenu = new Vue({
    el: ".ExitHouseMenu",
    data: {
        active: false,
        header: "Beenden",
    },
    methods: {
        exit: function () {
            mp.trigger('exitHouse'); //Кнопка Выход из дома
        },
        close: function () { //Кнопка "Закрыть" когда внутри дома
            this.active = false;
            mp.trigger('CloseExitHouseMenu');
        },
		garageEnter: function(){
            mp.trigger("garageHouse", 1);
        }
    }
});
/*Меню дома с улицы*/
var MyyHouseMenu = new Vue({
    el: ".MyyHouseMenu",
    data: {
        active: false,
        header: "Gebäudemanagement",
        id: 0,
        owner: "Spieler",
        type: 0,
        price: 0,
        garage: 0,

        roommates: 0,
        infoM: 1,
        carM: 0,
        furnitureM: 0,
        roommatesM: 0,
    },
    methods: {
        info: function (id, Owner, Type, Price, Garage, Roommates) {
            this.id = id;
            this.owner = Owner;
            this.type = Type;
            this.price = Price;
            this.garage = Garage;
            this.roommates = Roommates;
        },
        exit: function () {
            this.active = false;
            mp.trigger('CloseMyyHouseMenu');
        },
        infoMm: function (id) {
            this.infoM = id;
            this.carM = 0;
            this.furnitureM = 0;
            this.roommatesM = 0;
        },
        carMm: function (id) {
            this.infoM = 0;
            this.carM = id;
            this.furnitureM = 0;
            this.roommatesM = 0;
        },
        furnitureMm: function (id) {
            this.infoM = 0;
            this.carM = 0;
            this.furnitureM = id;
            this.roommatesM = 0;
        },
        roommatesMm: function (id) {
            this.infoM = 0;
            this.carM = 0;
            this.furnitureM = 0;
            this.roommatesM = id;
        }

    }
});