using Framework.Core.Common.Models;
using System;

namespace Framework.Core.Common.Behaviours
{
    public sealed class DomainEventEntityBuilder
    {
        private string _aggregateId;
        private string _creatorUser;
        private string _data;
        private bool _deleteEvent;
        private long _id;
        private string _ip;
        private bool _isSnapShotEvent;
        private ushort _lastSnapShot;

        public DomainEventEntity Build()
        {
            var model = new DomainEventEntity(_aggregateId, _id, _lastSnapShot);

            model.Set_EventData(_data);

            model.Set_IsSnapShot(_isSnapShotEvent);
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

        public DomainEventEntityBuilder EventData(string @event)
        {
            this._data = @event;
            return this;
        }

        public DomainEventEntityBuilder Type(int typeId, string type)
        {
            this._typeId = typeId;
            this._type = type;
            return this;
        }

        public DomainEventEntityBuilder SnapShot(ushort snapShot)
        {
            this._lastSnapShot = snapShot;
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