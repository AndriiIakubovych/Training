using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.PresentationLayer.Models
{
    public class ArticleViewModel
    {
        public int ArticleId { get; set; }
        [Required(ErrorMessage = "Article name is required!")]
        public string ArticleName { get; set; }
        public DateTime PublicationDate { get; set; }
        [Required(ErrorMessage = "Article content is required!")]
        public string ArticleContent { get; set; }
        public virtual ICollection<ArticleTagViewModel> ArticleTagViewModels { get; set; }
    }
}