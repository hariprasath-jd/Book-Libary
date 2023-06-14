using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Book_Libary.Models.User
{
    public class UserLoginLog
    {
        [ForeignKey("UserInfo")]
        [Key]
        public int Id { get; set; }
        public DateTime LogedIn { get; set; }

        public UserLoginInfo UserInfo { get; set; }
    }
}