using System;
using Colaboradix.Application.Common.Commands;

namespace Colaboradix.Application.Commands.UpdateTeam
{
    public record UpdateTeamCommand(Guid Id, string Name, string Description, bool Active) : ICommand;
}
