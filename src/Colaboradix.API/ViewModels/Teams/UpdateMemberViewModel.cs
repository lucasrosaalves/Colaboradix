using Colaboradix.Application.Commands.Teams.UpdateMember;
using System;

namespace Colaboradix.API.ViewModels.Teams
{
    public record UpdateMemberViewModel(string Name, byte TypeId, bool Active, Guid? NewTeamId = null)
    {
        public UpdateMemberCommand ToCommand(Guid teamId, Guid memberId)
        {
            return new UpdateMemberCommand(memberId, Name, TypeId, Active, teamId, NewTeamId);
        }
    }
}
