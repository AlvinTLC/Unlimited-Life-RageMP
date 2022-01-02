$(document).ready(() => {
    window.voiceAPI = {
        on: () => {
            $(".hud-wrapper .microphone").addClass("active");
        },
        off: () => {
            $(`.hud-wrapper .microphone`).removeClass(`active`);
        }
    };
});
