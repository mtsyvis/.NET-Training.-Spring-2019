using System;
using BLL.Abstracts;
using BLL.Interface.Entities;

namespace BLL.Mappers
{
    public class AccountMapper : MapperBase<BLL.Interface.Entities.Account, DAL.Interface.DTO.Account>
    {
        public override Account Map(DAL.Interface.DTO.Account element)
        {
            throw new NotImplementedException();
        }

        public override DAL.Interface.DTO.Account Map(Account element)
        {
            throw new NotImplementedException();
        }
    }
}
