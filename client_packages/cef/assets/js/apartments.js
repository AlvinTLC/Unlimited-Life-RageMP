var aparts = new Vue({
    el: ".iTeffa",
    data: {
        active: false,
		apartlist: [ ]
    },
    methods: {
		hide: function () {
			mp.trigger('client::closeapart');
        },
		hides: function () {
			this.active = false;
			this.apartlist = [];
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