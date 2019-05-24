using System.Collections.Generic;

namespace DAL.Fake
{
    using DAL.Interface.DTO;

    public class FakeListStorage
    {
        public static List<DtoAccount> List = new List<DtoAccount>
                                               {
                                                   new DtoAccount
                                                       {   
                                                           Iban = "1234",
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
