using System.Collections.Generic;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace DAL.Fake.Repositories
{
    public class FakeAccountRepository : IAccountRepository
    {
        public DtoAccount GetAccount(string iban)
        {
            return FakeListStorage.Accounts.Find(ac => ac.Iban == iban);
        }

        public void AddAccount(DtoAccount account, int userId)
        {


            FakeListStorage.Accounts.Add(account);
        }

        public void UpdateAccount(DtoAccount account)
        {
            var item = GetAccount(account.Iban);
            item.AccountType = account.AccountType;
            item.Balance = account.Balance;
            item.Points = account.Points;
        }

        public void DeleteAccount(string iban)
        {
            FakeListStorage.Accounts.Remove(GetAccount(iban));
        }

        public IEnumerable<DtoAccount> GetAccounts()
        {
            return FakeListStorage.Accounts;
        }
    }
}
