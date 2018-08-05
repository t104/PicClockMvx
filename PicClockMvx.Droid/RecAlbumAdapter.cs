using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace PicClockMvx.Droid
{
    public class RecAlbumAdapter
        : RecyclerView.Adapter
    {
        public List<ImageView> albumSource;
        public RecAlbumAdapter(List<ImageView> source)
        {
            albumSource = source;
        }

        public override int ItemCount { get => albumSource.Count; }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            AlbumViewHolder ah = holder as AlbumViewHolder;
            ah.Image = albumSource[position];
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                                          Inflate(Resource.Layout.album_grid_cell, parent, false);
            AlbumViewHolder ah = new AlbumViewHolder(itemView);
            return ah;
        }
    }
}
