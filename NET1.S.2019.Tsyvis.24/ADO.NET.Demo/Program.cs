using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ADO.NET.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["DataModelContainer"].ConnectionString;

            //var aeDb = new AccountEntitiesDb(connectionString);

            //foreach (var type in aeDb.GetAccountTypes())
            //{
            //    Console.WriteLine(type.Name);
            //}

            using (var context = new AccountModel())
            {
                foreach (var type in context.AccountTypes)
                {
                    Console.WriteLine(type.Name);
                }
            }

            Console.WriteLine("////////////////////////////////////////");
            using (var context = new AccountModel())
            {
                foreach (var ac in context.Accounts)
                {
                    Console.WriteLine($"{ac.AccountOwner.FirstName},   {ac.AccountOwner.LastName},  {ac.Id}");
                }
            }
        }
    }
}
