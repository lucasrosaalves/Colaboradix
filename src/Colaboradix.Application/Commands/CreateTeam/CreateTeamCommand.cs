using Colaboradix.Application.Common.Commands;

namespace Colaboradix.Application.Commands.CreateTeam
{
    public record CreateTeamCommand(string Name, string Description) : ICommand;
}
