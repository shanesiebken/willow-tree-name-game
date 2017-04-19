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
using MvvmCross.Binding.Droid.Target;
using MvvmCross.Binding.Bindings.Target;
using WillowTree.NameGame.Droid.Controls;
using MvvmCross.Binding;

namespace WillowTree.NameGame.Droid.Bindings
{
    public class DynamicImageViewTintAnimationBinding : MvxTargetBinding
    {
        public DynamicImageViewTintAnimationBinding(DynamicImageView target) : base(target)
        {
        }

        protected DynamicImageView View => Target as DynamicImageView;

        public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;

        public override Type TargetType => typeof(int?);

        public override void SetValue(object value)
        {
            var view = View;
            if (view == null)
                return;

            view.TintAnimation = (int?)value;
        }
    }
}