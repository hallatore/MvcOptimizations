using System.Web.Mvc;

namespace MvcOptimizations
{
    public class HtmlMinifierAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var response = filterContext.HttpContext.Response;

            if (response.ContentType == "text/html")
                response.Filter = new HtmlMinifierFilter(response.Filter);
        }
    }
}