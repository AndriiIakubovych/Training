using System.Collections.Generic;
using Blog.DataAccessLayer.Entities;
using Blog.DataAccessLayer.EntityFramework;
using Blog.DataAccessLayer.Interfaces;

namespace Blog.DataAccessLayer.Repositories
{
    public class TagRepository : IRepository<Tag>
    {
        private BlogContext context;

        public TagRepository(BlogContext context)
        {
            this.context = context;
        }

        public IEnumerable<Tag> GetAll()
        {
            return context.Tags;
        }

        public Tag Get(int id)
        {
            return context.Tags.Find(id);
        }

        public void Add(Tag tag)
        {
            context.Tags.Add(tag);
        }
    }
}