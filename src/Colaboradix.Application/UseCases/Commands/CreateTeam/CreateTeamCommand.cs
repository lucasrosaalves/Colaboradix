using Colaboradix.Application.Common.UseCases;

namespace Colaboradix.Application.UseCases.Commands.CreateTeam
{
    public record CreateTeamCommand(string Name, string Description) : ICommand;
}
