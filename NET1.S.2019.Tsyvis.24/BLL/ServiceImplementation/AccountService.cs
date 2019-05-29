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

        private IUnitOfWork unitOfWork;

        private AccountMapper mapper = new AccountMapper();

        public AccountService(IAccountRepository repository, ILogger logger, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }

        public void DepositAccount(string iban, double amount)
        {
            var account = this.mapper.Map(this.repository.GetAccount(iban));

            VerifyDataForAccountSumChange(account, amount);

            account.Balance += amount;
            this.repository.UpdateAccount(this.mapper.Map(account));

            this.unitOfWork.Commit();
        }

        public void WithdrawAccount(string iban, double amount)
        {
            var account = this.mapper.Map(this.repository.GetAccount(iban));

            VerifyDataForAccountSumChange(account, amount);

            if (!account.CanWithdraw(amount))
            {
               throw new NotEnoughMoneyInAccountException("Not enough money", account.Balance);
            }

            account.Balance -= amount;
            this.repository.UpdateAccount(this.mapper.Map(account));
            this.unitOfWork.Commit();
        }

        public void TransferAmount(string sourceIban, string destinationIban, double amount)
        {
            WithdrawAccount(sourceIban, amount);
            DepositAccount(destinationIban, amount);
            this.unitOfWork.Commit();
        }

        public void OpenAccount(int userId, AccountType type, IAccountNumberGenerateService numberGenerateService)
        {
            var account = new DtoAccount
                              {
                                  Iban = numberGenerateService.Generate(),
                                  OwnerId = userId,
                                  AccountType = type.ToString(),
                                  Balance = 0,
                                  IsClosed = false
                              };

            this.repository.AddAccount(account);
            this.unitOfWork.Commit();
        }

        public void CloseAccount(string iban)
        {
            var account = this.mapper.Map(this.repository.GetAccount(iban));
            account.IsClosed = true;
            this.unitOfWork.Commit();
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
