using Colaboradix.Domain.Enumerations;
using System;

namespace Colaboradix.Domain.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public UserType Type { get; set; }
        public ProjectDto Project { get; set; }
        public TeamDto Team { get; set; }
    }
}
