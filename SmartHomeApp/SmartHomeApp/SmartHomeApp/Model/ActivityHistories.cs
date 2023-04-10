using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHomeApp.Model
{
    public class ActivityHistories
    {

            public int id { get; set; }
            public int userInHomeId { get; set; }
            public DateTime? dateOfInclusion { get; set; }
            public int deviceInRoomId { get; set; }
            public string status { get; set; }
            public DeviceInRooms deviceInRoom { get; set; }
            public UserInHomes userInHome { get; set; }
    




        public class Devicenavigation
        {
            public int roomId { get; set; }
            public string name { get; set; }
            public int devicesId { get; set; }
            public int homeId { get; set; }
            public Homes home { get; set; }
        }


        public class Ownernavigation
        {
            public int userId { get; set; }
            public string login { get; set; }
            public string nickName { get; set; }
            public int roleId { get; set; }
            public string password { get; set; }
            public Roles role { get; set; }
        }

    }
}
