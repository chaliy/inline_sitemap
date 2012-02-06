using System.Text;
using System.Web;
using System.Web.Mvc;
using InlineSitemap.Advanced;

namespace InlineSitemap.Mvc
{
    public class SitemapResult : ActionResult
    {
        public SitemapUrlSet UrlSet { get; set; }

        public SitemapResult()
        {
            UrlSet = new SitemapUrlSet();
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (UrlSet == null)
            {
                throw new HttpException(404, "Sitemap was not found.");
            }

            var response = context.HttpContext.Response;
            var writer = new SitemapWriter(response.Output);            
            writer.WriteSitemp(UrlSet);

            response.ContentType = "application/xml";
            response.ContentEncoding = Encoding.UTF8;
            response.End();
        }
    }
}
