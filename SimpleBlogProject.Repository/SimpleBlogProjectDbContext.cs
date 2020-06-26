using Microsoft.EntityFrameworkCore;
using SimpleBlogProject.Repository.Domain.Blog;
using SimpleBlogProject.Repository.Domain.User;

namespace SimpleBlogProject.Repository
{
    public class SimpleBlogProjectDbContext : DbContext
    {
        public SimpleBlogProjectDbContext(DbContextOptions<SimpleBlogProjectDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Blog> Blog { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvention();
        }
    }
}
