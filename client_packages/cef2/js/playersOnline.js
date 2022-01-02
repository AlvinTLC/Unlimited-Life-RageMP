$(document).ready(function () {
	window.playersOnlineAPI = new Vue({
		el: '.online-list-wrapper',
		data: {
			players: [],
			enable: false,
			online: 0
		},	
		methods: {
			show() {
				if (this.enable) {
					this.closeMenu();
				} else if (!consoleAPI.active() && clientStorage.admin) this.showMenu();	
			},
			addPlayer(data) {
				data = JSON.parse(data);
				this.players.push({ id: data.id, name: data.name, level: convertMinutesToLevelRest(data.score).level, ping: data.ping });
				this.online++;
			},
			deletePlayer(id) {
				for (let i = 0; i < this.players.length; i++) {
					if (this.players[i].id == id) {
						this.players.splice(i, 1);
						this.online--;
						return;
					}
				}
			},
			showMenu() {
				$(".online-list-wrapper").css("display", "flex");
				this.enable = true;
				setCursor(true);
			},
			closeMenu() {
				$(".online-list-wrapper").css("display", "none");
				this.enable = false;
				setCursor(false);
			}
		}
	});
});
