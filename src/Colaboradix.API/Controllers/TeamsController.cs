using Colaboradix.Application.UseCases.Commands.CreateTeam;
using Colaboradix.Application.UseCases.Queries.GetActiveTeams;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Colaboradix.API.Controllers
{
    public class TeamsController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateTeam([FromBody] CreateTeamCommand command, CancellationToken cancellationToken)
        {
            return await CommandAsync(command, cancellationToken);
        }

        [HttpGet("Actives")]
        public async Task<IActionResult> GetActiveTeams(CancellationToken cancellationToken)
        {
            return await QueryAsync(new GetActiveTeamsQuery(), cancellationToken);
        }
    }
}
