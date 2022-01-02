$(document).ready(function () {
	window.iPad = new Vue({
		el: '.ipad-wrapper',
		data: {
			update: undefined,
			time: ``,
			appMenu: undefined,
			spawn: 0,
			house: 0,
			characterData: [],
			gettingCall: undefined,
			phoneNumber: undefined,
			input: {
				password_one: ``,
				password_two: ``,
				report_one: ``,
				report_two: ``
			},
			apartments: {
				vehicles: [],
				houses: [],
				business: []
			},
			faction: {
				moneyInput: ``,
				money: 0,
				moneyControl: `Пополнить`,
				notifyInput: ``,
				players: {},
				playerControl: undefined,
				rewardInput: ``,
				rewardOpositInput: ``
			},
			phoneCall: {
				numInput: ``,
				addInput_1: ``,
				addInput_2: ``,
				addInput_3: ``,
				blockDelete: false,
				textDelete: "Редактировать",
				contacts: [],
				history: [],
				callNum: undefined,
				callTime: {
					interval: undefined,
					time: `00:00`
				}
			},
			blockMenu: [
				"ipad-appSettings",
				"ipad-appReportQuestion",
				"ipad-appReportPlayer",
				"ipad-appAddPhoneContact",
				"ipad-appFactionNotify"
			]
		},
		methods: {
			showMenu: function () {
				$(".ipad-wrapper").css("display", "flex");
				this.setHoursMinutes(new Date());
				setCursor(true);
				lockOpen.lock(true, "iPad");
				mp.trigger('setBlockControl', true);
				if (!this.update) this.update = setInterval(() => {
					this.setHoursMinutes(new Date());
					if (this.appMenu === `ipad-appFactionMoney`) this.faction.money = clientStorage.factionMoney;
				}, 1000);
			},
			openApp(name) {
				switch (name) {
					case "ipad-appTaxi":
						// Пусто
						break;
					case "ipad-appCharacter":
						// Инициализация данных с клиента
					case "ipad-appSettings":
						// Чистим input
						this.input.password_one = ``;
						this.input.password_two = ``;
						break;
					case "ipad-appApartments":
						// Пусто
						break;
					case "ipad-appReport":
						// Пусто
						break;
					case "ipad-appPhoneContacts":
						// Отмена редакции
						this.phoneCall.textDelete = `Редактировать`;
						this.phoneCall.blockDelete = false;
						break;
					case "ipad-appPhoneRecent":
						// Пусто
						break;
					case "ipad-appPhoneDialer":
						// Чистим input
						this.phoneCall.numInput = ``;
						break;
					case "ipad-appReportQuestion":
						// Чистим input
						this.input.report_one = ``;
						break;
					case "ipad-appReportPlayer":
						// Чистим input
						this.input.report_two = ``;
						break;
					case "ipad-appAddPhoneContact":
						// Чистим input
						this.phoneCall.addInput_1 = ``;
						this.phoneCall.addInput_2 = ``;
						this.phoneCall.addInput_3 = ``;
						break;
					case "ipad-appSpawn":
						// Пусто
						break;
					case "ipad-appMessages":
						// Пусто
						break;
					case "ipad-appFaction":
						if (clientStorage.faction < 1) return nError("Вы не состоите в организации!");
						break;
					case "ipad-appFactionMoney":
						if (clientStorage.faction < 1) {
							this.appMenu = undefined;
							return nError("Вы не состоите в организации!");
						}
						this.faction.money = clientStorage.factionMoney;
						break;
					case "ipad-appFactionMoneyControl":
						if (clientStorage.faction < 1) {
							this.appMenu = undefined;
							return nError("Вы не состоите в организации!");
						}
						this.faction.moneyInput = ``;
						break;
					case "ipad-appFactionNotify":
						if (clientStorage.faction < 1) {
							this.appMenu = undefined;
							return nError("Вы не состоите в организации!");
						}
						if (clientStorage.factionRank < clientStorage.factionLastRank) return nError(`Оповещения доступны с ${clientStorage.factionLastRank} ранга!`);
						this.faction.notifyInput = ``;
						break;
					case "ipad-appFactionMembers":
						if (clientStorage.faction < 1) {
							this.appMenu = undefined;
							return nError("Вы не состоите в организации!");
						}
						if (this.faction.playerControl) {
							this.faction.players[this.faction.playerControl].isActive = false;
							delete this.faction.playerControl;
						}
						break;
					case "ipad-appFactionReward":
						if (clientStorage.faction < 1) {
							this.appMenu = undefined;
							return nError("Вы не состоите в организации!");
						}
						if (clientStorage.factionRank < (clientStorage.factionLastRank + 1)) return nError(`Доступно только лидеру!`);
						if (!this.faction.playerControl) return nError(`Выберите игрока!`);
						this.faction.rewardInput = ``;
						this.faction.rewardOpositInput = ``;
						break;
				}
				this.appMenu = name;
			},
			convertDaysHours(max) {
				let maxShared = max / 60;
				let days = Math.trunc(maxShared / 24);
				let unmaxShared = maxShared - days * 24;
				let hours = Math.trunc(unmaxShared);
				let minutes = Math.round(unmaxShared * 60 - 60 * hours);
				return `${days} дн. ${hours} ч. ${minutes} м.`;
			},
			setSpawn(id) {
				if (id == 1 && this.house == 0) return nError("У вас нет дома!");
				else if (id == 2 && clientStorage.faction < 1) return nError("Вы не состоите в организации!");

				this.spawn = id;
				nSuccess(`Вы установили новое место спавна!`);
				mp.trigger(`ipad.update.spawn`, id);
			},
			openFactionMoneyControl(name) {
				if (name === "Снять" && clientStorage.factionRank < (clientStorage.factionLastRank + 1)) return nError(`Вывод средств доступен только лидеру!`);
				this.openApp("ipad-appFactionMoneyControl");
				this.faction.moneyControl = name;
			},
			transferFactionMoney() {
				let money = this.faction.moneyInput;
				if (money.length < 1) return nError("Поле не заполнено!");
				if (this.faction.moneyControl == "Пополнить") mp.trigger(`ipad.put.faction.money`, money);
				else mp.trigger(`ipad.take.faction.money`, money);
				this.appMenu = "ipad-appFactionMoney";
			},
			sendFactionNotify() {
				let text = this.faction.notifyInput;
				if (text.length < 1) return nError("Поле не заполнено!");
				if (text.length > 64) return nError(`Слишком огромный текст! Символы: ${text.length}/64`);
				mp.trigger(`ipad.send.faction.notify`, text);
				this.appMenu = "ipad-appFaction";
			},
			backApp(name) {
				switch (name) {
					case "ipad-appTaxi":
						this.appMenu = undefined;
						break;
					case "ipad-appCharacter":
						this.appMenu = undefined;
						break;
					case "ipad-appSettings":
						this.appMenu = undefined;
						break;
					case "ipad-appApartments":
						this.appMenu = undefined;
						break;
					case "ipad-appReport":
						this.appMenu = undefined;
						break;
					case "ipad-appPhoneContacts":
						this.appMenu = undefined;
						break;
					case "ipad-appPhoneRecent":
						this.appMenu = undefined;
						break;
					case "ipad-appPhoneDialer":
						this.appMenu = undefined;
						break;
					case "ipad-appReportQuestion":
						this.appMenu = "ipad-appReport";
						break;
					case "ipad-appReportPlayer":
						this.appMenu = "ipad-appReport";
						break;
					case "ipad-appAddPhoneContact":
						this.appMenu = "ipad-appPhoneContacts";
						break;
					case "ipad-appSpawn":
						this.appMenu = undefined;
						break;
					case "ipad-appMessages":
						this.appMenu = undefined;
						break;
					case "ipad-appFaction":
						this.appMenu = undefined;
						break;
					case "ipad-appFactionMoney":
						this.appMenu = "ipad-appFaction";
						break;
					case "ipad-appFactionMoneyControl":
						this.appMenu = "ipad-appFactionMoney";
						break;
					case "ipad-appFactionNotify":
						this.appMenu = "ipad-appFaction";
						break;
					case "ipad-appFactionMembers":
						this.appMenu = "ipad-appFaction";
						break;
					case "ipad-appFactionReward":
						this.appMenu = "ipad-appFactionMembers";
						break;
					case "ipad-Home":
						this.appMenu = undefined;
						break;
				}
			},
			closeMenu(ignore = false) {
		        if (this.blockMenu.includes(this.appMenu) && !ignore) return;
				mp.trigger('setBlockControl', false);
				$(".ipad-wrapper").css("display", "none");
				setCursor(false);
				lockOpen.lock(false, "iPad");
				if (this.update) clearInterval(this.update);
				delete this.update, this.appMenu = undefined;
			},
			controlMenu() {
				if (lockOpen.name.includes("iPad")) {
					this.closeMenu();
				} else if (lockOpen.name.length < 1) {
					if (window.consoleAPI.active() || window.modalAPI.active()) return;
					this.showMenu();
				}
			},
			addFactionPlayer(data) {
				if (this.faction.players[data.id]) return;
				Vue.set(iPad.faction.players, data.id, { id: data.id, name: data.name, rank: data.rank, isActive: false }); // this.faction.players[data.id] = myData;
			},
			removeFactionPlayer(data) {
				Vue.delete(iPad.faction.players, data); // delete this.faction.players[data];
				if (this.faction.playerControl == data) delete this.faction.playerControl;
			},
			setFactionPlayerRank(data, rank) {
				if (!this.faction.players[data]) return;
				this.faction.players[data].rank = rank;
			},
			chooseFactionPlayer(data) {
				if (this.faction.playerControl) this.faction.players[this.faction.playerControl].isActive = false;
				this.faction.playerControl = data;
				this.faction.players[data].isActive = true;
				nSuccess(`Вы выбрали ${this.faction.players[data].name}`);
			},
			upFactionRank() {
				if (clientStorage.factionRank < clientStorage.factionLastRank) return nError(`Доступно с ${clientStorage.factionLastRank} ранга!`);
				if (!this.faction.playerControl) return nError(`Выберите игрока!`);
				mp.trigger(`ipad.up.faction.rank`, this.faction.playerControl);
			},
			downFactionRank() {
				if (clientStorage.factionRank < clientStorage.factionLastRank) return nError(`Доступно с ${clientStorage.factionLastRank} ранга!`);
				if (!this.faction.playerControl) return nError(`Выберите игрока!`);
				mp.trigger(`ipad.down.faction.rank`, this.faction.playerControl);
			},
			kickFactionPlayer() {
				if (clientStorage.factionRank < clientStorage.factionLastRank) return nError(`Доступно с ${clientStorage.factionLastRank} ранга!`);
				if (!this.faction.playerControl) return nError(`Выберите игрока!`);
				mp.trigger(`ipad.kick.faction.player`, this.faction.playerControl);
			},
			giveFactionReward() {
				if (clientStorage.factionRank < (clientStorage.factionLastRank + 1)) return nError(`Доступно только лидеру!`);
				if (!this.faction.playerControl) {
					this.appMenu = `ipad-appFactionMembers`;
					return nError(`Повторно выберите игрока!`);
				}
				if (this.faction.rewardInput.length < 1 || this.faction.rewardOpositInput.length < 1) return nError("Заполните все поля!");
				if (this.faction.rewardOpositInput.length > 64) return nError(`Слишком огромный текст! Символы: ${this.faction.rewardOpositInput.length}/64`);
				mp.trigger(`ipad.reward.faction.player`, this.faction.playerControl, this.faction.rewardInput, this.faction.rewardOpositInput);
				this.appMenu = "ipad-appFactionMembers";
			},
			clearFactionPlayers() {
				this.faction.players = {};
			},
			upLetter(str) {
				if (!str) return str;
				return str[0].toUpperCase() + str.slice(1);
			},
			setHoursMinutes(date) {
				let hours = date.getHours();
				let minutes = date.getMinutes();
				if (hours < 10) hours = "0" + hours;
				if (minutes < 10) minutes = "0" + minutes;
				this.time = `${hours}:${minutes}`;
			},
			callPlayerByButton(number) {
				if (this.phoneCall.blockDelete) return;
				if (number < 1) return nError("Номер не найден!");
				mp.trigger("telephone.call", number);
			},
			callPlayer() {
				if (this.phoneCall.numInput.length < 1) return nError("Поле не заполнено!");
				if (this.phoneCall.numInput == this.phoneNumber) return nError("Вы не можете позвонить на свой номер!");
				mp.trigger("telephone.call", this.phoneCall.numInput);
			},
			callTaxi() {
				mp.trigger('calltax');
			},
			callMeha() {
				mp.trigger('callmeh');
			},
			callMedic() {
				mp.trigger('callmed');
			},
			callMent() {
				mp.trigger('callment');
			},
			callstats() {
				mp.trigger('board2', 0);
			},
			callstore() {
				mp.trigger('donate2', 0);
			},
			callnews() {
				mp.trigger('addnews');
			},
			changePassword() {
				if (this.input.password_one.length < 6 || this.input.password_one.length > 20) return nError("Старый пароль должен состоять из 6-20 символов!");
				if (this.input.password_two.length < 6 || this.input.password_two.length > 20) return nError("Новый пароль должен состоять из 6-20 символов!");
				this.closeMenu(true);
				mp.trigger(`changeAccountPassword`, this.input.password_one, this.input.password_two);
			},
			loadApartmentsVehicles(vehicles) {
				this.apartments.vehicles = [];
				for (let i = 0; i < vehicles.length; i++) {
					let text = this.upLetter(vehicles[i]);
					this.apartments.vehicles[i] = text;
				}
			},
			loadApartmentsHouses(houses) {
				this.apartments.houses = [];
				for (let i = 0; i < houses.length; i++) {
					let text = this.upLetter(houses[i]);
					this.apartments.houses[i] = text;
				}
			},
			loadApartmentsBusiness(business) {
				this.apartments.business = [];
				for (let i = 0; i < business.length; i++) {
					let text = this.upLetter(business[i]);
					this.apartments.business[i] = text;
				}
			},
			sendReportMessage(report) {
				if (report) {
					if (this.input.report_two.length < 1) return nError("Поле не заполнено!");
					// mp.trigger - жалоба
				} else {
					if (this.input.report_one.length < 1) return nError("Поле не заполнено!");
					// mp.trigger - вопрос
				}
			},
			addApartmentsHouse(data) {
				this.apartments.houses.push(data);
			},
			deleteApartmentsHouse(data) {
				this.apartments.houses.splice(this.apartments.houses.indexOf(data), 1);
			},
			addApartmentsBusiness(data) {
				this.apartments.business.push(data);
			},
			deleteApartmentsBusiness(data) {
				this.apartments.business.splice(this.apartments.business.indexOf(data), 1);
			},
			addPhoneInputNumber(number) {
				this.phoneCall.numInput += number;
			},
			addPhoneContact(id, name, number) {
				this.phoneCall.contacts.push({ id: id, name: name, number: number });
			},
			addPhoneHistory(number, time) {
				this.phoneCall.history.push({ name: "Гражданин", number: number, time: time.substring(0, 10) });
				// nameOfPhoneContact(number);
			},
			deletePhoneHistory(i) {
				this.phoneCall.history.splice(i, 1);
			},
			cancelCall(type) {
				this.gettingCall = undefined;
				if (type != 2) mp.trigger("cancel.phone.call", type);
				if (this.phoneCall.callTime.interval) {
					clearInterval(this.phoneCall.callTime.interval);
					this.phoneCall.callTime = {
						interval: undefined,
						time: `00:00`
					}
				}
			},
			nameOfPhoneContact(number) {
				for (let i = 0; i < this.phoneCall.contacts.length; i++) {
					let contact = this.phoneCall.contacts[i];
					if (contact.number == number) return contact.name;
				}
				return "Неизвестный";
			},
			getPhoneCall(number) {
				for (let i = 0; i < this.phoneCall.contacts.length; i++) {
					let contact = this.phoneCall.contacts[i];
					if (contact.number == number) number = contact.name;
				}
				this.phoneCall.callNum = number;
				nSuccess(`Входящий звонок от ${number}`);
				this.appMenu = undefined;
				this.gettingCall = "ipad-appPhoneGettingCall";
			},
			startPhoneCall(number) {
				for (let i = 0; i < this.phoneCall.contacts.length; i++) {
					let contact = this.phoneCall.contacts[i];
					if (contact.number == number) number = contact.name;
				}
				this.phoneCall.callNum = number;
				this.appMenu = undefined;
				this.gettingCall = "ipad-appPhoneCalling";
			},
			checkAcceptCall() {
				mp.trigger("check.phone.accept.call");
			},
			acceptCall() {
				let time = 0;
				this.gettingCall = "ipad-appPhoneSpeakingCall";
				if (!this.phoneCall.callTime.interval) this.phoneCall.callTime.interval = setInterval(() => {
					this.phoneCall.callTime.time = this.getSpecialTime(++time);
				}, 1000);
			},
			createContact() {
				if (this.phoneCall.contacts.length > 29) return player.utils.error("У вас уже 30 контактов!");
				if ((this.phoneCall.addInput_1.length < 1 && this.phoneCall.addInput_2.length < 1) || this.phoneCall.addInput_3.length < 1) return nError("Заполните основные поля!");
				if (this.phoneCall.addInput_3 == this.phoneNumber) return nError("Вы не можете внести свой номер!");
				mp.trigger(`select.add.contact`, `${this.phoneCall.addInput_1} ${this.phoneCall.addInput_2}`, this.phoneCall.addInput_3);
				this.appMenu = "ipad-appPhoneContacts";
			},
			deleteContact(id) {
				for (let i = 0; i < this.phoneCall.contacts.length; i++) {
					let contact = this.phoneCall.contacts[i];
					if (contact.id == id) this.phoneCall.contacts.splice(i, 1);
				}
				mp.trigger("deleteContact", id);
			},
			openPhoneContactsDelete() {
				if (this.phoneCall.blockDelete) {
					this.phoneCall.textDelete = `Редактировать`;
					this.phoneCall.blockDelete = false;
				} else {
					if (this.phoneCall.contacts.length < 1) return nError("У вас нет контактов!");
					this.phoneCall.textDelete = `Готово`;
					this.phoneCall.blockDelete = true;
				}
			},
			getSpecialTime(seconds) {
				let minutes = Math.floor(seconds / 60);
				minutes = (minutes > 9) ? minutes : "0" + minutes;
				seconds = Math.floor(seconds % 60);
				seconds = (seconds > 9) ? seconds : "0" + seconds;
				return minutes + ":" + seconds;
			}
		}
	});
});