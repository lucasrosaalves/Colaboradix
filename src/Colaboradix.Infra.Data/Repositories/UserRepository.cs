using Colaboradix.Domain.Entities;
using Colaboradix.Domain.Repositories;
using Colaboradix.Infra.Data.Common;
using Colaboradix.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colaboradix.Infra.Data.Repositories
{
    internal class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository(DbSession session) 
            : base(session)
        {
        }
        public async Task<IEnumerable<User>> GetByProjectAsync(Guid projectId)
        {
            string sql = @"
                SELECT 1 FROM public.user
                 WHERE Email = @Email";

            return await QueryAsync<User>(sql, new
            {
                ProjectId = projectId
            });
        }

        public async Task<IEnumerable<User>> GetByTeamAsync(Guid teamId)
        {
            string sql = @"
                SELECT 1 FROM public.user
                 WHERE Email = @Email";

            return await QueryAsync<User>(sql, new
            {
                TeamId = teamId
            });
        }

        public async Task<bool> CheckIfExistsByEmailAsync(string email)
        {
            string sql = @"
                SELECT 1 FROM public.user
                 WHERE Email = @Email";

            return await ExecuteScalarAsync<bool>(sql, new 
            { 
                Email = email
            });
        }

        public async Task SaveAsync(User user)
        {
            string sql = @"
                INSERT INTO public.user
                    (user_id, Name, email,password, type ,active,project_id, team_id)
                VALUES(@Id, @Name, @Email,@Password,@Type ,@Active,@ProjectId, @TeamId)";

            await ExecuteAsync(sql, user);
        }
    }
}
