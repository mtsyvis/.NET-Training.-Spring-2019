using System;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DependencyResolver;
using Ninject;

namespace ConsolePL
{
    class Program
    {
        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolver();
        }

        static void Main(string[] args)
        {
            IAccountService service = resolver.Get<IAccountService>();
            IAccountNumberGenerateService creator = resolver.Get<IAccountNumberGenerateService>();

            service.OpenAccount("Account owner 1", AccountType.Base, creator);
            service.OpenAccount("Account owner 2", AccountType.Base, creator);
            service.OpenAccount("Account owner 4", AccountType.Base, creator);

            var creditNumbers = service.GetAllAccounts().Select(acc => acc.Iban).ToArray();

            foreach (var t in creditNumbers)
            {
                service.DepositAccount(t, 100);
            }

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine($"{item.Iban}  {nameof(item.Sum)} = {item.Sum}  {nameof(item.OwnerName)} = {item.OwnerName}");
            }

            foreach (var t in creditNumbers)
            {
                service.WithdrawAccount(t, 10);
            }

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine($"{item.Iban}  {nameof(item.Sum)} = {item.Sum}  {nameof(item.OwnerName)} = {item.OwnerName}");
            }
        }
    }
}
