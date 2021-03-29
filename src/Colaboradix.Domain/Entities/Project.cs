using Colaboradix.Domain.Common;
using System;
using System.Collections.Generic;

namespace Colaboradix.Domain.Entities
{
    public class Project : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid UserAdminId { get; set; }
        public User UserAdmin { get; set; }
        
        public IList<Team> Teams { get; set; }

        public bool Active { get; set; }
    }
}
