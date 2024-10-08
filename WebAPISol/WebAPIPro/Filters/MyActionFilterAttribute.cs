using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPIPro.Filters
{
    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Any Pre Logic
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // Any Post Logic
            base.OnActionExecuted(context);
        }
    }
}
