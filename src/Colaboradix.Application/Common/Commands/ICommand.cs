using Colaboradix.Application.Common.Models;
using MediatR;

namespace Colaboradix.Application.Common.Commands
{
    public interface ICommand : IRequest<ApplicationResponse>
    {
    }
}
