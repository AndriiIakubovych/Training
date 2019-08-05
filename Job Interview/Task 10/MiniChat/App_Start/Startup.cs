using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MiniChat.App_Start.Startup))]

namespace MiniChat.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}