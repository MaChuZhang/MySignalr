using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace MySignalr.WebUI.Hubs
{
    [HubName("chatHub")]
    public class ChatHub : Hub
    {
        [HubMethodName("hello")]
        public void Hello()
        {
            Clients.All.hello();
        }
        [HubMethodName("sendMsg")]
        public void SendMsg(string  message)
        {
            Clients.All.sendMessage(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),message);
        }
    }
}