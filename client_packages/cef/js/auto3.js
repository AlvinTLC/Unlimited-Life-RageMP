var auto = new Vue({
    el: ".auto",
    data: {
        active: false,
        indexM: 0,
        indexC: 0,
        models: ["Tesla","Tesla X","Tesla Model","BMW M4 SW SW SW SW SW","AMG G65","Lada Granta","Chevrolet Camaro","Ford Focus"],
        modelsName: [],
        colors: [],
        prices: ["1.999.999.999", "1.233.222", "3.212.223", "5.000.000", "6.500.000", "450.000", "3.250.000", "1.120.000",],
        header: "Vorrätig:",
        getName: function (modelName) {
            return globalModelsDetails[modelName] && globalModelsDetails[modelName].name || modelName;
        },
        getSpeed: function (modelName) {
            return globalModelsDetails[modelName] && globalModelsDetails[modelName].speed || "0";
        },
        getFuel: function (modelName) {
            return globalModelsDetails[modelName] && globalModelsDetails[modelName].fuel || "0";
        },
        getDriveForce: function (modelName) {
            return globalModelsDetails[modelName] && globalModelsDetails[modelName].DriveForce || "0";
        },
        getBrakeForce: function (modelName) {
            return globalModelsDetails[modelName] && globalModelsDetails[modelName].BrakeForce || "0";
        },
        getLossMult: function (modelName) {
            return globalModelsDetails[modelName] && globalModelsDetails[modelName].LossMult || "0";
        },
    },
    methods: {
        auto: function (index) {
            this.indexM = index
            mp.trigger('auto','model', index)
        },
        color: function (colorIndex) {
            this.indexC = colorIndex;
            mp.trigger('auto', 'color', colorIndex);
        },
        buy: function(){
            //console.log('buy')
            mp.trigger('buyAuto')
        },
        testdrive: function() {
          mp.trigger('testdrive')
        },
        exit: function(){
            //console.log('exit')
            this.reset()
            mp.trigger('closeAuto')
        },
        reset: function(){
            this.price=-1
            this.indexM=0
            this.indexC=0
            this.models=[]
            this.colors=[]
            this.prices = []
        }
    }
})