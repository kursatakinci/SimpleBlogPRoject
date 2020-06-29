using Autofac;
using SimpleBlogProject.Core;
using SimpleBlogProject.Core.Caching;
using SimpleBlogProject.Core.Elements;
using SimpleBlogProject.Framework.Filters;
using SimpleBlogProject.Repository;
using SimpleBlogProject.Service.Blog;
using SimpleBlogProject.Service.Blogger;
using SimpleBlogProject.Service.User;

namespace SimpleBlogProject.Framework.Dependencies
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public DependencyRegistrar()
        {

        }

        public void Register(ContainerBuilder builder)
        {
            builder.RegisterType<MemoryCacheManager>().As<ICacheManager>().SingleInstance();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();
            builder.RegisterType<BlogService>().As<IBlogService>().SingleInstance();
            builder.RegisterType<BlogPostService>().As<IBlogPostService>().SingleInstance();
            builder.RegisterType<UserInfoService>().As<IUserInfoService>().SingleInstance();
            builder.RegisterType<BloggerService>().As<IBloggerService>().SingleInstance();
            builder.RegisterType<WorkContext>().As<IWorkContext>().InstancePerLifetimeScope();
        }
    }
}
