using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MonoContactManager
{
	[Activity (Label = "ContactsAdder")]			
	public class ContactAdder : Activity
	{
		public ContactAdder (IntPtr handle) : base (handle)
		{
		}

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
		}
	}
}

