using Autofac;
using SimpleBlogProject.Core.Elements;
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
        }
    }
}
