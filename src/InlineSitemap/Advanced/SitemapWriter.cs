using System;
using System.Globalization;
using System.IO;
using System.Xml;

namespace InlineSitemap.Advanced
{
    public class SitemapWriter
    {        
        readonly XmlWriter _xmlWriter;

        public SitemapWriter(TextWriter underline)
        {
            Guard.ArgumentIsNotNull(underline, "underline");
            _xmlWriter = new XmlTextWriter(underline);
        }

        public void WriteSitemp(SitemapUrlSet urlSet)
        {
            WriteStartSitemap();

            foreach (var url in urlSet)
            {
                WriteUrl(url);
            }

            WriteEndSitemap();
        }

        public void WriteStartSitemap()
        {   
            _xmlWriter.WriteStartDocument();
            _xmlWriter.WriteStartElement("urlset");
            _xmlWriter.WriteAttributeString("xmlns", Namespaces.Sitemap);
        }

        public void WriteUrl(SitemapUrl sitemapUrl)
        {
            Guard.ArgumentIsNotNull(sitemapUrl, "sitemapUrl");

            // Empty location is something that should never occurs
            if (!String.IsNullOrWhiteSpace(sitemapUrl.Location))
            {
                _xmlWriter.WriteStartElement("url");
                _xmlWriter.WriteElementString("loc", sitemapUrl.Location);
                

                if (sitemapUrl.LastModified.HasValue)
                {
                    var lastModified = sitemapUrl.LastModified.Value;
                    // Format of the date time should be as defined by http://www.w3.org/TR/NOTE-datetime
                    _xmlWriter.WriteElementString("lastmod", lastModified.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
                }

                if (sitemapUrl.Frequency.HasValue)
                {
                    var changefreq = sitemapUrl.Frequency.Value.ToString().ToLower();
                    _xmlWriter.WriteElementString("changefreq", changefreq);
                }

                if (sitemapUrl.Priority.HasValue)
                {
                    var priority = sitemapUrl.Priority.Value;
                    if (Math.Abs(priority - 0.5) > 0.001)
                    {
                        _xmlWriter.WriteElementString("priority", priority.ToString(CultureInfo.InvariantCulture));
                    }
                    
                }

                _xmlWriter.WriteEndElement();
            }            
        }

        public void WriteEndSitemap()
        {
            _xmlWriter.WriteEndElement();
            _xmlWriter.WriteEndDocument();
        }
    }
}
