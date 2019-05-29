using DAL.Interface.DTO;
using ORM;
using System.Data.Entity;
using System.Linq;

namespace DAL.EntityFramework.Mappers
{
    /// <summary>
    /// Provide mapping ORM entities to DTO entities and on the contrary.
    /// </summary>
    public static class DalEntityMapper
    {
        /// <summary>
        /// Converts to dto account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns>The dto account</returns>
        public static DtoAccount ToDtoAccount(this Account account)
        {
            return new DtoAccount
                       {
                           Iban = account.Iban,
                           OwnerId = account.OwnerId,
                           Balance = (double)account.Balance,
                           Points = (double)account.BonusPoints,
                           AccountType = account.AccountType.Type,
                           IsClosed = account.IsClosed
                       };
        }

        /// <summary>
        /// Converts to orm account.
        /// </summary>
        /// <param name="dtoAccount">The dto account.</param>
        /// <param name="context">The context.</param>
        /// <returns>The orm account</returns>
        public static Account ToOrmAccount(this DtoAccount dtoAccount, DbContext context)
        {
            return new Account
                       {
                           Iban = dtoAccount.Iban,
                           OwnerId = dtoAccount.OwnerId,
                           Balance = (decimal)dtoAccount.Balance,
                           BonusPoints = (decimal)dtoAccount.Points,
                           AccountType =
                               context?.Set<AccountType>().FirstOrDefault(a => a.Type == dtoAccount.AccountType),
                           IsClosed = dtoAccount.IsClosed
                       };
        }
    }
}
