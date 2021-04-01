using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HCL.Api.Dapper
{
    public interface IDatabase
    {
        Task<IList<T>> ExecuteList<T>(string commandText);
        Task<T> Execute<T>(string commandText, List<Tuple<string, object>> lstParams = null);

    }

    public interface IDatabaseConnection
    {
        IDbConnection GetConnection();
    }
}
