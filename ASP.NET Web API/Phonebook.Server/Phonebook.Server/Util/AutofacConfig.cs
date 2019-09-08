using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Phonebook.Server.Models.Entities;
using Phonebook.Server.Models.EntityFramework;
using Phonebook.Server.Interfaces;
using Phonebook.Server.Repositories;

namespace Phonebook.Server.Util
{
    public class AutofacConfig
    {
        public static void ConfigureContainer(HttpConfiguration config)
        {
            ContainerBuilder builder = new ContainerBuilder();
            IContainer container;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<SubjectRepository>().As<IRepository<Subject>>().WithParameter("context", new PhonebookContext());
            container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}