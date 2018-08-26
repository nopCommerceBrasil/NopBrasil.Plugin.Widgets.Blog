using Nop.Web.Framework.Models;
using System;

namespace NopBrasil.Plugin.Widgets.Blog.Models
{
    public class BlogItemModel : BaseNopEntityModel
    {
        public string Title { get; set; }

        public string Short { get; set; }

        public string Full { get; set; }

        public string SeName { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
