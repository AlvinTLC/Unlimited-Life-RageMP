//global.DB = require('mysql2');
//global.DB = require('./DB');

//var DB = require('mysql2');
var mysql = require('mysql');

mp.events.add('server:animations:getNames',(player)=>{
    //console.log('Ani Request')
    player.call('getAniNames',([player.data.numpad1Name,player.data.numpad2Name,player.data.numpad3Name,player.data.numpad4Name,player.data.numpad5Name,player.data.numpad6Name,player.data.numpad7Name,player.data.numpad8Name,player.data.numpad9Name ]))
})

mp.events.add("server:animations:numpad0", (player) => {
    player.stopAnimation();
    player.data.ergeben = 0;
});
mp.events.add("server:animations:numpad1", (player) => {
    player.playAnimation(player.data.numpad1A,player.data.numpad1B,player.data.numpad1C,player.data.numpad1D);
    player.notify("Animation: " + player.data.numpad1Name);//es
});
mp.events.add("server:animations:numpad2", (player) => {
    player.playAnimation(player.data.numpad2A,player.data.numpad2B,player.data.numpad2C,player.data.numpad2D);
    player.notify("Animation: " + player.data.numpad2Name);
});
mp.events.add("server:animations:numpad3", (player) => {
    player.playAnimation(player.data.numpad3A,player.data.numpad3B,player.data.numpad3C,player.data.numpad3D);
    player.notify("Animation: " + player.data.numpad3Name);
});
mp.events.add("server:animations:numpad4", (player) => {
    player.playAnimation(player.data.numpad4A,player.data.numpad4B,player.data.numpad4C,player.data.numpad4D);
    player.notify("Animation: " + player.data.numpad4Name);
});
mp.events.add("server:animations:numpad5", (player) => {
    player.playAnimation(player.data.numpad5A,player.data.numpad5B,player.data.numpad5C,player.data.numpad5D);
    player.notify("Animation: " + player.data.numpad5Name);
});
mp.events.add("server:animations:numpad6", (player) => {
    player.playAnimation(player.data.numpad6A,player.data.numpad6B,player.data.numpad6C,player.data.numpad6D);
    player.notify("Animation: " + player.data.numpad6Name);
});
mp.events.add("server:animations:numpad7", (player) => {
    player.playAnimation(player.data.numpad7A,player.data.numpad7B,player.data.numpad7C,player.data.numpad7D);
    player.notify("Animation: " + player.data.numpad7Name);
});
mp.events.add("server:animations:numpad8", (player) => {
    player.playAnimation(player.data.numpad8A,player.data.numpad8B,player.data.numpad8C,player.data.numpad8D);
    player.notify("Animation: " + player.data.numpad8Name);
});
mp.events.add("server:animations:numpad9", (player) => {
    player.playAnimation(player.data.numpad9A,player.data.numpad9B,player.data.numpad9C,player.data.numpad9D);
    player.notify("Animation: " + player.data.numpad9Name);
});

mp.events.add("server:shortcut:save",(player,name,id,p1,p2,p3,p4) => {
    console.log('player.name'+player.name+' name:'+name+' id:'+id+' p1:'+p1+' p2:'+p2+' p3:'+p3+' p4:'+p4)
    if (id == 1) {
        mysql.Handle.query("UPDATE shortcuts SET num1animA = ?,num1animB = ?,num1animC = ?,num1animD = ?, num1name = ? WHERE name = ?", [p1,p2,p3,p4,name,player.name],function(err,res) {
            if (err) console.log("Error in Update Shorcuts: "+err);
            player.data.numpad1A = p1;
            player.data.numpad1B = p2;
            player.data.numpad1C = p3;
            player.data.numpad1D = p4;
            player.data.numpad1Name = name;
        });
    }
    if (id == 2) {
        mysql.Handle.query("UPDATE shortcuts SET num2animA = ?,num2animB = ?,num2animC = ?,num2animD = ?, num2name = ? WHERE name = ?", [p1,p2,p3,p4,name,player.name],function(err,res) {
            if (err) console.log("Error in Update Shorcuts: "+err);
            player.data.numpad2A = p1;
            player.data.numpad2B = p2;
            player.data.numpad2C = p3;
            player.data.numpad2D = p4;
            player.data.numpad2Name = name;
        });
    }
    if (id == 3) {
        mysql.Handle.query("UPDATE shortcuts SET num3animA = ?,num3animB = ?,num3animC = ?,num3animD = ?, num3name = ? WHERE name = ?", [p1,p2,p3,p4,name,player.name],function(err,res) {
            if (err) console.log("Error in Update Shorcuts: "+err);
            player.data.numpad3A = p1;
            player.data.numpad3B = p2;
            player.data.numpad3C = p3;
            player.data.numpad3D = p4;
            player.data.numpad3Name = name;
        });
    }
    if (id == 4) {
        mysql.Handle.query("UPDATE shortcuts SET num4animA = ?,num4animB = ?,num4animC = ?,num4animD = ?, num4name = ? WHERE name = ?", [p1,p2,p3,p4,name,player.name],function(err,res) {
            if (err) console.log("Error in Update Shorcuts: "+err);
            player.data.numpad4A = p1;
            player.data.numpad4B = p2;
            player.data.numpad4C = p3;
            player.data.numpad4D = p4;
            player.data.numpad4Name = name;
        });
    }
    if (id == 5) {
        mysql.Handle.query("UPDATE shortcuts SET num5animA = ?,num5animB = ?,num5animC = ?,num5animD = ?, num5name = ? WHERE name = ?", [p1,p2,p3,p4,name,player.name],function(err,res) {
            if (err) console.log("Error in Update Shorcuts: "+err);
            player.data.numpad5A = p1;
            player.data.numpad5B = p2;
            player.data.numpad5C = p3;
            player.data.numpad5D = p4;
            player.data.numpad5Name = name;
        });
    }
    if (id == 6) {
        mysql.Handle.query("UPDATE shortcuts SET num6animA = ?,num6animB = ?,num6animC = ?,num6animD = ?, num6name = ? WHERE name = ?", [p1,p2,p3,p4,name,player.name],function(err,res) {
            if (err) console.log("Error in Update Shorcuts: "+err);
            player.data.numpad6A = p1;
            player.data.numpad6B = p2;
            player.data.numpad6C = p3;
            player.data.numpad6D = p4;
            player.data.numpad6Name = name;
        });
    }
    if (id == 7) {
        mysql.Handle.query("UPDATE shortcuts SET num7animA = ?,num7animB = ?,num7animC = ?,num7animD = ?, num7name = ? WHERE name = ?", [p1,p2,p3,p4,name,player.name],function(err,res) {
            if (err) console.log("Error in Update Shorcuts: "+err);
            player.data.numpad7A = p1;
            player.data.numpad7B = p2;
            player.data.numpad7C = p3;
            player.data.numpad7D = p4;
            player.data.numpad7Name = name;
        });
    }
    if (id == 8) {
        mysql.Handle.query("UPDATE shortcuts SET num8animA = ?,num8animB = ?,num8animC = ?,num8animD = ?, num8name = ? WHERE name = ?", [p1,p2,p3,p4,name,player.name],function(err,res) {
            if (err) console.log("Error in Update Shorcuts: "+err);
            player.data.numpad8A = p1;
            player.data.numpad8B = p2;
            player.data.numpad8C = p3;
            player.data.numpad8D = p4;
            player.data.numpad8Name = name;
        });
    }
    if (id == 9) {
        mysql.Handle.query("UPDATE shortcuts SET num9animA = ?,num9animB = ?,num9animC = ?,num9animD = ?, num9name = ? WHERE name = ?", [p1,p2,p3,p4,name,player.name],function(err,res) {
            if (err) console.log("Error in Update Shorcuts: "+err);
            player.data.numpad9A = p1;
            player.data.numpad9B = p2;
            player.data.numpad9C = p3;
            player.data.numpad9D = p4;
            player.data.numpad9Name = name;
        });
    }
});