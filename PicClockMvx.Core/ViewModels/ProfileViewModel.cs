using System;
using MvvmCross.Core.ViewModels;
using PicClockMvx.Core.Models;

namespace PicClockMvx.Core.ViewModels
{
    public class ProfileViewModel :MvxViewModel
    {
        //Properties
        private string profileImageName;
        private string name;
        private string birthday;
        private string home;
        private string message;
        public string ProfileImageName
        {
            get => profileImageName;
            set => SetProperty(ref profileImageName, value);

        }
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public string Birthday
        {
            get => birthday;
            set => SetProperty(ref birthday, value);
        }
        public string Home
        {
            get => home;
            set => SetProperty(ref home, value);
        }
        public string Message
        {
            get => message;
            set => SetProperty(ref message, value);
        }
        public ProfileViewModel()
        {
            profileImageName = "";
            name = "";
            birthday = "";
            home = "";
            message = "";
        }
		public override void ViewAppearing()
		{
            System.Diagnostics.Debug.WriteLine("ProfileViewModel Appearing");
            ProfileImageName = ImageHolder.Current.Image.ProfileImageName;
            Name = ProfileHolder.Current.Profile.Name;
            Birthday = ProfileHolder.Current.Profile.Birthday;
            Home = ProfileHolder.Current.Profile.Home;
            Message = ProfileHolder.Current.Profile.Message;
            base.ViewAppearing();
		}
	}
}
