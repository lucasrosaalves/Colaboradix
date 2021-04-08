using Colaboradix.Domain.Common;
using System;

namespace Colaboradix.Domain.Entities
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Type { get; set; }
        public bool Active { get; set; }

        public Guid? ProjectId { get; set; }
        public Project Project { get; set; }

        public Guid? TeamId { get; set; }
        public Team Team { get; set; }
    }
}
