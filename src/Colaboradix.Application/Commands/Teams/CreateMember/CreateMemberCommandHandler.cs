using Colaboradix.Application.Common.Commands;
using Colaboradix.Application.Common.Interfaces;
using Colaboradix.Application.Common.Models;
using Colaboradix.Domain.Entities;
using Colaboradix.Domain.Enumerations;
using Colaboradix.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Colaboradix.Application.Commands.Teams.CreateMember
{
    public class CreateMemberCommandHandler : ICommandHandler<CreateMemberCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITeamRepository _teamRepository;

        public CreateMemberCommandHandler(IUnitOfWork unitOfWork, ITeamRepository teamRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _teamRepository = teamRepository ?? throw new ArgumentNullException(nameof(teamRepository));
        }

        public async Task<ApplicationResponse> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            if(await _teamRepository.MemberExistsAsync(request.Email))
            {
                return ApplicationResponse.Failure("Member already exists");
            }

            var member = new Member(request.Name, request.Email, MemberType.Regular, request.TeamId);

            await _teamRepository.AddMemberAsync(member);

            await _unitOfWork.CommitAsync();

            return ApplicationResponse.Success();
        }     
    }
}
