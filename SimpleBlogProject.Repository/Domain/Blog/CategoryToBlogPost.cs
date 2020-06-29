using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBlogProject.Repository.Domain.Blog
{
    public class CategoryToBlogPost : BaseEntity
    {
        public int Category_Id { get; set; }
        public int BlogPost_Id { get; set; }


        public virtual Category Category { get; set; }
        public virtual BlogPost BlogPost { get; set; }
    }
}
