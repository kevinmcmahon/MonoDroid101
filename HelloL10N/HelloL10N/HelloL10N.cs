using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace HelloL10N
{
    [Activity(Label = "Hello, L10N", MainLauncher = true)]
    public class HelloL10N : Activity
    {
        private static AlertDialog alert;

        public HelloL10N(IntPtr handle)
            : base(handle)
        {
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.layout.main);

            var b = FindViewById<Button>(Resource.id.flag_button);
            b.SetBackgroundDrawable(Resources.GetDrawable(Resource.drawable.flag));

            var builder = new AlertDialog.Builder(this);
            builder.SetMessage(Resource.@string.dialog_text)
                .SetCancelable(false)
                .SetTitle(Resource.@string.dialog_title)
                .SetPositiveButton("Done", (o, args) =>  ((Dialog)o).Dismiss()); 

            alert = builder.Create();

            b.Click += (o, args) => alert.Show();
        }
    }
}