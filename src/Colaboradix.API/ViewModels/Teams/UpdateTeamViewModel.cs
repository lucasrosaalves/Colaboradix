using Colaboradix.Application.Commands.Teams.UpdateTeam;
using System;

namespace Colaboradix.API.ViewModels.Teams
{
    public record UpdateTeamViewModel(Guid Id, string Name, string Description, bool Active)
    {
        public UpdateTeamCommand ToCommand()
        {
            return new UpdateTeamCommand(Id, Name, Description, Active);
        }
    }
}
