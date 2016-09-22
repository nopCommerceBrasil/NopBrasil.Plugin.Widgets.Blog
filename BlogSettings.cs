using Nop.Core.Configuration;

namespace NopBrasil.Plugin.Widgets.Blog
{
    public class BlogSettings : ISettings
    {
        public string WidgetZone { get; set; }
        public int QtdBlogPosts { get; set; }
    }
}