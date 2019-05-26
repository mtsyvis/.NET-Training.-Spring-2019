using System;
using BLL.Abstracts;
using BLL.Interface.Entities;

namespace BLL.Mappers
{
    public class AccountMapper : MapperBase<BLL.Interface.Entities.Account, DAL.Interface.DTO.DtoAccount>
    {
        public override Account Map(DAL.Interface.DTO.DtoAccount element)
        {
            AccountType type = (AccountType)Enum.Parse(typeof(AccountType), element.AccountType, true);
            var account = AccountFactory.Create(type);

            account.Iban = element.Iban;
            account.Balance = element.Balance;
            //account.OwnerEmail = element.OwnerEmail;
            //account.OwnerName = element.OwnerName;
            //account.OwnerSurname = element.OwnerSurname;
            account.IsClosed = false;
            account.Points = element.Points;

            return account;
        }

        public override DAL.Interface.DTO.DtoAccount Map(Account element)
        {
            return new DAL.Interface.DTO.DtoAccount
                       {
                           Iban = element.Iban,
                           //OwnerEmail = element.OwnerEmail,
                           //OwnerName = element.OwnerName,
                           //OwnerSurname = element.OwnerSurname,
                           Points = element.Points,
                           Balance = element.Balance,
                           IsClosed = element.IsClosed,
                           AccountType = element.Type.ToString()
                       };
        }
    }
}
