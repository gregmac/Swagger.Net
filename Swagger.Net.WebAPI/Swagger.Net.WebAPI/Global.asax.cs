using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Swagger.Net.WebAPI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Configure_Swagger();
        }

        private void Configure_Swagger()
        {
            var config = GlobalConfiguration.Configuration;

            config.Filters.Add(new SwaggerActionFilter());
            config.Services.Replace(typeof(IDocumentationProvider),
                new XmlCommentDocumentationProvider(HttpContext.Current.Server.MapPath("~/App_Data/Docs.XML")));

            // The Web API Configuration Object
            // Remove the XML Formatter
            var xmlFormatter = config.Formatters
              .Where(f =>
              {
                  return f.SupportedMediaTypes.Any(v => v.MediaType == "text/xml");
              })
              .FirstOrDefault();

            if (xmlFormatter != null)
            {
                config.Formatters.Remove(xmlFormatter);
            }
        }
    }
}