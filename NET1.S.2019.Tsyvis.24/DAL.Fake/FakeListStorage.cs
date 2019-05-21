using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Fake
{
    using DAL.Interface.DTO;

    public class FakeListStorage
    {
        public static List<Account> List = new List<Account>
                                               {
                                                   new Account
                                                       {
                                                           AccountType = "base",
                                                           OwnerEmail = "jon.skit@gmail.com",
                                                           OwnerName = "Jon",
                                                           OwnerSurname = "Skit",
                                                           Sum = 234.3,
                                                           Points = 20
                                                       }
                                               };
    }
}
