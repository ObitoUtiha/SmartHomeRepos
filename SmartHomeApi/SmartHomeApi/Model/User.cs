using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmartHomeApi.Model
{
    public partial class User
    {
        public User()
        {
            Homes = new HashSet<Home>();
            UserInHomes = new HashSet<UserInHome>();
        }

        public int UserId { get; set; }
        public string? Login { get; set; }
        public string? NickName { get; set; }
        public int? RoleId { get; set; }
        public string? Password { get; set; }

        public virtual Role? Role { get; set; }
        [JsonIgnore]

        public virtual ICollection<Home> Homes { get; set; }
        [JsonIgnore]

        public virtual ICollection<UserInHome> UserInHomes { get; set; }
    }
}
