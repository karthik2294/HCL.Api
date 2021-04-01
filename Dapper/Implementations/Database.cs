using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
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

        #region Execute

        ///// <summary>
        /// This method is used to get entity object as result
        /// </summary>
        /// <typeparam name="T">entity</typeparam>
        /// <param name="commandText">stored procedure name</param>       
        /// <param name="lstParams">sp params list</param>
        /// <returns></returns>
        public async Task<T> Execute<T>(string commandText, List<Tuple<string, object>> lstParams = null)
        {
            using (var sqlConnection = this.databaseConnection.GetConnection())
            {
                var args = (lstParams != null) ? BuildParams(lstParams) : null;
                T result = await sqlConnection.QueryFirstOrDefaultAsync<T>(commandText, args, commandType: CommandType.StoredProcedure);
                return await Task.FromResult(result);
            }
        }

        #endregion

        #region Build Parameters

        /// <summary>
        /// This method is used to build command object parameters list
        /// </summary>
        /// <param name="lstParams">parameters list</param>
        /// <returns></returns>
        private DbParams BuildParams(List<Tuple<string, object>> lstParams)
        {
            var args = new DbParams { };
            lstParams.ForEach(delegate (Tuple<String, Object> param)
            {
                args.Add(new SqlParameter(param.Item1, param.Item2));
            });
            return args;
        }

        #endregion
    }

    public class DbParams : SqlMapper.IDynamicParameters, IEnumerable<IDbDataParameter>
    {
        #region Global Variables

        private readonly List<IDbDataParameter> parameters = new List<IDbDataParameter>();
        public IEnumerator<IDbDataParameter> GetEnumerator() { return parameters.GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }

        #endregion

        #region Add Parameters

        public void Add(IDbDataParameter value)
        {
            parameters.Add(value);
        }

        void SqlMapper.IDynamicParameters.AddParameters(IDbCommand command, SqlMapper.Identity identity)
        {
            foreach (IDbDataParameter parameter in parameters)
                command.Parameters.Add(parameter);
        }

        #endregion
    }
}
