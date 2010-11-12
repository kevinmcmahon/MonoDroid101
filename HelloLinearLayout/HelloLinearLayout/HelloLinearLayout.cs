using System;
using Android.App;
using Android.OS;

namespace HelloLinearLayout
{
    [Activity(Label = "Hello LinearLayout", MainLauncher = true)]
    public class HelloLinearLayout : Activity
    {
        public HelloLinearLayout()
        {
        }

        public HelloLinearLayout(IntPtr handle) : base(handle)
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