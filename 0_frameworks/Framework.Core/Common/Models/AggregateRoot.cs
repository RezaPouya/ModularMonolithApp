using Framework.Core.Common.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Core.Common.Models
{
    public abstract class AggregateRoot<T> where T : class
    {
        public AggregateRoot(T identity)
        {
            _eventQueue = new List<IDomainEvent>();
            this.Identity = identity;
        }

        protected List<IDomainEvent> _eventQueue { get; set; }
        public T Identity { get; protected set; }

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