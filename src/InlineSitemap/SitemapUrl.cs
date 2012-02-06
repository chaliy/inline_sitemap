using System;

namespace InlineSitemap
{
    public class SitemapUrl
    {
        public string Location { get; set; }
        public DateTime? LastModified { get; set; }
        public SitemapChangeFrequency? Frequency { get; set; }
        public double? Priority { get; set; }
    }
}