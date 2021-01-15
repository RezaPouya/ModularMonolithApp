using System;

namespace Account.Domains.Common.Contracts
{
    public abstract record DomainEvent : IDomainEvent
    {
        protected DomainEvent(string aggregateId , bool isSavedInPresistenceMedia = true)
        {
            AggregateId = aggregateId;
            Id = DateTimeOffset.UtcNow.Ticks;
            IsSavedInPresistenceMedia = isSavedInPresistenceMedia;

        }

        public string AggregateId { get; protected set; }
        public long Id { get; protected set; }
        public bool IsSavedInPresistenceMedia { get; protected set; }

    }
}