using Colaboradix.Application.Common.Models;
using Colaboradix.Application.Common.UseCases;
using Colaboradix.Domain.Repositories;
using Colaboradix.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Colaboradix.Application.UseCases.Commands.CreateUser
{
    public class CreateUserService : ICommandService<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserService(IUserRepository userRepository)
        {
            _userRepository = userRepository 
                ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.SaveAsync(new User()
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                Name = request.Name
            });

            return Result.Success();
        }
    }

}
