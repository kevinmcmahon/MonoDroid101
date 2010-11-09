namespace CABarCode
{
    public class HtmlPageScraper
    {
        public static string GetTextBetween(string pageContent, string start, string end)
        {
            int startIndex = pageContent.IndexOf(start);
            string ending = pageContent.Substring(startIndex, pageContent.Length);

            string title = ending.Substring(start.Length, ending.IndexOf(end));
            return title;
        }
    }
}