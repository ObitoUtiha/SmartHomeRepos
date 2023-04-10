using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmartHomeApi.Model
{
    public partial class UserInHome
    {
        public UserInHome()
        {
            ActivityHistories = new HashSet<ActivityHistory>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? HomeId { get; set; }

        public virtual Home? Home { get; set; }
        public virtual User? User { get; set; }
        [JsonIgnore]

        public virtual ICollection<ActivityHistory> ActivityHistories { get; set; }
    }
}
