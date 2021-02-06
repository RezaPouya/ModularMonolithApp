using Framework.Core.Common.DbModels;
using Framework.Core.Common.Models;
using Framework.Core.Markers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Core.Common.Contracts
{
    public interface IAbstractDomainRepository<TDomain> : IScopedDependency where TDomain : AggregateRoot
    {
        public Task<List<DomainEventDbEntity>> GetEvents(string id, CancellationToken cancellationToken);

        public Task<bool> IsExists(string id, CancellationToken cancellationToken);

        public Task<int> SaveChangeAsync(TDomain domain, CancellationToken cancellationToken);
    }
}