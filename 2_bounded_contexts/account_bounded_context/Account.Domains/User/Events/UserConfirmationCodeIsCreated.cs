using Framework.Core.Common.Models;
using System;

namespace Account.Domains.User.Events
{
    public sealed record UserConfirmationCodeIsCreated : DomainEvent
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