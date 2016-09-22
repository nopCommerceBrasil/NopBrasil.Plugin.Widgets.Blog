using Nop.Services.Blogs;
using Nop.Services.Seo;
using NopBrasil.Plugin.Widgets.Blog.Models;

namespace NopBrasil.Plugin.Widgets.Blog.Service
{
    public class WidgetBlogService : IWidgetBlogService
    {
        private readonly IBlogService _blogService;
        private readonly BlogSettings _blogSettings;

        public WidgetBlogService(IBlogService blogService, BlogSettings blogSettings)
        {
            this._blogService = blogService;
            this._blogSettings = blogSettings;
        }

        public PublicInfoModel GetModel()
        {
            PublicInfoModel model = new PublicInfoModel();
            foreach (var post in _blogService.GetAllBlogPosts(pageIndex: 0, pageSize: _blogSettings.QtdBlogPosts))
            {
                string SeName = post.GetSeName(post.LanguageId, ensureTwoPublishedLanguages: false);
                model.BlogItems.Add(new BlogItemModel()
                {
                    CreatedOn = post.CreatedOnUtc,
                    Title = post.Title,
                    Short = post.BodyOverview,
                    Full = post.Body,
                    SeName = SeName,
                    Id = post.Id
                });
            }
            return model;
        }
    }
}
