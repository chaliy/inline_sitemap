namespace InlineSitemap
{
    /// <summary>
    ///     How frequently the page is likely to change. This value provides general information to search engines and may not correlate exactly to how often they crawl the page.
    /// </summary>
    public enum SitemapChangeFrequency
    {
        Always,
        Hourly,
        Daily,
        Weekly,
        Monthly,
        Yearly,        
        Never
    }
}