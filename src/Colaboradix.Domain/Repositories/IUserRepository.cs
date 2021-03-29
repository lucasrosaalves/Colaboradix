using Colaboradix.Domain.Entities;
using System.Threading.Tasks;

namespace Colaboradix.Domain.Repositories
{
    public interface IUserRepository
    {
        public Task SaveAsync(User user);
    }
}
