using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Colaboradix.Application.Common.UseCases;

namespace Colaboradix.Application.UseCases.Queries.GetActiveTeams
{
    public class GetTeamsWithMembersQueryHandler : IQueryHandler<GetTeamsWithMembersQuery, IEnumerable<TeamWithMembersDto>>
    {
        private readonly ISqlQueryService _queryService;

        public GetTeamsWithMembersQueryHandler(ISqlQueryService queryService)
        {
            _queryService = queryService ?? throw new ArgumentNullException(nameof(queryService));
        }

        public async Task<IEnumerable<TeamWithMembersDto>> Handle(GetTeamsWithMembersQuery request, CancellationToken cancellationToken)
        {

            string query = @"
                    SELECT
                        *
                    FROM Teams t
                      LEFT JOIN Members m ON
                        m.team_id = t.id  ";

            var teamsDictionary = new Dictionary<Guid, TeamWithMembersDto>();

            return await _queryService.QueryAsync<TeamWithMembersDto, TeamWithMembersDto.MemberDto, TeamWithMembersDto>(
                    query, (team, member) =>
                    {

                        if (!teamsDictionary.TryGetValue(team.Id, out var teamsEntry))
                        {
                            teamsEntry = team;
                            teamsEntry.Members = new List<TeamWithMembersDto.MemberDto>();
                            teamsDictionary.Add(teamsEntry.Id, teamsEntry);
                        }

                        teamsEntry.Members.Add(member);
                        return teamsEntry;
                    });
        }

    }
}
