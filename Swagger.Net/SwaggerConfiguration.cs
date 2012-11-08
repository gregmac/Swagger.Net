using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;

namespace Swagger.Net
{
    public class SwaggerConfiguration
    {
        /// <summary>
        /// Static instance used by default
        /// </summary>
        public static SwaggerConfiguration DefaultConfiguration { get; set; }

        /// <summary>
        /// The API version of your application
        /// </summary>
        public virtual string ApiVersion { get; set; }

        /// <summary>
        /// Swagger-spec version
        /// </summary>
        public virtual string SwaggerVersion { get; set; }


        public virtual System.Web.Http.Description.IApiExplorer ApiExplorer { get; set; }

        public static SwaggerConfiguration CreateDefaultConfig(HttpConfiguration httpConfig) {
            return new SwaggerConfiguration()
            {
                SwaggerVersion = "1.1",
                ApiVersion = System.Reflection.Assembly.GetCallingAssembly().GetType().Assembly.GetName().Version.ToString(),
                ApiExplorer = httpConfig.Services.GetApiExplorer()
            };
        }

        
    }
}
