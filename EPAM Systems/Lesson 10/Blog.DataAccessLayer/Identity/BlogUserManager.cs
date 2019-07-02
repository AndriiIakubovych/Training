using Microsoft.AspNet.Identity;
using Blog.DataAccessLayer.Entities;

namespace Blog.DataAccessLayer.Identity
{
    public class BlogUserManager : UserManager<BlogUser>
    {
        public BlogUserManager(IUserStore<BlogUser> store) : base(store) { }
    }
}