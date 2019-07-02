using System;
using System.Collections.Generic;

namespace Blog.DataAccessLayer.Entities
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string ArticleName { get; set; }
        public DateTime PublicationDate { get; set; }
        public string ArticleContent { get; set; }
        public virtual ICollection<ArticleTag> ArticleTags { get; set; }
    }
}