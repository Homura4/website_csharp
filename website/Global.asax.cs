using Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace website
{
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// 启动执行类
        /// </summary>
        protected void Application_Start()
        {
            // 注册
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // 初始化
            try
            {
                // 检测配置是否配置
                WebConfig.Check();

                // 构造数据库语句
                SqlFactory.BuildCommond();

                // 启动数据中心
                //DataCenterBLL.Start();

            }
            catch (Exception ex)
            {
                // 日志记录
                throw;
            }
        }
    }
}
