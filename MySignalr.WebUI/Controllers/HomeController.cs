using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
namespace MySignalr.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Chat()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            Response.Write("chat页面线程ID"+ threadId);
            Response.Write("用户登录页面cache设置的test的值"+HttpContext.Cache["test"]+HttpCurrent.Context.Cache["test"]);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}