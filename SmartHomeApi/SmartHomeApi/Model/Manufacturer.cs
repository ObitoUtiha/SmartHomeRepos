using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmartHomeApi.Model
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            Devices = new HashSet<Device>();
        }

        public int ManufacturerId { get; set; }
        public string? Name { get; set; }
        [JsonIgnore]

        public virtual ICollection<Device> Devices { get; set; }
    }
}
