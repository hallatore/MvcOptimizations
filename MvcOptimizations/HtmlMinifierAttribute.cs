using System.Web.Mvc;

namespace MvcOptimizations
{
    public class HtmlMinifierAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var response = filterContext.HttpContext.Response;

            if (filterContext.Result is ViewResult)
                response.Filter = new HtmlMinifierFilter(response.Filter);
        }
    }
}