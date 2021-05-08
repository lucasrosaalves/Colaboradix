using System;
using System.Threading.Tasks;
using Colaboradix.Domain.Common;
using Colaboradix.Domain.Entities;

namespace Colaboradix.Domain.Repositories
{
    public interface ITeamRepository : IRepository<Team>
    {
        Task<Team> GetByIdAsync(Guid id);
        Task<bool> ExistsByNameAsync(string name);
        Task<bool> ExistsBySameNameAndDifferentIdAsync(string name, Guid id);
        Task AddAsync(Team team);
        void Update(Team team);
        Task<bool> MemberExistsAsync(string email);
        Task<Member> GetMemberAsync(Guid memberId, Guid teamId);
        Task<Member> GetMemberAsync(string email);
        Task AddMemberAsync(Member member);
        void UpdateMember(Member member);
    }
}
