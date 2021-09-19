using System.Web;
using System.Web.Optimization;

namespace FullyProject
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //Dashbord Assets Style
            bundles.Add(new StyleBundle("~/assets/css").Include(
                      "~/assets/css-rtl/bootstrap.css",
                      "~/assets/fonts/icomoon.css",
                      "~/assets/fonts/flag-icon-css/css/flag-icon.min.css",
                      "~/assets/vendors/css/extensions/pace.css",
                      "~/assets/css-rtl/bootstrap-extended.css",
                      "~/assets/css-rtl/app.css",
                      "~/assets/css-rtl/colors.css",
                      "~/assets/css-rtl/custom-rtl.css",
                      "~/assets/css-rtl/core/menu/menu-types/vertical-menu.css",
                      "~/assets/css-rtl/core/menu/menu-types/vertical-overlay-menu.css",
                      "~/assets/css-rtl/core/colors/palette-gradient.css"
                      ));


            //Dashbord Assets Script
            bundles.Add(new ScriptBundle("~/assets/js").Include(
                     "~/assets/js/core/libraries/jquery.min.js",
                     "~/assets/vendors/js/ui/tether.min.js",
                     "~/assets/js/core/libraries/bootstrap.min.js",
                     "~/assets/vendors/js/ui/perfect-scrollbar.jquery.min.js",
                     "~/assets/vendors/js/ui/unison.min.js",
                     "~/assets/vendors/js/ui/blockUI.min.js",
                     "~/assets/vendors/js/ui/jquery.matchHeight-min.js",
                     "~/assets/vendors/js/ui/screenfull.min.js",
                     "~/assets/vendors/js/extensions/pace.min.js",
                     "~/assets/vendors/js/charts/chart.min.js",
                     "~/assets/js/core/app-menu.js",
                     "~/assets/js/core/app.js",
                     "~/assets/js/scripts/pages/dashboard-lite.js",
                     "~/assets/js/MyScript.js"));


            //Main Assets Style
            bundles.Add(new StyleBundle("~/mainAssets/css").Include(
                      "~/mainAssets/css/bootstrap.min.css",
                      "~/mainAssets/css/font-awesome.min.css",
                      "~/mainAssets/css/main.css",
                      "~/mainAssets/css/owl.carousel.min.css",
                      "~/mainAssets/css/owl.theme.default.min.css"


                      ));
                           //Main Assets Script
                           bundles.Add(new ScriptBundle("~/mainAssets/js").Include(
                     "~/mainAssets/js/jquery-3.1.1.min.js",
                     "~/mainAssets/js/bootstrap.min.js",
                     "~/mainAssets/js/owl.carousel.min.js",
                     "~/mainAssets/js/main.js"
                    ));
        
    }
    }
}
