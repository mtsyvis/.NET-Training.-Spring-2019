using System.Collections.Generic;

namespace DAL.Fake
{
    using DAL.Interface.DTO;

    public class FakeListStorage
    {
        public static List<DtoAccount> Accounts = new List<DtoAccount>
                                               {
                                                   new DtoAccount
                                                       {   
                                                           Iban = "1234",
                                                           AccountType = "base",
                                                           OwnerId = 1,
                                                           Balance = 234.3,
                                                           Points = 20
                                                       }
                                               };

        public static List<DtoUser> Users = new List<DtoUser>
                                                {
                                                    new DtoUser
                                                        {
                                                            Id = 1,
                                                            Name = "Jon",
                                                            Surname = "Skit",
                                                            Email = "jon.skit@gmail.com"
                                                        }
                                                };
    }
}
