using Colaboradix.Application.Common.Models;
using MediatR;

namespace Colaboradix.Application.Common.UseCases
{
    public interface ICommand : IRequest<Result>
    {
    }
}
