var tsBrowser = null;
var refresh = 0;
var browserLoad = false;
var canBeRefreshed = true;
var currentUrl = '';
let ringtone = null;

let LocalPlayer = mp.players.local;

mp.events.add('ConnectTeamspeak', (status) => {
    if (status) {
        tsBrowser = mp.browsers.new('');
        setTimeout(function () {
            refresh = 1;
            mp.game.audio.playSoundFrontend(-1, "Hack_Success", "DLC_HEIST_BIOLAB_PREP_HACKING_SOUNDS", true);
			mp.events.callRemote('Server:Voice:SetRange');
        }, 500);
    } else {
        refresh = 0;
        if (tsBrowser != null) {
            tsBrowser.destroy();
            tsBrowser = null;
        }
        mp.game.audio.playSoundFrontend(-1, "Hack_Failed", "DLC_HEIST_BIOLAB_PREP_HACKING_SOUNDS", true);
    }
});

function distanceCalc(vector1, vector2) {
    return mp.game.system.vdist2(vector1.x, vector1.y, vector1.z, vector2.x, vector2.y, vector2.z);
}

function subtract(vector1, vector2) {
    vector1.x = vector1.x - vector2.x;
    vector1.y = vector1.y - vector2.y;
    vector1.z = vector1.z - vector2.z;
    return vector1;
}

mp.events.add('render', () => {
    if (tsBrowser != null && canBeRefreshed) {
        if (refresh == 1) {
            canBeRefreshed = false;
            var player = mp.players.local;
            var playerPos = player.position;
            var playerRot = player.getHeading();
            var rotation = Math.PI / 180 * (playerRot * -1);
            var playerNames = new Array();

            var callingPlayerName = player.getVariable("CALLING_PLAYER_NAME");
            if (callingPlayerName && player.getVariable("CALL_IS_STARTED")) {
                if (callingPlayerName != "") {
                    playerNames.push(callingPlayerName + "~10~0~0~3");
                }
            }

			mp.players.forEach(
				(target, id) => {
					if(target.getVariable('Funk_Frequenz') == player.getVariable('Funk_Frequenz')) {
                        if(target.getVariable('Funk_Talk') == true) {
							playerNames.push(target.name + "~10~0~0~3");
						}
					}
				}
			);

			mp.players.forEach(
				(target, id) => {
					if(target.getVariable('Handy_ID') == player.getVariable('Handy_ID') && player.getVariable('Handy_ID') !== null && player.getVariable('Handy_ID') !== undefined) {
						if(target.getVariable('IsHeCalling') == true || player.getVariable('IsHeCalling') == true) {
							playerNames.push(target.name + "~10~0~0~3");
						}
					}
				}
			);


            mp.players.forEachInStreamRange(
                (playerStreamed, id) => {
                    var streamedPlayerPos = playerStreamed.position;
                    var distance = distanceCalc(playerPos, streamedPlayerPos);
                    var voiceRange = playerStreamed.getVariable("CLIENT_RANGE");
					var voiceStatus = playerStreamed.getVariable("VOICE_STATUS");

					if (voiceStatus) {

						var volumeModifier = 0;
						var range = 250;
						if (voiceRange == "Weit") {
							range = 450;
						}
						else if (voiceRange == "Leise") {
							range = 150;
						}
						if (distance > 5) {
							volumeModifier = (distance * -5 / 10);
						}
						if (volumeModifier > 0) {
							volumeModifier = 0;
						}

						if (distance < range) {
							var subPos = subtract(streamedPlayerPos, playerPos);
							var x = subPos.x * Math.cos(rotation) - subPos.y * Math.sin(rotation);
							var y = subPos.x * Math.sin(rotation) + subPos.y * Math.cos(rotation);
							x = x * 10 / range;
							y = y * 10 / range;
							var isDeath = playerStreamed.isDead();
							if (isDeath == null || !isDeath) {
								playerNames.push(playerStreamed.name + "~" + (Math.round(x * 1000) / 1000) + "~" + (Math.round(y * 1000) / 1000) + "~0~" + (Math.round(volumeModifier * 1000) / 1000));
							}
						}
					}
                }
            );
            var newUrl = "http://localhost:15555/players/" + player.name + "/" + playerNames.join(";") + "/";
            if (currentUrl != newUrl) {
                tsBrowser.url = newUrl;
                currentUrl = newUrl;
            }
            setTimeout(function () {
                canBeRefreshed = true;
            }, 500);
        }
    }
});

const keyVisualActiveVoice = 0x4E;
let mic = false;

mp.gui.execute(`HUD.mic=${mic}`);
const enableMicrophone = () => {
    if (global.chatActive || !global.loggedin) return;
    if (localplayer.getVariable('vmuted') == true) return;

    mp.voiceChat.muted = false;
    mp.gui.execute(`HUD.mic=${true}`);
    localplayer.playFacialAnim("mic_chatter", "mp_facial");
    mp.events.callRemote('Server:Voice:SetVoiceStatus', true);
}
const disableMicrophone = () => {
    if (!global.loggedin) return;

    mp.voiceChat.muted = true;
    mp.gui.execute(`HUD.mic=${false}`);
    localplayer.playFacialAnim("mood_normal_1", "facials@gen_male@variations@normal");
    mp.events.callRemote('Server:Voice:SetVoiceStatus', false);
}

//
// mp.keys.bind(keyVisualActiveVoice, true, function() {
//   mic = ! mic;
//   if (mic) {
//   	enableMicrophone();
//   } else {
//   	disableMicrophone();
//   }
// });

mp.keys.bind(keyVisualActiveVoice, true, function() {
    mic = true;
		enableMicrophone();
});

mp.keys.bind(keyVisualActiveVoice, false, function() {
    mic = false;
		disableMicrophone();
});




