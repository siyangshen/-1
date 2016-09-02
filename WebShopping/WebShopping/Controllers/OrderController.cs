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
            Session["carts"] = carts;
            ViewBag.counts = num;
            return View(products);
        }
    }
}