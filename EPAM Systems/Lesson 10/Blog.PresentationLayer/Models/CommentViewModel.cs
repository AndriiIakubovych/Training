using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.PresentationLayer.Models
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }
        [Required(ErrorMessage = "Author name is required!")]
        public string AuthorName { get; set; }
        public DateTime CommentDate { get; set; }
        [Required(ErrorMessage = "Comment text is required!")]
        public string CommentText { get; set; }
    }
}