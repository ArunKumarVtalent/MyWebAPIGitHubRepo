using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPIPro.Filters
{
    public class MyResultFilterAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            // Any Pre Logic
            base.OnResultExecuting(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            // Any Post Logic
            base.OnResultExecuted(context);
        }
    }
}
