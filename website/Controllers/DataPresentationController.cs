using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace website.Controllers
{
    /// <summary>
    /// 一些有用的图表示例
    /// </summary>
    public class DataPresentationController : Controller
    {
        // 图表1
        public ActionResult Chartjs()
        {
            return View();
        }

        // 图表2
        public ActionResult Chartjs2()
        {
            return View();
        }

        // moris图表
        public ActionResult Morisjs()
        {
            return View();
        }

        // echarts图表
        public ActionResult Echarts()
        {
            return View();
        }

        // 其他图表
        public ActionResult OtherCharts()
        {
            return View();
        }
    }
}