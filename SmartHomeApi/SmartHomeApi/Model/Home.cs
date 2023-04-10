using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmartHomeApi.Model
{
    public partial class Home
    {
        public Home()
        {
            Rooms = new HashSet<Room>();
            UserInHomes = new HashSet<UserInHome>();
        }

        public int HomeId { get; set; }
        public string? FullAddress { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; }
        public int? Owner { get; set; }

        public virtual User? OwnerNavigation { get; set; }
        [JsonIgnore]

        public virtual ICollection<Room> Rooms { get; set; }
        [JsonIgnore]

        public virtual ICollection<UserInHome> UserInHomes { get; set; }
    }
}
