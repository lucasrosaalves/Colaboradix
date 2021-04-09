using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using Dapper;
using System.Threading.Tasks;
using Colaboradix.Application.Common.Interfaces;

namespace Colaboradix.Infra.DataAccess
{
    internal class SqlQueryService : ISqlQueryService, IDisposable
    {
        private readonly IDbConnection _connection;

        public SqlQueryService(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString);
            _connection.Open();
        }

        public Task<IEnumerable<T>> QueryAsync<T>(string query)
            => _connection.QueryAsync<T>(query);

        public Task<IEnumerable<TResult>> QueryAsync<TFirst, TSecond, TResult>(string query, Func<TFirst, TSecond, TResult> map, string splitOn = "Id")
            => _connection.QueryAsync(query, map, splitOn: splitOn);

        public Task<T> QueryFirstOrDefaultAsync<T>(string query)
            => _connection.QueryFirstOrDefaultAsync<T>(query);

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}
