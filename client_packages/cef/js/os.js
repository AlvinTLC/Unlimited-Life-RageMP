var App = null;
var Home = null;
var Back = null;
var Items = {};
var Lists = [];
var IND = 0;

let removeMainMenu = () => {
    let element = document.querySelector('.screen');
    if (element) {
        element.parentNode.removeChild(element);
    };
}

let addMainMenu = () => {
    removeMainMenu();

    var d = document.createElement("div");
    d.classList.add("screen");
    
    let localDateTime = getLocaDateTime();
    d.innerHTML = `
    <div class="screen">
        <img src="package://cef/phoneRefresh/bg.jpg">
        <h2 id="time">
        </h2>

        <ul class="icon-list icons-list-top">
            <li class="empty" style="opacity: 0; cursor: default; list-style-image: url(package://cef/phoneRefresh/DontModify.png);"><i class="" aria-hidden="true"></i></li>
            <li class="empty" style="opacity: 0; cursor: default; list-style-image: url(package://cef/phoneRefresh/DontModify.png);"><i class="" aria-hidden="true"></i></li>
            <li class="empty" style="opacity: 0; cursor: default; list-style-image: url(package://cef/phoneRefresh/DontModify.png);"><i class="" aria-hidden="true"></i></li>
        </ul>
        <ul class="icon-list icons-list-1">
            <li class="empty" style="opacity: 0; cursor: default; list-style-image: url(package://cef/phoneRefresh/DontModify.png);"><i class="" aria-hidden="true"></i></li>
            <li class="empty" style="opacity: 0; cursor: default; list-style-image: url(package://cef/phoneRefresh/DontModify.png);"><i class="" aria-hidden="true"></i></li>
            <li class="empty" style="opacity: 0; cursor: default; list-style-image: url(package://cef/phoneRefresh/DontModify.png);"><i class="" aria-hidden="true"></i></li>
        </ul>
        <ul class="icon-list icons-list-2">
            <li class="empty" style="opacity: 0; cursor: default; list-style-image: url(package://cef/phoneRefresh/DontModify.png);"><i class="" aria-hidden="true"></i></li>
            <li class="empty" style="opacity: 0; cursor: default; list-style-image: url(package://cef/phoneRefresh/DontModify.png);"><i class="" aria-hidden="true"></i></li>
            <li class="empty" style="opacity: 0; cursor: default; list-style-image: url(package://cef/phoneRefresh/DontModify.png);"><i class="" aria-hidden="true"></i></li>
        </ul>
        <ul class="icon-list icons-list-3">
            <li class="empty" style="opacity: 0; cursor: default; list-style-image: url(package://cef/phoneRefresh/DontModify.png);"><i class="" aria-hidden="true"></i></li>
            <li class="empty" style="opacity: 0; cursor: default; list-style-image: url(package://cef/phoneRefresh/DontModify.png);"><i class="" aria-hidden="true"></i></li>
            <li class="empty" style="opacity: 0; cursor: default; list-style-image: url(package://cef/phoneRefresh/DontModify.png);"><i class="" aria-hidden="true"></i></li>
        </ul>

        <ul class="icon-list icons-list-bottom">

        </ul>



    </div>
    `;
    document.getElementsByClassName("mobile")[0].appendChild(d)

    // Set localtime
    let time = document.querySelector("#time");
    time.innerHTML = `
        ${localDateTime[0]}
        
        <span></span><br>
        <span id="date">${localDateTime[1]}</span>
    `;
}

let getLocaDateTime = () => {
    let now = new Date(Date.now());
    let month = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
    month = month[now.getMonth()];
    let minutes = now.getMinutes();
    let hours = now.getHours();
    if (minutes < 10) {
        minutes = "0" + minutes;
    }
    if (hours < 10) {
        hours = "0" + hours;
    }
    return [`${hours}:${minutes}`, `${now.getDate()}th ${month}, ${now.getFullYear()}`];
};
let updateDateTime = (day, month, year, hour, minute) => {
    let months = ["", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
    let time = document.querySelector("#time");
    if (minute < 10) {
        minute = "0" + minute;
    }
    if (hour < 10) {
        hour = "0" + hour;
    }

    if (time) {
        time.innerHTML = `
            ${hour}:${minute}
            
            <span></span><br>
            <span id="date">${day}th ${months[month]}, ${year}</span>
        `;
    }
}


function open(id, canhome, canback, data) {
    if (id === 'mainmenu') {
        $('.phone-screen').attr("hidden", true);

        addMainMenu();
        setTimeout(() => {
            $('.screen').toggleClass('active');
        }, 700);  
        
        
        reset();
        App = id;
        Home = canhome;
        Back = canback;
        if (Back == false) $('.back').addClass('disabled');
        if (Home == false) $('.home').addClass('disabled');
        $('.debug').append(id);
        var json = JSON.parse(data);
        json.forEach(function (item, i, arr) {
            switch (item[2]) {
                case 0:
                    break;
                case 1:
                    //addHeader(item[0], i, item[1], item[4], item[3]);
                    break;
                case 2:
                    //addCard(item[0], i, item[1], item[4], item[3]);
                    break;
                case 3:
                    addIcon(item[0], i, item[1], item[4], item[5]);
                    break;
                case 4:
                    //addCheck(item[0], i, item[4], item[6]);
                    break;
                case 5:
                    //addInput(item[0], i, item[1]);
                    break;
                case 6:
                    //addList(item[0], i, JSON.stringify(item[7]));
                    break;
            }
            IND++;
        });
    } else {
        // Remove main menu screen
        let element = document.querySelector('.screen');
        if (element) {
            element.parentNode.removeChild(element);
        }
        $('.phone-screen').attr("hidden", false);

        reset();
        App = id;
        Home = canhome;
        Back = canback;
        if (Back == false) $('.back').addClass('disabled');
        if (Home == false) $('.home').addClass('disabled');
        $('.debug').append(id);
        var json = JSON.parse(data);
        json.forEach(function (item, i, arr) {
            switch (item[2]) {
                case 0:
                    break;
                case 1:
                    addHeader(item[0], i, item[1], item[4], item[3]);
                    break;
                case 2:
                    addCard(item[0], i, item[1], item[4], item[3]);
                    break;
                case 3:
                    addBtn(item[0], i, item[1], item[4], item[5]);
                    break;
                case 4:
                    addCheck(item[0], i, item[4], item[6]);
                    break;
                case 5:
                    addInput(item[0], i, item[1]);
                    break;
                case 6:
                    addList(item[0], i, JSON.stringify(item[7]));
                    break;
            }
            IND++;
        });
    }

    show();
}
function show() {
    move('.mobile')
        .duration(0)
        .y(100)
        .end(function () {
            move('.mobile')
                .y(0)
                .set('opacity', 1)
                .end();
        });
}
function hide() {
    move('.mobile')
        .y(100)
        .set('opacity', 0)
        .end();
}
// ELEMENTS //
function addHeader(id, index, text, col, color) {
    var pure = "pure-u-";
    var style = "";
    if (col === 1) pure = pure + col;
    else pure = pure + '1-2';
    style = getColor(color);

    var card = '<div id="' + index + '" data-id="' + id + '" class="' + pure + '">\
    <h1 class="'+ style + '">' + text + '</h1></div>';
    $('.main').append(card);
}
function addBtn(id, index, title, col, big) {
    var callback = "call('" + id + "','button');";
    var pure = "pure-u-";
    var style = "button";
    if (col === 1) pure = pure + col;
    else pure = pure + '1-2';
    if (big == true) style = style + " big";

    var btn = '<div id="' + index + '" data-id="' + id + '" class="' + pure + '">\
    <div onClick="'+ callback + '" class="' + style + '">' + title + '</div></div>';
    $('.main').append(btn);
}
function addCard(id, index, text, col, color) {
    var pure = "pure-u-";
    var style = "";
    if (col === 1) pure = pure + col;
    else pure = pure + '1-2';
    style = getColor(color);

    var card = '<div id="' + index + '" data-id="' + id + '" class="' + pure + '">\
    <p class="'+ style + '">' + text + '</p></div>';
    $('.main').append(card);
}
function addInput(id, index, title) {
    var inp = '<div id="' + index + '" data-id="' + id + '" class="pure-u-1">\
    <input type="text" placeholder="'+ title + '"></div>';
    $('.main').append(inp);
}
function addList(id, index, elements) {
    var data = JSON.parse(elements);
    var callback = "call('" + id + "','listSelect');";
    var callLeft = "listChange('" + index + "','left');";
    var callRight = "listChange('" + index + "','right');";
    Lists[index] = data;

    var list = '<div id="' + index + '" data-id="' + id + '" class="pure-u-1"><div class="list">\
    <i class="left flaticon-left-arrow" onClick="'+ callLeft + '"></i>\
    <input id="l0" type="text" value="'+ data[0] + '" onClick="' + callback + '" readonly>\
    <i class="right flaticon-arrowhead-pointing-to-the-right" onClick="'+ callRight + '"></i>\
    </div></div>';
    $('.main').append(list);
}
function addCheck(id, index, col, checked) {
    var pure = "pure-u-";
    var chk = "";
    if (checked) chk = " checked";
    if (col === 1) pure = pure + col;
    else pure = pure + '1-2';
    var callback = "call('" + id + "','checkbox');";

    var box = '<div id="' + index + '" data-id="' + id + '" class="' + pure + '">\
    <input type="checkbox"'+ chk + ' onClick="' + callback + '"></div>';
    $('.main').append(box);
}
// ELEMENTS //
// SPECIAL //
function change(ind, data) {
    var pure = "pure-u-";
    var json = JSON.parse(data);
    if (json[4] === 1) pure = pure + json[4];
    else pure = pure + '1-2';
    var e = $('#' + ind); //main element
    var c = e.children(); //children element
    var style = "";
    if (json[5] == true) style = " big";
    var chk = "";
    if (json[6]) chk = " checked";
    switch (json[2]) {
        case 0:
            break;
        case 1:
            c.removeClass(); c.addClass(getColor(json[3])); c.html(json[1]);
            break;
        case 2:
            e.removeClass(); e.addClass(pure); c.removeClass(); c.addClass(getColor(json[3])); c.html(json[1]);
            break;
        case 3:
            e.removeClass(); e.addClass(pure); c.removeClass(); c.addClass("button" + style); c.html(json[1]);
            break;
        case 4:
            e.removeClass(); e.addClass(pure);
            break;
        case 5:
            c.html(json[1]);
            break;
        case 6:
            break;
    }
}

function listChange(id, btn) {
    var e = $('#' + id);
    //console.log(e);
    var ind = Number(e.children().children()[1].id.substr(1));
    var items = Lists[id];
    //console.log(ind);
    //console.log(items);
    if (btn == 'right') {
        if (ind + 1 < items.length) ind++;
    } else {
        if (ind - 1 >= 0) ind--;
    }
    e.children().children()[1].value = items[ind];
    e.children().children()[1].id = "l" + ind;
    call(e[0].dataset.id, 'listChange' + btn);
}

function getColor(id) {
    var Color = "";
    switch (id) {
        case 0: break;
        case 1: Color = " red"; break;
        case 2: Color = " green"; break;
        case 3: Color = " blue"; break;
        case 4: Color = " yellow"; break;
        case 5: Color = " orange"; break;
        case 6: Color = " teal"; break;
        case 7: Color = " cyan"; break;
        case 8: Color = " lime"; break;
    }
    return Color;
}
function getData() {
    var data = {};
    if (App !== 'mainmenu') {
        for (var i = 0; i <= IND - 1; i++) {
            var element = $('#' + i);//getting by index
            var id = element.get(0).id;//element id
            //console.log(element);
            var child = element.children();//child with data
            if (child.get(0).tagName === "INPUT") {
                if (child.attr("type") === "checkbox") {
                    data[id] = child.prop("checked"); //checkbox state
                } else {
                    data[id] = child.val();//textarea value
                }
            }
            else if (child.get(0).tagName === "DIV") {
                if (child[0].className !== "list") continue;
                var lst = {};//list data arr
                lst["Index"] = Number(child.children().get(1).id.substr(1));//index of selected item
                lst["Value"] = child.children().get(1).value;//list value
                data[id] = lst;
            }
        }
    }
    return JSON.stringify(data);
}

function reset() {
    $('.debug').html("AppID: ");
    App = null;
    Close = null;
    Items = {};
    Lists = [];
    IND = 0;
    $('.main').empty();
}
function call(id, event) {
    //console.log(id);
    //console.log(event);
    mp.trigger('phoneCallback', id, event, getData());
}

function home() {
    if (!Home) return;
    mp.trigger('phoneNavigation', 'home');
}
function back() {
    if (!Back) return;
    mp.trigger('phoneNavigation', 'back');
}
// SPECIAL //

function addIcon(id, index, title, col, big) {
    var callback = "call('" + id + "','button');";


    let newIcon = true;
    var iconImg;
    var icon;
    switch (id) {
        case 'gps':
            icon = 'fas fa-map-marker-alt';
            iconImg = "GPS.png";
            break;
        case 'acceptcall':
            icon = 'fas fa-phone-alt green';
            iconImg = "Anrufe.png";
            break;
        case 'endcall':
            icon = 'fas fa-phone-slash red';
            iconImg = "Reject.png";
            break;
        case 'contacts':
            icon = 'fas fa-address-book';
            iconImg = "Kontakte.png";
            break;
        case 'services':
            icon = 'fas fa-mobile-alt';
            iconImg = "Emergency.png";
            break;
        case 'biz':
            icon = 'fas fa-briefcase';
            iconImg = "Shop.png";
            break;
        case 'frac':
            icon = 'fas fa-users';
            iconImg = "Fraktion.png";
            break;
        case 'citymanage':
            icon = 'fas fa-city';
            iconImg = "City.png";
            break;
        case 'hotel':
            icon = 'fas fa-hotel';
            iconImg = "Hotel.png";
            break;
        case 'promo':
            icon = 'fas fa-dollar-sign';
            break;
        case 'house':
            icon = 'fas fa-home';
            iconImg = "Haus.png";
            break;
        case 'openhouse':
            icon = 'fas fa-lock';
            iconImg = "Lock.png";
            break;
        case 'leavehouse':
            icon = 'fas fa-lock-open';
            iconImg = "Exit.png";
            break;
        case 'ad':
            icon = 'fas fa-ad';
            iconImg = "WeazelNews.png";
            break;
    }

    if (newIcon) {
        var iconElement = `
             <li style="list-style-image: url(package://cef/phoneRefresh/${iconImg});" id='${index}' data-id='${id}' onClick="${callback}" ><i class="" aria-hidden="true"></i></li>
        `;
    } else {
        var iconElement = `
             <li id='${index}' data-id='${id}' onClick="${callback}" ><i class="${icon}" aria-hidden="true"></i></li>
        `;
    }

    // <li><i class="fa fa-comment-o" aria-hidden="true"></i></li>
    // <li><i class="fa fa-picture-o" aria-hidden="true"></i></li>
    // <li><i class="fa fa-camera" aria-hidden="true"></i></li>        
    

    let bottomRow = 3;
    let selectIconsListClass = (row) => {
        if (row > bottomRow) {
            return '.icons-list-bottom';
        }

        let iconsListClass;

        if (row == 0) {
            iconsListClass = '.icons-list-top';
        } else if (row == 1) {
            iconsListClass = '.icons-list-1';
        } else if (row == 2) {
            iconsListClass = '.icons-list-2';
        } else if (row == 3) {
            iconsListClass = '.icons-list-3';
        } else {
            iconsListClass = '.icons-list-bottom';
        }


        let emptyIconsCount = 0;
        let icons = document.querySelector(iconsListClass).children;
        for (let i = 0; i < icons.length; i++) {
            let li = icons[i];
            if (li.classList.contains("empty")) {
                emptyIconsCount++;
            }
        }

        if (emptyIconsCount === 0 && row < bottomRow) {
            row++;
            return selectIconsListClass(row);
        } else {
            return iconsListClass;
        }
    };

    //

    let iconsListClass = selectIconsListClass(col);
    if (iconsListClass) {
        let icons = document.querySelector(iconsListClass).children;
        let emptyIconsRemoved = 0;
        
        [...icons].forEach(li => {
            if (li.classList.contains("empty")) {
                var trElement = li.parentNode;
                trElement.removeChild(li);
                emptyIconsRemoved++;
            }
        });
        
        $(iconsListClass).append(iconElement);

        for (let i = 0; i < emptyIconsRemoved - 1; i++) {
            $(iconsListClass).append(`<li class="empty" style="opacity: 0; cursor: default; list-style-image: url(package://cef/phoneRefresh/DontModify.png);"><i class="" aria-hidden="true"></i></li>`);
        }
    }
}

$('.bottom').click(function(){
    if (App === 'mainmenu') {
        $('.screen').toggleClass('active');
        mp.trigger('phoneHide');
    } else {
        mp.trigger('phoneNavigation', 'home');
    }
})