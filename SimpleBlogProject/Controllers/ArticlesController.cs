using Microsoft.AspNetCore.Mvc;
using SimpleBlogProject.Framework.Controllers;
using SimpleBlogProject.Service.Blog;
using System.Collections.Generic;
using Autofac;
using System.Linq;

namespace SimpleBlogProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : AuthenticatedApiController
    {
        protected readonly IBlogService _blogService;

        public ArticlesController(IBlogService blogService) : base()
        {
            _blogService = blogService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value 1", "value 2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value 1";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}