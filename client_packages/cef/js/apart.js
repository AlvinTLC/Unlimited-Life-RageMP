var aparts = new Vue({
    el: ".main",
    data: {
        active: true,
		apartlist: [ ]
    },
    methods: {
		hide: function () {
			mp.trigger('client::closeapart');
        },
		hides: function () {
			this.active = false;
			this.apartlist = []; // optimize
        },
        show: function (data) {
			this.active = true;
			this.apartlist = data;
        },
		interact: function(index) {
			mp.trigger('client::sendapart', index);
		}
    }
})