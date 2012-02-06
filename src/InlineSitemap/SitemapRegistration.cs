using System;
using System.Web.Routing;
using InlineSitemap.Advanced;

namespace InlineSitemap
{
    public static class SitemapRegistration
    {
        public static RouteCollection MapSitemap(this RouteCollection @this,
            Func<SitemapUrlSet> factory,
            string url = "sitemap.xml")
        {
            Guard.ArgumentIsNotNull(@this, "@this");
            Guard.ArgumentIsNotNull(factory, "factory");
            Guard.ArgumentIsNotNull(url, "url");
            
            @this.Add("Sitemap", new Route(url, new SitemapRouteHandler(factory)));
            return @this;
        }        
    }
}
