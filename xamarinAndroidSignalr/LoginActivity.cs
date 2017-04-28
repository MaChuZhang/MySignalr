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
using Android.Support.V7.View;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
namespace xamarinAndroidSignalr
{
    [Activity(Label = "xamarinAndroidSignalr", MainLauncher = false, Icon = "@drawable/icon", Theme = "@style/MyTheme")]
    public class LoginActivity : AppCompatActivity
    {
        private TextView tv_goreg;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LoginActivity);
            tv_goreg = FindViewById<TextView>(Resource.Id.tv_goreg);
            tv_goreg.Click += (s, e) =>
            {
                Intent intent = new Intent(this, typeof(RegisterActivity));
                StartActivity(intent);
            };
            // Create your application here
        }
    }
}