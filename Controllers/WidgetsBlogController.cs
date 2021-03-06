﻿using NopBrasil.Plugin.Widgets.Blog.Models;
using Nop.Services.Configuration;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework;
using Microsoft.AspNetCore.Mvc;
using Nop.Services.Localization;
using Nop.Services.Security;
using Nop.Services.Messages;
using Nop.Web.Framework.Mvc.Filters;

namespace NopBrasil.Plugin.Widgets.Blog.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    public class WidgetsBlogController : BasePluginController
    {
        private readonly ISettingService _settingService;
        private readonly ILocalizationService _localizationService;
        private readonly BlogSettings _BlogSettings;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;

        public WidgetsBlogController(ISettingService settingService, ILocalizationService localizationService,
            BlogSettings BlogSettings, INotificationService notificationService, IPermissionService permissionService)
        {
            this._settingService = settingService;
            this._localizationService = localizationService;
            this._BlogSettings = BlogSettings;
            this._notificationService = notificationService;
            this._permissionService = permissionService;
        }

        public IActionResult Configure()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageShippingSettings))
                return AccessDeniedView();

            var model = new ConfigurationModel()
            {
                WidgetZone = _BlogSettings.WidgetZone,
                QtdBlogPosts = _BlogSettings.QtdBlogPosts
            };
            return View("~/Plugins/Widgets.Blog/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public IActionResult Configure(ConfigurationModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageShippingSettings))
                return AccessDeniedView();

            if (!ModelState.IsValid)
                return Configure();

            _BlogSettings.QtdBlogPosts = model.QtdBlogPosts;
            _BlogSettings.WidgetZone = model.WidgetZone;
            _settingService.SaveSetting(_BlogSettings);
            _notificationService.SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));
            return Configure();
        }
    }
}