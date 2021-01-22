using Framework.Core.Common.Contracts;

namespace Framework.Core.Common.Models
{
    public class DomainEventEntity : IEntity
    {
        protected DomainEventEntity()
        {
            this.SnapShot = false;
            this.SnapShotCount = 1;
        }

        public DomainEventEntity(string aggregateId, long Id, ushort snapShotCount) : this()
        {
            this.AggregateId = aggregateId;
            this.Id = Id;
            this.SnapShotCount = snapShotCount;
        }

        public long Id { get; private set; }
        public string AggregateId { get; private set; }
        public string Data { get; private set; }
        public string UniqueTypeId { get; protected set; }

        // add userId and Ip
       
        public bool SnapShot { get; protected set; }
        public ushort SnapShotCount { get; protected set; }

        //public void Set_Id(long id)
        //{
        //    this.Id = id;
        //}

        //public void Set_AggregateId(string aggregateId)
        //{
        //    this.AggregateId = aggregateId;
        //}

        public void Set_EventData(string @event)
        {
            this.Data = @event;
        }

        public void Set_UniqueId(string uniqueTypeId)
        {
            this.UniqueTypeId = uniqueTypeId;
        }

        //public void Set_SnapShotCounter(ushort counter)
        //{
        //    this.SnapShotCount = counter;
        //}

        public void Set_IsSnapShot(bool isSnapShot)
        {
            this.SnapShot = isSnapShot;
        }
    }
}