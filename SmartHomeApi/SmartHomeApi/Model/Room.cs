using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmartHomeApi.Model
{
    public partial class Room
    {
        public Room()
        {
            DeviceInRooms = new HashSet<DeviceInRoom>();
        }

        public int RoomId { get; set; }
        public string? Name { get; set; }
        public int? DevicesId { get; set; }
        public int? HomeId { get; set; }

        public virtual Home? Home { get; set; }
        [JsonIgnore]

        public virtual ICollection<DeviceInRoom> DeviceInRooms { get; set; }
    }
}
