var HUD = new Vue({
    el: ".inGameHud",
    data: {
        show: false,

        // Player data
        ammo: 0,
        money: 0,
        bank: 0,
        mic: false,
        time: "00:00",
        date: "00.00.00",
        wanted: 0,
        online: 0,
        userID: 0,
        street: "",
        hunger: 90,
        satiety: 40,
        crossingRoad: "",
        // Help
        isHelp: false,
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
        updateSpeed: function () {
            const meters = document.querySelectorAll('svg .meter');

            meters.forEach((path) => {

                let length = path.getTotalLength();


                // Get the value of the meter


                let value = 0.2496666666666667 * this.speed;
                // let rotate = value;

                let to = length * ((102 - value) / 100);
                console.log(to);
                path.getBoundingClientRect();

                path.style.strokeDashoffset = Math.max(0, to);
            });
        },
        updateFuel: function () {
            const fuels = document.querySelectorAll('svg .fuel');

            fuels.forEach((path) => {


                // let c = this.speedCount;

                let value = 1 * this.fuel;
                // let rotate = value;

                let to = length * ((309 - value) / 100);
                // console.log(to);
                path.getBoundingClientRect();

                path.style.strokeDashoffset = Math.max(0, to);

            });
        }
    }
});

var logotype = new Vue({
    el: ".logobox",
    data: {
        show: false,
        userID: 0,
        online: 0,
    }
});