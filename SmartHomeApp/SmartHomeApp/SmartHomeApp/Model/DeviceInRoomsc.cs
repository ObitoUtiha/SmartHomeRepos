using System;
using System.Collections.Generic;
using System.Text;
using static SmartHomeApp.Model.ActivityHistories;

namespace SmartHomeApp.Model
{
    public class DeviceInRooms
    {
        public int id { get; set; }
        public int roomId { get; set; }
        public int deviceId { get; set; }
        public Devices device { get; set; }
        public Devicenavigation deviceNavigation { get; set; }
    }
}
