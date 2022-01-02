/*
 *
 *	@LEAKED: 	Ultimate-G
 *	@Date:		06.10.2019
 *
 *  
*/
function StartInjury() {
    if ($("button#counter").hasClass("hidden")) {
        $("button#counter").removeClass("hidden");
    }

    if (!$("button#selection").hasClass("hidden")) {
        $("button#selection").addClass("hidden");
    }

    var counter = 0;
    var intervalFunction = setInterval(function () {
        $("h1#progressText").html(counter + "%");
        $("hr#progressBar").css("width", counter + "%");
        counter++;

        if (counter == 100) {
            $("div#counter").addClass("hidden");
            $("div#selection").removeClass("hidden");
            clearInterval(intervalFunction);
        }
    }, 6000);// 10 Min [6000]
}

function UpdateInjury(injury) {
    $("p#injury").html(injury);
}

function UpdateMedicStates(waitText, waitEnable, emergencyEnable) {
    // Warten "Text ändern"
    $("button#waiting").html(waitText);

    // Warten "aktiv"
    if (waitEnable) {
        if ($("button#waiting").hasClass("hidden")) {
            $("button#waiting").removeClass("hidden");
        }
    }
    // Warten "inaktiv"
    else {
        if (!$("button#waiting").hasClass("hidden")) {
            $("button#waiting").addClass("hidden");
        }
    }

    // Notfall "aktiv"
    if (emergencyEnable) {
        if ($("button#emergency").hasClass("hidden")) {
            $("button#emergency").removeClass("hidden");
        }
    }
    // Notfall "inaktiv"
    else {
        if (!$("button#emergency").hasClass("hidden")) {
            $("button#emergency").addClass("hidden");
        }
    }
}

$(function () {
    $("button#waiting").click(function () {
        StartInjury(3000);// 5 Minuten [3000]
    });

    $("button#emergency").click(function () {
        mp.trigger('DeathEnd');
    });
});