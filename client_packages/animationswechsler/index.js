const rpc = require('./rage-rpc.min.js');
/**
 * Title: Animationswechsler
 * Author: NetForceOne - watch me at twitch ;)
 * 
 */


let player = mp.players.local;

var aniBrowser = null;

var numpad1Name = "";
var numpad2Name = "";
var numpad3Name = "";
var numpad4Name = "";
var numpad5Name = "";
var numpad6Name = "";
var numpad7Name = "";
var numpad8Name = "";
var numpad9Name = "";

function newBrowser(){
if(aniBrowser === null ){
    //mp.gui.chat.push('show')
    notifypic('Animationswechsler','~g~Lade...','DIA_CLIFFORD')
    aniBrowser = mp.browsers.new("package://animationswechsler/index.html");
    mp.events.callRemote('server:animations:getNames',player)
    
    mp.gui.cursor.show(true, true);
  }else{
    if(aniBrowser != null){
        //mp.gui.chat.push('hidde')
        notifypic('Animationswechsler','~or~Deaktiviere...','DIA_CLIFFORD')
        aniBrowser.destroy()
        aniBrowser = null;
        mp.gui.cursor.show(false, false);
    }
  }
}


// 0x71 is the F2 key code
mp.keys.bind(0x2D, true, function() {
  
  newBrowser()
});

function notifypic(titel,beschreibung,picName='DIA_CONSTRUCTION'){
  // This function will load the specified texture dictionary.
  loadTextureDictionary(picName);
  mp.game.ui.setNotificationTextEntry("STRING");
  mp.game.ui.setNotificationMessage(picName, picName, false, 4, titel, beschreibung);
  mp.game.ui.drawNotification(true, false);
}

function loadTextureDictionary(textureDict) {
  if (!mp.game.graphics.hasStreamedTextureDictLoaded(textureDict)) {
      mp.game.graphics.requestStreamedTextureDict(textureDict, true);
      while (!mp.game.graphics.hasStreamedTextureDictLoaded(textureDict)) mp.game.wait(0);
  }
}


mp.events.add('getAniNames',(...names) =>{
  //mp.gui.chat.push('names:'+names)
  numpad1Name = names[0]
  numpad2Name = names[1]
  numpad3Name = names[2]
  numpad4Name = names[3]
  numpad5Name = names[4]
  numpad6Name = names[5]
  numpad7Name = names[6]
  numpad8Name = names[7]
  numpad9Name = names[8]

    setAniNames(names)
  
  
})

function setAniNames(names){
  rpc.callBrowser(aniBrowser,'setSlotAniNames',names);
  //mp.gui.chat.push('ja'+names)
}

function setNewAni(item, slotid){
    let p1; 
    let p2;
    let namenAni;
    //mp.gui.chat.push(slotid+'-'+item)
    if (item == "Sitzen (Männl.)") {
       namenAni = item+""
       p1 = '"anim@heists@fleeca_bank@ig_7_jetski_owner"'
       p2 = '"owner_idle"'
      
      mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
      
     } else if (item == "Sitzen (Weibl.)") {namenAni = item+""
       namenAni = item+""
       p1 = '"amb@lo_res_idles@"'
       p2 = '"world_human_picnic_female_lo_res_base"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
           
     } else if (item == "Sitzen (Stuhl)") {namenAni = item+""
       p1 = '"switch@michael@sitting"'
       p2 = '"idle"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
        
     } else if (item == "Sitzen (Stuhl) 2") {namenAni = item+""
       p1 = '"missfam2leadinoutmcs3"'
       p2 = '"onboat_leadin_pornguy_a"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
        
     } else if (item == "Sitzen (Stuhl Weibl.)") {namenAni = item+""
       p1 = '"timetable@reunited@ig_10"'
       p2 = '"base_amanda"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
        
     } else if (item == "Weinerlich Sitzen") {namenAni = item+""
       p1 = '"switch@trevor@floyd_crying"'
       p2 = '"console_end_loop_floyd"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
        
     } else if (item == "Auf dem Rücken liegen") {namenAni = item+""
       p1 = '"amb@world_human_sunbathe@male@back@base"'
       p2 = '"base"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,35);               
        
     } else if (item == "Auf dem Bauch liegen (Weibl.)") {namenAni = item+""
       p1 = '"amb@world_human_sunbathe@male@front@base"'
       p2 = '"base"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,35);
        
     } else if (item == "Auf dem Bauch liegen (Männl.)") {namenAni = item+""
       p1 = '"amb@world_human_sunbathe@male@front@idle_a"'
       p2 = '"idle"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,35);
        
     } else if (item == "Seitlich liegen") {namenAni = item+""
       p1 = '"amb@lo_res_idles@"'
       p2 = '"world_human_bum_slumped_right_lo_res_base"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
        
     } else if (item == "Betrunken liegen") {namenAni = item+""
       p1 = '"timetable@amanda@drunk@idle_a"'
       p2 = '"idle_pinot"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
        
     } else if (item == "Liegen (Ohnmacht)") {namenAni = item+""
       p1 = '"misssolomon_5@end"'
       p2 = '"dead_black_ops"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
        
     } else if (item == "Schlafen") {namenAni = item+""
       p1 = '"missfinale_c1@"'
       p2 = '"lying_dead_player0"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
        
     } else if (item == "Arme Verschränken (Männl.)") {namenAni = item+""
       p1 = '"anim@heists@heist_corona@single_team'
       p2 = '"single_team_loop_boss"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,49);
        
     } else if (item == "Arme Verschränken (Weibl.)") {namenAni = item+""
       p1 = '"amb@world_human_hang_out_street@female_arms_crossed@base"'
       p2 = '"base"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,49);
        
     } else if (item == "Security") {namenAni = item+""
       p1 = '"mini@strip_club@idles@bouncer@idle_a"'
       p2 = '"idle_a"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,49);
        
     } else if (item == "Anlehnen") {namenAni = item+""
       p1 = '"amb@world_human_leaning@male@wall@back@foot_up@base"'
       p2 = '"base"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,35);
        
     } else if (item == "Anlehnen 2") {namenAni = item+""
       p1 = '"amb@world_human_leaning@male@wall@back@legs_crossed@idle_a"'
       p2 = '"idle_c"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,35);
        
     } else if (item == "Arrogant") {namenAni = item+""
       p1 = '"missmic_3_ext@leadin@mic_3_ext"'
       p2 = '"_leadin_trevor"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,49);
        
     } else if (item == "Eingebildet") {namenAni = item+""
       p1 = '"mp_move@prostitute@m@hooker"'
       p2 = '"idle"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,49);
        
     } else if (item == "Salutieren") {namenAni = item+""
       p1 = '"anim@mp_player_intuppersalute"'
       p2 = '"idle_a"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,49);
        
     } else if (item == "Depressiv") {namenAni = item+""
       p1 = '"amb@world_human_bum_standing@depressed@idle_a"'
       p2 = '"idle_c"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,49);
        
     } else if (item == "Auf die Knie 2") {namenAni = item+""
       p1 = '"random@arrests"'
       p2 = '"kneeling_arrest_idle"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Knien") {namenAni = item+""
       p1 = '"amb@medic@standing@kneel@base"'
       p2 = '"base"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Auf die Knie") {namenAni = item+""
       p1 = '"missheist_jewel"'
       p2 = '"manageress_kneel_loop"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Verzweifelt Knien") {namenAni = item+""
       p1 = '"missfra2"'
       p2 = '"lamar_base_idle"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Gangzeichen 1") {namenAni = item+""
       p1 = '"mp_player_int_uppergang_sign_b"'
       p2 = '"mp_player_int_gang_sign_b_exit"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,49);
       
     } else if (item == "Gangzeichen 2") {namenAni = item+""
       p1 = '"mp_player_int_uppergang_sign_a"'
       p2 = '"mp_player_int_gang_sign_a"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,49);
       
     } else if (item == "Strip 1") {namenAni = item+""
       p1 = '"oddjobs@assassinate@multi@yachttarget@lapdance"'
       p2 = '"yacht_ld_f"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Strip 2") {namenAni = item+""
       p1 = '"mini@strip_club@private_dance@idle"'
       p2 = '"priv_dance_idle"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Strip 3") {namenAni = item+""
       p1 = '"mini@strip_club@private_dance@part1"'
       p2 = '"priv_dance_p1"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Strip 4") {namenAni = item+""
       p1 = '"mini@strip_club@private_dance@part2"'
       p2 = '"priv_dance_p2"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Strip 5") {namenAni = item+""
       p1 = '"mini@strip_club@private_dance@part3"'
       p2 = '"priv_dance_p3"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
               
     } else if (item == "Strip 6") {namenAni = item+""
       p1 = '"mp_am_stripper"'
       p2 = '"lap_dance_girl"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Ghetto") {namenAni = item+""
       p1 = '"missfbi3_sniping"'
       p2 = '"dance_m_default"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Tao 1") {namenAni = item+""
       p1 = '"misschinese2_crystalmazemcs1_cs"'
       p2 = '"dance_loop_tao"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Tao 2") {namenAni = item+""
       p1 = '"misschinese2_crystalmazemcs1_ig"'
       p2 = '"dance_loop_tao"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Stepptanz 1") {namenAni = item+""
       p1 = '"special_ped@mountain_dancer@base"'
       p2 = '"base"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Po wackeln") {namenAni = item+""
       p1 = '"switch@trevor@mocks_lapdance"'
       p2 = '"001443_01_trvs_28_idle_stripper"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Po wackeln 2") {namenAni = item+""
       p1 = '"switch@trevor@mocks_lapdance"'
       p2 = '"001443_01_trvs_28_exit_stripper"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Zumba 1") {namenAni = item+""
       p1 = '"timetable@tracy@ig_5@idle_a"'
       p2 = '"idle_a"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Zumba 2") {namenAni = item+""
       p1 = '"timetable@tracy@ig_5@idle_a"'
       p2 = '"idle_b"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Zumba 3") {namenAni = item+""
       p1 = '"timetable@tracy@ig_5@idle_a"'
       p2 = '"idle_c"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Zumba 4") {namenAni = item+""
       p1 = '"timetable@tracy@ig_5@idle_b"'
       p2 = '"idle_d"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Zumba 5") {namenAni = item+""
       p1 = '"timetable@tracy@ig_5@idle_b"'
       p2 = '"idle_e"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Geiles lied") {namenAni = item+""
       p1 = '"amb@world_human_cheering@female_b"'
       p2 = '"base"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Feminines Tanzen") {namenAni = item+""
       p1 = '"amb@world_human_jog_standing@female@idle_a"'
       p2 = '"idle_a"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Tanzfaul") {namenAni = item+""
       p1 = '"amb@world_human_partying@female@partying_beer@base"'
       p2 = '"base"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Luftgitarre") {namenAni = item+""
       p1 = '"anim@mp_player_intcelebrationfemale@air_guitar"'
       p2 = '"air_guitar"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Banging Tunes") {namenAni = item+""
       p1 = '"anim@mp_player_intcelebrationmale@banging_tunes"'
       p2 = '"banging_tunes"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,47);
       
     } else if (item == "Onkel Disco") {namenAni = item+""
       p1 = '"anim@mp_player_intcelebrationmale@uncle_disco"'
       p2 = '"uncle_disco"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,47);
       
     } else if (item == "Herzrasen") {namenAni = item+""
       p1 = '"anim@mp_player_intcelebrationmale@heart_pumping"'
       p2 = '"heart_pumping"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,47);
       
     } else if (item == "Der Fisch") {namenAni = item+""
       p1 = '"anim@mp_player_intcelebrationmale@oh_snap"'
       p2 = '"oh_snap"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,47);
       
     } else if (item == "Snap") {namenAni = item+""
       p1 = '"mp_player_int_uppergang_sign_a"'
       p2 = '"mp_player_int_gang_sign_a"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,49);
       
     } else if (item == "Raise") {namenAni = item+""
       p1 = '"anim@mp_player_intcelebrationmale@raise_the_roof"'
       p2 = '"raise_the_roof"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,47);
       
     } else if (item == "Salsa") {namenAni = item+""
       p1 = '"anim@mp_player_intcelebrationmale@salsa_roll"'
       p2 = '"salsa_roll"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,47);
       
     } else if (item == "Cats Cradle") {namenAni = item+""
       p1 = '"anim@mp_player_intcelebrationmale@cats_cradle"'
       p2 = '"cats_cradle"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,47);
       
     } else if (item == "Yoga 1") {namenAni = item+""
       p1 = '"rcmepsilonism3"'
       p2 = '"ep_3_rcm_marnie_meditating"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Yoga 2") {namenAni = item+""
       p1 = '"rcmepsilonism3"'
       p2 = '"base_loop"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Yoga 3") {namenAni = item+""
       p1 = '"rcmfanatic1maryann_stretchidle_b"'
       p2 = '"idle_e"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Yoga 4") {namenAni = item+""
       p1 = '"timetable@amanda@ig_4"'
       p2 = '"ig_4_idle"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Yoga 5") {namenAni = item+""
       p1 = '"amb@world_human_yoga@female@base"'
       p2 = '"base_c"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Liegestütze 1") {namenAni = item+""
       p1 = '"rcmfanatic3"'
       p2 = '"ef_3_rcm_loop_maryann"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Liegestütze 2") {namenAni = item+""
       p1 = '"amb@world_human_push_ups@male@base"'
       p2 = '"base"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Situps") {namenAni = item+""
       p1 = '"amb@world_human_sit_ups@male@base"'
       p2 = '"base"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Flex") {namenAni = item+""
       p1 = '"amb@world_human_muscle_flex@arms_at_side@base"'
       p2 = '"base"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,49);
       
     } else if (item == "Flex 2") {namenAni = item+""
       p1 = '"amb@world_human_muscle_flex@arms_in_front@idle_a"'
       p2 = '"idle_b"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,49);
       
     } else if (item == "Begutachten") {namenAni = item+""
       p1 = '"oddjobs@taxi@gyn@"'
       p2 = '"idle_b_ped"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Reparieren") {namenAni = item+""
       p1 = '"amb@world_human_vehicle_mechanic@male@base"'
       p2 = '"base"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Putzen") {namenAni = item+""
       p1 = '"timetable@maid@cleaning_window@base"'
       p2 = '"base"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Pfeifen") {namenAni = item+""
       p1 = '"rcmnigel1c"'
       p2 = '"hailing_whistle_waive_a"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,49);
       
     } else if (item == "Ironisches Klatschen") {namenAni = item+""
       p1 = '"amb@world_human_cheering@male_e"'
       p2 = '"base"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,49);
       
     } else if (item == "Peace") {namenAni = item+""
       p1 = '"anim@mp_player_intincarpeacestd@ds@"'
       p2 = '"idle_a"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,49);
       
     } else if (item == "2 Bier") {namenAni = item+""
       p1 = '"amb@code_human_in_car_mp_actions@v_sign@bodhi@rps@base"'
       p2 = '"idle_a"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,49);
       
     } else if (item == "Double Peace") {namenAni = item+""
       p1 = '"anim@mp_player_intcelebrationmale@peace"'
       p2 = '"peace"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,49);
       
     } else if (item == "Luftküssen") {namenAni = item+""
       p1 = '"anim@mp_player_intcelebrationfemale@blow_kiss"'
       p2 = '"blow_kiss"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Fuck you") {namenAni = item+""
       p1 = '"anim@mp_player_intselfiethe_bird"'
       p2 = '"idle_a"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,49);
       
     } else if (item == "Daumen hoch") {namenAni = item+""
       p1 = '"anim@mp_player_intupperthumbs_up"'
       p2 = '"idle_a"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,49);
       
     } else if (item == "Winken") {namenAni = item+""
       p1 = '"anim@mp_player_intupperwave"'
       p2 = '"idle_a"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,49);
       
     } else if (item == "Facepalm") {namenAni = item+""
       p1 = '"anim@mp_player_intupperface_palm"'
       p2 = '"idle_a"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,49);
       
     } else if (item == "Ausrasten") {namenAni = item+""
       p1 = '"anim@mp_player_intcelebrationmale@freakout"'
       p2 = '"freakout"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,49);
       
     } else if (item == "Pinkeln") {namenAni = item+""
       p1 = '"missbigscore1switch_trevor_piss"'
       p2 = '"piss_loop"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,33);
       
     } else if (item == "Notieren") {namenAni = item+""
       p1 = '"amb@world_human_clipboard@male@idle_a"'
       p2 = '"idle_c"'
       mp.events.callRemote("server:shortcut:save",namenAni, slotid,p1,p2,1,49);
       
     } 
  };

mp.events.add('setAniSlot1',(...arr) => {
    /*if(player.admin >= 2){
       
    }*/
    //mp.gui.chat.push('aniname:'+arr) 
    setNewAni(arr, 1)
})
mp.events.add('setAniSlot2',(...arr) => {

    //mp.gui.chat.push('aniname:'+arr)
    setNewAni(arr, 2)
}) 
mp.events.add('setAniSlot3',(...arr) => {

    //mp.gui.chat.push('aniname:'+arr)
    setNewAni(arr, 3)
}) 
mp.events.add('setAniSlot4',(...arr) => {

    //mp.gui.chat.push('aniname:'+arr)
    setNewAni(arr, 4)
}) 
mp.events.add('setAniSlot5',(...arr) => {

    //mp.gui.chat.push('aniname:'+arr)
    setNewAni(arr, 5)
}) 
mp.events.add('setAniSlot6',(...arr) => {

    //mp.gui.chat.push('aniname:'+arr)
    setNewAni(arr, 6)
}) 
mp.events.add('setAniSlot7',(...arr) => {

    //mp.gui.chat.push('aniname:'+arr)
    setNewAni(arr, 7)
}) 
mp.events.add('setAniSlot8',(...arr) => {

    //mp.gui.chat.push('aniname:'+arr)
    setNewAni(arr, 8)
}) 
mp.events.add('setAniSlot9',(...arr) => {

    //mp.gui.chat.push('aniname:'+arr)
    setNewAni(arr, 9)
}) 



