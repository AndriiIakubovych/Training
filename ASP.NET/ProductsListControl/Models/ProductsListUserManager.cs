using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace ProductsListControl.Models
{
    public class ProductsListUserManager : UserManager<ProductsListUser>
    {
        public ProductsListUserManager(IUserStore<ProductsListUser> store) : base(store) { }

        public static ProductsListUserManager Create(IdentityFactoryOptions<ProductsListUserManager> options, IOwinContext context)
        {
            ProductsListContext productsListContext = context.Get<ProductsListContext>();
            ProductsListUserManager manager = new ProductsListUserManager(new UserStore<ProductsListUser>(productsListContext));
            return manager;
        }
    }
}