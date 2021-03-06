using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform;

using PicClockMvx.Core.Services;
using PicClockMvx.Droid.Services;

namespace PicClockMvx.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
		protected override void InitializePlatformServices()
		{
			base.InitializePlatformServices();

			Mvx.RegisterSingleton<IMyService>(() => new MyService());
		}
	}
}
