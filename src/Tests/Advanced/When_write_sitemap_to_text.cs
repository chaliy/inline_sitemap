using System;
using System.IO;
using System.Xml.Linq;
using FluentAssertions;
using InlineSitemap.Advanced;
using NUnit.Framework;

namespace InlineSitemap.Tests.Advanced
{
    public class When_write_sitemap_to_text
    {
        XDocument _result;

        [SetUp]
        public void Given_few_urls()
        {           
            var text = new StringWriter();
            var writer = new SitemapWriter(text);
            writer.WriteStartSitemap();
            writer.WriteUrl(new SitemapUrl
            {
                Location = "http://kievalt.net",
                LastModified = new DateTime(2012, 12, 12),
                Frequency = SitemapChangeFrequency.Daily,
                Priority = 0.7
            });
            writer.WriteEndSitemap();

            _result = XDocument.Parse(text.ToString());
        }

        [Test]
        public void Should_render_root_element()
        {
            _result.Root.Should().NotBeNull();
        }

        [Test]
        public void Should_render_correct_urlset_root_element()
        {
            var urlSetName = XName.Get("urlset", "http://www.sitemaps.org/schemas/sitemap/0.9");
            _result.Root.Name.Should().Be(urlSetName);
        }

        [Test]
        public void Should_render_url_element()
        {
            var url = _result.Root.SitemapElement("url");            
            url.Should().NotBeNull();
        }

        [Test]
        public void Should_render_url_element_with_location()
        {
            var loc = _result.Root.SitemapElement("url").SitemapElement("loc");
            loc.Should().NotBeNull();
        }

        [Test]
        public void Should_render_url_element_with_correct_location()
        {
            var loc = _result.Root.SitemapElement("url").SitemapElement("loc");
            loc.Value.Should().Be("http://kievalt.net");
        }

        [Test]
        public void Should_render_url_element_with_correct_lastmodified()
        {
            var loc = _result.Root.SitemapElement("url").SitemapElement("lastmod");
            loc.Value.Should().Be("2012-12-12");
        }

        [Test]
        public void Should_render_url_element_with_correct_changefreq()
        {
            var loc = _result.Root.SitemapElement("url").SitemapElement("changefreq");
            loc.Value.Should().Be("daily");
        }

        [Test]
        public void Should_render_url_element_with_correct_priority()
        {
            var loc = _result.Root.SitemapElement("url").SitemapElement("priority");
            loc.Value.Should().Be("0.7");
        }
    }
}
