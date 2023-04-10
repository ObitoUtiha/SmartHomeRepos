using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmartHomeApi.Model
{
    public partial class DeviceInRoom
    {
        public DeviceInRoom()
        {
            ActivityHistories = new HashSet<ActivityHistory>();
        }

        public int Id { get; set; }
        public int? RoomId { get; set; }
        public int? DeviceId { get; set; }

        public virtual Device? Device { get; set; }
        public virtual Room? DeviceNavigation { get; set; }
        [JsonIgnore]

        public virtual ICollection<ActivityHistory> ActivityHistories { get; set; }
    }
}
