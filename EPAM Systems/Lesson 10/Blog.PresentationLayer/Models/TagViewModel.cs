using System.Collections.Generic;

namespace Blog.PresentationLayer.Models
{
    public class TagViewModel
    {
        public int TagId { get; set; }
        public string TagName { get; set; }
        public virtual ICollection<ArticleTagViewModel> ArticleTagViewModels { get; set; }
    }
}