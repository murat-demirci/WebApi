using Core.Dapper.Abstract;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Core.Dapper.Concrete;
public class DapperBase<T>(IConfiguration configuration) : IDapperBase<T> where T : class,new()
{
    public async Task<IEnumerable<T>> LoadDataAsync(string storedProcedure, DynamicParameters parameters, string connectionId = "TestDB")
    {
        using IDbConnection connection = new SqlConnection(configuration.GetConnectionString(connectionId));

        return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }
    public async Task<IEnumerable<T>> LoadDataAsync(string storedProcedure, string connectionId = "TestDB")
    {
        using IDbConnection connection = new SqlConnection(configuration.GetConnectionString(connectionId));

        return await connection.QueryAsync<T>(storedProcedure, commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> SaveDataAsync(string storedProcedure, DynamicParameters parameters, string connectionId = "TestDB")
    {
        using IDbConnection connection = new SqlConnection(configuration.GetConnectionString(connectionId));

        return await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure) > 0;
    }

    public async Task<bool> SaveDataAsync(string storedProcedure, string connectionId = "TestDB")
    {
        using IDbConnection connection = new SqlConnection(configuration.GetConnectionString(connectionId));

        return await connection.ExecuteAsync(storedProcedure, commandType: CommandType.StoredProcedure) > 0;
    }
}
