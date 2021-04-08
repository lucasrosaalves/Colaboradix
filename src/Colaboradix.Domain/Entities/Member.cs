using Colaboradix.Domain.Common;
using Colaboradix.Domain.Enumerations;
using System;
using System.Collections.Generic;

namespace Colaboradix.Domain.Entities
{
    public class Member : IEntity
    {
        private List<Feedback> _receivedFeedbacks;
        private List<Feedback> _submittedFeedbacks;

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public MemberType Type { get; private set; }
        public bool Active { get; private set; }

        public Guid? TeamId { get; private set; }
        public Team Team { get; private set; }

        public IReadOnlyList<Feedback> ReceivedFeedbacks => _receivedFeedbacks;
        public IReadOnlyList<Feedback> SubmittedFeedbacks => _submittedFeedbacks;

        public Member(string name, string email, MemberType type, Guid? teamId = null)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Type = type;
            TeamId = teamId;
            Active = true;
            _receivedFeedbacks = new();
            _submittedFeedbacks = new();
        }

        protected Member()
        {

        }
    }
}
