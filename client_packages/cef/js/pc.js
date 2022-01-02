let pc = {
    active : false,
    self : null,
    head : null,
    el : null,
    openCar : function(model, owner){
        this.reset()
        this.head.html('Zimmer Basis')
        this.el.append('<input type="text" maxlength="5" placeholder="Номер">')
        this.el.append('<div class="button">Пробить</div>')
        this.el.append('<p>МАРКА: <span></span></p><p>ВЛАДЕЛЕЦ: <span></span></p>')
        this.el.children('p:first').children().html(model)
        this.el.children('p:last').children().html(owner)
        this.set()
    },
    openWanted : function(data){
        this.reset()
        this.head.html('Jetzt suchen wir')
        this.el.append('<ol></ol>')
        var json = JSON.parse(data);
        json.forEach(function(item, i, arr) {
            pc.el.children('ol').append('<li>'+item+'</li>');
        });
    },
    openPerson : function(fname,lname,pass,gender,lvl,lic){
        this.reset()
        this.head.html("Datenbank")
        this.el.append('<input type="text" maxlength="30" placeholder="Reisepass/Name/Nachname">')
        this.el.append('<div class="button">Durchbrechen</div>')
        this.el.append('<p>Name: <span>'+fname+'</span></p>')
        this.el.append('<p>Nachname: <span>' + lname + '</span></p>')
        this.el.append('<p>Reisepass: <span>' + pass + '</span></p>')
        this.el.append('<p>Paul: <span>'+gender+'</span></p>')
        this.el.append('<p>Ur. Suche: <span>'+lvl+'</span></p>')
        this.el.append('<p>Liste der Lizenzen: <span>'+lic+'</span></p>')
        this.set()
    },
    clearWanted : function(){
        this.reset()
        this.head.html("Ungejagt.")
        this.el.append('<input type="text" maxlength="30" placeholder="Reisepass/Name/Nachname">')
        this.el.append('<div class="button">Lösch die Suche</div>')
        this.set()
    },
    set : function(){
        $('.button').on('click', function(){
            var t = $(this);
            //console.log(t);
            var data = $('input')[0].value;
            //console.log('pcMenuInput:'+data);
            mp.trigger('pcMenuInput', data);
        });
    },
    reset : function(){
        $('.button').off('click');
        $(".elements").empty();
    },
    show : function(){
        this.active = true
        this.self.css('display','block')
    },
    hide : function(){
        this.active = false
        this.self.css('display','none')
    }
}
$('.pc menu li').on('click', function(){
    var t = $(this)
    //console.log("pcMenu:"+t[0].id);
    mp.trigger('pcMenu', Number(t[0].id));
})
$('.pc span li').on('click', function(){
    var t = $(this)
    //console.log("pcMenu:"+t[0].id);
    mp.trigger('pcMenu', Number(t[0].id));
})
$('.pc a').on('click', function(){
    var t = $(this)
    //console.log("pcMenu:"+t[0].id);
    mp.trigger('pcMenu', Number(t[0].id));
})
$(document).ready(function(){
    pc.head = $('.pc .right h1')
    pc.el = $('.pc .right .elements')
    pc.self = $('.pc');
})