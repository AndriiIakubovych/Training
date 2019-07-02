using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Blog.DataAccessLayer.Entities;

namespace Blog.DataAccessLayer.Identity
{
    public class BlogRoleManager : RoleManager<BlogRole>
    {
        public BlogRoleManager(RoleStore<BlogRole> store) : base(store) { }
    }
}