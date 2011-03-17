using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace HelloL10N
{
    [Activity(Label = "Hello, L10N", MainLauncher = true)]
    public class HelloL10N : Activity
    {
        private static AlertDialog _alert; // like show dialog

        public HelloL10N()
        {
        }

        public HelloL10N(IntPtr handle)
            : base(handle)
        {
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            #region Step 1. Load your main layout

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.main);

            #endregion

            #region Step 2. Get the button that was declared in xml

            var b = FindViewById<Button>(Resource.Id.flag_button);
            b.SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.flag));

            #endregion

            #region Step 3. Build Alert Dialog

            var builder = new AlertDialog.Builder(this);
            builder.SetMessage(Resource.String.dialog_text)
                .SetCancelable(false)
                .SetTitle(GetString(Resource.String.dialog_title))
                .SetPositiveButton("Done", (o, args) => ((Dialog) o).Dismiss());

            _alert = builder.Create();

            #endregion

            #region Step 4. Wire up button click event to show alert.

            b.Click += (o, args) => _alert.Show();

            #endregion
        }
    }
}