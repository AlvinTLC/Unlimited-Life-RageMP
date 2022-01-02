var authenticationApp = new Vue({
    el: '#authenticationApp',
    data: {
        showedwelcome: 0,
        curselector: -1,
        cursex: -1,
        result_icon: "img/authentication/result_err.png",
        result_text: "",
        result_button: ""
    },
    methods: {
        setSelector: function(selector) {
            if (!selector) {
				document.getElementsByClassName("registration")[0].style.display = "none";
				document.getElementsByClassName("authentication")[0].style.display = "block";
            } else {
				document.getElementsByClassName("authentication")[0].style.display = "none";
				document.getElementsByClassName("registration")[0].style.display = "block";
            }
        },
        /*setSex: function(selector) {
              if(!selector) {

                  if(authenticationApp.$data.cursex !== 0) {
                      var list = $(".sex-block");
                      list[1].classList.add("sex-block-active");
                      list[0].classList.remove("sex-block-active");

                      authenticationApp.$data.cursex = 0;
                  }
              }
              else {
                  if(authenticationApp.$data.cursex !== 1) {
                      var list = $(".sex-block");
                      list[1].classList.remove("sex-block-active");
                      list[0].classList.add("sex-block-active");

                      authenticationApp.$data.cursex = 1;
                  }
              }
        },*/
        showRecoveryScreen: function() {
            $(".select,.login,.registration,.confirmEmail").fadeOut(500).promise().done(function() {
                $(".recovery").fadeIn(250);
                $(".recovery .email").focus();
            });
        },
        hideRecoveryScreen: function() {

            $(".recovery").fadeOut(500).promise().done(function() {
                $(".select,.login").fadeIn(250);
            });
        },
        hideRecoveryResultScreen: function() {

            $(".recovery-result").fadeOut(500).promise().done(function() {
                $(".select,.login").fadeIn(250);
            });
        },
        hideGoogleAuthScreen: function() {

            $(".google").fadeOut(500).promise().done(function() {
                $(".select,.login").fadeIn(250);
            });
        },
        hidePinCodeScreen: function() {
            $(".pincode").fadeOut(500).promise().done(function() {
                $(".select,.login").fadeIn(250);
            });
        },
        showConfirmEmail: function() {
            sendEmailCode();
            initConfirmEmailHandler();
            $(".select,.login,.registration").fadeOut(500).promise().done(function() {
                $(".confirmEmail").fadeIn(250);
                $(".confirmEmail .code").focus();
            });
        },
        showAuthAccount: function() {
			$(".select").fadeIn(1);
			authenticationApp.setSelector(0);
			$(".authentication .auth .loginOrEmail").focus();
        },
    }
});

authenticationApp.setSelector(0);

// Global function
function showAuthenticationScreen() {
    if (authenticationApp.$data.showwelcometest) return;
    authenticationApp.$data.showwelcometest = 1;

    $(".authentication").fadeIn(1);
    $(".authentication .login .loginOrEmail").focus();
}

function hideAuthenticationScreen() {
    $(".authentication").fadeOut(400);
}

function showRecoveryResultScreen(error, message, button) {

    if (error) authenticationApp.$data.result_icon = "img/authentication/result_err.png";
    else authenticationApp.$data.result_icon = "img/authentication/result_ok.png";

    authenticationApp.$data.result_text = message;
    authenticationApp.$data.result_button = button;

    $(".select,.login").fadeOut(500).promise().done(function() {
        $(".recovery-result").fadeIn(250);
    });
}

// Адаптация
function scaling() {
	let defaultHeight = 1080;
	let currentHeight = window.innerHeight;
	let scaleCoeff = currentHeight / defaultHeight;
	/*let containers = [
		'#authenticationApp',
		'.choiceMenu #notification',
		'#castomMenu #customizer',
		'#selectorCharacters #charSelect', 
		'#houseMenu #house',
		'#houseMenu #house_sync',
		'.car-showroom-wrapper #carShowroomSwitcher',
		'.car-showroom-wrapper #carShowroomSpecs',
		'.ipad-wrapper #ipad',
		'.online-list-wrapper #online',
		'.hud-wrapper #rightTop',
		'.hud-wrapper #rightBottom',
		'.hud-wrapper #leftBottom'];
	for (let i = 0; i < containers.length; i++) {
		let container = document.querySelector(containers[i]);
		if (container) container.style.transform = `scale(${scaleCoeff})`;
	}*/
	document.documentElement.style.setProperty('--scaling-coeff', scaleCoeff); // Адаптация инвентаря и всего документа
}

window.onload = () => {
	scaling();
};

window.onresize = () => {
	scaling();
};


/*
 * '.hud-wrapper #rightTop', '.hud-wrapper #rightBottom', '.hud-wrapper #leftBottom'*/