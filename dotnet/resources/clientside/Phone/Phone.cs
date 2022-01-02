using System;
using System.Linq;
using GTANetworkAPI;

namespace Phone_System
{
    public class Phone : Script
    {
        // Entity datas
        public const string PLAYER_TALKING_TO_PLAYER = "PLAYER_TALKING_TO_PLAYER";
        public const string PLAYER_CALL_OFFER = "PLAYER_CALL_OFFER";
        public const string PLAYER_ON_PHONE = "PLAYER_ON_PHONE";
        public const string PLAYER_PHONE_NUMBER = "PLAYER_PHONE_NUMBER"; // You need to load this one when a player logins in

        // Server events
        [ServerEvent(Event.PlayerConnected)]
        public void OnPlayerConnect(Player player)
        {
            // Clear the data on connection in case it gets bugged up so we don't get phantom calls
            if (player.HasSharedData(PLAYER_TALKING_TO_PLAYER) || player.HasSharedData(PLAYER_ON_PHONE))
            {
                player.ResetSharedData(PLAYER_TALKING_TO_PLAYER);
                player.ResetSharedData(PLAYER_ON_PHONE);
            }
        }

        // Remote events
        [RemoteEvent("server:playerCallPlayer")]
        public void PlayerCallPlayerEvent(Player player, Player target)
        {
            if (target != null)
            {
                if (!target.HasSharedData(PLAYER_ON_PHONE))
                {
                    target.SendChatMessage("Your phone is ringing...");
                    target.SetSharedData(PLAYER_CALL_OFFER, player.Id);
                    target.TriggerEvent("client:showPhoneCef", true);
                    target.TriggerEvent("javascript:getCalled", player.Name); // We put the player name on the targets screen

                }
                else
                {
                    player.SendChatMessage("Player already talking.");
                }
            }
            else
            {
                player.SendChatMessage(Messages.ERR_PLAYER_NOT_FOUND);
            }
        }
        [RemoteEvent("server:playerAnswer")]
        public void PlayerAnswerEvent(Player player, ushort targetID)
        {
            if (player.HasSharedData(PLAYER_CALL_OFFER))
            {
                int convertedID = Convert.ToInt32(targetID);
                EnableVoiceBetweenPlayers(player, GetPlayerById(convertedID));
            }
            else
            {
                player.SendChatMessage("No one is calling you.");
            }
        }
        [RemoteEvent("server:hangUp")]
        public void PlayerCallHangUpEvent(Player player)
        {
            if (player.HasSharedData(PLAYER_TALKING_TO_PLAYER) && player.HasSharedData(PLAYER_ON_PHONE))
            {
                player.ResetSharedData(PLAYER_TALKING_TO_PLAYER);
                player.ResetSharedData(PLAYER_ON_PHONE);
                player.SendChatMessage(Messages.INF_PLAYER_CALL_END);

                Player target = GetPlayerById(player.GetSharedData<int>(PLAYER_TALKING_TO_PLAYER));
                if (target != null)
                {
                    target.ResetSharedData(PLAYER_TALKING_TO_PLAYER);
                    target.ResetSharedData(PLAYER_ON_PHONE);
                    target.SendChatMessage(Messages.INF_TARGET_CALL_END);
                    target.TriggerEvent("client:showPhoneCef", false);
                    target.TriggerEvent("javascript:getCalled", player.Name);

                    DisableVoiceBetweenPlayers(player, target);
                    DisableVoiceBetweenPlayers(target, player);
                }
            }
        }

        /* Test Commands - these are the commands that I used for test, you can delete them or leave them if you want :)
        [Command(Messages.CMD_CALL, Messages.CMD_CALL_USAGE)] // 
        public void CMD_instacall(Player player, int phoneNumber)
        {
            NAPI.Util.ConsoleOutput("1 call");
            Player target = GetPlayerFromPhoneNumber(phoneNumber);
            if (target != null)
            {
                NAPI.Util.ConsoleOutput("2 call");
                if (!target.HasSharedData(PLAYER_ON_PHONE))
                {
                    NAPI.Util.ConsoleOutput("3 call");
                    EnableVoiceBetweenPlayers(player, target);
                }
                else
                {
                    NAPI.Util.ConsoleOutput("4 call");
                    player.SendChatMessage("Player already talking.");
                }
            }
            else
            {
                NAPI.Util.ConsoleOutput("5 call");
                player.SendChatMessage(Messages.ERR_PLAYER_NOT_FOUND);
            }
        }

        [Command("phonen", "USAGE: /phonen number (Sets your phone number)")]
        public void CMD_givemenumber(Player player, int phoneNumber)
        {
            player.SetSharedData(PLAYER_PHONE_NUMBER, phoneNumber);
            player.SendChatMessage($"You set your phone number to {phoneNumber}");
        }

        [Command(Messages.CMD_HANGUP)]
        public void CMD_hangup(Player player)
        {
            NAPI.Util.ConsoleOutput("1 hangup");
            if (player.HasSharedData(PLAYER_TALKING_TO_PLAYER) && player.HasSharedData(PLAYER_ON_PHONE))
            {
                NAPI.Util.ConsoleOutput("2 hangup");
                player.ResetSharedData(PLAYER_TALKING_TO_PLAYER);
                player.ResetSharedData(PLAYER_ON_PHONE);
                player.SendChatMessage(Messages.INF_PLAYER_CALL_END);

                NAPI.Util.ConsoleOutput("3 hangup");
                Player target = GetPlayerById(player.GetSharedData<int>(PLAYER_TALKING_TO_PLAYER));
                if(target != null)
                {
                    NAPI.Util.ConsoleOutput("4 hangup");
                    target.ResetSharedData(PLAYER_TALKING_TO_PLAYER);
                    target.ResetSharedData(PLAYER_ON_PHONE);
                    target.SendChatMessage(Messages.INF_TARGET_CALL_END);
                    NAPI.Util.ConsoleOutput("5 hangup");
                }
            }
            NAPI.Util.ConsoleOutput("6 hangup");
        }
        
        // Player commands

        [Command("sms", "USAGE: /sms [number] text", GreedyArg = true)]
        public void CMD_sms(Player player, int targetNumber, string messageText)
        {
            Player target = GetPlayerFromPhoneNumber(targetNumber);
            if(target != null)
            {
                string senderNumber = player.GetSharedData<int>(PLAYER_PHONE_NUMBER).ToString();
                string finalMessageText = messageText.Trim();
                target.SendChatMessage($"[SMS][From: {senderNumber}] {finalMessageText}");
                target.TriggerEvent("client:playSmsBeep");

                // We inform the sender
                player.SendChatMessage($"[SMS Sent][To: {senderNumber}] {finalMessageText}");
                player.TriggerEvent("client:playSmsBeep");

                player.TriggerEvent("javascript:messageText", finalMessageText);
                //target.TriggerEvent("javascript:messageText", finalMessageText);
            }
            else
            {
                player.SendChatMessage(Messages.ERR_PLAYER_NOT_FOUND);
            }
        }

        [Command("zovi")]
        public void Zovi(Player player, Player target)
        {
            if(target != null)
            {
                player.TriggerEvent("AnswerCallEvent", target.Id);
                player.EnableVoiceTo(target);
                target.EnableVoiceTo(player);
            }
        }*/

        // Function used for starting a call
        public void EnableVoiceBetweenPlayers(Player player, Player target)
        {
            // We check if either of players are already talking
            if (player.HasSharedData(PLAYER_TALKING_TO_PLAYER) || target.HasSharedData(PLAYER_TALKING_TO_PLAYER))
            {
                player.SendChatMessage(Messages.INF_LINE_BUSSY);
            }
            else
            {
                player.SetSharedData(PLAYER_TALKING_TO_PLAYER, target.Id);
                target.SetSharedData(PLAYER_TALKING_TO_PLAYER, player.Id);

                NAPI.Player.EnablePlayerVoiceTo(player, target);
                NAPI.Player.EnablePlayerVoiceTo(target, player);
            }
        }
        // Function used for hanging up
        public void DisableVoiceBetweenPlayers(Player player, Player target)
        {
            // We check if player are talking to each other
            if (player.HasSharedData(PLAYER_TALKING_TO_PLAYER) && target.HasSharedData(PLAYER_TALKING_TO_PLAYER) && player.GetSharedData<int>(PLAYER_TALKING_TO_PLAYER) == target.GetSharedData<int>(PLAYER_TALKING_TO_PLAYER))
            {
                NAPI.Player.DisablePlayerVoiceTo(player, target);
                NAPI.Player.DisablePlayerVoiceTo(target, player);

                player.ResetSharedData(PLAYER_TALKING_TO_PLAYER);

                target.ResetSharedData(PLAYER_TALKING_TO_PLAYER);
            }
            else
            {
                player.SendChatMessage(Messages.ERR_PLAYERS_NOT_TALKING);
            }
        }

        // Other core functions
        public static Player GetPlayerById(int id)
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
        public static Player GetPlayerFromNameOrId(string targetString) // format: full Player_Name, example: John_Five
        {
            Player target = null;
            if (int.TryParse(targetString, out int targetId))
            {
                target = GetPlayerById(targetId);
            }
            else
            {
                string[] targetName = targetString.Split('_');
                string finalName = targetName[0] + ' ' + targetName[1];
                
                target = NAPI.Player.GetPlayerFromName(finalName);
            }
            return target;
        }
        public static Player GetPlayerFromPhoneNumber(int number)
        {
            Player target = null;
            foreach (Player p in NAPI.Pools.GetAllPlayers())
            {
                if (p.GetSharedData<int>(PLAYER_PHONE_NUMBER) == number)
                {
                    target = p;
                }
            }
            return target;
        }
    }
}