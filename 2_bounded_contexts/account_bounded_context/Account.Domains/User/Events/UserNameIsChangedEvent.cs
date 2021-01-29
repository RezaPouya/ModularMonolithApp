using Framework.Core.Common.Models;
using System;

namespace Account.Domains.User.Events
{
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