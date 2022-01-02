using System;

namespace Phone_System
{
    // Here you have all the messages that player recive so you can easly change or translate.
    public class Messages
    {
        // Info messages
        public const string INF_PLAYER_CALL_END         = "You hang up.";
        public const string INF_TARGET_CALL_END         = "The person you were talking to has hang up and ended the call.";
        public const string INF_LINE_BUSSY              = "Line busy.";


        // Error messages
        public const string ERR_PLAYERS_NOT_TALKING     = "Those players are not talking.";
        public const string ERR_PLAYER_NOT_FOUND        = "Player not found.";

        // Commands
        public const string CMD_CALL                    = "call";
        public const string CMD_CALL_USAGE              = "USAGE: /call [Player-ID]";
        public const string CMD_HANGUP                  = "hangup";
    }
}
