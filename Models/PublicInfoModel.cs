using Nop.Web.Framework.Models;
using System;
using System.Collections.Generic;

namespace NopBrasil.Plugin.Widgets.Blog.Models
{
    public class PublicInfoModel : BaseNopModel, ICloneable
    {
        public PublicInfoModel()
        {
            BlogItems = new List<BlogItemModel>();
        }

        public IList<BlogItemModel> BlogItems { get; set; }

        public object Clone() => this.MemberwiseClone();
    }
}