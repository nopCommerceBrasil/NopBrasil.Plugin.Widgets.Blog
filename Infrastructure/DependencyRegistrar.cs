using Autofac;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using NopBrasil.Plugin.Widgets.Blog.Service;

namespace NopBrasil.Plugin.Widgets.Blog.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig nopConfig)
        {
            builder.RegisterType<WidgetBlogService>().As<IWidgetBlogService>().InstancePerDependency();
        }

        public int Order => 2;
    }
}
