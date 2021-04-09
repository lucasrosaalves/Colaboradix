using Colaboradix.API.Attributes;
using Colaboradix.Application.Commands.CreateTeam;
using Colaboradix.Application.Commands.UpdateTeam;
using Colaboradix.Application.Queries.GetActiveTeams;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Colaboradix.API.Controllers
{
    public class TeamsController : ApiControllerBase
    {
        [HttpPost]
        [CommandProducesResponseType]
        public async Task<IActionResult> CreateTeam([FromBody] CreateTeamCommand command, CancellationToken cancellationToken)
        {
            return await CommandAsync(command, cancellationToken);
        }

        [HttpPut]
        [CommandProducesResponseType]
        public async Task<IActionResult> UpdateTeam([FromBody] UpdateTeamCommand command, CancellationToken cancellationToken)
        {
            return await CommandAsync(command, cancellationToken);
        }

        [HttpGet("GetAllWithMembers")]
        [QueryProducesResponseType]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            return await QueryAsync(new GetTeamsWithMembersQuery(), cancellationToken);
        }
    }
}
