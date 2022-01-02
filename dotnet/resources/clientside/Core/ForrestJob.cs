using GTANetworkAPI;
using UNL.SDK;
using System;
using System.Collections.Generic;

namespace ULife.Core
{
    // Custom JOBS which was not before in this mode
    // Related JS files can be found in
    // packages/forrest folder and client_packages/forrest.js
    class ForrestJob : Script
    {
        private static nLog Log = new nLog("GM");

        private class Job
        {
            public string name;
            public string animName;
            public string animFlag;

            public ItemType sourceItemType;
            public ItemType targetItemType;
            public int probability;
            public double itemMoneyRate;
            public double itemExchangeRate = 1.0;
            public bool rewardPlayerByItem;

            public string attachmentModel;

            public List<ItemType> additionalSourceItems = new List<ItemType>() { };
            public List<int> fractionIds = new List<int>() { };

            public Job(
                string name, ItemType sourceItemType, ItemType targetItemType, 
                bool rewardPlayerByItem = true,
                double itemMoneyRate = 1.0,
                int probability = 50,
                string animName = "amb@prop_human_movie_bulb@base",
                string animFlag = "base",
                string attachmentModel = ""
            )
            {
                this.name = name;
                this.sourceItemType = sourceItemType;
                this.targetItemType = targetItemType;
                this.itemMoneyRate = itemMoneyRate;
                this.rewardPlayerByItem = rewardPlayerByItem;
                this.probability = probability;
                if (this.probability < 0 || this.probability > 100)
                {
                    this.probability = 50;
                }
                this.animName = animName;
                this.animFlag = animFlag;
                this.attachmentModel = attachmentModel;
            }

            public Job setAdditionalSourceItems(List<ItemType> additionalSourceItems)
            {
                this.additionalSourceItems = additionalSourceItems;
                return this;
            }

            public Job setItemExchangeRate(double rate)
            {
                this.itemExchangeRate = rate;
                return this;
            }

            public Job setPermissionByFractionIds(List<int> fractionIds)
            {
                this.fractionIds = fractionIds;
                return this;
            }
        }


        private static Dictionary<string, Job> ForrestJobs = new Dictionary<string, Job>() {
            {
                "Apfel Verarbeiter", new Job(
                    "Apfel Verarbeiter", ItemType.Apfel, ItemType.Apfelsaft,
                    true, // true - giveItem instead money
                    1.0, // money rate
                    50, // probability chan
                    "amb@prop_human_movie_bulb@base",
                    "base"
                )
                .setItemExchangeRate(0.5)
            },
            {
                "Trauben Verarbeiter",
                new Job("Trauben Verarbeiter", ItemType.Trauben, ItemType.Wein, true, 1.0, 50, "amb@prop_human_bum_bin@idle_b", "idle_d", "bkr_prop_weed_bucket_open_01a")
                .setItemExchangeRate(0.5)
            },
            {
               "Holz Verarbeiter",
                new Job("Holz Verarbeiter", ItemType.Holz, ItemType.Bat, true, 1.0, 50, "melee@large_wpn@streamed_core", "short_0_attack")
                .setItemExchangeRate(0.5)
            },
            {
                "Orangen Verarbeiter", new Job(
                    "Orangen Verarbeiter", ItemType.Orange, ItemType.Orangensaft,
                    true,
                    1.0,
                    50,
                    "amb@prop_human_movie_bulb@base",
                    "base"
                )
                .setItemExchangeRate(0.5)
            },
            {
                "Metalbarren Verarbeiter", new Job(
                    "Metalbarren Verarbeiter", ItemType.Eisen, ItemType.Metalbarren,
                    true,
                    1.0,
                    50,
                    "amb@world_human_gardener_plant@female@base",
                    "base_female"
                )
                .setItemExchangeRate(0.5)
            },
            {
                "Öl Verarbeiter", new Job(
                    "Öl Verarbeiter", ItemType.Erdöl, ItemType.Öl,
                    true,
                    1.0,
                    50,
                    "amb@world_human_gardener_plant@female@base",
                    "base_female"
                )
                .setItemExchangeRate(0.5)
            },

            // forrest2.js
            {
                "Ephidrin Verarbeiter", new Job(
                    "Ephidrin Verarbeiter", ItemType.Kröten, ItemType.Ephidrin,
                    true,
                    1.0,
                    50,
                    "amb@world_human_gardener_plant@female@base",
                    "base_female"
                )
                .setItemExchangeRate(0.5)
            },
            {
                "Joint Verarbeiter", new Job(
                    "Joint Verarbeiter", ItemType.Marihuana, ItemType.Joint,
                    true,
                    1.0,
                    50,
                    "amb@world_human_gardener_plant@female@base",
                    "base_female"
                )
                .setItemExchangeRate(0.5)
            },
            {
                "Schnaps Verarbeiter", new Job(
                    "Schnaps Verarbeiter", ItemType.Hopfen, ItemType.Schnaps,
                    true,
                    1.0,
                    50,
                    "amb@world_human_gardener_plant@female@base",
                    "base_female"
                )
                .setItemExchangeRate(0.5)
            },
            // forrest3.js
            {
                "Ephidrin Dealer", new Job(
                    "Ephidrin Dealer", ItemType.Ephidrin, ItemType.Sprunk,
                    false,
                    17,
                    20,
                    "amb@world_human_gardener_leaf_blower@idle_a",
                    "idle_a"
                )
            },
            {
                "Joint Dealer", new Job(
                    "Joint Dealer", ItemType.Joint, ItemType.Sprunk,
                    false,
                    15,
                    20,
                    "amb@world_human_gardener_leaf_blower@idle_a",
                    "idle_a"
                )
            },
            {
                "Schnaps Dealer", new Job(
                    "Schnaps Dealer", ItemType.Schnaps, ItemType.Sprunk,
                    false,
                    25,
                    50,
                    "amb@world_human_gardener_leaf_blower@idle_a",
                    "idle_a"
                )
            },
            // forrest4.js
            {
                "Apfel Händler", new Job(
                    "Apfel Händler", ItemType.Apfelsaft, ItemType.Sprunk,
                    false,
                    10.0,
                    50,
                    "amb@world_human_gardener_leaf_blower@idle_a",
                    "idle_a"
                )
            },
            {
                "Wein Händler", new Job(
                    "Wein Händler", ItemType.Wein, ItemType.Sprunk,
                    false,
                    15.50,
                    50,
                    "amb@world_human_gardener_leaf_blower@idle_a",
                    "idle_a"
                )
            },
            {
                "Eisen Händler", new Job(
                    "Eisen Händler", ItemType.Metalbarren, ItemType.Sprunk,
                    false,
                    14,
                    50,
                    "amb@world_human_gardener_leaf_blower@idle_a",
                    "idle_a"
                )
            },
            {
                "Öl Händler", new Job(
                    "Öl Händler", ItemType.Öl, ItemType.Sprunk,
                    false,
                    14,
                    50,
                    "amb@world_human_gardener_leaf_blower@idle_a",
                    "idle_a"
                )
            },
            {
                "Orangen Händler", new Job(
                    "Orangen Händler", ItemType.Orangensaft, ItemType.Sprunk,
                    false,
                    10.0,
                    50,
                    "amb@world_human_gardener_leaf_blower@idle_a",
                    "idle_a"
                )
            },
            {
                "Autobatterie Verarbeiter", new Job(
                    "Autobatterie Verarbeiter", ItemType.Autobatterie, ItemType.Lithium,
                    true,
                    1.0,
                    50,
                    "amb@world_human_gardener_leaf_blower@idle_a",
                    "idle_a"
                )
                .setItemExchangeRate(0.5)
            },
            {
                "Kokain Verarbeiter", new Job(
                    "Kokain Verarbeiter", ItemType.Kokablatt, ItemType.Kokain,
                    true,
                    1.0,
                    50,
                    "amb@world_human_gardener_leaf_blower@idle_a",
                    "idle_a"
                )
                .setAdditionalSourceItems(new List<ItemType>(){ ItemType.Aceton })
                .setItemExchangeRate(1.0)
            },
            {
                "Crystal Meth Verarbeiter", new Job(
                    "Crystal Meth Verarbeiter", ItemType.Ephidrin, ItemType.Crystal,
                    true,
                    1.0,
                    50,
                    "amb@world_human_gardener_leaf_blower@idle_a",
                    "idle_a"
                )
                .setAdditionalSourceItems(new List<ItemType>(){ ItemType.Lithium })
                .setItemExchangeRate(1.0)
            },
            {
                "Crystal Dealer", new Job(
                    "Crystal Dealer", ItemType.Crystal, ItemType.Sprunk,
                    false,
                    40.0,
                    50,
                    "amb@world_human_gardener_leaf_blower@idle_a",
                    "idle_a"
                )
                .setPermissionByFractionIds(new List<int>{ 1, 2, 3, 5, 13, 11, 16, 18, 10, 16 })
            },
            {
                "Kokain Dealer", new Job(
                    "Kokain Dealer", ItemType.Kokain, ItemType.Sprunk,
                    false,
                    45.0,
                    50,
                    "amb@world_human_gardener_leaf_blower@idle_a",
                    "idle_a"
                )
                .setPermissionByFractionIds(new List<int>{ 1, 2, 3, 5, 13, 11, 16, 18, 10, 16  })
            },            {
                "Juwel Händler", new Job(
                    "Juwel Händler", ItemType.Juwel, ItemType.Sprunk,
                    false,
                    500.0,
                    50,
                    "amb@world_human_gardener_leaf_blower@idle_a",
                    "idle_a"
                )
            },
        };


        [RemoteEvent("forrest:collectItem")]
        public static void collectItem(Player player, params object[] arguments)
        {
            string jobName = "";
            string attachmentModel = "";
            int UUID = Main.Players[player].UUID;
            ItemType sourceItemType = ItemType.Unknown;
            int probability = 50;
            // lol Justin ist Cool
            // Configs for every job: 
            // - annimation, 
            // - attached object to hand while collecting, 
            // - rewardItem
            // - rewardItem collecting probability, 
            // - rewardItem max count in inventory
            try
            {
                if (arguments != null) // Without this check will be server crash
                {
                    // 
                    jobName = arguments[0].ToString();
                    if (ForrestJobs.ContainsKey(jobName))
                    {
                        Job job = ForrestJobs[jobName];
                        player.PlayAnimation(
                            job.animName,
                            job.animFlag,
                            1
                        );
                        sourceItemType = job.sourceItemType; // TODO: Change to Holz
                        probability = job.probability;
                        attachmentModel = job.attachmentModel;
                    } else
                    {
                        Notify.Send(player, NotifyType.Warning, NotifyPosition.MapUp,
                            $"Get out from here!",
                        3000);
                        return;
                    }

                    // Freeze position and attach object
                    //player.FreezePosition = true;
                    if (attachmentModel != "")
                    {
                        BasicSync.AttachObjectToPlayer(
                            player,
                            NAPI.Util.GetHashKey(attachmentModel),
                            57005,
                            new Vector3(0.12, -0.03, -0.03), // вверх/вниз, forward/backward по лезвию,  влево/вправо
                            new Vector3(-80, 0, 0)
                        );
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }


            // Items
            NAPI.Task.Run(() => { 
                try {
                    // Stop annimation, dettach object, unfreeze player
                    BasicSync.DetachObject(player);
                    player.StopAnimation();
                    //player.FreezePosition = false;

                    // Check item stack size
                    if (sourceItemType == ItemType.Unknown)
                    {
                        return;
                    } else
                    {
                        int tryAdd = nInventory.TryAdd(player, new nItem(sourceItemType, 1));
                        if (tryAdd == -1 || tryAdd > 0)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast nicht genug Platz", 3000);
                            return;
                        }
                    }


                    // Probability game and item receiving
                    var lucky = new Random().Next(0, 100);
                    if (lucky > probability)
                    {                       
                        nInventory.Add(player, new nItem(sourceItemType, 1));
                        Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp,
                            $"Du hast ein {nInventory.ItemsNames[(int)sourceItemType]} gefunden!",
                        3000);   
                    }
                    else
                    {
                        Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp,
                            $"Du hast leider nichts gefunden! ",
                        3000);
                    }
                } catch (Exception e) {
                    Console.WriteLine(e.ToString());
                } 
            }, 
            3000);
        }

        // Items exchange
        [RemoteEvent("forrest:finishJob")]
        public static void finishJob(Player player, params object[] arguments)
        {
            try
            {
                Job job;
                ItemType sourceItemType;
                ItemType targetItemType;
                bool rewardPlayerByItem;
                double itemMoneyRate;
                // TODO
                //double itemExchangeRate;

                int UUID = Main.Players[player].UUID;
                string jobName = arguments[0].ToString();

                if (ForrestJobs.ContainsKey(jobName))
                {
                    job = ForrestJobs[jobName];
                    sourceItemType = job.sourceItemType;
                    targetItemType = job.targetItemType;
                    rewardPlayerByItem = job.rewardPlayerByItem;
                    itemMoneyRate = job.itemMoneyRate;
                    //itemExchangeRate = job.itemExchangeRate;
                }
                else
                { 
                    Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp,
                        $"{jobName} hat kein Zeit",
                    3000);
                    return;
                }

                if (job.fractionIds.Count > 0)
                {
                    if (! job.fractionIds.Contains(Main.Players[player].FractionID))
                    {
                        Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp,
                            $"Ich kenne dich nicht, verpiss dich bevor ich die Bullen rufe!",
                        3000);
                        return;
                    }
                }



                // Count all source items and give cash or items as reward
                int count = 0;
                var allSourceItems = job.additionalSourceItems;
                allSourceItems.Add(job.sourceItemType);
                foreach (ItemType itemType in allSourceItems)
                {
                    int index = nInventory.FindIndex(UUID, itemType);
                    if (index == -1)
                    {
                        Notify.Send(player, NotifyType.Warning, NotifyPosition.MapUp,
                            $"Du hast nicht Genung {nInventory.ItemsNames[(int)itemType]}",
                        3000);
                        return;
                    }

                    int c = nInventory.Items[UUID][index].Count;
                    if (c <= 0)
                    {
                        Notify.Send(player, NotifyType.Warning, NotifyPosition.MapUp,
                            $"Du hast nicht Genung {nInventory.ItemsNames[(int)itemType]}",
                        3000);
                        return;
                    }
                    
                    if (count == 0)
                    {
                        count = c;
                    }
                    count = Math.Min(c, count);
                }

                if (job.rewardPlayerByItem)
                {
                    // Check item stack size before giving reward
                    int howMuchGive = (int) Math.Round(count * job.itemExchangeRate);
                    int tryAdd = nInventory.TryAdd(player, new nItem(targetItemType, howMuchGive));
                    if (tryAdd == -1 || tryAdd > 0)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast nicht genug Platz", 3000);
                        return;
                    }

                    // Add item
                    // TODO: Add item exchange rate
                    nInventory.Add(player, new nItem(targetItemType, howMuchGive));
                    Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp,
                        $"Du hast {howMuchGive}x {nInventory.ItemsNames[(int)targetItemType]} bekommen!",
                    3000);
                }
                // Or cash
                else
                {
                    MoneySystem.Wallet.Change(player, System.Convert.ToInt32(job.itemMoneyRate * count));
                    Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp,
                        $"Du hast ${job.itemMoneyRate * count} bekommen!",
                    3000);
                }

                foreach (ItemType itemType in allSourceItems)
                {
                    nInventory.Remove(player, new nItem(itemType, count));
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
