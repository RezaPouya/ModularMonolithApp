using Framework.Core.Common.DbModels;
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
        where TEntityEvent : DomainEventDbEntity, new()
        where TDomain : AggregateRoot
    {
        private readonly DbContext _dbContext;
        protected readonly ICurrentUserInfo _currentUserInfo;

        public AbstractDomainRepository(DbContext dbContext, ICurrentUserInfo currentUserInfo)
        {
            _dbContext = dbContext;
            _currentUserInfo = currentUserInfo;
        }

        public async Task<List<DomainEventDbEntity>> GetEvents(string aggregateId, CancellationToken cancellationToken)
        {
            var records = await _dbContext.Set<TEntityEvent>()
              .Where(p => p.AggregateId.Equals(aggregateId))
              .OrderBy(p => p.Id)
              .ToListAsync(cancellationToken)
              .ConfigureAwait(false);

            return records as List<DomainEventDbEntity>;
        }

        public Task<bool> IsExists(string id, CancellationToken cancellationToken)
        {
            return _dbContext.Set<TEntityEvent>().AnyAsync(p => p.AggregateId.Equals(id), cancellationToken);
        }

        public async Task<int> SaveChangeAsync(TDomain domain, CancellationToken cancellationToken)
        {
            var notPersistedEvents = domain._eventQueue
                .Where(p => p.SavedInPersistenceMedia == false)
                .OrderBy(p => p.Id)
                .ToList();

            var eventToBeSavedList = new List<TEntityEvent>();

            foreach (var @event in notPersistedEvents)
            {
                var eventDbEntity = new DomainEventDbEntity(@event.AggregateId, @event.Id);
                eventDbEntity.Set_UniqueId(@event.UniqueTypeId);
                eventDbEntity.Set_EventData(JsonSerializerHelper.Serialize(@event));
                eventToBeSavedList.Add((TEntityEvent)eventDbEntity);
                eventDbEntity.Set_EventData(JsonSerializerHelper.Serialize(@event));
            }

            _dbContext.Set<TEntityEvent>().AddRange(eventToBeSavedList);

            await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            notPersistedEvents.ForEach(p =>
            {
                p.SetSavedInPersistenceMedia();
            });

            return eventToBeSavedList.Count();
        }
    }
}