using System.Web;
using System.Web.Mvc;

namespace Swagger.Net.WebApi.AttributeRouting
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}