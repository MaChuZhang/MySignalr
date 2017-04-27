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
        /// ͸����״̬����������ͼƬ��������
        /// </summary>
        /// <param name="activity"></param>
        public static void ColorStatusBar(Activity activity,Android.Graphics.Color color)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {   //���͸��״̬����ʹ���ݲ��ٸ���״̬��  
                activity.Window.ClearFlags(WindowManagerFlags.TranslucentStatus);
                activity.Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
                activity.Window.SetStatusBarColor(color);
                //͸�������������ֻ���������������ģ�����С�׵�  
                activity.Window.AddFlags(WindowManagerFlags.TranslucentNavigation);
                activity.Window.SetNavigationBarColor(color);
            }
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat && Build.VERSION.SdkInt <= BuildVersionCodes.Lollipop)
            {
                //״̬��͸��  
                activity.Window.AddFlags(WindowManagerFlags.TranslucentStatus);
                //͸��������  
                activity.Window.AddFlags(WindowManagerFlags.TranslucentNavigation);
            }
        }
        public static void BgStausBar(Activity activity)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
            {
                //״̬��͸��  
                activity.Window.AddFlags(WindowManagerFlags.TranslucentStatus);
                //͸��������  
                activity.Window.AddFlags(WindowManagerFlags.TranslucentNavigation);
            }
        }
    }
}