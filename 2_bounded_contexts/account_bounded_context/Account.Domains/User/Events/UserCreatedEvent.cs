using Account.Domains.Commons;
using Framework.Core.Attributes;
using Framework.Core.Common.Models;
using System;

namespace Account.Domains.User.Events
{
    [DomainEventInfo( name: nameof(UserCreatedEvent) ,
        aggregate: EventTypeUniqueIdConstants.UserAggregate.AGGREGATE_NAME ,
        uniqueTypeId: EventTypeUniqueIdConstants.UserAggregate.USER_CREATED_EVENT )]
    public class UserCreatedEvent : DomainEvent
    {
        public UserCreatedEvent(string aggregateRootId,
            string userName,
            string passwordHash,
            string email,
            DateTimeOffset creationDate ) : base(aggregateRootId)
        {
            UserName = userName;
            PasswordHash = passwordHash;
            Email = email;
            CreationDate = creationDate;
        }

        public string UserName { get; private set; }
        public string PasswordHash { get; private set; }
        public string Email { get; private set; }
        public DateTimeOffset CreationDate { get; private set; }
    }
}