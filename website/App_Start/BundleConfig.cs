using System.Web;
using System.Web.Optimization;

namespace website
{
    public class BundleConfig
    {
        // 有关捆绑的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region 母版页
            // js
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/module/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/module/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/fastclick").Include(
                        "~/Scripts/module/fastclick.js"));

            bundles.Add(new StyleBundle("~/bundles/nprogress").Include(
                        "~/Scripts/module/nprogress.js"));

            // css
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                        "~/Content/Module/bootstrap/css/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/font-awesome").Include(
                        "~/Content/Module/font-awesome/css/font-awesome.min.css"));

            bundles.Add(new StyleBundle("~/Content/nprogress").Include(
                        "~/Content/Module/nprogress/nprogress.css"));

            //自定义公共css与js
            bundles.Add(new StyleBundle("~/bundles/custom").Include(
                        "~/Scripts/build/custom.js"));

            bundles.Add(new StyleBundle("~/Content/custom").Include(
                        "~/Content/build/css/custom.css"));

            #endregion 母版页

            #region 模块

            // css
            bundles.Add(new StyleBundle("~/Content/animate").Include(
                        "~/Content/Module/animate.css/animate.min.css"));

            #endregion
        }
    }
}
