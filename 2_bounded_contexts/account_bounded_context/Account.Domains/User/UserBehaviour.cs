using Account.Domains.User.Events;
using Account.Domains.User.ValueObjects;
using Framework.Core.Common.Contracts;
using System.Collections.Generic;

namespace Account.Domains.User
{
    public partial class UserDomain
    {
        public UserDomain(IList<IDomainEvent> events) : base("")
        {
            foreach (var @event in events)
            {
                base._mutate(@event);
            }
        }

        protected void When(UserCreatedEvent @event)
        {
            this.Identity = @event.AggregateId;

            this.AccountInfo = new UserAccountInfo(@event.UserName,
                @event.PasswordHash, 
                @event.CreationDate);

            this.Email = new UserEmail(@event.Email);
        }
    }
}