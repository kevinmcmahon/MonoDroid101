using System;
using Android;
using Android.App;
using Android.OS;
using Android.Widget;

namespace HelloSpinner
{
    [Activity(Label = "Hello Spinner", MainLauncher = true)]
    public class HelloSpinner : Activity
    {
        public HelloSpinner()
        {
        }

        public HelloSpinner(IntPtr handle)
            : base(handle)
        {
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.main);

            var spinner = (Spinner) FindViewById(Resource.Id.spinner);

            ArrayAdapter adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.planets_array,
				Android.Resource.Layout.SimpleSpinnerItem);
                                                                   
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            spinner.ItemSelected += spinner_ItemSelected;

            spinner.Adapter = adapter;
        }

        private void spinner_ItemSelected(object sender, ItemEventArgs e)
        {
            Toast.MakeText(e.View.Context, "The planet is " + ((TextView) e.View).Text, ToastLength.Long).Show();
        }
    }
}