using System.Net;

namespace InlineSitemap.Advanced
{
    public class SearchEnginePing
    {
        static readonly string[] Targets = new string[]
        {
            "http://www.google.com/ping?sitemap={sitemap}",
            "http://www.bing.com/webmaster/ping.aspx?siteMap={sitemap}",
            "http://search.yahooapis.com/SiteExplorerService/V1/updateNotification?appid=YahooDemo&url={sitemap}",
            "http://submissions.ask.com/ping?sitemap={sitemap}"
        };

        public void Ping(string siteMapUrl)
        {
            // TODO Probably should be aync
            var client = new WebClient();
            foreach (var target in Targets)
            {
                var targetUrl = target.Replace("{sitemap}", siteMapUrl);                
                client.DownloadString(targetUrl);
            }
        }
    }
}
