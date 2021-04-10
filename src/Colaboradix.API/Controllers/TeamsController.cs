using Colaboradix.Application.Commands.CreateTeam;
using Colaboradix.Application.Commands.UpdateTeam;
using Colaboradix.Application.Queries.GetActiveTeams;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Colaboradix.API.Controllers
{
    public class TeamsController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> CreateTeam([FromBody] CreateTeamCommand command, CancellationToken cancellationToken)
        {
            return await CommandAsync(command, cancellationToken);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateTeam([FromBody] UpdateTeamCommand command, CancellationToken cancellationToken)
        {
            return await CommandAsync(command, cancellationToken);
        }

        [HttpGet("GetAllWithMembers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            return await QueryAsync(new GetTeamsWithMembersQuery(), cancellationToken);
        }
    }
}
