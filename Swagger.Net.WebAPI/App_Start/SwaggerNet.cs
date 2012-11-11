using System;
using System.IO;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Dispatcher;
using System.Web.Routing;
using Swagger.Net;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Swagger.Net.WebApi.App_Start.SwaggerNet), "PreStart")]
namespace Swagger.Net.WebApi.App_Start
{
    public static class SwaggerNet
    {
        public static void PreStart()
        {
            //RouteTable.Routes.MapHttpRoute(
            //    name: "SwaggerResourceList",
            //    routeTemplate: "api/swagger",
            //    defaults: new { swagger = true, controller = "Swagger", action = "GetResourceList" }
            //);
            //RouteTable.Routes.MapHttpRoute(
            //    name: "SwaggerApiDeclaration",
            //    routeTemplate: "apidocs/{controllerName}",
            //    defaults: new { swagger = true, controller = "Swagger", action = "GetApiDeclaration" }
            //);

        }
    }
}