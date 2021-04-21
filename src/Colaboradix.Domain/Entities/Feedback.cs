using Colaboradix.Domain.Common;
using System;

namespace Colaboradix.Domain.Entities
{
    public class Feedback : IEntity
    {
        public const byte MaxQuantity = 3;

        public Guid Id { get; private set; }
        public string Message { get; private set; }
        public byte Quantity { get; private set; }

        public Guid SenderId { get; private set; }
        public Member Sender { get; set; }

        public Guid ReceiverId { get; private set; }
        public Member Receiver { get; private set; }

        public Guid CycleId { get; private set; }
        public Cycle Cycle { get; private set; }

        public Feedback(string message, byte quantity, Guid senderId, Guid receiverId, Guid cycleId)
        {
            Id = Guid.NewGuid();
            Message = message;
            Quantity = quantity;
            SenderId = senderId;
            ReceiverId = receiverId;
            CycleId = cycleId;
        }

        protected Feedback()
        {

        }
    }
}
