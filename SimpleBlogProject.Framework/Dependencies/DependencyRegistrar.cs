using Autofac;
using Microsoft.Extensions.Caching.Memory;
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
            builder.RegisterType<MemoryCache>().As<IMemoryCache>().SingleInstance();
            builder.RegisterType<MemoryCacheManager>().As<ICacheManager>().SingleInstance();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<BlogService>().As<IBlogService>().InstancePerLifetimeScope();
            builder.RegisterType<BlogPostService>().As<IBlogPostService>().InstancePerLifetimeScope();
            builder.RegisterType<UserInfoService>().As<IUserInfoService>().InstancePerLifetimeScope();
            builder.RegisterType<BloggerService>().As<IBloggerService>().InstancePerLifetimeScope();
            builder.RegisterType<WorkContext>().As<IWorkContext>().InstancePerLifetimeScope();
        }
    }
}
