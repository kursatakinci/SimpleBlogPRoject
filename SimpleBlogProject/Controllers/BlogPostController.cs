using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimpleBlogProject.Contract;
using SimpleBlogProject.Core;
using SimpleBlogProject.Core.Helper.String;
using SimpleBlogProject.Framework.Controllers;
using SimpleBlogProject.Service.Blog;

namespace SimpleBlogProject.Controllers
{
    [Route("api/blogpost/[action]")]
    [ApiController]
    public class BlogPostController : AuthenticatedApiController
    {
        protected readonly IBlogPostService _blogPostService;
        public BlogPostController(IBlogPostService blogPostService,
            IWorkContext workContext) : base(workContext)
        {
            _blogPostService = blogPostService;
        }

        [HttpGet]
        public ActionResult<List<BlogPostListItemDto>> GetAll()
        {
            return GetAllBlogPosts(0);
        }

        [HttpGet("{blogId}")]
        public ActionResult<List<BlogPostListItemDto>> GetAll(int blogId)
        {
            return GetAllBlogPosts(blogId);
        }

        [NonAction]
        public List<BlogPostListItemDto> GetAllBlogPosts(int blogId)
        {
            return _blogPostService.GetBlogPostList(blogId);
        }

        [HttpGet("{id}")]
        public ActionResult<BlogPostDto> Get(int id)
        {
            return _blogPostService.GetBlogPost(id);
        }

        [HttpPost]
        public ActionResult<List<BlogPostListItemDto>> Search([FromBody] JsonElement jsonValue)
        {
            var value = JsonElementHelper.GetString(jsonValue);
            return _blogPostService.GetBlogPostListBySearchTerm(value);
        }

        [HttpPost]
        public ActionResult<bool> Insert([FromBody] JsonElement jsonValue)
        {
            try
            {
                var value = JsonElementHelper.GetString(jsonValue);
                var blogPostDto = JsonConvert.DeserializeObject<BlogPostDto>(value);
                _blogPostService.InsertBlogPost(blogPostDto);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPut]
        public ActionResult<bool> Put([FromBody] JsonElement jsonValue)
        {
            try
            {
                var value = JsonElementHelper.GetString(jsonValue);

                var blogPost = JsonConvert.DeserializeObject<BlogPostDto>(value);

                _blogPostService.UpdateBlogPost(blogPost);

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
                _blogPostService.DeleteBlogPost(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #region blog post comments
        [HttpPost]
        public ActionResult<bool> InsertComment([FromBody] JsonElement jsonValue)
        {
            try
            {
                var value = JsonElementHelper.GetString(jsonValue);
                var blogPostCommentDto = JsonConvert.DeserializeObject<BlogPostCommentDto>(value);
                _blogPostService.InsertBlogPostComment(blogPostCommentDto);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPut]
        public ActionResult<bool> PutComment([FromBody] JsonElement jsonValue)
        {
            try
            {
                var value = JsonElementHelper.GetString(jsonValue);

                var blogPostComment = JsonConvert.DeserializeObject<BlogPostCommentDto>(value);

                _blogPostService.UpdateBlogPostComment(blogPostComment);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // DELETE api/blogs/delete/5
        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteComment(int id)
        {
            try
            {
                _blogPostService.DeleteBlogPostComment(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
    }
}