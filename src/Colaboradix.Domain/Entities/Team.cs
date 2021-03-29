using Colaboradix.Domain.Common;
using System;
using System.Collections.Generic;

namespace Colaboradix.Domain.Entities
{
    public class Team : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        public Guid UserAdminId { get; set; }
        public User UserAdmin { get; set; }

        public IList<User> Users { get; set; }

        public bool Active { get; set; }
    }
}
