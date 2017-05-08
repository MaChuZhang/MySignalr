using System;
using Microsoft.AspNet.SignalR.Client;
using System.Threading.Tasks;
using System.Threading;
namespace xamarinAndroidSignalr.Common
{
    public class SignalRChatClient
    {
        private readonly HubConnection _connection;
        private readonly IHubProxy _proxy;
        public event EventHandler<string> OnReceiveEvent; //定义一个接收server端的事件
        private Timer _timer;
        //private const string url = "http://" + Constants.Host + "/Home/Chat";
        private const string url = "http://192.168.1.172:99/Home/Chat";
        public SignalRChatClient()
        {
            try
            {
                _connection = new HubConnection(url);
                _proxy = _connection.CreateHubProxy("serverHub");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
        }
        //负责连接的方法
        public  async Task Connect()
        {
            try
            {
                 await _connection.Start();
                _proxy.On("sendMsg", (string msg) =>
                {
                    OnReceiveEvent?.Invoke(this, msg);
                });

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
        //发送消息
        public Task Send(string  message)
        {
            string serverMethod = "sendMsg";
            if (_connection.State != ConnectionState.Connected)
            {
                _connection.Start();
                System.Diagnostics.Debug.WriteLine("未连接");
                return null;
            }
            System.Diagnostics.Debug.WriteLine("已连接");
            return _proxy.Invoke(serverMethod,message);
        }
    }
}