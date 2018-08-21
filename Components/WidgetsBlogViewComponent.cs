using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;
using NopBrasil.Plugin.Widgets.Blog.Service;

namespace NopBrasil.Plugin.Widgets.ContactData.Component
{
    [ViewComponent(Name = "WidgetsBlog")]
    public class WidgetsBlogViewComponent : NopViewComponent
    {
        private readonly IWidgetBlogService _widgetBlogService;

        public WidgetsBlogViewComponent(IWidgetBlogService widgetBlogService)
        {
            this._widgetBlogService = widgetBlogService;
        }

        public IViewComponentResult Invoke(string widgetZone, object additionalData) => View("~/Plugins/Widgets.Blog/Views/PublicInfo.cshtml", _widgetBlogService.GetModel());
    }
}
