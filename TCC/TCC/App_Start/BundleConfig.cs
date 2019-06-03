using System.Web;
using System.Web.Optimization;

namespace TCC
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Scripts
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/Plugins/js").Include(
                      "~/Plugins/DataTables/datatables.min.js",
                      "~/Plugins/Swal.js"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                      "~/Scripts/Site.js",
                      "~/Plugins/Chart.bundle.js",
                      "~/Scripts/View/UserPlant/UserPlant.js"));

            //Styles
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/View/Shared/SideBar.css",
                      "~/Content/View/Security/Index.css"));

            bundles.Add(new StyleBundle("~/Plugins/css").Include(
                      "~/Plugins/DataTables/datatables.min.css"));

            
        }
    }
}
