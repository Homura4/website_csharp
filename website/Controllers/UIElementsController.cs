using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace website.Controllers
{
    public class UIElementsController : Controller
    {
        /// <summary>
        /// 一般元素
        /// </summary>
        /// <returns></returns>
        public ActionResult GeneralElements()
        {
            return View();
        }

        /// <summary>
        /// 媒体库
        /// </summary>
        /// <returns></returns>
        public ActionResult MediaGallery()
        {
            return View();
        }

        /// <summary>
        /// 排版
        /// </summary>
        /// <returns></returns>
        public ActionResult Typography()
        {
            return View();
        }

        /// <summary>
        /// 图标库
        /// </summary>
        /// <returns></returns>
        public ActionResult Icons()
        {
            return View();
        }

        /// <summary>
        /// 符号库
        /// </summary>
        /// <returns></returns>
        public ActionResult Glyphicons()
        {
            return View();
        }

        /// <summary>
        /// 小工具
        /// </summary>
        /// <returns></returns>
        public ActionResult Widgets()
        {
            return View();
        }

        /// <summary>
        /// 发票
        /// </summary>
        /// <returns></returns>
        public ActionResult Invoice()
        {
            return View();
        }

        /// <summary>
        /// 收件箱
        /// </summary>
        /// <returns></returns>
        public ActionResult Inbox()
        {
            return View();
        }

        /// <summary>
        /// 日历
        /// </summary>
        /// <returns></returns>
        public ActionResult Calendar()
        {
            return View();
        }
    }
}