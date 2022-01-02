using GTANetworkAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using ULife.Core;
using UNL.SDK;
using System.Linq;
using System.Data;
using ULife.GUI;

namespace ULife.Houses

{
    #region HouseType Class
    public class HouseType
    {
        public string Name { get; }
        public Vector3 Position { get; }
        public string IPL { get; set; }
        public Vector3 PetPosition { get; }
        public float PetRotation { get; }

        public HouseType(string name, Vector3 position, Vector3 petpos, float rotation, string ipl = "")
        {
            Name = name;
            Position = position;
            IPL = ipl;
            PetPosition = petpos;
            PetRotation = rotation;
        }

        public void Create()
        {
            if (IPL != "") NAPI.World.RequestIpl(IPL);
        }
    }
    #endregion

    #region House Class
    class House
    {
        public int ID { get; }
        public string Owner { get; private set; }
        public int Type { get; private set; }
        public Vector3 Position { get; }
        public int Price { get; set; }
        public bool Locked { get; private set; }
        public int GarageID { get; set; }
        public int BankID { get; set; }
        public List<string> Roommates { get; set; } = new List<string>();
        [JsonIgnore] public int Dimension { get; set; }

        [JsonIgnore]
        public Blip blip;
        [JsonIgnore]
        public string PetName;
        [JsonIgnore]
        private TextLabel label;
        [JsonIgnore]
        private ColShape shape;

        [JsonIgnore]
        private ColShape intshape;
        [JsonIgnore]
        private Marker intmarker;

        [JsonIgnore]
        private List<GTANetworkAPI.Object> Objects = new List<GTANetworkAPI.Object>();

        [JsonIgnore]
        private List<NetHandle> PlayersInside = new List<NetHandle>();

        public int Apart { get; set; }
        public House(int id, string owner, int type, Vector3 position, int price, bool locked, int garageID, int bank, List<string> roommates, int apart)
        {
            ID = id;
            Owner = owner;
            Type = type;
            Position = position;
            Price = price;
            Locked = locked;
            GarageID = garageID;
            BankID = bank;
            Roommates = roommates;
            Apart = apart;
            if (Apart != -1)
            {
                Position = Apartments.ApartmentList[Apart].Pos;
                GarageManager.Garages[GarageID].SetPos(Apartments.ApartmentList[Apart].GaragePos, new Vector3(0, 0, Apartments.ApartmentList[Apart].Heading));
                return;
            }

            #region Creating Blip
            blip = NAPI.Blip.CreateBlip(Position);
            if (string.IsNullOrEmpty(Owner))
            {
                blip.Sprite = 374;
                blip.Color = 25;
            }
            else
            {
                blip.Sprite = 374;
                blip.Color = 79;
            }
            blip.Scale = 0.2f;
            blip.ShortRange = true;
            #endregion

            #region Creating Marker & Colshape
            shape = NAPI.ColShape.CreateCylinderColShape(position, 1, 2, 0);
            shape.OnEntityEnterColShape += (s, ent) =>
            {
                try
                {
                    NAPI.Data.SetEntityData(ent, "HOUSEID", id);
                    NAPI.Data.SetEntityData(ent, "INTERACTIONCHECK", 6);
                    Jobs.Gopostal.GoPostal_onEntityEnterColShape(s, ent);
                    Trigger.ClientEvent(ent, "PressE", true);
                }
                catch (Exception ex) { Console.WriteLine("shape.OnEntityEnterColShape: " + ex.Message); }
            };
            shape.OnEntityExitColShape += (s, ent) =>
            {
                try
                {
                    NAPI.Data.SetEntityData(ent, "INTERACTIONCHECK", 0);
                    NAPI.Data.ResetEntityData(ent, "HOUSEID");
                    Trigger.ClientEvent(ent, "PressE", false);
                }
                catch (Exception ex) { Console.WriteLine("shape.OnEntityExitColShape: " + ex.Message); }
            };
            #endregion

            label = NAPI.TextLabel.CreateTextLabel(Main.StringToU16($"House {id}"), position + new Vector3(0, 0, 1.5), 10f, 0.4f, 0, new Color(255, 255, 255), false, 0);
            UpdateLabel();
        }
        public void UpdateLabel()
        {
            if (Apart != -1) return;
            try
            {
                string text = $"Startseite: #{ID}\n";
                if (!string.IsNullOrEmpty(Owner)) text += $"Das Haus ist gekauft.";
                else text += $"Das Haus ist zu verkaufen.";
                text += (Locked) ? "~r~Geschlossen." : "~g~Es ist offen";
                label.Text = Main.StringToU16(text);
            }
            catch (Exception e)
            {
                blip.Color = 48;
                Console.WriteLine(ID.ToString() + e.ToString());
            }
        }
        public void CreateAllFurnitures()
        {
            if (FurnitureManager.HouseFurnitures.ContainsKey(ID))
            {
                if (FurnitureManager.HouseFurnitures[ID].Count >= 1)
                {
                    foreach (var f in FurnitureManager.HouseFurnitures[ID].Values) if (f.IsSet) CreateFurniture(f);
                }
            }
        }
        public void CreateFurniture(HouseFurniture f)
        {
            try
            {
                var obj = f.Create((uint)Dimension);
                NAPI.Data.SetEntityData(obj, "HOUSE", ID);
                NAPI.Data.SetEntityData(obj, "ID", f.ID);
                NAPI.Entity.SetEntityDimension(obj, (uint)Dimension);
                if (f.Name == "Waffentresor") NAPI.Data.SetEntitySharedData(obj, "TYPE", "WeaponSafe");
                else if (f.Name == "Wäscheschrank") NAPI.Data.SetEntitySharedData(obj, "TYPE", "ClothesSafe");
                else if (f.Name == "Schrank") NAPI.Data.SetEntitySharedData(obj, "TYPE", "SubjectSafe");
                Objects.Add(obj);
            }
            catch
            {
            }
        }
        public void DestroyFurnitures()
        {
            try
            {
                foreach (var obj in Objects) NAPI.Entity.DeleteEntity(obj);
                Objects = new List<GTANetworkAPI.Object>();
            }
            catch { }
        }
        public void DestroyFurniture(int id)
        {
            NAPI.Task.Run(() =>
            {
                try
                {
                    foreach (var obj in Objects)
                    {
                        if (obj.HasData("ID") && obj.GetData<int>("ID") == id)
                        {
                            NAPI.Entity.DeleteEntity(obj);
                            //Log.Debug("HOUSEFURNITURE: deleted " + id);
                            break;
                        }
                    }
                }
                catch { }
            });
        }

        public void UpdateBlip()
        {
            if (Apart != -1) return;
            if (string.IsNullOrEmpty(Owner))
            {
                blip.Sprite = 374;
                blip.Color = 52;
            }
            else
            {
                blip.Sprite = 40;
                blip.Color = 49;
            }
        }
        public void Create()
        {
            MySQL.Query($"INSERT INTO `houses`(`id`,`owner`,`type`,`position`,`price`,`locked`,`garage`,`bank`,`roommates`) " +
                $"VALUES ('{ID}','{Owner}',{Type},'{JsonConvert.SerializeObject(Position)}',{Price},{Locked},{GarageID},{BankID},'{JsonConvert.SerializeObject(Roommates)}')");
        }
        public void Save()
        {
            MoneySystem.Bank.Save(BankID);
            MySQL.Query($"UPDATE `houses` SET `owner`='{Owner}',`type`={Type},`position`='{JsonConvert.SerializeObject(Position)}',`price`={Price}," +
                $"`locked`={Locked},`garage`={GarageID},`bank`={BankID},`roommates`='{JsonConvert.SerializeObject(Roommates)}' WHERE `id`='{ID}'");
        }
        public void Destroy()
        {
            RemoveAllPlayers();
            blip.Delete();
            NAPI.ColShape.DeleteColShape(shape);
            NAPI.ColShape.DeleteColShape(intshape);
            label.Delete();
            intmarker.Delete();
            DestroyFurnitures();
        }
        public void SetLock(bool locked)
        {
            Locked = locked;

            UpdateLabel();
            Save();
        }
        public void SetOwner(Player player)
        {
            GarageManager.Garages[GarageID].DestroyCars();
            Owner = (player == null) ? string.Empty : player.Name;
            UpdateBlip();
            UpdateLabel();
            if (player != null)
            {
                Trigger.ClientEvent(player, "changeBlipColor", blip, 73);
                Trigger.ClientEvent(player, "createCheckpoint", 333, 36, GarageManager.Garages[GarageID].Position + new Vector3(0, 0, 0.3f), 1, NAPI.GlobalDimension, 220, 220, 0);
                Trigger.ClientEvent(player, "createGarageBlip", GarageManager.Garages[GarageID].Position);
                /*Hotel.MoveOutPlayer(player);*/

                var vehicles = VehicleManager.getAllPlayerVehicles(Owner);
                if (GarageManager.Garages[GarageID].Type != -1)
                    NAPI.Task.Run(() => { try { GarageManager.Garages[GarageID].SpawnCars(vehicles); } catch { } });
            }

            foreach (var r in Roommates)
            {
                var roommate = NAPI.Player.GetPlayerFromName(r);
                if (roommate != null)
                {
                    Notify.Send(roommate, NotifyType.Warning, NotifyPosition.MapUp, "Du wurdest aus deinen Haus geworfen", 3000);
                    roommate.TriggerEvent("deleteCheckpoint", 333);
                    roommate.TriggerEvent("deleteGarageBlip");
                }
            }

            Roommates = new List<string>();
            Save();
        }
        public string GaragePlayerExit(Player player)
        {
            var players = Main.Players.Keys.ToList();
            var online = players.FindAll(p => Roommates.Contains(p.Name) && p.Name != player.Name);

            var owner = NAPI.Player.GetPlayerFromName(Owner);
            if (Roommates.Contains(player.Name) && owner != null && Main.Players.ContainsKey(owner))
                online.Add(owner);

            var garage = GarageManager.Garages[GarageID];
            var number = garage.SendVehiclesInsteadNearest(online, player);

            return number;
        }
        public void SendPlayer(Player player)
        {
            NAPI.Entity.SetEntityPosition(player, HouseManager.HouseTypeList[Type].Position + new Vector3(0, 0, 1.12));
            NAPI.Entity.SetEntityDimension(player, Convert.ToUInt32(Dimension));
            Main.Players[player].InsideHouseID = ID;
            /* if(HouseManager.HouseTypeList[Type].PetPosition != null) {
                 if(!PetName.Equals("null")) Trigger.ClientEvent(player, "petinhouse",  PetName, HouseManager.HouseTypeList[Type].PetPosition.X, HouseManager.HouseTypeList[Type].PetPosition.Y, HouseManager.HouseTypeList[Type].PetPosition.Z, HouseManager.HouseTypeList[Type].PetRotation, Dimension);
             }*/
            DestroyFurnitures();
            CreateAllFurnitures();
            if (!PlayersInside.Contains(player)) PlayersInside.Add(player);
        }
        #region Меню выхода из дома
        public void RemovePlayer(Player player, bool exit = true)
        {
            if (exit)
            {
                NAPI.Entity.SetEntityPosition(player, Position + new Vector3(0, 0, 1.12));
                NAPI.Entity.SetEntityDimension(player, 0);
            }
            player.ResetData("InvitedHouse_ID");
            Main.Players[player].InsideHouseID = -1;

            if (PlayersInside.Contains(player.Handle)) PlayersInside.Remove(player.Handle);
        }
        #endregion
        public void RemoveFromList(Player player)
        {
            if (PlayersInside.Contains(player)) PlayersInside.Remove(player);
        }
        public void RemoveAllPlayers(Player requster = null)
        {
            for (int i = PlayersInside.Count - 1; i >= 0; i--)
            {
                Player player = NAPI.Entity.GetEntityFromHandle<Player>(PlayersInside[i]);
                if (requster != null && player == requster) continue;

                if (player != null)
                {
                    NAPI.Entity.SetEntityPosition(player, Position + new Vector3(0, 0, 1.12));
                    NAPI.Entity.SetEntityDimension(player, 0);

                    player.ResetData("InvitedHouse_ID");
                    Main.Players[player].InsideHouseID = -1;
                }

                PlayersInside.RemoveAt(i);
            }
        }
        public void CreateInterior()
        {
            #region Creating Interior ColShape & Marker
            intmarker = NAPI.Marker.CreateMarker(1, HouseManager.HouseTypeList[Type].Position - new Vector3(0, 0, 0.7), new Vector3(), new Vector3(), 1, new Color(255, 255, 255, 220), false, (uint)Dimension);

            intshape = NAPI.ColShape.CreateCylinderColShape(HouseManager.HouseTypeList[Type].Position - new Vector3(0.0, 0.0, 1.0), 2f, 4f, (uint)Dimension);
            intshape.OnEntityEnterColShape += (s, ent) =>
            {
                try
                {
                    NAPI.Data.SetEntityData(ent, "INTERACTIONCHECK", 7);
                }
                catch (Exception ex) { Console.WriteLine("intshape.OnEntityEnterColShape: " + ex.Message); }
            };

            intshape.OnEntityExitColShape += (s, ent) =>
            {
                try
                {
                    NAPI.Data.SetEntityData(ent, "INTERACTIONCHECK", 0);
                }
                catch (Exception ex) { Console.WriteLine("intshape.OnEntityExitColShape: " + ex.Message); }
            };
            #endregion
        }

        public void changeOwner(string newName)
        {
            Owner = newName;
            this.UpdateLabel();
            this.Save();
        }
    }
    #endregion

    class HouseManager : Script
    {
        public static nLog Log = new nLog("HouseManager");

        public static List<House> Houses = new List<House>();
        public static List<HouseType> HouseTypeList = new List<HouseType>
        {
            // name, position
            new HouseType("Trailer", new Vector3(1973.124, 3816.065, 32.30873), new Vector3(), 0.0f, "trevorstrailer"),
            new HouseType("Econom", new Vector3(151.2052, -1008.007, -100.12), new Vector3(), 0.0f,"hei_hw1_blimp_interior_v_motel_mp_milo_"),
            new HouseType("Econom+", new Vector3(265.9691, -1007.078, -102.0758), new Vector3(), 0.0f,"hei_hw1_blimp_interior_v_studio_lo_milo_"),
            new HouseType("Comfort", new Vector3(346.6991, -1013.023, -100.3162), new Vector3(349.5223, -994.5601, -99.7562), 264.0f, "hei_hw1_blimp_interior_v_apart_midspaz_milo_"),
            new HouseType("Comfort+", new Vector3(-31.35483, -594.9686, 78.9109),  new Vector3(-25.42115, -581.4933, 79.12776), 159.84f, "hei_hw1_blimp_interior_32_dlc_apart_high2_new_milo_"),
            new HouseType("Premium", new Vector3(-17.85757, -589.0983, 88.99482), new Vector3(-38.84652, -578.466, 88.58952), 50.8f, "hei_hw1_blimp_interior_10_dlc_apart_high_new_milo_"),
            new HouseType("Premium+", new Vector3(-173.9419, 497.8622, 136.5341), new Vector3(-164.9799, 480.7568, 137.1526), 40.0f, "apa_ch2_05e_interior_0_v_mp_stilts_b_milo_"),
            new HouseType("Apartment", new Vector3(-277.71503, -733.5195, 118.75954), new Vector3(-274.63492, 732.2145, 118.76547), -115),
        };
        public static List<int> MaxRoommates = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 2 };

        private static int GetUID()
        {
            int newUID = 0;
            while (Houses.FirstOrDefault(h => h.ID == newUID) != null) newUID++;
            return newUID;
        }

        public static int DimensionID = 10000;

        #region Events
        public static void onResourceStart()
        {
            try
            {
                foreach (HouseType house_type in HouseTypeList) house_type.Create();

                var result = MySQL.QueryRead($"SELECT * FROM `houses`");
                if (result == null || result.Rows.Count == 0)
                {
                    Log.Write("DB return null result.", nLog.Type.Warn);
                    return;
                }
                foreach (DataRow Row in result.Rows)
                {
                    /*House house = JsonConvert.DeserializeObject<House>(Row["data"].ToString());
                    house.Dimension = DimensionID;
                    house.CreateInterior();
                    house.CreateAllFurnitures();

                    Houses.Add(house);
                    DimensionID++;

                    MySQL.Query($"UPDATE houses SET owner='{house.Owner}',type={house.Type},position='{JsonConvert.SerializeObject(house.Position)}',price={house.Price},locked={house.Locked}," +
                        $"garage={house.GarageID},bank={house.BankID},roommates='{JsonConvert.SerializeObject(house.Roommates)}' WHERE id='{house.ID}'");*/

                    try
                    {
                        var id = Convert.ToInt32(Row["id"].ToString());
                        var owner = Convert.ToString(Row["owner"]);
                        var type = Convert.ToInt32(Row["type"]);
                        var position = JsonConvert.DeserializeObject<Vector3>(Row["position"].ToString());
                        var price = Convert.ToInt32(Row["price"]);
                        var locked = Convert.ToBoolean(Row["locked"]);
                        var garage = Convert.ToInt32(Row["garage"]);
                        var bank = Convert.ToInt32(Row["bank"]);
                        var roommates = JsonConvert.DeserializeObject<List<string>>(Row["roommates"].ToString());
                        var apart = Convert.ToInt32(Row["apart"]);

                        House house = new House(id, owner, type, position, price, locked, garage, bank, roommates, apart);
                        house.Dimension = DimensionID;
                        house.CreateInterior();
                        FurnitureManager.Create(id);
                        house.CreateAllFurnitures();

                        Houses.Add(house);
                        DimensionID++;

                    }
                    catch (Exception e)
                    {
                        Log.Write(Row["id"].ToString() + e.ToString(), nLog.Type.Error);
                    }

                }

                NAPI.Object.CreateObject(0x07e08443, new Vector3(1972.76892, 3815.36694, 33.6632576), new Vector3(0, 0, -109.999962), 255, NAPI.GlobalDimension);
                GarageManager.spawnCarsInGarage();
                Log.Write($"Loaded {Houses.Count} houses.", nLog.Type.Success);
            }
            catch (Exception e) { Log.Write("ResourceStart: " + e.Message, nLog.Type.Error); }
        }

        public static void Event_OnPlayerDeath(Player player, Player entityKiller, uint weapon)
        {
            try
            {
                NAPI.Entity.SetEntityDimension(player, 0);
                RemovePlayerFromHouseList(player);
            }
            catch (Exception e) { Log.Write("PlayerDeath: " + e.Message, nLog.Type.Error); }
        }

        public static void Event_OnPlayerDisconnected(Player player, DisconnectionType type, string reason)
        {
            try
            {
                RemovePlayerFromHouseList(player);
            }
            catch (Exception e) { Log.Write("PlayerDisconnected: " + e.Message, nLog.Type.Error); }
        }

        public static void SavingHouses()
        {
            foreach (var h in Houses) h.Save();
            Log.Write("Houses has been saved to DB", nLog.Type.Success);
        }

        [ServerEvent(Event.ResourceStop)]
        public void Event_OnResourceStop()
        {
            try
            {
                SavingHouses();
            }
            catch (Exception e) { Log.Write("ResourceStop: " + e.Message, nLog.Type.Error); }
        }
        #endregion

        #region Methods
        public static House GetHouse(Player player, bool checkOwner = false)
        {
            House house = Houses.FirstOrDefault(h => h.Owner == player.Name);
            if (house != null)
                return house;
            else if (!checkOwner)
            {
                house = Houses.FirstOrDefault(h => h.Roommates.Contains(player.Name));
                return house;
            }
            else
                return null;
        }

        public static House GetHouse(string name, bool checkOwner = false)
        {
            House house = Houses.FirstOrDefault(h => h.Owner == name);
            if (house != null)
                return house;
            else if (!checkOwner)
            {
                house = Houses.FirstOrDefault(h => h.Roommates.Contains(name));
                return house;
            }
            else
                return null;
        }

        public static void RemovePlayerFromHouseList(Player player)
        {
            if (Main.Players[player].InsideHouseID != -1)
            {
                House house = Houses.FirstOrDefault(h => h.ID == Main.Players[player].InsideHouseID);
                if (house == null) return;
                house.RemoveFromList(player);
            }
        }

        public static void CheckAndKick(Player player)
        {
            var house = GetHouse(player);
            if (house == null) return;
            if (house.Roommates.Contains(player.Name)) house.Roommates.Remove(player.Name);
        }

        public static void ChangeOwner(string oldName, string newName)
        {
            lock (Houses)
            {
                foreach (House h in Houses)
                {
                    if (h.Owner != oldName) continue;
                    Log.Write($"The house was found! [{h.ID}]");
                    h.changeOwner(newName);
                    h.Save();
                }
            }
        }
        #endregion

        public static void interactPressed(Player player, int id)
        {
            switch (id)
            {
                case 6:
                    {
                        if (player.IsInVehicle) return;
                        if (!player.HasData("HOUSEID")) return;

                        House house = Houses.FirstOrDefault(h => h.ID == player.GetData<int>("HOUSEID"));
                        if (house == null) return;
                        if (string.IsNullOrEmpty(house.Owner))
                        {
                            OpenHouseBuyMenu(player, player.GetData<int>("HOUSEID"));
                            return;
                        }
                        else
                        {
                            if (house.Locked)
                            {
                                var playerHouse = GetHouse(player);
                                if (playerHouse != null && playerHouse.ID == house.ID) { OpenHouseMenuInform(player, player.GetData<int>("HOUSEID")); }
                                else if (player.HasData("InvitedHouse_ID") && player.GetData<int>("InvitedHouse_ID") == house.ID) { OpenHouseMenuInform(player, player.GetData<int>("HOUSEID")); }
                                else { OpenHouseMenuInform(player, player.GetData<int>("HOUSEID")); }
                            }
                            else
                            {
                                OpenHouseMenuInform(player, player.GetData<int>("HOUSEID"));
                            }
                        }
                        return;
                    }
                case 7:
                    {
                        if (Main.Players[player].InsideHouseID == -1) return;

                        House house = Houses.FirstOrDefault(h => h.ID == Main.Players[player].InsideHouseID);
                        if (house == null) return;

                        if (player.HasData("IS_EDITING"))
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du musst deine Möbel erst aufbauen", 3000);
                            MenuManager.Close(player);
                            return;
                        }
                        Trigger.ClientEvent(player, "ExitHouseMenu");
                        return;
                    }
            }
        }

        [RemoteEvent("GoHouseInterS")]
        public static void GoHouseMenuInformA(Player player, int act)
        {
            if (!player.HasData("HOUSEID")) return;

            House house = Houses.FirstOrDefault(h => h.ID == act);
            if (house == null) return;

            if (!string.IsNullOrEmpty(house.Owner))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Dieses Haus hat bereits einen Mieter", 3000);
                return;
            }

            house.SendPlayer(player);
            return;
        }


        [RemoteEvent("ExitHouseMenuE")]
        public static void ExitHouseAA(Player player)
        {
            House house = Houses.FirstOrDefault(h => h.ID == Main.Players[player].InsideHouseID);
            house.RemovePlayer(player);
        }
        #region Menus
        public static void OpenHouseBuyMenu(Player player, int id)
        {
            House house = Houses.FirstOrDefault(h => h.ID == player.GetData<int>("HOUSEID"));
            Trigger.ClientEvent(player, "HouseMenuBuy", id, house.Owner, HouseTypeList[house.Type].Name, house.Locked, house.Price, GarageManager.GarageTypes[GarageManager.Garages[house.GarageID].Type].MaxCars, MaxRoommates[house.Type]);
        }
        public static void OpenHouseMenuInform(Player player, int id)
        {
            House house = Houses.FirstOrDefault(h => h.ID == player.GetData<int>("HOUSEID"));
            Trigger.ClientEvent(player, "HouseMenu", id, house.Owner, HouseTypeList[house.Type].Name, house.Locked, house.Price, GarageManager.GarageTypes[GarageManager.Garages[house.GarageID].Type].MaxCars, MaxRoommates[house.Type]);

        }
        [RemoteEvent("GoHouseMenuS")]
        public static void GoHouseMenuInform(Player player, int act)
        {
            House house = Houses.FirstOrDefault(h => h.ID == act);
            if (house.Locked)
            {
                var playerHouse = GetHouse(player);
                if (playerHouse != null && playerHouse.ID == house.ID) { house.SendPlayer(player); return; }
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Die Türen sind geschlossen! Du wurdest hier gar nicht erwartet!", 3000);
                return;
            }
            house.SendPlayer(player);
        }
        [RemoteEvent("buyHouseMenuS")]
        private static void callback_housebuy(Player player, int act)
        {
            if (!player.HasData("HOUSEID")) return;

            House house = Houses.FirstOrDefault(h => h.ID == act);
            if (house == null) return;

            if (!string.IsNullOrEmpty(house.Owner))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Dieses Haus hat bereits einen Mieter", 3000);
                return;
            }

            if (house.Price > Main.Players[player].Money)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast nicht genug Geld, um ein Haus zu bezahlen", 3000);
                return;
            }

            if (Houses.Count(h => h.Owner == player.Name) >= 1)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du kannst nicht mehr als Ein Haus besitzen", 3000);
                return;
            }
            var vehicles = VehicleManager.getAllPlayerVehicles(player.Name).Count;
            var maxcars = GarageManager.GarageTypes[GarageManager.Garages[house.GarageID].Type].MaxCars;
            if (vehicles > maxcars)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Das Haus, das Sie kaufen, hat {maxcars} Parkplätze, verkaufen Sie die zusätzlichen Autos", 3000);
                OpenCarsSellMenu(player);
                return;
            }
            CheckAndKick(player);
            house.SetLock(true);
            house.SetOwner(player);
            house.SendPlayer(player);
            MoneySystem.Bank.Accounts[house.BankID].Balance = Convert.ToInt32(house.Price / 100 * 0.02) * 2;

            MoneySystem.Wallet.Change(player, -house.Price);
            GameLog.Money($"player({Main.Players[player].UUID})", $"server", house.Price, $"houseBuy({house.ID})");

            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du hast dieses Haus gekauft, vergiss nicht, die Steuer dafür am Geldautomaten zu bezahlen", 3000);
            return;
        }

        public static void OpenHouseManageMenu(Player player)
        {
            House house = GetHouse(player, true);
            if (house == null)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast kein Zuhause", 3000);
                MenuManager.Close(player);
                return;
            }
            Trigger.ClientEvent(player, "MyyHouseMenu");

            Menu menu = new Menu("housemanage", false, false);
            menu.Callback = callback_housemanage;

            Menu.Item menuItem = new Menu.Item("header", Menu.MenuItem.Header);
            menuItem.Text = "Gebäudemanagement";
            menu.Add(menuItem);

            menuItem = new Menu.Item("changestate", Menu.MenuItem.Button);
            menuItem.Text = "Öffnen/Schließen";
            menu.Add(menuItem);

            menuItem = new Menu.Item("removeall", Menu.MenuItem.Button);
            menuItem.Text = "Alle Besucher rausschmeißen";
            menu.Add(menuItem);

            menuItem = new Menu.Item("furniture", Menu.MenuItem.Button);
            menuItem.Text = "Möbel";
            menu.Add(menuItem);

            menuItem = new Menu.Item("cars", Menu.MenuItem.Button);
            menuItem.Text = "Autos";
            menu.Add(menuItem);

            menuItem = new Menu.Item("roommates", Menu.MenuItem.Button);
            menuItem.Text = "Mitbewohner";
            menu.Add(menuItem);

            menuItem = new Menu.Item("sell", Menu.MenuItem.Button);
            menuItem.Text = $"An den Staat verkaufen für{Convert.ToInt32(house.Price * 0.6)}$";
            menu.Add(menuItem);

            menuItem = new Menu.Item("close", Menu.MenuItem.Button);
            menuItem.Text = "Schließen";
            menu.Add(menuItem);

            menu.Open(player);
        }
        private static void callback_housemanage(Player player, Menu menu, Menu.Item item, string eventName, dynamic data)
        {
            House house = GetHouse(player, true);
            if (house == null)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast kein Zuhause", 3000);
                MenuManager.Close(player);
                return;
            }
            switch (item.ID)
            {
                case "changestate":
                    house.SetLock(!house.Locked);
                    if (house.Locked) Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du hast das Haus abgeschlossen", 3000);
                    else Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du hast das Haus aufgeschlossen", 3000);
                    return;
                case "removeall":
                    house.RemoveAllPlayers(player);
                    Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du hast alle aus dem Haus geworfen", 3000);
                    return;
                case "furniture":
                    MenuManager.Close(player);
                    OpenFurnitureMenu(player);
                    return;
                case "sell":
                    int price = 0;
                    switch (Main.Accounts[player].VipLvl)
                    {
                        case 0: // None
                            price = Convert.ToInt32(house.Price * 0.6);
                            break;
                        case 1: // Bronze
                            price = Convert.ToInt32(house.Price * 0.65);
                            break;
                        case 2: // Silver
                            price = Convert.ToInt32(house.Price * 0.7);
                            break;
                        case 3: // Gold
                            price = Convert.ToInt32(house.Price * 0.75);
                            break;
                        case 4: // Platinum
                            price = Convert.ToInt32(house.Price * 0.8);
                            break;
                    }
                    Trigger.ClientEvent(player, "openDialog", "HOUSE_SELL_TOGOV", $"Willst du das haus wirklich verkaufen ${price}?");
                    MenuManager.Close(player);
                    return;
                case "cars":
                    OpenCarsMenu(player);
                    return;
                case "roommates":
                    OpenRoommatesMenu(player);
                    return;
                case "close":
                    MenuManager.Close(player);
                    return;
            }
        }
        public static void acceptHouseSellToGov(Player player)
        {
            House house = GetHouse(player, true);
            if (house == null)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast kein Zuhause", 3000);
                return;
            }

            if (Main.Players[player].InsideGarageID != -1)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du musst zuerst aus der Garage kommen", 3000);
                return;
            }
            house.RemoveAllPlayers();
            house.SetOwner(null);
            house.PetName = "null";
            Trigger.ClientEvent(player, "deleteCheckpoint", 333);
            Trigger.ClientEvent(player, "deleteGarageBlip");
            int price = 0;
            switch (Main.Accounts[player].VipLvl)
            {
                case 0: // None
                    price = Convert.ToInt32(house.Price * 0.6);
                    break;
                case 1: // Bronze
                    price = Convert.ToInt32(house.Price * 0.65);
                    break;
                case 2: // Silver
                    price = Convert.ToInt32(house.Price * 0.7);
                    break;
                case 3: // Gold
                    price = Convert.ToInt32(house.Price * 0.75);
                    break;
                case 4: // Platinum
                    price = Convert.ToInt32(house.Price * 0.8);
                    break;
            }
            MoneySystem.Wallet.Change(player, price);
            GameLog.Money($"server", $"player({Main.Players[player].UUID})", Convert.ToInt32(house.Price * 0.6), $"houseSell({house.ID})");
            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du hast das Haus an den Staat verkauft für{price}$", 3000);
        }

        public static void OpenCarsSellMenu(Player player)
        {
            Menu menu = new Menu("carsell", false, false);
            menu.Callback = callback_carsell;

            Menu.Item menuItem = new Menu.Item("header", Menu.MenuItem.Header);
            menuItem.Text = "Autos verkaufen";
            menu.Add(menuItem);

            menuItem = new Menu.Item("label", Menu.MenuItem.Card);
            menuItem.Text = "Wähle das Auto was du verkaufen willst.";
            menu.Add(menuItem);

            foreach (var v in VehicleManager.getAllPlayerVehicles(player.Name))
            {
                var vData = VehicleManager.Vehicles[v];
                var price = (BusinessManager.ProductsOrderPrice.ContainsKey(vData.Model)) ? Convert.ToInt32(BusinessManager.ProductsOrderPrice[vData.Model] * 0.5) : 0;
                menuItem = new Menu.Item(v, Menu.MenuItem.Button);
                menuItem.Text = $"{vData.Model} - {v} ({price}$)";
                menu.Add(menuItem);
            }

            menuItem = new Menu.Item("close", Menu.MenuItem.Button);
            menuItem.Text = "Schließen";
            menu.Add(menuItem);

            menu.Open(player);
        }
        private static void callback_carsell(Player player, Menu menu, Menu.Item item, string eventName, dynamic data)
        {
            if (item.ID == "close")
            {
                MenuManager.Close(player);
                return;
            }
            var vData = VehicleManager.Vehicles[item.ID];
            var price = (BusinessManager.ProductsOrderPrice.ContainsKey(vData.Model)) ? Convert.ToInt32(BusinessManager.ProductsOrderPrice[vData.Model] * 0.5) : 0;
            MoneySystem.Wallet.Change(player, price);
            GameLog.Money($"server", $"player({Main.Players[player].UUID})", price, $"carSell({vData.Model})");
            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du hast {vData.Model} ({item.ID})verkauft für {price}$", 3000);
            VehicleManager.Remove(item.ID);
            MenuManager.Close(player);
        }

        public static void OpenFurnitureMenu(Player player)
        {
            House house = GetHouse(player, true);
            if (house == null)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast kein Zuhause", 3000);
                MenuManager.Close(player);
                return;
            }

            Menu menu = new Menu("furnitures", false, false);
            menu.Callback = callback_furniture0;

            Menu.Item menuItem = new Menu.Item("header", Menu.MenuItem.Header);
            menuItem.Text = "Möbel";
            menu.Add(menuItem);

            menuItem = new Menu.Item("buyfurniture", Menu.MenuItem.Button);
            menuItem.Text = "Möbel kaufen";
            menu.Add(menuItem);

            menuItem = new Menu.Item("tofurniture", Menu.MenuItem.Button);
            menuItem.Text = "Möbel-Management";
            menu.Add(menuItem);

            menuItem = new Menu.Item("close", Menu.MenuItem.Button);
            menuItem.Text = "Schließen";
            menu.Add(menuItem);

            menu.Open(player);
        }

        private static void callback_furniture0(Player player, Menu menu, Menu.Item item, string eventName, dynamic data)
        {
            if (item.ID == "close")
            {
                MenuManager.Close(player);
                return;
            }
            if (Main.Players[player].InsideHouseID == -1)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du musst dafür Zuhause sein", 3000);
                MenuManager.Close(player);
                return;
            }
            House house = GetHouse(player, true);
            if (house == null)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast kein Zuhause", 3000);
                MenuManager.Close(player);
                return;
            }
            if (house.ID != Main.Players[player].InsideHouseID)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Dafür musst du Zuhause sein", 3000);
                MenuManager.Close(player);
                return;
            }
            if (item.ID == "tofurniture")
            {
                if (!FurnitureManager.HouseFurnitures.ContainsKey(house.ID) || FurnitureManager.HouseFurnitures[house.ID].Count() == 0)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast keine Möbel", 3000);
                    MenuManager.Close(player);
                    return;
                }
                Menu nmenu = new Menu("furnitures", false, false);
                nmenu.Callback = callback_furniture;

                Menu.Item menuItem = new Menu.Item("header", Menu.MenuItem.Header);
                menuItem.Text = "Möbel-Management";
                nmenu.Add(menuItem);

                menuItem = new Menu.Item("furniture", Menu.MenuItem.List);
                menuItem.Text = "ID:";
                var list = new List<string>();
                foreach (var f in FurnitureManager.HouseFurnitures[house.ID]) list.Add(f.Value.ID.ToString());
                menuItem.Elements = list;
                nmenu.Add(menuItem);

                menuItem = new Menu.Item("sellit", Menu.MenuItem.Button);
                menuItem.Text = "Verkaufen (7500$)";
                nmenu.Add(menuItem);

                var furn = FurnitureManager.HouseFurnitures[house.ID][Convert.ToInt32(list[0])];
                menuItem = new Menu.Item("type", Menu.MenuItem.Card);
                menuItem.Text = $"Typ: {furn.Name}";
                nmenu.Add(menuItem);

                var open = (furn.IsSet) ? "Да" : "Нет";
                menuItem = new Menu.Item("isSet", Menu.MenuItem.Card);
                menuItem.Text = $"Installiert: {open}";
                nmenu.Add(menuItem);

                menuItem = new Menu.Item("change", Menu.MenuItem.Button);
                menuItem.Text = "Installieren/Entfernen";
                nmenu.Add(menuItem);

                menuItem = new Menu.Item("close", Menu.MenuItem.Button);
                menuItem.Text = "Schließen";
                nmenu.Add(menuItem);

                nmenu.Open(player);
                return;
            }
            else if (item.ID == "buyfurniture")
            {

                Menu nmenu = new Menu("furnitures", false, false);
                nmenu.Callback = callback_furniture1;

                Menu.Item menuItem = new Menu.Item("header", Menu.MenuItem.Header);
                menuItem.Text = "Möbel kaufen";
                nmenu.Add(menuItem);

                menuItem = new Menu.Item("buy1", Menu.MenuItem.Button);
                menuItem.Text = "Waffentresor (15000$)";
                nmenu.Add(menuItem);

                menuItem = new Menu.Item("buy2", Menu.MenuItem.Button);
                menuItem.Text = "Wäscheschrank (15000$)";
                nmenu.Add(menuItem);

                menuItem = new Menu.Item("buy3", Menu.MenuItem.Button);
                menuItem.Text = "Kleiderschrank (15000$)";
                nmenu.Add(menuItem);

                menuItem = new Menu.Item("close", Menu.MenuItem.Button);
                menuItem.Text = "Schließen";
                nmenu.Add(menuItem);

                nmenu.Open(player);
            }
        }

        private static void callback_furniture1(Player player, Menu menu, Menu.Item item, string eventName, dynamic data)
        {
            if (item.ID == "close")
            {
                MenuManager.Close(player);
                return;
            }
            if (Main.Players[player].InsideHouseID == -1)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Dafür musst du Zuhause sein", 3000);
                MenuManager.Close(player);
                return;
            }
            House house = GetHouse(player, true);
            if (house == null)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast kein Zuhause", 3000);
                MenuManager.Close(player);
                return;
            }
            if (house.ID != Main.Players[player].InsideHouseID)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Dafür musst du Zuhause sein", 3000);
                MenuManager.Close(player);
                return;
            }
            if (FurnitureManager.HouseFurnitures[house.ID].Count() >= 50)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Du hast zuviele Möbel in deinem Haus", 3000);
                return;
            }
            if (item.ID == "buy1")
            {
                if (Main.Players[player].Money < 15000)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Du kannst dir diese Möbel nicht leisten", 3000);
                    return;
                }
                MoneySystem.Wallet.Change(player, -15000);
                FurnitureManager.newFurniture(house.ID, "Waffentresor");
                GameLog.Money("server", $"player({Main.Players[player].UUID})", 15000, $"buyFurn({house.ID} | Waffentresor)");
            }
            else if (item.ID == "buy2")
            {
                if (Main.Players[player].Money < 15000)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Du kannst dir das nicht leisten.", 3000);
                    return;
                }
                MoneySystem.Wallet.Change(player, -15000);
                FurnitureManager.newFurniture(house.ID, "Wäscheschrank");
                GameLog.Money("server", $"player({Main.Players[player].UUID})", 15000, $"buyFurn({house.ID} | Wäscheschrank)");
            }
            else if (item.ID == "buy3")
            {
                if (Main.Players[player].Money < 15000)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Du kannst dir das nicht leisten.", 3000);
                    return;
                }
                MoneySystem.Wallet.Change(player, -15000);
                FurnitureManager.newFurniture(house.ID, "Kleiderschrank");
                GameLog.Money("server", $"player({Main.Players[player].UUID})", 15000, $"buyFurn({house.ID} | Kleiderschrank)");
            }
            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, "Du kannst dir das nicht leisten!", 3000);
            MenuManager.Close(player);
        }

        private static void callback_furniture(Player player, Menu menu, Menu.Item item, string eventName, dynamic data)
        {
            if (item.ID == "close")
            {
                MenuManager.Close(player);
                return;
            }
            if (Main.Players[player].InsideHouseID == -1)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du musst dafür zuhause sein", 3000);
                MenuManager.Close(player);
                return;
            }
            House house = GetHouse(player, true);
            if (house == null)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast kein Zuhause", 3000);
                MenuManager.Close(player);
                return;
            }
            if (house.ID != Main.Players[player].InsideHouseID)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Dafür musst du Zuhause sein", 3000);
                MenuManager.Close(player);
                return;
            }
            if (Main.Players[player].InsideHouseID == -1 || Main.Players[player].InsideHouseID != house.ID)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du solltest Zuhause sein", 3000);
                MenuManager.Close(player);
                return;
            }
            if (!FurnitureManager.HouseFurnitures.ContainsKey(house.ID) || FurnitureManager.HouseFurnitures[house.ID].Count() == 0)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast keine Möbel", 3000);
                MenuManager.Close(player);
                return;
            }
            int id = Convert.ToInt32(data["1"]["Value"].ToString());
            var f = FurnitureManager.HouseFurnitures[house.ID][id];
            if (item.ID == "sellit")
            {
                if (f.IsSet)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du musst deine Möbel vor dem Verkauf zuerst abbauen.", 3000);
                    return;
                }
                GameLog.Money($"player({Main.Players[player].UUID})", "server", 7500, $"sellFurn({house.ID} | {f.Name})");
                Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du hast{f.Name} erfolgreich verkauft für 7500$", 3000);
                house.DestroyFurniture(f.ID);
                FurnitureManager.HouseFurnitures[house.ID].Remove(id);
                FurnitureManager.FurnituresItems[house.ID].Remove(id);
                MoneySystem.Wallet.Change(player, 7500);
                MenuManager.Close(player);
                return;
            }
            switch (eventName)
            {
                case "button":
                    switch (f.IsSet)
                    {
                        case true:
                            house.DestroyFurniture(f.ID);
                            f.IsSet = false;
                            menu.Items[4].Text = $"Installiert: Keine";
                            menu.Change(player, 4, menu.Items[4]);
                            return;
                        case false:
                            if (player.HasData("IS_EDITING"))
                            {
                                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du musst das zuerst aufbauen", 3000);
                                MenuManager.Close(player);
                                return;
                            }
                            player.SetData("IS_EDITING", true);
                            player.SetData("EDIT_ID", f.ID);
                            Trigger.ClientEvent(player, "startEditing", f.Model);
                            MenuManager.Close(player);
                            return;
                    }
                    return;
                case "listChangeleft":
                case "listChangeright":

                    menu.Items[3].Text = $"Typ: {f.Name}";
                    menu.Change(player, 3, menu.Items[3]);

                    var open = (f.IsSet) ? "Ja" : "Nein";
                    menu.Items[4].Text = $"Installiert: {open}";
                    menu.Change(player, 4, menu.Items[4]);
                    return;
            }
        }

        public static void OpenRoommatesMenu(Player player)
        {
            Menu menu = new Menu("roommates", false, false);
            menu.Callback = callback_roommates;

            Menu.Item menuItem = new Menu.Item("header", Menu.MenuItem.Header);
            menuItem.Text = "Mitbewohner";
            menu.Add(menuItem);

            var house = GetHouse(player, true);
            if (house.Roommates.Count > 0)
            {
                menuItem = new Menu.Item("label", Menu.MenuItem.Card);
                menuItem.Text = "Schmeiße eine bestimmte Person aus dem Haus";
                menu.Add(menuItem);

                foreach (var p in house.Roommates)
                {
                    menuItem = new Menu.Item(p, Menu.MenuItem.Button);
                    menuItem.Text = $"{p.Replace('_', ' ')}";
                    menu.Add(menuItem);
                }
            }
            else
            {
                menuItem = new Menu.Item("label", Menu.MenuItem.Card);
                menuItem.Text = "du hast niemanden eingeladen";
                menu.Add(menuItem);
            }

            menuItem = new Menu.Item("back", Menu.MenuItem.Button);
            menuItem.Text = "Zurück";
            menu.Add(menuItem);

            menu.Open(player);
        }
        private static void callback_roommates(Player player, Menu menu, Menu.Item item, string eventName, dynamic data)
        {
            if (item.ID == "back")
            {
                MenuManager.Close(player);
                return;
            }

            var mName = item.ID;
            var roomMate = NAPI.Player.GetPlayerFromName(mName);

            var house = GetHouse(player);
            if (house.Roommates.Contains(mName)) house.Roommates.Remove(mName);

            Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du hast {mName} aus dein Haus geworfen", 3000);
        }

        public static void OpenCarsMenu(Player player)
        {
            Menu menu = new Menu("cars", false, false);
            menu.Callback = callback_cars;

            Menu.Item menuItem = new Menu.Item("header", Menu.MenuItem.Header);
            menuItem.Text = "Autos";
            menu.Add(menuItem);

            foreach (var v in VehicleManager.getAllPlayerVehicles(player.Name))
            {
                menuItem = new Menu.Item(v, Menu.MenuItem.Button);
                menuItem.Text = $"{VehicleManager.Vehicles[v].Model} - {v}";
                menu.Add(menuItem);
            }

            menuItem = new Menu.Item("close", Menu.MenuItem.Button);
            menuItem.Text = "Schließen";
            menu.Add(menuItem);

            menu.Open(player);
        }
        private static void callback_cars(Player player, Menu menu, Menu.Item item, string eventName, dynamic data)
        {
            NAPI.Task.Run(() =>
            {
                try
                {
                    MenuManager.Close(player);
                    if (item.ID == "close") return;
                    OpenSelectedCarMenu(player, item.ID);
                }
                catch (Exception e) { Log.Write("callback_cars: " + e.Message + e.Message, nLog.Type.Error); }
            });
        }

        public static void OpenSelectedCarMenu(Player player, string number)
        {
            Menu menu = new Menu("selectedcar", false, false);
            menu.Callback = callback_selectedcar;

            var vData = VehicleManager.Vehicles[number];

            var house = GetHouse(player);
            var garage = GarageManager.Garages[house.GarageID];
            var check = garage.CheckCar(false, number);
            var check_pos = (string.IsNullOrEmpty(vData.Position)) ? false : true;

            Menu.Item menuItem = new Menu.Item("header", Menu.MenuItem.Header);
            menuItem.Text = number;
            menu.Add(menuItem);

            menuItem = new Menu.Item("model", Menu.MenuItem.Card);
            menuItem.Text = vData.Model;
            menu.Add(menuItem);

            var vClass = NAPI.Vehicle.GetVehicleClass(NAPI.Util.VehicleNameToModel(vData.Model));

            menuItem = new Menu.Item("repair", Menu.MenuItem.Button);
            menuItem.Text = $"Wiederherstellen {VehicleManager.VehicleRepairPrice[vClass]}$";
            menu.Add(menuItem);

            menuItem = new Menu.Item("key", Menu.MenuItem.Button);
            menuItem.Text = $"Duplikatschlüssel holen";
            menu.Add(menuItem);

            menuItem = new Menu.Item("changekey", Menu.MenuItem.Button);
            menuItem.Text = $"Schlösser wechseln";
            menu.Add(menuItem);

            if (check)
            {
                menuItem = new Menu.Item("evac", Menu.MenuItem.Button);
                menuItem.Text = $"Alle aus dem Auto werfen";
                menu.Add(menuItem);

                menuItem = new Menu.Item("gps", Menu.MenuItem.Button);
                menuItem.Text = $"Auto Orten";
                menu.Add(menuItem);
            }
            else if (check_pos)
            {
                menuItem = new Menu.Item("evac_pos", Menu.MenuItem.Button);
                menuItem.Text = $"Alle aus dem Auto werfen";
                menu.Add(menuItem);
            }

            int price = 0;
            if (BusinessManager.ProductsOrderPrice.ContainsKey(vData.Model))
            {
                switch (Main.Accounts[player].VipLvl)
                {
                    case 0: // None
                        price = Convert.ToInt32(BusinessManager.ProductsOrderPrice[vData.Model] * 0.5);
                        break;
                    case 1: // Bronze
                        price = Convert.ToInt32(BusinessManager.ProductsOrderPrice[vData.Model] * 0.6);
                        break;
                    case 2: // Silver
                        price = Convert.ToInt32(BusinessManager.ProductsOrderPrice[vData.Model] * 0.7);
                        break;
                    case 3: // Gold
                        price = Convert.ToInt32(BusinessManager.ProductsOrderPrice[vData.Model] * 0.8);
                        break;
                    case 4: // Platinum
                        price = Convert.ToInt32(BusinessManager.ProductsOrderPrice[vData.Model] * 0.9);
                        break;
                    default:
                        price = Convert.ToInt32(BusinessManager.ProductsOrderPrice[vData.Model] * 0.5);
                        break;
                }
            }
            menuItem = new Menu.Item("sell", Menu.MenuItem.Button);
            menuItem.Text = $"Verkaufen ({price}$)";
            menu.Add(menuItem);

            menuItem = new Menu.Item("close", Menu.MenuItem.Button);
            menuItem.Text = "Schließen";
            menu.Add(menuItem);

            menu.Open(player);
        }
        private static void callback_selectedcar(Player player, Menu menu, Menu.Item item, string eventName, dynamic data)
        {
            MenuManager.Close(player);
            switch (item.ID)
            {
                case "sell":
                    player.SetData("CARSELLGOV", menu.Items[0].Text);
                    VehicleManager.VehicleData vData = VehicleManager.Vehicles[menu.Items[0].Text];
                    int price = 0;
                    if (BusinessManager.ProductsOrderPrice.ContainsKey(vData.Model))
                    {
                        switch (Main.Accounts[player].VipLvl)
                        {
                            case 0: // None
                                price = Convert.ToInt32(BusinessManager.ProductsOrderPrice[vData.Model] * 0.5);
                                break;
                            case 1: // Bronze
                                price = Convert.ToInt32(BusinessManager.ProductsOrderPrice[vData.Model] * 0.6);
                                break;
                            case 2: // Silver
                                price = Convert.ToInt32(BusinessManager.ProductsOrderPrice[vData.Model] * 0.7);
                                break;
                            case 3: // Gold
                                price = Convert.ToInt32(BusinessManager.ProductsOrderPrice[vData.Model] * 0.8);
                                break;
                            case 4: // Platinum
                                price = Convert.ToInt32(BusinessManager.ProductsOrderPrice[vData.Model] * 0.9);
                                break;
                            default:
                                price = Convert.ToInt32(BusinessManager.ProductsOrderPrice[vData.Model] * 0.5);
                                break;
                        }
                    }
                    Trigger.ClientEvent(player, "openDialog", "CAR_SELL_TOGOV", $"Willst das wirklich an den Staat verkaufen {vData.Model} ({menu.Items[0].Text}) für ${price}?");
                    MenuManager.Close(player);
                    return;
                case "repair":
                    vData = VehicleManager.Vehicles[menu.Items[0].Text];
                    if (vData.Health > 0)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Das Auto muss nicht repariert werden", 3000);
                        return;
                    }

                    var vClass = NAPI.Vehicle.GetVehicleClass(NAPI.Util.VehicleNameToModel(vData.Model));
                    if (!MoneySystem.Wallet.Change(player, -VehicleManager.VehicleRepairPrice[vClass]))
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Du hast nicht genug Geld", 3000);
                        return;
                    }
                    vData.Items = new List<nItem>();
                    GameLog.Money($"player({Main.Players[player].UUID})", $"server", VehicleManager.VehicleRepairPrice[vClass], $"carRepair({vData.Model})");
                    vData.Health = 1000;
                    var garage = GarageManager.Garages[GetHouse(player).GarageID];
                    garage.SendVehicleIntoGarage(menu.Items[0].Text);
                    Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Es ist wieder etwas frei {vData.Model} ({menu.Items[0].Text})", 3000);
                    return;
                case "evac":
                    if (!Main.Players.ContainsKey(player)) return;

                    var number = menu.Items[0].Text;
                    garage = GarageManager.Garages[GetHouse(player).GarageID];
                    var check = garage.CheckCar(false, number);

                    if (!check)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Du hast das Auto in die Garage gefahren", 3000);
                        return;
                    }
                    if (Main.Players[player].Money < 200)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Nicht genug Geld (Fehlt {200 - Main.Players[player].Money}$)", 3000);
                        return;
                    }

                    var veh = garage.GetOutsideCar(number);
                    if (veh == null) return;
                    VehicleManager.Vehicles[number].Fuel = (int)((!NAPI.Data.HasEntityData(veh, "PETROL")) ? VehicleManager.VehicleTank[veh.Class] : NAPI.Data.GetEntitySharedData(veh, "PETROL"));
                    NAPI.Entity.DeleteEntity(veh);
                    garage.SendVehicleIntoGarage(number);

                    MoneySystem.Wallet.Change(player, -200);
                    GameLog.Money($"player({Main.Players[player].UUID})", $"server", 200, $"carEvac");
                    Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Dein Auto wurde in eine Werkstatt gebracht", 3000);
                    return;
                case "evac_pos":
                    if (!Main.Players.ContainsKey(player)) return;

                    number = menu.Items[0].Text;
                    if (string.IsNullOrEmpty(VehicleManager.Vehicles[number].Position))
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Dein Auto muss nicht abgeschleppt werden", 3000);
                        return;
                    }

                    VehicleManager.Vehicles[number].Position = null;
                    VehicleManager.Save(number);

                    garage = GarageManager.Garages[GetHouse(player).GarageID];
                    garage.SendVehicleIntoGarage(number);
                    Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Dein Auto wurde in eine Werkstatt geschleppt", 3000);
                    return;
                case "gps":
                    if (!Main.Players.ContainsKey(player)) return;

                    number = menu.Items[0].Text;
                    garage = GarageManager.Garages[GetHouse(player).GarageID];
                    check = garage.CheckCar(false, number);

                    if (!check)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "Dein Auto ist in der Garage geparkt", 3000);
                        return;
                    }

                    veh = garage.GetOutsideCar(number);
                    if (veh == null) return;

                    Trigger.ClientEvent(player, "createWaypoint", veh.Position.X, veh.Position.Y);
                    Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, "Der Standort deines Autos wurde im Navi markiert", 3000);
                    return;
                case "key":
                    if (!Main.Players.ContainsKey(player)) return;

                    garage = GarageManager.Garages[GetHouse(player).GarageID];
                    if (garage.Type == -1)
                    {
                        if (player.Position.DistanceTo(garage.Position) > 4)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du solltest vor der garage stehen", 3000);
                            return;
                        }
                    }
                    else
                    {
                        if (Main.Players[player].InsideGarageID == -1)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du musst in der Garage stehen", 3000);
                            return;
                        }
                    }

                    var tryAdd = nInventory.TryAdd(player, new nItem(ItemType.CarKey));
                    if (tryAdd == -1 || tryAdd > 0)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"nicht genug Platz in den Taschen", 3000);
                        return;
                    }

                    nInventory.Add(player, new nItem(ItemType.CarKey, 1, $"{menu.Items[0].Text}_{VehicleManager.Vehicles[menu.Items[0].Text].KeyNum}"));
                    Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du hast diesen Schlüssel {menu.Items[0].Text}", 3000);
                    return;
                case "changekey":
                    if (!Main.Players.ContainsKey(player)) return;

                    garage = GarageManager.Garages[GetHouse(player).GarageID];
                    if (garage.Type == -1)
                    {
                        if (player.Position.DistanceTo(garage.Position) > 4)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du solltest außerhalb deiner Garage stehen", 3000);
                            return;
                        }
                    }
                    else
                    {
                        if (Main.Players[player].InsideGarageID == -1)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du musst in der Garage sein", 3000);
                            return;
                        }
                    }

                    if (!MoneySystem.Wallet.Change(player, -1000))
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, "kosten für deinen Schloss wechsel $1000", 3000);
                        return;
                    }

                    VehicleManager.Vehicles[menu.Items[0].Text].KeyNum++;
                    Notify.Send(player, NotifyType.Success, NotifyPosition.MapUp, $"Du hast das Schloss {menu.Items[0].Text} gewechselt", 3000);
                    return;
            }
        }
        #endregion

        #region Commands
        public static void InviteToRoom(Player player, Player guest)
        {
            House house = GetHouse(player, true);
            if (house == null)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast kein Haus", 3000);
                return;
            }

            if (house.Roommates.Count >= MaxRoommates[house.Type])
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast die Maximale Mitbewohner anzahl erreicht", 3000);
                return;
            }

            if (GetHouse(guest) != null)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Dieser Bürger ist bereits dein Mitbewohner", 3000);
                return;
            }

            guest.SetData("ROOM_INVITER", player);
            guest.TriggerEvent("openDialog", "ROOM_INVITE", $"Dein gegenüber({player.Value}) hat dir angeboten bei ihm zu Wohnen");

            Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Du hast deinen Gegenüber({guest.Value})angeboten bei dir zu wohnen", 3000);
        }

        public static void acceptRoomInvite(Player player)
        {
            Player owner = player.GetData<Player>("ROOM_INVITER");
            if (owner == null || !Main.Players.ContainsKey(owner)) return;

            House house = GetHouse(owner, true);
            if (house == null)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Der Spieler hat kein Haus", 3000);
                return;
            }

            if (house.Roommates.Count >= MaxRoommates[house.Type])
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du kannst nicht mehr Bürger bei dir wohnen lassen", 3000);
                return;
            }

            house.Roommates.Add(player.Name);
            Trigger.ClientEvent(player, "createCheckpoint", 333, 1, GarageManager.Garages[house.GarageID].Position - new Vector3(0, 0, 1.12), 1, NAPI.GlobalDimension, 220, 220, 0);
            Trigger.ClientEvent(player, "createGarageBlip", GarageManager.Garages[house.GarageID].Position);

            Notify.Send(owner, NotifyType.Info, NotifyPosition.MapUp, $"Dein gegenüber ({player.Value}) wohnt jetzt bei dir", 3000);
            Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Du bist bei deinem gegenüber eingezogen ({owner.Value})", 3000);
        }

        [Command("cleargarages")]
        public static void CMD_CreateHouse(Player player)
        {
            if (!Group.CanUseCmd(player, "save")) return;

            var list = new List<int>();
            lock (GarageManager.Garages)
            {
                foreach (var g in GarageManager.Garages)
                {
                    var house = Houses.FirstOrDefault(h => h.GarageID == g.Key);
                    if (house == null) list.Add(g.Key);
                }
            }

            foreach (var id in list)
            {
                GarageManager.Garages.Remove(id);
                MySQL.Query($"DELETE FROM `garages` WHERE `id`={id}");
            }
        }

        [Command("createhouse")]
        public static void CMD_CreateHouse(Player player, int type, int price)
        {
            if (!Group.CanUseCmd(player, "save")) return;
            if (type < 0 || type >= HouseTypeList.Count)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Falscher Typ", 3000);
                return;
            }

            var bankId = MoneySystem.Bank.Create(string.Empty, 2, 0);
            House new_house = new House(GetUID(), string.Empty, type, player.Position - new Vector3(0, 0, 1.12), price, false, 0, bankId, new List<string>(), -1);
            DimensionID++;
            new_house.Dimension = DimensionID;
            new_house.Create();
            FurnitureManager.Create(new_house.ID);
            new_house.CreateInterior();

            Houses.Add(new_house);
        }

        [Command("removehouse")]
        public static void CMD_RemoveHouse(Player player, int id)
        {
            if (!Group.CanUseCmd(player, "save")) return;

            House house = Houses.FirstOrDefault(h => h.ID == id);
            if (house == null) return;

            house.Destroy();
            Houses.Remove(house);
            MySQL.Query($"DELETE FROM `houses` WHERE `id`='{house.ID}'");
        }
        [Command("houseis")]
        public static void CMD_HouseIs(Player player)
        {
            if (!Group.CanUseCmd(player, "save")) return;
            if (!player.HasData("HOUSEID"))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du musst vor deiner Haustür stehen(Marker)", 3000);
                return;
            }
            House house = Houses.FirstOrDefault(h => h.ID == player.GetData<int>("HOUSEID"));
            if (house == null) return;

            NAPI.Chat.SendChatMessageToPlayer(player, $"{player.GetData<int>("HOUSEID")}");
        }
        [Command("housechange")]
        public static void CMD_HouseOwner(Player player, string newOwner)
        {
            if (!Group.CanUseCmd(player, "save")) return;
            if (!player.HasData("HOUSEID"))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du musst vor deiner Haustür stehen(Marker)", 3000);
                return;
            }
            House house = Houses.FirstOrDefault(h => h.ID == player.GetData<int>("HOUSEID"));
            if (house == null) return;

            house.changeOwner(newOwner);
            SavingHouses();
        }

        [Command("housenewprice")]
        public static void CMD_setHouseNewPrice(Player player, int price)
        {
            if (!Group.CanUseCmd(player, "save")) return;
            if (!player.HasData("HOUSEID"))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du musst vor deiner Haustür stehen(Marker)", 3000);
                return;
            }

            House house = Houses.FirstOrDefault(h => h.ID == player.GetData<int>("HOUSEID"));
            if (house == null) return;
            house.Price = price;
            house.UpdateLabel();
            house.Save();
        }

        [Command("myguest")]
        public static void CMD_InvitePlayerToHouse(Player player, int id)
        {
            var guest = Main.GetPlayerByID(id);
            if (guest == null)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Bürger nicht gefunden", 3000);
                return;
            }
            if (player.Position.DistanceTo(guest.Position) > 2)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du bist zu weit weg", 3000);
                return;
            }
            InvitePlayerToHouse(player, guest);
        }

        public static void InvitePlayerToHouse(Player player, Player guest)
        {
            House house = GetHouse(player);
            if (house == null)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast kein Zuhause", 3000);
                return;
            }
            guest.SetData("InvitedHouse_ID", house.ID);
            Notify.Send(guest, NotifyType.Info, NotifyPosition.MapUp, $"Dein gegenüber ({player.Value})hat dich zu ihm eingeladen", 3000);
            Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Du hast dein gegenüber({guest.Value})zu dir eingeladen", 3000);
        }

        [Command("sellhouse")]
        public static void CMD_sellHouse(Player player, int id, int price)
        {
            var target = Main.GetPlayerByID(id);
            if (target == null)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Bürger nicht gefunden", 3000);
                return;
            }
            OfferHouseSell(player, target, price);
        }

        public static void OfferHouseSell(Player player, Player target, int price)
        {
            if (player.Position.DistanceTo(target.Position) > 2)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du bist zu weit vom Käufer weg", 3000);
                return;
            }
            House house = GetHouse(player, true);
            if (house == null)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast kein Zuhause", 3000);
                return;
            }
            if (GetHouse(target, true) != null)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Dein gegenüber hat bereits ein Haus", 3000);
                return;
            }
            if (price > 1000000000 || price < house.Price / 2)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Preis zu hoch/niedrig", 3000);
                return;
            }
            if (player.Position.DistanceTo(house.Position) > 30)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du bist zu weit vom Haus weg", 3000);
                return;
            }

            target.SetData("HOUSE_SELLER", player);
            target.SetData("HOUSE_PRICE", price);
            Trigger.ClientEvent(target, "openDialog", "HOUSE_SELL", $"Bürger ({player.Value})hat angeboten, dein Haus zu kaufen für ${price}");
            Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Du hast dienen Gegenüber ({target.Value}) angeboten sein Haus zu kaufen für {price}$", 3000);
        }

        public static void acceptHouseSell(Player player)
        {
            if (!player.HasData("HOUSE_SELLER") || !Main.Players.ContainsKey(player.GetData<Player>("HOUSE_SELLER"))) return;
            Player seller = player.GetData<Player>("HOUSE_SELLER");

            if (GetHouse(player, true) != null)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Du hast bereits ein Haus", 3000);
                return;
            }

            House house = GetHouse(seller, true);
            var price = player.GetData<int>("HOUSE_PRICE");
            if (house == null || house.Owner != seller.Name) return;
            if (!MoneySystem.Wallet.Change(player, -price))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.MapUp, $"Nicht genug Geld", 3000);
                return;
            }
            CheckAndKick(player);
            MoneySystem.Wallet.Change(seller, price);
            GameLog.Money($"player({Main.Players[player].UUID})", $"player({Main.Players[seller].UUID})", price, $"houseSell({house.ID})");
            seller.TriggerEvent("deleteCheckpoint", 333);
            seller.TriggerEvent("deleteGarageBlip");
            house.SetOwner(player);
            house.PetName = Main.Players[player].PetName;
            house.Save();

            Notify.Send(seller, NotifyType.Info, NotifyPosition.MapUp, $"Dein gegenüber ({player.Value}) hat dein Haus gekauft", 3000);
            Notify.Send(player, NotifyType.Info, NotifyPosition.MapUp, $"Du hast das Haus von deinem gegenüber gekauft ({seller.Value})", 3000);
        }
        #endregion
    }
}

