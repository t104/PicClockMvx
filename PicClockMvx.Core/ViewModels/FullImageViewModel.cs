using System;
using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;
using PicClockMvx.Core.Models;
using PicClockMvx.Core.Services;
using MvvmCross.Platform;

namespace PicClockMvx.Core.ViewModels
{
    public class FullImageViewModel :MvxViewModel<Image>
    {
        public FullImageViewModel()
        {
            imageName = "";
        }
		private ParameterOnSave parameterOnSave;
        private string imageName;
        public string ImageName
        {
            get => imageName;
            set => SetProperty(ref imageName, value);
        }
        public override void Prepare(Image parameter)
        {
            ImageName = parameter.ClockImageName;
			parameterOnSave = new ParameterOnSave()
			{
				ImageName = parameter.ClockImageName
			};
        }

		private MvxInteraction<ParameterOnSave> myInteraction = new MvxInteraction<ParameterOnSave>();
		public IMvxInteraction<ParameterOnSave> MyInteraction
		{
			get => myInteraction;
		}

		//Save image command
		private IMvxCommand saveImageCommand;
		public IMvxCommand SaveImageCommand
		{
			get => saveImageCommand ??
			(saveImageCommand = new MvxCommand(() =>
			{
				var config = new ConfirmConfig()
					.SetMessage("画像を保存しますか？")
					.SetAction(result =>
				{
					if (result)
					{
						parameterOnSave.CallBack = isSaved =>
						{
							var configOnSave = new AlertConfig();
							if (isSaved)
							{
								configOnSave.SetMessage("画像を保存しました");
							}
							else
							{
								configOnSave.SetMessage("画像の保存に失敗しました");
							}
							Mvx.Resolve<IUserDialogs>().Alert(configOnSave);
						};
						myInteraction.Raise(parameterOnSave);
					}
				}
							  );
				Mvx.Resolve<IUserDialogs>().Confirm(config);
			}
			                           ));
		}
        

    }
}
