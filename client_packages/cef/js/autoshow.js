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
      models: ["Sultan","Kuruma","Tesla Model X","Tesla Model X","Tesla Model X","Tesla Model X","Tesla Model X","Tesla Model X","Tesla Model X"],
      modelsName: ["Sultan","Kuruma","Tesla Model X","Tesla Model X","Tesla Model X","Tesla Model X","Tesla Model X","Tesla Model X","Tesla Model X"],
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
    Sultan: {fuel: 10,  speedW: 60, fuelW: 10,  brakesW: 45, controlW: 100, accelerationlW: 20,},
    Kuruma: {fuel: 44,  speedW: 89, fuelW: 30,  brakesW: 65, controlW: 55,  accelerationlW: 20,},
    Surano: {fuel: 102, speedW: 15, fuelW: 50,  brakesW: 45, controlW: 43,  accelerationlW: 20,},
    Dubsta: {fuel: 126, speedW: 70, fuelW: 100, brakesW: 15, controlW: 73,  accelerationlW: 40,},
    Rocoto: {fuel: 16,  speedW: 50, fuelW: 7,   brakesW: 65, controlW: 73,  accelerationlW: 50,},
    urus:   {fuel: 66,  speedW: 40, fuelW: 10,  brakesW: 45, controlW: 43,  accelerationlW: 20,},
    volga:  {fuel: 66,  speedW: 40, fuelW: 10,  brakesW: 45, controlW: 43,  accelerationlW: 20,},
    w140:   {fuel: 66,  speedW: 40, fuelW: 10,  brakesW: 45, controlW: 43,  accelerationlW: 20,},
    w210:   {fuel: 66,  speedW: 40, fuelW: 10,  brakesW: 45, controlW: 43,  accelerationlW: 20,},
    wraith: {fuel: 66,  speedW: 40, fuelW: 10,  brakesW: 45, controlW: 43,  accelerationlW: 20,}
};
