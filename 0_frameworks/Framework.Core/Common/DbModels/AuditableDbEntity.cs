namespace Framework.Core.Common.DbModels
{
    public abstract class AuditableDbEntity
    {
        public string Id { get; set; }
        public long CreationTime { get; set; }
        public string CreatorUserId { get; set; }
        public long LastUpdateTime { get; set; }
        public string UpdaterUserId { get; set; }
    }
}