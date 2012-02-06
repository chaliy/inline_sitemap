using System;
using NUnit.Framework;
using FluentAssertions;

namespace InlineSitemap.Tests
{
    public class When_define_url_set
    {
        SitemapUrlSet _urlSet;

        [SetUp]
        public void Given_url_set_and_few_addings()
        {
            _urlSet = new SitemapUrlSet
            {
                // You can add all values
                {"http://kievalt.net", DateTime.UtcNow, SitemapChangeFrequency.Daily, 1 },

                // Or just URL
                "http://kievalt.net/home/calendar/",

                // Or even sitemap itself
                new SitemapUrl
                {
                    Location = "http://kievalt.net/speakers/", 
                    Priority = 0.5
                }
            };
        }

        [Test]
        public void Should_add_all_three_nodes()
        {
            _urlSet.Should().HaveCount(3);
        }
    }
}
