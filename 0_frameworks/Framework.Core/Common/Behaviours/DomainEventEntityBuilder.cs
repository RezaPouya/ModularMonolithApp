using Framework.Core.Common.Models;

namespace Framework.Core.Common.Behaviours
{
    public sealed class DomainEventEntityBuilder
    {
        private string _aggregateId;
        private string _data;
        private long _id;
        private bool _deleteEvent;
        private string _creatorUser;
        private string _ip;

        public DomainEventEntity Build()
        {
            var model = new DomainEventEntity(_aggregateId, _id);
            model.Set_EventData(_data);
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

        public DomainEventEntityBuilder DeleteEvent(bool deletedEvent)
        {
            this._deleteEvent = deletedEvent;
            return this;
        }
    }
}