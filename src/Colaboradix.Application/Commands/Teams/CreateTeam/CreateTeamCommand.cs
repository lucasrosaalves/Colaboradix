using Colaboradix.Application.Common.Commands;

namespace Colaboradix.Application.Commands.Teams.CreateTeam
{
    public record CreateTeamCommand(string Name, string Description) : ICommand;
}
