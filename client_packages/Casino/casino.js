let casino = null;
let casinoBrowser = null;
let money = 0;

let delay = null;

function openCasino(casinoInstance, cash) {
	
	money = cash;
	mp.game.graphics.notify('open balance ' + money);
	casino = JSON.parse(casinoInstance);
	
	let path = "package://Casino/CEF/casino/slot/slot-diamond.html";
	switch(casino.type) {
		case "slot1": path = "package://Casino/CEF/casino/slot1/slot-greenliner.html"; break;
		case "slot2": path = "package://Casino/CEF/casino/slot2/slot-pinkpanther.html"; break;
	}
	
	casinoBrowser = mp.browsers.new(path);
	mp.gui.cursor.show(true, true);
	
	casinoBrowser.execute(`limits.maximumBet = ${casino.maxBet};`);
	casinoBrowser.execute(`limits.minimumBet = ${casino.minBet};`);
	casinoBrowser.execute(`limits.currentBet = ${casino.minBet};`);
	casinoBrowser.execute(`document.getElementById("aStatus").innerHTML = "${casino.minBet}";`);
	
}

function playCasino(currentBet) {
	
		if(delay !== null) {
			mp.game.graphics.notify(`Warte bis der Spin beendet ist!`);
			return;		
		}
		if(currentBet > money){
			mp.game.graphics.notify(`Du hast nicht genug Geld.`);
			return;
		}
		
		let winnings = 0;
		
		money -= currentBet;
		mp.events.callRemote("casinotake", currentBet);
		
		var results = [(Math.floor(Math.random() * Math.floor(8))),(Math.floor(Math.random() * Math.floor(8))),(Math.floor(Math.random() * Math.floor(8))),currentBet];
		if(results[0] == 0 && results[1] == 0 && results[2] == 0){
			results[3]*=3;
		} else if(results[1] == 0 && results[2] == 0){
			results[3]*=2;		
		} else if(results[1] == 0){
			results[3]*=1;
		} else if(results[0] == 6 && results[1] == 6 && results[2] == 6){
			results[3]*=10;
		} else if(results[0] == 5 && results[1] == 5 && results[2] == 5){
			results[3]*=15;				
		} else if(results[0] == 4 && results[1] == 4 && results[2] == 4){
			results[3]*=20;					
		} else if(results[0] == 3 && results[1] == 3 && results[2] == 3){
			results[3]*=30		
		} else if(results[0] == 2 && results[1] == 2 && results[2] == 2){
			results[3]*=40;			
		} else if(results[0] == 1 && results[1] == 1 && results[2] == 1){
			results[3]*=50;
		} else{
			results[3]=0;
		}

		winnings = Math.round(results[3]);
		money += winnings;
		
		casinoBrowser.execute(`result('${JSON.stringify(results)}')`);
			
		delay = setTimeout(() => {
			delay = null;

			mp.events.callRemote("casinowin", winnings);
		}, 5000);
		
}

function closeCasino() {
	if (casinoBrowser != null) {
		casinoBrowser.destroy();
		casinoBrowser = null;
		mp.gui.cursor.show(false, false);
		
		money = 0;
		casino = null;
	}
}

mp.events.add({
	
	"casino.open": openCasino,
	"slotmachineStart": playCasino,
	"closeAutomat": closeCasino
	
});

mp.keys.bind(0x59, true, function() {
	if (!loggedin || chatActive || editing || cuffed || localplayer.getVariable('InDeath') == true || localplayer.vehicle != null) return;
	mp.events.callRemote("getmoney");	
});

mp.events.add("getmoneyinfo", (babki) => {
	mp.game.graphics.notify('balance ' + babki);
	mp.events.callRemote("PushE", babki); 
});