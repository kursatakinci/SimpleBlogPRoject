using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBlogProject.Repository.Domain
{
    public abstract class BaseWithIdEntity : BaseEntity
    {
        public int Id { get; set; }
    }
}
