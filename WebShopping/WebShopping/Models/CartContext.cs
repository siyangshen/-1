using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebShopping.Models
{
    public class CartContext:DbContext
    {
        public DbSet<Cart> Carts { get; set; }
    }
}