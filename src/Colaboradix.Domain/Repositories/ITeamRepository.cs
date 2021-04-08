using System.Threading.Tasks;
using Colaboradix.Domain.Common;
using Colaboradix.Domain.Entities;

namespace Colaboradix.Domain.Repositories
{
    public interface ITeamRepository : IRepository<Team>
    {
        public Task AddAsync(Team team);
        public bool ExistsByName(string name);
    }
}
