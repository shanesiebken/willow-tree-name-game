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
using MvvmCross.Binding.Droid.BindingContext;
using WillowTree.NameGame.Core.ViewModels;

namespace WillowTree.NameGame.Droid.Views.Fragments
{
    [Register("willowtree.namegame.droid.views.fragments.NameGameTabFragment")]
    public class NameGameTabFragment : MvxFragment<NameGameViewModel>
    {
        public NameGameTabFragment()
        {
            this.RetainInstance = true;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        { 
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            //Pick the view based on what type of quiz we're playing
            if (!ViewModel.Reverse)
                return this.BindingInflate(Resource.Layout.fragment_name_game, null);
            return this.BindingInflate(Resource.Layout.fragment_reverse_name_game, null);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            ViewModel.Start();
            base.OnViewCreated(view, savedInstanceState);
        }
    }
}