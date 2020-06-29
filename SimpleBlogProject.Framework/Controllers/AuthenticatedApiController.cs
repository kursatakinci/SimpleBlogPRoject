using Microsoft.AspNetCore.Mvc;
using SimpleBlogProject.Core;
using SimpleBlogProject.Framework.Filters;

namespace SimpleBlogProject.Framework.Controllers
{
    [AuthenticationFilter]
    public class AuthenticatedApiController : BasicWorkContextedApiController
    {
        public AuthenticatedApiController(IWorkContext workContext) : base(workContext)
        {

        }
    }
}
