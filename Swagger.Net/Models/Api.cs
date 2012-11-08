using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swagger.Net.Models
{
    // https://github.com/wordnik/swagger-core/wiki/Api-Declaration > APIs
    public class Api
    {
        public string path { get; set; }
        public string description { get; set; }
        public IEnumerable<ApiOperation> operations { get; set; }
    }
}
