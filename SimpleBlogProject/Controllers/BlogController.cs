using Microsoft.AspNetCore.Mvc;
using SimpleBlogProject.Framework.Controllers;
using SimpleBlogProject.Service.Blog;
using System.Collections.Generic;
using SimpleBlogProject.Contract;
using Newtonsoft.Json;
using System.Text.Json;
using SimpleBlogProject.Core.Helper.String;
using SimpleBlogProject.Core;
using System;

namespace SimpleBlogProject.Controllers
{
    [Route("api/blog/[action]")]
    [ApiController]
    public class BlogController : AuthenticatedApiController
    {
        protected readonly IBlogService _blogService;

        public BlogController(IBlogService blogService,
            IWorkContext workContext) : base(workContext)
        {
            _blogService = blogService;
        }

        // GET api/blogs/get
        //blog listesi
        [HttpGet]
        public ActionResult<List<BlogListItemDto>> GetAll()
        {
            return _blogService.GetBlogList();
        }

        // GET api/blogs/get/5
        //tek blog
        [HttpGet("{id}")]
        public ActionResult<BlogDto> Get(int id)
        {
            return _blogService.GetBlogInfoById(id);
        }

        // POST api/blog/search
        //bir blogun 
        [HttpPost]
        public ActionResult<List<BlogListItemDto>> Search([FromBody] JsonElement jsonValue)
        {
            var value = JsonElementHelper.GetString(jsonValue);
            return _blogService.GetBlogListBySearchTerm(value);
        }

        // POST api/blog/insert
        //bir blogun 
        [HttpPost]
        public ActionResult<bool> Insert([FromBody] JsonElement jsonValue)
        {
            try
            {
                var value = JsonElementHelper.GetString(jsonValue);
                var blogDto = JsonConvert.DeserializeObject<BlogDto>(value);
                _blogService.InsertBlog(blogDto);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // PUT api/blogs/put/5
        [HttpPut]
        public ActionResult<bool> Put([FromBody] JsonElement jsonValue)
        {
            try
            {
                var value = JsonElementHelper.GetString(jsonValue);

                var blogInfo = JsonConvert.DeserializeObject<BlogDto>(value);

                _blogService.UpdateBlog(blogInfo);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // DELETE api/blogs/delete/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            try
            {
                _blogService.DeleteBlog(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}