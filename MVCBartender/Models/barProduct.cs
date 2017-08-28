using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity; 

namespace MVCBartender.Models
{
    public class barProduct
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Display( Name = "Type")]
        public string type { get; set; }
        [Required]
        [Display( Name = "Name")]
        public string name { get; set; }
        [Required]
        [Display( Name = "Price")]
        public float price { get; set; }
    }

    public class barProductContext : DbContext
    {
        public DbSet<barProduct> barProduct { get; set; }
    }
}