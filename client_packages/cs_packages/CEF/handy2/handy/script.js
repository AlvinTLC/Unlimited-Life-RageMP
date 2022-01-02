$( document ).ready(function() {
    startTime();
});
    
    function startTime() {
        var today = new Date();
        var h = today.getHours();
        var m = today.getMinutes();
        m = checkTime(m);
        document.getElementById('time').innerHTML =
        h + ":" + m;
        var t = setTimeout(startTime, 500);
    }
    function checkTime(i) {
        if (i < 10) {i = "0" + i};
        return i;
    }

    function startTime2() {
        var today = new Date();
        var h = today.getHours();
        var m = today.getMinutes();
        m = checkTime(m);
        document.getElementById('timeb').innerHTML =
        h + ":" + m;
        var t = setTimeout(startTime, 500);
        setTimeout(function(){ startTime2() }, 1000);
    }
    function checkTime(i) {
        if (i < 10) {i = "0" + i};
        return i;
    }
function smHide(){
    var e = e || window.event;
    if(e.which == 38) {
        var element = document.getElementsByClassName("smartphone")[0];
        document.getElementsByClassName("smartphone")[0].style.transition = "all 1s";
        element.classList.add("down");
    }
}


function smShow(){
    var e = e || window.event;
    if(e.which == 40) {
      var element = document.getElementsByClassName("smartphone")[0];
      element.classList.remove("down");
    }
  }

  var lastClass = "startClass";

  var lastItemName = "";
  var lastItemSrc = "";

  function checkSite(site) {
    if (site === "startClass" || site === "mapClass") {
        document.getElementsByClassName('headerb')[0].style.display = "none";
        document.getElementsByClassName('header')[0].style.display = "block";
    } else {
      document.getElementsByClassName('header')[0].style.display = "none";
      document.getElementsByClassName('headerb')[0].style.display = "block";
      startTime2();
    }
    if (site == "smsClass") {
      var message = document.getElementsByClassName('message')[0].innerHTML;
      var message = (message.slice(0,37))+'...'
      document.getElementsByClassName('message')[0].innerHTML = message;

      var message = document.getElementsByClassName('message')[1].innerHTML;
      var message = (message.slice(0,37))+'...'
      document.getElementsByClassName('message')[1].innerHTML = message;
    }
  }

  function switchSite(site) {
      checkSite(site);
      if (site !== lastClass) {
          var givenClass = document.getElementsByName(site)[0];
          givenClass.classList.remove("hidden");
          document.getElementsByName(lastClass)[0].classList.toggle("hidden");
          lastClass = site;
      }
  }

  function handynumber(number) {
        document.getElementsByName('callingnumber')[0].value = document.getElementsByName('callingnumber')[0].value + '' + number;
        if (document.getElementsByName('callingnumber')[0].value.length > 0) {
            document.getElementsByClassName('telkofav')[0].style.display = "none";
            document.getElementsByClassName('outputnumbers')[0].style.display = "block";
            document.getElementsByClassName('callsettings')[0].style.display = "none";
            document.getElementsByClassName('callback')[0].style.display = "block";
        }

}


function clearonenumber() {
    document.getElementsByName('callingnumber')[0].value = null;
    document.getElementsByName('callingnumber')[0].value = null;
    if (document.getElementsByName('callingnumber')[0].value.length === 0) {
        document.getElementsByClassName('telkofav')[0].style.display = "block";
        document.getElementsByClassName('outputnumbers')[0].style.display = "none";
        document.getElementsByClassName('callsettings')[0].style.display = "block";
        document.getElementsByClassName('callback')[0].style.display = "none";
    }
}

function searchFilter() {
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("searchInput");
    filter = input.value.toUpperCase();
    table = document.getElementById("searchTable");
    tr = table.getElementsByTagName("tr");
    for (i = 0; i < tr.length; i++) {
      td = tr[i].getElementsByTagName("td")[0];
      if (td) {
        txtValue = td.textContent || td.innerText;
        if (txtValue.toUpperCase().indexOf(filter) > -1) {
          tr[i].style.display = "";
        } else {
          tr[i].style.display = "none";
        }
      }       
    }
  }

function showContactAdd() {
  document.getElementsByClassName('contact')[0].style.transition = "all 1s";
  document.getElementsByClassName('contact')[0].style.left = "-16vw";
}

function back1() {
  document.getElementsByClassName('contact')[0].style.transition = "all 1s";
  document.getElementsByClassName('contact')[0].style.left = "0vw";
  document.getElementById('ac-name').value = "";
  document.getElementById('ac-number').value = "";
}

function back2() {
  document.getElementsByClassName('contact')[0].style.transition = "all 1s";
  document.getElementsByClassName('contact')[0].style.left = "0vw";
  document.getElementById('ac-name').value = "";
  document.getElementById('ac-number').value = "";
  alert('Kontakt Hinzugefügt');
}

function back3() {
  document.getElementsByClassName('contact')[0].style.transition = "all 1s";
  document.getElementsByClassName('contact')[0].style.left = "0vw";
  document.getElementsByClassName('sc-name')[0].value = "";
  document.getElementsByClassName('sc-number')[0].value = "";

  document.getElementsByClassName('headerb')[0].style.display = "block";
  document.getElementsByClassName('header')[0].style.display = "none";
}

function showContact(name, number) {
  document.getElementsByClassName('contact')[0].style.transition = "all 1s";
  document.getElementsByClassName('contact')[0].style.left = "15.75vw";
  document.getElementsByClassName('sc-name')[0].innerHTML = name;
  document.getElementsByClassName('sc-number')[0].innerHTML = number;

        document.getElementsByClassName('headerb')[0].style.display = "none";
        document.getElementsByClassName('header')[0].style.display = "block";

      startTime2();
      switchSite('contactClass');
}

function call() {
  document.getElementsByClassName('call')[0].style.transition = "all 1s";
  document.getElementsByClassName('call')[0].style.left = "-17vw";
  document.getElementsByClassName('headerb')[0].style.display = "none";
  document.getElementsByClassName('header')[0].style.display = "block";

  var number = $("input[name=callingnumber]").val();
  document.getElementsByClassName('c-number')[0].innerHTML = number;

  clearonenumber(1);

  startWatch();
}


function callBack() {
  document.getElementsByClassName('call')[0].style.transition = "all 1s";
  document.getElementsByClassName('call')[0].style.left = "0vw";
  document.getElementsByClassName('headerb')[0].style.display = "block";
  document.getElementsByClassName('header')[0].style.display = "none";

  document.getElementsByClassName('c-number')[0].innerHTML = "";

  resetWatch();
  
  mp.trigger("client:rejectCall");

}

var timer = null;
    var min_txt = document.getElementById("minutes");
    var min = Number(min_txt.innerHTML);
    var sec_txt = document.getElementById("seconds");
    var sec = Number(sec_txt.innerHTML);
    function stopTimeMilliseconds(timer) {
        if (timer) { 
            clearInterval(timer);
            return timer;
        }
        else return timer;
    }
    function startTimeMilliseconds() {
        var currDate = new Date();
        return currDate.getTime();	
    }
    function getElapsedTimeMilliseconds(startMilliseconds) {
        if (startMilliseconds > 0) {
            var currDate = new Date();
            elapsedMilliseconds = (currDate.getTime() - startMilliseconds);
            return elapsedMilliseconds;
        }
     else {
        return elapsedMilliseconds = 0;
        }
    }
    function startWatch() { 
        // START TIMER
        timer = stopTimeMilliseconds(timer); 
        var startMilliseconds = startTimeMilliseconds();
        timer = setInterval(function() { 
            var elapsedMilliseconds = getElapsedTimeMilliseconds(startMilliseconds); 
            if (sec < 10) {
                sec_txt.innerHTML = "0" + sec;
            }
            else {
                sec_txt.innerHTML = sec; 
            }
            min_txt.innerHTML = "0" + min; 
            msec = elapsedMilliseconds;
            if (min >= 59 && sec >=59 && msec > 900) {
                timer = stopTimeMilliseconds(timer);
                return true;
            }
            if (sec > 59) {
                sec = 0;
                min++;
            }
            if (msec > 999) {
                msec = 0;
                sec++;
                startWatch();
            }
        }, 10);
    }
    function stopWatch() {
        // STOP TIMER
        timer = stopTimeMilliseconds(timer);
        return true;
    }
    function resetWatch() {
        // REZERO TIMER
        timer = stopTimeMilliseconds(timer);
        sec_txt.innerHTML = "00"; 
        sec = 0;
        min_txt.innerHTML = "00"; 
        min = 0;
        return true;
    }

    function cancelCall() {
      document.getElementsByClassName('getCalled')[0].style.display = "none";
      document.getElementsByClassName('smartphone')[0].style.animation = ""
      document.getElementsByClassName('smartphone')[0].classList.remove('yougetcalled');
      
      // Rage-mp event
      mp.trigger("client:rejectCall");
    }

    function acceptCall() {
      document.getElementsByClassName('smartphone')[0].style.animation = ""
      document.getElementsByClassName('getCalled')[0].style.display = "none";
      document.getElementsByClassName('call')[0].style.transition = "all 1s";
      document.getElementsByClassName('call')[0].style.left = "-17vw";
      document.getElementsByClassName('headerb')[0].style.display = "none";
      document.getElementsByClassName('header')[0].style.display = "block";
      document.getElementsByClassName('smartphone')[0].classList.remove('yougetcalled');
    
      var name = document.getElementsByClassName('gc-name')[0].innerHTML;
      document.getElementsByClassName('c-number')[0].innerHTML = name;

      // Rage-mp event
      mp.trigger("client:answer");
    
      clearonenumber(1);
    
      startWatch();

      switchSite('callClass');
    }

    function getCalled(name) {
        document.getElementsByClassName('getCalled')[0].style.display = "block";
        document.getElementsByClassName('gc-name')[0].innerHTML = name;
        setTimeout(function() {
          document.getElementsByClassName('smartphone')[0].classList.add('yougetcalled');
        }, 500);
    }

    function smsSearch() {
      var input, filter, ul, li, a, i, txtValue;
      input = document.getElementById("smssearch");
      filter = input.value.toUpperCase();
      ul = document.getElementById("smslist");
      li = ul.getElementsByTagName("li");
      for (i = 0; i < li.length; i++) {
          a = li[i].getElementsByTagName("a")[0];
          txtValue = a.textContent || a.innerText;
          if (txtValue.toUpperCase().indexOf(filter) > -1) {
              li[i].style.display = "";
          } else {
              li[i].style.display = "none";
          }
      }
  }

  function showSmsMessages(name, number, list) {
    document.getElementsByClassName('sms')[0].style.transition = "all 0.5s";
    document.getElementsByClassName('sms')[0].style.left = "-15.7vw";
    document.getElementsByClassName('sm-name')[0].innerHTML = name;
    document.getElementsByClassName('sm-number')[0].innerHTML = number;

    var list = "sms-" + list;
    if(list == "sms-1") {
      document.getElementsByClassName('sms-1')[0].style.display = "block";
      document.getElementsByClassName('sms-2')[0].style.display = "none";
    }
    if(list == "sms-2") {
      document.getElementsByClassName('sms-1')[0].style.display = "none";
      document.getElementsByClassName('sms-2')[0].style.display = "block";
    }
  }

  function hideSmsMessages() {
    document.getElementsByClassName('sms')[0].style.transition = "all 0.5s";
    document.getElementsByClassName('sms')[0].style.left = "0vw";
    setTimeout(function() {
      document.getElementsByClassName('sm-number')[0].innerHTML = "";
    },500)
  }
  

  // By Zeki
var messages = []; 
  
function sendMessage(){
	let message = document.getElementById("sm-message").value;
	if (message =="") return;
	let number = document.getElementsByClassName('sm-number')[0].innerHTML;
	if (playerNumber == number) {
        return hideSmsMessages();
    }
	let name = document.getElementsByClassName('sm-name')[0].innerHTML;
	let d = new Date();
	let date = `${d.getDate()}.${d.getMonth()} ${d.getHours()}:${d.getMinutes()}`;
	messages.push({ numberFrom: playerNumber, numberTo: number, message: message, date:date});
	document.getElementById("sm-message").value="";
	showSmsMessages(name,number,number);
}

loadMessages = (messages) => { 
  $("#smslist").text("")
	$.each(messages, function(i, msg) {
			$("#smslist").append(
        `<li><img onclick='showContact(\"${msg.numberFrom}\", \"${msg.numberFrom}\")' class="sms-pb" src="img/contacticon.png">
        <a onclick='showSmsMessages(\"${msg.numberFrom}\", \"${msg.numberFrom}\", \"${i}\")' href="#">
          <div class="name">${msg.numberFrom}</div>
          <div class="message">${msg.message}</div>
        </a>
      </li>` 
			);
  });
}

function addMessage(message) { 
  messages.push(message);
  loadMessages(messages);
}