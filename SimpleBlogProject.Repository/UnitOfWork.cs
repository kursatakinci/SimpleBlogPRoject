using SimpleBlogProject.Repository.Domain.Blog;
using SimpleBlogProject.Repository.Domain.User;

namespace SimpleBlogProject.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private SimpleBlogProjectDbContext _dbContext;
        private BaseRepository<Blog> _blogs;
        private BaseRepository<UserInfo> _userInfos;

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

        public IRepository<UserInfo> UserInfos
        {
            get
            {
                return _userInfos ??
                    (_userInfos = new BaseRepository<UserInfo>(_dbContext));
            }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
