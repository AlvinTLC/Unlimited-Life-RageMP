const localPlayer=mp.players.local,fishingPlaceListData=[
[new mp.Vector3(-3424.56,967.9,7.35),1,
[
[new mp.Vector3(-3428.34,953.6,7.35),89,1],
[new mp.Vector3(-3428.45,955.49,7.35),92,1],
[new mp.Vector3(-3428.37,957.53,7.35),92,1],
[new mp.Vector3(-3428.36,959.58,7.35),80,1],
[new mp.Vector3(-3428.45,961.59,7.35),90,1],
[new mp.Vector3(-3428.35,965.48,7.35),89,1],
[new mp.Vector3(-3428.36,967.55,7.35),76,1],
[new mp.Vector3(-3428.42,969.54,7.35),87,1],
[new mp.Vector3(-3428.41,971.55,7.35),88,1],
[new mp.Vector3(-3428.44,973.59,7.35),91,1],
[new mp.Vector3(-3428.42,975.62,7.35),88,1],
[new mp.Vector3(-3428.36,977.53,7.35),79,1]
]
],
[new mp.Vector3(-1842.13,-1247.84,7.62),1,
[
[new mp.Vector3(-1864.52,-1236.68,7.62),50,1],
[new mp.Vector3(-1860.59,-1232.18,7.62),50,1],
[new mp.Vector3(-1862.44,-1239.72,7.62),140,1],
[new mp.Vector3(-1860.15,-1241.96,7.62),140,1],
[new mp.Vector3(-1855.43,-1246.19,7.62),140,1],
[new mp.Vector3(-1852.33,-1248.79,7.62),140,1],
[new mp.Vector3(-1849.9,-1250.84,7.62),140,1],
[new mp.Vector3(-1843.89,-1255.9,7.62),140,1],
[new mp.Vector3(-1839.98,-1259.05,7.62),140,1],
[new mp.Vector3(-1837.24,-1261.47,7.62),140,1],
[new mp.Vector3(-1833.38,-1264.69,7.62),140,1],
[new mp.Vector3(-1828.14,-1269.05,7.62),140,1],
[new mp.Vector3(-1824.03,-1267.79,7.62),232,1]
]
],
[new mp.Vector3(2076.18,4313.41,29.98),2,
[
[new mp.Vector3(2076.18,4313.41,29.98),-1,100],
[new mp.Vector3(1902.2,4347.41,30.68),-1,100],
[new mp.Vector3(2190.01,4441.62,30.6),-1,100],
[new mp.Vector3(2129.56,4169.28,29.45),-1,100],
[new mp.Vector3(1600.58,4148.72,29.93),-1,100]
]
],
[new mp.Vector3(1289.12,4039.84,30.5),2,
[
[new mp.Vector3(1289.12,4039.84,30.5),-1,130],
[new mp.Vector3(1036.04,3882.41,30.36),-1,100],
[new mp.Vector3(802.26,3907.3,30.3),-1,100]
]
],
[new mp.Vector3(323.34,3950.38,29.46),2,
[
[new mp.Vector3(323.34,3950.38,29.46),-1,100],
[new mp.Vector3(630.1,3914.1,30.34),-1,100],
[new mp.Vector3(67.07,4075.46,30.82),-1,100],
[new mp.Vector3(2129.56,4169.28,29.45),-1,80],
[new mp.Vector3(1600.58,4148.72,29.93),-1,80]
]
],
[new mp.Vector3(1061.32,7206.05,.1),3,
[
[new mp.Vector3(1061.32,7206.05,.1),-1,350]
]
],
[new mp.Vector3(3504.78,2575.09,9.71),1,
[
[new mp.Vector3(3499.44,2531.15,5.31),152,2],
[new mp.Vector3(3476.81,2534.26,7.88),188,2],
[new mp.Vector3(3523.68,2525.44,5.16),166,2],
[new mp.Vector3(3530.43,2521.82,4.84),156,2],
[new mp.Vector3(3536.98,2515.16,4.55),151,2],
[new mp.Vector3(3544.02,2511.15,4.54),186,2],
[new mp.Vector3(3558.67,2516.21,5.08),237,2],
[new mp.Vector3(3567.62,2530.57,2.32),251,2],
[new mp.Vector3(3579.41,2552.64,2.43),250,2],
[new mp.Vector3(3572.91,2579.21,2.55),277,2],
[new mp.Vector3(3563.49,2593.26,7.21),296,2],
[new mp.Vector3(3555.89,2600.17,8.75),340,2],
[new mp.Vector3(3541.44,2599.1,5.3),353,2],
[new mp.Vector3(3528.85,2605.98,8.69),310,2],
[new mp.Vector3(3518.79,2618.06,10.03),327,2],
[new mp.Vector3(3502.51,2623.61,11.42),343,2],
[new mp.Vector3(3488.61,2616.98,11.27),14,2],
[new mp.Vector3(3462.39,2625.6,14.77),15,2],
[new mp.Vector3(3430.82,2610.64,8.78),43,2],
[new mp.Vector3(3420.59,2583.97,11.49),82,2]
]
],
[new mp.Vector3(3918.13,5295.08,.56),3,
[
[new mp.Vector3(3918.13,5295.08,.56),-1,350]
]
]
];
var fishTriggerCounter=0,
fishPlaceIndexList=new Set,
fishPlaceIndexCounter=0;
fishingPlaceListData.forEach(a=>{mp.blips.new(1,a[0],
{name:"\u0420\u044B\u0431\u0430\u043B\u043A\u0430",dimension:0,drawDistance:20,shortRange:!0,scale:.9,color:30});
const b=a[2];b.forEach(a=>{let b=fishPlaceIndexCounter;
new global.TriggerColshape(a[0],0,a[2],()=>{0==fishTriggerCounter&&global.rpc.triggerBrowser(global.mainBrowser,"__infoPanel_toggleStatusIco",["fishing",!0]),
fishTriggerCounter++,fishPlaceIndexList.add(b)},()=>{0<fishTriggerCounter&&(fishTriggerCounter--,fishPlaceIndexList.delete(b),0==fishTriggerCounter&&global.rpc.triggerBrowser(global.mainBrowser,"__infoPanel_toggleStatusIco",["fishing",!1]))}),fishPlaceIndexCounter++})}),mp.events.add("player_fishing",function(a,b){const c=mp.players.atRemoteId(a);null==c||0===c.handle||(1==b?(mp.attachmentMngr.addClient(c,mp.game.joaat("fishingRod1")),c.taskPlayAnim("amb@world_human_stand_fishing@base","base",1,0,-1,1,1,!1,!1,!1)):2==b?c.taskPlayAnim("amb@world_human_stand_fishing@idle_a","idle_b",1,0,-1,1,1,!1,!1,!1):3==b?(mp.attachmentMngr.removeFor(c,mp.game.joaat("fishingRod1")),c.clearTasksImmediately()):0==b&&mp.attachmentMngr.removeFor(c,mp.game.joaat("fishingRod1")))}),mp.events.add("player_fishing_taskStart",async function(a,b){return 0==fishPlaceIndexList.size?void global.rpc.trigger("clientFunc_notifyError","\u0422\u0443\u0442 \u043D\u0435\u043B\u044C\u0437\u044F \u0440\u044B\u0431\u0430\u0447\u0438\u0442\u044C"):localPlayer.isSwimming()||localPlayer.isSwimmingUnderWater()?void global.rpc.trigger("clientFunc_notifyError","\u041D\u0435\u043B\u044C\u0437\u044F \u0434\u0435\u043B\u0430\u0442\u044C \u044D\u0442\u043E \u0432 \u0432\u043E\u0434\u0435"):void(mp.game.water.setWavesIntensity(0),mp.events.callRemote("server_fishing_start",[...fishPlaceIndexList][fishPlaceIndexList.size-1],a,b))}),mp.events.add("player_fishing_startPlayerFishing",function(a,b){mp.game.water.setWavesIntensity(0),mp.events.call("player_fishing",localPlayer.remoteId,2),global.menuBrowser.execute(`startPlayerFishing(${a}, ${b});`)});var wormsPositionsShow=!1;const wormsPositions=[[new mp.Vector3(2140.5,5168.28,53.13),null],[new mp.Vector3(1870.08,4805.17,44.7),null],[new mp.Vector3(1920.77,4765.4,41.8),null]];mp.events.add("player_fishing_showWormsPositions",function(){wormsPositionsShow||(wormsPositionsShow=!0,wormsPositions.forEach(a=>{a[1]=mp.blips.new(1,a[0],{color:1,dimension:localPlayer.dimension,scale:1,name:"\u041C\u0435\u0441\u0442\u043E \u0434\u043B\u044F \u043A\u043E\u043F\u0430\u043D\u0438\u044F \u0447\u0435\u0440\u0432\u0435\u0439"})}),setTimeout(()=>{wormsPositions.forEach(a=>{mp.blips.exists(a[1])&&a[1].destroy()}),wormsPositionsShow=!1},120000),global.rpc.trigger("clientFunc_notifySuccess","\u0422\u043E\u0447\u043A\u0438 \u043E\u0442\u043C\u0435\u0447\u0435\u043D\u044B \u043D\u0430 2 \u043C\u0438\u043D\u0443\u0442\u044B"))}),mp.game.streaming.requestAnimDict("amb@world_human_stand_fishing@base"),mp.game.streaming.requestAnimDict("amb@world_human_stand_fishing@idle_a"),mp.attachmentMngr.register("shovel_worms","prop_tool_shovel2",28422,new mp.Vector3(.05,-.03,-.9),new mp.Vector3(2.1,-4.2,5)),mp.attachmentMngr.register("fishingRod1","prop_fishing_rod_02",60309,new mp.Vector3(.01,-.01,.03),new mp.Vector3(.1,0,0));