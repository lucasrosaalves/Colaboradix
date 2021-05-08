using Colaboradix.Application.Commands.Teams.CreateMember;
using System;

namespace Colaboradix.API.ViewModels.Teams
{
    public record CreateMemberViewModel(string Name, string Email)
    {
        public CreateMemberCommand ToCommand(Guid teamId)
        {
            return new CreateMemberCommand(Name, Email, teamId);
        }
    }
}
