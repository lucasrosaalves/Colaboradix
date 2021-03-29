using MediatR;

namespace Colaboradix.Application.Common.UseCases
{
    public interface IQueryService<TResponse> : IRequestHandler<IQuery<TResponse>, TResponse>
    {
    }
}
