using Colaboradix.Application.Common.Commands;
using System;

namespace Colaboradix.Application.Commands.Teams.CreateMember
{
    public record CreateMemberCommand(string Name, string Email, Guid TeamId) : ICommand;
}
