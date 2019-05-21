using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IAccountService
    {
        void DepositAccount(string iban, double amount);

        void WithdrawAccount(string iban, double amount);

        void TransferAmount(string sourceIban, string destinationIban, double amount);

        void OpenAccount(string ownerName, AccountType type, IAccountNumberGenerateService numberGenerateService);

        void CloseAccount(string iban);

        IEnumerable<Account> GetAllAccounts();
    }
}
