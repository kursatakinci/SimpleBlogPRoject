namespace SimpleBlogProject.Repository.Domain.Blog
{
    public class Comment : BaseCreationDatedEntity
    {
        public int BlogPostId { get; set; }
        public string CommenterName { get; set; }
        public string CommenterEmail { get; set; }
        public string CommentBody { get; set; }
        public bool Approved { get; set; }

        public virtual BlogPost BlogPost { get; set; }
    }
}
