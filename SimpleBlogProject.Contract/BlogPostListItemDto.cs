using System;
using System.Collections.Generic;

namespace SimpleBlogProject.Contract
{
    public class BlogPostListItemDto
    {
        public int BlogId { get; set; }
        public string BlogName { get; set; }
        public int BlogPostId { get; set; }
        public string BlogPostTitle { get; set; }
        public List<string> BlogPostCategories { get; set; }
        public DateTime BlogPostCreatedOnUtc { get; set; }
        public int ApprovedCommentCount { get; set; }
    }
}
