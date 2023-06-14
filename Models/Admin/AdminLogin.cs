using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Libary.Models.Admin
{
    public class AdminLogin
    {
        public int Id { get; set; }
        public string AdminId { get; set;}
        public string AdminPassword { get; set; }
        public string AdminAttributte { get; set; }
    }
}