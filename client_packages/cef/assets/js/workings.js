var JobStatsInfo = new Vue({
    el: ".JobStatsInfo",
    data: {
        active: false,
        money: "1",
    },
    methods: {
        set: function (money) {
            this.money = money;
        }
    }
});

var JobsEinfo = new Vue({
    el: ".JobsEinfo",
    data: {
        active: false,
    }
});

var Miner = new Vue({
    el: ".Miner",
    data: {
        active: false,
        header: "Каменщик",
        money: "1",
        money2: "2",
        money3: "3",
        jobid: 11,
        work: 0,
    },
    methods: {
        set: function (money, level, currentjob, work, money2, money3) {
            this.money = money;
            this.level = level;
            this.jobid = currentjob;
            this.work = work;
            this.money2 = money2;
            this.money3 = money3;
        },
        exit: function () {
            this.active = false;
            mp.trigger('CloseMiner');
        },
        setnewjob: function (jobsid) {
            this.jobid = jobsid;
        },
        enterJob: function (work) {
            mp.trigger("enterJobMiner", work);
        },
        selectJob: function (jobid) {
            mp.trigger("selectJobMiner", jobid);
        }
    }
});
