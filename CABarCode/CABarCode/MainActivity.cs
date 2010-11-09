using System;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace CABarCode
{
    [Activity(Label = "CA Bar Code", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private EditText upcCode;

        public MainActivity(IntPtr handle)
            : base(handle)
        {
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.layout.main);

            // Get our button from the layout resource,
            // and attach an event to it
            var button = FindViewById<Button>(Resource.id.scan_button);

            button.Click += delegate { StartActivityForResult(BarcodeScanner.Scan(), 0); };

            upcCode = (EditText) FindViewById(Resource.id.upc_code);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == -1)
            {
                upcCode.Text = "scan has been canceled";
                return;
            }

            string upc = data.GetStringExtra("SCAN_RESULT");
            processUpc(upc);
        }

        private void processUpc(String upc)
        {
            try
            {
                var api = new GoogleBooksApi(upc);
                char[] title = api.GetTitle().ToCharArray();
                upcCode.SetText(title,0,title.Length);
            }
            catch (Exception e)
            {
                upcCode.SetText(e.Message.ToCharArray(), 0, e.Message.ToCharArray().Length);
            }
        }
    }
}