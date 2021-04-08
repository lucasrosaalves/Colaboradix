using System.Threading.Tasks;
using Colaboradix.Domain.Common;

namespace Colaboradix.Domain.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
