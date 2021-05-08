using Colaboradix.Application.Common.Commands;
using System;

namespace Colaboradix.Application.Commands.Teams.UpdateMember
{
    public record UpdateMemberCommand(Guid Id, string Name, byte TypeId, bool Active, Guid TeamId, Guid? NewTeamId = null) : ICommand;
}
