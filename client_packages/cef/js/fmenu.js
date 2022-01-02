var fmenu = new Vue({
    el: ".fmenu",
    data: {
        active: false,
        submenu: false,
        members: [],
        menu: 0,
        input: "",
        rank: "",
        btntext: ["", "", "Einladen", "Rauswerfen", "Bearbeiten"],
        header: ["", "", "Zur Organisation zulassen", "Aus der Organisation Rauswerfen", "Rang ändern"],
        btnactive: [false, false, false, false, false],
        oncounter: 0,
        ofcounter: 0,
        counter: 0,
    },
    methods: {
        set: function (json, count, on, off) {
            this.members = JSON.parse(json);
            this.oncounter = on;
            this.ofcounter = off;
            this.counter = count;
        },
        btn: function (id, event) {
            //console.log(id)
            var ind = this.btnactive.indexOf(true);
            if (ind > -1) this.btnactive[ind] = false;
            if (id == 0) {
                this.reset();
                this.active = false;
                mp.trigger('closefm');
                return;
            } else {
                this.submenu = true;
                this.menu = id;
                this.btnactive[id] = true;
                //console.log(event.target.classList)
            }
        },
        submit: function () {
            //console.log('submit:' + this.menu + ':' + this.input + ':' + this.rank);
            mp.trigger("fmenu", this.menu, this.input, this.rank);
            this.active = false;
            this.reset();
        },
        reset: function () {
            this.btnactive = [false, false, false, false, false];
            this.submenu = false;
            this.members = [];
            this.input = "";
            this.rank = "";
            this.menu = 0;
        }
    }
})