using System;
using System.Collections.Generic;
using System.Data;
using GTANetworkAPI;
using ULife.Core;
using UNL.SDK;

namespace ULife.Jobs.FarmerJob
{
    public class Farmer : Script
    {
        #region #1KR Settings
        private static nLog Log = new nLog("Farmer");
        private static List<CharacterData> Farmers = new List<CharacterData>();
        private static ColShape checkpoint;
        private static Random rnd = new Random();
        private static int minsec = 60;
        private static int maxsec = 120;
        private static int maxlvl = 20;
        #endregion

        #region #1KR Инициализация Работы Фермера
        [ServerEvent(Event.ResourceStart)]
        public void Event_FarmerStart()
        {
            try
            {
                #region Создание блипа, текста, колшейпа
                NAPI.Blip.CreateBlip(677, new Vector3(438.3554, 6510.949, 27.49061), 0.75f, 24, "Bauernhof", 255, 0, true, 0, 0); // Блип на карте
                //NAPI.TextLabel.CreateTextLabel("~g~Фермер", new Vector3(438.3554, 6510.949, 29.6), 10f, 0.1f, 0, new Color(255, 255, 255), true, NAPI.GlobalDimension); // Над головой у Ped
                List<Vector3> shapes = new List<Vector3>()
                {
                    new Vector3(438.3554, 6510.949, 28), //Голем
                };
                
                var golemShape = NAPI.ColShape.CreateCylinderColShape(shapes[0], 2f, 2, 0);
                golemShape.OnEntityEnterColShape += (shape, player) =>
                {
                    try
                    {
                        player.SetData("INTERACTIONCHECK", 520);
                    }
                    catch (Exception e)
                    {
                        Log.Write(e.ToString(), nLog.Type.Error);
                    }
                };
                golemShape.OnEntityExitColShape += (shape, player) =>
                {
                    try
                    {
                        player.SetData("INTERACTIONCHECK", 0);
                    }
                    catch (Exception e)
                    {
                        Log.Write(e.ToString(), nLog.Type.Error);
                    }
                };

                #endregion
                for (int i = 0; i < Checkpoints.Count; i++)
                {
                    checkpoint = NAPI.ColShape.CreateCylinderColShape(Checkpoints[i], 1, 2, 0);
                    checkpoint.SetData($"plantID", i);
                    checkpoint.OnEntityEnterColShape += PlayerEnterCheckpoint;
                }
                Log.Write("Loaded", nLog.Type.Success);
            }
            catch (Exception e)
            {
                Log.Write(e.ToString(), nLog.Type.Error);
            }
        }
        #endregion

        #region #1KR Открыть меню Фермера
        public static void OpenFarmerMenu(Player player)
        {
            try
            {
                var item = nInventory.Find(Main.Players[player].UUID, ItemType.Seed);
                int itemcount = item != null ? item.Count : 0;
                LoadLvl(player, "farmer");
                int[] jobinfo = player.GetData<int[]>("job_farmer"); //данные игрока
                List<object> data = new List<object>()
                {
                    jobinfo[0],
                    jobinfo[1],
                    jobinfo[2],
                    itemcount,
                    Farmers.Count,
                    player.GetData<bool>("ON_WORK"),
                    maxlvl
                };
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                Trigger.ClientEvent(player, "openJobsMenu", json);
                //player.SendChatMessage(json);
            }
            catch (Exception e)
            {
                Log.Write(e.ToString(), nLog.Type.Error);
            }
        }
        #endregion

        #region #1KR Начать или Закончить работу фермера
        [RemoteEvent("workstate")]
        public static void StartWork(Player player, bool state, string workname = null)
        {
            if (state)
            {
                var item = nInventory.Find(Main.Players[player].UUID, ItemType.Seed);
                if (item == null)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Du hast keine Samen", 2000);
                    return;
                }
                for (int i = 0; i < Checkpoints.Count; i++)
                {
                    Trigger.ClientEvent(player, "createPlant", Convert.ToInt32($"10{i}"), "Plantage", 1, Checkpoints[i], 1, 0, 255, 0, 0);
                    player.SetData($"seedplant{i}", false);
                    player.ResetData($"regenplant{i}");
                }
                Farmers.Add(Main.Players[player]);
                SetFarmerClothes(player);
                BasicSync.AttachObjectToPlayer(player, NAPI.Util.GetHashKey("prop_cs_trowel"), 57005, new Vector3(0.1, 0, 0), new Vector3(90, 50, -30));
                player.SetData("jobname", "farmer");
                player.SetData("ON_WORK", true);
                Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, "Du arbeitest jetzt als Bauer", 2000);
            }
            else
            {
                try
                {
                    Farmers.Remove(Main.Players[player]);
                    for (int i = 0; i < Checkpoints.Count; i++)
                    {
                        Trigger.ClientEvent(player, "deletePlant", Convert.ToInt32($"10{i}"));
                        Timers.Stop($"{player.Name}farmer{i}"); //остановка всех таймеров
                        player.SetData($"seedplant{i}", false); //можно Reset, надо чекнуть
                        player.ResetData($"regenplant{i}"); //сброс счетчика
                    }
                    SaveLvl(player, "farmer"); //сохранение данных
                    Customization.ApplyCharacter(player);
                    BasicSync.DetachObject(player);
                    player.ResetData("job_farmer");
                    player.ResetData("jobname");
                    player.SetData("ON_WORK", false);
                    Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, "Du hast gekündigt", 2000);
                }
                catch (Exception e)
                {
                    Log.Write(e.ToString(), nLog.Type.Error);
                }
            }
        }

        #endregion

        #region #1KR Игрок зашел в чекпоинт
        private static void PlayerEnterCheckpoint(ColShape colShape, Player player)
        {
            try
            {
                var colID = colShape.GetData<int>("plantID"); //номер колшейпа
                if (player.IsInVehicle) return; //если игрок в машине
                if (player.GetData<string>("jobname") != "farmer") return; //если игрок не работает фермером
                int[] jobinfo = player.GetData<int[]>("job_farmer");
                int lvl = jobinfo[0], exp = jobinfo[1], allpoints = jobinfo[2], sec = Convert.ToInt32(rnd.Next(minsec, maxsec) - lvl * 2);
                if (player.HasData($"regenplant{colID}")) //если колшейп регенерируется
                {
                    Notify.Send(player, NotifyType.Warning, NotifyPosition.MapUp, $"{player.GetData<int>($"regenplant{colID}")}", 2000);
                    return;
                }
                var item = nInventory.Find(Main.Players[player].UUID, ItemType.Seed); //ищем семена у игрока

                if (!player.GetData<bool>($"seedplant{colID}")) //если семена не были посажены сажаем
                {
                    if (item == null) //если у игрока нет семян
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Du hast keine Samen", 2000);
                        return; //не срабатывает
                    }

                    player.SetData($"seedplant{colID}", true); //семена посажены
                    nInventory.Remove(player, item.Type, 1); //отнимаем семена в количестве 1
                    NAPI.Task.Run(() => { Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du hast die Samen gepflanzt", 2000); }, 5000);
                }
                else if (player.GetData<bool>($"seedplant{colID}"))
                {
                    player.ResetData("job_farmer");

                    if (exp == 100 && lvl < maxlvl)
                    {
                        player.SetData("job_farmer", new int[] { ++lvl, ++exp - 100, ++allpoints });
                        Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Herzlichen glückwunsch zu deiner Beförderung: {lvl}", 2000);
                    }
                    else
                    {
                        if (lvl == maxlvl) exp = -1;
                        player.SetData("job_farmer", new int[] { lvl, ++exp, ++allpoints });
                        player.SendChatMessage($"LVL: {lvl}| EXP: {exp}| ALL: {allpoints}");
                    }

                    var tryAdd = nInventory.TryAdd(player, new nItem(ItemType.Hay));
                    player.SendChatMessage(tryAdd.ToString());
                    if (tryAdd == -1 || tryAdd > 0)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Nicht genug Platz in den Taschen", 2000);
                        return;
                    }
                    player.SetData($"seedplant{colID}", false); //семена взяты и начинается процесс регенерации земли
                    NAPI.Task.Run(() =>
                    {
                        nInventory.Add(player, new nItem(ItemType.Hay, 1));
                        Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Geerntet", 2000);
                    }, 5000);
                }
                Trigger.ClientEvent(player, "deletePlant", Convert.ToInt32($"10{colID}")); //удаляется маркер
                PlayFarmerAnimation(player);
                NAPI.Task.Run(() => { player.SetData($"regenplant{colID}", sec); UpdateCheckpointState(colShape, player); }, 5000); //заводится таймер
            }
            catch (Exception e)
            {
                Log.Write(e.ToString(), nLog.Type.Error);
            }
        }
        #endregion

        #region #1KR Таймер обновления
        private static void UpdateCheckpointState(ColShape colShape, Player player)
        {
            var colID = colShape.GetData<int>("plantID"); //номер колшейпа
            if (player.HasData($"regenplant{colID}")) //если колшейп имеет таймер
            {
                Timers.Start($"{player.Name}farmer{colID}", 5000, () =>
                {
                    if (player.HasData($"regenplant{colID}")) player.SetData($"regenplant{colID}", player.GetData<int>($"regenplant{colID}") - 5);
                    if (player.GetData<int>($"regenplant{colID}") < 1) //если таймер меньше 1
                    {
                        if (!player.GetData<bool>($"seedplant{colID}")) //если семена не посажены и процесс начат для регенарации земли
                        {
                            player.ResetData($"regenplant{colID}"); //сбрасываем таймер
                            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, "Die Plantage ist bereit für die Bepflanzung", 2000);
                            Trigger.ClientEvent(player, "createPlant", Convert.ToInt32($"10{colID}"), "Plantage", 1, Checkpoints[colID], 1, 0, 255, 0, 0);
                            Timers.Stop($"{player.Name}farmer{colID}"); //дубляж
                        }
                        else
                        {
                            player.ResetData($"regenplant{colID}"); //сброс таймера
                            player.SetData($"seedplant{colID}", true); //семена взросли
                            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, "Ernte", 2000);
                            Trigger.ClientEvent(player, "createPlant", Convert.ToInt32($"10{colID}"), "Plantage", 1, Checkpoints[colID], 1, 0, 0, 255, 0);
                            Timers.Stop($"{player.Name}farmer{colID}"); //дубляж
                        }
                        //Timers.Stop($"{player.Name}farmer{colID}");
                    }
                });
            }
        }
        #endregion

        #region #1KR Play Animation
        private static void PlayFarmerAnimation(Player player)
        {
            Main.OnAntiAnim(player);
            player.PlayAnimation("amb@world_human_gardener_plant@male@enter", "enter", 1);
            NAPI.Task.Run(() => 
            {
                player.PlayAnimation("amb@world_human_gardener_plant@male@base", "base", 1);

                NAPI.Task.Run(() =>
                {
                    player.PlayAnimation("amb@world_human_gardener_plant@male@exit", "exit", 1);

                    NAPI.Task.Run(() =>
                    {
                        player.StopAnimation();
                        Main.OffAntiAnim(player);

                    }, 6000);

                }, 3000);

            }, 3000);


            //Trigger.ClientEvent(player, "playScenarioJob", "WORLD_HUMAN_GARDENER_PLANT", 0, true); //воспроизводится анимация
        }
        #endregion

        #region #1KR Подгрузка уровня игрока
        public static void LoadLvl(Player player, string workname)
        {
            try
            {
                if (player.HasData($"job_{workname}")) return;
                int lvl = 1, exp = 0, allpoints = 0;
                CharacterData acc = Main.Players[player];
                DataTable result = MySQL.QueryRead($"SELECT * FROM `{workname}` WHERE uuid={acc.UUID}");
                if (result == null || result.Rows.Count == 0)
                {
                    MySQL.Query($"INSERT INTO `{workname}`(`uuid`, `level`, `exp`, `allpoints`) VALUES({acc.UUID}, {lvl}, {exp}, {allpoints})");
                    Log.Write($"Я зарегал игрока {player.Name}", nLog.Type.Warn);
                }
                else
                {
                    foreach (DataRow Row in result.Rows)
                    {
                        lvl = Convert.ToInt32(Row["level"]);
                        exp = Convert.ToInt32(Row["exp"]);
                        allpoints = Convert.ToInt32(Row["allpoints"]);
                    }
                    Log.Write($"Я загрузил игрока {player.Name}", nLog.Type.Warn);
                }
                player.SetData($"job_{workname}", new int[] { lvl, exp, allpoints });
            }
            catch (Exception e)
            {
                Log.Write(e.ToString(), nLog.Type.Error);
            }
        }
        #endregion

        #region #1KR Сохранение уровня игрока
        public static void SaveLvl(Player player, string workname)
        {
            try
            {
                int[] data = player.GetData<int[]>($"job_{workname}");
                if (data == null) return;
                CharacterData acc = Main.Players[player];
                DataTable result = MySQL.QueryRead($"SELECT * FROM `{workname}` WHERE uuid={acc.UUID}");
                if (result == null || result.Rows.Count == 0)
                {
                    MySQL.Query($"INSERT INTO `{workname}`(`uuid`, `level`, `exp`, `allpoints`) VALUES({acc.UUID}, {data[0]}, {data[1]}, {data[2]})");
                    Log.Write("Я зарегистрировал нового пользователя", nLog.Type.Warn);
                }
                else
                {
                    MySQL.Query($"UPDATE `{workname}` SET `level`={data[0]}, `exp`={data[1]}, `allpoints`={data[2]} WHERE uuid={acc.UUID}");
                    Log.Write($"Я обновил данные игрока {player.Name}", nLog.Type.Warn);
                }
            }
            catch (Exception e)
            {
                Log.Write(e.ToString(), nLog.Type.Error);
            }
        }
        #endregion

        #region #1KR Player Clothes
        private static void SetFarmerClothes(Player player)
        {
            Customization.ClearClothes(player, Main.Players[player].Gender);
            player.SetClothes(3, 64, 0);
            player.SetClothes(4, 36, 0);
            player.SetClothes(6, 66, 5);
            player.SetClothes(11, 117, 0);
        }
        #endregion

        #region #1KR Checkpoints
        private static List<Vector3> Checkpoints = new List<Vector3>()
        {
            new Vector3(461.2964, 6468.779, 28.84425),
            new Vector3(461.3177, 6474.811, 28.80018),
            new Vector3(461.2937, 6480.455, 28.67859),
            new Vector3(461.3493, 6486.196, 28.37697),
            new Vector3(461.2838, 6492.039, 28.35583),
            new Vector3(461.2453, 6497.739, 28.67142),

            new Vector3(467.657, 6468.898, 28.86738),
            new Vector3(467.5878, 6473.91, 28.76531),
            new Vector3(467.626, 6480.006, 28.75326),
            new Vector3(467.6512, 6486.813, 28.44364),
            new Vector3(467.6305, 6493.296, 28.34559),
            new Vector3(467.6164, 6499.664, 28.6644),
        };
        #endregion

    }
}
