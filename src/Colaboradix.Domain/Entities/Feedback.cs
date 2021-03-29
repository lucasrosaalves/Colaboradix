using Colaboradix.Domain.Common;
using System;

namespace Colaboradix.Domain.Entities
{
    public class Feedback : IEntity
    {
        public Guid Id { get; set; }
        public Guid FromId { get; set; }
        public User From { get; set; }

        public Guid ToId { get; set; }
        public User To { get; set; }

        public string Message { get; set; }
        public int Quantity { get; set; }

        public Guid CycleId { get; set; }
        public Cycle Cycle { get; set; }
    }
}
