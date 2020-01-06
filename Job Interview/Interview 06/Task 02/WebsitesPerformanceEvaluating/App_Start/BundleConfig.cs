using System.Web.Optimization;

namespace WebsitesPerformanceEvaluating
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.css", "~/Content/mdb.css", "~/Content/datatables.css", "~/Content/font-awesome.css", "~/Content/Site.css"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js", "~/Scripts/jquery.unobtrusive-ajax.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery-validate").Include("~/Scripts/jquery.validate.js", "~/Scripts/jquery.validate.unobtrusive.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js", "~/Scripts/mdb.js", "~/Scripts/datatables.js"));
            bundles.Add(new ScriptBundle("~/bundles/custom").Include("~/Scripts/main.js"));
        }
    }
}