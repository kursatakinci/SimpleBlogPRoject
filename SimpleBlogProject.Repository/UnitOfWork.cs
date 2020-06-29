using SimpleBlogProject.Repository.Domain.Blog;
using SimpleBlogProject.Repository.Domain.User;

namespace SimpleBlogProject.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private SimpleBlogProjectDbContext _dbContext;
        private BaseRepository<Blog> _blogs;
        private BaseRepository<BlogPost> _blogPosts;
        private BaseRepository<CategoryToBlogPost> _categoryToBlogPosts;
        private BaseRepository<Category> _categories;
        private BaseRepository<Comment> _comments;
        private BaseRepository<UserInfo> _userInfos;
        private BaseRepository<Blogger> _bloggers;

        public UnitOfWork(SimpleBlogProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<Blog> Blogs
        {
            get
            {
                return _blogs ??
                    (_blogs = new BaseRepository<Blog>(_dbContext));
            }
        }

        public IRepository<BlogPost> BlogPosts
        {
            get
            {
                return _blogPosts ??
                    (_blogPosts = new BaseRepository<BlogPost>(_dbContext));
            }
        }

        public IRepository<CategoryToBlogPost> CategoryToBlogPosts
        {
            get
            {
                return _categoryToBlogPosts ??
                    (_categoryToBlogPosts = new BaseRepository<CategoryToBlogPost>(_dbContext));
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                return _categories ??
                    (_categories = new BaseRepository<Category>(_dbContext));
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                return _comments ??
                    (_comments = new BaseRepository<Comment>(_dbContext));
            }
        }

        public IRepository<UserInfo> UserInfos
        {
            get
            {
                return _userInfos ??
                    (_userInfos = new BaseRepository<UserInfo>(_dbContext));
            }
        }

        public IRepository<Blogger> Bloggers
        {
            get
            {
                return _bloggers ??
                    (_bloggers = new BaseRepository<Blogger>(_bloggers));
            }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
