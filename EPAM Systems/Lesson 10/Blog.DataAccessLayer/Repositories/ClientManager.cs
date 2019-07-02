using Blog.DataAccessLayer.Entities;
using Blog.DataAccessLayer.EntityFramework;
using Blog.DataAccessLayer.Interfaces;

namespace Blog.DataAccessLayer.Repositories
{
    public class ClientManager : IClientManager
    {
        public BlogContext Context { get; set; }

        public ClientManager(BlogContext context)
        {
            Context = context;
        }

        public void Create(ClientProfile item)
        {
            Context.ClientProfiles.Add(item);
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}