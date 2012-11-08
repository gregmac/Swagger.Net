using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swagger.Net.Models
{
    // https://github.com/wordnik/swagger-core/wiki/Api-Declaration > APIs
    public class ApiOperation
    {
        public string httpMethod { get; set; }
        public string nickname { get; set; }
        public string responseClass { get; set; }
        public IEnumerable<ApiOperationParameter> parameters { get; set; }
        public string summary { get; set; }
        public string notes { get; set; }
        public IEnumerable<ApiErrorResponse> errorResponses { get; set; }
    }
}
