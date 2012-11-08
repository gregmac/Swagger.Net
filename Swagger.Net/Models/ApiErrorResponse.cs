using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swagger.Net.Models
{
    // https://github.com/wordnik/swagger-core/wiki/errors
    public class ApiErrorResponse
    {
        /// <summary>
        /// HTTP error code
        /// </summary>
        public int code { get; set; }

        public string reason { get; set; }
    }
}
