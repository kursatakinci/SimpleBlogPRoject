using System;

namespace SimpleBlogProject.Repository.Domain
{
    public abstract class BaseCreationDatedEntity : BaseWithIdEntity
    {
        public DateTime CreatedOnUtc { get; set; }
    }
}
