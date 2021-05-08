using Colaboradix.API.ViewModels.Teams;
using Colaboradix.Application.Queries.GetActiveTeams;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Colaboradix.API.Controllers
{
    public class TeamsController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateTeam([FromBody] CreateTeamViewModel request, CancellationToken cancellationToken)
        {
            return await CommandAsync(request.ToCommand(), cancellationToken);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeam([FromBody] UpdateTeamViewModel request, CancellationToken cancellationToken)
        {
            return await CommandAsync(request.ToCommand(), cancellationToken);
        }

        [HttpPost("{teamId}/Members")]
        public async Task<IActionResult> CreateMember([FromRoute] Guid teamId, [FromBody] CreateMemberViewModel request, CancellationToken cancellationToken)
        {
            return await CommandAsync(request.ToCommand(teamId), cancellationToken);
        }

        [HttpPut("{teamId}/Members/{memberId}")]
        public async Task<IActionResult> UpdateMember([FromRoute] Guid teamId, [FromRoute] Guid memberId, [FromBody] UpdateMemberViewModel request, CancellationToken cancellationToken)
        {
            return await CommandAsync(request.ToCommand(teamId, memberId), cancellationToken);
        }

        [HttpGet("GetAllWithMembers")]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            return await QueryAsync(new GetTeamsWithMembersQuery(), cancellationToken);
        }
    }
}
