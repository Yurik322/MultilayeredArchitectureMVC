using DAL.Interfaces;
using DAL.Repositories;
using Ninject.Modules;

namespace BLL.Infrastructure
{
    /// <summary>
    /// Class for services module that implement NinjectModule.
    /// </summary>
    public class ServiceModule : NinjectModule
    {
        private readonly string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EfUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
