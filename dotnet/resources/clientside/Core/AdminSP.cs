using GTANetworkAPI;
using UNL.SDK;

namespace ULife.Core
{
    class AdminSP : Script
    {
        [RemoteEvent("SpectateSelect")]
        public static void SpectatePrevNext(Player player, bool state)
        {
            if (!Main.Players.ContainsKey(player)) return;
            if (!Group.CanUseCmd(player, "sp")) return;
            int target = player.GetData<int>("spPlayer"); // Es ist besser, GetData einmal aufzurufen als mehrmals, da SetData/GetData langsam sind.
            if (target != -1)
            {
                int id = 0;
                if (!state)
                {
                    id = (target - 1);
                    if (id == player.Value) id--; // Überspringen Sie unsere ID, da wir uns selbst nicht nachverfolgen können
                }
                else
                {
                    id = (target + 1);
                    if (id == player.Value) id++; // Überspringen Sie unsere ID, da wir uns selbst nicht nachverfolgen können
                }
                Spectate(player, id);
            }
            else player.SendChatMessage("Es kann nicht zu einem anderen Spieler gewechselt werden.");
        }

        public static void Spectate(Player player, int id)
        {
            if (Main.Players.ContainsKey(player))
            {
                if (id >= 0 && id < NAPI.Server.GetMaxPlayers())
                {
                    Player target = Main.GetPlayerByID(id);
                    if (target != null)
                    {
                        if (target != player)
                        {
                            if (Main.Players.ContainsKey(target))
                            {
                                if (target.GetData<bool>("spmode") == false)
                                {
                                    if (player.GetData<bool>("spmode") == false)
                                    { // Neue Positionsdaten nicht speichern, wenn wir uns bereits im Tracking-Modus befinden
                                        player.SetData("sppos", player.Position);
                                        player.SetData("spdim", player.Dimension);
                                    }
                                    else NAPI.ClientEvent.TriggerClientEvent(player, "spmode", null, false); // Wenn bereits auf jemandem und dann auf jemand anderem, dann zuerst abkoppeln
                                    player.SetSharedData("INVISIBLE", true); // Ihre Variable mit dem System der Einschnitte, so dass die Spieler keinen Einschnitt über ihren Köpfen sehen
                                    player.SetData("spmode", true);
                                    player.SetData("spPlayer", target.Value);
                                    player.Transparency = 0; // Zuerst volle Transparenz für den Spieler einstellen, und erst dann zum Spieler teleportieren
                                    player.Dimension = target.Dimension;
                                    player.Position = new Vector3(target.Position.X, target.Position.Y, (target.Position.Z + 3)); // Erster Teleport zum Spieler zum Laden
                                    NAPI.ClientEvent.TriggerClientEvent(player, "spmode", target, true); //Und erst dann den Admin mit dem Player verbinden
                                    player.SendChatMessage("Sie sehen gerade " + target.Name + " [ID: " + target.Value + "].");
                                }
                            }
                            else player.SendChatMessage("Der Spieler unter dieser ID hat sich noch nicht angemeldet.");
                        }
                    }
                    else player.SendChatMessage("Spieler unter ID " + id + " fehlt.");
                }
                else player.SendChatMessage("Die Player-ID ist ungültig (kleiner als 0 oder größer als die Anzahl der Slots).");
            }
        }

        [RemoteEvent("UnSpectate")]
        public static void RemoteUnSpectate(Player player)
        {
            if (!Main.Players.ContainsKey(player)) return;
            if (!Group.CanUseCmd(player, "sp")) return;
            UnSpectate(player);
        }

        public static void UnSpectate(Player player)
        {
            if (Main.Players.ContainsKey(player))
            {
                if (player.GetData<bool>("spmode") == true)
                {
                    NAPI.ClientEvent.TriggerClientEvent(player, "spmode", null, false);
                    player.SetData("spPlayer", -1);
                    Timers.StartOnce(400, () => {
                        player.Dimension = player.GetData<uint>("spdim");
                        player.Position = player.GetData<Vector3>("sppos"); // Zuerst bringen wir den Spieler an seinen ursprünglichen Standort zurück und stellen erst dann die Transparenz wieder her
                        player.Transparency = 255;
                        player.SetSharedData("INVISIBLE", false); // Nick-Sichtbarkeit einschalten und Anzeige der Hitpoints aller Spieler in der Nähe deaktivieren
                        player.SetData("spmode", false);
                        player.SendChatMessage("Sie sind aus dem Beobachtermodus heraus.");
                    });
                }
                else player.SendChatMessage("Sie befinden sich nicht im Beobachtermodus.");
            }
        }
    }
}
