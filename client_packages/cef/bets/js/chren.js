var chren = new Vue({
    el: "#chren",
    data: {
        show: false,
        minbet: 500,
        maxbet: 100000,
        bet: 100000,
		balance: 0,
    },
    methods : {
      toggle() {
        chren.show = !chren.show
      },
    }
});