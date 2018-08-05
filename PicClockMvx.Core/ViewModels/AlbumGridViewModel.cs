using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using MvvmCross.Core.ViewModels;
using PicClockMvx.Core.Models;
using MvvmCross.Platform;
using MvvmCross.Core.Navigation;

namespace PicClockMvx.Core.ViewModels
{
    public class AlbumGridViewModel : MvxViewModel
    {
        public AlbumGridViewModel()
        {

        }
        public MvxObservableCollection<Image> AlbumSource { get; private set; }
        const string notAvailable = "ProfileImage/NotAvailable.jpg";

		public override Task Initialize()
		{
            var isAll = true;
            AlbumSource = new MvxObservableCollection<Image>();
            foreach (Image image in ImageHolder.Current.ImageList)
            {
                //add visible images or NotAvailable.png
                if (image.IsVisible)
                    AlbumSource.Add(image);
                else
                {
                    AlbumSource.Add(new Image()
                    {
                        ClockImageName = notAvailable,
                        ProfileImageName = notAvailable
                    });
                    isAll = false;
                }
            }
            //add bonus images if all images are visible
            if (isAll)
            {
                foreach (Image bonus in ImageHolder.Current.BonusImage)
                {
                    AlbumSource.Add(bonus);
                }
            }
            return base.Initialize();
		}
        //Navigation
        private IMvxCommand fullViewCommand;
        public IMvxCommand FullViewCommand
        {
            get
            {
                return fullViewCommand ?? (fullViewCommand = new MvxCommand<Image>(image =>
                {
                    Mvx.Resolve<IMvxNavigationService>()
                       .Navigate<FullImageViewModel, Image>(image);
                }));
            }
        }
	}
}