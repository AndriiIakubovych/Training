using System;

namespace Blog.DataAccessLayer.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string AuthorName { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentText { get; set; }
    }
}