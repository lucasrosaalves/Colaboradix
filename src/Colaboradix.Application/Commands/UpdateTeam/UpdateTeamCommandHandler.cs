using System;
using System.Threading;
using System.Threading.Tasks;
using Colaboradix.Application.Common.Commands;
using Colaboradix.Application.Common.Interfaces;
using Colaboradix.Application.Common.Models;
using Colaboradix.Domain.Repositories;

namespace Colaboradix.Application.Commands.UpdateTeam
{
    public class UpdateTeamCommandHandler : ICommandHandler<UpdateTeamCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITeamRepository _teamRepository;

        public UpdateTeamCommandHandler(IUnitOfWork unitOfWork, ITeamRepository teamRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _teamRepository = teamRepository ?? throw new ArgumentNullException(nameof(teamRepository));
        }

        public async Task<ApplicationResponse> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
        {
            var team = await _teamRepository.GetByIdAsync(request.Id);

            if(team is null)
            {
                return ApplicationResponse.Failure($"Team does not exist. Id {request.Id}");
            }

            if (await _teamRepository.ExistsBySameNameAndDifferentIdAsync(request.Name, request.Id))
            {
                return ApplicationResponse.Failure("This name is already in use");
            }

            team.SetName(request.Name);
            team.SetDescription(request.Description);
            team.SetActive(request.Active);

            _teamRepository.Update(team);

            await _unitOfWork.CommitAsync();

            return ApplicationResponse.Success();
        }
    }
}
