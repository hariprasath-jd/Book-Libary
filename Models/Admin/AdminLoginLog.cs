using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Libary.Models.Admin
{
    public class AdminLoginLog
    {
        public int AdminLoginLogId { get; set; } 
        public string AdminId { get; set; }
        public DateTime LoggedAt { get; set; }
        public DateTime Loggedout { get; set; }
    }
}