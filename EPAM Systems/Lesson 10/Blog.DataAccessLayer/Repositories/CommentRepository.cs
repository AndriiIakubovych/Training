using System.Collections.Generic;
using Blog.DataAccessLayer.Entities;
using Blog.DataAccessLayer.EntityFramework;
using Blog.DataAccessLayer.Interfaces;

namespace Blog.DataAccessLayer.Repositories
{
    public class CommentRepository : IRepository<Comment>
    {
        private BlogContext context;

        public CommentRepository(BlogContext context)
        {
            this.context = context;
        }

        public IEnumerable<Comment> GetAll()
        {
            return context.Comments;
        }

        public Comment Get(int id)
        {
            return context.Comments.Find(id);
        }

        public void Add(Comment comment)
        {
            context.Comments.Add(comment);
        }
    }
}