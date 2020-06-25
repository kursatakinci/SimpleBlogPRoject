using Microsoft.AspNetCore.Mvc.Filters;

namespace SimpleBlogProject.Framework.Filters
{
    public class AuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }
    }
}
