using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.Droid.Views;
using Android.Graphics;
using Android.Views.Animations;
using Android.Animation;
using Android.Graphics.Drawables;
using WillowTree.NameGame.Core.ViewModels;

namespace WillowTree.NameGame.Droid.Controls
{
    //This is a class to allow for a color animation, as well as appropriate sizing of images in android lists
    public class DynamicImageView : MvxImageView
    {
        public DynamicImageView(Context context) : base(context)
        {
        }

        public DynamicImageView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public DynamicImageView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }

        protected DynamicImageView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        //Overriding to avoid some weird cropping behavior in android layouts for resized images
        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            Drawable d = this.Drawable;

            if (d != null)
            {
                // ceil not round - avoid thin vertical gaps along the left/right edges
                int width = MeasureSpec.GetSize(widthMeasureSpec);
                int height = (int)Math.Ceiling(width * (float)d.IntrinsicHeight / d.IntrinsicWidth);
                this.SetMeasuredDimension(width, height);
            }
            else
            {
                base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
            }
        }

        //This is where we handle our image color animation
        public int? TintAnimation
        {
            set
            {
                if (value == -1)
                {
                    SetColorFilter(null);
                    return;
                }
                if (value != null && ColorFilter == null) {
                    //This changes a property via some evaluator (in this case, a color translator)
                    var colorFilterAnimation = ObjectAnimator.OfObject(this, "colorFilter", new ArgbEvaluator(), 0, 0);
                    var redTint = new Color(100, 0, 0, 85);
                    var greenTint = new Color(0, 100, 0, 85);
                    switch (value)
                    {
                        case 0:
                            colorFilterAnimation.SetObjectValues(0, redTint.ToArgb());
                            break;
                        case 1:
                            colorFilterAnimation.SetObjectValues(0, greenTint.ToArgb());
                            System.Diagnostics.Debug.WriteLine("Starting Green Animation");
                            break;

                    }
                    colorFilterAnimation.SetDuration(1000);
                    colorFilterAnimation.Start();
                }
            }
        }
    }
}