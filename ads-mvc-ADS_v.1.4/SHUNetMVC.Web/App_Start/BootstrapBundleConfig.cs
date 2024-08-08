using System.Web.Optimization;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(SHUNetMVC.Web.App_Start.BootstrapBundleConfig), "RegisterBundles")]

namespace SHUNetMVC.Web.App_Start
{
	public class BootstrapBundleConfig
    {
		public static void RegisterBundles()
		{
            // Add @Styles.Render("~/Content/fontawesome") in the <head/> of your _Layout.cshtml
            // When <compilation debug="true" />, MVC will render the full readable version. When set to <compilation debug="false" />, the minified version will be rendered automatically
            BundleTable.Bundles.Add(new StyleBundle("~/Content/bootstrap/icon/bundle").Include("~/Content/bootstrap/icon/bootstrap-icons.css", new CssRewriteUrlTransform()));
		}
	}
}