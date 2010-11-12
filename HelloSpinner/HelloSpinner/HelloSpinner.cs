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

            SetContentView(Resource.layout.main);

            var spinner = (Spinner) FindViewById(Resource.id.spinner);

            ArrayAdapter adapter = ArrayAdapter.CreateFromResource(this, Resource.array.planets_array,
                                                                   R.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(R.Layout.SimpleSpinnerDropdownItem);

            spinner.ItemSelected += spinner_ItemSelected;

            spinner.Adapter = adapter;
        }

        private void spinner_ItemSelected(object sender, ItemEventArgs e)
        {
            Toast.MakeText(e.View.Context, "The planet is " + ((TextView) e.View).Text, ToastLength.Long).Show();
        }
    }
}