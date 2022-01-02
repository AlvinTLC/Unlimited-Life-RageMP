using System.Collections.Generic;
using GTANetworkAPI;
using ULife.Core;
using UNL.SDK;
using System;
using ULife.GUI;

namespace ULife.Fractions
{
    class Ems : Script
    {
        private static nLog Log = new nLog("EMS");
        public static int HumanMedkitsLefts = 100;

        [ServerEvent(Event.ResourceStart)]
        public void onResourceStart()
        {
            try
            {
                /*NAPI.TextLabel.CreateTextLabel("~g~Bdesma Katsuni", new Vector3(309.561, -561.0858, 44.30), 5f, 0.3f, 0, new Color(255, 255, 255), true, NAPI.GlobalDimension); //Медик надпись - Тату
                NAPI.TextLabel.CreateTextLabel("~g~Steve Hobs", new Vector3(311.7008, -594.1584, 44.30), 5f, 0.3f, 0, new Color(255, 255, 255), true, NAPI.GlobalDimension); //Медик надпись - Лекарь
                NAPI.TextLabel.CreateTextLabel("~g~Billy Bob", new Vector3(302.4196, -598.45, 44.30), 5f, 0.3f, 0, new Color(255, 255, 255), true, NAPI.GlobalDimension); //Медик надпись - Одежда*/

                #region cols
                var col = NAPI.ColShape.CreateCylinderColShape(emsCheckpoints[0], 1, 2, 0); // enter ems
                col.SetData("INTERACT", 15);
                col.OnEntityEnterColShape += emsShape_onEntityEnterColShape;
                col.OnEntityExitColShape += emsShape_onEntityExitColShape;
                //NAPI.TextLabel.CreateTextLabel(Main.StringToU16("~g~Жми ~y~E"), new Vector3(emsCheckpoints[0].X, emsCheckpoints[0].Y, emsCheckpoints[0].Z + 1), 5F, 0.3F, 0, new Color(255, 255, 255));
                NAPI.Marker.CreateMarker(21, emsCheckpoints[0] + new Vector3(0, 0, 0.7), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 60));

                col = NAPI.ColShape.CreateCylinderColShape(emsCheckpoints[1], 1, 2, 0); // exit ems
                col.SetData("INTERACT", 16);
                col.OnEntityEnterColShape += emsShape_onEntityEnterColShape;
                col.OnEntityExitColShape += emsShape_onEntityExitColShape;
                //NAPI.TextLabel.CreateTextLabel(Main.StringToU16("~g~Жми ~y~E"), new Vector3(emsCheckpoints[1].X, emsCheckpoints[1].Y, emsCheckpoints[1].Z + 1), 5F, 0.3F, 0, new Color(255, 255, 255));
                NAPI.Marker.CreateMarker(21, emsCheckpoints[1] + new Vector3(0, 0, 0.7), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 60));

                col = NAPI.ColShape.CreateCylinderColShape(emsCheckpoints[3], 1, 2, 0); // open hospital stock
                col.SetData("INTERACT", 17);
                col.OnEntityEnterColShape += emsShape_onEntityEnterColShape;
                col.OnEntityExitColShape += emsShape_onEntityExitColShape;
                //NAPI.TextLabel.CreateTextLabel(Main.StringToU16("~g~Открыть запасы"), new Vector3(emsCheckpoints[3].X, emsCheckpoints[3].Y, emsCheckpoints[3].Z + 0.3), 5F, 0.3F, 0, new Color(255, 255, 255));

                col = NAPI.ColShape.CreateCylinderColShape(emsCheckpoints[4], 1, 2, 0); // duty change
                col.SetData("INTERACT", 18);
                col.OnEntityEnterColShape += emsShape_onEntityEnterColShape;
                col.OnEntityExitColShape += emsShape_onEntityExitColShape;
                //NAPI.TextLabel.CreateTextLabel(Main.StringToU16("~g~Сменить одежду"), new Vector3(emsCheckpoints[4].X, emsCheckpoints[4].Y, emsCheckpoints[4].Z + 0.3), 5F, 0.3F, 0, new Color(255, 255, 255));

                col = NAPI.ColShape.CreateCylinderColShape(emsCheckpoints[5], 1, 2, 0); // start heal course
                col.SetData("INTERACT", 19);
                col.OnEntityEnterColShape += emsShape_onEntityEnterColShape;
                col.OnEntityExitColShape += emsShape_onEntityExitColShape;
                //NAPI.TextLabel.CreateTextLabel(Main.StringToU16("~g~Начать лечение"), new Vector3(emsCheckpoints[5].X, emsCheckpoints[5].Y, emsCheckpoints[5].Z + 0.3), 5F, 0.3F, 0, new Color(255, 255, 255));

                col = NAPI.ColShape.CreateCylinderColShape(emsCheckpoints[6], 1, 2, 0); // tattoo delete
                col.SetData("INTERACT", 51);
                col.OnEntityEnterColShape += emsShape_onEntityEnterColShape;
                col.OnEntityExitColShape += emsShape_onEntityExitColShape;
                //NAPI.TextLabel.CreateTextLabel(Main.StringToU16("~g~Удалить тату"), new Vector3(emsCheckpoints[6].X, emsCheckpoints[6].Y, emsCheckpoints[6].Z + 0.3), 5F, 0.3F, 0, new Color(255, 255, 255));

                col = NAPI.ColShape.CreateCylinderColShape(new Vector3(312.0612, -592.8554, 43.28399), 53, 7, 0); // start heal course
                col.OnEntityEnterColShape += (s, e) =>
                {
                    try
                    {
                        e.SetData("IN_HOSPITAL", true);
                    }
                    catch { }
                };

                #region Load Medkits
                col = NAPI.ColShape.CreateCylinderColShape(new Vector3(3595.796, 3661.733, 32.75175), 4, 5, 0); // take meds
                col.SetData("INTERACT", 58);
                col.OnEntityEnterColShape += emsShape_onEntityEnterColShape;
                col.OnEntityExitColShape += emsShape_onEntityExitColShape;
                NAPI.Marker.CreateMarker(1, new Vector3(3595.796, 3661.733, 29.75175), new Vector3(), new Vector3(), 4, new Color(255, 0, 0));

                col = NAPI.ColShape.CreateCylinderColShape(new Vector3(3597.154, 3670.129, 32.75175), 1, 2, 0); // take meds
                col.SetData("INTERACT", 58);
                col.OnEntityEnterColShape += emsShape_onEntityEnterColShape;
                col.OnEntityExitColShape += emsShape_onEntityExitColShape;
                NAPI.Marker.CreateMarker(1, new Vector3(3597.154, 3670.129, 29.75175), new Vector3(), new Vector3(), 4, new Color(255, 0, 0)); //Маркер медикаментов
                NAPI.Blip.CreateBlip(153, new Vector3(3588.917, 3661.756, 41.48687), 0.50f, 15, "MedKits", 255, 0, true); //Блип на карте
                #endregion

                col = NAPI.ColShape.CreateCylinderColShape(emsCheckpoints[7], 1, 2, 0); // roof
                col.SetData("INTERACT", 63);
                col.OnEntityEnterColShape += emsShape_onEntityEnterColShape;
                col.OnEntityExitColShape += emsShape_onEntityExitColShape;
                //NAPI.TextLabel.CreateTextLabel(Main.StringToU16("~g~To hospital"), new Vector3(emsCheckpoints[7].X, emsCheckpoints[7].Y, emsCheckpoints[7].Z + 0.3), 5F, 0.3F, 0, new Color(255, 255, 255));

                col = NAPI.ColShape.CreateCylinderColShape(emsCheckpoints[8], 1, 2, 0); // to roof
                col.SetData("INTERACT", 63);
                col.OnEntityEnterColShape += emsShape_onEntityEnterColShape;
                col.OnEntityExitColShape += emsShape_onEntityExitColShape;
                //NAPI.TextLabel.CreateTextLabel(Main.StringToU16("~g~To roof"), new Vector3(emsCheckpoints[8].X, emsCheckpoints[8].Y, emsCheckpoints[8].Z + 0.3), 5F, 0.3F, 0, new Color(255, 255, 255));

                #endregion

                for (int i = 3; i < emsCheckpoints.Count; i++)
                {
                    Marker marker = NAPI.Marker.CreateMarker(1, emsCheckpoints[i] - new Vector3(0, 0, 0.7), new Vector3(), new Vector3(), 1, new Color(255, 255, 255, 220));
                }
            }
            catch (Exception e) { Log.Write("ResourceStart: " + e.Message, nLog.Type.Error); }
        }

        public static List<Vector3> emsCheckpoints = new List<Vector3>()
        {
            new Vector3(-22298.6205, -584.6313, -5000.14088), // enter ems          0
            new Vector3(-22275.446, -1361.11, -5000.5378),    // exit ems           1
            new Vector3(-468.638, -288.962, 34.911),  // Спавн после смерти  2 +
            new Vector3(-453.5629, -308.297, 33.910), // Инвентарь/шкаф        3 +
            new Vector3(-438.068, -307.675, 33.910),     // Сменить одежду     4 + 
            new Vector3(-435.95023, -325.8292, 33.91), // Лечение              5 +
            new Vector3(-467.28265, -294.61368, 33.91),  // Удаление тату        6 +
            new Vector3(339.0912, -583.9084, 73.04566), // roof               7
            new Vector3(247.0829, -1371.738, 23.41781), // to roof            8
        };

        public static void callEms(Player player, bool death = false)
        {
            if (!death)
            {
                if (Manager.countOfFractionMembers(8) == 0)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Es gibt keine Ärzte in Ihrer Nähe. Versuche es später", 3000);
                    return;
                }
                if (player.HasData("NEXTCALL_EMS") && DateTime.Now < player.GetData<DateTime>("NEXTCALL_EMS"))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Du hast den Ärzte bereits angerufen, versuch es später erneut", 3000);
                    return;
                }
                player.SetData("NEXTCALL_EMS", DateTime.Now.AddMinutes(7));
            }

            if (death && (Main.Players[player].InsideHouseID != -1 || Main.Players[player].InsideGarageID != -1)) return;

            if (player.HasData("CALLEMS_BLIP"))
                NAPI.Task.Run(() => { try { NAPI.Entity.DeleteEntity(player.GetData<Blip>("CALLEMS_BLIP")); } catch { } });

            var Blip = NAPI.Blip.CreateBlip(0, player.Position, 0.75f, 70, $"Spieler ({player.Value})", 0, 0, true, 0, NAPI.GlobalDimension);
            NAPI.Blip.SetBlipTransparency(Blip, 0);
            foreach (var p in NAPI.Pools.GetAllPlayers())
            {
                if (!Main.Players.ContainsKey(p) || Main.Players[p].FractionID != 8) continue;
                Trigger.ClientEvent(p, "changeBlipAlpha", Blip, 255);
            }
            player.SetData("CALLEMS_BLIP", Blip);

            var colshape = NAPI.ColShape.CreateCylinderColShape(player.Position, 70, 4, 0);
            colshape.OnEntityExitColShape += (s, e) =>
            {
                if (e == player)
                {
                    try
                    {
                        if (Blip != null) Blip.Delete();
                        e.ResetData("CALLEMS_BLIP");

                        NAPI.Task.Run(() =>
                        {
                            try
                            {
                                colshape.Delete();
                            }
                            catch { }
                        }, 20);
                        e.ResetData("CALLEMS_COL");
                        e.ResetData("IS_CALLEMS");
                    }
                    catch (Exception ex) { Log.Write("EnterEmsCall: " + ex.Message); }
                }
            };
            player.SetData("CALLEMS_COL", colshape);

            player.SetData("IS_CALLEMS", true);
            Manager.sendFractionMessage(8, $"Erhielt einen Anruf von einem Spieler ({player.Value})");
            Manager.sendFractionMessage(8, $"~b~Vom Spieler einen Anruf erhalten ({player.Value})", true);
        }

        public static void acceptCall(Player player, Player target)
        {
            int where = -1;
            try
            {
                where = 0;
                if (!Manager.canUseCommand(player, "ems")) return;
                where = 1;
                if (!target.HasData("IS_CALLEMS"))
                {
                    where = 2;
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Der Spieler hat den EMS nicht angerufen", 3000);
                    return;
                }
                where = 3;
                Blip blip = target.GetData<Blip>("CALLEMS_BLIP");

                where = 4;
                Trigger.ClientEvent(player, "changeBlipColor", blip, 38);
                where = 5;
                Trigger.ClientEvent(player, "createWaypoint", blip.Position.X, blip.Position.Y);
                where = 6;

                ColShape colshape = target.GetData<ColShape>("CALLEMS_COL");
                where = 7;
                colshape.OnEntityEnterColShape += (s, e) =>
                {
                    if (e == player)
                    {
                        try
                        {
                            NAPI.Entity.DeleteEntity(target.GetData<Blip>("CALLEMS_BLIP"));
                            target.ResetData("CALLEMS_BLIP");
                            NAPI.Task.Run(() =>
                            {
                                try
                                {
                                    colshape.Delete();
                                }
                                catch { }
                            }, 20);
                        }
                        catch (Exception ex) { Log.Write("EnterEmsCall: " + ex.Message); }
                    }
                };
                where = 8;

                Manager.sendFractionMessage(7, $"{player.Name.Replace('_', ' ')} Nahm den Notruf eines Spielers an ({target.Value})");
                where = 9;
                Manager.sendFractionMessage(7, $"~b~{player.Name.Replace('_', ' ')} Nahm den Notruf eines Spielers an ({target.Value})", true);
                where = 10;
                Notify.Send(target, NotifyType.Info, NotifyPosition.MapUp, $"Spieler ({player.Value}) Nahm den Notruf an", 3000);
                where = 11;
            }
            catch (Exception e) { Log.Write($"acceptCall/{where}/: {e.ToString()}"); }
        }

        public static void onPlayerDisconnectedhandler(Player player, DisconnectionType type, string reason)
        {
            try
            {
                if (player.HasData("HEAL_TIMER"))
                {
                    //Main.StopT(player.GetData("HEAL_TIMER"), "timer_7");
                    Timers.Stop(player.GetData<string>("HEAL_TIMER"));
                }

                if (player.HasData("DYING_TIMER"))
                {
                    //Main.StopT(player.GetData("DYING_TIMER"), "timer_8");
                    Timers.Stop(player.GetData<String>("DYING_TIMER"));
                }

                if (player.HasData("CALLEMS_BLIP"))
                {
                    NAPI.Entity.DeleteEntity(player.GetData<Blip>("CALLEMS_BLIP"));

                    Manager.sendFractionMessage(8, $"{player.Name.Replace('_', ' ')} Anruf abgebrochen");
                }
                if (player.HasData("CALLEMS_COL"))
                {
                    NAPI.ColShape.DeleteColShape(player.GetData<ColShape>("CALLEMS_COL"));
                }
            }
            catch (Exception e) { Log.Write("PlayerDisconnected: " + e.Message, nLog.Type.Error); }
        }

        private static List<string> deadAnims = new List<string>() { "dead_a", "dead_b", "dead_c", "dead_d", "dead_e", "dead_f", "dead_g", "dead_h" };
        [ServerEvent(Event.PlayerDeath)]
        public void onPlayerDeathHandler(Player player, Player entityKiller, uint weapon)
        {
            try
            {
                if (!Main.Players.ContainsKey(player)) return;

                Log.Debug($"{player.Name} is died by {weapon}");

                FractionCommands.onPlayerDeathHandler(player, entityKiller, weapon);
                SafeMain.onPlayerDeathHandler(player, entityKiller, weapon);
                Weapons.Event_PlayerDeath(player, entityKiller, weapon);
                Army.Event_PlayerDeath(player, entityKiller, weapon);
                Police.Event_PlayerDeath(player, entityKiller, weapon);
                Houses.HouseManager.Event_OnPlayerDeath(player, entityKiller, weapon);

                Jobs.FarmerJob.Farmer.StartWork(player, false); //todo Farmer
                Jobs.Collector.Event_PlayerDeath(player, entityKiller, weapon);
                Jobs.Gopostal.Event_PlayerDeath(player, entityKiller, weapon);
                //Jobs.Construction.Event_PlayerDeath(player, entityKiller, weapon);
                //Jobs.Miner.Event_PlayerDeath(player, entityKiller, weapon);

                VehicleManager.WarpPlayerOutOfVehicle(player);
                Main.Players[player].IsAlive = false;
                if (player.HasData("AdminSkin"))
                {
                    player.ResetData("AdminSkin");
                    player.SetSkin((Main.Players[player].Gender) ? PedHash.FreemodeMale01 : PedHash.FreemodeFemale01);
                    Customization.ApplyCharacter(player);
                }
                Trigger.ClientEvent(player, "screenFadeOut", 2000);
                var dimension = player.Dimension;

                if (Main.Players[player].DemorganTime != 0 || Main.Players[player].ArrestTime != 0)
                    player.SetData("IS_DYING", true);

                if (!player.HasData("IS_DYING"))
                {
                    if ((Manager.FractionTypes[Main.Players[player].FractionID] == 0 && (MafiaWars.warIsGoing || MafiaWars.warStarting)) ||
                        (Manager.FractionTypes[Main.Players[player].FractionID] == 1 && (GangsCapture.captureIsGoing || GangsCapture.captureStarting)))
                    {
                        player.SetSharedData("InDeath", true);
                        DeathConfirm(player, false);
                    }
                    else
                    {
                        player.SetSharedData("InDeath", true);
                        var medics = 0;
                        foreach (var m in Manager.Members) if (m.Value.FractionID == 8) medics++;
                        Trigger.ClientEvent(player, "openDialog", "DEATH_CONFIRM", $"Wollen sie den Notarzt rufen? ({medics} online)");
                    }
                }
                else
                {
                    NAPI.Task.Run(() => {
                        try
                        {
                            if (!Main.Players.ContainsKey(player)) return;

                            if (player.HasData("DYING_TIMER"))
                            {
                                Timers.Stop(player.GetData<string>("DYING_TIMER"));
                                player.ResetData("DYING_TIMER");
                            }

                            if (player.HasData("CALLEMS_BLIP"))
                            {
                                NAPI.Entity.DeleteEntity(player.GetData<Blip>("CALLEMS_BLIP"));
                                player.ResetData("CALLEMS_BLIP");
                            }

                            if (player.HasData("CALLEMS_COL"))
                            {
                                NAPI.ColShape.DeleteColShape(player.GetData<ColShape>("CALLEMS_COL"));
                                player.ResetData("CALLEMS_COL");
                            }

                            Trigger.ClientEvent(player, "DeathTimer", false);
                            player.SetSharedData("InDeath", false);
                            var spawnPos = new Vector3();

                            if (Main.Players[player].DemorganTime != 0)
                            {
                                spawnPos = Admin.DemorganPosition + new Vector3(0, 0, 1.12);
                                dimension = 1337;
                            }
                            else if (Main.Players[player].ArrestTime != 0)
                                spawnPos = Police.policeCheckpoints[4];
                            else if (Main.Players[player].FractionID == 14)
                                spawnPos = Fractions.Manager.FractionSpawns[14] + new Vector3(0, 0, 1.12);
                            else
                            {
                                player.SetData("IN_HOSPITAL", true);
                                spawnPos = emsCheckpoints[2];
                            }

                            NAPI.Player.SpawnPlayer(player, spawnPos);
                            NAPI.Player.SetPlayerHealth(player, 20);
                            player.ResetData("IS_DYING");
                            Main.Players[player].IsAlive = true;
                            Main.OffAntiAnim(player);
                            NAPI.Entity.SetEntityDimension(player, dimension);
                            Trigger.ClientEvent(player, "closeDeathscreen");
                        }
                        catch { }
                    }, 4000);
                }
            }
            catch (Exception e) { Log.Write("PlayerDeath: " + e.Message, nLog.Type.Error); }
        }

        public static void DeathConfirm(Player player, bool call)
        {
            NAPI.Player.SpawnPlayer(player, player.Position);
            NAPI.Entity.SetEntityDimension(player, 0);

            Main.OnAntiAnim(player);
            player.SetData("IS_DYING", true);
            player.SetData("DYING_POS", player.Position);

           // if (call) callEms(player, true);
            Voice.Voice.PhoneHCommand(player);

            NAPI.Player.SetPlayerHealth(player, 10);
            var time = (call) ? 600000 : 180000;
            Trigger.ClientEvent(player, "DeathTimer", time);
            var timeMsg = (call) ? "10 Minuten wirst du nicht von einem Arzt oder einer anderen Person Versorgt" : "3 Minuten wird dich niemand Versorgen";
            player.SetData("DYING_TIMER", Timers.StartOnce(time, () => DeathTimer(player, player.Name)));
                        Trigger.ClientEvent(player, "openDeathscreen");
            var deadAnimName = deadAnims[Main.rnd.Next(deadAnims.Count)];
            NAPI.Task.Run(() => { try { player.PlayAnimation("dead", deadAnimName, 39); } catch { } }, 500);

            Notify.Send(player, NotifyType.Alert, NotifyPosition.MapUp, $"Wenn während {timeMsg}, dann werden Sie ins Krankenhaus gebracht", 3000);
        }

        public static void DeathTimer(Player player, string name)
        {
            if (player.Name != name) return; // хз почему, но иногда в таймеры передаются другие игроки
            player.Health = 0;
        }

        public static void payMedkit(Player player)
        {
            if (Main.Players[player].Money < player.GetData<long>("PRICE"))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast nicht so viel Geld", 3000);
                return;
            }
            Player seller = player.GetData<Player>("SELLER");
            if (player.Position.DistanceTo(seller.Position) > 2)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du bist zu weit vom verkäufer entfernt ", 3000);
                return;
            }
            var item = nInventory.Find(Main.Players[seller].UUID, ItemType.HealthKit);
            if (item == null || item.Count < 1)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Verkäufer hat keine Erste-Hilfe-Sets", 3000);
                return;
            }
            var tryAdd = nInventory.TryAdd(player, new nItem(ItemType.HealthKit));
            if (tryAdd == -1 || tryAdd > 0)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Nicht genug Platz im Inventar", 3000);
                return;
            }

            nInventory.Add(player, new nItem(ItemType.HealthKit));
            nInventory.Remove(seller, ItemType.HealthKit, 1);

            Fractions.Stocks.fracStocks[6].Money += Convert.ToInt32(player.GetData<long>("PRICE") * 0.85);
            MoneySystem.Wallet.Change(player, -player.GetData<int>("PRICE"));
            MoneySystem.Wallet.Change(seller, Convert.ToInt32(player.GetData<long>("PRICE") * 0.15));

            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du hast einen Erste-Hilfe-Kasten gekauft", 3000);
            Notify.Send(seller, NotifyType.Info, NotifyPosition.MapUp, $"Spieler ({player.Value}) Ich habe den Erste-Hilfe-Kasten bei Ihnen gekauft", 3000);
        }

        public static void payHeal(Player player)
        {
            if (Main.Players[player].Money < player.GetData<long>("PRICE"))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast nicht so viel Geld", 3000);
                return;
            }
            var seller = player.GetData<Player>("SELLER");
            if (player.Position.DistanceTo(seller.Position) > 2)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du bist zu weit vom Arzt entfernt", 3000);
                return;
            }
            if (NAPI.Player.IsPlayerInAnyVehicle(seller) && NAPI.Player.IsPlayerInAnyVehicle(player))
            {
                var pveh = seller.Vehicle;
                var tveh = player.Vehicle;
                Vehicle veh = NAPI.Entity.GetEntityFromHandle<Vehicle>(pveh);
                if (veh.GetData<string>("ACCESS") != "FRACTION" || veh.GetData<object>("TYPE") != "EMS" || !veh.HasData("CANMEDKITS"))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du sitzt nicht in einem EMS-Fahrzeug", 3000);
                    return;
                }
                if (pveh != tveh)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler sitzt in einem anderen Auto", 3000);
                    return;
                }
                Notify.Send(seller, NotifyType.Success, NotifyPosition.MapUp, $"Du hast einen Spieler Behandelt ({player.Value})", 3000);
                Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Spieler ({seller.Value}) hat dich Behandelt", 3000);
                Trigger.ClientEvent(player, "stopScreenEffect", "PPFilter");
                NAPI.Player.SetPlayerHealth(player, 100);
                MoneySystem.Wallet.Change(player, -player.GetData<int>("PRICE"));
                MoneySystem.Wallet.Change(seller, player.GetData<int>("PRICE"));
                GameLog.Money($"player({Main.Players[player].UUID})", $"player({Main.Players[seller].UUID})", player.GetData<long>("PRICE"), $"payHeal");
                return;
            }
            else if (seller.GetData<bool>("IN_HOSPITAL") && player.GetData<bool>("IN_HOSPITAL"))
            {
                Notify.Send(seller, NotifyType.Success, NotifyPosition.MapUp, $"Du hast einen Spieler Behandelt ({player.Value})", 3000);
                Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Spieler ({seller.Value}) hat dich Behandelt", 3000);
                NAPI.Player.SetPlayerHealth(player, 100);
                MoneySystem.Wallet.Change(player, -player.GetData<int>("PRICE"));
                MoneySystem.Wallet.Change(seller, player.GetData<int>("PRICE"));
                GameLog.Money($"player({Main.Players[player].UUID})", $"player({Main.Players[seller].UUID})", player.GetData<long>("PRICE"), $"payHeal");
                Trigger.ClientEvent(player, "stopScreenEffect", "PPFilter");
                return;
            }
            else
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du musst in einem Krankenhaus oder Krankenwagen sein", 3000);
                return;
            }
        }

        public static void interactPressed(Player player, int interact)
        {
            switch (interact)
            {
                case 15:
                    if (player.IsInVehicle) return;
                    if (player.HasData("FOLLOWING"))
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du folgst jemanden", 3000);
                        return;
                    }
                    player.SetData("IN_HOSPITAL", true);
                    NAPI.Entity.SetEntityPosition(player, emsCheckpoints[1] + new Vector3(0, 0, 1.12));
                    Main.PlayerEnterInterior(player, emsCheckpoints[1] + new Vector3(0, 0, 1.12));
                    return;
                case 16:
                    if (player.HasData("FOLLOWING"))
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du folgst jemanden", 3000);
                        return;
                    }
                    if (NAPI.Player.GetPlayerHealth(player) < 100)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du musst solange warten bis deine Behandlung abgeschlossen ist", 3000);
                        break;
                    }

                    player.SetData("IN_HOSPITAL", false);
                    NAPI.Entity.SetEntityPosition(player, emsCheckpoints[0] + new Vector3(0, 0, 1.12));
                    Main.PlayerEnterInterior(player, emsCheckpoints[0] + new Vector3(0, 0, 1.12));
                    return;
                case 17:
                    if (Main.Players[player].FractionID != 8)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du bist kein EMS-Mitarbeiter", 3000);
                        return;
                    }
                    if (!player.GetData<bool>("ON_DUTY"))
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast den Dienst noch nicht Angetreten", 3000);
                        return;
                    }
                    if (!Stocks.fracStocks[8].IsOpen)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Das Lager ist geschlossen", 3000);
                        return;
                    }
                    OpenHospitalStockMenu(player);
                    return;
                case 18:
                    if (Main.Players[player].FractionID == 8)
                    {
                        if (!NAPI.Data.GetEntityData(player, "ON_DUTY"))
                        {
                            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du hast den Dienst Angetreten", 3000);
                            Manager.setSkin(player, 8, Main.Players[player].FractionLVL);
                            NAPI.Data.SetEntityData(player, "ON_DUTY", true);
                            break;
                        }
                        else
                        {
                            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du hast den Dienst Beendet", 3000);
                            Customization.ApplyCharacter(player);
                            if (player.HasData("HAND_MONEY")) player.SetClothes(5, 45, 0);
                            else if (player.HasData("HEIST_DRILL")) player.SetClothes(5, 41, 0);
                            NAPI.Data.SetEntityData(player, "ON_DUTY", false);
                            break;
                        }
                    }
                    else Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du bist kein EMS-Mitarbeiter", 3000);
                    return;
                case 19:
                    if (NAPI.Player.GetPlayerHealth(player) > 99)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du brauchst keine Behandlung", 3000);
                        break;
                    }
                    if (player.HasData("HEAL_TIMER"))
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du wirst bereits Behandelt", 3000);
                        break;
                    }
                    Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du hast mit der Behandlung begonnen", 3000);
                    player.SetData("HEAL_TIMER", Timers.Start(3750, () => healTimer(player)));
                    return;
                case 51:
                    OpenTattooDeleteMenu(player);
                    return;
                case 58:
                    if (Main.Players[player].FractionID != 8)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du bist kein EMS-Mitarbeiter", 3000);
                        break;
                    }
                    if (!player.IsInVehicle || !player.Vehicle.HasData("CANMEDKITS"))
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du bist nicht in deinem auto oder dein auto kann kein Erste-Hilfe-Kasten Transportieren", 3000);
                        break;
                    }

                    var medCount = VehicleInventory.GetCountOfType(player.Vehicle, ItemType.HealthKit);
                    if (medCount >= 50)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Es liegt die Maximale anzahl an Erste-Hilfe-Kasten im Auto", 3000);
                        break;
                    }
                    if (HumanMedkitsLefts <= 0)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Wir haben keine Erste-Hilfe-Kästen mehr. Kommen Sie in einer Stunde für mehr zurück", 3000);
                        break;
                    }
                    var toAdd = (HumanMedkitsLefts > 50 - medCount) ? 50 - medCount : HumanMedkitsLefts;
                    HumanMedkitsLefts = toAdd;

                    VehicleInventory.Add(player.Vehicle, new nItem(ItemType.HealthKit, toAdd));
                    Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du hast das Auto mit Erste-Hilfe-Kästen Befüllt", 3000);
                    return;
                case 63:
                    if (Main.Players[player].FractionID != 8)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du bist kein EMS-Mitarbeiter", 3000);
                        break;
                    }
                    if (player.IsInVehicle) return;
                    if (player.Position.Z > 50)
                    {
                        if (player.HasData("FOLLOWING"))
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du folgst jemanden", 3000);
                            return;
                        }
                        player.SetData("IN_HOSPITAL", true);
                        NAPI.Entity.SetEntityPosition(player, emsCheckpoints[8] + new Vector3(0, 0, 1.12));
                        Main.PlayerEnterInterior(player, emsCheckpoints[8] + new Vector3(0, 0, 1.12));
                    }
                    else
                    {
                        if (player.HasData("FOLLOWING"))
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du folgst jemanden", 3000);
                            return;
                        }
                        player.SetData("IN_HOSPITAL", false);
                        NAPI.Entity.SetEntityPosition(player, emsCheckpoints[7] + new Vector3(0, 0, 1.12));
                        Main.PlayerEnterInterior(player, emsCheckpoints[7] + new Vector3(0, 0, 1.12));
                    }
                    return;
            }
        }

        private static void healTimer(Player player)
        {
            NAPI.Task.Run(() =>
            {
                try
                {
                    if (player.Health == 100)
                    {
                        Timers.Stop(player.GetData<string>("HEAL_TIMER"));
                        player.ResetData("HEAL_TIMER");
                        Trigger.ClientEvent(player, "stopScreenEffect", "PPFilter");
                        Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $">Deine Behandlung ist Abgeschlossen", 3000);
                        return;
                    }
                    player.Health = player.Health + 1;
                }
                catch { }
            });
        }

        private void emsShape_onEntityEnterColShape(ColShape shape, Player entity)
        {
            try
            {
                NAPI.Data.SetEntityData(entity, "INTERACTIONCHECK", shape.GetData<int>("INTERACT"));
            }
            catch (Exception ex) { Log.Write("emsShape_onEntityEnterColShape: " + ex.Message, nLog.Type.Error); }
        }

        private void emsShape_onEntityExitColShape(ColShape shape, Player entity)
        {
            try
            {
                NAPI.Data.SetEntityData(entity, "INTERACTIONCHECK", 0);
            }
            catch (Exception ex) { Log.Write("emsShape_onEntityExitColShape: " + ex.Message, nLog.Type.Error); }
        }

        #region menus
        public static void OpenHospitalStockMenu(Player player)
        {
            Menu menu = new Menu("hospitalstock", false, false);
            menu.Callback = callback_hospitalstock;

            Menu.Item menuItem = new Menu.Item("header", Menu.MenuItem.Header);
            menuItem.Text = $"Lagerhaus ({Stocks.fracStocks[8].Medkits}шт)";
            menu.Add(menuItem);

            menuItem = new Menu.Item("takemed", Menu.MenuItem.Button);
            menuItem.Text = "Hol dir ein Erste-Hilfe-Kasten";
            menu.Add(menuItem);

            /*menuItem = new Menu.Item("putmed", Menu.MenuItem.Button);
            menuItem.Text = "Положить аптечку";
            menu.Add(menuItem);*/

            menuItem = new Menu.Item("Funk", Menu.MenuItem.Button);
            menuItem.Text = "Funkgerät nehmen";
            menu.Add(menuItem);

            menuItem = new Menu.Item("close", Menu.MenuItem.Button);
            menuItem.Text = "Schließen";
            menu.Add(menuItem);

            menu.Open(player);
        }
        private static void callback_hospitalstock(Player Player, Menu menu, Menu.Item item, string eventName, dynamic data)
        {
            switch (item.ID)
            {
                case "takemed":
                    if (!Manager.canGetWeapon(Player, "Medkits")) return;
                    if (Stocks.fracStocks[8].Medkits <= 0)
                    {
                        Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, $"Im Lager sind keine Erste-Hilfe-Kasten mehr vorhanden", 3000);
                        return;
                    }
                    var tryAdd = nInventory.TryAdd(Player, new nItem(ItemType.HealthKit));
                    if (tryAdd == -1 || tryAdd > 0)
                    {
                        Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, $"Nicht genug Platz im Inventar", 3000);
                        return;
                    }
                    nInventory.Add(Player, new nItem(ItemType.HealthKit));
                    var itemInv = nInventory.Find(Main.Players[Player].UUID, ItemType.HealthKit);
                    Notify.Send(Player, NotifyType.Info, NotifyPosition.MapUp, $"Du hast den Erste-Hilfe-Kasten mitgenommen. Du hast {itemInv.Count} Gerät", 3000);
                    Stocks.fracStocks[8].Medkits--;
                    GameLog.Stock(Main.Players[Player].FractionID, Main.Players[Player].UUID, "medkit", 1, false);
                    break;
                case "putmed":
                    itemInv = nInventory.Find(Main.Players[Player].UUID, ItemType.HealthKit);
                    if (itemInv == null)
                    {
                        Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast keine Erste-Hilfe-Kästen", 3000);
                        return;
                    }
                    nInventory.Remove(Player, ItemType.HealthKit, 1);
                    Notify.Send(Player, NotifyType.Info, NotifyPosition.MapUp, $"Du stellst den Erste-Hilfe-Kasten. Du hast {itemInv.Count - 1} Gerät", 3000);
                    Stocks.fracStocks[8].Medkits++;
                    GameLog.Stock(Main.Players[Player].FractionID, Main.Players[Player].UUID, "medkit", 1, true);
                    break;
                case "Funk":
                    if (!Main.Players.ContainsKey(Player)) return;

                    if (Main.Players[Player].FractionLVL < 1)
                    {
                        Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast keinen Zugang zu einem Funkgerät", 3000);
                        return;
                    }

                    nInventory.Add(Player, new nItem(ItemType.Funk, 1));
                    return;
                case "close":
                    MenuManager.Close(Player);
                    return;
            }

            Menu.Item menuItem = new Menu.Item("header", Menu.MenuItem.Header);
            menuItem.Text = $"Склад ({Stocks.fracStocks[8].Medkits}шт)";
            menu.Change(Player, 0, menuItem);
        }

        public static void OpenTattooDeleteMenu(Player player)
        {
            Menu menu = new Menu("tattoodelete", false, false);
            menu.Callback = callback_tattoodelete;

            Menu.Item menuItem = new Menu.Item("header", Menu.MenuItem.Header);
            menuItem.Text = $"Tätowierungen";
            menu.Add(menuItem);

            menuItem = new Menu.Item("header", Menu.MenuItem.Card);
            menuItem.Text = $"Wählen sie den Bereicht in dem alle Tattoos entfernt werden sollen - 3000$";
            menu.Add(menuItem);

            menuItem = new Menu.Item("Torso", Menu.MenuItem.Button);
            menuItem.Text = "Brust";
            menu.Add(menuItem);

            menuItem = new Menu.Item("Head", Menu.MenuItem.Button);
            menuItem.Text = "Kopf";
            menu.Add(menuItem);

            menuItem = new Menu.Item("LeftArm", Menu.MenuItem.Button);
            menuItem.Text = "linke Hand";
            menu.Add(menuItem);

            menuItem = new Menu.Item("RightArm", Menu.MenuItem.Button);
            menuItem.Text = "rechte Hand";
            menu.Add(menuItem);

            menuItem = new Menu.Item("LeftLeg", Menu.MenuItem.Button);
            menuItem.Text = "linkes Bein";
            menu.Add(menuItem);

            menuItem = new Menu.Item("RightLeg", Menu.MenuItem.Button);
            menuItem.Text = "rechtes Bein";
            menu.Add(menuItem);

            menuItem = new Menu.Item("close", Menu.MenuItem.Button);
            menuItem.Text = "Schließen";
            menu.Add(menuItem);

            menu.Open(player);
        }

        private static List<string> TattooZonesNames = new List<string>() { "Brust", "Kopf", "linke Hand", "rechte Hand", "linkes Bein", "rechtes Bein" };
        private static void callback_tattoodelete(Player Player, Menu menu, Menu.Item item, string eventName, dynamic data)
        {
            if (item.ID == "close")
            {
                MenuManager.Close(Player);
                return;
            }
            var zone = Enum.Parse<TattooZones>(item.ID);
            if (Customization.CustomPlayerData[Main.Players[Player].UUID].Tattoos[Convert.ToInt32(zone)].Count == 0)
            {
                Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, "Du hast keine keine Tätowierungen in diesem Bereich", 3000);
                return;
            }
            if (!MoneySystem.Wallet.Change(Player, -600))
            {
                Notify.Send(Player, NotifyType.Error, NotifyPosition.MapUp, "Unzureichende Mittel", 3000);
                return;
            }
            GameLog.Money($"player({Main.Players[Player].UUID})", $"server", 600, $"tattooRemove");
            Fractions.Stocks.fracStocks[6].Money += 600;

            foreach (var tattoo in Customization.CustomPlayerData[Main.Players[Player].UUID].Tattoos[Convert.ToInt32(zone)])
            {
                var decoration = new Decoration();
                decoration.Collection = NAPI.Util.GetHashKey(tattoo.Dictionary);
                decoration.Overlay = NAPI.Util.GetHashKey(tattoo.Hash);
                Player.RemoveDecoration(decoration);
            }
            Customization.CustomPlayerData[Main.Players[Player].UUID].Tattoos[Convert.ToInt32(zone)] = new List<Tattoo>();
            Player.SetSharedData("TATTOOS", Newtonsoft.Json.JsonConvert.SerializeObject(Customization.CustomPlayerData[Main.Players[Player].UUID].Tattoos));

            Notify.Send(Player, NotifyType.Success, NotifyPosition.MapUp, "Die Tattoos wurden erfolgreich entfernt " + TattooZonesNames[Convert.ToInt32(zone)], 3000);
        }
        #endregion
    }
}
