using Account.Domains.User.Events;
using Account.Domains.User.ValueObjects;
using Framework.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace Account.Domains.User
{
    public partial class UserDomain
    {
        public static string GenerateId()
        {
            return ($"user_{DateTimeOffset.UtcNow.Ticks}_{Guid.NewGuid().GetHashCode().ToString("x")}").ToLower();
        }

        public UserDomain(IList<IDomainEvent> events) : base("")
        {
            foreach (var @event in events)
            {
                base._mutate(@event);
            }
        }

        public void When(UserCreatedEvent @event)
        {
            this.Identity = @event.AggregateId;

            this.AccountInfo = new UserAccountInfo(@event.UserName,
                @event.PasswordHash,
                @event.CreationDate);

            this.Email = new UserEmail(@event.Email);
        }

        public void When(UserNameIsChangedEvent @event)
        {
            this.Identity = @event.AggregateId;

            this.AccountInfo = new UserAccountInfo(@event.UserName,
                this.AccountInfo.PasswordHash,
                @event.LastUpdate);
        }

        public void When(UserConfirmationCodeIsCreated @event)
        {
            this.Identity = @event.AggregateId;

            this.UserEmailConfirmation = new UserEmailConfirmation(@event.Code, @event.ExpirationCode);
        }
    }
}