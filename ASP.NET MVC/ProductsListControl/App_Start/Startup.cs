using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using ProductsListControl.Models;

[assembly: OwinStartup(typeof(ProductsListControl.Startup))]

namespace ProductsListControl
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(ProductsListContext.Create);
            app.CreatePerOwinContext<ProductsListUserManager>(ProductsListUserManager.Create);
            app.CreatePerOwinContext<ProductsListRoleManager>(ProductsListRoleManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions { AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie, LoginPath = new PathString("/Account/Login") });
        }
    }
}