using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimpleBlogProject.Contract;
using SimpleBlogProject.Core;
using SimpleBlogProject.Core.Helper.String;
using SimpleBlogProject.Framework.Controllers;
using SimpleBlogProject.Service.Blogger;

namespace SimpleBlogProject.Controllers
{
    [Route("api/blogger/[action]")]
    [ApiController]
    public class BloggerController : AuthenticatedApiController
    {
        protected readonly IBloggerService _bloggerService;
        public BloggerController(IBloggerService bloggerService,
            IWorkContext workContext) : base(workContext)
        {
            _bloggerService = bloggerService;
        }

        [HttpPost]
        public ActionResult<bool> Insert([FromBody] JsonElement jsonValue)
        {
            try
            {
                var value = JsonElementHelper.GetString(jsonValue);
                var bloggerDto = JsonConvert.DeserializeObject<BloggerDto>(value);
                _bloggerService.InsertBlogger(bloggerDto);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}