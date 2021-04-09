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

        public Task<ApplicationResponse> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
