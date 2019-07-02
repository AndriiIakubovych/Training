using System;

namespace Blog.BusinessLogicLayer.DataTransferObjects
{
    public class CommentDataTransferObject
    {
        public int CommentId { get; set; }
        public string AuthorName { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentText { get; set; }
    }
}