using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Data;

namespace Colaboradix.Infra.Data.Context
{
    internal class DbSession : IDisposable
    {
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        public DbSession(IConfiguration configuration)
        {
            Connection = CreateConnection(configuration);
            Connection.Open();
        }

        private static IDbConnection CreateConnection(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("ColaboradixDb");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new NpgsqlConnection(configuration.GetConnectionString("ColaboradixDb"));
        }

        public void Dispose() => Connection?.Dispose();
    }
}
