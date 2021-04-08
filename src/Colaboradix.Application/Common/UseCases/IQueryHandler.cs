using MediatR;

namespace Colaboradix.Application.Common.UseCases
{
    public interface IQueryService<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IQuery<TResponse>
    {
    }
}
