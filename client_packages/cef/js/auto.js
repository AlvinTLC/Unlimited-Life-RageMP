/* ************************  Vehicle iTeffa Vue Settings ************************ */
var auto = new Vue({
  el: ".auto_new",
  data: {
      active: false,
      bizInfoActive: false,
      bizSellPrice: 1,
      indexM: 0,
      indexC: 0,
  car: 0,
      models: ["Tesla Model S","Tesla Model 3","Tesla Model X","Tesla Model X","Tesla Model X","Tesla Model X","Tesla Model X","Tesla Model X","Tesla Model X"],
      modelsName: ["Tesla Model S","Tesla Model 3","Tesla Model X","Tesla Model X","Tesla Model X","Tesla Model X","Tesla Model X","Tesla Model X","Tesla Model X"],
      colors: ["Черный", "Белый", "Красный", "Оранжевый", "Желтый", "Зеленый", "Голубой", "Синий", "Фиолетовый"],
      prices: [15000000,900000,10000,8000000,5000000,845625478,87457895478,4411256,44578569],
  getFuel: function(modelName) {return stats[modelName] && stats[modelName].fuel || "";},
  SpeedW: function(modelName) {return stats[modelName] && stats[modelName].speedW || "";},
  FuelW: function(modelName) {return stats[modelName] && stats[modelName].fuelW || "";},
  BrakesW: function(modelName) {return stats[modelName] && stats[modelName].brakesW || "";},
  ControlW: function(modelName) {return stats[modelName] && stats[modelName].controlW || "";},
  AccelerationW: function(modelName) {return stats[modelName] && stats[modelName].accelerationlW || "";}
  },
  computed: {
      bizIncome: function() {
          return this.bizSellPrice*0.04;
      }
  },
 methods: {
      model: function(modelIndex){
          this.indexM = modelIndex;
          mp.trigger('auto','model',modelIndex);
      },
      cars: function(id){
          this.car = id;
      },
      color: function(colorIndex){
          this.indexC = colorIndex;
          mp.trigger('auto','color',colorIndex);
      },   
      auto: function (index) {
          this.indexM = index
          mp.trigger('auto','model', index, Number(this.rotationAuto))
      },
      buyBiz: function () {
          mp.trigger('buyBizCommand');
      },
  
  testdrive: function() { 
  console.log('testdriveAuto');
  mp.trigger('testdriveAuto', this.indexM, this.indexC);
  },

      buy: function(){
          mp.trigger('buyAuto')
          this.car=0
      },
      exit: function(){
          this.reset()
          mp.trigger('closeAuto')
      },  
  rotate: function() {
          mp.trigger('rotateAuto', Number(this.rotationAuto))
      },
      rotate: function() {
          mp.trigger('rotateAuto', Number(this.rotationAuto))
      },
      reset: function(){
          this.price=-1
          this.indexM=0
          this.indexC=0
          this.car=0
          this.models=[]
          this.colors=[]
          this.prices=[]
      }
  }
})

/* ************************  Vehicle iTeffa  ************************ */
var stats = {
        Faggio2: {
        fuel: 10,
        speedW: 50,
    fuelW: 10,
        brakesW: 45,
        controlW: 100,
    accelerationlW: 20,
    },
    Sanchez2: {
        fuel: 44,
        speedW: 70,
    fuelW: 30,
        brakesW: 65,
        controlW: 55,
    accelerationlW: 20,
    },
    Enduro: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 20,
    },
  
    PCJ: {
        fuel: 126,
        speedW: 70,
    fuelW: 100,
        brakesW: 15,
        controlW: 73,
    accelerationlW: 40,
    },
    Hexer: {
        fuel: 16,
        speedW: 50,
    fuelW: 7,
        brakesW: 65,
        controlW: 73,
    accelerationlW: 50,
    },
    Lectro: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 20,
    },
    Nemesis: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 20,
    },
    Hakuchou: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 20,
    },
    Ruffian: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 20,
    },
    Bmx: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 20,
    },
    Scorcher: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 20,
    },
    BF400: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 20,
    },
    CarbonRS: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 20,
    },
    Bati: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 20,
    },
    Double: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 20,
    },
    Diablous: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 20,
    },
    Cliffhanger: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 20,
    },
    Akuma: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 20,
    },
    Thrust: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 20,
    },
    Nightblade: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 20,
    },
    Vindicator: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 20,
    },
    Ratbike: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 20,
    },
    Blazer: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 20,
    },
    Gargoyle: {
        fuel: 86,
        speedW: 40,
    fuelW: 60,
        brakesW: 55,
        controlW: 23,
    accelerationlW: 20,
    },
    Sanctus: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 60,
    },
  
    Sultan: {
        fuel: 120,
        speedW: 20,
    fuelW: 100,
        brakesW: 15,
        controlW: 13,
    accelerationlW: 20,
    },
    SultanRS: {
        fuel: 120,
        speedW: 40,
    fuelW: 100,
        brakesW: 25,
        controlW: 23,
    accelerationlW: 30,
    },
    Kuruma: {
        fuel: 120,
        speedW: 10,
    fuelW: 100,
        brakesW: 35,
        controlW: 43,
    accelerationlW: 10,
    },
    Fugitive: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 60,
    },
    Tailgater: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 60,
    },
    Sentinel: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 60,
    },
    F620: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 60,
    },
    Schwarzer: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 60,
    },
    Exemplar: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 60,
    },
    Felon: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 60,
    },
    Schafter2: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 60,
    },
    Jackal: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 60,
    },
    Oracle2: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 60,
    },
    Surano: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 60,
    },
    Zion: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 60,
    },
    Dominator: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 60,
    },
    FQ2: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 60,
    },
    Gresley: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 60,
    },
    Serrano: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 60,
    },
    Dubsta: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 60,
    },
    Rocoto: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 60,
    },
    Cavalcade2: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 60,
    },
    XLS: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 60,
    },
    Baller2: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 60,
    },
    Elegy: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 60,
    },
    Banshee: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 60,
    },
    Massacro2: {
        fuel: 66,
        speedW: 40,
    fuelW: 10,
        brakesW: 45,
        controlW: 43,
    accelerationlW: 60,
    }
};
