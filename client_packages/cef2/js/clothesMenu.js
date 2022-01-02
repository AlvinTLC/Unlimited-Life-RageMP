// Переписать
$(document).ready(function () {
    window.clothesShop = new Vue({
        el: '.menu-wrapper',
        data: {
            config: undefined,
            menu: 0,
            loading: {
                names: {
                    2: "Головной убор",
                    3: "Верхняя одежда",
                    4: "Нижняя одежда",
                    6: "Штаны",
                    7: "Обувь"
                },
                hashes: {
                    2: "hats",
                },
                camera: {
                    2: "head",
                }
            },
            items: undefined,
            save: {
                cloth: 0,
                color: 0
            },
            price: 0
        },
        methods: {
            openMenu(type) {
                if (type === 1) {
                    $(".menu-wrapper").css("display", "flex");
                    $(".menu-wrapper #menuClothesMain").css("display", "flex");
                    setCursor(true);
                } else {
                    if (!this.config) return nError(`Конфиг не загружен, подождите!`);
                    $(".menu-wrapper #menuClothesMain").css("display", "none");
                    this.menu = type;
                    let item = this.config[this.loading.hashes[type]][clientStorage.sex];
                    this.price = item[0].price;
                    this.items = item;
                    this.loadChangeClothes();
                    mp.trigger("clothes_shop::resetView", this.loading.camera[type], true);
                    $(".menu-wrapper #menuClothes").css("display", "flex");
                }
            },
            buyClothes() { // hash type texture
                mp.trigger(`buy.shopclothes.item`, this.loading.hashes[this.menu], this.save.cloth, this.save.color);
            },
            loadChangeClothes() {
                mp.trigger(`change.clothesShop.items`, this.menu, this.items[this.save.cloth].drawable, this.items[this.save.cloth].textures[this.save.color]);
            },
            moveClothes(text) {
                let items = this.items;
                this.save.color = 0;
                if (text == "UP") {
                    if (this.save.cloth >= items.length - 1) return;
                    this.save.cloth++;
                    this.price = items[this.save.cloth].price;
                } else {
                    if (!this.save.cloth) return;
                    this.save.cloth--;
                    this.price = items[this.save.cloth].price;
                }
                this.loadChangeClothes();
            },
            moveColor(text) {
                let items = this.items[this.save.cloth].textures;
                if (text == "UP") {
                    if (this.save.color >= items.length - 1) return;
                    this.save.color++;
                } else {
                    if (!this.save.color) return;
                    this.save.color--;
                }
                this.loadChangeClothes();
            },
            loadConfig(data) {
                this.config = data;
            },
            closeMenu(type) {
                switch (type) {
                    case 1:
                        setCursor(false);
                        $(".menu-wrapper").css("display", "none");
                        $(".menu-wrapper #menuClothesMain").css("display", "none");
                        $(".menu-wrapper #menuClothes").css("display", "none");
                        break;
                    case 2:
                        $(".menu-wrapper #menuClothes").css("display", "none");
                        mp.trigger("clothes_shop::resetView", "full", true);
                        mp.trigger("close.clothesShop.items", this.menu);
                        $(".menu-wrapper #menuClothesMain").css("display", "flex");
                        break;
                    case 5:
                        mp.trigger(`events.callRemote`, `finish.clothes.shop`);
                        break;
                }
                this.save = { cloth: 0, color: 0 };
            },
        }
    });
});