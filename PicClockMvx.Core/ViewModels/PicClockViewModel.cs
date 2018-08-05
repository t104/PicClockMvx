using System;
using System.Threading.Tasks;
using System.Threading;
using MvvmCross.Core.ViewModels;
using PicClockMvx.Core.Models;
using MvvmCross.Platform;
using MvvmCross.Core.Navigation;
using Acr.UserDialogs;

namespace PicClockMvx.Core.ViewModels
{
    public class PicClockViewModel : MvxViewModel
    {
        //Properties that show up in view
        private DateTime time;
        private string imageName;
        public DateTime Time 
        {
            get => time;
            set => SetProperty(ref time, value);
        }
        public string ImageName 
        { 
            get => imageName;
            set => SetProperty(ref imageName, value);
        }

        //Constructor
        public PicClockViewModel()
        {
            Time = DateTime.Now;
            ImageName = "ClockImage/01_saki.png";
        }

        //Clock Task
        CancellationTokenSource source;
        async Task Clock(CancellationToken cancellationToken)
        {
			var timeMinute = DateTime.Now.Minute;
			while(true)
            {
                InvokeOnMainThread(() =>
                {
                    Time = DateTime.Now;
					if(timeMinute != DateTime.Now.Minute)
                    {
                        SetImage();
						timeMinute = DateTime.Now.Minute;
                    }
                });
                await Task.Delay(1000, cancellationToken);
            }
        }

        //Set a random image
        private void SetImage()
        {
            ImageHolder.Current.NewImage();
            ImageHolder.Current.SetImage();
            ProfileHolder.Current.SetProfile();
            ImageName = ImageHolder.Current.Image.ClockImageName;
        }
		public override Task Initialize()
		{
            SetImage();
            return base.Initialize();
		}
		public override void ViewAppearing()
		{
            source = new CancellationTokenSource();
            var clock = Clock(source.Token);
            base.ViewAppearing();
		}

		public override void ViewDisappearing()
		{
            source.Cancel();
            base.ViewDisappearing();
		}

        //Navigation command
        private IMvxCommand profileCommand;
		public IMvxCommand ProfileCommand => profileCommand ??
					(profileCommand = new MvxCommand(() =>
		{
			//if showing yassan
			if (ImageHolder.Current.Index == 12)
			{
				Mvx.Resolve<IMvxNavigationService>()
				   .Navigate<YassanViewModel>();
			}
			else
			{
				Mvx.Resolve<IMvxNavigationService>().Navigate<
			   ProfileViewModel>();
			}
		}));

		//Save command
		private IMvxCommand saveCommand;
        public IMvxCommand SaveCommand
        {
            get => saveCommand ??
            (saveCommand = new MvxCommand(() =>
            {
                var config = new AlertConfig()
                    .SetMessage("アルバムに追加しました")
					.SetAction(() =>
                {
					ImageHolder.Current.Image.IsVisible = true;
					ImageHolder.Current.OverwriteImage();
                });
                Mvx.Resolve<IUserDialogs>().Alert(config);
            }));
        }
	}
}
