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
        List<Models.Product> produs = new List<Models.Product>()
        {
            new Models.Product {Pid=1,PName="パナソニック",Description="19V型 ハイビジョン 液晶テレビ",PNum=10,Price=26200,PtId=1,Image="~/Images/1.jpg" },
            new Models.Product {Pid=2,PName="シャープ",Description="32V型 AQUOS 液晶テレビ",PNum=10,Price=37630,PtId=1,Image="~/Images/2.jpg"  },
            new Models.Product {Pid=3,PName="LG",Description="43V型 4K液晶テレビ",PNum=10,Price=75800,PtId=1,Image="~/Images/3.jpg"  },
            new Models.Product {Pid=4,PName="シャープ",Description="サイクロン掃除機 ベージュ",PNum=10,Price=10389,PtId=2,Image="~/Images/4.jpg" },
            new Models.Product {Pid=5,PName="東芝",Description="紙パック式掃除機 ブルー",PNum=10,Price=7980,PtId=2,Image="~/Images/5.jpg" },
            new Models.Product {Pid=6,PName="日立",Description="紙パック式掃除機 ホワイト",PNum=10,Price=9800,PtId=2,Image="~/Images/6.jpg" },
            new Models.Product {Pid=7,PName="パナソニック",Description="単機能レンジ22L ホワイト",PNum=10,Price=11379,PtId=3,Image="~/Images/7.jpg" },
            new Models.Product {Pid=8,PName="シャープ",Description="スチームオーブンレンジ23L ブラック",PNum=10,Price=20800,PtId=3,Image="~/Images/8.jpg"},
            new Models.Product {Pid=9,PName="日立",Description="過熱水蒸気オーブンレンジ22L パールホワイト",PNum=10,Price=21980,PtId=3,Image="~/Images/9.jpg" }
        };
        
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
        //オーダーとカートの情報をデータベースへ書き込む
        public ActionResult Complete()
        {
            List<Models.Cart> carts = (List<Models.Cart>)Session["carts"];
            List<Models.Product> products = new List<Models.Product>();
            List<int> num = new List<int>();
            foreach(var item in carts)
            {
                products.Add(produs.Where(d => d.Pid == item.Pid).SingleOrDefault());
                num.Add(item.Amount);
            }
            ViewBag.counts = num;
            return View(products);
        }
    }
}