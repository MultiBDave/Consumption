using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Data;
using Dapper;

namespace Consumption_Meter
{
    public class SqlDatabaseAccess : ISqlDatabaseAccess
    {
        private const string CONNECTION_NAME = "PM";
        private readonly IConfiguration _configuration;

        public SqlDatabaseAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<T>> Execute<T>(string sql)
        {
            string connectionString = _configuration.GetConnectionString(CONNECTION_NAME);

            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var rows = await connection.QueryAsync<T>(sql);

                return rows.ToList();
            }
        }

        public async Task<List<T>> Execute<T, U>(string sql, U model)
        {
            string connectionString = _configuration.GetConnectionString(CONNECTION_NAME);

            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var rows = await connection.QueryAsync<T>(sql, model);

                return rows.ToList();
            }
        }

        public async Task<T> ExecuteSingle<T, U>(string sql, U model)
        {
            string connectionString = _configuration.GetConnectionString(CONNECTION_NAME);

            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var row = await connection.QueryAsync<T>(sql, model);

                return row.First();
            }
        }
    }
}
