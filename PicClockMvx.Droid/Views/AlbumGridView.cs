
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
using MvvmCross.Binding.Droid.Views;
using PicClockMvx.Core.Models;

namespace PicClockMvx.Droid.Views
{
    [Activity(Label = "AlbumGridView")]
    public class AlbumGridView : MvxActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.AlbumGridView);
        }
    }
}
