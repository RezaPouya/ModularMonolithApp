using Framework.Core.Common.Contracts;
using Framework.Core.Common.Models;
using System;

namespace Framework.Core.Common.Behaviours
{
    public sealed class DomainEventEntityBuilder
    {
        private string _aggregateId;
        private string _creatorUser;
        private IDomainEvent _data;
        private bool _deleted;
        private bool _deleteEvent;
        private long _id;
        private string _ip;
        private bool _isSnapShotEvent;
        private short _lastSnapShot;
        private DateTimeOffset _occurredAt;
        private DateTimeOffset _publishDateTime;
        private bool _published;
        private bool _subscribedEvent;
        private bool _systemEvent;
        private string _type;
        private int _typeId;
        private short _version;

        public DomainEventEntity Build()
        {
            var model = new DomainEventEntity();
            model.Set_Id(_id);
            model.Set_AggregateId(_aggregateId);
            model.Set_Type(_typeId, _type);
            model.Set_Creator(_creatorUser, _ip);
            model.Set_EventData(_data);
            model.Set_DeleteEvent(_deleteEvent);
            model.Set_Deleted(_deleted);
            model.Set_OccurredAt(_occurredAt);
            model.Set_SnapShot(_lastSnapShot);
            model.Set_Version(_version);
            model.Set_SnapShotEvent(_isSnapShotEvent);
            model.Set_Deleted(_deleted);
            model.Set_Published(_published);
            model.Set_SystemEvent(_systemEvent);
            model.Set_PublishDateTime(_publishDateTime);
            model.Set_SubscribedEvent(_subscribedEvent);
            return model;
        }

        public DomainEventEntityBuilder Id(long id)
        {
            this._id = id;
            return this;
        }

        public DomainEventEntityBuilder AggregateId(string aggregateId)
        {
            this._aggregateId = aggregateId;
            return this;
        }

        public DomainEventEntityBuilder OccurredAt(DateTimeOffset occurredAt)
        {
            this._occurredAt = occurredAt;
            return this;
        }

        public DomainEventEntityBuilder Set_Creator(string creatorUser, string ip)
        {
            this._creatorUser = creatorUser;
            this._ip = ip;
            return this;
        }

        public DomainEventEntityBuilder EventData(IDomainEvent @event)
        {
            this._data = @event;
            // JsonSerializer.Deserialize<MyType>("{"Message":"Hello Again."}")
            return this;
        }

        public DomainEventEntityBuilder Type(int typeId, string type)
        {
            this._typeId = typeId;
            this._type = type;
            return this;
        }

        public DomainEventEntityBuilder SnapShot(short snapShot)
        {
            this._lastSnapShot = snapShot;
            return this;
        }

        public DomainEventEntityBuilder Deleted(bool deleted)
        {
            this._deleted = deleted;
            return this;
        }

        public DomainEventEntityBuilder DeleteEvent(bool deletedEvent)
        {
            this._deleteEvent = deletedEvent;
            return this;
        }

        public DomainEventEntityBuilder SubscribedEvent(bool subscribed)
        {
            this._subscribedEvent = subscribed;
            return this;
        }

        public DomainEventEntityBuilder SystemEvent(bool isSystemEvent)
        {
            this._systemEvent = isSystemEvent;
            return this;
        }

        public DomainEventEntityBuilder Published(bool published)
        {
            this._published = published;
            return this;
        }

        public DomainEventEntityBuilder PublishDateTime(DateTimeOffset publishDateTime)
        {
            this._publishDateTime = publishDateTime;
            return this;
        }

        public DomainEventEntityBuilder SnapShotEvent(bool snapShotEvent)
        {
            this._isSnapShotEvent = snapShotEvent;
            return this;
        }

        public DomainEventEntityBuilder Version(short version)
        {
            this._version = version;
            return this;
        }
    }
}