﻿using System.Collections.Generic;
using GTANetworkAPI;
using ULife.Core;
using UNL.SDK;
using System;

namespace ULife.Fractions
{
    class Gangs : Script
    {
        private static nLog Log = new nLog("Gangs");

        public static Dictionary<int, Vector3> EnterPoints = new Dictionary<int, Vector3>()
        {
            { 1, new Vector3(-76.18885, -1413.83, -28.20075) }, //Колшейп зеленых банд вход
            { 2, new Vector3(85.79318, -1958.851, -20.0017) }, //Колшейп феолетовых банд вход
            { 3, new Vector3(1408.579, -1486.897, -59.53736) }, //Колшейп желтых банд вход
            { 4, new Vector3(892.2407, -2172.888, -31.16626) }, //Колшейп синих банд вход
            { 5, new Vector3(485.3334, -1528.692, -28.18008) }, //Колшейп красных банд вход
        };
        public static Dictionary<int, Vector3> ExitPoints = new Dictionary<int, Vector3>()
        {
            { 1, new Vector3(-201.7147, -1627.962, -38.664788) }, //Колшейп зеленых банд выход 
            { 2, new Vector3(82.57095, -1958.607, -23.41236) }, //Колшейп феолетовых банд выход
            { 3, new Vector3(1420.487, -1497.264, -107.8639) }, //Колшейп желтых банд выход
            { 4, new Vector3(892.4592, -2168.068, 0.921189) }, //Колшейп синих банд выход
            { 5, new Vector3(484.9963, -1536.083, -33.22089) }, //Колшейп красных банд выход
        };

        public static List<Vector3> DrugPoints = new List<Vector3>()
        {
            //new Vector3(8.621573, 3701.914, 39.51624), //Колшейп сдачи/приема наркоты 1
            new Vector3(3804.169, 4444.753, 3.977164), //Колшейп сдачи/приема наркоты 2
        };
        private static int PricePerDrug = 60;

        [ServerEvent(Event.ResourceStart)]
        public void Event_OnResourceStart()
        {
            try
            {
                /*NAPI.TextLabel.CreateTextLabel("~g~Gang_Family", new Vector3(-75.66629, -1414.138, 30.40077), 5f, 0.3f, 0, new Color(255, 255, 255), true, 0); //Банда зеленых НПС
                NAPI.TextLabel.CreateTextLabel("~g~Carl Ballard", new Vector3(85.79006, -1957.156, 20.74745), 5f, 0.3f, 0, new Color(255, 255, 255), true, 0); //Банда феолетовых НПС
                NAPI.TextLabel.CreateTextLabel("~g~Chiraq Bloody", new Vector3(485.6168, -1529.195, 29.28829), 5f, 0.3f, 0, new Color(255, 255, 255), true, 0); //Банда желтых НПС
                NAPI.TextLabel.CreateTextLabel("~g~Riki Veronas", new Vector3(1408.224, -1486.415, 60.65733), 5f, 0.3f, 0, new Color(255, 255, 255), true, 0); //Банда синих НПС
                NAPI.TextLabel.CreateTextLabel("~g~Santano Amorales", new Vector3(892.2745, -2172.252, 32.28627), 5f, 0.3f, 0, new Color(255, 255, 255), true, 0); //Банда красных НПС*/

                foreach (var pos in DrugPoints)
                {
                    NAPI.Marker.CreateMarker(1, pos - new Vector3(0, 0, 1.12), new Vector3(), new Vector3(), 4, new Color(255, 0, 0), false, 0);
                    //NAPI.TextLabel.CreateTextLabel($"~g~Buy drugs ({PricePerDrug}$/g)", pos + new Vector3(0, 0, 0.7), 5f, 0.3f, 0, new Color(255, 255, 255), true, 0);
                    //NAPI.Blip.CreateBlip(140, pos, 0.75f, 69, "Drugs", 255, 0, true, 0, 0);

                    var col = NAPI.ColShape.CreateCylinderColShape(pos - new Vector3(0, 0, 1.12), 4, 5, 0);
                    col.OnEntityEnterColShape += (s, e) =>
                    {
                        try
                        {
                            e.SetData("INTERACTIONCHECK", 47);
                        }
                        catch (Exception ex) { Log.Write("OnEntityEnterColShape: " + ex.Message, nLog.Type.Error); }
                    };
                    col.OnEntityExitColShape += (s, e) =>
                    {
                        try
                        {
                            e.SetData("INTERACTIONCHECK", -1);
                        }
                        catch (Exception ex) { Log.Write("OnEntityExitColShape: " + ex.Message, nLog.Type.Error); }
                    };
                }

                foreach (var point in EnterPoints)
                {
                    NAPI.Marker.CreateMarker(1, point.Value - new Vector3(0, 0, 0.7), new Vector3(), new Vector3(), 1, new Color(255, 255, 255, 220), false, NAPI.GlobalDimension);

                    var col = NAPI.ColShape.CreateCylinderColShape(point.Value, 1.2f, 2, NAPI.GlobalDimension);
                    col.SetData("FRAC", point.Key);

                    col.OnEntityEnterColShape += (s, e) =>
                    {
                        if (!Main.Players.ContainsKey(e)) return;
                        e.SetData("FRACTIONCHECK", s.GetData<object>("FRAC"));
                        e.SetData("INTERACTIONCHECK", 64);
                    };
                    col.OnEntityExitColShape += (s, e) =>
                    {
                        if (!Main.Players.ContainsKey(e)) return;
                        e.SetData("INTERACTIONCHECK", -1);
                    };
                }

                foreach (var point in ExitPoints)
                {
                    NAPI.Marker.CreateMarker(1, point.Value - new Vector3(0, 0, 0.7), new Vector3(), new Vector3(), 1, new Color(255, 255, 255, 220), false, NAPI.GlobalDimension);

                    var col = NAPI.ColShape.CreateCylinderColShape(point.Value, 1.2f, 2, NAPI.GlobalDimension);
                    col.SetData("FRAC", point.Key);

                    col.OnEntityEnterColShape += (s, e) =>
                    {
                        if (!Main.Players.ContainsKey(e)) return;
                        e.SetData("FRACTIONCHECK", s.GetData<object>("FRAC"));
                        e.SetData("INTERACTIONCHECK", 65);
                    };
                    col.OnEntityExitColShape += (s, e) =>
                    {
                        if (!Main.Players.ContainsKey(e)) return;
                        e.SetData("INTERACTIONCHECK", -1);
                    };
                }
            }
            catch (Exception e) { Log.Write("ResourceStart: " + e.Message, nLog.Type.Error); }
        }

        public static void InteractPressed(Player player)
        {
            if (!Main.Players.ContainsKey(player)) return;
            if (!player.IsInVehicle || !player.Vehicle.HasData("CANDRUGS"))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Du musst dich in einem Fahrzeug befinden, das Drogen transportieren kann", 3000);
                return;
            }
            if (Fractions.Manager.FractionTypes[Main.Players[player].FractionID] != 1)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Du kannst keine Drogen kaufen", 3000);
                return;
            }
            if (!Fractions.Manager.canUseCommand(player, "buydrugs")) return;
            Trigger.ClientEvent(player, "openInput", "Medikamente besorgen", $"Stückzahl eingeben:", 4, "buy_drugs");
        }

        public static void BuyDrugs(Player player, int amount)
        {
            if (!Main.Players.ContainsKey(player)) return;
            if (!player.IsInVehicle || !player.Vehicle.HasData("CANDRUGS"))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Du musst dich in einem Fahrzeug befinden, das Drogen transportieren kann", 3000);
                return;
            }
            if (Fractions.Manager.FractionTypes[Main.Players[player].FractionID] != 1)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Du kannst keine Drogen kaufen", 3000);
                return;
            }
            if (!Fractions.Manager.canUseCommand(player, "buydrugs")) return;

            var tryAdd = VehicleInventory.TryAdd(player.Vehicle, new nItem(ItemType.Drugs, amount));
            if (tryAdd == -1 || tryAdd > 0)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Nicht genug Platz im Auto", 3000);
                return;
            }
            if (Fractions.Stocks.fracStocks[Main.Players[player].FractionID].Money < amount * PricePerDrug)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Unzureichende Mittel im Ganglager", 3000);
                return;
            }

            VehicleInventory.Add(player.Vehicle, new nItem(ItemType.Drugs, amount));
            Fractions.Stocks.fracStocks[Main.Players[player].FractionID].Money -= amount * PricePerDrug;

            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du hast {amount}g Drogen gekauft", 3000);
        }
    }
}
