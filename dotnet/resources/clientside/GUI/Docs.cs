using GTANetworkAPI;
using ULife.Core;
using UNL.SDK;
using System;
using System.Collections.Generic;
using System.Text;

namespace ULife.GUI
{
    class Docs : Script
    {
        private static nLog Log = new nLog("Docs");
        [RemoteEvent("passport")]
        public static void Event_Passport(Player player, params object[] arguments)
        {
            try
            {
                Player to = (Player)arguments[0];
                Log.Debug(to.Name.ToString());
                Passport(player, to);
            }
            catch (Exception e)
            {
                Log.Write("EXCEPTION AT \"EVENT_PASSPORT\":\n" + e.ToString(), nLog.Type.Error);
            }
        }
        [RemoteEvent("licenses")]
        public static void Event_Licenses(Player player, params object[] arguments)
        {
            try
            {
                Player to = (Player)arguments[0];
                Licenses(player, to);
            }
            catch (Exception e)
            {
                Log.Write("EXCEPTION AT \"EVENT_LICENSES\":\n" + e.ToString(), nLog.Type.Error);
            }
        }

        public static void Passport(Player from, Player to)
        {
            Vector3 pos = to.Position;
            if (from.Position.DistanceTo(pos) > 2)
            {
                Notify.Send(from, NotifyType.Error, NotifyPosition.MapUp, "Der Spieler ist zu weit weg", 3000);
                return;
            }
            to.SetData("REQUEST", "acceptPass");
            to.SetData("IS_REQUESTED", true);
            Notify.Send(to, NotifyType.Warning, NotifyPosition.MapUp, $"Der Bürger({from.Value})möchte dir seinen Ausweis zeigen Y/N", 3000);
            NAPI.Data.SetEntityData(to, "DOCFROM", from);
        }
        public static void Licenses(Player from, Player to)
        {
            Vector3 pos = to.Position;
            if (from.Position.DistanceTo(pos) > 2)
            {
                Notify.Send(from, NotifyType.Error, NotifyPosition.MapUp, "Der Spieler ist zu weit weg", 3000);
                return;
            }
            to.SetData("REQUEST", "acceptLics");
            to.SetData("IS_REQUESTED", true);
            Notify.Send(to, NotifyType.Warning, NotifyPosition.MapUp, $"Der Bürger({from.Value})möchte dir seine Lizenzen zeigen Y/N", 3000);
            NAPI.Data.SetEntityData(to, "DOCFROM", from);
        }
        public static void AcceptPasport(Player player)
        {
            Player from = NAPI.Data.GetEntityData(player, "DOCFROM");
            var acc = Main.Players[from];
            string gender = (acc.Gender) ? "Männer" : "Frauen";
            string fraction = (acc.FractionID > 0) ? Fractions.Manager.FractionNames[acc.FractionID] : "Nein";
            string work = (acc.WorkID > 0) ? Jobs.WorkManager.JobStats[acc.WorkID] : "Arbeitslos";
            List<object> data = new List<object>
                    {
                        acc.UUID,
                        acc.FirstName,
                        acc.LastName,
                        acc.CreateDate.ToString("dd.MM.yyyy"),
                        gender,
                        fraction,
                        work
                    };
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Der Bürger ({from.Value}) hat dir seinen Pass gezeigt", 5000);
            Notify.Send(from, NotifyType.Info, NotifyPosition.MapUp, $"Du hast deinem Gegenüber deinen Ausweis gezeigt({player.Value})", 5000);
            Log.Debug(json);
            Trigger.ClientEvent(player, "passport", json);
            Trigger.ClientEvent(player, "newPassport", from, acc.UUID);
        }
        public static void AcceptLicenses(Player player)
        {
            Player from = NAPI.Data.GetEntityData(player, "DOCFROM");
            var acc = Main.Players[from];
            string gender = (acc.Gender) ? "Männer" : "Frauen";

            var lic = "";
            for (int i = 0; i < acc.Licenses.Count; i++)
                if (acc.Licenses[i]) lic += $"{Main.LicWords[i]} / ";
            if (lic == "") lic = "Abwesend";

            List<string> data = new List<string>
                    {
                        acc.FirstName,
                        acc.LastName,
                        acc.CreateDate.ToString("dd.MM.yyyy"),
                        gender,
                        lic
                    };

            Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Dein gegenüber({from.Value}) dir seine Lizenzen gezeigt", 5000);
            Notify.Send(from, NotifyType.Info, NotifyPosition.MapUp, $"Du hast die Lizenzen deines gegenübers gesehen({player.Value})", 5000);
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            Trigger.ClientEvent(player, "licenses", json);
        }
    }
}
