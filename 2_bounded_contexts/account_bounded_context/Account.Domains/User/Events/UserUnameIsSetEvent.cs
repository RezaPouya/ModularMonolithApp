using Account.Domains.Common.Contracts;
using System;

namespace Account.Domains.User.Events
{
    public record UserUnameIsSetEvent : DomainEvent
    {
        public UserUnameIsSetEvent(
            string aggregateId,
            DateTimeOffset lastUpdate,
            string userName,
            string passwordHash) : base(aggregateId)
        {
            UserName = userName;
            PasswordHash = passwordHash;
            LastUpdate = lastUpdate;
        }

        public string UserName { get; private set; }
        public string PasswordHash { get; private set; }
        public DateTimeOffset LastUpdate { get; private set; }
    }
}