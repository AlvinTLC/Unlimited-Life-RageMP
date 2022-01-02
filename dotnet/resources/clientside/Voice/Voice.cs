﻿using GTANetworkAPI;
using System;
using System.Collections.Generic;
using ULife.GUI;
using ULife.Core;
using UNL.SDK;

namespace ULife.Voice
{
    public class Voice : Script
    {
        private static nLog Log = new nLog("Voice");
        public Voice()
        {
            RoomController.getInstance().CreateRoom("VoiceRoom");
        }

        public Player GetPlayerById(int id)
        {
            Player target = null;
            foreach (Player player in NAPI.Pools.GetAllPlayers())
            {
                if (player.Value == id)
                {
                    target = player;
                    break;
                }
            }
            return target;
        }

        public static void PlayerJoin(Player player)
        {
            try
            {
                VoiceMetaData DefaultVoiceMeta = new VoiceMetaData
                {
                    IsEnabledMicrophone = false,
                    RadioRoom = "",
                    StateConnection = "closed",
                    MicrophoneKey = 78 // N
                };

                VoicePhoneMetaData DefaultVoicePhoneMeta = new VoicePhoneMetaData
                {
                    CallingState = "nothing",
                    Target = null
                };

                player.SetData("Voip", DefaultVoiceMeta);
                player.SetData("PhoneVoip", DefaultVoicePhoneMeta);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void PlayerQuit(Player player, string reson)
        {
            try
            {
                RoomController controller = RoomController.getInstance();
                VoiceMetaData voiceMeta = player.GetData<VoiceMetaData>("Voip");

                if (controller.HasRoom(voiceMeta.RadioRoom))
                {
                    controller.OnQuit(voiceMeta.RadioRoom, player);
                }

                VoicePhoneMetaData playerPhoneMeta = player.GetData<VoicePhoneMetaData>("PhoneVoip");

                if (playerPhoneMeta.Target != null)
                {
                    Player target = playerPhoneMeta.Target;
                    VoicePhoneMetaData targetPhoneMeta = target.GetData<VoicePhoneMetaData>("PhoneVoip");

                    var pSim = Main.Players[player].Sim;
                    var playerName = (Main.Players[target].Contacts.ContainsKey(pSim)) ? Main.Players[target].Contacts[pSim] : pSim.ToString();

                    Notify.Send(target, NotifyType.Alert, NotifyPosition.JobSms, $"{playerName} hat den Anruf Benndet", 3000);
                    targetPhoneMeta.Target = null;
                    targetPhoneMeta.CallingState = "nothing";

                    target.ResetData("AntiAnimDown");
                    if (!target.IsInVehicle) target.StopAnimation();
                    else target.SetData("ToResetAnimPhone", true);

                    Core.BasicSync.DetachObject(target);

                    // Default voice system
                    Trigger.ClientEvent(target, "voice.phoneStop");
                    // Teamspeak
                    target.SetSharedData("Handy_ID", "reject:" + target.Name + new DateTime().ToString());

                    target.SetData("PhoneVoip", targetPhoneMeta);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        [Command("v_reload")]
        public void voiceDebugReload(Player player)
        {
            player.SendChatMessage("Sie haben den Voice - Chat erfolgreich für sich selbst neu gestartet(v1).");
            Trigger.ClientEvent(player, "v_reload");
        }

        [Command("v_reload2")]
        public void voiceDebug2Reload(Player player)
        {
            player.SendChatMessage("Sie haben den Voice - Chat erfolgreich für sich selbst neu gestartet(v2).");
            Trigger.ClientEvent(player, "v_reload2");
        }

        [Command("v_reload3")]
        public void voiceDebug3Reload(Player player)
        {
            player.SendChatMessage("Sie haben den Voice - Chat erfolgreich für sich selbst neu gestartet(v3).");
            Trigger.ClientEvent(player, "v_reload3");
        }

        [RemoteEvent("add_voice_listener")]
        public void add_voice_listener(Player player, params object[] arguments)
        {
            try
            {
                if (!Main.Players.ContainsKey(player)) return;
                Player target = (Player)arguments[0];
                if (!Main.Players.ContainsKey(target)) return;
                player.EnableVoiceTo(target);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        [RemoteEvent("remove_voice_listener")]
        public void remove_voice_listener(Player player, params object[] arguments)
        {
            try
            {
                if (!Main.Players.ContainsKey(player)) return;
                Player target = (Player)arguments[0];
                if (!Main.Players.ContainsKey(target)) return;
                player.DisableVoiceTo(target);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        // METHODS //

        public static void PhoneCallCommand(Player player, Player target)
        {
            try
            {
                if (player.HasData("AntiAnimDown"))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.JobSms, "Es ist unmöglich, ein Mobiltelefon zu bekommen", 3000);
                    return;
                }
                if (target != null && Main.Players.ContainsKey(target))
                {
                    VoicePhoneMetaData targetPhoneMeta = target.GetData<VoicePhoneMetaData>("PhoneVoip");
                    VoicePhoneMetaData playerPhoneMeta = player.GetData<VoicePhoneMetaData>("PhoneVoip");

                    if (playerPhoneMeta.Target != null)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.JobSms, "Im Moment redest du schon", 3000);
                        return;
                    }

                    var tSim = Main.Players[target].Sim;
                    var pSim = Main.Players[player].Sim;

                    var playerName = (Main.Players[target].Contacts.ContainsKey(pSim)) ? Main.Players[target].Contacts[pSim] : pSim.ToString();
                    var targetName = (Main.Players[player].Contacts.ContainsKey(tSim)) ? Main.Players[player].Contacts[tSim] : tSim.ToString();

                    if (targetPhoneMeta.Target != null)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.JobSms, $"Im Moment { targetName} beschäftigt", 3000);
                        Notify.Send(target, NotifyType.Alert, NotifyPosition.JobSms, $"{playerName} versuchte dich anzurufen", 3000);
                        return;
                    }

                    targetPhoneMeta.Target = player;
                    targetPhoneMeta.CallingState = "callMe";

                    playerPhoneMeta.Target = target;
                    playerPhoneMeta.CallingState = "callTo";

                    Main.OnAntiAnim(player);
                    player.PlayAnimation("anim@cellphone@in_car@ds", "cellphone_call_listen_base", 49);
                    Core.BasicSync.AttachObjectToPlayer(player, NAPI.Util.GetHashKey("prop_amb_phone"), 6286, new Vector3(0.06, 0.01, -0.02), new Vector3(80, -10, 110));

                    player.SetData("PhoneVoip", playerPhoneMeta);
                    target.SetData("PhoneVoip", targetPhoneMeta);

                    NAPI.Task.Run(() => {
                        try
                        {
                            if (!Main.Players.ContainsKey(player) || !Main.Players.ContainsKey(target)) return;

                            VoicePhoneMetaData tPhoneMeta = target.GetData<VoicePhoneMetaData>("PhoneVoip");
                            VoicePhoneMetaData pPhoneMeta = player.GetData<VoicePhoneMetaData>("PhoneVoip");

                            if (pPhoneMeta.Target == null || pPhoneMeta.Target != target || pPhoneMeta.CallingState == "talk") return;

                            pPhoneMeta.Target = null;
                            tPhoneMeta.Target = null;

                            pPhoneMeta.CallingState = "nothing";
                            tPhoneMeta.CallingState = "nothing";

                            if (!player.IsInVehicle)
                                player.StopAnimation();
                            else
                                player.SetData("ToResetAnimPhone", true);
                            Core.BasicSync.DetachObject(player);

                            player.SetData("PhoneVoip", pPhoneMeta);
                            target.SetData("PhoneVoip", tPhoneMeta);

                            player.ResetData("AntiAnimDown");

                            Notify.Send(player, NotifyType.Alert, NotifyPosition.JobSms, $"{targetName} reagiert nicht", 3000);
                            Notify.Send(target, NotifyType.Alert, NotifyPosition.JobSms, $"{playerName} hat den Anruf Benndent", 3000);
                        }
                        catch { }

                    }, 20000);

                    Notify.Send(target, NotifyType.Alert, NotifyPosition.JobSms, $"{playerName} ruft dich an.Öffnen Sie das Telefon, um den Anruf anzunehmen oder abzuweisen", 3000);
                    Notify.Send(player, NotifyType.Alert, NotifyPosition.JobSms, $"Du rufst an { targetName}", 3000);
                }
                else
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.JobSms, "Der Teilnehmer hat keine Netzabdeckung", 3000);
                }

            }
            catch (Exception e)
            {
                Log.Write($"PhoneCall: {e.Message}", nLog.Type.Error);
            }
        }

        [ServerEvent(Event.PlayerExitVehicle)]
        public void Event_PlayerExitVehicle(Player player, Vehicle veh)
        {
            try
            {
                if (player.HasData("ToResetAnimPhone"))
                {
                    player.StopAnimation();
                    player.ResetData("ToResetAnimPhone");
                }
            }
            catch { }
        }

        //[Command("ca")]
        public static void PhoneCallAcceptCommand(Player player)
        {
            try
            {
                VoicePhoneMetaData playerPhoneMeta = player.GetData<VoicePhoneMetaData>("PhoneVoip");

                if (playerPhoneMeta.Target == null || playerPhoneMeta.CallingState == "callTo" || !Main.Players.ContainsKey(playerPhoneMeta.Target))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.JobSms, $"Im Moment ruft dich niemand an", 3000);
                    return;
                }

                Player target = playerPhoneMeta.Target;

                VoicePhoneMetaData targetPhoneMeta = target.GetData<VoicePhoneMetaData>("PhoneVoip");

                playerPhoneMeta.CallingState = "talk";
                targetPhoneMeta.CallingState = "talk";

                var tSim = Main.Players[target].Sim;
                var pSim = Main.Players[player].Sim;

                var playerName = (Main.Players[target].Contacts.ContainsKey(pSim)) ? Main.Players[target].Contacts[pSim] : pSim.ToString();
                var targetName = (Main.Players[player].Contacts.ContainsKey(tSim)) ? Main.Players[player].Contacts[tSim] : tSim.ToString();

                Notify.Send(target, NotifyType.Success, NotifyPosition.JobSms, $"{playerName} nahm Ihren Anruf an", 3000);
                Notify.Send(player, NotifyType.Success, NotifyPosition.JobSms, $"Sie haben den Anruf von { targetName} angenommen!", 3000);

                Main.OnAntiAnim(player);
                player.PlayAnimation("anim@cellphone@in_car@ds", "cellphone_call_listen_base", 49);
                Core.BasicSync.AttachObjectToPlayer(player, NAPI.Util.GetHashKey("prop_amb_phone"), 6286, new Vector3(0.06, 0.01, -0.02), new Vector3(80, -10, 110));


                // Default voice system
                Trigger.ClientEvent(player, "voice.phoneCall", target, 1);
                Trigger.ClientEvent(target, "voice.phoneCall", player, 1);
                // Teamspeak

                string phoneId = player.Name + new DateTime().ToString();
                player.SetSharedData("Handy_ID", phoneId);
                target.SetSharedData("Handy_ID", phoneId);
                player.SetSharedData("IsHeCalling", true);


                player.ResetData("ToResetAnimPhone");
                target.ResetData("ToResetAnimPhone");

                player.SetData("PhoneVoip", playerPhoneMeta);
                target.SetData("PhoneVoip", targetPhoneMeta);
            }
            catch (Exception e)
            {
                Log.Write($"PhoneCallAccept: {e.Message}", nLog.Type.Error);
            }
        }

        //[Command("h")]
        public static void PhoneHCommand(Player player)
        {
            try
            {
                VoicePhoneMetaData playerPhoneMeta = player.GetData<VoicePhoneMetaData>("PhoneVoip");

                if (playerPhoneMeta.Target == null || !Main.Players.ContainsKey(playerPhoneMeta.Target))
                {
                    if (!player.HasData("IS_DYING") && !player.GetData<bool>("CUFFED")) Notify.Send(player, NotifyType.Error, NotifyPosition.JobSms, $"Sie telefonieren gerade nicht", 3000);
                    return;
                }

                Player target = playerPhoneMeta.Target;
                VoicePhoneMetaData targetPhoneMeta = target.GetData<VoicePhoneMetaData>("PhoneVoip");

                var tSim = Main.Players[target].Sim;
                var pSim = Main.Players[player].Sim;

                var playerName = (Main.Players[target].Contacts.ContainsKey(pSim)) ? Main.Players[target].Contacts[pSim] : pSim.ToString();
                var targetName = (Main.Players[player].Contacts.ContainsKey(tSim)) ? Main.Players[player].Contacts[tSim] : tSim.ToString();

                Notify.Send(player, NotifyType.Success, NotifyPosition.JobSms, $"Der Anruf ist beendet", 3000);
                Notify.Send(target, NotifyType.Success, NotifyPosition.JobSms, $"{playerName} hat den Anruf Benndet", 3000);

                playerPhoneMeta.Target = null;
                targetPhoneMeta.Target = null;

                playerPhoneMeta.CallingState = "nothing";
                targetPhoneMeta.CallingState = "nothing";

                if (!player.IsInVehicle) player.StopAnimation();
                if (!target.IsInVehicle) target.StopAnimation();

                player.ResetData("AntiAnimDown");
                target.ResetData("AntiAnimDown");
                if (player.IsInVehicle) player.SetData("ToResetAnimPhone", true);
                if (player.IsInVehicle) target.SetData("ToResetAnimPhone", true);

                Core.BasicSync.DetachObject(player);
                Core.BasicSync.DetachObject(target);

                // Default voice system
                Trigger.ClientEvent(player, "voice.phoneStop");
                Trigger.ClientEvent(target, "voice.phoneStop");

                // Teamspeak
                player.SetSharedData("Handy_ID", "reject:" + player.Name + new DateTime().ToString());
                target.SetSharedData("Handy_ID", "reject:" + target.Name + new DateTime().ToString());
                player.SetSharedData("IsHeCalling", false);
                target.SetSharedData("IsHeCalling", false);

                player.SetData("PhoneVoip", playerPhoneMeta);
                target.SetData("PhoneVoip", targetPhoneMeta);
            }
            catch (Exception e)
            {
                Log.Write($"PhoneCallCancel: {e.Message}", nLog.Type.Error);
            }
        }

        //[Command("changeroom")]
        public void ChangeRoomCommand(Player player, string name)
        {
            try
            {
                name = name.ToUpper();

                if (name.Length != 0)
                {
                    RoomController controller = RoomController.getInstance();
                    VoiceMetaData voiceMeta = player.GetData<VoiceMetaData>("Voip");

                    if (controller.HasRoom(name))
                    {
                        if (name.Equals(voiceMeta.RadioRoom))
                        {
                            player.SendChatMessage("You are already on this room");
                            return;
                        }

                        controller.OnQuit(name, player);
                        controller.OnJoin(name, player);
                    }
                    else
                    {
                        player.SendChatMessage("This room doesn't exist");
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        //[Command("createroom")]
        public void CreateRoomCommand(Player player, string name)
        {
            try
            {
                name = name.ToUpper();

                if (name.Length != 0)
                {
                    RoomController controller = RoomController.getInstance();

                    if (!controller.HasRoom(name))
                    {
                        controller.CreateRoom(name);

                        player.SendChatMessage("You create room - " + name);
                    }
                    else
                    {
                        player.SendChatMessage("Room already created");
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        //[Command("removeroom")]
        public void RemoveRoomCommand(Player player, string name)
        {
            try
            {
                name = name.ToUpper();

                if (name.Length != 0)
                {
                    RoomController controller = RoomController.getInstance();

                    if (controller.HasRoom(name))
                    {
                        controller.RemoveRoom(name);

                        player.SendChatMessage("You has removed room - " + name);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        //[Command("leaveroom")]
        public void LeaveRoomCommand(Player player, string name)
        {
            try
            {
                name = name.ToUpper();

                if (name.Length != 0)
                {
                    RoomController controller = RoomController.getInstance();

                    if (controller.HasRoom(name))
                    {
                        VoiceMetaData voiceMeta = player.GetData<VoiceMetaData>("Voip");

                        if (name.Equals(voiceMeta.RadioRoom))
                        {
                            controller.OnQuit(name, player);
                        }

                        player.SendChatMessage("You leave from room - " + name);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void SetVoiceDistance(Player player, float distance)
        {
            player.SetSharedData("voice.distance", distance);
        }

        public float GetVoiceDistance(Player player)
        {
            return player.GetSharedData<float>("voice.distance");
        }

        public bool IsMicrophoneEnabled(Player player)
        {
            VoiceMetaData voiceMeta = player.GetData<VoiceMetaData>("Voip");

            return voiceMeta.IsEnabledMicrophone;
        }

        public void SetVoiceMuted(Player player, bool isMuted)
        {
            player.SetSharedData("voice.muted", isMuted);
        }

        public bool GetVoiceMuted(Player player)
        {
            return player.GetSharedData<bool>("voice.muted");
        }

        public void SetMicrophoneKey(Player player, int microphoneKey)
        {
            try
            {
                VoiceMetaData voiceMeta = player.GetData<VoiceMetaData>("Voip");
                voiceMeta.MicrophoneKey = microphoneKey;

                Trigger.ClientEvent(player, "voice.changeMicrophoneActivationKey", microphoneKey);
                player.SetData("Voip", voiceMeta);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public int GetMicrophoneKey(Player player)
        {
            VoiceMetaData voiceMeta = player.GetData<VoiceMetaData>("Voip");
            return voiceMeta.MicrophoneKey;
        }

        [RemoteEvent("Teamspeak_LipSync")]
        public void TeamSpeakVoiceHandler(Player player)
        {
            Log.Write("Teamspeak LipSyznc");
        }
    }
}