using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace RequireJS.Helpers
{
    public static class RequireHelpers
    {
        public static MvcHtmlString RequireJSScript(this UrlHelper url, string requireJs, string relativeUrl)
        {
            var file = url.RequestContext.HttpContext.Server.MapPath(relativeUrl);
            var noExtension = Path.GetFileNameWithoutExtension(file);
            var extension = Path.GetExtension(file);
            var path = Path.GetDirectoryName(relativeUrl).Replace("\\", "/");
            TagBuilder tb = new TagBuilder("script");
            tb.Attributes.Add("src", requireJs);
            tb.Attributes.Add("data-main", path + '/' + GetRegularOrMinified(noExtension, extension));
            return new MvcHtmlString(tb.ToString());
        }

        private static string GetRegularOrMinified(string noExtension, string extension)
        {
#if DEBUG
            return string.Format("{0}{1}", noExtension, extension);
#else
            return string.Format("{0}.min{1}", noExtension, extension);
#endif
        }

        /// <summary>
        /// An Html helper for Require.js
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="core">Location of the common js file.</param>
        /// <param name="module">Location of the main.js file.</param>
        /// <returns></returns>
        public static MvcHtmlString RequireJs(this HtmlHelper helper, string core, string module)
        {
            var require = new StringBuilder();
            string jsLocation = "/public/release/";
#if DEBUG
            jsLocation = "/public/js/";
#endif
            
            if (File.Exists(helper.ViewContext.HttpContext.Server.MapPath(Path.Combine(jsLocation, module + ".js"))))
            {
                require.AppendLine("require( [ \"" + jsLocation + core + "\" ], function() {");
                require.AppendLine("    require( [ \"" + module + "\"] );");
                require.AppendLine("});");
            }

            return new MvcHtmlString(require.ToString());
        }

        public static MvcHtmlString ViewSpecificRequireJS(this HtmlHelper helper)
        {
            var action = helper.ViewContext.RouteData.Values["action"];

            var controller = helper.ViewContext.RouteData.Values["controller"];

            return helper.RequireJs("core.js", string.Format("views/{0}/{1}", controller, action));
        }
    }
}