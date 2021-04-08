using Colaboradix.Application.Common.Models;
using MediatR;

namespace Colaboradix.Application.Common.UseCases
{
    public interface ICommandHandler<T> : IRequestHandler<T, ApplicationResponse> where T : ICommand
    {

    }
}
