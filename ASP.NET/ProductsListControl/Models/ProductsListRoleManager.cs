using Microsoft.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace ProductsListControl.Models
{
    public class ProductsListRoleManager : RoleManager<ProductsListRole>
    {
        public ProductsListRoleManager(RoleStore<ProductsListRole> store) : base(store) { }

        public static ProductsListRoleManager Create(IdentityFactoryOptions<ProductsListRoleManager> options, IOwinContext context)
        {
            return new ProductsListRoleManager(new RoleStore<ProductsListRole>(context.Get<ProductsListContext>()));
        }
    }
}