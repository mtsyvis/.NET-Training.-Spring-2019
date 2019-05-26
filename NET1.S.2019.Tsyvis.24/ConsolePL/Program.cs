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

            IAccountNumberGenerateService creator = resolver.Get<IAccountNumberGenerateService>();
            IAccountService service = resolver.Get<IAccountService>();

            //service.OpenAccount(5, AccountType.Base, creator);
            //service.OpenAccount(6, AccountType.Gold, creator);
            //service.OpenAccount(7, AccountType.Platinum, creator);

            var creditNumbers = service.GetAllAccounts().Select(acc => acc.Iban).ToArray();

            foreach (var t in creditNumbers)
            {
                service.DepositAccount(t, 100);
            }

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine($"{item.Iban}  {nameof(item.Balance)} = {item.Balance}  ");
            }

            foreach (var t in creditNumbers)
            {
                service.WithdrawAccount(t, 10);
            }

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine($"{item.Iban}  {nameof(item.Balance)} = {item.Balance}   = ");
            }
        }
    }
}
