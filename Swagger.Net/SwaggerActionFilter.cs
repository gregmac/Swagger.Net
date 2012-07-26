using System;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Newtonsoft.Json.Linq;

namespace Swagger.Net
{
    public class SwaggerActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var docRequest = actionContext.ControllerContext.RouteData.Values.ContainsKey(SwaggerGen.SWAGGER);

            if (!docRequest)
            {
                base.OnActionExecuting(actionContext);
                return;
            }

            HttpResponseMessage response = new HttpResponseMessage();

            response.Content = new ObjectContent<ResourceListing>(
                getDocs(actionContext),
                actionContext.ControllerContext.Configuration.Formatters.JsonFormatter);

            actionContext.Response = response;
        }

        private ResourceListing getDocs(HttpActionContext actionContext)
        {
            var docProvider = (XmlCommentDocumentationProvider)GlobalConfiguration.Configuration.Services.GetDocumentationProvider();

            ResourceListing r = SwaggerGen.CreateResourceListing(actionContext);

            foreach (var api in GlobalConfiguration.Configuration.Services.GetApiExplorer().ApiDescriptions)
            {
                string apiControllerName = api.ActionDescriptor.ControllerDescriptor.ControllerName;
                if (api.Route.Defaults.ContainsKey(SwaggerGen.SWAGGER) ||
                    !apiControllerName.Equals(actionContext.ControllerContext.ControllerDescriptor.ControllerName) || 
                    apiControllerName.ToUpper().Equals(SwaggerGen.SWAGGER.ToUpper())) continue;

                ResourceApi rApi = SwaggerGen.CreateResourceApi(api);
                r.apis.Add(rApi);

                ResourceApiOperation rApiOperation = SwaggerGen.CreateResourceApiOperation(api, docProvider);
                rApi.operations.Add(rApiOperation);
                
                foreach (var param in api.ParameterDescriptions)
                {
                    ResourceApiOperationParameter parameter = SwaggerGen.CreateResourceApiOperationParameter(api, param, docProvider);
                    rApiOperation.parameters.Add(parameter);
                }
            }
            
            return r;
        }
    }
}
