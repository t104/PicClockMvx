using System;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using PicClockMvx.Core.Models;
using MvvmCross.Platform;
using MvvmCross.Core.Navigation;
using Acr.UserDialogs;

namespace PicClockMvx.Core.ViewModels
{
    public class MenuViewModel : MvxViewModel
    {
        void HandleAction()
        {
        }


        public override Task Initialize()
        {
            //Initialize profile and image
            ImageHolder.Current.Image = new Image();
            var loadAsync = ImageHolder.Current.LoadAsync();
            ProfileHolder.Current.Profile = new Profile();
            ProfileHolder.Current.Load();
            return base.Initialize();
        }
        //Navigation commands
        private IMvxCommand clockCommand;
        public IMvxCommand ClockCommand
        {
            get
            {
                return clockCommand ?? (clockCommand = new MvxCommand(() =>
                {
                    Mvx.Resolve<IMvxNavigationService>().Navigate<
                       PicClockViewModel>();
                }));
            }
        }
        private IMvxCommand albumCommand;
        public IMvxCommand AlbumCommand
        {
            get
            {
                return albumCommand ?? (albumCommand = new MvxCommand(() =>
                {
                    Mvx.Resolve<IMvxNavigationService>().Navigate<
                       AlbumGridViewModel>();
                }));
            }
        }
        //Initialize command
        private IMvxCommand initializeCommand;
        public IMvxCommand InitializeCommand
        {
            get => initializeCommand ?? (
                initializeCommand = new MvxCommand(() =>
            {
                var config = new ConfirmConfig()
                    .SetMessage("アルバムを初期化してよろしいですか？")
                    .SetAction(result =>
               {
                   if (result)
                   {
                       var initialize = ImageHolder.Current.InitializeAlbum();
                   }
               }
                              );
                Mvx.Resolve<IUserDialogs>().Confirm(config);
            }
                                                  ));
        }
    }
}