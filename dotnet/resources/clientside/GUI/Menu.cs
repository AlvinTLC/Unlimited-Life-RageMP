﻿using GTANetworkAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using ULife.Core;
using UNL.SDK;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace ULife.GUI
{
    class MenuManager : Script
    {
        public static Dictionary<Entity, Menu> Menus = new Dictionary<Entity, Menu>();
        private static nLog Log = new nLog("MenuControl");

        public static void Event_OnPlayerDisconnected(Player Player, DisconnectionType type, string reason)
        {
            try
            {
                if (Menus.ContainsKey(Player))
                    Menus.Remove(Player);
            }
            catch (Exception e) { Log.Write("PlayerDisconnected: " + e.Message, nLog.Type.Error); }
        }
        #region PhoneCallback
        [RemoteEvent("Phone")]
        public async Task PhoneCallback(Player Player, params object[] arguments)
        {
            if (Player == null || !Main.Players.ContainsKey(Player)) return;

            try
            {
                string eventName = Convert.ToString(arguments[0]);

                Menu menu = Menus[Player];
                switch (eventName)
                {
                    case "navigation":
                        string btn = Convert.ToString(arguments[1]);
                        if (btn == "home")
                        {
                            Close(Player, false);
                            Main.OpenPlayerMenu(Player).Wait();
                        }
                        else if (btn == "back")
                        {
                            menu.BackButton.Invoke(Player, menu);
                        }
                        break;
                    case "callback":
                        if (menu == null) return;
                        string ItemID = Convert.ToString(arguments[1]);
                        string Event = Convert.ToString(arguments[2]);
                        //dynamic data = NAPI.Util.FromJson(arguments[3].ToString());
                        dynamic data = JsonConvert.DeserializeObject(arguments[3].ToString());

                        Menu.Item item = menu.Items.FirstOrDefault(i => i.ID == ItemID);
                        if (item == null) return;
                        //await Log.DebugAsync($"app:{menu.ID}; item:{item.ID};");
                        //await Log.DebugAsync($"json:{Convert.ToString(arguments[3])}");
                        menu.Callback.Invoke(Player, menu, item, Event, data);
                        return;
                }
                return;
            }
            catch (Exception e)
            {
                Menu menu = Menus[Player];
                Log.Write($"EXCEPTION AT /{menu.ID}/\"PHONE_CALLBACK\":\n" + e.ToString(), nLog.Type.Error);
            }
        }
        #endregion
        #region Menu Open
        public static void Open(Player Player, Menu menu, bool force = false)
        {
            try
            {
                if (Menus.ContainsKey(Player))
                {
                    Log.Debug($"Player already have opened Menu! id:{Menus[Player].ID}", nLog.Type.Warn);
                    if (!force) return;
                    Menus.Remove(Player);
                }
                Menus.Add(Player, menu);

                //string data = JsonConvert.SerializeObject(menu);
                string data = menu.getJsonStr();

                if (!Player.HasData("Phone"))
                {
                    Trigger.ClientEvent(Player, "phoneShow");
                    Player.SetData("Phone", true);
                }
                Trigger.ClientEvent(Player, "phoneOpen", data);
            }
            catch (Exception e)
            {
                Log.Write("EXCEPTION AT \"MENUCONTROL_OPEN\":\n" + e.ToString(), nLog.Type.Error);
            }
        }
        public static async Task OpenAsync(Player Player, Menu menu, bool force = false)
        {
            try
            {
                lock (Menus)
                {
                    if (Menus.ContainsKey(Player))
                    {
                        Log.Debug($"Player already have opened Menu! id:{Menus[Player].ID}");
                        if (!force) return;
                        Menus.Remove(Player);
                    }
                    Menus.Add(Player, menu);
                }
                string data = await menu.getJsonStrAsync();

                if (!Player.HasData("Phone"))
                {
                    Trigger.ClientEvent(Player, "phoneShow");
                    Player.SetData("Phone", true);
                }
                Trigger.ClientEvent(Player, "phoneOpen", data);
            }
            catch (Exception e)
            {
                Log.Write("EXCEPTION AT \"MENUCONTROL_OPEN\":\n" + e.ToString(), nLog.Type.Error);
            }
        }
        #endregion
        #region Menu Close
        public static void Close(Player Player, bool hidePhone = true)
        {
            try
            {
                if (Menus.ContainsKey(Player))
                    Menus.Remove(Player);
                if (hidePhone)
                {
                    Trigger.ClientEvent(Player, "phoneHide");
                    Player.ResetData("Phone");
                }
                Trigger.ClientEvent(Player, "phoneClose");
            }
            catch (Exception e)
            {
                Log.Write("EXCEPTION AT \"MENUCONTROL_CLOSE\":\n" + e.ToString(), nLog.Type.Error);
            }
        }
        public static async Task CloseAsync(Player Player, bool hidePhone = true)
        {
            try
            {
                lock (Menus)
                {
                    if (Menus.ContainsKey(Player))
                        Menus.Remove(Player);
                }

                if (hidePhone)
                {
                    Trigger.ClientEvent(Player, "phoneHide");
                    Player.ResetData("Phone");
                }
                Trigger.ClientEvent(Player, "phoneClose");
            }
            catch (Exception e)
            {
                Log.Write("EXCEPTION AT \"MENUCONTROL_CLOSE\":\n" + e.ToString(), nLog.Type.Error);
            }
        }
        #endregion
    }
    class Menu
    {
        public delegate void MenuCallback(Player Player, Menu menu, Item item, string eventName, dynamic data);
        public delegate void MenuBack(Player Player, Menu menu);

        public string ID { get; internal set; }
        public List<Item> Items { get; internal set; }
        public bool canBack { get; internal set; }
        public bool canHome { get; internal set; }

        [JsonIgnore]
        public MenuCallback Callback { get; set; }
        [JsonIgnore]
        public MenuBack BackButton { get; set; }
        [JsonIgnore]
        private static nLog Log = new nLog("Menu");

        public Menu(string id, bool canback, bool canhome)
        {
            if (string.IsNullOrEmpty(id))
                ID = "";
            else
                ID = id;

            Items = new List<Item>();
            Callback = null;
            BackButton = null;
            canHome = canhome;
            canBack = canback;
        }
        public void Add(Item item)
        {
            Items.Add(item);
        }
        public void Open(Player Player)
        {
            MenuManager.Open(Player, this, true);
        }
        public async Task OpenAsync(Player Player)
        {
            await MenuManager.OpenAsync(Player, this, true);
        }
        public void Change(Player Player, int index, Item newData)
        {
            string data = JsonConvert.SerializeObject(newData.getJsonArr());
            Trigger.ClientEvent(Player, "phoneChange", index, data);
        }

        public string getJsonStr()
        {
            JArray items = new JArray();
            foreach (Item i in Items)
            {
                items.Add(i.getJsonArr());
            }
            JArray menuData = new JArray()
            {
                ID,
                items,
                canBack,
                canHome,
            };
            string data = JsonConvert.SerializeObject(menuData);
            //Log.Write(data, nLog.Type.Debug);
            return data;
        }
        public async Task<string> getJsonStrAsync()
        {
            JArray items = new JArray();
            foreach (Item i in Items)
            {
                items.Add(await i.getJsonArrAsync());
            }
            JArray menuData = new JArray()
            {
                ID,
                items,
                canBack,
                canHome,
            };
            string data = JsonConvert.SerializeObject(menuData);
            return data;
        }

        internal class Item
        {
            public string ID { get; internal set; }
            public string Text { get; internal set; }
            public MenuItem Type { get; internal set; }
            public MenuColor Color { get; set; }
            public int Column { get; set; }
            public int Scale { get; set; }
            public bool Checked { get; set; }
            public List<string> Elements { get; set; }

            public Item(string id, MenuItem type)
            {
                if (string.IsNullOrEmpty(id))
                    ID = "";
                else
                    ID = id;
                Type = type;
                Column = 1;
            }
            public JArray getJsonArr()
            {
                JArray elements = new JArray(Elements);
                JArray data = new JArray()
                {
                    ID,
                    Text,
                    Type,
                    Color,
                    Column,
                    Scale,
                    Checked,
                    elements
                };
                return data;
            }
            public async Task<JArray> getJsonArrAsync()
            {
                JArray elements = new JArray(Elements);
                JArray data = new JArray()
                {
                    ID,
                    Text,
                    Type,
                    Color,
                    Column,
                    Scale,
                    Checked,
                    elements
                };
                return data;
            }
        }
        #region Enums
        public enum MenuItem
        {
            Void,
            Header,
            Card,
            Button,
            Checkbox,
            Input,
            List,
            gpsBtn, // Добавленно для иконки в телефон
            contactBtn,
            servicesBtn,
            homeBtn,
            businessBtn
        }
        public enum MenuColor
        {
            White,
            Red,
            Green,
            Blue,
            Yellow,
            Orange,
            Teal,
            Cyan,
            Lime
        }
        #endregion
    }
}
