using Framework.Core.Attributes;
using System;
using System.Reflection;

namespace Framework.Core.AttributesExtensions
{
    public static class DomainEventInfoAttributeExtension
    {
        public static string UniqueTypeId(this Enum @enum)
        {
            Attribute attr = _getDomainEventInfoAttribute(@enum);
            DomainEventInfoAttribute attrInstance = _getDomainEventInfoInstance(@enum, attr);

            if (string.IsNullOrEmpty(attrInstance.UniqueTypeId))
                throw new NullReferenceException($"The domain info attribute field , UniqueTypeId is not set for '{@enum}'");

            return attrInstance.UniqueTypeId;
        }

        public static string Domain(this Enum @enum)
        {
            Attribute attr = _getDomainEventInfoAttribute(@enum);
            DomainEventInfoAttribute attrInstance = _getDomainEventInfoInstance(@enum, attr);

            if (string.IsNullOrEmpty(attrInstance.Name))
                throw new NullReferenceException($"The domain info attribute field , Domain is not set for '{@enum}'");

            return attrInstance.Name;
        }

        public static bool GetIsDeletedEvent(this Enum @enum)
        {
            Attribute attr = _getDomainEventInfoAttribute(@enum);
            DomainEventInfoAttribute attrInstance = _getDomainEventInfoInstance(@enum, attr);
            return attrInstance.DeleteEvent;
        }

        public static bool GetIsSnapShotEvent(this Enum @enum)
        {
            Attribute attr = _getDomainEventInfoAttribute(@enum);
            DomainEventInfoAttribute attrInstance = _getDomainEventInfoInstance(@enum, attr);
            return attrInstance.SnapShot;
        }

        public static bool GetIsSystemGeneratedEvent(this Enum @enum)
        {
            Attribute attr = _getDomainEventInfoAttribute(@enum);
            DomainEventInfoAttribute attrInstance = _getDomainEventInfoInstance(@enum, attr);
            return attrInstance.SystemGenerated;
        }

        public static ushort GetVersionEvent(this Enum @enum)
        {
            Attribute attr = _getDomainEventInfoAttribute(@enum);
            DomainEventInfoAttribute attrInstance = _getDomainEventInfoInstance(@enum, attr);
            return attrInstance.Version;
        }

        private static DomainEventInfoAttribute _getDomainEventInfoInstance(Enum @enum, Attribute attr)
        {
            var attrInstance = (DomainEventInfoAttribute)attr;

            if (attrInstance == null)
                throw new NullReferenceException($"The domain info attribute is not set for '{@enum}'");

            return attrInstance;
        }

        private static Attribute _getDomainEventInfoAttribute(Enum @enum)
        {
            MemberInfo[] memInfo = (@enum.GetType()).GetMember(@enum.ToString());

            if (memInfo == null || memInfo.Length <= 0)
            {
                throw new NullReferenceException($"The domain info attribute attribute is not set for '{@enum}'");
            }

            var attr = memInfo[0].GetCustomAttribute(typeof(DomainEventInfoAttribute), false);

            if (attr is null)
                throw new NullReferenceException($"The domain info attribute attribute is not set for '{@enum}'");

            return attr;
        }
    }
}