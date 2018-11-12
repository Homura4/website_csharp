using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace website.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        public ActionResult GeneralForm()
        {
            return View();
        }
    }
}