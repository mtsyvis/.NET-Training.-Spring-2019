//using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Fake;
using DAL.Interface.Interfaces;
//using DAL.Repositories;
using Ninject;

namespace DependencyResolver
{
    using DAL.ADO.NET.Repositories;
    using DAL.Fake.Repositories;

    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<IAccountRepository>().To<AdoNetAccountRepository>();//.WithConstructorArgument("test.bin");
            kernel.Bind<ILogger>().To<NLogLogger>();//.InSingletonScope();
            kernel.Bind<IAccountNumberGenerateService>().To<AccountNumberGuidGenerateService>().InSingletonScope();
            //kernel.Bind<IApplicationSettings>().To<ApplicationSettings>();
        }
    }
}
