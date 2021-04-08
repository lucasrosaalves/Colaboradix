using MediatR;

namespace Colaboradix.Application.Common.UseCases
{
    public interface IQuery<out T> : IRequest<T>
    {
    }
}
