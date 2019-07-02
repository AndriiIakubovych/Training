using System.Collections.Generic;
using Blog.DataAccessLayer.Entities;
using Blog.DataAccessLayer.EntityFramework;
using Blog.DataAccessLayer.Interfaces;

namespace Blog.DataAccessLayer.Repositories
{
    public class VoteRepository : IRepository<Vote>
    {
        private BlogContext context;

        public VoteRepository(BlogContext context)
        {
            this.context = context;
        }

        public IEnumerable<Vote> GetAll()
        {
            return context.Votes;
        }

        public Vote Get(int id)
        {
            return context.Votes.Find(id);
        }

        public void Add(Vote vote)
        {
            context.Votes.Add(vote);
        }
    }
}