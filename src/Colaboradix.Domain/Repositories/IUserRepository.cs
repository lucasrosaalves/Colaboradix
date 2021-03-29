using Colaboradix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colaboradix.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetByProjectAsync(Guid projectId);
        Task<IEnumerable<User>> GetByTeamAsync(Guid teamId);
        Task<bool> CheckIfExistsByEmailAsync(string email);
        public Task SaveAsync(User user);
    }
}
