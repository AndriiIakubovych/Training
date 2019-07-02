using Blog.DataAccessLayer.Repositories;
using Blog.BusinessLogicLayer.Interfaces;

namespace Blog.BusinessLogicLayer.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new EntityFrameworkUnitOfWork(connection));
        }
    }
}