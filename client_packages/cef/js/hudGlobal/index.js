var HUD = new Vue({
    el: ".inGameHud",
    data: {
        show: false,
        id: 100,
        online: 0,
		bonusblock: true,
		lastbonus: null,

        // Player data
        ammo: 0,
        money: 0,
        bank: 0,
        mic: false,
        time: "00:00",
        date: "00.00.00",
        street: "",
        eat: 30,  //Еда
        water: 80,  //Вода
        crossingRoad: "",
        // Help
        isHelp: false,
        pressact: false, //Тут взаимодействие
        helpTitle: "",
        helpText: "",
        // 
        // Vehicle data
        inVeh: false,
		belt: false,
        engine: false,
        doors: false,
        speed: 0,
		rpm: 0,
		gear: 0,
        cruiseColor: '#ffffff', // cruise mode color ('#ffffff' = off, '#eebe00' = on)
        ifuel: 0, // Fuel Info (0 - Red, 1 - Yellow, 2 - Green)
        fuel: 0,
        hp: 0,
    },
    methods: {
        setTime: (time, date) => {
            this.time = time;
            this.date = date;
		},
			showbonus(){
			this.bonusblock = !this.bonusblock;
		},

    /*//Это типа для userID и вообще проверить, если ГАВНО, то удалить
        add: function (id) {
            this.userID.push([id]);
            this.online++;
        },
    //Конец userID*/
        showNotify(title,text,status = 0) {
            var st_name = !status ? "success" : "danger";
            $('.notifyList').append(`
            <div class="notify ${st_name}">
            <div class="icon"><img src="./images/hud/noty_${st_name}.png" alt=""></div>
            <div class="info">
                <div class="title">${title}</div>
                <div class="desc">${text}</div>
            </div>
            <img src="./images/hud/notyborder_${st_name}.png" alt="" class="border">
        </div>`);
				var notify = $(' .notifyList .notify:last');
				setInterval(function () {
					notify.removeClass('animate__fadeInUp');

					notify.addClass('animate__fadeOutUp');
					setInterval(function () {
						notify.remove();
					}, 600)

				}, 6000);
        },
        updateSpeed(currentspeed, maxspeed = 200) //240
        {
            this.speed = currentspeed;

            const meters = document.querySelectorAll('svg[data-value] .meter');

            meters.forEach( (path) => {
            
                let length = path.getTotalLength();
                
                let c = parseInt(path.parentNode.getAttribute('data-value'));
                
                let value = 0.4166666666666667 * c;
                let rotate = -130 + (value * 2.61153846153846);
                
                let to = length * ((100 - value) / 100);
                //alert(to);
                path.getBoundingClientRect();
                
                path.style.strokeDashoffset = Math.max(0, to);  
            });
        }
    }
});