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

namespace InfiniteListExample
{
    public class InfiniteListOnScrollListener : Java.Lang.Object, ListView.IOnScrollListener
    {
        readonly InfiniteListAdapter adapter;

        public InfiniteListOnScrollListener() { }

        public InfiniteListOnScrollListener(InfiniteListAdapter adapter)
        {
            this.adapter = adapter;
        }

        public void OnScroll(AbsListView view, int firstVisibleItem, int visibleItemCount, int totalItemCount)
        {
            bool loadMore = firstVisibleItem + visibleItemCount >= totalItemCount && totalItemCount > 0;

            if (loadMore && adapter.Adding == false)
            {
                adapter.AppendMoreData();
                //adapter.NotifyDataSetChanged();
            }
        }

        public void OnScrollStateChanged(AbsListView view, ScrollState scrollState)
        {
        }

    }
}