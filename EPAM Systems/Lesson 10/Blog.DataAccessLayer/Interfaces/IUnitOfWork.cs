using System;
using System.Threading.Tasks;
using Blog.DataAccessLayer.Entities;
using Blog.DataAccessLayer.Identity;

namespace Blog.DataAccessLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        BlogUserManager UserManager { get; }
        BlogRoleManager RoleManager { get; }
        IClientManager ClientManager { get; }
        IRepository<Article> Articles { get; }
        IRepository<Comment> Comments { get; }
        IRepository<TestResult> TestResults { get; }
        IRepository<Vote> Votes { get; }
        IRepository<Tag> Tags { get; }
        IRepository<ArticleTag> ArticleTags { get; }
        void Save();
        Task SaveAsync();
    }
}