using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swagger.Net.Models
{
    // https://github.com/wordnik/swagger-core/wiki/parameters
    public class ApiOperationParameter
    {
        public string paramType { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string dataType { get; set; }
        public bool required { get; set; }
        public bool allowMultiple { get; set; }
        public AllowableValues allowableValues { get; set; }

        public class AllowableValues
        {
            public int max { get; set; }
            public int min { get; set; }
            public string valueType { get; set; }
        }
    }

}
