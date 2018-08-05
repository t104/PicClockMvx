using MvvmCross.Platform.IoC;
using MvvmCross.Platform;

namespace PicClockMvx.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            Mvx.RegisterSingleton<Acr.UserDialogs.IUserDialogs>(
                () => Acr.UserDialogs.UserDialogs.Instance);
            
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterNavigationServiceAppStart<ViewModels.MenuViewModel>();
        }
    }
}
