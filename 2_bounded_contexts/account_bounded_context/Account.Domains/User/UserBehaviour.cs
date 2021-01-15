using Account.Domains.Common.Contracts;
using System.Collections.Generic;

namespace Account.Domains.User
{
    public partial class User
    {
        public User(IList<IDomainEvent> events) : base("")
        {
            foreach (var @event in events)
            {
                base._mutate(@event);
            }
        }
    }
}