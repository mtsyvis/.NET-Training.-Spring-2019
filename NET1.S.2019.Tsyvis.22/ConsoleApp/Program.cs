using System.Configuration;
using DependencyResolver;
using NET1.S._2019.Tsyvis._22.Interfaces;
using Ninject;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = ConfigurationManager.AppSettings["URIs"];
            var destination = ConfigurationManager.AppSettings["URIsXml"];

            IKernel kernel = new StandardKernel(new ConfigModule());
            var exportService = kernel.Get<IExportService>();

            exportService.Export(source, destination);
        }
    }
}
