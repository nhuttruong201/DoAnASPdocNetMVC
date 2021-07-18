using System.Web;
using System.Web.Optimization;

namespace DO_AN_APS_DOC_NET_MVC
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
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      //"~/Content/bootstrap.css",
                      "~/Content/site.css"));



            // New
            bundles.Add(new StyleBundle("~/Content/kingclothes_css").Include(
                     "~/Content/css/all.css",
                     "~/Content/css/css.css",
                     "~/Content/css/bootstrap.min.css",
                     "~/Content/css/mdb.min.css",
                     "~/Content/css/flickity.css"
                     ));

            bundles.Add(new ScriptBundle("~/bundles/kingclothes_js").Include(
                     "~/Content/js/bootstrap.js",
                     "~/Content/js/bootstrap.min.js",
                     "~/Content/js/creditly.js",
                     "~/Content/js/easing.js",
                     "~/Content/js/easyResponsiveTabs.js",
                     "~/Content/js/flickity.pkgd.js",
                     "~/Content/js/imagezoom.js",
                     "~/Content/js/jquery-2.1.4.min.js",
                     "~/Content/js/jquery-ui.js",
                     "~/Content/js/jquery.flexisel.js",
                     "~/Content/js/jquery.flexslider.js",
                     "~/Content/js/jquery.magnific-popup.js",
                     "~/Content/js/jquery.min.js",
                     "~/Content/js/mdb.min.js",
                     "~/Content/js/minicart.js",
                     "~/Content/js/move-top.js",
                     "~/Content/js/popper.min.js",
                     "~/Content/js/SmoothScroll.min.js"
                     ));

            bundles.Add(new ScriptBundle("~/bundles/product_detail").Include(

                     "~/Content/js/imagezoom.js",
                     "~/Content/js/jquery.flexslider.js"

                      ));
            
        }
    }
}
