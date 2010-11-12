using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using Android.Widget;

namespace CABarCode
{
	[Activity(Label = "CA Bar Code", MainLauncher = true)]
	public class MainActivity : Activity
	{
		private EditText _upcCode;

		public MainActivity()
		{
		}

		public MainActivity(IntPtr handle)
			: base(handle)
		{
		}

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			Log.I("MainActivity.OnCreate", "Started CABarCode!!!");

			#region Step 1. Setup UI elements

			// Set our view from the "main" layout resource
			SetContentView(Resource.layout.main);

			// Get our button from the layout resource,
			// and attach an event to it
			var button = FindViewById<Button>(Resource.id.scan_button);
			_upcCode = FindViewById<EditText>(Resource.id.upc_code);

			#endregion

			#region Step 2. Wireup click event

			button.Click += delegate { StartActivityForResult(BarcodeScanner.Scan(), 0); };

			#endregion
		}

		private void ProcessUpc(String upc)
		{
			try
			{
				var api = new GoogleBooksApi(upc);
				char[] title = api.GetTitle().ToCharArray();
				_upcCode.SetText(title, 0, title.Length);
			}
			catch (Exception e)
			{
				Log.E("MainActivity.processUpc",
					  string.Format("Exception thrown Processing UPC. Message : {0}", e.Message));

				_upcCode.SetText(e.Message.ToCharArray(), 0, e.Message.ToCharArray().Length);
			}
		}

		#region Step 5. Ensure you get a response from barcode scanner

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			if (requestCode == -1)
			{
				_upcCode.Text = "scan has been canceled";
				return;
			}

			string upc = data.GetStringExtra("SCAN_RESULT");
			ProcessUpc(upc);
		}

		#endregion
	}
}