using System.Threading.Tasks;

namespace Colaboradix.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
