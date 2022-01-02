using GTANetworkAPI;
using System.Collections.Generic;
using ULife.GUI;
using System;
using ULife.Core;
using UNL.SDK;

namespace ULife.Fractions
{
    class TuningMan : Script
    {
        public const int Id = 19;
        public const int Type = 2; // GOV
        public const string Name = "TUNINGMAN";
        public const string GovTag = "TUNINGMAN";

        // When player press E on some colshape, it id is sended to Main.cs
        public const int COLSHAPE_OPEN_MENU_ID = 508;
        public const int COLSHAPE_DUTY_ID = 509;

        public static Vector3 FractionStock = new Vector3(-206.6372, -1341.737, 34.89437);
        public static Vector3 FractionGarage = new Vector3(-182.8405, -1331.017, 31.20308);
        public static Vector3 PlayerSpawn = new Vector3(-206.5398, -1331.393, 34.89439);
        public static Vector3 BlipPosition = new Vector3(-206.6372, -1341.737, 34.89437);




        private static nLog Log = new nLog(Name);
        private static Dictionary<int, ColShape> Cols = new Dictionary<int, ColShape>();
        public static List<Vector3> checkpoints = new List<Vector3>()
        {
            new Vector3(-207.5398, -1331.393, 34.89439), // duty
            new Vector3(-206.5398, -1340.393, 34.89439), // menu
        };


        public static void workingDayHandler(Player player)
        {
            if (Main.Players[player].FractionID == Id)
            {
                if (!NAPI.Data.GetEntityData(player, "ON_DUTY"))
                {
                    Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du hast deinen Tag bei der Arbeit begonnen", 3000);
                    //Manager.setSkin(player, 7, Main.Players[player].FractionLVL);
                    NAPI.Data.SetEntityData(player, "ON_DUTY", true);
                }
                else
                {
                    Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du hast deinen Tag bei der Arbeit beendet", 3000); ;
                    Customization.ApplyCharacter(player);
                    if (player.HasData("HAND_MONEY"))
                    {
                        player.SetClothes(5, 45, 0);
                    }
                    else if (player.HasData("HEIST_DRILL"))
                    {
                        player.SetClothes(5, 41, 0);
                    }

                    NAPI.Data.SetEntityData(player, "ON_DUTY", false);
                }
            }
            else
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du bist kein Tuning Man", 3000);
            }
        }

        [ServerEvent(Event.ResourceStart)]
        public void onResourceStart()
        {
            Cols.Add(0, NAPI.ColShape.CreateCylinderColShape(checkpoints[0], 1, 2, 0));
            Cols[0].SetData("INTERACT", COLSHAPE_OPEN_MENU_ID);
            Cols[0].OnEntityEnterColShape += onEntityEnterColshape;
            Cols[0].OnEntityExitColShape += onEntityExitColshape;

            NAPI.TextLabel.CreateTextLabel(Main.StringToU16("~g~Umkleide"), 
                new Vector3(checkpoints[0].X, checkpoints[0].Y, checkpoints[0].Z + 0.7), 
                5F, 0.3F, 0, new Color(255, 255, 255));
            NAPI.Marker.CreateMarker(1, checkpoints[0] - new Vector3(0, 0, 0.7), new Vector3(), new Vector3(), 1, new Color(255, 255, 255, 220));



            Cols.Add(1, NAPI.ColShape.CreateCylinderColShape(checkpoints[1], 1, 2, 0));
            Cols[1].SetData("INTERACT", COLSHAPE_DUTY_ID);
            Cols[1].OnEntityEnterColShape += onEntityEnterColshape;
            Cols[1].OnEntityExitColShape += onEntityExitColshape;

            NAPI.TextLabel.CreateTextLabel(Main.StringToU16("~g~Funkgeräte"), 
                new Vector3(checkpoints[1].X, checkpoints[1].Y, checkpoints[1].Z + 0.7), 
                5F, 0.3F, 0, new Color(255, 255, 255));
            NAPI.Marker.CreateMarker(1, checkpoints[1] - new Vector3(0, 0, 0.7), new Vector3(), new Vector3(), 1, new Color(255, 255, 255, 220));
        }

        private void onEntityEnterColshape(ColShape shape, Player entity)
        {
            try
            {
                NAPI.Data.SetEntityData(entity, "INTERACTIONCHECK", shape.GetData<int>("INTERACT"));
            }
            catch (Exception ex) { Log.Write("onEntityEnterColshape: " + ex.Message, nLog.Type.Error); }
        }

        private void onEntityExitColshape(ColShape shape, Player entity)
        {
            try
            {
                NAPI.Data.SetEntityData(entity, "INTERACTIONCHECK", 0);
            }
            catch (Exception ex) { Log.Write("onEntityExitColshape: " + ex.Message, nLog.Type.Error); }
        }


        public static void menuHandler(Player player)
        {
            if (Main.Players[player].FractionID != Id)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du bist kein Tuning Man", 3000);
                return;
            }
            if (!NAPI.Data.GetEntityData(player, "ON_DUTY"))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Sie müssen zuerst den Arbeitstag beginnen", 3000);
                return;
            }

            OpenTunningItemsMenu(player);
            return;
        }

        public static void OpenTunningItemsMenu(Player player)
        {
            Trigger.ClientEvent(player, "tuningManOpenItemMenu");
        }
        [RemoteEvent("tuningManGetItem")]
        public static void callback_mechItems(Player client, int index)
        {
            try
            {
                switch (index)
                {
                    case 0: // Funk spamming?
                        nInventory.Add(client, new nItem(ItemType.Funk, 1));
                        Notify.Send(client, NotifyType.Success, NotifyPosition.MapUp, $"Du hast ein Funkgerät genommen", 3000);
                        return;
                }
            }
            catch (Exception e)
            {
                Log.Write($"ACLS items: " + e.Message, nLog.Type.Error);
            }
        }
    }
}
