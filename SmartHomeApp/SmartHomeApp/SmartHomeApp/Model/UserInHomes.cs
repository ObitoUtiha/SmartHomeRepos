using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHomeApp.Model
{
    public class UserInHomes
    {

            public int id { get; set; }
            public int userId { get; set; }
            public int homeId { get; set; }
            public Homes home { get; set; }
            public Users user { get; set; }


    }
}
