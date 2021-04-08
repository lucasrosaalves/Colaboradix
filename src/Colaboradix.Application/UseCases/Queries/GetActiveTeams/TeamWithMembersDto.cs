using System;
using System.Collections.Generic;

namespace Colaboradix.Application.UseCases.Queries.GetActiveTeams
{
    public class TeamWithMembersDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<MemberDto> Members { get; set; } = new();

        public class MemberDto
        {
            public Guid Id { get; private set; }
            public string Name { get; private set; }
            public string Email { get; private set; }
            public byte Type { get; private set; }
            public bool Active { get; private set; }
        }
    }
}
