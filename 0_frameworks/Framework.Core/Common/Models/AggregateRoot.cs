using Framework.Core.Common.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Core.Common.Models
{
    public abstract class AggregateRoot
    {
        public AggregateRoot(string identity)
        {
            _eventQueue = new List<IDomainEvent>();
            this.Identity = identity;
        }

        public List<IDomainEvent> _eventQueue { get; set; }
        public string Identity { get; protected set; }
        public ushort SnapShotCounter { get; protected set; }

        public void SetSnapShotCounter(ushort snapShotCounter)
        {
            this.SnapShotCounter = snapShotCounter;
        }

        public void IncreaseSnapShotCounter() => this.SnapShotCounter++;

        public void Apply(IDomainEvent @event)
        {
            _record(@event);
            _mutate(@event);
        }

        public void Apply(List<IDomainEvent> events)
        {
            events.OrderBy(p => p.Id).ToList().ForEach(Apply);
        }

        protected void _mutate(IDomainEvent @event)
        {
            ((dynamic)this).When((dynamic)@event);
        }

        protected void _record(IDomainEvent @event)
        {
            this._eventQueue.Add(@event);
        }

        public abstract bool SaveChange();

        public abstract Task<bool> SaveChangeAsync();

    }
}