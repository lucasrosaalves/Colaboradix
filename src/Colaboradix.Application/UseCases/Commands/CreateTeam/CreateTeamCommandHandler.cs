using System.Threading;
using System.Threading.Tasks;
using Colaboradix.Application.Common.Models;
using Colaboradix.Application.Common.UseCases;

namespace Colaboradix.Application.UseCases.Commands.CreateTeam
{
    public class CreateTeamCommandHandler : ICommandHandler<CreateTeamCommand>
    {
        public Task<Result> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
