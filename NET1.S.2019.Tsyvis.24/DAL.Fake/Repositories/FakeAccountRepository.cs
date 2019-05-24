using System.Collections.Generic;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace DAL.Fake.Repositories
{
    public class FakeAccountRepository : IAccountRepository
    {
        public DtoAccount GetAccount(string iban)
        {
            return FakeListStorage.List.Find(ac => ac.Iban == iban);
        }

        public void AddAccount(DtoAccount account)
        {
            FakeListStorage.List.Add(account);
        }

        public void UpdateAccount(DtoAccount account)
        {
            var item = GetAccount(account.Iban);
            item.AccountType = account.AccountType;
            item.OwnerEmail = account.OwnerEmail;
            item.OwnerName = account.OwnerName;
            item.OwnerSurname = account.OwnerSurname;
            item.Sum = account.Sum;
            item.Points = account.Points;
        }

        public void DeleteAccount(string iban)
        {
            FakeListStorage.List.Remove(GetAccount(iban));
        }

        public IEnumerable<DtoAccount> GetAccounts()
        {
            return FakeListStorage.List;
        }
    }
}
