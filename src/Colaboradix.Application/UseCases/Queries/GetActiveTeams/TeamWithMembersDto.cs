using System;

namespace Colaboradix.Application.UseCases.Queries.GetActiveTeams
{
    public class ActiveTeamsDto
    {
       public Guid Id { get; set; }
        public string Name { get; set; }
        public string Descritpion { get; set; }
    }
}
