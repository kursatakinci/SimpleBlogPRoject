using System;

namespace SimpleBlogProject.Contract
{
    public class BlogDto
    {
        public int BlogId { get; set; }
        public string BlogName { get; set; }
        public string BlogShortDesc { get; set; }
        public DateTime BlogCreatedOnUtc { get; set; }
    }
}
