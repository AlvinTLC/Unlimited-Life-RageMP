let CEF = mp.browsers.new("package://animationmenu/html/index.html");
CEF.active = false;

let animationList = {
    0: "anim@heists@fleeca_bank@ig_7_jetski_owner:/:owner_idle",
    1: "amb@lo_res_idles@e:/:world_human_picnic_female_lo_res_base",
    2: "switch@michael@sitting:/:idle",
    3: "missfam2leadinoutmcs3:/:onboat_leadin_pornguy_a",
    4: "timetable@reunited@ig_10:/:base_amanda",
    5: "amb@medic@standing@kneel@base:/:base",
    6: "amb@world_human_sunbathe@male@back@base:/:base",
    7: "amb@world_human_sunbathe@male@front@base:/:base",
    8: "amb@lo_res_idles@:/:world_human_bum_slumped_right_lo_res_base",
    9: "timetable@amanda@drunk@idle_a:/:idle_pinot",
    10: "misssolomon_5@end:/:dead_black_ops",
    11: "missfinale_c1@:/:lying_dead_player0",
    12: "anim@heists@heist_corona@single_team:/:single_team_loop_boss",
    13: "amb@world_human_hang_out_street@female_arms_crossed@base:/:base",
    14: "busted:/:idle_2_hands_up",
    15: "missmic_3_ext@leadin@mic_3_ext:/:_leadin_trevor",
    16: "mp_move@prostitute@m@hooker:/:idle",
    17: "amb@world_human_leaning@male@wall@back@foot_up@bas:/:base",
    18: "mini@strip_club@idles@bouncer@idle_a:/:idle_a",
    19: "oddjobs@assassinate@multi@yachttarget@lapdance:/:yacht_ld_f",
    20: "mini@strip_club@private_dance@idle:/:priv_dance_idle",
    21: "mini@strip_club@private_dance@part1:/:priv_dance_p1",
    22: "mini@strip_club@private_dance@part2:/:priv_dance_p2",
    23: "mini@strip_club@private_dance@part3:/:priv_dance_p3",
    24: "mp_am_stripper:/:lap_dance_girl",
    25: "missfbi3_sniping:/:dance_m_default",
    26: "misschinese2_crystalmazemcs1_cs:/:dance_loop_tao",
    27: "misschinese2_crystalmazemcs1_ig:/:dance_loop_tao",
    28: "switch@trevor@mocks_lapdance:/:001443_01_trvs_28_idle_stripper",
    29: "switch@trevor@mocks_lapdance:/:001443_01_trvs_28_exit_stripper",
    30: "anim@mp_player_intcelebrationmale@salsa_roll:/:salsa_roll",
    31: "timetable@tracy@ig_5@idle_a:/:idle_a",
    32: "timetable@tracy@ig_5@idle_a:/:idle_b",
    33: "timetable@tracy@ig_5@idle_a:/:idle_c",
    34: "timetable@tracy@ig_5@idle_b:/:idle_d",
    35: "timetable@tracy@ig_5@idle_b:/:idle_e",
    36: "amb@world_human_cheering@female_b:/:base",
    37: "amb@world_human_jog_standing@female@idle_a:/:idle_a",
    38: "amb@world_human_partying@female@partying_beer@base:/:base",
    39: "anim@mp_player_intcelebrationfemale@air_guitar:/:air_guitar",
    40: "rcmepsilonism3:/:ep_3_rcm_marnie_meditating",
    41: "rcmepsilonism3:/:base_loop",
    42: "rcmfanatic1maryann_stretchidle_b:/:idle_e",
    43: "timetable@amanda@ig_4:/:ig_4_idle",
    44: "rcmfanatic3:/:ef_3_rcm_loop_maryann",
    45: "amb@world_human_push_ups@male@base:/:base",
    46: "amb@world_human_sit_ups@male@base:/:base",
    47: "amb@world_human_muscle_flex@arms_at_side@base:/:base",
    48: "oddjobs@taxi@gyn@:/:idle_b_ped",
    49: "amb@world_human_vehicle_mechanic@male@base:/:base",
    50: "timetable@maid@cleaning_window@base:/:base",
    51: "mp_player_int_uppergang_sign_b:/:mp_player_int_gang_sign_b_exit",
    52: "missheist_jewel:/:manageress_kneel_loop",
    53: "random@arrests:/:kneeling_arrest_idle",
    54: "rcmnigel1c:/:hailing_whistle_waive_a",
    55: "amb@world_human_cheering@male_e:/:base",
    56: "anim@mp_player_intincarpeacestd@ds@:/:idle_a",
    57: "anim@mp_player_intselfiethe_bird:/:idle_a",
    58: "anim@mp_player_intupperface_palm:/:idle_a",
    59: "anim@mp_player_intupperwave:/:idle_a",
    60: "missfra2:/:lamar_base_idle",
    61: "switch@trevor@floyd_crying:/:console_end_loop_floyd",
    62: "amb@code_human_wander_smoking@male@idle_a:/:idle_a",
    63: "amb@lo_res_idles@:/:creatures_world_retriever_sitting_lo_res_base",  //sitz Retriver
    64: "creatures@rottweiler@indication@:/:indicate_ahead",  // anschlagen
    65: "creatures@retriever@amb@world_dog_barking@base:/:base", // Bellen Retriver      //    65: "amb@lo_res_idles@:/:creatures_world_rottweiler_sitting_lo_res_base",
    66: "creatures@rottweiler@amb@sleep_in_kennel@:/:sleep_in_kennel", // Schlafen  Rottweiler       //    66: "amb@lo_res_idles@:/:creatures_world_rottweiler_standing_lo_res_base",
}

function switchMenu(bool) {
    CEF.active = bool;
    mp.gui.cursor.visible = bool;
    CEF.execute(`switchShow(${bool});`);
}

mp.events.add('cCloseCef', () => {
    switchMenu(false);
});

mp.events.add('cAnimations-stop', () => {
    mp.events.callRemote('sAnimations-stop');
});

mp.events.add('entityStreamIn', (entity) => {
    if (entity.type === 'player'){
        let splits = entity.getVariable("animation");
        if (splits !== undefined && splits !== null) {
            splits = splits.split(":/:");
            if (splits.length >= 2) {
                entity.taskPlayAnim(splits[0], splits[1], 0.00, 0.00, -1, 47, 0.00, false, false, false);
            }
        }
    }
});

mp.events.add('cAnimations-play', (id) => {
    let splits = animationList[id];
    splits = splits.split(":/:");
    mp.events.callRemote('sAnimations-play', splits[0], splits[1]);
});
// keydown
mp.keys.bind(0x21, true, function () { // X
    switchMenu(true)
});

// keyup
mp.keys.bind(0x21, false, function () { // X
    CEF.execute(`destroyClick();`);
});
