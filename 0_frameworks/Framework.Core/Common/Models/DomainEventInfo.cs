using System;

namespace Framework.Core.Common.Models
{
    public class DomainEventInfo
    {
        public string Name { get; set; }
        public string Aggregate { get; set; }
        public string UniqueTypeId { get; set; }
        public ushort Version { get; set; }
        public bool SystemGenerated { get; set; }
        public bool DeleteEvent { get; set; }
        public bool SnapShot { get; set; }
        public Type CurrentType { get; set; }
    }
}