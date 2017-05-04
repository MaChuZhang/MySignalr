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

namespace xamarinAndroidSignalr
{
    public  class MessageUtils
    {
        public static void ToastShort(Activity activity,string  message,params  object[] agrs)
        {
            try {
                var s = string.Format(message, agrs);
                activity.RunOnUiThread(() => {
                    Toast.MakeText(activity, s, ToastLength.Short).Show();
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void ToastLong(Activity activity, string message, params object[] agrs)
        {
            try
            {
                var s = string.Format(message, agrs);
                activity.RunOnUiThread(() => {
                    Toast.MakeText(activity, s, ToastLength.Long).Show();
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void ShowProgressDialog(Activity activity,string  title,string  message)
        {
            try
            {
                activity.RunOnUiThread(() =>
                {
                    ProgressDialog.Show(activity, title, message);
                });
            }
            catch(Exception e){
                Console.WriteLine(e.ToString());
            }
        }
    }
}