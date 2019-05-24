using System.Collections.Generic;
using DAL.Interface.DTO;

namespace DAL.Interface.Interfaces
{
    public interface IAccountRepository
    {
        DtoAccount GetAccount(string iban);

        void AddAccount(DtoAccount account);

        void UpdateAccount(DtoAccount account);

        void DeleteAccount(string iban);

        IEnumerable<DtoAccount> GetAccounts();
    }
}
