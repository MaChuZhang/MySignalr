using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;
namespace MySignalr.WebUI.Hubs
{
    [HubName("serverHub")]
    public class ServerHub : Hub
    {
        [HubMethodName("sendMsg")]
        public void SendMsg(string platform, string message)
        {
            //为客户端注册sendMessage方法
            Clients.All.sendMessage(platform, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":" + message);
            Clients.All.hello();
        }
        public override Task OnConnected()
        {
            Console.WriteLine("已连接");
            return base.OnConnected();
        }
    }
}