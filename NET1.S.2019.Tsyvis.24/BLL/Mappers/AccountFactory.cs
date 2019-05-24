using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    using BLL.Accounts;
    using BLL.Interface.Entities;
    using BLL.Interface.Exceptions;

    public static class AccountFactory
    {
        private static readonly Dictionary<AccountType, Func<Account>> map =
            new Dictionary<AccountType, Func<Account>>();

        static AccountFactory()
        {
            map[AccountType.Base] = () => new BaseAccount();
            map[AccountType.Gold] = () => new GoldAccount();
            map[AccountType.Platinum] = () => new PlatinumAccount();
        }

        public static Account Create(AccountType type)
        {
            var creator = GetCreator(type);
            if (creator is null)
            {
                throw new UnsupportedAccountTypeException($"{nameof(type)} is unsupported");
            }

            return creator.Invoke();
        }

        private static Func<Account> GetCreator(AccountType type)
        {
            map.TryGetValue(type, out var creator);
            return creator;
        }
    }
}
