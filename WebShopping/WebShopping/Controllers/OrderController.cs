using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShopping.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        List<Models.Product> products = new List<Models.Product>()
        {
            new Models.Product {PId=1,PName="パナソニック",Description="19V型 ハイビジョン 液晶テレビ",PNum=10,Price=26200,PtId=1,Image="~/Image/1.jpg" },
            new Models.Product {PId=2,PName="シャープ",Description="32V型 AQUOS 液晶テレビ",PNum=10,Price=37630,PtId=1,Image="~/Image/2.jpg"  },
            new Models.Product {PId=3,PName="LG",Description="43V型 4K液晶テレビ",PNum=10,Price=75800,PtId=1,Image="~/Image/3.jpg"  }
        };
        List<Models.Product>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 完成したオーダーを表示する
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public ActionResult Complete(int s)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Complete()
        {
            List<Models.Cart> carts = (List<Models.Cart>)Session["carts"];
            List<Models.Product> products = new List<Models.Product>();
            List<int> num = new List<int>();
            foreach(var item in carts)
            {
                products.Add(products.Where(d => d.PId == item.PId).SingleOrDefault());
                num.Add(item.Amount);
            }
            ViewBag.counts = num;
            return View(products);
        }
    }
}