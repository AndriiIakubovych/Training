using Microsoft.AspNet.Identity.EntityFramework;

namespace Blog.DataAccessLayer.Entities
{
    public class BlogUser : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
    }
}