using System.Threading.Tasks;
using Colaboradix.Domain.Entities;
using Colaboradix.Domain.Repositories;
using Colaboradix.Infra.Data.Context;

namespace Colaboradix.Infra.Data.Repositories
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
    }
}
