using System;
using Colaboradix.Application.Common.Commands;

namespace Colaboradix.Application.Commands.Teams.UpdateTeam
{
    public record UpdateTeamCommand(Guid Id, string Name, string Description, bool Active) : ICommand;
}
