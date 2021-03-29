using Colaboradix.Application.Common.Models;
using MediatR;

namespace Colaboradix.Application.Common.UseCases
{
    public interface IQuery<out T> : IRequest<T>
    {
        public Result IsValid();
    }
}
