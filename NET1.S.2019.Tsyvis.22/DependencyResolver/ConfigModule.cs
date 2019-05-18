using BLL;
using BLL.Interface.Interfaces;
using NET1.S._2019.Tsyvis._22.Interfaces;
using Ninject.Modules;

namespace DependencyResolver
{
    /// <summary>
    /// Provide binding contract with implementation.
    /// </summary>
    /// <seealso cref="Ninject.Modules.NinjectModule" />
    public class ConfigModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Bind<ILogger>().To<NLogLogger>();
            this.Bind<IUriReader>().To<UriLineReader>();
            this.Bind<IExportService>().To<UriToXmlExportService>();
        }
    }
}
