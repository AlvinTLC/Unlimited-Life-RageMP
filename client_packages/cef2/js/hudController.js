$(document).ready(function () {
	window.hudController = new Vue({
		el: '.hud-wrapper',
		data: {
			money: 0,
			bank: 0,
			online: 0
		},
		methods: {
			enable(open) {
				if (open)
					$(".hud-wrapper").css("display", "flex");
				else
					$(".hud-wrapper").css("display", "none");
			},
			discrip() {
				const help = document.querySelector('.hud-wrapper #rightBottom .container');
				const helpContent = document.querySelector('.hud-wrapper #rightBottom .content');
				help.classList.toggle('active');
				helpContent.classList.toggle('hidden');
			}
		}
	});
});