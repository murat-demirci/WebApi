using Dapper;

namespace Core.Dapper.Abstract;
public interface IDapperBase<T> where T : class,new()
{
    Task<IEnumerable<T>> LoadDataAsync(string storedProcedure, DynamicParameters parameters, string connectionId = "TestDB");
    Task<IEnumerable<T>> LoadDataAsync(string storedProcedure, string connectionId = "TestDB");
    Task<bool> SaveDataAsync(string storedProcedure, DynamicParameters parameters, string connectionId = "TestDB");
    Task<bool> SaveDataAsync(string storedProcedure, string connectionId = "TestDB");
}
