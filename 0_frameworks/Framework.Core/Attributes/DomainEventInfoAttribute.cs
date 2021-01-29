using System;

namespace Framework.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class DomainEventInfoAttribute : Attribute
    {
        public DomainEventInfoAttribute(string uniqueTypeId,
            string aggregate , 
            string name ,
            ushort version = 1,
            bool isDeleteEvent = false,
            bool isSystemGenerated = false,
            bool isSnapShotEvent = false)
        {
            UniqueTypeId = uniqueTypeId;
            Name = name;
            Aggregate = aggregate;
            Version = version;
            DeleteEvent = isDeleteEvent;
            SnapShot = isSnapShotEvent;
            SystemGenerated = isSystemGenerated;
        }

        public string Name { get; }
        public string Aggregate { get; }
        public string UniqueTypeId { get; }
        public ushort Version { get; }
        public bool SystemGenerated { get; }
        public bool DeleteEvent { get; }
        public bool SnapShot { get; }
    }
}