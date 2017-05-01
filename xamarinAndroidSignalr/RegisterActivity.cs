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
    [Activity(Label = "xamarinAndroidSignalr", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/MyTheme")]
    public class RegisterActivity : AppCompatActivity
    {
        private TextView tv_gologin;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.RegisterActivity);
            tv_gologin = FindViewById<TextView>(Resource.Id.tv_gologin);
            tv_gologin.Click += (s, e) => {
                Intent intent = new Intent(this,typeof(LoginActivity));
                StartActivity(intent);
            };
            // Create your application here
        }
    }
}