using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Droid.Shared.Presenter;
using MvvmCross.Platform.Droid.Platform;
using WillowTree.NameGame.Core;

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

        /// <summary>
        /// Overriding the default Xamarin view presenter to present fragments
        /// </summary>
        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var mvxFragmentsPresenter = new MvxFragmentsPresenter(AndroidViewAssemblies);
            Mvx.RegisterSingleton<IMvxAndroidViewPresenter>(mvxFragmentsPresenter);

            return mvxFragmentsPresenter;
        }
    }
}