using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShopping.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        static List<Models.Cart> carts = new List<Models.Cart>();
        List<Models.Product> products = new List<Models.Product>()
        {
            new Models.Product {PId=1 }
        };
        public ActionResult Index()
        {
            return View();
        }
    }
}