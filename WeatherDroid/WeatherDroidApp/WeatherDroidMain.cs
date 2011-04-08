using System;
using System.Threading;
using System.Text;
using Android.App;
using Android.OS;
using Android.Util;
using Android.Widget;
using WeatherDroidApp.www.webservicex.net;

namespace WeatherDroidApp
{
    public static class Constants
    {
        public static string LOGTAG = "WeatherDroidApp";
    }

    [Activity(Label = "WeatherDroidApp", MainLauncher = true)]
    public class WeatherDroidMain : Activity
    {
        private int count = 0;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Android.Util.Log.Verbose(Constants.LOGTAG, "Activity1 onCreate");

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var responseText = FindViewById<TextView>(Resource.Id.response);
            var statusText = FindViewById<TextView>(Resource.Id.status);
            var button = FindViewById<Button>(Resource.Id.MyButton);
            button.Click += (sender, args) =>
                                {
                                    count++;
                                    statusText.Text = string.Format("Requests Issued : {0}", count);
									responseText.Text = "Waiting for data";
									
									Log.Verbose(Constants.LOGTAG,"Calling Weather Web");                                    
                                    ThreadPool.QueueUserWorkItem(delegate
                                                                     {
																		WeatherForecasts forecast = CallWebService();
																		string display = ProcessForecast(forecast);
																		RunOnUiThread(() =>{ responseText.Text = display; });
                                                                     });
                                };
        }

        private WeatherForecasts CallWebService()
        {
			
			WeatherForecasts forecast = null;
			
            try
            {
				// http://www.webservicex.net/WeatherForecast.asmx?WSDL
				var ws = new www.webservicex.net.WeatherForecast("http://www.webservicex.net/WeatherForecast.asmx");
				forecast = ws.GetWeatherByZipCode("60614");
            }
            catch (Exception e)
            {
                Log.Error(Constants.LOGTAG, "Exception Calling WS : {0}\n\n{1}", e.Message, e.InnerException);
            }
			
			if(forecast != null)
			{
				Log.Verbose(Constants.LOGTAG, string.Format("State : {0}", forecast.StateCode));
				Log.Verbose(Constants.LOGTAG, string.Format("Number of Weather Datas : {0}", forecast.Details.Length));
			}
			else
			{
				Log.Error(Constants.LOGTAG, "forecast returned was null");
			}
			
			return forecast;
        }
		
		private string ProcessForecast(WeatherForecasts forecast)
		{
			StringBuilder sb = new StringBuilder();
			foreach(var wd in forecast.Details)
			{
				sb.AppendLine(string.Format("{0} HI: {1} LO:{2}", wd.Day, wd.MaxTemperatureF, wd.MinTemperatureF));
			}
			
            return sb.ToString();
		}
    }
}