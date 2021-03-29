using Colaboradix.Infra.Data.Context;
using Dapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colaboradix.Infra.Data.Common
{
    internal abstract class RepositoryBase
    {
        private readonly DbSession _session;

        protected RepositoryBase(DbSession session)
        {
            _session = session
                ?? throw new ArgumentNullException(nameof(session));
        }

        protected Task<TReturn> QueryFirstAsync<TReturn>(string sql, object param = null)
        {
            return _session.Connection.QueryFirstAsync<TReturn>(sql, param, _session.Transaction);
        }

        protected Task<IEnumerable<TReturn>> QueryAsync<TReturn>(string sql, object param = null)
        {
            return _session.Connection.QueryAsync<TReturn>(sql, param, _session.Transaction);
        }

        protected Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, object param = null, string splitOn = "Id")
        {
            return _session.Connection.QueryAsync(sql, map, param, splitOn: splitOn, transaction: _session.Transaction);
        }

        protected Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(string sql, Func<TFirst, TSecond, TThird, TReturn> map, object param = null, string splitOn = "Id")
        {
            return _session.Connection.QueryAsync(sql, map, param, splitOn: splitOn, transaction: _session.Transaction);
        }

        protected Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param = null, string splitOn = "Id")
        {
            return _session.Connection.QueryAsync(sql, map, param, splitOn: splitOn, transaction: _session.Transaction);
        }

        protected Task ExecuteAsync(string sql, object param = null)
        {
            return _session.Connection.ExecuteAsync(sql, param, _session.Transaction);
        }

        protected Task<T> ExecuteScalarAsync<T>(string sql, object param = null)
        {
            return _session.Connection.ExecuteScalarAsync<T>(sql, param, _session.Transaction);
        }
    }
}
