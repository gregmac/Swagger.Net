using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Linq;
using System.Text.RegularExpressions;
using Swagger.Net.Factories;

namespace Swagger.Net
{
    public class SwaggerController : ApiController
    {
        public SwaggerConfiguration SwaggerConfig { get; set; }


        /// <summary>
        /// Get the resource description of the api for swagger documentation
        /// </summary>
        /// <remarks>It is very convenient to have this information available for generating clients. This is the entry point for the swagger UI
        /// </remarks>
        /// <returns>JSON document representing structure of API</returns>
        public HttpResponseMessage GetResourceList()
        {
            // Arrange
            var config = SwaggerConfig ?? SwaggerConfiguration.Instance;
            var factory = new ResourceListingFactory();

            // Act
            var resourceListing = factory.Create(config);

            // Answer
            return new HttpResponseMessage()
            {
                Content = new ObjectContent<Models.ResourceListing>(resourceListing, ControllerContext.Configuration.Formatters.JsonFormatter)
            };
        }

        /// <summary>
        /// Get the API Declaration for a particular controller
        /// </summary>
        public Models.ApiDeclaration GetApiDeclaration(string id)
        {
            var config = SwaggerConfig ?? SwaggerConfiguration.Instance;
            var httpContext = new HttpContextWrapper(HttpContext.Current);  // TODO: testable way to pass context

            return new Models.ApiDeclaration()
            {
                apiVersion = config.ApiVersion,
                swaggerVersion = config.SwaggerVersion,
                basePath = ResolveServerUrl("~", httpContext),
                apis = from d in config.ApiDescriptions
                       where d.ActionDescriptor.ControllerDescriptor.ControllerName == id
                       group d by d.RelativePath into paths
                       select new Models.Api()
                       {
                           path = paths.Key,
                           operations = from op in paths
                                        select new Models.ApiOperation()
                                        {
                                            nickname = Regex.Replace(op.ID, "[^a-zA-Z0-9]", "_"),
                                            summary = op.Documentation,
                                            httpMethod = op.HttpMethod.Method,
                                        }
                       }
            };
        }

        private static string ResolveServerUrl(string relativeUrl, HttpContextWrapper httpContext)
        {
            return httpContext.Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute(relativeUrl);
        }
    }
}
