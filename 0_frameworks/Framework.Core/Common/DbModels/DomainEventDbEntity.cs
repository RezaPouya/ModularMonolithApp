using Framework.Core.Common.Contracts;
using Framework.Core.Markers;

namespace Framework.Core.Common.DbModels
{
    public class DomainEventDbEntity : IDbEntity
    {
        public DomainEventDbEntity()
        {
        }

        public DomainEventDbEntity(string aggregateId, long Id) : this()
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

        public int SnapshotId { get; set; }
        public bool IsSnapShotEvent { get; set; }
    }
}