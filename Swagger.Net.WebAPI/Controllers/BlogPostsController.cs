﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Swagger.Net.WebApi.Controllers
{
    /// <summary>
    /// This is blog posts controller summary
    /// </summary>
    /// <remarks>
    /// This is blog posts controller remarks
    /// </remarks>
    public class BlogPostsController : ApiController
    {
        // GET api/blogposts
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/blogposts/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/blogposts
        public void Post([FromBody]string value)
        {
        }

        // PUT api/blogposts/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/blogposts/5
        public void Delete(int id)
        {
        }
    }
}
