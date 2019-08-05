using System.Web.Optimization;

namespace MiniChat
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/Site.css"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js", "~/Scripts/jquery.signalR-2.4.1.js"));
            bundles.Add(new ScriptBundle("~/bundles/custom").Include("~/Scripts/main.js"));
        }
    }
}