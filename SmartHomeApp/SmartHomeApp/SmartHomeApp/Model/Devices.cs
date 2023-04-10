using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;
using static SmartHomeApp.Model.ActivityHistories;

namespace SmartHomeApp.Model
{
    public class Devices
    {
        public int devicesId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int power { get; set; }
        public int manufacturerId { get; set; }
        public byte[] photo { get; set; }
        [JsonIgnore]
        public ImageSource image => photo == null ? null : ImageSource.FromStream(() => new MemoryStream(photo));

        public int photoId { get; set; }
        public Manufacturers manufacturer { get; set; }

        public string fullPower => $"Мощность: {power} В.";
        public string fullMan => $"Производитель: {manufacturer.name}";

    }
}
