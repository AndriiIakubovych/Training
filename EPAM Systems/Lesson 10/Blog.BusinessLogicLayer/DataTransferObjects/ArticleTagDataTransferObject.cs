namespace Blog.BusinessLogicLayer.DataTransferObjects
{
    public class ArticleTagDataTransferObject
    {
        public int ArticleId { get; set; }
        public int TagId { get; set; }
        ArticleDataTransferObject ArticleDto { get; set; }
        TagDataTransferObject TagDto { get; set; }
    }
}