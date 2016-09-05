using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace WebShopping.Models
{
    public class OrderInitializer:CreateDatabaseIfNotExists<OrderContext>
    {
        protected override void Seed(OrderContext context)
        {
            
        }
    }
}