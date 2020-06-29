using Microsoft.AspNetCore.Mvc;
using SimpleBlogProject.Core;

namespace SimpleBlogProject.Framework.Controllers
{
    public class BasicWorkContextedApiController : ControllerBase
    {
        protected readonly IWorkContext _workContext;
        public BasicWorkContextedApiController(IWorkContext workContext) : base()
        {
            _workContext = workContext;
        }
    }
}
