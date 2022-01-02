const vehicleNames = require('./configs/autoshow.js')
var cam = mp.cameras.new('default', new mp.Vector3(0, 0, 0), new mp.Vector3(0, 0, 0), false);
autoshop = mp.browsers.new('package://cef/autoshow.html');
let autoColors = ["Черный", "Белый", "Красный", "Оранжевый", "Желтый", "Зеленый", "Голубой", "Синий", "Фиолетовый", ];
let autoModels = null;
let colors = {};
colors["Черный"] = [0, 0, 0];
colors["Белый"] = [225, 225, 225];
colors["Красный"] = [230, 0, 0];
colors["Оранжевый"] = [255, 115, 0];
colors["Желтый"] = [240, 240, 0];
colors["Зеленый"] = [0, 230, 0];
colors["Голубой"] = [0, 205, 255];
colors["Синий"] = [0, 0, 230];
colors["Фиолетовый"] = [190, 60, 165];
let auto = {
  model: null,
  color: null,
  entity: null,
};
function setVehInfo(e) {
  let t = 3.6 * mp.game.vehicle.getVehicleModelMaxSpeed(e.model),
    l = mp.game.vehicle.getVehicleModelAcceleration(e.model),
    o = e.getMaxNumberOfPassengers() + 1;
  autoshop.execute("auto.speed=" + t.toFixed(0)), global.menu.execute("auto.acceleration=" + l.toFixed(2))
}
const vehheading = require("./plugins/rotator.js");
mp.events.add('auto', (act, value) => {
  try {
    switch (act) {
      case "model":
        setTimeout(function() {
          auto.model = autoModels[value];
          auto.entity.model = mp.game.joaat(autoModels[value]);
          auto.entity.setCustomPrimaryColour(colors[auto.color][0], colors[auto.color][1], colors[auto.color][2]); // Цвет первый
          auto.entity.setCustomSecondaryColour(colors[auto.color][0], colors[auto.color][1], colors[auto.color][2]) // Цвет второй
          auto.entity.setRotation(-0.09107242, 0.0001472793, 57.51881, 2, true);
          // mp.events.callRemote('createveh', auto.model, colors[auto.color][0], colors[auto.color][1], colors[auto.color][2]); // RAGEMP 0.3.7
          auto.entity.setDirtLevel(0);
          setVehInfo(auto.entity);
        }, 0);
        break;
      case "color":
        auto.color = autoColors[value];
        auto.entity.setCustomPrimaryColour(colors[autoColors[value]][0], colors[autoColors[value]][1], colors[autoColors[value]][2]); // Цвет первый
        auto.entity.setCustomSecondaryColour(colors[autoColors[value]][0], colors[autoColors[value]][1], colors[autoColors[value]][2]) // Цвет второй
        // mp.events.callRemote('vehchangecolor', colors[auto.color][0], colors[auto.color][1], colors[auto.color][2]); // RAGEMP 0.3.7
        break;
    }
  } catch {};
});
mp.events.add("buyAuto", () => {
  if (new Date().getTime() - global.lastCheck < 50) return;
  global.lastCheck = new Date().getTime();
  menuClose();
  autoshop.execute("auto.active=0");
  mp.events.callRemote("carroomBuy", auto.model, auto.color);
  vehheading.stop();
  if (auto.entity == null) return;
  auto.entity.destroy();
  auto.entity = null;
});
// mp.events.add("rotateAuto", (angle) => {
//  auto.entity.setRotation(-0.09107242, 0.0001472793, angle, 1, true);
// });
mp.events.add("closeAuto", () => {
    if (new Date().getTime() - global.lastCheck < 50) return;
    global.lastCheck = new Date().getTime();
    menuClose();
    autoshop.execute("auto.active=0");
    mp.events.callRemote("carroomCancel");
    vehheading.stop();
    if (auto.entity == null) return;
    auto.entity.destroy();
    auto.entity = null;
  });
  mp.events.add('openAuto', (models, prices, bizInfo) => {
    if (global.menuCheck()) return;
    autoModels = JSON.parse(models);
    let autoNames = [];
    autoModels.forEach(model => {
      autoNames.push(vehicleNames.get(model) || "ModelName")
    });
    mp.events.callRemote('createveh', autoModels[0], 0, 0, 0);
    setAuto('models', models);
    setAuto('modelsName', JSON.stringify(autoNames));
    setAuto('colors', JSON.stringify(autoColors));
    setAuto('prices', prices);
    if (autoModels[0] === 'e60') global.menu.execute(`auto.cur='RF'`);
    // Создание авто в автосалоне
    auto.entity = mp.vehicles.new(mp.game.joaat(autoModels[0]), new mp.Vector3(-783.4909, -223.72554, 37.397556), {
      heading: -0.1569975,
      numberPlate: 'Ulife',
      alpha: 255,
      color: [[0, 0, 0],[0, 0, 0]],
      locked: false,
      engine: false,
      dimension: localplayer.dimension
    });
    auto.entity.setRotation(-0.5099085, -0.1569975, 20.68906, 2, true);
    setVehInfo(auto.entity),
    setTimeout(() => {
      if (auto.entity != null);
    }, 1000);
    auto.color = "Черный";
    auto.model = autoModels[0];
    vehheading.startveh(auto.entity);
    // Доделать грязное авто при первом входе
    auto.entity.setDirtLevel(0);
    global.menuOpen();
    autoshop.execute(`auto.active=true`);
    if (bizInfo != "owner") {
      autoshop.execute(`auto.bizInfoActive=true`);
      autoshop.execute(`auto.bizSellPrice=` + bizInfo);
    }
  });
function setAuto(type, jsonstr) {
  autoshop.execute(`auto.${type}=${jsonstr}`);
}
/*mp.events.add('testdriveAuto', (value) => {
    if(new Date().getTime() - global.lastCheck < 50) return; 
    global.lastCheck = new Date().getTime();
    global.menuClose();
    autoshop.execute('auto.active=0');
    mp.events.callRemote('carroomTestDrive', auto.model, colors[autoColors[value]][0], colors[autoColors[value]][1], colors[autoColors[value]][2]);
    if (auto.entity == null) return;
    auto.entity.destroy();
    // vehheading.stop();
    auto.entity = null;
})*/
mp.events.add('freeze', function(toggle) {
    localplayer.freezePosition(toggle);
  });
  mp.events.add('destroyCamera', function() {
    //cam.destroy();
    disableCamera()
    //mp.game.cam.renderScriptCams(false, false, 3000, true, true);
  });
  
  function disableCamera() {
	mp.game.cam.renderScriptCams(false, false, 0, false, false);
  }
  mp.events.add('carRoom', function() {
    cam = mp.cameras.new('default', new mp.Vector3(-788.5106, -228.77806, 37.22066), new mp.Vector3(0, 0, -45.13147), 40);
    cam.pointAtCoord(-788.5106, -228.77806, 37.22066);
    cam.setActive(true);
    mp.game.cam.renderScriptCams(true, false, 0, true, false);
  });
  mp.events.add('screenFadeOut', function(duration) {
    mp.game.cam.doScreenFadeOut(duration);
  });
  mp.events.add('screenFadeIn', function(duration) {
    mp.game.cam.doScreenFadeIn(duration);
  });
