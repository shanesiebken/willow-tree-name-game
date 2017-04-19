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
using MvvmCross.Droid.Support.V4;
using WillowTree.NameGame.Core.ViewModels;
using MvvmCross.Binding.Droid.BindingContext;

namespace WillowTree.NameGame.Droid.Views.Fragments
{
    [Register("willowtree.namegame.droid.views.fragments.StatsTabFragment")]
    public class StatsTabFragment : MvxFragment<StatsViewModel>
    {
        public StatsTabFragment()
        {
            this.RetainInstance = true;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.fragment_stats, null);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            ViewModel.Start();
            base.OnViewCreated(view, savedInstanceState);
        }
    }
}