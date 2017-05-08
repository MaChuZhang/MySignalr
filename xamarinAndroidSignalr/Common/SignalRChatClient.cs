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
        public event EventHandler<string> OnReceiveEvent; //����һ������server�˵��¼�
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
        //�������ӵķ���
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
        //������Ϣ
        public Task Send(string  message)
        {
            string serverMethod = "sendMsg";
            if (_connection.State != ConnectionState.Connected)
            {
                _connection.Start();
                System.Diagnostics.Debug.WriteLine("δ����");
                return null;
            }
            System.Diagnostics.Debug.WriteLine("������");
            return _proxy.Invoke(serverMethod,message);
        }
    }
}