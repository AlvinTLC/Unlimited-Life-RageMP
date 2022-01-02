function myFunction() {
			  var checkBox = document.getElementById("cb3");
			  var ipad = document.getElementById("ipadVis");
			  if (checkBox.checked == true){
				ipad.style.display = "block";
				mp.trigger('donate2', 3);
				mp.trigger('board2', 4);
			  } else {
				 ipad.style.display = "none";
				 mp.trigger('board2', 3);
				 mp.trigger('donate2', 2);
			  }
			}