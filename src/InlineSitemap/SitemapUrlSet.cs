using System;
using System.Collections;
using System.Collections.Generic;

namespace InlineSitemap
{
    public class SitemapUrlSet : IEnumerable<SitemapUrl>
    {
        private readonly IList<SitemapUrl> _urls = new List<SitemapUrl>();
        
        public void Add(params SitemapUrl[] url)
        {
            Guard.ArgumentIsNotNull(url, "url");
            foreach (var sitemapUrl in url)
            {
                _urls.Add(sitemapUrl);   
            }
        }
        
        public void Add(string loc, 
            DateTime? lastMod = null, 
            SitemapChangeFrequency? changeFreq = SitemapChangeFrequency.Always,
            double? priority = 0.5)
        {
            _urls.Add(new SitemapUrl
            {
                Location = loc,
                LastModified = lastMod,
                Frequency = changeFreq,
                Priority = priority
            });
        }

        public IEnumerator<SitemapUrl> GetEnumerator()
        {
            return _urls.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
