//using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Fake;
using DAL.Interface.Interfaces;
//using DAL.Repositories;
using Ninject;

namespace DependencyResolver
{
    using DAL.Fake.Repositories;

    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IAccountService>().To<AccountService>();
            //kernel.Bind<IRepository>().To<FakeRepository>();
            kernel.Bind<IAccountRepository>().To<FakeAccountRepository>().WithConstructorArgument("test.bin");
            kernel.Bind<IAccountNumberGenerateService>().To<AccountNumberGenerateService>().InSingletonScope();
            //kernel.Bind<IApplicationSettings>().To<ApplicationSettings>();
        }
    }
}
