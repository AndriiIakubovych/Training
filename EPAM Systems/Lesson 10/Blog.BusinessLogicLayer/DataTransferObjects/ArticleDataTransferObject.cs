using System;
using System.Collections.Generic;

namespace Blog.BusinessLogicLayer.DataTransferObjects
{
    public class ArticleDataTransferObject
    {
        public int ArticleId { get; set; }
        public string ArticleName { get; set; }
        public DateTime PublicationDate { get; set; }
        public string ArticleContent { get; set; }
        public virtual ICollection<ArticleTagDataTransferObject> ArticleTagDtos { get; set; }
    }
}