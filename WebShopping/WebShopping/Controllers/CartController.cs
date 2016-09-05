using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using WebShopping.Models;


namespace WebShopping.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        private CartContext db = new CartContext();
        static List<Models.Cart> crats = new List<Models.Cart>();
        List<Models.Product> produs = new List<Models.Product>()
        {

            new Models.Product
            {
                Pid =1,PName="パナソニック 19V型 ハイビジョン 液晶テレビ",
                Description ="「お部屋ジャンプリンク」対応で、別室のディーガなどに録画した番組を楽しめる。USBハードディスクへの録画対応で、かんたん番組録画。ARCに対応し、ホームシアターとつないで臨場感ある音を楽しめる ",
                PNum =10,Price=26200,PtId=1,Image="~/Images/1.jpg" },
            new Models.Product
            {
                Pid =2,PName="シャープ 32V型 AQUOS 液晶テレビ",
                Description ="Wチューナー搭載&USB HDDで裏録対応。地上デジタル放送で3倍録画が可能。",
                PNum =10,Price=37630,PtId=1,Image="~/Images/2.jpg"  },
            new Models.Product
            {
                Pid =3,PName="LG 43V型 4K液晶テレビ",
                Description ="どの角度からも鮮明に、IPSパネルが生み出す4Kにふさわしい広視野角。最薄部の奥行3.9cmのウルトラスリムボディ。新感覚マジックリモコン(付属)でスマート機能もかんたん操作。",
                PNum =10,Price=75800,PtId=1,Image="~/Images/3.jpg"  },
            new Models.Product
            {
                Pid =4,PName="シャープ サイクロン掃除機 ベージュ",
                Description ="高速旋回気流でごみと空気を強力に遠心分離。フローリング・畳のから拭きができます。騒音レベルを抑えてお掃除「やさしさモード」。ボタンを押すだけで、カップが着脱「ワンタッチ 着脱カップ」。つまみを回すだけでHEPAクリーンフィルターを簡単にクリーニング。 ",
                PNum =10,Price=10389,PtId=2,Image="~/Images/4.jpg" },
            new Models.Product
            {
                Pid =5,PName="東芝 紙パック式掃除機 ブルー",
                Description ="持ち運びやすく使いやすい！コンパクトボディ。フローリングターボヘッド搭載。お掃除を中断する時に便利な「ちょいとスタンド」付",
                PNum =10,Price=7980,PtId=2,Image="~/Images/5.jpg" },
            new Models.Product
            {
                Pid =6,PName="日立 紙パック式掃除機 ホワイト",
                Description ="軽量・コンパクトで取り回しラクラク。じゅうたん上のごみをかき上げる＜エアーヘッド＞。空気がスムーズに流れる＜パワー長持ち流路＞。空気の力でブラシを回転させ、じゅうたん上のごみをかき上げる。ヘッドは水洗いできる。ごみがたまってきても、空気がスムーズに流れるので、紙パックが長持ちする。 ",
                PNum =10,Price=9800,PtId=2,Image="~/Images/6.jpg" },
            new Models.Product
            {
                Pid =7,PName="パナソニック 単機能レンジ22L ホワイト",
                Description ="細かな火力コントロールができる850Wインバーターで解凍もスピーディーに。出力も3段階切り換えで。出力3段階切り換えで用途に合わせて使い分けができます。また、蒸気センサーによって、食品の分量にかかわらずワンタッチで簡単あたため。庫内広々なので大きなお弁当もあたためられます。",
                PNum =10,Price=11379,PtId=3,Image="~/Images/7.jpg" },
            new Models.Product
            {
                Pid =8,PName="シャープ スチームオーブンレンジ23L ブラック",
                Description ="おいしくヘルシーな、過熱水蒸気メニュー、自動でカンタン、冷凍食品(市販品)あたため、すっきり置ける、「奥行38cm&背面壁ピタ設計」、すばやくスチームが発生、「クイックスチーム方式」、外はこんがり、中はしっとり「自動トースト」、お料理に合わせて選べる、「あたため機能」 ",
                PNum =10,Price=20800,PtId=3,Image="~/Images/8.jpg"},
            new Models.Product
            {
                Pid =9,PName="日立 過熱水蒸気オーブンレンジ22L パールホワイト",
                Description ="コンパクトオーブン。過熱水蒸気・ノンフライ調理【ヘルシー調理】。3～4人分・2人分もオートで簡単【少人数も選べる26メニュー】。充実の蒸し料理【スチーム調理】。 ",
                PNum =10,Price=21980,PtId=3,Image="~/Images/9.jpg"  }
        };
        public ActionResult Index()
        {
            var cars = crats.Where(c => c.UserName == User.Identity.Name).ToList();
            List<Models.Product> ps = new List<Models.Product>();
            foreach (var item in cars)
            {
                ps.Add(produs.Where(p => p.Pid == item.Pid).SingleOrDefault());
                return View(ps);
            }
            //return View(ps);
            return View(db.Carts.Where(c => c.UserName == User.Identity.Name).ToList());
        }
        /// <summary>
        /// カートに入れる
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        [Authorize]
        public ActionResult AddToCart(int pid)
        {
            Models.Cart car = new Models.Cart();
            car.Cid = 1;
            car.Amount = 1;
            car.Pid = pid;
            car.UserName = User.Identity.Name;
            //この商品はすでにカートに入っているかどうかをチェック
            if (crats.Where(c => c.UserName == car.UserName && c.Pid == pid).Count() == 0)
            {
                crats.Add(car);
            }
            return RedirectToAction("Index");
            

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToCart([Bind(Include = "Cid,Amount,Pid,UserName")]Cart cart)
        {
            if (ModelState.IsValid)
            {

                db.Carts.Add(cart);
                cart.UserName = User.Identity.Name;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cart);
        }
        /// <summary>
        /// カートから削除
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        [OutputCache(Duration =0)]
        public ActionResult Remove(int pid)
        {
            string[] pids = Request.Form.GetValues("pids[]");
            string[] checks = Request.Form.GetValues("checks[]");
            string[] counts = Request.Form.GetValues("count[]");
            crats.Remove(crats.Where(s => s.Pid == pid).SingleOrDefault());
            var cras = crats.Where(c => c.UserName == User.Identity.Name).ToList();
            List<Models.Product> ps = new List<Models.Product>();
            if(pids!=null)
            {
                foreach(var item in pids)
                {
                    ps.Add(produs.Where(p => p.Pid.ToString() == item).SingleOrDefault());
                }
                ViewBag.Check = checks.ToList();
                ViewBag.counts = counts.ToList();
                //カートから削除する
                List<Models.Cart> carss = (List<Models.Cart>)Session["carts"];
                foreach(var item in carss)
                {
                    if(item.Pid==pid)
                    {
                        carss.Remove(item);
                        break;
                    }
                    Cart cart = db.Carts.Find(pid);
                }
                Session["carts"] = carss;
            }
            return PartialView("_PartialPage1", ps);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove([Bind(Include = "Cid,Amount,Pid,UserName")]Cart cart)
        {
            if(ModelState.IsValid)
            {
                db.Entry(cart).State = EntityState.Modified;
                cart.UserName = User.Identity.Name;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cart);
        }
        public ActionResult Ajaxplay()
        {
            string[] pids = Request.Form.GetValues("pid[]");
            string[] counts = Request.Form.GetValues("count[]");
            string[] prices = Request.Form.GetValues("price[]");
            int sun = 0;
            double price = 0;
            if(counts==null)
            {
                return Content("0|0");
            }
            Cart cart = db.Carts.Find(pids);
            for(int i=0;i<pids.Length;i++)
            {
                price += produs.Where(d => d.Pid == int.Parse(pids[i])).SingleOrDefault().Price * double.Parse(counts[i]);
                sun += int.Parse(counts[i]);
            }
            return Content(price.ToString() + "|" + sun.ToString());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ajaxplay([Bind(Include =" Cid, Amount, Pid, UserName")]Cart cart)
        {
            if(ModelState.IsValid)
            {
                db.Entry(cart).State = EntityState.Modified;
                cart.UserName = User.Identity.Name;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cart);
        }
        public ActionResult Aajax(string pid)
        {
            var resule = produs.Where(p => p.Pid == int.Parse(pid)).SingleOrDefault().Price;
            return Content(resule.ToString());
        }
        public ActionResult SS()
        {
            string[] pids = Request.Form.GetValues("pids[]");
            string[] checks = Request.Form.GetValues("checks[]");
            string[] counts = Request.Form.GetValues("count[]");
            int sum = 0;
            int i = 0;
            List<Models.Cart> carts = new List<Models.Cart>();
            foreach(var item in pids)
            {
                sum += int.Parse(item);
                Models.Cart c = new Models.Cart();
                c.Pid = int.Parse(item);
                c.Amount = int.Parse(counts[i]);
                c.UserName = User.Identity.Name;
                carts.Add(c);
                i++;
            }
            //保存
            Session["carts"] = carts;
            return Content(sum.ToString());
            
        }
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}