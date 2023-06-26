using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Book_Libary.Models.Admin
{
    public class AdminDetails
    {
        public int Id { get; set; }
        public string AdminName { get; set;}
        public string AdminEmail { get; set;}
        public string AdminMobile { get; set; }
        public string AdminAddress { get; set;}

        public AdminLogin Details { get; set;}
    }
}