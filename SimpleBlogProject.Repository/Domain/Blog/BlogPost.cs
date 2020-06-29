using System;
using System.Collections.Generic;

namespace SimpleBlogProject.Repository.Domain.Blog
{
    public class BlogPost : BaseCreationDatedEntity
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public virtual Blog Blog { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<CategoryToBlogPost> CategoryToBlogPosts { get; set; }

    }
}
