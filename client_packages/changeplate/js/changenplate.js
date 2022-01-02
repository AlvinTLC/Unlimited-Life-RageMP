var changeplatehtml = new Vue({
    el: ".changeplate",
    data: {
        active: false,
        oldnumber: ["null"],
		money: 1,
    },
    methods: {
		moneys(){
			changeplatehtml.money = 1;
		},
		bank(){
			changeplatehtml.money = 2;
		},
		startchange() {
		document.getElementById("changer").style.display = "block";
		document.getElementById("text").style.display = "none";
		$('#newnumber').on('input', validate);
		function validate(e) {
		  var $item = $(this),
			value = $item.val();
		  var st = new RegExp('[^a-zA-Z0-9]+');
			if (!st.test(value)){
			return true;
		  } else {
			console.log( 'error' );
			document.getElementById('newnumber').value='';
		  }
		}
		},
        finishchange() {
				var newnumber = document.getElementById('newnumber').value
				var dlina = document.getElementById('newnumber').value.length
				if(dlina > 0 && dlina < 4) return;
				var modifynumber = newnumber.toUpperCase()
				//console.log(modifynumber);
				//console.log("Длина " + dlina);
				var moneysystem = changeplatehtml.money;
				mp.trigger('newnumber', modifynumber, moneysystem);
				document.getElementById("changer").style.display = "none";
				document.getElementById('newnumber').value='';
				document.getElementById("text").style.display = "block";
			},
		closebutton(){
			mp.trigger('changer', 1);
		}
    }
});