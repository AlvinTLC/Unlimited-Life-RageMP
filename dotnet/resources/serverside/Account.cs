using System;
using System.Collections.Generic;

namespace UNL.SDK
{
    public class AccountData
    {
        public string Login { get; protected set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string HWID { get; protected set; }
        public string IP { get; protected set; }
        public string SocialClub { get; protected set; }

        public int Whitelist { get; set; }

        public long ulife { get; set; }
        public int VipLvl { get; set; }
        public DateTime VipDate { get; set; } = DateTime.Now;
        public DateTime lastwheel { get; set; } = DateTime.Now;
        public DateTime wheel { get; set; } = DateTime.Now;
        public DateTime timewheel { get; set; } = DateTime.Now;

        public List<string> PromoCodes { get; set; }
        public List<int> Characters { get; protected set; } // characters uuids

        public bool PresentGet { get; set; } = false;
    }
}