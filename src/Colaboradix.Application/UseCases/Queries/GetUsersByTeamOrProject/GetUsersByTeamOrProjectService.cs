using Colaboradix.Application.Common.UseCases;
using Colaboradix.Domain.Dtos;
using Colaboradix.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Colaboradix.Application.UseCases.Queries.GetUsersByTeamOrProject
{
    public class GetUsersByTeamOrProjectService : IQueryService<GetUsersByProjectOrTeamQuery, IEnumerable<UserDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersByTeamOrProjectService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public Task<IEnumerable<UserDto>> Handle(GetUsersByProjectOrTeamQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
