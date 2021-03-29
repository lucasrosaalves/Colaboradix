using Colaboradix.Application.Common.Models;
using MediatR;

namespace Colaboradix.Application.Common.UseCases
{
    public interface ICommandService<T> : IRequestHandler<T, Result> where T : ICommand
    {

    }
}
