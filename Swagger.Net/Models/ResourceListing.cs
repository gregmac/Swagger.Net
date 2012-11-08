using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swagger.Net.Models
{
    // https://github.com/wordnik/swagger-core/wiki/Resource-Listing
    public class ResourceListing
    {
        public string apiVersion { get; set; }
        public string swaggerVersion { get; set; }
        public string basePath { get; set; }
        public IEnumerable<ResourceListingApi> apis { get; set; }


        public class ResourceListingApi
        {
            public string path { get; set; }
            public string description { get; set; }
        }
    }


}
