using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace MVCBartender.Models
{
    public class order
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [Display(Name = "Order For")]
        public string orderdBy { get; set; }
        [Required]
        [Display(Name = "Order Items")]
        public List<barProduct> items { get; set; }
        [Required]
        [Display(Name = "Sale Price")]
        [DataType(DataType.Currency)]
        public float costOfOrder { get; set; }
    }

    public class orderContext : DbContext
    {
        public DbSet<order> orders { get; set; }
    }

}