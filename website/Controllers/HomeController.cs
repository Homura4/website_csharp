using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website.Common;

namespace website.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// home页
        /// </summary>
        /// <returns>ActionResult.</returns>
        [CustomAuthorize]
        public ActionResult Index()
        {
            return View();
        }

    }
}