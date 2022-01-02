using System.Collections.Generic;
using GTANetworkAPI;
using ULife.Core;
using UNL.SDK;
using ULife.GUI;
using System;
using System.Linq;

namespace ULife.Fractions
{
    class USMS : Script
    {
        private static Dictionary<int, ColShape> Cols = new Dictionary<int, ColShape>();
        public static Vector3 EnterUSMS = new Vector3(105.675, -744.6737, -44.63474); //Вход в USMS телепорт
        private static Vector3 ExitUSMS = new Vector3(107.1693, -744.6852, -44.75476); //Выход в USMS телепорт
        private static List<Vector3> USMSCheckpoints = new List<Vector3>()
        {
            new Vector3(845.0762, -1283.7312, 24.320343), // Смена одежды NPC Steve Hain (0)
            new Vector3(136.1821, -761.7615, 241.152), // Лифт с 49го этажа (1)
            new Vector3(130.9762, -762.3011, 241.1518), // c 49го этажа на 53й (2)
            new Vector3(156.81, -757.24, 257.05), // Выход с 53го этажа (3)
            new Vector3(-1561.171, -568.5499, 113.3084), // Выход с крышы (4)
            new Vector3(834.3581, -1295.337, 24.320347), // Оружейка, рядом стоит NPC Michael Bisping (5)
            new Vector3(136.0578, -761.8408, 44.75204), // Лифт с 1го этажа (6)
            new Vector3(134.416, -697.5543, 32.20507), // Выход с гаража (7)
            new Vector3(843.18054, -1308.3369, 23.320341),  // Смена одежды на USMS (8)
            new Vector3(854.3138, -1318.538, 24.322), // Склад USMS (9)
        };
        public static bool warg_mode = true;

        private static nLog Log = new nLog("USMS");

        [ServerEvent(Event.ResourceStart)]
        public void onResourceStart()
        {
            try
            {
                foreach (Vector3 vec in USMSCheckpoints)
                {
                    NAPI.Marker.CreateMarker(1, vec - new Vector3(0, 0, 0.7), new Vector3(), new Vector3(), 1f, new Color(255, 255, 255, 220));
                }

                NAPI.TextLabel.CreateTextLabel("", new Vector3(149.1317, -758.3485, 243.152), 5f, 0.3f, 0, new Color(255, 255, 255), true, NAPI.GlobalDimension);
                NAPI.TextLabel.CreateTextLabel("", new Vector3(120.0836, -726.7773, 243.152), 5f, 0.3f, 0, new Color(255, 255, 255), true, NAPI.GlobalDimension);

                #region cols
                Cols.Add(0, NAPI.ColShape.CreateCylinderColShape(USMSCheckpoints[0], 1, 2, 0)); // duty USMS
                Cols[0].SetData("INTERACT", 672);
                Cols[0].OnEntityEnterColShape += USMSShape_onEntityEnterColShape;
                Cols[0].OnEntityExitColShape += USMSShape_onEntityExitColShape;
                //NAPI.TextLabel.CreateTextLabel(Main.StringToU16("~g~Press E to change clothes"), new Vector3(USMSCheckpoints[0].X, USMSCheckpoints[0].Y, USMSCheckpoints[0].Z + 0.3), 5F, 0.3F, 0, new Color(255, 255, 255));

                Cols.Add(7, NAPI.ColShape.CreateCylinderColShape(USMSCheckpoints[5], 1, 2, 0)); // gun menu
                Cols[7].SetData("INTERACT", 678);
                Cols[7].OnEntityEnterColShape += USMSShape_onEntityEnterColShape;
                Cols[7].OnEntityExitColShape += USMSShape_onEntityExitColShape;
                //NAPI.TextLabel.CreateTextLabel(Main.StringToU16("~g~Press E to open gun menu"), new Vector3(USMSCheckpoints[5].X, USMSCheckpoints[5].Y, USMSCheckpoints[5].Z + 0.3), 5F, 0.3F, 0, new Color(255, 255, 255));

                Cols.Add(9, NAPI.ColShape.CreateCylinderColShape(USMSCheckpoints[7], 1, 2, 0)); // garage
                Cols[9].SetData("INTERACT", 675);
                Cols[9].OnEntityEnterColShape += USMSShape_onEntityEnterColShape;
                Cols[9].OnEntityExitColShape += USMSShape_onEntityExitColShape;
                //NAPI.TextLabel.CreateTextLabel(Main.StringToU16("~g~Press E"), new Vector3(USMSCheckpoints[7].X, USMSCheckpoints[7].Y, USMSCheckpoints[7].Z + 0.3), 5F, 0.3F, 0, new Color(255, 255, 255));

                Cols.Add(10, NAPI.ColShape.CreateCylinderColShape(USMSCheckpoints[8], 1, 2, 0)); // warg
                Cols[10].SetData("INTERACT", 679);
                Cols[10].OnEntityEnterColShape += USMSShape_onEntityEnterColShape;
                Cols[10].OnEntityExitColShape += USMSShape_onEntityExitColShape;
                //NAPI.TextLabel.CreateTextLabel(Main.StringToU16("~g~Press E to change SWAT clothes"), new Vector3(USMSCheckpoints[8].X, USMSCheckpoints[8].Y, USMSCheckpoints[8].Z + 0.3), 5F, 0.3F, 0, new Color(255, 255, 255));

                Cols.Add(11, NAPI.ColShape.CreateCylinderColShape(USMSCheckpoints[9], 1, 2, 0)); // stock
                Cols[11].SetData("INTERACT", 680);
                Cols[11].OnEntityEnterColShape += USMSShape_onEntityEnterColShape;
                Cols[11].OnEntityExitColShape += USMSShape_onEntityExitColShape;
                //NAPI.TextLabel.CreateTextLabel(Main.StringToU16("~g~Open gun stock"), new Vector3(USMSCheckpoints[9].X, USMSCheckpoints[9].Y, USMSCheckpoints[9].Z + 0.3), 5F, 0.3F, 0, new Color(255, 255, 255));
                #endregion
            }
            catch (Exception e) { Log.Write("ResourceStart: " + e.Message, nLog.Type.Error); }
        }

        public static void interactPressed(Player player, int interact)
        {
            switch (interact)
            {
                case 672:
                    if (Main.Players[player].FractionID == 18)
                    {
                        if (!NAPI.Data.GetEntityData(player, "ON_DUTY"))
                        {
                            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du hast den Arbeitstag begonnen", 3000);
                            Manager.setSkin(player, 18, Main.Players[player].FractionLVL);
                            NAPI.Data.SetEntityData(player, "ON_DUTY", true);
                            break;
                        }
                        else
                        {
                            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du bist für den Tag fertig", 3000);
                            Customization.ApplyCharacter(player);
                            if (player.HasData("HAND_MONEY")) player.SetClothes(5, 45, 0);
                            else if (player.HasData("HEIST_DRILL")) player.SetClothes(5, 41, 0);
                            NAPI.Data.SetEntityData(player, "ON_DUTY", false);
                            break;
                        }
                    }
                    else Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du arbeitest nicht beim USMS", 3000);
                    return;
                case 673:
                    if (player.IsInVehicle) return;
                    if (player.HasData("FOLLOWING"))
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Jemand schleppt dich mit", 3000);
                        return;
                    }
                    NAPI.Entity.SetEntityPosition(player, ExitUSMS + new Vector3(0, 0, 1.12));
                    Main.PlayerEnterInterior(player, ExitUSMS + new Vector3(0, 0, 1.12));
                    return;
                case 674:
                    if (player.IsInVehicle) return;
                    if (player.HasData("FOLLOWING"))
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Jemand schleppt dich mit", 3000);
                        return;
                    }
                    NAPI.Entity.SetEntityPosition(player, EnterUSMS + new Vector3(0, 0, 1.12));
                    Main.PlayerEnterInterior(player, EnterUSMS + new Vector3(0, 0, 1.12));
                    return;
                case 675:
                    if (player.IsInVehicle) return;
                    if (player.HasData("FOLLOWING"))
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Jemand schleppt dich mit", 3000);
                        return;
                    }
                    OpenUSMSLiftMenu(player);
                    return;
                case 678:
                    if (Main.Players[player].FractionID != 18)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du arbeitest nicht beim USMS", 3000);
                        return;
                    }
                    if (!Stocks.fracStocks[18].IsOpen)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Das Lager ist geschlossen.", 3000);
                        return;
                    }
                    OpenUSMSGunMenu(player);
                    return;
                case 677:
                    NAPI.Entity.SetEntityPosition(player, USMSCheckpoints[3] + new Vector3(0, 0, 1.12));
                    return;
                case 676:
                    NAPI.Entity.SetEntityPosition(player, USMSCheckpoints[2] + new Vector3(0, 0, 1.12));
                    return;
                case 679:
                    if (Main.Players[player].FractionID != 18)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du arbeitest nicht beim USMS", 3000);
                        return;
                    }
                    if (!player.GetData<bool>("ON_DUTY"))
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du musst den Arbeitstag beginnen", 3000);
                        return;
                    }
                    if (player.GetData<bool>("IN_CP_MODE"))
                    {
                        Manager.setSkin(player, Main.Players[player].FractionID, Main.Players[player].FractionLVL);
                        player.SetData("IN_CP_MODE", false);
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast deine Arbeitsuniform angezogen", 3000);
                    }
                    else
                    {
                        if (!warg_mode)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Не включен режим ЧП", 3000);
                            return;
                        }
                        if (Main.Players[player].Gender)
                        {
                            Customization.SetHat(player, 39, 2);
                            player.SetClothes(11, 53, 1);
                            player.SetClothes(4, 31, 2);
                            player.SetClothes(6, 25, 0);
                            player.SetClothes(9, 16, 0);
                            player.SetClothes(8, 130, 0);
                            player.SetClothes(3, 49, 0);
                        }
                        else
                        {
                            Customization.SetHat(player, 38, 2);
                            player.SetClothes(11, 46, 1);
                            player.SetClothes(4, 30, 2);
                            player.SetClothes(6, 25, 0);
                            player.SetClothes(9, 16, 0);
                            player.SetClothes(8, 160, 0);
                            player.SetClothes(3, 49, 0);
                        }
                        player.SetData("IN_CP_MODE", true);
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast deine spezielle Uniform angezogen.", 3000);
                    }
                    return;
                case 680:
                    if (Main.Players[player].FractionID != 18)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du bist kein Beamter", 3000);
                        return;
                    }
                    if (!NAPI.Data.GetEntityData(player, "ON_DUTY"))
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du musst den Arbeitstag beginnnen", 3000);
                        return;
                    }
                    if (!Stocks.fracStocks[18].IsOpen)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Das Lager ist geschlossen.", 3000);
                        return;
                    }
                    if (!Manager.canUseCommand(player, "openweaponstock")) return;
                    player.SetData("ONFRACSTOCK", 18);
                    GUI.Dashboard.OpenOut(player, Stocks.fracStocks[18].Weapons, "Die Waffenkammer", 6);
                    return;
            }
        }

        private void USMSShape_onEntityEnterColShape(ColShape shape, Player entity)
        {
            try
            {
                NAPI.Data.SetEntityData(entity, "INTERACTIONCHECK", shape.GetData<int>("INTERACT"));
            }
            catch (Exception ex) { Log.Write("USMSShape_onEntityEnterColShape: " + ex.Message, nLog.Type.Error); }
        }

        private void USMSShape_onEntityExitColShape(ColShape shape, Player entity)
        {
            try
            {
                NAPI.Data.SetEntityData(entity, "INTERACTIONCHECK", 0);
            }
            catch (Exception ex) { Log.Write("USMSShape_onEntityExitColShape: " + ex.Message, nLog.Type.Error); }
        }

        #region menus
        public static void OpenUSMSLiftMenu(Player player)
        {
            Trigger.ClientEvent(player, "openlift", 0, "USMSlift");
        }

        public static void OpenUSMSGunMenu(Player player)
        {
            Trigger.ClientEvent(player, "USMSguns");
        }
        [RemoteEvent("USMSgun")]
        public static void callback_USMSguns(Player client, int index)
        {
            try
            {
                switch (index)
                {
                    case 0:
                        Fractions.Manager.giveGun(client, Weapons.Hash.StunGun, "StunGun");
                        return;
                    case 1:
                        Fractions.Manager.giveGun(client, Weapons.Hash.CombatPistol, "CombatPistol");
                        return;
                    case 2:
                        var minrank = (warg_mode) ? 2 : 6;
                        Fractions.Manager.giveGun(client, Weapons.Hash.CombatPDW, "CombatPDW");
                        return;
                    case 3:
                        minrank = (warg_mode) ? 2 : 5;
                        Fractions.Manager.giveGun(client, Weapons.Hash.CarbineRifle, "CarbineRifle");
                        return;
                    case 4:
                        minrank = (warg_mode) ? 2 : 9;
                        Fractions.Manager.giveGun(client, Weapons.Hash.HeavySniper, "HeavySniper");
                        return;
                    case 5:
                        if (!Manager.canGetWeapon(client, "armor")) return;
                        if (Fractions.Stocks.fracStocks[18].Materials < Fractions.Manager.matsForArmor)
                        {
                            Notify.Send(client, NotifyType.Error, NotifyPosition.MapUp, "Unzureichende Materialien auf Lager", 3000);
                            return;
                        }
                        var aItem = nInventory.Find(Main.Players[client].UUID, ItemType.BodyArmor);
                        if (aItem != null)
                        {
                            Notify.Send(client, NotifyType.Error, NotifyPosition.MapUp, "Du hast bereits eine kugelsichere Weste", 3000);
                            return;
                        }
                        Fractions.Stocks.fracStocks[18].Materials -= Fractions.Manager.matsForArmor;
                        Fractions.Stocks.fracStocks[18].UpdateLabel();
                        nInventory.Add(client, new nItem(ItemType.BodyArmor, 1, 100.ToString()));
                        GameLog.Stock(Main.Players[client].FractionID, Main.Players[client].UUID, "armor", 1, false);
                        Notify.Send(client, NotifyType.Success, NotifyPosition.MapUp, $"Du hast eine kugelsichere Weste erhalten", 3000);
                        return;
                    case 6: // medkit
                        if (!Manager.canGetWeapon(client, "Medkits")) return;
                        if (Fractions.Stocks.fracStocks[18].Medkits == 0)
                        {
                            Notify.Send(client, NotifyType.Error, NotifyPosition.MapUp, "Es gibt keine Erste-Hilfe-Kästen im Lager", 3000);
                            return;
                        }

                        var tryAdd = nInventory.TryAdd(client, new nItem(ItemType.HealthKit));
                        if (tryAdd == -1 || tryAdd > 0)
                        {
                            Notify.Send(client, NotifyType.Error, NotifyPosition.MapUp, "Du hast bereits einen Erste-Hilfe-Kasten", 3000);
                            return;
                        }
                        Fractions.Stocks.fracStocks[18].Medkits--;
                        Fractions.Stocks.fracStocks[18].UpdateLabel();
                        nInventory.Add(client, new nItem(ItemType.HealthKit, 1));
                        GameLog.Stock(Main.Players[client].FractionID, Main.Players[client].UUID, "medkit", 1, false);
                        Notify.Send(client, NotifyType.Success, NotifyPosition.MapUp, $"Du hast den Erste-Hilfe-Kasten", 3000);
                        return;
                    case 7:
                        Fractions.Manager.giveAmmo(client, ItemType.PistolAmmo, 12);
                        return;
                    case 8:
                        minrank = (warg_mode) ? 2 : 6;
                        Fractions.Manager.giveAmmo(client, ItemType.SMGAmmo, 30);
                        return;
                    case 9:
                        minrank = (warg_mode) ? 2 : 5;
                        Fractions.Manager.giveAmmo(client, ItemType.RiflesAmmo, 30);
                        return;
                    case 10:
                        minrank = (warg_mode) ? 2 : 9;
                        Fractions.Manager.giveAmmo(client, ItemType.SniperAmmo, 5);
                        return;
                    case 11:
                        var data = (Main.Players[client].Gender) ? "177_1_true" : "177_1_false";
                        if (nInventory.Items[Main.Players[client].UUID].FirstOrDefault(i => i.Type == ItemType.Jewelry && i.Data == data) != null)
                        {
                            Notify.Send(client, NotifyType.Error, NotifyPosition.MapUp, $"Du hast bereits einen Ausweis", 3000);
                            return;
                        }
                        var hItem = nInventory.Find(Main.Players[client].UUID, ItemType.Jewelry);
                        if (hItem != null)
                        {
                            Notify.Send(client, NotifyType.Error, NotifyPosition.MapUp, $"Nicht genug Platz im Inventar", 3000);
                            return;
                        }

                        nInventory.Add(client, new nItem(ItemType.Jewelry, 1, data));
                        Notify.Send(client, NotifyType.Success, NotifyPosition.MapUp, $"Du hast ein USMS-Abzeichen erhalten", 3000);
                        return;
                    case 12:
                        minrank = (warg_mode) ? 2 : 2;
                        nInventory.Add(client, new nItem(ItemType.BZGas, 1));
                        // Fractions.Manager.giveGun(client, Weapons.Hash.BZGas, "BZGas");
                        Notify.Send(client, NotifyType.Success, NotifyPosition.MapUp, $"Du hast Tränengas genommen", 3000);
                        return;
                    case 13:
                        minrank = (warg_mode) ? 2 : 2;
                        nInventory.Add(client, new nItem(ItemType.SmokeGrenade, 1));
                        Notify.Send(client, NotifyType.Success, NotifyPosition.MapUp, $"Du hast Rauchgranate genommen", 3000);
                        return;
                    case 14:
                        minrank = (warg_mode) ? 2 : 2;
                        Fractions.Manager.giveGun(client, Weapons.Hash.Flare, "Flare");
                        Notify.Send(client, NotifyType.Success, NotifyPosition.MapUp, $"Du hast Fackel genommen", 3000);
                        return;
                    case 15:
                        minrank = (warg_mode) ? 2 : 2;
                        nInventory.Add(client, new nItem(ItemType.FlareGun, 1));
                        Notify.Send(client, NotifyType.Success, NotifyPosition.MapUp, $"Du hast Leuchtpistole genommen", 3000);
                        return;
                    case 16:
                        minrank = (warg_mode) ? 2 : 6;
                        nInventory.Add(client, new nItem(ItemType.CarbineRifleMk2, 1));
                        Notify.Send(client, NotifyType.Success, NotifyPosition.MapUp, $"Du hast Karabiner MK2 genommen", 3000);
                        return;
                    case 17:
                        minrank = (warg_mode) ? 2 : 4;
                        Fractions.Manager.giveGun(client, Weapons.Hash.MicroSMG, "MicroSMG");
                        Notify.Send(client, NotifyType.Success, NotifyPosition.MapUp, $"Du hast uzi genommen", 3000);
                        return;
                    case 18:
                        minrank = (warg_mode) ? 2 : 1;
                        nInventory.Add(client, new nItem(ItemType.Funk, 1));
                        Notify.Send(client, NotifyType.Success, NotifyPosition.MapUp, $"Du hast ein Funkgerät genommen", 3000);
                        return;
                }
            }
            catch (Exception e) { Log.Write("USMSgun: " + e.Message, nLog.Type.Error); }
        }
        #endregion
    }
}
