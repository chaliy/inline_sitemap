using System.Web.Mvc;

namespace InlineSitemap.Mvc
{
    public static class SitemapControllerExtensions
    {
        public static SitemapResult Sitemap(this Controller @this, SitemapUrlSet urlSet)
        {
            return new SitemapResult
            {
                UrlSet = urlSet
            };
        }
    }
}
