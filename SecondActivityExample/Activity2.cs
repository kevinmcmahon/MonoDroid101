using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace SecondActivityExample
{
	[Activity]
	[IntentFilter(new[] {"com.example.ACTIVITY2"}, Categories=new[]{Intent.CategoryDefault})]
	public class Activity2 : Activity
	{
		EditText txt_username;
		Button btn;
		
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView(SecondActivityExample.Resource.Layout.activity2);
        
	        string defaultName = ""; 
	        Bundle extras = this.Intent.Extras;
	        if (extras != null)
	        {
	            defaultName = extras.GetString("Name");        
	        }
			
	        //---get the EditText view--- 
	        txt_username = FindViewById<EditText>(Resource.Id.txt_username);
	        txt_username.Hint = defaultName;
	        
	        //---get the OK button---
	        btn = FindViewById<Button>(Resource.Id.btn_OK);
	        
	        //---event handler for the OK button---
	        btn.Click += delegate {
				Intent data = new Intent();
	
                //---set the data to pass back---
                data.SetData(Android.Net.Uri.Parse(txt_username.Text));
                SetResult(Result.Ok, data);
                
                //---closes the activity---
                this.Finish();
	        };  
		}
	}
}