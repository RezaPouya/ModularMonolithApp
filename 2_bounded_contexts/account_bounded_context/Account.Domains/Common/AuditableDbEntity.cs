using Account.Domains.Common.Contracts;
using Framework.Core.Commons;

namespace Framework.Core.Commons
{
    public abstract class AuditableDbEntity : IEntity
    {
        public long CreationTime { get; set; }
        public string CreatorUser { get; set; }
        public long LastUpdateTime { get; set; }
        public string UpdaterUser { get; set; }
    }
}