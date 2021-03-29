using Colaboradix.Application.Common.Models;
using Colaboradix.Application.Common.UseCases;
using Colaboradix.Domain.Repositories;
using Colaboradix.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
using Colaboradix.Domain.Common;
using Colaboradix.Application.Common.Errors;
using Colaboradix.Domain.Enumerations;

namespace Colaboradix.Application.UseCases.Commands.CreateUser
{
    public class CreateUserService : ICommandService<CreateUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public CreateUserService(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.BeginTransaction();

            if (await _userRepository.CheckIfExistsByEmailAsync(request.Email))
            {
                return Result.Failure(ApplicationErrors.UserAlreadyExists);
            }

            await _userRepository.SaveAsync(new User()
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                Name = request.Name,
                Password = request.Password,
                ProjectId = request.ProjectId,
                TeamId = request.TeamId,
                Type = UserType.Regular.Id,
                Active = false,
            });

            _unitOfWork.Commit();

            return Result.Success();
        }
    }

}
