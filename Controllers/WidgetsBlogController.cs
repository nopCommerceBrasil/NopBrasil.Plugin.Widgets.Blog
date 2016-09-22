using System.Web.Mvc;
using NopBrasil.Plugin.Widgets.Blog.Models;
using Nop.Services.Configuration;
using Nop.Web.Framework.Controllers;
using Nop.Web.Controllers;
using NopBrasil.Plugin.Widgets.Blog.Service;

namespace NopBrasil.Plugin.Widgets.Blog.Controllers
{
    public class WidgetsBlogController : BasePublicController
    {
        private readonly ISettingService _settingService;
        private readonly BlogSettings _BlogSettings;
        private readonly IWidgetBlogService _widgetBlogService;

        public WidgetsBlogController(ISettingService settingService,
            BlogSettings BlogSettings, IWidgetBlogService widgetBlogService)
        {
            this._settingService = settingService;
            this._BlogSettings = BlogSettings;
            this._widgetBlogService = widgetBlogService;
        }

        [AdminAuthorize]
        [ChildActionOnly]
        public ActionResult Configure()
        {
            var model = new ConfigurationModel()
            {
                WidgetZone = _BlogSettings.WidgetZone,
                QtdBlogPosts = _BlogSettings.QtdBlogPosts
            };
            return View("~/Plugins/Widgets.Blog/Views/WidgetsBlog/Configure.cshtml", model);
        }

        [HttpPost]
        [AdminAuthorize]
        [ChildActionOnly]
        public ActionResult Configure(ConfigurationModel model)
        {
            if (!ModelState.IsValid)
            {
                return Configure();
            }
            _BlogSettings.QtdBlogPosts = model.QtdBlogPosts;
            _BlogSettings.WidgetZone = model.WidgetZone;
            _settingService.SaveSetting(_BlogSettings);
            return Configure();
        }

        [ChildActionOnly]
        public ActionResult PublicInfo(string widgetZone, object additionalData = null)
        {
             return View("~/Plugins/Widgets.Blog/Views/WidgetsBlog/PublicInfo.cshtml", _widgetBlogService.GetModel());
        }
    }
}