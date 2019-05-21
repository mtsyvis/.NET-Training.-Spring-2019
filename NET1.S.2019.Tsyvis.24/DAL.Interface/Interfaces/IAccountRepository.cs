using System.Collections.Generic;
using DAL.Interface.DTO;

namespace DAL.Interface.Interfaces
{
    public interface IAccountRepository
    {
        Account GetAccount(string iban);

        void AddAccount(Account account);

        void UpdateAccount(Account account);

        void DeleteAccount(string iban);

        IEnumerable<Account> GetAccounts();
    }
}
