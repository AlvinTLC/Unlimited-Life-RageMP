$(document).ready(function () {
	window.autoCar = new Vue({
		el: '.car-showroom-wrapper',
		data: {
			complete: 0,
			vehicles: [],
			info: {
				bigLength: 0,
				smallLength: 0
			},
			vehInfo: {
				seats: [false, false, false, false],
				speed: [false, false, false, false, false],
				speedUp: [false, false, false, false, false],
				stop: [false, false, false, false, false],
				control: [false, false, false, false, false]
			},
			bars: []
		},	
		methods: {
			showMenu(vehicles) {
				mp.trigger('autoSaloon.setActive', true);
				mp.trigger('setBlockControl', true);
				for (let i = 0; i < vehicles.length; i++) {
					let v = vehicles[i];
					this.vehicles.push({ model: v.model, price: v.price, isActive: i == 0 ? true : false, isVisible: i < 5 ? true : false });
					this.bars.push(i == 0 ? true : false);
				}
				mp.trigger("autoSaloon.showCar", this.vehicles[0].model);
				this.info.bigLength = this.vehicles.length - 3;
				this.info.smallLength = this.vehicles.length - 2;
				$(".car-showroom-wrapper").css("display", "flex");
				lockOpen.lock(true, "autoCar");
				setCursor(true);
			},
			buyVehicle() {
				const obj = { model: this.vehicles[this.complete].model, id: this.complete};
				mp.trigger("events.callRemote", "autoSaloon.buyNewCar", JSON.stringify(obj));
				mp.trigger("events.callRemote", "autoSaloon.exit");
				mp.trigger("autoSaloon.deleteVehicle");
				mp.trigger("autoSaloon.setStatusMenu", false);
				mp.trigger("autoSaloon.destroyCam");
			},
			testDrive() {
				mp.trigger("events.callRemote", "autoSaloon.startTestDrive", this.vehicles[this.complete].model);
				mp.trigger("autoSaloon.destroyCam");
			},
			hideMenu(st) {
				if (st) {
					$(".car-showroom-wrapper").css("display", "flex");
					mp.trigger('autoSaloon.setActive', true);
					mp.trigger("autoSaloon.showCar", this.vehicles[this.complete].model);
					mp.trigger('setBlockControl', true);
					setCursor(true);
				} else {
					$(".car-showroom-wrapper").css("display", "none");
					mp.trigger('autoSaloon.setActive', false);
					mp.trigger('setBlockControl', false);
					setCursor(false);
				}
			},
			setVehInfo(data) {
				this.vehInfo = {
					seats: [false, false, false, false],
					speed: [false, false, false, false, false],
					speedUp: [false, false, false, false, false],
					stop: [false, false, false, false, false],
					control: [false, false, false, false, false]
				};
				this.counterInfo(0, data.maxPassagersCar);
				this.counterInfo(1, data.maxSpeedKm);
				this.counterInfo(2, data.acceleration);
				this.counterInfo(3, data.braking);
				this.counterInfo(4, data.controllability);
			},
			counterInfo(id, count) {
				let max;
				switch (id) {
					case 0:
						for (let i = 0; i < count; i++) {
							this.vehInfo.seats[i] = true;
							Vue.set(autoCar.vehInfo.seats, i, true);
							if (i > 2) return;
						}
						break;
					case 1:
						max = Math.round(5 - (250 / count));
						if (max < 1) max = 1;
						if (max > 4) max = 4;
						for (let i = 0; i < max; i++) {
							this.vehInfo.speed[i] = true;
							Vue.set(autoCar.vehInfo.speed, i, true);
						}
						break;
					case 2:
						max = Math.round(5 - (40 / count));
						if (max < 1) max = 1;
						if (max > 5) max = 4;
						for (let i = 0; i < max; i++) {
							this.vehInfo.speedUp[i] = true;
							Vue.set(autoCar.vehInfo.speedUp, i, true);
						}
						break;
					case 3:
						max = Math.round(5 - (120 / count));
						if (max < 1) max = 1;
						if (max > 5) max = 4;
						for (let i = 0; i < max; i++) {
							this.vehInfo.stop[i] = true;
							Vue.set(autoCar.vehInfo.stop, i, true);
						}
						break;
					case 4:
						max = Math.round(5 - (2.9 / count));
						if (max < 1) max = 1;
						if (max > 5) max = 4;
						for (let i = 0; i < max; i++) {
							this.vehInfo.control[i] = true;
							Vue.set(autoCar.vehInfo.control, i, true);
						}
						break;
				}
			},
			moveUp() {
				if (this.complete == this.vehicles.length - 1) return;
				this.vehicles[this.complete].isActive = false;
				if (this.complete > 1 && this.complete < this.info.bigLength) this.vehicles[this.complete - 2].isVisible = false;
				this.bars[this.complete] = false;
				this.complete++;
				this.bars[this.complete] = true;
				if (this.complete < this.info.smallLength) this.vehicles[this.complete + 2].isVisible = true;
				this.vehicles[this.complete].isActive = true;
				mp.trigger("autoSaloon.showCar", this.vehicles[this.complete].model);
			},
			moveDown() {
				if (this.complete == 0) return;
				this.vehicles[this.complete].isActive = false;
				if (this.complete > 2 && this.complete < this.info.smallLength) this.vehicles[this.complete + 2].isVisible = false;  // -
				this.bars[this.complete] = false;
				this.complete--;
				this.bars[this.complete] = true;
				if (this.complete > 1) this.vehicles[this.complete - 2].isVisible = true; // -
				this.vehicles[this.complete].isActive = true;	
				mp.trigger("autoSaloon.showCar", this.vehicles[this.complete].model);
			},
			closeMenu() {
				$(".car-showroom-wrapper").css("display", "none");
				mp.trigger('autoSaloon.setActive', false);
				mp.trigger('setBlockControl', false);
				mp.trigger("events.callRemote", "autoSaloon.exit");
				mp.trigger("autoSaloon.deleteVehicle");
				mp.trigger("autoSaloon.setStatusMenu", false);
				mp.trigger("autoSaloon.destroyCam");
				lockOpen.lock(false, "autoCar");
				setCursor(false);
				this.complete = 0;
				this.bars = [];
				this.vehicles = [];
			}
		}
	});
});
