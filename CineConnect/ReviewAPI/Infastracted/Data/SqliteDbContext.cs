using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastracted.Data
{
    public class SqliteDbContext
    {
        private readonly string _connectionString;

        public SqliteDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<T>(sql, parameters);
            }
        }

        public async Task ExecuteAsync(string sql, object parameters = null)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.OpenAsync();
                await connection.ExecuteAsync(sql, parameters);
            }
        }
    }
}
