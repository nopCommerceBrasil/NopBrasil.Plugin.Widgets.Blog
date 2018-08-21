using NopBrasil.Plugin.Widgets.Blog.Models;
using Nop.Services.Configuration;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework;
using Microsoft.AspNetCore.Mvc;
using Nop.Services.Localization;

namespace NopBrasil.Plugin.Widgets.Blog.Controllers
{
    [Area(AreaNames.Admin)]
    public class WidgetsBlogController : BasePluginController
    {
        private readonly ISettingService _settingService;
        private readonly ILocalizationService _localizationService;
        private readonly BlogSettings _BlogSettings;

        public WidgetsBlogController(ISettingService settingService, ILocalizationService localizationService,
            BlogSettings BlogSettings)
        {
            this._settingService = settingService;
            this._localizationService = localizationService;
            this._BlogSettings = BlogSettings;
        }

        public ActionResult Configure()
        {
            var model = new ConfigurationModel()
            {
                WidgetZone = _BlogSettings.WidgetZone,
                QtdBlogPosts = _BlogSettings.QtdBlogPosts
            };
            return View("~/Plugins/Widgets.Blog/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public ActionResult Configure(ConfigurationModel model)
        {
            if (!ModelState.IsValid)
                return Configure();

            _BlogSettings.QtdBlogPosts = model.QtdBlogPosts;
            _BlogSettings.WidgetZone = model.WidgetZone;
            _settingService.SaveSetting(_BlogSettings);
            SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));
            return Configure();
        }
    }
}