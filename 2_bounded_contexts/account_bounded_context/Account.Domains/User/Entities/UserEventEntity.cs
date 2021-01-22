using Framework.Core.Common.Models;

namespace Account.Domains.User.Entities
{
    public class UserEventEntity : DomainEventEntity<string>
    {
        public UserEntity User { get; set; }
    }
}