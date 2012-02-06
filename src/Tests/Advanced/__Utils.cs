using System.Xml.Linq;

namespace InlineSitemap.Tests.Advanced
{
    class __Utils
    {

    }

    static class __SitemapXEx
    {
        public static XElement SitemapElement(this XElement @this, string name)
        {
            return @this.Element(XName.Get(name, "http://www.sitemaps.org/schemas/sitemap/0.9"));
        }
    }
}
