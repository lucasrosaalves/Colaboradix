using MediatR;

namespace Colaboradix.Application.Common.Queries
{
    public interface IQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IQuery<TResponse>
    {
    }
}
