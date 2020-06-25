using Microsoft.AspNetCore.Mvc;
using SimpleBlogProject.Framework.Controllers;
using SimpleBlogProject.Service.Blog;
using System.Collections.Generic;
using SimpleBlogProject.Contract;

namespace SimpleBlogProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : AuthenticatedApiController
    {
        protected readonly IBlogService _blogService;

        public BlogsController(IBlogService blogService) : base()
        {
            _blogService = blogService;
        }

        // GET api/blogs
        [HttpGet]
        public ActionResult<List<BlogListItemDto>> Get()
        {
            return _blogService.GetBlogList();
        }

        // GET api/blogs/5
        [HttpGet("{id}")]
        public ActionResult<BlogDto> Get(int id)
        {
            return _blogService.GetBlogInfoById(id);
        }

        // POST api/blogs
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/blogs/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/blogs/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}