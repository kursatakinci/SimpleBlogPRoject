using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBlogProject.Repository.Domain.Blog
{
    public class Blogger : BaseCreationDatedEntity
    {
        public string BloggerName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
