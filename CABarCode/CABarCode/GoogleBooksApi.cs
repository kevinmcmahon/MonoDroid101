using System.IO;
using System.Net;

namespace CABarCode
{
	public class GoogleBooksApi
	{
		private readonly string pageContent;

		public GoogleBooksApi(string upc)
		{
			string url = string.Format("http://ajax.googleapis.com/ajax/services/search/books?v=1.0&q={0}", upc);
			WebRequest request = WebRequest.Create(url);

			using (WebResponse response = request.GetResponse())
			{
				using (var reader = new StreamReader(response.GetResponseStream()))
				{
					pageContent = reader.ReadToEnd();
				}
			}
		}

		public string GetTitle()
		{
			//This is BAD implementation, but the fastest for 101 class
			return HtmlPageScraper.GetTextBetween(pageContent, "\"titleNoFormatting\":\"", "\",");
		}
	}
}