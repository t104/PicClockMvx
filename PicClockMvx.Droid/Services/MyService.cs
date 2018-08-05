using System;
using System.Reflection;
using System.IO;
using PicClockMvx.Core.Services;
using PicClockMvx.Droid.Views;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content.Res;
using Android.Support.Compat;
using Android.Support.V4.Content;

namespace PicClockMvx.Droid.Services
{
	public class MyService : IMyService
    {
        public MyService()
        {
        }

		public void SaveImage(string imageName)
		{
			throw new NotImplementedException();
		}
        
	}
}
