using Colaboradix.Application.Common.Commands;
using Colaboradix.Application.Common.Interfaces;
using Colaboradix.Application.Common.Models;
using Colaboradix.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Colaboradix.Application.Commands.Teams.UpdateMember
{
    public class UpdateMemberCommandHandler : ICommandHandler<UpdateMemberCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITeamRepository _teamRepository;

        public UpdateMemberCommandHandler(IUnitOfWork unitOfWork, ITeamRepository teamRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _teamRepository = teamRepository ?? throw new ArgumentNullException(nameof(teamRepository));
        }

        public async Task<ApplicationResponse> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {
            var member = await _teamRepository.GetMemberAsync(request.Id, request.TeamId);

            if(member is null)
            {
                return ApplicationResponse.Failure("Member does not exists");
            }

            member.Update(request.Name, request.TypeId, request.Active, request.NewTeamId ?? request.TeamId);

            _teamRepository.UpdateMember(member);

            await _unitOfWork.CommitAsync();

            return ApplicationResponse.Success();
        }     
    }
}
