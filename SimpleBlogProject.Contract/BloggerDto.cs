using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBlogProject.Contract
{
    public class BloggerDto
    {
        public int BloggerId { get; set; }
        public string BloggerName { get; set; }
        public string BloggerEmail { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
