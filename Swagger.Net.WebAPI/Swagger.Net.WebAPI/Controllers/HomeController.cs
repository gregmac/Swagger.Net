using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Swagger.Net.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// This is my index doc
        /// </summary>
        /// <returns>A view</returns>
        public ActionResult Index()
        {
            //return Redirect("/docs");
            return View();
        }
    }
}
