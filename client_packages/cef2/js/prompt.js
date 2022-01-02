$(document).ready(() => {
    const SHOW_TIME = 10000;

    var prompts = {
        "select_menu": {
            text: "Используйте <span>&uarr;</span> <span>&darr;</span> <span>&crarr;</span> для выбора пункта в меню.",
            showTime: 60000
        },
        "vehicle_engine": {
            text: "Нажмите <span>2</span>, чтобы завести двигатель автомобиля."
        },
        "vehicle_repair": {
            text: "Автомобиль поломался. Необходимо вызвать механика."
        },
        "choiceMenu_help": {
            text: "Используйте клавиши <span>y</span> и <span>n</span>",
            header: "Диалог предложения",
        },
        "documents_help": {
            text: "Нажмите <span>e</span> для закрытия",
            header: "Документы",
        },
        "health_help": {
            text: "Приобрести медикаменты можно в больнице.",
            header: "Лечение",
        },
        "police_service_recovery_carkeys": {
            text: "Вызовите службу, чтобы пригнать авто к участку.",
            header: "Восстановление ключей",
        },
        "band_zones_attack_win": {
            text: "Влияние Вашей группировки увеличилось!",
            header: "Гетто",
        },
        "band_zones_attack_lose": {
            text: "Вашей группировке не удалось увеличить влияние!",
            header: "Гетто",
        },
        "band_zones_defender_win": {
            text: "Ваша группировка отстояла территорию!",
            header: "Гетто",
        },
        "band_zones_defender_lose": {
            text: "Влияние Вашей группировки уменьшилось!",
            header: "Гетто",
        },
    }

    window.promptAPI = {
        showByName: (name, eventId) => {
            /*var info = prompts[name];
            if (!info) return;
            var showTime = SHOW_TIME;
            if (info.showTime) showTime = info.showTime;

            promptAPI.show(info.text, info.header, showTime, eventId);*/
        },
        show: (text, header = "Подсказка", showTime = SHOW_TIME, eventId) => {
            /*$(".prompt .header").text(header);
            $(".prompt .text").html(text);

            if (chatAPI.isLeft()) {
                $('.prompt').css('left', '');
                $('.prompt').css('top', '1vh');
                $('.prompt').css('right', '1vh');
                $('.prompt').css('bottom', '');
            } else {
                $('.prompt').css('bottom', '');
                $('.prompt').css('left', '1vh');
                $('.prompt').css('top', '1vh');
                $('.prompt').css('right', '');
                $('.prompt').css('bottom', '');
            }

            var height = Math.abs(parseFloat($(".prompt .header").height()) + parseFloat($(".prompt .text").height()));
            $(".prompt .body").height(height);

            $(".prompt").slideDown("fast");

            if (eventId != -1) {
                setTimeout(() => {
                    promptAPI.hide();
                }, showTime);
            }*/
        },
        hide: () => {
            /*$(".prompt").slideUp("fast");*/
        }
    };
});
