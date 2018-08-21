using System.Collections.Generic;
using Nop.Core;
using Nop.Core.Plugins;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;

namespace NopBrasil.Plugin.Widgets.Blog
{
    public class BlogPlugin : BasePlugin, IWidgetPlugin
    {
        private readonly ISettingService _settingService;
        private readonly BlogSettings _blogSettings;
        private readonly IWebHelper _webHelper;

        public BlogPlugin(ISettingService settingService, BlogSettings BlogSettings, IWebHelper webHelper)
        {
            this._settingService = settingService;
            this._blogSettings = BlogSettings;
            this._webHelper = webHelper;
        }

        public IList<string> GetWidgetZones() => new List<string> { _blogSettings.WidgetZone };

        public override string GetConfigurationPageUrl() => _webHelper.GetStoreLocation() + "Admin/WidgetsBlog/Configure";

        public void GetPublicViewComponent(string widgetZone, out string viewComponentName) => viewComponentName = "WidgetsBlog";

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
            _settingService.DeleteSetting<BlogSettings>();

            this.DeletePluginLocaleResource("Plugins.Widgets.Blog.Fields.WidgetZone");
            this.DeletePluginLocaleResource("Plugins.Widgets.Blog.Fields.WidgetZone.Hint");
            this.DeletePluginLocaleResource("Plugins.Widgets.Blog.Fields.QtdBlogPosts");
            this.DeletePluginLocaleResource("Plugins.Widgets.Blog.Fields.QtdBlogPosts.Hint");

            base.Uninstall();
        }
    }
}