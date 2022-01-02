$(document).ready(function () {
	window.characterController = new Vue({
		el: '#selectorCharacters',
		data: {
			donate: 0,
			inits: [undefined, undefined, undefined],
			html: [
				``,
				`<div class="user-block free">
							<div class="user-block-info">
								<div class="user-avatar">
									<img src="img/selectCharacters/unlock.svg" alt="" />
								</div>
								<p class="player-name">Разблокировано</p>
							</div>
							<div class="desc-block">
								<div class="text">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Modi deserunt culpa aspernatur doloribus recusandae? Rem tempora quisquam, dolore adipisci magni nostrum fugit ipsam ea natus aliquam illo. Quod, eveniet error.</div>
								<div class="icon">
									<img src="img/selectCharacters/add.svg" alt="" />
								</div>
							</div>
							<div class="buttons">
								<button class="button accept" onclick="characterController.control(2)">Создать</button>
							</div>
				</div>`,
				`<div class="user-block donate">
							<div class="user-block-info">
								<div class="user-avatar">
									<img src="img/selectCharacters/lock.svg" alt="" />
								</div>
								<p class="player-name">Заблокировано</p>
							</div>
							<div class="desc-block">
								<div class="text">Lorem ipsum, dolor sit amet consectetur adipisicing elit. Itaque ab incidunt dolorum suscipit ducimus commodi magnam similique maxime error cupiditate quos nisi dolores, animi unde molestiae soluta sapiente ipsum quod.</div>
								<div class="icon">
									<img src="img/selectCharacters/donate.svg" alt="" />
								</div>
							</div>
							<div class="buttons">
								<button class="button accept" onclick="characterController.control(3)">Разблокировать</button>
							</div>
				</div>`
			]
		},
		methods: {
			initCharacters(data) {
				data = JSON.parse(data);
				this.donate = data.donate;
				this.inits = [undefined, undefined, undefined];
				var access = [true, true, data.isDonate];
				for (var i = 0; i < 3; i++) {
					let character = data.characters[i];
					if (character) {
						this.inits[i] = this.createInfoAcc(character, i);
						Vue.set(characterController.inits, this.html[0], i);
					} else {
						var c = access[i];
						let newValue = this.html[1];
						if (!c) newValue = this.html[2];
						this.inits[i] = newValue;
						Vue.set(characterController.inits, newValue, i);
					}
				}
				$("#selectorCharacters").css("display", "flex");
			},
			createInfoAcc(character, i) {
				let levelRest = convertMinutesToLevelRest(character.minutes);
				let maxExp = convertLevelToMaxExp(levelRest.level);
				return `<div class="user-block busy">
					<div class="user-block-info">
						<div class="user-avatar">
							<img src="img/selectCharacters/char_icon.png" alt="" />
						</div>
						<p class="player-name">${character.name}</p>
					</div>
					<ul class="info-blocks">
						<li class="info">
							<div class="name">Дата создания</div>
							<div class="value">${convertMillsToDate(character.regDate * 1000)}</div>
						</li>
						<li class="info">
							<div class="name">Онлайн</div>
							<div class="value">${parseInt(character.minutes / 60)} часов</div>
						</li>
						<li class="info">
							<div class="name">Уровень</div>
							<div class="value">${levelRest.level}</div>
						</li>
						<li class="info">
							<div class="name">Опыт</div>
							<div class="value">${levelRest.rest} / ${maxExp}</div>
						</li>
						<li class="info">
							<div class="name">Организация</div>
							<div class="value">${character.faction == 0 ? `Отсутствует` : character.faction }</div>
						</li>
						<li class="info">
							<div class="name">Наличные средства</div>
							<div class="value">$${character.money}</div>
						</li>
						<li class="info">
							<div class="name">Средства на счету</div>
							<div class="value">$${character.bank}</div>
						</li>
					</ul>	
					<div class="buttons">
						<button class="button accept" onclick="characterController.control(0, ${i});">Играть</button>
					</div>
				</div>`
			},
			control(type, data) {
				switch (type) {
					case 0:
						choiceMenuAPI.hide();
						mp.trigger('authCharacter', data);
						break;
					case 1:
						choiceMenuAPI.show(`accept_delete_character`, `{"name": "${data}"}`);
						break;
					case 2:
						mp.trigger(`events.callRemote`, `initNewCharacter`);
						break;
					case 3:
						if (this.donate < 1500) return mp.trigger('nError', 'Необходимо 1500 ICN!');
						mp.trigger('events.callRemote', 'characters.openSlot', 'donate');
						break;
				}
			}
		}
	});
});