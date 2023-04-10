using System;
using System.Collections.Generic;
using System.Text;
using static SmartHomeApp.Model.ActivityHistories;

namespace SmartHomeApp.Model
{
    public class Homes
    {
        public int homeId { get; set; }
        public string fullAddress { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public int owner { get; set; }
        public Ownernavigation ownerNavigation { get; set; }
    }
}
