using System.Collections.Generic;

namespace Blog.BusinessLogicLayer.DataTransferObjects
{
    public class TagDataTransferObject
    {
        public int TagId { get; set; }
        public string TagName { get; set; }
        public virtual ICollection<ArticleTagDataTransferObject> ArticleTagDtos { get; set; }
    }
}