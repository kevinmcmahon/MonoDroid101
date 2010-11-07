using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace HelloLinearLayout
{
    [Activity(Label = "Hello LinearLayout", MainLauncher = true)]
    public class HelloLinearLayout : Activity
    {
        int count = 1;

        public HelloLinearLayout(IntPtr handle)
            : base(handle)
        {
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.layout.main);
        }
    }
}