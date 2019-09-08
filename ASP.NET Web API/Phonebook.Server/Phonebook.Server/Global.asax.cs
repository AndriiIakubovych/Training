using System.Web.Http;
using Phonebook.Server.Util;

namespace Phonebook.Server
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutofacConfig.ConfigureContainer(GlobalConfiguration.Configuration);
        }
    }
}