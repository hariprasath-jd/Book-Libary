using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Book_Libary.Models.Inventory
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductPrice { get; set; }
        public string ProductCoverImage { get; set; }
        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        [ForeignKey("Genre")]
        public int CategoryId { get; set; }
        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        public Author Author { get; set; }
        public Genre Genre { get; set; }
        public Supplier Supplier { get; set; }
    }
}