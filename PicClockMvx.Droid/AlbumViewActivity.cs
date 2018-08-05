
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using PicClockMvx.Core.Models;

namespace PicClockMvx.Droid
{
    [Activity(Label = "AlbumViewActivity")]
    public class AlbumViewActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            var albumSource = new List<ImageView>();
            BitmapFactory.Options ops = new BitmapFactory.Options();
            ops.InSampleSize = 2;
            for (int i = 0; i < ImageHolder.Current.lengthImageJarray; i++)
            {
                ImageHolder.Current.SetImage(i);
                var imageName = ImageHolder.Current.Image.ClockImageName;
                try
                {
                    using (StreamReader sr = new StreamReader(this.Assets.Open(imageName)))
                    {
                        var bitmap = BitmapFactory.DecodeStream(sr.BaseStream, null, ops);
                        var imageView = new ImageView(this);
                        imageView.SetImageBitmap(bitmap);
                        albumSource.Add(imageView);
                    }
                }
                catch (IOException e)
                {
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }
    }
}
