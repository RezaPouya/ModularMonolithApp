using Framework.Core.Common.Contracts;
using System;
using System.Text.Json;

namespace Framework.Core.Common.Models
{
    public class DomainEventEntity<TDomainIdentity> : IEntity where TDomainIdentity : class
    {
        public DomainEventEntity()
        {
            this.Deleted = false;
            this.DeleteEvent = false;
            this.SubscribedEvent = false;
            this.SystemEvent = false;
            this.SystemEvent = false;
            this.Published = false;
        }

        public long Id { get; private set; }
        public TDomainIdentity AggregateId { get; private set; }
        public long OccurredAt { get; private set; }
        public string CreatorUser { get; private set; }
        public string Ip { get; private set; }
        public string Data { get; private set; }
        public int TypeId { get; private set; }
        public string Type { get; private set; }
        public short SnapShot { get; private set; }
        public bool Deleted { get; private set; }
        public bool DeleteEvent { get; private set; }
        public bool SubscribedEvent { get; private set; }
        public bool SystemEvent { get; private set; }
        public bool Published { get; private set; }
        public long PublishDateTime { get; private set; }
        public bool IsSnapShotEvent { get; private set; }
        public short Version { get; private set; }

        public void Set_Id(long id)
        {
            this.Id = id;
        }

        public void Set_AggregateId(TDomainIdentity aggregateId)
        {
            this.AggregateId = aggregateId;
        }

        public void Set_OccurredAt(DateTimeOffset occurredAt)
        {
            this.OccurredAt = occurredAt.UtcDateTime.Ticks;
        }

        public void Set_Creator(string creatorUser, string ip)
        {
            this.CreatorUser = creatorUser;
            this.Ip = ip;
        }

        public void Set_EventData(IDomainEvent @event)
        {
            this.Data = JsonSerializer.Serialize(@event);
            // JsonSerializer.Deserialize<MyType>("{"Message":"Hello Again."}")
        }

        public void Set_Type(int typeId, string type)
        {
            this.TypeId = typeId;
            this.Type = type;
        }

        public void Set_SnapShot(short snapShot)
        {
            this.SnapShot = snapShot;
        }

        public void Set_Deleted(bool deleted)
        {
            this.Deleted = deleted;
        }

        public void Set_DeleteEvent(bool deletedEvent)
        {
            this.DeleteEvent = deletedEvent;
        }

        public void Set_SubscribedEvent(bool subscribed)
        {
            this.SubscribedEvent = subscribed;
        }

        public void Set_SystemEvent(bool isSystemEvent)
        {
            this.SystemEvent = isSystemEvent;
        }

        public void Set_Published(bool published)
        {
            this.Published = published;
        }

        public void Set_PublishDateTime(DateTimeOffset publishDateTime)
        {
            this.PublishDateTime = publishDateTime.UtcDateTime.Ticks;
        }

        public void Set_SnapShotEvent(bool snapShotEvent)
        {
            this.IsSnapShotEvent = snapShotEvent;
        }

        public void Set_Version(short version)
        {
            this.Version = version;
        }
    }
}