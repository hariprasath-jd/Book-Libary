using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Book_Libary.Models.User

{
    public class UserLoginInfo
    {
       
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public UserLocationInfo Location { get; set; }
        public UserBasicInfo BasicInfo { get; set; }
        public UserLoginLog LogData { get; set; }
    }
}