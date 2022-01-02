var menuJobs = new Vue({ //#1KR
  el: '#app',
  data: {
    active: false,
    header: "Bauernjob",
    onWork: false,
    level: 1,
    exp: 0,
    allpoints: 0,
    seedcount: 0,
    farmerscount: 0,
  },
  methods: {
    setinfo(json) {
      this.onWork = json[5]
      this.level = json[0] >= json[6] ? "Maximal" : json[0]
      this.exp = json[0] >= json[6] ? "Maximal" : 100 - json[1]
      this.allpoints = json[2]
      this.seedcount = json[3]
      this.farmerscount = json[4]
    },
    workState() {
      this.onWork = !this.onWork;
      mp.trigger("changeWorkState", this.onWork, "farmer")
      this.closeMenu()
    },
    closeMenu() {
      this.active = false
      mp.trigger("closeJobMenu")
    }
  }
})
