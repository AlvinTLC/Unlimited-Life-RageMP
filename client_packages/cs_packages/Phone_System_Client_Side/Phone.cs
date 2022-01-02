using System;
using System.Collections.Generic;
using RAGE;
using RAGE.Ui;
using Newtonsoft.Json;

namespace Phone_System_Client_Side
{
    public class Phone : Events.Script
    {
        HtmlWindow phoneCEF = null;
        public Phone()                                              // Arguments:
        {
            Events.Add("client:hangUp", CancelCallEvent);           
            Events.Add("client:answer", AnswerCallEvent);
            Events.Add("client:startCall", StartCallEvent);         
            Events.Add("client:showPhoneCef", ShowPhoneCefEvent);   // true/false
            Events.Add("client:playSmsBeep", PlaySoundBeepEvent);
            
            Events.Add("javascript:getCalled", JS_GetCalled);       // playerName
            Events.Add("javascript:acceptCall", JS_AcceptCall);
            Events.Add("javascript:cancelCall", JS_CancelCall);
            Events.Add("javascript:messageText", JS_MessagesText);  // message text

            Events.Tick += VoiceProcess;

            // We create the html windows when player joins because we will use it whole game - we will just hide/show it
            phoneCEF = new HtmlWindow("package://cs_packages/CEF/handy2/handy/index.html")
            {
                Active = false
            };

            // Keybinds
            Input.Bind(38, true, ShowPhoneCefBinder);
            Input.Bind(40, true, HidePhoneCefBinder);

        }
        
        internal static bool LatestKeyState = false;
        public void VoiceProcess(List<Events.TickNametagData> nametags)
        {
            bool keyState = RAGE.Input.IsDown(RAGE.Ui.VirtualKeys.N);
            if (keyState && !LatestKeyState)
            {
                Voice.Muted = !Voice.Muted;
                Notify(Voice.Muted ? "Voice State: ~r~disabled." : "Voice State: ~g~enabled.");
            }
            
            LatestKeyState = keyState;
        }

        public void MessageTextEvent(object[] args)
        {
            MessageModel message = new MessageModel();
            message.numberFrom = args[0].ToString();
            message.numberTo = args[1].ToString();
            message.message = Convert.ToInt32(args[2]);

            string messageJson = RAGE.Util.Json.Serialize(message);

            phoneCEF.ExecuteJs($"addMessage({messageJson})");
        }
        
        public static void Notify(string text)
        {
            RAGE.Game.Ui.SetNotificationTextEntry("STRING");
            RAGE.Game.Ui.AddTextComponentSubstringPlayerName(text);
            RAGE.Game.Ui.DrawNotification(false, false);
        }

        public void ShowPhoneCefBinder()
        {
            ShowPhoneCef(true);
        }
        public void HidePhoneCefBinder()
        {
            ShowPhoneCef(false);
        }

        public void PlaySoundBeepEvent(object[] unused)
        {
            RAGE.Game.Audio.PlaySoundFrontend(-1, "5_SEC_WARNING", "HUD_MINI_GAME_SOUNDSET", false); 
        }

        public void CancelCallEvent(object[] unused)
        {
            if (RAGE.Elements.Player.LocalPlayer.HasData("PLAYER_TALKING_TO_PLAYER"))
            { 
                Events.CallRemote("server:hangUp");
                RAGE.Elements.Player.LocalPlayer.Call("client:showPhoneCef", false);
            }
        }
        public void AnswerCallEvent(object[] args)
        {
            if (RAGE.Elements.Player.LocalPlayer.HasData("PLAYER_CALL_OFFER") && !RAGE.Elements.Player.LocalPlayer.HasData("PLAYER_TALKING_TO_PLAYER"))
            {
                // We get the caller player object
                ushort callerRemoteId = RAGE.Elements.Player.LocalPlayer.GetData<ushort>("PLAYER_CALL_OFFER");
                RAGE.Elements.Player caller = RAGE.Elements.Entities.Players.GetAt(callerRemoteId);

                if (caller != null)
                {
                    // We answer and turn voice on for both players
                    caller.Call("server:playerAnswer");

                    caller.VoiceVolume = 1.0f;
                    caller.AutoVolume = true;
                    caller.Voice3d = true;
                    
                    RAGE.Elements.Player.LocalPlayer.VoiceVolume = 1.0f;
                    RAGE.Elements.Player.LocalPlayer.AutoVolume = true;
                    RAGE.Elements.Player.LocalPlayer.Voice3d = true;

                    RAGE.Voice.Muted = false;
                }
            }
        }
        public void StartCallEvent(object[] unused)
        {
            // We get the caller player object
            ushort callerRemoteId = RAGE.Elements.Player.LocalPlayer.GetData<ushort>("PLAYER_CALL_OFFER");
            RAGE.Elements.Player caller = RAGE.Elements.Entities.Players.GetAt(callerRemoteId);

            if (caller != null)
            {
                caller.Call("client:showPhoneCef", true);
                caller.Call("javascript:getCalled", RAGE.Elements.Player.LocalPlayer.Name); // We set the caller name into the cef
            }
        }

        public void ShowPhoneCefEvent(object[] args) // true/false
        {
            bool toggle = (bool)args[0];
            ShowPhoneCef(toggle);
        }

        public void ShowPhoneCef(bool toggle)
        {
            phoneCEF.Active = toggle;

            if(toggle)
                phoneCEF.ExecuteJs("smShow();");
            else
                phoneCEF.ExecuteJs("smHide();");

            Chat.Activate(!toggle);
            Chat.Show(!toggle);

            Cursor.Visible = toggle;
        }

        public void JS_GetCalled(object[] args)
        {
            string name = Convert.ToString(args[0]);
            phoneCEF.ExecuteJs($"getCalled({name});");
        }
        public void JS_AcceptCall(object[] unused)
        {
            phoneCEF.ExecuteJs($"acceptCall();");
        }
        public void JS_CancelCall(object[] unused)
        {
            phoneCEF.ExecuteJs($"cancelCall();");
        }
        public void JS_MessagesText(object[] args)
        {
            string messageText = args[0].ToString().Trim();
            phoneCEF.ExecuteJs($"checkSite({messageText});");
        }

    }
}
