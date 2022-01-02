function wheelrun(){

	let arr=[
	["img/roullete/money1.png",'50.000 $'],//0
	["img/roullete/money1.png",'100.000 $'],//1
	["img/roullete/money1.png",'150.000 $'],//2
	["img/roullete/g65.png",'Автомобиль: g65'],//3
	["img/roullete/c63.png",'Автомобиль: c63coupe'],//4
	["img/roullete/priora.png",'Автомобиль: apriora'],//5
	["img/roullete/e34.png",'Автомобиль: bmwe34'],//6
	["img/roullete/bita.png",'Бита'],//7
	["img/roullete/mask.png",'Маску'],//8
	["img/roullete/level.png",'10 опыта'],//9
	["img/roullete/kost.png",'Костюм'],//10
	["img/roullete/money1.png",'200.000 $'],//11
	["img/roullete/money1.png",'250.000 $'],//12
	["img/roullete/money1.png",'300.000 $'],//13
	["img/roullete/money1.png",'350.000 $'],//14
	["img/roullete/money1.png",'400.000 $'],//15
	["img/roullete/money1.png",'450.000 $'],//16
	["img/roullete/money1.png",'500.000 $']//17
	];
	
			$("body").find('.content').children().removeClass('animate1');
			$("body").find('.run').attr('disable',false);
			let index=Math.floor(Math.random()*18);
			let index1=Math.floor(Math.random()*16);
			let index2=Math.floor(Math.random()*16);
			let index3=Math.floor(Math.random()*16);
			let index4=Math.floor(Math.random()*16);
			let img=arr[index][0];
			let img1=arr[index1][0];
			let img2=arr[index2][0];
			let img3=arr[index3][0];
			let img4=arr[index4][0];
			let prize=arr[index][1];
			let red = Math.floor(Math.random()*255);
			let green = Math.floor(Math.random()*255);
			let blue = Math.floor(Math.random()*255);
			$("body").find('.content').children().addClass('animate');
			$("body").find('#wink').children().remove();
			$("body").find('#wink').append(`<img src=${img}>`);
			$("body").find('#wink1').children().remove();
			$("body").find('#wink1').append(`<img src=${img1}>`);
			$("body").find('#wink2').children().remove();
			$("body").find('#wink2').append(`<img src=${img2}>`);
			$("body").find('#wink3').children().remove();
			$("body").find('#wink3').append(`<img src=${img3}>`);
			$("body").find('#wink4').children().remove();
			$("body").find('#wink4').append(`<img src=${img4}>`);
			$("body").find('#two').children().remove();
			$("body").find('#two').append(`<img src=${img}>`);
					if($("body").find('.content').children().hasClass('animate')){
                        $("body").find('.content').append(`
						<div class='modal-wrap' style='z-index:10000;'>
						<div class='prize'  >
						<div class='bgshow1'></div>
						<h1>Поздравляем</h1>
							<h3>Вы выйграли ${prize}</h3>
							<img src="${img}" class="imgRol">
							<p style="margin-top: -211px;"></p>
							<div class='yes'>Забрать себе</div>
						</div></div>`);
						setTimeout(function(){
                            $("body").find('.prize').fadeIn();
						},12000);
                        $("body").one("click", ".yes", () => {
							
                            $("body").find('.prize').remove();
                            $("body").find('.content').children().removeClass('animate');
                            $("body").find('.content').children().addClass('animate1');
                            $("body").find('.modal-wrap').fadeOut();
                            mp.trigger("wheelAdd", index,true);

                        });
                        $("body").one("click", ".send", () => {
                            $("body").find('.content').children().removeClass('animate');
                            $("body").find('.content').children().addClass('animate1');
                            $("body").find('.modal-wrap').fadeOut();
                            mp.trigger("wheelAdd", index,false);
                        });
				}
}
