using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace NopBrasil.Plugin.Widgets.Blog.Models
{
    public class ConfigurationModel : BaseNopModel
    {
        public int ActiveStoreScopeConfiguration { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.Blog.Fields.WidgetZone")]
        public string WidgetZone { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.Blog.Fields.QtdBlogPosts")]
        public int QtdBlogPosts { get; set; }
    }
}