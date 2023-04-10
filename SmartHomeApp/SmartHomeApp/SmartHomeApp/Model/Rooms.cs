using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHomeApp.Model
{
    public class Rooms
    {

            public int roomId { get; set; }
            public string name { get; set; }
            public int devicesId { get; set; }
            public int homeId { get; set; }
            public Homes home { get; set; }

    }
}
