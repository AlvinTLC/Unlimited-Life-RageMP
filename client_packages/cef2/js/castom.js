$(document).ready(function () {
	window.castomApp = new Vue({
		el: '#castomMenu',
		data: {
			current: undefined,
			name_input: undefined,
			surname_input: undefined,
			pickedGender: 1,
			parents: {
				mother: "Ханна",
				father: "Бенджамин",
				appear: 50,
				body: 50,
				mothers: ["Ханна", "Одри", "Жасмин", "Жизель", "Амелия",
					"Изабелла", "Зои", "Эва", "Камилла", "Виолетта", "София",
					"Эвелин", "Николь", "Эшли", "Грейс", "Брианна", "Натали",
					"Оливия", "Элизабет", "Шарлотта", "Эмма", "Мисти"
				],
				fathers: ["Бенджамин", "Дэниел", "Джошуа", "Ноа", "Эндрю",
					"Хуан", "Алекс", "Исаак", "Эван", "Итан", "Винсент", "Анхель",
					"Диего", "Эдриан", "Габриэль", "Майкл", "Сантьяго", "Кевин",
					"Луис", "Самуил", "Энтони", "Клод", "Джон", "Нико"
				],
			},
			specifications: [50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50],
			face: {
				features: ["Челка набок", "1", "Модные", "1", "Гладкая кожа", "1", "Нет", "Нет", "Нет", "Нет", "Нет", "Зеленый", "Нет", "Нет", "Нет", "1"],
				hairs: {
					female: ["Нет", "Коротко", "Слои", "Косички", "Хвост", "Икорез", "Косичка", "Боб", "Ястреб", "Ракушка", "Лонг боб", "Свободно", "Пикси", "Подбритые виски",
						"Узел", "Волнистый боб", "Красотка", "Пучок", "Тугой узел", "Одуванчик", "Взрыв", "Узел ( Распущенный )", "Маллет", "Флэппер боб"],
					male: ["Нет", "Очень коротко", "Ястреб", "Хипстер", "Челка набок", "Коротко", "Байкер", "Хвост", "Косички", "Прилиза", "Покороче", "Шипы", "Цезарь", "Чоппи",
						"Дреды", "Длинные", "Лохматые кудри", "Серфингист", "Набок", "Зализ", "Длинные ( Зализ )", "Юный хипстер", "Маллет"]
				},
				brows: ["Нет", "Аккуратные", "Модные", "Клеопатра", "Ироничные", "Женственные", "Обольстительные", "Нахмуренные", "Чикса", "Торжествующие", "Беззаботные",
					"Дугой", "Мышка", "Двойная высечка", "Впалые", "Нарисованные карандашом", "Выщипанные", "Прямые и тонкие", "Естественные", "Пышные", "Неопрятные",
					"Широкие", "Обычные", "Южноевропейские", "Ухоженные", "Кустистые", "Перышки", "Колючие", "Сросшиеся", "Крылатые", "Тройная высечка", "Высечка дугой",
					"Подрезанные", "Сходящие на нет", "Высечка"],
				beards: ["Гладкая кожа", "Легкая щетина", "Бальбо", "Круглая борода", "Эспаньолка", "Козлиная бородка", "Островок", "Тонкая бородка", "Коротенькая бородка",
					"Мушкетер", "Усы", "Подстриженная борода", "Щетина", "Кругленькая борода", "Борода-подкова", "Карандашные усы и баки", "Борода-ремень", "Бальбо и баки",
					"Баки", "Короткая бородка", "Дали", "Дали и борода", "Велосипедные руль", "Островок с усами", "Английские усы с пеньком", "Голливудская борода",
					"Фу Манчу", "Островок с баками", "Широкие баки", "Ширма"],
				hurts: ["Нет", "Краснуха", "Корь", "Пятна", "Сыпь", "Угри", "Налет", "Гнойники", "Прыщики", "Большие прыщи", "Прыщи", "Сыпь на щеках", "Сыпь на лице",
					"Расковырянные прыщи", "Пубертат", "Язва", "Сыпь на подбродке", "С двумя лицами", "Зона Т", "Сальная кожа", "Шрамы", "Шрамы от прыщей",
					"Шрамы от больших прыщей", "Герпес", "Лишай"],
				olds: ["Нет", "Морщины в углах глаз", "Первые признаки старения", "Средний возраст", "Морщины", "Депрессия", "Преклонный возраст", "Старость",
					"Обветренная кожа", "Морщинистая кожа", "Обвисшая кожа", "Тяжелая жизнь", "Винтаж", "Пенсионный возраст", "Наркомания", "Престарелость"],
				bodys: ["Нет", "Румянец", "Раздражение от щетины", "Покраснение", "Солнечный ожог", "Синяки", "Алкоголизм", "Пятна", "Тотем", "Кровеносные сосуды",
					"Повреждения", "Бледная", "Мертвенно-бледная"],
				rodins: ["Нет", "Ангелочек", "Повсюду", "Местами", "Единичные", "На переноснице", "Куколка", "Фея", "Загорелая", "Родинки", "Ряд", "Как у модели", "Редкие",
					"Веснушки", "Капельки дождя", "Удвоенность", "С одной стороны", "Пары", "Бородавки"],
				hurtsBody: ["Нет", "Неровная", "Наждак", "Пятнистая", "Грубая", "Жёсткая", "Шероховатая", "Загрубелая", "Неровное", "Со складками", "Потрескавшаяся",
					"Твёрдая"],
				eyes: ["Зеленый", "Изумрудный", "Голубой", "Синий", "Светлый шатен", "Темно-коричневый", "Карий", "Темно-серый", "Светло-серый"],
				maskas: ["Нет", "Дымчато-черный", "Бронзовый", "Мягкий серый", "Ретро-гламур", "Естественный", "Кошачьи глаза", "Чикса", "Вамп", "Вайнвудский гламур", "Баблгам",
					"Мечта о море", "Пин-ап", "Лиловая страсть", "Дымчатые кошачьи глаза", "Огненный рубин", "Эстрадная принцесса", "Тушь для  глаз", "Кровавые слезы", "Хеви-метал",
					"Печаль", "Князь тьмы", "Рокер", "Гот", "Панк", "Сокрушенность"],
				rumanas: ["Нет", "Полный", "Под углом", "Округлый", "Горизонтальный", "На скулах", "Красотка", "В стиле 80-х"],
				pomada: ["Нет", "Цветные матовые", "Цветные блестящие", "Контур, матовые", "Контур, блестящие", "Жирный контур, матовые", "Жирный контур, блестящие", "Контур, матовые",
					"Контур блеск", "Размазанная помада", "Гейша"]
			},
			clothes: {
				top: "Футболка",
				leg: "Джинсы",
				foo: "Кроссовки",
				tops: {
					female: ["Майка", "Футболка", "Рубашка", "Кофта"],
					male: ["Футболка", "Свитшот", "Рубашка", "Майка"]
				},
				legs: {
					female: ["Джинсы", "Брюки", "Юбка", "Шорты"],
					male: ["Джинсы", "Шорты", "Штаны"]
				},
				foot: {
					female: ["Кроссовки", "Сланцы", "Туфли"],
					male: ["Кроссовки", "Сланцы"]
				}
			}
		},
		methods: {
			openMenu() {
				if (this.current) {
					this.clear("character");
					this.clear("parents");
					this.clear("specifications");
					this.clear("face");
					this.clear("clothes");
				}
				$("#castomMenu #icons").css("display", "flex");
				$("#castomMenu #character").css("display", "flex");
				this.current = "character";
				$("#castomMenu #icons .item.character").addClass("active");
			},
			reconMenu(name) {
				if (this.current) {
					if (this.current == name) return;
					$(`#castomMenu #${this.current}`).css(`display`, `none`);
					$(`#castomMenu #icons .item.${this.current}`).removeClass(`active`);
				}
				$(`#castomMenu #${name}`).css("display", "flex");
				this.current = name;
				$(`#castomMenu #icons .item.${name}`).addClass(`active`);
				mp.trigger("castom.focus", name);
			},
			control(menu, status, inc = false) {
				let index, name, arr;
				switch (menu) {
					case "parents mothers":
						index = this.parents.mothers.indexOf(this.parents.mother);
						name = this.parents.mothers[status == "up" ? ++index : --index];
						if (!name) return;
						this.parents.mother = name;
						mp.trigger("castom.chooseMother", index);
						$(`#castomMenu #parents .parents .parent.parent-1`).css(`backgroundImage`, `url(img/parents/f_${index}.png)`);
						break;
					case "parents fathers":
					    index = this.parents.fathers.indexOf(this.parents.father);
						name = this.parents.fathers[status == "up" ? ++index : --index];
						if (!name) return;
						this.parents.father = name;
						mp.trigger("castom.chooseFather", index);
						$(`#castomMenu #parents .parents .parent.parent-2`).css(`backgroundImage`, `url(img/parents/m_${index}.png)`);
						break;
					case "parents appearence":
					    index = this.parents.appear;
						if (status == "up" ? ++index : --index);
						if (index < 0 || index > 100) return;
						this.parents.appear = index;
						mp.trigger("castom.chooseAppear", index);
						break;
					case "parents body":
						index = this.parents.body;
						if (status == "up" ? ++index : --index);
						if (index < 0 || index > 100) return;
						this.parents.body = index;
						mp.trigger("castom.chooseBodyMix", index);
						break;
					case "specifications":
						index = this.specifications[inc];
						if (status == "up" ? ++index : --index);
						if (index < 0 || index > 100) return;
						this.specifications[inc] = index;
						Vue.set(castomApp.specifications, inc, index);
						mp.trigger("castom.chooseSpecifications", index, inc);
						break;
					case "clothes tops":
						arr = this.pickedGender == 1 ? this.clothes.tops.male : this.clothes.tops.female;
						index = arr.indexOf(this.clothes.top);
						name = arr[status == "up" ? ++index : --index];
						if (!name) return;
						this.clothes.top = name;
						mp.trigger("castom.chooseClothes", index, "tops");
						break;
					case "clothes legs":
						arr = this.pickedGender == 1 ? this.clothes.legs.male : this.clothes.legs.female;
						index = arr.indexOf(this.clothes.leg);
						name = arr[status == "up" ? ++index : --index];
						if (!name) return;
						this.clothes.leg = name;
						mp.trigger("castom.chooseClothes", index, "legs");
						break;
					case "clothes foot":
						arr = this.pickedGender == 1 ? this.clothes.foot.male : this.clothes.foot.female;
						index = arr.indexOf(this.clothes.foo);
						name = arr[status == "up" ? ++index : --index];
						if (!name) return;
						this.clothes.foo = name;
						mp.trigger("castom.chooseClothes", index, "foot");
						break;
					case "face hairs":
						arr = this.pickedGender == 1 ? this.face.hairs.male : this.face.hairs.female;
						index = arr.indexOf(this.face.features[0]);
						name = arr[status == "up" ? ++index : --index];
						if (!name) return;
						this.face.features[0] = name;
						Vue.set(castomApp.face.features, inc, name);
						mp.trigger("castom.chooseHair", index);
						break;
					case "face hairs color":
						index = this.face.features[inc];
						if (status == "up" ? ++index : --index);
						if (index < 1 || index > 50) return;
						this.face.features[inc] = index;
						Vue.set(castomApp.face.features, inc, index);
						mp.trigger("castom.chooseHairColor", --index);
						break;
					case "face brows":
						arr = this.face.brows;
						index = arr.indexOf(this.face.features[inc]);
						name = arr[status == "up" ? ++index : --index];
						if (!name) return;
						this.face.features[inc] = name;
						Vue.set(castomApp.face.features, inc, name);
						mp.trigger("castom.chooseFaceComponent", index, "Брови");
						break;
					case "face brows color":
						index = this.face.features[inc];
						if (status == "up" ? ++index : --index);
						if (index < 1 || index > 50) return;
						this.face.features[inc] = index;
						Vue.set(castomApp.face.features, inc, index);
						mp.trigger("castom.chooseFaceComponentColor", --index, "Брови");
						break;
					case "face beards":
						arr = this.face.beards;
						index = arr.indexOf(this.face.features[inc]);
						name = arr[status == "up" ? ++index : --index];
						if (!name) return;
						this.face.features[inc] = name;
						Vue.set(castomApp.face.features, inc, name);
						mp.trigger("castom.chooseFaceComponent", index, "Волосы на лице");
						break;
					case "face beards color":
						index = this.face.features[inc];
						if (status == "up" ? ++index : --index);
						if (index < 1 || index > 50) return;
						this.face.features[inc] = index;
						Vue.set(castomApp.face.features, inc, index);
						mp.trigger("castom.chooseFaceComponentColor", --index, "Волосы на лице");
						break;
					case "face hurts":
						arr = this.face.hurts;
						index = arr.indexOf(this.face.features[inc]);
						name = arr[status == "up" ? ++index : --index];
						if (!name) return;
						this.face.features[inc] = name;
						Vue.set(castomApp.face.features, inc, name);
						mp.trigger("castom.chooseFaceComponent", index, "Дефекты кожи");
						break;
					case "face olds":
						arr = this.face.olds;
						index = arr.indexOf(this.face.features[inc]);
						name = arr[status == "up" ? ++index : --index];
						if (!name) return;
						this.face.features[inc] = name;
						Vue.set(castomApp.face.features, inc, name);
						mp.trigger("castom.chooseFaceComponent", index, "Старение кожи");
						break;
					case "face bodys":
						arr = this.face.bodys;
						index = arr.indexOf(this.face.features[inc]);
						name = arr[status == "up" ? ++index : --index];
						if (!name) return;
						this.face.features[inc] = name;
						Vue.set(castomApp.face.features, inc, name);
						mp.trigger("castom.chooseFaceComponent", index, "Тип кожи");
						break;
					case "face rodins":
						arr = this.face.rodins;
						index = arr.indexOf(this.face.features[inc]);
						name = arr[status == "up" ? ++index : --index];
						if (!name) return;
						this.face.features[inc] = name;
						Vue.set(castomApp.face.features, inc, name);
						mp.trigger("castom.chooseFaceComponent", index, "Родинки и веснушки");
						break;
					case "face hurtsBody":
						arr = this.face.hurtsBody;
						index = arr.indexOf(this.face.features[inc]);
						name = arr[status == "up" ? ++index : --index];
						if (!name) return;
						this.face.features[inc] = name;
						Vue.set(castomApp.face.features, inc, name);
						mp.trigger("castom.chooseFaceComponent", index, "Повреждения кожи");
						break;
					case "face eyes":
						arr = this.face.eyes;
						index = arr.indexOf(this.face.features[inc]);
						name = arr[status == "up" ? ++index : --index];
						if (!name) return;
						this.face.features[inc] = name;
						Vue.set(castomApp.face.features, inc, name);
						mp.trigger("castom.chooseEyeColor", index);
						break;
					case "face maskas":
						arr = this.face.maskas;
						index = arr.indexOf(this.face.features[inc]);
						name = arr[status == "up" ? ++index : --index];
						if (!name) return;
						this.face.features[inc] = name;
						Vue.set(castomApp.face.features, inc, name);
						mp.trigger("castom.chooseFaceComponent", index, "Макияж глаз");
						break;
					case "face rumanas":
						arr = this.face.rumanas;
						index = arr.indexOf(this.face.features[inc]);
						name = arr[status == "up" ? ++index : --index];
						if (!name) return;
						this.face.features[inc] = name;
						Vue.set(castomApp.face.features, inc, name);
						mp.trigger("castom.chooseFaceComponent", index, "Румяна");
						break;
					case "face pomada":
						arr = this.face.rumanas;
						index = arr.indexOf(this.face.features[inc]);
						name = arr[status == "up" ? ++index : --index];
						if (!name) return;
						this.face.features[inc] = name;
						Vue.set(castomApp.face.features, inc, name);
						mp.trigger("castom.chooseFaceComponent", index, "Помада");
						break;
					case "face pomada color":
						index = this.face.features[inc];
						if (status == "up" ? ++index : --index);
						if (index < 1 || index > 42) return;
						this.face.features[inc] = index;
						Vue.set(castomApp.face.features, inc, index);
						mp.trigger("castom.chooseFaceComponentColor", --index, "Помада");
						break;
				}
			},
			createCharacter() {
				const firstName = this.name_input;
				const lastName = this.surname_input;
				const nameRegex = /^([A-Z][a-z]{1,15})$/;

				if (!firstName) return nError(`Вы не ввели Имя персонажа!`);
				if (!firstName) return nError(`Вы не ввели Фамилию персонажа!`);

				if (!nameRegex.test(firstName)) {
					nInfo(`Используйте шаблон "Имя"`);
					return nError(`Имя "${firstName}" некорректно!`);
				}

				if (!nameRegex.test(lastName)) {
					nInfo(`Используйте шаблон "Фамилия"`);
					return nError(`Фамилия "${lastName}" некорректна!`);
				}

				let fullLength = firstName.length + lastName.length;
				if (fullLength > 20) return nError(`У вас слишком длинное "Имя Фамилия"`);
				mp.trigger("regCharacter", `${firstName} ${lastName}`);
			},
			clear(current) {
				if (!current) current = this.current;
				mp.trigger("castom.clearMenu", current);
				switch (current) {
					case "character":
						this.name_input = undefined;
						this.surname_input = undefined;
						break;
					case "parents":
						this.parents.mother = "Ханна", this.parents.father = "Бенджамин";
						$(`#castomMenu #parents .parents .parent.parent-1`).css(`backgroundImage`, `url(img/parents/f_0.png)`);
						$(`#castomMenu #parents .parents .parent.parent-2`).css(`backgroundImage`, `url(img/parents/m_0.png)`);
						this.parents.appear = 50, this.parents.body = 50;
						break;
					case "specifications":
						this.specifications = [50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50];
						break;
					case "face":
						if (this.pickedGender == 1) {
							this.face.features = ["Челка набок", "1", "Модные", "1", "Гладкая кожа", "1", "Нет", "Нет", "Нет", "Нет", "Нет", "Зеленый", "Нет", "Нет", "Нет", "1"];
						} else {
							this.face.features = ["Хвост", "1", "Модные", "1", "Гладкая кожа", "1", "Нет", "Нет", "Нет", "Нет", "Нет", "Зеленый", "Нет", "Нет", "Нет", "1"];
						}
						break;
					case "clothes":
						if (this.pickedGender == 1) {
							this.clothes.top = this.clothes.tops.male[0];
							this.clothes.leg = this.clothes.legs.male[0];
							this.clothes.foo = this.clothes.foot.male[0];
						} else {
							this.clothes.top = this.clothes.tops.female[0];
							this.clothes.leg = this.clothes.legs.female[0];
							this.clothes.foo = this.clothes.foot.female[0];
						}
						break;
				}
			},
			chooseGender(data) {
				setTimeout(() => {
					if (this.pickedGender == data) return;
					mp.trigger("castom.toggleGender");
					this.clear("parents");
					this.clear("specifications");
					this.clear("face");
					this.clear("clothes");
				}, 1);
			},
			closeMenu() {
				$("#castomMenu #icons").css("display", "none");
				$(`#castomMenu #icons .item.${this.current}`).removeClass(`active`);
				$(`#castomMenu #${this.current}`).css(`display`, `none`);
				// this.current = undefined;
			},
		}
	});
});