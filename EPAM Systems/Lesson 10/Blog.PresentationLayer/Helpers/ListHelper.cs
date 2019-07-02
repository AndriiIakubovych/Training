using System.Collections.Generic;
using System.Web.Mvc;

namespace Blog.PresentationLayer.Helpers
{
    public static class ListHelper
    {
        public static MvcHtmlString CreateList(this HtmlHelper html, List<string> items, object htmlAttributes = null)
        {
            TagBuilder ul = new TagBuilder("ul"), li;
            foreach (string item in items)
            {
                li = new TagBuilder("li");
                li.SetInnerText(item);
                ul.InnerHtml += li.ToString();
            }
            ul.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            return MvcHtmlString.Create(ul.ToString());
        }
    }
}