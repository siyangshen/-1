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
        public int Odid { get; set; }
        [Required]
        [Range(0,100000)]
        public double Price { get; set; }
        public int Amout { get; set; }
        public int Pid { get; set; }
        public Product Product { get; set; }
        public int Oid { get; set; }
        public Order Order { get; set; }


    }
}