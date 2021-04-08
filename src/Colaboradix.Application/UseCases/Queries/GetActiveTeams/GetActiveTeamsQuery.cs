using System.Collections.Generic;
using Colaboradix.Application.Common.UseCases;

namespace Colaboradix.Application.UseCases.Queries.GetActiveTeams
{
    public record GetActiveTeamsQuery : IQuery<List<ActiveTeamsDto>>;
}
