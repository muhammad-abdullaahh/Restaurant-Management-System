using Microsoft.Data.SqlClient;
using System.Data;

namespace FoodHeaven.Data
{
    /// <summary>
    /// Raw SQL helper - replaces Entity Framework Core.
    /// Provides simple methods to run SQL queries using SqlConnection.
    /// </summary>
    public class DbHelper
    {
        private readonly string _connectionString;

        public DbHelper(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("DefaultConnection string is missing.");
        }

        // ── Open a new connection ──────────────────────────────────────
        public SqlConnection GetConnection() => new SqlConnection(_connectionString);

        // ── Execute SELECT and map rows to objects ─────────────────────
        public async Task<List<T>> QueryAsync<T>(
            string sql,
            Func<SqlDataReader, T> mapper,
            SqlParameter[]? parameters = null)
        {
            var results = new List<T>();
            using var conn = GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand(sql, conn);
            if (parameters != null) cmd.Parameters.AddRange(parameters);
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
                results.Add(mapper(reader));
            return results;
        }

        // ── Execute INSERT / UPDATE / DELETE ───────────────────────────
        public async Task<int> ExecuteAsync(string sql, SqlParameter[]? parameters = null)
        {
            using var conn = GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand(sql, conn);
            if (parameters != null) cmd.Parameters.AddRange(parameters);
            return await cmd.ExecuteNonQueryAsync();
        }

        // ── Execute INSERT and return the new auto-generated Id ────────
        public async Task<int> InsertAndGetIdAsync(string sql, SqlParameter[]? parameters = null)
        {
            // The SQL must end with:  OUTPUT INSERTED.Id
            using var conn = GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand(sql, conn);
            if (parameters != null) cmd.Parameters.AddRange(parameters);
            var result = await cmd.ExecuteScalarAsync();
            return Convert.ToInt32(result);
        }

        // ── Execute a query that returns a single value ────────────────
        public async Task<T?> ScalarAsync<T>(string sql, SqlParameter[]? parameters = null)
        {
            using var conn = GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand(sql, conn);
            if (parameters != null) cmd.Parameters.AddRange(parameters);
            var result = await cmd.ExecuteScalarAsync();
            if (result == null || result == DBNull.Value) return default;
            
            Type targetType = typeof(T);
            if (Nullable.GetUnderlyingType(targetType) != null)
            {
                targetType = Nullable.GetUnderlyingType(targetType)!;
            }
            return (T)Convert.ChangeType(result, targetType);
        }

        // ── Helper: safely read a nullable string from reader ──────────
        public static string? ReadStr(SqlDataReader r, string col)
        {
            int ord = r.GetOrdinal(col);
            return r.IsDBNull(ord) ? null : r.GetString(ord);
        }

        public static DateTime? ReadDateTime(SqlDataReader r, string col)
        {
            int ord = r.GetOrdinal(col);
            return r.IsDBNull(ord) ? null : r.GetDateTime(ord);
        }

        public static int? ReadIntN(SqlDataReader r, string col)
        {
            int ord = r.GetOrdinal(col);
            return r.IsDBNull(ord) ? null : r.GetInt32(ord);
        }

        public static TimeSpan ReadTime(SqlDataReader r, string col)
        {
            int ord = r.GetOrdinal(col);
            return r.IsDBNull(ord) ? TimeSpan.Zero : (TimeSpan)r[col];
        }

        public static decimal ReadDecimal(SqlDataReader r, string col)
        {
            int ord = r.GetOrdinal(col);
            return r.IsDBNull(ord) ? 0m : r.GetDecimal(ord);
        }
    }
}
