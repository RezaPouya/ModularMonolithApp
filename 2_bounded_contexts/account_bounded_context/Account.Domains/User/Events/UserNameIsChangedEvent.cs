using Account.Domains.Commons;
using Framework.Core.Attributes;
using Framework.Core.Common.Models;
using System;

namespace Account.Domains.User.Events
{
    [DomainEventInfo(name: nameof(UserCreatedEvent),
       aggregate: EventTypeUniqueIdConstants.UserAggregate.AGGREGATE_NAME,
       uniqueTypeId: EventTypeUniqueIdConstants.UserAggregate.USER_NAME_IS_CHANGED)]
    public class UserNameIsChangedEvent : DomainEvent
    {
        public UserNameIsChangedEvent(
            string aggregateId,
            DateTimeOffset lastUpdate,
            string userName) : base(aggregateId)
        {
            UserName = userName;
            LastUpdate = lastUpdate;
        }

        public string UserName { get; private set; }
        public DateTimeOffset LastUpdate { get; private set; }
    }
}