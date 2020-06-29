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
        public DbSet<BlogPost> BlogPost { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryToBlogPost>()
                .ToTable("Category_BlogPost_Mapping")
                .HasKey(cbp => new { cbp.Category_Id, cbp.BlogPost_Id });

            modelBuilder.Entity<Blog>()
                .HasMany<BlogPost>(b => b.BlogPosts)
                .WithOne(bp => bp.Blog)
                .HasForeignKey(bp => bp.BlogId);

            modelBuilder.Entity<Blog>()
                .HasOne<Blogger>(b => b.Blogger)
                .WithMany(ui => ui.Blogs)
                .HasForeignKey(b => b.BloggerId);

            modelBuilder.Entity<BlogPost>()
                .HasOne<Blog>(bp => bp.Blog)
                .WithMany(b => b.BlogPosts)
                .HasForeignKey(bp => bp.BlogId);

            modelBuilder.Entity<BlogPost>()
                .HasMany<CategoryToBlogPost>(c => c.CategoryToBlogPosts)
                .WithOne(cbp => cbp.BlogPost)
                .HasForeignKey(cbp => cbp.BlogPost_Id);

            modelBuilder.Entity<CategoryToBlogPost>()
                .HasOne<BlogPost>(cbp => cbp.BlogPost)
                .WithMany(c => c.CategoryToBlogPosts)
                .HasForeignKey(cbp => cbp.BlogPost_Id);

            modelBuilder.Entity<BlogPost>()
                .HasMany<Comment>(c => c.Comments)
                .WithOne(c => c.BlogPost)
                .HasForeignKey(c => c.BlogPostId);

            modelBuilder.Entity<Comment>()
                .HasOne<BlogPost>(c => c.BlogPost)
                .WithMany(bp => bp.Comments)
                .HasForeignKey(c => c.BlogPostId);


            modelBuilder.Entity<Category>()
                .HasMany<CategoryToBlogPost>(c => c.CategoryToBlogPosts)
                .WithOne(cbp => cbp.Category)
                .HasForeignKey(cbp => cbp.Category_Id);

            modelBuilder.Entity<CategoryToBlogPost>()
                .HasOne<Category>(cbp => cbp.Category)
                .WithMany(c => c.CategoryToBlogPosts)
                .HasForeignKey(cbp => cbp.Category_Id);


            modelBuilder.RemovePluralizingTableNameConvention();
        }
    }
}
