using Framework.Core.Common.Contracts;
using System;

namespace Framework.Core.Common.Models
{
    public abstract record DomainEvent : IDomainEvent
    {
        protected DomainEvent(string aggregateId, bool isSavedInPresistenceMedia = true)
        {
            AggregateId = aggregateId;
            Id = DateTimeOffset.UtcNow.Ticks;
            SavedInPersistenceMedia = isSavedInPresistenceMedia;
        }

        public string AggregateId { get; protected set; }
        public long Id { get; protected set; }
        public bool SavedInPersistenceMedia { get; protected set; }

        public void SetSavedInPersistenceMedia()
        {
            this.SavedInPersistenceMedia = true;
        }
    }
}