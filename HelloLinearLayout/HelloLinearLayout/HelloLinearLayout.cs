using System;
using Android.App;
using Android.OS;

namespace HelloLinearLayout
{
    [Activity(Label = "Hello LinearLayout", MainLauncher = true)]
    public class HelloLinearLayout : Activity
    {
		protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.main);
        }
    }
}