using Framework.Core.Common.Models;
using Framework.Core.Markers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Core.Common.Contracts
{
    public interface IAbstractDomainRepository<TEntity, TEntityId, TEntityEvent, TDomain> : IScopedDependency
           where TEntityId : class
           where TEntity : AuditableDbEntity<TEntityId>
           where TDomain : AggregateRoot<TEntityId>
           where TEntityEvent : DomainEventEntity<TEntityId>
    {
        Task<List<TEntityEvent>> GetAllEvents(string id, CancellationToken cancellationToken);

        Task<List<TEntityEvent>> GetAllLastSnapShotEvents(string id, CancellationToken cancellationToken);

        Task<bool> IsExists(string id, CancellationToken cancellationToken);

        Task<int> SaveChangeAsync(TDomain domain, CancellationToken cancellationToken);
    }

    public abstract class AbstractDomainRepository<TEntity, TEntityId, TEntityEvent, TDomain> : IScopedDependency
       where TEntityId : class
       where TEntity : AuditableDbEntity<TEntityId>
       where TDomain : AggregateRoot<TEntityId>
       where TEntityEvent : DomainEventEntity<TEntityId>
    {
        private readonly DbContext _dbContext;

        public AbstractDomainRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TEntityEvent>> GetAllEvents(TEntityId id, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<TEntityEvent>()
                .Where(p => p.AggregateId.Equals(id))
                .OrderBy(p => p.Id)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<List<TEntityEvent>> GetAllLastSnapShotEvents(TEntityId id, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<TEntityEvent>()
               .Where(p => p.AggregateId.Equals(id) && p.SnapShot == _dbContext.Set<TEntityEvent>().Max(r => r.SnapShot))
               .OrderBy(p => p.Id)
               .ToListAsync(cancellationToken)
               .ConfigureAwait(false);

            var records = await _dbContext.Set<TEntity>()
   .Where(p => p.Id.Equals(id))
   .Include(p=>p.TEn)
   .OrderBy(p => p.Id)
   .ToListAsync(cancellationToken)
   .ConfigureAwait(false);
        }

        private Task<bool> IsExists(string id, CancellationToken cancellationToken)
        {
        }

        private Task<int> SaveChangeAsync(TDomain domain, CancellationToken cancellationToken)
        {
        }
    }
}