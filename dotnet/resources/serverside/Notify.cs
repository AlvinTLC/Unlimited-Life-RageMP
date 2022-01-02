using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace UNL.SDK
{
    public enum NotifyType
    {
        Alert,
        Error,
        Success,
        Info,
        Warning
    }
    public enum NotifyPosition
    {
        MapUp,
        JobSms,
        BottomCenter
    }
    public static class Notify
    {
        public static void Send(Player Player, NotifyType type, NotifyPosition pos, string msg, int time)
        {
            Trigger.ClientEvent(Player, "notify", type, pos, msg, time);
        }

        public static void Send(Player c, NotifyType error, object bottomCenter, string v1, int v2)
        {
            throw new NotImplementedException();
        }
    }
}
