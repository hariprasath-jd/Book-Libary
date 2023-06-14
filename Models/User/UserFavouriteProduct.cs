using Book_Libary.Models.Inventory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Book_Libary.Models.User
{
    public class UserFavouriteProduct
    {
        [Key]
        public int Id { get; set; }
        //[ForeignKey()]
        public int ProductId { get; set;}
        

        public Product Product { get; set; }
    }
}