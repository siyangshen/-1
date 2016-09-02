using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace WebShopping.Models
{
    public class CartInitializer:CreateDatabaseIfNotExists<CartContext>
    {
        protected override void Seed(CartContext context)
        {
            
        }
    }
}