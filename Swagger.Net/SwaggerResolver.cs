using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dispatcher;

namespace Swagger.Net
{
    /// <summary>
    /// Allows the calling Web API project to resolve the SwaggerController which is the entry point for the Swagger spec
    /// </summary>
    public class SwaggerResolver : IAssembliesResolver
    {
        public ICollection<Assembly> GetAssemblies()
        {
            List<Assembly> baseAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            baseAssemblies.Add(Assembly.GetExecutingAssembly());
            return baseAssemblies;
        }
    }
}
