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

    }

    public interface IDatabaseConnection
    {
        IDbConnection GetConnection();
    }
}
