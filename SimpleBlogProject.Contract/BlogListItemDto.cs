using System;

namespace SimpleBlogProject.Contract
{
    public class BlogListItemDto
    {
        public int BlogId { get; set; }
        public string BlogName { get; set; }
        public string BlogShortDesc { get; set; }
        public DateTime BlogCreatedOnUtc { get; set; }
        public int BlogPostCount { get; set; }
        public int ApprovedCommentCount { get; set; }
    }
}
