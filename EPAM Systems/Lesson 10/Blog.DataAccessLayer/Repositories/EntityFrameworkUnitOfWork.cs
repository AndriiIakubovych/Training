using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Blog.DataAccessLayer.Entities;
using Blog.DataAccessLayer.EntityFramework;
using Blog.DataAccessLayer.Identity;
using Blog.DataAccessLayer.Interfaces;

namespace Blog.DataAccessLayer.Repositories
{
    public class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        private BlogContext context;
        private BlogUserManager userManager;
        private BlogRoleManager roleManager;
        private IClientManager clientManager;
        private ArticleRepository articleRepository;
        private CommentRepository commentRepository;
        private TestResultRepository testResultRepository;
        private VoteRepository voteRepository;
        private TagRepository tagRepository;
        private ArticleTagRepository articleTagRepository;
        private bool disposed = false;

        public EntityFrameworkUnitOfWork(string connectionString)
        {
            context = new BlogContext(connectionString);
            userManager = new BlogUserManager(new UserStore<BlogUser>(context));
            roleManager = new BlogRoleManager(new RoleStore<BlogRole>(context));
            clientManager = new ClientManager(context);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    userManager.Dispose();
                    roleManager.Dispose();
                    clientManager.Dispose();
                }
                disposed = true;
            }
        }

        public BlogUserManager UserManager
        {
            get { return userManager; }
        }

        public IClientManager ClientManager
        {
            get { return clientManager; }
        }

        public BlogRoleManager RoleManager
        {
            get { return roleManager; }
        }

        public IRepository<Article> Articles
        {
            get
            {
                if (articleRepository == null)
                    articleRepository = new ArticleRepository(context);
                return articleRepository;
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                if (commentRepository == null)
                    commentRepository = new CommentRepository(context);
                return commentRepository;
            }
        }

        public IRepository<TestResult> TestResults
        {
            get
            {
                if (testResultRepository == null)
                    testResultRepository = new TestResultRepository(context);
                return testResultRepository;
            }
        }

        public IRepository<Vote> Votes
        {
            get
            {
                if (voteRepository == null)
                    voteRepository = new VoteRepository(context);
                return voteRepository;
            }
        }

        public IRepository<Tag> Tags
        {
            get
            {
                if (tagRepository == null)
                    tagRepository = new TagRepository(context);
                return tagRepository;
            }
        }

        public IRepository<ArticleTag> ArticleTags
        {
            get
            {
                if (articleTagRepository == null)
                    articleTagRepository = new ArticleTagRepository(context);
                return articleTagRepository;
            }
        }
    }
}