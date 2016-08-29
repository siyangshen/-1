using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShopping.Controllers
{
    public class HomeController : Controller
    {
        List<Models.ProductType> typs = new List<Models.ProductType>()
        {
            new Models.ProductType {PtId=1,PtName="テレビ" },
            new Models.ProductType {PtId=2,PtName="掃除機" },
            new Models.ProductType {PtId=3,PtName="電子レンジ" }
        };
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
        List<Models.ProductImg> pimgs = new List<Models.ProductImg>()
        {
            new Models.ProductImg {Pimgid=1,ImgUrl="~/Images/1.jpg" ,Pid=1 },
            new Models.ProductImg {Pimgid=2,ImgUrl="~/Images/2.jpg" ,Pid=2 },
            new Models.ProductImg {Pimgid=3,ImgUrl="~/Images/3.jpg" ,Pid=3 },
            new Models.ProductImg {Pimgid=4,ImgUrl="~/Images/4.jpg" ,Pid=4 },
            new Models.ProductImg {Pimgid=5,ImgUrl="~/Images/5.jpg" ,Pid=5 },
            new Models.ProductImg {Pimgid=6,ImgUrl="~/Images/6.jpg" ,Pid=6 },
            new Models.ProductImg {Pimgid=7,ImgUrl="~/Images/7.jpg" ,Pid=7 },
            new Models.ProductImg {Pimgid=8,ImgUrl="~/Images/8.jpg" ,Pid=8 },
            new Models.ProductImg {Pimgid=9,ImgUrl="~/Images/9.jpg" ,Pid=9 },
        };

        public ActionResult Index()
        {
            ViewBag.Type = typs;
            ViewBag.P = produs;
            Session["mid"] = "w123";
            return View();
        }
        /// <summary>
        /// 商品のリスト
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ProductList(int id)
        {
            ViewBag.Type = typs;
            ViewBag.P = produs.Where(p => p.PtId == id).ToList();
            return View("index");
        }
        /// <summary>
        /// 商品の詳細
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public ActionResult ProductDetails(int pid)
        {
            var product = produs.Where(p => p.Pid == pid).SingleOrDefault();
            ViewBag.images = pimgs.Where(p => p.Pid == pid).ToList();            
            return View(product);
        }        
    }
}