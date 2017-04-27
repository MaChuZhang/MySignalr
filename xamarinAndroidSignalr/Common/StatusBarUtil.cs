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
    public  class StatusBarUtil
    {
        /// <summary>
        /// 透明化状态栏（适用于图片做背景）
        /// </summary>
        /// <param name="activity"></param>
        public static void ColorStatusBar(Activity activity,Android.Graphics.Color color)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {   //清除透明状态栏，使内容不再覆盖状态栏  
                activity.Window.ClearFlags(WindowManagerFlags.TranslucentStatus);
                activity.Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
                activity.Window.SetStatusBarColor(color);
                //透明导航栏部分手机导航栏不是虚拟的，比如小米的  
                activity.Window.AddFlags(WindowManagerFlags.TranslucentNavigation);
                activity.Window.SetNavigationBarColor(color);
            }
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat && Build.VERSION.SdkInt <= BuildVersionCodes.Lollipop)
            {
                //状态栏透明  
                activity.Window.AddFlags(WindowManagerFlags.TranslucentStatus);
                //透明导航栏  
                activity.Window.AddFlags(WindowManagerFlags.TranslucentNavigation);
            }
        }
        public static void BgStausBar(Activity activity)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
            {
                //状态栏透明  
                activity.Window.AddFlags(WindowManagerFlags.TranslucentStatus);
                //透明导航栏  
                activity.Window.AddFlags(WindowManagerFlags.TranslucentNavigation);
            }
        }
    }
}