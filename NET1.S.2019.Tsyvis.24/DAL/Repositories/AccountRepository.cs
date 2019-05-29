using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    using DAL.Interface.DTO;
    using DAL.Interface.Interfaces;

    public class AccountRepository : IAccountRepository
    {
        public DtoAccount GetAccount(string iban)
        {
            throw new NotImplementedException();
        }

        public void AddAccount(DtoAccount account, int userId)
        {
            throw new NotImplementedException();
        }

        public void UpdateAccount(DtoAccount account)
        {
            throw new NotImplementedException();
        }

        public void DeleteAccount(string iban)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DtoAccount> GetAccounts()
        {
            throw new NotImplementedException();
        }
    }
}
