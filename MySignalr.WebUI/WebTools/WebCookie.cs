using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySignalr.WebUI
{
    public class WebCookie
    {
        private const string SubCookieName = "CN";
        public string CookieName { get; set; }
        public HttpContextBase Context { get; set; }
        public bool ExistsCookies {
            get {
                return Context.Request.Cookies[CookieName] != null;
            }
        }
        public bool HasLoginOn
        {
            get {
                return ExistsCookies;
            }
        }
        public WebCookie()
        {
            Context = new HttpContextWrapper(HttpContext.Current);
            CookieName = "kebioo7";
        }
        public void CreateUserAuthCookie(string token)
        {
            SetCookieItem(CookieName, token);
        }
        /// <summary>
        /// 
        /// </summary>
        public string AccountIdentityCookie
        {
            get {
                return GetCookieItem(CookieName).Value;
            }
        }

        public void ClearUserAuthCookie()
        {
            Context.Response.Cookies.Remove(CookieName);
            Context.Response.Cookies.Clear();
            if (Context.Request.Cookies[CookieName] != null)
            {
                var clearCookie = new HttpCookie(CookieName) {Expires=DateTime.Now.AddDays(-2)};
                Context.Response.Cookies.Add(clearCookie);
            }
        }
        private void SetCookieItem(string field, string  value)
        {
            Context.Response.Cookies.Add(new HttpCookie(field,value));
        }


        private HttpCookie GetCookieItem(string  field)
        {
            if (Context.Request[field] == null)
            {
                return null;
            }
            return Context.Request.Cookies[field];
        }

    }
}