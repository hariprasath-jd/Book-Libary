using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Book_Libary.Models.Inventory
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthorDescription { get; set; }
        public string AuthorImage { get; set; }

        public ICollection<Product> Product { get; set; }

    }
}