using Framework.Core.Common.Models;
using System;

namespace Account.Domains.User.Events
{
    public sealed record UserCreatedEvent : DomainEvent
    {
        public UserCreatedEvent(string aggregateRootId,
            string userName,
            string passwordHash,
            string email,
            DateTimeOffset creationDate) : base(aggregateRootId)
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