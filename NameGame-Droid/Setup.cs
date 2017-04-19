using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Droid.Shared.Presenter;
using MvvmCross.Platform.Droid.Platform;
using WillowTree.NameGame.Core;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using MvvmCross.Binding.Bindings.Target.Construction;
using WillowTree.NameGame.Droid.Controls;

namespace WillowTree.NameGame.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext)
            : base(applicationContext)
        {

        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override System.Collections.Generic.IEnumerable<string> ViewNamespaces
        {
            get
            {
                var toReturn = base.ViewNamespaces;
                return toReturn.Concat(new[] { "WillowTree.NameGame.Droid.Controls", "Android.Support.V7.CardView" });
            }
        }

        protected override IEnumerable<Assembly> AndroidViewAssemblies => new List<Assembly>(base.AndroidViewAssemblies)
        {
            typeof(Android.Support.V7.Widget.Toolbar).Assembly,
            typeof(Android.Support.V4.View.ViewPager).Assembly,
            typeof(Android.Support.Design.Widget.TabLayout).Assembly,
            typeof(MvvmCross.Droid.Support.V7.RecyclerView.MvxRecyclerView).Assembly
        };

        /// <summary>
        /// Overriding the default Xamarin view presenter to present fragments
        /// </summary>
        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var mvxFragmentsPresenter = new MvxFragmentsPresenter(AndroidViewAssemblies);
            Mvx.RegisterSingleton<IMvxAndroidViewPresenter>(mvxFragmentsPresenter);

            return mvxFragmentsPresenter;
        }

        /*
        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            registry.RegisterCustomBindingFactory<DynamicImageView>(
                nameof(DynamicImageView.TintAnimation),
                image => new DynamicImageViewTintAnimationBinding(image));

            base.FillTargetFactories(registry);
        }
        */
    }
}