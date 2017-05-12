using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySignalr.DAL;
using MySignalr.DAL.DbModels;
namespace MySignalr.WebUI
{
    public static class HttpCurrent
    {
        public static HttpContextBase Context => new HttpContextWrapper(HttpContext.Current);

        public static HttpRequestBase Request => Context.Request;
        
        public static LoginedUser User
        {
            get {
                var key = "current_cache_user";
                using (var db = new DbEntities())
                {
                    if (!HttpContext.Current.Items.Contains(key))
                    {
                        HttpContext.Current.Items[key] = db.UserInfo.FirstOrDefault(p => p.Account == HttpContext.Current.User.Identity.Name);
                    }
                }
                return HttpContext.Current.Items[key] as LoginedUser; 
            }
        }
    }
}