using System.Collections.Generic;
using Colaboradix.Application.Common.Queries;

namespace Colaboradix.Application.Queries.GetActiveTeams
{
    public record GetTeamsWithMembersQuery : IQuery<IEnumerable<TeamWithMembersDto>>;
}
