using Framework.Core.Common.Contracts;
using Framework.Core.Extensions;
using System;

namespace Framework.Core.Common.Models
{
    public class DomainEvent : IDomainEvent
    {
        protected DomainEvent(string aggregateId)
        {
            this.Id = DateTimeOffset.UtcNow.Ticks;
            this.AggregateId = aggregateId;
            this.SavedInPersistenceMedia = false;
            _setDomainEventInfo();
        }

        public string AggregateId { get; protected set; }
        public long Id { get; protected set; }
        public string UniqueTypeId { get; protected set; }
        public ushort Version { get; protected set; }
        public bool SystemGenerated { get; protected set; }
        public bool DeleteEvent { get; protected set; }
        public bool SavedInPersistenceMedia { get; protected set; }
        public string UserId { get; protected set; }
        public string Ip { get; protected set; }

        public void SetSavedInPersistenceMedia()
        {
            this.SavedInPersistenceMedia = true;
        }

        public void SetActor(string userId, string ip)
        {
            this.UserId = userId;
            this.Ip = ip;
        }

        private void _setDomainEventInfo()
        {
            var info = this.GetEventInfo();

            this.UniqueTypeId = info.UniqueTypeId;
            this.Version = info.Version;
            this.SystemGenerated = info.SystemGenerated;
            this.DeleteEvent = info.DeleteEvent;
        }
    }
}