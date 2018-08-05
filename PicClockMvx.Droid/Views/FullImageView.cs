
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;
using PicClockMvx.Core.ViewModels;
using PicClockMvx.Core.Models;
using MvvmCross.Platform.Core;
using Android.Support.V4.Content;
using System.IO;

namespace PicClockMvx.Droid.Views
{
	[Activity(Label = "FullImageView")]
	public class FullImageView : MvxActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.FullImageVIew);

			//Binding
			var set = this.CreateBindingSet<FullImageView, FullImageViewModel>();
			set.Bind(this)
			   .For(View => View.MyInteraction)
			   .To(ViewModel => ViewModel.MyInteraction).OneWay();
			set.Apply();
		}

		private IMvxInteraction<ParameterOnSave> myInteraction;
		public IMvxInteraction<ParameterOnSave> MyInteraction
		{
			get => myInteraction;
			set
			{
				if (myInteraction != null)
					myInteraction.Requested -= OnSaveInteractionRequested;

				if (myInteraction != value)
				{
					myInteraction = value;
					myInteraction.Requested += OnSaveInteractionRequested;
				}
			}
		}

		private void OnSaveInteractionRequested(object sender, MvxValueEventArgs<ParameterOnSave> e)
		{
			var imageName = e.Value.ImageName;
			var permission = Android.Manifest.Permission.WriteExternalStorage;
			//need to request permission
            if (ShouldShowRequestPermissionRationale(permission))
            {
                RequestPermissions(new[] { permission }, 0);
            }
			if (ContextCompat.CheckSelfPermission(this, permission) == PermissionChecker.PermissionGranted)
			{
				var file = Android.OS.Environment.GetExternalStoragePublicDirectory(
					Android.OS.Environment.DirectoryDcim);
				var myfile = new Java.IO.File(file, "PicClockImage" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".jpg");
				var assets = Application.Context.Assets;
				try
				{
					using (var stream = assets.Open(imageName))
					using (var fs = new FileStream(myfile.AbsolutePath, FileMode.CreateNew))
					{
						stream.CopyTo(fs);
						e.Value.CallBack(true);
					}
				}
				catch (Exception exception)
				{
					System.Diagnostics.Trace.WriteLine(exception.ToString());
					e.Value.CallBack(false);
					throw;
				}
			}else{
				e.Value.CallBack(false);
			}
            
		}
	}
}