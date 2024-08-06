#pragma warning disable CS0693 // O parâmetro de tipo tem o mesmo nome que o parâmetro de tipo do tipo externo
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.

using System.Data;
using Microsoft.Data.SqlClient;

using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

public class SQLServerAdapter<T> {
    private readonly string _connectionString;

    public SQLServerAdapter(string connectionString) {
        _connectionString = connectionString;
    }
    public async Task<IActionResult> Execute(string query, SqlParameter[]? parameters = null)
    {
        using SqlConnection connection = new(_connectionString);
        using SqlCommand command = new(query, connection);
        if (parameters != null)
        {
            command.Parameters.AddRange(parameters);
        }

        await connection.OpenAsync();
        await command.ExecuteNonQueryAsync();

        return null;
    }

    public async Task<T?> Get<T>(string query, SqlParameter[]? parameters = null) where T : new()
    {
        using (SqlConnection connection = new(_connectionString))
        {
            using SqlCommand command = new(query, connection);
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            await connection.OpenAsync();

            using SqlDataReader reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                return MapToObject<T>(reader);
            }
        }

        return default;
    }

    public async Task<List<T>> List<T>(string query, SqlParameter[]? parameters = null) where T : new()
    {
        List<T> result = [];

        using (SqlConnection connection = new(_connectionString))
        {
            using SqlCommand command = new(query, connection);
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            await connection.OpenAsync();

            using SqlDataReader reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                T obj = MapToObject<T>(reader);
                result.Add(obj);
            }
        }

        return result;
    }

    private T MapToObject<T>(IDataRecord record) where T : new() {
        T obj = new();
        
        for (int i = 0; i < record.FieldCount; i++) {
            PropertyInfo property = typeof(T).GetProperty(record.GetName(i));
            if (property != null && record[i] != DBNull.Value) {
                property.SetValue(obj, Convert.ChangeType(record[i], property.PropertyType));
            }
        }

        return obj;
    }
}