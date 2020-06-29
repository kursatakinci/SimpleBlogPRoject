using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBlogProject.Contract
{
    public class BlogPostDto
    {
        public int BlogId { get; set; }
        public int BlogPostId { get; set; }
        public string BlogPostTitle { get; set; }
        public string BlogPostBody { get; set; }
        public DateTime BlogPostCreatedOnUtc { get; set; }
        public List<BlogPostCommentDto> Comments { get; set; }
        public List<string> Categories { get; set; }
    }
}
