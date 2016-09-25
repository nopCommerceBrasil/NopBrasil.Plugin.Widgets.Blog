using Autofac;
using Autofac.Core;
using Nop.Core.Caching;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using NopBrasil.Plugin.Widgets.Blog.Controllers;
using NopBrasil.Plugin.Widgets.Blog.Service;

namespace NopBrasil.Plugin.Widgets.Blog.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig nopConfig)
        {
            //we cache presentation models between requests
            builder.RegisterType<WidgetsBlogController>().AsSelf();
            builder.RegisterType<WidgetBlogService>().As<IWidgetBlogService>().WithParameter(ResolvedParameter.ForNamed<ICacheManager>("nop_cache_static")).InstancePerDependency();
        }

        public int Order
        {
            get { return 2; }
        }
    }
}
