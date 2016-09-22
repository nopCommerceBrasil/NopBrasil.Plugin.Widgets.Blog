using System.Web.Mvc;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc;

namespace NopBrasil.Plugin.Widgets.Blog.Models
{
    public class ConfigurationModel : BaseNopModel
    {
        public int ActiveStoreScopeConfiguration { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.Blog.Fields.WidgetZone")]
        [AllowHtml]
        public string WidgetZone { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.Blog.Fields.QtdBlogPosts")]
        [AllowHtml]
        public int QtdBlogPosts { get; set; }
    }
}