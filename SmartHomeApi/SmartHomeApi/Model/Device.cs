using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmartHomeApi.Model
{
    public partial class Device
    {
        public Device()
        {
            DeviceInRooms = new HashSet<DeviceInRoom>();
        }

        public int DevicesId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Power { get; set; }
        public int? ManufacturerId { get; set; }
        public byte[]? Photo { get; set; }
        public int? PhotoId { get; set; }

        public virtual Manufacturer? Manufacturer { get; set; }
        [JsonIgnore]
        public virtual ICollection<DeviceInRoom> DeviceInRooms { get; set; }
    }
}
