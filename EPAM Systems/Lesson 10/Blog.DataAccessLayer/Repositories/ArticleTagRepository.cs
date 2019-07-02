using System.Collections.Generic;
using Blog.DataAccessLayer.Entities;
using Blog.DataAccessLayer.EntityFramework;
using Blog.DataAccessLayer.Interfaces;

namespace Blog.DataAccessLayer.Repositories
{
    public class ArticleTagRepository : IRepository<ArticleTag>
    {
        private BlogContext context;

        public ArticleTagRepository(BlogContext context)
        {
            this.context = context;
        }

        public IEnumerable<ArticleTag> GetAll()
        {
            return context.ArticleTags;
        }

        public ArticleTag Get(int id)
        {
            return context.ArticleTags.Find(id);
        }

        public void Add(ArticleTag articleTag)
        {
            context.ArticleTags.Add(articleTag);
        }
    }
}