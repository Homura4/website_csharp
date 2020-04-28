using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace website.Controllers
{
    public class TablesController : Controller
    {
        // 静态表
        public ActionResult Tables()
        {
            return View();
        }

        // 动态表
        public ActionResult TablesDynamic()
        {
            return View();
        }
    }
}