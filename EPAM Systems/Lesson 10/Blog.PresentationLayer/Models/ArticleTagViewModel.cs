namespace Blog.PresentationLayer.Models
{
    public class ArticleTagViewModel
    {
        public int ArticleId { get; set; }
        public int TagId { get; set; }
        public ArticleViewModel ArticleViewModel { get; set; }
        public TagViewModel TagViewModel { get; set; }
    }
}