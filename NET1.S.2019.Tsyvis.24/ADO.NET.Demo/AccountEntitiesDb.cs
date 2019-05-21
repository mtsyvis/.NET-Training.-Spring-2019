using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.Demo
{
    using System.Data;
    using System.Data.SqlClient;

    public class AccountEntitiesDb
    {
        private readonly string connectionString;

        public AccountEntitiesDb(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<AccountType> GetAccountTypes()
        {
            var sqlConnection = new SqlConnection(this.connectionString);
            var sqlCommand =
                new SqlCommand("GetAllAccountTypes", sqlConnection) { CommandType = CommandType.StoredProcedure };
            var accountTypes = new List<AccountType>();

            using (sqlConnection)
            {
                sqlConnection.Open();

                SqlDataReader reader= sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    var emp = new AccountType() { Id = (int)reader["Id"], Name = (string)reader["Name"] };
                    accountTypes.Add(emp);
                }
            }

            return accountTypes;
        }
    }
}
