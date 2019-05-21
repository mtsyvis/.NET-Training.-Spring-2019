using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceImplementation
{
    using BLL.Interface.Entities;
    using BLL.Interface.Interfaces;

    using DAL.Interface.Interfaces;

    public class AccountService : IAccountService
    {
        private IAccountRepository repository;

        public AccountService(IAccountRepository repository)
        {
            this.repository = repository;
        }

        public void DepositAccount(string iban, double amount)
        {
            throw new NotImplementedException();
        }

        public void WithdrawAccount(string iban, double amount)
        {
            throw new NotImplementedException();
        }

        public void TransferAmount(string sourceIban, string destinationIban, double amount)
        {
            throw new NotImplementedException();
        }

        public void OpenAccount(string ownerName, AccountType type, IAccountNumberGenerateService numberGenerateService)
        {
            throw new NotImplementedException();
        }

        public void CloseAccount(string iban)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            throw new NotImplementedException();
        }
    }
}
