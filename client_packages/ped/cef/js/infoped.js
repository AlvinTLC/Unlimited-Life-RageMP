function timer(){

    var obj=document.getElementById('button-second');
    var regexp = /(\d+)/i;
    var RealTimer = regexp.exec(obj.innerHTML)[0];

    if (--RealTimer < 0) RealTimer = 0;

    obj.innerHTML = `${RealTimer}`;

    if (RealTimer==0) {
        document.getElementById('button-second').style.display = 'none';
        document.getElementById('button-active').style.display = 'block';
        return
    }
    else { setTimeout(timer,1000); }
}

timer()

function closePed() {
    mp.trigger("closePedInfo")
}