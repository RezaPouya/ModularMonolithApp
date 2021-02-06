using Framework.Core.Common.DbModels;
using Framework.Core.Common.Models;

namespace Framework.Core.Common.Builders
{
    public sealed class DomainEventDbEntityBuilder
    {
        private string _aggregateId;
        private string _data;
        private long _id;
        private bool _deleteEvent;
        private string _creatorUser;
        private string _ip;

        public DomainEventDbEntity Build()
        {
            var model = new DomainEventDbEntity(_aggregateId, _id);
            model.Set_EventData(_data);
            return model;
        }

        public DomainEventDbEntityBuilder Id(long id)
        {
            this._id = id;
            return this;
        }

        public DomainEventDbEntityBuilder AggregateId(string aggregateId)
        {
            this._aggregateId = aggregateId;
            return this;
        }

        public DomainEventDbEntityBuilder Set_Creator(string creatorUser, string ip)
        {
            this._creatorUser = creatorUser;
            this._ip = ip;
            return this;
        }

        public DomainEventDbEntityBuilder EventData(string @event)
        {
            this._data = @event;
            return this;
        }

        public DomainEventDbEntityBuilder DeleteEvent(bool deletedEvent)
        {
            this._deleteEvent = deletedEvent;
            return this;
        }
    }
}