using Android.Content;
using Android.Util;

namespace CABarCode
{
    public class BarcodeScanner
    {
        #region Step 4. Create Intent and load up extra params

        public static Intent Scan()
        {
            Log.I("Barcode", "Scan button pressed.");
            var intent = new Intent("com.google.zxing.client.android.SCAN");
            intent.PutExtra("SCAN_MODE", "Product_MODE"); // Product_MODE or QR_CODE_MODE
            return intent;
        }

        #endregion
    }
}