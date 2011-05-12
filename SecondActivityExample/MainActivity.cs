using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace SecondActivityExample
{
	public static class Constants 
	{
		public static string LOGTAG = "SecondActivityExample";
		public static string INTENT_NAME = "com.example.ACTIVITY2";
	}
	
	[Activity (Label = "Second Activity", MainLauncher = true)]
	public class MainActivity : Activity
	{
		int reqCode = 1;
		
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

		}
	
		public override bool OnKeyDown (Keycode keyCode, KeyEvent e)
		{
			Android.Util.Log.Debug(Constants.LOGTAG, "key pressed!");
			switch(keyCode)
			{
				case Keycode.Num1:
					StartActivity(new Intent(Constants.INTENT_NAME));
					break;
				case Keycode.Num2:
					StartActivityForResult(new Intent(Constants.INTENT_NAME), reqCode);
					break;
				case Keycode.Num3:
					Intent i = new Intent(Constants.INTENT_NAME);
					Bundle extras = new Bundle();
					extras.PutString("Name","Your name here");
					i.PutExtras(extras);
					StartActivityForResult(i,reqCode);
					break;
				default:
					Android.Util.Log.Debug(Constants.LOGTAG," key didn't map to a valid key event");
					break;
			}
			return false;
		}
		
		protected override void OnActivityResult (int requestCode, Result resultCode, Intent data)
		{
			if(requestCode == reqCode && resultCode == Result.Ok)
			{
				Toast.MakeText(this, data.Data.ToString(),ToastLength.Short).Show();
			}
		}
	}
}