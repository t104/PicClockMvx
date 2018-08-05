
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

using MvvmCross.Droid.Views;
using MvvmCross.Binding.Droid;
using MvvmCross.Plugins.Messenger;
using PicClockMvx.Core.Models;
using MvvmCross.Platform;
using Android.Support.V4.Content;

namespace PicClockMvx.Droid.Views
{
    [Activity(Label = "View for MenuViewModel")]
    public class MenuView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            SetContentView(Resource.Layout.MenuView);

            //Initialize Acr.Userdialog
            Acr.UserDialogs.UserDialogs.Init(this);
        }
    }
}
