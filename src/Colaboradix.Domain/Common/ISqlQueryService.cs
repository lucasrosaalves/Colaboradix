using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ISqlQueryService
{
    Task<IEnumerable<T>> QueryAsync<T>(string query);
    Task<IEnumerable<TResult>> QueryAsync<TFirst, TSecond, TResult>(string query, Func<TFirst, TSecond, TResult> map, string splitOn = "Id");
    Task<T> QueryFirstOrDefaultAsync<T>(string query);
}