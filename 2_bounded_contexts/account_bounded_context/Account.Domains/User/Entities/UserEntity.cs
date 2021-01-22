using Framework.Core.Common.Contracts;
using Framework.Core.Common.Models;

namespace Account.Domains.User.Entities
{
    public sealed class UserEntity : AuditableDbEntity<string, UserEventEntity>, IEntity
    {
        public UserEntity() : base()
        {
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public bool CellphoneConfirmed { get; set; }
        public bool EmailConfirmed { get; set; }
        public int EventCount { get; set; }
        public short SnapShotCount { get; set; }
    }
}