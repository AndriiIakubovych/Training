using System.Collections.Generic;
using Blog.DataAccessLayer.Entities;
using Blog.DataAccessLayer.EntityFramework;
using Blog.DataAccessLayer.Interfaces;

namespace Blog.DataAccessLayer.Repositories
{
    public class ArticleRepository : IRepository<Article>
    {
        private BlogContext context;

        public ArticleRepository(BlogContext context)
        {
            this.context = context;
        }

        public IEnumerable<Article> GetAll()
        {
            return context.Articles;
        }

        public Article Get(int id)
        {
            return context.Articles.Find(id);
        }

        public void Add(Article article)
        {
            context.Articles.Add(article);
        }
    }
}