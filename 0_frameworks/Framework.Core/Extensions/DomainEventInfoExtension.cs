using Framework.Core.Attributes;
using Framework.Core.Common.Models;
using System;
using System.Linq;

namespace Framework.Core.Extensions
{
    public static class DomainEventInfoExtension
    {
        public static DomainEventInfoAttribute GetEventInfo(this DomainEvent @event)
        {
            var customeAttributes = @event.GetType().GetCustomAttributes(typeof(DomainEventInfoAttribute), false);

            if (customeAttributes.Length <= 0)
                throw new NullReferenceException($"Event Info : there is not Domain Info Attribute for '{nameof(@event)}'");

            if (customeAttributes.Length > 1)
                throw new Exception($"Event Info : there is more than Domain Info Attribute for '{nameof(@event)}'");

            return (DomainEventInfoAttribute)customeAttributes.FirstOrDefault();
        }
    }
}