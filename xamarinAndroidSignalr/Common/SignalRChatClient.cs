using System;
using Microsoft.AspNet.SignalR.Client;
using System.Threading.Tasks;
using System.Threading;
using xamarinAndroidSignalr.Common;
namespace xamarinAndroidSignalr.Common
{
    public class SignalRChatClient
    {
        private readonly HubConnection _connection;
        private readonly IHubProxy _proxy;
        public  event EventHandler<string> OnReceiveEvent; //定义一个接收server端的事件
        private Timer _timer;
        //private const string url = "http://" + Constants.Host + "/Home/Chat";
        private const string url = "http://192.168.1.172:99/";
        public SignalRChatClient()
        {
            try
            {
                _connection = new HubConnection(url);
                _proxy = _connection.CreateHubProxy("serverHub");
                System.Diagnostics.Debug.WriteLine(_connection.State);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
        }
        //负责连接的方法
        public   void  Connect()
        {
            try
            {
                 _connection.Start();
                _proxy.On("sendMessage",(string platform,string msg) =>
                {
                    OnReceiveEvent?.Invoke(this, platform+":"+ msg);
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        //发送消息
        public  Task Send(string  platform,string  message)
        {
            try
            {
                string serverMethod = "sendMsg";
                //Thread.Sleep(1000);
                if (_connection.State != ConnectionState.Connected)
                {
                    System.Diagnostics.Debug.WriteLine(_connection.State);
                    return null;
                }
                System.Diagnostics.Debug.WriteLine("已连接");
                return _proxy.Invoke(serverMethod,platform, message);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}