using Autofac;
using SimpleBlogProject.Core.Elements;
using SimpleBlogProject.Repository;
using SimpleBlogProject.Service.Blog;

namespace SimpleBlogProject.Framework.Dependencies
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public DependencyRegistrar()
        {

        }

        public void Register(ContainerBuilder builder)
        {
            builder.RegisterType<BlogService>().As<IBlogService>().SingleInstance();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();
        }
    }
}
