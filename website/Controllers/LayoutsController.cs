using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace website.Controllers
{
    public class LayoutsController : Controller
    {
        // 固定边栏
        public ActionResult FixedSidebar()
        {
            return View();
        }

        // 固定页脚
        public ActionResult FixedFooter()
        {
            return View();
        }
    }
}