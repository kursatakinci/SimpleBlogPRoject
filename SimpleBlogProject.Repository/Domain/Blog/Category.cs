using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBlogProject.Repository.Domain.Blog
{
    public class Category : BaseCreationDatedEntity
    {
        public string Name { get; set; }

        public virtual ICollection<CategoryToBlogPost> CategoryToBlogPosts { get; set; }
    }
}
