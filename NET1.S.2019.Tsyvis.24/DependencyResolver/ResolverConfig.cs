//using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Fake;
using DAL.Interface.Interfaces;
//using DAL.Repositories;
using Ninject;

namespace DependencyResolver
{
    using System.Configuration;
    using System.Data.Entity;

    using DAL.ADO.NET.Repositories;
    using DAL.EntityFramework;
    using DAL.EntityFramework.Repositories;
    using DAL.Fake.Repositories;

    using Ninject.Parameters;

    using ORM;

    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AccountModel"].ConnectionString;

            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<IAccountRepository>().To<AccountRepository>();

            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
            kernel.Bind<DbContext>().To<AccountModel>().InSingletonScope();
                //.WithParameter(new Parameter("connectionString", connectionString, false));


            kernel.Bind<ILogger>().To<NLogLogger>();
            kernel.Bind<IAccountNumberGenerateService>().To<AccountNumberGuidGenerateService>().InSingletonScope();

            //kernel.Bind<IApplicationSettings>().To<ApplicationSettings>();
        }
    }
}
