using System.Collections.Generic;

namespace Blog.DataAccessLayer.Entities
{
    public class Tag
    {
        public int TagId { get; set; }
        public string TagName { get; set; }
        public virtual ICollection<ArticleTag> ArticleTags { get; set; }
    }
}