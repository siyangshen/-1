using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebShopping.Controllers
{
    public class MemberController : Controller
    {
        // GET: Begin
        /// <summary>
        /// 会員登録
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Models.Member member)
        {
            return View();
        }
        /// <summary>
        /// ログイン
        /// </summary>
        /// <param name="resulturl"></param>
        /// <returns></returns>
        public ActionResult Login(string resulturl)
        {
            ViewBag.Url = resulturl;
            return View();
        }
        
        public ActionResult Login(string account,string pwd,string resulturl)
        {
            FormsAuthentication.SetAuthCookie("admin", false);
            return Redirect(resulturl);
        }
        /// <summary>
        /// ログアウト
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            return View();
        }
    }
}