using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebShopping.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrId { get; set; }
        [Required]
        [Range(0,100000)]
        public double Price { get; set; }
        public int Amout { get; set; }
        public int ProId { get; set; }
        public Product Product { get; set; }
        public int OId { get; set; }
        public Order Order { get; set; }


    }
}