using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.View;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
namespace xamarinAndroidSignalr
{
    [Activity(Label = "xamarinAndroidSignalr", MainLauncher = true, Icon = "@drawable/icon",Theme ="@style/MyTheme")]
    public class MainActivity : AppCompatActivity
    {
        int count = 1;
        private TextView tv_goreg;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.LoginActivity);

            // Button button = FindViewById<Button>(Resource.Id.MyButton);

            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
            tv_goreg = FindViewById<TextView>(Resource.Id.tv_goreg);
            tv_goreg.Click += (s, e) =>
            {
                Intent intent = new Intent(this,typeof(RegisterActivity));
                StartActivity(intent);
            };
            var Color =Resources.GetColor(Resource.Color.color_primary);
            StatusBarUtil.ColorStatusBar(this,Color);
        }
    }
}

