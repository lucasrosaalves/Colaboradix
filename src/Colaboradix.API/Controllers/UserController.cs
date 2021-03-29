using Colaboradix.Application.UseCases.Commands.CreateUser;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Colaboradix.API.Controllers
{
    public class UserController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            return await CommandAsync(command);
        }
    }
}
