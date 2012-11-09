using System;
using System.IO;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Dispatcher;
using System.Web.Routing;
using Swagger.Net;

[assembly: WebActivator.PreApplicationStartMethod(typeof($rootnamespace$.App_Start.SwaggerNet), "PreStart")]
namespace $rootnamespace$.App_Start
{
    public static class SwaggerNet
    {
        public static void PreStart()
        {
            RouteTable.Routes.MapHttpRoute(
                name: "SwaggerResourceList",
                routeTemplate: "apidocs/swagger",
                defaults: new { swagger = true, controller = "Swagger", action = "GetResourceList" }
            );
            RouteTable.Routes.MapHttpRoute(
                name: "SwaggerApiDeclaration",
                routeTemplate: "apidocs/{controllerName}",
                defaults: new { swagger = true, controller = "Swagger", action = "GetApiDeclaration" }
            );

            SwaggerConfiguration.DefaultConfiguration = SwaggerConfiguration.CreateDefaultConfig(GlobalConfiguration.Configuration);
        }
    }
}