using Microsoft.AspNetCore.Mvc;
using SimpleBlogProject.Framework.Controllers;
using SimpleBlogProject.Service.Blog;
using System.Collections.Generic;
using SimpleBlogProject.Contract;
using Newtonsoft.Json;

namespace SimpleBlogProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogsController : AuthenticatedApiController
    {
        protected readonly IBlogService _blogService;

        public BlogsController(IBlogService blogService) : base()
        {
            _blogService = blogService;
        }

        // GET api/blogs
        //blog listesi
        [HttpGet]
        public ActionResult<List<BlogListItemDto>> Get()
        {
            return _blogService.GetBlogList();
        }

        // GET api/blogs/5
        //tek blog
        [HttpGet("{id}")]
        public ActionResult<BlogDto> Get(int id)
        {
            return _blogService.GetBlogInfoById(id);
        }

        // POST api/blogs
        //bir blogun 
        [HttpPost]
        public ActionResult<List<BlogListItemDto>> Search([FromBody] string value)
        {
            return _blogService.GetBlogList();
        }

        // PUT api/blogs/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] string value)
        {
            var blog = _blogService.GetBlogInfoById(id);

            if (blog != null)
            {
                var blogInfo = JsonConvert.DeserializeObject<BlogDto>(value);

                blog.BlogBody = blogInfo.BlogBody;
                blog.BlogId = id;
                blog.BlogName = blogInfo.BlogName;
                blog.BlogShortDesc = blogInfo.BlogShortDesc;

                _blogService.GetBlogList();

                return true;
            }
            else
            {
                return false;
            }
        }

        // DELETE api/blogs/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            var blog = _blogService.GetBlogInfoById(id);

            if (blog != null)
            {
                _blogService.GetBlogList();

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}