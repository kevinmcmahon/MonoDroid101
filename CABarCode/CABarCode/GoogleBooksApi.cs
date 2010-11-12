using System.IO;
using System.Net;

namespace CABarCode
{
    public class GoogleBooksApi
    {
        private readonly string _pageContent;

        public GoogleBooksApi(string upc)
        {
            string url = string.Format("http://ajax.googleapis.com/ajax/services/search/books?v=1.0&q={0}", upc);
            WebRequest request = WebRequest.Create(url);

            using (WebResponse response = request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    _pageContent = reader.ReadToEnd();
                }
            }
        }

        public string GetTitle()
        {
            return HtmlPageScraper.GetTextBetween(_pageContent, "\"titleNoFormatting\":\"", "\",");
        }
    }
}