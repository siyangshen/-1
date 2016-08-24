using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShopping.Controllers
{
    public class HomeController : Controller
    {
        List<Models.ProductType> types = new List<Models.ProductType>()
        {
            new Models.ProductType {PtId=1,PtName="テレビ" },
            new Models.ProductType {PtId=2,PtName="掃除機" },
            new Models.ProductType {PtId=3,PtName="電子レンジ" }
        };
        List<Models.Product> products = new List<Models.Product>()
        {
            new Models.Product {PId=1,PName="パナソニック",Description="19V型 ハイビジョン 液晶テレビ",PNum=10,Price=26200,PtId=1,Image="~/Image1/1.jpg" },
            new Models.Product {PId=2,PName="シャープ",Description="32V型 AQUOS 液晶テレビ",PNum=10,Price=37630,PtId=1,Image="~/Image1/2.jpg"  },
            new Models.Product {PId=3,PName="LG",Description="43V型 4K液晶テレビ",PNum=10,Price=75800,PtId=1,Image="~/Image1/3.jpg"  },
            new Models.Product {PId=4,PName="シャープ",Description="サイクロン掃除機 ベージュ",PNum=10,Price=10389,PtId=2,Image="~/Image2/1.jpg" },
            new Models.Product {PId=5,PName="東芝",Description="紙パック式掃除機 ブルー",PNum=10,Price=7980,PtId=2,Image="~/Image2/2.jpg" },
            new Models.Product {PId=6,PName="日立",Description="紙パック式掃除機 ホワイト",PNum=10,Price=9800,PtId=2,Image="~/Image2/3.jpg" },
            new Models.Product {PId=7,PName="パナソニック",Description="単機能レンジ22L ホワイト",PNum=10,Price=11379,PtId=3,Image="~/Image3/1.jpg" },
            new Models.Product {PId=8,PName="シャープ",Description="エレックオーブンレンジ26L ホワイト",PNum=10,Price=8980,PtId=3,Image="~/Image3/2.jpg"},
            new Models.Product {PId=9,PName="日立",Description="過熱水蒸気オーブンレンジ22L パールホワイト",PNum=10,Price=21980,PtId=3,Image="~/Image3/3.jpg" }
        };
        List<Models.ProductImage> image = new List<Models.ProductImage>()
        {
            new Models.ProductImage {ProImgId=1,ImgUrl="~/Image1/1.jpg" ,PId=1 },
            new Models.ProductImage {ProImgId=2,ImgUrl="~/Image1/2.jpg" ,PId=2 },
            new Models.ProductImage {ProImgId=3,ImgUrl="~/Image1/3.jpg" ,PId=3 },
            new Models.ProductImage {ProImgId=4,ImgUrl="~/Image2/1.jpg" ,PId=4 },
            new Models.ProductImage {ProImgId=5,ImgUrl="~/Image2/2.jpg" ,PId=5 },
            new Models.ProductImage {ProImgId=6,ImgUrl="~/Image2/3.jpg" ,PId=6 },
            new Models.ProductImage {ProImgId=7,ImgUrl="~/Image3/1.jpg" ,PId=7 },
            new Models.ProductImage {ProImgId=8,ImgUrl="~/Image3/2.jpg" ,PId=8 },
            new Models.ProductImage {ProImgId=9,ImgUrl="~/Image3/3.jpg" ,PId=9 },
        };

        public ActionResult Index()
        {
            ViewBag.Type = types;
            ViewBag.P = products;
            return View();
        }
        /// <summary>
        /// 商品のリスト
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ProductList(int id)
        {
            ViewBag.Type = types;
            ViewBag.P = products.Where(p => p.PtId == id).ToList();
            return View("index");
        }
        public ActionResult ProductDetails(int pid)
        {
            var product = products.Where(p => p.PtId == pid).SingleOrDefault();
            ViewBag.images = image.Where(p => p.PId == pid).ToList();            
            return View(product);
        }        
    }
}