using Ninject.Modules;
using Blog.BusinessLogicLayer.Interfaces;
using Blog.BusinessLogicLayer.Services;

namespace Blog.PresentationLayer.Util
{
    public class BlogModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBlogService>().To<BlogService>();
        }
    }
}