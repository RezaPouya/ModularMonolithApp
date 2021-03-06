﻿using Framework.Core.Common.DbModels;
using Framework.Core.Common.Models;
using Framework.Core.Markers;
using Framework.Core.Singletons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Common.Contracts
{
    public interface IDomainService : IScopedDependency
    {
        protected List<IDomainEvent> _getDomainEvent(List<DomainEventDbEntity> domainEventEntityList)
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
