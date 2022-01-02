var fractioncarspawner = new Vue({
  el: "#app",
  data: {
    active: false,
    vehicles: [],
    // [false, 10, "bla", "adwad"]
  },
  methods: {
    reset: function() {
      this.items = [];
      this.active = false;
    },
    closepanel: function() {
      this.reset();
      mp.trigger("closeFractionVehicleSpawner");
    },
    callback(type, vnumber) {
      mp.trigger("carspawner:trigger", vnumber, type);
      this.closepanel();
    }
  }
})
