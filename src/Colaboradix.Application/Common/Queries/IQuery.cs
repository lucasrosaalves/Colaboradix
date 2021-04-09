using MediatR;

namespace Colaboradix.Application.Common.Queries
{
    public interface IQuery<out T> : IRequest<T>
    {
    }
}
