using System.Collections.Generic;
using System.Web.Mvc;

namespace UsersAchievements.Helpers
{
    public static class TagExtensions
    {
        public static MvcHtmlString Image<T>(this HtmlHelper<T> html, string src , string alt, IDictionary<string, object> htmlAttributes = null)
        {
            string htmlString;
            if (htmlAttributes == null)
            {
                htmlString = $"<img src=\"{src}\" alt=\"{alt}\">";
            }
            else
            {
                htmlString = $"<img src=\"{src}\" alt=\"{alt}\"";
                foreach (var htmlAttribute in htmlAttributes)
                {
                    htmlString += $" {htmlAttribute.Key}=\"{htmlAttribute.Value}\"";
                }
                htmlString += ">";
            }
            return new MvcHtmlString(htmlString);
        }
    }
}