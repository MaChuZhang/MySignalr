using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.View;
using Android.Support.V7.App;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.Design.Widget;
using ToolBar = Android.Support.V7.Widget.Toolbar;
namespace xamarinAndroidSignalr
{
    [Activity(Label = "xamarinAndroidSignalr", MainLauncher = false, Icon = "@drawable/icon",Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity
    {
        //fragment 页面常量
        internal const int PAGE_CHAT = 0;
        internal const int PAGE_CONTRACT = 1;
        internal const int PAGE_MORE = 2;
        //ui 
        private ViewPager viewPager;
        private TextView tv_chat;
        private TextView tv_more;
        private TextView tv_contract;
        private MainFragmentPagerAdapter mAdapter;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            StatusBarUtil.ColorStatusBar(this,Resources.GetColor(Resource.Color.color_primary));
            mAdapter = new MainFragmentPagerAdapter(SupportFragmentManager);
            bindViews();
        }

        private void bindViews()
        {
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolBar);
            toolbar.SetLogo(Resource.Drawable.Icon);
            toolbar.InflateMenu(Resource.Menu.chatToolMenu);
            SetSupportActionBar(toolbar);
            
            tv_chat = FindViewById<TextView>(Resource.Id.tv_chat);
            tv_contract = FindViewById<TextView>(Resource.Id.tv_contract);
            tv_more = FindViewById<TextView>(Resource.Id.tv_more);


            viewPager = (ViewPager)FindViewById(Resource.Id.viewPager);
            viewPager.Adapter = mAdapter;
            viewPager.CurrentItem = 0;
            tv_chat.Selected = true;
            viewPager.PageScrollStateChanged += PageScrollStateChanged;
            tv_chat.Click += delegate { MenuClick(tv_chat); };
            tv_contract.Click += delegate { MenuClick(tv_contract); };
            tv_more.Click += delegate { MenuClick(tv_more); };
        }
        //menu 单击事件
        private void MenuClick(View  ItemView)
        {
            switch(ItemView.Id)
            {
                case Resource.Id.tv_chat:
                    SetSelected();
                    tv_chat.Selected = true;
                    viewPager.CurrentItem= PAGE_CHAT;
                    break;
                case Resource.Id.tv_contract:
                    SetSelected();
                    tv_contract.Selected = true;
                    viewPager.CurrentItem = PAGE_CONTRACT;
                    break;
                case Resource.Id.tv_more:
                    SetSelected();
                    tv_contract.Selected = true;
                    viewPager.CurrentItem = PAGE_MORE;
                    break;
            }
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.chatToolMenu,menu);
            return true;
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.tool_search:
                    Toast.MakeText(this,"搜索",ToastLength.Short).Show();
                    return true;
                case Resource.Id.tool_addAccount:
                    Toast.MakeText(this, "加好友", ToastLength.Short).Show();
                    return true;
                case Resource.Id.tool_scanCode:
                    Toast.MakeText(this, "扫码", ToastLength.Short).Show();
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
        private void SetSelected()
        {
            tv_chat.Selected = false;
            tv_contract.Selected = false;
            tv_more.Selected = false;
        }
        //viewpager 滑动事件
        private  void PageScrollStateChanged(object s, ViewPager.PageScrollStateChangedEventArgs e)
        {
            if (e.State == 2)
            {
                switch (viewPager.CurrentItem)
                {
                    case PAGE_CHAT:
                        SetSelected();
                        tv_chat.Selected = true;
                        break;
                    case PAGE_CONTRACT:
                        SetSelected();
                        tv_contract.Selected = true;
                        break;
                    case PAGE_MORE:
                        SetSelected();
                        tv_more.Selected = true;
                        break;
                }
            }
        }
    }
    //public  override void OnOageScrollStateChange
}

