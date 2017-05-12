using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySignalr.DAL;
using System.Threading;
using  MySignalr.WebUI;
namespace MySignalr.WebUI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string  pwd,string account)
        {
            if (accessDb.checkLogin(account, pwd))
            {
                WebCookie cookie = new WebCookie();
                cookie.CreateUserAuthCookie(account.DESEncrypt());
                Response.Redirect("/Home/Chat");
            }
            return View();
        }
    }
}