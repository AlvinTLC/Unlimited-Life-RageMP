using GTANetworkAPI;
using Redage.SDK;
using System;
using System.Collections.Generic;
using NeptuneEvo.Fractions;
using NeptuneEvo.MoneySystem;

namespace NeptuneEvo.Core
{
    class CustomRobbery : Script
    {
        private static nLog Log = new nLog("JewelryRobbery");
        
        public static Dictionary<string, RobberyPoint> JEWELRIES_STORAGE = new Dictionary<string, RobberyPoint>() { };

        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
           
            for (int i = 0; i < ATM.ATMs.Count; i++)
            {
                Vector3 pos = ATM.ATMs[i];
                RobberyPoint atm1 = new RobberyPoint(
                    "ATM #" + i.ToString(),
                    pos.X, pos.Y, pos.Z,
                    new List<Vector3>() { 
                        pos
                    },
                    ItemType.ATMHackingCard,
                    ItemType.Apfel,
                    7,
                    60000*60
                );
                atm1.moneyWillBeReward(100, 2340); // Random money output between $1 and $100 (instead of Item)
                atm1.setJewelrlyHandlerDuration(480000);
            }

            RobberyPoint jewerlyStore = new RobberyPoint(
                "Juwelier",
                -631.480712890625, -237.48617553710938, 38.0731201171875,
                // The points where player will interact in robbery
                new List<Vector3>() {
                    new Vector3(-617.6251, -230.5709, 38.05703353881836),
                    new Vector3(-618.3434, -229.539, 38.05703353881836),
                    new Vector3(-619.6905, -227.6954, 38.05703353881836),
                    new Vector3(-620.5076, -226.5882, 38.05703353881836),
                    new Vector3(-624.4215087890625, -231.12767028808594, 38.05703353881836),
                    new Vector3(-622.9570922851562, -233.14566040039062, 38.05703353881836),
                    new Vector3(-620.1578369140625, -233.43927001953125, 38.05703353881836),
                    new Vector3(-619.7055053710938, -230.3838348388672, 38.05703353881836),
                    new Vector3(-621.044189453125, -228.51296997070312, 38.05703353881836),
                },
                // Needed item to start
                ItemType.Crowbar,
                // Reward item
                ItemType.Juwel,
                // 0 cop should be online to start
                7,
                // When the robbery will be available again (miliseconds)
                60000*30
            );
            jewerlyStore.showMarkers();
            jewerlyStore.moneyWillBeReward(3000, 3500);
        }


        public class RobberyPoint
        {
            ItemType robberyEntranceItem;
            ItemType outputItem;

            string name;
            double x;
            double y;
            double z;
            public List<ColShape> colshapes = new List<ColShape>() { };
            public ColShape entrance;
            public ColShape maxRadius;
            Marker marker;

            DateTime lastEntranceAt = new DateTime(1996, 1, 2);
            Dictionary<int, DateTime> lastActionAt = new Dictionary<int, DateTime>() { };
            int entranceHandlerDuration = 120000;
            int jewelrlyHandlerDuration = 30000;
            public bool locked = true; // if you change it to false, then store 

            List<string> entranceAnimation = new List<string>() {"amb@medic@standing@kneel@base", "base" };
            List <string> robberyAnimation = new List<string>() {"missheist_jewel", "smash_case"};
            public int robberyCooldown = 3600000;

            public List<Vector3> jewelriesPostion = new List<Vector3>() { };

            int copsShouldBeOnline = 0;

            bool rewardByMoney = false;
            int minMoneyReward = 1;
            int maxMoneyReward = 100;
            bool withMarkers = false;

            public RobberyPoint(string name, double x, double y, double z, List<Vector3> colshapes, ItemType robberyEntranceItem, ItemType outputItem, int copsShouldBeOnline, int robberyCooldown = 3600000)
            {
                if (JEWELRIES_STORAGE.ContainsKey(name))
                {
                    Log.Write("The name should be unique! Duplicate " + this.name);
                    return;
                }

                this.robberyCooldown = robberyCooldown;
                this.robberyEntranceItem = robberyEntranceItem;
                this.outputItem = outputItem;
                this.copsShouldBeOnline = copsShouldBeOnline;

                this.name = name;
                this.x = x;
                this.y = y;
                this.z = z;
                this.entrance = NAPI.ColShape.CreateSphereColShape(new Vector3(x, y, z), 1.7f);
                this.maxRadius = NAPI.ColShape.CreateSphereColShape(new Vector3(x, y, z), 10.7f);

                if (colshapes.Count == 0)
                {
                    ColShape shape = NAPI.ColShape.CreateSphereColShape(new Vector3(x, y, z), 1.7f);
                    this.robberyColShapeHandler(shape);
                    this.colshapes.Add(shape);
                }
                else
                {
                    foreach (Vector3 j in colshapes)
                    {
                        ColShape shape = NAPI.ColShape.CreateSphereColShape(j, 1.7f);
                        this.robberyColShapeHandler(shape);
                        this.colshapes.Add(shape);
                    }
                }

                this.jewelriesPostion = colshapes;

                JEWELRIES_STORAGE[this.name] = this;

                entrance.OnEntityEnterColShape += (s, entity) =>
                {
                    try
                    {
                        if (this.locked)
                        {
                            if (entity is Client)
                            {
                                this.openMenu(entity);
                            }
                        }
                    }
                    catch (Exception e) { Console.WriteLine("shape.OnEntityEnterColshape: " + e.Message); }
                };
                entrance.OnEntityExitColShape += (s, entity) =>
                {
                    try
                    {
                        if (entity is Client)
                        {
                            this.closeMenu(entity);
                        }
                    }
                    catch (Exception e) { Console.WriteLine("shape.OnEntityEnterColshape: " + e.Message); }
                };
            }

            void robberyColShapeHandler(ColShape shape)
            {
                shape.OnEntityEnterColShape += (s, entity) =>
                {
                    try
                    {
                        if (entity is Client && ! this.locked)
                        {
                            entity.SendNotification("Drück ~g~F ~w~um auszurauben");
                        }
                    }
                    catch (Exception e) { Console.WriteLine("shape.OnEntityEnterColshape: " + e.Message); }
                };
            }

            public void open()
            {
                this.lastEntranceAt = DateTime.Now;
                if (this.withMarkers)
                {
                    this.marker.Color = new Color(10, 10, 10);
                }
                this.locked = false;
            }

            public void close()
            {
                if (this.withMarkers)
                {
                    this.marker.Color = new Color(0, 200, 0);
                }
                this.locked = true;
            }

            void createBlip(int id, int color, string name)
            {
                Log.Write("Blip creation doesn't implemented");
            }

            bool policeOnDuty(Client player)
            {
                bool result = Police.membersOnline() >= this.copsShouldBeOnline;
                if (!result)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, "Es sind nicht genug Polizisten im Staat!!", 3000);
                }
                return result;
            }

            bool robberyCooldownPassed(Client player)
            {
                bool result = DateTime.Now > this.lastEntranceAt.AddMilliseconds(this.robberyCooldown);
                if (!result)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, "Es wurde bereits alles leergeräumt!!", 3000);
                }
                return result;
            }

            bool hasItem(Client player, ItemType item)
            {
                bool result = false;

                int UUID = Main.Players[player].UUID;
                int index = nInventory.FindIndex(UUID, item);
                if (index != -1)
                {
                    if (nInventory.Items[UUID][index].Count > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        // Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, "You dont have a " + nInventory.ItemsNames[(int)item] + " to open an entrane", 3000);
                    }
                }
                else
                {
                    // Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, "You dont have a " + nInventory.ItemsNames[(int)item] + " to open an entrane", 3000);
                }
                

                return result;
            }

            bool canOpenEntrance(Client player)
            {
                return this.policeOnDuty(player) && this.robberyCooldownPassed(player) && this.hasItem(player, this.robberyEntranceItem);
            }


            public void entranceHandler(Client player)
            {
                Log.Write("ENTRANCE HANDLER");
                if (this.canOpenEntrance(player))
                {
                    player.PlayAnimation(this.entranceAnimation[0], this.entranceAnimation[1], 33); // 33 or 1
                    player.FreezePosition = true;
                    NAPI.Task.Run(() =>
                    {
                        if (this.withMarkers)
                        {
                            player.TriggerEvent("robbery:loadMarkers", this.name, this.jewelriesPostion);
                        }

                        player.FreezePosition = false;
                        player.StopAnimation();

                        this.open();
                        this.alarm(player);

                        player.SendNotification("Drück ~g~F ~w~um auszurauben");
                    }, this.entranceHandlerDuration);


                }
            }

            bool robberyActionPossible(int id, Client player)
            {
                Log.Write(id.ToString());
                if (! this.lastActionAt.ContainsKey(id))
                {
                    this.lastActionAt[id] = new DateTime(1996, 1, 2);
                }

                if (this.locked)
                {
                    Notify.Send(player, NotifyType.Warning, NotifyPosition.BottomCenter, "Zuerst Luke aufbrechen", 3000);
                    return false;
                }

                if (DateTime.Now < this.lastActionAt[id].AddMilliseconds(this.robberyCooldown))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, "Es wurde bereits alles leergeräumt!!", 3000);
                    return false;
                }

                

                return this.policeOnDuty(player) && this.hasItem(player, this.robberyEntranceItem);
            }

            public void robberyAction(Client player, int id)
            {
                if (Main.Players.ContainsKey(player))
                {
                    if (this.robberyActionPossible(id, player))
                    {
                        Log.Write("robberyAction HANDLER");
                        player.PlayAnimation(this.robberyAnimation[0], this.robberyAnimation[1], 1); // 1 or 33
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du brauchst {this.jewelrlyHandlerDuration / 60000} Minuten um alles leerzuräumen!", 3000);
                        this.lastActionAt[id] = DateTime.Now;

                        NAPI.Task.Run(() =>
                        {
                            if (Main.Players.ContainsKey(player))
                            {
                                player.StopAnimation();

                                /*
                                if (! this.maxRadius.IsPointWithin(player.Position))
                                {
                                    Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"You are outside of robbery radius, no money recevied", 3000);
                                    return;
                                }
                                */

                                if (this.rewardByMoney)
                                {
                                    // And this gives money
                                    var lucky = new Random().Next(this.minMoneyReward, this.maxMoneyReward);
                                    MoneySystem.Wallet.Change(player, System.Convert.ToInt32(lucky));
                                    Notify.Send(player, NotifyType.Success, NotifyPosition.BottomCenter, "Du hast " + lucky + "$ ausgeraubt", 3000);
                                    if (this.withMarkers)
                                    {
                                        player.TriggerEvent("robbery:destroyMarker", this.name, id);
                                    }
                                }
                                else
                                {
                                    // This gives item
                                    int tryAdd = nInventory.TryAdd(player, new nItem(this.outputItem, 1));
                                    if (tryAdd == -1 || tryAdd > 0)
                                    {
                                        Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Du hast nicht genug Platz", 3000);
                                        return;
                                    }
                                    else
                                    {
                                        var lucky = new Random().Next(0, 7);
                                        nInventory.Add(player, new nItem(this.outputItem, lucky, "98_0_false")); // This data (98_0_false) is for ItemType.Jewerly (woman)

                                        Notify.Send(player, NotifyType.Success, NotifyPosition.BottomCenter,
                                            $"Du hast {lucky}x {nInventory.ItemsNames[(int)this.outputItem]} gefunden!",
                                        3000);
                                        if (this.withMarkers)
                                        {
                                            player.TriggerEvent("robbery:destroyMarker", this.name, id);
                                        }
                                    }

                                }
                            }
                        }, this.jewelrlyHandlerDuration);
                    }
                }
            }

            public void openMenu(Client player)
            {
                if (this.locked && this.hasItem(player, this.robberyEntranceItem))
                {
                    player.TriggerEvent("robbery:openMenu", this.name);
                }
            }

            public void closeMenu(Client player)
            {
               player.TriggerEvent("robbery:hideMenu");
            }

            public void alarm(Client player)
            {
                Vector3 position = new Vector3(this.x, this.y, this.z);
                Blip blip = NAPI.Blip.CreateBlip(0, position, 1, 59, "Raub", 0, 0, true, 0, 0);
                blip.Transparency = 0;
                foreach (var el in Main.Players)
                {
                    var p = el.Key;
                    if (!Main.Players.ContainsKey(p)) continue;
                    if (Main.Players[p].FractionID != 7 && Main.Players[p].FractionID != 9) continue;

                    Trigger.ClientEvent(p, "changeBlipAlpha", blip, 255);
                    Trigger.ClientEvent(p, "createWaypoint", position.X, position.Y);
                }


                NAPI.Task.Run(() => {
                    try
                    {
                        if (blip != null) blip.Delete();
                    }
                    catch { }
                }, this.robberyCooldown);

                var acc = Main.Players[player];
                var name = this.name;
                var currentWanted = (acc.WantedLVL == null) ? 0 : acc.WantedLVL.Level; //Main.Players[player].WantedLVL.Level;
                var wantedLevel = new WantedLevel(currentWanted + 4, "Polizei", DateTime.Now, this.name + " Raub");
                if (player.GetData("IS_MASK") != null && player.HasSharedData("IS_MASK"))
                {
                    if (! player.GetData("IS_MASK"))
                    {
                        Police.setPlayerWantedLevel(player, wantedLevel);
                        Notify.Send(player, NotifyType.Alert, NotifyPosition.BottomCenter, "Die Polizei ist nun auf dem Weg!!!", 3000);
                        Manager.sendFractionMessage(7, "Ein ATM wird aufgebrochen!!!");
                        Manager.sendFractionMessage(9, "Ein ATM wird aufgebrochen!!!");
                    }
                }
                else
                {
                        Police.setPlayerWantedLevel(player, wantedLevel);
                        Notify.Send(player, NotifyType.Alert, NotifyPosition.BottomCenter, "Die Polizei ist nun auf dem Weg!!!", 3000);
                        Manager.sendFractionMessage(7, "Ein ATM wird aufgebrochen!!!");
                        Manager.sendFractionMessage(9, "Ein ATM wird aufgebrochen!!!");
                }
                

                NAPI.Task.Run(() =>
                {
                    try
                    {
                        if (Main.Players.ContainsKey(player) && this.withMarkers)
                        {
                            for (int id = 0; id < this.colshapes.Count; id++)
                            {
                                player.TriggerEvent("robbery:destroyMarker", this.name, id);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Log.Write(e.Message);
                    }

                    this.close();
                }, this.robberyCooldown);
            }

            public void moneyWillBeReward(int minMoneyReward, int maxMoneyReward)
            {
                this.minMoneyReward = minMoneyReward;
                this.maxMoneyReward = maxMoneyReward;
                this.rewardByMoney = true;
            }

            public void showMarkers()
            {
                this.withMarkers = true;
                this.marker = NAPI.Marker.CreateMarker(29, new Vector3(x, y, z), new Vector3(x, y, z), new Vector3(0, 0, 0), 1f, new Color(0, 200, 0), true, 0);
            }

            public RobberyPoint setEntranceHandlerDuration(int ms)
            {
                this.entranceHandlerDuration = ms;
                return this;
            }

            public RobberyPoint setJewelrlyHandlerDuration(int ms)
            {
                this.jewelrlyHandlerDuration = ms;
                return this;
            }
        }
       
        [RemoteEvent("robbery:etranceEvent")]
        public static void entranceEvent(Client player, params object[] arguments)
        {
            foreach (RobberyPoint jewelry in JEWELRIES_STORAGE.Values)
            {
                if (jewelry.entrance.IsPointWithin(player.Position))
                {
                    jewelry.entranceHandler(player);
                    break;
                }
            }
        }


        [RemoteEvent("robbery:start")] // Press E
        public static void start(Client player, params object[] arguments)
        {
            foreach (RobberyPoint jewelry in JEWELRIES_STORAGE.Values)
            {
                try
                {
                    // Rob checkpoints
                    for (int id = 0; id < jewelry.colshapes.Count; id++)
                    {
                        ColShape col = jewelry.colshapes[id];

                        if (col.IsPointWithin(player.Position))
                        {
                            jewelry.robberyAction(player, id);
                            return;
                        }
                    }
                }
                catch (Exception e)
                {
                    Log.Write(e.Message);
                }
            }
        }
    }
}