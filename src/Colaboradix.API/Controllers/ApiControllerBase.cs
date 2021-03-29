using Colaboradix.Application.Common.UseCases;
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

            var validation = query.IsValid();

            if (!validation.Succeeded)
            { 
                return BadRequest(validation.Errors);
            }

            return Ok(await Mediator.Send(query, cancellationToken));
        }

        protected async Task<IActionResult> CommandAsync(ICommand command, CancellationToken cancellationToken = default)
        {
            if (command is null) { return BadRequest(); }

            var validation = command.IsValid();

            if (!validation.Succeeded)
            {
                return BadRequest(validation.Errors);
            }

            var result = await Mediator.Send(command, cancellationToken);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return NoContent();
        }
    }
}
