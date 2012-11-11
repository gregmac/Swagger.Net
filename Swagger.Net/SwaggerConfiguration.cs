using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace Swagger.Net
{

    public class SwaggerConfiguration
    {
        private static SwaggerConfiguration _instance;

        private HttpContext _context;
        private Collection<ApiDescription> _apiDescriptions;
        
        public virtual string ApiVersion { get; set; }
        public virtual string SwaggerVersion { get; set; }
        public virtual string DocumentControllerAlias { get; set; }


        public Collection<ApiDescription> ApiDescriptions
        {
            get { return _apiDescriptions ?? GlobalConfiguration.Configuration.Services.GetApiExplorer().ApiDescriptions; }
            set { _apiDescriptions = value; }
        }

        public HttpContext HttpContext
        {
            get { return _context ?? HttpContext.Current; }
            set { _context = value; }
        }

        // Singleton
        public static SwaggerConfiguration Instance
        {
            get { return _instance ?? (_instance = CreateDefaultInstance()); }
            set { _instance = value; }
        }


        public static SwaggerConfiguration CreateDefaultInstance()
        {
            // todo: fetch from web.config
            var alias = ConfigurationManager.AppSettings["document_controller_alias"] ?? "api";
            return new SwaggerConfiguration()
            {
                SwaggerVersion = "1.1",
                ApiVersion = System.Reflection.Assembly.GetCallingAssembly().GetName().Version.ToString(),
                DocumentControllerAlias = alias,
            };
        }

    }
}
