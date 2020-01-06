using System;
using System.Web.Mvc;

namespace WebsitesPerformanceEvaluating.Helpers
{
    public static class ActiveMenuHelper
    {
        public static MvcHtmlString MenuLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName)
        {
            var currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
            var currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");
            var builder = new TagBuilder("li") { InnerHtml = "<a href=\"" + new UrlHelper(htmlHelper.ViewContext.RequestContext).Action(actionName, controllerName).ToString() + "\">" + linkText + "</a><div class=\"item-line\"></div>" };
            if (string.Equals(controllerName, currentController, StringComparison.CurrentCultureIgnoreCase) && string.Equals(actionName, currentAction, StringComparison.CurrentCultureIgnoreCase))
                builder.AddCssClass("active");
            return new MvcHtmlString(builder.ToString());
        }
    }
}