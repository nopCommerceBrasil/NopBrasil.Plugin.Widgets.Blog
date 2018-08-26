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
        private readonly ILocalizationService _localizationService;

        public BlogPlugin(ISettingService settingService, BlogSettings BlogSettings, IWebHelper webHelper, ILocalizationService localizationService)
        {
            this._settingService = settingService;
            this._blogSettings = BlogSettings;
            this._webHelper = webHelper;
            this._localizationService = localizationService;
        }

        public IList<string> GetWidgetZones() => new List<string> { _blogSettings.WidgetZone };

        public override string GetConfigurationPageUrl() => _webHelper.GetStoreLocation() + "Admin/WidgetsBlog/Configure";

        public override void Install()
        {
            var settings = new BlogSettings
            {
                QtdBlogPosts = 3,
                WidgetZone = "home_page_before_news"
            };
            _settingService.SaveSetting(settings);

            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.Blog.Fields.WidgetZone", "WidgetZone name");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.Blog.Fields.WidgetZone.Hint", "Enter the WidgetZone name that will display the HTML code.");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.Blog.Fields.QtdBlogPosts", "Number of blog posts");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.Blog.Fields.QtdBlogPosts.Hint", "Enter the number of blog posts that will be displayed in view.");

            base.Install();
        }

        public override void Uninstall()
        {
            _settingService.DeleteSetting<BlogSettings>();

            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.Blog.Fields.WidgetZone");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.Blog.Fields.WidgetZone.Hint");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.Blog.Fields.QtdBlogPosts");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.Blog.Fields.QtdBlogPosts.Hint");

            base.Uninstall();
        }

        public string GetWidgetViewComponentName(string widgetZone) => "WidgetsBlog";
    }
}