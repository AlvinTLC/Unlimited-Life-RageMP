let menu = {
    active: false,
    self: null,
    el: null,
    add: function(id, type, name, addit, key){
        var block = $('<div>');
        block.attr('id',id);
        block.attr('class', 'block');
        block.append('<img src="items/'+key+'.png" class="svgs" />');
        block.append('<div class="left">'+name+'</div>');
        if(addit !== undefined) block.append('<span>'+addit+'</span>');
        if(type == 0) block.append('<div class="right">Weiter</div>');
        else if(type == 1) block.append('<div class="right">Kaufen</div>');
		else if(type == 10) block.append('<div class="right">Verkaufen</div>'); /*Рыбалка*/
        else block.append('<div class="right">Nehmen</div>');
        block.children('.right').attr('onclick','menu.act(this)')
        this.el.append(block);
    },
    reset: function(){
        this.el.empty();
        this.self.children('.grids').children('.elements2').children('.market').html("");
        this.self.children('.grids').children('.elements').children('h1').html("");
        this.self.children('.grids').children('.elements2').children('.buttons').children('#btn1').css('display','none');
        this.self.children('.grids').children('.elements2').children('.buttons').children('#btn2').css('display','none');
        this.self.children('.grids').children('.elements2').children('.buttons').children('#btn3').css('display','none');
    },
    show: function(){
        this.active = true
        this.self.css('display','block')
    },
    hide: function(){
        this.active = false
        this.self.css('display','none')
        this.reset()
    },
    act: function(e){
        var btn = $(e);
        var btnid = btn.parent()[0].id;
        var menid = this.self[0].id;
        //console.log('menu:'+menid+':'+btnid);
        mp.trigger('menu',menid,btnid);
    }
}
$(document).ready(function(){
    menu.self = $('.menu')
    menu.el = $('.menu .grids .elements')
})
$('.menu #btn1').on('click', function(){
    var id = menu.self.attr('id');
    //console.log("menu:exit");
    mp.trigger('smExit');
});
$('.menu #btn2').on('click', function(){
    var id = menu.self.attr('id');
    //console.log("menu:exit");
    mp.trigger('menu','resign');
});
$('.menu #btn3').on('click', function(){
    var id = menu.self.attr('id');
    //console.log("menu:exit");
    mp.trigger('smExit');
});

function openWorks(level, currentjob) {

    jobselector.show(level, currentjob);
}

// Рыбалка //
function openFishShop(data){
    menu.reset();
    menu.self.attr('id', 'fishshop');
    menu.self.children('.grids').children('.elements').children('h1').html("Geschäft");
    var json = JSON.parse(data);
    json.forEach(function (item, i, arr) {
        // name, additional
        menu.add(i, 10,item[0],item[1],item[2]);
    });
    menu.self.children('.grids').children('.elements2').children('.buttons').children('#btn3').css('display','table-cell');
}
function openShop(data){
    menu.reset();
    menu.self.attr('id', 'shop');
    var json = JSON.parse(data);
    json.forEach(function (item, i, arr) {
        // name, additional
        menu.add(i, 1,item[0],item[1],item[2]);
    });
    menu.self.children('.grids').children('.elements2').children('.market').html('<img src="items/market24.svg" style="width:25vh;"/>');
    menu.self.children('.grids').children('.elements2').children('.buttons').children('#btn3').css('display','table-cell');
}
function openBlack(data){
    menu.reset();
    menu.self.attr('id', 'black');
    menu.self.children('.grids').children('.elements').children('h1').html("Schwarzmarkt");
    var json = JSON.parse(data);
    json.forEach(function (item, i, arr) {
        // name, additional
        menu.add(i, 1,item[0],item[1],item[2]);
    });
    menu.self.children('.grids').children('.elements2').children('.market').html('<img src="items/bmarket.svg" style="width:25vh;"/>');
    menu.self.children('.grids').children('.elements2').children('.buttons').children('#btn3').css('display','table-cell');
}
function openMech(data) {
    menu.reset();
    menu.self.attr('id', 'mech');
    menu.self.children('.grids').children('.elements').children('h1').html("Lager");
    var json = JSON.parse(data);
    json.forEach(function (item, i, arr) {
        // name, additional
        menu.add(i, 2, item);
    });
    menu.self.children('.grids').children('.elements2').children('.market').html('<img src="items/lager.svg" style="width:25vh;"/>');
    menu.self.children('.grids').children('.elements2').children('.buttons').children('#btn3').css('display','table-cell');
}
function openTuning(data) {
    menu.reset();
    menu.self.attr('id', 'tuning');
    menu.self.children('h1').html("Lager");
    var json = JSON.parse(data);
    json.forEach(function (item, i, arr) {
        // name, additional
        menu.add(i, 2, item);
    });
    menu.self.children('.grids').children('.elements2').children('.market').html('<img src="items/lager.svg" style="width:25vh;"/>');
    menu.self.children('.grids').children('.elements2').children('.buttons').children('#btn3').css('display','table-cell');
}
function openFib(data){
    menu.reset();
    menu.self.attr('id', 'fib');
    menu.self.children('.grids').children('.elements').children('h1').html("FIB Waffenkammer");
    var json = JSON.parse(data);
    json.forEach(function (item, i, arr) {
        // name, additional
        menu.add(i, 2, item);
    });
    menu.self.children('.grids').children('.elements2').children('.market').html('<img src="items/fib.svg" style="width:25vh;"/>');
    menu.self.children('.grids').children('.elements2').children('.buttons').children('#btn3').css('display','table-cell');
}
function openUSMS(data){
    menu.reset();
    menu.self.attr('id', 'USMS');
    menu.self.children('.grids').children('.elements').children('h1').html("USMS Waffenkammer");
    var json = JSON.parse(data);
    json.forEach(function (item, i, arr) {
        // name, additional
        menu.add(i, 2, item);
    });
    menu.self.children('.grids').children('.elements2').children('.market').html('<img src="items/usms.svg" style="width:25vh;"/>');
    menu.self.children('.grids').children('.elements2').children('.buttons').children('#btn3').css('display','table-cell');
}
function openLspd(data){
    menu.reset();
    menu.self.attr('id', 'lspd');
    menu.self.children('.grids').children('.elements').children('h1').html("LSPD Waffenkammer");
    var json = JSON.parse(data);
    json.forEach(function (item, i, arr) {
        // name, additional
        menu.add(i, 2, item);
    });
    menu.self.children('.grids').children('.elements2').children('.market').html('<img src="items/lspd.svg" style="width:25vh;"/>');
    menu.self.children('.grids').children('.elements2').children('.buttons').children('#btn3').css('display','table-cell');
}
function openArmy(data){
    menu.reset();
    menu.self.attr('id', 'army');
    menu.self.children('.grids').children('.elements').children('h1').html("ARMY Kammer");
    var json = JSON.parse(data);
    json.forEach(function (item, i, arr) {
        // name, additional
        menu.add(i, 2, item);
    });
    menu.self.children('.grids').children('.elements2').children('.buttons').children('#btn3').css('display','table-cell');
}
function openArmygun(data) {
    menu.reset();
    menu.self.attr('id', 'army');
    menu.self.children('.grids').children('.elements').children('h1').html("ARMY Waffenkammer");
    var json = JSON.parse(data);
    json.forEach(function (item, i, arr) {
        // name, additional
        menu.add(i, 2, item);
    });
    menu.self.children('.grids').children('.elements2').children('.market').html('<img src="items/armyhouse.svg" style="width:25vh;"/>');
    menu.self.children('.grids').children('.elements2').children('.buttons').children('#btn3').css('display', 'table-cell');
}
function openGov(data) {
    menu.reset();
    menu.self.attr('id', 'gov');
    menu.self.children('.grids').children('.elements').children('h1').html("GOV Waffenkammer");
    var json = JSON.parse(data);
    json.forEach(function (item, i, arr) {
        // name, additional
        menu.add(i, 2, item);
    });
    menu.self.children('.grids').children('.elements2').children('.market').html('<img src="items/cityhall.svg" style="width:25vh;"/>');
    menu.self.children('.grids').children('.elements2').children('.buttons').children('#btn3').css('display', 'table-cell');
}
function openArcars(data){
    menu.reset();
    menu.self.attr('id', 'arcars');
    menu.self.children('h1').html("Autovermietung");
    var json = JSON.parse(data);
    json.forEach(function (item, i, arr) {
        // name, additional
        menu.add(i, 2, item);
    });
    menu.self.children('.grids').children('.elements2').children('.buttons').children('#btn3').css('display', 'table-cell');
}
function openGang(data) {
    menu.reset();
    menu.self.attr('id', 'gang');
    menu.self.children('.grids').children('.elements').children('h1').html("Fahrzeuge");
    var json = JSON.parse(data);
    json.forEach(function (item, i, arr) {
        // name, additional
        menu.add(i, 2, item);
    });
    menu.self.children('.grids').children('.elements2').children('.market').html('<img src="items/robbertime.svg" style="width:25vh;"/>');
    menu.self.children('.grids').children('.elements2').children('.buttons').children('#btn3').css('display', 'table-cell');
}
function openMafia(data) {
    menu.reset();
    menu.self.attr('id', 'mafia');
    menu.self.children('.grids').children('.elements').children('h1').html("Transport");
    var json = JSON.parse(data);
    json.forEach(function (item, i, arr) {
        // name, additional
        menu.add(i, 2, item);
    });
    menu.self.children('.grids').children('.elements2').children('.market').html('<img src="items/crimemenu.svg" style="width:25vh;"/>');
    menu.self.children('.grids').children('.elements2').children('.buttons').children('#btn3').css('display', 'table-cell');
}