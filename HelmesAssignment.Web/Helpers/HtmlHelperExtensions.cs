using System.Web.Mvc;
using HelmesAssignment.Entities.Models;

namespace HelmesAssignment.Web.Helpers
{
    public static class HtmlHelperExtensions 
    {
        public static MvcHtmlString Alert(this HtmlHelper helper, FlashMessage flashMessage)
        {
            if (flashMessage == null)
            {
                return new MvcHtmlString(string.Empty);
            }
            var messageTypeText = flashMessage.MessageType.ToString().ToLowerInvariant();
            return new MvcHtmlString($@"<div class=""alert alert-{messageTypeText}"" role=""alert"">{flashMessage.Message}</div>");
        }
    }
}