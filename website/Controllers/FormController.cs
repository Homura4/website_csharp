using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace website.Controllers
{
    /// <summary>
    /// 控件
    /// </summary>
    public class FormController : Controller
    {
        /// <summary>
        /// 基础控件
        /// </summary>
        /// <returns></returns>
        public ActionResult GeneralForm()
        {
            return View();
        }

        /// <summary>
        /// 高级控件
        /// </summary>
        /// <returns></returns>
        public ActionResult AdvancedComponents()
        {
            return View();
        }

        /// <summary>
        /// 表格验证
        /// </summary>
        /// <returns></returns>
        public ActionResult FormValidation()
        {
            return View();
        }

        /// <summary>
        /// 表单向导
        /// </summary>
        /// <returns></returns>
        public ActionResult FormWizards()
        {
            return View();
        }

        /// <summary>
        /// 表格上传
        /// </summary>
        /// <returns></returns>
        public ActionResult FormUpload()
        {
            return View();
        }

        /// <summary>
        /// 表格按钮
        /// </summary>
        /// <returns></returns>
        public ActionResult FormButtons()
        {
            return View();
        }
    }
}