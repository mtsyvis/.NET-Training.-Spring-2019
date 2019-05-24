using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceImplementation
{
    using BLL.Abstracts;
    using BLL.Interface.Entities;
    using BLL.Interface.Exceptions;
    using BLL.Interface.Interfaces;
    using BLL.Mappers;

    using DAL.Interface.DTO;
    using DAL.Interface.Interfaces;

    public class AccountService : IAccountService
    {
        private IAccountRepository repository;

        private ILogger logger;

        private AccountMapper mapper = new AccountMapper();

        public AccountService(IAccountRepository repository, ILogger logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public void DepositAccount(string iban, double amount)
        {
            var account = this.mapper.Map(this.repository.GetAccount(iban));

            VerifyDataForAccountSumChange(account, amount);

            account.Sum += amount;

            this.repository.UpdateAccount(this.mapper.Map(account));
        }

        public void WithdrawAccount(string iban, double amount)
        {
            var account = this.mapper.Map(this.repository.GetAccount(iban));

            VerifyDataForAccountSumChange(account, amount);

            account.Sum -= amount;

            this.repository.UpdateAccount(this.mapper.Map(account));
        }

        public void TransferAmount(string sourceIban, string destinationIban, double amount)
        {
            WithdrawAccount(sourceIban, amount);
            DepositAccount(destinationIban, amount);
        }

        public void OpenAccount(string ownerName, AccountType type, IAccountNumberGenerateService numberGenerateService)
        {
            var account = new DtoAccount
                              {
                                  Iban = numberGenerateService.Generate(),
                                  OwnerName = ownerName,
                                  AccountType = type.ToString(),
                                  Sum = 0,
                                  IsClosed = false
                              };

            this.repository.AddAccount(account);
        }

        public void CloseAccount(string iban)
        {
            var account = this.mapper.Map(this.repository.GetAccount(iban));
            account.IsClosed = true;
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return this.mapper.Map(this.repository.GetAccounts());
        }

        private void VerifyDataForAccountSumChange(Account account, double value)
        {
            if (account.IsClosed)
            {
                throw new NotSupportedOperationException($"account is closed");
            }

            if (value < 0)
            {
                throw new NotSupportedException($"It is impossible to deposit the account with a negative value {nameof(value)}");
            }
        }
    }
}
