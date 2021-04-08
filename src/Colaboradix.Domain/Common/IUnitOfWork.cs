using System.Threading.Tasks;

namespace Colaboradix.Domain.Common
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
