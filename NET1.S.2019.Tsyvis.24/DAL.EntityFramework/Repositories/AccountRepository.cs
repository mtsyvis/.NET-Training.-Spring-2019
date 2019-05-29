using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using DAL.EntityFramework.Mappers;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

using ORM;

namespace DAL.EntityFramework.Repositories
{
    /// <summary>
    /// Provide manipulation with account entities.
    /// </summary>
    /// <seealso cref="DAL.Interface.Interfaces.IAccountRepository" />
    public class AccountRepository : IAccountRepository
    {
        private readonly DbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public AccountRepository(DbContext dbContext)
        {
            this.context = dbContext;
        }

        /// <summary>
        /// Gets the account.
        /// </summary>
        /// <param name="iban">The iban.</param>
        /// <returns>The dtoAccount</returns>
        public DtoAccount GetAccount(string iban)
        {
            var account = this.context.Set<Account>().FirstOrDefaultAsync(a => a.Iban == iban).Result;
            return account.ToDtoAccount();
        }

        /// <summary>
        /// Adds the account.
        /// </summary>
        /// <param name="account">The account.</param>
        public void AddAccount(DtoAccount account)
        {
            this.context.Set<Account>().Add(account.ToOrmAccount(this.context));
        }

        /// <summary>
        /// Updates the account.
        /// </summary>
        /// <param name="account">The account.</param>
        public void UpdateAccount(DtoAccount account)
        {
            var updateAccount = this.context.Set<Account>().FirstOrDefaultAsync(a => a.Iban == account.Iban).Result;
            updateAccount.Balance = (decimal)account.Balance;
            updateAccount.BonusPoints = (decimal)account.Points;
            updateAccount.AccountType =
                this.context.Set<AccountType>().FirstOrDefault(a => a.Type == account.AccountType);
            updateAccount.IsClosed = account.IsClosed;
        }

        /// <summary>
        /// Deletes the account.
        /// </summary>
        /// <param name="iban">The iban.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void DeleteAccount(string iban)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the accounts.
        /// </summary>
        /// <returns>The accounts</returns>
        public IEnumerable<DtoAccount> GetAccounts()
        {
            var accounts = this.context.Set<Account>().Select(account => account).ToList();

            foreach (var account in accounts)
            {
                yield return account.ToDtoAccount();
            }
        }
    }
}
