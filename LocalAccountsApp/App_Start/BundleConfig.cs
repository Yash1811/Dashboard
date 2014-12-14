using System.Web;
using System.Web.Optimization;

namespace LocalAccountsApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/lib/jquery/jquery-2.0.3.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/lib/bootstrap/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                     "~/Scripts/lib/angular/angular.js",
                     "~/Scripts/lib/angular/angular-route.js",
                     "~/Scripts/lib/angular/ui-bootstrap-tpls-0.12.0.min.js",
                     "~/Scripts/lib/angular/angular-local-storage.min.js",
                     "~/Scripts/app/app.js",
                     "~/Scripts/app/controllers.js",
                     "~/Scripts/app/directives.js",
                      "~/Scripts/app/services.js"));

            bundles.Add(new StyleBundle("~/content/css").Include(
                      "~/Content/css/bootstrap/bootstrap.css",
                      "~/Content/css/dashboard/common.css"));           

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}
