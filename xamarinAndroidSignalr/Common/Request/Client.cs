using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RestSharp;
namespace xamarinAndroidSignalr
{
    
    internal class Client
    {
        private const string host = "192.168.1.172:99";
        private const string url = "http://"+host+"/api/{0}";
        private static RestClient GetClient(string  api)
        {
            var client = new RestClient(string.Format(url, api))
            {
                Timeout = 5000,
                ReadWriteTimeout =5000
            };
            return client;
        }

        public static void Login(string  account, string  pwd,Action successAction,Action<string> errorAction)
        {
            try
            {
                RestClient client = GetClient("user/login");
                var request = new RestRequest($"?account={account.Trim()}&pwd={pwd.Trim()}");
                //request.AddBody("account",account);
               // request.AddBody("pwd", pwd);
                RestRequestAsyncHandle restHandle = client.PostAsync(request,(response,handle)=> {
                    if (response.StatusCode == 0)
                    {
                        errorAction("ÍøÂç×´¿ö²î,ÇëÁªÍøÖØÊÔ");
                        return;
                    }
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string content = response.Content;
                        if (response.Content.Contains("success"))
                        {
                            successAction();
                            return;
                        }
                    }
                    errorAction("µÇÂ¼Ê§°Ü"+response.StatusCode);
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
    }
}