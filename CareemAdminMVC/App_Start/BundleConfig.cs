using System.Web;
using System.Web.Optimization;

namespace CareemAdminMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                       "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/vendor/jquery-3.2.1.min.js",
                      "~/Content/vendor/bootstrap-4.1/popper.min.js",
                      "~/Content/vendor/bootstrap-4.1/bootstrap.min.js",
                      "~/Content/vendor/slick/slick.min.js",
                      "~/Content/vendor/wow/wow.min.js",
                      "~/Content/vendor/animsition/animsition.min.js",
                      "~/Content/vendor/bootstrap-progressbar/bootstrap-progressbar.min.js",
                      "~/Content/vendor/counter-up/jquery.waypoints.min.js",
                      "~/Content/vendor/counter-up/jquery.counterup.min.js",
                      "~/Content/vendor/circle-progress/circle-progress.min.js",
                      "~/Content/vendor/perfect-scrollbar/perfect-scrollbar.js",
                      "~/Content/vendor/chartjs/Chart.bundle.min.js",
                      "~/Content/vendor/select2/select2.min.js",
                      "~/Content/js/main.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/vendor/bootstrap-4.1/popper.min.js",
                      "~/Content/bootstrap.css",
                      "~/Content/css/font-face.css",
                      "~/Content/css/theme.css",
                      "~/Content/vendor/perfect-scrollbar/perfect-scrollbar.css",
                      "~/Content/vendor/select2/select2.min.css",
                      "~/Content/vendor/slick/slick.css",
                      "~/Content/vendor/css-hamburgers/hamburgers.min.css",
                      "~/Content/vendor/wow/animate.css",
                      "~/Content/vendor/bootstrap-progressbar/bootstrap-progressbar-3.3.4.min.css",
                      "~/Content/vendor/animsition/animsition.min.css",
                      "~/Content/vendor/bootstrap-4.1/bootstrap.min.css",
                      "~/Content/vendor/mdi-font/css/material-design-iconic-font.min.css",
                      "~/Content/vendor/font-awesome-5/css/fontawesome-all.min.css",
                      "~/Content/vendor/font-awesome-4.7/css/font-awesome.min.css"));

            //login page bundles

            bundles.Add(new ScriptBundle("~/bundles/login/bootstrap").Include(
                      "~/Content/login/vendor/jquery/jquery-3.2.1.min.js",
                      "~/Content/login/vendor/animsition/js/animsition.min.js",
                      "~/Content/login/vendor/bootstrap/js/popper.js",
                      "~/Content/login/vendor/bootstrap/js/bootstrap.min.js",
                      "~/Content/login/vendor/select2/select2.min.js",
                      "~/Content/login/vendor/daterangepicker/moment.min.js",
                      "~/Content/login/vendor/daterangepicker/daterangepicker.js",
                      "~/Content/login/vendor/countdowntime/countdowntime.js",
                      "~/Content/login/js/main.js"
                      ));
            
            bundles.Add(new StyleBundle("~/Content/login/css").Include(
                      "~/Content/login/images/icons/favicon.ico",
                      "~/Content/login/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Content/login/fonts/font-awesome-4.7.0/css/font-awesome.min.css",
                      "~/Content/login/fonts/Linearicons-Free-v1.0.0/icon-font.min.css",
                      "~/Content/login/vendor/animate/animate.css",
                      "~/Content/login/vendor/css-hamburgers/hamburgers.min.css",
                      "~/Content/login/vendor/animsition/css/animsition.min.css",
                      "~/Content/login/vendor/select2/select2.min.css",
                      "~/Content/login/vendor/daterangepicker/daterangepicker.css",
                      "~/Content/login/css/util.css",
                      "~/Content/login/css/main.css"
                      ));
                      
                      
        }
    }
}
