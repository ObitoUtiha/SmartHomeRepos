using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHomeApp.Model
{
    public class Users
    {

            public int userId { get; set; }
            public string login { get; set; }
            public string nickName { get; set; }
            public int roleId { get; set; }
            public string password { get; set; }
            public Roles role { get; set; }


    }
}
