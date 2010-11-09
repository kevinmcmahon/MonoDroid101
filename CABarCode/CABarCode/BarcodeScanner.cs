using Android.Content;
using Android.Util;

namespace CABarCode
{
	public class BarcodeScanner
	{
		public static Intent Scan()
		{
			Log.I("Barcode", "Scan button pressed.");
			Intent intent = new Intent("com.google.zxing.client.android.SCAN");
			intent.PutExtra("SCAN_MODE", "Product_MODE"); // Product_MODE or QR_CODE_MODE
			return intent;
		}
	}
}