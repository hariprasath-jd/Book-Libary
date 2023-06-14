using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Book_Libary.Models.Inventory
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string GerneType { get; set; }
        public string GenreDescription { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}