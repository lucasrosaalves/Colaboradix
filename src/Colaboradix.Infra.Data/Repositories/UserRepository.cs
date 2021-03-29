using Colaboradix.Domain.Entities;
using Colaboradix.Domain.Repositories;
using Colaboradix.Infra.Data.Common;
using Colaboradix.Infra.Data.Context;
using System.Threading.Tasks;

namespace Colaboradix.Infra.Data.Repositories
{
    internal class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository(DbSession session) 
            : base(session)
        {
        }

        public async Task SaveAsync(User user)
        {
            string sql = @"
                INSERT INTO public.user
                    (UserId, Name, Email,Password, Type ,Active,ProjectId, TeamId)
                VALUES(@Id, @Name, @Email,@Password,@Type ,@Active,@ProjectId, @TeamId)";

            await ExecuteAsync(sql, user);
        }
    }
}
