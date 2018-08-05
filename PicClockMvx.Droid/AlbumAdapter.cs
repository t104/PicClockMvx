using System;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Android.Content;
using Android.Graphics;
using System.IO;
using Android.Content.Res;

namespace PicClockMvx.Droid
{
    public class AlbumAdapter
        : BaseAdapter
    {
        Context context;
        List<string> images;
        public AlbumAdapter(Context c, List<string> i)
        {
            context = c;
            images = i;
        }

        public override int Count
        {
            get => images.Count;
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return 0;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ImageView imageView;
            if (convertView == null)
            {
                // if it's not recycled, initialize some attributes
                imageView = new ImageView(context);
                //imageView.LayoutParameters = new GridView.LayoutParams(100, 100);
                //imageView.SetScaleType(ImageView.ScaleType.CenterCrop);
                //imageView.SetPadding(8, 8, 8, 8);
            }
            else
            {
                imageView = (ImageView)convertView;
            }

            // set image in asset
            Bitmap bitmap;
            AssetManager assets = context.Assets;
            BitmapFactory.Options options = new BitmapFactory.Options();
            options.InSampleSize = 2;
            try
            {
                using (StreamReader sr = new StreamReader(assets.Open(images[position])))
                {
                    bitmap = BitmapFactory.DecodeStream(sr.BaseStream, null, options);
                    imageView.SetImageBitmap(bitmap);
                }
            }
            catch (IOException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            return imageView;
        }

    }
}
