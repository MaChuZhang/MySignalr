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
using Android.Support.V4.App;
using Fragment = Android.Support.V4.App.Fragment;
using FragmentManager = Android.Support.V4.App.FragmentManager;
using Java.Lang;

namespace xamarinAndroidSignalr
{
    public class MainFragmentPagerAdapter:FragmentPagerAdapter
    {
        private const int TabItemCount = 3;
        private ChatFragment chatFragment = null;
        private ContractFragment contractFragment = null;
        private MoreFragment moreFragment = null;
        public MainFragmentPagerAdapter(FragmentManager fm):base(fm)
        {
            chatFragment = new ChatFragment();
            contractFragment = new ContractFragment();
            moreFragment = new MoreFragment();
        }
        public override int Count
        {
            get
            {
                return TabItemCount;
            }
        }

        public override void DestroyItem(View container, int position, Java.Lang.Object objectValue)
        {
            base.DestroyItem(container, position, objectValue);
        }

        public override Fragment GetItem(int position)
        {
            Fragment fragment = null;
            switch (position) {
                case MainActivity.PAGE_CHAT:
                    fragment =chatFragment;
                    break;
                case MainActivity.PAGE_CONTRACT:
                    fragment = contractFragment;
                    break;
                case MainActivity.PAGE_MORE:
                    fragment = moreFragment;
                    break;
            }
            return fragment;
        }
    }
}