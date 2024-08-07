using Microsoft.Data.SqlClient;

namespace TodoApi.Core.Application.Interfaces
{
    public interface IDatabaseAdapter<T> where T : new()
    {
        Task<int> ExecuteAsync(string query, SqlParameter[]? parameters = null);
        Task<T?> GetAsync(string query, SqlParameter[]? parameters = null);
        Task<List<T>> ListAsync(string query, SqlParameter[]? parameters = null);
    }
}

