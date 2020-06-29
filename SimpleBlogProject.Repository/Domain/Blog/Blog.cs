using SimpleBlogProject.Repository.Domain.User;
using System.Collections.Generic;

namespace SimpleBlogProject.Repository.Domain.Blog
{
    public class Blog : BaseCreationDatedEntity
    {
        public int BloggerId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }

        public virtual Blogger Blogger { get; set; }
        public virtual ICollection<BlogPost> BlogPosts { get; set; }
    }
}
