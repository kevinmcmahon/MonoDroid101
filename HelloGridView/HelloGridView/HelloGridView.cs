using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace HelloGridView
{
    [Activity(Label = "Hello GridView", MainLauncher = true)]
    public class HelloGridView : Activity
    {
        public HelloGridView()
        {
        }

        public HelloGridView(IntPtr handle)
            : base(handle)
        {
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.main);

            var gridView = (GridView) FindViewById(Resource.Id.gridview);
            gridView.Adapter = new ImageAdapter(this);

            gridView.ItemClick += gridView_ItemClick;
        }

        private void gridView_ItemClick(object sender, ItemEventArgs e)
        {
            Toast.MakeText(e.View.Context, "" + e.Position, ToastLength.Short).Show();
        }
    }
}