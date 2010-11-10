using System;

namespace CABarCode
{
    public class HtmlPageScraper
    {
        public static string GetTextBetween(string pageContent, string start, string end)
        {
            if (string.IsNullOrEmpty(pageContent))
                throw new ArgumentException("Page content empty.", "pageContent");
            if (string.IsNullOrEmpty(start))
                throw new ArgumentException("start null or empty.", "start");
            if (string.IsNullOrEmpty(end))
                throw new ArgumentException("end null or empty.", "end");

            int startIndex = pageContent.IndexOf(start);
            string ending = pageContent.Substring(startIndex);
            int strLength = ending.IndexOf(end) - start.Length;
            return ending.Substring(start.Length, strLength);
        }
    }
}