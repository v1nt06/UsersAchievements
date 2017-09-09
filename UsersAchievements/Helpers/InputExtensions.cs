using System;
using System.Web.Mvc;

namespace UsersAchievements.Helpers
{
    public static class InputExtensions
    {
        public static MvcHtmlString Submit<T>(this HtmlHelper<T> html, string value = "Submit")
        {
            var htmlString = $"<input type=\"submit\" value=\"{value}\" />";
            return new MvcHtmlString(htmlString);
        }

        public static MvcHtmlString DatePicker<T>(this HtmlHelper<T> html, string name, DateTime? date = null)
        {
            var htmlString = date == null
                ? $"<input type=\"date\" name=\"{name}\" />"
                : $"<input type=\"date\" name=\"{name}\" value=\"{date.Value:yyyy-MM-dd}\" />";
            return new MvcHtmlString(htmlString);
        }

        public static MvcHtmlString FilePicker<T>(this HtmlHelper<T> html, string name = "", string accept = "")
        {
            var htmlString = $"<input type=\"file\" name=\"{name}\" accept=\"{accept}\" />";
            return new MvcHtmlString(htmlString);
        }
    }
}