// ANIMALS
mp.peds.new(-1026527405, new mp.Vector3(-550.4594, -235.0781, 37.72579), 218.8, 0); //Кот у мерии, сейчас обезьяна
mp.peds.new(307287994, new mp.Vector3(-555.18, -267.6916, 35.14048), 303.2, 0); //Хаски у мерии, теперь горный лев
mp.peds.new(402729631, new mp.Vector3(-555.5945, -268.7845, 37.69592), 316.7, 0); // Голубь над Хаски у мерии
mp.peds.new(1832265812, new mp.Vector3(564.3991, 2740.475, 41.50517), 182.1, 0); //Пес у Зоомагазина где то в палетто бэй
mp.peds.new(3549666813, new mp.Vector3(-193.6039, 793.1151, 197.6122), 144.9679,0); //Чайка
/*mp.peds.new(2506301981, new mp.Vector3(-199.1794, -1609.419, 34.01067), 261.4599, 0); //Пес территория Зеленных
mp.peds.new(2506301981, new mp.Vector3(85.70742, -1955.27, 20.15471), 314.5776, 0); //Пес территория Феолетовых
mp.peds.new(2506301981, new mp.Vector3(483.7948, -1519.017, 28.67134), 87.19617, 0); //Пес территория Красных
mp.peds.new(2506301981, new mp.Vector3(882.3968, -2169.903, 31.65136), 189.0253, 0); //Пес территория Синих
mp.peds.new(2506301981, new mp.Vector3(1416.409, -1496.435, 59.40118), 161.6646, 0); //Пес территория :tkns[
mp.peds.new(882848737, new mp.Vector3(442.9502, -981.1665, 30.06959), 88.87737, 0); //Пес в PLSD*/
mp.peds.new(3630914197, new mp.Vector3(-1528.098, 1753.292, 86.17753), 323.6743, 0); //Оленьу реки
mp.peds.new(1462895032, new mp.Vector3(2015.733, 4967.312, 41.87567), 258.3119, 0); //Кот на пеньке

/////// НПС //////////

mp.peds.new(1381498905, new mp.Vector3(-86.05331, -1210.9806, 27.836163), 100.48001, 0); //Путана_под_мостом_улица_Строббери (поднят по оси Z на 115см.) - Путана в красном
mp.peds.new(348382215, new mp.Vector3(-86.2769, -1213.4092, 27.976975), 93.489944, 0); //Путана_под_мостом_улица_Строббери - Путана в леопардовом
mp.peds.new(42647445, new mp.Vector3(-86.294754, -1217.088, 28.176537), 98.20537, 0); //Путана_под_мостом_улица_Строббери
mp.peds.new(51789996, new mp.Vector3(-86.244125, -1232.7998, 28.748304), 108.14619, 0); //Путана_под_мостом_улица_Строббери
mp.peds.new(1943971979, new mp.Vector3(-86.29642, -1229.8224, 28.663693), 86.07586, 0); //Путана_под_мостом_улица_Строббери

//////////////////////

// Peds
var needped = [null,null,null];
needped[0] = mp.peds.new(-681546704, new mp.Vector3(-767.4036, -1269.557, 5.7), 67.10416, 0); //Чувак на пирсе с заданием Bony
needped[1] = mp.peds.new(-855671414, new mp.Vector3(-847.3671, -1313.989, 4.97), 300.2086, 0); //Женщина у маяка с заданием Emma
needped[2] = mp.peds.new(1906124788, new mp.Vector3(-520.9094, -1503.0, 10.9), 171.277, 0); //Мужик на поле с заданием Frank

mp.events.add('ChatPyBed', (id, variation) => {
	try {
		if (!loggedin || pedtimer) return;
		pedtimer = true;
		switch(id) {
			case 0:
				pedtext = "Привет! Тебя ждет один человек у причала.";
				mp.gui.chat.push("!{Yellow}[Bony] !{White}Привет! Тебя ждет один человек у причала.");
				pedsaying = needped[0];
				break;
			case 1:	
				pedtext = "Это очень важно чувак, не игнорь...";
				mp.gui.chat.push("!{Yellow}[Bony] !{White}Это очень важно чувак, не игнорь...");
				pedsaying = needped[0];
				break;
			case 2:	
				pedtext = "Если хочешь начать жить в этом сранном городе";
				pedtext2 = "То начни сначало зарабатывать, убери этот мусор с пирса";
				mp.gui.chat.push("!{Green}[Emma] !{White}Если хочешь начать жить в этом сранном городе. То начни сначало зарабатывать, убери этот мусор с пирса.");
				pedsaying = needped[1];
				break;
			case 3:	
				pedtext = "В большом городе за большие сиськи";
				pedtext2 = "стоя не аплодируют. А теперь живо уберать мусор с пирса.";
				mp.gui.chat.push("!{Green}[Emma] !{White}В большом городе за большие сиськи стоя не аплодируют. А теперь живо уберать мусор с пирса.");
				pedsaying = needped[1];
				break;
			case 4:	
				pedtext = "Очень слабо и этого не достаточно!";
				mp.gui.chat.push("!{Red}[Emma] !{White}Очень слабо и этого не достаточно!");
				pedsaying = needped[1];
				break;
			case 5:	
				pedtext = "Там еще есть что уберать, живо назад!";
				mp.gui.chat.push("!{Red}[Emma] !{White}Там еще есть что уберать, живо назад!");
				pedsaying = needped[1];
				break;
			case 6:	
				mp.gui.chat.push("!{Gray}[Подсказка] Думаю, достаточно.");
				pedtimer = false;
				break;
			case 7:	
				pedtext = "Так быстро? Ну теперь запахло свежестью!";
				pedtext2 = "Держи пару баксов в знак благодарности. Слушай...";
				mp.gui.chat.push("!{Yellow}[Emma] !{White}Так быстро? Ну теперь запахло свежестью! Держи пару баксов в знак благодарности. Слушай...");
				pedsaying = needped[1];
				setTimeout(function() { pedtimer = false; mp.events.call("ChatPyBed", 8); }, 6100);
				break;
			case 8:	
				pedtext = "Знаю, нужны деньги, Бери велосипед и езжай под мост.";
				pedtext2 = "Вот тебе примерное местоположение.";
				mp.gui.chat.push("!{Yellow}[Emma] !{White}Знаю, нужны деньги, Бери велосипед и езжай под мост. Вот тебе примерное местоположение.");
				pedsaying = needped[1];
				mp.events.call("createWaypoint", -521.0117, -1503.451);
				break;
			case 9:	
				pedtext = "Мне больше не чего тебе предложить";
				pedtext2 = "Постарайся занятся другими делами!";
				mp.gui.chat.push("!{Green}[Bony] !{White}В штате полно работ, начни уже зарабатывать");
				pedsaying = needped[0];
				break;
			case 10:	
				pedtext = "Буду краток, чтобы тебе заработать бабок!";
				pedtext2 = "Сгоняй за пивом, что-то жарковато...";
				mp.gui.chat.push("!{Orange}[Frank] !{White}Буду краток, чтобы тебе заработать бабок! Сгоняй за пивом, что-то жарковато...");
				pedsaying = needped[2];
				if(variation == 0) setTimeout(function() { pedtimer = false; mp.events.call("ChatPyBed", 11); }, 6100);
				else if(variation == 1) setTimeout(function() { pedtimer = false; mp.events.call("ChatPyBed", 12); }, 6100);
				break;
			case 11:	
				pedtext = "Ну рас такое дело, почему бы и нет?";
				pedtext2 = "Это тебе на пахавать и на носки.";
				mp.gui.chat.push("!{Orange}[Frank] !{White}Ну рас такое дело, почему бы и нет? Это тебе на пахавать и на носки.");
				pedsaying = needped[2];
				break;
			case 12:	
				pedtext = "В общем сгоняй за пивом,";
				pedtext2 = "а Я пока придумаю тебе работенку...";
				mp.gui.chat.push("!{Orange}[Frank] !{White}В общем сгоняй за пивом, а Я пока придумаю тебе работенку...");
				pedsaying = needped[2];
				mp.events.call("createWaypoint", -639.8232, -1288.375);
				break;
			case 13:	
				pedtext = "(Бульк-Бульк...) Ух! Спасибо...";
				pedtext2 = "В общем слушай, Я нашел тебе работенку...";
				mp.gui.chat.push("!{Orange}[Frank] !{White}(Бульк-Бульк...) Ух! Спасибо... В общем слушай, Я нашел тебе работенку...");
				pedsaying = needped[2];
				break;
			case 14:	
				pedtext = "Ок! Смотрю ты не белоручка!";
				pedtext2 = "Видешь те ящики? Их нужно убрать с пути!";
				mp.gui.chat.push("!{Orange}[Frank] !{White}Ок! Смотрю ты не белоручка! Видешь те ящики? Их нужно убрать с пути!");
				pedsaying = needped[2];
				mp.events.call("createWaypoint", -523.7624, -1520.044);
				break;
			case 15:	
				pedtext = "Ну что стоишь? Ящики сами себя не передвинут!";
				mp.gui.chat.push("!{Orange}[Frank] !{White}Ну что стоишь? Ящики сами себя не передвинут!");
				pedsaying = needped[2];
				mp.events.call("createWaypoint", -523.7624, -1520.044);
				break;
			case 16:	
				pedtext = "Отдуши, душевно в душу!";
				pedtext2 = "Вот тебе денюшка за твою работу!";
				mp.gui.chat.push("!{Orange}[Frank] !{White}Отдуши, душевно в душу! Вот тебе денюшка за твою работу!");
				pedsaying = needped[2];
				break;
			case 17:	
				pedtext = "Ой нет! С тебя достаточно. Теперь тебе в город!";
				pedtext2 = "Может быть еще встретимся!";
				mp.gui.chat.push("!{Orange}[Frank] !{White}Иди в город, там работа по богаче!");
				pedsaying = needped[2];
				break;
			case 18:	
				pedtext = "Я купил не давно новый смартфон";
				pedtext2 = "и хочу тебя попросить кое-что...";
				mp.gui.chat.push("!{Orange}[Frank] !{White}Я купил не давно новый смартфон и хочу тебя попросить кое-что...");
				pedsaying = needped[2];
				setTimeout(function() { pedtimer = false; mp.events.call("ChatPyBed", 19); }, 6100);
				break;
			case 19:	
				pedtext = "Слетай в ближайщий магазинчик и купи мне SIM-карту,";
				pedtext2 = "прям выручишь меня!";
				mp.gui.chat.push("!{Orange}[Frank] !{White}Слетай в ближайщий магазинчик и купи мне SIM-карту, прям выручишь меня!");
				pedsaying = needped[2];
				mp.events.call("createWaypoint", -707.7335, -914.6592);
				break;
			case 20:	
				pedtext = "У Меня новый смартфон и старая SIM-карта не подходит";
				pedtext2 = "купи мне новую SIM-карту.";
				mp.gui.chat.push("!{Orange}[Frank] !{White}У Меня новый смартфон и старая SIM-карта не подходит купи мне новую SIM-карту.");
				pedsaying = needped[2];
				mp.events.call("createWaypoint", -707.7335, -914.6592);
				break;
			case 21:	
				pedtext = "Ништяк! Теперь могу звонить и разговаривать!";
				pedtext2 = "Кстате, вот тебе бабосик, спасибо!";
				mp.gui.chat.push("!{Orange}[Frank] !{White}Ништяк! Теперь могу звонить и разговаривать! Кстате, вот тебе бабосик, спасибо!");
				pedsaying = needped[2];
				setTimeout(function() { pedtimer = false; mp.events.call("ChatPyBed", 22); }, 6100);
				break;
			case 22:	
				pedtext = "И последняя просьба, отвечаю за слова!";
				pedtext2 = "Моя псина сбежала от меня, найди ее...";
				mp.gui.chat.push("!{Orange}[Frank] !{White}И последняя просьба, отвечаю за слова! Моя псина сбежала от меня, найди ее...");
				pedsaying = needped[2];
				setTimeout(function() { pedtimer = false; mp.events.call("ChatPyBed", 23); }, 6100);
				break;
			case 23:	
				pedtext = "Как найдешь ее, пни по жопе";
				pedtext2 = "пусть бежит назад, шучу! Ах-ха-ха!";
				mp.gui.chat.push("!{Orange}[Frank] !{White}Как найдешь ее, пни по жопе пусть бежит назад, шучу! Ах-ха-ха!");
				pedsaying = needped[2];
				mp.events.call("createWaypoint", -830.1286, -938.4238);
				break;
			case 24:	
				pedtext = "Ну давай же, найди ее!";
				mp.gui.chat.push("!{Orange}[Frank] !{White}Ну давай же, найди ее!");
				pedsaying = needped[2];
				mp.events.call("createWaypoint", -830.1286, -938.4238);
				break;
			case 25:	
				pedtext = "Ту-у-уф! Ну прям отдуши! Держи копеечку!";
				pedtext2 = "Ну а теперь беги сдавать на вождение!";
				mp.gui.chat.push("!{Orange}[Frank] !{White}Ту-у-уф! Ну прям отдуши! Держи копеечку! Ну а теперь беги сдавать на вождение!");
				pedsaying = needped[2];
				mp.events.call("createWaypoint", -302.1545, -927.6508);
				break;
		}
		if(pedtimer == true) {
			if(pedtext2 == null) setTimeout(function() { pedsaying = null; pedtext = ""; pedtimer = false; }, 3000);
			else setTimeout(function() { pedsaying = null; pedtext = ""; pedtext2 = null; pedtimer = false; }, 6000);
		}
	} catch (e) { }
});