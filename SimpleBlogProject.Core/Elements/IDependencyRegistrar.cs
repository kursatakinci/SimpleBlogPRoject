using Autofac;

namespace SimpleBlogProject.Core.Elements
{
    public interface IDependencyRegistrar
    {
        void Register(ContainerBuilder builder);
    }
}
