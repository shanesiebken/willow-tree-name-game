using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WillowTree.NameGame.Core.Models;

namespace WillowTree.NameGame.Core.ViewModels
{
    public partial class ProfileViewModel : MvxViewModel
    {
        public ProfileViewModel(Profile p)
        {
            Profile = p;
            Visible = false;
            TintAnimation = -1;
        }

        public Profile Profile { get; set; }

        //Represents the color filter on the associated view through an integer flag
        private int? _tintAnimation;
        public int? TintAnimation
        {
            get
            {
                return _tintAnimation;
            }
            set
            {
                _tintAnimation = value;
                RaisePropertyChanged(() => TintAnimation);
            }
        }

        //Represents the visibility of "hidden" fields before an item is selected
        private bool _visible;
        public bool Visible
        {
            get
            {
                return _visible;
            }
            set
            {
                _visible = value;
                RaisePropertyChanged(() => Visible);
            }
        }
    }
}
