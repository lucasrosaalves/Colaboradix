using System;
using System.Threading;
using System.Threading.Tasks;
using Colaboradix.Application.Common.Models;
using Colaboradix.Application.Common.UseCases;
using Colaboradix.Domain.Common;
using Colaboradix.Domain.Entities;
using Colaboradix.Domain.Repositories;

namespace Colaboradix.Application.UseCases.Commands.CreateTeam
{
    public class CreateTeamCommandHandler : ICommandHandler<CreateTeamCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITeamRepository _teamRepository;

        public CreateTeamCommandHandler(IUnitOfWork unitOfWork, ITeamRepository teamRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _teamRepository = teamRepository ?? throw new ArgumentNullException(nameof(teamRepository));
        }

        public async Task<ApplicationResponse> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            if (_teamRepository.ExistsByName(request.Name))
            {
                return ApplicationResponse.Failure("This name is already in use");
            }

            var team = new Team(request.Name, request.Description);

            await _teamRepository.AddAsync(team);

            await _unitOfWork.CommitAsync();

            return ApplicationResponse.Success();
        }
    }
}
