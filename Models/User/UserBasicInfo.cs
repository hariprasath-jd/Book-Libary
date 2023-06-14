using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Sockets;
using System.Web;

namespace Book_Libary.Models.User
{
    public class UserBasicInfo
    {
        [ForeignKey("UserInfo")]
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }

        public UserLoginInfo UserInfo { get; set; }
    }
}