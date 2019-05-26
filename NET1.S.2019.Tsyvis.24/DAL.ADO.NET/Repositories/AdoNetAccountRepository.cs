using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace DAL.ADO.NET.Repositories
{
    /// <summary>
    /// Provide manipulation with AccountManagement db using ADO.NET
    /// </summary>
    /// <seealso cref="DAL.Interface.Interfaces.IAccountRepository" />
    public class AdoNetAccountRepository : IAccountRepository
    {
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdoNetAccountRepository"/> class.
        /// </summary>
        public AdoNetAccountRepository()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["AccountManagement"].ConnectionString;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdoNetAccountRepository"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public AdoNetAccountRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Gets the account.
        /// </summary>
        /// <param name="iban">The iban.</param>
        /// <returns>The account</returns>
        public DtoAccount GetAccount(string iban)
        {
            var sqlConnection = new SqlConnection(this.connectionString);
            var sqlCommand = new SqlCommand("GetAccount", sqlConnection) { CommandType = CommandType.StoredProcedure };

            sqlCommand.Parameters.Add(new SqlParameter("@iban", SqlDbType.NVarChar, 200));
            sqlCommand.Parameters["@iban"].Value = iban;

            using (sqlConnection)
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader(CommandBehavior.SingleRow);

                if (!reader.HasRows)
                {
                    return null;
                }

                reader.Read();
                var account = new DtoAccount
                                  {
                                      Iban = (string)reader["Iban"],
                                      OwnerId = (int)reader["OwnerId"],
                                      Balance = (double)(decimal)reader["Balance"],
                                      Points = (double)(decimal)reader["BonusPoints"],
                                      AccountType = (string)reader["AccountType"],
                                      IsClosed = (bool)reader["IsClosed"]
                                  };

                reader.Close();
                return account;
            }
        }

        /// <summary>
        /// Adds the account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <param name="userId">The user identifier.</param>
        public void AddAccount(DtoAccount account, int userId)
        {
            var sqlConnection = new SqlConnection(this.connectionString);
            var sqlCommand = new SqlCommand("InsertAccount", sqlConnection) { CommandType = CommandType.StoredProcedure };

            sqlCommand.Parameters.Add(new SqlParameter("@Iban", SqlDbType.NVarChar, 200));
            sqlCommand.Parameters["@Iban"].Value = account.Iban;
            sqlCommand.Parameters.Add(new SqlParameter("@OwnerId", SqlDbType.Int, 4));
            sqlCommand.Parameters["@OwnerId"].Value = userId;
            sqlCommand.Parameters.Add(new SqlParameter("@Balance", SqlDbType.Decimal));
            sqlCommand.Parameters["@Balance"].Value = account.Balance;
            sqlCommand.Parameters.Add(new SqlParameter("@BonusPoints", SqlDbType.Decimal));
            sqlCommand.Parameters["@BonusPoints"].Value = account.Points;
            sqlCommand.Parameters.Add(new SqlParameter("@AccountType", SqlDbType.NVarChar, 50));
            sqlCommand.Parameters["@AccountType"].Value = account.AccountType;

            using (sqlConnection)
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the account.
        /// </summary>
        /// <param name="account">The account.</param>
        public void UpdateAccount(DtoAccount account)
        {
            var sqlConnection = new SqlConnection(this.connectionString);
            var sqlCommand = new SqlCommand("UpdateAccount", sqlConnection) { CommandType = CommandType.StoredProcedure };

            sqlCommand.Parameters.Add(new SqlParameter("@Iban", SqlDbType.NVarChar, 200));
            sqlCommand.Parameters["@Iban"].Value = account.Iban;
            sqlCommand.Parameters.Add(new SqlParameter("@Balance", SqlDbType.Decimal));
            sqlCommand.Parameters["@Balance"].Value = account.Balance;
            sqlCommand.Parameters.Add(new SqlParameter("@BonusPoints", SqlDbType.Decimal));
            sqlCommand.Parameters["@BonusPoints"].Value = account.Points;
            sqlCommand.Parameters.Add(new SqlParameter("@AccountType", SqlDbType.NVarChar, 50));
            sqlCommand.Parameters["@AccountType"].Value = account.AccountType;
            sqlCommand.Parameters.Add(new SqlParameter("@IsClosed", SqlDbType.Bit));
            sqlCommand.Parameters["@IsClosed"].Value = account.IsClosed;

            using (sqlConnection)
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void DeleteAccount(string iban)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the accounts.
        /// </summary>
        /// <returns>All accounts</returns>
        public IEnumerable<DtoAccount> GetAccounts()
        {
            var sqlConnection = new SqlConnection(this.connectionString);
            var sqlCommand = new SqlCommand("GetAllAccounts", sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            var accounts = new List<DtoAccount>();

            using (sqlConnection)
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    var account = new DtoAccount
                                      {
                                          Iban = (string)reader["Iban"],
                                          OwnerId = (int)reader["OwnerId"],
                                          Balance = (double)(decimal)reader["Balance"],
                                          Points = (double)(decimal)reader["BonusPoints"],
                                          AccountType = (string)reader["AccountType"],
                                          IsClosed = (bool)reader["IsClosed"]
                                      };

                    accounts.Add(account);
                }

                reader.Close();
                return accounts;
            }
        }
    }
}
