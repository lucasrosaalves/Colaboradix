using Colaboradix.Domain.Common;
using System;
using System.Collections.Generic;

namespace Colaboradix.Domain.Entities
{
    public class Cycle : IEntity
    {
        private List<Feedback> _feedbacks;

        public Guid Id { get; private set; }
        public DateTime From { get; private set; }
        public DateTime To { get; private set; }

        public Guid TeamId { get; private set; }
        public Team Team { get; private set; }

        public IReadOnlyList<Feedback> Feedbacks => _feedbacks;

        public Cycle(DateTime from, DateTime to, Guid teamId)
        {
            Id = Guid.NewGuid();
            From = from;
            To = to;
            TeamId = teamId;
            _feedbacks = new();
        }

        protected Cycle()
        {

        }
    }
}
