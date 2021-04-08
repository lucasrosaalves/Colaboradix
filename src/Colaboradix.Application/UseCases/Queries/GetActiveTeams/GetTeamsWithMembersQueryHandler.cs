using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Colaboradix.Application.Common.UseCases;
using Dapper;

namespace Colaboradix.Application.UseCases.Queries.GetActiveTeams
{
    public class GetActiveTeamsQueryHandler : IQueryHandler<GetActiveTeamsQuery, IEnumerable<ActiveTeamsDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetActiveTeamsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory ?? throw new ArgumentNullException(nameof(sqlConnectionFactory));
        }

        public async Task<IEnumerable<ActiveTeamsDto>> Handle(GetActiveTeamsQuery request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            return await connection.QueryAsync<ActiveTeamsDto>(@"
                SELECT id, name, description
                    FROM Teams
                WHERE Active = true");
        }

    }
}
