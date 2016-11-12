using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using System.Net.Http.Formatting;
using System.Security.Claims;
namespace MySignalr.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //RouteTable.Routes.MapHubs();
            GlobalConfiguration.Configure(WebApiConfig.Register);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        private static readonly List<string> IgnorePaths = new List<string>
        {
            "/images/",
            "/scripts/",
            "/style/",
            "/styles/",
            "/content/",
            "/js/",
            "/css/",
            "signalr",
            "/account/logon",
            "/home/quicklogon",
            "__browserlink",
        };
        protected void Application_AuthenticateRequest(object sender,EventArgs e)
        {
            var context = new HttpContextWrapper(HttpContext.Current);
            //忽略
            if (context.Request.Url != null)
            {
                var pathAndQuery = context.Request.Url.PathAndQuery.ToLower();
                if (IgnorePaths.Any(pathAndQuery.StartsWith))
                {
                    return;
                }
            }
         
            var webCookies = new WebCookie();
            if (webCookies.HasLoginOn)
            {
                try {
                    string c = webCookies.AccountIdentityCookie;
                    var code = webCookies.AccountIdentityCookie.DESDecrypt();
                    var claims = new List<Claim> { new Claim(ClaimTypes.Name, code) };
                    var claimsIdentity = new ClaimsIdentity(claims, "zl", "", "admin");
                    context.User = new ClaimsPrincipal(claimsIdentity);
                    return;
                }
                catch (Exception ep)
                {
                    System.Diagnostics.Debug.WriteLine(ep.ToString());
                }
            }
        }
    }
}
