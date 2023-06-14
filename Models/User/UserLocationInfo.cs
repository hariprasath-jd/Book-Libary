using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Book_Libary.Models.User
{
    public class UserLocationInfo
    {
        [ForeignKey("UserInfo")]
        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public UserLoginInfo UserInfo { get; set; }
    }
}