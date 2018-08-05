using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;


namespace PicClockMvx.Droid
{
    public class AlbumViewHolder
        : RecyclerView.ViewHolder
    {
        public ImageView Image { get; set; }
        public AlbumViewHolder(View itemView) : base (itemView)
        {
            Image = itemView.FindViewById<ImageView>(Resource.Id.ImageButton);
        }
    }
}
