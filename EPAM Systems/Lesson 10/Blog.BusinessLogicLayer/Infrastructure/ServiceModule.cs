using Ninject.Modules;
using Blog.DataAccessLayer.Interfaces;
using Blog.DataAccessLayer.Repositories;

namespace Blog.BusinessLogicLayer.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;

        public ServiceModule(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<EntityFrameworkUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}