using Framework.Core.Common.Contracts;
using Framework.Core.Common.Models;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Core.Common.Abstracts
{
    public class AbstractDomainService : IDomainService
    {
        protected List<IDomainEvent> _getDomainEvent(List<DomainEventEntity> domainEventEntityList)
        {
            List<IDomainEvent> @events = new List<IDomainEvent>();

            foreach (var domainEventEntity in domainEventEntityList)
            {
                @events.Add(DomainEventInfoSingleton.GetInstance().GetDomainInstance(domainEventEntity));
            }

            return events.OrderBy(p => p.Id).ToList();
        }
    }
}