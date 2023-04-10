using System;
using System.Collections.Generic;

namespace SmartHomeApi.Model
{
    public partial class ActivityHistory
    {
        public int Id { get; set; }
        public int? UserInHomeId { get; set; }
        public DateTime? DateOfInclusion { get; set; }
        public int? DeviceInRoomId { get; set; }
        public string? Status { get; set; }

        public virtual DeviceInRoom? DeviceInRoom { get; set; }
        public virtual UserInHome? UserInHome { get; set; }
    }
}
