using System;
using System.Text;
using System.Web;
using System.Web.Routing;

namespace InlineSitemap.Advanced
{
    public class SitemapRouteHandler : IRouteHandler, IHttpHandler
    {
        readonly Func<SitemapUrlSet> _factory;

        public SitemapRouteHandler(Func<SitemapUrlSet> factory)
        {
            Guard.ArgumentIsNotNull(factory, "factory");
            _factory = factory;
        }

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return this;
        }

        bool IHttpHandler.IsReusable
        {
            get { return false; }
        }

        void IHttpHandler.ProcessRequest(HttpContext context)
        {
            Guard.ArgumentIsNotNull(context, "context");
            var urlSet = _factory();
            var response = context.Response;            

            var writer = new SitemapWriter(response.Output);
            writer.WriteSitemp(urlSet);

            response.ContentType = "application/xml";
            response.ContentEncoding = Encoding.UTF8;
            response.End();
        }
    }    
}
