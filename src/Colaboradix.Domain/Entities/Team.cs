using Colaboradix.Domain.Common;
using Colaboradix.Domain.Exceptions;
using System;
using System.Collections.Generic;

namespace Colaboradix.Domain.Entities
{
    public class Team : IEntity
    {
        private List<Member> _members;
        private List<Cycle> _cycles;

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }

        public IReadOnlyList<Member> Members => _members;
        public IReadOnlyList<Cycle> Cycles => _cycles;


        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException("Name can not be null or empty");
            }

            Name = name;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }

        public void SetActive(bool active)
        {
            Active = active;
        }

        public Team(string name, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Active = true;
            _members = new();
            _cycles = new();
        }

        protected Team()
        {
        }
    }
}
