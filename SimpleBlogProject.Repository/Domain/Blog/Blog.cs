using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBlogProject.Repository.Domain.Blog
{
    public class Blog : BaseEntity
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Body { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
