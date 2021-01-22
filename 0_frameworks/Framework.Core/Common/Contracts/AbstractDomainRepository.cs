using Framework.Core.Common.Models;
using Framework.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Core.Common.Contracts
{
    public abstract class AbstractDomainRepository<TDomain, TEntityEvent> : IAbstractDomainRepository<TDomain>
        where TEntityEvent : DomainEventEntity, new()
        where TDomain : AggregateRoot
    {
        private readonly DbContext _dbContext;
        protected readonly ICurrentUserInfo _currentUserInfo;
        public AbstractDomainRepository(DbContext dbContext, ICurrentUserInfo currentUserInfo)
        {
            _dbContext = dbContext;
            _currentUserInfo = currentUserInfo;
        }

        public async Task<List<DomainEventEntity>> GetAllEvents(string id, CancellationToken cancellationToken)
        {
            var records = await _dbContext.Set<TEntityEvent>()
              .Where(p => p.AggregateId.Equals(id))
              .OrderBy(p => p.Id)
              .ToListAsync(cancellationToken).ConfigureAwait(false);

            return records as List<DomainEventEntity>;
        }

        public async Task<List<DomainEventEntity>> GetAllLastSnapShotEvents(string id, CancellationToken cancellationToken)
        {
            var records = await _dbContext.Set<TEntityEvent>()
               .Where(p =>
                    p.AggregateId.Equals(id) &&
                    p.SnapShot == _dbContext.Set<TEntityEvent>().Max(r => r.SnapShot)
                 )
               .OrderBy(p => p.Id)
               .ToListAsync(cancellationToken).ConfigureAwait(false);

            return records as List<DomainEventEntity>;
        }

        public Task<bool> IsExists(string id, CancellationToken cancellationToken)
        {
            return _dbContext.Set<TEntityEvent>().AnyAsync(p => p.AggregateId.Equals(id), cancellationToken);
            ;
        }

        public async Task<int> SaveChangeAsync(TDomain domain, CancellationToken cancellationToken)
        {
            var notPersistedEvents = domain._eventQueue
                .Where(p => p.SavedInPersistenceMedia == false)
                .OrderBy(p => p.Id)
                .ToList();

            var eventToBeSavedList = new List<TEntityEvent>();

            var serializer = new JsonSerializerHelper();

            foreach (var @event in notPersistedEvents)
            {
                var eventEntity = new DomainEventEntity(@event.AggregateId, @event.Id, @event.SnapShotCount);
                eventEntity.Set_IsSnapShot(@event.SnapShot);
                eventEntity.Set_UniqueId(@event.UniqueTypeId);
                eventEntity.Set_EventData(serializer.Serialize(@event));
                eventToBeSavedList.Add((TEntityEvent)eventEntity);
                if(@event.SystemGenerated == false)
                {
                    eventEntity.Set_EventData
                }
            }

            _dbContext.Set<TEntityEvent>().AddRange(eventToBeSavedList);

            await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return eventToBeSavedList.Count();
        }
    }
}