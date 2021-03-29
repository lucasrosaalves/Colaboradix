using Colaboradix.Domain.Common;
using System;

namespace Colaboradix.Domain.Entities
{
    public class Cycle : IEntity
    {
        public Guid Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
