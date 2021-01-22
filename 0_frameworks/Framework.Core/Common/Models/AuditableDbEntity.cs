using Framework.Core.Common.Contracts;
using System.Collections.Generic;

namespace Framework.Core.Common.Models
{
    public abstract class AuditableDbEntity<TIdentity, TEventEntity> : IEntity
        where TIdentity : class
        where TEventEntity : DomainEventEntity<TIdentity>
    {
        public AuditableDbEntity()
        {
            this.Events = new List<TEventEntity>();
        }

        public TIdentity Id { get; set; }
        public long CreationTime { get; set; }
        public string CreatorUser { get; set; }
        public long LastUpdateTime { get; set; }
        public string UpdaterUser { get; set; }
        public short LastSnapShot { get; set; }

        public List<TEventEntity> Events { get; set; }
    }
}