using System;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using PicClockMvx.Core.Models;

namespace PicClockMvx.Core.ViewModels
{
	public class YassanViewModel :MvxViewModel
    {
        public YassanViewModel()
        {
        }
		//Properties
		private string profileImageName;
		private string nicname;
		private string birthday;
		private string home;
        
		public string ProfileImageName
		{
			get => profileImageName;
			set => SetProperty(ref profileImageName, value);
		}
		public string Name
		{
			get => nicname;
			set => SetProperty(ref nicname, value);
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
		public MvxObservableCollection<Profile> ProfileSource
		{
			get; private set; 
		}

		public override Task Initialize()
		{
            //add profiles to collection
			ProfileSource = new MvxObservableCollection<Profile>();
			foreach (Profile profile in ProfileHolder.Current.ProfileList)
			{
				if(profile.ID != 12)
				{
					ProfileSource.Add(profile);
				}
			}
			return base.Initialize();
		}
		public override void ViewAppearing()
		{
			ProfileImageName = ImageHolder.Current.Image.ProfileImageName;
            Birthday = ProfileHolder.Current.Profile.Birthday;
            Home = ProfileHolder.Current.Profile.Home;
			Name = ProfileHolder.Current.Profile.Name;
			base.ViewAppearing();
		}
	}
}
