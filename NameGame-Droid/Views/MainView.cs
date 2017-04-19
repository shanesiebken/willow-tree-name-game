using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.AppCompat;
using System.Collections.Generic;
using WillowTree.NameGame.Core.ViewModels;
using WillowTree.NameGame.Droid.Views.Fragments;

namespace WillowTree.NameGame.Droid
{
    [Activity(Label = "NameGame", MainLauncher = true, Icon = "@drawable/icon", Theme ="@style/NameGameTheme")]
    public class MainView : MvxCachingFragmentCompatActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.view_main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(false);
            SupportActionBar.Title = "WillowTree Name Game";

            var viewPager = FindViewById<ViewPager>(Resource.Id.game_view_pager);
            //Set up our tabs in a container, they are fragments
            var fragments = new List<MvxCachingFragmentStatePagerAdapter.FragmentInfo>();

            fragments.Add(new MvxCachingFragmentStatePagerAdapter.FragmentInfo("Name Game", typeof(NameGameTabFragment), this.ViewModel.NameGameViewModel));
            fragments.Add(new MvxCachingFragmentStatePagerAdapter.FragmentInfo("Mat* Game", typeof(NameGameTabFragment), this.ViewModel.MatModeViewModel));
            fragments.Add(new MvxCachingFragmentStatePagerAdapter.FragmentInfo("Reverse Name Game", typeof(NameGameTabFragment), this.ViewModel.ReverseNameGameViewModel));
            fragments.Add(new MvxCachingFragmentStatePagerAdapter.FragmentInfo("Stats", typeof(StatsTabFragment), this.ViewModel.StatsViewModel));

            viewPager.Adapter = new MvxCachingFragmentStatePagerAdapter(this, SupportFragmentManager, fragments);

            //Add tabs to layour
            var tabLayout = FindViewById<TabLayout>(Resource.Id.tab_layout);
            tabLayout.SetupWithViewPager(viewPager);
        }
    }
}