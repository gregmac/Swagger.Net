using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swagger.Net.Models
{
    // https://github.com/wordnik/swagger-core/wiki/Api-Declaration
    public class ApiDeclaration
    {
        public string apiVersion { get; set; }
        public string swaggerVersion { get; set; }
        public string basePath { get; set; }
        public IEnumerable<Api> apis { get; set; }
    }
}
