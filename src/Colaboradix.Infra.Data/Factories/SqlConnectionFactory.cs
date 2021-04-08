using System;
using System.Data;
using Npgsql;

namespace Colaboradix.Infra.Data.Factories
{
    public class SqlConnectionFactory : ISqlConnectionFactory, IDisposable
    {
        private readonly IDbConnection _connection;
        public SqlConnectionFactory(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString);
            _connection.Open();
        }

        public IDbConnection GetOpenConnection() => _connection;

        public void Dispose()
        {
            _connection?.Dispose();
        }

    }
}
