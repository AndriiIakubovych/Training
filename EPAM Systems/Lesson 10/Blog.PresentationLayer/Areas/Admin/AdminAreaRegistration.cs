using System.Web.Mvc;

namespace Blog.PresentationLayer.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute("Admin_default", "Admin/{controller}/{action}/{id}", new { controller = "Blog", action = "Index", id = UrlParameter.Optional });
        }
    }
}