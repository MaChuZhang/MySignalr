using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Fragment = Android.Support.V4.App.Fragment;
using xamarinAndroidSignalr.Common;
using System.Threading.Tasks;
namespace xamarinAndroidSignalr
{
    public class ChatFragment : Fragment
    {
        private Button btn_send;
        private EditText et_msg;
        private ListView lv_msg;
        private Context context;
        private SignalRChatClient client;
        public override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
             client = new SignalRChatClient();
            await client.Connect();
            // Create your fragment here
        }
        public ChatFragment(Context  _context)
        {

            //this.Context = context;
            context =_context;
        }

        public    override  View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Layout.Fragment_Chat,container,false);
            btn_send = view.FindViewById<Button>(Resource.Id.btn_send);
            et_msg =  view.FindViewById<EditText>(Resource.Id.et_msg);
            ListView lv_msg = view.FindViewById<ListView>(Resource.Id.lv_msg);
           
            var adapter = new ArrayAdapter(context, Android.Resource.Layout.SimpleListItem1);
            string msg = et_msg.Text;
            //发送消息
            btn_send.Click += delegate
            {
                client.Send(msg);
                et_msg.Text = string.Empty;
            };
            lv_msg.Adapter = adapter;
            //使用委托接受消息
            client.OnReceiveEvent += (sender, message) => Activity.RunOnUiThread(() =>
            {
                adapter.Add(message);
            });
            return   view;
        }
    }
}