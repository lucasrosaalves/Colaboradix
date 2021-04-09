using Colaboradix.Application.Common.Models;
using MediatR;

namespace Colaboradix.Application.Common.Commands
{
    public interface ICommandHandler<T> : IRequestHandler<T, ApplicationResponse> where T : ICommand
    {

    }
}
