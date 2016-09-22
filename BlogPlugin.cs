using System.Collections.Generic;
using System.Web.Routing;
using Nop.Core.Plugins;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;

namespace NopBrasil.Plugin.Widgets.Blog
{
    /// <summary>
    /// PLugin
    /// </summary>
    public class BlogPlugin : BasePlugin, IWidgetPlugin
    {
        private readonly ISettingService _settingService;
        private readonly BlogSettings _blogSettings;

        public BlogPlugin(IPictureService pictureService,
            ISettingService settingService, BlogSettings BlogSettings)
        {
            this._settingService = settingService;
            this._blogSettings = BlogSettings;
        }

        public IList<string> GetWidgetZones()
        {
            return new List<string> { _blogSettings.WidgetZone };
        }

        public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "WidgetsBlog";
            routeValues = new RouteValueDictionary { { "Namespaces", "NopBrasil.Plugin.Widgets.Blog.Controllers" }, { "area", null } };
        }

        public void GetDisplayWidgetRoute(string widgetZone, out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "PublicInfo";
            controllerName = "WidgetsBlog";
            routeValues = new RouteValueDictionary
            {
                {"Namespaces", "NopBrasil.Plugin.Widgets.Blog.Controllers"},
                {"area", null},
                {"widgetZone", widgetZone}
            };
        }

        public override void Install()
        {
            var settings = new BlogSettings
            {
                QtdBlogPosts = 3,
                WidgetZone = "home_page_before_news"
            };
            _settingService.SaveSetting(settings);

            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.Blog.Fields.WidgetZone", "WidgetZone name");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.Blog.Fields.WidgetZone.Hint", "Enter the WidgetZone name that will display the HTML code.");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.Blog.Fields.QtdBlogPosts", "Number of blog posts");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.Blog.Fields.QtdBlogPosts.Hint", "Enter the number of blog posts that will be displayed in view.");

            base.Install();
        }

        public override void Uninstall()
        {
            //settings
            _settingService.DeleteSetting<BlogSettings>();

            //locales
            this.DeletePluginLocaleResource("Plugins.Widgets.Blog.Fields.WidgetZone");
            this.DeletePluginLocaleResource("Plugins.Widgets.Blog.Fields.WidgetZone.Hint");
            this.DeletePluginLocaleResource("Plugins.Widgets.Blog.Fields.QtdBlogPosts");
            this.DeletePluginLocaleResource("Plugins.Widgets.Blog.Fields.QtdBlogPosts.Hint");

            base.Uninstall();
        }
    }
}
