using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HCL.Api.Dapper
{
    public class DatabaseConnection : IDatabaseConnection
    {
        public readonly IConfiguration Configuration;

        public DatabaseConnection(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }

        public System.Data.IDbConnection GetConnection()
        {
            string connectionString = Configuration.GetConnectionString("hclDB");
            return new SqlConnection(connectionString);
        }
    }
    public class Database : IDatabase
    {
        #region Global Variables
        private readonly IDatabaseConnection databaseConnection;
        
        #endregion

        #region Constructor
        public Database(IConfiguration Configuration)
        {
            this.databaseConnection = new DatabaseConnection(Configuration);
        }

        public Database(IDatabaseConnection databaseConnection)
        {
            this.databaseConnection = databaseConnection;
        }
        #endregion

        #region Execute List
        public async Task<IList<T>> ExecuteList<T>(string commandText)
            {
                using (var sqlConnection = this.databaseConnection.GetConnection())
                {
                IEnumerable<T> result = await sqlConnection.QueryAsync<T>(commandText, null, commandType: CommandType.StoredProcedure);
                    return await Task.FromResult(result.ToList());
                }
            }
        #endregion
    }
}
