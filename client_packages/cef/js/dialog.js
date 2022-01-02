var dialog = new Vue({
    el: '.dialog',
    data: {
        active: false,
        title: "Eine Schwuchtel hat dir den Kiefer gebrochen! Willst du ihn fertig machen? Oder sind Sie ein verdammter Patient? Verdammtes Arschloch, willst du, dass ich die Bullen rufe? Wenn Sie zustimmen, dann klicken Sie auf ja, wenn nein, dann nein.....",
    },
    methods: {
        yes: function () {
            mp.trigger('dialogCallback',true)
        },
        no: function () {
            mp.trigger('dialogCallback',false)
        }
    }
})