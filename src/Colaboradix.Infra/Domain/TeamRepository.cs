using System.Linq;
using System.Threading.Tasks;
using Colaboradix.Domain.Entities;
using Colaboradix.Domain.Repositories;
using Colaboradix.Infra.Data.Domain.Common;

namespace Colaboradix.Infra.Data.Domain.Repositories
{
    internal class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(ApplicationDbContext applicationDbContext)
            :base (applicationDbContext)
        {
        }

        public async Task AddAsync(Team team)
        {
            await ApplicationDbContext.Teams.AddAsync(team);
        }

        public bool ExistsByName(string name)
        {
            return ApplicationDbContext.Teams.Any(t => t.Name == name);
        }
    }
}
