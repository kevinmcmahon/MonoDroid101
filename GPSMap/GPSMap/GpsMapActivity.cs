using System;
using Android;
using Android.App;
using Android.Content;
using Android.Locations;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using Android.OS;

namespace GPSMap
{
	[Activity(Label = "MD GPS Map", MainLauncher = true)]
	public class GpsMapActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.main);
			
			StartLocationManager();
		}

		private void StartLocationManager()
		{
			LocationManager locationManager = (LocationManager) GetSystemService(LocationService);
			string gps = LocationManager.GpsProvider;
			float minDistance = 10; // meters
			long minTime = 1000 * 30; // milliseconds, 1000 = 1s
			locationManager.RequestLocationUpdates(gps, minTime, minDistance, new GpsLocationListener(this));

		}
		
   // compose Google Maps URL

	private string BuildGoogleMapsUrl(Location location)
	{
		return "http://maps.google.com/maps?q="+ location.Latitude+","+location.Longitude;
	}

   // Open the WebView

	private void OpenWebView(String url)
	{
		WebView webview = (WebView) FindViewById(Resource.Id.web_view);
		webview.Settings.JavaScriptEnabled = true;
		webview.LoadUrl(url);
	}

		public void UpdateLocation(Location location)
		{
			var url = BuildGoogleMapsUrl(location);
			OpenWebView(url);
		}
	}

	public class GpsLocationListener : ILocationListener
	{
		private readonly GpsMapActivity _gpsMapActivity;

		public GpsLocationListener(GpsMapActivity gpsMapActivity)
		{
			_gpsMapActivity = gpsMapActivity;
		}

		public void OnLocationChanged(Location location)
		{
			_gpsMapActivity.UpdateLocation(location);
		}

		public void OnProviderDisabled(string provider)
		{
		}

		public void OnProviderEnabled(string provider)
		{
		}

		public void OnStatusChanged(string provider, int status, Bundle extras)
		{
		}

		public IntPtr Handle { get; private set; }
	}
}

