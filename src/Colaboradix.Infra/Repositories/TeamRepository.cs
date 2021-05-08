using System;
using System.Threading.Tasks;
using Colaboradix.Domain.Entities;
using Colaboradix.Domain.Repositories;
using Colaboradix.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Colaboradix.Infra.Repositories
{
    internal class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public TeamRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext
                ?? throw new ArgumentNullException(nameof(applicationDbContext));
        }

        public async Task<Team> GetByIdAsync(Guid id)
        {
            return await _applicationDbContext.Teams.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _applicationDbContext.Teams.AnyAsync(t => t.Name == name);
        }

        public async Task<bool> ExistsBySameNameAndDifferentIdAsync(string name, Guid id)
        {
            return await _applicationDbContext.Teams.AnyAsync(t => t.Name == name && t.Id != id);
        }

        public async Task AddAsync(Team team)
        {
            await _applicationDbContext.Teams.AddAsync(team);
        }

        public void Update(Team team)
        {
            _applicationDbContext.Teams.Update(team);
        }

        public async Task<bool> MemberExistsAsync(string email)
        {
            return await _applicationDbContext.Members.AnyAsync(member => member.Email == email);
        }

        public async Task<Member> GetMemberAsync(Guid memberId, Guid teamId)
        {
            return await _applicationDbContext.Members.FirstOrDefaultAsync(member => member.Id == memberId && member.TeamId == teamId);
        }
        public async Task<Member> GetMemberAsync(string email)
        {
            return await _applicationDbContext.Members.FirstOrDefaultAsync(member => member.Email == email);
        }

        public async Task AddMemberAsync(Member member)
        {
            await _applicationDbContext.Members.AddAsync(member);
        }

        public void UpdateMember(Member member)
        {
            _applicationDbContext.Members.Update(member);
        }
    }
}
