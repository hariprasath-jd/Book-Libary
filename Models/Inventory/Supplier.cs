using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Book_Libary.Models.Inventory
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string SupplierPhone { get; set; }
        public string SupplierEmail { get; set;}
        public string SupplierDescription { get; set; }


        public ICollection<Product> Products { get; set; }
    }
}