using Framework.Core.Common.Contracts;

namespace Framework.Core.Common.Models
{
    public class DomainEventEntity : IEntity
    {
        public DomainEventEntity()
        {
        }

        public DomainEventEntity(string aggregateId, long Id) : this()
        {
            this.AggregateId = aggregateId;
            this.Id = Id;
        }

        public long Id { get; private set; }
        public string AggregateId { get; private set; }
        public string Data { get; private set; }
        public string UniqueTypeId { get; protected set; }

        public void Set_EventData(string @event)
        {
            this.Data = @event;
        }

        public void Set_UniqueId(string uniqueTypeId)
        {
            this.UniqueTypeId = uniqueTypeId;
        }
    }
}