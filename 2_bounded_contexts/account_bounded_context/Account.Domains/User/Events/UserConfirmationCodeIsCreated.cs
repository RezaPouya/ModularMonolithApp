using Account.Domains.Commons;
using Framework.Core.Attributes;
using Framework.Core.Common.Models;
using System;

namespace Account.Domains.User.Events
{
    [DomainEventInfo(name: nameof(UserCreatedEvent),
      aggregate: EventTypeUniqueIdConstants.UserAggregate.AGGREGATE_NAME,
      uniqueTypeId: EventTypeUniqueIdConstants.UserAggregate.USER_CONFIRMATION_CODE_IS_CREATED,
      isSystemGenerated:true)]
    public class UserConfirmationCodeIsCreated : DomainEvent
    {
        public UserConfirmationCodeIsCreated(string aggregateRootId,
            string code,
            DateTimeOffset expirationCode) : base(aggregateRootId)
        {
            Code = code;
            ExpirationCode = expirationCode;
        }

        public string Code { get; private set; }
        public DateTimeOffset ExpirationCode { get; private set; }
    }
}