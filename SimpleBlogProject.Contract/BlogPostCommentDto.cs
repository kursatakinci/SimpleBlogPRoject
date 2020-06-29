using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBlogProject.Contract
{
    public class BlogPostCommentDto
    {
        public int CommentId { get; set; }
        public int BlogPostId { get; set; }
        public string CommenterFullName { get; set; }
        public string CommenterEmail { get; set; }
        public string Comment { get; set; }
        public DateTime CommentCreatedOnUtc { get; set; }
        public bool Approved { get; set; }
    }
}
