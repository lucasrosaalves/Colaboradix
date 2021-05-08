using Colaboradix.Application.Common.Commands;
using Colaboradix.Application.Common.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Threading.Tasks;

namespace Colaboradix.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();

        protected async Task<IActionResult> QueryAsync<T>(IQuery<T> query, CancellationToken cancellationToken = default)
        {
            if(query is null) { return BadRequest(); }

            try
            {
                return Ok(await Mediator.Send(query, cancellationToken));
            }
            catch
            {
                return NoContent();
            }
        }

        protected async Task<IActionResult> CommandAsync(ICommand command, CancellationToken cancellationToken = default)
        {
            if (command is null) { return BadRequest(); }

            var result = await Mediator.Send(command, cancellationToken);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return NoContent();
        }
    }
}
