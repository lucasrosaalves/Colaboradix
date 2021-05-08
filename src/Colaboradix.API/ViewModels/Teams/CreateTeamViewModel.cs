using Colaboradix.Application.Commands.Teams.CreateTeam;

namespace Colaboradix.API.ViewModels.Teams
{
    public record CreateTeamViewModel(string Name, string Description)
    {
        public CreateTeamCommand ToCommand()
        {
            return new CreateTeamCommand(Name, Description);
        }
    }
}
